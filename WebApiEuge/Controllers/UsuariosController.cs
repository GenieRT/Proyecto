using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;
using WebApiVersion3.Services;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IRegistro RegistroCU;
        private ILogin LoginCU;
        private readonly IEmailService emailService;

        public UsuarioController(IRegistro registroCU, ILogin loginCU, IEmailService emailService)
        {
            RegistroCU = registroCU;
            LoginCU = loginCU;
            this.emailService = emailService;
        }

        [HttpPut("ActualizarContraseña")]
        public ActionResult ActualizarContraseña([FromBody] ActualizarContrasenaDTO datos)
        {
            try
            {
                // Validar los datos recibidos
                if (string.IsNullOrWhiteSpace(datos.Email) || string.IsNullOrWhiteSpace(datos.NuevaContraseña))
                {
                    return BadRequest("El email y la nueva contraseña son requeridos.");
                }

              
                var usuario = RegistroCU.BuscarUsuarioPorEmail(datos.Email);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                //entidad usuario
                var usuarioEnt = RegistroCU.BuscarUsuarioEntidadPorEmail(datos.Email);
                // asignacion temporal
                usuarioEnt.Contraseña = datos.NuevaContraseña;

                try
                {
                    usuarioEnt.Validar(); //valida la contrasena en una etapa temprana
                }
                catch (Exception ex)
                {
                    return BadRequest($"Contraseña inválida: {ex.Message}");
                }

                // Actualizar la contraseña
                RegistroCU.ActualizarContraseña(datos.Email, datos.NuevaContraseña);


                return Ok("Proceso exitoso. Por favor, revisa tu correo para confirmar el cambio de contraseña.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error internoOO: {ex.Message}");
            }
        }




        [HttpGet("ConfirmarCambio")]
        public ActionResult ConfirmarCambio(string email, string token)
        {
            try
            {
                // Validar que los parámetros no estén vacíos
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                {
                    return BadRequest("El email y el token son requeridos.");
                }

                // Buscar al usuario por email //capaz borrar luego
                var usuario = RegistroCU.BuscarUsuarioPorEmail(email);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }



                //buscar entidad usuario para no exponer las pass en el dto
                var usuarioEnt = RegistroCU.BuscarUsuarioEntidadPorEmail(email);

                // Validar el token
                if (usuarioEnt.ConfirmationToken != token)
                {
                    return BadRequest("Token inválido o expirado.");
                }

                // Confirmar el cambio de contraseña
                usuarioEnt.SetPassword(usuarioEnt.TemporalPassword);
                usuarioEnt.TemporalPassword = null; // Limpiar la contraseña temporal
                usuarioEnt.ConfirmationToken = null; // Limpiar el token

                RegistroCU.ActualizarUsuario(usuarioEnt);

                return Ok("El cambio de contraseña ha sido confirmado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }





        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // GET: api/<UsuarioController>
        //[HttpGet("IniciarSesion/{email}/{pass}", Name = "Login")]
        [HttpGet("IniciarSesion")]
        public ActionResult Login([FromQuery] string email, [FromQuery] string pass)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
                {
                    return BadRequest("El email y la contraseña son requeridos.");
                }

                UsuarioDTO usuario = LoginCU.Login(email, pass);
                if (usuario == null)
                {
                    return Unauthorized("Email o contraseña incorrectos.");
                }
                else
                {
                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "El email no está registrado." || ex.Message == "Contraseña incorrecta.")
                {
                    return Unauthorized(ex.Message);
                }

                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }




    }
}

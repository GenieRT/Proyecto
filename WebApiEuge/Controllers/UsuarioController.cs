﻿using Microsoft.AspNetCore.Http;
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
        private readonly ITokenService tokenService;

        public UsuarioController(IRegistro registroCU, ILogin loginCU, IEmailService emailService, ITokenService tokenService)
        {
            RegistroCU = registroCU;
            LoginCU = loginCU;
            this.emailService = emailService;
            this.tokenService = tokenService;
        }

        [HttpPut("ActualizarContraseña")]
        public ActionResult ActualizarContraseña([FromBody] ActualizarContrasenaDTO datos)
        {
            try
            {
                RegistroCU.ActualizarContraseña(datos.Email, datos.NuevaContraseña);
                return Ok("Proceso exitoso. Por favor, revisa tu correo para confirmar el cambio de contraseña.");
            }
            catch (ArgumentException ex) // Validaciones del caso de uso
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) // Otros errores
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

        }




        [HttpGet("ConfirmarCambio")]
        public ActionResult ConfirmarCambio(string email, string token)
        {
            try
            {
                RegistroCU.ConfirmarCambio(email, token);
                return Ok("El cambio de contraseña ha sido confirmado exitosamente.");
            }
            catch (ArgumentException ex) // Validaciones del caso de uso
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) // Otros errores
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

        }





        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("IniciarSesion")]
        public ActionResult Login([FromQuery] string email, [FromQuery] string pass)
        {
            try
            {
                UsuarioDTO usuario = LoginCU.Login(email, pass);
                string token = LoginCU.GenerarToken(usuario.Id.ToString(), usuario.Rol);

                return Ok(new { usuario, token });
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }




    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IRegistro RegistroCU;
        private ILogin LoginCU;

        public UsuarioController(IRegistro registroCU, ILogin loginCU)
        {
            RegistroCU = registroCU;
            LoginCU = loginCU;
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

                 // Buscar el usuario por email desde el caso de uso (que usará el repositorio internamente)
                 var usuario = RegistroCU.BuscarUsuarioPorEmail(datos.Email);
                 if (usuario == null)
                 {
                     return NotFound("Usuario no encontrado.");
                 }

                 // Actualizar la contraseña
                 RegistroCU.ActualizarContraseña(datos.Email, datos.NuevaContraseña);

                 return Ok("Contraseña actualizada con éxito.");
             }
             catch (Exception ex)
             {
                 return StatusCode(500, $"Error internoOO: {ex.Message}");
             }
         }
      

      




        /*   [ProducesResponseType(StatusCodes.Status200OK)]
           [ProducesResponseType(StatusCodes.Status400BadRequest)]
           // POST api/<UsuarioController>
           [HttpPost("Registro")]
           public ActionResult Post([FromBody] UsuarioDTO usuario)
           {
               try
               {
                   if (usuario == null || string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Contraseña) || string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Rol))
                   {
                       return BadRequest("Los datos del usuario son requeridos.");
                   }

                   RegistroCU.AddUser(usuario);
                   return Ok(usuario);
               }
               catch (Exception ex)
               {
                   return StatusCode(400, ex.Message);
               }
           } */

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
                return StatusCode(500, ex.Message);
            }
        }




    }
}

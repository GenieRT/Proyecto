using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.CasosDeUso
{
    public class RegistroCU : IRegistro
    {
        private IRepositorioUsuarios repoUsuarios;
        private readonly IEmailService emailService;

        public RegistroCU(IRepositorioUsuarios repositorioUsuarios, IEmailService emailService)
        {
            this.repoUsuarios = repositorioUsuarios;
            this.emailService = emailService;
        }

        public UsuarioDTO BuscarUsuarioPorEmail(string email)
        {
            var usuario = repoUsuarios.FindByEmail(email);
            if (usuario == null)
            {
                return null;
            }

            return new UsuarioDTO(usuario);
        }

        //para buscar directamente la entidad Usuario
        public Usuario BuscarUsuarioEntidadPorEmail(string email)
        {
            var usuario = repoUsuarios.FindByEmail(email);
            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }




        public void ActualizarContraseña(string email, string nuevaContraseña)
        {
            var usuario = repoUsuarios.FindByEmail(email);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            // Validar y actualizar la contraseña
            //usuario.SetPassword(nuevaContraseña);

            // Guardar los cambios en la base de datos
            //repoUsuarios.Update(usuario);




            // Generar un token de confirmación 
            string token = Guid.NewGuid().ToString();

            // Asignar el token y su posible expiración al usuario
            usuario.ConfirmationToken = token;
            usuario.TemporalPassword = nuevaContraseña;

            // Guardar el token en la base de datos
            repoUsuarios.Update(usuario);

            // Construir el link de confirmación
            string confirmationLink = $"https://localhost:7218/api/Usuario/ConfirmarCambio?email={email}&token={token}";

            // Enviar el correo al usuario con el link
            string subject = "Confirmación de cambio de contraseña";
            string body = $"Hola {usuario.Nombre},<br><br>" +
                          $"Hemos recibido tu solicitud para cambiar tu contraseña. Haz clic en el siguiente link para confirmar el cambio:<br>" +
                          $"<a href=\"{confirmationLink}\">Confirmar cambio de contraseña</a><br><br>" +
                          $"Si no realizaste esta solicitud, ignora este correo.";

            emailService.SendEmail(email, subject, body);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            repoUsuarios.Update(usuario);
        }
    }
}

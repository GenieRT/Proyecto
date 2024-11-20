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
    public class LoginCU : ILogin
    {
        private IRepositorioUsuarios repoUsuarios;

        public LoginCU(IRepositorioUsuarios repositorioUsuarios)
        {
            this.repoUsuarios = repositorioUsuarios;
        }

        public UsuarioDTO Login(string email, string pass)
        {
            // Buscar al usuario en el repositorio
            var usuario = repoUsuarios.FindByEmail(email);
            if (usuario == null)
            {
                throw new Exception("El email no está registrado.");
            }

            // Validar la contraseña
            string claveEncriptada = Usuario.ComputeSha256Hash(pass);
            if (usuario.EncriptedPassword != claveEncriptada)
            {
                throw new Exception("Contraseña incorrecta.");
            }

            return new UsuarioDTO(usuario);
        }
    }
}

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

        public RegistroCU(IRepositorioUsuarios repositorioUsuarios)
        {
            this.repoUsuarios = repositorioUsuarios;
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

        public void ActualizarContraseña(string email, string nuevaContraseña)
        {
            var usuario = repoUsuarios.FindByEmail(email);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            // Validar y actualizar la contraseña
            usuario.SetPassword(nuevaContraseña);

            // Guardar los cambios en la base de datos
            repoUsuarios.Update(usuario);
        }

        


       /* public UsuarioDTO AddUser(UsuarioDTO usuario)
        {
            Usuario nuevo = new Usuario();
            nuevo.Nombre = usuario.Nombre;
            nuevo.Email = usuario.Email;
            nuevo.Contraseña = usuario.Contraseña;
            nuevo.Rol = usuario.Rol;
            repoUsuarios.Add(nuevo);

            return new UsuarioDTO(nuevo);
        } */
    }
}

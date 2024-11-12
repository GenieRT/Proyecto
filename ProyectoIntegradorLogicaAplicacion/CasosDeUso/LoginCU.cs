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
            return new UsuarioDTO(repoUsuarios.Login(email, pass));
        }
    }
}

using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.InterfacesRepositorios
{
    public interface IRepositorioUsuarios : IRepositorio <Usuario>
    {
        public bool FindBy(string email, string pass);

        public Usuario Login(string email, string pass);

        public Usuario Registro(string email, string pass);
    }
}

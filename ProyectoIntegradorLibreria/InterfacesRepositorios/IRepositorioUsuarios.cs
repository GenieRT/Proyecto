using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.InterfacesRepositorios
{
    public interface IRepositorioUsuarios : IRepositorio<Usuario>
    {
        Usuario? FindByEmail(string email);
        IEnumerable<Cliente> GetAllClientes();
        //public Usuario Login(string email, string pass);
    }
}

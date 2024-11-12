using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData.EntityFramework.SQL
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private ISUSAContext _context;

        public RepositorioUsuarios()
        {
            _context = new ISUSAContext();
        }
        public void Add(Usuario t) //TODO: el caso de uso llama a este metodo
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }



        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario t)
        {
            throw new NotImplementedException();
        }

        public bool FindByID(int id)
        {
            throw new NotImplementedException();
        }

        Usuario IRepositorio<Usuario>.FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool FindBy(string email, string pass)
        {
            var buscar = _context.Usuarios.Where(u => u.Contraseña == pass && u.Email == email).SingleOrDefault();

            if (buscar == null)
            {
                return false;
            }
            return true;
        }

        public Usuario Login(string email, string pass)
        {
            throw new NotImplementedException();
        }


    }
}

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


        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }



        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }


        public Usuario? FindByID(int id)
        {
            return _context.Usuarios.Find(id);
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

        /*public Usuario Login(string email, string pass)
        {
            string claveEncriptada = Usuario.ComputeSha256Hash(pass);
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.EncriptedPassword == claveEncriptada);
        }*/

        public Usuario? FindByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void Add(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}

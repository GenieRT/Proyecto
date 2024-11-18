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

        void IRepositorio<Usuario>.Add(Usuario u) //TODO: el caso de uso registro llama a este metodo
        {
            try
            {
                var pass = u.Contraseña;
                u.SetPassword(pass);
                u.validar();
                _context.Usuarios.Add(u);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error interno: {e.InnerException?.Message}");
                throw new Exception($"Hubo un error al agregar el usuario: {e.Message}", e);
            }
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
            string claveEncriptada = Usuario.ComputeSha256Hash(pass);

            //var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.EncriptedPassword == claveEncriptada);

            return new Usuario();
        }


    }
}

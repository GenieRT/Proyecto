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
        public void Add(Usuario t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindByID(int id)
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
    }
}

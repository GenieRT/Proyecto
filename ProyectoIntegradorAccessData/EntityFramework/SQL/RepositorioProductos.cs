using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData.EntityFramework.SQL
{
    public class RepositorioProductos : IRepositorioProductos
    {

        private ISUSAContext _context;

        public RepositorioProductos()
        {
            _context = new ISUSAContext();
        }
        public void Add(Producto t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> FindAll()
        {
            throw new NotImplementedException();
        }

        public Producto FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Producto t)
        {
            throw new NotImplementedException();
        }
    }
}

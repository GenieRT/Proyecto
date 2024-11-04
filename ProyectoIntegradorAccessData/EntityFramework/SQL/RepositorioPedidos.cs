using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData.EntityFramework.SQL
{
    public class RepositorioPedidos : IRepositorioPedidos
    {
        private ISUSAContext _context;

        public RepositorioPedidos()
        {
            _context = new ISUSAContext();
        }
        public void Add(Pedido t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> FindAll()
        {
            throw new NotImplementedException();
        }

        public Pedido FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pedido t)
        {
            throw new NotImplementedException();
        }
    }
}

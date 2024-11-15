using Microsoft.EntityFrameworkCore;
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
        void IRepositorio<Pedido>.Add(Pedido pedido)
        {
            try
            {
                if (pedido.Productos != null)
                {
                    foreach(LineaPedido ln in pedido.Productos)
                    {
                        _context.Entry(ln).State = EntityState.Unchanged;
                    }
                }
                pedido.Validar();
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();

            }catch(Exception ex)
            {
                throw new Exception("Error al hacer pedido" + ex.Message);
            }

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

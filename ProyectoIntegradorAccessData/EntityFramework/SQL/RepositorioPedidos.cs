using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public void Add(Pedido pedido)
        {
            try
            {

                if (pedido == null)
                {
                    throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo.");
                }
                if(GetClienteById(pedido.ClienteId) == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                foreach(LineaPedido ln in pedido.Productos)
                {
                    if(GetProductoById(ln.ProductoId) == null || GetPresentacionById(ln.PresentacionId) == null){
                        throw new Exception("Producto o presentación no encontrado");
                    }
                }


                pedido.Validar();
                _context.Pedidos.Add(pedido);
                // Guardar cambios
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al hacer pedido: " + ex.Message);
            }
        }

        //proximos 3: aprobarPedidoCU
        public Usuario? GetClienteById(int id)
        {
            return _context.Usuarios.FirstOrDefault(c => c.Id == id);
        }
        
        public Pedido? GetPedidoById(int pedidoId)
        {
            return _context.Pedidos.FirstOrDefault(p => p.Id == pedidoId);
        }
        
        public void Update(Pedido p)
        {
            _context.Pedidos.Update(p);
            _context.SaveChanges();
        }

        public Presentacion GetPresentacionById(int id)
        {
            return _context.Presentacions.FirstOrDefault(p => p.Id == id);
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

        

        public Producto GetProductoById(int id)
        {
            return _context.Productos.FirstOrDefault(p => p.Id == id);
        }

      


        public IEnumerable<Pedido> GetPedidosPorCliente(int clienteId)
        {
            return _context.Pedidos.Where(p => p.ClienteId == clienteId).ToList();
        }

        public IEnumerable<Reserva> GetReservasPorCliente(int clienteId)
        {
            return _context.Reservas.Where(r => r.ClienteId == clienteId).ToList();
        }

        
    }
}

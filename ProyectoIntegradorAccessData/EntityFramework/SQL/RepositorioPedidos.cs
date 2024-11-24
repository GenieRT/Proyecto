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
        public void Add(Pedido pedido)
        {
            try
            {
                /*if (pedido.Id > 0) // Verifica si el pedido ya existe
                {
                    var existingPedido = _context.Pedidos
                        .Include(p => p.Productos)
                        .FirstOrDefault(p => p.Id == pedido.Id);

                    if (existingPedido != null)
                    {
                        // Reemplazar la lista de productos
                        existingPedido.Productos.Clear();
                        foreach (var linea in pedido.Productos)
                        {
                            existingPedido.Productos.Add(linea);
                        }

                        // Actualizar el pedido
                        _context.Entry(existingPedido).State = EntityState.Modified;
                    }
                }
                else
                {
                    // Nuevo pedido, simplemente agregarlo
                    
                }*/

                if (pedido == null)
                {
                    throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo.");
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


        public Usuario GetClienteById(int id)
        {
            return _context.Usuarios.FirstOrDefault(c => c.Id == id);
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

using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.Enum;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData.EntityFramework.SQL
{
    public class RepositorioReservas : IRepositorioReservas
    {
        private ISUSAContext _context;

        public RepositorioReservas()
        {
            _context = new ISUSAContext();
        }
        public void Add(Reserva reserva)
        {
            if(reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula");
            }
            
            Pedido ped = GetPedidoById(reserva.PedidoId);
            Usuario cli = GetClienteById(reserva.ClienteId);

            if (cli == null)
            {
                throw new InvalidOperationException("No se encontró el cliente");
            }

            if (ped == null)
            {
                throw new InvalidOperationException("No se encontró el pedido.");
            }

            if (ped.Estado == EstadoPedidoEnum.CERRADO || ped.Estado == EstadoPedidoEnum.PENDIENTE)
            {
                throw new InvalidOperationException("El pedido no está aprobado o ya está cerrado.");
            }

            reserva.ProcesarReserva(ped);
            _context.Reservas.Add(reserva);
            //guardar cambios
            _context.SaveChanges();
        }

        public IEnumerable<Reserva> FindAll()
        {
            throw new NotImplementedException();
        }

        public Reserva FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetClienteById(int id)
        {
            return _context.Usuarios.FirstOrDefault(c => c.Id == id);
        }

        public Pedido GetPedidoById(int id)
        {
            return _context.Pedidos
                   .Include(p => p.Productos)  
                   .FirstOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reserva t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserva> GetReservasPorCliente(int clienteId)
        {
            try
            {
                Console.WriteLine($"Obteniendo reservas para ClienteId: {clienteId}");

                var reservas = _context.Reservas
                    .Include(r => r.Cliente) // Incluye la información del cliente
                    .Include(r => r.Pedido) // Incluye la información del pedido
                    .Include(r => r.LineasReservas)
                        .ThenInclude(lr => lr.Producto)
                    .Where(r => r.ClienteId == clienteId)
                    .ToList();

                Console.WriteLine($"Cantidad de reservas obtenidas: {reservas.Count}");

                return reservas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetReservasPorCliente: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalle interno: {ex.InnerException.Message}");
                }
                throw;
            }

        }
    }
}

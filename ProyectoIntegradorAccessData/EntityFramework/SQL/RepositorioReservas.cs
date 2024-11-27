using ProyectoIntegradorLibreria.Entities;
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
            if (reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula");
            }
            Pedido ped = GetPedidoById(reserva.PedidoId);
            if(GetClienteById(reserva.ClienteId) == null || ped == null)
            {
                throw new Exception("Cliente o Pedido no encontrado");
            }
            if(ped.Estado == "Pendiente" || ped.Estado == "Cerrado")
            {
                throw new Exception("Pedido no aprobado o ya cerrado");
            }

            reserva.Validar();
            _context.Reservas.Add(reserva);
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
            return _context.Pedidos.FirstOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reserva t)
        {
            throw new NotImplementedException();
        }
    }
}

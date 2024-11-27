using ProyectoIntegradorLibreria.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoReservaEnum EstadoReserva { get; set; } 
        public Pedido Pedido { get; set; }

        [ForeignKey (nameof(Pedido))] public int PedidoId { get; set; }   
        public Cliente Cliente { get; set; }

        [ForeignKey (nameof(Cliente))] public int ClienteId { get; set; }
        public string Camion { get; set; }
        public string Chofer { get; set; }

        public Reserva() { }

        public void Validar()
        {
            ValidarReserva();
        }

        private void ValidarReserva()
        {
            if (Fecha < DateTime.Now.AddDays(7))
            {
                throw new InvalidOperationException("La fecha de la reserva debe ser al menos una semana después del día actual.");
            }

            if (string.IsNullOrWhiteSpace(Camion))
            {
                throw new InvalidOperationException("El campo camión no puede ser nulo o vacío.");
            }

            if (string.IsNullOrWhiteSpace(Chofer))
            {
                throw new InvalidOperationException("El campo chofer no puede ser nulo o vacío.");
            }
        }
    }
}

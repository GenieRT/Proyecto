using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoReserva { get; set; }
        public int PedidoId { get; set; } // Para identificar el pedido asociado a esta reserva

        public ReservaDTO() { }

        public ReservaDTO(Reserva reserva)
        {
            this.Id = reserva.Id;
            this.Fecha = reserva.Fecha;
            this.EstadoReserva = reserva.EstadoReserva;
            this.PedidoId = reserva.PedidoId;
        }
    }
}


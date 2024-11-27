using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoReservaEnum? EstadoReserva { get; set; }

        public PedidoDTO ? Pedido { get; set; }

        public int PedidoId { get; set; }
        public ClienteDTO ? Cliente { get; set; }
        public int ClienteId { get; set; }
        public string Camion { get; set; }
        public string Chofer { get; set; }

        public ReservaDTO() 
        {
           this.EstadoReserva = EstadoReservaEnum.SIN_ESTADO;
        }

        public ReservaDTO(Reserva reserva)
        {
            Id = reserva.Id;
            Fecha = reserva.Fecha;
            EstadoReserva = reserva.EstadoReserva;
            Pedido = new PedidoDTO(reserva.Pedido);
            PedidoId = reserva.PedidoId;
            Cliente = new ClienteDTO(reserva.Cliente);
            ClienteId = reserva.ClienteId;
            Camion = reserva.Camion;
            Chofer = reserva.Chofer;

        }
    }
}


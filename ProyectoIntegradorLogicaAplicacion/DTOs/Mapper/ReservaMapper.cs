using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs.Mapper
{
    public class ReservaMapper
    {
        public static Reserva FromDto(ReservaDTO reserva)
        {
            return new Reserva
            {
                Fecha = reserva.Fecha,
                EstadoReserva = (ProyectoIntegradorLibreria.Enum.EstadoReservaEnum)reserva.EstadoReserva,
                PedidoId = reserva.PedidoId,
                ClienteId = reserva.ClienteId,
                Camion = reserva.Camion,
                Chofer = reserva.Chofer,
            };
        }


        public static ReservaDTO ToDto(Reserva reserva)
        {
            return new ReservaDTO()
            {
                Id = reserva.Id,
                Fecha = reserva.Fecha,
                EstadoReserva = reserva.EstadoReserva,
                PedidoId = reserva.PedidoId,
                ClienteId = reserva.ClienteId,
                Camion = reserva.Camion,
                Chofer = reserva.Chofer,

            };
        }
    }
}

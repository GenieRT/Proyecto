using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs
{
    public class ClientePedidoReservaDTO
    {
        public List<PedidoDTO> Pedidos { get; set; }
        public List<ReservaDTO> Reservas { get; set; }

        public ClientePedidoReservaDTO(IEnumerable<Pedido> pedidos, IEnumerable<Reserva> reservas)
        {
            Pedidos = pedidos.Select(p => new PedidoDTO(p)).ToList();
            Reservas = reservas.Select(r => new ReservaDTO(r)).ToList();
        }

    }
}

using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string ? Estado { get; set; }
        public List<LineaPedidoDTO> Productos { get; set; }
        public ClienteDTO ? Cliente { get; set; }

        public int ClienteId { get; set; }

        public PedidoDTO() 
        { 
           this.Productos = new List<LineaPedidoDTO>();
            this.Estado = "Pendiente";
        }
        public PedidoDTO(Pedido pedido)
        {
           this.Id = pedido.Id;
           this.Fecha = pedido.Fecha;
           this.ClienteId = pedido.ClienteId;
           this.Cliente = new ClienteDTO(pedido.Cliente);
           this.Estado = pedido.Estado;

            if (pedido?.Productos != null) 
            {
                this.Productos = pedido.Productos.Select(lp => new LineaPedidoDTO(lp)).ToList();
            }

        }
    }
}
 
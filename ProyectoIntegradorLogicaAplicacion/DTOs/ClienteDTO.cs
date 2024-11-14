using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public int NumeroCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Estado { get; set; }
        public List<PedidoDTO> Pedidos { get; set; } 

        public ClienteDTO()
        {
            this.Pedidos = new List<PedidoDTO>();
        }

        public ClienteDTO(Cliente cliente)
        {
            this.Id = cliente.Id;
            this.NumeroCliente = cliente.NumeroCliente;
            this.RazonSocial = cliente.RazonSocial;
            this.Estado = cliente.Estado;

            if(cliente != null)
            {
                if (cliente.Pedidos != null)
                {
                    foreach(Pedido p in cliente.Pedidos)
                    {
                        Pedidos.Add(new PedidoDTO(p));
                    }
                }
            }
        }
    }
}

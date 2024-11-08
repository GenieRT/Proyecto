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
        public int NumeroCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Estado { get; set; }
        public List<PedidoDTO> Pedidos { get; set; } = new List<PedidoDTO>();
    }
}

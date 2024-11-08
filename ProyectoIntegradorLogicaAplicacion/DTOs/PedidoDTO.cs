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
        public string Estado { get; set; }
        public List<LineaPedidoDTO> Productos { get; set; } = new List<LineaPedidoDTO>();
        public Cliente Cliente { get; set; }
    }
}

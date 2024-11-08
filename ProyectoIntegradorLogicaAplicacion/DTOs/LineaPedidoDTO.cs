using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs
{
    public class LineaPedidoDTO
    {
        public int IdProducto { get; set; }
        public PresentacionDTO Presentacion { get; set; }
        public int Cantidad { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string TipoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Costo { get; set; }
        public int StockDisponible { get; set; }
    }
}

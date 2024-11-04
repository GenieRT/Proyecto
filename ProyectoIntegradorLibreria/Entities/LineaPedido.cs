using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.Entities
{
    public class LineaPedido
    {
        public int IdProducto { get; set; }
        public Presentacion Presentacion { get; set; }
        public int Cantidad { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.Entities
{
    public class LineaPedido
    {
        

        [ForeignKey(nameof(Producto))] public int  ProductoId { get; set; }

        public Producto Producto { get; set; }
        public Presentacion Presentacion { get; set; }

       [ForeignKey (nameof(Presentacion))] public int PresentacionId { get; set; }
        public int Cantidad { get; set; }

        public Pedido? Pedido { get; set; }

        [ForeignKey(nameof(Pedido))]
        public int PedidoId { get; set; }

        public LineaPedido() { }
    }

}

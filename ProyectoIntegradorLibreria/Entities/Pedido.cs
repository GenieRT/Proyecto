using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public List<LineaPedido> Productos { get; set; }
        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        public Pedido() 
        { 
            Productos = new List<LineaPedido>();
        }

        public void Validar()
        {
            ValidarLista();
        }
        private void ValidarLista()
        {
            if (Productos == null || Productos.Count == 0)
            {
                throw new Exception("El pedido debe contener al menos un producto.");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoReserva { get; set; } //enum
        public Pedido Pedido { get; set; }

        [ForeignKey (nameof(Pedido))] public int PedidoId { get; set; }   
        public Cliente Cliente { get; set; }

        [ForeignKey (nameof(Cliente))] public int ClienteId { get; set; }
        public string Camion { get; set; }
        public string Chofer { get; set; }

        public Reserva() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.Entities
{
    public class TurnoCarga
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Toneladas { get; set; }
    }
}

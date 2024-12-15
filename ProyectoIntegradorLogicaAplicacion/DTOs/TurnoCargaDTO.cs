using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace ProyectoIntegradorLogicaAplicacion.DTOs
{
   public class TurnoCargaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Toneladas { get; set; }

        public TurnoCargaDTO() { }


        public TurnoCargaDTO(TurnoCarga turnoCarga)
        {
            try
            {
              

                if (turnoCarga == null)
                {
                    throw new ArgumentNullException(nameof(turnoCarga), "El turno no puede ser nulo.");
                }

                
                Fecha = turnoCarga.Fecha;
                Toneladas = turnoCarga.Toneladas;
            }
            catch (Exception ex)
            {
              
                throw;
            }
        }
    }


}

using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs.Mapper
{
    public class TurnosCargaMapper
    {
        public static TurnoCarga FromDto(TurnoCargaDTO turnoCarga)
        {
            return new TurnoCarga
            {
                Fecha = turnoCarga.Fecha,
                Toneladas = turnoCarga.Toneladas,
                
            };
        }



        public static TurnoCargaDTO ToDto(TurnoCarga turnoCarga)
        {
            return new TurnoCargaDTO()
            {
                Fecha = turnoCarga.Fecha,
                Toneladas = turnoCarga.Toneladas,
            };
        }

        public static IEnumerable<TurnoCargaDTO> ToListaDto(IEnumerable<TurnoCarga> turnoCargas)
        {
            List<TurnoCargaDTO> aux = new List<TurnoCargaDTO>();
            foreach (var turnoCarga in turnoCargas)
            {
                TurnoCargaDTO turnoCargaDto = ToDto(turnoCarga);
                aux.Add(turnoCargaDto);
            }
            return aux;
        }
    }
}

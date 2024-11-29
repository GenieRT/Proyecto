using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs.Mapper
{
    public class LineaReservaMapper
    {
        public static LineaReserva FromDto(LineaReservaDTO linea)
        {
            return new LineaReserva
            {
                ProductoId = linea.ProductoId,
                CantidadReservada = linea.CantidadReservada
            };
        }



        public static LineaReservaDTO ToDto(LineaReserva linea)
        {
            return new LineaReservaDTO()
            {
                Id = linea.Id,
                ProductoId = linea.ProductoId,
                CantidadReservada = linea.CantidadReservada

            };
        }

        public static IEnumerable<LineaReservaDTO> ToListaDto(IEnumerable<LineaReserva> lineas)
        {
            List<LineaReservaDTO> aux = new List<LineaReservaDTO>();
            foreach (var linea in lineas)
            {
                LineaReservaDTO lineaDto = ToDto(linea);
                aux.Add(lineaDto);
            }
            return aux;
        }
    }
}

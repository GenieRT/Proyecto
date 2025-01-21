using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData.EntityFramework.SQL
{
    public class RepositorioTurnosCarga : IRepositorioTurnosCarga
    {
        private ISUSAContext _context;

        public RepositorioTurnosCarga()
        {
            _context = new ISUSAContext();
        }
        public void Add(TurnoCarga t)
        {
            if (t.Toneladas == 0)
            {
                throw new ArgumentNullException(nameof(t), "La catidad de toneladas no puede ser cero");
            }

            _context.TurnosCargas.Add(t);
            //guardar cambios
            _context.SaveChanges();
        }

        public TurnoCarga ObtenerTurnoPorFecha(DateTime fecha)
        {
            return _context.TurnosCargas
                .FirstOrDefault(t => fecha >= t.FechaInicioSemana && fecha <= t.FechaFinSemana);
        }

    }
}

using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData.EntityFramework.SQL
{
    public class RepositorioReservas : IRepositorioReservas
    {
        private ISUSAContext _context;

        public RepositorioReservas()
        {
            _context = new ISUSAContext();
        }
        public void Add(Reserva t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserva> FindAll()
        {
            throw new NotImplementedException();
        }

        public Reserva FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reserva t)
        {
            throw new NotImplementedException();
        }
    }
}

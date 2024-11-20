using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorAccesData.EntityFramework.SQL
{
    public class RepositorioPresentaciones : IRepositorioPresentaciones
    {
        private ISUSAContext _context;

        public RepositorioPresentaciones()
        {
            _context = new ISUSAContext();
        }
        public void Add(Presentacion t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Presentacion> FindAll()
        {
            return _context.Presentacions;
        }

        public Presentacion FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Presentacion t)
        {
            throw new NotImplementedException();
        }
    }
}

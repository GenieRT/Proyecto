﻿using ProyectoIntegradorLibreria.Entities;
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
            throw new NotImplementedException();
        }

        public IEnumerable<TurnoCarga> FindAll()
        {
            throw new NotImplementedException();
        }

        public TurnoCarga FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TurnoCarga t)
        {
            throw new NotImplementedException();
        }
    }
}
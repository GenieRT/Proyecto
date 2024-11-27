using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.DTOs.Mapper;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.CasosDeUso
{
    public class RegistrarReservaCU : IRegistrarReserva
    {
        public IRepositorioReservas _repositorioReservas;

        public RegistrarReservaCU(IRepositorioReservas repositorioReservas)
        {
            _repositorioReservas = repositorioReservas;
        }

        public ReservaDTO Ejecutar(ReservaDTO reserva)
        {
            if(reserva == null)
            {
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula");
            }
            Reserva nueva = ReservaMapper.FromDto(reserva);
            _repositorioReservas.Add(nueva);
            return ReservaMapper.ToDto(nueva);
        }
    }
}

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
    public class VerificarDemandaProduccionCU : IVerificarDemandaYProduccion
    {

        private IRepositorioProductos _repositorioProductos;
        private IRepositorioReservas _repositorioReservas;

        public VerificarDemandaProduccionCU(IRepositorioProductos repositorioProductos, IRepositorioReservas repositorioReservas)
        {
            _repositorioProductos = repositorioProductos;
            _repositorioReservas = repositorioReservas;
        }
        
        
            public IEnumerable<ProductoDemandaDTO> Ejecutar(bool soloConAlerta = false)
            {
                // Obtener líneas de reserva para la próxima semana
                var lineasReserva = _repositorioReservas.GetReservasProximaSemana();

                if (!lineasReserva.Any())
                {
                    throw new KeyNotFoundException("No se encontraron reservas para la próxima semana.");
                }

                var productosConStock = _repositorioProductos.FindAll();

                // Mapear las líneas de reserva a ProductoDemandaDTO
                var productosDemanda = lineasReserva
                    .GroupBy(lr => lr.ProductoId)
                    .Select(grupo =>
                    {
                        var productoStock = productosConStock.FirstOrDefault(p => p.Id == grupo.Key);

                        if (productoStock == null)
                        {
                            throw new KeyNotFoundException($"No se encontró información de stock para el producto con ID {grupo.Key}.");
                        }

                        return LineaReservaMapper.MapToProductoDemandaDTO(grupo, productoStock);
                    });

                // Filtrar solo con alerta si se requiere
                return soloConAlerta
                    ? productosDemanda.Where(p => p.AlertaProduccion).ToList()
                    : productosDemanda.ToList();
            } 
        }
}


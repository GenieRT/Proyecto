using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.CasosDeUso
{
    public class ListarProductosCU : IListarProductos
    {
        public IRepositorioProductos _repositorioProductos;

        public ListarProductosCU(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }

        public IEnumerable<ProductoDTO> ListarProductos()
        {
           List<ProductoDTO> aRetornar = new List<ProductoDTO>();
            foreach(Producto p in _repositorioProductos.FindAll().ToList()) 
            { 
                aRetornar.Add(new ProductoDTO(p));
            }
            return aRetornar;
        }
    }
}

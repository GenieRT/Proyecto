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
    public class ObtenerProductoPorIdCU : IObtenerProductoPorId
    {

        IRepositorioProductos _repoProductos;

        public ObtenerProductoPorIdCU (IRepositorioProductos repoProductos)
        {
            _repoProductos = repoProductos;
        }
        public ProductoDTO Ejecutar(int id)
        {
            return ProductoMapper.ToDto(_repoProductos.FindByID(id));
        }
    }
}

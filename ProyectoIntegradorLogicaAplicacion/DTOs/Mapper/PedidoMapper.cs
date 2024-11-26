using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs.Mapper
{
    public class PedidoMapper
    {
        public static Pedido FromDto(PedidoDTO pedido)
        {
            return new Pedido
            {
                Fecha = pedido.Fecha,
                Estado = pedido.Estado,
                ClienteId = pedido.ClienteId,
                Productos = pedido.Productos.Select(p => new LineaPedido
                {
                    ProductoId = p.ProductoId,
                    PresentacionId = p.PresentacionId,
                    Cantidad = p.Cantidad,

                }).ToList()
            };
        }



        public static PedidoDTO ToDto(Pedido pedido)
        {
            return new PedidoDTO()
            {
                Id = pedido.Id,
                Fecha = pedido.Fecha,
                ClienteId = pedido.ClienteId,
                Estado = pedido.Estado,
                Productos = (List<LineaPedidoDTO>)LineaPedidoMapper.ToListaDto(pedido.Productos)

            };
        }
        /*
            public static IEnumerable<AutorDto> ToListaDto(IEnumerable<Autor> autores)
            {
                List<AutorDto> aux = new List<AutorDto>();
                foreach (var autor in autores)
                {
                    AutorDto autorDto = ToDto(autor);
                    aux.Add(autorDto);
                }
                return aux;
            }
        }*/
    } }

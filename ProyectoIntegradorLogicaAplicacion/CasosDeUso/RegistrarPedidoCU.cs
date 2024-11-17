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
    public class RegistrarPedidoCU : IRegistrarPedido
    {
        public IRepositorioPedidos _repositorioPedidos;
       
        public RegistrarPedidoCU(IRepositorioPedidos repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public PedidoDTO addPedido(PedidoDTO pedido)
        {
            //Usuario clienteExistente = _repositorioPedidos.GetClienteById(pedido.ClienteId);
            //Cliente cliente = clienteExistente as Cliente;

            /*if (cliente == null)
            {
                cliente = new Cliente
                {
                    Id = pedido.ClienteId,
                    NumeroCliente = pedido.Cliente.NumeroCliente,
                    RazonSocial = pedido.Cliente.RazonSocial,
                    Estado = pedido.Cliente.Estado
                };
            }*/

            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo.");
            }

            Pedido nuevoPedido = new Pedido
            {
                Fecha = pedido.Fecha,
                Estado = pedido.Estado,
                ClienteId = pedido.ClienteId,
                Productos = pedido.Productos.Select(p => new LineaPedido
                {
                    ProductoId = p.ProductoId,
                    PresentacionId = p.PresentacionId,
                    Cantidad = p.Cantidad,
                    PedidoId = p.PedidoId
                }).ToList()
            };

            /*if (lp.Id != 0)
            {
                var trackedEntity = _repositorioPedidos.GetLineaPedidoById(lp.Id);
                if (trackedEntity != null)
                {
                    lineaPedido = trackedEntity;
                }
                else
                {
                    lineaPedido.Id = lp.Id;
                }
            }

            nuevoPedido.Productos.Add(lineaPedido);
            }*/


            _repositorioPedidos.Add(nuevoPedido);

            return pedido;
        }
    }
}


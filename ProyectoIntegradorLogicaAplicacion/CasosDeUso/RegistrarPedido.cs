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
    public class RegistrarPedido : IRegistrarPedido
    {
        public IRepositorioPedidos _repositorioPedidos;
       
        public RegistrarPedido(IRepositorioPedidos repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public PedidoDTO addPedido(PedidoDTO pedido)
        {
            Pedido aCrear = new Pedido()
            {
                Id = pedido.Id,
                Fecha = pedido.Fecha,
                Estado = "Pendiente",
            };
            Cliente cliente = new Cliente()
            {
                Id = pedido.ClienteId,
                NumeroCliente = pedido.Cliente.NumeroCliente,
                RazonSocial = pedido.Cliente.RazonSocial,
                Estado = pedido.Cliente.Estado,
                Pedidos = new List<Pedido>()

            };

            if(pedido.Cliente.Pedidos != null)
            {
                foreach(PedidoDTO p in pedido.Cliente.Pedidos)
                {
                    Pedido ped = new Pedido();
                    ped.Id = p.Id;
                    ped.ClienteId = p.ClienteId;
                    ped.Cliente = cliente;
                    ped.Estado = p.Estado;

                    if(p.Productos != null)
                    {
                        foreach(LineaPedidoDTO linea in p.Productos)
                        {
                            LineaPedido lineaPedido = new LineaPedido();
                            lineaPedido.ProductoId = linea.ProductoId;
                            lineaPedido.Cantidad = linea.Cantidad;
                            Presentacion presentacion = new Presentacion();
                            presentacion.Id = linea.Presentacion.Id;
                            presentacion.Unidad = linea.Presentacion.Unidad;
                            presentacion.Descripcion = linea.Presentacion.Descripcion;
                            lineaPedido.Presentacion = presentacion;
                            ped.Productos.Add(lineaPedido);
                        }
                    }
                }
            }
       
            if(pedido.Productos != null )
            {
                aCrear.Productos = new List<LineaPedido>();
                foreach(LineaPedidoDTO lp in pedido.Productos)
                {
                    LineaPedido lineaPedido = new LineaPedido();
                    lineaPedido.ProductoId = lp.ProductoId;
                    lineaPedido.Cantidad = lp.Cantidad;
                    Presentacion presentacion = new Presentacion();
                    presentacion.Id = lp.Presentacion.Id;
                    presentacion.Unidad = lp.Presentacion.Unidad;
                    presentacion.Descripcion = lp.Presentacion.Descripcion;
                    lineaPedido.Presentacion = presentacion;
                    aCrear.Productos.Add(lineaPedido);
                }
            }

            _repositorioPedidos.Add(aCrear);
            return pedido; 
        }
    }
}

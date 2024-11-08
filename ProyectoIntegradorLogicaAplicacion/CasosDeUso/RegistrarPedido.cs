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
                Fecha = pedido.Fecha,
                Estado = "Pendiente",
                Cliente = pedido.Cliente
            };
            if(pedido.Productos != null)
            {
                aCrear.Productos = new List<LineaPedido>();
                foreach(LineaPedidoDTO lp in pedido.Productos)
                {
                    LineaPedido lineaPedido = new LineaPedido();
                    lineaPedido.IdProducto = lp.IdProducto;
                    lineaPedido.Cantidad = lp.Cantidad;
                    Presentacion presentacion = new Presentacion();
                    presentacion.Id = lp.Presentacion.Id;
                    presentacion.Unidad = lp.Presentacion.Unidad;
                    presentacion.Descripcion = lp.Presentacion.Descripcion;
                    lineaPedido.Presentacion = presentacion;
                }
            }

            _repositorioPedidos.Add(aCrear);
            return pedido; 
        }
    }
}

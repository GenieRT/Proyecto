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
    public class ListarPedidosCU : IListarPedidos
    {
        private readonly IRepositorioPedidos repoPedidos;

        public ListarPedidosCU(IRepositorioPedidos repositorioPedidos) 
        {
            this.repoPedidos = repositorioPedidos;    
        }

        public Cliente? buscarClientePorId(int clienteId)
        {
            var cli = repoPedidos.GetClienteById(clienteId);

            if (cli == null || !(cli is Cliente cliente))
            {
                return null;
            }

            return cliente;
        }


        public ClientePedidoReservaDTO ObtenerPedidosYReservasPorCliente(int clienteId)
        {
            var pedidos = repoPedidos.GetPedidosPorCliente(clienteId) ?? new List<Pedido>();
            var reservas = repoPedidos.GetReservasPorCliente(clienteId) ?? new List<Reserva>();
            //si las listas vienen null, crea una nueva vacia

            return new ClientePedidoReservaDTO(pedidos, reservas);
        }
    }
}

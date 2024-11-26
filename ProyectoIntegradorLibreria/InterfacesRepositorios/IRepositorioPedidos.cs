using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.InterfacesRepositorios
{
    public interface IRepositorioPedidos : IRepositorio<Pedido>
    {

       public Usuario GetClienteById(int clienteId);
       public Presentacion GetPresentacionById(int id);

       public Producto GetProductoById(int id);
    }
}

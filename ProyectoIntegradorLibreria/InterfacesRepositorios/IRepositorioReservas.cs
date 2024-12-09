﻿using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.InterfacesRepositorios
{
    public interface IRepositorioReservas : IRepositorio<Reserva>
    {
        public Usuario GetClienteById(int id);
        public Pedido GetPedidoById(int id);
        public IEnumerable<Reserva> GetReservasPorCliente(int clienteId);

        public IEnumerable<Reserva> GetReservasEmplados();

    }
}

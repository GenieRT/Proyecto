﻿using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;

namespace ProyectoIntegrador.WebApiVersion3.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IRegistrarPedido _registrarPedido;

        public PedidoController(IRegistrarPedido registrarPedido)
        {
            _registrarPedido = registrarPedido;
        }

        // GET: api/v1/pedidos
        /*[HttpGet]
        public IActionResult GetAll()
        {
            var pedidos = _repositorioPedidos.FindAll();
            if (pedidos == null || !pedidos.Any())
                return NoContent();
            return Ok(pedidos);
        }

        // GET: api/v1/pedidos/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pedido = _repositorioPedidos.FindByID(id);
            if (pedido == null)
                return NotFound($"No se encontró el pedido con ID {id}");
            return Ok(pedido);
        }*/

        // POST: api/v1/pedidos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post ([FromBody] PedidoDTO pedido)
        {
            try
            {
                PedidoDTO pedDTO = this._registrarPedido.addPedido(pedido);
                return Created("api/v1/Pedido", pedDTO);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/v1/pedidos/{id}
        /*[HttpPut("{id}")]
        public IActionResult Update(int id, Pedido pedido)
        {
            if (pedido == null || pedido.Id != id)
                return BadRequest("El ID del pedido no coincide o el pedido es nulo.");

            _repositorioPedidos.Update(pedido);
            return NoContent();
        }

        // DELETE: api/v1/pedidos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _repositorioPedidos.FindByID(id);
            if (pedido == null)
                return NotFound($"No se encontró el pedido con ID {id}");

            _repositorioPedidos.Remove(id);
            return NoContent();
        }*/
    }
}
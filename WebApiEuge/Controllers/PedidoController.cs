using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;

namespace ProyectoIntegrador.WebApiVersion3.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IRegistrarPedido _registrarPedido;
        private IListarPedidos listarPedidosCU;
        private IAprobarPedido aprobarPedidoCU;


        public PedidoController(IRegistrarPedido registrarPedido, IListarPedidos listarPedidos, IAprobarPedido aprobarPedido)
        {
            _registrarPedido = registrarPedido;
            listarPedidosCU = listarPedidos;
            aprobarPedidoCU = aprobarPedido;
        }

        [HttpGet("PedidosYReservas")]
        public IActionResult ObtenerPedidosYReservas(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                {
                    return BadRequest("El ID del cliente es inválido.");
                }


                //verificar si el cliente existe
                var cli = listarPedidosCU.buscarClientePorId(clienteId);
                if (cli == null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                var pedidosReservas = listarPedidosCU.ObtenerPedidosYReservasPorCliente(clienteId);

                if (pedidosReservas == null || (!pedidosReservas.Pedidos.Any() && !pedidosReservas.Reservas.Any()))
                {
                    return NotFound("No se encontraron pedidos ni reservas para el cliente.");
                }

                return Ok(pedidosReservas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }


        [HttpPut("AprobarPedido")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AprobarPedido([FromQuery] int pedidoId, [FromQuery] int empleadoId)
        {
            try
            {
                if (pedidoId <= 0 || empleadoId <= 0)
                {
                    return BadRequest("El ID del pedido y el ID del empleado son requeridos y deben ser mayores a 0.");
                }

                //luego se cambiara cunado se implemente token etc
                var empleado = aprobarPedidoCU.BuscarEmpleadoPorId(empleadoId);
                if (empleado == null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Acción permitida solo para empleados.");
                }

                var pedido = aprobarPedidoCU.BuscarPedidoPorId(pedidoId);
                if (pedido == null)
                {
                    return NotFound("Pedido no encontrado.");
                }

                //validar estado del pedido y aprobarlo
                var resultado = aprobarPedidoCU.AprobarPedido(pedido);

                if (!resultado)
                {
                    return StatusCode(500, "Error al aprobar el pedido.");
                }

                return Ok("Pedido aprobado con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
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
        public IActionResult Post ([FromBody] PedidoDTO pedido)
        {
            try
            {
                PedidoDTO pedDTO = this._registrarPedido.addPedido(pedido);
                return Created("api/Pedidos", pedDTO);
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;

namespace WebApi2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IListarClientes _listarClientesCU;

        public ClienteController(IListarClientes listarClientesCU)
        {
            _listarClientesCU = listarClientesCU;
        }

        [HttpGet]
        [Authorize(Roles = "Empleado")]
        public IActionResult GetAllClientes()
        {
            try
            {
                var clientes = _listarClientesCU.Listar();
                return Ok(clientes);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Error de infraestructura: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Error: {ex.Message}");
            }
        }
    }
}

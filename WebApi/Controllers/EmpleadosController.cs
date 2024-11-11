using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;

namespace ProyectoIntegrador.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IRepositorioUsuarios _repositorioEmpleados;

        public EmpleadosController(IRepositorioUsuarios repositorioEmpleados)
        {
            _repositorioEmpleados = repositorioEmpleados;
        }

        // Mostrar todos los empleados
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var empleados = _repositorioEmpleados.FindAll();
                if (empleados == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return Ok(empleados);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al obtener los empleados.");
            }
        }
    }
}

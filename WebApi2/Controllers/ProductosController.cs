using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoIntegradorWebApi2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IRepositorioProductos _repositorioProductos;

        // Constructor inyectando el repositorio de productos
        public ProductoController(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }

        // Obtener todos los productos
        [HttpGet("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var productos = _repositorioProductos.FindAll();

                // Verificar si se encontraron productos
                if (productos == 0)// buscar como verificar
                {
                    return StatusCode(204, "No se encontraron productos.");
                }

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al obtener los productos.");
            }
        }

        // Obtener productos filtrados por nombre
        [HttpGet("filtro/nombre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByNombre([FromQuery] string nombre)
        {
            try
            {
                // Validar que el nombre no esté vacío
                if (string.IsNullOrEmpty(nombre))
                {
                    return BadRequest("El filtro de nombre es obligatorio.");
                }

                var productos = _repositorioProductos.FindAll()
                    .Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

                // Verificar si se encontraron productos
                if (productos.Count == 0)
                {
                    return StatusCode(204, "No se encontraron productos con el nombre proporcionado.");
                }

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al obtener los productos.");
            }
        }



        // Obtener un producto por su ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var producto = _repositorioProductos.FindByID(id);
                if (producto == null)
                {
                    return NotFound("Producto no encontrado.");
                }

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al obtener el producto.");
            }
        }
    }
}
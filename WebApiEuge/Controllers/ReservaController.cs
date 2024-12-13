using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorLibreria.Entities;
using ProyectoIntegradorLibreria.InterfacesRepositorios;
using ProyectoIntegradorLogicaAplicacion.DTOs;
using ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso;
using System;
using System.Collections.Generic;

namespace ProyectoIntegrador.WebApi2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private IRegistrarReserva _registrarReserva;
        private IListarReservas _listarReservas;
        private IObtenerReservasProximaSemana _listarReservasProximaSemana;
        private IVerificarDemandaYProduccion _verificarDemandaProduccion;

        public ReservaController(IRegistrarReserva registrarReserva, IListarReservas listarReservas, IObtenerReservasProximaSemana reservasProximaSemana, IVerificarDemandaYProduccion verificarDemandaYProduccion)
        {
            _registrarReserva = registrarReserva;
            _listarReservas = listarReservas;
            _listarReservasProximaSemana = reservasProximaSemana;
            _verificarDemandaProduccion = verificarDemandaYProduccion;
        }

        //Registro de Reserva
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Cliente")]
        public IActionResult Create([FromBody]ReservaDTO reserva)
        {
            try
            {
                ReservaDTO reservaDTO = _registrarReserva.Ejecutar(reserva);
                return Created("api/v1/Reserva", reservaDTO);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //LISTAR RESERVAS EMPLEADO
        [HttpGet("ReservasEmpleado")]
        [Authorize(Roles = "Empleado")]
        public IActionResult MostrarReservasEmpleado(string rol)
        {
            if (rol == "Empleado")
            {

                try
                {
                    var reservasempleado = _listarReservas.GetReservasEmplados();
                    return Ok(reservasempleado);
                }
                catch (ArgumentException ex) // Excepción para parámetros inválidos
                {
                    return BadRequest(ex.Message);
                }
                catch (KeyNotFoundException ex) // Excepción para recursos no encontrados
                {
                    return NotFound(ex.Message);
                }
                catch (Exception ex) // Excepción general para errores internos
                {
                    return StatusCode(500, $"Error interno: {ex.Message}");
                }


            }
            return BadRequest("No tienes permiso para ver estos datos");


        }

        // Obtener productos reservados para la próxima semana
        [HttpGet("ReservasSemanaProxima")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetReservasSemanaProxima()
        {
            try
            {
                // Llama al caso de uso correspondiente para obtener los productos reservados
                var productosReservados = _listarReservasProximaSemana.Ejecutar();

                if (productosReservados == null || !productosReservados.Any())
                {
                    return NotFound("No se encontraron productos reservados para la semana próxima.");
                }

                return Ok(productosReservados);
            }
            catch (Exception ex)
            {
                // Manejo de errores general
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // Verificar demanda de producción
        [HttpGet("VerificarDemandaProduccion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult VerificarDemandaProduccion()
        {
            try
            {
                var productosConAlerta = _verificarDemandaProduccion.Ejecutar(true);
                if (!productosConAlerta.Any())
                {
                    return NotFound("No se encontraron productos con alertas de producción.");
                }

                return Ok(productosConAlerta);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }


        /*
        // Mostrar todas las reservas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var reservas = _repositorioReservas.FindAll();
                if (reservas == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return Ok(reservas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al obtener las reservas.");
            }
        }

        // Buscar reserva por ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var reserva = _repositorioReservas.FindByID(id);
                if (reserva == null)
                {
                    return NotFound($"Reserva con ID {id} no encontrada.");
                }
                return Ok(reserva);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al obtener la reserva.");
            }
        }


        // Actualizar una reserva existente
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, Reserva reserva)
        {
            if (reserva == null || reserva.Id != id)
            {
                return BadRequest("Los datos de la reserva son inválidos.");
            }

            try
            {
                var reservaExistente = _repositorioReservas.FindByID(id);
                if (reservaExistente == null)
                {
                    return NotFound($"Reserva con ID {id} no encontrada.");
                }

                _repositorioReservas.Update(reserva);
                return Ok("Reserva actualizada con éxito.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al actualizar la reserva.");
            }
        }*/
    }
}
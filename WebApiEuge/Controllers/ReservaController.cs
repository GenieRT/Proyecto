﻿using Microsoft.AspNetCore.Http;
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

        public ReservaController(IRegistrarReserva registrarReserva)
        {
            _registrarReserva = registrarReserva;
        }

        // Crear una nueva reserva
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
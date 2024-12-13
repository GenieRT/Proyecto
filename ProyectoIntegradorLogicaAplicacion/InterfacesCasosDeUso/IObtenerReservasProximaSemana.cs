﻿using ProyectoIntegradorLogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso
{
    public interface IObtenerReservasProximaSemana
    {
        public IEnumerable<ProductoDemandaDTO> Ejecutar();
    }
}

using ProyectoIntegradorLogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.InterfacesCasosDeUso
{
    public interface IRegistro
    {
        UsuarioDTO BuscarUsuarioPorEmail(string email);
        void ActualizarContraseña(string email, string nuevaContraseña);
    }

}

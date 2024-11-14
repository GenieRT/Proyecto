using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLibreria.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public Usuario() { }

        /*public void Validar()
    {

        Regex regexMayuscula = new Regex("[A-Z]");
        Regex regexMinuscula = new Regex("[a-z]");
        Regex regexDigito = new Regex("[0-9]");


        if (string.IsNullOrEmpty(Email))
        {
            throw new UsuarioInvalidoException("El email no puede ser nulo o vacio");
        }
        if (string.IsNullOrEmpty(Contraseña))
        {
            throw new UsuarioInvalidoException("La contraseña no puede ser nula o vacia");
        }
        if (Contraseña.Length <= 6)
        {
            throw new UsuarioInvalidoException("La contraseña no puede ser nula o vacia");
        }
        if (!regexMayuscula.IsMatch(Contraseña))
        {
            throw new UsuarioInvalidoException("La contraseña debe tener mayusculas");
        }

        if (!regexMinuscula.IsMatch(Contraseña))
        {
            throw new UsuarioInvalidoException("La contraseña debe tener minusculas");
        }

        if (!regexDigito.IsMatch(Contraseña))
        {
            throw new UsuarioInvalidoException("La contraseña debe tener un numero del 0 al 9");
        }

    }*/

    }

    //contructor vacio protected
    //constructor con todos los datos que llame a Validar

    
    
    
}

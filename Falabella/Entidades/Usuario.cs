using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuario : Persona
    {
        public int IdUsuario { get; set; }
        public string Pass { get; set; }
        public string NombreUsuario { get; set; }
    }
}

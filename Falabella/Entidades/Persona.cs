using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{

    /// <summary>
    /// AAB (Diciembre 30, 2018)
    /// Modela la información de una persona
    /// </summary>
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public TipoDocumento TipoIdentificacion { get; set; }
        public string Identificcion { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}

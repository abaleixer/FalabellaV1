using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// AAB (Diciembre 30, 2018)
    /// Modela una aseguradora
    /// </summary>
    public class Aseguradora
    {
        public int IdAseguradora { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public List<Poliza> Polizas { get; set; }
    }
}

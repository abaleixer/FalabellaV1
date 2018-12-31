using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// AAB (Diciembre 30, 2018)
    /// Modela una poliza
    /// </summary>
    public class Poliza
    {
        public int IdPoliza { get; set; }
        public int IdAseguradora { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Cobertura { get; set; }
        public List<PorcentajeCobertura> Porcentajes { get; set; }
    }
}

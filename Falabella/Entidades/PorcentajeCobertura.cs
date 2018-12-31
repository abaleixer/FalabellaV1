using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// AAB (Diciembre 30, 2018)
    /// Modela la cobertura y porcentaje de una poliza
    /// </summary>
    public class PorcentajeCobertura
    {
        public int IdCobertura { get; set; }
        public int IdPoliza { get; set; }
        public string Tipo { get; set; }
        public float Porcentaje { get; set; }
    }
}

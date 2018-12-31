using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// AAB (Diciembre 30, 2018)
    /// Modela un cliente
    /// </summary>
    public class Cliente : Persona
    {
        public int IdCliente { get; set; }       
        public Poliza Poliza { get; set; }
        public PorcentajeCobertura Porcentaje { get; set; }
        public float ValorPrima { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}

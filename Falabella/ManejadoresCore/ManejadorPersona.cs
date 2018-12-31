using DataAccessCore;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManejadoresCore
{
    /// <summary>
    /// AAB (Diciembre 30, 2018)
    /// Maneja la logica de una persona
    /// </summary>
    public class ManejadorPersona
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agrega una persona
        /// </summary>
        /// <param name="persona"></param>
        public int AgregarPersona(Persona persona)
        {
           return  PersonaDAO.AgregarPersona(persona);
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Retorna la lista de tipos identificación
        /// </summary>
        /// <returns></returns>
        public List<TipoDocumento> DarTiposDocumento ()
        {
            return PersonaDAO.DarTiposDocumento();
        }
    }
}

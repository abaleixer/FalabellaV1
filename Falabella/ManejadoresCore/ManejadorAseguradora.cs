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
    /// Maneja la lógica de las aseguradoras aliadas 
    /// </summary>
    public class ManejadorAseguradora
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// retorna la lista de aseguradoras
        /// </summary>
        /// <returns>Lista de aseguradoras</returns>
        public List<Aseguradora> DarAseguradoras()
        {
            return AseguradoraDAO.DarAseguradoras();
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018) 
        /// Agrega una nueva aseguradora y retorna la lista final resultante 
        /// </summary>
        /// <param name="aseguradora">Aseguradora Agregada</param>
        /// <returns>Lista de aseguradoras</returns>
        public List<Aseguradora> AgregarAseguradora(Aseguradora aseguradora)
        {
            return AseguradoraDAO.AgregarAseguradora(aseguradora);
        }
    }
}

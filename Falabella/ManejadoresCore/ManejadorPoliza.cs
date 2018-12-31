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
    /// Manejador encargado de la lógica las polizas
    /// </summary>
    public class ManejadorPoliza
    {
        /// <summary>
        ///  AAB (Diciembre 30, 2018)
        ///  Retorna la lista de las polizas de la aseguradora
        /// </summary>
        /// <param name="idAseguradora">Id de la aseguradora</param>
        /// <returns>Lista de pólizas</returns>
        public List<Poliza> DarPolizasXidAseguradora(int idAseguradora)
        {
            return PolizaDAO.DarPolizasXidAseguradora(idAseguradora);
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agrega una nueva póliza a la aseguradora
        /// </summary>
        /// <param name="poliza">Póliza</param>
        /// <returns>Lista de polizas de la aseguradora</returns>
        public List<Poliza> AgregarPoliza(Poliza poliza)
        {
            return PolizaDAO.AgregarPoliza(poliza);
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agrega un nuevo porcentaje de prima a la poliza
        /// </summary>
        /// <param name="Porcentaje">Porcentaje</param>
        /// <returns>Lista de porcentaje de la poliza</returns>
        public List<PorcentajeCobertura> AgragarPorcentaje(PorcentajeCobertura porcentaje)
        {
            return PolizaDAO.AgregarPorcentaje(porcentaje);
        }


        /// <summary>
        ///  AAB (Diciembre 30, 2018)
        ///  Retorna la lista de porcentajes de la poliza
        /// </summary>
        /// <param name="idPoliza">Id de la póliza</param>
        /// <returns>Lista de porcentajes</returns>
        public List<PorcentajeCobertura> DarPorcentajesPoliza(int idPoliza)
        {
            return PolizaDAO.DarPorcentajeCoberturaXidPoliza(idPoliza);
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018) 
        /// </summary>
        /// <param name="idPorcentaje"></param>
        /// <returns></returns>
        public PorcentajeCobertura DarPorcentajeCoberturaXidPorcentaje(int idPorcentaje)
        {
            return PolizaDAO.DarPorcentajeCoberturaXidPorcentaje(idPorcentaje);
        } 
    }
}

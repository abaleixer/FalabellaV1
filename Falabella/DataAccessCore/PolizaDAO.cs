using Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DataAccessCore
{
    /// <summary>
    /// AAB (Diciembre 30, 2018)
    /// Conexión de datos de una póliza
    /// </summary>
    public class PolizaDAO
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Retorna las pólizas según el id de la aseguradora  
        /// </summary>
        /// <param name="idAseguradora">Id aseguradora</param>
        /// <returns>Lista de pólizas</returns>
        public static List<Poliza> DarPolizasXidAseguradora(int idAseguradora)
        {
            try
            {
                Poliza PolizaAseguradora = new Poliza();
                List<Poliza> Polizas = new List<Poliza>();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "DarPolizasXidAseguradora";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "idAseguradora", DbType.Int32, idAseguradora);
                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    for (int i = 0; i <  ds.Tables[0].Rows.Count; i++)
                    {
                        PolizaAseguradora = new Poliza();
                        PolizaAseguradora.IdPoliza = int.Parse(ds.Tables[0].Rows[i]["idPoliza"].ToString());
                        PolizaAseguradora.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                        PolizaAseguradora.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
                        PolizaAseguradora.Cobertura = ds.Tables[0].Rows[i]["cobertura"].ToString();
                        PolizaAseguradora.Porcentajes = new List<PorcentajeCobertura>();
                        PolizaAseguradora.Porcentajes = DarPorcentajeCoberturaXidPoliza(PolizaAseguradora.IdPoliza);
                        Polizas.Add(PolizaAseguradora);
                    }
                }
                return Polizas;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("PolizaDAO:DarPolizasXidAseguradora: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Retorna la lista de porcentajes de las pólizas para el cálculo de las primas 
        /// </summary>
        /// <param name="idPoliza"></param>
        /// <returns>Lista de porcentajes de las polizas según el id de la poliza</returns>
        public static List<PorcentajeCobertura> DarPorcentajeCoberturaXidPoliza(int idPoliza)
        {
            try
            {
                PorcentajeCobertura PorcentajeCobertura = new PorcentajeCobertura();
                List<PorcentajeCobertura> PorcentajesCobertura = new List<PorcentajeCobertura>();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "DarPorcentajesPolizasXidPoliza";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "idpoliza", DbType.Int32, idPoliza);
                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PorcentajeCobertura = new PorcentajeCobertura();
                        PorcentajeCobertura.IdCobertura = int.Parse(ds.Tables[0].Rows[i]["idCobertura"].ToString());
                        PorcentajeCobertura.Tipo = ds.Tables[0].Rows[i]["tipo"].ToString();
                        PorcentajeCobertura.Porcentaje = float.Parse(ds.Tables[0].Rows[i]["porcentaje"].ToString());                   
                        PorcentajesCobertura.Add(PorcentajeCobertura);
                    }
                }
                return PorcentajesCobertura;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("PolizaDAO:DarPorcentajeCoberturaXidPoliza: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }


        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Retorna el porcentaje
        /// </summary>
        /// <param name="idPorcentaje"></param>
        /// <returns>Porcentaje</returns>
        public static PorcentajeCobertura DarPorcentajeCoberturaXidPorcentaje(int idPorcentaje)
        {
            try
            {
                PorcentajeCobertura PorcentajeCobertura = new PorcentajeCobertura();              
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "DarPorcentajesPolizaXidPorcentaje";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "idCobertura", DbType.Int32, idPorcentaje);
                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    if (ds.Tables[0].Rows.Count > 0)
                    {                                            
                        PorcentajeCobertura.IdCobertura = int.Parse(ds.Tables[0].Rows[0]["idCobertura"].ToString());
                        PorcentajeCobertura.Tipo = ds.Tables[0].Rows[0]["tipo"].ToString();
                        PorcentajeCobertura.Porcentaje = float.Parse(ds.Tables[0].Rows[0]["porcentaje"].ToString());                      
                    }
                }
                return PorcentajeCobertura;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("PolizaDAO:DarPorcentajeCoberturaXidPorcentaje: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }




        /// <summary>
        /// AAB (Diciembre 30, 2018) 
        /// Agrega una nueva poliza y retorna la lista final resultante 
        /// </summary>
        /// <param name="poliza">Poliza agregada</param>
        /// <returns>Lista de polizas</returns>
        public static List<Poliza> AgregarPoliza(Poliza poliza)
        {
            try
            {
                Poliza PolizaAseguradora= new Poliza();
                List<Poliza> Polizas= new List<Poliza>();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "AgregarPoliza";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "nombre", DbType.String, poliza.Nombre);
                    db.AddInParameter(dbCommand, "descripcion", DbType.String, poliza.Descripcion);
                    db.AddInParameter(dbCommand, "cobertura", DbType.String, poliza.Cobertura);
                    db.AddInParameter(dbCommand, "idAseguradora", DbType.Int32, poliza.IdAseguradora);

                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PolizaAseguradora = new Poliza();
                        PolizaAseguradora.IdPoliza = int.Parse(ds.Tables[0].Rows[i]["idPoliza"].ToString());
                        PolizaAseguradora.IdAseguradora = int.Parse(ds.Tables[0].Rows[i]["idAseguradora"].ToString());
                        PolizaAseguradora.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                        PolizaAseguradora.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
                        PolizaAseguradora.Cobertura= ds.Tables[0].Rows[i]["cobertura"].ToString();                    
                        Polizas.Add(PolizaAseguradora);
                    }
                }
                return Polizas;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("PolizaDAO:AgregarPoliza: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }



        /// <summary>
        /// AAB (Diciembre 30, 2018) 
        /// Agrega un porcentaje nuevo a la poliza para el calculo de la prima y retorna la lista final resultante 
        /// </summary>
        /// <param name="porcentaje">Porcentaje agregado</param>
        /// <returns>Lista de Porcentaje</returns>
        public static List<PorcentajeCobertura> AgregarPorcentaje(PorcentajeCobertura porcentaje)
        {
            try
            {
                PorcentajeCobertura PorcentajePoliza = new PorcentajeCobertura();
                List<PorcentajeCobertura> Porcentajes = new List<PorcentajeCobertura>();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "AgregarPorcentajeCobertura";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "tipo", DbType.String, porcentaje.Tipo);
                    db.AddInParameter(dbCommand, "idPoliza", DbType.Int32, porcentaje.IdPoliza);
                    db.AddInParameter(dbCommand, "porcentaje", DbType.Double, porcentaje.Porcentaje);                    

                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PorcentajePoliza = new PorcentajeCobertura();
                        PorcentajePoliza.IdPoliza = int.Parse(ds.Tables[0].Rows[i]["idPoliza"].ToString());
                        PorcentajePoliza.IdCobertura = int.Parse(ds.Tables[0].Rows[i]["idCobertura"].ToString());
                        PorcentajePoliza.Tipo = ds.Tables[0].Rows[i]["tipo"].ToString();
                        PorcentajePoliza.Porcentaje = float.Parse(ds.Tables[0].Rows[i]["porcentaje"].ToString());                      
                        Porcentajes.Add(PorcentajePoliza);
                    }
                }
                return Porcentajes;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("PolizaDAO:AgregarPorcentaje: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }
    }
}

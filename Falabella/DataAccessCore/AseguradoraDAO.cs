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
    /// Conexión de datos de una aseguradora
    /// </summary>
    public class AseguradoraDAO
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018) 
        /// Retorna las aseguradoras aliadas que existan en la Data
        /// </summary>
        /// <returns>Lista de aseguradoras</returns>
        public static List<Aseguradora> DarAseguradoras()
        {
            try
            {
                Aseguradora AseguradoraAliada = new Aseguradora();
                List<Aseguradora> Aseguradoras = new List<Aseguradora>();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "DarAseguradoras";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AseguradoraAliada = new Aseguradora();
                        AseguradoraAliada.IdAseguradora = int.Parse(ds.Tables[0].Rows[i]["idAseguradora"].ToString());
                        AseguradoraAliada.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                        AseguradoraAliada.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
                        AseguradoraAliada.Logo = ds.Tables[0].Rows[i]["logo"].ToString();
                        AseguradoraAliada.Polizas = new List<Poliza>();
                        AseguradoraAliada.Polizas = PolizaDAO.DarPolizasXidAseguradora(AseguradoraAliada.IdAseguradora);
                        Aseguradoras.Add(AseguradoraAliada);
                    }
                }
                return Aseguradoras;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("AseguradoraDAO:DarAseguradoras: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018) 
        /// Agrega una nueva aseguradora y retorna la lista final resultante 
        /// </summary>
        /// <param name="aseguradora">Aseguradora agregada</param>
        /// <returns>Lista de aseguradoras</returns>
        public static List<Aseguradora> AgregarAseguradora(Aseguradora aseguradora)
        {
            try
            {
                Aseguradora AseguradoraAliada = new Aseguradora();
                List<Aseguradora> Aseguradoras = new List<Aseguradora>();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "AgregarAseguradora";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "nombre", DbType.String, aseguradora.Nombre);
                    db.AddInParameter(dbCommand, "descripcion", DbType.String, aseguradora.Descripcion);
                    db.AddInParameter(dbCommand, "logo", DbType.String, aseguradora.Logo);

                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AseguradoraAliada = new Aseguradora();
                        AseguradoraAliada.IdAseguradora = int.Parse(ds.Tables[0].Rows[i]["idAseguradora"].ToString());
                        AseguradoraAliada.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                        AseguradoraAliada.Descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
                        AseguradoraAliada.Logo = ds.Tables[0].Rows[i]["logo"].ToString();
                        AseguradoraAliada.Polizas = new List<Poliza>();
                        AseguradoraAliada.Polizas = PolizaDAO.DarPolizasXidAseguradora(AseguradoraAliada.IdAseguradora);
                        Aseguradoras.Add(AseguradoraAliada);
                    }
                }
                return Aseguradoras;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("AseguradoraDAO:AgregarAseguradora: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }
    }
}

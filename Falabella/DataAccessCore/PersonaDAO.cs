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
    /// Maneja la conexión de datos de una persona
    /// </summary>
    public class PersonaDAO
    {

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agregar Persona
        /// </summary>
        /// <param name="persona">Persona</param>
        /// <returns></returns>
        public static int AgregarPersona(Persona persona)
        {
            try
            {
                int idPersona = 0;
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "AgregarPersona";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "nombre", DbType.String, persona.Nombre);
                    db.AddInParameter(dbCommand, "apellidos", DbType.String, persona.Apellidos);
                    db.AddInParameter(dbCommand, "cumpleanios", DbType.DateTime, persona.FechaNacimiento);
                    db.AddInParameter(dbCommand, "direccion", DbType.String, persona.Direccion);
                    db.AddInParameter(dbCommand, "telefono", DbType.String, persona.Telefono);
                    db.AddInParameter(dbCommand, "celular", DbType.String, persona.Celular);
                    db.AddInParameter(dbCommand, "identificacion", DbType.String, persona.Identificcion);
                    db.AddInParameter(dbCommand, "idTipoIdentificacion", DbType.Int32, persona.TipoIdentificacion.IdTipo);
                    string dbResponse = db.ExecuteScalar(dbCommand).ToString();
                    int.TryParse(dbResponse, out idPersona);
                }
                return idPersona;

            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("PersonaDAO:AgregarPersona: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Retorna la lista de tipos identificación
        /// </summary>
        /// <returns></returns>
        public static List<TipoDocumento> DarTiposDocumento()
        {
            try
            {
                TipoDocumento TipoDocumento = new TipoDocumento();
                List<TipoDocumento> TipoDocumentos = new List<TipoDocumento>();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "DarTiposIdentificacion";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TipoDocumento = new TipoDocumento();
                        TipoDocumento.IdTipo= int.Parse(ds.Tables[0].Rows[i]["idTipoIdentificacion"].ToString());
                        TipoDocumento.Nombre = ds.Tables[0].Rows[i]["descripcion"].ToString();                       
                        TipoDocumentos.Add(TipoDocumento);
                    }
                }
                return TipoDocumentos;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("PersonaDAO:DarTiposDocumento: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }
    }
}

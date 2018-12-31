using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Entidades;

namespace DataAccessCore
{
    /// <summary>
    /// AAB (Diciembre 30, 2018)
    /// Maneja la conexión de datos de un usuario  
    /// </summary>
    public class UsuarioDAO
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Autentica al usuario    
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="usuario"></param>
        /// <returns>Si el usuario existe retorna los datos del usuario</returns>
        public static Usuario AutenticarUsuario(string pass, string usuario)
        {
            try
            {
                Usuario usuarioLogin = new Usuario();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "AutenticarUsuario";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "usuario", DbType.String, usuario);
                    db.AddInParameter(dbCommand, "pass", DbType.String, pass);
                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        usuarioLogin.IdUsuario = int.Parse(ds.Tables[0].Rows[0]["idUsuario"].ToString());
                        usuarioLogin.Nombre = ds.Tables[0].Rows[0]["nombre"].ToString();
                        usuarioLogin.Apellidos = ds.Tables[0].Rows[0]["apellidos"].ToString();
                    }
                }
                return usuarioLogin;

            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("UsuarioDAO:AutenticarUsuario: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }
    }
}

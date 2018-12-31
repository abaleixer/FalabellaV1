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
    ///  AAB (Diciembre 30, 2018)
    /// Maneja la conexión de datos del cliente
    /// </summary>
    public class ClienteDAO
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agregar Cliente
        /// </summary>
        /// <param name="cliente">cliente</param>
        /// <returns>Id del cliente</returns>
        public static int AgregarCliente(Cliente cliente)
        {
            try
            {
                int idCliente = 0;
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "AgregarCliente";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    db.AddInParameter(dbCommand, "idPersona", DbType.Int32, cliente.IdPersona);
                    db.AddInParameter(dbCommand, "idPoliza", DbType.Int32, cliente.Poliza.IdPoliza);
                    db.AddInParameter(dbCommand, "idCobertura", DbType.Int32, cliente.Porcentaje.IdCobertura);
                    db.AddInParameter(dbCommand, "valorPrima", DbType.Decimal, cliente.ValorPrima);
                    string dbResponse = db.ExecuteScalar(dbCommand).ToString();
                    int.TryParse(dbResponse, out idCliente);                    
                }
                return idCliente;

            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("ClienteDAO:AgregarCliente: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }


        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Retorna la lista de clientes con todos sus datos
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> DarClientes()
        {
            try
            {
                Cliente ClienteA = new Cliente();
                List<Cliente> Clientes = new List<Cliente>();
                Database db = DatabaseFactory.CreateDatabase();
                string sqlCommand = "DarClientes";
                using (DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand))
                {                 
                    DataSet ds = db.ExecuteDataSet(dbCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClienteA = new Cliente();
                        ClienteA.IdCliente = int.Parse(ds.Tables[0].Rows[i]["idCliente"].ToString()); 
                        ClienteA.Identificcion = ds.Tables[0].Rows[i]["identificacion"].ToString();
                        ClienteA.IdPersona = int.Parse(ds.Tables[0].Rows[i]["idPersona"].ToString());
                        ClienteA.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                        ClienteA.Apellidos = ds.Tables[0].Rows[i]["apellidos"].ToString();
                        ClienteA.Telefono = ds.Tables[0].Rows[i]["telefono"].ToString();
                        ClienteA.Celular = ds.Tables[0].Rows[i]["celular"].ToString();
                        ClienteA.Poliza = new Poliza();
                        ClienteA.Poliza.IdPoliza = int.Parse(ds.Tables[0].Rows[i]["idPoliza"].ToString());
                        ClienteA.Poliza.Nombre = ds.Tables[0].Rows[i]["nombrePoliza"].ToString();
                        ClienteA.Porcentaje = new PorcentajeCobertura();
                        ClienteA.Porcentaje.IdCobertura = int.Parse(ds.Tables[0].Rows[i]["idCobertura"].ToString());
                        ClienteA.Porcentaje.Porcentaje = float.Parse(ds.Tables[0].Rows[i]["porcentaje"].ToString());
                        ClienteA.Porcentaje.Tipo = ds.Tables[0].Rows[i]["tipo"].ToString();
                        ClienteA.ValorPrima = float.Parse(ds.Tables[0].Rows[i]["valorPrima"].ToString());
                        ClienteA.FechaCompra = DateTime.Parse(ds.Tables[0].Rows[i]["fechaCompra"].ToString());
                        Clientes.Add(ClienteA);
                    }
                }
                return Clientes;
            }
            catch (Exception e)
            {
                Util.EventLogger.WriteLog("ClienteDAO:DarClientes: " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                throw e;
            }
        }
    }
}

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
    /// Maneja la logica de un cliente
    /// </summary>
    public class ManejadorCliente
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agrega un cliente con los datos de la compra
        /// </summary>
        /// <param name="cliente"></param>
        public int AgregarCliente(Cliente cliente)
        {         
            return ClienteDAO.AgregarCliente(cliente);
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Retornar lista de clientes
        /// </summary>
        /// <returns></returns>
        public List<Cliente> DarClientes()
        {
            return ClienteDAO.DarClientes();
        }
    }
}

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
    /// Manejador encargado de la lógica de los usuarios
    /// </summary>
    public class ManejadorUsuario
    {
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// 
        /// </summary>
        /// <param name="pass">Contraseña del usuario</param>
        /// <param name="usuario">Usuario</param>
        /// <returns>Usuario autenticado</returns>
        public Usuario AutenticarUsuairo(string pass, string usuario)
        {
            UsuarioDAO UsuarioDAO = new UsuarioDAO();
            string passCripto = Util.CryptograpchicManager.GetHash(pass); 
            return UsuarioDAO.AutenticarUsuario(passCripto, usuario);
        }

    }
}

using Entidades;
using ManejadoresCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguros_Falabella
{
    public partial class Login : System.Web.UI.Page
    {
        ManejadorUsuario ManUsuario = new ManejadorUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Session.RemoveAll();
                txbUsuario.Text = "";
                txbPass.Text = "";
            }
        }

        /// <summary>
        /// Creado: *(AAB Diciembre 30, 2018)*
        /// Ejecuta la acción de comprobar la autenticación del usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txbUsuario.Text.Length <= 3 || txbPass.Text.Length <= 3)
            {
            
                //Carga el efecto de advertencia  para el usuario. La función esta en js
                //string script = @"<script type='text/javascript'>document.getElementById('mensaje').className = 'aab-mostrar';</script>";               
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
            }
            else
            {
                if (AutenticarUsuario() == true)
                {                            
                    Response.Redirect("Default.aspx");
                }
            }
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Ejecuta la acción de autenticar al usuario
        /// </summary>
        /// <returns>Bolean que confirma si el usuario fue autenticado</returns>
        private bool AutenticarUsuario()
        {
            bool autenticado = false;
            Usuario usuario = new Usuario();
            string user = txbUsuario.Text;
            string pass = txbPass.Text;
            usuario = ManUsuario.AutenticarUsuairo(pass, user);
            if (usuario.IdUsuario != 0)
            {
                Session.Add("usuario", usuario);
               //  ReportarProcesoUsuario();
                autenticado = true;
            }
            else
            {
                lblMensaje.Text = "El usuario o la contraseña no coinciden";
            }
            return autenticado;
        }

        ////private void ReportarProcesoUsuario()
        ////{

        ////    Usuario usuario = (Usuario)Session["usuario"];          
        ////    string strClientIP;
        ////    strClientIP = Request.UserHostAddress;
        ////  //  ManUsuario.generarMovimientoUsuario(usuario.Id, "El usuario ha Iniciado Sesión", strClientIP);

        ////}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguros_Falabella
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // AAB (Diciembre 30 2018)
            // Verifica el estado de la sesión 
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/Index.aspx");
            }
        }
    }
}
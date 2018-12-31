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
    public partial class _Default : Page
    {
        ManejadorAseguradora ManAseguradora = new ManejadorAseguradora();

        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Carga los datos
        /// </summary>
        private void CargarDatos()
        {
            List<Aseguradora> Aseguradoras = new List<Aseguradora>();
            Aseguradoras = ManAseguradora.DarAseguradoras();

            for(int i = 0; i< Aseguradoras.Count; i++)
            {              

                string polizasTxt = "";
                for (int j = 0; j < Aseguradoras[i].Polizas.Count; j++) {
                    polizasTxt += "<h4>"+ Aseguradoras[i].Polizas[j].Nombre  + "</h4>";
                    polizasTxt += "<p>"+ Aseguradoras[i].Polizas[j].Descripcion + "</p>";

                    string PorcentajesTxt = "";
                    for (int l = 0; l < Aseguradoras[i].Polizas[j].Porcentajes.Count; l++)
                    {
                        PorcentajesTxt += "<h4> Tipo de póliza " + Aseguradoras[i].Polizas[j].Porcentajes[l].Tipo + "</h4>";
                        PorcentajesTxt += "<p> Porcentaje Prima  " + Aseguradoras[i].Polizas[j].Porcentajes[l].Porcentaje + "</p>";
                    }
                    polizasTxt += "<div>" + PorcentajesTxt + "</div>";

                }
                string aseguradoraTxt = "<div class='col-md-4 col-xs-12 col-sm-6 col-lg-3'>"
                  + " <img src='"+ Aseguradoras[i].Logo +"'/> "
                  //+ "<h2>" + Aseguradoras[i].Nombre + "</h2>"
                  + "<p>" + Aseguradoras[i].Descripcion + "</p>"
                  + polizasTxt
                  + "</div>";
                ltrAseguradora.Text += aseguradoraTxt;
            }            
        }
    }
}
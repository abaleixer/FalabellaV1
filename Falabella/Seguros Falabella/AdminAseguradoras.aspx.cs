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
    public partial class AdminAseguradoras : System.Web.UI.Page
    {
        ManejadorAseguradora ManAseguradora = new ManejadorAseguradora();
        ManejadorPoliza ManPoliza = new ManejadorPoliza();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
                pnlPolizasNew.Visible = false;
                pnlPorcentaje.Visible = false;
            }
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Carga los datos
        /// </summary>
        private void CargarDatos()
        {
            grvAseguradoras.DataSource = ManAseguradora.DarAseguradoras();
            grvAseguradoras.DataBind();
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agrega una aseguradora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarAseguradora_Click(object sender, EventArgs e)
        {
            if (txbNombre.Text.Length > 2 && txbDescripcion.Text.Length > 2 && txbLogo.Text.Length > 2)
            {
                Aseguradora AseguradoraAgregar = new Aseguradora();
                AseguradoraAgregar.Nombre = txbNombre.Text;
                AseguradoraAgregar.Descripcion = txbDescripcion.Text;
                AseguradoraAgregar.Logo = txbLogo.Text;

                grvAseguradoras.DataSource = ManAseguradora.AgregarAseguradora(AseguradoraAgregar);
                grvAseguradoras.DataBind();

                txbNombre.Text = "";
                txbDescripcion.Text = "";
                txbLogo.Text = "";
            }
        }

        protected void grvAseguradoras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName  == "AgregarPoliza")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grvAseguradoras.Rows[index];
                int idAseguradora = Convert.ToInt32(row.Cells[0].Text);
                ViewState["idAseguradora"] = idAseguradora.ToString();
                DarPolizasXidAseguradora(idAseguradora);
                pnlPolizasNew.Visible = true;
                ltrH3.Text = "<h3> Polizas de "+ row.Cells[1].Text + "</h3>";
            }
        }

        private void DarPolizasXidAseguradora(int idAseguradora)
        {
            grvPolizas.DataSource =  ManPoliza.DarPolizasXidAseguradora(idAseguradora);
            grvPolizas.DataBind();            
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agregar póiliza a la aseguradora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarPoliza_Click(object sender, EventArgs e)
        {
            Poliza PolizaAgregar = new Poliza();
            PolizaAgregar.Nombre = txbNombrePoliza.Text;
            PolizaAgregar.Descripcion = txbDescripcionPoliza.Text;
            PolizaAgregar.Cobertura = txbCobertura.Text;
            PolizaAgregar.IdAseguradora = int.Parse(ViewState["idAseguradora"].ToString());

            grvPolizas.DataSource = ManPoliza.AgregarPoliza(PolizaAgregar);
            grvPolizas.DataBind();

            txbNombrePoliza.Text = "";
            txbDescripcionPoliza.Text = "";
            txbCobertura.Text = "";

        }

       
        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvPolizas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "AgregarPorcentaje")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grvPolizas.Rows[index];
                int idPoliza = Convert.ToInt32(row.Cells[0].Text);
                ViewState["idPoliza"] = idPoliza.ToString();
                DarPorcentajeXidPoliza(idPoliza);
                pnlPorcentaje.Visible = true;
                ltrPorcentajePoliza.Text = "<h3> Porcentaje de la póliza " + row.Cells[1].Text + "</h3>";
            }
          
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Carga los porcentajes de la poliza
        /// </summary>
        /// <param name="idPoliza">Id de la poliza</param>
        private void DarPorcentajeXidPoliza(int idPoliza)
        {
            grvPorcentajes.DataSource = ManPoliza.DarPorcentajesPoliza(idPoliza);
            grvPorcentajes.DataBind();
        }

        /// <summary>
        /// AAB (Diciembre 30, 2018)
        /// Agrega el porcentaje de la prima de la poliza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarPorcentaje_Click1(object sender, EventArgs e)
        {
            float porcentage = 0;
            float.TryParse(txbPorcentaje.Text, out porcentage);
            if (porcentage > 0)
            {
                PorcentajeCobertura PorcentajePoliza = new PorcentajeCobertura();
                PorcentajePoliza.Tipo = txbTipo.Text;
                PorcentajePoliza.Porcentaje = porcentage;
                PorcentajePoliza.IdPoliza = int.Parse(ViewState["idPoliza"].ToString());

                grvPorcentajes.DataSource = ManPoliza.AgragarPorcentaje(PorcentajePoliza);
                grvPorcentajes.DataBind();

                txbTipo.Text = "";
                txbPorcentaje.Text = "";
            }
        }
    }
}
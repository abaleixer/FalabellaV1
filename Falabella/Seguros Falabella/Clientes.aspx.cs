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
    public partial class Clientes : System.Web.UI.Page
    {
        ManejadorAseguradora ManAseguradora = new ManejadorAseguradora();
        ManejadorPoliza ManPoliza = new ManejadorPoliza();
        ManejadorPersona ManPersona = new ManejadorPersona();
        ManejadorCliente ManCliente = new ManejadorCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        /// <summary>
        /// AAB( Diciembre 30, 2018)
        /// Carga los datos del formulario
        /// </summary>
        private void CargarDatos()
        {
            ddlTipoIdentificacion.DataSource = ManPersona.DarTiposDocumento(); ;
            ddlTipoIdentificacion.DataTextField = "Nombre";
            ddlTipoIdentificacion.DataValueField = "IdTipo";
            ddlTipoIdentificacion.DataBind();
                      
            ddlAseguradora.DataSource = ManAseguradora.DarAseguradoras();
            ddlAseguradora.DataTextField = "Nombre";
            ddlAseguradora.DataValueField = "IdAseguradora";
            ddlAseguradora.DataBind();
            ddlAseguradora.Items.Insert(0, new ListItem("Seleccione", "-1"));

            grvClientes.DataSource = ManCliente.DarClientes();
            grvClientes.DataBind();

        }

        /// <summary>
        /// AAB( Diciembre 30, 2018)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlAseguradora_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAseguradora = 0;
            int.TryParse(ddlAseguradora.SelectedValue,out idAseguradora);
            if (idAseguradora > 0)
            {
                ddlPolizas.DataSource = ManPoliza.DarPolizasXidAseguradora(idAseguradora);
                ddlPolizas.DataTextField = "Nombre";
                ddlPolizas.DataValueField = "IdPoliza";
                ddlPolizas.DataBind();
                ddlPolizas.Items.Insert( 0, new ListItem("Seleccione", "-1"));              
            }
        }

        /// <summary>
        /// AAB( Diciembre 30, 2018)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPolizas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPoliza = 0;
            int.TryParse(ddlPolizas.SelectedValue, out idPoliza);
            if (idPoliza > 0)
            {
                ddlTiposPolizas.DataSource = ManPoliza.DarPorcentajesPoliza(idPoliza);
                ddlTiposPolizas.DataTextField = "Tipo";
                ddlTiposPolizas.DataValueField = "IdCobertura";
                ddlTiposPolizas.DataBind();
                ddlTiposPolizas.Items.Insert(0, new ListItem("Seleccione", "-1"));
            }
        }


        /// <summary>
        /// AAB( Diciembre 30, 2018)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTiposPolizas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPorcentaje = 0;
            int.TryParse(ddlTiposPolizas.SelectedValue, out idPorcentaje);
            float valorAsegurado = 0;
            float porcentaje = 0;
            porcentaje = ManPoliza.DarPorcentajeCoberturaXidPorcentaje(idPorcentaje).Porcentaje;
            float.TryParse(txbValorAsegurado.Text,out valorAsegurado);
            float total = valorAsegurado * porcentaje / 1000; 
            lblTotalPrimaPoliza.Text = total.ToString();
        }

        /// <summary>
        /// AAB( Diciembre 30, 2018)
        /// Agrega el cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (txbNombre.Text.Length > 2 && txbApeliidos.Text.Length > 2 && txbCumpleanios.Text.Length > 2 && 
                txbIdentificacion.Text.Length > 2 && txbDireccion.Text.Length > 2 && txbTelefono.Text.Length > 2 && 
                txbCelular.Text.Length > 2 && txbValorAsegurado.Text.Length > 2)
            {
             
                Cliente cliente = new Cliente();
                cliente.Nombre = txbNombre.Text;
                cliente.Apellidos = txbApeliidos.Text;
                cliente.FechaNacimiento = DateTime.Parse(txbCumpleanios.Text);
                cliente.Identificcion = txbIdentificacion.Text;
                cliente.Direccion = txbDireccion.Text;
                cliente.Telefono = txbTelefono.Text;
                cliente.Celular = txbCelular.Text;
                cliente.TipoIdentificacion = new TipoDocumento();
                cliente.TipoIdentificacion.IdTipo =  int.Parse(ddlTipoIdentificacion.SelectedValue);

                cliente.IdPersona = ManPersona.AgregarPersona(cliente);
                cliente.Poliza = new Poliza();
                cliente.Poliza.IdPoliza = int.Parse(ddlPolizas.SelectedValue);
                cliente.Porcentaje = new PorcentajeCobertura();
                cliente.Porcentaje.IdCobertura = int.Parse(ddlTiposPolizas.SelectedValue);
                cliente.ValorPrima = float.Parse(lblTotalPrimaPoliza.Text);                

                ManCliente.AgregarCliente(cliente);

                Response.Redirect("~/Clientes.aspx");
            }
        }

    }
}
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Seguros_Falabella.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="aab-card-m" style="display:block">
    <h3>Agregar Venta Cliente</h3>
        <asp:TextBox placeholder="Nombre" ID="txbNombre" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox placeholder="Apellidos" ID="txbApeliidos" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox TextMode="Date" placeholder="Cumpleaños" ID="txbCumpleanios" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>

            <asp:DropDownList ID="ddlTipoIdentificacion" runat="server"></asp:DropDownList>

        <asp:TextBox placeholder="Identificación" ID="txbIdentificacion" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox  placeholder="Dirección" ID="txbDireccion" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox TextMode="Phone" placeholder="Teléfono" ID="txbTelefono" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox TextMode="Phone" placeholder="Celular" ID="txbCelular" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>

             <asp:TextBox TextMode="Number" placeholder="Valor Asegurado" ID="txbValorAsegurado" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>

            <asp:DropDownList AutoPostBack="true" ID="ddlAseguradora" runat="server" OnSelectedIndexChanged="ddlAseguradora_SelectedIndexChanged">                
            </asp:DropDownList>
            <asp:DropDownList AutoPostBack="true" ID="ddlPolizas" runat="server" OnSelectedIndexChanged="ddlPolizas_SelectedIndexChanged">             
            </asp:DropDownList>
            <asp:DropDownList  AutoPostBack="true" ID="ddlTiposPolizas" runat="server" OnSelectedIndexChanged="ddlTiposPolizas_SelectedIndexChanged">               
            </asp:DropDownList>

            <label>Total valor de la prima  $   <asp:Label runat="server" ID="lblTotalPrimaPoliza"></asp:Label></label> 

            <asp:Button runat="server" CssClass="aab-btn aab-btn-verde" ID="btnAgregarCliente"  Text="Agregar" OnClick="btnAgregarCliente_Click"  />

    </div>

    <h3>Lista Clientes</h3>

       <asp:GridView class="table table-bordered" ID="grvClientes" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos"/>
            <asp:BoundField DataField="Identificcion" HeaderText="Identificacion"/>    
            
             <asp:BoundField DataField="Telefono" HeaderText="Telefono"/>    
             <asp:BoundField DataField="Celular" HeaderText="Celular"/>    
             <asp:BoundField DataField="ValorPrima" HeaderText="Valor Prima"/>    
             <asp:BoundField DataField="FechaCompra" HeaderText="Fecha Compra"/>    
        </Columns>
    </asp:GridView>
    
</asp:Content>

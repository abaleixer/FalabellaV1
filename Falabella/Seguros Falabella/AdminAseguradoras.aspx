<%@ Page Title="Admin Aseguradoras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminAseguradoras.aspx.cs" Inherits="Seguros_Falabella.AdminAseguradoras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Button CssClass="aab-btn aab-btn-verde aab-btn-agregar" ID="btnMostrarAseguradora" runat="server"  Text="Agregar Aseguradora" OnClientClick="IsFormulario(); return false;"/>
    <div id="aab-add-aseguradora" class="aab-card-m" style="display:none;">
        <asp:TextBox placeholder="Nombre" ID="txbNombre" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox placeholder="Descripción"  ID="txbDescripcion" CssClass="aab-txb  aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox placeholder="Logo" ID="txbLogo" CssClass="aab-txb  aab-txb-liner" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="aab-btn aab-btn-verde" ID="btnAgregarAseguradora" OnClick="btnAgregarAseguradora_Click" Text="Agregar"/>
    </div>

    <asp:GridView class="table table-bordered" ID="grvAseguradoras" runat="server" AutoGenerateColumns="false" OnRowCommand="grvAseguradoras_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdAseguradora" HeaderText="Id"/>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
            <asp:ButtonField ControlStyle-CssClass="aab-btn aab-btn-verde-simple" ButtonType="Button"  CommandName="AgregarPoliza" Text="Agregar Poliza"/>
                       
        </Columns>
    </asp:GridView>

    <asp:Literal runat="server" ID="ltrH3"></asp:Literal>

    <asp:Panel ID="pnlPolizasNew" runat="server">
        <div class="aab-card-m" style="display:block">
        <asp:TextBox placeholder="Nombre" ID="txbNombrePoliza" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox placeholder="Descripción"  ID="txbDescripcionPoliza" CssClass="aab-txb  aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox placeholder="Cobertura"  ID="txbCobertura" CssClass="aab-txb  aab-txb-liner" runat="server"></asp:TextBox>
        <asp:Button runat="server" CssClass="aab-btn aab-btn-verde" ID="btnAgregarPoliza"  Text="Agregar" OnClick="btnAgregarPoliza_Click" />

      <asp:GridView class="table table-bordered" ID="grvPolizas" runat="server" AutoGenerateColumns="false" OnRowCommand="grvPolizas_RowCommand">
        <Columns>
            <asp:BoundField DataField="IdPoliza" HeaderText="Id"/>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
             <asp:BoundField DataField="Cobertura" HeaderText="Cobertura"/>
            <asp:ButtonField ControlStyle-CssClass="aab-btn aab-btn-verde-simple" ButtonType="Button"  CommandName="AgregarPorcentaje" Text="Agregar Porcentaje"/>                       
        </Columns>
    </asp:GridView>
    </div>
    </asp:Panel>



     <asp:Literal runat="server" ID="ltrPorcentajePoliza"></asp:Literal>
     <asp:Panel ID="pnlPorcentaje" runat="server">

        <div class="aab-card-m" style="display:block">
        <asp:TextBox placeholder="Tipo Póliza" ID="txbTipo" CssClass="aab-txb aab-txb-liner" runat="server"></asp:TextBox>
        <asp:TextBox TextMode="Number" step="0.01" placeholder="Porcentaje Prima"  ID="txbPorcentaje" CssClass="aab-txb  aab-txb-liner" runat="server"></asp:TextBox>        
        <asp:Button runat="server" CssClass="aab-btn aab-btn-verde" ID="btnAgregarPorcentaje"  Text="Agregar" OnClick="btnAgregarPorcentaje_Click1" />

      <asp:GridView class="table table-bordered" ID="grvPorcentajes" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="IdCobertura" HeaderText="Id"/>
            <asp:BoundField DataField="Tipo" HeaderText="Tipo Poliza"/>
            <asp:BoundField DataField="porcentaje" HeaderText="Porcentaje Prima"/>                    
        </Columns>
    </asp:GridView>
    </div>
    </asp:Panel>
</asp:Content>

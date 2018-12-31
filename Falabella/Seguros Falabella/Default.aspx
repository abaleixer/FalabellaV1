<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Seguros_Falabella._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <a runat="server" href="~/AdminAseguradoras" class="aab-btn aab-btn-verde">Admnistrar Aseguradoras</a> 
    <div class="jumbotron">
        <h1>Seguros Falabella</h1>
        <p class="lead">Porque ellos también necesitan que los consientan y los cuiden como se merecen, por eso en Seguros Falabella estamos siempre contigo para ayudarte en los cuidados que necesita tu mascota: Permite a su asegurado tener cobertura y asistencia completa en caso de que su mascota sufra alguna eventualidad.</p>
      
    </div>

    <div class="row">

<asp:Literal runat="server" ID="ltrAseguradora"></asp:Literal>
         
    </div>

</asp:Content>

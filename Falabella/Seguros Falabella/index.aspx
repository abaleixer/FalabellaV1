<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Seguros_Falabella.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Falabella</title>

        <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/falabella") %>
    </asp:PlaceHolder>

     <webopt:bundlereference runat="server" path="~/Content/css" />
</head>
<body class="row">
    <form id="form1" runat="server">
                 <asp:ScriptManager runat="server">
            <Scripts>              
                <%--Scripts de marco--%>            
                <asp:ScriptReference Name="jquery" />              
                <%--Scripts del sitio--%>
            </Scripts>
        </asp:ScriptManager>


        <div class="col-xs-12 col-sm-offset-2 col-sm-8 col-sm-offset-2 col-md-offset-4 col-md-4 col-md-offset-4   col-lg-offset-4 col-lg-4 col-lg-offset-4 aab-card">
            <div class="aab-title">
                <img src="https://cdn-segurosfalabella.azureedge.net/web/img/vectors/logos/co-color.svg"/>          
            </div>
            <div id="aab-login">
                <asp:TextBox ID="txbUsuario"  runat="server" CssClass="aab-txb" placeholder="Usuario"></asp:TextBox>
                   <asp:TextBox ID="txbPass" TextMode="Password" runat="server" CssClass="aab-txb" placeholder="Contraseña"></asp:TextBox>
            </div>
            <asp:Label ID="lblMensaje" runat="server" CssClass="aab-mensaje" Text=""></asp:Label>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="aab-btn" OnClick="btnIngresar_Click"/>
        </div>
    </form>
</body>
</html>

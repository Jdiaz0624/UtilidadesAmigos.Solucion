<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Estilos/EstilosPaginas.css" rel="stylesheet" type="text/css" />
    <div class="Usuario-Conectado">
        <hr  />
        <div>
        <asp:Label ID="lbUsuarioConectado" runat="server" Text="Usuario Conectado"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lbDepartamento" runat="server" Text="Departamento"></asp:Label>
    </div>
    </div>
    <hr  />
</asp:Content>

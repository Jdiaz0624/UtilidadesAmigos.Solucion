<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .jumbotron{
            color:#000000;
            background:#7BC5FF;
            font-size:20px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }
    </style>

    <div class="container-fluid">
        <div align="center" class="jumbotron">

        <div>
        <asp:Label ID="lbUsuarioConectado" runat="server" Text="Usuario Conectado"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lbDepartamento" runat="server" Text="Departamento"></asp:Label>
    </div>
    </div>
    </div>
\
</asp:Content>

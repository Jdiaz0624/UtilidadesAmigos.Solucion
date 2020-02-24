<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SolicitudSeguroLey.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.SolicitudSeguroLey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#7BC5FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }

        .btn-sm{
            width:100px;
        }
          .LetrasNegrita {
          font-weight:bold;
          }


    </style>


    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="LbTitulo" runat="server" Text="Solicitud de Seguros de Ley" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbTipoServicio" runat="server" Text="lbTipoServicio" Visible="false" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbProductoSeleccionado" runat="server" Visible="false" Text="Producto Seleccionado" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <div align="center">
            <asp:Label ID="lbTipoProductoSeleccionadoNombre" runat="server" Text="Tipo Producto Seleccionado" CssClass="LetrasNegrita"></asp:Label><br />
            <asp:Label ID="lbProductoSeleccionadonombre" runat="server" Text="Producto Seleccionado" CssClass="LetrasNegrita"></asp:Label><br />
            <asp:Label ID="lbDescripcioNproducto" runat="server" Text="Descripcion" CssClass="LetrasNegrita"></asp:Label><br />
        </div>
        <hr />
    </div>
</asp:Content>

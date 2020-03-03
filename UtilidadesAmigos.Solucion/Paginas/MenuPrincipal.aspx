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

        .Imagenesxx {
        width:300px;
        height:100px;
        text-align:center;
        }

        .carousel {
        border-color:blue;
        
        }
         .LetrasNegrita {
          font-weight:bold;
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
        <div align="center">
            <asp:Label ID="lbCantidadTicketTitulo" runat="server" Text="Cantidad de Ticket Abiertos (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadTicketVariable" runat="server" ForeColor="Blue" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadTicketCerrar" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="Label7" runat="server" Text=" " CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="lbCantidadTicketCerradosTitulo" runat="server" Text="Cantidad de Ticket Cerrados (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadTicketCerradosVariables" ForeColor="Green" runat="server" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadTicketCerradosCerrar" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="Label8" runat="server" Text=" " CssClass="LetrasNegrita"></asp:Label>

             <asp:Label ID="lbCantidadTicketDeclinadosTitulo" runat="server" Text="Cantidad de Ticket Declinados (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadTicketDeclinadosVariable" runat="server" ForeColor="Red" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadTicketDeclinadosCerrar" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
        </div>
    </div>
    <br /><br />
     <div align="center">
        <button type="button" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-xl">Sugerencias</button>
    </div>
    <br /><br />
<div class="container-fluid Imagenesxx">

        <div align="center" id="carouselExampleFade" class="carousel slide carousel-fade" data-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="../Imagenes/Logo.jpg" class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="../Imagenes/login.jpg" class="d-block w-100" alt="...">
    </div>
   <div class="carousel-item">
      <img src="../Imagenes/01.jpg" class="d-block w-100" alt="...">
    </div>
      <div class="carousel-item">
      <img src="../Imagenes/02.gif" class="d-block w-100" alt="...">
    </div>
      <div class="carousel-item">
      <img src="../Imagenes/03.jpg" class="d-block w-100" alt="...">
    </div>
      <div class="carousel-item">
      <img src="../Imagenes/04.jfif" class="d-block w-100" alt="...">
    </div>
      <div class="carousel-item">
      <img src="../Imagenes/05.jfif" class="d-block w-100" alt="...">
    </div>
      <div class="carousel-item">
      <img src="../Imagenes/06.jpg" class="d-block w-100" alt="...">
    </div>
      <div class="carousel-item">
      <img src="../Imagenes/07.jpg" class="d-block w-100" alt="...">
    </div>
      <div class="carousel-item">
      <img src="../Imagenes/08.jpg" class="d-block w-100" alt="...">
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleFade" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleFade" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
</div>
   <div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      SUGERENCIAS
    </div>
  </div>
</div>

</asp:Content>

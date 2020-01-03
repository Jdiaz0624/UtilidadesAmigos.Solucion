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

</asp:Content>

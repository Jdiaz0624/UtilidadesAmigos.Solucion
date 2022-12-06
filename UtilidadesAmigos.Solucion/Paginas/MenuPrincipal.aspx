<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">

        /*.Imagenesxx {
        width:300px;
        height:100px;
        text-align:center;
        }*/

        .carousel {
        border-color:blue;
        
        }
         .LetrasNegrita {
          font-weight:bold;
          }

          .carousel-item {
      display: block;
      width: 100%;
      height: 250px;
      
}
.carousel-item img {
      height: 100%;
      width: 100%;

}

        .Cobros {
        
        width:350px;
        height:350px;
        border:dotted;
        }

        /*#fobd {
margin-top: 70px !important;
margin-bottom: -35px !important;
padding-top: 10px !important;
padding-bottom: 70px !important;*/
/*background:#ff0000;*/
/*background-position: 0 0 !important;
background-repeat: no-repeat !important;
}*/
.container {
    width: 100%;
    height: 300px;
    border: 1px solid black;
    display: -webkit-flex;  /*Safari*/ 
    display: flex;
    margin: auto;
}

.center {
text-align: center;
}

.four-column {
position: relative;
min-height: 1px;
padding-right: 15px;
padding-left: 15px;
}
.frame-item {
	padding: 1em;
    border: 1px solid #B2B2B2;
    -webkit-flex: 1;  /* Safari 6.1+ */
    -ms-flex: 1;  /* IE 10 */    
    flex: 1;
}

/*@media (min-width: 1200px){
.container {
width: 1170px;
}}
@media (min-width: 992px){
.container {
width: 970px;
}}
@media (min-width: 768px){
.container {
width: 750px;
}}

@media (min-width: 992px){
.four-column {
float: left;
width: 25%;
}}*/

        h4 {
        text-align:center;
        font-size:20px;
        }

        p {
        text-align:center;              
        font-size:100px;
        
        }

        .BotonEstadistica {
        
        width:100%;
        height:100%;
        font-size:100px;
        border:none;
        background:#ffffff;
        }

        .Rojo {
        color:#ff0000;
        }

        .Verde {
        color:green;
        }
    </style>


    <div class="container-fluid">


    <br /><br />

<div class="container-fluid Imagenesxx">
    <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
  <div class="carousel-inner">

     <div class="carousel-item active">
      <img src="../Imagenes/Logo.jpg" class="d-block w-100" alt="..." />
    </div>


  </div>

  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>




</div>

        <br />
        <br />
       <div id="fobd">
  
  <div class="container">
    <div class="frame-item">
      <h4>
        Sin Pago Inicial (0-10)
      </h4>
        <hr />

        <div>
            <asp:Button ID="btnSinPagoInicial" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnSinPagoInicial_Click" CssClass="BotonEstadistica Rojo" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Primer Pago Sin Cobro (11-30)
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnPrimerPagoSinCobros" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnPrimerPagoSinCobros_Click" CssClass="BotonEstadistica Verde" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Segundo Pago Sin Cobro (31-60) 
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnSegundoPagoSinCobros" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnSegundoPagoSinCobros_Click" CssClass="BotonEstadistica Verde" />
        </div>
    </div>
  </div>

           <br />
             <div class="container">
    <div class="frame-item">
      <h4>
        Tercer Pago Sin Cobro (60-90)
      </h4>
        <hr />

        <div>
            <asp:Button ID="btnTercerPagoSinCobros" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnTercerPagoSinCobros_Click" CssClass="BotonEstadistica Verde" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Cuarto Pago Sin Cobro (91-120)
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnCuartoPagoSinCobros" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnCuartoPagoSinCobros_Click" CssClass="BotonEstadistica Verde" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Mas de 120 dias Sin Cobro 
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnMasDeCientoVeinteDiasSinCobros" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnMasDeCientoVeinteDiasSinCobros_Click" CssClass="BotonEstadistica Verde" />
        </div>
    </div>
  </div>
           <br />
  
</div>
     </div>

</asp:Content>

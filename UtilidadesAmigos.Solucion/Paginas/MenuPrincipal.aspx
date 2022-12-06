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

         .BotonImagen {
              width: 60px;
              height: 60px;
          }

        .Tamaniocb {
        
        font-size:larger;
        }
    </style>

    <script type="text/javascript">
        function Mensaje() {
            alert("Tienes que seleccionar una opción para realizar actualizar esta información.");
        }
    </script>


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
      <div id="DivBloqueEstadistica" runat="server">
            <div align="center">
            <div align="center">
                <asp:ImageButton ID="btnActualizar" runat="server" ToolTip="Actualizar Información" CssClass="BotonImagen" ImageUrl="~/Imagenes/auto.png" OnClick="btnActualizar_Click" />
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte de Estadistica de Polizas Sin Pagos" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
                <br /><br />
                <div class="form-check-inline">
                    <asp:Label ID="lbInformacionValidar" runat="server" Text="Información a Validar" CssClass="LetrasNegrita"></asp:Label>
                    <asp:CheckBox ID="cbTodos" runat="server" Text="Todos" CssClass="form-check-inline pe-auto" AutoPostBack="true" OnCheckedChanged="cbTodos_CheckedChanged" />
                    <asp:CheckBox ID="cbSinInicial" runat="server" Text="Sin Inicial" CssClass="form-check-inline" AutoPostBack="true" OnCheckedChanged="cbSinInicial_CheckedChanged" />
                    <asp:CheckBox ID="cbPrimerPago" runat="server" Text="de 11 a 30 Dias" CssClass="form-check-inline" AutoPostBack="true" OnCheckedChanged="cbPrimerPago_CheckedChanged" />
                    <asp:CheckBox ID="cbSegundoPago" runat="server" Text="de 31 a 60 Dias" CssClass="form-check-inline" AutoPostBack="true" OnCheckedChanged="cbSegundoPago_CheckedChanged" />
                    <asp:CheckBox ID="cbTercerpago" runat="server" Text="de 61 a 90 Dias" CssClass="form-check-inline" AutoPostBack="true" OnCheckedChanged="cbTercerpago_CheckedChanged" />
                    <asp:CheckBox ID="cbCuartoPago" runat="server" Text="de 91 a 120 Dias" CssClass="form-check-inline" AutoPostBack="true" OnCheckedChanged="cbCuartoPago_CheckedChanged" />
                    <asp:CheckBox ID="cbQuintoPago" runat="server" Text="de 121 o mas" CssClass="form-check-inline" AutoPostBack="true" OnCheckedChanged="cbQuintoPago_CheckedChanged"  />
                </div>
            </div>
        </div>
       <div id="fobd">
  <h1 align="center" class="alert">Estadistica de Polizas Sin pagos</h1>
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
        Sin Pago de 11 a 30 Dias
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnPrimerPagoSinCobros" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnPrimerPagoSinCobros_Click" CssClass="BotonEstadistica Verde" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Sin pago de 31 a 60 Dias 
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
        Sin Pago de 61 a 90 Dias
      </h4>
        <hr />

        <div>
            <asp:Button ID="btnTercerPagoSinCobros" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnTercerPagoSinCobros_Click" CssClass="BotonEstadistica Verde" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Sin Pago de 91 a 120 Dias
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnCuartoPagoSinCobros" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnCuartoPagoSinCobros_Click" CssClass="BotonEstadistica Verde" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Sin pagos de mas de 120 Dias
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
     </div>

</asp:Content>

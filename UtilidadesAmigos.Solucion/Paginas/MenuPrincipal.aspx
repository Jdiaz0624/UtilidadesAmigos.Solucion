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
    height: 350px;
    border: 1px solid black;
    display: -webkit-flex;  /*Safari*/ 
    display: flex;
    margin: auto;
}

.Segundocontainer {
    width: 100%;
    height: 300px;
    border: 1px solid black;
    display: -webkit-flex;  /*Safari*/ 
    display: flex;
    margin:unset;
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


.frame-item2 {
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

        <div id="DIVBloqueImagen" runat="server">

        
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

            </div>


      <div id="DivBloqueEstadistica" runat="server">
          <br /><br />
            <div align="center">
            <div align="center">
                <asp:ImageButton ID="btnActualizar" runat="server" ToolTip="Actualizar Información" Visible="false" CssClass="BotonImagen" ImageUrl="~/Imagenes/auto.png" OnClick="btnActualizar_Click" />
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte de Estadistica de Polizas Sin Pagos" Visible="false" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
                <br /><br />
                <div id="DivBloqueCheck" runat="server" class="form-check-inline">
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
        Sin Pago 0-10 Dias
      </h4>
        <hr />

        <div>
            <asp:Button ID="btnSinInicialPrimero" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnSinInicialPrimero_Click" CssClass="BotonEstadistica Rojo" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Sin Pago de 11 a 30 Dias
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnSinInicialSegundo" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnSinInicialSegundo_Click" CssClass="BotonEstadistica Rojo" />
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Sin pago de mas de 30 Dias 
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnSinInicialTercero" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnSinInicialTercero_Click" CssClass="BotonEstadistica Rojo" />
        </div>
    </div>
  </div>

           <br />
             <div class="container">
    <div class="frame-item">
      <h4>
        Primer Pago Aplicado
      </h4>
        <hr />

        <div>
            <asp:Button ID="btnPrimerPAgoAplicado" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnPrimerPAgoAplicado_Click" CssClass="BotonEstadistica Verde" />

            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbPrimerRenglonPrimerPagoAplicado" runat="server" Text="0-30: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb0_30_PrimerPago" runat="server" Text="0"></asp:Label>
                </div>
                 <div class="col-md-6">
                    <asp:Label ID="lbSegundoReglonPrimerPago" runat="server" Text="31-60: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb31_60_PrimerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbCuartoRenglonPrimerPago" runat="server" Text="61-90: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb61_90_PrimerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbQuintoRenglonPrimerPago" runat="server" Text="91-120: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb91_120_PrimerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSextoRenglonPrimerPago" runat="server" Text="121-150: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb121_150_PrimerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSeptimoRenglonPrimerPago" runat="server" Text="151-Mas: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbMas_150_Dias_PrimerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbPolizasDiasNegativosPrimerPago" runat="server" Text="-0: " ToolTip="Este registro representa la cantidad de polizas que se renovaron por adelantado o no ha llegado el dia de inicio de vigencia" CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbDiasNegativosPrimerPago" runat="server" ForeColor="Red" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbOctavoRenglonPrimerPago" runat="server" Text="RD$: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbCantidadAcumuladaPrimerPago" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Segundo Pago Aplicado
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnSegundoPagoAplicado" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnSegundoPagoAplicado_Click" CssClass="BotonEstadistica Verde" />

            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbPrimerRenglonSegundoPagoAplicado" runat="server" Text="0-30: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb0_30_SegundoPago" runat="server" Text="0"></asp:Label>
                </div>
                 <div class="col-md-6">
                    <asp:Label ID="lbSegundoReglonSegundoPago" runat="server" Text="31-60: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb31_60_SegundoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbCuartoRenglonSegundoPago" runat="server" Text="61-90: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb61_90_SegundoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbQuintoRenglonSegundoPago" runat="server" Text="91-120: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb91_120_SegundoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSextoRenglonSegundoPago" runat="server" Text="121-150: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb121_150_SegundoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSeptimoRenglonSegundoPago" runat="server" Text="151-Mas: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb151_Mas_SegundoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbPolizasDiasNegativosSegundoPago" runat="server" Text="-0: " ToolTip="Este registro representa la cantidad de polizas que se renovaron por adelantado o no ha llegado el dia de inicio de vigencia" CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbDiasNegativosSegundoPago" runat="server" ForeColor="Red" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbOctavoRenglonSegundoPago" runat="server" Text="RD$: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbCantidadAcumulada_SegundoPago" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Tercer Pago Aplicado
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnTercerPagoAplicado" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnTercerPagoAplicado_Click" CssClass="BotonEstadistica Verde" />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbPrimerRenglonTercerPagoAplicado" runat="server" Text="0-30: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb0_30_TercerPago" runat="server" Text="0"></asp:Label>
                </div>
                 <div class="col-md-6">
                    <asp:Label ID="lbSegundoReglonTercerPago" runat="server" Text="31-60: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb31_60_TercerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbCuartoRenglonTercerPago" runat="server" Text="61-90: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb61_90_TercerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbQuintoRenglonTercerPago" runat="server" Text="91-120: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb91_120_TercerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSextoRenglonTercerPago" runat="server" Text="120-150: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb121_150_TercerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSeptimoRenglonTercerPago" runat="server" Text="151-Mas: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb151_Mas_TercerPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbPolizasDiasNegativosTercerPago" runat="server" Text="-0: " ToolTip="Este registro representa la cantidad de polizas que se renovaron por adelantado o no ha llegado el dia de inicio de vigencia" CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbDiasNegativosTercerPago" runat="server" ForeColor="Red" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbOctavoRenglonTercerPago" runat="server" Text="RD$: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbCantidadAcumulada_TercerPago" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>
    </div>
  </div>
           <br />
             <div class="container">
    <div class="frame-item">
      <h4>
        Cuarto Pago Aplicado
      </h4>
        <hr />

        <div>
            <asp:Button ID="btnCuartoPago" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnCuartoPago_Click" CssClass="BotonEstadistica Verde" />

            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbPrimerRenglonCuartoPagoAplicado" runat="server" Text="0-30: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb0_30_CuartoPago" runat="server" Text="0"></asp:Label>
                </div>
                 <div class="col-md-6">
                    <asp:Label ID="lbSegundoReglonCuartoPago" runat="server" Text="31-60: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb31_60_CuartoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbCuartoRenglonCuartoPago" runat="server" Text="61-90: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb61_90_CuartoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbQuintoRenglonCuartoPago" runat="server" Text="91-120: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb91_120_CuartoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSextoRenglonCuartoPago" runat="server" Text="121-150: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb121_150_CuartoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSeptimoRenglonCuartoPago" runat="server" Text="151-Mas: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb151_Mas_CuartoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbPolizasDiasNegativosCuartoPago" runat="server" Text="-0: " ToolTip="Este registro representa la cantidad de polizas que se renovaron por adelantado o no ha llegado el dia de inicio de vigencia" CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbDiasNegativosCuartoPago" runat="server" ForeColor="Red" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbOctavoRenglonCuartoPago" runat="server" Text="RD$: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbCantidadAcumulada_CuartoPago" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Quinto Pago Aplicado
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnQuintoPago" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnQuintoPago_Click" CssClass="BotonEstadistica Verde" />

            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbPrimerRenglonQuintoPagoAplicado" runat="server" Text="0-30: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb0_30_QuintoPago" runat="server" Text="0"></asp:Label>
                </div>
                 <div class="col-md-6">
                    <asp:Label ID="lbSegundoReglonQuintoPago" runat="server" Text="31-60: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb31_60_QuintoPago" runat="server" Text="0"></asp:Label>
                </div>
         
                <div class="col-md-6">
                    <asp:Label ID="lbCuartoRenglonQuintoPago" runat="server" Text="61-90: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb61_90_QuintoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbQuintoRenglonQuintoPago" runat="server" Text="91-120: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb91_120_QuintoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSextoRenglonQuintoPago" runat="server" Text="121-150: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb121_150_QuintoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSeptimoRenglonQuintoPago" runat="server" Text="151-Mas: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb151_Mas_QuintoPago" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbPolizasDiasNegativosQuintoPago" runat="server" Text="-0: " ToolTip="Este registro representa la cantidad de polizas que se renovaron por adelantado o no ha llegado el dia de inicio de vigencia" CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbDiasNegativosQuintoPago" runat="server" ForeColor="Red" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbOctavoRenglonQuintoPago" runat="server" Text="RD$: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbCantidadAcumulada_QuintoPago" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="frame-item">
      <h4>
        Mas de 5 Pagos
      </h4>
        <hr />
        <div>
            <asp:Button ID="btnMasDeCincoPagos" runat="server" Text="0" ToolTip="Click Para Descargar el Listado" OnClick="btnMasDeCincoPagos_Click" CssClass="BotonEstadistica Verde" />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbPrimerRenglonMasCintoPagoPagoAplicado" runat="server" Text="0-30: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb0_30_Mas_Cinco_Pagos" runat="server" Text="0"></asp:Label>
                </div>
                 <div class="col-md-6">
                    <asp:Label ID="lbSegundoReglonMasCintoPago" runat="server" Text="31-60: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb31_60_Mas_Cinco_Pagos" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbCuartoRenglonMasCintoPago" runat="server" Text="61-90: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb61_90_Mas_Cinco_Pagos" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbQuintoRenglonMasCintoPago" runat="server" Text="91-120: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb91_120_Mas_Cinco_Pagos" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSextoRenglonMasCintoPago" runat="server" Text="121-150: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb121_150_Mas_Cinco_Pagos" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbSeptimoRenglonMasCintoPago" runat="server" Text="151-Mas: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lb151_Mas_Mas_Cinco_Pagos" runat="server" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbPolizasDiasNegativosMasDeCincoPagos" runat="server" Text="-0: " ToolTip="Este registro representa la cantidad de polizas que se renovaron por adelantado o no ha llegado el dia de inicio de vigencia" CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbDiasNegativosMasDeCincoPagos" runat="server" ForeColor="Red" Text="0"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lbOctavoRenglonMasCintoPago" runat="server" Text="RD$: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbCantidadAcumulada_Mas_Cinco_Pagos" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>
    </div>
  </div>
           <br />
  
</div>
      </div>

        <div id="DIvBloqueRemodelacion" runat="server">
            <h1>Se estan realizando algunos ajustes a la parte de estadistica de renovación, se notificara una vez este disponible.</h1>
             <img src="../Imagenes/remodelacion.jpg" class="d-block w-100" alt="..." />
        </div>
     </div>

</asp:Content>

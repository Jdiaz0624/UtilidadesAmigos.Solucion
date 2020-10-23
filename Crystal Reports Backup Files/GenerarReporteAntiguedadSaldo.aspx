<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarReporteAntiguedadSaldo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarReporteAntiguedadSaldo" %>
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
    <script type="text/javascript">

        function CamposVacios() {
            alert("Has dejado campos vacios que son necesarios para generar este reporte, favor de revisar");
        }
        function Campofechacortevacio() {
            
            $("#<%=txtFechaCorteConsulta.ClientID%>").css("border-color", "red");
        }
        function CampoTasaVacio() {
            $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
        }

        function ErrorProceso() {
            alert("Error al procesar la información, favor de contactar a tecnologia");
        }

        function FuncionNoDisponible() {
            alert("Esta opción a un no esta disponible.";
        }
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Reporte de Antiguedad de Saldo"></asp:Label>
        </div>

        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechacorteConsulta" runat="server" Text="Fecha de corte" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaCorteConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbNumeroFacturaConsulta" runat="server" Text="Numero de Factura (FT, CR o PAD)" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroFacturaConsulta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamoConsulta" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

                <div class="form-group col-md-3">
                <asp:Label ID="lbTasaDollar" runat="server" Text="Tasa de Dolar" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtTasaDollar" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
            </div>
        </div>
        <!--TIPO DE REPORTE-->
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbTIpoReporte" runat="server" Text="Tipo de Reporte" CssClass="LetrasNegrita"></asp:Label><br />
                <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Reporte Resumido" ToolTip="Mostrar el reporte resumido" GroupName="TipoReporte" CssClass="form-check-input LetrasNegrita" />
               <asp:RadioButton ID="rbReporteSuperResumido" runat="server" Visible="false" Text="Reporte Super Resumido" ToolTip="Mostrar el reporte super resumido, vinculando los ramos y convirtiendo todo a pesos directamente" GroupName="GroupName" CssClass="form-check-input LetrasNegrita" />
                <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Reporte Detallado" ToolTip="Mostrar el reporte detallado" GroupName="TipoReporte" CssClass="form-check-input LetrasNegrita" />
            </div>
            <br />
           <%--  <div class="form-group form-check">
                <asp:Label ID="lbTipoOrganizacion" runat="server" Text="Tipo de Organizacion" CssClass="LetrasNegrita"></asp:Label><br />
                <asp:RadioButton ID="rbPorRamo" runat="server" Text="Ramo" GroupName="TipoOrganizacion" ToolTip="Organizar reporte por ramo" CssClass="form-check-input LetrasNegrita" />
                <asp:RadioButton ID="rbPorIntermediario" runat="server" Text="Intermediario" GroupName="TipoOrganizacion" ToolTip="Organizar reporte por intermediario" CssClass="form-check-input LetrasNegrita" />
                 <asp:RadioButton ID="rbPorOficina" runat="server" Text="Oficina" GroupName="TipoOrganizacion" ToolTip="Organizar reporte por oficina" CssClass="form-check-input LetrasNegrita" />
                 <asp:RadioButton ID="rbPorMoneda" runat="server" Text="Moneda" ToolTip="Organizar reporte por monedas" GroupName="TipoOrganizacion" CssClass="form-check-input LetrasNegrita" />
            </div>--%>

            <div class="form-group form-check">
                <asp:Label ID="lbMovimientosAMostrar" runat="server" Text="Movimientos a Mostrar" CssClass="LetrasNegrita"></asp:Label><br />
                <asp:RadioButton ID="rbTodosMovimientos" runat="server" Text="Todos" ToolTip="Mostrar Todos los registros" GroupName="TipoMovimiento" CssClass="form-check-input LetrasNegrita" />
                <asp:RadioButton ID="rbFacturas" runat="server" Text="Facturas (FT)" GroupName="TipoMovimiento" ToolTip="Mostrar solo las facturas" CssClass="form-check-input LetrasNegrita" />
                 <asp:RadioButton ID="rbCreditos" runat="server" Text="Creditos (CR)" GroupName="TipoMovimiento" ToolTip="Mostrar solo los creditos" CssClass="form-check-input LetrasNegrita" />
                 <asp:RadioButton ID="rbPrimaDepositos" runat="server" Text="Prima a Depositos (PAD)" GroupName="TipoMovimiento" ToolTip="Mostrar solo las primas a depositos" CssClass="form-check-input LetrasNegrita" />
            </div>
            
        </div>
        <br />
          <div align="Center">
         <asp:Button ID="btnExportarRegistros"  runat="server" CssClass="btn btn-outline-primary btn-sm Custom"  Text="Exportar" ToolTip="Exportar Registros" OnClick="btnExportarRegistros_Click" />
         <asp:Button ID="btnGenerarReporte"  runat="server" CssClass="btn btn-outline-primary btn-sm Custom"  Text="Reporte" ToolTip="Generar Reporte" OnClick="btnGenerarReporte_Click"/>
        </div>
    </div>
</asp:Content>

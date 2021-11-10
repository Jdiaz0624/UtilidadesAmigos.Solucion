<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteProduccion.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReporteProduccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
          <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#1E90FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }

        .btn-sm{
            width:90px;
        }

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        
        .BotonEspecial {
           width:100%;
           font-weight:bold;
          }

        th {
            background-color: #1E90FF;
            color: #000000;
        }

        .BotonSolicitud {
               width:50px;
               height:50px;
           }
        .BotonImagen {
               width:50px;
               height:50px;
           }
    </style>

    <script type="text/javascript">
        function CamposFechaVAcios() {
            alert("Los campos Fechas son necesarios para generar esta información, favor de verificar.");
        }
        function CampoFechaDesdeVacio() {

            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }

        $(document).ready(function () {

            //VALIDAR LA TASA
            $("#<%=btnBuscarInformacion.ClientID%>").click(function () {

                var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                if (Tasa < 1) {

                    alert("El campo tasa no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtTasa.ClientID%>").css("border-color", "red");
                    return false;

                }
            });
        })
    </script>

    <br />
    <asp:Label ID="lbFechaDesdeGuardada" runat="server" Text="1942-01-01" Visible="false"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="1942-01-31" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div class="form-check-inline">
            <asp:Label ID="lbAgruparDatos" runat="server" Text="Agrupar Datos" CssClass="Letranegrita"></asp:Label>
            <br />
            <asp:RadioButton ID="rbNoAgruparDatos" runat="server" Text="No Agrupar" ToolTip="No Agrupar Datos" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="rbNoAgruparDatos_CheckedChanged" GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorConcepto" runat="server" Text="Por Concepto" AutoPostBack="true" OnCheckedChanged="rbAgruparPorConcepto_CheckedChanged" ToolTip="Agrupar Información por Concepto" CssClass="form-check-input" GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorUsuario" runat="server" Text="Por Usuario" AutoPostBack="true" OnCheckedChanged="rbAgruparPorUsuario_CheckedChanged" ToolTip="Agrupar Información por Usuario" CssClass="form-check-input"  GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorOficina" runat="server" Text="Por Oficina" AutoPostBack="true" OnCheckedChanged="rbAgruparPorOficina_CheckedChanged" ToolTip="Agrupar Información por Oficina" CssClass="form-check-input"  GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorRamo" runat="server" Text="Por Ramo" AutoPostBack="true" OnCheckedChanged="rbAgruparPorRamo_CheckedChanged" ToolTip="Agrupar Información por Ramo" CssClass="form-check-input" GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorIntermediario" runat="server" AutoPostBack="true" OnCheckedChanged="rbAgruparPorIntermediario_CheckedChanged" Text="Por Intermediario" ToolTip="Agrupar Información Por Intermediario" CssClass="form-check-input" GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorSupervisor" runat="server" AutoPostBack="true" OnCheckedChanged="rbAgruparPorSupervisor_CheckedChanged" Text="Por Supervisor" ToolTip="Agrupar Información por Supervisor" CssClass="form-check-input"  GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorMoneda" runat="server" Text="Por Moneda" AutoPostBack="true" OnCheckedChanged="rbAgruparPorMoneda_CheckedChanged" ToolTip="Agrupar Informacion Por Moneda" CssClass="form-check-input"  GroupName="Agrupacion" />
        </div>
        <hr id="HRSeparadorTipoReporte" runat="server" />

        <div id="DIVTipoReporteGenerar" runat="server" class="form-check-inline">
            <asp:Label ID="lbTipoReporteGenerar" runat="server" Text="Tipo de Reporte" CssClass="Letranegrita"></asp:Label><br />
            <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Reporte Detallado" ToolTip="Generar el reporte detallado" CssClass="form-check-input" GroupName="TipoReporte" />
            <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Reporte Resumido" ToolTip="Generar el reporte resumido" CssClass="form-check-input" GroupName="TipoReporte" />
        </div>
        <hr />

        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="col-md-2">
                <asp:Label ID="lbCodIntermediario" runat="server" Text="Cod Vendedor"  CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodIntermediario" runat="server" AutoPostBack="true" OnTextChanged="txtCodIntermediario_TextChanged" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre Vendedor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>
            
            <div class="col-md-2">
                <asp:Label ID="lbCodSupervisor" runat="server" Text="Cod Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodSupervisor" runat="server" AutoPostBack="true" OnTextChanged="txtCodSupervisor_TextChanged" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarRamo_SelectedIndexChanged" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbSeleccionarSubRamo" runat="server" Text="Sub Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSubRamo" runat="server" ToolTip="Seleccionar Sub Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbUsuario" runat="server" Text="Usuario" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarUsuario" runat="server" ToolTip="Seleccionar Usuario" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbNumeroFactura" runat="server" Text="No. Documento" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbSeleccionarMoneda" runat="server" Text="Moneda" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarMoneda" runat="server" ToolTip="Seleccionar Moneda" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTasa" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" step="0.01"></asp:TextBox>
            </div>

             <div class="col-md-12">
                <asp:Label ID="lbConcepto" runat="server" Text="Concepto" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarCOncepto" runat="server" ToolTip="Seleccionar Concepto" CssClass="form-control"></asp:DropDownList>
            </div>

        </div>
        <br />
        <div class="form-check-inline">
            <asp:Label ID="lbTipoReporte" runat="server" Text="Formato de Reporte" CssClass="Letranegrita"></asp:Label>
            <br />
            <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" CssClass="form-check-input" GroupName="FormatoReporte" />
            <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" CssClass="form-check-input" GroupName="FormatoReporte" />
            <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano" CssClass="form-check-input" GroupName="FormatoReporte" />
        </div>
        <hr />
        <div id="DIVRecargarData" runat="server" class="form-check-inline">
            <asp:CheckBox ID="cbRecargarData" runat="server" Text="Recargar Data" ToolTip="Recargar la Data" CssClass="form-check-input" />
        </div>
        <div align="center">
            <asp:ImageButton ID="btnBuscarInformacion" runat="server" CssClass="BotonImagen" ToolTip="Consultar Información por pantalla" OnClick="btnBuscarInformacion_Click" ImageUrl="~/Imagenes/Buscar.png" />
             <asp:ImageButton ID="btnReporteProduccion" runat="server" CssClass="BotonImagen" ToolTip="Generar Reporte" OnClick="btnReporteProduccion_Click" ImageUrl="~/Imagenes/Reporte.png" />
        </div>
        <br />
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col"> Poliza </th>
                    <th scope="col"> Concepto </th>
                    <th scope="col"> Valor </th>
                    <th scope="col"> Fecha </th>
                    <th scope="col"> Hora </th>
                    <th scope="col"> Detalle </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoProduccion" runat="server">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                            <asp:HiddenField ID="hfNumeroFactura" runat="server" Value='<%# Eval("NumeroFactura") %>' />

                            <td> <%# Eval("Poliza") %> </td>
                            <td> <%# Eval("Concepto") %> </td>
                            <td> <%#string.Format("{0:N2}", Eval("Bruto")) %> </td>
                            <td> <%# Eval("FechaFormateada") %> </td>
                            <td> <%# Eval("Hora") %> </td>
                            <td> <asp:ImageButton ID="btnSeleccionarRegistro" runat="server" ImageUrl="~/Imagenes/escoger.png" CssClass="BotonImagen" ToolTip="Seleccionar Registro" /> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
         <div align="center">
                <asp:Label ID="lbPaginaActualTituloProduccion" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableProduccion" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloProduccion" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableProduccion" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionPolizasProduccion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaPolizasProduccion" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaPolizasProduccion_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorPolizasProduccion" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorPolizasProduccion_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionPolizasProduccion" runat="server" OnItemCommand="dtPaginacionPolizasProduccion_ItemCommand" OnItemDataBound="dtPaginacionPolizasProduccion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralProduccion" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteProduccion" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteProduccion_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoPolizasProduccion" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoPolizasProduccion_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />

        <div id="DIVBloqueDetalleFActura" runat="server" visible="false" class="row">
            <div class="col-md-3">
                <asp:Label ID="lbPolizaDetalle" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbNumeroDocumentoDetalle" runat="server" Text="No. Documento" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroDocumentoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbTipoDocumentodetalle" runat="server" Text="Tipo de Documento" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTipoDocumentoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lboficinaDetalle" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtOficinaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbAseguradoDetalle" runat="server" Text="Cliente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtClienteDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbSupervisorDetalle" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtSupervisordetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbIntermedarioetalle" runat="server" Text="Vendedor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtIntermediarioDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbFechaFacturacionDetalle" runat="server" Text="Fecha Facturación" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaFacturacionDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbHoraFacturacionDetalle" runat="server" Text="Hora Facturación" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtHoraFacturacionDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbInicioVigenciaDetalle" runat="server" Text="Inicio Vigencia" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtInicioVigenciaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbFinVigenciaDetalle" runat="server" Text="Fin Vigencia" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFinVigenciaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbSumaAseguradaDetalle" runat="server" Text="Suma Asegurada" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtSumaAseguradaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbComprobanteDetalle" runat="server" Text="NCF" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtComprobanteFiscalDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbMesDetalle" runat="server" Text="Mes" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtMesDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbUsuarioDetalle" runat="server" Text="Usuario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtUsuarioDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbMontoBrutodetalle" runat="server" Text="Bruto" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtMontoBrutoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbMontoImuestoDetalle" runat="server" Text="Impuesto" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtMontoImpuestoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbMontoNetoDetalle" runat="server" Text="Neto" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtMontoNetoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbCobradoDetalle" runat="server" Text="Cobrado" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCobradoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbRamoDetalle" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtRamoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbSubRamoDetalle" runat="server" Text="Sub Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtSubramoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbConceptoDetalle" runat="server" Text="Concepto" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtConceptoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div id="DIVTipoVehiculoDetalle" runat="server" class="col-md-3">
                <asp:Label ID="lbTipoVehiculoDetalle" runat="server" Text="Tipo de Vehiculo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTipoVehiculoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div id="DIVMarcaDetalle" runat="server" class="col-md-3">
                <asp:Label ID="lbMarcaDetalle" runat="server" Text="Marca" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtMarcaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div id="DIVModeloDetalle" runat="server" class="col-md-3">
                <asp:Label ID="lbModeloDetalle" runat="server" Text="Modelo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtModeloDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div id="DIVAnoDetalle" runat="server" class="col-md-3">
                <asp:Label ID="lbAnoDetalle" runat="server" Text="Año" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtAnoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div id="DIVColorDetalle" runat="server" class="col-md-3">
                <asp:Label ID="lbColorDetalle" runat="server" Text="Color" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtColorDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div id="DIVChasisDetalle" runat="server" class="col-md-3">
                <asp:Label ID="lbChasisDetalle" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtChasisDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div id="DIVPlacaDetalle" runat="server" class="col-md-3">
                <asp:Label ID="lbPlacaDetalle" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPlacaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbModedaDetalle" runat="server" Text="Moneda" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtMonedaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>


        </div>

        <br />
    </div>
</asp:Content>

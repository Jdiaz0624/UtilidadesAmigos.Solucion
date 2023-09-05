<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteProduccion.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReporteProduccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../Content/EstilosComunes.css" rel="stylesheet" />
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
    <asp:Label ID="lbFechaDesdeValidacion" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbFechaHastaValidacion" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbTasaValidacion" runat="server" Text="0" Visible="false"></asp:Label>

    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <div class="form-check-inline">
            <asp:Label ID="lbAgruparDatos" runat="server" Text="Agrupar Datos" CssClass="Letranegrita"></asp:Label>
            <br />
            <asp:RadioButton ID="rbNoAgruparDatos" runat="server" Text="No Agrupar" ToolTip="No Agrupar Datos" AutoPostBack="true" OnCheckedChanged="rbNoAgruparDatos_CheckedChanged" GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorConcepto" runat="server" Text="Por Concepto" AutoPostBack="true" OnCheckedChanged="rbAgruparPorConcepto_CheckedChanged" ToolTip="Agrupar Información por Concepto" GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorUsuario" runat="server" Text="Por Usuario" AutoPostBack="true" OnCheckedChanged="rbAgruparPorUsuario_CheckedChanged" ToolTip="Agrupar Información por Usuario"   GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorOficina" runat="server" Text="Por Oficina" AutoPostBack="true" OnCheckedChanged="rbAgruparPorOficina_CheckedChanged" ToolTip="Agrupar Información por Oficina"   GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorRamo" runat="server" Text="Por Ramo" AutoPostBack="true" OnCheckedChanged="rbAgruparPorRamo_CheckedChanged" ToolTip="Agrupar Información por Ramo"  GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorIntermediario" runat="server" AutoPostBack="true" OnCheckedChanged="rbAgruparPorIntermediario_CheckedChanged" Text="Por Intermediario" ToolTip="Agrupar Información Por Intermediario"  GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorSupervisor" runat="server" AutoPostBack="true" OnCheckedChanged="rbAgruparPorSupervisor_CheckedChanged" Text="Por Supervisor" ToolTip="Agrupar Información por Supervisor"   GroupName="Agrupacion" />
            <asp:RadioButton ID="rbAgruparPorMoneda" runat="server" Text="Por Moneda" AutoPostBack="true" OnCheckedChanged="rbAgruparPorMoneda_CheckedChanged" ToolTip="Agrupar Informacion Por Moneda"  GroupName="Agrupacion" />
         
        </div>
        <br />
        <div id="DIVTipoReporte" runat="server" class="form-check-inline">
            <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Detallado" ToolTip="Generar Reporte de Producción Detallado" GroupName="TipoReporteGererar" />
            <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Resumido" ToolTip="Generar Reporte de Producción Resumido" GroupName="TipoReporteGererar" />
        </div>

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
            <asp:RadioButton ID="rbPDF" runat="server" Text="PDF"  GroupName="FormatoReporte" />
            <asp:RadioButton ID="rbExcel" runat="server" Text="Excel"  GroupName="FormatoReporte" />
            <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano"  GroupName="FormatoReporte" />
        </div>
        <hr />
      
        <div class="ContenidoCentro">
             <asp:ImageButton ID="btnBuscarInformacion" runat="server" CssClass="BotonImagen" ToolTip="Consultar Información por pantalla" OnClick="btnBuscarInformacion_Click" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" />
             <asp:ImageButton ID="btnReporteProduccion" runat="server" CssClass="BotonImagen" ToolTip="Generar Reporte" OnClick="btnReporteProduccion_Click" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" />
        </div>
        <br />
        <div class="table-responsive">
            <table class="table table-striped">
            <thead class="table-dark">
                <tr>
                    <th scope="col"> Poliza </th>
                    <th scope="col"> Factura </th>
                    <th scope="col"> Fecha </th>
                    <th scope="col"> Concepto </th>
                    <th scope="col"> Bruto </th>
                    <th scope="col"> ISC </th>
                    <th scope="col"> Neto </th>
                    <th scope="col"> Valor Poliza </th>
                    <th scope="col"> Cobrado </th>
                    <th scope="col"> Pendiente </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoProduccion" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td> <%# Eval("Poliza") %> </td>
                            <td> <%# Eval("NumeroFactura") %> </td>
                            <td> <%# Eval("FechaFactura") %> </td>
                            <td> <%# Eval("Concepto") %> </td>
                            <td> <%#string.Format("{0:N2}", Eval("MontoBruto")) %> </td>
                            <td> <%#string.Format("{0:N2}", Eval("ISC")) %> </td>
                            <td> <%#string.Format("{0:N2}", Eval("MontoNeto")) %> </td>
                            <td> <%#string.Format("{0:N2}", Eval("ValorPoliza")) %> </td>
                             <td> <%#string.Format("{0:N2}", Eval("Cobrado")) %> </td>
                             <td> <%#string.Format("{0:N2}", Eval("Pendiente")) %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
            <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">
                            <label class="Letranegrita">Pagina</label> <asp:Label ID="lbPaginaActualVariableProduccion" runat="server" Text=" 0 "></asp:Label>
                            <label class="Letranegrita">De</label> <asp:Label ID="lbCantidadPaginaVAriableProduccion" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
             <div id="divPaginacionPolizasProduccion" runat="server" class="table-responsive" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPaginaPaginacion" runat="server" ToolTip="Ir a la Primera Pagina del Listado" CssClass="BotonImagen" OnClick="btnPrimeraPaginaPaginacion_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnteriorPaginacion" runat="server" ToolTip="Ir a la Pagina Anterior del Listado" CssClass="BotonImagen" OnClick="btnPaginaAnteriorPaginacion_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" /> </td>

                    <td>
                        <asp:DataList ID="dtPaginacionPolizasProduccion" runat="server" OnItemCommand="dtPaginacionPolizasProduccion_ItemCommand" OnItemDataBound="dtPaginacionPolizasProduccion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnPaginaSiguientePaginacion" runat="server" ToolTip="Ir a la Siguiente Pagina del Listado" CssClass="BotonImagen" OnClick="btnPaginaSiguientePaginacion_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPaginaPaginacion" runat="server" ToolTip="Ir a la Ultima Pagina del Listado" CssClass="BotonImagen" OnClick="btnUltimaPaginaPaginacion_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" /> </td>
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

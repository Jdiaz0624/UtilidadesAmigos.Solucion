<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarReporteCobros.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarReporteCobros" %>
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
            width:90px;
        }

        .Letranegrita {
        font-weight:bold;
        }
          table {
            border-collapse: collapse;
        }
        

        th {
            background-color: dodgerblue;
            color: white;
        }
    </style>

    <script type="text/javascript">
        function CampoFechaDesdevacio() {
            $("#<%=txtFechaDesdeConsulta.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHastaConsulta.ClientID%>").css("border-color", "red");
        }
        function CamposFechaVacios() {
            alert("Has dejado campos de fecha vacios, estos son necesarios para realizar la consulta.");
        }

        $(document).ready(function () {
            $("#<%=btnConsultarRegistros.ClientID%>").click(function () {
                //VALIDAMOS EL CAMPO TASA
                var Tasa = $("#<%=txtTasaConsulta.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para realizar la consulta, favor de verificar");
                    $("#<%=txtTasaConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }

            });

            $("#<%=btnExportarRegistros.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaConsulta.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para exportar la información, favor de verificar");
                    $("#<%=txtTasaConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

        })

    </script>
    <div class="container-fluid">
      <br /><br />
        <asp:Label ID="lbAgruparDatos" runat="server" Text="Agrupar Datos" CssClass="Letranegrita"></asp:Label>
        <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbNoAgruparDatos" runat="server" Text="No Agrupar" ToolTip="Generar Reporte sin Agrupar datos" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbNoAgruparDatos_CheckedChanged" />
                <asp:RadioButton ID="rbAgruparPorConcepto" runat="server" Text="Concepto" ToolTip="Generar Reporte Agrupado Por Concepto" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbAgruparPorConcepto_CheckedChanged" />
                <asp:RadioButton ID="rbAgruparTipoPago" runat="server" Text="Tipo de Pago" ToolTip="Generar Reporte Agrupado Por Tipo de Pago" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbAgruparTipoPago_CheckedChanged" />
                <asp:RadioButton ID="rbAgruparIntermediario" runat="server" Text="Intermediario" ToolTip="Generar Reporte Agrupado Por Intermediario" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbAgruparIntermediario_CheckedChanged" />
                <asp:RadioButton ID="rbAgruparSupervisor" runat="server" Text="Supervisor" ToolTip="Generar Reporte Agrupado Por Supervisor" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbAgruparSupervisor_CheckedChanged" />
                <asp:RadioButton ID="rbAgruparPorOficina" runat="server" Text="Oficina" ToolTip="Generar Reporte Agrupado Por Oficina" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbAgruparPorOficina_CheckedChanged" />
                <asp:RadioButton ID="rbAgrupaRamo" runat="server" Text="Ramo" ToolTip="Generar Reporte Agrupado Por Ramo" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbAgrupaRamo_CheckedChanged" />
                <asp:RadioButton ID="rbAgruparUsuario" runat="server" Text="Usuario" ToolTip="Generar Reporte Agrupado Por Usuario" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbAgruparUsuario_CheckedChanged" />
                <asp:RadioButton  ID="rbAgrupadoPorDia" runat="server" Text="Por Dia" ToolTip="Generar Reporte Agrupado Por Dia" CssClass="form-check-input Letranegrita" GroupName="AgrupacionDatos" AutoPostBack="true" OnCheckedChanged="rbAgrupadoPorDia_CheckedChanged" />
            </div>
        </div><br />
        <asp:Label ID="lbTipoReporte" runat="server" Text="Tipo de Reporte a Generar" CssClass="Letranegrita"></asp:Label><br />
        <div id="divTipoReporte" runat="server" class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Detallado" ToolTip="Generar Reporte Detallado" CssClass="form-check-input Letranegrita" GroupName="TipoReporte"/>
                <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Resumido" ToolTip="Generar Reporte Resumido" CssClass="form-check-input Letranegrita" GroupName="TipoReporte"/>
            </div>
        </div>
        <br />
        <asp:Label ID="lbTipoReportePorDia" runat="server" Text="Tipo de Reporte Por Dia a Generar" CssClass="Letranegrita"></asp:Label><br />
        <div id="DivTipoReportePorDia" runat="server" class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbReporteResumidoPorDia" runat="server" Text="Resumido" ToolTip="Generar Reporte Resumido Por Dia" CssClass="form-check-input Letranegrita" GroupName="TipoReportePorDia"/>
                <asp:RadioButton ID="rbReporteDetalladoPorDia" runat="server" Text="Detallado" ToolTip="Generar Reporte Detallado Por Dia" CssClass="form-check-input Letranegrita" GroupName="TipoReportePorDia"/>
                <asp:RadioButton ID="rbReportePorSupervisorPorDia" runat="server" Text="Por Supervisor" ToolTip="Generar Reporte Por Supervisor Por Dia" CssClass="form-check-input Letranegrita" GroupName="TipoReportePorDia"/>
                <asp:RadioButton ID="rbReportePorIntermediarioPorDia" runat="server" Text="Por Intermediario" ToolTip="Generar Reporte Por Intermediario Por Dia" CssClass="form-check-input Letranegrita" GroupName="TipoReportePorDia"/>
            </div>
        </div>
        <hr />
        <asp:Label ID="lbTipoRecibos" runat="server" Text="Tipo de Recibos a Mostrar" CssClass="Letranegrita"></asp:Label><br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbTodosRecibos" runat="server" Text="Todos" ToolTip="Mostrar Todos los Recibos (Activos y Anulados)" CssClass="form-check-input Letranegrita" GroupName="Anulado"/>
                <asp:RadioButton ID="rbRecibosActivos" runat="server" Text="Activos" ToolTip="Mostrar Recibos Activos" CssClass="form-check-input Letranegrita" GroupName="Anulado"/>
                <asp:RadioButton ID="rbRecibosAnulados" runat="server" Text="Anulados" ToolTip="Mostrar Recibos Anulados" CssClass="form-check-input Letranegrita" GroupName="Anulado" />
            </div>
        </div>

        <!--AGREGAMOS LOS CONTROLES DE BUSQUEDA-->
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbfechadesdeConsulta" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbFechaHastaConsulta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-2">
                <asp:Label ID="lbCodigoSupervisorConsulta" runat="server" Text="Codigo de Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisorConsulta" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisorConsulta_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbNombreSupervisorintermediario" runat="server" Text="Nombre de Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisorConsulta" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-2">
                <asp:Label ID="lbCodigoIntermediarioConsulta" runat="server" Text="Codigo de Intermediario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediarioConsulta" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioConsulta_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group col-md-4">
                <asp:Label ID="lbNombreIntermediarioConsulta" runat="server" Text="Nombre de Intermediario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediarioConsulta" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarSucursalConsulta" runat="server" Text="Seleccionar Sucursal" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursalConsulta_SelectedIndexChanged" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionaroficinaConsulta" runat="server" Text="Seleccionar Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficinaConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarRamoConsulta" runat="server" Text="Seleccionar Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamoConsulta" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-1">
                <asp:Label ID="lbTasaConsulta" runat="server" Text="Tasa" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTasaConsulta" runat="server" TextMode="Number" Step="0.01" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarConceptoConsulta" runat="server" Text="Seleccionar Concepto" CssClass="Letranegrita"></asp:Label>
                 <asp:DropDownList ID="ddlSeleccionarConceptoConsulta" runat="server" ToolTip="Seleccionar Concepto" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbNumeroReciboConsulta" runat="server" Text="Numero de Recibo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroRecibo" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbNumeroPolizaConsulta" runat="server" Text="Numero de Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroPolizaCOnsulta" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <asp:Label ID="lbExportarA" runat="server" Text="Exportar A:" CssClass="Letranegrita"></asp:Label>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbExportarPDF" runat="server" Text="PDF" ToolTip="Exportar Data a PDF" GroupName="ExportarData" CssClass="form-check-input Letranegrita" />
                <asp:RadioButton ID="rbExportarExcel" runat="server" Text="Excel" ToolTip="Exportar Data a Excel" GroupName="ExportarData" CssClass="form-check-input Letranegrita" />
                <asp:RadioButton ID="rbExportarWord" runat="server" Text="Word" ToolTip="Exportar Data a Word" GroupName="ExportarData" CssClass="form-check-input Letranegrita" />
                <asp:RadioButton ID="rbExportarTXT" runat="server" Text="TXT" ToolTip="Exportar Data a TXT" GroupName="ExportarData" CssClass="form-check-input Letranegrita" />
                <asp:RadioButton ID="rbExportarCSV" runat="server" Text="CSV" ToolTip="Exportar Data a CSV" GroupName="ExportarData" CssClass="form-check-input Letranegrita" />
            </div>
        </div>
         <div id="divGraficar" runat="server" align="center">
            <div class="form-check-inline"  >
           <div class="form-group form-check">
               <asp:CheckBox ID="cbGraficar" runat="server" Text="Graficar" AutoPostBack="true" OnCheckedChanged="cbGraficar_CheckedChanged"  ToolTip="Graficar Información" CssClass="form-check-input" />
           </div>
       </div>
       </div><br />
        <div align="center">

            <asp:Button ID="btnConsultarRegistros" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm" OnClick="btnConsultarRegistros_Click" />
            <asp:Button ID="btnExportarRegistros" runat="server" Text="Exportar" ToolTip="Exportar Registros" CssClass="btn btn-outline-primary btn-sm" OnClick="btnExportarRegistros_Click" />
       
        <hr />
        <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbCantidadRegistroscerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>

        <asp:Label ID="lbTotalCobradopesosTitulo" runat="server" Text="Cobrado en Pesos ( " CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbTotalCobradoPesosVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbTotalCobradoCerrarPesos" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>

        <asp:Label ID="lbTotalCobradoDollarTitulo" runat="server" Text="Cobrado en Dollar ( " CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbTotalCobradoDollarVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbTotalCobradoCerrarDollar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>

        <asp:Label ID="lbPesosDollarConvertidoTitulo" runat="server" Text="RD$ ( " CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbPesosDollarConvertidoVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbPesosDollarConvertidoCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
             </div>
        <br />
        <!--INICIO DEL REPEATER-->
        <div>
            <div class="table-responsive mT20">
                <table class="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th style="width:10%" align="left" >
                                <asp:Label ID="lbPolizaHeaderRepeater" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                            </th>

                            <th style="width:20%" align="left" >
                                <asp:Label ID="lbRamoHeaderRepeater" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                            </th>

                            <th style="width:15%" align="left" >
                                <asp:Label ID="lbReciboHeaderrepeater" runat="server" Text="Recibo" CssClass="Letranegrita"></asp:Label>
                            </th>

                            <th style="width:15%"  align="left" >
                                <asp:Label ID="lbConceptoHeaderRepeater" runat="server" Text="Concepto" CssClass="Letranegrita"></asp:Label>
                            </th>

                            <th style="width:10%" align="left" >
                                <asp:Label ID="lbValorHaderRepeater" runat="server" Text="Valor" CssClass="Letranegrita"></asp:Label>
                            </th>

                            <th style="width:10%" align="left" >
                                <asp:Label ID="lbMonedaHeaderRepeater" runat="server" Text="Moneda" CssClass="Letranegrita"></asp:Label>
                            </th>

                            <th style="width:10%" align="left" >
                                <asp:Label ID="lbFechaHeaderRepeater" runat="server" Text="Fecha" CssClass="Letranegrita"></asp:Label>
                            </th>

                            <th style="width:10%" align="left" >
                                <asp:Label ID="lbTipoPagoHeaderRepeater" runat="server" Text="Tipo Pago" CssClass="Letranegrita"></asp:Label>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoCobro" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="width:10%" >
                                        <%#Eval("Poliza") %>
                                    </td>

                                    <td style="width:20%">
                                        <%# Eval("Ramo") %>
                                    </td>

                                    <td style="width:15%" >
                                        <%#Eval("NumeroFormateado") %>
                                    </td>

                                    <td style="width:15%" >
                                        <%#Eval("Concepto") %>
                                    </td>

                                    <td style="width:10%" >
                                        <%# string.Format("{0:n2}", Eval("Bruto")) %>
                                    </td>

                                    <td style="width:10%" >
                                        <%#Eval("Moneda") %>
                                    </td>

                                    <td style="width:10%" >
                                        <%#Eval("FechaFormateada") %>
                                    </td>

                                    <td style="width:10%" >
                                        <%#Eval("TipoPago") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
        <!--FIN DEL REPEATER-->

         <div align="center">
                    
                    <asp:Label ID="lbDeTitulo" runat="server" CssClass="Letranegrita" Text="Total de Paginas "></asp:Label>
                    <asp:Label ID="lbCantidadPaginasVariable" CssClass="Letranegrita" runat="server" Text=" 0 "></asp:Label>
                </div>

        <!--PAGINACION-->
        <div id="divPaginacionrepeater" runat="server" align="center">
            <div style="margin-top:20px;"></div>
            <table style="width:600px;">
                <tr>
                    <td>
                        <asp:LinkButton ID="lbPrimeraPagina" runat="server" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la Primera Pagina del listado" Text="Inicio" OnClick="lbPrimeraPagina_Click"></asp:LinkButton>
                    </td>

                    <td>
                        <asp:LinkButton ID="lbPaginaAnterior" runat="server" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la Pagina anterior del listado" Text="Anterior" OnClick="lbPaginaAnterior_Click"></asp:LinkButton>
                    </td>

                    <td>
                        <asp:DataList ID="rptPaging" runat="server"
                                    OnItemCommand="rptPaging_ItemCommand"
                                    OnItemDataBound="rptPaging_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbPaging" runat="server"
                                            CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage"
                                            Text='<%# Eval("PageText") %> ' Width="20px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>
                    </td>

                    <td>
                        <asp:LinkButton ID="lbSiguientePagina" runat="server" Text="Siguiente" ToolTip="Ir a la Pagina Siguiente del listado" CssClass="btn btn-outline-success btn-sm" OnClick="lbSiguientePagina_Click"></asp:LinkButton>
                    </td>

                    <td>
                         <asp:LinkButton ID="LinkUltimaPagina" runat="server" Text="Final" ToolTip="Ir a la Ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimaPagina_Click"></asp:LinkButton>
                    </td>

                    <td>
                        <asp:Label ID="lbPaginaActual" runat="server" Text="0"></asp:Label>
                    </td>

                    <td></td>
                </tr>
            </table>
        </div>
        <!--FIN DE PAGINACION-->
        <br />
        <!--INICIO DE LOS GRAFICOS-->

        


        <!--GRAFICO DE SUPERVISORES-->
        <div id="divGraficarSupervisores" runat="server" align="center" >

             <asp:Label ID="lbGraficosSupervisoresCobro" runat="server"  Text="Top 10 Cobrado Supervisores" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraSupervisores" Width="1100px" runat="server" Palette="SeaGreen">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
        </div>

        <!--GRAFICO DE INTERMEDIARIOS-->
        <div id="divGraficarIntermediarios" runat="server" align="center">
            <asp:Label ID="lbGraficarIntermediarios" runat="server"  Text="Top 10 Cobrado Intermediarios" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraIntermediarios" Width="1100px" runat="server" Palette="SeaGreen">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
        </div>

        <!--GRAFICO DE LOS TIPOS DE PAGOS-->
        <div id="divGraficarTipoPago" runat="server" align="center">
            <asp:Label ID="lbGraficarTiposPagos" runat="server"  Text="Top 10 Cobrado Tipos de Pagos" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraTipoPago" Width="1100px" runat="server" Palette="SeaGreen">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
        </div>

        <!--GRAFICO DE LOS CONCEPTOS-->
        <div id="divGraficarConcepto" runat="server" align="center">
            <asp:Label ID="lbGraficarConcepto" runat="server"  Text="Top 10 Cobrado Por Concepto" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraConcepto" Width="1100px" runat="server" Palette="SeaGreen">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
        </div>

        <!--GRAFICO DE LOS RAMOS-->
        <div id="divGraficarRamo" runat="server" align="center">
            <asp:Label ID="lbGraficarRamo" runat="server"  Text="Top 10 Cobrado Por Ramo" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraRamo" Width="1100px" runat="server" Palette="SeaGreen">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
        </div>

        <!--GRAFICO DE LAS OFICINAS-->
        <div id="divGraficaroficina" runat="server" align="center">
            <asp:Label ID="lbGraficaroficina" runat="server"  Text="Top 10 Cobrado Por Oficina" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraOficina" Width="1100px" runat="server" Palette="SeaGreen">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
        </div>

        <!--GRAFICO DE LOS USUARIOS-->
        <div id="divGraficarusuario" runat="server" align="center">
            <asp:Label ID="lbGraficarUsuarios" runat="server"  Text="Top 10 Cobrado Por Usuarios" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraUsuario" Width="1100px" runat="server" Palette="SeaGreen">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
        </div>

           



        <!--FIN DE LOS GRAFICOS-->
    </div>

</asp:Content>

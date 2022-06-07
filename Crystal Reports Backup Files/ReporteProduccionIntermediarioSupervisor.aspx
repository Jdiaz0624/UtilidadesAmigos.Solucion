<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" Debug="true" AutoEventWireup="true" CodeBehind="ReporteProduccionIntermediarioSupervisor.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ReporteProduccionIntermediarioSupervisor" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        

        th {
            background-color: #1E90FF;
            color: #000000;
        }
    </style>

    <script type="text/javascript">
        function OpcionNoDisponible() {
            alert("Esta Opcion no esta disponible por el momento");
        }
        function CamposVacios() {
            alert("Has dejado campos vacios que son necesarios para realizar esta consulta, favor de verificar");
        }
        function CampoTasaVAcio() {
            alert("El campo tasa no puede estar vacio, favor de verificar");
            $("#<%=txtTasa.ClientID%>").css("border-color", "red");
        }

        function CampoFechaDesdeVAcio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHAstaVAcio() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }
        $(document).ready(function () {
            //VALIDAMOS EL CAMPO TASA
            $("#<%=btnConsultar.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                if(Tasa < 1) {
                    CampoTasaVAcio();
                }
            });

            $("#<%=btnExportar.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                if(Tasa < 1) {
                    CampoTasaVAcio();
                  }
            });

        })
    </script>
   <div class="container-fluid">
       <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
       <br /><br />
       <asp:Label ID="lbFechaDesdeValidacion" runat="server" Visible="false" Text="Fecha Desde Validacion"></asp:Label>
            <asp:Label ID="lbFechaHastaValidacion" runat="server" Visible="false" Text="Fecha Hasta Validacion"></asp:Label>
            <asp:Label ID="lbTasaValidacion" runat="server" Visible="false" Text="Tasa Validacion"></asp:Label>
       <div class="form-check-inline">
               <asp:Label ID="lbTipoAgrupacion" runat="server" Text="Agrupar Datos" CssClass="Letranegrita"></asp:Label><br />
               <asp:RadioButton ID="rbNoAgrupar" runat="server" Text="No agrupar" GroupName="AgruparData" ToolTip="No Agrupar Informacion" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbAgruparConcepto" runat="server" Text="Concepto"  GroupName="AgruparData" ToolTip="Agrupar Informacion por Concepto" CssClass="form-check-input Letranegrita" />
                <asp:RadioButton ID="rbAgruparPorUsuarios" runat="server" Text="Usuario" GroupName="AgruparData" ToolTip="Agrupar Información por Usuario" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbAgruparPorOficina" runat="server" Text="Oficina" GroupName="AgruparData" ToolTip="Agrupar Información por Oficina" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbAgruparPorRamo" runat="server" Text="Ramo" GroupName="AgruparData" ToolTip="Agrupar Información por Ramo" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbAgruparPorIntermediario" runat="server" Text="Intermediario" GroupName="AgruparData" ToolTip="Agrupar Información por Intermediario" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbAgruparPorSupervisor" runat="server" Text="Supervisor" GroupName="AgruparData" ToolTip="Agrupar Información por Supervisor" CssClass="form-check-input Letranegrita" />
       </div>
       <hr />
       <div class="form-check-inline">
               <asp:Label ID="lbEstatusPoliza" runat="server" Text="Seleccionar Estatus de Poliza" CssClass="Letranegrita"></asp:Label><br />
               <asp:RadioButton ID="rbTodas" runat="server" Text="Todas" ToolTip="Muestra todas las polizas activas y canceladas" GroupName="FiltroEstatus" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbActivas" runat="server" Text="Activas" ToolTip="Muestra solo las polizas activas" GroupName="FiltroEstatus" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbCanceladas" runat="server" Text="Canceladas" ToolTip="Muestra solo las polizas canceladas" GroupName="FiltroEstatus" CssClass="form-check-input Letranegrita" />
       </div>
       <hr />
       <div class="form-check-inline">
               <asp:Label ID="lbTipoInformacion" runat="server" Text="Seleccionar Tipo de Reporte" CssClass="Letranegrita"></asp:Label><br />
               <asp:RadioButton ID="rbDetalle" runat="server" Text="Reporte Detallado" GroupName="TipoReporte" ToolTip="Esta Opcion Muestra el Detalle del reporte solicitado" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbResumido" runat="server" Text="Reporte Resumido" ToolTip="Esta Opción muestra el resumen del reporte solicitado" GroupName="TipoReporte" CssClass="form-check-input Letranegrita" />
       </div>
       <hr />
       <div class="row">
           <div class="col-md-6">
               <asp:Label ID="lbfechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-6">
               <asp:Label ID="lbfechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-2">
               <asp:Label ID="lbCodSupervisor" runat="server" Text="ID Supervisor" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtCodigoSupervisor" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-4">
               <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre de Supervisor" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtNombreSupervisor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-2">
               <asp:Label ID="lbCodigoIntermediario" runat="server" Text="ID Intermediario" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtCodigoIntermediario" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-4">
               <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre de Intermediario" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-3">
               <asp:Label ID="lbSeleccionarSucursal" runat="server" Text="Seleccionar Sucursal" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarSucursal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursal_SelectedIndexChanged" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
           </div>
            <div class="col-md-4">
               <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Seleccionar Oficina" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
           </div>
            <div class="col-md-4">
               <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Seleccionar Ramo" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
           </div>
            <div class="col-md-1">
               <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtTasa" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-6">
               <asp:Label ID="lbSeleccionarCocepto" runat="server"  Text="Seleccionar Concepto" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarConcepto" runat="server"  ToolTip="Seleccionar Concepto" CssClass="form-control"></asp:DropDownList>
           </div>
       </div>
       <br />
       <asp:Label ID="lbFormatoExportacion" runat="server" Text="Exportar a" CssClass="Letranegrita"></asp:Label>
       <div class="form-check-inline">
               <asp:RadioButton ID="rbExportarPDF" runat="server" Text="PDF" CssClass="form-check-input Letranegrita" ToolTip="Exportar Reporte a PDF" GroupName="ExportarInformacion" />
                <asp:RadioButton ID="rbExportarExel" runat="server" Text="Excel" CssClass="form-check-input Letranegrita" ToolTip="Exportar Reporte a Excel" GroupName="ExportarInformacion" />
                <asp:RadioButton ID="rbExportarWord" runat="server" Text="Word" CssClass="form-check-input Letranegrita" ToolTip="Exportar Reporte a Word" GroupName="ExportarInformacion" />
                <asp:RadioButton ID="rbExportartxt" runat="server" Text="TXT" CssClass="form-check-input Letranegrita" ToolTip="Exportar Reporte a TXT" GroupName="ExportarInformacion" />
                <asp:RadioButton ID="rbExportarXML" runat="server" Text="XML" CssClass="form-check-input Letranegrita" Visible="false" ToolTip="Exportar Reporte a XML" GroupName="ExportarInformacion" />
                <asp:RadioButton ID="rbExportarCSV" runat="server" Text="CSV" CssClass="form-check-input Letranegrita" ToolTip="Exportar Reporte a CSV" GroupName="ExportarInformacion" />

       </div>
       <div align="center">
           <asp:Button ID="btnConsultar" runat="server" Text="Consulta" CssClass="btn btn-outline-primary btn-sm" OnClick="btnConsultar_Click" ToolTip="Consultar por Pantalla"/>
           <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" OnClick="btnExportar_Click" ToolTip="Exportar a excel" />

                 </div>
       <hr />
       <div align="center">
           <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" CssClass="Letranegrita" Text="Cantidad de Registros ( "></asp:Label>
           <asp:Label ID="lbcantidadRegistrosVariable" runat="server" CssClass="Letranegrita" Text="0"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" CssClass="Letranegrita" Text=" )"></asp:Label>

           <asp:Label ID="lbTotalFacturadoTitulo" runat="server" CssClass="Letranegrita" Text="Total F. ( "></asp:Label>
           <asp:Label ID="lbTotalFacturadoVariable" runat="server" CssClass="Letranegrita" Text="0"></asp:Label>
           <asp:Label ID="lbTotalFacturadoCerrar" runat="server" CssClass="Letranegrita" Text=" )"></asp:Label>

           <asp:Label ID="lbFacturadoPesosTitulo" runat="server" CssClass="Letranegrita" Text="F. Pesos ( "></asp:Label>
           <asp:Label ID="lbFacturadoPesosVariable" runat="server" CssClass="Letranegrita" Text="0"></asp:Label>
           <asp:Label ID="lbFacturadoPesosCerrar" runat="server" CssClass="Letranegrita" Text=" )"></asp:Label>

            <asp:Label ID="LbFacturadoDollarTitulo" runat="server" CssClass="Letranegrita" Text="F. Dollar ( "></asp:Label>
           <asp:Label ID="LbFacturadoDollarVariable" runat="server" CssClass="Letranegrita" Text="0"></asp:Label>
           <asp:Label ID="LbFacturadoDollarcerrar" runat="server" CssClass="Letranegrita" Text=" )"></asp:Label>

            <asp:Label ID="lbFacturadoTotalTitulo" runat="server" CssClass="Letranegrita" Text="F. Total ( "></asp:Label>
           <asp:Label ID="lbFacturadoTotalVariable" runat="server" CssClass="Letranegrita" Text="0"></asp:Label>
           <asp:Label ID="lbFacturadoTotalCerrar" runat="server" CssClass="Letranegrita" Text=" )"></asp:Label>
       </div>
       <br />
          <!--INICIO DEL GRID-->
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col">Poliza</th>
                        <th scope="col">Factura</th>
                        <th scope="col">Tipo</th>
                        <th scope="col">Bruto</th>
                        <th scope="col">Moneda</th>
                        <th scope="col">Concepto</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoProduccion" runat="server">
                        <ItemTemplate>
                            <tr>
                                 <td> <%# Eval("Poliza") %> </td>
                                 <td> <%# Eval("NumeroFacturaFormateado") %> </td>
                                 <td> <%# Eval("Tipo") %> </td>
                                 <td> <%#string.Format("{0:n2}", Eval("Bruto")) %> </td>
                                 <td> <%# Eval("Moneda") %> </td>
                                 <td> <%# Eval("Concepto") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>


        <div align="center">
                <asp:Label ID="lbPaginaActualTitulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavle" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTitulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPagina" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPagina_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnterior" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnterior_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguiente" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguiente_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimo" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimo_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
    <!--FIN DEL GRID-->
       <br />
       <div align="center">
            <div class="form-check-inline"  >
               <asp:CheckBox ID="cbGraficar" runat="server" Text="Graficar" AutoPostBack="true" OnCheckedChanged="cbGraficar_CheckedChanged" ToolTip="Graficar Información" CssClass="form-check-input" />

       </div>
       </div>
      
       <div align="center">
           <!--GRAFICO POR SUPERVISOR-->
            <asp:Label ID="lbGraficoSupervisores" runat="server" Visible="false" Text="Top 10 Produccion Supervisores" CssClass="Letranegrita"></asp:Label>
<br />
            <asp:Chart ID="GraSupervisores" Width="1100px" Visible="False" runat="server" Palette="Pastel">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
           <br />


           <asp:Label ID="lbGraficoIntermediario" runat="server" Visible="false" Text="Top 10 Produccion Intermediarios" CssClass="Letranegrita"></asp:Label>
           <br />
           <!--GRAFICO POR INTERMEDIARIO-->
         <asp:Chart ID="GraIntermediarios" Width="1100px" Visible="False" runat="server" Palette="Pastel">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}" Font="Century Gothic, 8.25pt"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1">
               <AxisX2 IntervalAutoMode="VariableCount"></AxisX2>
               </asp:ChartArea>
               
           </ChartAreas>
       </asp:Chart>
        
           <br />




          

           <!--GRAFICO POR OFICINA-->
           <asp:Label ID="lbGraficoOficina" runat="server" Visible="false" Text="Produccion Por Oficinas" CssClass="Letranegrita"></asp:Label>
           <br />
            <asp:Chart ID="GraOficina" Width="1012px" Visible="False" runat="server" Palette="Pastel">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}" YValuesPerPoint="2"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
            <br />

           <!--GRAFICO POR RAMO-->
           <asp:Label ID="lbGraficoRamo" runat="server" Visible="false" Text="Produccion Por Ramos" CssClass="Letranegrita"></asp:Label>
           <br />
            <asp:Chart ID="GraRamo" Width="1012px" Visible="False" runat="server" Palette="Pastel">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}" YValuesPerPoint="2"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
            <br />


           <!--GRAFICO POR USUARIO-->
            <asp:Label ID="lbGraficoPorUsuario" runat="server" Visible="false" Text="Produccion Por Usuario" CssClass="Letranegrita"></asp:Label>
           <br />
            <asp:Chart ID="GraUsuario" Width="1012px" Visible="False" runat="server" Palette="Pastel">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}" YValuesPerPoint="2"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1" BackSecondaryColor="Transparent"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
            <br />



           <!--GRAFICO POR CONCEPTO-->
            <asp:Label ID="lbGraficoConcepto" runat="server" Visible="false" Text="Produccion Por Concepto" CssClass="Letranegrita"></asp:Label>
           <br />
            <asp:Chart ID="GraConcepto" Width="1012px" Visible="False" runat="server" Palette="Pastel">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N}" YValuesPerPoint="2"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
            <br />
       </div>
       
   </div>

</asp:Content>

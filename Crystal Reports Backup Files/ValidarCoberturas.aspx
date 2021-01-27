<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ValidarCoberturas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ValidarCoberturas" %>
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
            background-color: dodgerblue;
            color: white;
        }
    </style>
    <script type="text/javascript">
      function OcultarControlesCoberturas() {
            $("#<%=cbEstatus.ClientID%>").hide();
            $("#<%=txtCoberturaMantenimiento.ClientID%>").attr("disabled", "disabled");
        }

        function DataCedensa() {
            alert("Esta cobertura solo se exporta, ya que ellos requeiren toda la data completa correspondiente a las polizas activas, por lo tanto no hay necesidad de filtrar los registros");
        }

        function MostrarControlesCoberturas() {
            $("#<%=cbEstatus.ClientID%>").show();
            $("#<%=txtCoberturaMantenimiento.ClientID%>").removeAttr("disabled", true);
        }

        function ActivarControlesPlanCobertura() {
            $("#<%=ddlCoberturaPlanCobertura.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtCodigoCoberturaPlanCobertura.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtPlanCobertura.ClientID%>").removeAttr("disabled", true);
             $("#<%=cbEstatusPlanCobertura.ClientID%>").removeAttr("disabled", true);

        }

        function DesactivarControlesPlanCobertura() {

            $("#<%=ddlCoberturaPlanCobertura.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtCodigoCoberturaPlanCobertura.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtPlanCobertura.ClientID%>").attr("disabled", "disabled");
            $("#<%=cbEstatusPlanCobertura.ClientID%>").attr("disabled", "disabled");

            $("#<%=txtCodigoCoberturaPlanCobertura.ClientID%>").val("");
            $("#<%=txtPlanCobertura.ClientID%>").val("");
            $("#<%=lbIdMantenimientoPlanCobertura.ClientID%>").text("0");
        }

        function ErrorConsulta() {
            alert("Error al realizar la consulta, favor de verificar los parametros seleccionados")

        }

        function ErrorExportar() {

            alert("Error al realizar al exportar la data, favor de verificar los parametros seleccionados")
        }

        function CamposFechaVacios() {
            alert("Los campos fecha son necesarios para realizar esta consulta, favor de verificar.");
        }

        function CampoFechaDesdeVacio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }

        $(document).ready(function () {

            $("#btnPlan").click(function () {
                DesactivarControlesPlanCobertura();

            })


          

      


            //CONTROLAMOS EL EVENTO CLICK DEL BOTON COBERTURA
            $("#btnCobertura").click(function () {
                OcultarControlesCoberturas();

            })

            $("#<%=btnGuardarCobertura.ClientID%>").click(function () {
                var DescripcionCobertura = $('#<%=txtCoberturaMantenimiento.ClientID%>').val().length;
                if (DescripcionCobertura < 1) {
                    alert("El campo Descripción no puede estar vacio")
                    $("#<%=txtCoberturaMantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }

            })


            //CONTROLAMOS EL EVENTO CLICK DEL BOTON CONSULTA
            $("#<%=btnConsultar.ClientID%>").click(function () {
                //VALIDAMOS EL CAMPO COBERTURA
                var Cobertura = $("#<%=ddlSeleccionarCpbertura.ClientID%>").val();
                if (Cobertura < 1) {
                    alert("El campo cobertura no puede estar vacio")
                    $("#<%=ddlSeleccionarCpbertura.ClientID%>").css("border-color", "red");
                    return false;

                }
                else
                {
                    var PlanCobertura = $("#<%=ddlSeleccionarPlanCobertura.ClientID%>").val();
                    if (PlanCobertura < 1) {
                         alert("El campo plan de cobertura no puede estar vacio")
                    $("#<%=ddlSeleccionarPlanCobertura.ClientID%>").css("border-color", "red");
                    return false;


                    }
                }


            })

        })
    </script>
<!--INICIO DEL ENCABEZADO-->
    <div class="container-fluid">
        <div class="jumbotron" align="Center">
            <asp:Label ID="lbEncabezado" runat="server" Text="Sacar Data de Coberturas"></asp:Label>
            
        </div>
    </div>
<!--FIN DEL ENCABEZADO-->

<!--INICIO DE LOS MENUS DESPLEGABLES Y CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarCobertura" runat="server" CssClass="Letranegrita" Text="Seleccionar Cobertura"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarCpbertura" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Seleccionar Cobertura" OnSelectedIndexChanged="ddlSeleccionarCpbertura_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarPlanCobertura" runat="server" CssClass="Letranegrita" Text="Seleccionar Plan"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarPlanCobertura" runat="server" ToolTip="Seleccionar un plan Segun la cobertura seleccionada" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbPolizaFiltro" runat="server" CssClass="Letranegrita" Text="Poliza"></asp:Label>
                <asp:TextBox ID="txtPolizaFiltro" runat="server" AutoCompleteType="Disabled"  MaxLength="20" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarSucursal" runat="server" CssClass="Letranegrita" Text="Seleccionar Sucursal"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursal" runat="server" ToolTip="Seleccionar Surcursal" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursal_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Seleccionar Oficina" CssClass="Letranegrita" ></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" ToolTip="Seleccionar la Oficina para el filtro" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-4">
               
            </div>
              <div class="form-group col-md-4">
                    <asp:Label ID="lbFechaDesde" runat="server" CssClass="Letranegrita" Text="Fecha Desde"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" ToolTip="Inicio de Rango de fecha" TextMode="Date" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <asp:Label ID="lbFechaHasta" runat="server" CssClass="Letranegrita" Text="Fecha Hasta"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" ToolTip="Fin de Rango de fecha" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
        </div>
        <!--FIN DE LOS MENUS DESPLEGABLES Y CONTROLES DE BUSQUEDA-->
        <br />

        <!--INICIO DE LOS RADIOS PARA EXPORTAR-->
        <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:Label ID="lbExportarA" runat="server" Text="Exportar A:" CssClass="Letranegrita"></asp:Label>
                    <asp:RadioButton ID="rbExportarExel" runat="server" Text="Excel" CssClass="form-check-input" ToolTip="Exportar a Formato de Excel" GroupName="Exportar" />
                    <asp:RadioButton ID="rbExportarcsv" runat="server" Text="CSV" CssClass="form-check-input"  ToolTip="Exportar a Formato CSV" GroupName="Exportar" />
                    <asp:RadioButton ID="rbExportartxt" runat="server" Text="TXT" CssClass="form-check-input" ToolTip="Exportar a formato de texto" GroupName="Exportar" />
                    <asp:RadioButton ID="rbExportarPDF" runat="server" Text="PDF" CssClass="form-check-input" ToolTip="Exportar a formato PDF" GroupName="Exportar" />
                </div>
                <div class="form-group form-check">
                    
                </div>
                <div class="form-group form-check">
                    
                </div>
            </div>
        <!--FIN DE LOS RADIOS PARA EXPORTAR-->

        <!--INICIO DE LOS BOTONES-->
        <div align="center" >
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-secondary btn-sm Letranegrita" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-secondary btn-sm Letranegrita" ToolTip="Exportar Registros" OnClick="btnExportar_Click" />
                <button type="button" id="btnCobertura" class="btn btn-outline-secondary btn-sm Letranegrita" data-toggle="modal" data-target=".bd-example-modal-lg">Coberturas</button>
             <button type="button" id="btnPlan" class="btn btn-outline-secondary btn-sm Letranegrita" data-toggle="modal" data-target=".PlanCobertura">Plan</button>
            <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="btn btn-outline-secondary btn-sm Letranegrita" ToolTip="Reporte de Cobertura" OnClick="btnReporte_Click" />
            <br /><br />
            <asp:Label ID="lbCantidadRegistrosListadoGeneralTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosListadoGeneralVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosListadoGeneralCerrar" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>
        </div>
        <br />
        
        <!--FIN DE LOS BOTONES-->
     <!--INICIO DEL GRID-->
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:10%" align="left"> <asp:Label ID="lbPolizaHeaderCoberturas" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbEstatusHeaderCoberturas" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:15%" align="left"> <asp:Label ID="lbInicioVigenciaHeaderCoberturas" runat="server" Text="Inicio" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:15%" align="left"> <asp:Label ID="lbFinVigenciaHeaderCoberturas" runat="server" Text="Fin" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbFechaProcesoHeaderCoberturas" runat="server" Text="Proceso" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:25%" align="left"> <asp:Label ID="lbCoberturaHeaderCobertutras" runat="server" Text="Cobertura" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:15%" align="left"> <asp:Label ID="lbTipoMovimientoHeaderCoberturas" runat="server" Text="Movimiento" CssClass="Letranegrita"></asp:Label> </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoCoberturasPrincipal" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                <td style="width:10%"> <%# Eval("Estatus") %> </td>
                                <td style="width:15%"> <%# Eval("InicioVigencia") %> </td>
                                <td style="width:15%"> <%# Eval("FinVigencia") %> </td>
                                <td style="width:10%"> <%# Eval("FechaProceso") %> </td>
                                <td style="width:25%"> <%# Eval("Cobertura") %> </td>
                                <td style="width:15%"> <%# Eval("TipoMovimiento") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

         <div align="center">
                <asp:Label ID="lbPaginaActualTituloListadoPrincipal" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableListadoPrincipal" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloListadoPrincipal" runat="server" Text="De " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableListadoPrincipal" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>

             <div id="DivPaginacionListadoPrincipal" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:LinkButton ID="LinkPrimeraListadoPrincipal" runat="server" Text="Primero" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraListadoPrincipal_Click" CssClass="btn btn-outline-success btn-sm"  ></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkAnteriorListadoPrincipal" runat="server" Text="Anterior" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorListadoPrincipal_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td>
                                <asp:DataList ID="dtPaginacionListadoPrincipal" runat="server" OnCancelCommand="dtPaginacionListadoPrincipal_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipal_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkIndiceListadoPrincipal" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="NuevaPagina" Text='<%# Eval("TextoPagina")%>' Width="20px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:LinkButton ID="LinkSiguienteListadoPrincipal" runat="server" Text="Siguiente" ToolTip="Ir la Siguiente pagina del listado" OnClick="LinkSiguienteListadoPrincipal_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkUltimoListadoPrincipal" runat="server" Text="Ultmo" ToolTip="Ir a la Ultima Pagina del listado" OnClick="LinkUltimoListadoPrincipal_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
            <br />
    <!--FIN DEL GRID-->


          <div align="center">
            <div id="divGraficoEstatus" runat="server"  >

             <asp:Label ID="lbGraficoEstatus" runat="server"  Text="Estatus de Coberturas" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraEstatus" Width="800px" runat="server" Palette="Excel">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" ChartType="Pie"></asp:Series>
              
           </Series>
                <Legends>
                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="false" Name="Default" LegendStyle="Row"></asp:Legend>
                </Legends>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
              
           </ChartAreas>
                <BorderSkin SkinStyle="Emboss" />
       </asp:Chart>
        </div>
       </div>
    </div>



        <!--INICIO DEL POPO DE LAS COBERTURAS-->


<div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="MantenimientoCoberturas" runat="server" Text="Mantenimiento de Coberturas"></asp:Label>
              <asp:Label ID="lbIdCobertura" Visible="false" runat="server" Text="Mantenimiento de Coberturas"></asp:Label>
          </div>
         <asp:ScriptManager ID="CoberturasScript" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanelCoberturas" runat="server" Visible="true">
              <ContentTemplate>
                   <div class="form-row">
              <div class="form-group col-md-12">
                  <asp:Label ID="Cobertura" runat="server" Text="Cobertura"></asp:Label>
                  <asp:TextBox ID="txtCoberturaMantenimiento" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <div class="form-check-inline">
              <div class="form-group form-check">
                  <asp:CheckBox ID="cbEstatus" runat="server" Text="Estatus" CssClass="form-check-input Letranegrita" />
              </div>
          </div>
                  <br />
                       <!--INICIO DEL GRID-->
                        <div class="table-responsive">
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th style="width:10%" align="left"> <asp:Label ID="lbSeleccionarCoberturaHeaderCobertura" runat="server" Text="Seleccionar" CssClass="Letranegrita"></asp:Label> </th>
                                        <th style="width:80%" align="left"> <asp:Label ID="lbCoberturaHeaderCobertura" runat="server" Text="Cobertura" CssClass="Letranegrita"></asp:Label> </th>
                                        <th style="width:10%" align="left"> <asp:Label ID="lbEstatusHeaderCobertura" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label> </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpListadoCoberturas" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <asp:HiddenField ID="hfIdCobertura" runat="server" Value='<%# Eval("IdCobertura") %>' />
                                                <td style="width:10%"> <asp:Button ID="btnSeleccionarCobertura" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm Letranegrita" ToolTip="Seleccionar Cobertura" OnClick="btnSeleccionarCobertura_Click" /> </td>
                                                <td style="width:10%"> <%# Eval("Descripcion") %> </td>
                                                <td style="width:10%"> <%# Eval("Estatus") %> </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>

                   <div align="center">
                <asp:Label ID="lbPaginaActualTituloCoberturas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableCoberturas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloCoberturas" runat="server" Text="De " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableCoberturas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>

             <div id="DivPaginacionCoberturas" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:LinkButton ID="LinkPrimeroCoberturas" runat="server" Text="Primero" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroCoberturas_Click" CssClass="btn btn-outline-success btn-sm"  ></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkAnteriorCoberturas" runat="server" Text="Anterior" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorCoberturas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td>
                                <asp:DataList ID="dtPaginacionCoberturas" runat="server" OnCancelCommand="dtPaginacionCoberturas_CancelCommand" OnItemDataBound="dtPaginacionCoberturas_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkIndiceListadoCoberturas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="NuevaPagina" Text='<%# Eval("TextoPagina")%>' Width="20px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:LinkButton ID="LinkSiguienteCoberturas" runat="server" Text="Siguiente" ToolTip="Ir la Siguiente pagina del listado" OnClick="LinkSiguienteCoberturas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkUltimoCoberturas" runat="server" Text="Ultmo" ToolTip="Ir a la Ultima Pagina del listado" OnClick="LinkUltimoCoberturas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
          <br />

    <!--FIN DEL GRID-->
                  <br />
                  

                    <div align="center">
              <asp:Button ID="btnGuardarCobertura" runat="server" Text="Guardar" CssClass="btn btn-outline-secondary btn-sm Letranegrita" OnClick="btnGuardarCobertura_Click" />
          </div>
                  <br />
              </ContentTemplate>
          </asp:UpdatePanel>
        
      </div>
    </div>
  </div>
</div>



           <!--INICIO DEL POPO DE LAS COBERTURAS-->


<div class="modal fade bd-example-modal-xl PlanCobertura" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbEncabezadoPlanCobertura" runat="server" Text="Mantenimiento de Plan de Coberturas"></asp:Label>
              <asp:Label ID="lbIdMantenimientoPlanCobertura" runat="server" Text="IdPlanCobertura" Visible="false"></asp:Label>
          </div>
          <!--INICIO DE LOS CONTROLES DEL MANTENIMIENTO-->
      
          <asp:UpdatePanel ID="PlanCoberturaUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                   <div class="form-row">
              <div class="form-group col-md-12">
                  <asp:Label ID="lbCoberturaPlanCobertura" runat="server" Text="Cobertura"></asp:Label>
                  <asp:DropDownList ID="ddlCoberturaPlanCobertura" runat="server" ToolTip="Seleccionar Cobertura" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbCodigoCobertura" runat="server" Text="Codigo de Cobertura"></asp:Label>
                  <asp:TextBox ID="txtCodigoCoberturaPlanCobertura" runat="server" MaxLength="5" TextMode="Number" CssClass="form-control" ></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbPlanCobertura" runat="server" Text="Plan de Cobertura"></asp:Label>
                  <asp:TextBox ID="txtPlanCobertura" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <div class="form-check-inline">
              <div class="form-group form-check">
                  <asp:CheckBox ID="cbEstatusPlanCobertura" runat="server" Text="Estatus" CssClass="form-check-input" />
              </div>
          </div>
          <br />
          <div class="table-responsive">
              <table class="table table-hover">
                  <thead>
                      <tr>
                          <th style="width:10%" align="left"> <asp:Label ID="lbSeleccionarHeaderPlanCobertura" runat="server" Text="Seleccionar" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:30%" align="left"> <asp:Label ID="lbCoberturaHeaderPlanCobertura" runat="server" Text="Cobertura" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:10%" align="left"> <asp:Label ID="lbCodigoCobertutaHeaderPlanCobertura" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:40%" align="left"> <asp:Label ID="lbPlanCoberturaHeaderPlanCobertura" runat="server" Text="Plan" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:10%" align="left"> <asp:Label ID="lbEstatusHeaderPlanCobertura" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label> </th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater ID="rpListadoPlanCobertura" runat="server">
                          <ItemTemplate>
                              <tr>
                                  <asp:HiddenField ID="hfIdPlanCobertura" runat="server" Value='<%# Eval("IdPlanCobertura") %>' />

                                  <td style="width:10%"> <asp:Button ID="btnSeleccionarPlanCobertura" runat="server" Text="Seleccionar" ToolTip="Seleccionar Plan Cobertura" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarPlanCobertura_Click" /> </td>
                                  <td style="width:30%"> <%# Eval("Cobertura") %> </td>
                                  <td style="width:10%"> <%# Eval("CodigoCobertura") %> </td>
                                  <td style="width:40%"> <%# Eval("PlanCobertura") %> </td>
                                  <td style="width:10%"> <%# Eval("Estatus") %> </td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
          </div>

                      <div align="center">
                <asp:Label ID="lbPaginaActualTituloPlanCoberturas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariablePlanCoberturas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloPlanCoberturas" runat="server" Text="De " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariablePlanCoberturas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>

             <div id="DivPaginacionPlanCobertura" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:LinkButton ID="LinkPrimeroPlanCobertura" runat="server" Text="Primero" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroPlanCobertura_Click" CssClass="btn btn-outline-success btn-sm"  ></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkAnteriorPlanCobertura" runat="server" Text="Anterior" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorPlanCobertura_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td>
                                <asp:DataList ID="dlPlanCobertura" runat="server" OnCancelCommand="dlPlanCobertura_CancelCommand" OnItemDataBound="dlPlanCobertura_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkIndiceListadoCoberturas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="NuevaPagina" Text='<%# Eval("TextoPagina")%>' Width="20px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:LinkButton ID="LinkSiguientePlanCobertura" runat="server" Text="Siguiente" ToolTip="Ir la Siguiente pagina del listado" OnClick="LinkSiguientePlanCobertura_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkUltimoPlanCobertura" runat="server" Text="Ultmo" ToolTip="Ir a la Ultima Pagina del listado" OnClick="LinkUltimoPlanCobertura_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
                  <br />
                  <div align="center">
              <asp:Button ID="btnGuardarPlanCobertura" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm" OnClick="btnGuardarPlanCobertura_Click" ToolTip="Guardar Registro" />
    </div>
              </ContentTemplate>
          </asp:UpdatePanel>
          
          <br />
      </div>
    </div>
  </div>
</div>

</asp:Content>

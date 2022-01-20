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
            background-color: #1E90FF;
            color: #000000;
        }

              .BotonImgen {
              width:40px;
              height:40px;
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

        function RegistrosNoEncontrados() {
            alert("No se encontrarón registros para validar.");
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

            $("#<%=btnGuardarCoberturaNuevo.ClientID%>").click(function () {
                var DescripcionCobertura = $('#<%=txtCoberturaMantenimiento.ClientID%>').val().length;
                if (DescripcionCobertura < 1) {
                    alert("El campo Descripción no puede estar vacio")
                    $("#<%=txtCoberturaMantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }

            })


            //CONTROLAMOS EL EVENTO CLICK DEL BOTON CONSULTA
            $("#<%=btnConsultarNuevo.ClientID%>").click(function () {
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
    </div>
<!--FIN DEL ENCABEZADO-->

<!--INICIO DE LOS MENUS DESPLEGABLES Y CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <br /><br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lbSeleccionarCobertura" runat="server" CssClass="Letranegrita" Text="Seleccionar Cobertura"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarCpbertura" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Seleccionar Cobertura" OnSelectedIndexChanged="ddlSeleccionarCpbertura_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbSeleccionarPlanCobertura" runat="server" CssClass="Letranegrita" Text="Seleccionar Plan"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarPlanCobertura" runat="server" ToolTip="Seleccionar un plan Segun la cobertura seleccionada" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbPolizaFiltro" runat="server" CssClass="Letranegrita" Text="Poliza"></asp:Label>
                <asp:TextBox ID="txtPolizaFiltro" runat="server" AutoCompleteType="Disabled"  MaxLength="20" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbSeleccionarSucursal" runat="server" CssClass="Letranegrita" Text="Seleccionar Sucursal"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursal" runat="server" ToolTip="Seleccionar Surcursal" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursal_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Seleccionar Oficina" CssClass="Letranegrita" ></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" ToolTip="Seleccionar la Oficina para el filtro" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-4">
               
            </div>
              <div class="col-md-4">
                    <asp:Label ID="lbFechaDesde" runat="server" CssClass="Letranegrita" Text="Fecha Desde"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" ToolTip="Inicio de Rango de fecha" TextMode="Date" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbFechaHasta" runat="server" CssClass="Letranegrita" Text="Fecha Hasta"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" ToolTip="Fin de Rango de fecha" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
        </div>
        <!--FIN DE LOS MENUS DESPLEGABLES Y CONTROLES DE BUSQUEDA-->
        <br />
        <div class="form-check-inline">
                <asp:CheckBox ID="cbValidarDataCobertura" runat="server" Text="Validar Data" ToolTip="Validar la data de cobertura" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="cbValidarDataCobertura_CheckedChanged" />
        
        </div>
<div id="DIVBloqueConsulta" runat="server">
            <!--INICIO DE LOS RADIOS PARA EXPORTAR-->
        <div class="form-check-inline">
      
                    <asp:Label ID="lbExportarA" runat="server" Text="Exportar A:" CssClass="Letranegrita"></asp:Label>
                    <asp:RadioButton ID="rbExportarExel" runat="server" Text="Excel" CssClass="form-check-input" ToolTip="Exportar a Formato de Excel" GroupName="Exportar" />
                    <asp:RadioButton ID="rbExportarcsv" runat="server" Text="CSV" CssClass="form-check-input"  ToolTip="Exportar a Formato CSV" GroupName="Exportar" />
                    <asp:RadioButton ID="rbExportartxt" runat="server" Text="TXT" CssClass="form-check-input" ToolTip="Exportar a formato de texto" GroupName="Exportar" />
                    <asp:RadioButton ID="rbExportarPDF" runat="server" Text="PDF" CssClass="form-check-input" ToolTip="Exportar a formato PDF" GroupName="Exportar" />
        
              
            </div>
        <!--FIN DE LOS RADIOS PARA EXPORTAR-->
        <!--INICIO DE LOS BOTONES-->
        <div align="center" >
            <asp:ImageButton ID="btnConsultarNuevo" runat="server" ToolTip="Consultar Registros" CssClass="BotonImgen" OnClick="btnConsultarNuevo_Click" ImageUrl="~/Imagenes/Buscar.png" />
            <asp:ImageButton ID="btnExportarExcelNuevo" runat="server" ToolTip="Exportar Registros a Excel" CssClass="BotonImgen" OnClick="btnExportarExcelNuevo_Click" ImageUrl="~/Imagenes/excel.png" />
            <asp:ImageButton ID="btnReporteNuevo" runat="server" ToolTip="Generar Reporte de Coberturas" CssClass="BotonImgen" OnClick="btnReporteNuevo_Click" ImageUrl="~/Imagenes/Reporte.png" />

          <br />
                <button type="button" id="btnCobertura" class="btn btn-outline-secondary btn-sm Letranegrita" data-toggle="modal" data-target=".bd-example-modal-lg">Coberturas</button>
             <button type="button" id="btnPlan" class="btn btn-outline-secondary btn-sm Letranegrita" data-toggle="modal" data-target=".PlanCobertura">Plan</button>
            <br /><br />
            <asp:Label ID="lbCantidadRegistrosListadoGeneralTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosListadoGeneralVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosListadoGeneralCerrar" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>
        </div>
        <br />       
        <!--FIN DE LOS BOTONES-->
     <!--INICIO DEL GRID-->
       
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Poliza </th>
                        <th scope="col"> Estatus </th>
                        <th scope="col"> Inicio </th>
                        <th scope="col"> Fin </th>
                        <th scope="col"> Proceso </th>
                        <th scope="col"> Cobertura </th>
                        <th scope="col"> Movimiento </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoCoberturasPrincipal" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td> <%# Eval("Poliza") %> </td>
                                <td> <%# Eval("Estatus") %> </td>
                                <td> <%# Eval("InicioVigencia") %> </td>
                                <td> <%# Eval("FinVigencia") %> </td>
                                <td> <%# Eval("FechaProceso") %> </td>
                                <td> <%# Eval("Cobertura") %> </td>
                                <td> <%# Eval("TipoMovimiento") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
    

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
                            <td> <asp:ImageButton ID="btnPrimeraPaginaListado" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaListado_Click" CssClass="BotonImgen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnteriorListado" runat="server" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnteriorListado_Click" CssClass="BotonImgen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipal" runat="server" OnCancelCommand="dtPaginacionListadoPrincipal_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipal_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentralListadoGeneral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePaginaListado" runat="server" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePaginaListado_Click" CssClass="BotonImgen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPaginaListado" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPaginaListado_Click" CssClass="BotonImgen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
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


        <div id="DivBloqueValidarData" runat="server">
            <br />
            <div id="DivBuscarArchivoExcel" runat="server" class="form-group col-sm-6">
                                  <label for="FileUpload1">Buscar Archivo en el equipo</label>
                                    <asp:FileUpload ID="FIleArchivoCobertura" CssClass="form-control-file" runat="server" />
                                </div>
            <div align="center">
                <asp:Label ID="lbEjemeploFormatoExel" runat="server" Text="Formato de Archivo (Columnas)--> Poliza|Chasis|Placa|Cobertura" CssClass="Letranegrita"></asp:Label><br />
                <asp:ImageButton ID="btnProcesarInformacionNuevo" runat="server" ToolTip="Validar la información de cobertura" CssClass="BotonImgen" OnClick="btnProcesarInformacionNuevo_Click" ImageUrl="~/Imagenes/Procesar.png" />
            </div>
            <br />
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
                   <div class="row">
              <div class="col-md-12">
                  <asp:Label ID="Cobertura" runat="server" Text="Cobertura"></asp:Label>
                  <asp:TextBox ID="txtCoberturaMantenimiento" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <div class="form-check-inline">

                  <asp:CheckBox ID="cbEstatus" runat="server" Text="Estatus" CssClass="form-check-input Letranegrita" />
           
          </div>
                  <br />
                       <!--INICIO DEL GRID-->

                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        
                                        <th scope="col"> Cobertura </th>
                                        <th scope="col"> Estatus </th>
                                        <th scope="col"> Seleccionar </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpListadoCoberturas" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <asp:HiddenField ID="hfIdCobertura" runat="server" Value='<%# Eval("IdCobertura") %>' />
                                                <td> <%# Eval("Descripcion") %> </td>
                                                <td> <%# Eval("Estatus") %> </td>
                                                <td> <asp:ImageButton ID="btnSeleccioanrCoberturaNuevo" runat="server" ToolTip="Seleccionar" CssClass="BotonImgen" ImageUrl="~/Imagenes/Seleccionar2.png" OnClick="btnSeleccioanrCoberturaNuevo_Click" /> </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                  

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
                            <td> <asp:ImageButton ID="btnPriemraPaginaCoberturas" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImgen" OnClick="btnPriemraPaginaCoberturas_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnteriorCobertura" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImgen" OnClick="btnPaginaAnteriorCobertura_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>

                            <td align="center">
                                <asp:DataList ID="dtPaginacionCoberturas" runat="server" OnCancelCommand="dtPaginacionCoberturas_CancelCommand" OnItemDataBound="dtPaginacionCoberturas_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentralCoberturas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnPaginaSiguienteCobertura" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImgen" OnClick="btnPaginaSiguienteCobertura_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPaginaCobertura" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImgen" OnClick="btnUltimaPaginaCobertura_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
          <br />

    <!--FIN DEL GRID-->
                  <br />
                  

                    <div align="center">
                        <asp:ImageButton ID="btnGuardarCoberturaNuevo" runat="server" ToolTip="Guardar Información" CssClass="BotonImgen" ImageUrl="~/Imagenes/salvar.png" OnClick="btnGuardarCoberturaNuevo_Click" />
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
                   <div class="row">
              <div class="col-md-12">
                  <asp:Label ID="lbCoberturaPlanCobertura" runat="server" Text="Cobertura"></asp:Label>
                  <asp:DropDownList ID="ddlCoberturaPlanCobertura" runat="server" ToolTip="Seleccionar Cobertura" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="col-md-6">
                  <asp:Label ID="lbCodigoCobertura" runat="server" Text="Codigo de Cobertura"></asp:Label>
                  <asp:TextBox ID="txtCodigoCoberturaPlanCobertura" runat="server" MaxLength="5" TextMode="Number" CssClass="form-control" ></asp:TextBox>
              </div>
              <div class="col-md-6">
                  <asp:Label ID="lbPlanCobertura" runat="server" Text="Plan de Cobertura"></asp:Label>
                  <asp:TextBox ID="txtPlanCobertura" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <div class="form-check-inline">
     
                  <asp:CheckBox ID="cbEstatusPlanCobertura" runat="server" Text="Estatus" CssClass="form-check-input" />
         
          </div>
          <br />
       
              <table class="table table-striped">
                  <thead>
                      <tr>
                         
                          <th scope="col"> Cobertura </th>
                          <th scope="col"> Codigo </th>
                          <th scope="col"> Plan </th>
                          <th scope="col"> Estatus </th>
                           <th scope="col"> Seleccionar </th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater ID="rpListadoPlanCobertura" runat="server">
                          <ItemTemplate>
                              <tr>
                                  <asp:HiddenField ID="hfIdPlanCobertura" runat="server" Value='<%# Eval("IdPlanCobertura") %>' />

                                  <td> <%# Eval("Cobertura") %> </td>
                                  <td> <%# Eval("CodigoCobertura") %> </td>
                                  <td> <%# Eval("PlanCobertura") %> </td>
                                  <td> <%# Eval("Estatus") %> </td>
                                  <td> <asp:ImageButton ID="btnSeleccionarPlanCoberturaNuevo" runat="server" ToolTip="Seleccionar Registro" CssClass="BotonImgen" ImageUrl="~/Imagenes/Seleccionar2.png" OnClick="btnSeleccionarPlanCoberturaNuevo_Click" /> </td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
      

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
                            <td> <asp:ImageButton ID="btnPrimeraPaginaPlanCobertura" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImgen" OnClick="btnPrimeraPaginaPlanCobertura_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnteriorPlanCobertura" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImgen" OnClick="btnPaginaAnteriorPlanCobertura_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                            <td align="center">
                                <asp:DataList ID="dlPlanCobertura" runat="server" OnCancelCommand="dlPlanCobertura_CancelCommand" OnItemDataBound="dlPlanCobertura_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPAginacionCentralPlanCoberturas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnPaginaSiguientePlanCobertura" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImgen" OnClick="btnPaginaSiguientePlanCobertura_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                            <td> <asp:ImageButton ID="btnUltimoPlanCobertura" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImgen" OnClick="btnUltimoPlanCobertura_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
                  <br />
                  <div align="center">
                      <asp:ImageButton ID="btnGuardarPlanCoberturaNuevo" runat="server" CssClass="BotonImgen" ToolTip="Guardar Información" OnClick="btnGuardarPlanCoberturaNuevo_Click" ImageUrl="~/Imagenes/salvar.png" />
    </div>
              </ContentTemplate>
          </asp:UpdatePanel>
          
          <br />
      </div>
    </div>
  </div>
</div>

</asp:Content>

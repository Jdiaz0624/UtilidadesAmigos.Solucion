<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ListadoRenovacion.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ListadoRenovacion" %>
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
        function ErrorConsulta() {
            alert("Error al realizar la consulta, favor de verificar el rango de fecha");
        }

        function OpcionEnDesarrollo() {
            alert("Esta Opción esta en desarrollo por el momento");
        }
              function CamposVaciosEstadistica(){
                  alert("Has dejado campos vacios que son necesarios para realizar esta operación, favor de verificar");
                  return false;
        }
        function CamposFechaVacios() {
            alert("Los campos fecha son necesarios para realizar este proceso, favor de verificar.");
        }
              function FechaDesdeVacio() {
                  $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
         }
              function FechaHastaVacio() {
                  $("#<%=txtFechaHAsta.ClientID%>").css("border-color", "red");
}
    </script>
       <div class="container-fluid">
       <br /><br />
        <asp:Label ID="lbCotizacionPoliza" runat="server" Text="Cotizacion" Visible="false" ></asp:Label>
        <div align="center">
            <asp:Label ID="Label2" runat="server" Text=" Desde " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbMesDesde" runat="server" Text=" Mes " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="Label3" runat="server" Text="  " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="Label4" runat="server" Text=" Hasta " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbMesHasta" runat="server" Text=" Mes " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>
                  <asp:Label ID="Label5" runat="server" Text="Dias ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbDIas" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>
                  <asp:Label ID="Label8" runat="server" Text="Meses ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbMes" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label10" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label12" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>
                  <asp:Label ID="Label11" runat="server" Text="Años ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbano" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label13" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <!--AGREGAMOS LOS FILTROS-->
           <div class="form-check-inline">
               <div class="form-group form-check">
                   <asp:CheckBox ID="cbProcesarRegistros" runat="server" Text="Procesar Registros" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="cbProcesarRegistros_CheckedChanged" ToolTip="Procesar Registros de las renovaciones" />
               </div>
           </div>
        <div class="form-row">
            <div class="form-group col-md-2">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group col-md-2">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHAsta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group col-md-4">
                        <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarRamo" AutoPostBack="true" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarRamo_SelectedIndexChanged"></asp:DropDownList>
            </div>

              <div class="form-group col-md-4">
                   <asp:Label ID="lbSeleccionarSubRamo" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarSubRamo" runat="server" ToolTip="Seleccionar SubRamo" CssClass="form-control"></asp:DropDownList>
            </div>

              <div class="form-group col-md-3">
                   <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

              <div class="form-group col-md-3">
                       <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group col-md-3">
                        <asp:Label ID="lbCodSupervisor" runat="server" Text="Cod Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" TextMode="Number" runat="server" MaxLength="5" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group col-md-3">
                  <asp:Label ID="lbCodIntermediario" runat="server" Text="Cod Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFCodIntermediario" TextMode="Number" runat="server" MaxLength="5" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbValidarBalance" runat="server" Text="Validar Balance" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlValidarBalance" runat="server" ToolTip="Validar Balance" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-3">
                  <asp:Label ID="lbExcluirMotores" runat="server" Visible="false" Text="Excluir Motores" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlExcluirMotorew" runat="server" Visible="false" ToolTip="Excluir Motores" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-3" id="DivMes" runat="server" visible="false">
                  <asp:Label ID="lbSeleccionarMes" runat="server" Text="Mes" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarMes" runat="server" ToolTip="Seleccionar Mes" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3" id="DivAno" runat="server" visible="false">
                  <asp:Label ID="lbSeleccionarAno" runat="server" Text="Año" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtAno" runat="server" CssClass="form-control" TextMode="Number" MaxLength="4" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <!--FINALIZAN LOS CONTROLES DE FILTROS-->

        <div id="DivBloqueConsultaNormal" runat="server">
            <!--INGRESMAOS LOS BOTONES-->
        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" ToolTip="Exportar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
            <button type="button" id="btnEstadistica" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".bd-example-modal-xl">Estadistica</button>
            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-outline-primary btn-sm Custom" ToolTip="Imprimir listado de renovación" OnClick="btnImprimir_Click" />
        </div>
        <!--FINALIZAMOS LOS BOTONES-->
        <br />
        <!--INICIO DEL GRID-->
        <div class="table-responsive mT20">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:10%" align="left"> <asp:Label ID="lbPolizaHeaderRepeater" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbInicioVigenciaHeaderRepeater" runat="server" Text="Inicio" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbFinVigenciaHeaderRepeater" runat="server" Text="Fin" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbPrimaHeaderRepeater" runat="server" Text="Prima" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:20%" align="left"> <asp:Label ID="lbFacturadoHeaderRepeater" runat="server" Text="Facturado" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:20%" align="left"> <asp:Label ID="lbCobradoHeaderRepeater" runat="server" Text="Cobrado" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:20%" align="left"> <asp:Label ID="lbBalanceHeaderRepeater" runat="server" Text="Balance" CssClass="Letranegrita"></asp:Label> </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoRenovacion" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                <td style="width:10%"> <%# Eval("FechaInicioVigencia") %> </td>
                                <td style="width:10%"> <%# Eval("FechaFinVigencia") %> </td>
                                <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Prima")) %> </td>
                                <td style="width:20%"> <%#string.Format("{0:n2}", Eval("Facturado")) %> </td>
                                <td style="width:20%"> <%#string.Format("{0:n2}", Eval("Cobrado")) %> </td>
                                <td style="width:20%"> <%#string.Format("{0:n2}", Eval("Balance")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

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
        </div>





           <div id="DivBloqueProcesarRegistros" runat="server" visible="false">
               <div class="form-check-inline">
                   <div class="form-group form-check">
                       <asp:CheckBox ID="cbExclirMotoresMachado" runat="server" Text="Excluir Motores" CssClass="form-check-input Letranegrita" />
                   </div>
               </div>
               <div align="center">
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" ToolTip="Procesar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnProcesar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" ToolTip="Actualizar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnConsultarRegistrosProcesados" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultarRegistrosProcesados_Click" />
            <asp:Button ID="btnReporteRegistrosProcesados" runat="server" Text="Reporte" ToolTip="Exportar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnReporteRegistrosProcesados_Click" />
        </div>
               <br />
               <div class="table-responsive">
                   <table class="table table-hover">
                       <thead>
                           <tr>
                               <th style="width:35%" align="left"> SUPERVISOR </th>
                               <th style="width:5%" align="left"> RENOVAR </th>
                               <th style="width:15%" align="left"> MONTO </th>
                               <th style="width:5%" align="left"> RENOVADAS </th>
                               <th style="width:15%" align="left"> MONTO R </th>
                               <th style="width:15%" align="left"> COBRADO </th>
                               <th style="width:10%" align="left"> % </th>
                           </tr>
                       </thead>

                       <tbody>
                           <asp:Repeater ID="rpListadoRenovacionMachado" runat="server">
                               <ItemTemplate>
                                   <tr>
                               <td style="width:35%" align="left"> <%# Eval("Supervisor") %> </td>
                               <td style="width:5%" align="left"> <%#string.Format("{0:n0}", Eval("CantidadRenovar")) %>  </td>
                               <td style="width:15%" align="left"> <%#string.Format("{0:n2}", Eval("MontoRenovar")) %>  </td>
                               <td style="width:5%" align="left"> <%#string.Format("{0:n0}", Eval("CantidadRenovada")) %>  </td>
                               <td style="width:15%" align="left"> <%#string.Format("{0:n2}", Eval("MontoRenovado")) %>  </td>
                               <td style="width:15%" align="left"> <%#string.Format("{0:n2}", Eval("Cobrado")) %>  </td>
                               <td style="width:10%" align="left"> <%# Eval("Porcentaje") %>  </td>
                           </tr>
                               </ItemTemplate>
                           </asp:Repeater>
                       </tbody>
                   </table>
               </div>
               <div align="center">
                <asp:Label ID="lbPaginaActualTituloMachado" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleMachado" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloMachado" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableMachado" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
               <div id="divPaginacionProceso" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroProceso" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroProceso_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorProceso" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorProceso_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionProceso" runat="server" OnItemCommand="dtPaginacionProceso_ItemCommand" OnItemDataBound="dtPaginacionProceso_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralProceso" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteProceso" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteProceso_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoProceso" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoProceso_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
               <br />

           </div>
    </div>


    <!--ESTADISTICA-->
    <div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbTituloEstatustica" runat="server" Text="Estadistica de Renovación"></asp:Label>
          </div>
          <asp:ScriptManager ID="EstadisticaScripmanager" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="EstadisticaUpdatePanel" runat="server">
              <ContentTemplate>
                  <div class="form-check">
                      <div class="form-check-inline">
                          <asp:RadioButton ID="rbEstadisticaSupervisor" runat="server" Text="Por Supervisor" GroupName="Estadistica" CssClass="form-check-input LetrasNegrita" />
                      </div>
                      <div class="form-check-inline">
                          <asp:RadioButton ID="rbEstadisticaIntermediario" runat="server" Text="Por Intermediario" GroupName="Estadistica" CssClass="form-check-input LetrasNegrita" />
                      </div>
                  </div>
                  <div class="form-row">
                      <div class="form-group col-md-4">
                          <asp:Label ID="lbFechaDesdeEstadistica" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                          <asp:TextBox ID="txtFechaDesdeEstadistica" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbFechaHastaEstadistica" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                          <asp:TextBox ID="txtFechaHastaEstadistica" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionarRamoEstadistica" runat="server" Text="Seleccionar Ramo" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarRamoEstadistica" runat="server" OnSelectedIndexChanged="ddlSeleccionarRamoEstadistica_SelectedIndexChanged" AutoPostBack="true" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
                      </div>

                      

                       <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionarSubramoEstadistica" runat="server" Text="Seleccionar SubRamo" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarSubramoEstadistica" runat="server" ToolTip="Seleccionar SubRamo" CssClass="form-control"></asp:DropDownList>
                      </div>

                       <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionaroficinaEstadistica" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionaroficinaEstadistica" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                      </div>
                        <div class="form-group col-md-4">
                          <asp:Label ID="lbValidarBalanceEstadistica" runat="server" Text="Validar Balance" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlValidarBalanceEstadistica" runat="server" ToolTip="Validar Balance" CssClass="form-control"></asp:DropDownList>
                      </div>
                        <div class="form-group col-md-4">
                          <asp:Label ID="lbExcluirMotoresEstadistica" runat="server" Visible="false" Text="Excluir Motores" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlExcluirMotoresEstadistica" runat="server" Visible="false" ToolTip="Excluir Motores" CssClass="form-control"></asp:DropDownList>
                      </div>
                  </div>
                 
                   <div align="center">
                      <asp:Button ID="btnConsultarEstadistica" runat="server" Text="Buscar" ToolTip="Consultar Estadistica" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultarEstadistica_Click" />
              
                  </div>
          <br />
                  <!--INICIO DEL GRID-->
                  <div class="table-responsive mT20">
                      <table class="table table-hover">
                          <thead>
                              <tr>
                                  <th style="width:60%" align="left"> <asp:Label ID="lbPersonaHeaderRepeaterEstadistica" runat="server" Text="Persona" CssClass="Letranegrita"></asp:Label> </th>
                                   <th style="width:20%" align="left"> <asp:Label ID="lbCantidadHeaderRepeaterEstadistica" runat="server" Text="Cantidad" CssClass="Letranegrita"></asp:Label> </th>
                                   <th style="width:20%" align="left"> <asp:Label ID="lbMontoHeaderRepeaterEstadistica" runat="server" Text="Monto" CssClass="Letranegrita"></asp:Label> </th>
                              </tr>
                          </thead>
                          <tbody>
                              <asp:Repeater ID="rpListadoEstadistica" runat="server">
                                  <ItemTemplate>
                                      <tr>
                                          <td style="width:60%"> <%# Eval("Persona") %> </td>
                                          <td style="width:20%"> <%#string.Format("{0:n0}", Eval("CantidadPoliza")) %> </td>
                                          <td style="width:20%"> <%#string.Format("{0:n2}", Eval("Monto")) %> </td>
                                      </tr>
                                  </ItemTemplate>
                              </asp:Repeater>
                          </tbody>
                      </table>
                  </div>

                  <div align="center">
                <asp:Label ID="lbPaginaActualTituloEstadistica" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleEstadistica" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloEstadistica" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableEstadistica" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionEstadistica" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="linkPrimerostadistica" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="linkPrimerostadistica_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteirorEstadistica" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteirorEstadistica_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtEstadistica" runat="server" OnItemCommand="dtEstadistica_ItemCommand" OnItemDataBound="dtEstadistica_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralEstadistica" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteEstadistica" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteEstadistica_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoEstadistica" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoEstadistica_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                  <!--FIN DEL GRID-->
              </ContentTemplate>
          </asp:UpdatePanel>
          <br />
                <div align="center">
                     <asp:Button ID="btnExportarEstadistica" runat="server" Text="Exportar" ToolTip="Exportar Estadistica" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportarEstadistica_Click" />
                </div>
          <br />
      </div>
    </div>
  </div>
</div>
</asp:Content>

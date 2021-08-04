<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ConsultaPersonas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.SuperIntendencia.ConsultaPersonas" %>
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

          .BotonEspecoal {
           width:100%;
             font-weight:bold;
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
          .auto-style1 {
              width: 70%;
              height: 36px;
          }
          .auto-style2 {
              width: 10%;
              height: 36px;
          }
    </style>

    <script type="text/javascript">
        function CamposBusquedaNormalVacio() {
            alert("Los campos RNC y nombre no pueden estar ambos vacio, favor de verificar.");
            $("#<%=txtRNCCedula.ClientID%>").css("border-color", "red");
            $("#<%=txtNombre.ClientID%>").css("border-color", "red");
        }
        function CamposChasisPlacaVacios() {
            alert("Los campos Placa y Chasis no pueden estar ambos vacio, favor de verificar.");
            $("#<%=txtPlacaConsulta.ClientID%>").css("border-color", "red");
            $("#<%=txtChasisConsulta.ClientID%>").css("border-color", "red");  
        }

        function ArchivoNoProcesado() {
            alert("Error al procesar el archivo, no se selecciono ninguno o los parametros de este no son correctos, favor de verificar.");

        }
        function InformacionAProcesarNoEncontrada() {
            alert("No se encontraron registros extraidos de archivos, favor de verificar.");
        }



    </script>

   <div class="container-fluid">
    <br /><br />
       <div class="form-check-inline">
           <div class="form-group form-check">               
               <asp:RadioButton ID="rbExportarPDF" runat="server" Text="Exportar a PDF" CssClass="form-check-input Letranegrita" GroupName="Exportar" ToolTip="Exportar Informacion a PDF" />
               <asp:RadioButton ID="rbExportarWord" runat="server" Text="Exportar a Word" CssClass="form-check-input Letranegrita" GroupName="Exportar" ToolTip="Exportar Informacion a Word" />
               <br />
                
           </div>
           
      
       </div>
       <asp:ScriptManager ID="ScripMAnagerConsultaPersonas" runat="server"></asp:ScriptManager>


       <div class="form-check-inline">
           <div class="form-group form-check">
               <asp:RadioButton ID="rbConsultaNormal" runat="server" Text="Consultar Por RNC o Nombre" CssClass="form-check-input Letranegrita" GroupName="TipoConsulta" ToolTip="Consultar mediante el rnc o el Nombre" />
               <asp:RadioButton ID="rbConsultaChasisPlaca" runat="server" Text="Consultar por Placa o Chasis" CssClass="form-check-input Letranegrita " GroupName="TipoConsulta" ToolTip="Consultar mediante el chasis o la placa" /><br />
               
           </div>
     
       </div>
       <br />
       <div class="form-check-inline">
            <div class="form-group form-check">
          <asp:CheckBox ID="cbBusquedaPorLote" runat="server" CssClass="form-check-input Letranegrita" ToolTip="Buscar informacion de Personas mediante un archio de excel seleccionado del equipo" Text="Buscar Mediante Archivo" AutoPostBack="true" OnCheckedChanged="cbBusquedaPorLote_CheckedChanged" />
      </div>
       </div>
       <div class="form-row">
           <div class="form-group col-md-3">
               <asp:Label ID="lbConsuktarRNC" runat="server" Text="RNC / Cedula" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtRNCCedula" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-3">
               <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-3">
               <asp:Label ID="lbPlacaConsulta" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtPlacaConsulta" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-3">
               <asp:Label ID="lbChasisConsulta" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtChasisConsulta" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-6">
               <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Seleccionar Ramo" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
           </div>

            <div id="DivBuscarArchivoExcel" runat="server" class="form-group col-sm-6">
                                  <label for="FileUpload1">Buscar Archivo en el equipo</label>
                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control-file" runat="server" />
                                </div>
       </div>
       <div align="center">
           <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultar_Click" />
           <asp:Button ID="btnProcesarRegistros" runat="server" Text="Procesar" ToolTip="Procesar Registros" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnProcesarRegistros_Click" /><br />
           <asp:Label ID="lbError" runat="server" Text="Error" ForeColor="Red" Visible="false"></asp:Label>
       </div>

       <br />
       <div id="DivBloqueConsulta" runat="server">
           <!--DETALLE DE LOS CLIENTES ENCONTRADOS-->
       <div align="center">
           <asp:Label ID="lbCantidadRegistrosClienteTitulo" runat="server" Text="Registros Encontrados ( " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosClienteVariable" runat="server" Text=" NO " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosClienteCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
       <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionCobertura" data-toggle="collapse" data-target="#InformacionCliente" aria-expanded="false" aria-controls="collapseExample">
                    INFORMACION DE CLIENTE
                     </button><br />
       <div class="collapse" id="InformacionCliente">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelCliente" runat="server">
                       <ContentTemplate>
                            <div class="table-responsive mT20">
                         <table class="table table-hover">
                            <thead>
                                 <tr>
                                 <th style="width:10%"> <asp:Label ID="lbSeleccionarRegistroHeaderRepeaterCliente" runat="server" Text="Seleccionar" CssClass="Letranegrita"></asp:Label> </th>
                                 <th style="width:20%"> <asp:Label ID="lbNombreClienteHEaderRepeaterCliente" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label> </th>
                                 <th style="width:10%"> <asp:Label ID="lbRNCHeaderRepeaterCliente" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label> </th>
                                 <th style="width:20%"> <asp:Label ID="lbRamoHeaderRepeaterCliente" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label> </th>
                                 <th style="width:10%"> <asp:Label ID="lbPlacaHeaderRepeaterCliente" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label> </th>
                                 <th style="width:10%"> <asp:Label ID="lbChasisHeaderRepeaterCliente" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label> </th>
                                 <th style="width:10%"> <asp:Label ID="lbinicioVigenciaheaderRepeaterCliente" runat="server" Text="Inicio" CssClass="Letranegrita"></asp:Label> </th>
                                 <th style="width:10%"> <asp:Label ID="lbFinVigenciaHeaderRepeater" runat="server" Text="Fin" CssClass="Letranegrita"></asp:Label> </th>
                             </tr>
                            </thead>
                             <tbody>
                                 <asp:Repeater ID="rpListadoBusquedaCliente" runat="server">
                                     <ItemTemplate>
                                         <tr>
                                             <asp:HiddenField ID="hfPolizaBusquedaCliente" runat="server" Value='<%# Eval("poliza") %>' />
                                             <asp:HiddenField ID="hfCotizacionBusquedaCliente" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                             <asp:HiddenField ID="hfSecuenciaBusquedaCliente" runat="server" Value='<%# Eval("Secuencia") %>' />

                                             <td style="width:10%"> <asp:Button ID="btnSeleccionarRegistrosBusquedaCliente" runat="server" Text="Seleccionar" ToolTip="Seleccionar Registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarRegistrosBusquedaCliente_Click" /> </td>
                                             <td style="width:10%"> <%# Eval("Nombre") %> </td>
                                             <td style="width:10%"> <%# Eval("NumeroIdentificacion") %> </td>
                                             <td style="width:10%"> <%# Eval("Ramo") %> </td>
                                             <td style="width:10%"> <%# Eval("Placa") %> </td>
                                             <td style="width:10%"> <%# Eval("Chasis") %> </td>
                                             <td style="width:10%"> <%# Eval("InicioVigencia") %> </td>
                                             <td style="width:10%"> <%# Eval("FinVigencia") %> </td>
                                         </tr>
                                     </ItemTemplate>
                                 </asp:Repeater>
                             </tbody>
                         </table>
                     </div>
                     <!--PAGINACION DEL REPEATER-->
            <div align="center">
                <asp:Label ID="lbPaginaActualTituloCliente" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleCliente" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloCliente" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableCliente" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionCliente" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaCliente" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaCliente_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorCliente" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorCliente_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionCliente" runat="server" OnItemCommand="dtPaginacionCliente_ItemCommand" OnItemDataBound="dtPaginacionCliente_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralCliente" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteCliente" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteCliente_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoCliente" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoCliente_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                      
                   </div>

           <div id="DivBloqueDetalleCliente" runat="server">
               <hr />
               <div align="center">
                   <asp:Label ID="lbTituloDetaleCliente" runat="server" Text="Detalle del Cliente Seleccionado" align="center" CssClass="Letranegrita"></asp:Label>
               </div>
               <br />
               <div class="form-row">
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbNombreDetalleCliente" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtNombreDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbRNCDetalleCliente" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtENCDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbRamoDetalleCliente" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtRamoDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbNombreVendedorDetalleCliente" runat="server" Text="Vendedor" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtNombreVendedorDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbRNCVendedorDetalleCliente" runat="server" Text="RNC Vendedor" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtRNCVendedorDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbLicenciaVenedirDetalleCliente" runat="server" Text="Licencia" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtLicenciaDetalleVendedor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbTipoVehiculoDetalleCliente" runat="server" Text="Tipo de Vehiculo" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txttipoVehiculoDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbMarcaDetalleCliente" runat="server" Text="Marca" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtMarcaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbModeloDetalleCliente" runat="server" Text="Modelo" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtModeloDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbAnoDetalleCliente" runat="server" Text="Año" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtAnoDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbPlacaDetalleCliente" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtPalcaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbChasisDetalleCliente" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtCiasusDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbCOlorDetalleCliente" runat="server" Text="Color" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtColorDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbMontoAseguradoDetalleCliente" runat="server" Text="Monto Asegurado" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtMontoAseguradoDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbPrimaDetalleCliente" runat="server" Text="Prima" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtPrimaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbInicioVigenciaDetalleCliente" runat="server" Text="Inicio de vigencia" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtInicioVigenciaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbFinVigenciaDetalleCliente" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtFinVigenciaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-4">
                       <asp:Label ID="lbPolizaDetalleCliente" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtPolizaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
               </div>
           </div>
            </ContentTemplate>
                   </asp:UpdatePanel>
                </div>
            </div>
       <br />
        <!--DETALLE DE LOS INTERMEDIARIOS / SUPERVISORES ENCONTRADOS-->
       <div align="center">
           <asp:Label ID="lbCantidadIntermediariosSupervisorTitulo" runat="server" Text="Registros Encontrados ( " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadIntermediariosSupervisorVariable" runat="server" Text=" NO " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadIntermediariosSupervisorCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
       <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionIntermediarioSupervisor" data-toggle="collapse" data-target="#InformacionIntermediarioSupervisor" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE INTERMEDIARIO / SUPERVISOR
                     </button><br />
       <div class="collapse" id="InformacionIntermediarioSupervisor">
                <div class="card card-body">
                  <asp:UpdatePanel ID="UpdatePanelIntermediario" runat="server">
                      <ContentTemplate>
                          <div class="table-responsive mT20">
                      <table class="table table-hover">
                          <thead>
                              <tr>
                                  <th style="width:10%" align="left"> <asp:Label ID="SeleccionadHeaderIntermediario" runat="server" Text="Seleccionar" CssClass="Letranegrita"></asp:Label> </th>
                                  <th style="width:40%" align="left"> <asp:Label ID="lbNombreIntermediarioHeaderIntermediario" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label> </th>
                                  <th style="width:10%" align="left"> <asp:Label ID="lbEstatusHEaderIntermediario" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label> </th>
                                  <th style="width:10%" align="left"> <asp:Label ID="lbRNCHeaderIntermediario" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label> </th>
                                  <th style="width:10%" align="left"> <asp:Label ID="lbFechaEntradaHEaderIntermediario" runat="server" Text="Fecha de Entrada" CssClass="Letranegrita"></asp:Label> </th>
                                  <th style="width:10%" align="left"> <asp:Label ID="lbLicenciaSeguroHeaderIntermediario" runat="server" Text="Licencia de Seguro" CssClass="Letranegrita"></asp:Label> </th>
                                  <th style="width:10%" align="left"> <asp:Label ID="lbOficinaHeaderIntermediario" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label> </th>
                              </tr>
                          </thead>
                          <tbody>
                              <asp:Repeater ID="rpListadoIntermediarios" runat="server">
                                  <ItemTemplate>
                                      <tr>
                                          <asp:HiddenField ID="hfCodigointermediario" runat="server" Value='<%# Eval("Codigo") %>' />
                                          <td style="width:10%"> <asp:Button ID="btnSeleccionarIntermediarioRepeater" runat="server" Text="Seleccionar" ToolTip="Seleccionar Registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarIntermediarioRepeater_Click" /> </td>
                                          <td style="width:40%"> <%# Eval("Nombre") %> </td>
                                          <td style="width:10%"> <%# Eval("Estatus") %> </td>
                                          <td style="width:10%"> <%# Eval("Rnc") %> </td>
                                          <td style="width:10%"> <%# Eval("FechaEntrada") %> </td>
                                          <td style="width:10%"> <%# Eval("LicenciaSeguro") %> </td>
                                          <td style="width:10%"> <%# Eval("NombreOficina") %> </td>
                                      </tr>
                                  </ItemTemplate>
                              </asp:Repeater>
                          </tbody>
                      </table>
                  </div>
                      <!--PAGINACION DEL REPEATER-->
            <div align="center">
                <asp:Label ID="lbPaginaActualTituloIntermediario" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleIntermediario" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloIntermediario" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableIntermedairaio" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
            <div id="DivPaginacionIntermediario" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroIntermediario" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroIntermediario_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorIntermediario" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorIntermediario_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtIntermediario" runat="server" OnItemCommand="dtIntermediario_ItemCommand" OnItemDataBound="dtIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionIntermediario" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteIntermediario" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteIntermediario_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoIntermediario" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoIntermediario_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <div id="DivDetalleInformacionIntermediarioSeleccionado" runat="server">
                <hr />
                <div align="center">
                    <asp:Label ID="lbTituloDetalleIntermediarios" runat="server" Text="Detalle de Intermediarios / Supervisor" CssClass="Letranegrita"></asp:Label>
                </div>
                <br />
           <div class="form-row">
               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioCodigoDetalle" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioCodigoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioTipoRNCDetalle" runat="server" Text="Tipo de Identificación" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioTipoRNCDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioNumeroIdentificacionDetalle" runat="server" Text="Numero de Identificación" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioNumeroIdentificacionDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioNombreDetalle" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioNombreDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioSupervisorDetalle" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioSupervisorDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioFechaEntradaDetalle" runat="server" Text="Fecha de Entrada" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioFechaEntradaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioTelefonoResidenciaDetalle" runat="server" Text="Telefono de Residencia" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioTelefonoResidenciaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioTelefonoOficina" runat="server" Text="Telefono de oficina" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioTelefonoOficinaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioCelularDetalle" runat="server" Text="Celular" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioCelularDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioLicenciaSeguroDetalle" runat="server" Text="Licencia de Seguro" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioLicenciaSeguroDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioOficinaDetalle" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioOficinaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioFechaNacimientoDetalle" runat="server" Text="Fecha de nacimiento" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioFechaNacimientoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioCuentaBancoDetalle" runat="server" Text="Cuenta de Banco" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioCuentaBancoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioBancoDetalle" runat="server" Text="Banco" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioBancoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="form-group col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioFormaPagoDetalle" runat="server" Text="Forma de Pago" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioFormaPagoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>
           </div>
       </div>
                      </ContentTemplate>
                  </asp:UpdatePanel>
                   </div>
            
                </div>
       <br />
        <!--DETALLE DE LOS PROVEEDORES ENCONTRADOS-->
       <div align="center">
           <asp:Label ID="lbCantidadProveedorTitulo" runat="server" Text="Registros Encontrados ( " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadProveedorVariable" runat="server" Text=" NO " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadProveedorCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
       <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionproveedor" data-toggle="collapse" data-target="#InformacionProveedor" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE PROVEEDOR
                     </button><br />
       <div class="collapse" id="InformacionProveedor">
                <div class="card card-body">
                 <asp:UpdatePanel ID="UpdatePanelProveedores" runat="server">
                     <ContentTemplate>
                           <div class="table-responsive mT20">
                       <table class="table table-hover">
                           <thead>
                               <tr>
                               <th style="width:10%"> <asp:Label ID="lbSeleccionarHeadeRepeaterProveedor" runat="server" Text="Seleccionar" CssClass="Letranegrita"></asp:Label> </th>
                               <th style="width:50%"> <asp:Label ID="lbNombreHeadeRepeaterProveedor" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label> </th>
                               <th style="width:10%"> <asp:Label ID="lbRNCHeadeRepeaterProveedor" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label> </th>
                               <th style="width:10%"> <asp:Label ID="lbTipoClienteHeadeRepeaterProveedor" runat="server" Text="Tipo de Proveedor" CssClass="Letranegrita"></asp:Label> </th>
                               <th style="width:10%"> <asp:Label ID="lbTipoRNCHeadeRepeaterProveedor" runat="server" Text="Tipo de RNC" CssClass="Letranegrita"></asp:Label> </th>
                               <th style="width:10%"> <asp:Label ID="lbFechaCreadoHeadeRepeaterProveedor" runat="server" Text="Fecha Creado" CssClass="Letranegrita"></asp:Label> </th>
                           </tr>
                           </thead>
                           <tbody>
                               <asp:Repeater ID="rpListadoProveedores" runat="server">
                                   <ItemTemplate>
                                       <tr>
                                           <asp:HiddenField ID="hfCodigoproveedor" runat="server" Value='<%# Eval("Codigo") %>' />

                                           <td style="width:10%"> <asp:Button ID="btnSeleccionarRegistroProveedor" runat="server" Text="Seleccionar" ToolTip="Seleccionar Registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarRegistroProveedor_Click" /> </td>
                                           <td style="width:50%"> <%# Eval("NombreCliente") %> </td>
                                           <td style="width:10%"> <%# Eval("Rnc") %> </td>
                                           <td style="width:10%"> <%# Eval("TipoCliente") %> </td>
                                           <td style="width:10%"> <%# Eval("TipoIdentificacion") %> </td>
                                           <td style="width:10%"> <%# Eval("FechaCreado") %> </td>
                                       </tr>
                                   </ItemTemplate>
                               </asp:Repeater>
                           </tbody>
                       </table>

                   </div>

                              <!--PAGINACION DEL REPEATER-->
           <div align="center">
                <asp:Label ID="lbPaginaActualTituloProveedor" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleProveedor" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloProveedor" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableProveedor" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
           <div id="DivPaginacionProveedores" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroProveedor" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroProveedor_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorProveedor" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorProveedor_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtProveedor" runat="server" OnItemCommand="dtProveedor_ItemCommand" OnItemDataBound="dtProveedor_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionProveedor" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteProveedor" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteProveedor_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoProveedor" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoProveedor_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
           <div id="DivDetalleProveedores" runat="server">
               <hr />
               <div align="center">
                   <asp:Label ID="lbTituloDetalleProveedor" runat="server" Text="Detalle del proveedor Seleccionado" CssClass="Letranegrita"></asp:Label>
               </div>
               <br />
                        <div class="form-row">
                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorCodigo" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCodigo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorTipoProveedor" runat="server" Text="Tipo de Proveedor" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTipoProveedor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorNombre" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorTipoRNC" runat="server" Text="Tipo de RNC" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTipoRNC" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorRNC" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorRNC" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedrFechaCreado" runat="server" Text="Fecha Creado" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorFechaCreado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorTelefonoCasa" runat="server" Text="Telefono" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTelefonoCasa" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorTelefonoOficina" runat="server" Text="Telefono de Oficina" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTelefonoOficina" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProvedorCelular" runat="server" Text="Celular" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCelular" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorCuentaBanco" runat="server" Text="Cuenta de Banco" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCuentaBanco" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorBAnco" runat="server" Text="Banco" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorBanco" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorTipoCuentaBAnco" runat="server" Text="Tipo de Cuenta" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProbeedorTipoCuentaBAnco" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorClaseProveedor" runat="server" Text="Clase de Proveedor" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorClaseProveedor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorFechaUltimoPago" runat="server" Text="Ultimo Pago" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorFechaUltimoPago" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorLimiteCredito" runat="server" Text="Limite de Credito" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorLimiteCredito" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-12">
                                <asp:Label ID="lbDetalleProveedorDireccion" runat="server" Text="Dirección" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorDireccion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorTotalPagado" runat="server" Text="Total Pagado" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTotalPagado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProvvedorCantidadSolicitud" runat="server" Text="Cantidad de Solicitud Emitidas" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCantidadSolicitud" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorCantidadSolicitudCanceladas" runat="server" Text="Cantidad de Solicitud Canceladas" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCantidadSolicitudCanceadas" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorUltimaFechaSolicitud" runat="server" Text="Ultima Fecha de Solicitud" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorUltimaFechaSOlicitud" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedrNumeroSolicitud" runat="server" Text="Numero de Solicitud" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorNumeroSolicitud" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorDescripcionTipoSolicitud" runat="server" Text="Descripcion de Tipo de Solicitud" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorDescripcionTipoSolciitid" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleproveedrValor" runat="server" Text="Valor" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorValor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleproveedorNumeroCheque" runat="server" Text="Numero de Cheque" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorNumeroCheque" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorFechaCheque" runat="server" Text="Fecha de Cheque" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorFechaCheque" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:Label ID="lbDetalleProveedorUsuario" runat="server" Text="Usuario" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleproveedorUsuario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-4">

                            </div>

                            <div class="form-group col-md-4">

                            </div>

                            <div class="form-group col-md-12">
                                <asp:Label ID="lbDetalleProveedorConcepto1" runat="server" Text="Concepto 1" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorConcepto1" runat="server" TextMode="MultiLine" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-12">
                                <asp:Label ID="lbDetalleProveedorConcepto2" runat="server" Text="Concepto 2" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorConcepto2" runat="server" TextMode="MultiLine" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     </ContentTemplate>
                 </asp:UpdatePanel>
                   </div>
                </div>
       <br />
       <div align="center">
           <asp:Label ID="lbCantidadRegistrosAseguradoBajoPolizaTitulo" runat="server" Text="Registros Encontrados ( " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosAseguradoBajoPolizaVariable" runat="server" Text=" NO " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosAseguradoBajoPolizaCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
       <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnAseguradoBajoPoliza" data-toggle="collapse" data-target="#InformacionAsegurdoBajoPoliza" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE ASEGURADO BAJO POLIZA
                     </button><br />
       <div class="collapse" id="InformacionAsegurdoBajoPoliza">
                <div class="card card-body">
                 <asp:UpdatePanel ID="UpdatePanelAsegurado" runat="server">
                     <ContentTemplate>
                           <div class="table-responsive mT20">
                       <table class="table table-hover">
                           <thead>
                               <tr>
                                   <th style="width:10%" align="left" > <asp:Label ID="lbSeleccionarRegistros" runat="server" Text="Seleccionar" CssClass="Letranegrita"></asp:Label> </th>
                                   <th style="width:40%" align="left" > <asp:Label ID="lbNombreHeaderRepeaterAsegurado" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label> </th>
                                   <th style="width:10%" align="left" > <asp:Label ID="lbPolizaHeaderRepeaterAsegurado" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label> </th>
                                   <th style="width:10%" align="left" > <asp:Label ID="lbEstatusheaderRepeaterAsegurado" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label> </th>
                                   <th style="width:10%" align="left" > <asp:Label ID="lbItemHeaderRepeaterAsegurado" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label> </th>
                                   <th style="width:10%" align="left" > <asp:Label ID="lbInicioVigenciaHeaderRepeaterAsegurado" runat="server" Text="Inicio de Vigencia" CssClass="Letranegrita"></asp:Label> </th>
                                   <th style="width:10%" align="left" > <asp:Label ID="lbFinVigenciaHeaderRepeaterAsegurado" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label> </th>
                               </tr>
                           </thead>
                           <tbody>
                               <asp:Repeater ID="rpListadoRegistrosasegurado" runat="server">
                                   <ItemTemplate>
                                       <tr>
                                           <asp:HiddenField ID="hfPolizaInformacionAsegurado" runat="server" Value='<%# Eval("Poliza") %>' />
                                           <asp:HiddenField ID="hfCotizacionInformacionAsegurado" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                           <asp:HiddenField ID="hfSecuenciaInformacionAsegurado" runat="server" Value='<%# Eval("Item") %>' />

                                           <td style="width:10%"> <asp:Button ID="btnSeleccionarRegistrosInformacionAsegurado" runat="server" Text="Seleccionar" ToolTip="Seleccionar registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarRegistrosInformacionAsegurado_Click" /> </td>
                                           <td style="width:40%"> <%# Eval("Nombre") %> </td>
                                           <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                           <td style="width:10%"> <%# Eval("Estatus") %> </td>
                                           <td style="width:10%"> <%# Eval("Item") %> </td>
                                           <td style="width:10%"> <%# Eval("InicioVigencia") %> </td>
                                           <td style="width:10%"> <%# Eval("FinVigencia") %> </td>
                                       </tr>
                                   </ItemTemplate>
                               </asp:Repeater>
                           </tbody>
                       </table>
                   </div>

                                        <!--PAGINACION DEL REPEATER-->
           <div align="center">
                <asp:Label ID="lbPaginaActualTituloAsegurado" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleAsegurado" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloAsegurdo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableAsegurado" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
           <div id="DivPaginacionInformacionAsegurado" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroAsegurado" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroAsegurado_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorAsegurado" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorAsegurado_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtAsegurado" runat="server" OnItemCommand="dtAsegurado_ItemCommand" OnItemDataBound="dtAsegurado_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionAsegurado" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteAsegurado" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteAsegurado_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimaAsegurado" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimaAsegurado_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>

                         <div id="DivDetalleAsegurado" runat="server">
                             <hr />
                             <div align="center">
                                 <asp:Label ID="lbTituloDetalleasegurado" runat="server" Text="Detalle de Asegurado" CssClass="Letranegrita"></asp:Label>
                             </div>
                             <br />
                             <div class="form-row">
                                 <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>

                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoEstatus" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoEstatus" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoitem" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoitem" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoInicioVigencia" runat="server" Text="Inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoInicioVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoFinVigencia" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoFinVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoIntermediario" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoRNCIntermediario" runat="server" Text="RNC Intermediario" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoRNCIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoLicenciaIntermediario" runat="server" Text="Licencia Intermediario" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoLicenciaIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoprima" runat="server" Text="Prima" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoPrima" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoMontoAsegurado" runat="server" Text="Monto Asegurado" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoMontoasegurado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoTipoVehiculo" runat="server" Text="Tipo de Vehiculo" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoTipoVehiculo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoMarca" runat="server" Text="Marca" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoMarca" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoModelo" runat="server" Text="Modelo" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoModelo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoChasis" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoChasis" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoPlaca" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoPlaca" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoAno" runat="server" Text="Año" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoAno" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="form-group col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoColor" runat="server" Text="Color" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoColor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                             </div>
                         </div>
                     </ContentTemplate>
                 </asp:UpdatePanel>
                   </div>
                </div>
       <br />
       <div align="center">
           <asp:Label ID="lbCantidadRegistrosAseguradoTitulo" runat="server" Text="Registros Encontrados ( " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosAseguradoVariable" runat="server" Text=" NO " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosAseguradoCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
       <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionAsegurado" data-toggle="collapse" data-target="#InformacionAsegurado" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE ASEGURADO 
                     </button><br />
       <div class="collapse" id="InformacionAsegurado">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelAseguradoGeneral" runat="server">
                       <ContentTemplate>
                           <div class="table-responsive mT20">
                               <table class="table table-hover">
                                   <thead>
                                       <tr>
                                           <th style="width:10%" align="left"> <asp:Label ID="lbSeleccionarAseguradogeneral" runat="server" Text="Seleccionar" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:30%" align="left"> <asp:Label ID="lbNombreHeaderRepeaterAseguradoGeneral" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="left"> <asp:Label ID="lbRNCHeaderRepeaterAseguradoGeneral" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="left"> <asp:Label ID="lbPolizaHeaderRepeaterAseguradoGeneral" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:5%" align="left"> <asp:Label ID="lbItemHeaderRepeaterAseguradoGeneral" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:5%" align="left"> <asp:Label ID="lbIDAseguradoHeaderRepeaterAseguradoGeneral" runat="server" Text="Numero" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="left"> <asp:Label ID="blEstatusPolizaHeaderRepeaterAseguradoGeneral" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="left"> <asp:Label ID="lbInicioVigenciaHeaderRepeaterAseguradoGeneral" runat="server" Text="Inicio" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="left"> <asp:Label ID="lbFinVigenciaHeaderRepeaterAseguradoGeneral" runat="server" Text="Fin" CssClass="Letranegrita"></asp:Label> </th>
                                       </tr>
                                   </thead>
                                   <tbody>
                                       <asp:Repeater ID="rpIDListadoAseguradoGeneral" runat="server">
                                           <ItemTemplate>
                                               <tr>
                                                   <asp:HiddenField ID="hfCotizacionAseguradoGeneral" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                                   <asp:HiddenField ID="hfItemAseguradoGeneral" runat="server" Value='<%# Eval("Secuencia") %>' />
                                                   <asp:HiddenField ID="hfIdAseguradoAseguradoGeneral" runat="server" Value='<%# Eval("IdAsegurado") %>' />

                                                   <td style="width:10%"> <asp:Button ID="btnSeleccionarRegistroAseguradoGeneral" runat="server" Text="Seleccionar" OnClick="btnSeleccionarRegistroAseguradoGeneral_Click" ToolTip="Seleccionar Registro" CssClass="btn btn-outline-secondary btn-sm" /> </td>
                                                   <td style="width:30%"> <%# Eval("Nombre") %> </td>
                                                   <td style="width:10%"> <%# Eval("RNC") %> </td>
                                                   <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                                   <td style="width:5%"> <%# Eval("Secuencia") %> </td>
                                                   <td style="width:5%"> <%# Eval("IdAsegurado") %> </td>
                                                   <td style="width:10%"> <%# Eval("Estatus") %> </td>
                                                   <td style="width:10%"> <%# Eval("InicioVigencia") %> </td>
                                                   <td style="width:10%"> <%# Eval("FinVigencia") %> </td>
                                               </tr>
                                           </ItemTemplate>
                                       </asp:Repeater>
                                   </tbody>
                               </table>
                           </div>

            <!--PAGINACION DEL REPEATER-->
           <div align="center">
                <asp:Label ID="lbPaginaActualTituloAseguradoGeneral" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleAseguradoGeneral" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloAsegurdoGeneral" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableAseguradoGeneral" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
           <div id="DivPaginacionAseguradoGeneral" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroAseguradoGeneral" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroAseguradoGeneral_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorAseguradoGeneral" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorAseguradoGeneral_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtAseguradoGeneral" runat="server" OnItemCommand="dtAseguradoGeneral_ItemCommand" OnItemDataBound="dtAseguradoGeneral_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionAseguradoGeneral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteAseguradoGeneral" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteAseguradoGeneral_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoAseguradoGeneral" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoAseguradoGeneral_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>

                           <div id="DivDetalleAseguradoGeneral" runat="server">
                               <hr />
                               <div align="center">
                                   <asp:Label ID="lbTituloDetalleAseguradoGeneral" runat="server" Text="Detalle del Registro Seleccionado" CssClass="Letranegrita"></asp:Label>
                               </div>

                               <div class="form-row">
                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralEstatus" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralEstatus" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralCotizacion" runat="server" Text="Cotización" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralCotizacion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralSecuencia" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralSecuencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralIdAsegurado" runat="server" Text="Numero de Asegurado" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralIdAsegurado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralParentezco" runat="server" Text="Parentezco" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralParentezco" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralRNC" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralRNC" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralFechaNacimiento" runat="server" Text="Fecha de Nacimiento" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralFechaNacimiento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralSexo" runat="server" Text="Sexo" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralSexo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralInicioVigencia" runat="server" Text="Inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralInicioVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralFinVigencia" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralFinVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>
                               </div>
                           </div>
                       </ContentTemplate>
                   </asp:UpdatePanel>
                   </div>
                </div>
       <br />
       <div align="center">
           <asp:Label ID="lbCantidadRegistrosDependienteTitulo" runat="server" Text="Registros Encontrados ( " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosDependienteVariable" runat="server" Text=" NO " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosDependienteCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
       <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionDependiente" data-toggle="collapse" data-target="#InformacionDependiente" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE DEPENDIENTES 
                     </button><br />
       <div class="collapse" id="InformacionDependiente">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelDependiente" runat="server">
                       <ContentTemplate>
                           <div class="table-responsive mT20">
                               <table class="table table-hover">
                                   <thead>
                                       <tr>
                                           <th style="width:10%" align="center" > <asp:Label ID="lbSeleccionarRegistroHeaderRepeaterDetependiente" runat="server" Text="Seleccionar" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:30%" align="center" >  <asp:Label ID="lbNombreHeaderRepeaterDetependiente" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="center" >  <asp:Label ID="lbRNCHeaderRepeaterDetependiente" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="center" >  <asp:Label ID="lbPolizaHeaderRepeaterDetependiente" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:5%" align="center" >  <asp:Label ID="lbItemHeaderRepeaterDetependiente" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:5%" align="center" >  <asp:Label ID="lbIdAseguradoHeaderRepeaterDetependiente" runat="server" Text="No." CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="center" >  <asp:Label ID="lbEstatusHeaderRepeaterDetependiente" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="center" >  <asp:Label ID="lbInicioVigenciaHeaderRepeaterDetependiente" runat="server" Text="Inicio" CssClass="Letranegrita"></asp:Label> </th>
                                           <th style="width:10%" align="center" >  <asp:Label ID="lbFinVigenciaHeaderRepeaterDetependiente" runat="server" Text="Fin" CssClass="Letranegrita"></asp:Label> </th>
                                       </tr>
                                   </thead>
                                   <tbody>
                              
                                          <asp:Repeater ID="rpListadoDependientes" runat="server">
                                              <ItemTemplate>
                                                 <tr>
                                                   <asp:HiddenField ID="hfCotizacionDependiente" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                                   <asp:HiddenField ID="hfSecuenciaDependiente" runat="server" Value='<%# Eval("Secuencia") %>' />
                                                   <asp:HiddenField ID="hfIdAseguradoDependiente" runat="server" Value='<%# Eval("IdAsegurado") %>' />

                                                      <td style="width:10%"> <asp:Button ID="btnSeleccionarregistroDependiente" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarregistroDependiente_Click" ToolTip="Seleccionar registro" /> </td>
                                                      <td style="width:30%"> <%# Eval("Nombre") %> </td>
                                                      <td style="width:10%"> <%# Eval("RNC") %> </td>
                                                      <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                                      <td style="width:5%"> <%# Eval("Secuencia") %> </td>
                                                      <td style="width:5%"> <%# Eval("IdAsegurado") %> </td>
                                                      <td style="width:10%"> <%# Eval("Estatus") %> </td>
                                                      <td style="width:10%"> <%# Eval("InicioVigencia") %> </td>
                                                      <td style="width:10%"> <%# Eval("FinVigencia") %> </td>
                                                 </tr>


                                              </ItemTemplate>
                                          </asp:Repeater>
                                     
                                   </tbody>
                               </table>
                           </div>

                           <div align="center">
                <asp:Label ID="lbPaginaActualTituloDependiente" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleDependiente" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloDependiente" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableDependiente" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
           <div id="DivPaginacionDependiente" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroDependiente" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroDependiente_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorDependiente" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorDependiente_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtDependiente" runat="server" OnItemCommand="dtDependiente_ItemCommand" OnItemDataBound="dtDependiente_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionDependiente" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteDependiente" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteDependiente_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoDependiente" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoDependiente_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>

                           <div id="DivDetalleDependientes" runat="server">
                               <hr />
                               <div align="center">
                                   <asp:Label ID="lbTituloDetalleDependiente" runat="server" Text="Detalle del Registro Seleccionado" CssClass="Letranegrita"></asp:Label>
                               </div>
                               <div class="form-row">
                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependientePoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependientePoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                    <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteEstatus" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteEstatus" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteCotizacion" runat="server" Text="Cotización" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteCotizacion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteRNC" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteRNC" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteIdAsegurado" runat="server" Text="Id Asegurado" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteIdAsegurado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteParentezco" runat="server" Text="Parentezco" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteParentezco" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteFechaNacimiento" runat="server" Text="Fecha de Nacimiento" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteFechaNacimiento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteSexo" runat="server" Text="Sexo" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteSexo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteSecuencia" runat="server" Text="Secuencia" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteSecuencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteinicio" runat="server" Text="inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteinicio" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-4">
                                       <asp:Label ID="lbDetalleDependienteFinVigencia" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteFinVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>
                               </div>
                           </div>
                       </ContentTemplate>
                   </asp:UpdatePanel> 
                   </div>
                </div>
       <br />
       </div>





       <div id="DivBloqueProcesoLote" runat="server">
           <div class="form-check-inline">
               <div class="form-group form-check">
                   <asp:Label ID="lbLetreroBusquedaArchivoBusquedaPorLote" runat="server" Text="Tipo de Busqueda: " CssClass="Letranegrita"></asp:Label><br />
                   <asp:RadioButton ID="rbTodosLosParametros" runat="server" Text="Todos" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar por Todos los Parametros" />
                   <asp:RadioButton ID="rbPorNombreBusquedaPorLote" runat="server" Text="Nombre" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar mediante el nombre de la persona" />
                   <asp:RadioButton ID="rbNumeroIdentificacionBusquedaPorLote" runat="server" Text="Numero de Identificación" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar mediante el Numero de Identificación de la persona" />
                   <asp:RadioButton ID="rbChasisBusquedaPorLote" runat="server" Text="Chasis" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar mediante el Numero de Chasis" />
                   <asp:RadioButton ID="rbPlacaBusquedaPorLote" runat="server" Text="Placa" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar mediante el Numero de Placa" />
               </div>
           </div>
           <br />
           <div class="form-check-inline">
               <div class="form-group form-check">
                   <asp:Label ID="lbLetreroBuscarEn" runat="server" Text="Buscar Como" CssClass="Letranegrita"></asp:Label><br />
                   <asp:CheckBox ID="cbTodos" runat="server" Text="Todos" CssClass="form-check-input" ToolTip="Buscar en Todos los Registros" />
                   <asp:CheckBox ID="cbCliente" runat="server" Text="Cliente" CssClass="form-check-input" ToolTip="Buscar informacion en la data de los clientes registrados" />
                   <asp:CheckBox ID="cbIntermediario" runat="server" Text="Intermediario" CssClass="form-check-input" ToolTip="Buscar en la Data de los Intermediarios y Supervisores" />
                   <asp:CheckBox ID="cbProvedor" runat="server" Text="Proveedor" CssClass="form-check-input" ToolTip="Buscar en la Data de los Proveedores" />
                   <asp:CheckBox ID="cbAseguradoBajoPoliza" runat="server" Text="Asegurado P" CssClass="form-check-input" ToolTip="Buscar en la Data de los Asegurados Bajo Polizas" /><br />
                   <asp:CheckBox ID="cbAsegurado" runat="server" Text="Asegurado" CssClass="form-check-input" ToolTip="Buscar en la Data de los Asegurados" />
                   <asp:CheckBox ID="cbDependiente" runat="server" Text="Dependiente" CssClass="form-check-input" ToolTip="Buscar en la Data de los Dependientes" />
                   <asp:CheckBox ID="cbCheque" runat="server" Text="Cheque" CssClass="form-check-input" ToolTip="Buscar en la Data de las Solicitudes y Cheques" />
                   <asp:CheckBox ID="cbDocumentosAmigos" runat="server" Text="Documentos Amigos" CssClass="form-check-input" ToolTip="Buscar en la Data de los Documentos Amigos" />
               </div>
           </div>
           <div align="center">
               <asp:Label ID="lbCantidadRegistrosProcesadosTitulo" runat="server" Text="Cantidad de Registros Procesados ( " CssClass="Letranegrita"></asp:Label>
               <asp:Label ID="lbCantidadRegistrosProcesadosVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
               <asp:Label ID="lbCantidadRegistrosProcesadosCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
           </div>
           <div class="table-responsive">
               <table class="table table-hover">
                   <thead>
                       <tr>
                            <th align="left" class="auto-style1"> NOMBRE </th>
                            <th align="left" class="auto-style2"> IDENTIFICACION </th>
                            <th align="left" class="auto-style2"> CHASIS </th>
                            <th align="left" class="auto-style2"> PLACA </th>
                       </tr>
                   </thead>

                   <tbody>
                       <asp:Repeater ID="rpRegistrosCargadoArchivo" runat="server">
                           <ItemTemplate>
                               <tr>
                                    <td style="width:70%" align="left"> <%# Eval("Nombre") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("NumeroIdentificacion") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Chasis") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Placa") %> </td>
                               </tr>
                           </ItemTemplate>
                       </asp:Repeater>
                   </tbody>

                   
               </table>
           </div>

            <div align="center">
                <asp:Label ID="lbPaginaActualTituloArchivo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleArchivo" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloArchivo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableArchivo" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
           <div id="DivPaginacionArchivo" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroArchivo" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroArchivo_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorArchivo" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorArchivo_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtArchivo" runat="server" OnItemCommand="dtArchivo_ItemCommand" OnItemDataBound="dtArchivo_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionArchivo" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteArchivo" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteArchivo_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoArchivo" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoArchivo_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>

       </div>
  </div>
</asp:Content>

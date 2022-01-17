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
            background-color: #1E90FF;
            color: #000000;
        }
          .auto-style1 {
              width: 70%;
              height: 36px;
          }
          .auto-style2 {
              width: 10%;
              height: 36px;
          }

           .BotonImagen {
               width:40px;
               height:40px;
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
     
       <asp:ScriptManager ID="ScripMAnagerConsultaPersonas" runat="server"></asp:ScriptManager>


       <div class="form-check-inline">
     
               <asp:RadioButton ID="rbConsultaNormal" runat="server" Text="Consultar Por RNC o Nombre" CssClass="form-check-input Letranegrita" GroupName="TipoConsulta" ToolTip="Consultar mediante el rnc o el Nombre" />
               <asp:RadioButton ID="rbConsultaChasisPlaca" runat="server" Text="Consultar por Placa o Chasis" CssClass="form-check-input Letranegrita " GroupName="TipoConsulta" ToolTip="Consultar mediante el chasis o la placa" /><br />
             
       </div>
       <br />
       <div class="form-check-inline">
      
          <asp:CheckBox ID="cbBusquedaPorLote" runat="server" CssClass="form-check-input Letranegrita" ToolTip="Buscar informacion de Personas mediante un archio de excel seleccionado del equipo" Text="Buscar Mediante Archivo" AutoPostBack="true" OnCheckedChanged="cbBusquedaPorLote_CheckedChanged" />

       </div>
       <div class="row">
           <div class="col-md-3">
               <asp:Label ID="lbConsuktarRNC" runat="server" Text="RNC / Cedula" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtRNCCedula" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-3">
               <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-3">
               <asp:Label ID="lbPlacaConsulta" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtPlacaConsulta" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-3">
               <asp:Label ID="lbChasisConsulta" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtChasisConsulta" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="col-md-6">
               <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Seleccionar Ramo" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
           </div>

            <div id="DivBuscarArchivoExcel" runat="server" class="form-group col-sm-6">
                                  <label for="FileUpload1">Buscar Archivo en el equipo</label>
                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control-file" runat="server" />
                                </div>
       </div>
       <div align="center">
           <asp:ImageButton ID="btnConsultar" runat="server" CssClass="BotonImagen" OnClick="btnConsultar_Click1" ToolTip="Buscar Información" ImageUrl="~/Imagenes/Buscar.png" />
           <asp:ImageButton ID="btnProcesarRegistros" runat="server" CssClass="BotonImagen" OnClick="btnProcesarRegistros_Click1" ToolTip="Procesar Información" ImageUrl="~/Imagenes/Procesar.png" /><br />
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
       <button class="btn btn-outline-dark btn-sm BotonEspecoal" type="button" id="btnInformacionCobertura" data-toggle="collapse" data-target="#InformacionCliente" aria-expanded="false" aria-controls="collapseExample">
                    INFORMACION DE CLIENTE
                     </button><br />
       <div class="collapse" id="InformacionCliente">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelCliente" runat="server">
                       <ContentTemplate>
                         <table class="table table-striped">
                            <thead>
                                 <tr>
                                 <th scope="col"> Nombre </th>
                                 <th scope="col"> RNC </th>
                                 <th scope="col"> Romo </th>
                                 <th scope="col"> Placa </th>
                                 <th scope="col"> Chasis </th>
                                 <th scope="col"> Inicio </th>
                                 <th scope="col"> Fin </th>
                                 <th scope="col"> Seleccionar </th>
                             </tr>
                            </thead>
                             <tbody>
                                 <asp:Repeater ID="rpListadoBusquedaCliente" runat="server">
                                     <ItemTemplate>
                                         <tr>
                                             <asp:HiddenField ID="hfPolizaBusquedaCliente" runat="server" Value='<%# Eval("poliza") %>' />
                                             <asp:HiddenField ID="hfCotizacionBusquedaCliente" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                             <asp:HiddenField ID="hfSecuenciaBusquedaCliente" runat="server" Value='<%# Eval("Secuencia") %>' />

                                             
                                             <td> <%# Eval("Nombre") %> </td>
                                             <td> <%# Eval("NumeroIdentificacion") %> </td>
                                             <td> <%# Eval("Ramo") %> </td>
                                             <td> <%# Eval("Placa") %> </td>
                                             <td> <%# Eval("Chasis") %> </td>
                                             <td> <%# Eval("InicioVigencia") %> </td>
                                             <td> <%# Eval("FinVigencia") %> </td>
                                             <td> <asp:ImageButton ID="btnseleccionarRegistrosBusquedaClienteNuevo" runat="server" ToolTip="Seleccionar Registro" CssClass="BotonImagen" OnClick="btnseleccionarRegistrosBusquedaClienteNuevo_Click" ImageUrl="~/Imagenes/Seleccionar2.png" /> </td>
                                         </tr>
                                     </ItemTemplate>
                                 </asp:Repeater>
                             </tbody>
                         </table>
            
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
                    <td> <asp:ImageButton ID="btnPrimeraPaginaCliente" runat="server" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaCliente_Click" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorCliente" runat="server" CssClass="BotonImagen" ToolTip="Ir a la Pagina Anterior" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnAnteriorCliente_Click" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionCliente" runat="server" OnItemCommand="dtPaginacionCliente_ItemCommand" OnItemDataBound="dtPaginacionCliente_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralClientes" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteCliente" runat="server" CssClass="BotonImagen" ToolTip="Ir a la Pagina Siguiente" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguienteCliente_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoCliente" runat="server" CssClass="BotonImagen" ToolTip="Ir a la Ultima Pagina" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimoCliente_Click" /> </td>

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
               <div class="row">
                   <div class="col-md-4">
                       <asp:Label ID="lbNombreDetalleCliente" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtNombreDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbRNCDetalleCliente" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtENCDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbRamoDetalleCliente" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtRamoDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbNombreVendedorDetalleCliente" runat="server" Text="Vendedor" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtNombreVendedorDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbRNCVendedorDetalleCliente" runat="server" Text="RNC Vendedor" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtRNCVendedorDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbLicenciaVenedirDetalleCliente" runat="server" Text="Licencia" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtLicenciaDetalleVendedor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbTipoVehiculoDetalleCliente" runat="server" Text="Tipo de Vehiculo" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txttipoVehiculoDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbMarcaDetalleCliente" runat="server" Text="Marca" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtMarcaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbModeloDetalleCliente" runat="server" Text="Modelo" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtModeloDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbAnoDetalleCliente" runat="server" Text="Año" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtAnoDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbPlacaDetalleCliente" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtPalcaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbChasisDetalleCliente" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtCiasusDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbCOlorDetalleCliente" runat="server" Text="Color" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtColorDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbMontoAseguradoDetalleCliente" runat="server" Text="Monto Asegurado" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtMontoAseguradoDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbPrimaDetalleCliente" runat="server" Text="Prima" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtPrimaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbInicioVigenciaDetalleCliente" runat="server" Text="Inicio de vigencia" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtInicioVigenciaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
                       <asp:Label ID="lbFinVigenciaDetalleCliente" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtFinVigenciaDetalleCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                   </div>
                   <div class="col-md-4">
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
       <button class="btn btn-outline-dark btn-sm BotonEspecoal" type="button" id="btnInformacionIntermediarioSupervisor" data-toggle="collapse" data-target="#InformacionIntermediarioSupervisor" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE INTERMEDIARIO / SUPERVISOR
                     </button><br />
       <div class="collapse" id="InformacionIntermediarioSupervisor">
                <div class="card card-body">
                  <asp:UpdatePanel ID="UpdatePanelIntermediario" runat="server">
                      <ContentTemplate>
          
                      <table class="table table-striped">
                          <thead>
                              <tr>
                                 
                                  <th scope="col"> Nombre </th>
                                  <th scope="col"> Estatus </th>
                                  <th scope="col"> RNC </th>
                                  <th scope="col"> Fecha de Entrada </th>
                                  <th scope="col"> Licencia Seguro </th>
                                  <th scope="col"> Oficina </th>
                                   <th scope="col"> Seleccionar </th>
                              </tr>
                          </thead>
                          <tbody>
                              <asp:Repeater ID="rpListadoIntermediarios" runat="server">
                                  <ItemTemplate>
                                      <tr>
                                          <asp:HiddenField ID="hfCodigointermediario" runat="server" Value='<%# Eval("Codigo") %>' />
                                          <td> <%# Eval("Nombre") %> </td>
                                          <td> <%# Eval("Estatus") %> </td>
                                          <td> <%# Eval("Rnc") %> </td>
                                          <td> <%# Eval("FechaEntrada") %> </td>
                                          <td> <%# Eval("LicenciaSeguro") %> </td>
                                          <td> <%# Eval("NombreOficina") %> </td>
                                          <td> <asp:ImageButton ID="btnseleccionarIntermediarioSupervisorNuevo" runat="server" CssClass="BotonImagen" ToolTip="Seleccionar Registro" ImageUrl="~/Imagenes/Seleccionar2.png" OnClick="btnseleccionarIntermediarioSupervisorNuevo_Click" /> </td>
                                      </tr>
                                  </ItemTemplate>
                              </asp:Repeater>
                          </tbody>
                      </table>
           
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
                    <td> <asp:ImageButton ID="btnPrimeroIntermediario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeroIntermediario_Click" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorIntermediario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnAnteriorIntermediario_Click" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtIntermediario" runat="server" OnItemCommand="dtIntermediario_ItemCommand" OnItemDataBound="dtIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralIntermediario" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteIntermediario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguienteIntermediario_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoIntermediario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimoIntermediario_Click" /> </td>
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
           <div class="row">
               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioCodigoDetalle" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioCodigoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioTipoRNCDetalle" runat="server" Text="Tipo de Identificación" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioTipoRNCDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioNumeroIdentificacionDetalle" runat="server" Text="Numero de Identificación" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioNumeroIdentificacionDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioNombreDetalle" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioNombreDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioSupervisorDetalle" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioSupervisorDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioFechaEntradaDetalle" runat="server" Text="Fecha de Entrada" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioFechaEntradaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioTelefonoResidenciaDetalle" runat="server" Text="Telefono de Residencia" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioTelefonoResidenciaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioTelefonoOficina" runat="server" Text="Telefono de oficina" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioTelefonoOficinaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioCelularDetalle" runat="server" Text="Celular" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioCelularDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioLicenciaSeguroDetalle" runat="server" Text="Licencia de Seguro" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioLicenciaSeguroDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioOficinaDetalle" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioOficinaDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioFechaNacimientoDetalle" runat="server" Text="Fecha de nacimiento" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioFechaNacimientoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioCuentaBancoDetalle" runat="server" Text="Cuenta de Banco" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioCuentaBancoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
                   <asp:Label ID="lbBusquedaIntermediarioBancoDetalle" runat="server" Text="Banco" CssClass="Letranegrita"></asp:Label>
                   <asp:TextBox ID="txtBusquedaIntermediarioBancoDetalle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
               </div>

               <div class="col-md-4">
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
       <button class="btn btn-outline-dark btn-sm BotonEspecoal" type="button" id="btnInformacionproveedor" data-toggle="collapse" data-target="#InformacionProveedor" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE PROVEEDOR
                     </button><br />
       <div class="collapse" id="InformacionProveedor">
                <div class="card card-body">
                 <asp:UpdatePanel ID="UpdatePanelProveedores" runat="server">
                     <ContentTemplate>
                       <table class="table table-striped">
                           <thead>
                               <tr>
                               
                               <th scope="col"> Nombre </th>
                               <th scope="col"> RNC </th>
                               <th scope="col"> Tipo de Proveedor </th>
                               <th scope="col"> Tipo de RNC </th>
                               <th scope="col"> Fecha Creado </th>
                               <th scope="col"> Seleccionar </th>
                           </tr>
                           </thead>
                           <tbody>
                               <asp:Repeater ID="rpListadoProveedores" runat="server">
                                   <ItemTemplate>
                                       <tr>
                                           <asp:HiddenField ID="hfCodigoproveedor" runat="server" Value='<%# Eval("Codigo") %>' />
                                           <td> <%# Eval("NombreCliente") %> </td>
                                           <td> <%# Eval("Rnc") %> </td>
                                           <td> <%# Eval("TipoCliente") %> </td>
                                           <td> <%# Eval("TipoIdentificacion") %> </td>
                                           <td> <%# Eval("FechaCreado") %> </td>
                                           <td> <asp:ImageButton ID="btnSeleccionarregistroProveedorNuevo" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Seleccionar2.png" OnClick="btnSeleccionarregistroProveedorNuevo_Click" ToolTip="Seleccionar Registro" /> </td>
                                       </tr>
                                   </ItemTemplate>
                               </asp:Repeater>
                           </tbody>
                       </table>


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
                    <td> <asp:ImageButton ID="btnPrimeroProveedor" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" ToolTip="Ir a la Primera Pagina" OnClick="btnPrimeroProveedor_Click" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorProveedor" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" ToolTip="Ir a la Pagina Anterior" OnClick="btnAnteriorProveedor_Click" /> </td>

                    <td align="center" >
                        <asp:DataList ID="dtProveedor" runat="server" OnItemCommand="dtProveedor_ItemCommand" OnItemDataBound="dtProveedor_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionProveedores" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteProveedor" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" ToolTip="Ir a la Siguiente Pagina" OnClick="btnSiguienteProveedor_Click" /> </td>
                    <td> <asp:ImageButton ID="AnteriorUltimoProveedor" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" ToolTip="Ir a la Ultima Pagina" OnClick="AnteriorUltimoProveedor_Click" /> </td>
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
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorCodigo" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCodigo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorTipoProveedor" runat="server" Text="Tipo de Proveedor" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTipoProveedor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorNombre" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorTipoRNC" runat="server" Text="Tipo de RNC" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTipoRNC" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorRNC" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorRNC" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedrFechaCreado" runat="server" Text="Fecha Creado" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorFechaCreado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorTelefonoCasa" runat="server" Text="Telefono" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTelefonoCasa" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorTelefonoOficina" runat="server" Text="Telefono de Oficina" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTelefonoOficina" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProvedorCelular" runat="server" Text="Celular" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCelular" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorCuentaBanco" runat="server" Text="Cuenta de Banco" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCuentaBanco" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorBAnco" runat="server" Text="Banco" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorBanco" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorTipoCuentaBAnco" runat="server" Text="Tipo de Cuenta" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProbeedorTipoCuentaBAnco" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorClaseProveedor" runat="server" Text="Clase de Proveedor" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorClaseProveedor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorFechaUltimoPago" runat="server" Text="Ultimo Pago" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorFechaUltimoPago" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorLimiteCredito" runat="server" Text="Limite de Credito" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorLimiteCredito" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-12">
                                <asp:Label ID="lbDetalleProveedorDireccion" runat="server" Text="Dirección" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorDireccion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorTotalPagado" runat="server" Text="Total Pagado" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorTotalPagado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProvvedorCantidadSolicitud" runat="server" Text="Cantidad de Solicitud Emitidas" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCantidadSolicitud" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorCantidadSolicitudCanceladas" runat="server" Text="Cantidad de Solicitud Canceladas" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorCantidadSolicitudCanceadas" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorUltimaFechaSolicitud" runat="server" Text="Ultima Fecha de Solicitud" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorUltimaFechaSOlicitud" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedrNumeroSolicitud" runat="server" Text="Numero de Solicitud" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorNumeroSolicitud" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorDescripcionTipoSolicitud" runat="server" Text="Descripcion de Tipo de Solicitud" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorDescripcionTipoSolciitid" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleproveedrValor" runat="server" Text="Valor" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorValor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleproveedorNumeroCheque" runat="server" Text="Numero de Cheque" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorNumeroCheque" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorFechaCheque" runat="server" Text="Fecha de Cheque" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorFechaCheque" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lbDetalleProveedorUsuario" runat="server" Text="Usuario" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleproveedorUsuario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-4">

                            </div>

                            <div class="col-md-4">

                            </div>

                            <div class="col-md-12">
                                <asp:Label ID="lbDetalleProveedorConcepto1" runat="server" Text="Concepto 1" CssClass="Letranegrita"></asp:Label>
                                <asp:TextBox id="txtDetalleProveedorConcepto1" runat="server" TextMode="MultiLine" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-12">
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
       <button class="btn btn-outline-dark btn-sm BotonEspecoal" type="button" id="btnAseguradoBajoPoliza" data-toggle="collapse" data-target="#InformacionAsegurdoBajoPoliza" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE ASEGURADO BAJO POLIZA
                     </button><br />
       <div class="collapse" id="InformacionAsegurdoBajoPoliza">
                <div class="card card-body">
                 <asp:UpdatePanel ID="UpdatePanelAsegurado" runat="server">
                     <ContentTemplate>

                       <table class="table table-striped">
                           <thead>
                               <tr>
                                   <th scope="col"> Nombre </th>
                                   <th scope="col"> Poliza </th>
                                   <th scope="col"> Estatus </th>
                                   <th scope="col"> Item </th>
                                   <th scope="col"> Inicio de Vigencia </th>
                                   <th scope="col"> Fin de Vigencia </th>
                                   <th scope="col"> Seleccionar </th>
                               </tr>
                           </thead>
                           <tbody>
                               <asp:Repeater ID="rpListadoRegistrosasegurado" runat="server">
                                   <ItemTemplate>
                                       <tr>
                                           <asp:HiddenField ID="hfPolizaInformacionAsegurado" runat="server" Value='<%# Eval("Poliza") %>' />
                                           <asp:HiddenField ID="hfCotizacionInformacionAsegurado" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                           <asp:HiddenField ID="hfSecuenciaInformacionAsegurado" runat="server" Value='<%# Eval("Item") %>' />

                                           <td> <%# Eval("Nombre") %> </td>
                                           <td> <%# Eval("Poliza") %> </td>
                                           <td> <%# Eval("Estatus") %> </td>
                                           <td> <%# Eval("Item") %> </td>
                                           <td> <%# Eval("InicioVigencia") %> </td>
                                           <td> <%# Eval("FinVigencia") %> </td>
                                           <td> <asp:ImageButton ID="btnSeleccionarregistrosInformacionAseguradoBajoPoliza" runat="server" ToolTip="Seleccionar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Seleccionar2.png" OnClick="btnSeleccionarregistrosInformacionAseguradoBajoPoliza_Click" /> </td>
                                       </tr>
                                   </ItemTemplate>
                               </asp:Repeater>
                           </tbody>
                       </table>
               

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
                    <td> <asp:ImageButton ID="btnPrimeraPaginaAseguradoBajoPoliza" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" OnClick="btnPrimeraPaginaAseguradoBajoPoliza_Click" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnteriorAseguradoBajoPoliza" runat="server" ImageUrl="~/Imagenes/Anterior.png" CssClass="BotonImagen" ToolTip="Ir a la Pagina Anterior" OnClick="btnPaginaAnteriorAseguradoBajoPoliza_Click" /> </td>
                    <td align="center">
                        <asp:DataList ID="dtAsegurado" runat="server" OnItemCommand="dtAsegurado_ItemCommand" OnItemDataBound="dtAsegurado_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralAseguradoBajoPoliza" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePaginaAseguradoBajoPoliza" runat="server" ImageUrl="~/Imagenes/Siguiente.png" CssClass="BotonImagen" ToolTip="Ir a la Siguiente Pagina" OnClick="btnSiguientePaginaAseguradoBajoPoliza_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPaginaAseguradoBajoPoliza" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" CssClass="BotonImagen" ToolTip="Ir a la Ultima Pagina" OnClick="btnUltimaPaginaAseguradoBajoPoliza_Click" /> </td>
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
                             <div class="row">
                                 <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>

                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoEstatus" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoEstatus" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoitem" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoitem" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoInicioVigencia" runat="server" Text="Inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoInicioVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoFinVigencia" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoFinVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoIntermediario" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoRNCIntermediario" runat="server" Text="RNC Intermediario" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoRNCIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoLicenciaIntermediario" runat="server" Text="Licencia Intermediario" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoLicenciaIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoprima" runat="server" Text="Prima" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoPrima" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoMontoAsegurado" runat="server" Text="Monto Asegurado" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoMontoasegurado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoTipoVehiculo" runat="server" Text="Tipo de Vehiculo" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoTipoVehiculo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoMarca" runat="server" Text="Marca" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoMarca" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoModelo" runat="server" Text="Modelo" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoModelo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoChasis" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoChasis" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoPlaca" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoPlaca" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
                                     <asp:Label ID="lbDetalleAseguradoAno" runat="server" Text="Año" CssClass="Letranegrita"></asp:Label>
                                     <asp:TextBox ID="txtDetalleaseguradoAno" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                 </div>
                                  <div class="col-md-4">
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
       <button class="btn btn-outline-dark btn-sm BotonEspecoal" type="button" id="btnInformacionAsegurado" data-toggle="collapse" data-target="#InformacionAsegurado" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE ASEGURADO 
                     </button><br />
       <div class="collapse" id="InformacionAsegurado">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelAseguradoGeneral" runat="server">
                       <ContentTemplate>
                               <table class="table table-striped">
                                   <thead>
                                       <tr>
                                           
                                           <th scope="col"> Nombre </th>
                                           <th scope="col"> RNC </th>
                                           <th scope="col"> Poliza </th>
                                           <th scope="col"> Item </th>
                                           <th scope="col"> Numero </th>
                                           <th scope="col"> Estatus </th>
                                           <th scope="col"> Inicio </th>
                                           <th scope="col"> Fin </th>
                                           <th scope="col"> Seleccionar </th>
                                       </tr>
                                   </thead>
                                   <tbody>
                                       <asp:Repeater ID="rpIDListadoAseguradoGeneral" runat="server">
                                           <ItemTemplate>
                                               <tr>
                                                   <asp:HiddenField ID="hfCotizacionAseguradoGeneral" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                                   <asp:HiddenField ID="hfItemAseguradoGeneral" runat="server" Value='<%# Eval("Secuencia") %>' />
                                                   <asp:HiddenField ID="hfIdAseguradoAseguradoGeneral" runat="server" Value='<%# Eval("IdAsegurado") %>' />

                                                   <td> <%# Eval("Nombre") %> </td>
                                                   <td> <%# Eval("RNC") %> </td>
                                                   <td> <%# Eval("Poliza") %> </td>
                                                   <td> <%# Eval("Secuencia") %> </td>
                                                   <td> <%# Eval("IdAsegurado") %> </td>
                                                   <td> <%# Eval("Estatus") %> </td>
                                                   <td> <%# Eval("InicioVigencia") %> </td>
                                                   <td> <%# Eval("FinVigencia") %> </td>
                                                   <td> <asp:ImageButton ID="btnSeleccionarRegistroAseguradoGeneralNuevo" runat="server" ToolTip="Seleccionar Registro" OnClick="btnSeleccionarRegistroAseguradoGeneralNuevo_Click" ImageUrl="~/Imagenes/Seleccionar2.png" CssClass="BotonImagen" /> </td>
                                               </tr>
                                           </ItemTemplate>
                                       </asp:Repeater>
                                   </tbody>
                               </table>
                        

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
                    <td> <asp:ImageButton ID="btnPrimeroAseguradoGeneral" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" ToolTip="Ir a la Primera Pagina" OnClick="btnPrimeroAseguradoGeneral_Click" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorAseguradoGeneral" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" ToolTip="Ir a la Primera Anterior" OnClick="btnAnteriorAseguradoGeneral_Click" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtAseguradoGeneral" runat="server" OnItemCommand="dtAseguradoGeneral_ItemCommand" OnItemDataBound="dtAseguradoGeneral_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralAseguradoGeneral" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteAseguradoGeneral" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" ToolTip="Ir a la Primera Siguiente" OnClick="btnSiguienteAseguradoGeneral_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoAseguradoGeneral" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" ToolTip="Ir a la Primera Siguiente" OnClick="btnUltimoAseguradoGeneral_Click" /> </td>
                </tr>
            </table>
        </div>
        </div>

                           <div id="DivDetalleAseguradoGeneral" runat="server">
                               <hr />
                               <div align="center">
                                   <asp:Label ID="lbTituloDetalleAseguradoGeneral" runat="server" Text="Detalle del Registro Seleccionado" CssClass="Letranegrita"></asp:Label>
                               </div>

                               <div class="row">
                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralEstatus" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralEstatus" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralCotizacion" runat="server" Text="Cotización" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralCotizacion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralSecuencia" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralSecuencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralIdAsegurado" runat="server" Text="Numero de Asegurado" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralIdAsegurado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralParentezco" runat="server" Text="Parentezco" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralParentezco" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralRNC" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralRNC" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralFechaNacimiento" runat="server" Text="Fecha de Nacimiento" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralFechaNacimiento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralSexo" runat="server" Text="Sexo" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralSexo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleAseguradoGeneralInicioVigencia" runat="server" Text="Inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleAseguradoGeneralInicioVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
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
       <button class="btn btn-outline-dark btn-sm BotonEspecoal" type="button" id="btnInformacionDependiente" data-toggle="collapse" data-target="#InformacionDependiente" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE DEPENDIENTES 
                     </button><br />
       <div class="collapse" id="InformacionDependiente">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelDependiente" runat="server">
                       <ContentTemplate>
      
                               <table class="table table-striped">
                                   <thead>
                                       <tr>
                                           
                                           <th scope="col" >  Nombre </th>
                                           <th scope="col" >  RNC </th>
                                           <th scope="col" >  Poliza </th>
                                           <th scope="col" >  Item </th>
                                           <th scope="col" >  No. </th>
                                           <th scope="col" >  Estatus </th>
                                           <th scope="col" >  Inicio </th>
                                           <th scope="col" >  Fin </th>
                                           <th scope="col"> Seleccionar </th>
                                       </tr>
                                   </thead>
                                   <tbody>
                              
                                          <asp:Repeater ID="rpListadoDependientes" runat="server">
                                              <ItemTemplate>
                                                 <tr>
                                                   <asp:HiddenField ID="hfCotizacionDependiente" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                                   <asp:HiddenField ID="hfSecuenciaDependiente" runat="server" Value='<%# Eval("Secuencia") %>' />
                                                   <asp:HiddenField ID="hfIdAseguradoDependiente" runat="server" Value='<%# Eval("IdAsegurado") %>' />

                                                      <td> <%# Eval("Nombre") %> </td>
                                                      <td> <%# Eval("RNC") %> </td>
                                                      <td> <%# Eval("Poliza") %> </td>
                                                      <td> <%# Eval("Secuencia") %> </td>
                                                      <td> <%# Eval("IdAsegurado") %> </td>
                                                      <td> <%# Eval("Estatus") %> </td>
                                                      <td> <%# Eval("InicioVigencia") %> </td>
                                                      <td> <%# Eval("FinVigencia") %> </td>
                                                     <td> <asp:ImageButton ID="btnSeleccionarRegistroDependienteNuevo" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Seleccionar2.png" OnClick="btnSeleccionarRegistroDependienteNuevo_Click" ToolTip="Seleccionar Registro" /> </td>
                                                 </tr>


                                              </ItemTemplate>
                                          </asp:Repeater>
                                     
                                   </tbody>
                               </table>
           

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
                    <td> <asp:ImageButton ID="btnPrimeroDependiente" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeroDependiente_Click" ToolTip="Ir a la Primera Pagina" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorDependiente" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnAnteriorDependiente_Click" ToolTip="Ir a la Pagina Anterior" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtDependiente" runat="server" OnItemCommand="dtDependiente_ItemCommand" OnItemDataBound="dtDependiente_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralDependiente" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteDependiente" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguienteDependiente_Click" ToolTip="Ir a la Pagina Anterior" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoDependiente" runat="server" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimoDependiente_Click" ToolTip="Ir a la Ultima Pagina" /> </td>
                </tr>
            </table>
        </div>
        </div>

                           <div id="DivDetalleDependientes" runat="server">
                               <hr />
                               <div align="center">
                                   <asp:Label ID="lbTituloDetalleDependiente" runat="server" Text="Detalle del Registro Seleccionado" CssClass="Letranegrita"></asp:Label>
                               </div>
                               <div class="row">
                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependientePoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependientePoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                    <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteEstatus" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteEstatus" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteCotizacion" runat="server" Text="Cotización" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteCotizacion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteRNC" runat="server" Text="RNC" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteRNC" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteIdAsegurado" runat="server" Text="Id Asegurado" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteIdAsegurado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteParentezco" runat="server" Text="Parentezco" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteParentezco" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteFechaNacimiento" runat="server" Text="Fecha de Nacimiento" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteFechaNacimiento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteSexo" runat="server" Text="Sexo" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteSexo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteSecuencia" runat="server" Text="Secuencia" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteSecuencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
                                       <asp:Label ID="lbDetalleDependienteinicio" runat="server" Text="inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtDetalleDependienteinicio" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                   <div class="col-md-4">
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

                   <asp:Label ID="lbLetreroBusquedaArchivoBusquedaPorLote" runat="server" Text="Tipo de Busqueda: " CssClass="Letranegrita"></asp:Label><br />
                   <asp:RadioButton ID="rbTodosLosParametros" runat="server" Text="Todos" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar por Todos los Parametros" />
                   <asp:RadioButton ID="rbPorNombreBusquedaPorLote" runat="server" Text="Nombre" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar mediante el nombre de la persona" />
                   <asp:RadioButton ID="rbNumeroIdentificacionBusquedaPorLote" runat="server" Text="Numero de Identificación" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar mediante el Numero de Identificación de la persona" />
                   <asp:RadioButton ID="rbChasisBusquedaPorLote" runat="server" Text="Chasis" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar mediante el Numero de Chasis" />
                   <asp:RadioButton ID="rbPlacaBusquedaPorLote" runat="server" Text="Placa" CssClass="form-check-input" GroupName="BusqudaArchivo" ToolTip="Buscar mediante el Numero de Placa" />
               </div>
    
           <br />
           <div class="form-check-inline">

                   <asp:Label ID="lbLetreroBuscarEn" runat="server" Text="Buscar Como" CssClass="Letranegrita"></asp:Label><br />
                   <asp:CheckBox ID="cbTodos" runat="server" AutoPostBack="true" OnCheckedChanged="cbTodos_CheckedChanged" Text="Todos" CssClass="form-check-input" ToolTip="Buscar en Todos los Registros" />
                   <asp:CheckBox ID="cbCliente" runat="server" AutoPostBack="true" OnCheckedChanged="cbCliente_CheckedChanged" Text="Cliente" CssClass="form-check-input" ToolTip="Buscar informacion en la data de los clientes registrados" />
                   <asp:CheckBox ID="cbIntermediario" runat="server" AutoPostBack="true" OnCheckedChanged="cbIntermediario_CheckedChanged" Text="Intermediario" CssClass="form-check-input" ToolTip="Buscar en la Data de los Intermediarios y Supervisores" />
                   <asp:CheckBox ID="cbProvedor" runat="server" AutoPostBack="true" OnCheckedChanged="cbProvedor_CheckedChanged" Text="Proveedor" CssClass="form-check-input" ToolTip="Buscar en la Data de los Proveedores" />
                   <asp:CheckBox ID="cbAseguradoBajoPoliza" runat="server" AutoPostBack="true" OnCheckedChanged="cbAseguradoBajoPoliza_CheckedChanged" Text="Asegurado P" CssClass="form-check-input" ToolTip="Buscar en la Data de los Asegurados Bajo Polizas" />
                   <asp:CheckBox ID="cbAsegurado" runat="server" AutoPostBack="true" OnCheckedChanged="cbAsegurado_CheckedChanged" Text="Asegurado" CssClass="form-check-input" ToolTip="Buscar en la Data de los Asegurados" />
                   <asp:CheckBox ID="cbDependiente" runat="server" AutoPostBack="true" OnCheckedChanged="cbDependiente_CheckedChanged" Text="Dependiente" CssClass="form-check-input" ToolTip="Buscar en la Data de los Dependientes" /><br />
                   <asp:CheckBox ID="cbCheque" runat="server" AutoPostBack="true" OnCheckedChanged="cbCheque_CheckedChanged" Text="Cheque" CssClass="form-check-input" ToolTip="Buscar en la Data de las Solicitudes y Cheques" />
                   <asp:CheckBox ID="cbDocumentosAmigos" runat="server" AutoPostBack="true" OnCheckedChanged="cbDocumentosAmigos_CheckedChanged" Text="Documentos Amigos" CssClass="form-check-input" ToolTip="Buscar en la Data de los Documentos Amigos" />
                   <asp:CheckBox ID="cbReclamaciones" runat="server" AutoPostBack="true" OnCheckedChanged="cbReclamaciones_CheckedChanged" Text="Reclamos" CssClass="form-check-input" ToolTip="Buscar en los reclamos" />
                   <asp:CheckBox ID="cbPlaca" runat="server" AutoPostBack="true" OnCheckedChanged="cbPlaca_CheckedChanged" Text="Placa" CssClass="form-check-input" ToolTip="Buscar Por Placa" />
                   <asp:CheckBox ID="cbChasis" runat="server" AutoPostBack="true" OnCheckedChanged="cbChasis_CheckedChanged" Text="CHasis" CssClass="form-check-input" ToolTip="Buscar Por Chasis" />

               </div>

           <br />
             <div class="form-check-inline">
         
               <asp:RadioButton ID="rbHojaExcelPlano" runat="server" Text="Excel Plano" CssClass="form-check-input Letranegrita" GroupName="Exportar" ToolTip="Exportar Informacion a Excel Plano" />
               <asp:RadioButton ID="rbExportarPDF" runat="server" Text="Exportar a PDF" CssClass="form-check-input Letranegrita" GroupName="Exportar" ToolTip="Exportar Informacion a PDF" />
               <asp:RadioButton ID="rbExcel" runat="server" Text="Exportar a Excel" CssClass="form-check-input Letranegrita" GroupName="Exportar" ToolTip="Exportar Informacion a Excel" />
               <asp:RadioButton ID="rbExportarWord" runat="server" Text="Exportar a Word" CssClass="form-check-input Letranegrita" GroupName="Exportar" ToolTip="Exportar Informacion a Word" />
               <br />
                
           </div>
           
      

           <div align="center">
               <asp:Label ID="lbCantidadRegistrosProcesadosTitulo" runat="server" Text="Cantidad de Registros Cargados ( " CssClass="Letranegrita"></asp:Label>
               <asp:Label ID="lbCantidadRegistrosProcesadosVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
               <asp:Label ID="lbCantidadRegistrosProcesadosCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
           </div>
       
               <table class="table table-striped">
                   <thead>
                       <tr>
                            <th scope="col"> Nombre </th>
                            <th scope="col"> Identificación </th>
                            <th scope="col"> Chasis </th>
                            <th scope="col"> Placa </th>
                       </tr>
                   </thead>

                   <tbody>
                       <asp:Repeater ID="rpRegistrosCargadoArchivo" runat="server">
                           <ItemTemplate>
                               <tr>
                                    <td> <%# Eval("Nombre") %> </td>
                                    <td> <%# Eval("NumeroIdentificacion") %> </td>
                                    <td> <%# Eval("Chasis") %> </td>
                                    <td> <%# Eval("Placa") %> </td>
                               </tr>
                           </ItemTemplate>
                       </asp:Repeater>
                   </tbody>

                   
               </table>
    

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
                    <td> <asp:ImageButton ID="btnPrimeroarchivo" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" CssClass="BotonImagen" OnClick="btnPrimeroarchivo_Click" ToolTip="Ir a la Primera Pagina" /> </td>
                     <td> <asp:ImageButton ID="btnAnteriorArchivo" runat="server" ImageUrl="~/Imagenes/Anterior.png" CssClass="BotonImagen" OnClick="btnAnteriorArchivo_Click" ToolTip="Ir a la Pagina Anterior" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtArchivo" runat="server" OnItemCommand="dtArchivo_ItemCommand" OnItemDataBound="dtArchivo_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionArchivo" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                     <td> <asp:ImageButton ID="btnSiguienteArchivo" runat="server" ImageUrl="~/Imagenes/Siguiente.png" CssClass="BotonImagen" OnClick="btnSiguienteArchivo_Click" ToolTip="Ir a la Primera Siguiente" /> </td>
                     <td> <asp:ImageButton ID="btnUltimoArchivo" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" CssClass="BotonImagen" OnClick="btnUltimoArchivo_Click" ToolTip="Ir a la Ultima Primera" /> </td>
                </tr>
            </table>
        </div>
        </div>
           <br />
       </div>
  </div>
</asp:Content>

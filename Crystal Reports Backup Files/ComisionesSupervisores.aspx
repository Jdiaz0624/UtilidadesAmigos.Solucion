<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ComisionesSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ComisionesSupervisores" %>
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
            .BotonImagen {
            
                width:50px;
                height:50px;
            }
    </style>

    <script type="text/javascript">
        function CamposFechasVacios() {
            alert("Los campos fechas no pueden estar vacios para realizar esta operación, favor de verificar.");
        }
        function CampoFechaDesdeVacio() {
            $("#<%=txtFechaDesdeConsulta.ClientID%>").css("border-color", "red");
        }

        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHastaConsulta.ClientID%>").css("border-color", "red");
        }

        function ClaveSeguridadVacioaBuscarCodigo() {
            $("#<%=txtClaveSeguridadBuscarCodigo.ClientID%>").css("border-color", "red");
        }


        $(document).ready(function () {
            $("#<%=btnEliminarSupervisorAgregado.ClientID%>").click(function () {
                var ClaveSeguridad = $("#<%=txtClaveSeguridadControlesPermitidos.ClientID%>").val().length;

                if (ClaveSeguridad < 1) {
                    $("#<%=txtClaveSeguridadControlesPermitidos.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

        })
    </script>
    <div class="container-fluid">
        <br /><br />

        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbFechaHastaConsulta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbCodigoSupervisorConsulta" runat="server" Text="Codigo de Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisorConsulta" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisorConsulta_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbNombreSupervisorConsulta" runat="server" Text="Nombre de Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisorConsulta" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbSeleccionarSucursalConsulta" runat="server" Text="Sucursal" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursalConsulta_SelectedIndexChanged" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbSeleccionarOficinaConsulta" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficinaConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="form-check-inline">
     
                <asp:Label ID="lbGenerarReporteA" runat="server" Text="Generar Reporte A: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbGenerarReportePDF" runat="server" CssClass="form-check-input" Text="PDF" ToolTip="Generar Reporte a PDF" GroupName="Reporte" />
                <asp:RadioButton ID="rbGenerarReporteExcel" runat="server" CssClass="form-check-input" Text="Excel" ToolTip="Generar Reporte a Excel" GroupName="Reporte" />
                <asp:RadioButton ID="rbGenerarReporteWord" runat="server" CssClass="form-check-input" Text="Word" ToolTip="Generar Reporte a Word" GroupName="Reporte" /><br />
                <asp:Label ID="lbTipoReporteGenerar" runat="server" Text="Tipo de Reporte: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Resumido" CssClass="form-check-input" GroupName="TipoReporteGenerar" ToolTip="Generar el reporte resumido" />
                <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Detalle" CssClass="form-check-input" GroupName="TipoReporteGenerar" ToolTip="Generar el reporte detallado" />
         
        </div>

        <div align="center">
       

            <asp:ImageButton ID="btnConsultarNuevo" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" OnClick="btnConsultarNuevo_Click" ImageUrl="~/Imagenes/Buscar.png" />
            <asp:ImageButton ID="btnExportarNuevo" runat="server" ToolTip="Exportar Información a Excel" CssClass="BotonImagen" OnClick="btnExportarNuevo_Click" ImageUrl="~/Imagenes/excel.png" />
            <asp:ImageButton ID="btnReporteNuevo" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" OnClick="btnReporteNuevo_Click" ImageUrl="~/Imagenes/Reporte.png" />
            <br />
            <button type="button" id="btnCodigosPermitidos" class="btn btn-outline-secondary btn-sm Custom" data-toggle="modal" data-target=".CodigosPermitidos">Codigos</button>
            <br />
            <asp:Label ID="lbCantidadRegistrosEncontradosTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosEncontradosVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosEncontradosCerrar" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>

             <asp:Label ID="lbCobradoBrutoTitulo" runat="server" Text="Cobrado Bruto ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCobradBrutoVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCobradoBrutoCerrer" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>

             <asp:Label ID="lbCobradoNetoTitulo" runat="server" Text="Cobrado Neto ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCobradoNetoVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCobradoNetoCerrar" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>
        </div>
        <br />


           <table class="table table-striped">
               <thead>
                   <tr>
                   <th scope="col">Supervisor</th>
                   <th sscope="col">Recibo</th>
                   <th sscope="col">Fecha</th>
                   <th sscope="col">Neto</th>
                   <th sscope="col">Concepto</th>
                   <th sscope="col">%</th>
                   <th sscope="col">A Pagar</th>
               </tr>
               </thead>
               <tbody>
                   <asp:Repeater ID="rpListadoComisionesSupervisores" runat="server">
                       <ItemTemplate>
                           <tr>
                               <td> <%# Eval("NombreSupervisor") %> </td>
                               <td> <%# Eval("ReciboFormateado") %> </td>
                               <td> <%# Eval("FechaPagoFormateado") %> </td>                               
                               <td> <%#string.Format("{0:n2}", Eval("Neto")) %> </td>
                               <td> <%# Eval("ConceptoFactura") %> </td>
                               <td> <%#string.Format("{0:n2}", Eval("PorcientoComisionIntermediario")) %> </td>
                               <td> <%#string.Format("{0:n2}", Eval("ComisionPagar")) %> </td>
                           </tr>
                       </ItemTemplate>
                   </asp:Repeater>
               </tbody>
           </table>


        <div align="center">
                <asp:Label ID="lbPaginaActualTituloPrincipal" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavlePrincipal" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloPrincipal" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariablePrincipal" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaPrincipal" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaPrincipal_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorPrincipal" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorPrincipal_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionPrincipal" runat="server" OnItemCommand="dtPaginacionPrincipal_ItemCommand" OnItemDataBound="dtPaginacionPrincipal_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralPrincipal" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguientePrincipal" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguientePrincipal_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoPrincipal" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoPrincipal_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
        <br />
           </div>



             <div class="modal fade bd-example-modal-xl CodigosPermitidos" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
       <div class="container-fluid">
            <div class="jumbotron" align="center">
            <asp:Label ID="lbProcesarCodigos" runat="server" Text="Procesar Codigos" CssClass="Letranegrita"></asp:Label>
        </div>

         <asp:ScriptManager ID="ScripManagerCodigos" runat="server"></asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanelCodigos" runat="server">
               <ContentTemplate>
                     <div class="form-check-inline">

                   <asp:Label ID="lbTipoInformacionMostrar" runat="server" Text="Tipo de Información: " CssClass="Letranegrita"></asp:Label>
                   <asp:RadioButton ID="rbCodigosPermitidos" runat="server" Text="Codigos Permitidos" ToolTip="Mostrar los codigos permitidos para generar comisión" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="rbCodigosPermitidos_CheckedChanged" GroupName="TipoInformacion" />
                   <asp:RadioButton ID="rbBuscarCodigos" runat="server" Text="Buscar Codigos" ToolTip="Buscar Codigos de supervisores para agregar" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="rbBuscarCodigos_CheckedChanged" GroupName="TipoInformacion" />
         
                     
           </div>

                   <div class="row">
                       <div class="col-md-6">
                           <asp:Label ID="lbIdCodigoCodigospermitidos" runat="server" Text="Codigo de Supervisor" CssClass="Letranegrita"></asp:Label>
                           <asp:TextBox ID="txtCodigoCodigospermitidos" runat="server" CssClass="form-control" TextMode="Number" MaxLength="4" AutoCompleteType="Disabled"></asp:TextBox>
                           
                       </div>

                       <div class="col-md-6">
                           <asp:Label ID="lbNombreSupervisorCodigosPermitidos" runat="server" Text="Nombre de Supervisor" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNombreSupervisorPopop" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                       </div>
                   </div>

                   <div align="center">
                       <asp:Button ID="btnBuscarPOPOP" runat="server" Text="Buscar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Buscar Registros" OnClick="btnBuscarPOPOP_Click" />
                       <br />
                       <asp:Label ID="lbCantidadRegistrosTituloPOPOP" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
                       <asp:Label ID="lbCantidadRegistrosVariablePOPOP" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                       <asp:Label ID="lbCantidadRegistrosCerrarPOPOP" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>
                   </div>
                   <br />

                       <div id="DivBloqueCodigosPermitidos" runat="server">
      
                              <table class="table table-striped">
                                  <thead>
                                      <tr>
                                          <th scope="col"> Seleccionar </th>
                                          <th scope="col"> Codigo </th>
                                          <th scope="col"> Nombre </th>
                                          <th scope="col"> Fecha </th>
                                          <th scope="col"> Oficina </th>
                                      </tr>
                                  </thead>
                                  <tbody>
                                      <asp:Repeater ID="rpListadoSupervisoresAgregados" runat="server">
                                          <ItemTemplate>
                                              <tr>
                                                  <asp:HiddenField ID="hfIdRegistroSeleccionado" runat="server" Value='<%# Eval("IdRegistro") %>' />

                                                  <td> <asp:Button ID="btnSeleccionarregistroAgregadoHEaderRpeaterPOPOP" runat="server" Text="Seleccionar" ToolTip="Seleccionar registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarregistroAgregadoHEaderRpeaterPOPOP_Click" /> </td>
                                                  <td> <%# Eval("CodigoSupervisor") %> </td>
                                                  <td> <%# Eval("Nombre") %> </td>
                                                  <td> <%# Eval("FechaAgregado") %> </td>
                                                  <td> <%# Eval("Oficina") %> </td>
                                              </tr>
                                          </ItemTemplate>
                                      </asp:Repeater>
                                  </tbody>
                              </table>
                  

                             <div align="center">
                <asp:Label ID="lbPaginaActualTituloCodigosPermitidos" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleCodigosPermitidos" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloCodigosPermitidos" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableCodigosPermitidos" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionCodigosPermitidos" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaCodigosPermitidos" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaCodigosPermitidos_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorCodigosPermitidos" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorCodigosPermitidos_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionCodigosPermitidos" runat="server" OnItemCommand="dtPaginacionCodigosPermitidos_ItemCommand" OnItemDataBound="dtPaginacionCodigosPermitidos_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralCodigosPermitidos" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteCodigosPermitidos" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteCodigosPermitidos_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoCodigosPermitidos" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoCodigosPermitidos_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />

                           <div id="DivControlesCodigoPermitidos" runat="server">
                               <div class="row">
                                   <asp:Label ID="IdRegistroSeleccionadoCodigoPermitidos" runat="server" Text="IdRegistroSeleccionado" Visible="false"></asp:Label>
                                   <div class="col-md-4">
                                       <asp:Label ID="lbCodigoSupervisorControlesPermitido" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtCodigoSupervisorControlesPermitidos" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                    <div class="col-md-4">
                                       <asp:Label ID="lbNombreSupervisorControlesPermitidos" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtNombreSupervisorControlesPermitidos" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                    <div class="col-md-4">
                                       <asp:Label ID="lbFechaAgregadoCOntrolesPermitidos" runat="server" Text="Fecha Agregado" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtFechaAgregadosControlesPermitidos" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>

                                    <div class="col-md-4">
                                       <asp:Label ID="lboficinaSupervisorControlesPermitidos" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtOficinaSupervisorCOntrolesPermitidos" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                   </div>
                                    <div class="col-md-4">
                                       <asp:Label ID="lbClaveSeguridadControlesPermitifdosd" runat="server" Text="Clave de Seguridad" CssClass="Letranegrita"></asp:Label>
                                       <asp:TextBox ID="txtClaveSeguridadControlesPermitidos" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                   </div>
                               </div>
                               <div align="center">
                                   <asp:Button ID="btnEliminarSupervisorAgregado" runat="server" Text="Eliminar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Eliminar Registro" OnClick="btnEliminarSupervisorAgregado_Click" />
                                   <asp:Button ID="btnVolverAtras" runat="server" Text="Volver" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Volver Atras" OnClick="btnVolverAtras_Click" />
                               </div>
                               <br />
                           </div>

                         </div>


                         <div id="DivBloqueBuscarCodigos" runat="server">

                             <div align="center">
                                 <div class="row">
                                     <div class="col-md-6">
                                         <asp:Label ID="lbClaveSeguridadBuscarCodigo" runat="server" Text="Clave de Seguridad" CssClass="Letranegrita"></asp:Label>
                                         <asp:TextBox ID="txtClaveSeguridadBuscarCodigo" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                     </div>
                                 </div>
                             </div>

                                <table class="table table-striped">
                                   <thead>
                                        <tr>
                                        <th scope="col"> Guardar </th>
                                        <th scope="col"> Codigo </th>
                                        <th scope="col"> Nombre </th>
                                        <th scope="col"> Estatus </th>
                                        <th scope="col"> Oficina </th>
                                    </tr>
                                   </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpListadoSupervisoresBuscar" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <asp:HiddenField ID="hfCodigoSupervisor" runat="server" Value='<%# Eval("Codigo") %>' />
                                                <td> <asp:Button ID="btnGuardarBuscarCodigo" runat="server" Text="Guardar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Guardar Registro" OnClick="btnGuardarBuscarCodigo_Click" /> </td>
                                                <td> <%# Eval("Codigo") %> </td>
                                                <td> <%# Eval("Nombre") %> </td>
                                                <td> <%# Eval("Estatus") %> </td>
                                                <td> <%# Eval("Oficina") %> </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>

                       

                               <div align="center">
                <asp:Label ID="lbPaginaActualTituloBuscarCodigos" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleBuscarCodigos" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloBuscarCodigos" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableBuscarCodigos" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionBuscarCodigos" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaBuscarCodigos" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaBuscarCodigos_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorBuscarCodigos" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorBuscarCodigos_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionBuscarCodigos" runat="server" OnItemCommand="dtPaginacionBuscarCodigos_ItemCommand" OnItemDataBound="dtPaginacionBuscarCodigos_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralBuscarCodigos" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteBuscarCodigos" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteBuscarCodigos_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoBuscarCodigos" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoBuscarCodigos_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
<br />
                         </div>
               </ContentTemplate>
           </asp:UpdatePanel>




       </div>

    </div>
  </div>
</div>
         
</asp:Content>

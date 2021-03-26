<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="DatosPoliza.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.DatosPoliza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style type="text/css">

        .btn-sm{
            width:100px;
        }
           .LetrasNegrita {
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
        function RegistronoEncontrado() {
            alert("No se encontraron registros con el numero de poliza ingresado, favor de verificar.");
        }
        $(document).ready(function () {
            $("#<%=btnConsultarRegistros.ClientID%>").click(function () {
                var ValidarCampoPoliza = $("#<%=txtIngresarPolizaConsulta.ClientID%>").val().length;
                if (ValidarCampoPoliza < 1) {
                    alert("El campo poliza no puede estar vacio, favor de verificar.");
                    $("#<%=txtIngresarPolizaConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

        })
    </script>
    <br /><br />
    <div class="container-fluid">
        <div id="DivBloquePrincipal" runat="server">
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="lbIngresarPolizaConsulta" runat="server" Text="Ingresar Poliza" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtIngresarPolizaConsulta" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                   <div class="form-group col-md-6">
                    <asp:Label ID="lbIngresaNumeroItemConsulta" runat="server" Text="Ingresar Item" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtIngresarItemConsulta" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div align="center">
                <asp:Button ID="btnConsultarRegistros" runat="server" Text="Consultar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultarRegistros_Click" />
                <button type="button" id="btnOtrosFiltros" class="btn btn-outline-secondary btn-sm" data-toggle="modal" data-target=".OtrosFiltros">Otros Filtros</button>

                <br /><br />
                <asp:Label ID="lbCantidadRegistrosBloquePrincipalTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="LetrasNegrita"></asp:Label>
                <asp:Label ID="lbCantidadRegistrosBloquePrincipalVariable" runat="server" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbCantidadRegistrosBloquePrincipalCerrar" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>
            </div>
            <br /><br />
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                             <th style="width:10%" align="left"> Detalle </th>
                             <th style="width:10%" align="left"> Poliza </th>
                             <th style="width:10%" align="left"> Item </th>
                             <th style="width:20%" align="left"> Ramo </th>
                             <th style="width:20%" align="left"> SubRamo </th>
                             <th style="width:30%" align="left"> Cliente </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoPrincipal" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfPolizaListadoPrncipal" runat="server" Value='<%# Eval("Poliza") %>' />
                                     <asp:HiddenField ID="hfNumeroItemPrincipal" runat="server" Value='<%# Eval("Item") %>' />

                                    <td style="width:10%"> <asp:Button ID="btnDetallePrincipal" runat="server" Text="Detalle" ToolTip="Mostrar el Detalle del registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnDetallePrincipal_Click" /> </td>
                                    <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                    <td style="width:10%"> <%# Eval("Item") %> </td>
                                    <td style="width:20%"> <%# Eval("Ramo") %> </td>
                                    <td style="width:20%"> <%# Eval("SubRamo") %> </td>
                                    <td style="width:30%"> <%# Eval("Cliente") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

               <div align="center">
                <asp:Label ID="lbPaginaActualTituloBloquePrincipal" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="LinkBlbPaginaActualVariableBloquePrincipal" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloBloquePrincipal" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableBloquePrincipal" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionDetalleBloquePrincipal" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaBloquePrincipal" runat="server" Text="Inicio" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaBloquePrincipal_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorBloquePrincipal" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorBloquePrincipal_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionBloquePrincipal" runat="server" OnItemCommand="dtPaginacionBloquePrincipal_ItemCommand" OnItemDataBound="dtPaginacionBloquePrincipal_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralBloquePrincipal" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteBloquePrincipal" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteBloquePrincipal_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoBloquePrincipal" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoBloquePrincipal_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <div id="DIVBloqueDecision" visible="false" runat="server">
                <div class="form-check-inline">
                    <div class="form-group form-check">
                        <asp:RadioButton ID="rbDetallePoliza" runat="server" Text="Detalle de Registro" CssClass="form-check-input LetrasNegrita" ToolTip="Mostrar el detalle del Registro seleccionado" GroupName="Decision" AutoPostBack="true" OnCheckedChanged="rbDetallePoliza_CheckedChanged" />
                         <asp:RadioButton ID="rbCoberturasPolizas" runat="server" Text="Cobertura de Registro" CssClass="form-check-input LetrasNegrita" ToolTip="Mostrar las coberturas del registro seleccionado" GroupName="Decision" AutoPostBack="true" OnCheckedChanged="rbCoberturasPolizas_CheckedChanged" />
                    </div>
                </div>
            </div>
            <!--DETALLE DE LA PANTALLA PRINCIPAL-->
            <div id="BloqueControlesPrincipales" visible="false" runat="server">
                <div class="form-check-inline">
                    <div class="form-group form-check">
                        <asp:CheckBox ID="cbModificarValor" runat="server" Text="Modificar Valor" CssClass="form-check-input LetrasNegrita" ToolTip="Modificar el valor del registro" AutoPostBack="true" OnCheckedChanged="cbModificarValor_CheckedChanged" />
                        <asp:CheckBox ID="cbModificarVigencia" runat="server" Text="Modificar Vigencia" CssClass="form-check-input LetrasNegrita" ToolTip="Modificar la vigencia del registro" AutoPostBack="true" OnCheckedChanged="cbModificarVigencia_CheckedChanged" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleRamoPrincipal" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleRamoPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleSubramoPrincipal" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleSubramoPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                     <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleInicioVigencia" runat="server" Text="Inicio Vigencia Actual" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleInicioVigenciaPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                     <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleFinVigenciaPrincipal" runat="server" Text="Fin Vigencia Actual" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleFinVigenciaPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleTipoVehiculoPrincipal" runat="server" Text="Tipo de Vehiculo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleTipoVehiculoPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleMarcaPrincipal" runat="server" Text="Marca" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleMarcaPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleModeloPrincipal" runat="server" Text="Modelo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleModeloPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleColorPrincipal" runat="server" Text="Color" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleColorPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleChasisPrincipal" runat="server" Text="Chasis" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleChasisPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetallePlacaPrincipal" runat="server" Text="Placa" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetallePlacaprincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleValorAseguradoPrincipal" runat="server" Text="Valor Asegurado" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleValorAseguradoPrinncipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleFianzaPrincipal" runat="server" Text="Fianza" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleFianzaPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleAseguradoPrincipal" runat="server" Text="Asegurado" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleAseguradoPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleClientePrincipal" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleClientePrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>


                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetallePrimaActualPrincipal" runat="server" Text="Prima Actual" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetallePrimaActualPrincipal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6" id="DivPrimaNueva" runat="server">
                        <asp:Label ID="lbDetallePrimaNuevaPrincipal" runat="server" Text="Prima Nueva" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetallePrimaNuevaPrincipal" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6" id="DivFechaInicioVigencia" runat="server">
                        <asp:Label ID="lbInicioVigencia" runat="server" Text="Inicio de Vigencia" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleInicioVigencia" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6" id="DivFechaFinVigencia" runat="server">
                        <asp:Label ID="lbDetalleFechaFinVigencia" runat="server" Text="Fin de Vigencia" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleFechaFinVigencia" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div align="center">
                    <asp:Button ID="btnGuardarDetalle" runat="server" Text="Guardar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Guardar Registro" OnClick="btnGuardarDetalle_Click" /> 
                     <asp:Button ID="btnVolverAtras" runat="server" Text="Volver" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Volver Atras" OnClick="btnVolverAtras_Click" /> 
                </div>
                <br />
            </div>

        </div>












        <div id="DivBloqieCoberturas" visible="false" runat="server">
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="width:10%" align="left"> Seleccionar </th>
                            <th style="width:40%" align="left"> Cobertura </th>
                            <th style="width:20%" align="left"> Limite </th>
                            <th style="width:10%" align="left"> % Deducible </th>
                            <th style="width:10%" align="left"> Minimo </th>
                            <th style="width:10%" align="left"> % Cobertura </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoCoberturasItem" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfNumeroCotizacionCobertura" runat="server" Value='<%# Eval("") %>' />
                                     <asp:HiddenField ID="hfNumeroItemCobertura" runat="server" Value='<%# Eval("") %>' />

                                    <td style="width:10%"> <asp:Button ID="btnseleccionarCoberturas" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Seleccionar Coberturas" OnClick="btnseleccionarCoberturas_Click" /> </td>
                                    <td style="width:40%"> <%# Eval("") %> </td>
                                    <td style="width:20%"> <%#string.Format("{0:n2}", Eval("")) %> </td>
                                    <td style="width:10%"> <%#string.Format("{0:n2}", Eval("")) %> </td>
                                    <td style="width:10%"> <%#string.Format("{0:n2}", Eval("")) %> </td>
                                    <td style="width:10%"> <%#string.Format("{0:n2}", Eval("")) %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

        

         <div align="center">
                <asp:Label ID="lbPaginaActualTituloCoberturas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="LinkBlbPaginaActualVariableCoberturas" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloCoberturas" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableCoberturas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionDetalleCoberturas" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaCoberturas" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaCoberturas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorCoberturas" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorCoberturas_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionCoberturas" runat="server" OnItemCommand="dtPaginacionCoberturas_ItemCommand" OnItemDataBound="dtPaginacionCoberturas_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralCoberturas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteCoberturas" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteCoberturas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoCoberturas" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoCoberturas_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            </div>
    </div>
























           <div class="modal fade bd-example-modal-xl OtrosFiltros" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">

        <asp:ScriptManager ID="ScripManagerOtrosFiltros" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelOtrosFiltros" runat="server">
            <ContentTemplate>
              <div class="container-fluid">
                  <div id="DivBloqueConsultaOtrosFiltros" runat="server">
                        <div class="form-check-inline">
                    <div class="form-group form-check">
                        <asp:RadioButton ID="rbBuscarPorPlaca" runat="server" Text="Buscar Por Placa" CssClass="form-check-input LetrasNegrita" ToolTip="Buscar mediante la placa" AutoPostBack="true" OnCheckedChanged="rbBuscarPorPlaca_CheckedChanged" GroupName="TipoBusqueda" />
                         <asp:RadioButton ID="rbBuscarPorChasis" runat="server" Text="Buscar Por Chasis" CssClass="form-check-input LetrasNegrita" ToolTip="Buscar mediante el Chasis" AutoPostBack="true" OnCheckedChanged="rbBuscarPorChasis_CheckedChanged" GroupName="TipoBusqueda" />
                    </div>
                </div>
                <br />
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label ID="lbLetreroOtroFiltro" runat="server" Text="Ingresar Dato" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtCampoOtroFiltro" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div align="center">
                    <asp:Button ID="btnBuscarotrosFiltros" runat="server" Text="Buscar" ToolTip="Buscar Registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnBuscarotrosFiltros_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lbCantidadRegistrosTituloOtrosFiltros" runat="server" Text="Cantidad de Registros ( " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbCantidadRegistrosVariableOtrosFiltros" runat="server" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
                    <asp:Label ID="lbCantidadRegistrosCerrarOtrosFiltros" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>
                </div>
                <br />

                  <div class="table-responsive">
                      <table class="table table-hover">
                          <thead>
                              <tr>
                              <th style="width:10%" align="left"> Detalle </th>
                              <th style="width:10%" align="left"> Poliza </th>
                              <th style="width:10%" align="left"> Item </th>
                              <th style="width:20%" align="left"> Ramo </th>
                              <th style="width:20%" align="left"> SubRamo </th>
                              <th style="width:30%" align="left"> Cliente </th>
                          </tr>
                          </thead>
                          <tbody>
                              <asp:Repeater ID="rpListadoOtrosFiltros" runat="server">
                                  <ItemTemplate>
                                      <tr>
                                          <asp:HiddenField ID="hfPolizaOtrosFiltros" runat="server" Value='<%# Eval("") %>' />
                                          <asp:HiddenField ID="hfItemOtrosFiltros" runat="server" Value='<%# Eval("") %>' />

                                          <td style="width:10%"> <asp:Button ID="btnDetalleOtrosFiltros" runat="server" Text="Detalle" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Mostrar el Detalle del Registro" OnClick="btnDetalleOtrosFiltros_Click" /> </td>
                                          <td style="width:10%"> <%# Eval("") %> </td>
                                          <td style="width:10%"> <%# Eval("") %> </td>
                                          <td style="width:20%"> <%# Eval("") %> </td>
                                          <td style="width:20%"> <%# Eval("") %> </td>
                                          <td style="width:30%"> <%# Eval("") %> </td>
                                      </tr>
                                  </ItemTemplate>
                              </asp:Repeater>
                          </tbody>
                      </table>
                  </div>
                   <div align="center">
                <asp:Label ID="lbPaginaActualTituloOtrosFiltros" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="LinkBlbPaginaActualVariableOtrosFiltros" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloOtrosFiltros" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableOtrosFiltros" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionDetalleOtrosFiltros" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaOtrosFiltros" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaOtrosFiltros_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorOtrosFiltros" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorOtrosFiltros_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionOtrosFiltros" runat="server" OnItemCommand="dtPaginacionOtrosFiltros_ItemCommand" OnItemDataBound="dtPaginacionOtrosFiltros_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralOtrosFiltros" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteOtrosFiltros" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteOtrosFiltros_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoOtrosFiltros" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoOtrosFiltros_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                  </div>







                  <div id="DivBloqueDetalleOtrosFiltros" visible="false" runat="server">

                      <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleRamoOtrosFiltros" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleRamoOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleSubramoOtrosFiltros" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleSubramoOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                     <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleInicioOtrosFiltros" runat="server" Text="Inicio Vigencia Actual" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleInicioVigenciaOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                     <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleFinVigenciaOtrosFiltros" runat="server" Text="Fin Vigencia Actual" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleFinVigenciaOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleTipoVehiculoOtrosFiltros" runat="server" Text="Tipo de Vehiculo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleTipoVehiculoOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleMarcaOtrosFiltros" runat="server" Text="Marca" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleMarcaOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleModeloOtrosFiltros" runat="server" Text="Modelo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleModeloOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleColorOtrosFiltros" runat="server" Text="Color" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleColorOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleChasisOtrosFiltros" runat="server" Text="Chasis" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleChasisOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetallePlacaOtrosFiltros" runat="server" Text="Placa" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetallePlacaOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleValorAseguradoOtrosFiltros" runat="server" Text="Valor Asegurado" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleValorAseguradoOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleFianzaOtrosFiltros" runat="server" Text="Fianza" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleFianzaOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleAseguradoOtrosFiltros" runat="server" Text="Asegurado" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleAseguradoOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetalleClienteOtrosFiltros" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetalleClienteOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>


                    <div class="form-group col-md-6">
                        <asp:Label ID="lbDetallePrimaActualOtrosFiltros" runat="server" Text="Prima Actual" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDetallePrimaActualOtrosFiltros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

  
                </div>

                      <div align="center">
                          <asp:Button ID="btnVolverAtrasOtrosFiltros" runat="server" Text="Volver" ToolTip="Volver Atras" OnClick="btnVolverAtrasOtrosFiltros_Click" CssClass="btn btn-outline-secondary btn-sm" />
                      </div>
                      <br />
                  </div>
              </div>

            </ContentTemplate>
        </asp:UpdatePanel>
      
        <br />
    </div>
  </div>
</div>
</asp:Content>

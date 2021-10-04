<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteOperacionesSospechosas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ReporteOperacionesSospechosas" %>
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

        .BotonImagen {
        width:50px;
        height:50px;
        
        }
    </style>

    <script type="text/javascript">
        function CamposFechaVacios() {
            alert("Los campos fecha no pueden estar vacios para realizar esta operación, favor de verificar.");
        }
        function CampoFechaDesdeVacio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }
        $(document).ready(function () {
            $("#<%=btnConsultarRegistrosNuevo.ClientID%>").click(function () {
                var TipoOperacion = $("#<%=ddlSeleccionarTipoOperacion.ClientID%>").val();
                if (TipoOperacion < 1) {
                    alert("El campo tipo de operación no puede estar vacio, favor de verificar.");
                    $("#<%=ddlSeleccionarTipoOperacion.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var MontoOperacion = $("#<%=txtMontoCondicion.ClientID%>").val().length;
                    if (MontoOperacion < 1) {
                        alert("El camo Monto de Condición no puede estar vacio, favor de verificar.");
                        $("#<%=txtMontoCondicion.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                        if (Tasa < 1) {
                            alert("El campo tasa no puede estar vacio, favoe de verificar.");
                            $("#<%=txtTasa.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            $("#<%=btnExportarRegistrosNuevo.ClientID%>").click(function () {
                var TipoOperacion = $("#<%=ddlSeleccionarTipoOperacion.ClientID%>").val();
                 if (TipoOperacion < 1) {
                     alert("El campo tipo de operación no puede estar vacio, favor de verificar.");
                     $("#<%=ddlSeleccionarTipoOperacion.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var MontoOperacion = $("#<%=txtMontoCondicion.ClientID%>").val().length;
                    if (MontoOperacion < 1) {
                        alert("El camo Monto de Condición no puede estar vacio, favor de verificar.");
                        $("#<%=txtMontoCondicion.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                        if (Tasa < 1) {
                            alert("El campo tasa no puede estar vacio, favoe de verificar.");
                             $("#<%=txtTasa.ClientID%>").css("border-color", "red");
                             return false;
                         }
                     }
                 }
             });
        })
    </script>
      <!--INICIO DE ENCABEZADO-->
      <div class="container-fluid">
     <br /><br />

          <div class="form-row">
              <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
              </div>

              <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
              </div>

              <div class="form-group col-md-3">
                  <asp:Label ID="lbSeleccionarTipoOperacion" runat="server" Text="Seleccionar Tipo de Operación" CssClass="Letranegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionarTipoOperacion" runat="server"  ToolTip="Seleccionar Tipo de Operación" CssClass="form-control"></asp:DropDownList>
              </div>

               <div class="form-group col-md-3">
                  <asp:Label ID="lbMontoCondicion" runat="server" Text="Monto Condición" CssClass="Letranegrita"></asp:Label>
                  <asp:TextBox ID="txtMontoCondicion" runat="server" CssClass="form-control"  ToolTip="Este es el monto a validar, para buscar los registros" TextMode="Number" step="0.01" Text="15000.00"></asp:TextBox>
              </div>
               <div class="form-group col-md-2">
                  <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="Letranegrita"></asp:Label>
                  <asp:TextBox ID="txtTasa" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
              </div>
          </div>
          <br />
          <div align="center">
              <asp:ImageButton ID="btnConsultarRegistrosNuevo" runat="server" ToolTip="Consultar Registros" CssClass="BotonImagen" OnClick="btnConsultarRegistrosNuevo_Click" ImageUrl="~/Imagenes/Buscar.png" />
              <asp:ImageButton ID="btnExportarRegistrosNuevo" runat="server" ToolTip="Exportar Registros" CssClass="BotonImagen" OnClick="btnExportarRegistrosNuevo_Click" ImageUrl="~/Imagenes/excel.png" />
              <asp:ImageButton ID="btnRestablecerPantallaNuevo" runat="server" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" OnClick="btnRestablecerPantallaNuevo_Click" ImageUrl="~/Imagenes/auto.png" />

              <br /><br />
              <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
              <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0 " CssClass="Letranegrita"></asp:Label>
              <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
          </div>
          <br />
          <!--INICIO DEL REPEATER-->
          <div class="table-responsive">
              <table class="table table-hover">
                  <thead>
                      <tr>
                          <th style="width:10%" align="left"> <asp:Label ID="lbdetalleHeaderRepeater" runat="server" Text="Detalle" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:10%" align="left"> <asp:Label ID="lbPoliaHeaderDetalleRepeater" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:10%" align="left"> <asp:Label ID="lbReciboHEaderRepeater" runat="server" Text="Recibo" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:10%" align="left"> <asp:Label ID="lbFechaHEaderRepeater" runat="server" Text="Fecha" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:15%" align="left"> <asp:Label ID="lbValorHeaderRepeater" runat="server" Text="Valor" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:15%" align="left"> <asp:Label ID="lbValorPesosHeaderRepeater" runat="server" Text="V. Pesos" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:15%" align="left"> <asp:Label ID="lbValorDollarHeaderRepeater" runat="server" Text="V. Dollar" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:15%" align="left"> <asp:Label ID="lbMonedaHeaderRepeater" runat="server" Text="Acumulado" CssClass="Letranegrita"></asp:Label> </th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater ID="rpListado" runat="server">
                          <ItemTemplate>
                              <tr>
                                    <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                                    <asp:HiddenField ID="hfNumeroRecibo" runat="server" Value='<%# Eval("NumeroRecibo") %>' />

                                  <td style="width:10%"> <asp:Button ID="btnDetalle" runat="server" Text="Detalle" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Mostrar el detalle del registro" OnClick="btnDetalle_Click" /> </td>
                                  <td style="width:10%"> <%# Eval("Poliza") %>  </td>
                                  <td style="width:10%"> <%# Eval("NumeroRecibo") %> </td>
                                  <td style="width:10%"> <%# Eval("FechaRecibo") %> </td>
                                  <td style="width:15%"> <%#string.Format("{0:n2}", Eval("MontoOriginal")) %> </td>
                                  <td style="width:15%"> <%#string.Format("{0:n2}", Eval("PagoAcumuladoPesos")) %> </td>
                                  <td style="width:15%"> <%#string.Format("{0:n2}", Eval("PagoAcumuladoDollar")) %> </td>
                                  <td style="width:15%"> <%#string.Format("{0:n2}", Eval("MontoAcumulado")) %> </td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
          </div>
          
            <div align="center">
                <asp:Label ID="lbPaginaActualTituloOperacionesSospechosas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableOperacionesSospechosas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloOperacionesSospechosas" runat="server" Text="De " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableOperacionesSospechosas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>

             <div id="DivPaginacionListadoPrincipal" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:LinkButton ID="LinkPrimeraOperacionesSospechosas" runat="server" Text="Primero" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraOperacionesSospechosas_Click" CssClass="btn btn-outline-success btn-sm"  ></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkAnteriorOperacionesSospechosas" runat="server" Text="Anterior" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorOperacionesSospechosas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td>
                                <asp:DataList ID="dtPaginacionOperacionesSospechosas" runat="server" OnCancelCommand="dtPaginacionOperacionesSospechosas_CancelCommand" OnItemDataBound="dtPaginacionOperacionesSospechosas_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkIndiceOperacionesSospechosas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="NuevaPagina" Text='<%# Eval("TextoPagina")%>' Width="20px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:LinkButton ID="LinkSiguienteOperacionesSospechosas" runat="server" Text="Siguiente" ToolTip="Ir la Siguiente pagina del listado" OnClick="LinkSiguienteOperacionesSospechosas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkUltimoOperacionesSospechosas" runat="server" Text="Ultmo" ToolTip="Ir a la Ultima Pagina del listado" OnClick="LinkUltimoOperacionesSospechosas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>






          <br />
          <div id="DivBloqueDetalle" runat="server">
              <div class="form-row">
                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNumeroReporte" runat="server" Text="Numero Reporte" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNumeroReporteDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtPolizaDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbCodigoRegistroEntidad" runat="server" Text="Codigo Registro Entidad" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtCodigoRegistroEntidadDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbUsuario" runat="server" Text="Usuario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtUsuario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbOficina" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtOficina" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbFechaEnvio" runat="server" Text="Fecha Envio" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtFechaEnvio" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbHoraEnvio" runat="server" Text="Hora Envio" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtHoraEnvio" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTipoPersonaCliente" runat="server" Text="Tipo Persona Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTipoPersonaCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbPEPCliente" runat="server" Text="PEP Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtPEPCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbPEPClienteTipo" runat="server" Text="PEP Cliente Tipo" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtPEPClienteTipo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbSexoCliente" runat="server" Text="Sexo Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSexoCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNombreRazonSocialCliente" runat="server" Text="Nombre Razon Social Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNombreRazonSocialCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbApellidoRazonSocialCliente" runat="server" Text="Apellido Razon Social Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtApellidoRazonSocialCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNacionalidadorigenCliente" runat="server" Text="Nacionalidad origen Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNacionalidadorigenCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNacionalidadAdquiridaCliente" runat="server" Text="Nacionalidad Adquirida Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNacionalidadAdquiridaCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTipoDocumentoCliente" runat="server" Text="Tipo Documento Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTipoDocumentoCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbNoDocumentoIdentidadCliente" runat="server" Text="No Documento Identidad Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNoDocumentoIdentidadCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbSiTipoDocumentoIgualOtroEspesificar" runat="server" Text="Tipo Documento Igual Otro Espesificar" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSiTipoDocumentoIgualOtroEspesificar" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbActividadEconomicaCliente" runat="server" Text="Actividad Economica Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtActividadEconomicaCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTipoProductoCliente" runat="server" Text="Tipo Producto Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTipoProductoCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbNoCuenta1" runat="server" Text="NoCuenta 1" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNoCuenta1" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNoCuenta2" runat="server" Text="NoCuenta 2" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNoCuenta2" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNoCuenta3" runat="server" Text="NoCuenta 3" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNoCuenta3" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbProvinciaCliente" runat="server" Text="Provincia Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtProvinciaCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbMunicipioCliente" runat="server" Text="Municipio Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtMunicipioCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbSectorCliente" runat="server" Text="Sector Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSectorCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbDireccionCliente" runat="server" Text="Direccion Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtDireccionCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTelefonoCasaCliente" runat="server" Text="Telefono Casa Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTelefonoCasaCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbTelefonoOficinaCliente" runat="server" Text="Telefono Oficina Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTelefonoOficinaCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbCelular1Cliente" runat="server" Text="Celular1 Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtCelular1Cliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbCelular2Cliente" runat="server" Text="Celular 2 Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtCelular2Cliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTipoTransaccion" runat="server" Text="Tipo Transaccion" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTipoTransaccion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbDescripcionTransaccion" runat="server" Text="Descripcion Transaccion" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtDescripcionTransaccion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTipoMoneda" runat="server" Text="Tipo Moneda" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTipoMoneda" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNumeroRecibo" runat="server" Text="Numero Recibo" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNumeroRecibo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbFechaRecibo" runat="server" Text="Fecha Recibo" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtFechaRecibo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbMontoOriginal" runat="server" Text="Monto Original" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtMontoOriginal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbPagoAcumuladoPesos" runat="server" Text="Pago Acumulado Pesos" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtPagoAcumuladoPesos" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbPagoAcumuladoDollar" runat="server" Text="Pago Acumulado Dollar" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtPagoAcumuladoDollar" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTasaCambio" runat="server" Text="Tasa Cambio" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTasaCambio" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbTipoInstrumento" runat="server" Text="Tipo Instrumento" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTipoInstrumento" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbFechaTransaccion" runat="server" Text="Fecha Transaccion" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtFechaTransaccion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbHoraTransaccion" runat="server" Text="Hora Transaccion" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtHoraTransaccion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbFechaEnvioDetalle" runat="server" Text="Fecha Envio" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtFechaEnvioDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbHoraTransaccion2" runat="server" Text="Hora Transaccion" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtHoraTransaccion2" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbOrigenFondos" runat="server" Text="Origen Fondos" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtOrigenFondos" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTransaccionRealizada" runat="server" Text="Transaccion Realizada" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTransaccionRealizada" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbMotivoTransaccion" runat="server" Text="Motivo Transaccion" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtMotivoTransaccion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbPaisOrigen" runat="server" Text="Pais Origen" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtPaisOrigen" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbPaisDestino" runat="server" Text="Pais Destino" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtPaisDestino" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbEntidadCorresponsal" runat="server" Text="Entidad Corresponsal" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtEntidadCorresponsal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbRemesador" runat="server" Text="Remesador" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtRemesador" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbIntermediarioIgualCliente" runat="server" Text="Intermediario Igual Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtIntermediarioIgualCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbSexoIntermediario" runat="server" Text="Sexo Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSexoIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNombreRazonIntermediario" runat="server" Text="Nombre Razon Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNombreRazonIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbApellidoRazonIntermediario" runat="server" Text="Apellido Razon Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtApellidoRazonIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbNacionalidadOrigenIntermediario" runat="server" Text="Nacionalidad Origen Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNacionalidadOrigenIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNacionalidadAdquiridaIntermediario" runat="server" Text="Nacionalidad Adquirida Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNacionalidadAdquiridaIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTipoRncIntermediario" runat="server" Text="Tipo Rnc Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTipoRncIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNoDocumentoIntermediario" runat="server" Text="No Documento Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNoDocumentoIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbSiTipoDocumentoIgualOtroEspesificarIntermdiario" runat="server" Text="TipoDocumento Igual Otro Intermdiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSiTipoDocumentoIgualOtroEspesificarIntermdiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbProvinciaIntermediario" runat="server" Text="Provincia Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtProvinciaIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbMunicipioIntermediario" runat="server" Text="Municipio Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtMunicipioIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbSectorIntermediario" runat="server" Text="Sector Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSectorIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbDireccionIntermediario" runat="server" Text="Direccion Intermediario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtDireccionIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbBeneficiarioIgualCliente" runat="server" Text="Beneficiario Igual Cliente" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtBeneficiarioIgualCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbSexoBeneficiario" runat="server" Text="Sexo Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSexoBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNombreRazonSocialBeneficiario" runat="server" Text="Nombre RazonSocial Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNombreRazonSocialBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbApellidoRazonSocialBeneficiario" runat="server" Text="Apellido Razon Social Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtApellidoRazonSocialBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNacionalidadBeneficiario" runat="server" Text="Nacionalidad Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNacionalidadBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbNacionalidadAdquiridaBeneficiario" runat="server" Text="Nacionalid adAdquirida Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNacionalidadAdquiridaBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbTipoIdentificacionBeneficiario" runat="server" Text="Tipo Identificacion Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtTipoIdentificacionBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbNoDocumentoIdentidadBeneficiario" runat="server" Text="No Documento Identidad Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtNoDocumentoIdentidadBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbSiTipoDocumentoIgualOtroEspesificarBeneficiario" runat="server" Text="Tipo Documento Igual Otro Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSiTipoDocumentoIgualOtroEspesificarBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbProvinciaBeneficiario" runat="server" Text="Provincia Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtProvinciaBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbMunicipioBeneficiario" runat="server" Text="Municipio Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtMunicipioBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbSectorBeneficiario" runat="server" Text="Sector Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtSectorBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbDireccionBeneficiario" runat="server" Text="Direccion Beneficiario" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtDireccionBeneficiario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbMotivoReporte" runat="server" Text="Motivo Reporte" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtMotivoReporte" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbEspesifiquePrioridadReporte" runat="server" Text="Espesifique Prioridad Reporte" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtEspesifiquePrioridadReporte" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbAnexo" runat="server" Text="Anexo" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtAnexo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbValidadoDesde" runat="server" Text="Validado Desde" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtValidadoDesde" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbValidadoHasta" runat="server" Text="Validado Hasta" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtValidadoHasta" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="lbMontoCondicion2" runat="server" Text="Monto Condicion" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtMontoCondicion2" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="lbGeneradoPor" runat="server" Text="Generado Por" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="txtGeneradoPor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

  

              </div>
              <br />
              <div class="form-check-inline">
                  <div class="form-group form-check">
                      <asp:Label ID="lbExportarRegistrosA" runat="server" Text="Exportar A: " CssClass="Letranegrita"></asp:Label>
                      <asp:RadioButton ID="rbExportarPDF" runat="server" Text="PDF" CssClass="form-check-input Letranegrita" ToolTip="Generar Reporte en PDF" GroupName="Reporte" />
                      <asp:RadioButton ID="rbExportarWord" runat="server" Text="Word" CssClass="form-check-input Letranegrita" ToolTip="Generar Reporte en Word" GroupName="Reporte" />
                  </div>
              </div>
              <div align="center">
                  <asp:Button ID="btnGenerarReporte" runat="server" Text="Reporte" ToolTip="Generar Reporte del Registro Seleccionado" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnGenerarReporte_Click" />
                  <asp:Button ID="btnVolverAtras" runat="server" Text="Volver Atras" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnVolverAtras_Click" />
              </div>
              <br />
          </div>
      </div>
</asp:Content>

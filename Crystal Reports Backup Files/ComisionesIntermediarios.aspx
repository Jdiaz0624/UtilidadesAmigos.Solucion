<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ComisionesIntermediarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ComisionesIntermediarios" %>
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

        .LetrasNegrita {
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
        function CampoTasaVacio() {
            alert("El campo Tasa no puede estar vacio, favor de verificar");
            $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
        }
        function FechaDesdeComisionesVacio() {
            $("#<%=txtFechaDesdeComisiones.ClientID%>").css("border-color", "red");
        }

        function CamposFechasVacios() {
            alert("Los campos fechas no pueden estar vacios para realizar esta operación, favor de verificar.");
        }
        function FechaHastaComisionesVAcio() {
            $("#<%=txtFechaHastaComisiones.ClientID%>").css("border-color", "red");
        }
        $(document).ready(function () {
            $("#<%=btnConsultarComisionesNuevo.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaDollar.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                    if (MontoMinimo < 1) {
                        alert("El campo Monto Minimo no puede estar vacio para realizar esta consulta, favor de verificar");
                        $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }
            });
            $("#<%=btnExortarComisionesNuevo.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaDollar.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                    if (MontoMinimo < 1) {
                        alert("El campo Monto Minimo no puede estar vacio para exportar esta información, favor de verificar");
                        $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }
            });
            $("#<%=btnReporteCOmisionesNuevo.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaDollar.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                    if (MontoMinimo < 1) {
                        alert("El campo Monto Minimo no puede estar vacio para generar este reporte, favor de verificar");
                        $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }
            });
        })
    </script>
          <div class="container-fluid">
          <br /><br />
          <br />
          <div class="row">
              <div class="col-md-3">
                  <asp:Label ID="lbFechaDesdeComisiones" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaDesdeComisiones" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-3">
                  <asp:Label ID="lbFechaHastaComisiones" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaHastaComisiones" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>
               <div class="col-md-3">
                  <asp:Label ID="lbCodigoIntermediarioComisiones" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtCodigoIntermediarioComisiones" runat="server" MaxLength="4" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioComisiones_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-3">
                  <asp:Label ID="lbNombrevendedorComisiones" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtNombreVendedorComsiiones" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-3">
                  <asp:Label ID="lbSeleccionarSucursalComisiones" runat="server" Text="Seleccionar Sucursal" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionarSucursalComisiones" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursalComisiones_SelectedIndexChanged" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="col-md-3">
                  <asp:Label ID="lbSeleccionarOficinaComisiones" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionaroficinaComisiones" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="col-md-3">
                  <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Seleccionar Ramo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
              </div>
               <div class="col-md-3">
                  <asp:Label ID="lbMontoMinimo" runat="server" Text="Monto Minimo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtMontoMinimo" runat="server" Text="500" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-3">
                  <asp:Label ID="lbNumeroPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtNumeroPoliza" runat="server" AutoCompleteType="Disabled"  CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-3">
                  <asp:Label ID="lbNumeroRecibo" runat="server" Text="No. Recibo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtNumeroRecibo" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-3">
                  <asp:Label ID="lbNumeroFactura" runat="server" Text="No. Factura" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtNumeroFactura" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="col-md-2">
                  <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtTasaDollar" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
              </div>
             
          </div>
              <div align="center">
                  <asp:Label ID="lbLeyrtero" runat="server" Text="Seleccionar Tipo de Reporte a Mostrar:" CssClass="LetrasNegrita"></asp:Label>
                  <div class="form-check-inline">
         
                          <asp:RadioButton ID="rbGenerarReporteResumido" runat="server" Text="Resumido" ToolTip="Generar reporte de comisión resumido" GroupName="Reporte" CssClass="form-check-input LetrasNegrita" />
                          <asp:RadioButton ID="rbGenerarReporteDetalle" runat="server" Text="Detalle" ToolTip="Generar reporte de comsiion detalle" GroupName="Reporte" CssClass="form-check-input LetrasNegrita" />
                          <asp:RadioButton ID="rbGenerarReporteInterno" runat="server" Text="Interno" ToolTip="Generar reporte de comisión de intermediario interno" GroupName="Reporte" CssClass="form-check-input LetrasNegrita" />
             

              </div>
                  <br />
                  <div class="form-check-inline">

                          <asp:Label ID="lbGenerarReporteA" runat="server" Text="Generar Reporte A: " CssClass="LetrasNegrita"></asp:Label>
                          <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" CssClass="form-check-input" ToolTip="Generar Reporte a PDF" GroupName="Exportar" />
                          <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" CssClass="form-check-input" ToolTip="Generar Reporte a Excel" GroupName="Exportar" />
                          <asp:RadioButton ID="rbWord" runat="server" Text="Word" CssClass="form-check-input" ToolTip="Generar Reporte a Word" GroupName="Exportar" />
          
                  </div><br />
                  <div class="form-check-inline">
             
                          <asp:CheckBox ID="cbMostrarIntermediariosAcumulativos" runat="server" Text="Montos Intermediarios Acumulativos" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="cbMostrarIntermediariosAcumulativos_CheckedChanged" />
           
                  </div>
          <div align="center">
              <asp:ImageButton ID="btnConsultarComisionesNuevo" runat="server" ToolTip="Buscar Información" CssClass="BotonImagen" OnClick="btnConsultarComisionesNuevo_Click" ImageUrl="~/Imagenes/Buscar.png" />
              <asp:ImageButton ID="btnExortarComisionesNuevo" runat="server" ToolTip="Exportar Información a Excel" CssClass="BotonImagen" OnClick="btnExortarComisionesNuevo_Click" ImageUrl="~/Imagenes/excel.png" />
              <asp:ImageButton ID="btnReporteCOmisionesNuevo" runat="server" ToolTip="Generar Reporte de Comisiones" CssClass="BotonImagen" OnClick="btnReporteCOmisionesNuevo_Click" ImageUrl="~/Imagenes/Reporte.png" />
              <asp:ImageButton ID="btnActualizarListadoNuevo" runat="server" ToolTip="Actualizar Montos Acumulados" CssClass="BotonImagen" Visible="false" OnClick="btnActualizarListadoNuevo_Click" ImageUrl="~/Imagenes/auto.png" />
          </div>
          <br />
    </div>

              <div id="DivRepeaterNormal" runat="server" visible="true">
     
                  <table class="table table-striped">
                      <thead>
                          <tr>
                              <th scope="col"> Poliza </th>
                              <th scope="col"> Recibo </th>
                              <th scope="col"> Fecha </th>
                              <th scope="col"> Bruto </th>
                              <th scope="col"> Neto </th>
                              <th scope="col"> % </th>
                              <th scope="col"> Comisión </th>
                              <th scope="col"> Retención </th>
                              <th scope="col"> Avance </th>
                              <th scope="col"> Liquidar </th>
                          </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="rpListadoComision" runat="server">
                              <ItemTemplate>
                                  <tr>
                                      <td> <%# Eval("Poliza") %> </td>
                                      <td> <%# Eval("Recibo") %> </td>
                                      <td> <%# Eval("Fecha") %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Bruto")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Neto")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("PorcientoComision")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Comision")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Retencion")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("AvanceComision")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("ALiquidar")) %> </td>
                                  </tr>
                              </ItemTemplate>
                          </asp:Repeater>
                      </tbody>
                  </table>
     
               <div align="center">
                <asp:Label ID="lbPaginaActualTitulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavle" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTitulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
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
              </div>

              <div id="DivBloqueRepeaterAcumulativo" runat="server" visible="false">
                  <div align="center">
                      <asp:Label ID="lbcantidadRegistrosEncontradosAcumulativosTitulo" runat="server" Text="Cantidad de registros ( " CssClass="Letranegrita"></asp:Label>
                      <asp:Label ID="lbcantidadRegistrosEncontradosAcumulativosVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                      <asp:Label ID="lbcantidadRegistrosEncontradosAcumulativosCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
                  </div>


                      <table class="table table-striped">
                          <thead>
                              <tr>
                                  <th scope="col"> Detalle </th>
                                  <th scope="col"> Intermediario </th>
                                  <th scope="col"> Oficina </th>
                                  <th scope="col"> Comisión </th>
                                  <th scope="col"> Retención </th>
                                  <th scope="col"> Avance </th>
                                  <th scope="col"> A Liquidar </th>
                                  <th scope="col"> Estatus </th>
                                  <th scope="col"> Cantidad </th>                                
                              </tr>
                          </thead>
                          <tbody>
                              <asp:Repeater ID="rpListadoMontosIntermediariosAcumulados" runat="server">
                                  <ItemTemplate>
                                      <tr>
                                          <asp:HiddenField ID="hfCodigoIntermediario" runat="server" Value='<%# Eval("CodigoIntermediario") %>' />

                                          <td> <asp:Button ID="btnDetalleMontoAcumulado" runat="server" Text="Detalle" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Descargar el detalle del registro" OnClick="btnDetalleMontoAcumulado_Click" /> </td>
                                          <td> <%# Eval("Intermediario") %> </td>
                                          <td> <%# Eval("Oficina") %> </td>
                                          <td> <%#string.Format("{0:n2}", Eval("ComisionGenerada")) %> </td>
                                          <td> <%#string.Format("{0:n2}", Eval("Retencion")) %> </td>
                                          <td> <%#string.Format("{0:n2}", Eval("AvanceComision")) %> </td>
                                          <td> <%#string.Format("{0:n2}", Eval("Aliquidar")) %> </td>
                                          <td> <%# Eval("GeneraCheque") %> </td>
                                          <td> <%#string.Format("{0:n0}", Eval("CantiadRegistros")) %> </td>
                                      </tr>
                                  </ItemTemplate>
                              </asp:Repeater>
                          </tbody>
                      </table>
         

                     <div align="center">
                <asp:Label ID="lbPaginaActualTituloDetalle" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="LinkBlbPaginaActualVariavleDetalleutton2" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloDetalle" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableDetalle" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionDetalle" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaDetalle" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaDetalle_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorDetalle" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorDetalle_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionDetalle" runat="server" OnItemCommand="dtPaginacionDetalle_ItemCommand" OnItemDataBound="dtPaginacionDetalle_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteDetalle" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteDetalle_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoDetalle" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoDetalle_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>

              </div>
          <br />
      </div>
</asp:Content>

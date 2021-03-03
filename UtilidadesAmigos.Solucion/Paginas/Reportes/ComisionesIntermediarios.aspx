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
            $("#<%=btnConsultarComisiones.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaDollar.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
            $("#<%=btnExortarComisiones.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaDollar.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
            $("#<%=btnReporteCOmisiones.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaDollar.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        })
    </script>
          <div class="container-fluid">
          <br /><br />
          <br />
          <div class="form-row">
              <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaDesdeComisiones" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaDesdeComisiones" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaHastaComisiones" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaHastaComisiones" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>
               <div class="form-group col-md-3">
                  <asp:Label ID="lbCodigoIntermediarioComisiones" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtCodigoIntermediarioComisiones" runat="server" MaxLength="4" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioComisiones_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbNombrevendedorComisiones" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtNombreVendedorComsiiones" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbSeleccionarSucursalComisiones" runat="server" Text="Seleccionar Sucursal" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionarSucursalComisiones" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursalComisiones_SelectedIndexChanged" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbSeleccionarOficinaComisiones" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionaroficinaComisiones" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="form-group col-md-1">
                  <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtTasaDollar" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
              <div align="center">
                  <asp:Label ID="lbLeyrtero" runat="server" Text="Seleccionar Tipo de Reporte a Mostrar:" CssClass="LetrasNegrita"></asp:Label>
                  <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:RadioButton ID="rbGenerarReporteResumido" runat="server" Text="Resumido" ToolTip="Generar reporte de comisión resumido" GroupName="Reporte" CssClass="form-check-input LetrasNegrita" />
                          <asp:RadioButton ID="rbGenerarReporteDetalle" runat="server" Text="Detalle" ToolTip="Generar reporte de comsiion detalle" GroupName="Reporte" CssClass="form-check-input LetrasNegrita" />
                          <asp:RadioButton ID="rbGenerarReporteInterno" runat="server" Text="Interno" ToolTip="Generar reporte de comisión de intermediario interno" GroupName="Reporte" CssClass="form-check-input LetrasNegrita" />
                      </div>

              </div>
                  <br />
                  <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:Label ID="lbGenerarReporteA" runat="server" Text="Generar Reporte A: " CssClass="LetrasNegrita"></asp:Label>
                          <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" CssClass="form-check-input" ToolTip="Generar Reporte a PDF" GroupName="Exportar" />
                          <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" CssClass="form-check-input" ToolTip="Generar Reporte a Excel" GroupName="Exportar" />
                          <asp:RadioButton ID="rbWord" runat="server" Text="Word" CssClass="form-check-input" ToolTip="Generar Reporte a Word" GroupName="Exportar" />
                      </div>
                  </div>
          <div align="center">
              <asp:Button ID="btnConsultarComisiones" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultarComisiones_Click"  />
              <asp:Button ID="btnExortarComisiones" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExortarComisiones_Click" />
              <asp:Button ID="btnReporteCOmisiones" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm" ToolTip="Reporte de Comisiones" OnClick="btnReporteCOmisiones_Click" />
          </div>
          <br />
    </div>

              <div class="table-responsive">
                  <table class="table table-hover">
                      <thead>
                          <tr>
                              <th style="width:10%" align="left"> <asp:Label ID="lbPolizaHeaderRepeater" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbReciboHeaderRepeater" runat="server" Text="Recibo" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbFechaHeaderRepeater" runat="server" Text="Fecha" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbBrutoHeaderRepeater" runat="server" Text="Bruto" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbNetoHeaderRepeater" runat="server" Text="Neto" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbPorcientoComisionHeaderRepeater" runat="server" Text="%" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbComisionHeaderRepeater" runat="server" Text="Comisión" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbRetencionHeaderRepeater" runat="server" Text="Retención" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbAvanceHeaderRepeater" runat="server" Text="Avance" CssClass="LetrasNegrita"></asp:Label> </th>
                              <th style="width:10%" align="left"> <asp:Label ID="lbLiquidarHeaderRepeater" runat="server" Text="Liquidar" CssClass="LetrasNegrita"></asp:Label> </th>
                          </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="rpListadoComision" runat="server">
                              <ItemTemplate>
                                  <tr>
                                      <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                      <td style="width:10%"> <%# Eval("Recibo") %> </td>
                                      <td style="width:10%"> <%# Eval("Fecha") %> </td>
                                      <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Bruto")) %> </td>
                                      <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Neto")) %> </td>
                                      <td style="width:10%"> <%#string.Format("{0:n2}", Eval("PorcientoComision")) %> </td>
                                      <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Comision")) %> </td>
                                      <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Retencion")) %> </td>
                                      <td style="width:10%"> <%#string.Format("{0:n2}", Eval("AvanceComision")) %> </td>
                                      <td style="width:10%"> <%#string.Format("{0:n2}", Eval("ALiquidar")) %> </td>
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
          <br />
      </div>
</asp:Content>

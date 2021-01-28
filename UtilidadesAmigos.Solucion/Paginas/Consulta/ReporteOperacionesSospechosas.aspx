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
    </style>

      <!--INICIO DE ENCABEZADO-->
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbEncabezado" runat="server" Text="Reporte de Operaciones Sospechosas"></asp:Label>
          </div>

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
              <asp:Button ID="btnConsultarRegistros" runat="server" Text="Consultar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultarRegistros_Click" />
              <asp:Button ID="btnExportarRegistros" runat="server" Text="Exportar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Exportar Registros" OnClick="btnExportarRegistros_Click" />
              <asp:Button ID="btnRestablecerPantalla" runat="server" Text="Restablecer" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Restablecer Pantalla" OnClick="btnRestablecerPantalla_Click" />
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
                          <th style="width:10%" align="left"> <asp:Label ID="lbMonedaHeaderRepeater" runat="server" Text="Moneda" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:15%" align="left"> <asp:Label ID="lbValorHeaderRepeater" runat="server" Text="Valor" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:15%" align="left"> <asp:Label ID="lbValorPesosHeaderRepeater" runat="server" Text="V. Pesos" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:15%" align="left"> <asp:Label ID="lbValorDollarHeaderRepeater" runat="server" Text="V. Dollar" CssClass="Letranegrita"></asp:Label> </th>
                          <th style="width:5%" align="left"> <asp:Label ID="lbTasaHeaderRepeater" runat="server" Text="Tasa" CssClass="Letranegrita"></asp:Label> </th>
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
                                  <td style="width:10%"> <%# Eval("TipoMoneda") %> </td>
                                  <td style="width:15%"> <%#string.Format("{0:n2}", Eval("MontoOriginal")) %> </td>
                                  <td style="width:15%"> <%#string.Format("{0:n2}", Eval("PagoAcumuladoPesos")) %> </td>
                                  <td style="width:15%"> <%#string.Format("{0:n2}", Eval("PagoAcumuladoDollar")) %> </td>
                                  <td style="width:5%"> <%# Eval("Tasa") %> </td>
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







          <div id="DivBloqueDetalle" runat="server">
              <div class="form-row">
                  <div class="form-group col-md-3">
                      <asp:Label ID="Label1" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="Texbox1" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label2" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox1" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label3" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox2" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label4" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox3" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label5" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox4" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label6" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox5" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label7" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox6" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label8" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox7" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label9" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox8" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label10" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox9" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label11" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox10" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label12" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox11" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label13" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox12" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label14" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox13" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label15" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox14" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label16" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox15" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label17" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox16" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label18" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox17" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label19" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox18" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label20" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox19" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label21" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox20" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label22" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox21" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label23" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox22" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label24" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox23" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label25" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox24" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label26" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox25" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label27" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox26" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label28" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox27" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label29" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox28" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label30" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox29" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label31" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox30" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label32" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox31" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label33" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox32" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label34" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox33" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label35" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox34" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label36" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox35" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label37" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox36" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label38" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox37" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label39" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox38" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label40" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox39" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label41" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox40" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label42" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox41" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label43" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox42" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label44" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox43" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label45" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox44" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label46" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox45" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label47" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox46" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label48" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox47" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label49" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox48" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label50" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox49" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label51" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox50" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label52" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox51" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label53" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox52" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label54" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox53" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label55" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox54" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label56" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox55" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label57" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox56" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label58" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox57" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label59" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox58" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label60" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox59" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label61" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox60" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label62" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox61" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label63" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox62" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label64" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox63" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label65" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox64" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label66" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox65" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label67" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox66" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label68" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox67" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label69" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox68" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label70" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox69" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label71" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox70" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label72" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox71" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label73" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox72" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label74" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox73" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label75" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox74" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label76" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox75" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label77" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox76" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label78" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox77" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label79" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox78" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label80" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox79" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label81" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox80" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label82" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox81" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label83" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox82" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label84" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox83" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label85" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox84" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label86" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox85" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label87" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox86" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label88" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox87" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label89" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox88" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label90" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox89" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label91" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox90" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label92" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox91" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label93" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox92" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label94" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox93" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label95" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox94" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label96" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox95" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                    <div class="form-group col-md-3">
                      <asp:Label ID="Label97" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox96" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label98" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox97" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label99" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox98" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                  </div>

                  <div class="form-group col-md-3">
                      <asp:Label ID="Label100" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                      <asp:TextBox ID="TextBox99" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
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

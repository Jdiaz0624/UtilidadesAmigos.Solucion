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
        

  

                 .BotonImagen {
                   width:50px;
                   height:50px;
                 
                 }
    </style>

    <script type="text/javascript">
        function CampoFechaDesdeVacio() {

            $("#<%=txtFechaDesdeComisiones.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHastaVacio() {

            $("#<%=txtFechaHastaComisiones.ClientID%>").css("border-color", "red");
        }

        function CamposFechaVAcios() {
            alert("El campo Fecha Desde o el Campo Fecha Hasta son necesarios para realizar esta operación, favor de verificar.");
        }

        $(function () {

            //VALIDAMOS EL BOTON BUSCAR CON EL MONTO MINIMO
            $("#<%=btnConsultarComisionesNuevo.ClientID%>").click(function () {
                var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                if (MontoMinimo < 1) {
                    alert("El campo Monto minimo no puede estar vacio para buscar esta información, favor de verificar.");
                    $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                    return false;
                }
            });


            //VALIDAMOS EL BOTON BUSCAR CON EL MONTO MINIMO
            $("#<%=btnReporteCOmisionesNuevo.ClientID%>").click(function () {
                var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                if (MontoMinimo < 1) {
                    alert("El campo Monto Minimo no puede estar vacio para generar este reporte, favor de verificar.");
                    $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        });
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
       
             
          </div>
              <div align="center">
                  <asp:Label ID="lbLeyrtero" runat="server" Text="Seleccionar Tipo de Reporte a Mostrar:" CssClass="LetrasNegrita"></asp:Label>
                  <div class="form-check-inline">
         
                          <asp:RadioButton ID="rbGenerarReporteResumido" runat="server" Text="Resumido" ToolTip="Generar reporte de comisión resumido" GroupName="Reporte" />
                          <asp:RadioButton ID="rbGenerarReporteDetalle" runat="server" Text="Detalle" ToolTip="Generar reporte de comsiion detalle" GroupName="Reporte" />
                          <asp:RadioButton ID="rbGenerarReporteInterno" runat="server" Text="Interno" ToolTip="Generar reporte de comisión de intermediario interno" GroupName="Reporte" />
              </div>
                  <br />
                  <div class="form-check-inline">
                          <asp:Label ID="lbGenerarReporteA" runat="server" Text="Generar Reporte A: " CssClass="LetrasNegrita"></asp:Label>
                          <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" ToolTip="Generar Reporte a PDF" GroupName="Exportar" />
                          <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" ToolTip="Generar Reporte a Excel" GroupName="Exportar" />
                          <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano" ToolTip="Generar Reporte a Excel Plano" GroupName="Exportar" />
          
                  </div><br />
                  <div class="form-check-inline">
             
                          <asp:CheckBox ID="cbMostrarIntermediariosAcumulativos" runat="server" Text="Montos Intermediarios Acumulativos" AutoPostBack="true" OnCheckedChanged="cbMostrarIntermediariosAcumulativos_CheckedChanged" />
           
                  </div>
                  <br /><br />
          <div align="center">
              <asp:ImageButton ID="btnConsultarComisionesNuevo" runat="server" ToolTip="Buscar Información" CssClass="BotonImagen" OnClick="btnConsultarComisionesNuevo_Click" ImageUrl="~/Imagenes/Buscar.png" />
              <asp:ImageButton ID="btnReporteCOmisionesNuevo" runat="server" ToolTip="Generar Reporte de Comisiones" CssClass="BotonImagen" OnClick="btnReporteCOmisionesNuevo_Click" ImageUrl="~/Imagenes/Reporte.png" />
              <asp:ImageButton ID="btnActualizarListadoNuevo" runat="server" ToolTip="Actualizar Montos Acumulados" CssClass="BotonImagen" Visible="false" OnClick="btnActualizarListadoNuevo_Click" ImageUrl="~/Imagenes/auto.png" />
          </div>
          <br />
    </div>

              <div id="DivRepeaterNormal" runat="server" visible="true">
     
                  <table class="table table-striped">
                      <thead class="table table-dark">
                          <tr>
                              <th scope="col"> Intermediario </th>
                              <th scope="col"> Bruto </th>
                              <th scope="col"> Neto </th>
                              <th scope="col"> Comisión </th>
                              <th scope="col"> Retencion </th>
                              <th scope="col"> Avance </th>
                              <th scope="col"> Liquidar </th>
                          </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="rpListadoComision" runat="server">
                              <ItemTemplate>
                                  <tr>
                                      <td> <%# Eval("Intermediario") %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Bruto")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Neto")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Comision")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Retencion")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("AvanceComision")) %> </td>
                                      <td> <%#string.Format("{0:n2}", Eval("Aliquidar")) %> </td>
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
                    <td> <asp:ImageButton ID="btnPrimeraPaginaComisiones" runat="server" ToolTip="Ir a la Primera Pagina del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaComisiones_Click" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnteriorComisiones" runat="server" ToolTip="Ir a la Pagina Anterior del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnteriorComisiones_Click" /> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionComisiones" runat="server" OnItemCommand="dtPaginacionComisiones_ItemCommand" OnItemDataBound="dtPaginacionComisiones_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    
                    <td> <asp:ImageButton ID="btnPaginaSiguienteComisiones" runat="server" ToolTip="Ir a la Pagina Siguiente del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnPaginaSiguienteComisiones_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPaginaComisiones" runat="server" ToolTip="Ir a la Ultima Pagina del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPaginaComisiones_Click" /> </td>
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
                          <thead class="table table-dark">
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

                                          <td> <asp:ImageButton ID="btnExportarListadoRecibos" runat="server" ToolTip="Exportar el Listado de los recibos" CssClass="BotonImagen" ImageUrl="~/Imagenes/excel.png" OnClick="btnExportarListadoRecibos_Click" /> </td>
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
                    <td> <asp:ImageButton ID="btnPrimeraPAginaMontosAcumulados" runat="server" ToolTip="Ir a la Primera Pagina del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPAginaMontosAcumulados_Click" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnteriorMontosAcumulados" runat="server" ToolTip="Ir a la Pagina Anterior del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnteriorMontosAcumulados_Click" /> </td>
                    <td>
                        <asp:DataList ID="DTPaginacionMontosAcumulados" runat="server" OnItemCommand="DTPaginacionMontosAcumulados_ItemCommand" OnItemDataBound="DTPaginacionMontosAcumulados_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    
                    <td> <asp:ImageButton ID="btnSiguientePaginaMontosAcumulados" runat="server" ToolTip="Ir a la Pagina Siguiente del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePaginaMontosAcumulados_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPaginaMontosAcumulados" runat="server" ToolTip="Ir a la Ultima Pagina del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPaginaMontosAcumulados_Click" /> </td>
                </tr>
            </table>
        </div>
        </div>

              </div>
          <br />
      </div>
</asp:Content>

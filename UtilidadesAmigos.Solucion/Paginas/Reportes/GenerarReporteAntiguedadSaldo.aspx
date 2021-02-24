<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarReporteAntiguedadSaldo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarReporteAntiguedadSaldo" %>
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
        function CampoFechaCorteVacio() {
            alert("El campo Fecha de corte no puede estar vacio para realziar esta operación, favor de verificar.");
            $("#<%=txtFechaCorte.ClientID%>").css("border-color", "red");
        }

        $(document).ready(function () {
            $("#<%=btnConsultar.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaDollar.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para realizar esta consulta, favor de verificar.");
                    $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
                    return false;
                }

            });

            $("#<%=btnExportar.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasaDollar.ClientID%>").val().length;
                if (Tasa < 1) {
                    alert("El campo tasa no puede estar vacio para exportar esta información, favor de verificar.");
                    $("#<%=txtTasaDollar.ClientID%>").css("border-color", "red");
                    return false;
                }

            });
        })
    </script>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTituloPantalla" runat="server" Text="Reporte de Antiguedad de Saldo" CssClass="Letranegrita"></asp:Label>
        </div>

        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbfechacorte" runat="server" Text="Fecha de Corte" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaCorte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbNumeroFactura" runat="server" Text="Numero de Factura (FT, CR o PAD)" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroFactura" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo para la consulta" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="form-group col-md-1">
                <asp:Label ID="lbTasaDollar" runat="server" Text="Tasa" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTasaDollar" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
            </div>
            <div class="form-group col-md-2">
                <asp:Label ID="lbTipoMovimiento" runat="server" Text="Tipo de Movimiento" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoMovimiento" runat="server" ToolTip="Seleccionar el Tipo de Movimiento" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-1">
                <asp:Label ID="lbCodigoCliente" runat="server" Text="Codigo Cliente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoCliente" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoCliente_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
             <div class="form-group col-md-2">
                <asp:Label ID="lbNombreCliente" runat="server" Text="Nombre Cliente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group col-md-1">
                <asp:Label ID="lbCodigoVendedor" runat="server" Text="Codigo Vendedor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoVendedor" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoVendedor_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
             <div class="form-group col-md-2">
                <asp:Label ID="lbNombreVendedor" runat="server" Text="Nombre Vendedor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreVendedor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbOficina" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbTipoReporte" runat="server" Text="Tipo de Reporte: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Resumido" CssClass="form-check-input" GroupName="TipoReporte" ToolTip="Generar Antiguedad de Saldo Resumida" />
                <asp:RadioButton ID="rbReporteNeteado" runat="server" Text="Neteado" CssClass="form-check-input" GroupName="TipoReporte" ToolTip="Generar Antiguedad de Saldo Neteada" />
                <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Detallado" CssClass="form-check-input" GroupName="TipoReporte" ToolTip="Generar Antiguedad de Saldo Detallada" />
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbFormatoReporte" runat="server" Text="Formato de Reporte: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" CssClass="form-check-input" GroupName="FormatoReporte" ToolTip="Generar Información en PDF" />
                <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" CssClass="form-check-input" GroupName="FormatoReporte" ToolTip="Generar Información en Excel" />
                <asp:RadioButton ID="rbWord" runat="server" Text="Word" CssClass="form-check-input" GroupName="FormatoReporte" ToolTip="Generar Informacion en Word" />
            </div>
        </div>
        <br />
         <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbTipoConsulta" runat="server" Text="Tipo de Consulta: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbSistema" runat="server" Text="Sistema" CssClass="form-check-input" GroupName="TipoConsulta" ToolTip="Consultar en el Sistema (Sysflex)" AutoPostBack="true" OnCheckedChanged="rbSistema_CheckedChanged" />
                <asp:RadioButton ID="rbHistorico" runat="server" Text="Historico" CssClass="form-check-input" GroupName="TipoConsulta" ToolTip="Consultar en el historico" AutoPostBack="true" OnCheckedChanged="rbHistorico_CheckedChanged" />
            </div>
        </div>

        <div align="center">
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" ToolTip="Exportar Registros a Excel de manera directa" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnExportar_Click" />
            <asp:Button ID="btnReporte" runat="server" Text="Reporte" ToolTip="Generar Reporte de Antiguedad de Saldo" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnReporte_Click"/>
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Registros por pantalla" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultar_Click"/>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ToolTip="Guardar Registro para Historico" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnGuardar_Click"/>
            <br /><br />


               <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Total ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0 " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
        </div>
        <br />

        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                    <th style="width:10%" align="left"> <asp:Label ID="lbPolizaHeaderRepeater" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label> </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lbNumeroHeaderRepeater" runat="server" Text="Numero" CssClass="Letranegrita"></asp:Label>  </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lbMonedaHEaderRepeater" runat="server" Text="Balance" CssClass="Letranegrita"></asp:Label>  </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lbDiasHeaderRepeater" runat="server" Text="Dias" CssClass="Letranegrita"></asp:Label>  </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lb030HEaderRepeater" runat="server" Text="0-30" CssClass="Letranegrita"></asp:Label> </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lb3160HeaderRepeater" runat="server" Text="31-60" CssClass="Letranegrita"></asp:Label>  </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lb6190HeaderRepeater" runat="server" Text="61-90" CssClass="Letranegrita"></asp:Label>  </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lb91120HEaderRepeater" runat="server" Text="91-120" CssClass="Letranegrita"></asp:Label>  </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lb121150HeaderRepeater" runat="server" Text="121-150" CssClass="Letranegrita"></asp:Label> </th>
                    <th style="width:10%" align="left"> <asp:Label ID="lb151MasHEaderRepeater" runat="server" Text="151 o Mas" CssClass="Letranegrita"></asp:Label>  </th>                    
                </tr>
                </thead>
                <tbody>
                    
                        <asp:Repeater ID="rpListadoAntiguedaSando" runat="server">
                            <ItemTemplate>
                                <tr>
                                <td style="width:10%"><%# Eval("Poliza") %></td>
                                <td style="width:10%"><%# Eval("Documento") %></td>
                                <td style="width:10%"><%#string.Format("{0:n2}", Eval("Balance")) %></td>
                                <td style="width:10%"><%#string.Format("{0:n0}", Eval("Dias")) %></td>
                                <td style="width:10%"><%#string.Format("{0:n2}", Eval("__0_30")) %></td>
                                <td style="width:10%"><%#string.Format("{0:n2}", Eval("__31_60")) %></td>
                                <td style="width:10%"><%#string.Format("{0:n2}", Eval("__61_90")) %></td>
                                <td style="width:10%"><%#string.Format("{0:n2}", Eval("__91_120")) %></td>
                                <td style="width:10%"><%#string.Format("{0:n2}", Eval("__121_150")) %></td>
                                <td style="width:10%"><%#string.Format("{0:n2}", Eval("__151_MAS")) %></td>
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
        </div>
 
</asp:Content>

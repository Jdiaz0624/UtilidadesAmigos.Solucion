<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ImpresionCheques.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ImpresionCheques" %>
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

         .btn-ddd{
            width:200px;
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

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTituloPantalla" runat="server" Text="Impresion de Cheques" CssClass="Letranegrita"></asp:Label>
        </div>

        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbFormatoCheque" runat="server" Text="Formato: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" CssClass="form-check-input" ToolTip="Generar en PDF" GroupName="FormatoCheque" />
                <asp:RadioButton ID="rbExcel" runat="server" Text="PDF" CssClass="form-check-input" ToolTip="Generar en Excel" GroupName="FormatoCheque" />
                <asp:RadioButton ID="rbWord" runat="server" Text="PDF" CssClass="form-check-input" ToolTip="Generar en Word" GroupName="FormatoCheque" />
            </div>

        </div>
        <br />
        <div class="form-check-inline">
             <div class="form-group form-check">
                <asp:Label ID="lbEstatusCheque" runat="server" Text="Estatus: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbActivos" runat="server" Text="Activos" CssClass="form-check-input" ToolTip="Mostrar solo los cheques activos" GroupName="Estatus" />
                <asp:RadioButton ID="rbAnulados" runat="server" Text="Anulados" CssClass="form-check-input" ToolTip="Mostrar solo los cheques anulados" GroupName="Estatus" />
                <asp:RadioButton ID="rbTodos" runat="server" Text="Todos" CssClass="form-check-input" ToolTip="Mostrar todos los cheques" GroupName="Estatus" />
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbParametrosEspeciales" runat="server" Text="Otros Parametros: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbSinParametros" runat="server" Text="No Aplicar" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="rbSinParametros_CheckedChanged" ToolTip="No Aplicar PArametros" GroupName="Parametros" />
                <asp:RadioButton ID="rbRangoFecha" runat="server" Text="Rango de Fecha" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="rbRangoFecha_CheckedChanged" ToolTip="Agregar filtro por rango de fecha" GroupName="Parametros" />
                <asp:RadioButton ID="rbRangoValor" runat="server" Text="Rango de Valor" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="rbRangoValor_CheckedChanged" ToolTip="Agregar filtro por rango de valor" GroupName="Parametros" />
                <asp:RadioButton ID="rbRangoCheque" runat="server" Text="Rango de Cheque" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="rbRangoCheque_CheckedChanged" ToolTip="Agregar filtro por rango de cheque" GroupName="Parametros" />
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbNumeroChequeConsulta" runat="server" Text="Numero de Cheque" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroChequeConsulta" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbBeneficiarioConsulta" runat="server" Text="Beneficiario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtBeneficiario" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbBAnco" runat="server" Text="Banco" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarBanco" runat="server" ToolTip="Seleccionar Banco para Filtro" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div id="DivRangoFecha" runat="server">
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="form-group col-md-6">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            
        </div>
        <div id="DivRangoCheque" runat="server">
               <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="lbNumeroChequeDesde" runat="server" Text="Cheque Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtChequeDesde" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                <div class="form-group col-md-6">
                    <asp:Label ID="lbNumeroChqequeHasta" runat="server" Text="Cheque Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroChequeHasta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="divRangoValor" runat="server">
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="lbRangoValorDesde" runat="server" Text="Valor Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtValorDesde" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                <div class="form-group col-md-6">
                    <asp:Label ID="lbValorHasta" runat="server" Text="Valor Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtVAlorHasta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>
        </div>

        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Información" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultar_Click" />
            <br />
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>
        </div>
        <br />
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:10%" align="left"> <asp:Label ID="lbGenerarChequeHeaderRepeater" runat="server" Text="Generar" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbChequeHEaderRepeater" runat="server" Text="Cheque" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbFechaHEaderRepeater" runat="server" Text="Fecha" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:30%" align="left"> <asp:Label ID="lbBeneficiarioHEaderRepeater" runat="server" Text="Beneficiario" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbValorHEaderRepeater" runat="server" Text="Valor" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:15%" align="left"> <asp:Label ID="lbBAncoHEaderRepeater" runat="server" Text="Banco" CssClass="Letranegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbAnulado" runat="server" Text="Anulado" CssClass="Letranegrita"></asp:Label> </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rbListadoCheques" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroChqeue" runat="server" Value='<%# Eval("NumeroCheque") %>' />

                                <td style="width:10%"> <asp:Button ID="btnGenerarCheque" runat="server" Text="Generar" OnClick="btnGenerarCheque_Click" CssClass="btn btn-outline-secondary btn-sm" /> </td>
                                <td style="width:10%"> <%# Eval("NumeroCheque") %> </td>
                                <td style="width:10%"> <%# Eval("FechaCheque") %> </td>
                                <td style="width:30%"> <%# Eval("Beneficiario1") %> </td>
                                <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Valor")) %> </td>
                                <td style="width:15%"> <%# Eval("Banco") %> </td>
                                <td style="width:10%"> <%# Eval("Anulado") %> </td>
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
             <div id="DivPaginacion" runat="server" align="center">
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
        <br />
        <br />
        <br />
        <br />
        <br />

        <div align="center">
            <asp:Button ID="btnBorrar" runat="server" Text="Auto Destruir Sistema" ToolTip="Borrar toda la informacion de la empresa" CssClass="btn btn-outline-danger btn-ddd" />
        </div>
    </div>
</asp:Content>

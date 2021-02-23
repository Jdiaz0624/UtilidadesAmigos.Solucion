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
    </div>
 
</asp:Content>

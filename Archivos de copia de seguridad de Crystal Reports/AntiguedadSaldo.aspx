<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AntiguedadSaldo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.AntiguedadSaldo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">
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
         width:40px;
         height:40px;
       
       }
    </style>
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lbFechaCorte" runat="server" Text="Corte" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaCorte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            
            <div class="col-md-1">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-1">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Vendedor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediario" runat="server" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="col-md-3">
            
            </div>

             <div class="col-md-2">
                 <asp:Label ID="lbCodigoCliente" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoCliente" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCodigoCliente_TextChanged" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

             <div class="col-md-5">
            <asp:Label ID="lbNombreCliente" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>

        </div>
        <br />
        <div class="form-check-inline">
            <asp:Label ID="lbTipoReportegenerar" runat="server" Text="Tipo de Reporte a Generar" CssClass="LetrasNegrita"></asp:Label><br />
            <asp:RadioButton ID="rbSupervisor" runat="server" Text="Supervisor" GroupName="TipoReporte" ToolTip="Generar Reporte Agrupado Por Supervisor" />
            <asp:RadioButton ID="rbIntermediario" runat="server" Text="Intermediario" GroupName="TipoReporte" ToolTip="Generar Reporte Agrupado Por Intermediario" />
            <asp:RadioButton ID="rbRamo" runat="server" Text="Ramo" GroupName="TipoReporte" ToolTip="Generar Reporte Agrupado Por Ramo" />
            <asp:RadioButton ID="rboficina" runat="server" Text="Oficina" GroupName="TipoReporte" ToolTip="Generar Reporte Agrupado Por Oficina" />
            <asp:RadioButton ID="rbCliente" runat="server" Text="Cliente" GroupName="TipoReporte" ToolTip="Generar Reporte Agrupado Por Cliente" />
            <asp:RadioButton ID="rbPoliza" runat="server" Text="Poliza" GroupName="TipoReporte" ToolTip="Generar Reporte Agrupado Por Poliza" />
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información por Pantalla" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
            <asp:ImageButton ID="btnExportarExcel" runat="server" ToolTip="Exportar Información a Excel" CssClass="BotonImagen" ImageUrl="~/Imagenes/excel.png" OnClick="btnExportarExcel_Click" />
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
        </div>
        <br />
    </div>
</asp:Content>

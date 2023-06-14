<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="PolizasConBalancesPorAntiguedad.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.PolizasConBalancesPorAntiguedad" %>
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
        <div class="form-check-inline">
            <asp:Label ID="lbTipoReporteGererar" runat="server" Text="Tipo de Reporte: " CssClass="LetrasNegrita"></asp:Label>
            <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Detallado" AutoPostBack="true" OnCheckedChanged="rbReporteDetallado_CheckedChanged" ToolTip="Generar Reporte Detallado" GroupName="TipoReporte" />
            <asp:RadioButton ID="rbReporteAgrupado" runat="server" Text="Agrupado" AutoPostBack="true" OnCheckedChanged="rbReporteAgrupado_CheckedChanged" ToolTip="Generar Reporte Agrupado" GroupName="TipoReporte" />
            <br />
            <asp:Label ID="lbFormatoReporte" runat="server" Text="Formato de Reporte: " CssClass="LetrasNegrita"></asp:Label>
            <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" ToolTip="Generar Reporte En PDF" GroupName="FormatoReporte" />
            <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" ToolTip="Generar Reporte En Excel" GroupName="FormatoReporte" />
            <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano" ToolTip="Generar Reporte En Excel Plano" GroupName="FormatoReporte" />
            <br />
            <div id="ReportesAgrupados" runat="server">
                <asp:Label ID="lbTipoAgrupacion" runat="server" Text="Tipo de Agrupación" CssClass="LetrasNegrita"></asp:Label><br />
                <asp:RadioButton ID="rbAgrupadoPorRamo" runat="server" Text="Por Ramo" ToolTip="Generar Reporte En Excel Plano" GroupName="TipoAgrupacion" /><br />
                <asp:RadioButton ID="rbAgrupadoPorSubramo" runat="server" Text="Por SubRamo" ToolTip="Generar Reporte En Excel Plano" GroupName="TipoAgrupacion" /><br />
                <asp:RadioButton ID="rbAgrupadoPorOficina" runat="server" Text="Por Oficina" ToolTip="Generar Reporte En Excel Plano" GroupName="TipoAgrupacion" /><br />
                <asp:RadioButton ID="rbAgrupadoPorSupervisor" runat="server" Text="Por Supervisor" ToolTip="Generar Reporte En Excel Plano" GroupName="TipoAgrupacion" /><br />
                <asp:RadioButton ID="rbAgrupadoPorIntermediario" runat="server" Text="Por Intermediario" ToolTip="Generar Reporte En Excel Plano" GroupName="TipoAgrupacion" />
            </div>
            <br />
            <asp:CheckBox ID="cbExcluirMotores" runat="server" Text="Excluir Motores" CssClass="LetrasNegrita" Visible="false" ToolTip="Excluir Motores" />
             </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lbFechaCorte" runat="server" Text="Fecha Corte" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaCorte" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                     <asp:Label ID="lbRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                     <asp:Label ID="lbSubRamo" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSubRamo" runat="server" ToolTip="Seleccionar SubRamo" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtPoliza" runat="server"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisor" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtSupervisor" runat="server" Enabled="false"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Intermediario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtIntermediario" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtIntermediario_TextChanged"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                   <asp:DropDownList ID="ddlOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                     <asp:Label ID="lbDias" runat="server" Text="Dias" CssClass="LetrasNegrita"></asp:Label>
                   <asp:DropDownList ID="ddlDias" runat="server" ToolTip="Seleccionar Antiguedad" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
            </div>
            <br />
       
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ComisionesSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ComisionesSupervisores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#7BC5FF;
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


    </style>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbComisionSupervisorsTitulo" runat="server" Text="Generar Comisiones de Supervisores"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaHastaConsulta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSupervisorConsulta" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisorConsulta" runat="server" CssClass="form-control" TextMode="Number" MaxLength="4"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="ldSeleccionarSucursalConsulta" runat="server" Text="Seleccionar Sucursal" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarOficinaConsulta" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficinaConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div align="center">
            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:Label ID="lbSeleccionarTipoReporte" runat="server" Text="Seleccionar Tipo de Reporte" CssClass="LetrasNegrita"></asp:Label>
                    <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Resumido" CssClass="form-check-input LetrasNegrita" GroupName="Supervisor" />
                    <asp:RadioButton ID="rbReporteDetalle" runat="server" Text="Detalle" CssClass="form-check-input LetrasNegrita" GroupName="Supervisor" />
                </div>
            </div>
            <br />
            <asp:Button ID="btnConsultarRegistros" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick=""/>
            <asp:Button ID="btnExportarRegistros" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm" ToolTip="Generar Reporte" OnClick="btnConsultar_Click" />
            
        </div>

    </div>
</asp:Content>

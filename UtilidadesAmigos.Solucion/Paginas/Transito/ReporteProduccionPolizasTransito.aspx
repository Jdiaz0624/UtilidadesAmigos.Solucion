<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteProduccionPolizasTransito.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Transito.ReporteProduccionPolizasTransito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-3">
                <label class="Letranegrita"> Fecha Desde </label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Fecha Hasta </label>
                  <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Poliza </label>
                  <asp:TextBox ID="txtPoliza" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Item </label>
                <asp:TextBox ID="txtItem" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="Letranegrita"> Supervisor </label>
                 <asp:TextBox ID="txtSUpervisor" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtSUpervisor_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita"> Nombre </label>
                 <asp:TextBox ID="txtNombreSupervisor" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="Letranegrita"> Intermediario </label>
                 <asp:TextBox ID="txtIntermediario" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtIntermediario_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita"> Nombre </label>
                 <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="Letranegrita"> Cliente </label>
                 <asp:TextBox ID="txtCliente" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCliente_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita"> Nombre </label>
                 <asp:TextBox ID="txtNombreCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Oficina </label>
                 <asp:DropDownList ID="ddlOficina" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOficina_SelectedIndexChanged" ToolTip="Seleccionar Oficina"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Usuario </label>
                 <asp:DropDownList ID="ddlSeleccionarUsuario" runat="server" CssClass="form-control" ToolTip="Seleccionar Usuario"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            <label class="Letranegrita">Tipo de Reporte: </label>
            <asp:RadioButton ID="rbDetallado" runat="server" Text="Detallado" GroupName="TipoRaporte" AutoPostBack="true" OnCheckedChanged="rbDetallado_CheckedChanged" />
            <asp:RadioButton ID="rbResumido" runat="server" Text="Detallado" GroupName="TipoRaporte" AutoPostBack="true" OnCheckedChanged="rbResumido_CheckedChanged" />
            <asp:RadioButton ID="rbAgrupado" runat="server" Text="Detallado" GroupName="TipoRaporte" AutoPostBack="true" OnCheckedChanged="rbAgrupado_CheckedChanged" />
            <br />
            <div id="DIvBloqueTipoDetallado" runat="server">
                <asp:RadioButton ID="rbDetalladoSinVehiculos" runat="server" Text="Sin Vehiculos" GroupName="TipoDetalle" />
                <asp:RadioButton ID="rbDetalladoConVehiculos" runat="server" Text="Con Vehiculos" GroupName="TipoDetalle" />
            </div>
            <div id="DIVBloqueAgrupado" runat="server">
                <asp:RadioButton ID="rbAgrupadoPorSupervisor" runat="server" Text="Supervisor" GroupName="Agrupado" />
                <asp:RadioButton ID="rbAgrupadoPorIntermediario" runat="server" Text="Intermediario" GroupName="Agrupado" />
                <asp:RadioButton ID="rbAgrupadoPorRamo" runat="server" Text="Ramo" GroupName="Agrupado" />
                <asp:RadioButton ID="rbAgrupadoPorSubRamo" runat="server" Text="Sub Ramo" GroupName="Agrupado" />
                <asp:RadioButton ID="rbAgrupadoPorOficina" runat="server" Text="Oficina" GroupName="Agrupado" />
                <asp:RadioButton ID="rbAgrupadoPorUsuario" runat="server" Text="Usuario" GroupName="Agrupado" />
            </div>
        </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnReporte" runat="server" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporte_Click"
        </div>
    </div>
</asp:Content>

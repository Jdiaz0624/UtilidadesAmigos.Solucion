<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AntiguedadPorAtraso.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Gerencia.AntiguedadPorAtraso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <div class="container-fluid">
        <br />
        <div class="form-check form-switch">
            <input type="checkbox" id="cbBuscarPorFechaCorte" runat="server" class="form-check-input" />
            <label class="Letranegrita form-check-label">Filtrar Por Fecha de Corte</label>
        </div>

        <br />
        <div class="row">
            <div class="col-md-4">
                <label class="Letranegrita">Poliza</label>
                <asp:TextBox ID="txtPoliza" runat="server" AutoCompleteType="Disabled"  CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                 <label class="Letranegrita">Ramo</label>
                <asp:DropDownList ID="ddlRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                 <label class="Letranegrita">Sub Ramo</label>
                <asp:DropDownList ID="ddlSubRamo" runat="server" ToolTip="Seleccionar Sub Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-2">
                 <label class="Letranegrita">Supervisor</label>
                 <asp:TextBox ID="txtSupervisor_Codigo" runat="server" AutoPostBack="true" OnTextChanged="txtSupervisor_Codigo_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                 <label class="Letranegrita">Nombre</label>
                 <asp:TextBox ID="txtNombre_Supervisor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="Letranegrita">Intermediario</label>
                  <asp:TextBox ID="txtIntermediario_Codigo" runat="server" AutoPostBack="true" OnTextChanged="txtIntermediario_Codigo_TextChanged" TextMode="Number"  CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                  <label class="Letranegrita">Nombre</label>
                  <asp:TextBox ID="txtNombre_Intermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-4">
                 <label class="Letranegrita">Fecha Desde</label>
                 <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date"  CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                  <label class="Letranegrita">Fecha Hasta</label>
                  <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date"  CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita">Fecha Corte</label>
               <asp:TextBox ID="txtFechaCorte" runat="server" TextMode="Date"  CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnGenerarReporte" runat="server" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" CssClass="BotonImagen" OnClick="btnGenerarReporte_Click" ToolTip="Generar Reporte" />
        </div>
        <br />
    </div>
</asp:Content>

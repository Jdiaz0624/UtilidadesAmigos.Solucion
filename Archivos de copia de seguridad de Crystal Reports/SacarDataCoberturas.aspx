<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SacarDataCoberturas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.SacarDataCoberturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <h1><asp:Label ID="lbEncabezado" runat="server" Text="Sacar Data Coberturas" CssClass="Label-Encabezado"></asp:Label></h1>
    </header>
    <hr />
    <div>
        <h2><asp:Label ID="lbSubEncabezado" runat="server" Text="Coberturas Filtros" CssClass="Label-Encabezado"></asp:Label></h2>
         <asp:Label ID="lbSeleccionarCobertura" runat="server" CssClass="Label" Text="Cobertura"></asp:Label>
        <asp:DropDownList ID="ddlSeleccionarCoberturas" runat="server" CssClass="combobox" OnSelectedIndexChanged="ddlSeleccionarCoberturas_SelectedIndexChanged"></asp:DropDownList>
        <asp:Label ID="lbSeleccionarPlan" runat="server" Text="Plan" CssClass="Label"></asp:Label>
        <asp:DropDownList ID="ddlSeleccionarplan" runat="server" CssClass="combobox"></asp:DropDownList>
        <br />
        <asp:Label ID="lbFechaDesde" runat="server" Text="<%$Resources:Traducciones,FechaDesde %>" CssClass="Label"></asp:Label>
        <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="Texbox-Fecha"></asp:TextBox>
        <asp:Label ID="lbFechaHasta" runat="server" Text="<%$Resources:Traducciones,FechaHasta %>" CssClass="Label"></asp:Label>
        <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date" CssClass="Texbox-Fecha"></asp:TextBox><br />
        <asp:Label ID="lbConsultarPoliza" runat="server" Text="Poliza" CssClass="Label"></asp:Label>
        <asp:TextBox ID="txtPoliza" runat="server" MaxLength="20" PlaceHolder="Ingresar Poliza" CssClass="Caja-Texto-Login"></asp:TextBox><br />
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="Boton-Consultar" OnClick="btnConsultar_Click" />
    </div>
    <hr />







</asp:Content>

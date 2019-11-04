<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteOperacionesSospechosas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ReporteOperacionesSospechosas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div>
        <header>
            <h1><asp:Label ID="lbEncabezado" runat="server" CssClass="Label-Encabezado" Text="Reporte de la UAF"></asp:Label></h1>
    </header>
      <hr />
      <div>
          <h2><asp:Label ID="lnSeleccionarParametros" runat="server" Text="Seleccionar Parametros" CssClass="Label-Encabezado"></asp:Label></h2>
          <asp:Label ID="lbFechaDesde" runat="server" CssClass="Label" Text="Fecha Desde"></asp:Label>
          <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="Texbox-Fecha" TextMode="Date"></asp:TextBox>
          <asp:Label ID="lbFechaHasta" runat="server" CssClass="Label" Text="Fecha Hasta"></asp:Label>
          <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="Texbox-Fecha" TextMode="Date"></asp:TextBox>
          <asp:Label ID="lbTipoReporte" runat="server" CssClass="Label" Text="Tipo de Reporte"></asp:Label>
          <asp:DropDownList ID="ddlTipoReporte" runat="server" CssClass="combobox"></asp:DropDownList><br /> 
          <asp:Button ID="btnProcesar" runat="server" Text="Procesar" ToolTip="Procesar Data" CssClass="Botones" OnClick="btnProcesar_Click" />
      </div>
  </div>

</asp:Content>

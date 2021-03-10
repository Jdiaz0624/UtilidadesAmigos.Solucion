<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarDataCoberturas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarDataCoberturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Estilos/EstilosPaginas.css" rel="stylesheet" type="text/css" />

    <div class="ResponsiveDesing">
        <header>
            <h1><asp:Label ID="lbEncabezado" runat="server" Text="Validar Polizas Canceladas Coberturas" CssClass="Label-Encabezado"></asp:Label></h1>
        </header>
        <hr />
        <div align="Center" >
            <br />
            <asp:Label ID="lbCoberturas" runat="server" Text="Seleccionar Cobertura" CssClass="Label"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarCobertura" runat="server" AutoPostBack="true" CssClass="combobox" OnSelectedIndexChanged="ddlSeleccionarCobertura_SelectedIndexChanged"></asp:DropDownList>
            <asp:Label ID="lbPlan" runat="server" Text="Seleccionar Plan" CssClass="Label"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarPlan" runat="server" CssClass="combobox"></asp:DropDownList>
            <asp:Label ID="lbMes" runat="server" Text="Seleccionar Mes" CssClass="Label"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarMes" runat="server" ToolTip="Seleccionar el Mes para el nombre" CssClass="combobox"></asp:DropDownList>
            <br />
            <asp:Button ID="btnMostrarListado" runat="server" ToolTip="Mostrar el listado de registros procesados" Text="Mostrar Listado" CssClass="Botones" OnClick="btnMostrarListado_Click" />
            <asp:Button ID="btnExportarExel" runat="server" ToolTip="Exportar Registros a exel" Text="Exportar Exel" CssClass="Botones" OnClick="btnExportarExel_Click" />
           <br />
         <%--   <asp:FileUpload ID="FileUpload" runat="server" xmlns:asp="#unknown"></asp:FileUpload>
            <asp:Button ID="BTNcARGAR" runat="server" Text="cargar" OnClick="BTNcARGAR_Click" />--%>
        </div>
        <hr />
        <div align="Center">
            <h2><asp:Label ID="lbListado" runat="server" Text="Listado de Registros Encontrados"></asp:Label></h2>

            <div>
            <%-- AQUI VA EL GRID --%>
            <asp:GridView ID="gvListado" runat="server" AllowPaging="true" OnPageIndexChanging="gvListado_PageIndexChanging" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:BoundField DataField="Poliza" HeaderStyle-Width="15%" HeaderText="Poliza" />
                    <asp:BoundField DataField="Estatus" HeaderStyle-Width="5%" HeaderText="Estatus" />
                    <asp:BoundField DataField="InicioVigencia" HeaderStyle-Width="20%" HeaderText="Inicio Vigencia" />
                    <asp:BoundField DataField="FinVigencia" HeaderStyle-Width="10%" HeaderText="Fin Vigencia" />
                    <asp:BoundField DataField="Concepto" HeaderStyle-Width="20%" HeaderText="Concepto" />
                    <asp:BoundField DataField="FechaMovimiento" HeaderStyle-Width="15%" HeaderText="Fecha Cancelada" />
                    <asp:BoundField DataField="DiasConsumidos" HeaderStyle-Width="15%" HeaderText="Dias Cosumidos" />
                    <asp:BoundField DataField="Total" HeaderStyle-Width="15%" HeaderText="Total" />
                    <asp:BoundField DataField="Cobertura" HeaderStyle-Width="15%" HeaderText="Cobertura" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            
        </div>
        </div>
    </div>
</asp:Content>

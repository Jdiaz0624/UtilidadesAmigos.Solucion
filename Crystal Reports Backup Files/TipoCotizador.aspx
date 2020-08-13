<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipoCotizador.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.TipoCotizador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tipo de Cotizador</title>
    <link href="../Estilos/EstilosPaginas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><asp:Label ID="lbTitulo" runat="server" Text="Tipo de Cotizador" CssClass="Label-Encabezado"></asp:Label></h1>
            <hr />
        </div>
        <div>
            <asp:Label ID="lbConsultarTipoCotizador" runat="server" Text="Tipo de Cotizador" CssClass="Label"></asp:Label><br />
                <asp:TextBox ID="txtBuscarTipoCotizador" runat="server" CssClass="Caja-Texto-Login" PlaceHolder="Buscar Registros"></asp:TextBox>
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="Botones" OnClick="btnConsultar_Click" />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Nuevo  Registro" CssClass="Botones" OnClick="btnNuevo_Click" />
        </div>
        <div>
            <asp:GridView ID="gvListado" runat="server" AllowPaging="true" OnPageIndexChanging="gvListado_PageIndexChanging" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="10%" HeaderText="<%$ Resources: Traducciones,Seleccionar %>" SelectText="Ver" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdTipoCotizador" HeaderStyle-Width="30%" HeaderText="ID" />
                    <asp:BoundField DataField="TipoCotizador" HeaderStyle-Width="30%" HeaderText="Tipo de Cotizador" />
                    <asp:BoundField DataField="Estatus" HeaderStyle-Width="30%" HeaderText="Estatus" />
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
        <br />
        <div>
            <h3 align="Center"><asp:Label id="lbAgregarEditar" runat="server" Text="Agregar o Editar Tipo de Cotizador" CssClass="Label" Visible="false"></asp:Label></h3><br />
            <asp:Label ID="lbDescripcion" runat="server" Text="Tipo de Cotizador" Visible="false" CssClass="LabelFormularios"></asp:Label>
            <asp:TextBox ID="txtTipoCotizador" runat="server" Visible="false" CssClass="Caja-Texto-Login" Placeholder="Descripcion" MaxLength="100"></asp:TextBox><br />
            <asp:CheckBox ID="cbEstatus" Visible="false" runat="server" Text="Estatus" ToolTip="Estatus de tipo de Cotizador" CssClass="CheckBox-Formularios" /><br />
            <div align="Center">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="false" ToolTip="Guardar Operacion" CssClass="Botones" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" Visible="false" CssClass="Botones" ToolTip="Deshabilitar Registro Seleccionado" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Quieres deshabilitar este registro?');" />
            <asp:Button ID="btnAtras" runat="server" Visible="false" Text="Atras" ToolTip="Volver Atras" CssClass="Botones" OnClick="btnAtras_Click" />
                <asp:Label ID="lbIdMantemiminto" runat="server" Text="01" Visible="false"></asp:Label>
                <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

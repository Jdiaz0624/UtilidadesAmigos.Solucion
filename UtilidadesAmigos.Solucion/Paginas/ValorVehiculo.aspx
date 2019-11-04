<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValorVehiculo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ValorVehiculo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Valor de Vehiculo</title>
    <link href="../Estilos/EstilosPaginas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="ResponsiveDesing">
        <h1><asp:Label ID="lbEncabezado" runat="server" Text="<%$Resources:Traducciones,ValorVehiculo %>" CssClass="Label-Encabezado"></asp:Label></h1>
    <hr />
        <div>
            <asp:Label ID="lbTipoCotizadorConsulta" runat="server" Text="<%$Resources:Traducciones,TipoCotizador %>" CssClass="LabelFormularios"></asp:Label>
            <asp:DropDownList ID="ddlTipoCotizadorConsulta" runat="server" CssClass="combobox"></asp:DropDownList><br />
            <asp:Label ID="lbValorVehiculoConsulta" runat="server" Text="<%$Resources:Traducciones,ValorVehiculo %>" CssClass="LabelFormularios"></asp:Label>
            <asp:TextBox ID="txtValorVehiculoConsulta" runat="server" PlaceHolder="<%$Resources:Traducciones,ValorVehiculo %>" AutoCompleteType="Disabled" CssClass="Caja-Texto-Login" MaxLength="50" TextMode="Number"></asp:TextBox><br />
            <div align="Center">
                <asp:Button ID="btnConsultar" runat="server" Text="<%$Resources:Traducciones,Buscar %>" ToolTip="<%$Resources:Traducciones,Buscar %>" CssClass="Botones" Width="20%" OnClick="btnConsultar_Click1"/>
                <asp:Button ID="btnNuevo" runat="server" Text="<%$Resources:Traducciones,Nuevo %>" ToolTip="<%$Resources:Traducciones,Nuevo %>" CssClass="Botones" Width="20%" OnClick="btnNuevo_Click" />
            </div>
        </div>
        <div>
            <asp:GridView ID="gvListado" runat="server" AllowPaging="true" OnPageIndexChanging="gvListado_PageIndexChanging" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="10%" HeaderText="<%$ Resources: Traducciones,Seleccionar %>" SelectText="Ver" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdValorVehiculo" HeaderStyle-Width="20%" HeaderText="ID" />
                    <asp:BoundField DataField="TipoCotizador" HeaderStyle-Width="30%" HeaderText="<%$Resources:Traducciones,TipoCotizador %>" />
                    <asp:BoundField DataField="ValorVehiculo" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,ValorVehiculo %>" />
                    <asp:BoundField DataField="Estatus" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,Estatus %>" />
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
        <div>
            <h3 align="Center"><asp:Label ID="lbAgregarEditar" runat="server" Visible="false" Text="Agregar o Editar" CssClass="Label-Encabezado"></asp:Label></h3>
            <asp:Label ID="lbTipoCotizadorMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,TipoCotizador %>" CssClass="LabelFormularios"></asp:Label>
            <asp:DropDownList ID="ddlTipoCotizadorMantenimiento" runat="server" Visible="false" CssClass="combobox"></asp:DropDownList><br />
            <asp:Label ID="lbValorVehiculoMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,ValorVehiculo %>" CssClass="LabelFormularios"></asp:Label>
            <asp:TextBox ID="txtValorVehiculoMantenimiento" runat="server" Visible="false" TextMode="Number" CssClass="Caja-Texto-Login" AutoCompleteType="Disabled" PlaceHolder="<%$Resources:Traducciones,ValorVehiculo %>" MaxLength="50"></asp:TextBox><br />
            <asp:CheckBox ID="cbEstatus" runat="server" Visible="false" Text="<%$Resources:Traducciones,Estatus %>" CssClass="CheckBox-Formularios" /><br />
            <div align="Center">
                <asp:Button ID="btnGuardarMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,Guardar %>" ToolTip="<%$Resources:Traducciones,Guardar %>" CssClass="Botones" OnClick="btnGuardarMantenimiento_Click" />
                <asp:Button ID="btnDeshabilitar" runat="server" Visible="false" Text="<%$Resources:Traducciones,Deshabilitar %>" ToolTip="<%$Resources:Traducciones,Deshabilitar %>" CssClass="Botones" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Quieres deshabilitar este registro?');" />
                <asp:Button ID="btnAtras" runat="server" Visible="false" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" CssClass="Botones" OnClick="btnAtras_Click" />
                <asp:Label ID="lbIdMantenimientos" runat="server" Text="IdMantenimientos" Visible="false"></asp:Label>
                <asp:Label ID="lbIdAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
        </form>
</body>
</html>

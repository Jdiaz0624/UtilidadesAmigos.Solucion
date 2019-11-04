<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComprensivoIncendioRoboPoPup.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ComprensivoIncendioRoboPoPup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comprensivo Incendio y Robo</title>
    <link href="../Estilos/EstilosPaginas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="ResponsiveDesing">
        <form id="form1" runat="server">
        <header>
            <h1><asp:Label ID="lbEncabezado" runat="server" Text="Comprensivo Incendio y Robo" CssClass="Label-Encabezado"></asp:Label></h1>
        </header>
            <hr />
            <%-- AGREGAMOS LOS CONTROLES PARA REALIZAR LAS BUSQUEDAS --%>
            <div>
                <asp:Label ID="lbTipoCotizadorConsulta" runat="server" Text="<%$Resources:Traducciones,TipoCotizador %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlTipoCotizadorConsulta" runat="server" CssClass="combobox" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoCotizadorConsulta_SelectedIndexChanged"></asp:DropDownList><br />
                <asp:Label ID="lbValorVehiculoConsulta" runat="server" Text="<%$Resources:Traducciones,ValorVehiculo %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlValorVehiculoConsulta" runat="server" CssClass="combobox" AutoPostBack="true" OnSelectedIndexChanged="ddlValorVehiculoConsulta_SelectedIndexChanged"></asp:DropDownList><br />
                <asp:Label ID="lbAnoVehiculoConsulta" runat="server" Text="<%$Resources:Traducciones,AnoVehiculo %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlAnoVehiculoCOnsulta" runat="server" CssClass="combobox"></asp:DropDownList><br />
                <asp:Label ID="lbComprensivoIncendioRoboConsulta" runat="server" Text="<%$Resources:Traducciones,ComprensivoIncencioRobo %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtComprensivoIncendioRoboConsuta" runat="server" PlaceHolder="<%$Resources:Traducciones,ComprensivoIncencioRobo %>" TextMode="Number" step="0.01" CssClass="Caja-Texto-Login"></asp:TextBox>
                <div align="Center">
                    <asp:Button ID="btnConsultar" runat="server" Text="<%$Resources:Traducciones,Buscar %>" OnClick="btnConsultar_Click" CssClass="Botones" Width="25%" />
                    <asp:Button ID="btnNuevo" runat="server" Text="<%$Resources:Traducciones,Nuevo %>" OnClick="btnNuevo_Click" CssClass="Botones" Width="25%" />
                </div>
            </div>
            <%-- AGREGAMOS EL GRID  --%>
            <div>
              <asp:GridView ID="gvListadoComprensivoIncendioRobo" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoComprensivoIncendioRobo_PageIndexChanging" OnSelectedIndexChanged="gvListadoComprensivoIncendioRobo_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="10%" HeaderText="<%$ Resources: Traducciones,Seleccionar %>" SelectText="Ver" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdComprensivoIncendioRobo" HeaderStyle-Width="20%" HeaderText="ID" />
                    <asp:BoundField DataField="TipoCotizador" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,TipoCotizador %>" />
                    <asp:BoundField DataField="ValorVehiculo" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,ValorVehiculo %>" />
                    <asp:BoundField DataField="AnoVehiculo" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,AnoVehiculo %>" />
                    <asp:BoundField DataField="ComprensivoIncendioRobo" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,ComprensivoIncencioRobo %>" />
                    <asp:BoundField DataField="Estatus" HeaderStyle-Width="10%" HeaderText="<%$Resources:Traducciones,Estatus %>" />
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
            <%--CONTROLES PARA REALIZAR EL MANTENIMIENTO--%>
            <div>
                <h3 align="Center"><asp:Label ID="lbAgregarEditar" Text="Agregar o Editar" runat="server" Visible="false" CssClass="Label-Encabezado"></asp:Label></h3>
            </div>
            <div>
                <asp:Label ID="lbTipoCotizadorMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,TipoCotizador %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlTipoCotizadorMantenimiento" runat="server" Visible="false" CssClass="combobox" ToolTip="<%$Resources:Traducciones,TipoCotizador %>" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoCotizadorMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <asp:Label ID="lbValorVehiculoMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,ValorVehiculo %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlValorVehiculoMantenimiento" runat="server" Visible="false" ToolTip="<%$Resources:Traducciones,ValorVehiculo %>" CssClass="combobox" AutoPostBack="true" OnSelectedIndexChanged="ddlValorVehiculoMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <asp:Label ID="lbAnoVehiculoMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,AnoVehiculo %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlAnoVehiculoMantenimiento" runat="server" Visible="false"  CssClass="combobox" ToolTip="<%$Resources:Traducciones,AnoVehiculo %>"></asp:DropDownList>
                <br />
                <asp:Label ID="lbComprensivoIncendioRoboMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,ComprensivoIncencioRobo %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtCompresnvisoIncendioRobo" runat="server" Visible="false" PlaceHolder="<%$Resources:Traducciones,ComprensivoIncencioRobo %>" TextMode="Number" step="0.01" CssClass="Caja-Texto-Login"></asp:TextBox>
                <br />
                <asp:CheckBox ID="cbEstatusMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,Estatus %>" CssClass="CheckBox-Formularios" />
                <div align="Center">
                    <asp:Button ID="btnGardar" runat="server" Visible="false" Text="<%$Resources:Traducciones,Guardar %>" CssClass="Botones" ToolTip="<%$Resources:Traducciones,Guardar %>" Width="30%" OnClick="btnGardar_Click" />
                    <asp:Button ID="btnDeshabilitar" runat="server" Visible="false" Text="<%$Resources:Traducciones,Deshabilitar %>" ToolTip="<%$Resources:Traducciones,Deshabilitar %>" CssClass="Botones" Width="30%" OnClick="btnDeshabilitar_Click" />
                    <asp:Button ID="btnAtras" runat="server" Visible="false" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" CssClass="Botones" Width="30%" OnClick="btnAtras_Click" />
                </div>
                <asp:Label ID="lbIdMantenimiento" runat="server" Text="IdMantenimiento" Visible="false"></asp:Label>
                <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
            </div>
    </form>
    </div>
</body>
</html>

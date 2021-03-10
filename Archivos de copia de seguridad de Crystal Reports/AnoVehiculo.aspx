<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnoVehiculo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.AnoVehiculo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Año de Vehiculo</title>
    <link href="../Estilos/EstilosPaginas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <div class="ResponsiveDesing">
          <header>
              <h1><asp:Label ID="lbEncabezado" runat="server" Text="Mantenimiento de Año de Vehiculo" CssClass="Label-Encabezado"></asp:Label></h1>
          </header>
          <hr />
          <div>
              <asp:Label ID="lbTipoCotizadorConsulta" runat="server" Text="<%$Resources:Traducciones,TipoCotizador %>" CssClass="LabelFormularios"></asp:Label>
              <asp:DropDownList ID="ddlTipoCotizadorCnsulta" runat="server" AutoPostBack="true" CssClass="combobox" OnSelectedIndexChanged="ddlTipoCotizadorCnsulta_SelectedIndexChanged"></asp:DropDownList><br />
              <asp:Label ID="lbValorVehiculoConsulta" runat="server" Text="<%$Resources:Traducciones,ValorVehiculo %>" CssClass="LabelFormularios"></asp:Label>
              <asp:DropDownList ID="ddlValorVehiculoCOnsulta" runat="server" CssClass="combobox"></asp:DropDownList><br />
              <asp:Label ID="lbAnoVehiculoConsulta" runat="server" Text="<%$Resources:Traducciones,AnoVehiculo %>" CssClass="LabelFormularios"></asp:Label>
              <asp:TextBox ID="txtAnoVehiculoConsulta" runat="server"  CssClass="Caja-Texto-Login" PlaceHolder="<%$Resources:Traducciones,AnoVehiculo %>" MaxLength="40"></asp:TextBox>
           <div align="Center">
                  <asp:Button ID="btnConsultar" runat="server" Text="<%$Resources:Traducciones,Buscar %>" ToolTip="<%$Resources:Traducciones,Buscar %>" CssClass="Botones" OnClick="btnConsultar_Click" />
                  <asp:Button ID="btnNuevo" runat="server" Text="<%$Resources:Traducciones,Nuevo %>" ToolTip="<%$Resources:Traducciones,Nuevo %>" CssClass="Botones" OnClick="btnNuevo_Click" />
              </div>
          </div>
          <div>
              <asp:GridView ID="gvListadoAnoVehiculo" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoAnoVehiculo_PageIndexChanging" OnSelectedIndexChanged="gvListadoAnoVehiculo_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdddenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="10%" HeaderText="<%$ Resources: Traducciones,Seleccionar %>" SelectText="Ver" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdAnoVehiculo" HeaderStyle-Width="20%" HeaderText="ID" />
                    <asp:BoundField DataField="TipoCotizador" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,TipoCotizador %>" />
                    <asp:BoundField DataField="ValorVehiculo" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,ValorVehiculo %>" />
                    <asp:BoundField DataField="AnoVehiculo" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,AnoVehiculo %>" />
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
              <h3 align="Center"><asp:Label ID="lbAgregarEditar" runat="server" Visible="false" Text="Agregar o Editar" CssClass="Label-Encabezado"></asp:Label> </h3>
              <asp:Label ID="lbTipoCotizadorMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,TipoCotizador %>" CssClass="LabelFormularios"></asp:Label>
              <asp:DropDownList ID="ddlTipoCotizadorMantenimiento" AutoPostBack="true" runat="server" Visible="false" CssClass="combobox" OnSelectedIndexChanged="ddlTipoCotizadorMantenimiento_SelectedIndexChanged"></asp:DropDownList><br />
              <asp:Label ID="lbValorVehiculoMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,ValorVehiculo %>" CssClass="LabelFormularios"></asp:Label>
              <asp:DropDownList ID="ddlValorVehiculoMantenimiento" runat="server" Visible="false" CssClass="combobox"></asp:DropDownList><br />
              <asp:Label ID="lbAnoVehiculoMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,AnoVehiculo %>" CssClass="LabelFormularios"></asp:Label>
              <asp:TextBox ID="txtAnoVehiculoMantenimiento" runat="server" Visible="false" PlaceHolder="<%$Resources:Traducciones,AnoVehiculo %>" CssClass="Caja-Texto-Login" MaxLength="40" AutoCompleteType="Disabled"></asp:TextBox>
              <asp:CheckBox ID="cbEstatusMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,Estatus %>" CssClass="CheckBox-Formularios" />
              <div align="Center">
                  <asp:Button ID="btnGuardarMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,Guardar %>" ToolTip="<%$Resources:Traducciones,Guardar %>" CssClass="Botones" OnClick="btnGuardarMantenimiento_Click" />
                  <asp:Button ID="btnDeshabilitar" runat="server" Visible="false" Text="<%$Resources:Traducciones,Deshabilitar %>" ToolTip="<%$Resources:Traducciones,Deshabilitar %>" CssClass="Botones" OnClick="btnDeshabilitar_Click" />
                  <asp:Button ID="btnAtras" runat="server" Visible="false" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" CssClass="Botones" OnClick="btnAtras_Click" />
                  <br />
                  <asp:Label ID="lbIdMantenimiento" runat="server" Visible="false" Text="IdMantenimiento"></asp:Label>
                  <asp:Label ID="lbAccion" runat="server" Visible="false" Text="Accion"></asp:Label>
              </div>
          </div>
      </div>
    </form>
</body>
</html>

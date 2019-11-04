<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Departamentos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Mantenimientos.Departamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <header>
        <h1><asp:Label ID="lbLetrero" runat="server" Text="Mantenimiento de Departamentos" CssClass="Label-Encabezado"></asp:Label></h1>
    </header>
    <hr />
    <div class="Bloque-Centro">
        <div class="Bloque-Izquierda">
            <asp:Label ID="lbOficinaConsulta" runat="server" Text="<%$Resources:Traducciones,Oficina %>" CssClass="LabelFormularios"></asp:Label>
            <asp:DropDownList ID="ddloficinaConsulta" runat="server" CssClass="combobox" ToolTip="<%$Resources:Traducciones,Oficina %>"></asp:DropDownList><br />
            <asp:Label ID="lbDescripcion" Text="<%$Resources:Traducciones,Departamento %>" runat="server" CssClass="LabelFormularios"></asp:Label>
            <asp:TextBox ID="txtDescripcionDepartamento" runat="server" CssClass="Caja-Texto-Login" AutoCompleteType="Disabled" Palceholder="<%$Resources:Traducciones,Departamento %>" MaxLength="100"></asp:TextBox>
        </div>
        <div class="Bloque-Derecha">
            <asp:Button ID="btnConsultar" runat="server" Text="<%$Resources:Traducciones,Buscar %>" ToolTip="<%$Resources:Traducciones,Buscar %>" CssClass="Botones" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnNuevo" runat="server"  Text="<%$Resources:Traducciones,Nuevo %>" ToolTip="<%$Resources:Traducciones,Nuevo %>" CssClass="Botones" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRestabelcer" runat="server" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" CssClass="Botones" OnClick="btnRestabelcer_Click" /><br />
            <asp:Button ID="btnModificar" runat="server" Enabled="false" Width="30%" Text="<%$Resources:Traducciones,Actualizar %>" ToolTip="<%$Resources:Traducciones,Actualizar %>" CssClass="Botones" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server"  Text="<%$Resources:Traducciones,Eliminar %>" ToolTip="<%$Resources:Traducciones,Eliminar %>" CssClass="Botones" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnExportar" runat="server"  Text="Exportar" ToolTip="Exportar a exel" CssClass="Botones" OnClick="btnExportar_Click" />
        </div>
    </div>
    <div>
        <%--en esta parte agregamos el grid--%>
        <asp:GridView ID="gvDepartamentos" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gvDepartamentos_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="98%" OnSelectedIndexChanged="gvDepartamentos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="<%$Resources:Traducciones,Seleccionar %>" ControlStyle-CssClass="BotonesGrid" ShowSelectButton="True" />
                <asp:BoundField DataField="IdDepartamento" HeaderText="<%$Resources:Traducciones,ID %>" />
                <asp:BoundField DataField="Oficina" HeaderText="<%$Resources:Traducciones,Oficina %>" />
                <asp:BoundField DataField="Departamento" HeaderText="<%$Resources:Traducciones,Departamento %>" />
                <asp:BoundField DataField="Estatus" HeaderText="<%$Resources:Traducciones,Estatus %>" />
                <asp:BoundField DataField="CreadoPor" HeaderText="<%$Resources:Traducciones,CreadoPor %>" />
                <asp:BoundField DataField="FechaAdiciona" HeaderText="<%$Resources:Traducciones,FechaAdiciona %>" />
                <asp:BoundField DataField="ModificadoPor" HeaderText="<%$Resources:Traducciones,ModificadoPor %>" />
                <asp:BoundField DataField="FechaModifica" HeaderText="<%$Resources:Traducciones,FechaModifica %>" />
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
        <%--en esta parte agregamos los controles para el mantenimiento--%>
        <asp:Label ID="lbOficinaMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,Oficina %>" CssClass="LabelFormularios"></asp:Label>
        <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server" Visible="false" CssClass="combobox" ToolTip="<%$Resources:Traducciones,Oficina %>"></asp:DropDownList><br />
        <asp:Label ID="lbOficinaDepartamento" runat="server" Visible="false" Text="<%$Resources:Traducciones,Departamento %>" CssClass="LabelFormularios"></asp:Label>
        <asp:TextBox ID="txtDescripcionDepartamentoMAN" runat="server" Visible="false" AutoCompleteType="Disabled" PlaceHolder="<%$Resources:Traducciones,Departamento %>" CssClass="Caja-Texto-Login"></asp:TextBox><br />
        <asp:CheckBox ID="cbEstatus" runat="server" Visible="false" Text="<%$Resources:Traducciones,Estatus %>" CssClass="CheckBox-Formularios" ToolTip="<%$Resources:Traducciones,Estatus %>" /><br />
        <div align="Center">
            <asp:Button ID="btnGuardar" runat="server" Visible="false" Text="<%$Resources:Traducciones,Guardar %>" CssClass="Botones" Width="15%" ToolTip="<%$Resources:Traducciones,Guardar %>" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnAtras" runat="server" Visible ="false" Text="<%$Resources:Traducciones,Atras %>" Width="15%" CssClass="Botones" ToolTip="<%$Resources:Traducciones,Atras %>" OnClick="btnAtras_Click" />
            <asp:Label ID="lbIdMantenimiento" runat="server" Text="IdMantenimiento" Visible="false"></asp:Label>
            <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>

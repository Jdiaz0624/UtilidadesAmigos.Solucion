<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Oficinas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Mantenimientos.Oficinas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <h1><asp:Label ID="lbLetrero" runat="server" Text="Mantenimiento de Oficinas" CssClass="Label-Encabezado"></asp:Label></h1>
    </header>
    <hr />
    <div class="Bloque-Centro">
        <div class="Bloque-Izquierda">
            <asp:Label ID="lbDescripcion" Text="Oficina" runat="server" CssClass="LabelFormularios"></asp:Label>
            <asp:TextBox ID="txtDescripcionOficina" runat="server" CssClass="Caja-Texto-Login" Palceholder="Descripcion Oficina" MaxLength="100"></asp:TextBox>
        </div>
        <div class="Bloque-Derecha">
            <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar Registros" CssClass="Botones" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Nuevo Registro" CssClass="Botones" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRestabelcer" runat="server" Text="Atras" ToolTip="Restablecer Pantalla" CssClass="Botones" OnClick="btnRestabelcer_Click" /><br />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" ToolTip="Modificar Registro seleccionado" CssClass="Botones" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" ToolTip="Deshabilitar registro seleccionado" CssClass="Botones" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" ToolTip="Exportar a exel" CssClass="Botones" OnClick="btnExportar_Click" />
        </div>
    </div>
    <div>
        <%--en esta parte agregamos el grid--%>
        <asp:GridView ID="gvOficinas" runat="server"  AutoGenerateColumns="False" OnPageIndexChanging="gvOficinas_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="98%" OnSelectedIndexChanged="gvOficinas_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Select" ShowSelectButton="True" />
                <asp:BoundField DataField="IdOficina"   HeaderText="IdOficina" />
                <asp:BoundField DataField="Oficina"  HeaderText="Oficina" />
                <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                <asp:BoundField DataField="Creadopor" HeaderText="Creado Por" />
                <asp:BoundField DataField="FechaAdiciona" HeaderText="Fecha Creado" />
                <asp:BoundField DataField="ModificadoPor" HeaderText="Modificado por" />
                <asp:BoundField DataField="FechaModifica" HeaderText="Fecha Modifica" />
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
        <asp:Label ID="lbOficina" Visible="false" runat="server" Text="Ingrese Oficina" CssClass="LabelFormularios"></asp:Label>
        <asp:TextBox ID="txtDescripcionOficinaMAn" Visible="false" runat="server" PlaceHolder="Descripcion de Oficina" CssClass="Caja-Texto-Login"></asp:TextBox><br />
        <asp:CheckBox ID="cbEstatus" runat="server" Visible="false" Text="Estatus" CssClass="CheckBox-Formularios" ToolTip="Estatus de Oficina" /><br />
        <asp:CheckBox ID="cbGuardar" runat="server" Visible="false" Text="Guardar" CssClass="CheckBox-Formularios" />
        <asp:CheckBox ID="cbModificar" runat="server" Visible="false" Text="Modificar" CssClass="CheckBox-Formularios" />
        <asp:CheckBox ID="cbDeshabilitar" runat="server" Visible="false" Text="Deshabilitar" CssClass="CheckBox-Formularios" /><br />
        <asp:Label ID="lbIdOficinaMantenimiento" Visible="false" runat="server" Text="IdOficinaSeleccionado"></asp:Label>
        <div align="Center">
            <asp:Button ID="btnGuardar" Visible="false" runat="server" Text="Guardar" CssClass="Botones" ToolTip="Terminar Operacion" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>

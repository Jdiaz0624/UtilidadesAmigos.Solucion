<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoUsuarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <header>
       <h1><asp:Label ID="lbEncabezado" runat="server" Text="Mantenimiento de Usuarios" CssClass="Label-Encabezado"></asp:Label></h1>
   </header>
    <hr />
    <div class="Contenedor">
        <div class="Bloque-Izquierda" >
            <asp:Label ID="lbUsuarioConsulta" runat="server" Text="Usuario" CssClass="Label"></asp:Label>
            <asp:TextBox ID="txtUsuarioFiltro" runat="server" placeholder="Ingrese Nombre de Usuario" MaxLength="20" CssClass="Texto"></asp:TextBox><br /><br />
            <asp:Label ID="lbIdUsuarioSeleccionado" runat="server" Text="0" CssClass="Label" Visible="False"></asp:Label>
<%--            <asp:Label ID="lbPersonaFiltros" runat="server" Text="Persona" CssClass="Label"></asp:Label>
            <asp:TextBox ID="txtPersonaFiltros" runat="server" placeholder="Persona de la Persona" CssClass="Texto" MaxLength="40"></asp:TextBox>--%>
        </div>
        <div class="Bloque-Derecha">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" ToolTip="Consultar Registros" CssClass="Botones" />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Nuevo Usuario" CssClass="Botones" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" ToolTip="Modificar Usuario Seleccionado" CssClass="Botones" OnClick="btnModificar_Click" /><br />
            <asp:Button ID="btnAtras" runat="server" Text="Atras" ToolTip="Volver Atras" Enabled="false" CssClass="Botones" OnClick="btnAtras_Click" />
            <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" ToolTip="Deshabilitar Usuario Seleccionado" Enabled="false" CssClass="Botones" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Quieres Deshabilitar Este Registro?');" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" ToolTip="Eliminar Usuario Seleccionado" CssClass="Botones" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Quieres Eliminar Este Registro?');" />
        </div>
    </div>
    <div>
        <asp:GridView ID="gbListadoUsuarios" horizontalalign="Right" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gbListadoUsuarios_RowDataBound" OnSelectedIndexChanged="gbListadoUsuarios_SelectedIndexChanged1" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Detalle" ShowSelectButton="True" />
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


        <asp:TextBox ID="txtNumeroPaginas" AutoPostBack="true" runat="server" CssClass="Caja-Texto-Paginacion" TextMode="Number" Text="1" OnTextChanged="txtNumeroPaginas_TextChanged"></asp:TextBox>
        <asp:TextBox ID="txtNumeroRegistros" runat="server" AutoPostBack="true" CssClass="Caja-Texto-Paginacion" TextMode="Number" Text="10" OnTextChanged="txtNumeroRegistros_TextChanged"></asp:TextBox>
    </div>
    <div>
        <h3><asp:Label ID="lbSubEncabezadoMantenimiento" runat="server" Text="Mantenimiento de Usuarios" CssClass="Label"></asp:Label></h3>
        
        <asp:Label ID="lbDepartamentoMantenimiento" runat="server" Text="Departamento" CssClass="LabelFormularios"></asp:Label>
        <asp:DropDownList ID="ddlDepartamentoMantenimiento" runat="server" CssClass="combobox"></asp:DropDownList><br />
        <asp:Label ID="lbPerfilMantenimiento" runat="server" Text="Perfil" CssClass="LabelFormularios"></asp:Label>
        <asp:DropDownList ID="ddlPerfilMantenimiento" runat="server" CssClass="combobox"></asp:DropDownList><br />
        <asp:Label ID="lbUsuarioMantenimiento" runat="server" Text="Usuario" CssClass="LabelFormularios"></asp:Label>
        <asp:TextBox ID="txtUsuarioMantenimiento" runat="server" Placeholder="Ingrese Usuario" CssClass="Texto"></asp:TextBox><br />
        <asp:Label ID="lbClaveMantenimiento" runat="server" Text="Clave" CssClass="LabelFormularios"></asp:Label>
        <asp:TextBox ID="txtClaveMantenimiento" runat="server" Placeholder="Ingrese Clave" CssClass="Texto" TextMode="Password" MaxLength="20"></asp:TextBox><br />
        <asp:Label ID="lbConfirmarClaveMantenimiento" runat="server" Text="Confirmar Clave" CssClass="LabelFormularios"></asp:Label>
        <asp:TextBox ID="txtConfirmarClaveMantenimiento" runat="server" Placeholder="Confirmar Clave" CssClass="Texto" TextMode="Password" MaxLength="20"></asp:TextBox><br />
        <asp:Label ID="lbPersonaMantenimiento" runat="server" Text="Persona" CssClass="LabelFormularios"></asp:Label>
        <asp:TextBox ID="txtPersonaMantenimiento" runat="server" Placeholder="Nombre de la Persona" MaxLength="40" CssClass="Texto"></asp:TextBox><br />
        <asp:CheckBox ID="cbEstatusMantenimiento" AutoPostBack="true" runat="server" CssClass="CheckBox-Formularios" Text="Estatus" OnCheckedChanged="cbEstatusMantenimiento_CheckedChanged" /><br />
        <asp:CheckBox ID="cbLlevaEmailMantenimiento" AutoPostBack="true" runat="server" CssClass="CheckBox-Formularios" Text="¿Lleva Email?" OnCheckedChanged="cbLlevaEmailMantenimiento_CheckedChanged" /><br />
        <asp:Label ID="lbEmailMantenimiento" runat="server" Text="Email"  CssClass="LabelFormularios"></asp:Label>
        <asp:TextBox ID="txtEmailMantenimiento" runat="server" Placeholder ="Ingrese Enail" CssClass="Texto"></asp:TextBox><br />
        <asp:CheckBox ID="cbCambiaClaveMantenimiento" runat="server" Text="Cambia Clave" CssClass="CheckBox-Formularios" />
    </div>
    <div class="Bloque-Centro">
        <asp:TextBox ID="txtClaveSeguridadMantenimeinto" runat="server" CssClass="Caja-Texto-Login" PlaceHolder="Clave de Seguridad" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="btnProcesarMantenimento" Text="Procesar" runat="server" CssClass="Botones"  ToolTip="Completar Operacion" OnClick="btnProcesarMantenimento_Click" />
    </div>
</asp:Content>

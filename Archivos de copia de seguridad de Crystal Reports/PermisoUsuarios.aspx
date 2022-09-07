<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="PermisoUsuarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.PermisoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <h1><asp:Label ID="lbEncabezado" runat="server" CssClass="Label-Encabezado" Text="Mantenimiento de Permiso a Usuarios"></asp:Label></h1>
    </header>
    <hr class="hr" />
    <div class="Contenedor" >
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <div class="Bloque-Izquierda" >
            <asp:Label ID="lbClaveSeguridad" runat="server" CssClass="LabelFormularios" Text="Clave de Seguridad"></asp:Label>
            <asp:TextBox ID="txtClaveSeguridad" runat="server" CssClass="Texto" placeholder="IngreseClaveSeguridad" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="lbUsuario" runat="server" Text="Ingrese Usuario" CssClass="LabelFormularios"></asp:Label>
            <asp:TextBox ID="txtUsuarioFiltro" runat="server" placeholder="Ingrese Nombre de Usuario" ToolTip="Ingrese el Nombre de Usuario" CssClass="Texto"></asp:TextBox>
        </div>
        <div class="Bloque-Derecha">
            <asp:Button ID="btnBuscarRegistros" runat="server" CssClass="Botones" Text="Buscar" ToolTip="Buscar Registros" OnClick="btnBuscarRegistros_Click" />
            <asp:Button ID="btnAtras" runat="server" CssClass="Botones" Text="Atras" ToolTip="Volver Atras" />
            <asp:Button ID="btnProcesar" runat="server" CssClass="Botones" Text="Validar" ToolTip="Validar la Clave de Segurida" OnClick="btnProcesar_Click" />
        </div>
    </div>
    <hr class="hr" />
    <div>
        <h2><asp:Label ID="lbSubEncabezadoUsuaruis" runat="server" CssClass="Label-Encabezado" Text="Listado de Usuarios"></asp:Label></h2><br />
        <asp:GridView ID="gbListadoUsuarios" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="gbListadoUsuarios_RowDataBound" OnSelectedIndexChanged="gbListadoUsuarios_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Modificar" SelectText="Select" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:TextBox ID="txtNumeroPagina" runat="server" Text="1" TextMode="Number" ToolTip="Numero de Pagina" CssClass="Caja-Texto-Paginacion"></asp:TextBox>
        <asp:TextBox ID="txtNumeroRegistros" runat="server" Text="10" TextMode="Number" ToolTip="Numero de Registros" CssClass="Caja-Texto-Paginacion"></asp:TextBox>
    </div>
    <div>
        <h2><asp:Label ID="lbSubEncabezadoPermisoPerfil" runat="server" Text="Listado de Permiso de usuarios" CssClass="Label-Encabezado"></asp:Label></h2><br />
        <asp:GridView ID="gbListadoPermisousuarios" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Procesar" SelectText="Cambiar" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>

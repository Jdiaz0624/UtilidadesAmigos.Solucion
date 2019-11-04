<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ResponsiveDesing">
        <header>
            <h1><asp:Label ID="lbEncabezado" runat="server" Text="Mantenimiento de Empleados" CssClass="Label-Encabezado"></asp:Label></h1>
        </header>
        <hr />
        <div class="Bloque-Centro">
            <div class="Bloque-Izquierda">
                <%-- AQUI VAN LOS CONTROLES DE BUSQUEDA --%>
                <asp:Label ID="lbOficinaConsulta" runat="server" Text="<%$ Resources:Traducciones,Oficina %>" CssClass="Label"></asp:Label><br />
                <asp:DropDownList ID="ddlOficinaConsulta" runat="server" CssClass="combobox" AutoPostBack="true" ToolTip="<%$Resources:Traducciones,Oficina %>" OnSelectedIndexChanged="ddlOficinaConsulta_SelectedIndexChanged"></asp:DropDownList><br />
                <asp:Label ID="lbDepartamentoConsulta" runat="server" Text="<%$ Resources:Traducciones,Departamento %>" CssClass="Label"></asp:Label><br />
                <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" CssClass="combobox" ToolTip="<%$Resources:Traducciones,Departamento %>"></asp:DropDownList><br />
                <asp:Label ID="lbNombreConsulta" runat="server" Text="<%$ Resources:Traducciones,Nombre %>" CssClass="Label"></asp:Label><br />
                <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="Caja-Texto-Login" PlaceHolder="<%$Resources:Traducciones,Nombre %>" MaxLength="100"></asp:TextBox>


                <div>
            <%-- AQUI VAN LOS CONTROLES PARA EL MANTENIMIENTO --%>
            <asp:Label ID="lbOficinaMantenimiento" runat="server" CssClass="LabelFormularios" Visible="false" Text="<%$Resources:Traducciones,Oficina %>"></asp:Label>
            <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server" CssClass="combobox" Visible="false" AutoPostBack="True"  ToolTip="<%$Resources:Traducciones,Oficina %>" OnSelectedIndexChanged="ddlOficinaMantenimiento_SelectedIndexChanged"></asp:DropDownList><br />
            <asp:Label ID="lbDepartamentoMantenimiento" runat="server" CssClass="LabelFormularios" Visible="false" Text="<%$Resources:Traducciones,Departamento %>"></asp:Label>
            <asp:DropDownList ID="ddlDepartamenoMantenimiento" runat="server" CssClass="combobox" Visible="false" ToolTip="<%$Resources:Traducciones,Departamento %>"></asp:DropDownList><br />
            <asp:Label ID="lbNombreMantenimiento" runat="server" CssClass="LabelFormularios" Visible="false" Text="<%$Resources:Traducciones,Nombre %>"></asp:Label>
            <asp:TextBox ID="txtNombreMantenimiento" runat="server" CssClass="Caja-Texto-Login" Visible="false" PlaceHolder="<%$Resources:Traducciones,Nombre %>" MaxLength="100"></asp:TextBox><br />
            <asp:CheckBox ID="cbEstatusMantenimiento" runat="server" Text="<%$Resources:Traducciones,Estatus %>" CssClass="CheckBox-Formularios" Visible="false" ToolTip="<%$Resources:Traducciones,Estatus %>" />
                    <div align="Center">
                        <asp:Button ID="btnGuardarMantenimiento" runat="server" CssClass="Botones" Visible="false" Text="<%$Resources:Traducciones,Guardar %>" ToolTip="<%$Resources:Traducciones,Guardar %>" OnClick="btnGuardarMantenimiento_Click"/>
                        <asp:Button ID="btnAtrasMantenimiento" runat="server" CssClass="Botones" Visible="false" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" OnClick="btnAtrasMantenimiento_Click" />
                        <asp:Label ID="lbIdMantenimiento" runat="server" Text="IdMantenimiento" Visible="false"></asp:Label>
                        <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
                    </div>
        </div>
            </div>
            <div class="Bloque-Derecha">
                <%-- AQUI VAN LOS BOTONES PARA EL MANTENIMIENTO --%>
                <asp:Button ID="btnConsultar" runat="server" CssClass="Botones" Text="<%$Resources:Traducciones,Buscar %>" ToolTip="<%$Resources:Traducciones,Buscar %>" OnClick="btnConsultar_Click" />
                <asp:Button ID="btnNuevo" runat="server" CssClass="Botones" Text="<%$Resources:Traducciones,Nuevo %>" ToolTip="<%$Resources:Traducciones,Nuevo %>" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnatrasConsulta" runat="server" CssClass="Botones" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" OnClick="btnatrasConsulta_Click"/><br />
                <asp:Button ID="btnModificar" runat="server" CssClass="Botones" Text="<%$Resources:Traducciones,Actualizar %>" Enabled="false" ToolTip="<%$Resources:Traducciones,Actualizar %>" OnClick="btnModificar_Click" />
                <asp:Button ID="btnDeshabilitar" runat="server" CssClass="Botones" Text="<%$Resources:Traducciones,Deshabilitar %>" Enabled="false" ToolTip="<%$Resources:Traducciones,Deshabilitar %>" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Quieres desabilitar este registro?');" />
                <asp:Button ID="btnExportar" runat="server" CssClass="Botones" Text="<%$Resources:Traducciones,Exportar %>" ToolTip="<%$Resources:Traducciones,Exportar %>" OnClick="btnExportar_Click" />
            </div>
        </div>
        <div>
            <%-- AQUI VA EL GRID --%>
            <asp:GridView ID="gvEmpleados" runat="server" AllowPaging="true" OnPageIndexChanging="gvEmpleados_PageIndexChanging" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="10%" HeaderText="<%$ Resources: Traducciones,Seleccionar %>"  ControlStyle-CssClass="BotonesGrid" SelectText="<%$Resources:Traducciones,Seleccionar %>" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdEmpleado" HeaderStyle-Width="5%" HeaderText="ID" />
                    <asp:BoundField DataField="Oficina" HeaderStyle-Width="15%" HeaderText="<%$Resources:Traducciones,Oficina %>" />
                    <asp:BoundField DataField="Departamento" HeaderStyle-Width="5%" HeaderText="<%$Resources:Traducciones,Departamento %>" />
                    <asp:BoundField DataField="Nombre" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,Nombre %>" />
                    <asp:BoundField DataField="Estatus" HeaderStyle-Width="10%" HeaderText="<%$Resources:Traducciones,Estatus %>" />
                    <asp:BoundField DataField="CreadoPor" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,CreadoPor %>" />
                    <asp:BoundField DataField="FechaAdiciona" HeaderStyle-Width="15%" HeaderText="<%$Resources:Traducciones,FechaAdiciona %>" />
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
</asp:Content>

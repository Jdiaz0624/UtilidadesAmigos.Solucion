 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AsignacionTarjetas.aspx.cs" EnableViewState ="true" Inherits="UtilidadesAmigos.Solucion.Paginas.AsignacionTarjetas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ResponsiveDesing">
        <header>
            <h1><asp:Label ID="lbEncabezado" runat="server" Text="Asignacion de tarjetas de Acceso" CssClass="Label-Encabezado"></asp:Label></h1>
        </header>
        <hr />
        <div class="Bloque-Centro">
            <div class="Bloque-Izquierda">
                <%-- CONTROLES PARA LA CONSULTA --%>
                <asp:Label ID="lbOficinaConsulta" runat="server" Text="<%$Resources:Traducciones,Oficina %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlOficinaConsulta" runat="server" AutoPostBack="true" ToolTip="<%$Resources:Traducciones,Oficina %>" CssClass="combobox" OnSelectedIndexChanged="ddlOficinaConsulta_SelectedIndexChanged1"></asp:DropDownList><br />
                <asp:Label ID="lbDepartamentoConsulta" runat="server" Text="<%$Resources:Traducciones,Departamento %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" AutoPostBack="true" ToolTip="<%$Resources:Traducciones,Departamento %>" CssClass="combobox" OnSelectedIndexChanged="ddlDepartamentoConsulta_SelectedIndexChanged1"></asp:DropDownList><br />
                <asp:Label ID="lbEmpleadoConsulta" runat="server" Text="<%$Resources:Traducciones,Empleado %>" CssClass="LabelFormularios"></asp:Label>
                <asp:DropDownList ID="ddlEmpleadoConsulta" runat="server" ToolTip="<%$Resources:Traducciones,Empleado %>" CssClass="combobox"></asp:DropDownList><br />
                <asp:Label ID="lbNumeroTarjetaConsulta" runat="server" Text="<%$Resources:Traducciones,NumeroTarjeta %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtNumerotarjetaConsulta" runat="server" PlaceHolder="<%$Resources:Traducciones,NumeroTarjeta %>" MaxLength="100" TextMode="Number" CssClass="Caja-Texto-Login"></asp:TextBox><br />
                <asp:CheckBox ID="cbFiltrarPorRangoFechaConsulta" runat="server" Text="<%$Resources:Traducciones,FiltrarRangofecha %>" CssClass="CheckBox-Formularios" /><br />
                <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="<%$Resources:Traducciones,FechaDesde %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" PlaceHolder="<%$Resources:Traducciones,FechaDesde %>" TextMode="Date" CssClass="Texbox-Fecha"></asp:TextBox>
                <asp:Label ID="lbFechaHastaConsulta" runat="server" Text="<%$Resources:Traducciones,FechaHasta %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtFechaHastaConsulta" runat="server" PlaceHolder="<%$Resources:Traducciones,FechaHasta %>" TextMode="Date" CssClass="Texbox-Fecha"></asp:TextBox>
                <%-- CONTROLES PARA EL MANTENIMIENTO --%>
                <div>
                    <h3 align="Center"><asp:Label ID="lbMantenimientoTarjetasAcceso" Visible="false" runat="server" Text="Mantenimiento de tarjetas" CssClass="Label-Encabezado"></asp:Label></h3>
                    <asp:Label ID="lbOficinaMantenimiento" Visible="false" runat="server" Text="<%$Resources:Traducciones,Oficina %>" CssClass="LabelFormularios"></asp:Label>
                    <asp:DropDownList ID="ddlOficinaMantenimiento" AutoPostBack="true" Visible="false" runat="server" ToolTip="<%$Resources:Traducciones,Oficina %>" CssClass="combobox" OnSelectedIndexChanged="ddlOficinaMantenimiento_SelectedIndexChanged1"></asp:DropDownList><br />
                    <asp:Label ID="lbDepartamentoMantenimiento" Visible="false" runat="server" Text="<%$Resources:Traducciones,Departamento %>" CssClass="LabelFormularios"></asp:Label>
                    <asp:DropDownList ID="ddlDepartamentoMantenimiento" Visible="false" AutoPostBack="true" runat="server" CssClass="combobox" ToolTip="<%$Resources:Traducciones,Departamento %>" OnSelectedIndexChanged="ddlDepartamentoMantenimiento_SelectedIndexChanged1"></asp:DropDownList><br />
                    <asp:Label ID="lbEmpleadoMantenimiento" Visible="false" runat="server" CssClass="LabelFormularios" Text="<%$Resources:Traducciones,Empleado %>"></asp:Label>
                    <asp:DropDownList ID="ddlEmpleadoMantenimiento" Visible="false" AutoPostBack="true" runat="server" CssClass="combobox" ToolTip="<%$Resources:Traducciones,Empleado %>"></asp:DropDownList><br />
                    <asp:Label ID="lbNumeroTarjetraMantenimiento" Visible="false" runat="server" CssClass="LabelFormularios" Text="<%$Resources:Traducciones,NumeroTarjeta %>"></asp:Label>
                    <asp:TextBox ID="txtNumerotarjetaMantenimiento" Visible="false" runat="server" CssClass="Caja-Texto-Login" PlaceHolder="<%$Resources:Traducciones,NumeroTarjeta %>" TextMode="Number" MaxLength="100"></asp:TextBox><br />
                    <asp:Label ID="lbFechaEntregaMantenimiento" Visible="false" runat="server" CssClass="LabelFormularios" Text="<%$Resources:Traducciones,Fecha %>"></asp:Label>
                    <asp:TextBox ID="txtFechaEntregaMantenimiento" Visible="false" runat="server" CssClass="Texbox-Fecha" TextMode="Date" PlaceHolder="<%$Resources:Traducciones,Fecha %>"></asp:TextBox><br />
                    <asp:CheckBox ID="cbEstatusMantenimiento" Visible="false" runat="server" CssClass="CheckBox-Formularios" Text="<%$Resources:Traducciones,Estatus %>" ToolTip="<%$Resources:Traducciones,Estatus %>" />
                     
                    <div align="Center">
                        <asp:Button ID="btnGuardarMantenimiento" Visible="false" runat="server" CssClass="Botones" Text="<%$Resources:Traducciones,Guardar %>" ToolTip="<%$Resources:Traducciones,Guardar %>" OnClick="btnGuardarMantenimiento_Click" />
                        <asp:Button ID="btnAtrasMantenimiento" Visible="false" runat="server" CssClass="Botones" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" OnClick="btnAtrasMantenimiento_Click" /><br />
                        <asp:Label ID="lbIdMantenimiento" runat="server" Text="IdMantenimiento" Visible="false"></asp:Label>
                        <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="Bloque-Derecha">
                <%-- BOTONES SUPERIORES --%>
                <asp:Button ID="btnConsultar" runat="server" Text="<%$Resources:Traducciones,Buscar %>" ToolTip="<%$Resources:Traducciones,Buscar %>" CssClass="Botones" OnClick="btnConsultar_Click" />
                <asp:Button ID="btnNuevo" runat="server" Text="<%$Resources:Traducciones,Nuevo %>" ToolTip="<%$Resources:Traducciones,Nuevo %>" CssClass="Botones" OnClick="btnNuevo_Click1" />
                <asp:Button ID="btnAtras" runat="server" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" CssClass="Botones" OnClick="btnAtras_Click1" Enabled="False" /><br />
                <asp:Button ID="btnModificar" runat="server" Text="<%$Resources:Traducciones,Actualizar %>" ToolTip="<%$Resources:Traducciones,Actualizar %>" CssClass="Botones" Enabled="False" OnClick="btnModificar_Click1" />
                <asp:Button ID="btnDeshabilitar" runat="server" Text="<%$Resources:Traducciones,Deshabilitar %>" ToolTip="<%$Resources:Traducciones,Deshabilitar %>" CssClass="Botones" Enabled="False" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Quieres deshabilitar este registro?');" />
                <asp:Button ID="btnExportar" runat="server" Text="<%$Resources:Traducciones,Exportar %>" ToolTip="<%$Resources:Traducciones,Exportar %>" CssClass="Botones" OnClick="btnExportar_Click" />


            </div>
        </div>
        <div>
            <%-- AQUI VA EL GRID --%>
            <asp:GridView ID="gvTarjetaAcceso" runat="server" AllowPaging="true" OnPageIndexChanging="gvTarjetaAcceso_PageIndexChanging" OnSelectedIndexChanged="gvTarjetaAcceso_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="<%$ Resources: Traducciones,Seleccionar %>" SelectText="Ver" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdTarjetaAcceso" HeaderStyle-Width="11%" HeaderText="ID" />
                    <asp:BoundField DataField="Oficina" HeaderStyle-Width="11%" HeaderText="<%$Resources:Traducciones,Oficina %>" />
                    <asp:BoundField DataField="Departamento" HeaderStyle-Width="11%" HeaderText="<%$Resources:Traducciones,Departamento %>" />
                    <asp:BoundField DataField="Empleado" HeaderStyle-Width="12%" HeaderText="<%$Resources:Traducciones,Empleado %>" />
                    <asp:BoundField DataField="SecuenciaInterna" HeaderStyle-Width="11%" HeaderText="<%$Resources:Traducciones,SecuenciaInterna %>" />
                    <asp:BoundField DataField="NumeroTarjeta" HeaderStyle-Width="11%" HeaderText="<%$Resources:Traducciones,NumeroTarjeta %>" />
                    <asp:BoundField DataField="FechaEntrega" HeaderStyle-Width="11%" HeaderText="<%$Resources:Traducciones,Fecha %>" />
                    <asp:BoundField DataField="Estatus" HeaderStyle-Width="11%" HeaderText="<%$Resources:Traducciones,Estatus %>" />
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

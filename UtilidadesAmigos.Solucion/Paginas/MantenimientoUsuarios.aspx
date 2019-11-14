<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoUsuarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#7BC5FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }

        .btn-sm{
            width:90px;
        }
    </style>

    <!--INICIO DEL ENCABEZADO DE LA PANTALLA-->
    <div class="container-fluid">
        <div align="center" class="jumbotron">
            <asp:Label ID="lbmantenimientoEmpleados" Text="Mantenimiento de Usuarios" runat="server"></asp:Label>
        </div>
    </div>
    <!--FIN DEL ENCABEZADO DE LA PANTALLA-->

    <!--AQUI INICIAN LOS CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <div class="form-row">
        <div class="form-group col-md-3">
                 <asp:Label ID="lbUsuarioConsulta" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="txtUsuarioFiltro" runat="server" placeholder="Ingrese Nombre de Usuario" MaxLength="20" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lbIdUsuarioSeleccionado" runat="server" Text="0" Visible="False"></asp:Label>
        </div>
    </div>
    </div>
    <!--AQUI TERMINAN LOS CONTROLES DE BUSQUEDA-->
    <!--AQUI COMIENZAN LOS BOTONES PARA REALIZAR EL MANTENIMIENTO-->
    <div class="container-fluid">
        <div>
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm" />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Nuevo Usuario" CssClass="btn btn-outline-primary btn-sm" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" ToolTip="Modificar Usuario Seleccionado" CssClass="btn btn-outline-primary btn-sm" OnClick="btnModificar_Click" /><br />
        </div>
        <br />
        <div>
             <asp:Button ID="btnAtras" runat="server" Text="Atras" ToolTip="Volver Atras" Enabled="false" CssClass="btn btn-outline-primary btn-sm" OnClick="btnAtras_Click" />
            <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" ToolTip="Deshabilitar Usuario Seleccionado" Enabled="false" CssClass="btn btn-outline-primary btn-sm" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Quieres Deshabilitar Este Registro?');" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" ToolTip="Eliminar Usuario Seleccionado" CssClass="btn btn-outline-primary btn-sm" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Quieres Eliminar Este Registro?');" />
        </div>
    </div>
    <!--AQUI TERMINAN LOS BOTONES PARA REALIZAR EL MANENIMIENTO-->
    <br />
    <!--AQUI INICIA EL GRID-->
     <div class="container-fluid">
            <asp:GridView id="gbListadoUsuarios" runat="server" AllowPaging="True" OnPageIndexChanging="gbListadoUsuarios_PageIndexChanging1" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoUsuarios_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                     <asp:CommandField ButtonType="Button" HeaderText="Detalle" SelectText="Ver" ControlStyle-CssClass="btn btn-outline-primary btn-sm" ShowSelectButton="True" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="Perfil" HeaderText="Perfil" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Persona" HeaderText="Persona" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="CambiaClave" HeaderText="Cambia Clave" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" HorizontalAlign="Center" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>


        </div>
    <!--AQUI TERMINA EL GRID-->






           
           





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

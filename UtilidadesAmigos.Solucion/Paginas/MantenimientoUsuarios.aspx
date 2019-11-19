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
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar"  ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Nuevo Usuario" CssClass="btn btn-outline-primary btn-sm" OnClick="btnNuevo_Click"/>
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" ToolTip="Modificar Usuario Seleccionado" CssClass="btn btn-outline-primary btn-sm" OnClick="btnModificar_Click"/><br />
        </div>
        <br />
        <div>
             <asp:Button ID="btnAtras" runat="server" Text="Atras" ToolTip="Volver Atras" Enabled="false" CssClass="btn btn-outline-primary btn-sm" OnClick="btnAtras_Click"/>
            <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" ToolTip="Deshabilitar Usuario Seleccionado" Enabled="false" CssClass="btn btn-outline-primary btn-sm" OnClick="btnDeshabilitar_Click"  OnClientClick="return confirm('¿Quieres Deshabilitar Este Registro?');" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" ToolTip="Eliminar Usuario Seleccionado" CssClass="btn btn-outline-primary btn-sm" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Quieres Eliminar Este Registro?');" />
        </div>
    </div>
    <!--AQUI TERMINAN LOS BOTONES PARA REALIZAR EL MANENIMIENTO-->
    <br />
    <!--AQUI INICIA EL GRID-->
     <div class="container-fluid">
            <asp:GridView id="gbListadoUsuarios" runat="server" AllowPaging="True" OnPageIndexChanging="gbListadoUsuarios_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoUsuarios_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                     <asp:CommandField ButtonType="Button" HeaderText="Detalle" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" ShowSelectButton="True" />
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

    <!--AQUI COMIENZAN LOS CONTROLES PARA REALIZAR EL MANTENIMIENTO DE USUARIOS-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbDepartamentoMantenimiento" runat="server" Visible="false" Text="Seleccionar Departamento"></asp:Label>
               <asp:DropDownList ID="ddlDepartamentoMantenimiento" runat="server" Visible="false" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbPerfilMantenimiento" runat="server" Visible="false" Text="Selccionar Perfil"></asp:Label>
                <asp:DropDownList ID="ddlPerfilMantenimiento" runat="server" Visible="false" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                        <asp:Label ID="lbUsuarioMantenimiento" runat="server" Visible="false" Text="Ingresar Nombre de Usuario"></asp:Label>
                       <asp:TextBox ID="txtUsuarioMantenimiento" runat="server" Visible="false" Placeholder="Ingrese Usuario" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                 <asp:Label ID="lbPersonaMantenimiento" runat="server" Visible="false" Text="Ingrese Nombre del Usuario"></asp:Label>
                 <asp:TextBox ID="txtPersonaMantenimiento" runat="server" Visible="false" Placeholder="Nombre de Usuario" MaxLength="40" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                    <asp:Label ID="lbClaveMantenimiento" runat="server" Visible="false" Text="Ingresar Clave"></asp:Label>
                    <asp:TextBox ID="txtClaveMantenimiento" runat="server" Visible="false" Placeholder="Ingrese Clave" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                  <asp:Label ID="lbConfirmarClaveMantenimiento" runat="server" Visible="false" Text="Confirmar Clave"></asp:Label>
                  <asp:TextBox ID="txtConfirmarClaveMantenimiento" runat="server" Visible="false" Placeholder="Confirmar Clave" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                        <asp:Label ID="lbEmailMantenimiento" runat="server" Visible="false" Text="Email"></asp:Label>
                        <asp:TextBox ID="txtEmailMantenimiento" runat="server" Visible="false" Placeholder ="Ingrese Enail" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                <asp:Label ID="lbClaveSeguridad" runat="server" Visible="false" Text="Ingrese Clave de Seguridad"></asp:Label>
                <asp:TextBox ID="txtClaveSeguridadMantenimeinto" runat="server" Visible="false" CssClass="form-control" PlaceHolder="Clave de Seguridad" TextMode="Password"></asp:TextBox>
            </div>

        </div>

        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbEstatusMantenimiento" AutoPostBack="true" runat="server" Visible="false" CssClass="form-check-input" Text="Estatus" OnCheckedChanged="cbEstatusMantenimiento_CheckedChanged" />
            </div>
            <div class="form-group form-check">
                <asp:CheckBox ID="cbLlevaEmailMantenimiento" AutoPostBack="true" runat="server" Visible="false" CssClass="form-check-input" Text="¿Lleva Email?" OnCheckedChanged="cbLlevaEmailMantenimiento_CheckedChanged" />
            </div>
            <div class="form-group form-check">
                 <asp:CheckBox ID="cbCambiaClaveMantenimiento" runat="server" Visible="false" Text="Cambia Clave" CssClass="form-check-input" />
            </div>
        </div>
    </div>

    <div align="Center">
            <asp:Button ID="btnProcesarMantenimento" Text="Procesar" runat="server" Visible="false" CssClass="btn btn-outline-primary btn-sm"  ToolTip="Completar Operacion" OnClick="btnProcesarMantenimento_Click" />
        <asp:Button ID="btnVolverAtras" Text="Volver" runat="server" Visible="false" CssClass="btn btn-outline-primary btn-sm" ToolTip="Volver Atras" OnClick="btnVolverAtras_Click" />
    </div>

    <!--AQUI TERMINAN LOS CONTROLES PARA REALIZAR EL MANTENIMIENTO DE USUARIOS-->

</asp:Content>

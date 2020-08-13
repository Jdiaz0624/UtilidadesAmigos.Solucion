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
    <script type="text/javascript">

    </script>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTituloConsulta" runat="server" Text="Consulta de Usuario"></asp:Label>
            <asp:Label ID="lbMantenimientoUsuario" runat="server" Text="IdMantenimiento" Visible="false"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarSucursal" runat="server" Text="Sucursal"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursalConsulta_SelectedIndexChanged"  runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
            </div>

                <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionaroficinaConsulta" runat="server" Text="Oficina"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficinaConsulta" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionaroficinaConsulta_SelectedIndexChanged" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarDepartamentoConsulta" runat="server" Text="Departamento"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarDepartamentoConsulta" runat="server" ToolTip="Seleccionar Departamento" CssClass="form-control"></asp:DropDownList>
            </div>

              <div class="form-group col-md-3">
                     <asp:Label ID="lbSeleccionarPerfilConsulta" runat="server" Text="Perfil"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarPerfilConsulta" runat="server" ToolTip="Seleccionar Perfil" CssClass="form-control"></asp:DropDownList>
            </div>

              <div class="form-group col-md-3">
                      <asp:Label ID="lbUsuarioConsulta" runat="server" Text="Consulta"></asp:Label>
               <asp:TextBox ID="txtUsuarioConsulta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <br />
         <div>
              <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-lg">Nuevo</button>
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExportar_Click" /><br /><br />
                <button type="button" id="btnModificarConsulta" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-lg">Modificar</button>
              <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Deshabilitar Registro Seleccionado" OnClick="btnDeshabilitar_Click"/>
             <asp:Button ID="btnRestablecerPantalla" runat="server" Text="Restablecer" CssClass="btn btn-outline-primary btn-sm" ToolTip="Restablecer la pantalla" />
        </div>
        <br />
          <div>
            <asp:GridView ID="gvUsuario" runat="server" AllowPaging="true" OnPageIndexChanging="gvUsuario_PageIndexChanging" OnSelectedIndexChanged="gvUsuario_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="IdUsuario" HeaderText="ID" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="Perfil" HeaderText="Perfil" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Persona" HeaderText="Persona" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="CambiaClave" HeaderText="CambiaClave" />
                     <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
                </Columns  >
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
    </div>

        <!--PANTALLA DE MANTENIMIENTO DE INVENTARIO-->
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbMantenimientoUsuarios" runat="server" Text="Mantenimiento de Usuarios"></asp:Label>
          </div>
          <asp:ScriptManager ID="UsuarioScripManaher" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="UsuarioUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                  <div class="form-row">
                       <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionarSucursalMantenimiento" runat="server" Text="Sucursal"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarSucursalMantenimeinto" runat="server" CssClass="form-control" ToolTip="Seleccionar Sucursal" OnSelectedIndexChanged="ddlSeleccionarSucursalMantenimeinto_SelectedIndexChanged"></asp:DropDownList>
                         
                      </div>

                       <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionarOficinaMantenimiento" runat="server" Text="Oficina"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarOficinaMantenimiento" runat="server" CssClass="form-control" ToolTip="Seleccionar Oficina" OnSelectedIndexChanged="ddlSeleccionarOficinaMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionarDepartamentoMantenimiento" runat="server" Text="Departamento"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarDepartamentoMantenimiento" runat="server" ToolTip="Seleccionar Departamento" CssClass="form-control"></asp:DropDownList>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionarPerfilMantenimiento" runat="server" Text="Perfil"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarPerfilMantenimiento" runat="server" ToolTip="Seleccionar Perfil" CssClass="form-control"></asp:DropDownList>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbNombreUsuarioMantenimiento" runat="server" Text="Usuario"></asp:Label>
                          <asp:TextBox ID="txtNombreUsuarioMantenimiento" AutoCompleteType="Disabled" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbNombrePersonaMantenimeinto" runat="server" Text="Nombre"></asp:Label>
                          <asp:TextBox ID="txtNombrePersonaMantenimiento" AutoCompleteType="Disabled" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbClaveMantenimiento" runat="server" Text="Clave"></asp:Label>
                          <asp:TextBox ID="txtClaveMantenimiento" TextMode="Password" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbConfirmarClaveMantenimiento" runat="server" Text="Confirmar Clave"></asp:Label>
                          <asp:TextBox ID="txtConfirmarClaveMantenimiento" runat="server" TextMode="Password" MaxLength="20" CssClass="form-control"></asp:TextBox>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbEmailMantenimiento" runat="server" Text="Email"></asp:Label>
                          <asp:TextBox ID="txtEmailMantenimiento" AutoCompleteType="Disabled" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbTipoPersonaMantenimiento" runat="server" Text="Tipo de Persona"></asp:Label>
                         <asp:DropDownList ID="ddlSeleccionarTipoPersona" runat="server" ToolTip="Seleccionar el Tipo de Persona" CssClass="form-control"></asp:DropDownList>
                      </div>
                          <div class="form-group col-md-4">
                          <asp:Label ID="lbClaveSeguridad" runat="server" Text="Clave de Seguridad"></asp:Label>
                          <asp:TextBox ID="txtClaveSeguridadMantenimiento" runat="server" TextMode="Password" MaxLength="20" CssClass="form-control"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:CheckBox ID="cbEstatusMantenimiento" runat="server" Text="Estatus" CssClass="form-check-input" />
                      </div>
                      
                      <div class="form-group form-check">
                          <asp:CheckBox ID="cbLlevaEmailMantenimiento" AutoPostBack="true" runat="server" Text="¿Lleva Email?" CssClass="form-check-input" />
                      </div>

                      <div class="form-group form-check">
                          <asp:CheckBox ID="cbCambiaClave" runat="server" Text="Cambia Clave" CssClass="form-check-input" />
                      </div>
                  </div>
              </ContentTemplate>
          </asp:UpdatePanel>
          <!--BOTONES-->
          <div align="center">
               <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Guardar Registro" OnClick="btnGuardar_Click" />
           <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Modificar Registro" OnClick="btnModificar_Click" />
          </div>
          <br />
      </div>
    </div>
  </div>
</div>
</asp:Content>

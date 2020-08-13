<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoClaveSeguridad.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoClaveSeguridad" %>
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
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezado" runat="server" Text="Mantenimiento de Clave de Seguridad"></asp:Label>
        </div>
    </div>
    <!--FIN DEL ENCABEZADO DE LA PANTALLA-->
    <asp:Label ID="lbIdClaveSeguridad" runat="server" Text="IdClaveSeguridad" Visible="false"></asp:Label>
    <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
    <!--INICIO DE LOS CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbusuario" runat="server" Text="Nombre de Usuario"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" PlaceHolder="Usuario" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
        </div>

        <div>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Nuevo Registro" CssClass="btn btn-outline-primary btn-sm" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" ToolTip="Modificar Registro Seleccionado" CssClass="btn btn-outline-primary btn-sm" OnClick="btnModificar_Click" />
        </div>
        <br />
          <div>
            <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" ToolTip="Deshabilitar Registro Seleccionado" CssClass="btn btn-outline-primary btn-sm" OnClick="btnDeshabilitar_Click" />
            <asp:Button ID="btnAtras" runat="server" Text="Atras" ToolTip="Volver Atras" CssClass="btn btn-outline-primary btn-sm" />
        </div>
    </div>
    <!--FIN DE LOS CONTROLES DE BUSQUEDA-->
    <br />

    <!--INICIO DEL GRID-->
       <div class="container-fluid">
            <asp:GridView id="gbListadoClaveSeguridad" runat="server" AllowPaging="True" OnPageIndexChanging="gbListadoClaveSeguridad_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoClaveSeguridad_SelectedIndexChanged" OnRowDataBound="gbListadoClaveSeguridad_RowDataBound">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar" SelectText="Ver" ControlStyle-CssClass="btn btn-outline-primary btn-sm" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Clave" HeaderText="Clave" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    
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
    <!--FIN DEL GRID-->

    <!--INICIO DE LOS CONTROLES PARA EL MANTENIMIENTO-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbClaveNueva" runat="server" Visible="false" Text="Clave Nueva"></asp:Label>
                <asp:TextBox ID="txtClaveNueva" runat="server" Visible="false" PlaceHolder="Clave Nueva" CssClass="form-control" MaxLength="20" TextMode="Password"></asp:TextBox>
            </div> 
            <div class="form-group col-md-3">
                <asp:Label ID="lbConfirmarClave" runat="server" Visible="false" Text="Confirmar Clave"></asp:Label>
                <asp:TextBox ID="txtConfirmarClave" runat="server" Visible="false" PlaceHolder="Confirmar Clave" CssClass="form-control" MaxLength="20" TextMode="Password"></asp:TextBox>
            </div> 
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarUsuario" runat="server" Visible="false" Text="Seleccionar Usuario"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarusuario" Visible="false" runat="server" ToolTip="Seleccionar Usuario" CssClass="form-control"></asp:DropDownList>
            </div> 
            <div class="form-group col-md-3">
                <asp:Label ID="lbClaveSeguridad" runat="server" Visible="false" Text="Clave de Seguridad"></asp:Label>
                <asp:TextBox ID="txtClaveSeguridad" runat="server" Visible="false" PlaceHolder="Clave de Seguridad" CssClass="form-control" MaxLength="20" TextMode="Password"></asp:TextBox>
            </div> 

    </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox id="cbEstatus" runat="server" Visible="false" Text="Estatus" ToolTip="Estatus de Clave" CssClass="form-check-input" />
            </div>
        </div>
        <div align="center">
            <asp:Button ID="btnGuardar" runat="server" Visible="false" Text="Guardar" ToolTip="Guardar Operación" CssClass="btn btn-outline-primary btn-sm" OnClick="btnGuardar_Click" />
             <asp:Button ID="btnVolver" runat="server" Visible="false" Text="Volver" ToolTip="Volver" CssClass="btn btn-outline-primary btn-sm" OnClick="btnVolver_Click" />
        </div>
        </div>
    <!--FIN DE LOS CONTROLES PARA EL MANTENIMIENTO-->
</asp:Content>

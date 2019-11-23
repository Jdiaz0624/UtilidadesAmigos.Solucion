<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimeintoPerfiles.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimeintoPerfiles" %>
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
    <!--INICIO DEL ENCABEZADO-->
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezado" runat="server" Text="Mantenimiento de Perfiles">
            </asp:Label>
        </div>
    </div>
    <!--FIN DEL ENCABEZADO-->
    <asp:Label ID="lbIdPerfil" runat="server" Text="IdPerfil" Visible="false"></asp:Label>
    <asp:Label ID="lbEstatus" runat="server" Text="Estatus" Visible="false"></asp:Label>

    <!--INICIO DE LO CONTROLES DE BUSQUEDA Y MANTENIMIENTO-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbDescripcionPerfil" runat="server" Text="Perfil"></asp:Label>
                <asp:TextBox ID="txtDescripcionPerfil" runat="server" PlaceHolder="Perfil" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbClaveSeguridad" runat="server" Text="Clave de Seguridad"></asp:Label>
                <asp:TextBox ID="txtClaveSeguridad" runat="server" PlaceHolder="Clave de Seguridad" MaxLength="20" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbEstatus" runat="server" Visible="false" ToolTip="Estatus de Perfil" Text="Estatus" CssClass="form-check-input" />
            </div>
        </div>
        <div>
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnNuevo" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Guardar Perfil" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" />
        </div>
        <br />
        <div>
            <asp:Button ID="btnModificar" runat="server" Enabled="false" CssClass="btn btn-outline-primary btn-sm" Text="Modificar" ToolTip="Modificar Registro Seleccionado" OnClick="btnModificar_Click" />
            <asp:Button ID="btnDeshabilitar" runat="server" Enabled="false" CssClass="btn btn-outline-primary btn-sm" Text="Deshabilitar" ToolTip="Deshabilitar Registro Seleccionado" OnClick="btnDeshabilitar_Click" />
            <asp:Button ID="btnAtras" runat="server" Enabled="false" Text="Atras" CssClass="btn btn-outline-primary btn-sm" ToolTip="Volver atras" OnClick="btnAtras_Click" />
        </div>
    </div>
    <!--FIN DE LOS CONTROLES DE BUSQUEDA Y MANTENIMIENTO-->
    <br />
    <!--INICIO DEL GRID-->
     <div class="container-fluid">
            <asp:GridView id="gbListadoPerfiles" runat="server" AllowPaging="True" OnPageIndexChanging="gbListadoPerfiles_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoPerfiles_SelectedIndexChanged" OnRowDataBound="gbListadoPerfiles_RowDataBound">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="Detalle" SelectText="Ver" ControlStyle-CssClass="btn btn-outline-primary btn-sm" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdPerfil" HeaderText="ID" />
                    <asp:BoundField DataField="perfil" HeaderText="Perfil" />
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
    <!--FIN DEL GRID-->
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Inventario" %>
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

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTituloConsulta" runat="server" Text="Consulta de Inventario"></asp:Label>
             <asp:Label ID="lbArticulo" Visible ="false" runat="server" Text="Consulta de Inventario"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarSurcursalConsulta" runat="server" Text="Sucursal"></asp:Label>
                <asp:DropDownList ID="ddlSucursalCOnsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Sucursal"></asp:DropDownList>
            </div>
                <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarDepartamentoConsulta" runat="server" Text="Departamento"></asp:Label>
                <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Departamento"></asp:DropDownList>
            </div>
                <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarTipoArticuloConsulta" runat="server" Text="Tipo de Articulo"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoArticulo" runat="server" CssClass="form-control" ToolTip="Seleccionar Tipo de Articulo"></asp:DropDownList>
            </div>
                <div class="form-group col-md-3">
                <asp:Label ID="lbDescripcionConsulta" runat="server" Text="Descripción"></asp:Label>
               <asp:TextBox ID="txtDescripcionCOnsulta" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
            </div>
        </div>
         <div>
              <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-lg">Nuevo</button>
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExportar_Click" /><br /><br />
                <button type="button" id="btnCobertura" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-lg">Modificar</button>
              <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Deshabilitar Registro Seleccionado" OnClick="btnDeshabilitar_Click"/>
        </div>
    <div>
            <asp:GridView ID="gvInventario" runat="server" AllowPaging="true" OnPageIndexChanging="gvInventario_PageIndexChanging" OnSelectedIndexChanged="gvInventario_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="#" HeaderText="ID" />
                    <asp:BoundField DataField="#" HeaderText="Sucursal" />
                    <asp:BoundField DataField="#" HeaderText="Departamento" />
                    <asp:BoundField DataField="#" HeaderText="Tipo Producto" />
                    <asp:BoundField DataField="#" HeaderText="Descripción" />
                    <asp:BoundField DataField="#" HeaderText="Estatus" />
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
      ...
    </div>
  </div>
</div>
</asp:Content>

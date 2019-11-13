<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Departamentos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Mantenimientos.Departamentos" %>
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


        .Custom{
            width: 78px;
        }
          .Mantenimiento{
            width: 100px;
        }
    </style>
    <script type="text/javascript">
        function ErrorDeshabilitar() {
            alert("Error al tratar de deshabilitar este registro")
        }
    </script>

<div class="container-fluid">
    <div align="Center" class="jumbotron">
        <asp:Label ID="lbEncabezado" runat="server" Text="Mantenimiento de Departamentos"></asp:Label>
    </div>

    <br />
    <div class="form-row">
        <div class="form-group col-md-3">
             <asp:Label ID="lbOficinaConsulta" runat="server" Text="<%$Resources:Traducciones,Oficina %>"></asp:Label>
            <asp:DropDownList ID="ddloficinaConsulta" runat="server" CssClass="form-control" ToolTip="<%$Resources:Traducciones,Oficina %>"></asp:DropDownList>
        </div>
        
        <div class="form-group col-md-3">
               <asp:Label ID="lbDescripcion" Text="<%$Resources:Traducciones,Departamento %>" runat="server"></asp:Label>
            <asp:TextBox ID="txtDescripcionDepartamento" runat="server" CssClass="form-control" AutoCompleteType="Disabled" Palceholder="<%$Resources:Traducciones,Departamento %>" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-3">
         <asp:Button ID="btnConsultar" runat="server" Text="<%$Resources:Traducciones,Buscar %>" ToolTip="<%$Resources:Traducciones,Buscar %>" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnNuevo" runat="server"  Text="<%$Resources:Traducciones,Nuevo %>" ToolTip="<%$Resources:Traducciones,Nuevo %>" CssClass="btn btn-outline-primary btn-sm Custom"  OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRestabelcer" runat="server" Text="<%$Resources:Traducciones,Atras %>" ToolTip="<%$Resources:Traducciones,Atras %>" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnRestabelcer_Click" />
    </div>
    <br />
        <div class="col-md-3">
             <asp:Button ID="btnModificar" runat="server" Enabled="false" Text="<%$Resources:Traducciones,Actualizar %>" ToolTip="<%$Resources:Traducciones,Actualizar %>" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server"  Text="<%$Resources:Traducciones,Eliminar %>" ToolTip="<%$Resources:Traducciones,Eliminar %>" CssClass="btn btn-outline-danger btn-sm Custom" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnExportar" runat="server"  Text="Exportar" ToolTip="Exportar a exel" CssClass="btn btn-outline-success btn-sm Custom" OnClick="btnExportar_Click" />
    </div>
</div>
    <br />


    <div class="container-fluid">
        <%--en esta parte agregamos el grid--%>
        <asp:GridView ID="gvDepartamentos" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gvDepartamentos_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="gvDepartamentos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="<%$Resources:Traducciones,Seleccionar %>"  ControlStyle-CssClass="btn btn-outline-info btn-sm" ShowSelectButton="True" />
                <asp:BoundField DataField="IdDepartamento" HeaderText="<%$Resources:Traducciones,ID %>" />
                <asp:BoundField DataField="Oficina" HeaderText="<%$Resources:Traducciones,Oficina %>" />
                <asp:BoundField DataField="Departamento" HeaderText="<%$Resources:Traducciones,Departamento %>" />
                <asp:BoundField DataField="Estatus" HeaderText="<%$Resources:Traducciones,Estatus %>" />
                <asp:BoundField DataField="CreadoPor" HeaderText="<%$Resources:Traducciones,CreadoPor %>" />
                <asp:BoundField DataField="FechaAdiciona" HeaderText="<%$Resources:Traducciones,FechaAdiciona %>" />
                <asp:BoundField DataField="ModificadoPor" HeaderText="<%$Resources:Traducciones,ModificadoPor %>" />
                <asp:BoundField DataField="FechaModifica" HeaderText="<%$Resources:Traducciones,FechaModifica %>" />
            </Columns>
            <EditRowStyle BackColor="#7BC5FF" />
            <FooterStyle BackColor="#7BC5FF" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#7BC5FF" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" Font-Bold="true" />
            <RowStyle BackColor="#FBFCFF" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-3">
                  <asp:Label ID="lbOficinaMantenimiento" runat="server" Visible="false" Text="<%$Resources:Traducciones,Oficina %>"></asp:Label>
        <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server" Visible="false" CssClass="form-control" ToolTip="<%$Resources:Traducciones,Oficina %>"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                 <asp:Label ID="lbOficinaDepartamento" runat="server" Visible="false" Text="<%$Resources:Traducciones,Departamento %>"></asp:Label>
        <asp:TextBox ID="txtDescripcionDepartamentoMAN" runat="server" Visible="false" AutoCompleteType="Disabled" PlaceHolder="<%$Resources:Traducciones,Departamento %>" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <div class="form-check">
                
        <asp:CheckBox ID="cbEstatus" runat="server" Visible="false" Text="<%$Resources:Traducciones,Estatus %>" CssClass="CheckBox-Formularios" ToolTip="<%$Resources:Traducciones,Estatus %>" />
            </div>
        <%--en esta parte agregamos los controles para el mantenimiento--%>
      
       
        <div align="Center">
            <asp:Button ID="btnGuardar" runat="server" Visible="false" Text="<%$Resources:Traducciones,Guardar %>" CssClass="btn btn-outline-primary btn-lg Mantenimiento" ToolTip="<%$Resources:Traducciones,Guardar %>" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnAtras" runat="server" Visible ="false" Text="<%$Resources:Traducciones,Atras %>" CssClass="btn btn-outline-primary btn-lg Mantenimiento" ToolTip="<%$Resources:Traducciones,Atras %>" OnClick="btnAtras_Click" />
            <asp:Label ID="lbIdMantenimiento" runat="server" Text="IdMantenimiento" Visible="false"></asp:Label>
            <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>

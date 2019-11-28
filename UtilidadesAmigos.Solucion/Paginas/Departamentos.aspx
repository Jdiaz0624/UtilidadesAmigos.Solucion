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
            width: 100px;
            height: 40px;
        }
          .Mantenimiento{
            width: 100px;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {




        });
    </script>


<!--INICIO DEL ENCABEZADO DE LA PANTALLA-->
    <div class="container-fluid">
    <div align="Center" class="jumbotron">
        <asp:Label ID="lbEncabezado" runat="server" Text="Mantenimiento de Departamentos"></asp:Label>
    </div>
        <div>
            <asp:Label ID="lbIdDepartamento" runat="server" Text="IdDepartamento" Visible="false"></asp:Label>
            <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
        </div>
        <!--FIN DEL ENCABEZADO DE LA PANTALLA-->


<!--INICIO DE LOS CONTROLES PARA REALIZAR LA CONSULTA-->
            <div class="form-row">
        <div class="form-group col-md-3">
             <asp:Label ID="lbOficinaConsulta" runat="server" Text="Oficina"></asp:Label>
            <asp:DropDownList ID="ddloficinaConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Oficina"></asp:DropDownList>
        </div>
        
        <div class="form-group col-md-3">
               <asp:Label ID="lbDescripcion" Text="Departamento" runat="server"></asp:Label>
            <asp:TextBox ID="txtDescripcionDepartamento" runat="server" CssClass="form-control" AutoCompleteType="Disabled" Palceholder="Departamento" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div>
         <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnNuevo" runat="server"  Text="Nuevo" ToolTip="Nuevo" CssClass="btn btn-outline-primary btn-sm Custom"  OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRestabelcer" runat="server" Text="Atras" ToolTip="Atras" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnRestabelcer_Click" />
    </div>
    <br />
        <div>
             <asp:Button ID="btnModificar" runat="server" Enabled="false" Text="Actualizar" ToolTip="Actualizar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Enabled="false" Text="Deshabilitar" ToolTip="Deshabilitar Registro Seleccionado" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnExportar" runat="server"  Text="Exportar" ToolTip="Exportar a exel" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
    <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <!--FIN DE LOS CONTROLES PARA REALIZAR LA CONSULTA-->
</div>
    <br />


<!--INICIO DEL GRID-->
        <div class="container-fluid">
        <%--en esta parte agregamos el grid--%>
        <asp:GridView ID="gvDepartamentos" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gvDepartamentos_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="gvDepartamentos_SelectedIndexChanged" OnRowDataBound="gvDepartamentos_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm Custom" ShowSelectButton="True" />
                <asp:BoundField DataField="IdDepartamento" HeaderText="ID" />
                <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                <asp:BoundField DataField="CreadoPor" HeaderText="Creado por" />
                <asp:BoundField DataField="FechaAdiciona" HeaderText="Fecha Adiciona" />
                <asp:BoundField DataField="ModificadoPor" HeaderText="Modificado Por" />
                <asp:BoundField DataField="FechaModifica" HeaderText="Fecha Modifica" />
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
                  <asp:Label ID="lbOficinaMantenimiento" Visible="false" runat="server"  Text="Oficina"></asp:Label>
        <asp:DropDownList ID="ddlOficinaMantenimiento" Visible="false" runat="server"  CssClass="form-control" ToolTip="Oficina"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                 <asp:Label ID="lbOficinaDepartamento" Visible="false" runat="server"  Text="Departamento"></asp:Label>
        <asp:TextBox ID="txtDescripcionDepartamentoMAN" runat="server" Visible="false"  AutoCompleteType="Disabled" PlaceHolder="Departamento" CssClass="form-control"></asp:TextBox>
            </div>
          <div class="form-group col-md-3">
               <asp:Label ID="lbClaveSeguridad" Visible="false" runat="server"  Text="Clave de Seguridad"></asp:Label>
               <asp:TextBox ID="txtclaveSeguridad" runat="server" TextMode="Password" Visible="false"  AutoCompleteType="Disabled" PlaceHolder="Clave de Seguridad" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:CheckBox ID="cbEstatus" runat="server"  Text="Estatus" Visible="false" CssClass="form-check-input" ToolTip="Estatus" />
                    
                </div>
        
            </div>
        <%--en esta parte agregamos los controles para el mantenimiento--%>
      
       
        <div align="Center">
            <asp:Button ID="btnGuardar" runat="server"  Text="Guardar" Visible="false" CssClass="btn btn-outline-primary btn-lg Mantenimiento" ToolTip="Guardar Registro" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnAtras" runat="server"  Text="Atras" Visible="false" CssClass="btn btn-outline-primary btn-lg Mantenimiento" ToolTip="Volver Atras" OnClick="btnAtras_Click" />
        </div>
    </div>
    <!--FIN DE LOS CONTROLES PARA EL MANTENIMIENTO-->
</asp:Content>

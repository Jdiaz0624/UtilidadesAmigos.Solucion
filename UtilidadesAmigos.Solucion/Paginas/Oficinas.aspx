<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Oficinas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Mantenimientos.Oficinas" %>
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
    </style>
    <!--INICIO DEL ENCABEZADO DE LA PANTALLA-->
   <div class="container-fluid">
       <div align="Center" class="jumbotron">
       <asp:Label ID="lbEncabezado" runat="server"  Text="Mantenimiento de Oficinas"></asp:Label>
   </div>
       <div>
           <asp:Label ID="lbIdOficina" runat="server" Text="IdOficina" Visible="false"></asp:Label>
           <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
       </div>
       <!--FIN DEL ENCABEZADO DE LA PANTALLA-->
       <br />
       <div class="form-row">
            <div class="form-group col-md-3">
               <asp:Label ID="lbSucursalConsulta" Text="Sucursal" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
           </div>

           <div class="form-group col-md-3">
               <asp:Label ID="lbDescripcion" Text="Oficina" runat="server"></asp:Label>
            <asp:TextBox ID="txtDescripcionOficina" runat="server" CssClass="form-control" Palceholder="Descripcion Oficina" MaxLength="100"></asp:TextBox>
           </div>
       </div>





            <div class="col-md-3">
                    <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Nuevo Registro" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRestabelcer" runat="server" Text="Atras" Enabled="false" ToolTip="Restablecer Pantalla" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnRestabelcer_Click" /><br />
     

            </div>
       <br />
       <div class="col-md-3">
                           <asp:Button ID="btnModificar" runat="server" Enabled="false" Text="Modificar" ToolTip="Modificar Registro seleccionado" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Enabled="false" ToolTip="Deshabilitar registro seleccionado" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" ToolTip="Exportar a exel" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
       </div>
       <br />



   </div>



            



    <div class="container-fluid">
        <%--en esta parte agregamos el grid--%>
        <asp:GridView ID="gvOficinas" runat="server"  AutoGenerateColumns="False" OnPageIndexChanging="gvOficinas_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="gvOficinas_SelectedIndexChanged" OnDataBound="gvOficinas_DataBound" OnRowDataBound="gvOficinas_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button"  ControlStyle-CssClass="btn btn-outline-primary btn-sm Custom" HeaderText="Select" ShowSelectButton="True" />
                 
                <asp:BoundField DataField="IdOficina"   HeaderText="IdOficina" />
                 <asp:BoundField DataField="Sucursal"   HeaderText="Sucursal" />
                <asp:BoundField DataField="Oficina"  HeaderText="Oficina" />
                <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                <asp:BoundField DataField="Creadopor" HeaderText="Creado Por" />
                <asp:BoundField DataField="FechaAdiciona" HeaderText="Fecha Creado" />
             <%--   <asp:BoundField DataField="ModificadoPor" HeaderText="Modificado por" />
                <asp:BoundField DataField="FechaModifica" HeaderText="Fecha Modifica" />--%>
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
    <div>
        <%--en esta parte agregamos los controles para el mantenimiento--%>
        <div class="container-fluid">
            <div class="form-row">
                    <div class="form-group col-md-3">
               <asp:Label ID="lbSeleccionarSucursalmantenimiento" Text="Sucursal" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalMantenimiento" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
           </div>
                <div class="form-group col-md-3">
                    <asp:Label ID="lbOficina" Visible="false" runat="server" Text="Ingrese Oficina"></asp:Label>
                    <asp:TextBox ID="txtDescripcionOficinaMAn" Visible="false" runat="server" AutoCompleteType="Disabled" PlaceHolder="Descripcion de Oficina" CssClass="form-control"></asp:TextBox>
                    
                </div>
                <div class="form-group col-md-3">
                    <asp:Label ID="lbClaveSeguridad" runat="server" Visible="false" Text="Clave de Seguridad"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridad" runat="server" Visible="false" TextMode="Password" PlaceHolder="Clave de Seguridad" CssClass="form-control" MaxLength="20"></asp:TextBox>
                </div>
            </div>
            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:CheckBox ID="cbEstatus" runat="server" Visible="false" Text="Estatus" CssClass="form-check-input" ToolTip="Estatus de Oficina" />
                </div>
            </div>
        </div>
        <div align="Center">
            <asp:Button ID="btnGuardar" Visible="false" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm Custom" ToolTip="Terminar Operacion" OnClick="btnGuardar_Click" />
             <asp:Button ID="btnVolver" Visible="false" runat="server" Text="Volver" CssClass="btn btn-outline-primary btn-sm Custom" ToolTip="Volver Atras" OnClick="btnVolver_Click"/>
        </div>
    </div>
</asp:Content>

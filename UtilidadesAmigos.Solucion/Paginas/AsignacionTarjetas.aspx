 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AsignacionTarjetas.aspx.cs" EnableViewState ="true" Inherits="UtilidadesAmigos.Solucion.Paginas.AsignacionTarjetas" %>
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
        function Mensajes() {
            alert("Hola Mundo")
        }
    </script>
    <!--AQUI INICIA LA PARTE DEL ENCABEZADO-->
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezado" runat="server" Text="Asignación de tarjetas de acceso"></asp:Label>
        </div>
    </div>
    <!--AQUI TERMINA LA PARTE DEL ENCABEZADO-->

    <!--AQUI INICIAN LOS CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-6">
                      <asp:Label ID="lbOficinaConsulta" runat="server" Text="Seleccionar Oficina"></asp:Label>
                <asp:DropDownList ID="ddlOficinaConsulta" runat="server" AutoPostBack="true" ToolTip="Seleccionar Oficina" CssClass="form-control" OnSelectedIndexChanged="ddlOficinaConsulta_SelectedIndexChanged1"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbDepartamentoConsulta" runat="server" Text="Seleccionar Departamento"></asp:Label>
                <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" AutoPostBack="true" ToolTip="Seleccionar Departamento" CssClass="form-control" OnSelectedIndexChanged="ddlDepartamentoConsulta_SelectedIndexChanged1"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbEmpleadoConsulta" runat="server" Text="Seleccionar Colaborador"></asp:Label>
                <asp:DropDownList ID="ddlEmpleadoConsulta" runat="server" ToolTip="Seleccionar Colaborador" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">              
                <asp:Label ID="lbNumeroTarjetaConsulta" runat="server" Text="Numero de tarjeta de Acceso"></asp:Label>
                <asp:TextBox ID="txtNumerotarjetaConsulta" runat="server" PlaceHolder="Ingrese Numero tarjeta" MaxLength="100" TextMode="Number"  CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                 <asp:CheckBox ID="cbFiltrarPorRangoFechaConsulta" runat="server" Text="Filtrar Por Rango de Fecha" CssClass="form-check-input" />
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                   <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="Fecha Desde"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" PlaceHolder="Fecha Desde" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaHastaConsulta" runat="server" Text="Fecha Hasta"></asp:Label>
                <asp:TextBox ID="txtFechaHastaConsulta" runat="server" PlaceHolder="Fecha Hasta" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    <!--AQUI TERMINAN LOS CONTROLESD DE BUSQUEDA-->

    <!--AQUI COLOCAMOS LOS BOTONES PARA REALIZAR EL MANTENIMIENTO CORRESPONDIENTE-->
    <div class="container-fluid">
        <div>
            <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar registros" CssClass="btn btn-outline-primary btn-sm" OnClick="btnConsultar_Click" />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear un nuevo registro" CssClass="btn btn-outline-primary btn-sm" OnClick="btnNuevo_Click1" />
                <asp:Button ID="btnAtras" runat="server" Text="Atras" ToolTip="Volver Atras" CssClass="btn btn-outline-primary btn-sm" OnClick="btnAtras_Click1" Enabled="False" />
        </div>
        <br />
        <div>
                <asp:Button ID="btnModificar" runat="server" Text="Actualizar" ToolTip="Actualiza un registro seleccionado" CssClass="btn btn-outline-primary btn-sm" Enabled="False" OnClick="btnModificar_Click1" />
                <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" ToolTip="Deshabilita un registro seleccionado" CssClass="btn btn-outline-primary btn-sm" Enabled="False" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Quieres deshabilitar este registro?');" />
                <asp:Button ID="btnExportar" runat="server" Text="Exportar" ToolTip="Exportar la data a exel" CssClass="btn btn-outline-primary btn-sm" OnClick="btnExportar_Click" />
        </div>
    </div>
    <!--AQUI FINALIZAN LOS BOTONES CORRESPONDIENTE AL MANTENIMEINTO-->

    <br />

    <!--AQUI INICIA EL GRID-->
     <div class="container-fluid">
            <asp:GridView ID="gvTarjetaAcceso" runat="server" AllowPaging="true" OnPageIndexChanging="gvTarjetaAcceso_PageIndexChanging" OnSelectedIndexChanged="gvTarjetaAcceso_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdTarjetaAcceso" HeaderStyle-Width="11%" HeaderText="ID" />
                    <asp:BoundField DataField="Oficina" HeaderStyle-Width="11%" HeaderText="Oficina" />
                    <asp:BoundField DataField="Departamento" HeaderStyle-Width="11%" HeaderText="Departamento" />
                    <asp:BoundField DataField="Empleado" HeaderStyle-Width="12%" HeaderText="Empleado" />
                    <asp:BoundField DataField="SecuenciaInterna" HeaderStyle-Width="11%" HeaderText="Secuencia Interna" />
                    <asp:BoundField DataField="NumeroTarjeta" HeaderStyle-Width="11%" HeaderText="Numero de tarjeta" />
                    <asp:BoundField DataField="FechaEntrega" HeaderStyle-Width="11%" HeaderText="Fecha" />
                    <asp:BoundField DataField="Estatus" HeaderStyle-Width="11%" HeaderText="Estatus" />
                </Columns>

                  <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

            </asp:GridView>
             

        </div>
    <!--AQUI TERMINA EL GRID-->
    <!--AQUI PONEMOS LOS CONTROLES PARA REALIZAR EL MANTENIMIENTO-->
    <div class="container-fluid">
        <div class="form-row">
        <div class="form-group col-md-6">
            <asp:Label ID="lbOficinaMantenimiento" Visible="false" runat="server" Text="Seleccionar Oficina"></asp:Label>
            <asp:DropDownList ID="ddlOficinaMantenimiento" AutoPostBack="true" Visible="false" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control" OnSelectedIndexChanged="ddlOficinaMantenimiento_SelectedIndexChanged1"></asp:DropDownList>
        </div>
            <div class="form-group col-md-6">
                 <asp:Label ID="lbDepartamentoMantenimiento" Visible="false" runat="server" Text="Seleccionar Departamentos" CssClass="LabelFormularios"></asp:Label>
            <asp:DropDownList ID="ddlDepartamentoMantenimiento" Visible="false" AutoPostBack="true" runat="server" CssClass="form-control" ToolTip="Seleccionar Departamentos" OnSelectedIndexChanged="ddlDepartamentoMantenimiento_SelectedIndexChanged1"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                    <asp:Label ID="lbEmpleadoMantenimiento" Visible="false" runat="server" Text="Seleccionar Colaborador"></asp:Label>
                      <asp:DropDownList ID="ddlEmpleadoMantenimiento" Visible="false" AutoPostBack="true" runat="server" CssClass="form-control" ToolTip="Seleccionar Empleado"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                    <asp:Label ID="lbNumeroTarjetraMantenimiento" Visible="false" runat="server" Text="Numero de tarjeta"></asp:Label>
                    <asp:TextBox ID="txtNumerotarjetaMantenimiento" Visible="false" runat="server" CssClass="form-control" PlaceHolder="Ingrese Numero de Tarjeta de Acceso" TextMode="Number" MaxLength="100"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaEntregaMantenimiento" Visible="false" runat="server" Text="Fecha de Entrega"></asp:Label>
                    <asp:TextBox ID="txtFechaEntregaMantenimiento" Visible="false" runat="server" CssClass="form-control" TextMode="Date" PlaceHolder="Fecha de Entrega"></asp:TextBox>
            </div>
    </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbEstatusMantenimiento" Visible="false" runat="server" CssClass="form-control" Text="Estatus" ToolTip="Estatus de Tarjeta" />
            </div>
        </div>
    </div>
       <div align="Center">
                        <asp:Button ID="btnGuardarMantenimiento" Visible="false" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Guardar" ToolTip="Guardar Operación" OnClick="btnGuardarMantenimiento_Click" />
                        <asp:Button ID="btnAtrasMantenimiento" Visible="false" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Atras" ToolTip="Volver Atras" OnClick="btnAtrasMantenimiento_Click" /><br />
                        <asp:Label ID="lbIdMantenimiento" runat="server" Text="IdMantenimiento" Visible="false"></asp:Label>
                        <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
                    </div>
    <!--AQUI FINALIZAN LOS CONTROLES PARA REALIZAR EL MANTENIMIENTO-->
</asp:Content>

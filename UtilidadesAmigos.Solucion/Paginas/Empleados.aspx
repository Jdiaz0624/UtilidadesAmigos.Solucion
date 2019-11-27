<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
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
        $(document).ready(function () {
            //OCULTAMOS LOS CONTROLES
        

            


          <%--  $('#<%=btnGuardarMantenimiento.ClientID%>').click(function () {
                 //VALIDAMOS LOS CAMPOS VACIOS
                var Oficina = $('#<%=txtNombreMantenimiento.ClientID%>').val().length;
                var ClaveSeguridad = $('#<%=txtClaveSeguridad.ClientID%>').val().length;

                if (Oficina < 1) {
                    alert("El campo nombre no puede estar vacio")
                    $('#<%=txtNombreMantenimiento.ClientID%>').css("border-color", "red");
                    return false;
                } else
                {
                    //VALIDAMOS EL CAMPO CLAVE DE SEGURIDAD
                    
                    if (ClaveSeguridad < 1) {
                        alert("Favor de ingresar la clave de seguridad para proceder")
                        $('#<%=txtClaveSeguridad.ClientID%>').css("border-color", "red");
                        return false;
                    }
                    else
                    {
                         return true;

                    }
                   
                    
                    
                }
            })--%>



           


        })
    </script>
    <!--INICIO DEL ENCABEZADO DE LA PANTALLA-->
    <div class="container-fluid">
        <div align="center" class="jumbotron">
            <asp:Label ID="lbEncabezadoPantalla" runat="server" Text="Mantenimeinto de Empleados"></asp:Label>
        </div>
    </div>
    <div>
        <asp:Label ID="lbIdEmpleado" runat="server" Text="IdEmpleado" Visible="false"></asp:Label>
        <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
    </div>
    <!--FIN DEL ENCABEZADO DE LA PANTALLA-->

    <!--INICIO DE LOS CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbOficinaConsulta" runat="server" Text="Oficina"></asp:Label>
                <asp:DropDownList ID="ddlOficinaConsulta" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="Oficina" OnSelectedIndexChanged="ddlOficinaConsulta_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbDepartamentoConsulta" runat="server" Text="Departamento"></asp:Label>
                <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" CssClass="form-control" ToolTip="Departamento"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbNombreConsulta" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="form-control" PlaceHolder="Nombre" MaxLength="100"></asp:TextBox>
            </div>
        </div>
    </div>
    <!--FIN DE LOS CONTROLES DE BUSQUEDA-->

    <!--INICIO DE LOS BOTONES DE LA PANTALLA DE CONSULTA-->
    <div>
        <div class="container-fluid">
                 <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Buscar" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
                <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Nuevo" ToolTip="Crear Nuevo Registro" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnatrasConsulta" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Atras" ToolTip="Restablecer la pantalla" OnClick="btnatrasConsulta_Click"/>
        </div>
        <br />
        <div class="container-fluid">
              <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Actualizar" Enabled="false" ToolTip="Actualizar registro seleccionado" OnClick="btnModificar_Click" />
                <asp:Button ID="btnDeshabilitar" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Deshabilitar" Enabled="false" ToolTip="Deshabilitar registro seleccionado" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Quieres desabilitar este registro?');" />
                <asp:Button ID="btnExportar" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Exportar" ToolTip="Exportar Registros a exel" OnClick="btnExportar_Click" />
        </div>
    </div>
    <!--FIN DE LOS BOTONES DE LA PANTALLA DE CONSULTA-->

    <br />

    <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvEmpleados" runat="server" AllowPaging="true" OnPageIndexChanging="gvEmpleados_PageIndexChanging" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="gvEmpleados_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdEmpleado" HeaderText="ID" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="CreadoPor" HeaderText="Creado Por" />
                    <asp:BoundField DataField="FechaAdiciona" HeaderText="Fecha Adiciona" />
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
    <!--FIN DEL GRID-->

    <!--AQUI COMIENZAN LOS CONTROLES PARA REALIZAR LOS MANTENIMIENTOS CORRESPONDIENTES-->
    <div  class="container-fluid">
        <div " class="form-row">
            <div class="form-group col-md-6">
                 <asp:Label ID="lbOficinaMantenimiento" Visible="false" runat="server"  Text="Oficina"></asp:Label>
                <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server" Visible="false" CssClass="form-control"  AutoPostBack="True"  ToolTip="Seleccionar Oficina" OnSelectedIndexChanged="ddlOficinaMantenimiento_SelectedIndexChanged"></asp:DropDownList><br />
            </div>

               <div class="form-group col-md-6">
                    <asp:Label ID="lbDepartamentoMantenimiento" Visible="false"  runat="server"   Text="Departamento"></asp:Label>
                   <asp:DropDownList ID="ddlDepartamenoMantenimiento" Visible="false" runat="server" CssClass="form-control"  ToolTip="Seleccionar Departamento"></asp:DropDownList>
            </div>

               <div class="form-group col-md-6">
                    <asp:Label ID="lbNombreMantenimiento" runat="server" Visible="false"  Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombreMantenimiento" runat="server" Visible="false" AutoCompleteType="Disabled" CssClass="form-control"  PlaceHolder="Nombre" MaxLength="100"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
             <asp:Label ID="lbClaveSeguridad" runat="server" Visible="false" Text="Clave de Seguridad"></asp:Label>
            <asp:TextBox ID="txtClaveSeguridad" runat="server" Visible="false" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Password"  PlaceHolder="Clave de Seguridad" MaxLength="20"></asp:TextBox>
            </div>
        </div>
      <div class="form-group form-check">
          <div class="form-check-inline">
                   <asp:CheckBox ID="cbEstatusMantenimiento" Visible="false" runat="server" Text="Estatus" CssClass="form-check-input"  ToolTip="Estatus" />
          </div>
      </div>
        <div align="Center">
                        <asp:Button ID="btnGuardarMantenimiento" Visible="false" runat="server" CssClass="btn btn-outline-primary btn-sm Custom"  Text="Guardar" ToolTip="Guardar Operación" OnClick="btnGuardarMantenimiento_Click"/>
                        <asp:Button ID="btnAtrasMantenimiento" Visible="false" runat="server" CssClass="btn btn-outline-primary btn-sm Custom"  Text="Atras" ToolTip="Volver Atras" OnClick="btnAtrasMantenimiento_Click" />
                    </div>
    </div>
    <!--AQUI TERMINAN LOS CONTROLES PARA REALIZAR LOS MANTENIMIENTOS CORRESPONDIENTES-->
</asp:Content>

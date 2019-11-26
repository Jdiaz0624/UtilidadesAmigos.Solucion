﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Empleados" %>
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
  
        })
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=btnGuardarMantenimiento.ClientID%>').click(function () {
                 //VALIDAMOS LOS CAMPOS VACIOS
                var Oficina = $('#<%=txtNombreMantenimiento.ClientID%>').val().length;
                if (Oficina < 1) {
                    alert("El campo nombre no puede estar vacio")
                    $('#<%=txtNombreMantenimiento.ClientID%>').css("border-color", "red");
                    return false;
                } else
                {
                    //VALIDAMOS EL CAMPO CLAVE DE SEGURIDAD
                    var ClaveSeguridad = $('#<%=txtClaveSeguridad.ClientID%>').val().length;
                    if (ClaveSeguridad < 1) {
                        alert("Favor de ingresar la clave de seguridad para proceder")
                        $('#<%=txtClaveSeguridad.ClientID%>').css("border-color", "red");
                        return false;
                    }
                    
                    
                }
            })



           


        })
    </script>
    <!--INICIO DEL ENCABEZADO DE LA PANTALLA-->
    <div class="container-fluid">
        <div align="center" class="jumbotron">
            <asp:Label ID="lbEncabezadoPantalla" runat="server" Text="Mantenimeinto de Empleados"></asp:Label>
        </div>
    </div>
    <!--FIN DEL ENCABEZADO DE LA PANTALLA-->

    <!--INICIO DE LOS CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbOficinaConsulta" runat="server" Text="Oficina"></asp:Label>
                <asp:DropDownList ID="ddlOficinaConsulta" runat="server" CssClass="form-control" AutoPostBack="true" ToolTip="Oficina" OnSelectedIndexChanged="ddlOficinaConsulta_SelectedIndexChanged"></asp:DropDownList>
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
            <asp:GridView ID="gvEmpleados" runat="server" AllowPaging="true" OnPageIndexChanging="gvEmpleados_PageIndexChanging" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="10%" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdEmpleado" HeaderStyle-Width="5%" HeaderText="ID" />
                    <asp:BoundField DataField="Oficina" HeaderStyle-Width="15%" HeaderText="<%$Resources:Traducciones,Oficina %>" />
                    <asp:BoundField DataField="Departamento" HeaderStyle-Width="5%" HeaderText="<%$Resources:Traducciones,Departamento %>" />
                    <asp:BoundField DataField="Nombre" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,Nombre %>" />
                    <asp:BoundField DataField="Estatus" HeaderStyle-Width="10%" HeaderText="<%$Resources:Traducciones,Estatus %>" />
                    <asp:BoundField DataField="CreadoPor" HeaderStyle-Width="20%" HeaderText="<%$Resources:Traducciones,CreadoPor %>" />
                    <asp:BoundField DataField="FechaAdiciona" HeaderStyle-Width="15%" HeaderText="<%$Resources:Traducciones,FechaAdiciona %>" />
                </Columns  >
                <EditRowStyle BackColor="#999999"  />
                <FooterStyle BackColor="#5D7B9D" HorizontalAlign="Left" Font-Bold="True" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
    </div>
    <!--FIN DEL GRID-->

    <!--AQUI COMIENZAN LOS CONTROLES PARA REALIZAR LOS MANTENIMIENTOS CORRESPONDIENTES-->
    <div  class="container-fluid">
        <div " class="form-row">
            <div class="form-group col-md-6">
                 <asp:Label ID="lbOficinaMantenimiento" runat="server"  Text="Oficina"></asp:Label>
                <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server" CssClass="form-control"  AutoPostBack="True"  ToolTip="Seleccionar Oficina" OnSelectedIndexChanged="ddlOficinaMantenimiento_SelectedIndexChanged"></asp:DropDownList><br />
            </div>

               <div class="form-group col-md-6">
                    <asp:Label ID="lbDepartamentoMantenimiento"  runat="server"   Text="Departamento"></asp:Label>
                   <asp:DropDownList ID="ddlDepartamenoMantenimiento" runat="server" CssClass="form-control"  ToolTip="Seleccionar Departamento"></asp:DropDownList>
            </div>

               <div class="form-group col-md-6">
                    <asp:Label ID="lbNombreMantenimiento" runat="server"  Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombreMantenimiento" runat="server" AutoCompleteType="Disabled" CssClass="form-control"  PlaceHolder="Nombre" MaxLength="100"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
             <asp:Label ID="lbClaveSeguridad" runat="server"  Text="Clave de Seguridad"></asp:Label>
            <asp:TextBox ID="txtClaveSeguridad" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Password"  PlaceHolder="Clave de Seguridad" MaxLength="20"></asp:TextBox>
            </div>
        </div>
      <div class="form-group form-check">
          <div class="form-check-inline">
                   <asp:CheckBox ID="cbEstatusMantenimiento" runat="server" Text="Estatus" CssClass="form-check-input"  ToolTip="Estatus" />
          </div>
      </div>
        <div align="Center">
                        <asp:Button ID="btnGuardarMantenimiento" runat="server" CssClass="btn btn-outline-primary btn-sm"  Text="Guardar" ToolTip="Guardar Operación" OnClick="btnGuardarMantenimiento_Click"/>
                        <asp:Button ID="btnAtrasMantenimiento" runat="server" CssClass="btn btn-outline-primary btn-sm"  Text="Atras" ToolTip="Volver Atras" OnClick="btnAtrasMantenimiento_Click" />
                    </div>
    </div>
    <!--AQUI TERMINAN LOS CONTROLES PARA REALIZAR LOS MANTENIMIENTOS CORRESPONDIENTES-->
</asp:Content>

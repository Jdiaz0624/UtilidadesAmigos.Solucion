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

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        

        th {
            background-color: #0094ff;
            color: #000000;
        }
    </style>
   

    <script type="text/javascript">
        function BloquearControles() {
            $("#btnModificar").attr("disabled", "disabled");
            $("#<%=btnRestabelcer.ClientID%>").attr("disabled", "disabled");

            $("#<%=btnConsultar.ClientID%>").removeAttr("disabled", true);
            $("#btnNuevo").removeAttr("disabled", true);
        }

        function DesbloquearControles() {
            $("#btnModificar").removeAttr("disabled", true);
            $("#<%=btnRestabelcer.ClientID%>").removeAttr("disabled", true);

            $("#<%=btnConsultar.ClientID%>").attr("disabled", "disabled");
            $("#btnNuevo").attr("disabled", "disabled");
        }

        function ClaveSeguridadNoValida() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar");
            $("#<%=txtClaveSeguridad.ClientID%>").val("");
        }

          function ErrorMantenimiento() {
            alert("Error al realizar el mantenimiento");
        }

        $(document).ready(function () {
            //EVENTO DEL BOTON NUEVO
            $("#btnNuevo").click(function () {
                $("#<%=txtNombreMantenimiento.ClientID%>").val("");
                $("#<%=lbClaveSeguridad.ClientID%>").show();
                $("#<%=txtClaveSeguridad.ClientID%>").show();
                $("#<%=cbEstatusMantenimiento.ClientID%>").prop("checked", true);
                $("#<%=btnModificarMantenimiento.ClientID%>").hide();
                $("#<%=btnGuardarMantenimiento.ClientID%>").show();

            });

            //EVENTO DEL BOTON MODIFICAR
            $("#btnModificar").click(function () {
                $("#<%=lbClaveSeguridad.ClientID%>").show();
                $("#<%=txtClaveSeguridad.ClientID%>").show();
                $("#<%=btnModificarMantenimiento.ClientID%>").show();
                $("#<%=btnGuardarMantenimiento.ClientID%>").hide();

            });

            //EVENTO DEL BOTON GUARDAR
            $("#<%=btnGuardarMantenimiento.ClientID%>").click(function () {
                //VALIDAMOS LOS CAMPOS VACIOS
                var ValidarSucursal = $("#<%=ddlSeleccionarSucursalmantenimiento.ClientID%>").val();
                if (ValidarSucursal < 1) {
                    alert("El campo sucursal no puede estar vacio para guardar este registro");
                    $("#<%=ddlSeleccionarSucursalmantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ValidarOficina = $("#<%=ddlOficinaMantenimiento.ClientID%>").val();
                    if (ValidarOficina < 1) {
                        alert("El campo oficina no puede estar vacio para guardar este registro");
                        $("#<%=ddlOficinaMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var ValidarDepartamento = $("#<%=ddlDepartamenoMantenimiento.ClientID%>").val();
                        if (ValidarDepartamento < 1) {
                            alert("El campo departamento no puede estar vacio para guardar este registro");
                            $("#<%=ddlDepartamenoMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var ValidarNombre = $("#<%=txtNombreMantenimiento.ClientID%>").val().length;
                            if (ValidarNombre < 1) {
                                alert("El campo nombre no puede estar vacio para guardar este registro");
                                $("#<%=txtNombreMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var ValidarClaveSegrudiad = $("#<%=txtClaveSeguridad.ClientID%>").val().length;

                                if (ValidarClaveSegrudiad < 1) {
                                    alert("El campo clave de seguridad no puede estar vacio");
                                    $("#<%=txtClaveSeguridad.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                            }
                        }
                    }
                }

            });

            //EVENTO DEL BOTON MODIFICAR
            $("#<%=btnModificarMantenimiento.ClientID%>").click(function () {
                 //VALIDAMOS LOS CAMPOS VACIOS
                var ValidarSucursal = $("#<%=ddlSeleccionarSucursalmantenimiento.ClientID%>").val();
                if (ValidarSucursal < 1) {
                    alert("El campo sucursal no puede estar vacio para guardar este registro");
                    $("#<%=ddlSeleccionarSucursalmantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ValidarOficina = $("#<%=ddlOficinaMantenimiento.ClientID%>").val();
                    if (ValidarOficina < 1) {
                        alert("El campo oficina no puede estar vacio para guardar este registro");
                        $("#<%=ddlOficinaMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var ValidarDepartamento = $("#<%=ddlDepartamenoMantenimiento.ClientID%>").val();
                        if (ValidarDepartamento < 1) {
                            alert("El campo departamento no puede estar vacio para guardar este registro");
                            $("#<%=ddlDepartamenoMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var ValidarNombre = $("#<%=txtNombreMantenimiento.ClientID%>").val().length;
                            if (ValidarNombre < 1) {
                                alert("El campo nombre no puede estar vacio para guardar este registro");
                                $("#<%=txtNombreMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var ValidarClaveSegrudiad = $("#<%=txtClaveSeguridad.ClientID%>").val().length;

                                if (ValidarClaveSegrudiad < 1) {
                                    alert("El campo clave de seguridad no puede estar vacio");
                                    $("#<%=txtClaveSeguridad.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                            }
                        }
                    }
                }
            });
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
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <!--FIN DEL ENCABEZADO DE LA PANTALLA-->
    <div align="center">
        <asp:Label ID="lbCantidadregistrosTitulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
         <asp:Label ID="lbCantidadRegistrosdVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
         <asp:Label ID="lbCantidadRegistrossCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
    </div>
    <!--INICIO DE LOS CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <div class="row">
             <div class="col-md-3">
                <asp:Label ID="lbSucursalConsulta" runat="server" CssClass="Letranegrita" Text="Oficina"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="Sucursal" OnSelectedIndexChanged="ddlSeleccionarSucursalConsulta_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbOficinaConsulta" runat="server" CssClass="Letranegrita" Text="Oficina"></asp:Label>
                <asp:DropDownList ID="ddlOficinaConsulta" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="Oficina" OnSelectedIndexChanged="ddlOficinaConsulta_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbDepartamentoConsulta" runat="server" CssClass="Letranegrita" Text="Departamento"></asp:Label>
                <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" CssClass="form-control" ToolTip="Departamento"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbNombreConsulta" runat="server" CssClass="Letranegrita" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
        </div>
    </div>
    <!--FIN DE LOS CONTROLES DE BUSQUEDA-->

    <!--INICIO DE LOS BOTONES DE LA PANTALLA DE CONSULTA-->

        <div align="center">
         <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
         <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoEmpleados">Nuevo</button>
         <button type="button" id="btnModificar" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoEmpleados">Modificar</button>
         <asp:Button ID="btnRestabelcer" runat="server" Text="Atras" ToolTip="Atras" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnRestabelcer_Click" />
         <asp:Button ID="btnExportar" runat="server"  Text="Exportar" ToolTip="Exportar a exel" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
        </div>
    <!--FIN DE LOS BOTONES DE LA PANTALLA DE CONSULTA-->

    <br />

    <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvEmpleados" runat="server" AllowPaging="true" OnPageIndexChanging="gvEmpleados_PageIndexChanging" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdEmpleado" HeaderText="ID" />
                    <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="CreadoPor" HeaderText="Creado Por" />
                    <asp:BoundField DataField="FechaAdiciona" HeaderText="Fecha Creado" />
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

   

       <div class="modal fade bd-example-modal-lg MantenimientoEmpleados" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezadoMantenimiento" runat="server" Text="Mantenimiento de Empleados"></asp:Label>
        </div>
        <!--AQUI COMIENZAN LOS CONTROLES PARA REALIZAR LOS MANTENIMIENTOS CORRESPONDIENTES-->
    <div  class="container-fluid">
       <asp:ScriptManager ID="ScripManagerEmpleado" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelEmpleado" runat="server">
            <ContentTemplate>
                 <div " class="row">

              <div class="col-md-6">
                <asp:Label ID="lbSeleccionarSucursalMantenimiento" runat="server" CssClass="Letranegrita" Text="Sucursal"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalmantenimiento" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="Sucursal" OnSelectedIndexChanged="ddlSeleccionarSucursalmantenimiento_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-md-6">
                 <asp:Label ID="lbOficinaMantenimiento"  runat="server" CssClass="Letranegrita" Text="Oficina"></asp:Label>
                <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server"  CssClass="form-control"  AutoPostBack="True"  ToolTip="Seleccionar Oficina" OnSelectedIndexChanged="ddlOficinaMantenimiento_SelectedIndexChanged"></asp:DropDownList>
            </div>
               <div class="col-md-6">
                    <asp:Label ID="lbDepartamentoMantenimiento"   runat="server"  CssClass="Letranegrita" Text="Departamento"></asp:Label>
                   <asp:DropDownList ID="ddlDepartamenoMantenimiento"  runat="server" CssClass="form-control"  ToolTip="Seleccionar Departamento"></asp:DropDownList>
            </div>
               <div class="col-md-6">
                    <asp:Label ID="lbNombreMantenimiento" runat="server" CssClass="Letranegrita"  Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombreMantenimiento" runat="server"  AutoCompleteType="Disabled" CssClass="form-control"  MaxLength="100"></asp:TextBox>
            </div>
             <div class="col-md-6">
             <asp:Label ID="lbClaveSeguridad" runat="server" CssClass="Letranegrita" Text="Clave de Seguridad"></asp:Label>
            <asp:TextBox ID="txtClaveSeguridad" runat="server"  AutoCompleteType="Disabled" CssClass="form-control" TextMode="Password"  MaxLength="20"></asp:TextBox>
            </div>
        </div>
   
          <div class="form-check-inline">
                   <asp:CheckBox ID="cbEstatusMantenimiento"  runat="server" Text="Estatus" CssClass="form-check-input"  ToolTip="Estatus" />
          </div>
   
            </ContentTemplate>
        </asp:UpdatePanel>
        <div align="Center">
         <asp:Button ID="btnGuardarMantenimiento"  runat="server" CssClass="btn btn-outline-primary btn-sm Custom"  Text="Guardar" ToolTip="Guardar Registro" OnClick="btnGuardarMantenimiento_Click"/>
         <asp:Button ID="btnModificarMantenimiento"  runat="server" CssClass="btn btn-outline-primary btn-sm Custom"  Text="Modificar" ToolTip="Modificar Registro" OnClick="btnModificarMantenimiento_Click"/>
        </div>
        <br />
    </div>
    <!--AQUI TERMINAN LOS CONTROLES PARA REALIZAR LOS MANTENIMIENTOS CORRESPONDIENTES-->
    </div>
  </div>
</div>
</asp:Content>

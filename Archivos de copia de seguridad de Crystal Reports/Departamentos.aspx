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

        .Custom2{
            width: 130px;
            height: 45px;
        }
          .Mantenimiento{
            width: 100px;
        }

        .LetraNegrita {
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
            $("#<%=btnConsultar.ClientID%>").attr("disabled", "disabled");
            $("#btnNuevo").attr("disabled", "disabled");

            $("#btnModificar").removeAttr("disabled", true);
            $("#<%=btnRestabelcer.ClientID%>").removeAttr("disabled", true);
        }

        function ClaveSeguridadNoValida() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar");
            $("#<%=txtclaveSeguridad.ClientID%>").val("");
        }

        function RegistroGuardado() {
            alert("Registro guardado con exito");
        }
        function RegistroModificado() {
            alert("Registo modificado con exito");
        }

        $(document).ready(function () {
            //EVENTO PARA EL BOTON NUEVO DE LA PANTALLA DE CONSULTA
            $("#btnNuevo").click(function () {
                $("#<%=txtDescripcionDepartamento.ClientID%>").val("");
                $("#<%=txtclaveSeguridad.ClientID%>").val("");
                $("#<%=cbEstatus.ClientID%>").prop("checked", true);

                $("#<%=btnModificarMantenimiento.ClientID%>").hide();
                $("#<%=btnGuardarmantenimiento.ClientID%>").show();
            });

            //EVENTO PARA EL BOTON MODIFICAR DE LA PANTALLA DE CONSULTA
            $("#btnModificar").click(function () {
                $("#<%=btnGuardarmantenimiento.ClientID%>").hide();
                $("#<%=btnModificarMantenimiento.ClientID%>").show();
            });

            //EVENTO PARA EL BOTON GUARDAR MANTENIMIENTO
            $("#<%=btnGuardarmantenimiento.ClientID%>").click(function () {
                //VALIDAMOS LOS CAMPOS VACIOS
                var ValidarCampoSucursal = $("#<%=ddlSeleccionarSucursalmantenimiento.ClientID%>").val();
                if (ValidarCampoSucursal < 1) {
                    alert("El campo sucursal no puede estar vacio para guardar este registro");
                    $("#<%=ddlSeleccionarSucursalmantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ValidarOficina = $("#<%=ddlOficinaMantenimiento.ClientID%>").val();
                    if (ValidarOficina < 1) {
                        alert("El campo oficina no pude estar vacio para guardar este registro");
                        $("#<%=ddlOficinaMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var ValidarDepartamento = $("#<%=txtDescripcionDepartamentoMAN.ClientID%>").val().length;
                        if (ValidarDepartamento < 1) {
                            alert("El campo departaemnto no pude estar vacio para guardar este registro");
                            $("#<%=txtDescripcionDepartamentoMAN.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var ValidamosClaveSeguridad = $("#<%=txtclaveSeguridad.ClientID%>").val().length;
                            if (ValidamosClaveSeguridad < 1) {
                                alert("El campo clave de seguridad no puede estar vacio para guardar este registro");
                                $("#<%=txtclaveSeguridad.ClientID%>").css("border-color", "red");
                                return false;
                            }
                        }
                    }
                   
                }
            });

            //EVENTO PARA EL BOTON MODIFICAR MANTENIMIENTO
            $("#<%=btnModificarMantenimiento.ClientID%>").click(function () {
                  var ValidarCampoSucursal = $("#<%=ddlSeleccionarSucursalmantenimiento.ClientID%>").val();
                if (ValidarCampoSucursal < 1) {
                    alert("El campo sucursal no puede estar vacio para guardar este registro");
                    $("#<%=ddlSeleccionarSucursalmantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ValidarOficina = $("#<%=ddlOficinaMantenimiento.ClientID%>").val();
                    if (ValidarOficina < 1) {
                        alert("El campo oficina no pude estar vacio para guardar este registro");
                        $("#<%=ddlOficinaMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var ValidarDepartamento = $("#<%=txtDescripcionDepartamentoMAN.ClientID%>").val().length;
                        if (ValidarDepartamento < 1) {
                            alert("El campo departaemnto no pude estar vacio para guardar este registro");
                            $("#<%=txtDescripcionDepartamentoMAN.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var ValidamosClaveSeguridad = $("#<%=txtclaveSeguridad.ClientID%>").val().length;
                            if (ValidamosClaveSeguridad < 1) {
                                alert("El campo clave de seguridad no puede estar vacio para guardar este registro");
                                $("#<%=txtclaveSeguridad.ClientID%>").css("border-color", "red");
                                return false;
                            }
                        }
                    }
                   
                }
            });



        });
    </script>


<!--INICIO DEL ENCABEZADO DE LA PANTALLA-->
    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
    <div align="Center" class="jumbotron">
        <asp:Label ID="lbEncabezado" runat="server" Text="Mantenimiento de Departamentos"></asp:Label>
    </div>
        <div align="center">
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de registros (" CssClass="LetraNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="LetraNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" )" CssClass="LetraNegrita"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lbIdDepartamento" runat="server" Text="IdDepartamento" Visible="false"></asp:Label>
        </div>
        <!--FIN DEL ENCABEZADO DE LA PANTALLA-->


<!--INICIO DE LOS CONTROLES PARA REALIZAR LA CONSULTA-->
            <div class="row">
         <div class="col-md-3">
             <asp:Label ID="lbSeleccionarSucursalConsulta" CssClass="LetraNegrita" runat="server" Text="Sucursal"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarSucursalCOnsulta" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursalCOnsulta_SelectedIndexChanged" CssClass="form-control" ToolTip="Seleccionar Sucursal"></asp:DropDownList>
        </div>

        <div class="col-md-3">
             <asp:Label ID="lbOficinaConsulta" runat="server" CssClass="LetraNegrita" Text="Oficina"></asp:Label>
            <asp:DropDownList ID="ddloficinaConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Oficina"></asp:DropDownList>
        </div>
        
        <div class="col-md-3">
               <asp:Label ID="lbDescripcion" Text="Departamento" CssClass="LetraNegrita" runat="server"></asp:Label>
            <asp:TextBox ID="txtDescripcionDepartamento" runat="server" CssClass="form-control" AutoCompleteType="Disabled" Palceholder="Departamento" MaxLength="100"></asp:TextBox>
        </div>
    </div>
    <div align="center">
         <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
         <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoDepartaemntos">Nuevo</button>
         <button type="button" id="btnModificar" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoDepartaemntos">Modificar</button>
         <asp:Button ID="btnRestabelcer" runat="server" Text="Atras" ToolTip="Atras" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnRestabelcer_Click" />
         <asp:Button ID="btnExportar" runat="server"  Text="Exportar" ToolTip="Exportar a exel" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
    </div>
    <br />

            


        <!--FIN DE LOS CONTROLES PARA REALIZAR LA CONSULTA-->
</div>
    <br />


<!--INICIO DEL GRID-->
        <div class="container-fluid">
        <%--en esta parte agregamos el grid--%>
        <asp:GridView ID="gvDepartamentos" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gvDepartamentos_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="gvDepartamentos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm Custom" ShowSelectButton="True" />
                <asp:BoundField DataField="IdDepartamento" HeaderText="ID" />
                <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" />
                <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                <asp:BoundField DataField="CreadoPor" HeaderText="Creado por" />
                <asp:BoundField DataField="FechaCreado" HeaderText="Fecha" />
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
     





      <div class="modal fade bd-example-modal-lg MantenimientoDepartaemntos" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezadoMantenimiento" runat="server" Text="Mantenimiento de departamentos"></asp:Label>
        </div>
        <div class="container-fluid">
       <asp:ScriptManager ID="ScripManagerDepartamentos" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanelDepartamentos" runat="server">
                <ContentTemplate>
                     <div class="row">
             <div class="col-md-4">
                  <asp:Label ID="lbSeleccionarSucursalMantenimiento" Visible="true" CssClass="LetraNegrita" runat="server"  Text="Sucursal"></asp:Label>
        <asp:DropDownList ID="ddlSeleccionarSucursalmantenimiento" Visible="true" runat="server" OnSelectedIndexChanged="ddlSeleccionarSucursalmantenimiento_SelectedIndexChanged"  CssClass="form-control" AutoPostBack="true" ToolTip="Sucursal"></asp:DropDownList>
            </div>

            <div class="col-md-4">
                  <asp:Label ID="lbOficinaMantenimiento" Visible="true" CssClass="LetraNegrita" runat="server"  Text="Oficina"></asp:Label>
        <asp:DropDownList ID="ddlOficinaMantenimiento" Visible="true" runat="server"  CssClass="form-control" ToolTip="Oficina"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                 <asp:Label ID="lbOficinaDepartamento" Visible="true" runat="server" CssClass="LetraNegrita"  Text="Departamento"></asp:Label>
        <asp:TextBox ID="txtDescripcionDepartamentoMAN" runat="server" Visible="true"  AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
          <div class="col-md-4">
               <asp:Label ID="lbClaveSeguridad" Visible="true" runat="server" CssClass="LetraNegrita" Text="Clave de Seguridad"></asp:Label>
               <asp:TextBox ID="txtclaveSeguridad" runat="server" TextMode="Password" Visible="true"  AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <div class="form-check-inline">

                    <asp:CheckBox ID="cbEstatus" runat="server"  Text="Estatus" Visible="true" CssClass="form-check-input" ToolTip="Estatus" />
                    

        
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        <%--en esta parte agregamos los controles para el mantenimiento--%>
      
       
        <div align="Center">
              <asp:Button ID="btnGuardarmantenimiento" runat="server" Text="Guardar" ToolTip="Guardar regsitro" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnGuardarMantenimiento_Click" />
              <asp:Button ID="btnModificarMantenimiento" runat="server" Text="Modificar" ToolTip="Modificar registro seleciconado" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnModificarMantenimiento_Click" />
        </div>
            <br />
    </div>
    </div>
  </div>
</div>
    <!--FIN DE LOS CONTROLES PARA EL MANTENIMIENTO-->



</asp:Content>

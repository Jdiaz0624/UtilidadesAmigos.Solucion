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

        .letraNegrita {
        font-weight:bold;
            }
        .Custom{
            width: 78px;
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
            $("#<%=btnRestabelcer.ClientID%>").attr("disabled", "disabled");
            $("#btnModificar").attr("disabled", "disabled");

            $("#btnNuevo").removeAttr("disabled", true);
            $("#<%=btnConsultar.ClientID%>").removeAttr("disabled", true);
        }
        function DesbloquearControles() {
            $("#btnNuevo").attr("disabled", "disabled");
            $("#<%=btnConsultar.ClientID%>").attr("disabled", "disabled");

            $("#<%=btnRestabelcer.ClientID%>").removeAttr("disabled", true);
            $("#btnModificar").removeAttr("disabled", true);
        }

        function RegistroGuardado() {
            alert("Registro guardado con exito");
        }
        function RegistroModificado() {
            alert("Registro modificado con exito");
        }
        function ClaveSeguridadNoValida() {
            alert("La clave de seguridad ingresada no es valida");
           
        }

        $(document).ready(function () {
            //EVENTO PARA EL BOTON NUEVO
            $("#btnNuevo").click(function () {
                $("#<%=btnGuardar.ClientID%>").show();
                $("#<%=btnModificarMantenimiento.ClientID%>").hide();

                $("#<%=txtDescripcionOficinaMAn.ClientID%>").val("");
                $("#<%=cbEstatus.ClientID%>").prop("checked", true);
            });

            //EVENTO PARA EL BOTON MODIFICAR
            $("#btnModificar").click(function () {
                $("#<%=btnModificarMantenimiento.ClientID%>").show();
                $("#<%=btnGuardar.ClientID%>").hide();
            });

            //EVENTO PARA EL BOTON GUARDAR
            $("#<%=btnGuardar.ClientID%>").click(function () {
                //VALIDAMOS LOS CAMPOS VACIOS
                var ValidarOficina = $("#<%=txtDescripcionOficinaMAn.ClientID%>").val().length;
                if (ValidarOficina < 1) {
                    alert("El campo oficina no puede estar vacio para guardar este registro, favor de verificar");
                    $("#<%=txtDescripcionOficinaMAn.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ValidarClaveSeguridad = $("#<%=txtClaveSeguridad.ClientID%>").val().length;
                    if (ValidarClaveSeguridad < 1) {
                        alert("El campo clave de seguridad es necesario para guardar este registro");
                        $("#<%=txtClaveSeguridad.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }
            });

            //EVENTO PARA EL BOTON MODIFICAR
            $("#<%=btnModificarMantenimiento.ClientID%>").click(function () {
                  //VALIDAMOS LOS CAMPOS VACIOS
                var ValidarOficina = $("#<%=txtDescripcionOficinaMAn.ClientID%>").val().length;
                if (ValidarOficina < 1) {
                    alert("El campo oficina no puede estar vacio para guardar este registro, favor de verificar");
                    $("#<%=txtDescripcionOficinaMAn.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ValidarClaveSeguridad = $("#<%=txtClaveSeguridad.ClientID%>").val().length;
                    if (ValidarClaveSeguridad < 1) {
                        alert("El campo clave de seguridad es necesario para guardar este registro");
                        $("#<%=txtClaveSeguridad.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }

            });
        })
    </script>
    <!--INICIO DEL ENCABEZADO DE LA PANTALLA-->
   <div class="container-fluid">
       <div align="Center" class="jumbotron">
       <asp:Label ID="lbEncabezado" runat="server"  Text="Mantenimiento de Oficinas"></asp:Label>

   </div>
       <div>
           <asp:Label ID="lbIdOficina" runat="server"  Text="IdOficina" Visible="false"></asp:Label>
       </div>
       <!--FIN DEL ENCABEZADO DE LA PANTALLA-->
       <br />
       <div class="row">
            <div class="col-md-3">
               <asp:Label ID="lbSucursalConsulta" Text="Sucursal" CssClass="letraNegrita" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
           </div>

           <div class="col-md-3">
               <asp:Label ID="lbDescripcion" Text="Oficina"  CssClass="letraNegrita" runat="server"></asp:Label>
            <asp:TextBox ID="txtDescripcionOficina" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
           </div>
       </div>





            <div align="center">
              <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
             <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoOficina">Nuevo</button>
            <asp:Button ID="btnRestabelcer" runat="server" Text="Atras" Enabled="false" ToolTip="Restablecer Pantalla" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnRestabelcer_Click" />
             <button type="button" id="btnModificar" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoOficina">Modifcar</button>
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" ToolTip="Exportar a exel" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />

            </div>

       <br />



   </div>



            



    <div class="container-fluid">
        <asp:GridView id="gvOficinas" runat="server" AllowPaging="True" OnPageIndexChanging="gvOficinas_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gvOficinas_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                 <Columns>
                   <asp:CommandField ButtonType="Button"  ControlStyle-CssClass="btn btn-outline-primary btn-sm Custom" HeaderText="Select" ShowSelectButton="True" />
                 
                <asp:BoundField DataField="IdOficina"   HeaderText="ID" />
                 <asp:BoundField DataField="Sucursal"   HeaderText="Sucursal" />
                <asp:BoundField DataField="Oficina"  HeaderText="Oficina" />
                <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                <asp:BoundField DataField="Creadopor" HeaderText="Creado Por" />
                <asp:BoundField DataField="FechaAdiciona" HeaderText="Fecha Creado" />
                     
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






  <div class="modal fade bd-example-modal-lg MantenimientoOficina" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezadoMantenimiento" runat="server" Text="Mantenimiento de Oficinas" CssClass=".letraNegrita"></asp:Label>
        </div>
      <div class="container-fluid">
            <div class="row">
                    <div class="col-md-4">
               <asp:Label ID="lbSeleccionarSucursalmantenimiento" Text="Sucursal" CssClass="letraNegrita" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalMantenimiento" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
           </div>
                <div class="col-md-4">
                    <asp:Label ID="lbOficina" Visible="true" runat="server" CssClass="letraNegrita" Text="Ingrese Oficina"></asp:Label>
                    <asp:TextBox ID="txtDescripcionOficinaMAn" Visible="true" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                    
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbClaveSeguridad" runat="server" Visible="true" CssClass="letraNegrita" Text="Clave de Seguridad"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridad" runat="server" Visible="true" TextMode="Password" CssClass="form-control" MaxLength="20"></asp:TextBox>
                </div>
            </div>
            <div class="form-check-inline">
               
                    <asp:CheckBox ID="cbEstatus" runat="server" Visible="true" Text="Estatus" CssClass="form-check-input" ToolTip="Estatus de Oficina" />
 
            </div>
        </div>
        <div align="Center">
            <asp:Button ID="btnGuardar" Visible="true" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm Custom" ToolTip="Guardar registro" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnModificarMantenimiento" Visible="true" runat="server" Text="Modificar" CssClass="btn btn-outline-primary btn-sm Custom" ToolTip="Modificar registro seleccionado" OnClick="btnModificarMantenimiento_Click" />
        </div>
        <br />
    </div>
  </div>
</div>
</asp:Content>

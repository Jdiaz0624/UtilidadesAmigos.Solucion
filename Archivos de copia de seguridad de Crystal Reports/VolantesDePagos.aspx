<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="VolantesDePagos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.VolantesDePagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link rel="stylesheet" href="../../Content/EstilosComunes.css" />


    <script type="text/javascript">
        function CodigoEmpleadoNoValido() {
            alert("El codigo de empleado ingresado no es valido o esta cancelado, favor de verificar.");
        }


        function CorreoNoActivo() {
            alert("Esta persona no tiene la opción de envio de correo activo.");
        }
        $(document).ready(function () {

       
            $("#<%=btnProcesar.ClientID%>").click(function () {
                var Year = $("#<%=txtAno.ClientID%>").val().length;
                if (Year < 1) {
                    alert("El campo año no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtAno.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Month = $("#<%=txtMes.ClientID%>").val().length;
                    if (Month < 1) {
                        alert("El campo mes no puede estar vacio para realizar esta operación, favor de verificar.");
                        $("#<%=txtMes.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }
            });

        })
    </script>

    <br />
    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <div id="DivBloqueProceso" runat="server">
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lbCodigoEmpleado" runat="server" Text="Codigo de Empleado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoEmpleado" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Placeholder="Opcional" AutoPostBack="true" OnTextChanged="txtCodigoEmpleado_TextChanged" TextMode="Number"></asp:TextBox>
            </div>

             <div class="col-md-6">
                <asp:Label ID="lbNombreEmpleado" runat="server" Text="Nombre de Empleado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreEmpleado" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

              <div class="col-md-4">
                <asp:Label ID="lbSeleccionarTipoNomina" runat="server" Text="Tipo de Nomina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlTipoNomina" runat="server" CssClass="form-control" Enabled="false" ToolTip="Seleccionar El tipo de Nomina"></asp:DropDownList>
            </div>

            <div class="col-md-2">
                <asp:Label ID="lbAno" runat="server" Text="Año" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtAno" runat="server" AutoCompleteType="Disabled"  CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="col-md-2">
                <asp:Label ID="lbMes" runat="server" Text="Mes" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtMes" runat="server" AutoCompleteType="Disabled" MaxLength="2" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            
    
                <asp:Label ID="lbTipoNominaLetrero" runat="server" Text="Seleccionar Tipo de Nomina" CssClass="LetrasNegrita"></asp:Label><br />
                 <asp:RadioButton ID="rbPrimeraQuincena" runat="server" Text="Primera Quincena" CssClass="form-check-input" GroupName="TipoNomina" />
                 <asp:RadioButton ID="rbSegundaQuincena" runat="server" Text="Segunda Quincena" CssClass="form-check-input" GroupName="TipoNomina" />
     
           
        </div>
            <br />
            <div align="center">
                <asp:Button ID="btnProcesar" runat="server" Text="Procesar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Generar Volantes de Pagos" OnClick="btnProcesar_Click" />
                <asp:Button ID="btnCodigos" runat="server" Text="Codigos"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Buscar Codigos de Empleados" OnClick="btnCodigos_Click" />
                
            </div>
            <br />
    </div>

        <div id="DivBloqueBuscarCodigo" runat="server">
            <asp:Label ID="lbCodigoEmpleadoSeleccionadoModificar" runat="server" Text="0" Visible="false"></asp:Label>
            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbNombreEmpleadoConsulta" runat="server" Text="Nombre de Empleado" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreEmpleadoConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <br />
             <div align="center">
                <asp:Button ID="btnBuscarCodigo" runat="server" Text="Buscar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Buscar Codigos" OnClick="btnBuscarCodigo_Click" />
                 <asp:Button ID="btnVolverVolantePago" runat="server" Text="Volver"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Volver Atras" OnClick="btnVolverVolantePago_Click" />
            </div>
            <br />
          
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th scope="col"> Seleccionar </th>
                             <th scope="col"> Codigo </th>
                             <th scope="col"> Nombre </th>
                             <th scope="col"> Oficina </th>
                            <th scope="col"> Departamento </th>
                            <th scope="col"> Estatus </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoCodigos" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfCodigoEmpleado" runat="server" Value='<%# Eval("CodigoEmpleado") %>' />
                                    <td> <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Seleccionar el Codigo" OnClick="btnSeleccionar_Click" /> </td>
                                    <td> <%# Eval("CodigoEmpleado") %> </td>
                                    <td> <%# Eval("Nombre") %> </td>
                                    <td> <%# Eval("DescSucursal") %> </td>
                                    <td> <%# Eval("DescDepto") %> </td>
                                    <td> <%# Eval("Estatus") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
      

             <div align="center">
               <asp:Label ID="lbPaginaActualTituloVolantePago" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleVolantePago" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloVolantePago" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableVolantePago" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionVolantePago" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaVolantePago" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaVolantePago_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorVolantePago" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorVolantePago_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionVolantePago" runat="server" OnItemCommand="dtPaginacionVolantePago_ItemCommand" OnItemDataBound="dtPaginacionVolantePago_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralVolantePago" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteVolantePago" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteVolantePago_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoVolantePago" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoVolantePago_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />

            <div id="BloqueModificarCorreo" runat="server">
                <br />
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lbCodigoEmpleadoSeleccionado" runat="server" Text="Codigo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtCodigoEmpleadoSeleccionado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="col-md-6">
                        <asp:Label ID="lbNombreEmpleadoSeleccionado" runat="server" Text="Nombre de Empleado" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtNombreEmpleadoSeleccionado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <asp:Label ID="lbOficinaEmpleadoSeleccionado" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtOficinaEmpleadoSeleccionado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                     <div class="col-md-3">
                        <asp:Label ID="lbDepartamentoEmpleadoSeleccionado" runat="server" Text="Departamento" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDepartamentoEmpleadoSeleccionado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                     <div class="col-md-3">
                        <asp:Label ID="lbCorreo" runat="server" Text="Correo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtCorreoEmpleadoSelecciondo" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
                <div class="form-check-inline">
                  
                        <asp:CheckBox ID="cbEnvioCorreo" runat="server" Text="Envio de Correo" ToolTip="Habilitar si se le puede enviar volante de pagos al empleado seleccionado" CssClass="form-check-input" />
             
                </div>
                <br />
                <div align="center">
                <asp:Button ID="btnModificarCorreo" runat="server" Text="Modificar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar Correo" OnClick="btnModificarCorreo_Click" />
                    <asp:Button ID="btnVolverModificarCorreo" runat="server" Text="Volver"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Volver Atras" OnClick="btnVolverModificarCorreo_Click" />
            </div>
                <br />
            </div>
        </div>
    </div>

</asp:Content>

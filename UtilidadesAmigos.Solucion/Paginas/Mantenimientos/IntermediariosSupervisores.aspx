<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="IntermediariosSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.IntermediariosSupervisores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style type="text/css">

        .btn-sm{
            width:90px;
        }

        .LetrasNegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        

        th {
            background-color: dodgerblue;
            color: white;
        }
    </style>

    <script type="text/javascript">

        function CamposComunicacionVacios() {
            alert("Tienes que ingresar al menos un numero de telefono para realizar esta operación.");
            $("#<%=txtTelefono1Mantenimiento.ClientID%>").css("border-color", "blue");
            $("#<%=txtTelefono2Mantenimiento.ClientID%>").css("border-color", "blue");
            $("#<%=txtTelefono3Mantenimiento.ClientID%>").css("border-color", "blue");
            $("#<%=txtCelularMantenimiento.ClientID%>").css("border-color", "blue");

        }
        function ErrorRealizarMantenimiento() {
            alert("Error al realizar el mantenimiento");
        }

        function CampoFechaNAcimientoVacio() {
            alert("El campo Fecha de Nacimiento no puede estar vacio para realizar esta operación, favor de verificar.");
            $("#<%=txtFechaNacimientoMantenimiento.ClientID%>").css("border-color", "red");
        }

        function CampoFechaEntradaVacio() {
            alert("El campo fecha de Entrada no puede estar vacio para realizar esta operación favor de verificar.");
            $("#<%=txtFechaEntradaMantenimiento.ClientID%>").css("border-color", "red");
        }

        function SeleccionarOpcionComision() {
            alert("Favor de marcar la opción de modificar comisiones para realizar este paso.");
            $("#<%=rbModificarComisiones.ClientID%>").css("border-color", "blue");
        }
        function ClaveSeguridadInvalida() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar.");
        }

        $(document).ready(function () {
            $("#<%=btnModificarComision.ClientID%>").click(function () {
                var RamoSeleccionado = $("#<%=txtRamoSeleccionadoComisionesComisiones.ClientID%>").val().length;
                if (RamoSeleccionado < 1) {
                    alert("Favor de seleccionar un registro para proceder con este paso.");
                    return false;
                }
                else {
                    var SubRamoSeleccionado = $("#<%=txtSubRamoSeleccionadoComisiones.ClientID%>").val().length;
                    if (SubRamoSeleccionado < 1) {
                        alert("Favor de seleccionar un registro para proceder con este paso.");
                        return false;
                    }
                    else {
                        var PorcientoCOmisionVAcio = $("#<%=txtPorcientoComisionSeleccionadoComisiones.ClientID%>").val().length;
                        if (PorcientoCOmisionVAcio < 1) {
                            alert("El campo de Porciento de Comision no puede estar vacio para modificar este registro, favor de verificar.");
                            $("#<%=txtPorcientoComisionSeleccionadoComisiones.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var ValorPorcientoCOmision = $("#<%=txtPorcientoComisionSeleccionadoComisiones.ClientID%>").val();
                            if (ValorPorcientoCOmision > 100) {
                                alert("El valor ingresado para el Porciento de comisión no es valido, favor de verificar.");
                                $("#<%=txtPorcientoComisionSeleccionadoComisiones.ClientID%>").css("border-color", "blue");
                                return false;
                            }
                        }
                    }
                }
            });


            $("#<%=btnValidarClaveSeguridad.ClientID%>").click(function () {
                var ClaveSeguridad = $("#<%=txtClaveSeguridadComisiones.ClientID%>").val().length;
                if (ClaveSeguridad < 1) {
                    alert("El campo clave de seguridad no puede estar vacio, favor de verificar.");
                    $("#<%=txtClaveSeguridadComisiones.ClientID%>").css("border-color", "red");
                    return false;
                }
            });


            $("#<%=btnGuardarMantenimiento.ClientID%>").click(function () {
               
              
                    var NumeroIdentificacion = $("#<%=txtNumeroIdentificacionMantenimiento.ClientID%>").val().length;
                    if (NumeroIdentificacion < 1) {
                        alert("El campo numero de identificación no puede estar vacio para realizar esta operación, favor de verificar.");
                        $("#<%=txtNumeroIdentificacionMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var Apellido = $("#<%=txtApellidoMantenimiento.ClientID%>").val().length;
                        if (Apellido < 1) {
                            alert("El campo Apellido no puede estar vacio para realizar esta operación, favor de verificar.");
                            $("#<%=txtApellidoMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var Nombre = $("#<%=txtNombreMantenimiento.ClientID%>").val().length;
                            if (Nombre < 1) {
                                alert("El campo Nombre no puede estar vacio para realizar esta operación, favor de verificar.");
                                $("#<%=txtNombreMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var Direccion = $("#<%=txtDireccion.ClientID%>").val().length;
                                if (Direccion < 1) {
                                    alert("El campo Dirección no puede estar vacio para realizar esta operación, favor de verificar.");
                                    $("#<%=txtDireccion.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                                else {
                                    var Pais = $("#<%=ddlPaisMantenimiento.ClientID%>").val();
                                    if (Pais < 1) {
                                        alert("El campo Pais no puede estar vacio para realizar esta operación, favor de verificar.");
                                        $("#<%=ddlPaisMantenimiento.ClientID%>").css("border-color", "red");
                                        return false;
                                    }
                                    else {
                                        var Zona = $("#<%=ddlZonaMantenimiento.ClientID%>").val();
                                        if (Zona < 1) {
                                            alert("El campo Zona no puede estar vacio para realizar esta operación, favor de verificar.");
                                            $("#<%=ddlZonaMantenimiento.ClientID%>").css("border-color", "red");
                                            return false;
                                        }
                                        else {
                                            var Provincia = $("#<%=ddlProvinciaMantenimiento.ClientID%>").val();
                                            if (Provincia < 1) {
                                                alert("El campo Provincia no puede estar vacio para realizar esta operación, favor de verificar.");
                                                $("#<%=ddlProvinciaMantenimiento.ClientID%>").css("border-color", "red");
                                                return false;
                                            }
                                            else {
                                                var Municipio = $("#<%=ddlMunicipioMAntenimiento.ClientID%>").val();
                                                if (Municipio < 1) {
                                                    alert("El campo Municipio no puede estar vacio para realizar esta operación, favor de verificar.");
                                                    $("#<%=ddlMunicipioMAntenimiento.ClientID%>").css("border-color", "red");
                                                    return false;
                                                }
                                                else {
                                                    var Sector = $("#<%=ddlSectorMantenimiento.ClientID%>").val();
                                                    if (Sector < 1) {
                                                        alert("El campo Sector no puede estar vacio para realizar esta operación, favor de verificar.");
                                                        $("#<%=ddlSectorMantenimiento.ClientID%>").css("border-color", "red");
                                                        return false;
                                                    }
                                                    else {
                                                        var Ubicacion = $("#<%=ddlUbicacionMantenimiento.ClientID%>").val();
                                                        if (Ubicacion < 1) {
                                                            alert("El campo Ubicación no puede estar vacio para realizar esta operación, favor de verificar.");
                                                            $("#<%=ddlUbicacionMantenimiento.ClientID%>").css("border-color", "red");
                                                            return false;
                                                        }
                                                        else {
                                                            var CodigoSupervisor = $("#<%=txtCodigoSupervisorMantenimiento.ClientID%>").val().length;
                                                            if (CodigoSupervisor < 1) {
                                                                alert("El campo Codigo de Supervisor no puede estar vacio para realizar esta operación, favor de verificar.");
                                                                $("#<%=txtCodigoSupervisorMantenimiento.ClientID%>").css("border-color", "red");
                                                                return false;
                                                            }
                                                            else {
                                                                var ValorCodigoSupervisor = $("#<%=txtCodigoSupervisorMantenimiento.ClientID%>").val();
                                                                if (ValorCodigoSupervisor == 0) {
                                                                    alert("El codigo de supervisor no puede tener el valor de cero, favor de verificar.");
                                                                    $("#<%=txtCodigoSupervisorMantenimiento.ClientID%>").css("border-color", "blue");
                                                                    return false;
                                                                }
                                                                else {
                                                                    var Oficina = $("#<%=ddlOficinaMAntenimiento.ClientID%>").val();
                                                                    if (Oficina < 1) {
                                                                        alert("El campo Oficina no puede estar vacio para realizar esta operación, favor de verificar.");
                                                                        $("#<%=ddlOficinaMAntenimiento.ClientID%>").css("border-color", "red");
                                                                        return false;
                                                                    }
                                                                    else {
                                                                        var CanalDistribucion = $("#<%=ddlCanalDistribucionMantenimiento.ClientID%>").val();
                                                                            if (CanalDistribucion < 1) {
                                                                                alert("El campo Canal de Distribución no puede estar vacio para realizar esta operación, favor de verificar.");
                                                                                $("#<%=ddlCanalDistribucionMantenimiento.ClientID%>").css("border-color", "red");
                                                                                return false;
                                                                            }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                
            });

        })
    </script>

  <div class="container-fluid">
        <div id="DivBloqueConsulta"  runat="server">
            <br />
            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Label ID="lbCodigoIntermediarioConsulta" runat="server" Text="Codigo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediarioConsulta" runat="server" MaxLength="4" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-4">
                    <asp:Label ID="lbNombreIntermediarioCnsulta" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediarioConsulta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-4">
                    <asp:Label ID="lbOficinaConsulta" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarOficinaConsulta" runat="server" ToolTip="Seleccionar la Oficina para consultar" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
             <div align="center">
                 <asp:Button ID="btnConsultar" runat="server" Text="Consultar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
                 <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Crear nuevo registro" OnClick="btnNuevo_Click" />
                 <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar registro seleccionado" OnClick="btnModificar_Click" />
                 <asp:Button ID="btnComisiones" runat="server" Text="Comisiones"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Mostrar las comisiones del registro seleccionado" OnClick="btnComisiones_Click" />
                 <asp:Button ID="btnRestabelcer" runat="server" Text="Restablecer"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Restabelcer Pantalla" OnClick="btnRestabelcer_Click" />
        </div>
            <br />
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="width:10%" align="left">Seleccionar</th>
                            <th style="width:10%" align="left">Codigo</th>
                            <th style="width:35%" align="left">Nombre</th>
                            <th style="width:10%" align="left">Estatus</th>
                            <th style="width:15%" align="left">Oficina</th>
                            <th style="width:10%" align="left">Entrada</th>
                            <th style="width:10%" align="left">Licencia</th>
                        </tr>
                    </thead>
                    <tbody>
                     
                           <asp:Repeater ID="rpListado" runat="server">
                               <ItemTemplate>
                                      <tr>
                                   <asp:HiddenField ID="hfIdRegistroSeleccionado" runat="server" Value='<%# Eval("Codigo") %>' />
                                   <td style="width:10%" align="left"> <asp:Button ID="btnSeleccionarRegistro" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Seleccionar Registro" OnClick="btnSeleccionarRegistro_Click" />  </td>
                                   <td style="width:10%" align="left"> <%# Eval("Codigo") %> </td>
                                   <td style="width:35%" align="left"> <%# Eval("NombreVendedor") %> </td>
                                   <td style="width:10%" align="left"> <%# Eval("Estatus") %> </td>
                                   <td style="width:15%" align="left"> <%# Eval("NombreOficina") %> </td>
                                   <td style="width:10%" align="left"> <%# Eval("FechaEntrada") %> </td>
                                   <td style="width:10%" align="left"> <%# Eval("LicenciaSeguro") %> </td>
                                          </tr>
                               </ItemTemplate>
                           </asp:Repeater>
                        
                    </tbody>
                </table>
            </div>
            <br />
            <div align="center">
               <asp:Label ID="lbPaginaActualTituloIntermediariosSupervisores" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleIntermediariosSupervisores" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloIntermediariosSupervisores" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableIntermediariosSupervisores" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaIntermediariosSupervisores" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaIntermediariosSupervisores_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorIntermediariosSupervisores" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorIntermediariosSupervisores_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionIntermediariosSupervisores" runat="server" OnItemCommand="dtPaginacionIntermediariosSupervisores_ItemCommand" OnItemDataBound="dtPaginacionIntermediariosSupervisores_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralIntermediariosSupervisores" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteIntermediariosSupervisores" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteIntermediariosSupervisores_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoIntermediariosSupervisores" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoIntermediariosSupervisores_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
    </div>

    <div id="DivBloqueMantenimiento" runat="server">
        <asp:Label ID="lbAccionTomar" runat="server" Text="0" Visible="false"></asp:Label>
        <asp:Label ID="lbCodigoSeleccionadoVariable" runat="server" Text="0" Visible="false"></asp:Label>
        <br />
        <!----------------------------------------------------------------PRIMERA FILA------------------------------------------------------------------------------------->

        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbRetencionSiMantenimiento" runat="server" Text="Retencion Si" CssClass="form-check-input LetrasNegrita" ToolTip="Agregar la Retención al nuevo registro" GroupName="RetencionIntermediario" />
                <asp:RadioButton ID="rbRetencionNoMantenimiento" runat="server" Text="Retencion No" CssClass="form-check-input LetrasNegrita" ToolTip="No Agregar la Retención al nuevo registro" GroupName="RetencionIntermediario" />
                <asp:Label ID="lbSeparador1" runat="server" Text=" | " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbActivoMantenimiento" runat="server" Text="Activo" CssClass="form-check-input LetrasNegrita" ToolTip="Marcar el estatus activo el intermediario" GroupName="EstatusIntermediario" />
                <asp:RadioButton ID="rbInactivoMantenimiento" runat="server" Text="Inactivo" CssClass="form-check-input LetrasNegrita" ToolTip="Marcar el estatus inactivo el intermediario" GroupName="EstatusIntermediario" />
                <asp:Label ID="lbSeparador2" runat="server" Text=" | " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbIntermediarioDirectoMantenimiento" runat="server" Text="Directo" CssClass="form-check-input LetrasNegrita" ToolTip="Intermediario Directo" GroupName="IntermediarioDirecto" />
                <asp:RadioButton ID="rbIntermediarioNoDirectoMantenimiento" runat="server" Text="No Directo" CssClass="form-check-input LetrasNegrita" ToolTip="Intermediario No Directo" GroupName="IntermediarioDirecto" />
            </div>
        </div>
        <br />
        <div class="form-row">

            <!----------------------------------------------------------------SEGUNDA FILA------------------------------------------------------------------------------------->
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaEntradaMAntenimiento" runat="server" Text="Fecha de Entrada" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaEntradaMantenimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaNacimienoMantenimiento" runat="server" Text="Fecha de Nacimiento" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaNacimientoMantenimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbseleccionarTipoIdentificacionMantenimiento" runat="server" Text="Tipo de Identificación" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoIdentificacionMantenimiento" runat="server" ToolTip="Seleccionar el tipo de identificación" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbNumeroIdentificacionMAntenimiento" runat="server" Text="Numero de Identificación" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroIdentificacionMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <!-----------------------------------------------------------------TERCERA FILA----------------------------------------------------------------------------------->

            <div class="form-group col-md-6">
                <asp:Label ID="lbApellidoMantenimiento" runat="server" Text="Apellido" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtApellidoMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                <asp:Label ID="lbNombreMantenimiento" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <!------------------------------------------------------------------CUARTA FILA-------------------------------------------------------------------------------------->

            <div class="form-group col-md-12">
                <asp:Label ID="lbDireccionMantenimiento" runat="server" Text="Dirección" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <!----------------------------------------------------------------QUINTA FILA---------------------------------------------------------------------------------------->

              <div class="form-group col-md-12">
                <asp:Label ID="lbContactoMantenimiento" runat="server" Text="Contacto" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtContactoMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <!----------------------------------------------------------------SEXTA FILA---------------------------------------------------------------------------------------->

             <div class="form-group col-md-4">
                <asp:Label ID="lbPaisMantenimiento" runat="server" Text="Pais" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlPaisMantenimiento" runat="server" ToolTip="Seleccionar el Pais" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaisMantenimiento_SelectedIndexChanged" ></asp:DropDownList>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbZonaMAntenimiento" runat="server" Text="Zona" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlZonaMantenimiento" runat="server" ToolTip="Seleccionar la Zona" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlZonaMantenimiento_SelectedIndexChanged"></asp:DropDownList>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbProvinciaMantenimiento" runat="server" Text="Provincia" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlProvinciaMantenimiento" runat="server" ToolTip="Seleccionar la Provincia" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProvinciaMantenimiento_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <!----------------------------------------------------------------SEPTIMA FILA-------------------------------------------------------------------------------------->

            <div class="form-group col-md-4">
                <asp:Label ID="lbMunicipioMantenimiento" runat="server" Text="Municipio" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlMunicipioMAntenimiento" runat="server" ToolTip="Seleccionar el Municipio" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMunicipioMAntenimiento_SelectedIndexChanged"></asp:DropDownList>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbSectorMantenimiento" runat="server" Text="Sector" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSectorMantenimiento" runat="server" ToolTip="Seleccionar el Sector" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSectorMantenimiento_SelectedIndexChanged"></asp:DropDownList>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbUnicacionMAntenimiento" runat="server" Text="Ubicación" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlUbicacionMantenimiento" runat="server" ToolTip="Seleccionar la Ubicación" CssClass="form-control"></asp:DropDownList>
            </div>

            <!---------------------------------------------------------------OCTAVA FILA---------------------------------------------------------------------------------------------------->

            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSupervisorMantenimiento" runat="server" Text="Codigo Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisorMantenimiento" runat="server" TextMode="Number" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCodigoSupervisorMantenimiento_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="form-group col-md-9">
                <asp:Label ID="lbNombreSupervisorMAntenimiento" runat="server" Text="Nombre de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisorMantenimiento" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <!--------------------------------------------------------------NOVENA FILA-------------------------------------------------------------------------------------------------->

            <div class="form-group col-md-6">
                <asp:Label ID="lbOficinaMantenimiento" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlOficinaMAntenimiento" runat="server" ToolTip="Seleccionar la Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-6">
                <asp:Label ID="lbBancoMantenimieto" runat="server" Text="Banco" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlBancoMantenimiento" runat="server" ToolTip="Seleccionar el Banco" CssClass="form-control"></asp:DropDownList>
            </div>

             <!--------------------------------------------------------------DECIMA FILA-------------------------------------------------------------------------------------------------->

            <div class="form-group col-md-4">
                <asp:Label ID="lbNumeroCuentaMantenimiento" runat="server" Text="Numero de Cuenta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroCuentaMantenimiento" runat="server" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbCanalDistribucionMantenimiento" runat="server" Text="Canal de Distribución" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlCanalDistribucionMantenimiento" runat="server" ToolTip="Seleccionar el Canal de Distribución" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbLicenciaSeguroMantenimiento" runat="server" Text="Licencia de Seguro" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtLicenciaSeguro" runat="server" CssClass="form-control"  AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <!--------------------------------------------------------------DECIMA PRIMERA FILA--------------------------------------------------------------------------------------------->

        </div>
        <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbTipoCuentaMantenimiento" runat="server" CssClass="LetrasNegrita" Text="Tipo de Cuenta"></asp:Label><br />
                <asp:RadioButton ID="rbCuentaAhorroMantenimiento" runat="server" Text="Cuenta de Ahorro" CssClass="form-check-input LetrasNegrita" GroupName="TipoCuenta" />
                <asp:RadioButton ID="rbCuentaCorrienteMantenimiento" runat="server" Text="Cuenta Corriente" CssClass="form-check-input LetrasNegrita" GroupName="TipoCuenta" />
                <asp:RadioButton ID="rbTarjetaMantenimiento" runat="server" Text="Tarjeta" CssClass="form-check-input LetrasNegrita" GroupName="TipoCuenta" />
                <asp:RadioButton ID="rbPrestamoMantenimiento" runat="server" Text="Prestamo" CssClass="form-check-input LetrasNegrita" GroupName="TipoCuenta" />
                <br />

                <asp:Label ID="lbTipoCobroMantenimiento" runat="server" CssClass="LetrasNegrita" Text="Tipo de Cobro"></asp:Label><br />
                <asp:RadioButton ID="rbChequeMantenimiento" runat="server" Text="Cheque" CssClass="form-check-input LetrasNegrita" GroupName="TipoCobro" />
                <asp:RadioButton ID="rbEfectivoMantenimiento" runat="server" Text="Efectivo" CssClass="form-check-input LetrasNegrita" GroupName="TipoCobro" />
                <asp:RadioButton ID="rbTransferenciaMantenimiento" runat="server" Text="Transferencia" CssClass="form-check-input LetrasNegrita" GroupName="TipoCobro" />
                <asp:RadioButton ID="rbCuentasPorPagar" runat="server" Text="Cuentas Por Pagar" CssClass="form-check-input LetrasNegrita" GroupName="TipoCobro" />
            </div>
        </div>
        <br />

        <!---------------------------------------------------------------DECIMA SEGUNDA FILA------------------------------------------------------------------------------------------->
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbTelefono1Mantenimiento" runat="server" Text="Telefono 1" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtTelefono1Mantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbTelefono2Mantenimiento" runat="server" Text="Telefono 2" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtTelefono2Mantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbTelefono3Mantenimiento" runat="server" Text="Telefono 3" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtTelefono3Mantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

        <!-----------------------------------------------------------------DECIMAL TERCERA FILA------------------------------------------------------------------------------------------>

            <div class="form-group col-md-4">
                <asp:Label ID="lbCelularMantenimiento" runat="server" Text="Celular" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCelularMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbFacMantenimiento" runat="server" Text="Fax" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFAxMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbEmailMantenimiento" runat="server" Text="Email" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtEmailMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <!------------------------------------------------------------DECIMAL CUARTA FILA--------------------------------------------------------------------------------------------->

            <div class="form-group col-md-12">
                <asp:Label ID="lbComentarioMAntenimiento" runat="server" Text="Comentario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtComentarioMantenimiento" runat="server" TextMode="MultiLine" CssClass="form-control" Width="100%" Height="60px" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:Button ID="btnGuardarMantenimiento" runat="server" Text="Guardar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Guardar Registro" OnClick="btnGuardarMantenimiento_Click" />
            <asp:Button ID="btnVolverAtrasMantenimiento" runat="server" Text="Volver"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Volver Atras" OnClick="btnVolverAtrasMantenimiento_Click" />
        </div>
        <br />
    </div>

      <div id="DivBloqueComisiones" runat="server">
          <br />
          <div align="center">
              <asp:Label ID="lbEncabezadoCmisionesTitulo" runat="server" Text="Listado de Comisiones de: " CssClass="LetrasNegrita"></asp:Label>
              <asp:Label ID="lbEncabezadoComisionesVariable" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>

              <asp:Label ID="lbCodigoIntermediario" runat="server" Text="0" Visible="false" CssClass="LetrasNegrita"></asp:Label>
              <asp:Label ID="lbCodigoRamo" runat="server" Text="0" Visible="false" CssClass="LetrasNegrita"></asp:Label>
              <asp:Label ID="lbCodigoSubRamo" runat="server" Text="0" Visible="false" CssClass="LetrasNegrita"></asp:Label>
          </div>
          <br />
          <div class="form-check-inline">
              <div class="form-group form-check">
                  <asp:RadioButton ID="rbConsultarComisiones" runat="server" Text="Consultar Comisiones" CssClass="form-check-input LetrasNegrita" ToolTip="Consultar las comisiones del Intermediario seleccionado" AutoPostBack="true" OnCheckedChanged="rbConsultarComisiones_CheckedChanged" GroupName="Comisiones" />
                  <asp:RadioButton ID="rbModificarComisiones" runat="server" Text="Modificar Comisiones" CssClass="form-check-input LetrasNegrita" ToolTip="Modificar las comisiones del Intermediario seleccionado" AutoPostBack="true" OnCheckedChanged="rbModificarComisiones_CheckedChanged" GroupName="Comisiones" />
              </div>
          </div>
          <br />
          <div class="form-row">
              <div class="form-group col-md-4">
                  <asp:Label ID="lbSeleccionarRamoComisiones" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionarRamoComisiones" runat="server" ToolTip="Seleccionar el Ramo para consulta" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarRamoComisiones_SelectedIndexChanged"></asp:DropDownList>
              </div>

              <div class="form-group col-md-4">
                  <asp:Label ID="lbSeleccionarSubRamoComsiiones" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionarSubRamoComisiones" runat="server" ToolTip="Seleccionar el SubRamo para consulta" CssClass="form-control"></asp:DropDownList>
              </div>

              <div class="form-group col-md-4">
                  <asp:Label ID="lbClaveSeguridad" runat="server" Text="Clave de Seguridad" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtClaveSeguridadComisiones" runat="server" TextMode="Password" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <br />
           <div align="center">
            <asp:Button ID="btnConsultarComisiones" runat="server" Text="Consultar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Consultar las comisiones" OnClick="btnConsultarComisiones_Click" />
            <asp:Button ID="btnValidarClaveSeguridad" runat="server" Text="Validar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Validar la Clave de seguridad" OnClick="btnValidarClaveSeguridad_Click" />
        </div><br />
     
      <!--LISTADO DE COMISIONES-->
      <div class="table-responsive">
          <table class="table table-hover">
              <thead>
                  <tr>
                      <th style="width:10%" align="left"> SELECCIONAR </th>
                      <th style="width:5%" align="left"> ID </th>
                      <th style="width:35%" align="left"> RAMO </th>
                      <th style="width:5%" align="left"> ID </th>
                      <th style="width:35%" align="left"> SUBRAMO </th>
                      <th style="width:10%" align="left"> %  </th>
                  </tr>
              </thead>

              <tbody>
                  <asp:Repeater ID="rpListadoComisiones" runat="server">
                      <ItemTemplate>
                          <tr>
                              <asp:HiddenField ID="hfRamoComsiones" runat="server" Value='<%# Eval("IdRamo") %>' />
                              <asp:HiddenField ID="hfSubRamoComisiones" runat="server" Value='<%# Eval("IdSubRamo") %>' />

                              <td style="width:10%" align="left"> <asp:Button ID="btnSeleccionarComision" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Seleccionar Registro" OnClick="btnSeleccionarComision_Click" /> </td>
                              <td style="width:5%" align="left"> <%# Eval("IdRamo") %> </td>
                              <td style="width:35%" align="left"> <%# Eval("Ramo") %> </td>
                              <td style="width:5%" align="left"> <%# Eval("IdSubRamo") %> </td>
                              <td style="width:35%" align="left"> <%# Eval("Subramo") %> </td>
                              <td style="width:10%" align="left"> <%#string.Format("{0:n2}", Eval("PorcientoComision")) %> </td>
                          </tr>
                      </ItemTemplate>
                  </asp:Repeater>
              </tbody>
          </table>
      </div>
      <div align="center">
               <asp:Label ID="lbPaginaActualTituloIntermediariosSupervisoresComisiones" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleIntermediariosSupervisoresComisiones" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloIntermediariosSupervisoresComisiones" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableIntermediariosSupervisoresComisiones" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionComisiones" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaIntermediariosSupervisoresComisiones" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaIntermediariosSupervisoresComisiones_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorIntermediariosSupervisoresComisiones" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorIntermediariosSupervisoresComisiones_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionIntermediariosSupervisoresComisiones" runat="server" OnItemCommand="dtPaginacionIntermediariosSupervisoresComisiones_ItemCommand" OnItemDataBound="dtPaginacionIntermediariosSupervisoresComisiones_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralIntermediariosSupervisoresComisiones" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteIntermediariosSupervisoresComisiones" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteIntermediariosSupervisoresComisiones_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoIntermediariosSupervisoresComisiones" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoIntermediariosSupervisoresComisiones_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />

      <div id="DivBloqueInternoComision" runat="server">
          <div class="form-row">
              <div class="form-group col-md-6">
                  <asp:Label ID="lbRamoSeleccionadoComisionesComisiones" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtRamoSeleccionadoComisionesComisiones" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
              </div>

               <div class="form-group col-md-6">
                  <asp:Label ID="lbSubRamoSeleccionadoComisiones" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtSubRamoSeleccionadoComisiones" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
              </div>

               <div class="form-group col-md-6">
                  <asp:Label ID="lbPorcientoComisionSeleccionadoComisiones" runat="server" Text="% de Comisión" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtPorcientoComisionSeleccionadoComisiones" runat="server" TextMode="Number" step="0.01" CssClass="form-control" Enabled="false"></asp:TextBox>
              </div>

            
          </div>
           <div align="center">
            <asp:Button ID="btnModificarComision" runat="server" Text="Modificar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar Comisión" OnClick="btnModificarComision_Click" />
            <asp:Button ID="btnCancearProceso" runat="server" Text="Cancelar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Cancelar Proceso" OnClick="btnCancearProceso_Click" />
        </div><br />
      </div>
      <br />
       <div align="center">
            <asp:Button ID="btnVolverAtrasComisiones" runat="server" Text="Volver"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Volver Atras" OnClick="btnVolverAtrasComisiones_Click" />
        </div><br />
           </div>
  </div>
</asp:Content>

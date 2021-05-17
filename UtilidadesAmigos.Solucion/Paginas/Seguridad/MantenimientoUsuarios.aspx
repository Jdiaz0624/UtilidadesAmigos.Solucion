<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoUsuarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoUsuarios" %>
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
        $(document).ready(function () {

            //VALIDAMOS LOS DATOS DEL BOTON GUARDAR
            $("#<%=btnGuardar.ClientID%>").click(function () {
                var Sucursal = $("#<%=ddlSucursalMantenimiento.ClientID%>").val();
                if (Sucursal < 1) {
                    alert("El campo Sucursal no puede estar vacio para realizar esta operación.");
                    $("#<%=ddlSucursalMantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Oficina = $("#<%=ddlOficinaMantenimiento.ClientID %>").val();
                    if (Oficina < 1) {
                        alert("El campo de Oficina no puede estar vacio para realizar esta operación.");
                        $("#<%=ddlOficinaMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var Departamento = $("#<%=ddlDepartamentoMantenimiento.ClientID%>").val();
                        if (Departamento < 1) {
                            alert("El campo Departamento no puede estar vacio para realizar esta operación.");
                            $("#<%=ddlDepartamentoMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var Perfil = $("#<%=ddlPerfilMantenimiento.ClientID%>").val();
                            if (Perfil < 1) {
                                alert("El campo Perfil no puede estar vacio para realizar esta operación.");
                                $("#<%=ddlPerfilMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var Usuario = $("#<%=txtUsuarioMantenimiento.ClientID%>").val().length;
                                if (Usuario < 1) {
                                    alert("El campo Usuario no puede estar vacio para realizar esta operación.");
                                    $("#<%=txtUsuarioMantenimiento.ClientID%>").css("border-color", "Red");
                                    return false;
                                }
                                else {
                                    var Persona = $("#<%=txtPersonaMantenimiento.ClientID%>").val().length;
                                    if (Persona < 1) {
                                        alert("El campo Persona no puede estar vacio para realizar esta operación.");
                                        $("#<%=txtPersonaMantenimiento.ClientID%>").css("border-color", "red");
                                        return false;
                                    }
                                    else {
                                        var TipoPersona = $("#<%=ddlTipoPersonaMantenimiento.ClientID%>").val();
                                        if (TipoPersona < 1) {
                                            alert("El campo Tipo de Persona no puede esta vacio para realizar esta operación.");
                                            $("#<%=ddlTipoPersonaMantenimiento.ClientID%>").css("border-color", "red");
                                            return false;
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
    <br />
    <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>
    <asp:Label ID="lbIdUsuario" runat="server" Text="0" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div id="DivBloqueConsulta" runat="server">
           <div class="form-row">
               <div class="form-group col-md-3">
                   <asp:Label ID="lbSucursalConsulta" runat="server" Text="Sucursal" CssClass="LetrasNegrita"></asp:Label>
                   <asp:DropDownList ID="ddlSucursalCOnsulta" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSucursalCOnsulta_SelectedIndexChanged"></asp:DropDownList>
               </div>

               <div class="form-group col-md-3">
                   <asp:Label ID="lbOficinaConsulta" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                   <asp:DropDownList ID="ddlOficinaConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOficinaConsulta_SelectedIndexChanged"></asp:DropDownList>
               </div>

               <div class="form-group col-md-3">
                   <asp:Label ID="lbDepartamentoConsulta" runat="server" Text="Departamento" CssClass="LetrasNegrita"></asp:Label>
                   <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" ToolTip="Seleccionar Departamento" CssClass="form-control"></asp:DropDownList>
               </div>

               <div class="form-group col-md-3">
                   <asp:Label ID="lbPerfilConsulta" runat="server" Text="Perfil" CssClass="LetrasNegrita"></asp:Label>
                   <asp:DropDownList ID="ddlPerfilCOnsulta" runat="server" ToolTip="Seleccionar Perfil" CssClass="form-control"></asp:DropDownList>
               </div>

               <div class="form-group col-md-3">
                   <asp:Label ID="lbUsuarioConsulta" runat="server" Text="Usuario" CssClass="LetrasNegrita"></asp:Label>
                   <asp:TextBox ID="txtUsuarioConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
               </div> 
           </div>
            <br />
            <div align="center">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Crear Nuevo Registro" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnReporte" runat="server" Text="Reporte"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Reporte de Usuarios" OnClick="btnReporte_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar Registro Seleccionado" OnClick="btnModificar_Click" />
                <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Restablecer Pantalla" OnClick="btnRestablecer_Click" />

            </div>
            <br />
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="width:10%" align="left"> SELECCIONAR </th>
                            <th style="width:10%" align="left"> USUARIO </th>
                            <th style="width:20%" align="left"> PERSONA </th>
                            <th style="width:10%" align="left"> SUCURSAL </th>
                            <th style="width:10%" align="left"> OFICINA </th>
                            <th style="width:10%" align="left"> DEPARTAMENTO </th>
                            <th style="width:10%" align="left"> PERFIL </th>
                            <th style="width:10%" align="left"> ESTATUS </th>
                            <th style="width:10%" align="left"> CAMBIA CLAVE </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoUsuarios" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfIdUsuario" runat="server" Value='<%# Eval("IdUsuario") %>' />
                                    <td style="width:10%" align="left"> <asp:Button ID="btnSeleccionarUsuario" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarUsuario_Click" /> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Usuario") %> </td>
                                    <td style="width:20%" align="left"> <%# Eval("Persona") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Sucursal") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Oficina") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Departamento") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Perfil") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Estatus") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("CambiaClave") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

             <div align="center">
               <asp:Label ID="lbPaginaActualTituloUsuarios" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleUsuarios" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloUsuarios" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableUsuarios" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionUsuarios" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaUsuarios" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaUsuarios_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorUsuarios" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorUsuarios_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionUsuarios" runat="server" OnItemCommand="dtPaginacionUsuarios_ItemCommand" OnItemDataBound="dtPaginacionUsuarios_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralUsuarios" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteUsuarios" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteUsuarios_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoUsuarios" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoUsuarios_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>

        <div id="DivBloqueMantenimiento" runat="server">
            <br />
            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label ID="lbSucursalMantenimiento" runat="server" Text="Sucursal" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSucursalMantenimiento" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSucursalMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                </div>

                 <div class="form-group col-md-3">
                    <asp:Label ID="lbOficinaMAntenimiento" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOficinaMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                </div>

                 <div class="form-group col-md-3">
                    <asp:Label ID="lbDepartamentoMantenimiento" runat="server" Text="Departamento" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlDepartamentoMantenimiento" runat="server" ToolTip="Seleccionar Departamento" CssClass="form-control"></asp:DropDownList>
                </div>

                 <div class="form-group col-md-3">
                    <asp:Label ID="lbPerfilMantenimiento" runat="server" Text="Perfil" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlPerfilMantenimiento" runat="server" ToolTip="Seleccionar Perfil" CssClass="form-control"></asp:DropDownList>
                </div>

                 <div class="form-group col-md-3">
                    <asp:Label ID="lbUsuarioMantenimiento" runat="server" Text="Usuario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtUsuarioMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbPersonaMantenimiento" runat="server" Text="Persona" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtPersonaMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbEmailMantenimiento" runat="server" Text="Email" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtEmailMantenimiento" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbTipoPersonaMantenimiento" runat="server" Text="Tipo de Persona" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlTipoPersonaMantenimiento" runat="server" ToolTip="Seleccionar Tipo de Persona" CssClass="form-control"></asp:DropDownList>
                </div>

                 <div class="form-group col-md-3">
                    <asp:Label ID="lbClaveSeguridadMAntenimiento" runat="server" Text="Clave de Seguridad" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridadMAntenimiento" runat="server" CssClass="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

            </div>

            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:CheckBox ID="cbEstatusMantenimiento" runat="server" Text="Estatus" ToolTip="Estatus de Usuario" CssClass="form-check-input" />
                    <asp:CheckBox ID="cbLLevaEmail" runat="server" Text="Lleva Email" ToolTip="Validar si lleva envio de correo" CssClass="form-check-input" />
                    <asp:CheckBox ID="cbCambiaClave" runat="server" Text="Cambia Clave" ToolTip="Validar si el usuario cambia clave en el proximo login" CssClass="form-check-input" />
                    <asp:CheckBox ID="cbImpresionMarbete" runat="server" Text="Impresión de Marbete" ToolTip="Dar permiso para impresión de marbetes" CssClass="form-check-input" />
                </div>
            </div>
            <br />
             <div align="center">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Guardar Registro" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Volver Atras" OnClick="btnVolver_Click" />

            </div>
            <br />
        </div>
    </div>

   
</asp:Content>

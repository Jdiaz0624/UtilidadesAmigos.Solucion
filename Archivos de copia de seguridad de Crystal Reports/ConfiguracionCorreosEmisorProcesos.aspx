<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ConfiguracionCorreosEmisorProcesos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Seguridad.ConfiguracionCorreosEmisorProcesos" %>
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
            border-collapse: collapse;6
        }
        

        th {
            background-color: dodgerblue;
            color: white;
        }
    </style>


    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=btnGuardar.ClientID%>").click(function () {
                var Correo = $("#<%=txtCorreoModificar.ClientID%>").val().length;
                if (Correo < 1) {
                    alert("El campo correo no puede estar vacio para modificar este registro, favor de verificar.");
                    $("#<%=txtCorreoModificar.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ClaveCorreo = $("#<%=txtClaveModificar.ClientID%>").val().length;
                    if (ClaveCorreo < 1) {
                        alert("El campo clave de correo no puede estar vacio para modificar este registro, favor de verificar.");
                        $("#<%=txtClaveModificar.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var Puerto = $("#<%=txtpuertoMantenimiento.ClientID%>").val().length;
                        if (Puerto < 1) {
                            alert("El campo puerto no puede estar vacio para modificar este registro, favor de verificar.");
                            $("#<%=txtpuertoMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var SMTP = $("#<%=txtSMTPMantenimiento.ClientID%>").val().length;
                            if (SMTP < 1) {
                                alert("El campo SMTP no puede estar vacio para modificar este registro, favor de verificar.");
                                $("#<%=txtSMTPMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var ClaveSeguridad = $("#<%=txtClaveSeguridad.ClientID%>").val().length;
                                if (ClaveSeguridad < 1) {
                                    alert("El campo clave de seguridad no puede estar vacia para modificar este registro, favor de verificar.");
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

    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <div id="DivBloqueConsulta" runat="server">
            <br />
            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Label ID="lbprocesoConsulta" runat="server" Text="Proceso" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlProcesoConsulta" runat="server" ToolTip="seleccionar Proceso para Consultar" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div align="center">
                <asp:Button ID="btnConsultarRegistros" runat="server" Text="Consultar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Consultar registros" OnClick="btnConsultarRegistros_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar registro Seleccionado" OnClick="btnModificar_Click" />
                <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Restablecer Pantalla" OnClick="btnRestablecer_Click" />
            </div>
            <br />
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="width:10%" align="left"> SELECCIONAR </th>
                            <th style="width:30%" align="left"> CORREO </th>
                            <th style="width:40%" align="left"> PROCESO </th>
                            <th style="width:10%" align="left"> PUERTO </th>
                            <th style="width:10%" align="left"> SMTP </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoCorreos" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfIdCorreo" runat="server" Value='<%# Eval("IdCorreo") %>' />
                                    <asp:HiddenField ID="hfIdProceso" runat="server" Value='<%# Eval("IdProceso") %>' />

                                    <td style="width:10%" align="left"> <asp:Button ID="btnSeleccionarRegistro" runat="server" Text="Seleccionar" OnClick="btnSeleccionarRegistro_Click" ToolTip="Seleccionar Registro" CssClass="btn btn-outline-secondary btn-sm" /> </td>
                                    <td style="width:30%" align="left"> <%# Eval("Correo") %> </td>
                                    <td style="width:40%" align="left"> <%# Eval("Proceso") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Puerto") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("SMTP") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <div align="center">
               <asp:Label ID="lbPaginaActualTituloCorreos" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleCorreos" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloCorreos" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableCorreos" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionCorreos" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaCorreos" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaCorreos_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorCorreos" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorCorreos_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionCorreos" runat="server" OnItemCommand="dtPaginacionCorreos_ItemCommand" OnItemDataBound="dtPaginacionCorreos_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralCorreos" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteCorreos" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteCorreos_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoCorreos" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoCorreos_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>

        <div id="DivBloqueModificar" runat="server">
            <br />
            <asp:Label ID="lbIdCorreoSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
            <asp:Label ID="lbIdProcesoSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label ID="lbCorreoModificar" runat="server" Text="Correo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCorreoModificar" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbClaveModificar" runat="server" Text="Clave" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveModificar" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbPuertoMantenimiento" runat="server" Text="Puerto" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtpuertoMantenimiento" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbSMTPMantenimiento" runat="server" Text="SMTP" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtSMTPMantenimiento" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbClaveSeguridad" runat="server" Text="Clave de Seguridad" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridad" runat="server" AutoCompleteType="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:Button id="btnGuardar" runat="server" Text="Guardar" ToolTip="Guardar Información" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnGuardar_Click" />
                <asp:Button id="btnVolver" runat="server" Text="Volver" ToolTip="Volver Atras" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnVolver_Click" />
            </div>
            <br />
        </div>
    </div>
</asp:Content>

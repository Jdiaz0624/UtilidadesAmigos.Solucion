<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarBackupBaseDatos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.GenerarBackupBaseDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style type="text/css">
     .jumbotron{
            color:#000000; 
            background:#1E90FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }

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
            background-color: #1E90FF;
            color: #000000;
        }
    </style>

    <script type="text/javascript">
        function ClaveSeguridadErronea() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar.");
        }

        function CampoRutaVacio() {
            alert("El campo Ruta de Archivo no puede estar vacio para guardar este registro, favor de verificar.");
            $("#<%=txtRutaArchivoConfiguracion.ClientID%>").css("border-color", "red");
        }
        function CorreoEncontrado() {
            alert("El correo ingresado ya esta registrado para recibir notificación, favor de verificar.");
            $("#<%=txtCorreoElectronico.ClientID%>").css("border-color", "Blue");
        }
        function CampoCorreoVacio() {
            alert("El campo correo no puede estar vacio para guardar este registro, favor de verificar.");
            $("#<%=txtCorreoElectronico.ClientID%>").css("border-color", "red");
        }
        $(document).ready(function () {
            //VALIDACION DEL BOTON GENERAR BACKUP DE BASE DE DATOS
            $("#<%=btnGenerarBackup.ClientID%>").click(function () {
                var ClaveSeguridad = $("#<%=txtClaveSeguridadGenerarBackup.ClientID%>").val().length;
                if (ClaveSeguridad < 1) {
                    alert("El campo clave de seguriad no puede estar vacio para generar el backup, favor de verificar.");
                    $("#<%=txtClaveSeguridadGenerarBackup.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

            //VALIDACION DEL BOTON GENERAR BACKUP DE BASE DE DATOS
            $("#<%=btnGuardar.ClientID%>").click(function () {
                var ClaveSeguridadConfiguracion = $("#<%=txtClaveSeguridadConfiguracion.ClientID%>").val().length;
                if (ClaveSeguridadConfiguracion < 1) {
                    alert("El campo clave de seguridad no puede estar vacio para guardar este registro, favor de verificar.");
                    $("#<%=txtClaveSeguridadConfiguracion.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

            $("#<%=btnModificar.ClientID%>").click(function () {
                var ClaveSeguridadConfiguracion = $("#<%=txtClaveSeguridadConfiguracion.ClientID%>").val().length;
                if (ClaveSeguridadConfiguracion < 1) {
                    alert("El campo clave de seguridad no puede estar vacio para modificar este registro, favor de verificar.");
                     $("#<%=txtClaveSeguridadConfiguracion.ClientID%>").css("border-color", "red");
                     return false;
                 }
            });

            $("#<%=btnEliminar.ClientID%>").click(function () {
                var ClaveSeguridadConfiguracion = $("#<%=txtClaveSeguridadConfiguracion.ClientID%>").val().length;
                if (ClaveSeguridadConfiguracion < 1) {
                    alert("El campo clave de seguridad no puede estar vacio para eliminar, favor de verificar.");
                     $("#<%=txtClaveSeguridadConfiguracion.ClientID%>").css("border-color", "red");
                     return false;
                 }
             });

        })
    </script>

    <br /><br />
   <div class="container-fluid">
        <div class="form-check-inline">
            <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
            <asp:RadioButton ID="rbGenerarBackuup" runat="server" Text="Generar Backup" AutoPostBack="true" CssClass="form-check-input" OnCheckedChanged="rbGenerarBackuup_CheckedChanged" ToolTip="Generar Backup de Base de Datos" GroupName="TipoOperacion" />
            <asp:RadioButton ID="rbHistorialBackup" runat="server" Text="Historial" AutoPostBack="true" CssClass="form-check-input" OnCheckedChanged="rbHistorialBackup_CheckedChanged" ToolTip="Historial de Backup de Base de Datos" GroupName="TipoOperacion" />
            <asp:RadioButton ID="rbConfiguracion" runat="server" Text="Configuración" AutoPostBack="true" CssClass="form-check-input" OnCheckedChanged="rbConfiguracion_CheckedChanged" ToolTip="Configuracion de Base de Datos" GroupName="TipoOperacion" />

    </div>
    <!--INICIO DEL BLOQUE DE BACKUP DE BASE DE DATOS-->
    <div id="DivBloqueBackup" runat="server" visible="false">
   
            <div class="row">
                <div class="col-md-3" >
                    <asp:Label ID="lbClaveSeguridadGenerarBackup"  runat="server" Text="Clave de Seguridad" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridadGenerarBackup" align="center" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                </div>

                 <div class="col-md-3" >
                    <asp:Label ID="lbNombreArchivo"  runat="server" Text="Nombre de Archivo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreArchivo" align="center" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
        <div align="center">
            <asp:Button ID="btnGenerarBackup" runat="server" Text="Generar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Generar backup de Base de datos" OnClick="btnGenerarBackup_Click" />
        </div>
   
    </div>
       <br />
    <!--FIN DEL BLOQUE DE BACKUP DE BASE DE DATOS-->

    <!--INICIO DEL BLOQUE DE HISTORIAL DE BACKUP DE BASE DE DATOS-->
    <div id="DivBloqueHistorialBaseDatos" runat="server" visible="false">
        <div class="row">
            <div class="col-md-4">
                <asp:Label id="lbFechaDesdeHistoerial" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeHistorial" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label id="lbFechaHastaHistorial" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaHistorial" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label id="lbNombreUsuarioHistorial" runat="server" Text="Usuario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreUsuarioHistorial" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <div class="form-check-inline">

                <asp:Label ID="lbTipoReporte" runat="server" Text="Tipo de Reporte: " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="TipoReporte" CssClass="form-check-input" />
                <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="TipoReporte" CssClass="form-check-input" />
                <asp:RadioButton ID="rbWord" runat="server" Text="Word" GroupName="TipoReporte" CssClass="form-check-input" />
 
        </div>

        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Historial" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultar_Click" />
             <asp:Button ID="btnReporte" runat="server" Text="Reporte" ToolTip="Reporte de Historial" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnReporte_Click" />
        </div>
        <br />
        <div align="center">
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de registros ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadregistrosVariable" runat="server" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>
        </div>
        <br />

            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Nombre </th>
                        <th scope="col"> Descripción</th>
                        <th scope="col"> Usuario</th>
                        <th scope="col"> Fecha </th>
                        <th scope="col"> Hora </th>
                        <th scope="col"> Estatus </th>
                        <th scope="col"> Observación </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListado" runat="server">
                        <ItemTemplate>
                            <tr>
                                 <td> <%# Eval("NombreArchivo") %> </td>
                                 <td> <%# Eval("Descripcion") %> </td>
                                 <td> <%# Eval("Usuario") %> </td>
                                 <td> <%# Eval("Fecha") %> </td>
                                 <td> <%# Eval("Hora") %> </td>
                                 <td> <%# Eval("Estatus") %> </td>
                                 <td> <%# Eval("Comentario") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
 

         <div align="center">
                <asp:Label ID="lbPaginaActualTitulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="LinkBlbPaginaActualVariavle" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTitulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionDetalle" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPagina" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPagina_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnterior" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnterior_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguiente" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguiente_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimo" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimo_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>

    </div>
    <!--FIN DEL BLOQUE DE HISTORIAL DE BACKUP DE BASE DE DATOS-->

    <!--INICIO DEL BLOQUE DE CONFIGURACION DE BACKUP DE BASE DE DATOS-->
    <div id="DivBloqueConfiguracionBaseDatos"  runat="server" visible="false">
        <div class="form-check-inline">
  
                    <asp:RadioButton ID="rbConfigurarRutaBackup" runat="server" AutoPostBack="true" OnCheckedChanged="rbConfigurarRutaBackup_CheckedChanged" Text="Configurar Ruta" ToolTip="Configurar la Ruta donde se va a guardar el backup." GroupName="Tipo" CssClass="form-check-input LetrasNegrita " />
                    <asp:RadioButton ID="rbConfigurarCorreosBackup" runat="server" AutoPostBack="true" OnCheckedChanged="rbConfigurarCorreosBackup_CheckedChanged" Text="Configurar Correos" ToolTip="Configurar los correos a los que el sistema enviara notificación una vez realizado el backup." GroupName="Tipo" CssClass="form-check-input LetrasNegrita" />

            </div>
            <br />
        <div class="row" >
            <asp:Label ID="lbIdCorreoEnviarConfiguracion" runat="server" Text="IdCorreoEnviar" Visible="false"></asp:Label>
            <asp:Label ID="lbIdProcesoConfiguracion" runat="server" Text="IdProceso" Visible="false"></asp:Label>


             <div class="col-md-6">
                <asp:Label ID="lbClaveSeguridadConfiguracion" runat="server" Text="Clave de Seguridad" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtClaveSeguridadConfiguracion" runat="server" CssClass="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lbRutaArchivoConfiguracion" runat="server" Text="Ruta de Archivo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtRutaArchivoConfiguracion" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lbCorreoElectronico" runat="server" Text="Correo Electronico" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control" TextMode="Email" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <div class="form-check-inline">

                <asp:CheckBox ID="cbEstatusCorreo" runat="server" Text="Estatus" CssClass="form-check-input LetrasNegrita" ToolTip="Estatus de Correo" />
  
        </div>
        <br />
        <div align="center">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Guardar Registro" OnClick="btnGuardar_Click" />
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar Registro" OnClick="btnModificar_Click" />
             <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Eliminar Registro" OnClick="btnEliminar_Click" />
             <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Restablecer Pantalla" OnClick="btnRestablecer_Click" />
            <br />
            <asp:Label ID="lbCantidadCorreosregistradostitulo" runat="server" Text="Cantidad de Correos ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadCorreosregistradosVariable" runat="server" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadCorreosregistradosCerrar" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>

        </div>
        <br />

            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Eliminar </th>
                        <th scope="col"> Correo </th>
                        <th scope="col"> Estatus </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoCorreos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfIdCorreo" runat="server" Value='<%# Eval("IdCorreoEnviar") %>' />
                                <asp:HiddenField ID="hfIdProceso" runat="server" Value='<%# Eval("IdProceso") %>'/>

                                <td style="width:10%"> <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Eliminar registro" OnClick="btnSeleccionar_Click" /> </td>
                                <td style="width:80%"> <%# Eval("Correo") %> </td>
                                <td style="width:10%"> <%# Eval("Estatus") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

        <div align="center">
                <asp:Label ID="lbPaginaActualConfiguracionTitulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="LinkBlbPaginaActualConfiguracionVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaConfiguracionTitulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaConfiguracionVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionConfiguracion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaConfiguracion" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaConfiguracion_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorConfiguracion" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorConfiguracion_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionConfiguracion" runat="server" OnItemCommand="dtPaginacionConfiguracion_ItemCommand" OnItemDataBound="dtPaginacionConfiguracion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralConfiguracion" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteConfiguracion" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteConfiguracion_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoConfiguracion" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoConfiguracion_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
    </div>
    <!--FIN DEL BLOQUE DE CONFIGURACION DE BACKUP DE BASE DE DATOS-->
   </div>
</asp:Content>

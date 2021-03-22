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
            background-color: dodgerblue;
            color: white;
        }
    </style>

    <script type="text/javascript">
        function ClaveSeguridadErronea() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar.");
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
                    alert("El campo clave de seguridad no puede estar vacio, favor de verificar.");
                    $("#<%=txtClaveSeguridadConfiguracion.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

        })
    </script>

    <br /><br />
   <div class="container-fluid">
        <div class="form-check-inline">
        <div class="form-group form-check">
            <asp:RadioButton ID="rbGenerarBackuup" runat="server" Text="Generar Backup" AutoPostBack="true" CssClass="form-check-input" OnCheckedChanged="rbGenerarBackuup_CheckedChanged" ToolTip="Generar Backup de Base de Datos" GroupName="TipoOperacion" />
            <asp:RadioButton ID="rbHistorialBackup" runat="server" Text="Historial" AutoPostBack="true" CssClass="form-check-input" OnCheckedChanged="rbHistorialBackup_CheckedChanged" ToolTip="Historial de Backup de Base de Datos" GroupName="TipoOperacion" />
            <asp:RadioButton ID="rbConfiguracion" runat="server" Text="Configuración" AutoPostBack="true" CssClass="form-check-input" OnCheckedChanged="rbConfiguracion_CheckedChanged" ToolTip="Configuracion de Base de Datos" GroupName="TipoOperacion" />
        </div>
    </div>
    <!--INICIO DEL BLOQUE DE BACKUP DE BASE DE DATOS-->
    <div id="DivBloqueBackup" runat="server" visible="false">
   
            <div class="form-row">
                <div class="form-group col-md-3" >
                    <asp:Label ID="lbClaveSeguridadGenerarBackup"  runat="server" Text="Clave de Seguridad" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridadGenerarBackup" align="center" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                </div>

                 <div class="form-group col-md-3" >
                    <asp:Label ID="lbNombreArchivo"  runat="server" Text="Nombre de Archivo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreArchivo" align="center" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
        <div align="center">
            <asp:Button ID="btnGenerarBackup" runat="server" Text="Generar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Generar backup de Base de datos" OnClick="btnGenerarBackup_Click" />
        </div>
   
    </div>
    <!--FIN DEL BLOQUE DE BACKUP DE BASE DE DATOS-->

    <!--INICIO DEL BLOQUE DE HISTORIAL DE BACKUP DE BASE DE DATOS-->
    <div id="DivBloqueHistorialBaseDatos" runat="server" visible="false">
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label id="lbFechaDesdeHistoerial" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeHistorial" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label id="lbFechaHastaHistorial" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaHistorial" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label id="lbNombreUsuarioHistorial" runat="server" Text="Usuario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreUsuarioHistorial" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbTipoReporte" runat="server" Text="Tipo de Reporte: " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="TipoReporte" CssClass="form-check-input" />
                <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="TipoReporte" CssClass="form-check-input" />
                <asp:RadioButton ID="rbWord" runat="server" Text="Word" GroupName="TipoReporte" CssClass="form-check-input" />
            </div>
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
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:10%" align="left"> <asp:Label ID="lbNombreArchivoHeaderRepeater" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label> </th>
                        <th style="width:22%" align="left"> <asp:Label ID="lbDescripcionHeaderRepeater" runat="server" Text="Descripcion" CssClass="LetrasNegrita"></asp:Label> </th>
                        <th style="width:16%" align="left"> <asp:Label ID="lbusuarioHeaderRepeater" runat="server" Text="Usuario" CssClass="LetrasNegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbFechaHeaderRepeater" runat="server" Text="Fecha" CssClass="LetrasNegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbHoraHEaderRepeater" runat="server" Text="Hora" CssClass="LetrasNegrita"></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbEstatusHeaderRepeater" runat="server" Text="Estatus" CssClass="LetrasNegrita"></asp:Label> </th>
                        <th style="width:22%" align="left"> <asp:Label ID="lbObservacionGeaderrepeater" runat="server" Text="Observación" CssClass="LetrasNegrita"></asp:Label> </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListado" runat="server">
                        <ItemTemplate>
                            <tr>
                                 <td style="width:10%"> <%# Eval("") %> </td>
                                 <td style="width:22%"> <%# Eval("") %> </td>
                                 <td style="width:16%"> <%# Eval("") %> </td>
                                 <td style="width:10%"> <%# Eval("") %> </td>
                                 <td style="width:10%"> <%# Eval("") %> </td>
                                 <td style="width:10%"> <%# Eval("") %> </td>
                                 <td style="width:22%"> <%# Eval("") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

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
        <div class="form-row" >
             <div class="form-group col-md-6">
                <asp:Label ID="lbClaveSeguridadConfiguracion" runat="server" Text="Clave de Seguridad" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtClaveSeguridadConfiguracion" runat="server" CssClass="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbRutaArchivoConfiguracion" runat="server" Text="Ruta de Archivo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtRutaArchivoConfiguracion" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Guardar Registro" OnClick="btnGuardar_Click" />
        </div>
    </div>
    <!--FIN DEL BLOQUE DE CONFIGURACION DE BACKUP DE BASE DE DATOS-->
   </div>
</asp:Content>

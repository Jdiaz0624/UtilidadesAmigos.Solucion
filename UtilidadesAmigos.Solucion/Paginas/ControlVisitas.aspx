<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ControlVisitas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ControlVisitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Content/EstilosComunes.css" />

   

    <script type="text/javascript">



        function CamposFechasVacios() {
            alert("Los campos fechas no pueden estar vacios para realizar este tipo de busqueda.");
        }

        function CarnetNoDisponible() {
            $("#<%=ddlCarnet.ClientID%>").css("border-color", "red");
        }

        function CarnetDisponible() {
            $("#<%=ddlCarnet.ClientID%>").css("border-color", "green");
        }

        function FechaDesdeVacio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }

        function FechaHastaVacio() {
            $("#<%=txtFechaHAsta.ClientID%>").css("border-color", "red");
        }

        $(Document).ready(function () {
            //Funciones del Boton Guardar
            $("#<%=btnGuardarNuevo.ClientID%>").click(function () {
                var TipoProceso = $("#<%=ddlTipoprocesoMantenimiento.ClientID%>").val();
                if (TipoProceso < 1) {
                    alert("El campo Tipo de Proceso no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=ddlTipoprocesoMantenimiento.ClientID%>").css("border-color", "red");
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
                        var NumeroIdentificacion = $("#<%=txtNumeroIdentificacionMantenimiento.ClientID%>").val().length;
                        if (NumeroIdentificacion < 1) {
                            alert("El campo Numero de Identificación no puede estar vacio para realizar esta operación, favor de verificar.");
                            $("#<%=txtNumeroIdentificacionMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var Remitente = $("#<%=txtRemitenteMantenimiento.ClientID%>").val().length;
                            if (Remitente < 1) {
                                alert("El campo remitente no puede estar vacio para realizar esta operación, favor de verificar.");
                                $("#<%=txtRemitenteMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var Destinatario = $("#<%=txtDestinatarioMantenimiento.ClientID%>").val().length;
                                if (Destinatario < 1) {
                                    alert("El campo Destinatario no puede estar vacio para realizar esta operación, favor de verificar.");
                                    $("#<%=txtDestinatarioMantenimiento.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                                else {
                                    var CantidadDocumentos = $("#<%=txtCantidadDocumentosMantenimiento.ClientID%>").val().length;
                                    if (CantidadDocumentos < 1) {
                                        alert("El campo Cantidad de Documentos no puede estar vacio para realizar esta operación, favor de verificar.");
                                        $("#<%=txtCantidadDocumentosMantenimiento.ClientID%>").css("border-color", "red");
                                        return false;
                                    }
                                    else {
                                        var CantidadPersonas = $("#<%=txtCantidadPersonasMantenimiento.ClientID%>").val().length;
                                        if (CantidadPersonas < 1) {
                                            alert("El campo Cantidad de Personas no puede estar vacio para realizar esta operación, favor de verificar.");
                                            $("#<%=txtCantidadPersonasMantenimiento.ClientID%>").css("border-color", "red");
                                            return false;
                                        }
                                       <%-- else {
                                            var Comentario = $("#<%=txtComentarioMantenimiento.ClientID%>").val().length;
                                            if (Comentario < 1) {
                                                alert("El campo Comentario / Descripción no puede estar vacio para realizar esta operación, favor de verificar.");
                                                $("#<%=txtComentarioMantenimiento.ClientID%>").css("border-color", "red");
                                                return false;
                                            }
                                        }--%>
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
    <asp:Label ID="lbIdRegistroSeleccionado" runat="server" Text="IdRegistroseleccionado" Visible="false"></asp:Label>
    <asp:Label ID="lbAccionTomarSeleccionado" runat="server" Text="Accion" Visible="false"></asp:Label>
    <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>

    <div id="DivBloqueCOnsulta" runat="server">
        <div class="form-check-inline">
     
                <asp:CheckBox ID="cbAgregarRangoFecha" runat="server" Text="Agregar Rango Fecha" CssClass="Letranegrita" AutoPostBack="true" OnCheckedChanged="cbAgregarRangoFecha_CheckedChanged" />
         
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lbTipoProcesoConsulta" runat="server" Text="Tipo de Proceso" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoProcesoCOnsulta" runat="server" ToolTip="Seleccionar el Tipo de Proceso" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbNombreConsulta" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreConsulta" runat="server"  CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbRemitenteConsulta" runat="server" Text="Remitente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtRemitenteConsulta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbDestinatarioConsulta" runat="server" Text="Destinatario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtDestinatario" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="col-md-4" id="DivFechaDesde" runat="server">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="col-md-4" id="DivFechaHAsta" runat="server">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHAsta" runat="server" TextMode="Date" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
             <div class="col-md-6" id="Div1" runat="server">
                <asp:Label ID="lbUsuario" runat="server" Text="Usuario" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlUsuarioDigita" runat="server" ToolTip="Seleccionar Usuario para filtro" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="form-check-inline">

                <asp:Label ID="lbGenerarReporteEn" runat="server" Text="Generar Reporte en:" CssClass="Letranegrita"></asp:Label><br />
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" ToolTip="Generar Reporte en PDF" CssClass="Letranegrita" GroupName="Reporte" />
                <asp:RadioButton ID="rbEXcel" runat="server" Text="XLSX" ToolTip="Generar Reporte en Excel" CssClass="Letranegrita" GroupName="Reporte" />
                <asp:RadioButton ID="rbWord" runat="server" Text="Docx" ToolTip="Generar Reporte en Word" CssClass="Letranegrita" GroupName="Reporte" />
                <asp:RadioButton ID="rbTXT" runat="server" Text="TXT" ToolTip="Generar Reporte en TXT" CssClass="Letranegrita" GroupName="Reporte" />
   
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultarNuevo" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" OnClick="btnConsultarNuevo_Click" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" />
            <asp:ImageButton ID="btnReporteNuevo" runat="server" ToolTip="Generar Reporte de Control de Visitas" CssClass="BotonImagen" OnClick="btnReporteNuevo_Click" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" />
            <asp:ImageButton ID="btnNuevoNuevo" runat="server" ToolTip="Crear Nuevo Registro" CssClass="BotonImagen" OnClick="btnNuevoNuevo_Click" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" />
            <asp:ImageButton ID="btnModificarNuevo" runat="server" Enabled="false" ToolTip="Modificar Registro Seleccionado" CssClass="BotonImagen" OnClick="btnModificarNuevo_Click" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" />
            <asp:ImageButton ID="btnEliminarNuevo" runat="server" Enabled="false" ToolTip="Eliminar Registro Seleccionado" CssClass="BotonImagen" OnClick="btnEliminarNuevo_Click" ImageUrl="~/ImagenesBotones/borrar.png" />
            <asp:ImageButton ID="btnRestablecerNuevo" runat="server" Enabled="false" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" OnClick="btnRestablecerNuevo_Click" ImageUrl="~/ImagenesBotones/Restablecer_Nuevo.png" />
        </div>
        <br />
           <div class="table-responsive">
                <table class="table table-striped">
     <thead class="table-dark">
         <tr>
             
             <th scope="col">Nombre</th>
             <th scope="col">RNC</th>
             <th scope="col">Fecha</th>
             <th scope="col">Tipo PROC</th>
             <th scope="col">Remitente</th>
             <th scope="col">Destinatario</th>
             <th scope="col">Selet</th>
         </tr>
     </thead>
     <tbody>
         <asp:Repeater ID="rpListadoControlVisitas" runat="server">
             <ItemTemplate>
                 <asp:HiddenField ID="hfNoRegistro" runat="server" Value='<%# Eval("NoRegistro") %>' />

                 <tr>
                     
                     <td><%# Eval("Nombre") %> </td>
                     <td><%# Eval("NumeroIdentificacion") %></td>
                     <td><%# Eval("FechaDigita") %></td>
                     <td><%# Eval("TipoProceso") %></td>
                     <td><%# Eval("Remitente") %></td>
                     <td><%# Eval("Destinatario") %></td>
                     
                     <td><asp:ImageButton ID="btnSeleccionarRegistrosNuevo" runat="server" ToolTip="Seleccionar Registro" CssClass="BotonImagen" OnClick="btnSeleccionarRegistrosNuevo_Click" ImageUrl="~/ImagenesBotones/hacer-clic.png" /></td>
                 </tr>
             </ItemTemplate>
         </asp:Repeater>
     </tbody>
 </table>
          
<table>
            <tfoot class="table-light ContenidoDerecha">
        <tr class="ContenidoDerecha">
            <td class="ContenidoDerecha"><b>Pagina </b> <asp:Label ID="lbPaginaActual" runat="server" Text=" 0 "></asp:Label> <b>De </b>   <asp:Label ID="lbCantidadPagina" runat="server" Text="0" ></asp:Label> </td>
        </tr>
    </tfoot>
</table>

 <div id="DivPaginacionListadoPrincipal" runat="server" align="center" >
    <div style="margin-top=20px;">
        <table style="width:600px;">
            <tr>
                <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" OnClick="btnPrimeraPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" OnClick="btnPaginaAnterior_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                <td align="center">
                    <asp:DataList ID="dtPaginacion" runat="server" OnCancelCommand="dtPaginacionListadoPrincipal_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipal_ItemDataBound" RepeatDirection="Horizontal" >
                        <ItemTemplate>
                            <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                        </ItemTemplate>
                    </asp:DataList>

                </td>
                <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" OnClick="btnSiguientePagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" OnClick="btnUltimaPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
               
            </tr>
        </table>
    </div>
</div>

                </div>
        <br />

         <!--GRAFICO DE SUPERVISORES-->
        <div id="DivGraficoControlVisitas" runat="server" align="center" >

             <asp:Label ID="lbGraficoControlVisitas" runat="server"  Text="Estadistica de Control de visitas" CssClass="Letranegrita"></asp:Label>
             <br />
            <asp:Chart ID="GraControlVisitas" Width="1100px" runat="server" Palette="SeaGreen">
           <Series>
               <asp:Series Name="Serie" XValueMember="1" YValueMembers="2" IsValueShownAsLabel="true" Label="#VAL{N0}"></asp:Series>
           </Series>
           <ChartAreas>
               <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
           </ChartAreas>
       </asp:Chart>
        </div>


        <div id="DivBloqueDetalle" visible="false" runat="server">
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label id="lbCantidadDocumentosVistaPrevia" runat="server" Text="Cantidad de Documentos" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCantidadDocumentosVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label id="lbCantidadPersonasVistaPrevia" runat="server" Text="Cantidad de Personas" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCantidadPersonasVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label id="lbCreadoPorVistaPrevia" runat="server" Text="Creado Por" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCreadoPorVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label id="lbUltimaModificacionVistaPrevia" runat="server" Text="Modificado Por" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtModificadoPorVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label id="lbFechaModificadoVistaPrevia" runat="server" Text="Fecha Modificado" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaModificadoVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-4">

                </div>

                <div class="col-md-12">
                    <asp:Label id="lbComentarioVistaPrevia" runat="server" Text="Comentario / Descripción" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtComentarioVistaPrevia" runat="server" Enabled="false" TextMode="MultiLine" Height="100px" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>


    <div id="DivBloqueMantenimiento" runat="server">
        <asp:HiddenField ID="hfResultadoValidacionCarnet" runat="server" />
        <br />
        <div class="row">
            <div class="col-md-4">
                <label class="Letranegrita "> Tipo de Proceso </label>
                <label class="Letranegrita Rojo"> * </label>
                <asp:DropDownList ID="ddlTipoprocesoMantenimiento" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoprocesoMantenimiento_SelectedIndexChanged" ToolTip="Seleccionar el Tipo de Proceso"></asp:DropDownList>
            </div>

              <div class="col-md-4">
                  <label class="Letranegrita "> Nombre </label>
                  <label class="Letranegrita Rojo"> * </label>
                <asp:TextBox ID="txtNombreMantenimiento" runat="server" AutoPostBack="true" OnTextChanged="txtNombreMantenimiento_TextChanged" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                 <label class="Letranegrita "> Numero de Identificación </label>
                 <label class="Letranegrita Rojo"> * </label>
                <asp:TextBox ID="txtNumeroIdentificacionMantenimiento" runat="server" MaxLength="30" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                 <label class="Letranegrita "> Remitente </label>
                 <label class="Letranegrita Rojo"> * </label>
                <asp:TextBox ID="txtRemitenteMantenimiento" runat="server" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                 <label class="Letranegrita "> Destinatario </label>
                 <label class="Letranegrita Rojo"> * </label>
                <asp:TextBox ID="txtDestinatarioMantenimiento" runat="server" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                 <label class="Letranegrita "> Cantidad de Documentos </label>
                 <label class="Letranegrita Rojo"> * </label>
                <asp:TextBox ID="txtCantidadDocumentosMantenimiento" runat="server" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                 <label class="Letranegrita "> Cantidad de Personas </label>
                 <label class="Letranegrita Rojo"> * </label>
                <asp:TextBox ID="txtCantidadPersonasMantenimiento" runat="server" TextMode="Number" AutoCompleteType ="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-4">
               <label class="Letranegrita "> Asignacion de Carnet </label>
               <label class="Letranegrita Rojo"> * </label>
               <asp:DropDownList ID="ddlCarnet" runat="server" ToolTip="Asignar Carnet" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCarnet_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-md-4">
       
            </div>

            <div class="col-md-12">
                <asp:Label ID="lbComentario" runat="server" Text="Comentario / Descripción" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtComentarioMantenimiento" runat="server" TextMode="MultiLine" Height="100px" AutoCompleteType ="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnGuardarNuevo" runat="server" ToolTip="Completar Operación" CssClass="BotonImagen" OnClick="btnGuardarNuevo_Click" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" />
            <asp:ImageButton ID="btnVolverNuevo" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" OnClick="btnVolverNuevo_Click" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" />
        </div>
        <br />
    </div>
</asp:Content>

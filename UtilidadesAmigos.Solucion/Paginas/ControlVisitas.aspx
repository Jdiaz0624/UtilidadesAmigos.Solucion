<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ControlVisitas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ControlVisitas" %>
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

          .BotonEspecoal {
           width:100%;
             font-weight:bold;
          }

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        

        th {
            background-color: #1E90FF;
            color: #000000;
        }
          .auto-style1 {
              width: 70%;
              height: 36px;
          }
          .auto-style2 {
              width: 10%;
              height: 36px;
          }
        .BotonImagen {
            width: 50px;
            height: 50px;
        }
    </style>

    <script type="text/javascript">

        function CamposFechasVacios() {
            alert("Los campos fechas no pueden estar vacios para realizar este tipo de busqueda.");
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
            <asp:ImageButton ID="btnConsultarNuevo" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" OnClick="btnConsultarNuevo_Click" ImageUrl="~/Imagenes/Buscar.png" />
            <asp:ImageButton ID="btnReporteNuevo" runat="server" ToolTip="Generar Reporte de Control de Visitas" CssClass="BotonImagen" OnClick="btnReporteNuevo_Click" ImageUrl="~/Imagenes/Reporte.png" />
            <asp:ImageButton ID="btnNuevoNuevo" runat="server" ToolTip="Crear Nuevo Registro" CssClass="BotonImagen" OnClick="btnNuevoNuevo_Click" ImageUrl="~/Imagenes/Agregar (2).png" />
            <asp:ImageButton ID="btnModificarNuevo" runat="server" Enabled="false" ToolTip="Modificar Registro Seleccionado" CssClass="BotonImagen" OnClick="btnModificarNuevo_Click" ImageUrl="~/Imagenes/Editar.png" />
            <asp:ImageButton ID="btnEliminarNuevo" runat="server" Enabled="false" ToolTip="Eliminar Registro Seleccionado" CssClass="BotonImagen" OnClick="btnEliminarNuevo_Click" ImageUrl="~/Imagenes/Eliminar.png" />
            <asp:ImageButton ID="btnRestablecerNuevo" runat="server" Enabled="false" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" OnClick="btnRestablecerNuevo_Click" ImageUrl="~/Imagenes/auto.png" />
        </div>
        <br />
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">Selet</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">RNC</th>
                        <th scope="col">Fecha</th>
                        <th scope="col">Tipo PROC</th>
                        <th scope="col">Remitente</th>
                        <th scope="col">Destinatario</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoControlVisitas" runat="server">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfNoRegistro" runat="server" Value='<%# Eval("NoRegistro") %>' />

                            <tr>
                                <td><asp:ImageButton ID="btnSeleccionarRegistrosNuevo" runat="server" ToolTip="Seleccionar Registro" CssClass="BotonImagen" OnClick="btnSeleccionarRegistrosNuevo_Click" ImageUrl="~/Imagenes/Seleccionar2.png" /></td>
                                <td><%# Eval("Nombre") %> </td>
                                <td><%# Eval("NumeroIdentificacion") %></td>
                                <td><%# Eval("FechaDigita") %></td>
                                <td><%# Eval("TipoProceso") %></td>
                                <td><%# Eval("Remitente") %></td>
                                <td><%# Eval("Destinatario") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>



         <div align="center">
                <asp:Label ID="lbPaginaActualTituloControlVisistas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableControlVisistas" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloControlVisistas" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableControlVisistas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionControlVisistas" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaControlVisistas" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaControlVisistas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorControlVisistas" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorControlVisistas_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionControlVisistas" runat="server" OnItemCommand="dtPaginacionControlVisistas_ItemCommand" OnItemDataBound="dtPaginacionControlVisistas_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralControlVisistas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteControlVisistas" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteControlVisistas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoControlVisistas" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoControlVisistas_Click"></asp:LinkButton> </td>
                </tr>
            </table>
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

        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lbTipoProcesoMantenimiento" runat="server" Text="Tipo de Proceso" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlTipoprocesoMantenimiento" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoprocesoMantenimiento_SelectedIndexChanged" ToolTip="Seleccionar el Tipo de Proceso"></asp:DropDownList>
            </div>

              <div class="col-md-4">
                <asp:Label ID="lbNombreMantenimiento" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreMantenimiento" runat="server" AutoPostBack="true" OnTextChanged="txtNombreMantenimiento_TextChanged" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbNumeroIdentificacionMantenimiento" runat="server" Text="Numero de Identificación" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroIdentificacionMantenimiento" runat="server" MaxLength="30" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbRemitenteMantenimiento" runat="server" Text="Remitente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtRemitenteMantenimiento" runat="server" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbDestinatarioMantenimiento" runat="server" Text="Destinatario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtDestinatarioMantenimiento" runat="server" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbCantidadDocumentosMantenimiento" runat="server" Text="Cantidad de Documentos" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCantidadDocumentosMantenimiento" runat="server" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbCantidadPersonasMantenimient" runat="server" Text="Cantidad de Personas" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCantidadPersonasMantenimiento" runat="server" TextMode="Number" AutoCompleteType ="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-4">
              
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
            <asp:ImageButton ID="btnGuardarNuevo" runat="server" ToolTip="Completar Operación" CssClass="BotonImagen" OnClick="btnGuardarNuevo_Click" ImageUrl="~/Imagenes/salvar.png" />
            <asp:ImageButton ID="btnVolverNuevo" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" OnClick="btnVolverNuevo_Click" ImageUrl="~/Imagenes/volver-flecha.png" />
        </div>
        <br />
    </div>
</asp:Content>

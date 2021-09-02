﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ControlVisitas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ControlVisitas" %>
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
            background-color: dodgerblue;
            color: white;
        }
          .auto-style1 {
              width: 70%;
              height: 36px;
          }
          .auto-style2 {
              width: 10%;
              height: 36px;
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
            $("#<%=btnGuardar.ClientID%>").click(function () {
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
                                        else {
                                            var Comentario = $("#<%=txtComentarioMantenimiento.ClientID%>").val().length;
                                            if (Comentario < 1) {
                                                alert("El campo Comentario / Descripción no puede estar vacio para realizar esta operación, favor de verificar.");
                                                $("#<%=txtComentarioMantenimiento.ClientID%>").css("border-color", "red");
                                                return false;
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

    <br />
    <asp:Label ID="lbIdRegistroSeleccionado" runat="server" Text="IdRegistroseleccionado" Visible="false"></asp:Label>
    <asp:Label ID="lbAccionTomarSeleccionado" runat="server" Text="Accion" Visible="false"></asp:Label>

    <div id="DivBloqueCOnsulta" runat="server">
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbAgregarRangoFecha" runat="server" Text="Agregar Rango Fecha" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="cbAgregarRangoFecha_CheckedChanged" />
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbTipoProcesoConsulta" runat="server" Text="Tipo de Proceso" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoProcesoCOnsulta" runat="server" ToolTip="Seleccionar el Tipo de Proceso" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbNombreConsulta" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbRemitenteConsulta" runat="server" Text="Remitente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtRemitenteConsulta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbDestinatarioConsulta" runat="server" Text="Destinatario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtDestinatario" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="form-group col-md-4" id="DivFechaDesde" runat="server">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="form-group col-md-4" id="DivFechaHAsta" runat="server">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHAsta" runat="server" TextMode="Date" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:Label ID="lbGenerarReporteEn" runat="server" Text="Generar Reporte en:" CssClass="Letranegrita"></asp:Label><br />
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" ToolTip="Generar Reporte en PDF" CssClass="Letranegrita form-check-input" GroupName="Reporte" />
                <asp:RadioButton ID="rbEXcel" runat="server" Text="XLSX" ToolTip="Generar Reporte en Excel" CssClass="Letranegrita form-check-input" GroupName="Reporte" />
                <asp:RadioButton ID="rbWord" runat="server" Text="Docx" ToolTip="Generar Reporte en Word" CssClass="Letranegrita form-check-input" GroupName="Reporte" />
                <asp:RadioButton ID="rbTXT" runat="server" Text="TXT" ToolTip="Generar Reporte en TXT" CssClass="Letranegrita form-check-input" GroupName="Reporte" />
            </div>
        </div>
        <br />
        <div align="center">
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnReporte" runat="server" Text="Reporte" ToolTip="Volver Atras" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnReporte_Click" />
             <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Nuevo Registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnNuevo_Click" />
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" Enabled="false" ToolTip="Modificar Registros" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnModificar_Click" />
             <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Enabled="false" ToolTip="Eliminar Registros" CssClass="btn btn-outline-danger btn-sm" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer" Enabled="false" ToolTip="Restablecer Pantalla" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnRestablecer_Click" />
        </div>
        <br />

        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:10%" align="left">SELECT</th>
                        <th style="width:15%" align="left">NOMBRE</th>
                        <th style="width:15%" align="left">RNC</th>
                        <th style="width:10%" align="left">FECHA</th>
                        <th style="width:15%" align="left">TIPO PROC</th>
                        <th style="width:15%" align="left">REMITENTE</th>
                        <th style="width:15%" align="left">DESTINATARIO</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoControlVisitas" runat="server">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfNoRegistro" runat="server" Value='<%# Eval("NoRegistro") %>' />

                            <tr>
                                <td style="width:10%" align="left"><asp:Button ID="btnSeleccionarRegistros" runat="server" Text="Seleccionar" ToolTip="Seleccionar Registros" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarRegistros_Click" /> </td>
                                <td style="width:15%" align="left"><%# Eval("Nombre") %> </td>
                                <td style="width:15%" align="left"><%# Eval("NumeroIdentificacion") %></td>
                                <td style="width:15%" align="left"><%# Eval("FechaDigita") %></td>
                                <td style="width:15%" align="left"><%# Eval("TipoProceso") %></td>
                                <td style="width:15%" align="left"><%# Eval("Remitente") %></td>
                                <td style="width:15%" align="left"><%# Eval("Destinatario") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>


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
            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Label id="lbCantidadDocumentosVistaPrevia" runat="server" Text="Cantidad de Documentos" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCantidadDocumentosVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="form-group col-md-4">
                    <asp:Label id="lbCantidadPersonasVistaPrevia" runat="server" Text="Cantidad de Personas" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCantidadPersonasVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="form-group col-md-4">
                    <asp:Label id="lbCreadoPorVistaPrevia" runat="server" Text="Creado Por" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCreadoPorVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="form-group col-md-4">
                    <asp:Label id="lbUltimaModificacionVistaPrevia" runat="server" Text="Modificado Por" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtModificadoPorVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="form-group col-md-4">
                    <asp:Label id="lbFechaModificadoVistaPrevia" runat="server" Text="Fecha Modificado" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaModificadoVistaPrevia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-4">

                </div>

                <div class="form-group col-md-12">
                    <asp:Label id="lbComentarioVistaPrevia" runat="server" Text="Comentario / Descripción" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtComentarioVistaPrevia" runat="server" Enabled="false" TextMode="MultiLine" Height="100px" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>


    <div id="DivBloqueMantenimiento" runat="server">

        <br />
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbTipoProcesoMantenimiento" runat="server" Text="Tipo de Proceso" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlTipoprocesoMantenimiento" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoprocesoMantenimiento_SelectedIndexChanged" ToolTip="Seleccionar el Tipo de Proceso"></asp:DropDownList>
            </div>

              <div class="form-group col-md-4">
                <asp:Label ID="lbNombreMantenimiento" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreMantenimiento" runat="server" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbNumeroIdentificacionMantenimiento" runat="server" Text="Numero de Identificación" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroIdentificacionMantenimiento" runat="server" MaxLength="30" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbRemitenteMantenimiento" runat="server" Text="Remitente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtRemitenteMantenimiento" runat="server" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbDestinatarioMantenimiento" runat="server" Text="Destinatario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtDestinatarioMantenimiento" runat="server" MaxLength="100" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbCantidadDocumentosMantenimiento" runat="server" Text="Cantidad de Documentos" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCantidadDocumentosMantenimiento" runat="server" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbCantidadPersonasMantenimient" runat="server" Text="Cantidad de Personas" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCantidadPersonasMantenimiento" runat="server" TextMode="Number" AutoCompleteType ="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
              
            </div>

            <div class="form-group col-md-4">
       
            </div>

            <div class="form-group col-md-12">
                <asp:Label ID="lbComentario" runat="server" Text="Comentario / Descripción" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtComentarioMantenimiento" runat="server" TextMode="MultiLine" Height="100px" AutoCompleteType ="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
           <asp:Button ID="btnGuardar" runat="server" Text="Completar" ToolTip="Completar Operación" CssClass="btn btn-outline-success btn-sm" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" ToolTip="Volver Atras" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnVolver_Click" />
        </div>
        <br />
    </div>
</asp:Content>

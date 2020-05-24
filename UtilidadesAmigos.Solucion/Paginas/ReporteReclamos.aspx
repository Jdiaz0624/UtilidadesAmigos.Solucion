﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteReclamos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ReporteReclamos" %>
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
        .LetrasNegritas {
        font-weight:bold;
        }

         .btn-sm{
            width:100px;
        }
    </style>

    <script type="text/javascript">


        function NumeroReclamoVacio() {
            alert("El campo numero de reclamación no puede estar vacio para generar las fechas automaticas");
            $("#<%=txtNumeroReclamacionMantenimiento.ClientID%>").css("border-color", "red");
        }
        function NumeroReclamoNoValido() {
            alert("El Numero de reclamo ingresado no es valido, favor de verificar");
            $("#<%=txtNumeroReclamacionMantenimiento.ClientID%>").css("border-color", "red");
            return false;
        }

        function Mensaje() {
            alert("Esta opción esta en desarrollo");
        }

        function CamposVaciosCondicion() {
            alert("No puedes dejar campos vacios para realizar esta operación");
            $("#<%=txtMantenimientoCOndicion.ClientID%>").css("border-color", "red");
        }

        function ModoConsulta() {
            //DESBLOQUAR CONTROLES
            $("#<%=btnConsultarRegistros.ClientID%>").removeAttr("disabled", "true");
            $("#<%=btnExportarRegistrosConsulta.ClientID%>").removeAttr("disabled", "true");
            $("#btnNuevo").removeAttr("disabled", "true");
            $("#btnCondicion").removeAttr("disabled", "true");
            $("#btnTipo").removeAttr("disabled", "true");
            $("#btnEstatus").removeAttr("disabled", "true");
          //  $("#").removeAttr("disabled", "true");

            //BLOQUEAR CONTROLES
            $("#brnModificar").attr("disabled", "disabled");
            $("#brnEliminar").attr("disabled", "disabled");
            $("#<%=btnRestabelcerPantalla.ClientID%>").attr("disabled", "disabled");
        }

        function ModoMantenimiento() {
            //DESBLOQUEAR CONTROLES
            $("#brnModificar").removeAttr("disabled", "true");
            $("#brnEliminar").removeAttr("disabled", "true");
            $("#<%=btnRestabelcerPantalla.ClientID%>").removeAttr("disabled", "true");

            //BLOQUEAR CONTROLES
            $("#<%=btnConsultarRegistros.ClientID%>").removeAttr("disabled", "true");
            $("#<%=btnExportarRegistrosConsulta.ClientID%>").removeAttr("disabled", "true");
            $("#btnNuevo").removeAttr("disabled", "true");
            $("#btnCondicion").removeAttr("disabled", "true");
            $("#btnTipo").removeAttr("disabled", "true");
            $("#btnEstatus").removeAttr("disabled", "true");
         //   $("#").removeAttr("disabled", "true");

        }

        function CheckVerde() {
            $("#<%=cbEstatusTipoRecmalo.ClientID%>").css("border-color", "green");
        }

        function BotonNuevo() {
                 $("#<%=btnGuardarMantenimiento.ClientID%>").show();
                $("#<%=btnModificarMantenimeinto.ClientID%>").hide();
                $("#<%=btnEliminarMantenimiento.ClientID%>").hide();

                //LIMPIAMOS LOS CONTROLES
                $("#<%=txtNumeroReclamacionMantenimiento.ClientID%>").val("");
                $("#<%=txtPolizaMantenimiento.ClientID%>").val("");
                $("#<%=txtIntermediarioMantenimiento.ClientID%>").val("");
                $("#<%=txtAseguradoMantenimiento.ClientID%>").val("");
                $("#<%=txtMontoMantenimiento.ClientID%>").val("");
                $("#<%=txtBeneficiarioMantenimiento.ClientID%>").val("");
                $("#<%=txtInicioVigenciaMantenimiento.ClientID%>").val("");
                $("#<%=txtFechaInicioVigenciaAutomatico.ClientID%>").val("");
                $("#<%=txtFinVigenciaMantenimiento.ClientID%>").val("");
                $("#<%=txtFechaFinVigenciaAutomatico.ClientID%>").val("");
                $("#<%=txtFechaAperturaMantenimiento.ClientID%>").val("");
                $("#<%=txtFechaAperturaAutomatica.ClientID%>").val("");
                $("#<%=txtFechaSiniestroMantenimiento.ClientID%>").val("");
                $("#<%=txtFechaSiniestroAutomatica.ClientID%>").val("");
                $("#<%=txtComentarioMantenimiento.ClientID%>").val("");
                $("#<%=lbTituloMantenimiento.ClientID%>").text("Guardar Nuevo Registro");
        }
        $(document).ready(function () {
            //ACCION PARA EJECUTAR POR EL BOTON NUEVO
            $("#btnNuevo").click(function () {
                BotonNuevo();
              

            });

            //RECLAMACION CONSULTA
              $("#<%=txtReclamacionConsulta.ClientID%>").on("keydown keypress", function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 20 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
            });

            //INTERMEDIARIO
              $("#<%=txtIntermediarioConsulta.ClientID%>").on("keydown keypress", function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 4 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
              });

             //INTERMEDIARIO EN MANTENIMIENTO
              $("#<%=txtIntermediarioMantenimiento.ClientID%>").on("keydown keypress", function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 4 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
              });
              

            //CAMPO NUMERICO NUMERO DE RECLAMACION
             $("#<%=txtNumeroReclamacionMantenimiento.ClientID%>").on("keydown keypress", function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 20 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
              });
          

           



              //MANTENIMIENTO DE CONDICIONES DE RECLAMACIONES
           

            //FIN DE MANTENIMIENTO DE CONDICIONES DE RECLAMOS


              $("#<%=btnGuardarMantenimiento.ClientID%>").click(function () {
                  //VALIDAMOS EL NUMERO DE RCLAMO
                  var ValidarReclamacion = $("#<%=txtNumeroReclamacionMantenimiento.ClientID%>").val().length;
                  if (ValidarReclamacion < 1) {
                      alert("El campo numero de reclamación no puede estar vacio, favor de verificar");
                      $("#<%=txtNumeroReclamacionMantenimiento.ClientID%>").css("border-color", "red");
                      return false;
                  }
                  else {
                      //VALIDAMOS EL NUMERO DE POLIZA
                      var ValidarPoliza = $("#<%=txtPolizaMantenimiento.ClientID%>").val().length;
                      if (ValidarPoliza < 1) {
                          alert("El campo poliza no puede estar vacio, favor de verificar");
                          $("#<%=txtPolizaMantenimiento.ClientID%>").css("border-color", "red");
                          return false;
                      }
                      else {
                          //VALIDAMOS EL CODIGO DEL INTERMEDIARIO
                          var CodigoIntermediario = $("#<%=txtIntermediarioMantenimiento.ClientID%>").val().length;
                          if (CodigoIntermediario < 1) {
                              alert("El codigo del intermediario no puede estar vacio, favor de verificar");
                              $("#<%=txtIntermediarioMantenimiento.ClientID%>").css("border-color", "red");
                              return false;
                          }
                          else {
                              //VALIDAMOS EL NOMBRE DEL ASEGURADO
                              var ValidarAsegurado = $("#<%=txtAseguradoMantenimiento.ClientID%>").val().length;
                              if (ValidarAsegurado < 1) {
                                  alert("el campo asegurado no puede estar vacio, favor de verificar");
                                  $("#<%=txtAseguradoMantenimiento.ClientID%>").css("border-color", "red");
                                  return false;
                              }
                              else {
                                  var ValidarTipoReclamo = $("#<%=ddlSeleccionarTipoMantenimiento.ClientID%>").val();
                                  if (ValidarTipoReclamo < 1) {
                                      alert("El campo tipo de reclamación no puede estar vacio, favor de verificar");
                                      $("#<%=ddlSeleccionarTipoMantenimiento.ClientID%>").css("border-color", "red");
                                      return false;
                                  }

                                  else {
                                      var ValidarCondicionReclamo = $("#<%=ddlSeleccionarCondicionMantenimiento.ClientID%>").val();
                                      if (ValidarCondicionReclamo < 1) {
                                          alert("El campo Condición de reclamo no puede estar vacio, favor de verificar");
                                          $("#<%=ddlSeleccionarCondicionMantenimiento.ClientID%>").css("border-color", "red");
                                          return false;
                                      }
                                      else {
                                          //BALIDAMOS EL MONTO DE RECLAMO
                                          var MontoReclamo = $("#<%=txtMontoMantenimiento.ClientID%>").val().length;

                                          if (MontoReclamo < 1) {
                                              alert("El campo monto no puede estar vacio, favor de verificar");
                                              $("#<%=txtMontoMantenimiento.ClientID%>").css("border-color", "red");
                                              return false;
                                          }
                                          else {
                                              //VALIDAMOS EL BENEFICIARIO
                                              var ValidarBeneficiarioReclamo = $("#").val().length;
                                              if (ValidarBeneficiarioReclamo < 1) {
                                                  alert("El campo beneficiario no puede estar vacio, favor de verificar");
                                                  $("#<%=txtBeneficiarioMantenimiento.ClientID%>").css("border-color");
                                                  return false;
                                              }
                                              else {
                                                  //VALIDAR EL ESTATUS DE LA RECLAMACION
                                                  var EstatusREclamo = $("#<%=ddlSeleccionarEstatusMantenimiento.ClientID%>").val();
                                                  if (EstatusREclamo < 1) {
                                                      alert("El campo reclamo no peude estar vacio, favor de verificar");
                                                      $("#<%=ddlSeleccionarEstatusMantenimiento.ClientID%>").css("border-color", "red");
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
              });

        });
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Reporte de Reclamos"></asp:Label>
            <asp:Label ID="lbIdMantenimiento" runat="server" Text="Numero de Reclamos" Visible="false"></asp:Label>
            <asp:Label ID="lbNumeroReclamacionSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
            <asp:Label ID="lbPolizaSeleccionada" runat="server" Text="Poliza" Visible="false"></asp:Label>
            <asp:Label ID="lbIdUsuarioConectado" runat="server" Text="Id de usuario conectado" Visible="false"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbNumeroReclamacionConsulta" runat="server" Text="Reclamación" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtReclamacionConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbIntermediarioConsulta" runat="server" Text="Intermediario" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtIntermediarioConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbAseguradoCOnsulta" runat="server" Text="Asegurado" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtAseguradoCOnsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbCondicionConsulta" runat="server" Text="Seleccionar Condición" CssClass="LetrasNegritas"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarCondicionConsulta" runat="server" ToolTip="Seleccionar Condición" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbBeneficiarioCOnsulta" runat="server" Text="Beneficiario" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtBeneficiarioConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarTipoConsulta" runat="server" Text="Seleccionar Tipo de Reclamo" CssClass="LetrasNegritas"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoConsulta" runat="server" ToolTip="Seleccionar Tipo de Reclamo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarEstatusConsulta" runat="server" Text="Seleccionar Estatus de Reclamo" CssClass="LetrasNegritas"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarEstatutsConsulta" runat="server" ToolTip="Seleccionar Estatus de Reclamo" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbAgregarRangoFechaConsulta" runat="server" AutoPostBack="true" Text="Agregar Rango de Fecha" OnCheckedChanged="cbAgregarRangoFechaConsulta_CheckedChanged" CssClass="form-check-input" />
            </div>
            
        </div><br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbConsultarInicioVigenciaConsulta" Visible="false" runat="server" Text="inicio de Vigencia" ToolTip="Consultar mediante el Inicio de Vigencia" CssClass="form-check-input" GroupName="Consulta" />    
            </div>
             <div class="form-group form-check">
                <asp:RadioButton ID="rbConsultarFinVigencia" runat="server" Visible="false" Text="Fin de Vigencia" ToolTip="Consultar Mediante el Fin de Vigencia" CssClass="form-check-input" GroupName="Consulta" />    
            </div>
             <div class="form-group form-check">
                <asp:RadioButton ID="rbConsultarFechaApertura" runat="server" Visible="false" Text="Fecha de Apertura" ToolTip="Consultar Mediante la fecha de apertura" CssClass="form-check-input" GroupName="Consulta" />    
            </div>
            <div class="form-group form-check">
                <asp:RadioButton ID="rbConsultarFechaSiniestro" runat="server" Visible="false" Text="Fecha de Siniestro" ToolTip="Consultar Mediante la fecha de siniestro" CssClass="form-check-input" GroupName="Consulta" />    
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaDesdeConsulta" runat="server" Visible="false" Text="Fecha Desde" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" Visible="false" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
               <div class="form-group col-md-3">
                <asp:Label ID="lbFechHAstaConsulta" runat="server" Visible="false" Text="Fecha Hasta" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtFechaHAstaConsulta" runat="server" Visible="false"  TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <!--INGRESAMOS LOS BOTONES PARA LAS DISTINTAS OPERACIONES DE LA PAGINA-->
        <div align="center">
            <asp:Button ID="btnConsultarRegistros" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Consultar" ToolTip="Consultar Registros" OnClick="btnConsultarRegistros_Click" />
            <asp:Button ID="btnExportarRegistrosConsulta" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Exportar" ToolTip="Exportar Data a Exel" OnClick="btnExportarRegistrosConsulta_Click" />
            <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".MANTENIMIENTOPOPOP">Nuevo</button>
             <button type="button" id="brnModificar" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".MANTENIMIENTOPOPOP">Modificar</button>
            <button type="button" id="brnEliminar" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".ELIMINARREGISTROPOPOP">Eliminar</button>
            <button type="button" id="btnCondicion" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".POPOCONDICIONESRECLAMOS">Condición</button>
            <button type="button" id="btnTipo" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".POPOTIPORECLAMO">Tipo</button>
            <button type="button" id="btnEstatus" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".POPOESTATUSRECLAMO">Estatus</button>
            <asp:Button ID="btnRestabelcerPantalla" runat="server" Text="Restablecer" CssClass="btn btn-outline-primary btn-sm" ToolTip="Restablecer Pantalla" OnClick="btnRestabelcerPantalla_Click" />
        </div>
        <br />
        <!--GRID-->
        <div align="center">
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros (" CssClass="LetrasNegritas"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariables" runat="server" Text="0" CssClass="LetrasNegritas"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=")" CssClass="LetrasNegritas"></asp:Label>
        </div>
         <div>
            <asp:GridView ID="gvListadoReclamos" runat="server" AllowPaging="true" OnRowDataBound="gvListadoReclamos_RowDataBound" OnPageIndexChanging="gvListadoReclamos_PageIndexChanging" OnSelectedIndexChanged="gvListadoReclamos_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:BoundField DataField="Numero" HeaderText="ID" />
                    <asp:BoundField DataField="Reclamacion" HeaderText="Reclamación" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Asegurado" HeaderText="Asegurado" />
                    <asp:BoundField DataField="Beneficiario" HeaderText="Beneficiario" />
                    <asp:BoundField DataField="TipoReclamacion" HeaderText="Tipo" />
                    <asp:BoundField DataField="Condicion" HeaderText="Condición" />                    
                    <asp:BoundField DataField="EstatusReclamacion" HeaderText="Estatus" />
                     <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
                </Columns  >
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

        <!--GRID-->

        <!--MOSTRAMOS LA INFORMACION SELECCIONADA DEL REGISTRO SELECCIONADO-->
        <div align="center">
                <asp:Label ID="lbRegistroSeleccionado" runat="server" Visible="false" Text="Registro Seleccionado" CssClass="LetrasNegritas"></asp:Label>
            </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbNumeriIDSeleccionadoConsulta" runat="server" Visible="false" Text="Numero de Orden" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtNumeroIdSeleccionadoConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="form-group col-md-4">
                <asp:Label ID="lbNumeroreclamacinSeleccionadoConsulta" runat="server" Visible="false" Text="Numero de Reclamación" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtNumeroreclamacionSeleccionadoConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbPolizaSeleccionadaConsulta" runat="server" Visible="false" Text="Numero de Poliza" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtPolizaSeleccionadaConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbEstatusPolizaSeleccionadaConsulta" runat="server" Visible="false" Text="Estatus de Poliza" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtEstatusPolizaSelccionadaConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbIntermediarioSeleccionadoCOnsulta" runat="server" Visible="false" Text="Intermediario" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtIntermediarioSeleccionadoConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbAseguradoSeleccionadoConsulta" runat="server" Visible="false" Text="Asegurado" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtaseguradoSeleccionadoConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbBeneficiarioSeleccionadoCOnsulta" runat="server" Visible="false" Text="Beneficiario" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtBeneficiarioSeleccionadoConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbTipoSeleccionadoConsulta" runat="server" Visible="false" Text="Tipo de Reclamo" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtTipoReclamoSeleccionado" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbCondicionSeleccionadaConsulta" runat="server" Visible="false" Text="Condición de Reclamo" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtCondicionSeleccionadaConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbEstatusSeleccionadaConsulta" runat="server" Visible="false" Text="Estatus de reclamo" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtEstatusSeleccionadoConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbMontoSeleccionadoConsulta" runat="server" Visible="false" Text="Monto del reclamo" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtMontoSeleccionadoConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbUsuarioSeleccionadoCOnsulta" runat="server" Visible="false" Text="Creado Por" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtUsuarioSeleccionadoCOnsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                <asp:Label ID="lbInicioVigenciaSeleccionadoConsulta" runat="server" Visible="false" Text="Inicio de Vigencia" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtInicioVigenciaSeleccionadoConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group col-md-3">
                <asp:Label ID="lbFechaFinVigenciaSeleccionadaConsulta" runat="server" Visible="false" Text="Fin de Vigencia" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtFechaFinVigenciaSeleccionadaConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group col-md-3">
                <asp:Label ID="lbFechaAperturaSeleccionadaConsulta" runat="server" Visible="false" Text="Fecha de Apertura" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtFechaAperturaSeleccionadaConsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group col-md-3">
                <asp:Label ID="lbFechaSiniestroSeleccionadaConsulta" runat="server" Text="Fecha de Siniestro" Visible="false" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtFechaSiniestroSeleccionadaConsulta" runat="server" Enabled="false" Visible="false" CssClass="form-control"></asp:TextBox>
            </div>
                 <div class="form-group col-md-12">
                <asp:Label ID="lbComentarioSeleccionadoConsulta" runat="server" Text="Comentario" Visible="false" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtComentarioSeleccionadoCnsulta" runat="server" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <asp:ScriptManager ID="ScripsManagerPOPOP" runat="server"></asp:ScriptManager>

        <!--MANTENIMIENTO POPOP-->
                <div class="modal fade MANTENIMIENTOPOPOP" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
       <div class="container-fluid">
           <div class="jumbotron" align="center">
               <asp:Label ID="lbTituloMantenimiento" runat="server" Text="Titulo Mantenimiento"></asp:Label>
           </div>
           <asp:UpdatePanel ID="UpdatePanelMantenimiento" runat="server">
               <ContentTemplate>
                   <!--INGRESAMOS LOS CONTROLES PARA REALIZAR EL MANTENIMIENTO-->
                   <div class="form-row">
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbNumeroReclamacionMantenimiento" runat="server" Text="Numero de Reclamación" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtNumeroReclamacionMantenimiento" TextMode="Number" AutoCompleteType="Disabled" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>

                        <div class="form-group col-md-4">
                           <asp:Label ID="lbPolizaMantenimiento" runat="server" Text="Numero de Poliza" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtPolizaMantenimiento" AutoCompleteType="Disabled" MaxLength="30" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>

                         <div class="form-group col-md-4">
                           <asp:Label ID="lbIntermediarioMantenimeinto" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtIntermediarioMantenimiento" TextMode="Number" AutoCompleteType="Disabled" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>

                         <div class="form-group col-md-4">
                           <asp:Label ID="lbAseguradoMantenimiento" runat="server" Text="Asegurado" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtAseguradoMantenimiento" AutoCompleteType="Disabled" MaxLength="100" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>

                        <div class="form-group col-md-4">
                           <asp:Label ID="lbSeleccionarTipoMantenimiento" runat="server" Text="Seleccionar Tipo" CssClass="LetrasNegritas"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarTipoMantenimiento" runat="server" ToolTip="Seleccionar el tipo de reclamacion" CssClass="form-control"></asp:DropDownList>
                       </div>

                        <div class="form-group col-md-4">
                           <asp:Label ID="lbSeleccionarCondicionMantenimiento" runat="server" Text="Seleccionar Condición" CssClass="LetrasNegritas"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarCondicionMantenimiento" runat="server" ToolTip="Seleccionar la condición de Reclamos" CssClass="form-control"></asp:DropDownList>
                       </div>

                        <div class="form-group col-md-4">
                           <asp:Label ID="lbMontoMantenimiento" runat="server" Text="Monto" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtMontoMantenimiento" AutoCompleteType="Disabled" TextMode="Number" step="0.01"  runat="server" CssClass="form-control"></asp:TextBox>
                       </div>

                        <div class="form-group col-md-4">
                           <asp:Label ID="lbBeneficiarioMantenimiento" runat="server" Text="Beneficiario" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtBeneficiarioMantenimiento" AutoCompleteType="Disabled" MaxLength="100" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>

                       <div class="form-group col-md-4">
                           <asp:Label ID="lbSeleccionarEstatusMantenimiento" runat="server" Text="Seleccionar Estatus de reclamacion" CssClass="LetrasNegritas"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarEstatusMantenimiento" runat="server" ToolTip="Seleccionar el estatus de Reclamos" CssClass="form-control"></asp:DropDownList>
                       </div>

                       <div class="form-group col-md-3">
                           <asp:Label ID="lbFechaInicioVigencia" runat="server" Text="Inicio de Vigencia" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtInicioVigenciaMantenimiento" runat="server" Visible="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
                           <asp:TextBox ID="txtFechaInicioVigenciaAutomatico" runat="server" Enabled="false" Visible="false" CssClass="form-control" ></asp:TextBox>
                       </div>

                       <div class="form-group col-md-3">
                           <asp:Label ID="lbFinVigenciaMantenimiento" runat="server" Text="FIn de Vigencia" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtFinVigenciaMantenimiento" runat="server" Visible="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
                           <asp:TextBox ID="txtFechaFinVigenciaAutomatico" runat="server" Enabled="false" Visible="false" CssClass="form-control" ></asp:TextBox>
                       </div>

                       <div class="form-group col-md-3">
                           <asp:Label ID="lbFechaAperturaMAntenimiento" runat="server" Text="Fecha de Apertura" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtFechaAperturaMantenimiento" runat="server"  Visible="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
                           <asp:TextBox ID="txtFechaAperturaAutomatica" runat="server" Enabled="false" Visible="false" CssClass="form-control" ></asp:TextBox>
                       </div>

                       <div class="form-group col-md-3">
                           <asp:Label ID="lbFechaSiniestroMantenimiento" runat="server" Text="Fecha de Siniestro" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtFechaSiniestroMantenimiento" runat="server" Visible="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
                           <asp:TextBox ID="txtFechaSiniestroAutomatica" runat="server" Enabled="false" Visible="false" CssClass="form-control" ></asp:TextBox>
                       </div>
                   </div>
                   <!--AGREGAR CHECK-->
                   <div class="form-check-inline">
                       <div class="form-group form-check">
                           <asp:CheckBox ID="cbBuscarFechaAutomatico" runat="server" Text="Buscar las Fecha de manera automatica" OnCheckedChanged="cbBuscarFechaAutomatico_CheckedChanged" AutoPostBack="true" ToolTip="Busca la fecha de vigencia, siniestro y de apertura a partir del numero de reclamación ya ingresado en el sistema" CssClass="form-check-input" />
                       </div>
                   </div>
                   <div class="form-row">
                       <div class="form-group col-md-12">
                           <asp:Label ID="lbComentarioMantenimiento" runat="server" Text="Comentario" CssClass="LetrasNegritas"></asp:Label>
                           <asp:TextBox ID="txtComentarioMantenimiento" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="8000"></asp:TextBox>
                       </div>
                   </div>

                    
               </ContentTemplate>
           </asp:UpdatePanel>
        <div align="center">
               <asp:Button ID="btnGuardarMantenimiento" runat="server" Text="Guardar" ToolTip="Guardar registro" OnClick="btnGuardarMantenimiento_Click" CssClass="btn btn-outline-primary btn-sm" />
              <asp:Button ID="btnModificarMantenimeinto" runat="server" Text="Modificar" ToolTip="Modificar Registro" OnClick="btnModificarMantenimeinto_Click" CssClass="btn btn-outline-primary btn-sm" />
              <asp:Button ID="btnEliminarMantenimiento" runat="server" Text="Eliminar" ToolTip="Eliminar Registro" OnClick="btnEliminarMantenimiento_Click" CssClass="btn btn-outline-primary btn-sm" />
           </div>
           <br />
       </div>
    </div>
  </div>
</div>
        <!--FIN DE MANTENIMIENTO POPOP-->

        <!--POPOP CONDICIONES-->
        <div class="modal fade POPOCONDICIONESRECLAMOS" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbMantenimientoCondicionTitulo" runat="server" Text="Mantenimiento de condición de reclamos"></asp:Label>
              <asp:Label ID="lbIdMantenimientoCondicion" runat="server" Text="0" Visible="false"></asp:Label>
              <asp:Label ID="lbAccionCondicionMantenimiento" runat="server" Text="INSERT" Visible="false"></asp:Label>
          </div>
          <asp:UpdatePanel ID="UpdatePanelCondicion" runat="server">
              <ContentTemplate>
                  <div class="form-row">
                      <div class="form-group col-md-4">
                          <asp:Label ID="lbMantenimientoCondicion" runat="server" Text="Condición" CssClass="LetrasNegritas"></asp:Label>
                          <asp:TextBox ID="txtMantenimientoCOndicion" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                      </div>

                    

                  </div>
                  <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:CheckBox ID="cbEstatusMantenimientoCondicion" runat="server" Text="Estatus" CssClass="form-check-input" ToolTip="Estatus de condición de reclamacion" />
                      </div>
                  </div>
                  <br />
                   <div align="center">
                       <asp:Button ID="btnConsultarCOndicionresReclamacion" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Consultar" Visible="true" ToolTip="Consultar Registros" OnClick="btnConsultarCOndicionresReclamacion_Click" />
                       <asp:Button ID="btnGuardarCondicionReclamos" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Guardar" Visible="true" ToolTip="Guardar Registro" OnClick="btnGuardarCondicionReclamos_Click" />
                       <asp:Button ID="btnModificarCondicionReclamos" runat="server" CssClass="btn btn-outline-primary btn-sm" Visible="false" Text="Modificar" ToolTip="Modificar Registro Seleccionado" OnClick="btnModificarCondicionReclamos_Click" />
                       <asp:Button ID="btnRestabelcerCondicionReclamos" runat="server" CssClass="btn btn-outline-primary btn-sm" Visible="false" Text="Restablecer" ToolTip="Restablecer Pantalla" OnClick="btnRestabelcerCondicionReclamos_Click" />
                     </div>
                  <br />
                   <!--GRID-->
         <div>
            <asp:GridView ID="gvListadoCondicionesReclamaciones" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoCondicionesReclamaciones_PageIndexChanging" OnSelectedIndexChanged="gvListadoCondicionesReclamaciones_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:BoundField DataField="IdCondicion" HeaderText="ID" />
                    <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                     <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
                </Columns  >
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

        <!--GRID-->
                  <br />
              </ContentTemplate>
          </asp:UpdatePanel>
      </div>
    </div>
  </div>
</div>
        <!--FIN DE POPO CONDICIONES-->


<!--POPO TIPO DE RECLAMO-->
                <div class="modal fade POPOTIPORECLAMO" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
       <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbMantenimeintoTipoReclamoTitulo" runat="server" Text="Mantenimiento de Tipo de reclamos"></asp:Label>
              <asp:Label ID="lbIdMantenimientoTipoReclamo" runat="server" Text="0" Visible="false"></asp:Label>
              <asp:Label ID="lbAccionTipoReclamo" runat="server" Text="INSERT" Visible="false"></asp:Label>
          </div>
          <asp:UpdatePanel ID="UpdatePanelTipoReclamos" runat="server">
              <ContentTemplate>
                  <div class="form-row">
                      <div class="form-group col-md-4">
                          <asp:Label ID="lbMantenimientoTipoReclamo" runat="server" Text="Tipo de Reclamo" CssClass="LetrasNegritas"></asp:Label>
                          <asp:TextBox ID="txtMantenimientoTipoReclamo" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                      </div>

                    

                  </div>
                  <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:CheckBox ID="cbEstatusTipoRecmalo" runat="server" AutoPostBack="true" Text="Estatus" CssClass="form-check-input" ToolTip="Estatus de Tipo de reclamación" OnCheckedChanged="cbEstatusTipoRecmalo_CheckedChanged" />
                      </div>
                  </div>
                  <br />
                   <div align="center">
                       <asp:Button ID="btnConsultarTipoReclamo" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Consultar" Visible="true" ToolTip="Consultar Registros" OnClick="btnConsultarTipoReclamo_Click" />
                       <asp:Button ID="btnGuardarTipoReclamo" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Guardar" Visible="true" ToolTip="Guardar Registro" OnClick="btnGuardarTipoReclamo_Click" />
                       <asp:Button ID="btnModificarTipoReclamo" runat="server" CssClass="btn btn-outline-primary btn-sm" Visible="false" Text="Modificar" ToolTip="Modificar Registro Seleccionado" OnClick="btnModificarTipoReclamo_Click" />
                       <asp:Button ID="btnRestablecerTipoReclamo" runat="server" CssClass="btn btn-outline-primary btn-sm" Visible="false" Text="Restablecer" ToolTip="Restablecer Pantalla" OnClick="btnRestablecerTipoReclamo_Click" />
                     </div>
                  <br />
                   <!--GRID-->
         <div>
            <asp:GridView ID="gvListadoTipoReclamo" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoTipoReclamo_PageIndexChanging" OnSelectedIndexChanged="gvListadoTipoReclamo_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:BoundField DataField="IdTipoReclamacion" HeaderText="ID" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                     <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
                </Columns  >
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

        <!--GRID-->
                  <br />
              </ContentTemplate>
          </asp:UpdatePanel>
      </div>
    </div>
  </div>
</div>
        <!--FIN DE POPO TIPO DE RECLAMO-->


        <!--POPO ESTATUS RECLAMOS-->
         <div class="modal fade POPOESTATUSRECLAMO" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
       <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbTituloEstatusMantenimiento" runat="server" Text="Mantenimiento de Estatus de reclamos"></asp:Label>
              <asp:Label ID="lbIdMantenimientoEstatusReclamo" runat="server" Text="0" Visible="false"></asp:Label>
          </div>
          <asp:UpdatePanel ID="UpdatePanelEstatusReclamo" runat="server">
              <ContentTemplate>
                  <div class="form-row">
                      <div class="form-group col-md-4">
                          <asp:Label ID="lbMantenimientoEstatusReclamo" runat="server" Text="Estatus de Reclamo" CssClass="LetrasNegritas"></asp:Label>
                          <asp:TextBox ID="txtMantenimientoEstatusReclamo" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                      </div>

                    

                  </div>
                  <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:CheckBox ID="cbMantenimientoEstatusReclamo" runat="server" AutoPostBack="true" Text="Estatus" CssClass="form-check-input" ToolTip="Estatus de Estatus de reclamación" OnCheckedChanged="cbEstatusTipoRecmalo_CheckedChanged" />
                      </div>
                  </div>
                  <br />
                   <div align="center">
                       <asp:Button ID="btnConsultarEstatusReclamo" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Consultar" Visible="true" ToolTip="Consultar Registros" OnClick="btnConsultarEstatusReclamo_Click" />
                       <asp:Button ID="btnGuardarEstatusReclamo" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Guardar" Visible="true" ToolTip="Guardar Registro" OnClick="btnGuardarEstatusReclamo_Click" />
                       <asp:Button ID="btnModificarEstatusReclamo" runat="server" CssClass="btn btn-outline-primary btn-sm" Visible="false" Text="Modificar" ToolTip="Modificar Registro Seleccionado" OnClick="btnModificarEstatusReclamo_Click" />
                       <asp:Button ID="btnRestablecerEstatusReclamo" runat="server" CssClass="btn btn-outline-primary btn-sm" Visible="false" Text="Restablecer" ToolTip="Restablecer Pantalla" OnClick="btnRestablecerEstatusReclamo_Click" />
                     </div>
                  <br />
                   <!--GRID-->
         <div>
            <asp:GridView ID="gvListadoEstatusReclamo" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoEstatusReclamo_PageIndexChanging" OnSelectedIndexChanged="gvListadoEstatusReclamo_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:BoundField DataField="IdEstatusReclamacion" HeaderText="ID" />
                    <asp:BoundField DataField="DescripcionEstatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                     <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
                </Columns  >
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

        <!--GRID-->
                  <br />
              </ContentTemplate>
          </asp:UpdatePanel>
      </div>
    </div>
  </div>
</div>
        <!--FIN DE ESTATUS ECLAMOS-->
    </div>
</asp:Content>

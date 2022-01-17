<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ListadoRenovacion.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ListadoRenovacion" %>
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

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        
        .BotonEspecial {
           width:100%;
           font-weight:bold;
          }

        th {
            background-color: #1E90FF;
            color: #000000;
        }

        .BotonSolicitud {
               width:50px;
               height:50px;
           }
        .BotonImagen {
               width:40px;
               height:40px;
           }
               .auto-style1 {
                   width: 199px;
               }
    </style>
    <script type="text/javascript">
        function ErrorConsulta() {
            alert("Error al realizar la consulta, favor de verificar el rango de fecha");
        }

        function OpcionEnDesarrollo() {
            alert("Esta Opción esta en desarrollo por el momento");
        }
              function CamposVaciosEstadistica(){
                  alert("Has dejado campos vacios que son necesarios para realizar esta operación, favor de verificar");
                  return false;
        }
        function CamposFechaVacios() {
            alert("Los campos fecha son necesarios para realizar este proceso, favor de verificar.");
        }
              function FechaDesdeVacio() {
                  $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
         }
              function FechaHastaVacio() {
                  $("#<%=txtFechaHAsta.ClientID%>").css("border-color", "red");
        }

        function CamposFechaReporteVacios() {
            alert("Los campos fecha son necesarios para generar este reporte o marcar el check para no utilizar fecha.");
        }

        function FechaDesdeReporteVacio() {
            $("#<%=txtFechaDesdeReporte.ClientID%>").css("border-color", "red");
        }

        function FechaHastaReportevacio() {
            $("#<%=txtFechaHastaReporte.ClientID%>").css("border-color", "red");
        }


        function RegistrosPolizasARenovar() {
            alert("Registros de Polizas a Renovar cargados y actualizados correctamente");
        }
        function RegistrsPolizasRenovadas() {
            alert("Registros de Polizas Renovadas Cargadas y Actualizadas correctamente");
        }
        function RegistrosEliminados() {
            alert("Registros de polizas a Renovar y Renovadas Eliminadas corerctamente");
        }

        function CambioEstatus() {
            alert("No es posible camiar el estatus de este registro por que ya fue procesado.");
        }
        function EliminarRegistro() {
            alert("No es polible eliminar este registro por que ya fue procesado.");
        }
        function ErrorProcesarComentrio() {
            alert("Error al guardar el comentario, favor verificar los datos ingresados.");
        }
    </script>


       <div id="DivBloquePrincipal" runat="server" class="container-fluid">
       <br /><br />
        <asp:Label ID="lbCotizacionPoliza" runat="server" Text="Cotizacion" Visible="false" ></asp:Label>

          <div align="center">
               <asp:ImageButton ID="btnActualizarEstadistica" runat="server" CssClass="BotonSolicitud" OnClick="btnActualizarEstadistica_Click" ToolTip="Actualizar" ImageUrl="~/Imagenes/auto.png" />
              <asp:ImageButton ID="btnReportePolizasGestionCobros" runat="server" CssClass="BotonImagen" OnClick="btnReportePolizasGestionCobros_Click" ToolTip="Exportar Información" ImageUrl="~/Imagenes/pdf.png" />
              <br />
           <asp:Label ID="lbCantidadPolizasPendientesGestionTitulo" runat="server" Text="Cantidad de Polizas Pendientes (" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadPolizasPendientesVariable" runat="server" Text="0" ForeColor="Red" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadPolizasPendientesCerrar" runat="server" Text=")" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbSeparadorGestion" runat="server" Text=" | " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasProcesadasGestionTitulo" runat="server" Text="Cantidad de Polizas Procesadas (" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadPolizasProcesadasVariableGestion" runat="server" Text="0" ForeColor="ForestGreen" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadPolizasProcesadasGestionCerrar" runat="server" Text=")" CssClass="Letranegrita"></asp:Label>
          
          </div>

           <asp:ScriptManager ID="ScripManagerGestionCobros" runat="server"></asp:ScriptManager> 
<button class="btn btn-outline-primary btn-sm BotonEspecial" type="button" id="btnPolizasNoContastadas" data-toggle="collapse" data-target="#PolizasNoContactadas" aria-expanded="false" aria-controls="collapseExample">
                  
                  <asp:Label ID="lbPolizasNoContactadas" runat="server" Text="  POLIZAS NO CONTACTADAS" CssClass="Letranegrita"></asp:Label>
                     </button><br />


       <div class="collapse" id="PolizasNoContactadas">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelPolizasNoContactadas" runat="server">
                       <ContentTemplate>
                               <div class="form-check-inline">
                                   <asp:RadioButton ID="rbRegistrosPendientesGestionCobros" runat="server" Text="Pendientes" ToolTip="Mostrar Todos los Registros Pendientes" CssClass="form-check-input Letranegrita" GroupName="RadiosGestionCobros" />
                                   <asp:RadioButton ID="rbRegistrosProcesadosGestionCobros" runat="server" Text="Procesados" ToolTip="Mostrar Todos los Registros Procesados" CssClass="form-check-input Letranegrita" GroupName="RadiosGestionCobros" />
                                   <asp:RadioButton ID="rbTodosLosRegistrosGestionCobros" runat="server" Text="Todos" ToolTip="Mostrar Todos los Registros (Penientes y Procesados)" CssClass="form-check-input Letranegrita" GroupName="RadiosGestionCobros" />

                               </div>
    <br />
                           <div class="row">
                               <div class="d-inline-flex col-md-4 ">
                                   <asp:Label ID="lbPolizaCOnsultaGesionCobro" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                                   <asp:TextBox ID="txtPolizaConsultaGestionCobro" runat="server" Height="40px" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                   <asp:ImageButton ID="btnBuscarPolizaGestionCobrosNuevo" runat="server" CssClass="BotonImagen mb-3" OnClick="btnBuscarPolizaGestionCobrosNuevo_Click" ToolTip="Buscar Información" ImageUrl="~/Imagenes/Buscar.png" />
                                   
                               </div>
                           </div>
           <br />

                               <table class="table table-striped">
                                   <thead>
                                       <tr>

                                           <th scope="col"> Poliza </th>
                                           <th scope="col"> Estatus </th>
                                           <th scope="col"> Concepto </th>
                                           <th scope="col" class="auto-style1"> Comentario </th>
                                           <th scope="col"> Vigencia </th>
                                           <th scope="col"> Nueva LLamada </th>
                                           <th scope="col"> Completar </th>
                                           <th scope="col"> Borrar </th>
                                       </tr>
                                   </thead>
                                   <tbody>
                                       <asp:Repeater ID="rpPolizasNoContactadas" runat="server">
                                           <ItemTemplate>
                                               <tr>
                                                   <asp:HiddenField ID="hfNumeroRegistroGestion" runat="server" Value='<%# Eval("NumeroRegistro") %>' />
                                                   <asp:HiddenField ID="hfPolizaGestion" runat="server" Value='<%# Eval("Poliza") %>' />
                                                   <asp:HiddenField ID="hfEstatusGEstion" runat="server" Value='<%# Eval("Estatus") %>' />

                                                 <%--  <td style="width:10%" align="left"> <asp:Button ID="btnGestionarPolizasNoContactadas" runat="server" Text="Gestión" CssClass="btn btn-outline-primary btn-sm" ToolTip="Gestionar polizas no contactadas en la gestion de cobros" OnClick="btnGestionarPolizasNoContactadas_Click" /> </td>--%>                                               
                                                   <td> <%# Eval("Poliza") %> </td>
                                                   <td> <%# Eval("Estatus") %> </td>
                                                   <td> <%# Eval("ConceptoLlamada") %> </td>
                                                   <td> <%# Eval("Comentario") %> </td>
                                                   <td> <%# Eval("FinVigencia") %> </td>
                                                   <td> <%# Eval("NuevaLLamada") %> </td>
                                                   <td> <asp:ImageButton ID="btnGestionarPolizasNoContactadasNuevo" runat="server" CssClass="BotonImagen" OnClick="btnGestionarPolizasNoContactadasNuevo_Click" ToolTip="Cambiar estatus de polizas no contactadas en la gestion de cobros" ImageUrl="~/Imagenes/Completar.png" /> </td>
                                                   <td> <asp:ImageButton ID="btnEliminarRegistrosPolizasGestionadas" runat="server" CssClass="BotonImagen" OnClick="btnEliminarRegistrosPolizasGestionadas_Click" ToolTip="Borrar Registro." ImageUrl="~/Imagenes/Eliminar.png" /> </td>
                                               </tr>
                                           </ItemTemplate>
                                       </asp:Repeater>
                                   </tbody>
                               </table>
              

                            <div align="center">
                <asp:Label ID="lbPaginaActualTituloPolizasNoContactadas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariablePolizasNoContactadas" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloPolizasNoContactadas" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriablePolizasNoContactadas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionPolizasNoContactadas" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaPolizasNoContactadas" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaPolizasNoContactadas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorPolizasNoContactadas" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorPolizasNoContactadas_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionPolizasNoContactadas" runat="server" OnItemCommand="dtPaginacionPolizasNoContactadas_ItemCommand" OnItemDataBound="dtPaginacionPolizasNoContactadas_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralPolizasNoContactadas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguientePolizasNoContactadas" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguientePolizasNoContactadas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoPolizasNoContactadas" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoPolizasNoContactadas_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
              
        
            </ContentTemplate>
                   </asp:UpdatePanel>
                </div>
            </div>
           <br />
        <!--AGREGAMOS LOS FILTROS-->

               <div class="form-check-inline">
                   <asp:CheckBox ID="cbProcesarRegistros" runat="server" Text="Procesar Registros" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="cbProcesarRegistros_CheckedChanged" ToolTip="Procesar Registros de las renovaciones" />
                   <asp:CheckBox ID="cbGenerarReporteGestionCobros" runat="server" Text="Reporte de Gestión de Cobros" ToolTip="Generar Reporte de los comentarios de la gestion de cobro" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="cbGenerarReporteGestionCobros_CheckedChanged" />
               </div>

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="col-md-2">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHAsta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="col-md-4">
                        <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarRamo" AutoPostBack="true" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarRamo_SelectedIndexChanged"></asp:DropDownList>
            </div>

              <div class="col-md-4">
                   <asp:Label ID="lbSeleccionarSubRamo" runat="server" Text="SubRamo" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarSubRamo" runat="server" ToolTip="Seleccionar SubRamo" CssClass="form-control"></asp:DropDownList>
            </div>

              <div class="col-md-3">
                   <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

              <div class="col-md-3">
                       <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="col-md-3">
                        <asp:Label ID="lbCodSupervisor" runat="server" Text="Cod Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" TextMode="Number" runat="server" MaxLength="5" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="col-md-3">
                  <asp:Label ID="lbCodIntermediario" runat="server" Text="Cod Intermediario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFCodIntermediario" TextMode="Number" runat="server" MaxLength="5" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="col-md-3">
                  <asp:Label ID="lbValidarBalance" runat="server" Text="Validar Balance" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlValidarBalance" runat="server" ToolTip="Validar Balance" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="col-md-3">
                  <asp:Label ID="lbExcluirMotores" runat="server" Visible="false" Text="Excluir Motores" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlExcluirMotorew" runat="server" Visible="false" ToolTip="Excluir Motores" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="col-md-3" id="DivMes" runat="server" visible="false">
                  <asp:Label ID="lbSeleccionarMes" runat="server" Text="Mes" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarMes" runat="server" ToolTip="Seleccionar Mes" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3" id="DivAno" runat="server" visible="false">
                  <asp:Label ID="lbSeleccionarAno" runat="server" Text="Año" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtAno" runat="server" CssClass="form-control" TextMode="Number" MaxLength="4" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <!--FINALIZAN LOS CONTROLES DE FILTROS-->

        <div id="DivBloqueConsultaNormal" runat="server">
            <!--INGRESMAOS LOS BOTONES-->
        <div align="center">
            <asp:ImageButton ID="btnConsultarNuevo" runat="server" CssClass="BotonImagen" OnClick="btnConsultarNuevo_Click" ToolTip="Buscar Información" ImageUrl="~/Imagenes/Buscar.png" />
            <asp:ImageButton ID="btnExportarNuevo" runat="server" CssClass="BotonImagen" OnClick="btnExportarNuevo_Click" ToolTip="Exportar" ImageUrl="~/Imagenes/excel.png" />
        </div>
        <!--FINALIZAMOS LOS BOTONES-->
        <br />
            <!--REPORTE DE GESTION DE COBROS-->
            <div id="DivReporteGestionCobros" runat="server" visible="false">
                <div class="form-check-inline">
             
                        <asp:CheckBox ID="cbNoAgregarRangoFechaReporte" runat="server" CssClass="form-check-input Letranegrita" ToolTip="No Agregar Rango de fecha para el repore" Text="No Agregar Rango de Fecha" />
             
                </div>

                    <div class="form-check-inline">
                        <asp:Label ID="lbTipoFormatoReporteGEstion" runat="server" Text="Formato de Reporte: " CssClass="Letranegrita"></asp:Label>
                        <asp:RadioButton ID="rbFormatoPDFGestion" runat="server" Text="PDF" ToolTip="Genear Reporte de Gestión de cobros en PDF" GroupName="ReporteGestion" CssClass="form-check-input" />
                        <asp:RadioButton ID="rbFormatoExcelGestion" runat="server" Text="EXCEL" ToolTip="Genear Reporte de Gestión de cobros en EXCEL" GroupName="ReporteGestion" CssClass="form-check-input" />
                        <asp:RadioButton ID="rbFormatoExcelPlanoGestion" runat="server" Text="EXCEL PLANO" ToolTip="Genear Reporte de Gestión de cobros en EXCEL sin formato" GroupName="ReporteGestion" CssClass="form-check-input" />
                    </div>
    
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lbPolizaReporte" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                        <asp:TextBox ID="txtPolizaReporte" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                     <div class="col-md-3">
                        <asp:Label ID="lbFechaDesdeReporte" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                        <asp:TextBox ID="txtFechaDesdeReporte" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lbFechaHastaReporte" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                        <asp:TextBox ID="txtFechaHastaReporte" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lbSeleccionarUsuarioReporte" runat="server" Text="Seleccionar Usuario" CssClass="Letranegrita"></asp:Label>
                        <asp:DropDownList ID="ddlSeleccionarUsuarioReporte" runat="server" ToolTip="Seleccionar usuario para filtrar en el reporte" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>

                <div align="center">
                    <asp:ImageButton ID="btnReporteGestionCobros" runat="server" ToolTip="Generar Reporte de comentarios de gestión de cobros" CssClass="BotonImagen" OnClick="btnReporteGestionCobros_Click" ImageUrl="~/Imagenes/Reporte.png" />
                </div>
                <br />
            </div>
        <!--INICIO DEL GRID-->
      
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Gestión </th>
                        <th scope="col"> Poliza </th>
                        <th scope="col"> Item </th>
                        <th scope="col"> Prima </th>
                        <th scope="col"> Facturado </th>
                        <th scope="col"> Cobrado </th>
                        <th scope="col"> Balance </th>
                        <th scope="col"> Fin Vigencia </th>
                        <th scope="col"> Comentarios </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoRenovacion" runat="server">
                        <ItemTemplate>
                            <tr>
                                 <asp:HiddenField ID="hfPolizaGestionCobros" runat="server" Value='<%# Eval("Poliza") %>' />
                   <%--     <asp:HiddenField ID="hfFechaFinVigenciaGestionCobros" runat="server" Value='<%# Eval("FechaFinVigencia") %>' />--%>

                                <td> <asp:ImageButton ID="btnGestionNuevo" runat="server" CssClass="BotonImagen" OnClick="btnGestionNuevo_Click" ToolTip="Gestion de Cobros" ImageUrl="~/Imagenes/Servicio al Cliente.png" /> </td>
                                <td> <%# Eval("Poliza") %> </td>
                                <td> <%#string.Format("{0:n0}", Eval("Secuencia")) %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Prima")) %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Facturado")) %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Cobrado")) %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Balance")) %> </td>
                                <td> <%# Eval("FinVigenciaFormateado") %> </td>
                                <td> <%# string.Format("{0:n0}", Eval("CantidadComentarios")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
       

        <div align="center">
                <asp:Label ID="lbPaginaActualTitulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavle" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTitulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacion" runat="server" align="center">
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
        <!--FIN DEL GRID-->
        </div>

        <div id="DivBloqueProcesarRegistros" runat="server" visible="false">
      
                   <div class="form-check-inline">
                       <asp:CheckBox ID="cbExclirMotoresMachado" runat="server" Text="Excluir Motores" CssClass="form-check-input Letranegrita" />
                   </div>
   
               <br />

                   <div class="form-check">
                       <asp:RadioButton ID="rbReportePDFMachado" runat="server" Text="PDF" CssClass="form-check-input Letranegrita" ToolTip="Generar Reporte en PDF" GroupName="ReporteMachado" />
                       <asp:RadioButton ID="rbReporteExcelMachado" runat="server" Text="Excel" CssClass="form-check-input Letranegrita" ToolTip="Generar Reporte en Excel" GroupName="ReporteMachado" />
                       <asp:RadioButton ID="rbReporteWordMachado" runat="server" Text="Word" CssClass="form-check-input Letranegrita" ToolTip="Generar Reporte en Word" GroupName="ReporteMachado" />
                   </div>
    
               <div align="center">
            <asp:Button ID="btnProcesar" runat="server" Text="A Renovar" ToolTip="Procesar los registros a Renovar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnProcesar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Renovadas" ToolTip="Actualizar Registros registros renovados" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnConsultarRegistrosProcesados" runat="server" Text="Consultar" ToolTip="Consultar Registros en Pantalla" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultarRegistrosProcesados_Click" />
            <asp:Button ID="btnReporteRegistrosProcesados" runat="server" Text="Reporte" ToolTip="Generar Reporte Machado" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnReporteRegistrosProcesados_Click" />
            <asp:Button ID="btnEliminarRegistrosMAchados" runat="server" Text="Eliminar" ToolTip="Eliminar los registros machados entre las polizas a renovar y renovadas" CssClass="btn btn-outline-danger btn-sm Custom" OnClick="btnEliminarRegistrosMAchados_Click" />
        </div>
               <br />
         
                   <table class="table table-striped">
                       <thead>
                           <tr>
                               <th scope="col"> Supervisor </th>
                               <th scope="col"> Renovar </th>
                               <th scope="col"> Monto </th>
                               <th scope="col"> Renovadas </th>
                               <th scope="col"> Monto R </th>
                               <th scope="col"> Cobrado </th>
                               <th scope="col"> % </th>
                           </tr>
                       </thead>

                       <tbody>
                           <asp:Repeater ID="rpListadoRenovacionMachado" runat="server">
                               <ItemTemplate>
                                   <tr>
                               <td> <%# Eval("Supervisor") %> </td>
                               <td> <%#string.Format("{0:n0}", Eval("CantidadRenovar")) %>  </td>
                               <td> <%#string.Format("{0:n2}", Eval("MontoRenovar")) %>  </td>
                               <td> <%#string.Format("{0:n0}", Eval("CantidadRenovada")) %>  </td>
                               <td> <%#string.Format("{0:n2}", Eval("MontoRenovado")) %>  </td>
                               <td> <%#string.Format("{0:n2}", Eval("Cobrado")) %>  </td>
                               <td> <%# Eval("Porcentaje") %>  </td>
                           </tr>
                               </ItemTemplate>
                           </asp:Repeater>
                       </tbody>
                   </table>
      
               <div align="center">
                <asp:Label ID="lbPaginaActualTituloMachado" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleMachado" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloMachado" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableMachado" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
               <div id="divPaginacionProceso" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroProceso" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroProceso_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorProceso" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorProceso_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionProceso" runat="server" OnItemCommand="dtPaginacionProceso_ItemCommand" OnItemDataBound="dtPaginacionProceso_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralProceso" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteProceso" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteProceso_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoProceso" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoProceso_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
               <br />

           </div>
    </div>

    <div id="DivGestionCobros" visible="false" runat="server">
        <asp:Label ID="lbPolizaSeleccionada" runat="server" Text="Poliza" Visible="false"></asp:Label>
        <asp:Label ID="lbFinVigenciaSeleccionada" runat="server" Text="FinVigencia" Visible="false"></asp:Label>

        <div class="container-fluid">
            <br />
            
              <button class="btn btn-outline-primary btn-sm BotonEspecial" type="button" id="btnInformacionCobertura" data-toggle="collapse" data-target="#InformacionCliente" aria-expanded="false" aria-controls="collapseExample">
                  
                  <asp:Label ID="lbDetalleGeneralesPolizaSeleccionada" runat="server" Text="  DETALLES GENERALES DE LA POLIZA SELECCIONADA" CssClass="Letranegrita"></asp:Label>
                     </button><br />


       <div class="collapse" id="InformacionCliente">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelCliente" runat="server">
                       <ContentTemplate>
                           <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lbPolizaGestionCobro" runat="server"  Text="Poliza" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtPolizaGestionCObros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbEstatusGestionCobros" runat="server"  Text="Estatus" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtEstatusGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbRamoGestionCobros" runat="server"  Text="Ramo" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtRamoGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--SEGUNDA LINEA-->
                <div class="col-md-4">
                    <asp:Label ID="lbClienteGestionCobros" runat="server" Text="Cliente" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtClienteGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbTelefonosGestionCObros" runat="server" Text="Telefonos" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTelefonosGestonCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbDireccionGestionCobros" runat="server" Text="Dirección" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtDireccionGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--TERCERA FILA-->

                 <div class="col-md-4">
                    <asp:Label ID="lbSupervisorGestionCobros" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtSupervisorGEstionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbIntermediarioGEstionCobros" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtIntermediarioGestionCobro" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbLicenciaGestionCobros" runat="server" Text="Licencia" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtLicencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--CUARTA FILA-->
                 <div class="col-md-4">
                    <asp:Label ID="lbFechaCreadaGestionCobros" runat="server" Text="Fecha Creada" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaCreadaGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbInicioVigenciaGestionCObros" runat="server" Text="Inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtInicioVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbFInVigenciaGestionCobros" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFInVigenciaGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--QUINTA FILA-->
                 <div class="col-md-4">
                    <asp:Label ID="lbTotalFActuradoGestionCobros" runat="server" Text="Total Facturado" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalFacturado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbTotalCobradoGestionCobros" runat="server" Text="Total Cobrado" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalCobradoGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbBalanceGestionCobros" runat="server" Text="Balance" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtBalanceGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--SEXTA FILA-->
                 <div class="col-md-4">
                    <asp:Label ID="lbTotalFacturasGestionCobros" runat="server" Text="Facturas" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalFacturasGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbTotalRecibos" runat="server" Text="Recibos" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalRecibosGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbTotalReclamaciones" runat="server" Text="Reclamaciones" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalReclamacionesGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

              
            </div>

                           <div id="DivDatoVehiculo" runat="server">
               
                                   <table class="table table-striped">
                                       <thead>
                                           <tr>
                                               <th scope="col"> Item </th>
                                               <th scope="col"> Tipo </th>
                                               <th scope="col"> Marca </th>
                                               <th scope="col"> Modelo </th>
                                               <th scope="col"> Color </th>
                                               <th scope="col"> Año </th>
                                               <th scope="col"> Placa </th>
                                               <th scope="col"> Chasis </th>
                                           </tr>
                                       </thead>

                                       <tbody>
                                           <asp:Repeater ID="rpDatosVehiculo" runat="server">
                                               <ItemTemplate>
                                                   <tr>
                                                       <td> <%# Eval("Item") %> </td>
                                                       <td> <%# Eval("Tipo") %> </td>
                                                       <td> <%# Eval("Marca") %> </td>
                                                       <td> <%# Eval("Modelo") %> </td>
                                                       <td> <%# Eval("Color") %> </td>
                                                       <td> <%# Eval("Ano") %> </td>
                                                       <td> <%# Eval("Placa") %> </td>
                                                       <td> <%# Eval("Chasis") %> </td>
                                                   </tr>
                                               </ItemTemplate>
                                           </asp:Repeater>
                                       </tbody>

                                   </table>
                          
                                <div align="center">
                <asp:Label ID="lbPaginaActualTituloDatoVehiculo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableDatoVehiculo" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloDatoVehiculo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableDatoVehiculo" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
               <div id="divPaginacionDatoVehiculo" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroDatoVehiculo" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroDatoVehiculo_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorDatoVehiculo" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorDatoVehiculo_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionDatoVehiculo" runat="server" OnItemCommand="dtPaginacionDatoVehiculo_ItemCommand" OnItemDataBound="dtPaginacionDatoVehiculo_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralDatoVehiculo" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteDatoVehiculo" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteDatoVehiculo_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoDatoVehiculo" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoDatoVehiculo_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
               <br />
                           </div>
            </ContentTemplate>
                   </asp:UpdatePanel>
                </div>
            </div>


       <br />

            <div class="row">
                  <!--SEPTIMA FILA-->
                <div class="col-md-4">
                    <asp:Label ID="lbEstatusDeLlamada" runat="server" Text="Concepto de Llamada" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarEstatusLLamadaGestionCobros" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarEstatusLLamadaGestionCobros_SelectedIndexChanged" CssClass="form-control" ToolTip="Seleccionar el Estatus de llamada"></asp:DropDownList>
                </div>

                 <div class="col-md-8">
                    <asp:Label ID="lbConceptoEstatusLlamada" runat="server" Text="Concepto" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarConceptoGestionCobros" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarConceptoGestionCobros_SelectedIndexChanged" ToolTip="Seleccionar el Estatus de llamada"></asp:DropDownList>
                </div>

                <div class="col-md-4" id="DivFechaLlamada" runat="server" visible="false" >
                    <asp:Label ID="lbFechaNuevallamada" runat="server" Text="Fecha de Nueva LLamada" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaNuevaLLamada" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-md-4" id="DIVHoraLLamada" runat="server" visible="false">
                    <asp:Label ID="lbHoranUevaLLamada" runat="server" Text="Hora de Nueva LLamada" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtHoraNuevaLLamada" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-12">
                    <asp:Label ID="lbComentarioGestionCobros" runat="server" Text="Comentario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtComentarioGestionCobros" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="MultiLine" Height="60px"></asp:TextBox>
                </div>
             
            </div>
               <br />
        </div>

        <br />
        <div align="center">
            <asp:ImageButton ID="btnGuardarNuevo" runat="server" CssClass="BotonImagen" OnClick="btnGuardarNuevo_Click" ToolTip="Guardar Registro" ImageUrl="~/Imagenes/salvar.png" />
            <asp:ImageButton ID="btnVolverNuevo" runat="server" CssClass="BotonImagen" OnClick="btnVolverNuevo_Click" ToolTip="Volver Atras" ImageUrl="~/Imagenes/volver-flecha.png" />
            <br /><br />
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=")" CssClass="Letranegrita"></asp:Label>
        </div>
       
        

            <table class="table table-striped">
                <thead>
                    <tr>
                    <th scope="col"> Esattus </th>
                    <th scope="col"> Concepto </th>
                    <th scope="col"> Comentario </th>
                    <th scope="col"> Vigencia </th>
                    <th scope="col"> Usuario </th>
                    <th scope="col"> Fecha </th>
                    <th scope="col"> Hora </th>
                   </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="rpGestionCobros" runat="server">
                        <ItemTemplate>
                            <tr>
                       

                        <td> <%# Eval("EstatusLlamada") %> </td>
                        <td> <%# Eval("ConceptoLlamada") %> </td>
                        <td> <%# Eval("Comentario") %> </td>
                        <td> <%# Eval("FechaFinVigencia") %> </td>
                        <td> <%# Eval("Usuario") %> </td>
                        <td> <%# Eval("Fecha") %> </td>
                        <td> <%# Eval("Hora") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
    
        <div align="center">
                <asp:Label ID="lbPaginaActualTituloGestionCobros" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableGestionCobros" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloGestionCobros" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableGestionCobros" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
               <div id="divPaginacionGestionCobros" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeroGestionCobros" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeroGestionCobros_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorGestionCobros" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorGestionCobros_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionGestionCobros" runat="server" OnItemCommand="dtPaginacionGestionCobros_ItemCommand" OnItemDataBound="dtPaginacionGestionCobros_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralGestionCobros" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteGestionCobros" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteGestionCobros_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoGestionCobros" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoGestionCobros_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
               <br />
    </div>


    <!--ESTADISTICA-->
    <div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbTituloEstatustica" runat="server" Text="Estadistica de Renovación"></asp:Label>
          </div>
          <%--<asp:ScriptManager ID="EstadisticaScripmanager" runat="server"></asp:ScriptManager>--%>
          <asp:UpdatePanel ID="EstadisticaUpdatePanel" runat="server">
              <ContentTemplate>
  
                      <div class="form-check-inline">
                          <asp:RadioButton ID="rbEstadisticaSupervisor" runat="server" Text="Por Supervisor" GroupName="Estadistica" CssClass="form-check-input LetrasNegrita" />
                      </div>
                      <div class="form-check-inline">
                          <asp:RadioButton ID="rbEstadisticaIntermediario" runat="server" Text="Por Intermediario" GroupName="Estadistica" CssClass="form-check-input LetrasNegrita" />
                      </div>
           
                  <div class="row">
                      <div class="col-md-4">
                          <asp:Label ID="lbFechaDesdeEstadistica" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                          <asp:TextBox ID="txtFechaDesdeEstadistica" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                      </div>

                      <div class="col-md-4">
                          <asp:Label ID="lbFechaHastaEstadistica" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                          <asp:TextBox ID="txtFechaHastaEstadistica" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                      </div>

                      <div class="col-md-4">
                          <asp:Label ID="lbSeleccionarRamoEstadistica" runat="server" Text="Seleccionar Ramo" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarRamoEstadistica" runat="server" OnSelectedIndexChanged="ddlSeleccionarRamoEstadistica_SelectedIndexChanged" AutoPostBack="true" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
                      </div>

                      

                       <div class="col-md-4">
                          <asp:Label ID="lbSeleccionarSubramoEstadistica" runat="server" Text="Seleccionar SubRamo" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarSubramoEstadistica" runat="server" ToolTip="Seleccionar SubRamo" CssClass="form-control"></asp:DropDownList>
                      </div>

                       <div class="col-md-4">
                          <asp:Label ID="lbSeleccionaroficinaEstadistica" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionaroficinaEstadistica" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                      </div>
                        <div class="col-md-4">
                          <asp:Label ID="lbValidarBalanceEstadistica" runat="server" Text="Validar Balance" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlValidarBalanceEstadistica" runat="server" ToolTip="Validar Balance" CssClass="form-control"></asp:DropDownList>
                      </div>
                        <div class="col-md-4">
                          <asp:Label ID="lbExcluirMotoresEstadistica" runat="server" Visible="false" Text="Excluir Motores" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlExcluirMotoresEstadistica" runat="server" Visible="false" ToolTip="Excluir Motores" CssClass="form-control"></asp:DropDownList>
                      </div>
                  </div>
                 
                   <div align="center">
                      <asp:Button ID="btnConsultarEstadistica" runat="server" Text="Buscar" ToolTip="Consultar Estadistica" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultarEstadistica_Click" />
              
                  </div>
          <br />
                  <!--INICIO DEL GRID-->
            
                      <table class="table table-striped">
                          <thead>
                              <tr>
                                  <th scope="col"> Persona  </th>
                                   <th scope="col"> Cantidad> </th>
                                   <th scope="col"> Monto </th>
                              </tr>
                          </thead>
                          <tbody>
                              <asp:Repeater ID="rpListadoEstadistica" runat="server">
                                  <ItemTemplate>
                                      <tr>
                                          <td> <%# Eval("Persona") %> </td>
                                          <td> <%#string.Format("{0:n0}", Eval("CantidadPoliza")) %> </td>
                                          <td> <%#string.Format("{0:n2}", Eval("Monto")) %> </td>
                                      </tr>
                                  </ItemTemplate>
                              </asp:Repeater>
                          </tbody>
                      </table>
              

                  <div align="center">
                <asp:Label ID="lbPaginaActualTituloEstadistica" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleEstadistica" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloEstadistica" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableEstadistica" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionEstadistica" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="linkPrimerostadistica" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="linkPrimerostadistica_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteirorEstadistica" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteirorEstadistica_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtEstadistica" runat="server" OnItemCommand="dtEstadistica_ItemCommand" OnItemDataBound="dtEstadistica_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralEstadistica" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteEstadistica" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteEstadistica_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoEstadistica" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoEstadistica_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                  <!--FIN DEL GRID-->
              </ContentTemplate>
          </asp:UpdatePanel>
          <br />
                <div align="center">
                     <asp:Button ID="btnExportarEstadistica" runat="server" Text="Exportar" ToolTip="Exportar Estadistica" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportarEstadistica_Click" />
                </div>
          <br />
      </div>
    </div>
  </div>
</div>
</asp:Content>

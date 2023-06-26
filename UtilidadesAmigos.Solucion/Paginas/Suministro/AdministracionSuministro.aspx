<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AdministracionSuministro.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Suministro.AdministracionSuministro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="../../Content/EstilosComunes.css" />


    <script type="text/javascript">
        var Mensaje = " no puede estar vacio para realziar esta operación, favor de verificar.";

        function CantidadMayor() {
            alert("La cantidad que intentas sacar de inventario supera la cantidad que tienes en almacen, favor de validar.");
        }
        function ProcesoCompletado() {
            alert("Proceso completado con exito.");
        }
        $(function () {

            $("#<%=btnGuardar.ClientID%>").click(function () {

                var Sucursal = $("#<%=ddlSucursalMantenimiento.ClientID%>").val();
                if (Sucursal < 1) {
                    alert("El campo sucursal" + Mensaje);
                    $("#<%=ddlSucursalMantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {

                    var Oficina = $("#<%=ddlOficinaMantenimiento.ClientID%>").val();
                    if (Oficina < 1) {
                        alert("El campo Oficina" + Mensaje);
                        $("#<%=ddlOficinaMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {

                        var Categoria = $("#<%=ddlCategoriaMantenimiento.ClientID%>").val();
                        if (Categoria < 1) {
                            alert("El campo Categoria" + Mensaje);
                            $("#<%=ddlCategoriaMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var UnidadMedida = $("#<%=ddlMedidaMantenimiento.ClientID%>").val();
                            if (UnidadMedida < 1) {
                                alert("El campo Unidad de Medida" + Mensaje);
                                $("#<%=ddlMedidaMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var Descripcion = $("#<%=txtDescripcionMantenimiento.ClientID%>").val().length;
                                if (Descripcion < 1) {
                                    alert("El campo Descripción" + Mensaje);
                                    $("#<%=txtDescripcionMantenimiento.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                                else {
                                    var Stock = $("#<%=txtStockMantenimiento.ClientID%>").val().length;
                                    if (Stock < 1) {
                                        alert("El campo Stock" + Mensaje);
                                        $("#<%=txtStockMantenimiento.ClientID%>").css("border-color", "red");
                                        return false;
                                    }
                                    else {
                                        var StockMinimo = $("#<%=txtStockMinimoMantenimiento.ClientID%>").val().length;
                                        if (StockMinimo < 1) {
                                            alert("El campo Stock Minimo" + Mensaje);
                                            $("#<%=txtStockMinimoMantenimiento.ClientID%>").css("border-color", "red");
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });


            $("#<%=btnGuardar_Suplir_Sacar.ClientID%>").click(function () {

                var Stock = $("#<%=txtStockNuevo_Suplir_Sacar.ClientID%>").val().length;
                if (Stock < 1) {
                    alert("El campo Stock Nuevo" + Mensaje);
                    $("#<%=txtStockNuevo_Suplir_Sacar.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

        })
        
    </script>

   
      <div class="container-fluid">
        <br />
        <div id="DivTipoOperacion" runat="server" class="form-check-inline">
            <asp:Label ID="lbTipoOperacion" runat="server" Text="Tipo de Operación: " CssClass="Letranegrita" ></asp:Label>
            <asp:RadioButton ID="rbSolicitudes" runat="server" Text="Solicitudes" AutoPostBack="true" OnCheckedChanged="rbSolicitudes_CheckedChanged" ToolTip="Mostrar las Solicitudes realziadas" GroupName="TipoOperacion" />
            <asp:RadioButton ID="rbAdministracionInventario" runat="server" Text="Inventario" AutoPostBack="true" OnCheckedChanged="rbAdministracionInventario_CheckedChanged" ToolTip="Administración de Inventario" GroupName="TipoOperacion" />
        </div>
          <hr />
     <div id="DIVBloqueSolicitudes" runat="server">
        <div id="DivSubBloqueHeader" runat="server">
             <br />
         <div class="form-check form-switch">
             <input type="checkbox" id="cbAgregarRangoFecha" runat="server" class="form-check-input" />
             <label class="form-check-label Letranegrita "> No Agregar Rango de Fecha</label>
         </div>
         <div class="row">
             <div class="col-md-3">
                 <asp:Label ID="lbNumeroSolicitudConsulta" runat="server" Text="No. Solicitud" CssClass="Letranegrita"></asp:Label>
                 <asp:TextBox ID="txtNumeroSolicitud" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
             </div>

              <div class="col-md-3">
                  <asp:Label ID="lbSucursalConsulta" runat="server" Text="Sucursal" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSucursalCOnsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Sucursal" AutoPostBack="true" OnSelectedIndexChanged="ddlSucursalCOnsulta_SelectedIndexChanged"></asp:DropDownList>
             </div>
              <div class="col-md-3">
                  <asp:Label ID="Label2" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlOficinaConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Oficina" AutoPostBack="true" OnSelectedIndexChanged="ddlOficinaConsulta_SelectedIndexChanged"></asp:DropDownList>
             </div>
              <div class="col-md-3">
                 <asp:Label ID="Label3" runat="server" Text="Departamento" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Departamento" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartamentoConsulta_SelectedIndexChanged"></asp:DropDownList>
             </div>

              <div class="col-md-3">
                  <asp:Label ID="Label4" runat="server" Text="Usuario" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlUsuarioConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Usuario"></asp:DropDownList>
             </div>
              <div class="col-md-3">
                   <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                 <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
             </div>
              <div class="col-md-3">
                   <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                 <asp:TextBox ID="txtFEcfaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
             </div>
              <div class="col-md-3">
                   <asp:Label ID="lbEstatusSolicitud" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlEstatusSolicitud" runat="server" CssClass="form-control" ToolTip="Estatus de Solicitud"></asp:DropDownList>
             </div>
         </div>
         <br />
         <div class="ContenidoCentro">
             <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultar_Click" />
             <asp:ImageButton ID="btnReporteSolicitudes" runat="server" ToolTip="Reporte de Solicitudes" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporteSolicitudes_Click" />
         </div>
         <br />
         <table class="table table-striped">
             <thead class="table-dark">
                 <tr>
                      <th scope="col"> Sucursal </th>
                      <th scope="col"> Oficina </th>
                      <th scope="col"> Departamento </th>
                      <th scope="col"> Nombre </th>
                      <th class="ContenidoCentro" scope="col"> Fecha </th>
                      <th class="ContenidoCentro" scope="col"> Items </th>
                      <th class="ContenidoCentro" scope="col"> Estatus </th>
                      <th class="ContenidoDerecha" scope="col"> Procesar </th>
                 </tr>
             </thead>
             <tbody>
                 <asp:Repeater ID="rpSolicitudesHeader" runat="server">
                     <ItemTemplate>
                         <tr>

                             <asp:HiddenField ID="hfNumeroSolicitudHeader" runat="server" Value='<%# Eval("NumeroSolicitud") %>' />
                             <asp:HiddenField ID="hfNumeroConectorHeader" runat="server" Value='<%# Eval("NumeroConector") %>' />

                             <td> <%# Eval("Sucursal") %> </td>
                             <td> <%# Eval("Oficina") %> </td>
                             <td> <%# Eval("Departamento") %> </td>
                             <td> <%# Eval("Persona") %> </td>
                             <td class="ContenidoCentro"> <%# Eval("Fecha") %> </td>
                             <td class="ContenidoCentro"> <%#string.Format("{0:N0}", Eval("CantidadItems")) %> </td>
                             <td class="ContenidoCentro"> <%# Eval("Estatus") %> </td>
                             <td class="ContenidoDerecha"> <asp:ImageButton ID="btnVer" runat="server" ToolTip="Ver Detalle del registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/proceso.png" OnClick="btnVer_Click" /> </td>
                         </tr>
                     </ItemTemplate>
                 </asp:Repeater>
             </tbody>
         </table>
           <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">
                            <b>Página </b> <asp:Label ID="lbCantidadPaginaVariable" runat="server" Text="0" ></asp:Label> <b>de </b>  <asp:Label ID="lbPaginaActualVariable" runat="server" Text=" 0 "></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                            <b>Total de Solicitudes: </b> <asp:Label ID="lbCantidadSolicitudes" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                            <b>Solicitudes Activas: </b> <asp:Label ID="lbSolicitudesActivas" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                             <b>Solicitudes Procesadas: </b> <asp:Label ID="lbSolicitudesProcesadas" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                             <b>Solicitudes Pendientes: </b> <asp:Label ID="lbSolicitudesPendientes" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="ContenidoIzquierda">
                             <b>Solicitudes Canceladas: </b> <asp:Label ID="lbSolicitudesCanceladas" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="ContenidoIzquierda">
                             <b>Solicitudes Rechazadas: </b> <asp:Label ID="lbSolicitudesRechazadas" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                </tfoot>
            </table>
              <div id="DivPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_SolicitudesHeader" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_SolicitudesHeader_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_SolicitudesHeader" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_SolicitudesHeader_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />  </td>
                    <td class="ContenidoCentro">
                        <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_SolicitudesHeader" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_SolicitudesHeader" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_SolicitudesHeader_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_SolicitudesHeader" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_SolicitudesHeader_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>


           <div id="DIvBloqueDetalleRegistro"  runat="server">
               <br />
               <asp:Label ID="lbNumeroConector_Detalle_Variable" runat="server" Visible="false" Text="Dato"></asp:Label>
                 <asp:Label ID="lbIdUsuario_Detalle_variable" runat="server" Visible="false" Text="Dato"></asp:Label>
                           <table class="table table-striped">
                               <thead class="table-secondary">
                                   <tr>
                                       <th scope="col"> <b>NUMERO DE SOLICITUD</b> </th>
                                       <th scope="col"> <asp:Label ID="lbNumeroSolicitud_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>

                                      <tr>
                                       <th scope="col"> <b>FECHA</b> </th>
                                       <th scope="col"> <asp:Label ID="lbFecha_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>

                                      <tr>
                                       <th scope="col"> <b>HORA</b> </th>
                                       <th scope="col"> <asp:Label ID="lbHora_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>

                                      <tr>
                                       <th scope="col"> <b>SUCURSAL</b> </th>
                                       <th scope="col"> <asp:Label ID="lbSucursal_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>

                                      <tr>
                                       <th scope="col"> <b>OFICINA</b> </th>
                                       <th scope="col"> <asp:Label ID="lbOficina_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>

                                      <tr>
                                       <th scope="col"> <b>DEPARTAMENTO</b> </th>
                                       <th scope="col"> <asp:Label ID="lbDepartamento_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>

                                      <tr>
                                       <th scope="col"> <b>USUARIO</b> </th>
                                       <th scope="col"> <asp:Label ID="lbUsuario_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>

                                      <tr>
                                       <th scope="col"> <b>CANTIDAD DE ARTICULOS</b> </th>
                                       <th scope="col"> <asp:Label ID="lbArticulos_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>

                                      <tr>
                                       <th scope="col"> <b>ESTATUS ACTUAL</b> </th>
                                       <th scope="col"> <asp:Label ID="lbEstatus_Detalle_Variable" runat="server" Text="Dato"></asp:Label> </th>
                                   </tr>
                               </thead>
                           </table>
              <asp:ScriptManager ID="ScripManagerGestionCobros" runat="server"></asp:ScriptManager> 
             <button class=" btn-sm  btn-dark BotonEspecial" type="button" id="btnPolizasNoContastadas" data-toggle="collapse" data-target="#RegistroSeleccionado" aria-expanded="false" aria-controls="collapseExample">
                  
                  <asp:Label ID="lbRegistroSeleccionado" runat="server" Text="DETALLE DE LOS ARTICULOS SOLICITADOS" CssClass="Letranegrita"></asp:Label>
                     </button><br />


       <div class="collapse" id="RegistroSeleccionado">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelRegistroSeleccionado" runat="server">
                       <ContentTemplate>
                           
                           <br />
                       <table class="table table-striped">
                           <thead class="table-dark">
                               <tr>
                                   <th scope="col"> Articulo </th>
                                   <th scope="col"> Categoria </th>
                                   <th scope="col"> Medida </th>
                                   <th class="ContenidoCentro" scope="col"> Cant. Solicitada </th>
                                   <th class="ContenidoCentro" scope="col"> Cant. Disponible </th>
                                   <th class="ContenidoCentro" scope="col"> Estatus </th>
                                   <th class="ContenidoCentro" scope="col"> Despachada </th>
                               </tr>
                           </thead>
                           <tbody>
                               <asp:Repeater ID="rpSolicitudDetalle" runat="server">
                                   <ItemTemplate>
                                       <tr>
                                            <td> <%# Eval("Descripcion") %> </td>
                                            <td> <%# Eval("Categoria") %> </td>
                                            <td> <%# Eval("UnidadMedida") %> </td>
                                            <td class="ContenidoCentro"> <%#string.Format("{0:N0}", Eval("Cantidad")) %> </td>
                                            <td class="ContenidoCentro"> <%#string.Format("{0:N0}", Eval("Disponible")) %> </td>
                                            <td class="ContenidoCentro"> <%# Eval("Estatus") %> </td>
                                            <td class="ContenidoCentro"> <%# Eval("Despachado") %> </td>
                                       </tr>
                                   </ItemTemplate>
                               </asp:Repeater>
                           </tbody>
                       </table>
                          
                           
                           <br />
                    </ContentTemplate>
                   </asp:UpdatePanel>
                </div>
            </div>
           <br />
               <div class="row">
                   <div class="col-md-12">
                       <asp:Label ID="lbComentarioSolicitud" runat="server" Text="Comentario" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtComentarioSolicitud" runat="server" Placeholder="Este campo es Opcional" CssClass="form-control" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
                   </div>
               </div>
               <br />
               <div class="form-check form-switch">
                   <input type="checkbox" id="cbNotificarViaCorreo" runat="server" class="form-check-input" />
                   <label class="form-check-label">Notificar Estatus final al usuario via correo.</label>
               </div>
               <br />
                           <div id="DivBloqueBotones" class="ContenidoCentro">
                               <asp:ImageButton ID="btnProcesar" runat="server" ToolTip="Procesar Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Completado.png" OnClick="btnProcesar_Click" />
                               <asp:ImageButton ID="btnCancelarSolicitud" runat="server" ToolTip="Cancelar Solicitud" CssClass="BotonImagen " ImageUrl="~/ImagenesBotones/Cancelar_Nuevo.png" OnClick="btnCancelarSolicitud_Click" OnClientClick="return confirm('¿Quieres Cancelar Esta Solicitud?');" />
                               <asp:ImageButton ID="btnRechazarSolicitud" runat="server" ToolTip="Rechazar Soicitud" CssClass="BotonImagen " ImageUrl="~/ImagenesBotones/rechazado.png" OnClick="btnRechazarSolicitud_Click" OnClientClick="return confirm('¿Quieres Rechazar Esta Solicitud?');" />
                                <asp:ImageButton ID="btnVolverAtrasSolicitud" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen " ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverAtrasSolicitud_Click" />
                           </div>
                 <br />
        </div>



     </div>




     <div id="DIVBloqueAdministracionInventario" runat="server">
         <div id="DivSubBloqueInventarioConsulta" runat="server">
             <br />
             <div class="row">
                 <div class="col-md-3">
                     <asp:Label ID="lbSucursalInventarioConsulta" runat="server" Text="Sucursal" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlSucursalInventarioConsulta" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSucursalInventarioConsulta_SelectedIndexChanged"></asp:DropDownList>
                 </div>
                 <div class="col-md-3">
                        <asp:Label ID="lboficinaInventarioConsulta" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlOficinaInventarioConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                 </div>
                 <div class="col-md-3">
                        <asp:Label ID="lbCategoriaInventarioConsulta" runat="server" Text="Categoria" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlCategoriaInventarioConsulta" runat="server" ToolTip="Seleccionar Categoria" CssClass="form-control"></asp:DropDownList>
                 </div>
                 <div class="col-md-3">
                        <asp:Label ID="lbMedidaInventarioConsulta" runat="server" Text="Medida" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlMedidaInventarioConsulta" runat="server" ToolTip="Seleccionar Unidad de Medida" CssClass="form-control"></asp:DropDownList>
                 </div>
                 <div class="col-md-2">
                     <asp:Label ID="lbIdItem" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label>
                     <asp:TextBox ID="txtCodigoItem" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCodigoItem_TextChanged" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
                 </div>
                 <div class="col-md-10">
                     <asp:Label ID="lbArticuloInventarioConsulta" runat="server" Text="Descripción" CssClass="Letranegrita"></asp:Label>
                     <asp:TextBox ID="txtArticuloInventarioConsulta" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtArticuloInventarioConsulta_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                 </div>
             </div>
             <br />
             <div class="ContenidoCentro">
                 <asp:ImageButton ID="btnConsultarInventarioConsulta" runat="server" ToolTip="Consultar Información del Inventario" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultarInventarioConsulta_Click" />
                 <asp:ImageButton ID="btnNuevoRegistroInventarioConsulta" runat="server" ToolTip="Crear Nuevo Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" OnClick="btnNuevoRegistroInventarioConsulta_Click" />
                 <asp:ImageButton ID="btnReporteInventarioConsulta" runat="server" ToolTip="Reporte de Inventario" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporteInventarioConsulta_Click" />
                 <asp:ImageButton ID="btnSuplirInventarioConsulta" runat="server" ToolTip="Suplir Inventario" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/inventario.png" OnClick="btnSuplirInventarioConsulta_Click" />
                 <asp:ImageButton ID="btnEditarReporteInventarioCOnsulta" runat="server" ToolTip="Editar Registro Seleccionado" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" OnClick="btnEditarReporteInventarioCOnsulta_Click" />
                 <asp:ImageButton ID="btnBorrarInventarioCOnsulta" runat="server"  ToolTip="Borrar Registro Seleccionado" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/borrar.png" OnClick="btnBorrarInventarioCOnsulta_Click" OnClientClick="return confirm('¿Quieres Borrar Este Registro?');" />
                 <asp:ImageButton ID="btnRestablecerInventarioConsulta" runat="server" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Restablecer_Nuevo.png" OnClick="btnRestablecerInventarioConsulta_Click" />
             </div>
             <br />
             <table class="table table-striped">
                <thead class="table-dark">
                     <tr>
                     <th scope="col"> Sucursal </th>
                     <th scope="col"> Oficina </th>
                     <th scope="col"> ID </th>
                     <th scope="col"> Descripción </th>
                     <th scope="col"> Categoria </th>
                     <th scope="col"> Medida </th>
                     <th class="ContenidoCentro" scope="col"> Stock </th>
                     <th class="ContenidoDerecha" scope="col"> Seleccionar </th>
                 </tr>
                </thead>
                 <tbody>
                     <asp:Repeater ID="rpListadoInventario" runat="server">
                         <ItemTemplate>
                             <tr>
                                <asp:HiddenField ID="hfIdArticulo" runat="server" Value='<%# Eval("IdRegistro") %>' />

                                 <td> <%# Eval("Sucursal") %> </td>
                                 <td> <%# Eval("Oficina") %> </td>
                                 <td> <%# Eval("IdRegistro") %> </td>
                                 <td> <%# Eval("Articulo") %> </td>
                                 <td> <%# Eval("Categoria") %> </td>
                                 <td> <%# Eval("UnidadMedida") %> </td>
                                 <td class="ContenidoCentro" > <%#string.Format("{0:N0}", Eval("Stock")) %> </td>
                                 <td class="ContenidoDerecha" > <asp:ImageButton ID="btnVerItemInventario" runat="server" ToolTip="Seleccionar este registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/hacer-clic.png" OnClick="btnVerItemInventario_Click" />     </td>
                             </tr>
                         </ItemTemplate>
                     </asp:Repeater>
                 </tbody>
             </table>
             <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">
                            <b>Página </b> <asp:Label ID="lbCantidadPaginaVariable_InventarioConsulta" runat="server" Text="0" ></asp:Label> <b>de </b>  <asp:Label ID="lbPaginaActualVariable_InventarioConsulta" runat="server" Text=" 0 " ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                            <b>Total de Registros: </b> <asp:Label ID="lbCantidadRegistros_InventarioConsulta" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                            <b>Solicitudes Agotados: </b> <asp:Label ID="lbregistrosAgotados_InventarioConsulta" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                </tfoot>
            </table>
              <div id="DivPaginacionInventarioCOnsulta" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_InventarioConsulta" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_InventarioConsulta_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_InventarioConsulta" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_InventarioConsulta_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />  </td>
                    <td class="ContenidoCentro">
                        <asp:DataList ID="dtInventarioConsulta" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_SolicitudesHeader" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_InventarioConsulta" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_InventarioConsulta_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_InventarioConsulta" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_InventarioConsulta_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
         </div>
         <div id="DivSubBloqueInventarioMantenimiento" runat="server">
             <br />
             <asp:Label ID="lbIdregistroSeleccionado" runat="server" Text="0" Visible="false" CssClass="Letranegrita"></asp:Label>
             <asp:Label ID="lbAccionTomarInventario" runat="server" Text="0" Visible="false"></asp:Label>
             <div class="row">
                 <div class="col-md-3">
                     <asp:Label ID="lbSucursalMantenimiento" runat="server" Text="Sucursal" CssClass="Letranegrita"></asp:Label>
                     <asp:Label ID="Astericso" runat="server" Text=" *" ForeColor="Red"></asp:Label>
                     <asp:DropDownList ID="ddlSucursalMantenimiento" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSucursalMantenimiento_SelectedIndexChanged" ></asp:DropDownList>
                 </div>
                  <div class="col-md-3">
                      <asp:Label ID="lbOficinaMantenimiento" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                       <asp:Label ID="Label1" runat="server" Text=" *" ForeColor="Red"></asp:Label>
                     <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                 </div>
                  <div class="col-md-3">
                      <asp:Label ID="lbCategoriaMantenimeinto" runat="server" Text="Categoria" CssClass="Letranegrita"></asp:Label>
                       <asp:Label ID="Label5" runat="server" Text=" *" ForeColor="Red"></asp:Label>
                     <asp:DropDownList ID="ddlCategoriaMantenimiento" runat="server" ToolTip="Seleccionar Categoria" CssClass="form-control"></asp:DropDownList>
                 </div>
                  <div class="col-md-3">
                      <asp:Label ID="lbMedidaMantenimiento" runat="server" Text="Medida" CssClass="Letranegrita"></asp:Label>
                       <asp:Label ID="Label7" runat="server" Text=" *" ForeColor="Red"></asp:Label>
                     <asp:DropDownList ID="ddlMedidaMantenimiento" runat="server" ToolTip="Seleccionar Medida" CssClass="form-control"></asp:DropDownList>
                 </div>

                  <div class="col-md-6">
                      <asp:Label ID="lbDescripcionMantenimiento" runat="server" Text="Descripción" CssClass="Letranegrita"></asp:Label>
                       <asp:Label ID="Label8" runat="server" Text=" *" ForeColor="Red"></asp:Label>
                      <asp:TextBox ID="txtDescripcionMantenimiento" runat="server" MaxLength="1000" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                 </div>
                  <div class="col-md-3">
                      <asp:Label ID="lbStockMantenimiento" runat="server" Text="Stock" CssClass="Letranegrita"></asp:Label>
                       <asp:Label ID="Label9" runat="server" Text=" *" ForeColor="Red"></asp:Label>
                      <asp:TextBox ID="txtStockMantenimiento" runat="server"  CssClass="form-control" TextMode="Number"></asp:TextBox>

                 </div>
                  <div class="col-md-3">
                      <asp:Label ID="lbStockMinimoMantenimiento" runat="server" Text="Stock Minimo" CssClass="Letranegrita"></asp:Label>
                       <asp:Label ID="Label10" runat="server" Text=" *" ForeColor="Red"></asp:Label>
                      <asp:TextBox ID="txtStockMinimoMantenimiento" runat="server"  CssClass="form-control" TextMode="Number"></asp:TextBox>
                 </div>
             </div>
             <br />
             <div class="ContenidoCentro">
                 <asp:ImageButton ID="btnGuardar" runat="server" ToolTip="Guardar Información" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" OnClick="btnGuardar_Click" />
                 <asp:ImageButton ID="btnVolver" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolver_Click" />
             </div>
             <br />
         </div>

         <div id="DIVSubBloqueSuplirSacar" runat="server">
             <br />
             <div class="form-check-inline">
                 <asp:Label ID="lbTipoOperacionAgregarSacar" runat="server" Text="Tipo de Operación: " CssClass="Letranegrita"></asp:Label>
                 <asp:RadioButton ID="rbAgregarItems" runat="server" Text="Agregar Items" ToolTip="Agregar Cantidad al registro Seleccionado" GroupName="SuplirSacar" />
                 <asp:RadioButton ID="rbSacaritems" runat="server" Text="Sacar Items" ToolTip="Sacar Cantidad al registro Seleccionado" GroupName="SuplirSacar" />
             </div>
             <br />
             <div class="row">
                 <div class="col-md-8">
                     <asp:Label ID="lbDescripcion_Suplir_Sacar" runat="server" Text="Descripción" CssClass="Letranegrita"></asp:Label>
                     <asp:TextBox ID="txtDescripcion_Suplir_Sacar" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                 </div>
                 <div class="col-md-2">
                      <asp:Label ID="lbStockActual_Suplir_Sacar" runat="server" Text="Stock Actual" CssClass="Letranegrita"></asp:Label>
                     <asp:TextBox ID="txtStockActual_Suplir_Sacar" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                 </div>
                 <div class="col-md-2">
                      <asp:Label ID="lbStockNuevo_Suplir_Sacar" runat="server" Text="Stock Nuevo" CssClass="Letranegrita"></asp:Label>
                     <asp:Label ID="lbAsretisco_Suplir_Sacar" runat="server" Text=" *" ForeColor="Red"></asp:Label>
                     <asp:TextBox ID="txtStockNuevo_Suplir_Sacar" runat="server" CssClass="form-control" ></asp:TextBox>
                 </div>
             </div>
             <br />
             <div class="ContenidoCentro">
                 <asp:ImageButton ID="btnGuardar_Suplir_Sacar" runat="server" ToolTip="Completar Proceso" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Completado.png" OnClick="btnGuardar_Suplir_Sacar_Click" />
                  <asp:ImageButton ID="btnVolverAtras_Suplir_Sacar" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverAtras_Suplir_Sacar_Click" />
             </div>
             <br />
         </div>
     </div>



            <div id="DIVBloqueCOmpletado" class="ContenidoCentro" runat="server">
           
          
             <br />
            <asp:Label ID="lbNotificacionEnviadaAlCorreo" runat="server" Text="Notificación enviada al Correo (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbNotificacionEnviadaAlCorreoVariable" runat="server" Text="DATO" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbNumeroFacturaGeneradoCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
                <br />
            <asp:Label ID="lbCodigoError" runat="server" Text="Codigo de Error: " Visible="false" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCodigoErrorVariable" runat="server" Text=" Dato" Visible="false" CssClass="LetrasNegrita"></asp:Label>
            
            <br />
            <asp:Image ID="IMGCompletado" runat="server" CssClass="BotonImagenCompletado" ImageUrl="~/Imagenes/Completado3.gif" />
            <br />
            <br />
            <asp:ImageButton ID="btnNuevoRegistro" runat="server" CssClass="BotonImagen" ToolTip="Nuevo P" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" OnClick="btnNuevoRegistro_Click" />
            <br />
        </div>
    </div>
</asp:Content>

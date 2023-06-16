<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SolicitudSuministro.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Suministro.SolicitudSuministro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">

        function CantidadProcesadaInvalida() {
            alert("La cantidad que intentas procesar supera la cantidad que esta en almacen, favor de validar.");
        }
        $(function () {

            $("#<%=btnAgregarRegistroSeleccionado.ClientID%>").click(function () {

                var CantidadProcesar = $("#<%=txtCantidadProcesarRegistroSeleccionado.ClientID%>").val().length;
                if (CantidadProcesar < 1) {
                    alert("El campo Cantidad a procesar no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtCantidadProcesarRegistroSeleccionado.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        })
    </script>
    <div class="container-fluid">
        <div id="DIVBloqueConsulta" runat="server" visible="true">
            <br />
            <table class="table table-bordered">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Información</th>
                         <th scope="col"> Dato</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><b>SUCURSAL</b></td>
                        <td><asp:Label ID="lbSucursal_ConsultaSolicitud" runat="server" Text="Dato"></asp:Label> </td>
                    </tr>
                    <tr>
                        <td><b>OFICINA</b></td>
                        <td><asp:Label ID="lbOficina_ConsultaSolicitud" runat="server" Text="Dato"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>DEPARTAMENTO</b></td>
                        <td><asp:Label ID="lbDepartamento_ConsultaSolicitud" runat="server" Text="Dato"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>SOLICITANTE</b></td>
                        <td><asp:Label ID="lbSolicitante_ConsultaSolicitud" runat="server" Text="Dato"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <div class="form-check form-switch">
                <input id="cbNoAgregarRangoFecha" runat="server" type="checkbox" class="form-check-input" />
                <label class="form-check-label">No Agregar Rango de Fecha</label>
            </div>
            <br />
            <div class="row">
                 <div class="col-md-3">
                     <asp:Label ID="lbNumeroSolicitud" runat="server" CssClass="Letranegrita" Text="No. Solicitud"></asp:Label>
                     <asp:TextBox ID="txtNumeroSolicitud_ConsultaSolicitud" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                 </div>
                 <div class="col-md-3">
                      <asp:Label ID="lbfechaDesde" runat="server" CssClass="Letranegrita" Text="Fecha Desde"></asp:Label>
                     <asp:TextBox ID="txtFechaDesde_ConsultaSolicitud" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                 </div>
                 <div class="col-md-3">
                      <asp:Label ID="lbFechaHasta" runat="server" CssClass="Letranegrita" Text="Fecha Hasta"></asp:Label>
                     <asp:TextBox ID="txtFechaHasta_ConsultaSolicitud" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                 </div>
                 <div class="col-md-3">
                      <asp:Label ID="lbEstatus" runat="server" CssClass="Letranegrita" Text="Estatus"></asp:Label>
                     <asp:DropDownList ID="ddlEstatus_ConsultaSolicitud" runat="server" CssClass="form-control" ToolTip="Seleccionar Estatus de Solicitud"></asp:DropDownList>
                 </div>
            </div>
            <br />
            <div class="ContenidoCentro">
                <asp:ImageButton ID="btnConsultarInformacion_ConsultaSolicitud" CssClass="BotonImagen" runat="server" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultarInformacion_ConsultaSolicitud_Click" />
                <asp:ImageButton ID="btnNuevaSolicitud_ConsultaSolicitud" CssClass="BotonImagen" runat="server" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" OnClick="btnNuevaSolicitud_ConsultaSolicitud_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th class="ContenidoCentro" scope="col"> Solicitud </th>
                        <th class="ContenidoCentro" scope="col"> Fecha </th>
                        <th class="ContenidoCentro" scope="col"> Items </th>
                        <th class="ContenidoCentro" scope="col"> Estatus </th>
                        <th class="ContenidoDerecha" scope="col"> Cancelar </th>
                        <th class="ContenidoDerecha" scope="col"> Detalle </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoSolicitudes_ConsultaSolicitud" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroSolicitud" runat="server" Value='<%# Eval("") %>' />
                                <td class="ContenidoCentro"> <%# Eval("") %> </td>
                                <td class="ContenidoCentro"> <%# Eval("") %> </td>
                                <td class="ContenidoCentro"> <%#string.Format("{0:N0}", Eval("")) %> </td>
                                <td class="ContenidoCentro"> <%# Eval("") %> </td>
                                <td class="ContenidoDerecha"> <asp:ImageButton ID="btnCancelarSolicitud" runat="server" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" OnClick="btnNuevaSolicitud_ConsultaSolicitud_Click" /> </td>
                                <td class="ContenidoDerecha"> <asp:ImageButton ID="btnDetalleSolicitud" runat="server" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" OnClick="btnNuevaSolicitud_ConsultaSolicitud_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
              <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">
                            <b>Página </b> <asp:Label ID="lbCantidadPaginaVariable_ConsultaSolicitud" runat="server" Text="0" ></asp:Label> <b>de </b>  <asp:Label ID="lbPaginaActualVariable_ConsultaSolicitud" runat="server" Text=" 0 "></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                            <b>Total de Solicitudes: </b> <asp:Label ID="lbCantidadSolicitudes_ConsultaSolicitud" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                            <b>Solicitudes Activas: </b> <asp:Label ID="lbSolicitudesActivas_ConsultaSolicitud" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                             <b>Solicitudes Procesadas: </b> <asp:Label ID="lbSolicitudesProcesadas_ConsultaSolicitud" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                             <b>Solicitudes Canceladas: </b> <asp:Label ID="lbSolicitudesCanceladas_ConsultaSolicitud" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                             <b>Solicitudes Rechazadas: </b> <asp:Label ID="lbSolicitudesRechazadas_ConsultaSolicitud" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                </tfoot>
            </table>
              <div id="DivPaginacion_ConsultaSolicitud" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_ConsultaSolicitud" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_ConsultaSolicitud_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_ConsultaSolicitud" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_ConsultaSolicitud_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />  </td>
                    <td class="ContenidoCentro">
                        <asp:DataList ID="dtPaginacion_ConsultaSolicitud" runat="server" OnItemCommand="dtPaginacion_ConsultaSolicitud_ItemCommand" OnItemDataBound="dtPaginacion_ConsultaSolicitud_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_ConsultaSolicitud" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_ConsultaSolicitud" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_ConsultaSolicitud_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_ConsultaSolicitud" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_ConsultaSolicitud_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
            <br />
           <div id="DIvBloqueDetalleRegistro"  runat="server">
              <asp:ScriptManager ID="ScripManagerGestionCobros" runat="server"></asp:ScriptManager> 
             <button class=" btn-sm  btn-dark BotonEspecial" type="button" id="btnPolizasNoContastadas" data-toggle="collapse" data-target="#RegistroSeleccionado" aria-expanded="false" aria-controls="collapseExample">
                  
                  <asp:Label ID="lbRegistroSeleccionado" runat="server" Text="DETALLE DE LOS ARTICULOS SOLICITADOS" CssClass="Letranegrita"></asp:Label>
                     </button><br />


       <div class="collapse" id="RegistroSeleccionado">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelRegistroSeleccionado" runat="server">
                       <ContentTemplate>
                       <table class="table table-striped">
                           <thead class="table-dark">
                               <tr>
                                   <th scope="col"> Articulo </th>
                                   <th scope="col"> Categoria </th>
                                   <th scope="col"> Medida </th>
                                   <th scope="col"> Cant. Solicitada </th>
                               </tr>
                           </thead>
                           <tbody>
                               <asp:Repeater ID="rpSolicitudDetalle" runat="server">
                                   <ItemTemplate>
                                       <tr>
                                            <td> <%# Eval("") %> </td>
                                            <td> <%# Eval("") %> </td>
                                            <td> <%# Eval("") %> </td>
                                            <td> <%#string.Format("{0:N0}", Eval("")) %> </td>

                                       </tr>
                                   </ItemTemplate>
                               </asp:Repeater>
                           </tbody>
                       </table>
                    </ContentTemplate>
                   </asp:UpdatePanel>
                </div>
            </div>
           <br />

        </div>
        </div>



        <div id="DIVBloqueMantenimiento" runat="server" visible="false">
            <br />
            <asp:Label ID="lbNumeroConector" runat="server" Text="0" Visible="false"></asp:Label>
            <div id="DIVSubBloqueConsultaInventario" runat="server">
                <div class="row">
                 <div class="col-md-3">
                     <asp:Label ID="lbSucursalProceso" runat="server" Text="Sucursal" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlSucursalProceso" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSucursalProceso_SelectedIndexChanged"></asp:DropDownList>
                 </div>
                 <div class="col-md-3">
                     <asp:Label ID="lbOficinaProceso" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlOficinaProceso" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOficinaProceso_SelectedIndexChanged"></asp:DropDownList>
                 </div>
                 <div class="col-md-3">
                     <asp:Label ID="lbDepartamentoProceso" runat="server" Text="Departamento" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlDepartamentoProceso" runat="server" ToolTip="Seleccionar Departaemnto" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartamentoProceso_SelectedIndexChanged"></asp:DropDownList>
                 </div>
                 <div class="col-md-3">
                     <asp:Label ID="lbUsuarioProceso" runat="server" Text="Usuario" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlUsuarioProceso" runat="server" ToolTip="Seleccionar Usuario" CssClass="form-control"></asp:DropDownList>
                 </div>

                 <div class="col-md-3">
                      <asp:Label ID="lbCodigoProceso" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label>
                     <asp:TextBox ID="txtCodigoProceso" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoProceso_TextChanged" CssClass="form-control"></asp:TextBox>
                 </div>
                 <div class="col-md-3">
                      <asp:Label ID="lbDescripcionProceso" runat="server" Text="Descripción" CssClass="Letranegrita"></asp:Label>
                     <asp:TextBox ID="txtDescripcionProceso" runat="server" AutoPostBack="true" OnTextChanged="txtDescripcionProceso_TextChanged" CssClass="form-control"></asp:TextBox>
                 </div>
                 <div class="col-md-3">
                      <asp:Label ID="lbCategoriaProceso" runat="server" Text="Categoria" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlCategoriaProceso" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoriaProceso_SelectedIndexChanged" ToolTip="Seleccionar Categoria" CssClass="form-control"></asp:DropDownList>
                 </div>
                 <div class="col-md-3">
                      <asp:Label ID="lbUnidadMedidaProceso" runat="server" Text="Medida" CssClass="Letranegrita"></asp:Label>
                     <asp:DropDownList ID="ddlUnidadMedida" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnidadMedida_SelectedIndexChanged" ToolTip="Seleccionar Unidad de Medida" CssClass="form-control"></asp:DropDownList>
                 </div>
            </div>
            <br />
            <div class="ContenidoCentro">
                <asp:ImageButton ID="btnConsultarInformacionInventario" runat="server" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" CssClass="BotonImagen" OnClick="btnConsultarInformacionInventario_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Codigo </th>
                        <th scope="col"> Descripción </th>
                        <th scope="col"> Categoria </th>
                        <th scope="col"> Medida </th>
                        <th class="ContenidoCentro" scope="col"> Disponible </th>
                        <th class="ContenidoDerecha" scope="col"> Seleccionar </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoInventario" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfCodigoInventario" runat="server" Value='<%# Eval("IdRegistro") %>' />

                                <td> <%# Eval("IdRegistro") %> </td>
                                <td> <%# Eval("Articulo") %> </td>
                                <td> <%# Eval("Categoria") %> </td>
                                <td> <%# Eval("UnidadMedida") %> </td>
                                <td class="ContenidoCentro" > <%#string.Format("{0:N0}", Eval("Stock")) %> </td>
                                <td class="ContenidoDerecha" ><asp:ImageButton ID="btnSeleccionarInventario" runat="server" ImageUrl="~/ImagenesBotones/hacer-clic.png" CssClass="BotonImagen" OnClick="btnSeleccionarInventario_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">
                            <b>Página </b> <asp:Label ID="lbCantidadPaginaVariable_Inventario" runat="server" Text="0" ></asp:Label> <b>de </b>  <asp:Label ID="lbPaginaActual_Inventario" runat="server" Text=" 0 "></asp:Label>
                        </td>
                    </tr>

                </tfoot>
            </table>
              <div id="DivPaginacion_Inventario" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_Inventario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Inventario_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_Inventario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Inventario_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />  </td>
                    <td class="ContenidoCentro">
                        <asp:DataList ID="dtPaginacion_Inventario" runat="server" OnItemCommand="dtPaginacion_Inventario_ItemCommand" OnItemDataBound="dtPaginacion_Inventario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_Inventario" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_Inventario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_Inventario_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_Inventario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Inventario_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
            </div>


            <div id="DIVSubBloqueRegistroSeleccionado" runat="server">
                <br />
                <asp:Label ID="lbIdSucursalSeleccionada_RegistroSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
                 <asp:Label ID="lbOficina_RegistroSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
                 <asp:Label ID="lbDepartamento_RegistroSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
                 <asp:Label ID="lbUsuario_RegistroSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Label ID="lbCategoria_RegistroSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Label ID="lbUnidadMedida_RegistroSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>

                <asp:Label ID="lbCodigoItemSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
                <h3 class="ContenidoCentro" >Datos del Registro Seleccionado</h3>
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="lbDescripcionRegistroSeleccionado" runat="server" Text="Descripcion" CssClass="Letranegrita"></asp:Label> 
                        <asp:TextBox ID="txtDescripcionRegistroSeleccionado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbCategoriaRegistriSeleccionado" runat="server" Text="Categoria" CssClass="Letranegrita"></asp:Label> 
                        <asp:TextBox ID="txtCategoriaRegistroSeleccionado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbMedidaRegistroSeleccionado" runat="server" Text="Medida" CssClass="Letranegrita"></asp:Label> 
                        <asp:TextBox ID="txtMedidaRegistroSeleccionado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lbStockRegistroSeleccionado" runat="server" Text="Disponible" CssClass="Letranegrita"></asp:Label> 
                        <asp:TextBox ID="txtStockRegistroSeleccionado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class=" col-md-2">
                        <asp:Label ID="lbCantidadProcesarRegistroSeleccionado" runat="server" Text="Cantidad a Procesar" CssClass="  Letranegrita"></asp:Label> 
                        <asp:TextBox ID="txtCantidadProcesarRegistroSeleccionado" runat="server" CssClass="  form-control"></asp:TextBox>
                    </div>

                </div>
                <br />
                 <div class="ContenidoCentro">
                <asp:ImageButton ID="btnAgregarRegistroSeleccionado" CssClass="BotonImagen" runat="server" ImageUrl="~/ImagenesBotones/Agregar2_Nuevo.png" OnClick="btnAgregarRegistroSeleccionado_Click" />
                <asp:ImageButton ID="btnVolverRegistroSeleccionado" CssClass="BotonImagen" runat="server" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverRegistroSeleccionado_Click" />
            </div>
                <br />
            </div>

            <div id="DIVSubBloqueCompletarSolicitud" runat="server">
                  <br />
              <div id="DivBloqueCompletarProceso" runat="server" class="ContenidoCentro">
                <asp:ImageButton ID="btnGuardarSolicitud" CssClass="BotonImagen" runat="server" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" OnClick="btnGuardarSolicitud_Click" />
                <asp:ImageButton ID="btnVolverAtras" CssClass="BotonImagen" runat="server" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverAtras_Click" />
            </div>
            <br />
            <h3 class="ContenidoCentro">Items para agregar a la solicitud</h3>
            <hr />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                         <th scope="col"> Codigo </th>
                         <th scope="col"> Descripción </th>
                         <th scope="col"> Categoria </th>
                         <th scope="col"> Medida </th>
                         <th class="ContenidoCentro" scope="col"> Cantidad </th>
                         <th class="ContenidoDerecha" scope="col"> Borrar </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoRegistrosAgregados" runat="server">
                        <ItemTemplate>
                            <tr>

                        <asp:HiddenField ID="hfIdCodigoProductoAGregado" runat="server" Value='<%# Eval("CodigoArticulo") %>' />
                        <asp:HiddenField ID="hfSecuenciaEspejo" runat="server" Value='<%# Eval("Secuencial") %>' />

                        <td> <%# Eval("CodigoArticulo") %> </td>
                        <td> <%# Eval("DescripcionArticulo") %> </td>
                        <td> <%# Eval("Categoria") %> </td>
                        <td> <%# Eval("UnidadMedida") %> </td>
                        <td class="ContenidoCentro" > <%#string.Format("{0:N0}", Eval("Cantidad")) %> </td>
                        <td class="ContenidoDerecha" >  <asp:ImageButton ID="btnBorrarRegitro" CssClass="BotonImagen" runat="server" ImageUrl="~/ImagenesBotones/borrar.png" OnClick="btnBorrarRegitro_Click" OnClientClick="return confirm('¿Quieres Eliminar Este Registro?');" /> </td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <br />
        </div>
            </div>
          
    </div>
  

</asp:Content>

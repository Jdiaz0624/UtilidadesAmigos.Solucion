<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AdministracionSuministro.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Suministro.AdministracionSuministro" %>
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
            border-collapse: collapse;
        }
        

        th {
            background-color: #1E90FF;
            color: #000000;
        }
          .BotonImagen {
           width: 40px;
           height: 40px;
          }


    </style>

    <script type="text/javascript">

        function OpcionNovalida() {
            alert("La opción seleccionada no es valida, favor de verificar.");
        }
        function CantidadSuperiorStock() {
            alert("La cantidad que intentas sacar del inventario supera la cantidad en stock, favor de verificar.");
        }
        $(function () {

            //VALIDACIONES DEL BOTON GUARDAR EN LA PARTE DE INVENTARIO
            $("#<%=btnGuardarRegistroMantenimientoInventario.ClientID%>").click(function () {

                var Articulo = $("#<%=txtArticuloMantenimientoInventario.ClientID%>").val().length;
                if (Articulo < 1) {

                    alert("El campo Articulo no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtArticuloMantenimientoInventario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Medida = $("#<%=ddlSeleccionarMedidaMantenimientoInventario.ClientID%>").val();
                    if (Medida < 1) {

                        alert("El campo medida no puede estar vacio para realizar esta operación, favor de verificar.");
                        $("#<%=ddlSeleccionarMedidaMantenimientoInventario.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var Stock = $("#<%=txtStockMantenimientoInventario.ClientID%>").val().length;
                        if (Stock < 1) {
                            alert("El campo Stock no puede estar vacio para realizar esta operación, favor de verificar.");
                            $("#<%=txtStockMantenimientoInventario.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            $("#<%=btnSuplirSacarProductos.ClientID%>").click(function () {
                var Cantidad = $("#<%=txtCantidadSupliorSacar.ClientID%>").val().length;
                if (Cantidad < 1) {
                    alert("El campo cantidad no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtCantidadSupliorSacar.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        });
    </script>

    <div class="container-fluid">
        <br />
        <div class="form-check-inline">
            <asp:RadioButton ID="rbSolicitudes" runat="server" CssClass="LetrasNegrita" ToolTip="Mostrar las solicitudes" AutoPostBack="true" OnCheckedChanged="rbSolicitudes_CheckedChanged" GroupName="TipoOperacion" Text="Solicitudes" />
            <asp:RadioButton ID="rbInventario" runat="server" CssClass="LetrasNegrita" ToolTip="Mostrar el Inventario" AutoPostBack="true" OnCheckedChanged="rbInventario_CheckedChanged" GroupName="TipoOperacion" Text="Inventario" />
        </div>
        <div id="DIVBloqueConsulta" runat="server">
        <br />
           <div class="row">
               <div class="col-md-3">
                   <asp:Label ID="lbNumeroSolicitudConsulta" runat="server" Text="No. Solicitud" CssClass="LetrasNegrita"></asp:Label>
                   <asp:TextBox ID="txtNumeroSolicitudConsulta" runat="server" TextMode="Number" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
               </div>

                <div class="col-md-3">
                    <asp:Label ID="lbPersonaConsulta" runat="server" Text="Persona" CssClass="LetrasNegrita"></asp:Label>
                   <asp:TextBox ID="txtPersonaConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
               </div>

                <div class="col-md-3">
                    <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                   <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
               </div>

                <div class="col-md-3">
                    <asp:Label ID="lbFechaHAstaConsulta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                   <asp:TextBox ID="txtFechahastaConsulta" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
               </div>
           </div>
            <br />
            <div class="form-check-inline">
                <asp:Label ID="lbEstatusRegistro" runat="server" Text="Estatus: " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbTodosLosRegistros" runat="server" Text="Todos" ToolTip="Muestra todos los registros" GroupName="Estatus" />
                <asp:RadioButton ID="rbActivos" runat="server" Text="Activos" ToolTip="Muestra todos los registros activos" GroupName="Estatus" />
                <asp:RadioButton ID="rbProcesados" runat="server" Text="Procesados" ToolTip="Muestra todos los registros procesados" GroupName="Estatus" />
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnBuscarInformacion" runat="server" ToolTip="BuscarRegistros" ImageUrl="~/Imagenes/Buscar.png" CssClass="BotonImagen" OnClick="btnBuscarInformacion_Click" />
                 <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Reporte de Suministro" ImageUrl="~/Imagenes/Reporte.png" CssClass="BotonImagen" OnClick="btnReporte_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead>
                    <tr>
                    <th scope="col"> Persona </th>
                    <th scope="col"> Fecha </th>
                    <th scope="col"> Hora </th>
                    <th scope="col"> Estatus </th>
                    <th scope="col">  </th>
                </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoSolicitudes" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroSolicitud" runat="server" Value='<%# Eval("") %>' />

                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <asp:ImageButton ID="btnSeleccionar" runat="server" ToolTip="Seleccionar Registro" ImageUrl="~/Imagenes/Seleccionar2.png" CssClass="BotonImagen" OnClick="btnSeleccionar_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
             <div align="center">
                <asp:Label ID="lbPaginaActualEncabezadoSolicitud" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableEncabezadoSolicitud" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloEncabezadoSolicitud" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableEncabezadoSolicitud" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionEncabezadoSolicitud" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaEncabezadoSolicitud" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaEncabezadoSolicitud_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorEncabezadoSolicitud" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorEncabezadoSolicitud_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionEncabezadoSolicitud" runat="server" OnItemCommand="dtPaginacionEncabezadoSolicitud_ItemCommand" OnItemDataBound="dtPaginacionEncabezadoSolicitud_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralEncabezadoSolicitud" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteEncabezadoSolicitud" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteEncabezadoSolicitud_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoEncabezadoSolicitud" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoEncabezadoSolicitud_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
       <br />
        <div id="BloqueArticulosSeleccionados" runat="server">
            <div align="center">
                <asp:Label ID="lbTituloArticulosSeleccionados" runat="server" Text="Listado de Articulos de la solicitud seleccionada" CssClass="LetrasNegrita"></asp:Label>
                <br />
                <hr />
                <br />
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th scope="col"> Articulo </th>
                            <th scope="col"> Cantidad </th>
                            <th scope="col">  </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoArticulosSolicitud" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfCodigoArticulo" runat="server" Value='<%# Eval("") %>' />
                                     <asp:HiddenField ID="hfNumeroSolicitud" runat="server" Value='<%# Eval("") %>' />
                                     <asp:HiddenField ID="hfCodigoUsuario" runat="server" Value='<%# Eval("") %>' />

                                    <td> <%# Eval("") %> </td>
                                    <td> <%#string.Format("{0:N0}", Eval("")) %> </td>
                                    <td> <td> <asp:ImageButton ID="btnEliminarArticulo" runat="server" ToolTip="Eliminar Articulo" CssClass="BotonImagen" OnClick="btnEliminarArticulo_Click" ImageUrl="~/Imagenes/Eliminar.png" /> </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                  <div align="center">
                <asp:Label ID="lbPaginaActualArticulosSeleccionado" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableArticulosSeleccionado" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloArticulosSeleccionado" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableArticulosSeleccionado" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionArticulosSeleccionado" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaArticulosSeleccionado" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaArticulosSeleccionado_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorArticulosSeleccionado" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorArticulosSeleccionado_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionArticulosSeleccionado" runat="server" OnItemCommand="dtPaginacionArticulosSeleccionado_ItemCommand" OnItemDataBound="dtPaginacionArticulosSeleccionado_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralArticulosSeleccionado" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteArticulosSeleccionado" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteArticulosSeleccionado_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoArticulosSeleccionado" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoArticulosSeleccionado_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
       <br />
                <div align="center">
                    <asp:ImageButton ID="btnCompletarOperacion" runat="server" ToolTip="Procesar Solicitud" CssClass="BotonImagen" OnClick="btnEliminarArticulo_Click" ImageUrl="~/Imagenes/Procesar.png" />
                    <asp:ImageButton ID="btnCancelar" runat="server" ToolTip="btnCancelarProceso" CssClass="BotonImagen" OnClick="btnEliminarArticulo_Click" ImageUrl="~/Imagenes/cancelado.png" />
                </div>
            </div>
        </div>
    </div>

        <div id="DIVBloqueInventario" runat="server">
            <asp:Label ID="lbCodigoArticuloInventarioSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
            <asp:Label ID="lbAccionInventario" runat="server" Visible="false" Text=""></asp:Label>

            <div id="DIVBloqueConsultaInventario" runat="server">
                <br />
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="lbDescripcionConsultaInventario" runat="server" CssClass="LetrasNegrita" Text="Articulo"></asp:Label>
                        <asp:TextBox ID="txtDescripcionConsultaInventario" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lbSeleccionarMedida" runat="server" CssClass="LetrasNegrita" Text="Medida"></asp:Label>
                        <asp:DropDownList ID="ddlSeleccionarMedida" runat="server" ToolTip="Seleccionar Medida" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="form-check-inline">
                    <asp:Label ID="lbEstatusInventario" runat="server" Text="Estatus: " CssClass="LetrasNegrita"></asp:Label>
                    <asp:RadioButton ID="rbEstatusTodos" runat="server" Text="Todos" GroupName="EstatusInventario" />
                    <asp:RadioButton ID="rbEstatusDisponible" runat="server" Text="Disponible" GroupName="EstatusInventario" />
                    <asp:RadioButton ID="rbEstatusPocos" runat="server" Text="Pocos" GroupName="EstatusInventario" />
                    <asp:RadioButton ID="rbEstatusAgotados" runat="server" Text="Agotados" GroupName="EstatusInventario" />
                </div>
                <div align="center">

                    <asp:ImageButton ID="btnConsultarInventario" runat="server" ToolTip="Buscar Registros" ImageUrl="~/Imagenes/Buscar.png" CssClass="BotonImagen" OnClick="btnConsultarInventario_Click" />
                    <asp:ImageButton ID="btnNuevoRegistro" runat="server" ToolTip="Crear Nuevo Registro" ImageUrl="~/Imagenes/Agregar (2).png" CssClass="BotonImagen" OnClick="btnNuevoRegistro_Click" />
                    <asp:ImageButton ID="btnReporteInventario" runat="server" ToolTip="Reporte de Inventario" ImageUrl="~/Imagenes/Reporte.png" CssClass="BotonImagen" OnClick="btnReporteInventario_Click" />
                    <asp:ImageButton ID="btnSuplirInventario" runat="server" ToolTip="Suplir Inventario" ImageUrl="~/Imagenes/Procesar.png" CssClass="BotonImagen" OnClick="btnSuplirInventario_Click" />
                    <asp:ImageButton ID="btnEditarInventario" runat="server" ToolTip="Editar Registro Seleccionado" ImageUrl="~/Imagenes/Editar.png" CssClass="BotonImagen" OnClick="btnEditarInventario_Click" />
                    <asp:ImageButton ID="btnEliminarInventario" runat="server" ToolTip="Eliminar Registro Seleccionado" ImageUrl="~/Imagenes/Eliminar.png" CssClass="BotonImagen" OnClick="btnEliminarInventario_Click" />
                    <asp:ImageButton ID="btnRestablecerPantalla" runat="server" ToolTip="Restablecer Pantalla" ImageUrl="~/Imagenes/auto.png" CssClass="BotonImagen" OnClick="btnRestablecerPantalla_Click" />
            </div>
                <br />
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th scope="col"> Articulo </th>
                            <th scope="col"> Medida </th>
                            <th scope="col"> Stock </th>
                            <th scope="col"> Estatus </th>
                            <th scope="col">  </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoInventario" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfCodigoArticulo" runat="server" Value='<%# Eval("CodigoArticulo") %>' />

                                    <td> <%# Eval("Articulo") %> </td>
                                    <td> <%# Eval("Medida") %> </td>
                                    <td> <%#string.Format("{0:N0}", Eval("Stock")) %> </td>
                                    <td> <%# Eval("Estatus") %> </td>
                                    <td> <asp:ImageButton ID="btnSeleccionarArticuloINventario" runat="server" ToolTip="Seleccionar Registro" ImageUrl="~/Imagenes/Seleccionar2.png" CssClass="BotonImagen" OnClick="btnSeleccionarArticuloINventario_Click" /> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                  <div align="center">
                <asp:Label ID="lbPaginaActualInventario" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableInventario" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloInventario" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableInventario" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionInventario" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaInventario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaInventario_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorInventario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorInventario_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionInventario" runat="server" OnItemCommand="dtPaginacionInventario_ItemCommand" OnItemDataBound="dtPaginacionInventario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralInventario" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteInventario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteInventario_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoInventario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoInventario_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
       <br />
            </div>

            <div id="DIVBloqueMantenimientoInventario" runat="server">
                <br />
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="lbarticuloMantenimientoInventario" runat="server" Text="Articulo" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtArticuloMantenimientoInventario" runat="server" AutoCompleteType="Disabled" MaxLength="1000" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-md-4">
                        <asp:Label ID="lbSeleccionarMedidaMantenimientoInventario" runat="server" Text="Medida" CssClass="LetrasNegrita"></asp:Label>
                      <asp:DropDownList ID="ddlSeleccionarMedidaMantenimientoInventario" runat="server" ToolTip="Seleccionar Unidad de Medida" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="col-md-2">
                        <asp:Label ID="lbStockMantenimientoInventario" runat="server" Text="Stock" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtStockMantenimientoInventario" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div align="center">
                    <asp:ImageButton ID="btnGuardarRegistroMantenimientoInventario" runat="server" ToolTip="Guardar Información" ImageUrl="~/Imagenes/salvar.png" CssClass="BotonImagen" OnClick="btnGuardarRegistroMantenimientoInventario_Click" />
                    <asp:ImageButton ID="btnVolverAtras" runat="server" ToolTip="Volver Atras" ImageUrl="~/Imagenes/volver-flecha.png" CssClass="BotonImagen" OnClick="btnVolverAtras_Click" />
                </div>
                <br />
            </div>

            <div id="DIVBloqueSuplirInventario" runat="server">
                <br />
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lbDescripcionArticuloSuplirInventario" runat="server" Text="Articulo: " CssClass="LetrasNegrita"></asp:Label>
                    </div>
                     <div class="col-md-9">
                        <asp:Label ID="lbDescripcionArticuloSuplirInventarioVariable" runat="server" Text="Dato" CssClass="LetrasNegrita"></asp:Label>
                    </div>

                     <div class="col-md-3">
                        <asp:Label ID="lbMedidaSuplirInventario" runat="server" Text="Medida: " CssClass="LetrasNegrita"></asp:Label>
                    </div>
                     <div class="col-md-9">
                        <asp:Label ID="lbMedidaSuplirInventarioVariable" runat="server" Text="Dato" CssClass="LetrasNegrita"></asp:Label>
                    </div>

                    <div class="col-md-3">
                        <asp:Label ID="lbStockSuplirInventario" runat="server" Text="Stock: " CssClass="LetrasNegrita"></asp:Label>
                    </div>
                     <div class="col-md-9">
                        <asp:Label ID="lbStockSuplirInventarioVariable" runat="server" Text="Dato" CssClass="LetrasNegrita"></asp:Label>
                    </div>
                    <br />
                    <br />

                     <div class="col-md-3">
                        <asp:Label ID="lbCantidad" runat="server" Text="Cantidad: " CssClass="LetrasNegrita"></asp:Label>
                    </div>
                     <div class="col-md-3">
                        <asp:TextBox ID="txtCantidadSupliorSacar" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>

                </div>
                <br />
                <div class="form-check-inline">
                    <asp:RadioButton ID="rbIngresarProductos" runat="server" Text="Ingresar Producto" CssClass="LetrasNegrita" GroupName="SuplirSacarInventario" AutoPostBack="true" OnCheckedChanged="rbIngresarProductos_CheckedChanged" />
                     <asp:RadioButton ID="rbSacarProductos" runat="server" Text="Sacar Producto" CssClass="LetrasNegrita" GroupName="SuplirSacarInventario" AutoPostBack="true" OnCheckedChanged="rbSacarProductos_CheckedChanged" />
                </div>
                <br />
                <div align="center">
                    <asp:ImageButton ID="btnSuplirSacarProductos" runat="server" ImageUrl="~/Imagenes/Procesar.png" CssClass="BotonImagen" OnClick="btnSuplirSacarProductos_Click" ToolTip="Procesar Información" />
                    <asp:ImageButton ID="btnVolverSuplirSacar" runat="server" ImageUrl="~/Imagenes/volver-flecha.png" CssClass="BotonImagen" OnClick="btnVolverAtras_Click" ToolTip="Volver Atras" />
                </div>
                <br />
            </div>
        </div>
                    
    </div>
</asp:Content>

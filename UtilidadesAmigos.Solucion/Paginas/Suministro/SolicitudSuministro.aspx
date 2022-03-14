<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SolicitudSuministro.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Suministro.SolicitudSuministro" %>
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
        function CantidadAlmacenSuperior() {

            alert("La cantidad que intentas solicitar supera el stock actual de este registro en almacen, favor de verificar.");
        }
    </script>

    <div class="container-fluid">
        <asp:Label ID="lbCodigoArtiuloSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
        <asp:Label ID="lbAccionTomar" runat="server" Text="" Visible="false"></asp:Label>

        <div id="DIVBloqueConsulta" runat="server" >
            <div class="row">
                <div class="col-md-5">
                    <asp:Label ID="lbNombreArticuloConsulta" runat="server" Text="Articulo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreArticuloConsulta" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNombreArticuloConsulta_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server"  ImageUrl="~/Imagenes/Buscar.png" CssClass="BotonImagen" OnClick="btnConsultar_Click" ToolTip="Buscar Registros" />
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
                    <asp:Repeater ID="rbListadoSeleccionarArticulo" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfCodigoArticulo" runat="server" Value='<%# Eval("CodigoArticulo") %>' />
                                <td> <%# Eval("Articulo") %> </td>
                                <td> <%# Eval("Medida") %> </td>
                                <td> <%#string.Format("{0:N0}", Eval("Stock")) %> </td>
                                <td> <%# Eval("Estatus") %> </td>
                                <td> <asp:ImageButton ID="btnSeleccionarRegistro" runat="server"  ImageUrl="~/Imagenes/Seleccionar2.png" CssClass="BotonImagen" OnClick="btnSeleccionarRegistro_Click" ToolTip="Seleccionar Registro" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
              <div align="center">
                <asp:Label ID="lbPaginaActualSeleccionarArticulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableSeleccionarArticulo" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloSeleccionarArticulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableSeleccionarArticulo" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionSeleccionarArticulo" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaSeleccionarArticulo" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaSeleccionarArticulo_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorSeleccionarArticulo" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorSeleccionarArticulo_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionSeleccionarArticulo" runat="server" OnItemCommand="dtPaginacionSeleccionarArticulo_ItemCommand" OnItemDataBound="dtPaginacionSeleccionarArticulo_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralSeleccionarArticulo" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteSeleccionarArticulo" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteSeleccionarArticulo_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoSeleccionarArticulo" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoSeleccionarArticulo_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
       <br />
            <hr />
            <br />
            <div class="row">
                <div class="col-md-8">
                    <asp:Label ID="lbArticuloSeleccionado" runat="server" Text="Articulo Seleccionado" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtArticuloSeleccionado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                 <div class="col-md-2">
                    <asp:Label ID="lbCantidad" runat="server" Text="Cantidad" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                 <div class="col-md-2">
                    <asp:Label ID="lbStockSeleccionado" runat="server" Text="Stock" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtStockSeleccionado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnAgregarRegistro" runat="server"  ImageUrl="~/Imagenes/Agregar (2).png" CssClass="BotonImagen" OnClick="btnAgregarRegistro_Click" ToolTip="Agregar Selección" />
                <asp:ImageButton ID="btbCancelar" runat="server"  ImageUrl="~/Imagenes/cancelado.png" CssClass="BotonImagen" OnClick="btbCancelar_Click" ToolTip="Cancelar Selección" />
            </div>
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
                    <asp:Repeater ID="rpArticulosAgregados" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td> <%# Eval("") %> </td>
                                <td> <%#string.Format("{0:N0}", Eval("")) %> </td>
                                <td> <asp:ImageButton ID="btnEliminar" runat="server"  ImageUrl="~/Imagenes/Eliminar.png" CssClass="BotonImagen" OnClick="btnEliminar_Click" ToolTip="Eliminar Registro" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
              <div align="center">
                <asp:Label ID="lbPaginaActualEliminarArticulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableEliminarArticulo" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloEliminarArticulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableEliminarArticulo" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionEliminarArticulo" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaEliminarArticulo" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaEliminarArticulo_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorEliminarArticulo" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorEliminarArticulo_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionEliminarArticulo" runat="server" OnItemCommand="dtPaginacionEliminarArticulo_ItemCommand" OnItemDataBound="dtPaginacionEliminarArticulo_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralEliminarArticulo" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteEliminarArticulo" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteEliminarArticulo_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoEliminarArticulo" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoEliminarArticulo_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
       <br />
            <div align="center">
                <asp:ImageButton ID="btnCompletarProceso" runat="server"  ImageUrl="~/Imagenes/Completar.png" CssClass="BotonImagen" OnClick="btnCompletarProceso_Click" ToolTip="Completar Operación" />
            </div>
            <br />
        </div>

       <div id="DIVBloqueCOmpletado" align="center" runat="server">
            <br />
            <asp:Label ID="lbNumerofacturageneradoTitulo" runat="server" Text="Numero de Solicitud ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbNumeroFacturaGeneradoVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbNumeroFacturaGeneradoCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbNumeroConectorGenerado" runat="server" CssClass="LetrasNegrita" Text="0" Visible="false"></asp:Label>
            <br />
            <asp:Image ID="IMGCompletado" runat="server" CssClass="BotonImagenCompletado" ImageUrl="~/Imagenes/Completado3.gif" />
            <br />
            <br />
        </div>
    </div>
</asp:Content>

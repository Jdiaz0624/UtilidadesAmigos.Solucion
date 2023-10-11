<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="EquiposElectronicos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Correcciones.EquiposElectronicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        $(function () {

            $("#<%=btnConsultar.ClientID%>").click(function () {
                var Poliza = $("#<%=txtPolizaConsulta.ClientID%>").val().length;
                if (Poliza < 1) {

                    alert("El campo Póliza no puede estar vacio para consultar esta información, favor de verificar.");
                    $("#<%=txtPolizaConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

            $("#<%=btnGuardar.ClientID%>").click(function () {

                var Descripcion = $("#<%=txtDescripcion.ClientID%>").val().length;
                if (Descripcion < 1) {
                    alert("El campo Descripción no puede estar vacio.");
                    $("#<%=txtDescripcion.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Marca = $("#<%=txtMarca.ClientID%>").val().length;
                    if (Marca < 1) {
                        alert("El campo Marca no puede estar vacio.");
                        $("#<%=txtMarca.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var Modelo = $("#<%=txtModelo.ClientID%>").val().length;
                        if (Modelo < 1) {
                            alert("El campo Modelo no puede estar vacio.");
                            $("#<%=txtModelo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {

                            var Serie = $("#<%=txtSerie.ClientID%>").val().length;
                            if (Serie < 1) {
                                alert("El campo Serie no puede estar vacio.");
                                $("#<%=txtSerie.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var ValorAsegurado = $("#<%=txtValorAsegurado.ClientID%>").val().length;
                                if (ValorAsegurado < 1) {
                                    alert("El campo Valor Asegurado no puede estar vacio.");
                                    $("#<%=txtValorAsegurado.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                                else {
                                    var ValorReposicion = $("#<%=txtValorReposicion.ClientID%>").val().length;
                                    if (ValorReposicion < 1) {
                                        alert("El campo Valor de Reposición no puede estar vacio.");
                                        $("#<%=txtValorReposicion.ClientID%>").css("border-color", "red");
                                        return false;
                                    }
                                    else {
                                        var PorcientoDeducible = $("#<%=txtPorcientoDeducible.ClientID%>").val().length;
                                        if (PorcientoDeducible < 1) {
                                            alert("El campo Porciento Deducible no puede estar vacio.");
                                            $("#<%=txtPorcientoDeducible.ClientID%>").css("border-color", "red");
                                            return false;
                                        }
                                        else {
                                            var BaseDeducible = $("#<%=txtBAseDeducible.ClientID%>").val().length;
                                            if (BaseDeducible < 1) {
                                                alert("El campo Base de Deducible no puede estar vacio.");
                                                $("#<%=txtBAseDeducible.ClientID%>").css("border-color", "red");
                                                return false;
                                            }
                                            else {
                                                var MinimoDeducibble = $("#<%=txtMinimoDeducible.ClientID%>").val().length;
                                                if (MinimoDeducibble < 1) {
                                                    alert("El campo Minimo Deducible no puede estar vacio.");
                                                    $("#<%=txtMinimoDeducible.ClientID%>").css("border-color", "red");
                                                    return false;
                                                }
                                                else {
                                                    var PorcientoPrima = $("#<%=txtPorcientoDeducible.ClientID%>").val().length;
                                                    if (PorcientoPrima < 1) {
                                                        alert("El campo Porciento Prima no puede estar vacio.");
                                                        $("#<%=txtPorcientoDeducible.ClientID%>").css("border-color", "red");
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
                }
            });
        })
    </script>

    <div class="container-fluid">
        <div id="DIVBloqueConsulta" runat="server">
            <div id="DIvSubBloquePoliza" runat="server">
                <br />
                <div class="row">
                    <div class="col-md-3">
                        <label class="Letranegrita">No. Poliza</label>
                        <label class="Letranegrita Rojo">*</label>
                        <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtPolizaConsulta_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                     <div class="col-md-3">
                        <label class="Letranegrita">No. Item</label>
                        <asp:TextBox ID="txtNumeroItem" runat="server" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="ContenidoCentro">
                    <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultar_Click" CssClass="BotonImagen" />
                </div>
                <br />
            </div>
            <div id="DIVSubBloqueListado" runat="server">
                <br />
                <h3>
                    <label class="Seleccionar Item"></label>
                </h3>
                <br />
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Cliente</th>
                                <td> <asp:Label ID="lbDatoCliente" runat="server" Text="Dato"></asp:Label> </td>
                            </tr>
                            <tr>
                                <th scope="col">Supervisor</th>
                                <td> <asp:Label ID="lbDatoSupervisor" runat="server" Text="Dato"></asp:Label> </td>
                            </tr>
                            <tr>
                                <th scope="col">Intermediario</th>
                                <td> <asp:Label ID="lbDatoIntermediario" runat="server" Text="Dato"></asp:Label> </td>
                            </tr>
                            <tr>
                                <th scope="col">Total de Equipos Agregados</th>
                                <td> <asp:Label ID="lbDatoTotalEquipos" runat="server" Text="Dato"></asp:Label> </td>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class="table-responsive">
                    <table class="table table-striped">
                        <thead class="table-dark">
                            <tr>
                                <th scope="col"> Item </th>
                                <th scope="col" class="ContenidoCentro"> Total de Equipos </th>
                                <th scope="col" class="ContenidoDerecha"> Seleccionar </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpListadoItems" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <asp:HiddenField ID="hfCotizacion" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                        <asp:HiddenField ID="hfSecuencia" runat="server" Value='<%# Eval("Item") %>' />

                                        <td> <%# Eval("Item") %> </td>
                                        <td class="ContenidoCentro"> <%#string.Format("{0:N0}", Eval("CantidadEquipos")) %> </td>
                                        <td class="ContenidoDerecha"><asp:ImageButton ID="btnSeleccionar" runat="server" ToolTip="Seleccionar Registro" ImageUrl="~/ImagenesBotones/hacer-clic.png" OnClick="btnSeleccionar_Click" CssClass="BotonImagen" /></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <table class="table">
                        <tfoot class="table-light">
                            <tr>
                                <td class="ContenidoDerecha">
                                    <label class="Letranegrita">Pagina</label> <asp:Label ID="lbPaginaActual_Items" runat="server" Text="0"></asp:Label>
                                    <label class="Letranegrita">De</label> <asp:Label ID="lbCantidadPagina_Item" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                 <div id="DivPaginacion_Header" runat="server" align="center">
                <div style="margin-top: 20px;">
                    <table style="width: 600px">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnPrimeraPagina_Item" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Item_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnPaginaAnterior_Item" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Item_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />
                            </td>
                            <td class="ContenidoCentrado">
                                <asp:DataList ID="dtPaginacion_Item" runat="server" OnItemCommand="dtPaginacion_Item_ItemCommand" OnItemDataBound="dtPaginacion_Item_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral_Item" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td>
                                <asp:ImageButton ID="btnSiguientePagina_Item" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_Item_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnUltimaPagina_Item" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Item_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
                <br />
            </div>
        </div>

        <div id="DIVBloqueEquiposElectronicos" runat="server">
             <asp:HiddenField ID="hfCotizacionSeleccionado" runat="server" />
             <asp:HiddenField ID="hfSecuenciaSeleccionado" runat="server" />

            <div id="DIVSubBloqueListadoEquiposAgregados" runat="server">
                <br />
            <h2 class="ContenidoCentro">Cantidad de Equipos Agregados</h2>
            <br />
            <h2 class="ContenidoCentro"><asp:Label ID="lbCantidadEquiposElectrinicos" runat="server" Text="0"></asp:Label></h2>
            <br />
                <div class="ContenidoCentro">
                    <asp:ImageButton ID="btnNuevoRegistro" runat="server" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" CssClass="BotonImagen" ToolTip="Crear Nuevo Registro" OnClick="btnNuevoRegistro_Click" /> 
                    <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/ImagenesBotones/Excel.png" CssClass="BotonImagen" ToolTip="Exportar Inventario a Excel" OnClick="btnExcel_Click" /> 
                    <asp:ImageButton ID="btnVolverAtras" runat="server" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" CssClass="BotonImagen" ToolTip="Volver Atras" OnClick="btnVolverAtras_Click" /> 
                </div>
                <br />
                <div class="table-responsive">
                    <table class="table table-striped">
                        <thead class="table-dark">
                            <tr>
                                <th scope="col"> Codigo </th>
                                <th scope="col"> Descripción </th>
                                <th scope="col"> Marca </th>
                                <th scope="col"> Modelo </th>
                                <th scope="col"> Serie </th>
                                <th scope="col" class="ContenidoCentro"> Asegurado </th>
                                <th scope="col" class="ContenidoCentro"> Reposición </th>
                                <th scope="col" class="ContenidoCentro"> % Deducible </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpListadoInventario" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <asp:HiddenField ID="hfCotizacion" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                        <asp:HiddenField ID="hfSecuencia" runat="server" Value='<%# Eval("Secuencia") %>' />

                                        <td> <%# Eval("IdEquipo") %> </td>
                                        <td> <%# Eval("Descripcion") %> </td>
                                        <td> <%# Eval("Marca") %> </td>
                                        <td> <%# Eval("Modelo") %> </td>
                                        <td> <%# Eval("Serie") %> </td>
                                        <td class="ContenidoCentro"> <%#string.Format("{0:N2}", Eval("ValorAsegurado")) %> </td>
                                        <td class="ContenidoCentro"> <%# Eval("ValorReposicion") %> </td>
                                        <td class="ContenidoCentro"> <%# Eval("PorcDeducible") %> </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <table class="table">
                        <tfoot class="table-light">
                            <tr>
                                <td class="ContenidoDerecha">
                                    <label class="Letranegrita">Pagina</label> <asp:Label ID="lbPaginaActual_Equipos" runat="server" Text="0"></asp:Label>
                                    <label class="Letranegrita">De</label> <asp:Label ID="lbCantidadPAginas_Equipos" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                 <div id="DivPaginacion_Equipos" runat="server" align="center">
                <div style="margin-top: 20px;">
                    <table style="width: 600px">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnPrimeraPagina_Equiposo" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Equiposo_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnAnterior_Equiposo" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnterior_Equiposo_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />
                            </td>
                            <td class="ContenidoCentrado">
                                <asp:DataList ID="dtEquipos" runat="server" OnItemCommand="dtEquipos_ItemCommand" OnItemDataBound="dtEquipos_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral_Equipos" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td>
                                <asp:ImageButton ID="btnSiguiente_Equiposo" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguiente_Equiposo_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnUltima_Equiposo" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltima_Equiposo_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
                <br />
            </div>

            <div id="DIVSubBloqueProcesarEquipos" runat="server">
                <br />
                <div class="row">
                    <div class="col-md-4">
                        <label class="Letranegrita"> Descripción </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="Letranegrita"> Marca </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="Letranegrita"> Modelo </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="150"></asp:TextBox>
                    </div>

                    <div class="col-md-4">
                        <label class="Letranegrita"> Serie </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtSerie" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="150"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="Letranegrita"> Valor Asegurado </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtValorAsegurado" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" step="0.01" ></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="Letranegrita"> Valor Reposición </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtValorReposicion" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" step="0.01" ></asp:TextBox>
                    </div>

                    <div class="col-md-4">
                        <label class="Letranegrita"> % Deducible </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtPorcientoDeducible" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" step="0.01" ></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="Letranegrita"> Base Deducible </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtBAseDeducible" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="50" ></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="Letranegrita"> Minimo Deducible </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtMinimoDeducible" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" step="0.01" ></asp:TextBox>
                    </div>

                    <div class="col-md-4">
                        <label class="Letranegrita"> % Prima </label>
                        <label class="Letranegrita Rojo"> * </label>
                        <asp:TextBox ID="txtPorcientoPrima" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" step="0.01" ></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="ContenidoCentro">
                    <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" ToolTip="Guardar" CssClass="BotonImagen" OnClick="btnGuardar_Click" />
                    <asp:ImageButton ID="btnVolver" runat="server" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" ToolTip="Guardar" CssClass="BotonImagen" OnClick="btnVolver_Click" />
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>

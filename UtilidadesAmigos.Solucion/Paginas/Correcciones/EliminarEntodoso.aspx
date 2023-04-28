<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="EliminarEntodoso.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Correcciones.EliminarEntodoso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        function PolizaNoEncontrada() {
            alert("No se encontraron registros con el numero de poliza ingresado, favor de verificar.");
        }
        function EndosoEliminado() {
            alert("Endoso Eliminado Con Exito.");
        }

        function RegistroDevuelto() {
            alert("Este registro ya fue restaurado.");
        }
        function RegistroRestaurado() {
            alert("Registro Restaurado con Exito.");
        }


        $(function () {

            $("#<%=btnBuscar.ClientID%>").click(function () {

                var Poliza = $("#<%=txtPolizaConsulta.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo Poliza no puede estar vacio para buscar este registro, favor de verificar.");
                    $("#<%=txtPolizaConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        })
    </script>

    <div id="DIVBloqueConsulta" runat="server">
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <div class="col-md-3">
                     <asp:Label ID="lbItemConsulta" runat="server" Text="No. item" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtItemConsulta" runat="server" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnBuscar" runat="server" ToolTip="Buscar registros" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnBuscar_Click" />
            <asp:ImageButton ID="btnHistorico" runat="server" ToolTip="Buscar Historico de Borrado de Endosos" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnHistorico_Click" />
        </div>
        <br />
        <table class="table table-striped">
            <thead class="table-dark">
                <tr>
                     <th scope="col"> Poliza </th>
                     <th scope="col"> Item </th>
                     <th scope="col"> Ramo </th>
                     <th scope="col"> Subramo </th>
                     <th scope="col"> Beneficiario </th>
                    <th class="ContenidoDerecha" scope="col"> Valor </th>
                     <th class="ContenidoDerecha" scope="col"> Entrar </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoEndosos" runat="server">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                            <asp:HiddenField ID="hfItem" runat="server" Value='<%# Eval("Item") %>' />
                            <asp:HiddenField ID="hfBeneficiario" runat="server" Value='<%# Eval("IdBeneficiario") %>' />

                            <td> <%# Eval("Poliza") %> </td>
                            <td> <%# Eval("Item") %> </td>
                            <td> <%# Eval("Ramo") %> </td>
                            <td> <%# Eval("Subramo") %> </td>
                            <td> <%# Eval("NombreBeneficiario") %> </td>
                            <td class="ContenidoDerecha"> <%#string.Format("{0:N2}", Eval("ValorEndosoCesion")) %> </td>
                            <td class="ContenidoDerecha"> <asp:ImageButton ID="btnSeleccionar" runat="server" ToolTip="Ingresar al registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/hacer-clic.png" OnClick="btnSeleccionar_Click" /> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
         <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">Pag
                            <asp:Label ID="lbPaginaActualVariable_Header" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                            de
                            <asp:Label ID="lbCantidadPaginaVariable_Header" runat="server" Text="0" CssClass="Letranegrita"></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
            <div id="DivPaginacion_Header" runat="server" align="center">
                <div style="margin-top: 20px;">
                    <table style="width: 600px">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnPrimeraPagina_Header" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Header_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnPaginaAnterior_Header" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Header_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />
                            </td>
                            <td class="ContenidoCentrado">
                                <asp:DataList ID="dtPaginacion_Header" runat="server" OnItemCommand="dtPaginacion_Header_ItemCommand" OnItemDataBound="dtPaginacion_Header_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral_Header" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td>
                                <asp:ImageButton ID="btnSiguientePagina_Header" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_Header_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnUltimaPagina_Header" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Header_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
    <br />
    </div>
    <div id="DivBloqueProceso" runat="server">
        <asp:Label ID="lbCotizacion_Proceso" runat="server" Text="0" Visible="false"></asp:Label>
        <asp:Label ID="lbSecuencia_Proceso" runat="server" Text="0" Visible="false"></asp:Label>
        <asp:Label ID="lbIdbeneficiario_Proceso" runat="server" Text="0" Visible="false"></asp:Label>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbPolizaProceso" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaProceso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbRamoProceso" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtRamoProceso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbSubRamoProceso" runat="server" Text="Sub Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtSubRamoProceso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbItemProceso" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtItemProceso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbfechaInicioVigenciaProceso" runat="server" Text="Inicio Vigencia" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaInicioVigenciaProceso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbFechaFinVigenciaProceso" runat="server" Text="Fin Vigencia" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaFinVigenciaProceso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbBeneficiarioProceso" runat="server" Text="Beneficiario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtBeneficiarioProceso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbValorEndosoProceso" runat="server" Text="Valor Endoso" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtValorEndosoProceso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnEliminar" runat="server" ToolTip="Borrar Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/borrar.png" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Quieres Eliminar Este Registro?');" />
             <asp:ImageButton ID="btnVolverAtras" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverAtras_Click" />
        </div>
        <br />
    </div>
    <div id="DivBloqueHistorico" runat="server">
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbPoliza_Historial" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza_Historial" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbItem_Historial" runat="server" Text="No. Item" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtItem_Historial" runat="server" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled" ></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbfechaDesde_Historial" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde_Historial" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled" ></asp:TextBox>
            </div>
            <div class="col-md-3">
                 <asp:Label ID="lbFechaHasta_Historial" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta_Historial" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled" ></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnBuscar_Historial" runat="server" ToolTip="Buscar Registros" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnBuscar_Historial_Click" />
             <asp:ImageButton ID="btnVolver_Historial" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverAtras_Click" />
        </div>
        <br />
        <table class="table table-striped">
            <thead class="table-dark">
                <tr>
                    <th scope="col"> Poliza </th>
                    <th scope="col"> Item </th>
                    <th scope="col"> Beneficiario </th>
                    <th scope="col" class="ContenidoDerecha"> Valor </th>
                    <th scope="col"> Elimino </th>
                    <th scope="col"> Fecha </th>
                    <th scope="col"> Estatus </th>
                    <th scope="col" class="ContenidoDerecha" > Restaurar </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpHistorial" runat="server">
                    <ItemTemplate>
                        <tr>

                            <asp:HiddenField ID="hfIdRegistroHistorial" runat="server" Value='<%# Eval("IdRegistro") %>' />

                             <td> <%# Eval("Poliza") %> </td>
                             <td> <%# Eval("Secuencia") %> </td>
                             <td> <%# Eval("NombreBeneficiario") %> </td>
                             <td class="ContenidoDerecha"> <%#string.Format("{0:N2}", Eval("ValorEndosoCesion")) %> </td>
                             <td> <%# Eval("EliminadoPor") %> </td>
                             <td> <%# Eval("FechaProcesoElimina") %> </td>
                             <td> <%# Eval("Estatus") %> </td>
                             <td class="ContenidoDerecha"> <asp:ImageButton ID="btnRestaurar_Historial" runat="server" ToolTip="Restaurar Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Restaurar.png" OnClick="btnRestaurar_Historial_Click" OnClientClick="return confirm('¿Quieres Restaurar Este Registro?');" /> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
         <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">Pag
                            <asp:Label ID="lbPaginaActualVariable_Historial" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                            de
                            <asp:Label ID="lbCantidadPaginaVariable_Historial" runat="server" Text="0" CssClass="Letranegrita"></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
            <div id="DivPaginacion_Historial" runat="server" align="center">
                <div style="margin-top: 20px;">
                    <table style="width: 600px">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnPrimeraPagina_Historial" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Historial_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnPaginaAnterior_Historial" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Historial_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />
                            </td>
                            <td class="ContenidoCentrado">
                                <asp:DataList ID="dtPaginacion_Historial" runat="server" OnItemCommand="dtPaginacion_Historial_ItemCommand" OnItemDataBound="dtPaginacion_Historial_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral_Historial" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td>
                                <asp:ImageButton ID="btnSiguientePagina_Historial" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_Historial_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnUltimaPagina_Historial" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Historial_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
    </div>
</asp:Content>

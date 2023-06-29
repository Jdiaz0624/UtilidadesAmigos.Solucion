<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoDependientes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoDependientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />


    <script type="text/javascript">
        function OpcionNoDisponible() { alert("Esta Opción esta en desarrollo por el momento."); }
        $(function () {

            $("#<%=btnConsultarRegistros.ClientID%>").click(function () {
                var Poliza = $("#<%=txtNumeroPolizaConuslta.ClientID%>").val().length;
                  if (Poliza < 1) {
                      alert("El campo Poliza no puede estar vacio para buscar dependientes, favor de verificar.");
                      $("#<%=txtNumeroPolizaConuslta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

            $("#<%=btnExportarInformacion.ClientID%>").click(function () {
                var Poliza = $("#<%=txtNumeroPolizaConuslta.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo Poliza no puede estar vacio para Exportar dependientes, favor de verificar.");
                    $("#<%=txtNumeroPolizaConuslta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        })
    </script>
    <div class="container-fluid">
        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <div id="DIVBloqueCOnsulta" runat="server">
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lbNumeroPolizaConsulta" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroPolizaConuslta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="ContenidoCentro">
                   <asp:ImageButton ID="btnConsultarRegistros" runat="server" OnClick="btnConsultarRegistros_Click" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" />
                    <asp:ImageButton ID="btnExportarInformacion" runat="server" OnClick="btnExportarInformacion_Click" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Excel.png" />
                    <asp:ImageButton ID="btnAgregarDependiente" runat="server" Visible="false" OnClick="btnAgregarDependiente_Click" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" />
            </div>
         
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Nombre </th>
                        <th scope="col"> Parentezco </th>
                        <th scope="col"> Cedula </th>
                        <th scope="col"> Fecha Nac </th>
                        <th scope="col"> Sexo </th>
                        <th scope="col"> Prima </th>
                        <th class="ContenidoDerecha" scope="col"> Editar </th>
                        <th class="ContenidoDerecha" scope="col"> Borrar </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadodepenientes" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroCotizacion" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                <asp:HiddenField ID="hfIdAsegurao" runat="server" Value='<%# Eval("IdAsegurado") %>' />

                                <td> <%# Eval("Nombre") %> </td>
                                <td> <%# Eval("Parentezco") %> </td>
                                <td> <%# Eval("Cedula") %> </td>
                                <td> <%# Eval("FechaNacimiento") %> </td>
                                <td> <%# Eval("Sexo") %> </td>
                                <td> <%#string.Format("{0:N2}", Eval("PorcPrima")) %> </td>
                                <td class="ContenidoDerecha"> <asp:ImageButton ID="btnEditarRegistro" runat="server" ToolTip="Editar Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" OnClick="btnEditarRegistro_Click" /> </td>
                                <td class="ContenidoDerecha"> <asp:ImageButton ID="btnBorrarRegistro" runat="server" ToolTip="Borrar Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/borrar.png" OnClick="btnBorrarRegistro_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">
                            <b>Pagina </b>  <asp:Label ID="lbPaginaActualVariableDependientes" runat="server" Text=" 0 "></asp:Label> <b> De </b>  <asp:Label ID="lbCantidadPaginaVAriableDependientes" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoIzquierda">
                            <b>Estatus: </b> <asp:Label ID="lbEstatusPolizaVariable" runat="server" Text=" "></asp:Label>
                        </td>
                    </tr>

                     <tr>
                        <td class="ContenidoIzquierda">
                            <b>Ramo: </b> <asp:Label ID="lbRamoVariable" runat="server" Text=" " ></asp:Label>
                        </td>
                    </tr>

                     <tr>
                        <td class="ContenidoIzquierda">
                            <b>Sub Ramo: </b> <asp:Label ID="lbSubRamoVariable" runat="server" Text=" "></asp:Label>
                        </td>
                    </tr>
                </tfoot>
            </table>
            <div id="DivPaginacion_Header" runat="server" align="center">
                <div style="margin-top: 20px;">
                    <table style="width: 600px">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnPrimeraPagina" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnPaginaAnterior" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />
                            </td>
                            <td class="ContenidoCentrado">
                                <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td>
                                <asp:ImageButton ID="btnSiguientePaginar" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePaginar_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnUltimaPagina" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
                           <br />
        </div>
        <div id="DIVBloqueMantenimiento" runat="server"></div>
    </div>

</asp:Content>

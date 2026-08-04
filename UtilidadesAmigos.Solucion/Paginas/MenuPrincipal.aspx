<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MenuPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <link href="../Content/EstilosComunes.css" rel="stylesheet" />

    <script type="text/javascript">
        function Mensaje() {
            alert("Tienes que seleccionar una opción para realizar actualizar esta información.");
        }

        function MensajeNotificacion() {
            alert("No se encontrarón registros para generar este archivo, favor de validar.");
        }
    </script>


    <div class="container-fluid">

       <!-- Bloque Imagen -->
<div id="DIVBloqueImagen" runat="server" class="mb-5">
    <div class="container-fluid Imagenesxx">
        <div id="carouselExampleControls" class="carousel slide shadow rounded-3 overflow-hidden" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="../Imagenes/Logo.jpg" class="d-block w-100" alt="Logo Futuro Seguros" />
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Anterior</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Siguiente</span>
            </button>
        </div>
    </div>
</div>

<!-- Bloque Remodelación -->
<div id="DIvBloqueRemodelacion" runat="server" class="card shadow-lg border-0 rounded-3 mb-5">
    <div class="card-header bg-warning text-dark fw-bold">
        <i class="fa fa-tools"></i> Aviso de Remodelación
    </div>
    <div class="card-body text-center">
        <h5 class="mb-3">Se están realizando ajustes a la parte de estadística de renovación. Se notificará una vez esté disponible.</h5>
        <img src="../Imagenes/remodelacion.jpg" class="img-fluid rounded" alt="Remodelación" />
    </div>
</div>

<!-- Bloque Notificaciones -->
<div id="DIVBloqueNotificacionesReclamaciones" runat="server" class="card shadow-lg border-0 rounded-3">
    <div class="card-header bg-primary text-white">
        <h5 class="mb-0"><i class="fa fa-bell"></i> Notificación de estatus a reclamos</h5>
    </div>
    <div class="card-body">
        <div class="table-responsive">
            <table class="table table-striped table-hover align-middle mb-0">
                <thead class="table-dark">
                    <tr>
                        <th class="ContenidoIzquierda">Estatus</th>
                        <th class="ContenidoCentro">Días Notificación</th>
                        <th class="ContenidoCentro">Registros Encontrados</th>
                        <th class="ContenidoDerecha">Exportar</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpNotificaciones" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfCodigoEstatus" runat="server" Value='<%# Eval("IdEstatus") %>' />
                                <asp:HiddenField ID="hfNombreEstatus" runat="server" Value='<%# Eval("NombreEstatus") %>' />

                                <td class="ContenidoIzquierda"><%# Eval("NombreEstatus") %></td>
                                <td class="ContenidoCentro"><%# string.Format("{0:N0}", Eval("DiasNotificacion")) %></td>
                                <td class="ContenidoCentro"><%# string.Format("{0:N0}", Eval("ANotificar")) %></td>
                                <td class="ContenidoDerecha">
                                    <asp:ImageButton ID="btnExportarReclamaciones" runat="server" 
                                        ImageUrl="~/ImagenesBotones/Excel.png" CssClass="BotonImagen" 
                                        ToolTip="Exportar Información" OnClick="btnExportarReclamaciones_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot class="table-light">
                    <tr>
                        <td colspan="4" class="ContenidoDerecha">
                            <span class="fw-bold">Página</span> 
                            <asp:Label ID="lbPaginaActual" runat="server" Text="0" CssClass="fw-bold text-primary"></asp:Label>
                            <span class="fw-bold">de</span> 
                            <asp:Label ID="lbCantidadPagina" runat="server" Text="0" CssClass="fw-bold text-primary"></asp:Label>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>

        <!-- Paginación -->
        <div id="DivPaginacionNotificacion" runat="server" class="text-center mt-4">
            <table class="mx-auto">
                <tr>
                    <td><asp:ImageButton ID="btnPrimeraPagina" runat="server" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" OnClick="btnPrimeraPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Página" /></td>
                    <td><asp:ImageButton ID="btnPaginaAnterior" runat="server" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" OnClick="btnPaginaAnterior_Click" CssClass="BotonImagen" ToolTip="Ir a la Página Anterior" /></td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacion" runat="server" OnCancelCommand="dtPaginacion_CancelCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark btn-sm" />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td><asp:ImageButton ID="btnSiguientePagina" runat="server" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" OnClick="btnSiguientePagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Página Siguiente" /></td>
                    <td><asp:ImageButton ID="btnUltimaPagina" runat="server" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" OnClick="btnUltimaPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Última Página" /></td>
                </tr>
            </table>
        </div>
    </div>
</div>
     </div>

</asp:Content>

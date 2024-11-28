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

        <div id="DIVBloqueImagen" runat="server">

        
    <br /><br />

<div class="container-fluid Imagenesxx">
    <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
  <div class="carousel-inner">

     <div class="carousel-item active">
      <img src="../Imagenes/Logo.jpg" class="d-block w-100" alt="..." />
    </div>
  </div>

  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>




</div>

        <br />
        <br />

            </div>


 

        <div id="DIvBloqueRemodelacion" runat="server">
            <h1>Se estan realizando algunos ajustes a la parte de estadistica de renovación, se notificara una vez este disponible.</h1>
             <img src="../Imagenes/remodelacion.jpg" class="d-block w-100" alt="..." />
        </div>

        <div id="DIVBloqueNotificacionesReclamaciones" runat="server">
            <br />
            <div class="table table-responsive">
                <table class="table">
                    <thead class="table-light">
                        <tr>
                            <th class="ContenidoCentro">
                                <h3>Notificación de estatus a reclamos</h3>
                            </th>
                        </tr>
                    </thead>
                </table>
                <hr />
                <table class="table table-striped">
                    <thead class="table-dark">
                        <tr>
                             <th class="ContenidoIzquierda" scope="col"> Estatus </th>
                             <th class="ContenidoCentro" scope="col"> Dias Notificación </th>
                             <th class="ContenidoCentro" scope="col"> Registros Encontrados </th>
                             <th class="ContenidoDerecha" scope="col""> Exportar </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpNotificaciones" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfCodigoEstatus" runat="server" Value='<%# Eval("IdEstatus") %>' />
                                     <asp:HiddenField ID="hfNombreEstatus" runat="server" Value='<%# Eval("NombreEstatus") %>' />


                                    <td class="ContenidoIzquierda"> <%# Eval("NombreEstatus") %> </td>
                                    <td class="ContenidoCentro"> <%#string.Format("{0:N0}", Eval("DiasNotificacion")) %> </td>
                                    <td class="ContenidoCentro"> <%#string.Format("{0:N0}", Eval("ANotificar")) %> </td>
                                    <td class="ContenidoDerecha"> <asp:ImageButton ID="btnExportarReclamaciones" runat="server" ImageUrl="~/ImagenesBotones/Excel.png" CssClass="BotonImagen" ToolTip="Exportar Información" OnClick="btnExportarReclamaciones_Click" /> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <table class="table">
                    <tfoot class="table-light">
                        <tr>
                            <td class="ContenidoDerecha">
                                <label class="Letranegrita">Pagina</label> <asp:Label ID="lbPaginaActual" runat="server" Text="0"></asp:Label>
                                <label class="Letranegrita">De</label> <asp:Label ID="lbCantidadPagina" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
             <div id="DivPaginacionNotificacion" runat="server" align="center" >
    <div style="margin-top=20px;">
        <table style="width:600px;">
            <tr>
                <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" OnClick="btnPrimeraPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" OnClick="btnPaginaAnterior_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                <td align="center">
                    <asp:DataList ID="dtPaginacion" runat="server" OnCancelCommand="dtPaginacion_CancelCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal" >
                        <ItemTemplate>
                            <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                        </ItemTemplate>
                    </asp:DataList>

                </td>
                <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" OnClick="btnSiguientePagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" OnClick="btnUltimaPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
               
            </tr>
        </table>
    </div>
</div>
        </div>
     </div>

</asp:Content>

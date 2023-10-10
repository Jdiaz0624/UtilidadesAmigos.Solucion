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
                        <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
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

        </div>
    </div>
</asp:Content>

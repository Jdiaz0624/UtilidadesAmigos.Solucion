<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="EliminarEntodoso.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Correcciones.EliminarEntodoso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <div id="DIVBloqueConsulta">
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
        <div class="ContenidoCentrado">
            <asp:ImageButton ID="btnBuscar" runat="server" ToolTip="Buscar registros" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnBuscar_Click" />
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
                            <td> <%#string.Format("{0:N2}", Eval("ValorEndosoCesion")) %> </td>
                            <td> <asp:ImageButton ID="btnSeleccionar" runat="server" ToolTip="Ingresar al registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/hacer-clic.png" OnClick="btnSeleccionar_Click" /> </td>
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
    <div id="DivBloqueProceso"></div>
    <div id="DivBloqueHistorico"></div>
</asp:Content>

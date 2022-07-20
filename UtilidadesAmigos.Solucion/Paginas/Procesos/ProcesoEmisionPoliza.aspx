﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProcesoEmisionPoliza.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.ProcesoEmisionPoliza" %>
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
        
       .BotonImagen {
         width:40px;
         height:40px;
       
       }
    </style>
    <div class="container-fluid">
        <br />
        <div id="DIVBloqueConsulta" runat="server">
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lbNumeroRegistroConsulta" runat="server" Text="No. Registro" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroRegistroConsulyta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                 <div class="col-md-4">
                    <asp:Label ID="lbCodigoClienteConsulta" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoClienteConsulta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                 <div class="col-md-4">
                    <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtPolizaconsulta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
                <asp:ImageButton ID="btnNuevoRegistro" runat="server" ToolTip="Nuevo Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Agregar (2).png" OnClick="btnNuevoRegistro_Click"/>
                <asp:ImageButton ID="btnRestablecerPantalla" runat="server" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" ImageUrl="~/Imagenes/auto.png" OnClick="btnRestablecerPantalla_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Registro </th>
                        <th scope="col"> Cliente </th>
                        <th scope="col"> Poliza </th>
                        <th scope="col"> Estatus </th>
                        <th scope="col">  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpProcesoEmisionEncabezado" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroRegistroEncabezado" runat="server" Value='<%# Eval("") %>' />

                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <asp:ImageButton ID="btnEditarRegistro" runat="server" ToolTip="Editar Registro" ImageUrl="~/Imagenes/Editar.png" CssClass="BotonImagen" OnClick="btnEditarRegistro_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
             <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina </b> <asp:Label ID="lbPaginaActual" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> <b>De </b>   <asp:Label ID="lbCantidadPagina" runat="server" Text="0" CssClass="Letranegrita"></asp:Label> </td>
                    </tr>
                </tfoot>
            </table>
              <div id="DivPaginacionHeader" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPaginaHeader" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaHeader_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnteriorHeader" runat="server" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnteriorHeader_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipalHeader" runat="server" OnCancelCommand="dtPaginacionListadoPrincipalHeader_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipalHeader_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentralHeader" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePaginaHeader" runat="server" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePaginaHeader_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPaginaHeader" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPaginaHeader_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
        <br />
        </div>
        <div id="DIVBloqueNuevoRegistro" runat="server">
            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbCodigoClienteNuevoRegistro" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoClienteNuevoRegistro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCodigoClienteNuevoRegistro_TextChanged" TextMode="Number" MaxLength="20" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                 <div class="col-md-6">
                    <asp:Label ID="lbNombreClienteNuevoRegistro" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreClienteNuevoRegistro" runat="server" CssClass="form-control" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <br />
             <div align="center">
                <asp:ImageButton ID="btnGaurdarNuevoRegistro" runat="server" ToolTip="Guardar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/salvar.png" OnClick="btnGaurdarNuevoRegistro_Click" />
                <asp:ImageButton ID="btnVolverAtras" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/Imagenes/volver-flecha.png" OnClick="btnVolverAtras_Click"/>
            </div>
            <br />
        </div>
        <div id="DIvBloqueModificarRegistro" runat="server">
            <br />
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lbNumeroRegistroEditar" runat="server" Text="Registro no." CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroregistroEditar" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbClienteEditar" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClienteEditar" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbNombreEditar" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreEditar" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbPolizaEditar" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtPolizaEditar" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="form-check-inline">
                <asp:Label ID="lbSeguimiento" runat="server" Text="Seguimiento de Caso" CssClass="LetrasNegrita"></asp:Label> <br /><hr />
                <asp:CheckBox ID="cbClienteCreadoEditar" runat="server" Text="Cliente Creado" CssClass="LetrasNegrita" ToolTip="Cliente Creado" /> <br />
                <asp:CheckBox ID="cbDocumentosRevisados" runat="server" AutoPostBack="true" OnCheckedChanged="cbDocumentosRevisados_CheckedChanged" Text="Documentos Revisados" CssClass="LetrasNegrita" ToolTip="Documentos Recibidos" /> <br />
                <asp:CheckBox ID="cbEmisionPoliza" runat="server" AutoPostBack="true" OnCheckedChanged="cbEmisionPoliza_CheckedChanged" Text="Emisión de Poliza" CssClass="LetrasNegrita" ToolTip="Emisión de Poliza" /> <br />
                <asp:CheckBox ID="cbSegundaRevision" runat="server" AutoPostBack="true" OnCheckedChanged="cbSegundaRevision_CheckedChanged" Text="Segunda Revisión" CssClass="LetrasNegrita" ToolTip="Segunda Revisión" /> <br />
                <asp:CheckBox ID="cbImpresiónMarbete" runat="server" AutoPostBack="true" OnCheckedChanged="cbImpresiónMarbete_CheckedChanged" Text="Impresión de Marbete" CssClass="LetrasNegrita" ToolTip="Impresión de Marbete" /> <br />
                <asp:CheckBox ID="cbPolizaDespachada" runat="server" AutoPostBack="true" OnCheckedChanged="cbPolizaDespachada_CheckedChanged" Text="Poliza Despachada" CssClass="LetrasNegrita" ToolTip="Poliza Despachada" /> 
            </div>
            <br />
             <div align="center">
                <asp:ImageButton ID="btnEditarRegistro" runat="server" ToolTip="Editar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/salvar.png" OnClick="btnEditarRegistro_Click1" />
                <asp:ImageButton ID="btnColverAtrasEditarRegistro" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/Imagenes/volver-flecha.png" OnClick="btnColverAtrasEditarRegistro_Click"/>
            </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Registro </th>
                        <th scope="col"> Estatus </th>
                        <th scope="col"> Fecha </th>
                        <th scope="col"> Hora </th>
                        <th scope="col"> Usuario </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpProcesoEmisionDetalle" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
             <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina </b> <asp:Label ID="lbPaginaActualDetalle" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> <b>De </b>   <asp:Label ID="Label1" runat="server" Text="0" CssClass="Letranegrita"></asp:Label> </td>
                    </tr>
                </tfoot>
            </table>
              <div id="DivPaginacionDetalle" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPaginaDetalle" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaDetalle_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnteriorDetalle" runat="server" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnteriorDetalle_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipalDetalle" runat="server" OnCancelCommand="dtPaginacionListadoPrincipalDetalle_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipalDetalle_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentralDetalle" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePaginaDetalle" runat="server" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePaginaDetalle_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPaginaDetalle" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPaginaDetalle_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
        <br />
        </div>
    </div>
</asp:Content>

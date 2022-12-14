<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="CartaCancelacion.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.CartaCancelacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style type="text/css">

        .btn-sm{
            width:90px;
        }

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        
        .BotonEspecial {
           width:100%;
           font-weight:bold;
          }

       

        .BotonSolicitud {
               width:50px;
               height:50px;
           }
        .BotonImagen {
               width:40px;
               height:40px;
           }
    </style>

    <div class="container-fluid">
        <br />
        <div class="form-check-inline">
            <asp:Label ID="lbTipoCartaGenerar" runat="server" Text="Carta a Generar: " CssClass="Letranegrita"></asp:Label>
            <asp:RadioButton id="rbCartaCancelacionAsegurado" runat="server" Text="Asegurado" GroupName="CartaCancelacion" AutoPostBack="true" OnCheckedChanged="rbCartaCancelacionAsegurado_CheckedChanged" />
            <asp:RadioButton id="rbCartaCancelacionIntermediario" runat="server" Text="Intermediario" GroupName="CartaCancelacion" AutoPostBack="true" OnCheckedChanged="rbCartaCancelacionIntermediario_CheckedChanged" />
        </div>
        <br />
        <div id="DivBloqueCartaCancelacionAsegurado" runat="server">
            <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lbCodigoSupervisor_CartaAsegurado" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisor_CartaAsegurado" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_CartaAsegurado_TextChanged" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbNombreSupervisor_CartaAsegurado" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisor_CartaAsegurado" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbCodigoIntermediario_CartaAsegurado" runat="server" Text="Vendedor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediario_CartaAsegurado" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_CartaAsegurado_TextChanged" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbNombreIntermediario_CargaAsegurado" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario_CartaAsegurado" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbCodigoAsegurado_CartaAsegurado" runat="server" Text="Asegurado" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoAsegurado_CartaAsegurado" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoAsegurado_CartaAsegurado_TextChanged" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbNombreAsegurado_CartaAsegurado" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreAsegurado_CartaAsegurado" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbPoliza_CartaAsegurado" runat="server" Text="Póliza" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtPoliza_CartaAsegurado" runat="server"  CssClass="form-control"  AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbCantidadDias_CartaAsegurado" runat="server" Text="Dias" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtDias_CartaAsegurado" runat="server" TextMode="Number" CssClass="form-control"  AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Buscar Información" ImageUrl="~/Imagenes/Buscar.png" CssClass="BotonImagen" OnClick="btnConsultar_Click" />
                <asp:ImageButton ID="btnCartasEnLote" runat="server" ToolTip="Generar Cartas en Lote" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnCartasEnLote_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Asegurado </th>
                         <th scope="col"> Poliza </th>
                         <th scope="col"> Balance </th>
                         <th scope="col"> Vendedor </th>
                        <th scope="col"> Inicio </th>
                        <th scope="col"> Fin </th>
                        <th scope="col"> Dias </th>
                         <th scope="col">  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoCartaAsegurado" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfSupervisor_CartaAsegurado" runat="server" Value='<%# Eval("CodigoSupervisor") %>' />
                                <asp:HiddenField ID="hfIntermediario_CargaAsegurado" runat="server" Value='<%# Eval("CodigoIntermediario") %>' />
                                <asp:HiddenField ID="hfAsegurado_CartaIAsegurado" runat="server" Value='<%# Eval("CodigoAsegurado") %>' />
                                <asp:HiddenField ID="hfPoliza_CartaAsegurado" runat="server" Value='<%# Eval("Poliza") %>' />
                                <asp:HiddenField ID="hfNombreAsegurado_CartaAsegurado" runat="server" Value='<%# Eval("Asegurado") %>' />


                                 <td> <%# Eval("Asegurado") %> </td>
                                 <td> <%# Eval("Poliza") %> </td>
                                 <td> <%#string.Format("{0:n2}", Eval("BalanceNumerico")) %> </td>
                                 <td> <%# Eval("Intermediario") %> </td>
                                <td> <%# Eval("InicioVigencia") %> </td>
                                <td> <%# Eval("FinVigencia") %> </td>
                                <td> <%#string.Format("{0:n0}", Eval("CantidadDias")) %> </td>
                                 <td>  <asp:ImageButton ID="btnCartaAsegurado" runat="server" ToolTip="Generar Carta de Cancelación de Asegurado" ImageUrl="~/Imagenes/Reporte.png" CssClass="BotonImagen" OnClick="btnCartaAsegurado_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
             <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina</b> <asp:Label ID="lbPaginaActual_CartaAsegurado" runat="server" Text=" 0 "></asp:Label> <b>de</b> <asp:Label ID="lbCantidadPaginaVariable_CartaAsegurado" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
              <div id="divPaginacion_CartaAsegurado" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_CartaAsegurado" runat="server" ToolTip="Ir a la Primera Pagina del Listado" CssClass="BotonImagen" OnClick="btnPrimeraPagina_CartaAsegurado_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_CartaAsegurado" runat="server" ToolTip="Ir a la Pagina Anterior del Listado" CssClass="BotonImagen" OnClick="btnPaginaAnterior_CartaAsegurado_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>

                    <td>
                        <asp:DataList ID="dtPaginacion_CartaAsegurado" runat="server" OnItemCommand="dtPaginacion_CartaAsegurado_ItemCommand" OnItemDataBound="dtPaginacion_CartaAsegurado_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_CartaAsegurado" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnPaginaSiguiente_CartaAsegurado" runat="server" ToolTip="Ir a la Siguiente Pagina del Listado" CssClass="BotonImagen" OnClick="btnPaginaSiguiente_CartaAsegurado_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_CartaAsegurado" runat="server" ToolTip="Ir a la Ultima Pagina del Listado" CssClass="BotonImagen" OnClick="btnUltimaPagina_CartaAsegurado_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        </div>
        <div id="DIVBloqueCartaCancelacionIntermediario" runat="server">
            <br />
            <div class="row">
                 <div class="col-md-2">
                    <asp:Label ID="lbCodigoSupervisor_CartaIntermediario" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisor_CartaIntermediario" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_CartaIntermediario_TextChanged" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbNombreSupervisor_CartaIntermediario" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisor_CartaIntermediario" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbCodigoIntermediario_CartaIntermediario" runat="server" Text="Vendedor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediario_CartaIntermediario" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_CartaIntermediario_TextChanged" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbNombreIntermedirio_CartaIntermediario" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario_CartaIntermediario" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsukltar_CartaIntermediario" runat="server" ToolTip="Buscar Información" ImageUrl="~/Imagenes/Buscar.png" CssClass="BotonImagen" OnClick="btnConsukltar_CartaIntermediario_Click" />
            </div>
            <br />
              <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Supervisor </th>
                         <th scope="col"> Vendedor </th>
                         <th scope="col"> Balance </th>
                         <th scope="col">  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoCartaIntermediario" runat="server">
                        <ItemTemplate>
                            <tr>
                                 <asp:HiddenField ID="hfSupervisor_CartaIntermediario" runat="server" Value='<%# Eval("CodigoSupervisor") %>' />
                                 <asp:HiddenField ID="hfIntermediario_CartaIntermediario" runat="server" Value='<%# Eval("CodigoIntermediario") %>' />
                                <asp:HiddenField ID="hfNombreIntermediario" runat="server" Value='<%# Eval("Intermediario") %>' />


                                 <td> <%# Eval("Supervisor") %> </td>
                                 <td> <%# Eval("Intermediario") %> </td>
                                 <td> <%#string.Format("{0:n2}", Eval("SumatoriaPolizasBalancePendientePesos")) %> </td>
                                 <td>  <asp:ImageButton ID="btnCartaIntermediario" runat="server" ToolTip="Generar Carta de Cancelación de Asegurado" ImageUrl="~/Imagenes/Reporte.png" CssClass="BotonImagen" OnClick="btnCartaIntermediario_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
             <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina</b> <asp:Label ID="lbPaginaActual_CartaIntermediario" runat="server" Text=" 0 "></asp:Label> <b>de</b> <asp:Label ID="lbCantidadPaginaVariable_CartaIntermediario" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
            <div id="divPaginacion_CartaIntermediario" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_CartaIntermediario" runat="server" ToolTip="Ir a la Primera Pagina del Listado" CssClass="BotonImagen" OnClick="btnPrimeraPagina_CartaIntermediario_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_CartaIntermediario" runat="server" ToolTip="Ir a la Pagina Anterior del Listado" CssClass="BotonImagen" OnClick="btnPaginaAnterior_CartaIntermediario_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>

                    <td>
                        <asp:DataList ID="dtPaginacion_CartaIntermediario" runat="server" OnItemCommand="dtPaginacion_CartaIntermediario_ItemCommand" OnItemDataBound="dtPaginacion_CartaIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_CartaIntermediario" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnPaginaSiguiente_CartaIntermediario" runat="server" ToolTip="Ir a la Siguiente Pagina del Listado" CssClass="BotonImagen" OnClick="btnPaginaSiguiente_CartaIntermediario_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_CartaIntermediario" runat="server" ToolTip="Ir a la Ultima Pagina del Listado" CssClass="BotonImagen" OnClick="btnUltimaPagina_CartaIntermediario_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        </div>
    </div>
</asp:Content>

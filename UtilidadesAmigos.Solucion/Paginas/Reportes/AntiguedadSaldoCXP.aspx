<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AntiguedadSaldoCXP.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.AntiguedadSaldoCXP" %>
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
        <div id="DIVBloqueConsulta" runat="server">
            <br />
            <div class="form-check-inline">
                <asp:CheckBox ID="cbAgregarRangoFecha" runat="server" Text="Agregar Rango de Fecha" ToolTip="Consultar utilizando el rango de fecha de las facturas" CssClass="Letranegrita" AutoPostBack="true" OnCheckedChanged="cbAgregarRangoFecha_CheckedChanged" />
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lbFechaCorte" runat="server" Text="Fecha Corte" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaCorte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbCodigoProveedor" runat="server" Text="Codigo Proveedor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoProveedor" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoProveedor_TextChanged" ></asp:TextBox>
                </div>
                  <div class="col-md-6">
                    <asp:Label ID="lbNombreProveedor" runat="server" Text="Nombre Proveedor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreProveedor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                 <div class="col-md-4">
                    <asp:Label ID="lbDia" runat="server" Text="Dias" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlDias" runat="server" ToolTip="Seleccionar agrupacion de dias" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbTipoDocumento" runat="server" Text="Tipo Documento" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" ToolTip="Seleccionar Tipo de Documento" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lbNumeroFactura" runat="server" Text="Factura" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroFactura" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div id="DivFechaDesde" runat="server" class="col-md-3">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div id="DivFechaHasta" runat="server" class="col-md-3">
                    <asp:Label ID="lbFechaHAsta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                 <div  class="col-md-3">
                    <asp:Label ID="lbnCF" runat="server" Text="NCF" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNCF" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsutar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" OnClick="btnConsutar_Click" ImageUrl="~/Imagenes/Buscar.png" />
                <asp:ImageButton ID="btnExportarExcel" runat="server" ToolTip="Exportar Informacion a Excel Plano" CssClass="BotonImagen" OnClick="btnExportarExcel_Click" ImageUrl="~/Imagenes/excel.png" />
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Gererar Reporte de Antiguedad de Saldo de CXP" CssClass="BotonImagen" OnClick="btnReporte_Click" ImageUrl="~/Imagenes/Reporte.png" />
                <asp:ImageButton ID="btnGrupo" runat="server" ToolTip="Agregar Proveedores a Grupo de Dias" CssClass="BotonImagen" OnClick="btnGrupo_Click" ImageUrl="~/Imagenes/Dias.png" />
                <asp:ImageButton ID="btnExcluir" runat="server" ToolTip="Excluir Factura" CssClass="BotonImagen" OnClick="btnExcluir_Click" ImageUrl="~/Imagenes/Excluir.png" />
                <asp:ImageButton ID="btnRestabelcerPantalla" runat="server" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" OnClick="btnRestabelcerPantalla_Click" ImageUrl="~/Imagenes/auto.png" />
            </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Proveedor </th>
                        <th scope="col"> Factura </th>
                        <th scope="col"> Tipo </th>
                        <th scope="col"> Fecha </th>
                        <th scope="col"> Valor </th>
                        <th scope="col">  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpAntiguedadSaldoCXP" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfProveedor" runat="server" Value='<%# Eval("Proveedor") %>' />
                                <asp:HiddenField ID="hfNumeroFactura" runat="server" Value='<%# Eval("Factura") %>' />
                                <asp:HiddenField ID="hfTipoDocumento" runat="server" Value='<%# Eval("Tipo") %>' />
                                <asp:HiddenField ID="hfNCF" runat="server" Value='<%# Eval("Ncf") %>' />

                                <td> <%# Eval("NombreProveedor") %> </td>
                                <td> <%# Eval("Factura") %> </td>
                                <td> <%# Eval("Descripcion") %> </td>
                                <td> <%# Eval("Fecha") %> </td>
                                <td> <%#string.Format("{0:N2}", Eval("Valor")) %> </td>
                                <td align="left" > <asp:ImageButton ID="btnSeleccionar" runat="server" ToolTip="Seleccionar Registro" CssClass="BotonImagen" OnClick="btnSeleccionar_Click" ImageUrl="~/Imagenes/Seleccionar2.png" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina</b> <asp:Label ID="lbPaginaActual_Antiguedad" runat="server" Text=" 0 "></asp:Label> <b>de</b> <asp:Label ID="lbCantidadPaginaVariable_Antiguedad" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
              <div id="divPaginacion_Antiguedad" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_Antiguedad" runat="server" ToolTip="Ir a la Primera Pagina del Listado" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Antiguedad_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_Antiguedad" runat="server" ToolTip="Ir a la Pagina Anterior del Listado" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Antiguedad_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>

                    <td>
                        <asp:DataList ID="dtPaginacion_Antiguedad" runat="server" OnItemCommand="dtPaginacion_Antiguedad_ItemCommand" OnItemDataBound="dtPaginacion_Antiguedad_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_Antiguedad" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnPaginaSiguiente_Antiguedad" runat="server" ToolTip="Ir a la Siguiente Pagina del Listado" CssClass="BotonImagen" OnClick="btnPaginaSiguiente_Antiguedad_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_Antiguedad" runat="server" ToolTip="Ir a la Ultima Pagina del Listado" CssClass="BotonImagen" OnClick="btnUltimaPagina_Antiguedad_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        </div>

        <div id="DIVBloqueProceso" runat="server"></div>
    </div>
</asp:Content>

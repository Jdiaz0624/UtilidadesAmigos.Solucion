<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteReclamaciones.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReporteReclamaciones" %>
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

        .BotonImagen {
                width:40px;
                height:40px;
           }
    </style>

    <div class="container-fluid">
        <div id="DIVBloqueConsulta" runat="server">
            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbReclamacion" runat="server" Text="Reclamacion" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtReclamacion" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbPoliza" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtPoliza" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbEstatusReclamacion" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlEstatusReclamacion" runat="server"  AutoCompleteType="Disabled" ToolTip="Estatus de Reclamación" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbTipoReclamacion" runat="server" Text="Tipo de Reclamación" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlTipoReclamacion" runat="server" AutoCompleteType="Disabled" ToolTip="Tipo de Reclamación" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisor" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisor" runat="server" AutoCompleteType="Disabled" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediario" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario" runat="server" AutoCompleteType="Disabled" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>

            </div>
            <br />
            <div class="form-check-inline">
                <asp:Label ID="lbFormatoReporte" runat="server" Text="Formato de Reporte: " CssClass="Letranegrita"></asp:Label> 
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" ToolTip="Generar Reporte en PDF" GroupName="FormatoReporte" />
                <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" ToolTip="Generar Reporte en Excel" GroupName="FormatoReporte" />
                <asp:RadioButton ID="rbExelPlano" runat="server" Text="Excel Plano" ToolTip="Generar Reporte en Excel Plano" GroupName="FormatoReporte" />
            </div>


            <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Informacion" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
            </div>
            <br />

            <table class="table table-striped">
                <thead class="table table-dark">
                    <tr>
                        <th scope="col"> RECLAMACION </th>
                        <th scope="col"> POLIZA </th>
                        <th scope="col"> ITEM </th>
                        <th scope="col"> RECLAMANTE </th>
                        <th scope="col"> FECHA </th>
                        <th scope="col"> ESTATUS </th>
                        <th scope="col"> TIPO </th>
                        <th scope="col"> Ver </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoReclamos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfReclamacion" runat="server" Value='<%# Eval("Reclamacion") %>' />
                                <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                                <asp:HiddenField ID="hfItem" runat="server" Value='<%# Eval("Item") %>' />
                                <asp:HiddenField ID="hfRamo" runat="server" Value='<%# Eval("Ramo") %>' />
                                <asp:HiddenField ID="hfSubramo" runat="server" Value='<%# Eval("SubRamo") %>' />

                                <td> <%# Eval("Reclamacion") %> </td>
                                <td> <%# Eval("Poliza") %> </td>
                                <td> <%# Eval("Item") %> </td>
                                <td> <%# Eval("Reclamante") %> </td>
                                <td> <%# Eval("FechaApertura") %> </td>
                                <td> <%# Eval("EstatusReclamacion") %> </td>
                                <td> <%# Eval("TipoReclamacion") %> </td>
                                <td> <asp:ImageButton ID="btnDetalleReclamo" runat="server" ToolTip="Ver Detalle de Reclamo" CssClass="BotonImagen" ImageUrl="~/Imagenes/pdf.png" OnClick="btnDetalleReclamo_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

             <div align="center">
                <asp:Label ID="lbPaginaActualTitulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavle" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTitulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPaginaReclamaciones" runat="server" ToolTip="Ir a la Primera Pagina del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaReclamaciones_Click" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnteriorReclamaciones" runat="server" ToolTip="Ir a la Pagina Anterior del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnteriorReclamaciones_Click" /> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionReclamaciones" runat="server" OnItemCommand="dtPaginacionReclamaciones_ItemCommand" OnItemDataBound="dtPaginacionReclamaciones_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralReclamaciones" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    
                    <td> <asp:ImageButton ID="btnPaginaSiguienteReclamaciones" runat="server" ToolTip="Ir a la Pagina Siguiente del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnPaginaSiguienteReclamaciones_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPaginaReclamaciones" runat="server" ToolTip="Ir a la Ultima Pagina del Listado" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPaginaReclamaciones_Click" /> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
              </div>
        </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteImpresionMarbetes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReporteImpresionMarbetes" %>
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
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
             <div class="col-md-3">
                  <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-md-3">
                  <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="col-md-1">
                  <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
             <div class="col-md-5">
                  <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
             <div class="col-md-1">
                  <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediario" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
             <div class="col-md-5">
                  <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
             <div class="col-md-2">
                  <asp:Label ID="lbCodigoCliente" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoCliente" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoCliente_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
             <div class="col-md-4">
                  <asp:Label ID="lbNombreCliente" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlRamo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbSubRamo" runat="server" Text="Sub Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSubramo" runat="server" ToolTip="Seleccionar Sub Ramo" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            <asp:Label ID="lbFormatoreporte" runat="server" Text="Formato: " CssClass="LetrasNegrita"></asp:Label>
            <asp:RadioButton ID="rbFormatoReporte" runat="server" Text="PDF" GroupName="FormatoReporte" ToolTip="Generar Reporte en PDF" />
             <asp:RadioButton ID="rbFormatoExcel" runat="server" Text="Excel" GroupName="FormatoReporte" ToolTip="Generar Reporte en Excel" />
             <asp:RadioButton ID="rbFormatoExcelPlano" runat="server" Text="Excel Plano" GroupName="FormatoReporte" ToolTip="Generar Reporte en Excel Plano" />
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnMostrarPorPantalla" runat="server" CssClass="BotonImagen" ToolTip="Buscar Por Pantalla" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnMostrarPorPantalla_Click" />
            <asp:ImageButton ID="btnGenerarReporte" runat="server" CssClass="BotonImagen" ToolTip="Generar Reporte" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnGenerarReporte_Click" />
        </div>
        <br />
        <table class="table table-striped">
            <thead class="table-dark">
                <tr>
                    <th scope="col"> Poliza </th>
                    <th scope="col"> Cliente </th>
                    <th scope="col"> Supervisor </th>
                    <th scope="col"> Intermediario </th>
                    <th scope="col"> Fecha </th>
                    <th scope="col"> Hora </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoImpresionmarbete" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td> <%# Eval("Poliza") %> </td>
                            <td> <%# Eval("Cliente") %> </td>
                            <td> <%# Eval("Supervisor") %> </td>
                            <td> <%# Eval("Intermediario") %> </td>
                            <td> <%# Eval("FechaImpresion") %> </td>
                            <td> <%# Eval("HoraImpresion") %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
           <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td align="left"><b>Impresiones </b> <asp:Label ID="lbCantidadImpresiones" runat="server" Text=" 0 "></asp:Label></td>
                        <td align="right"><b>Pagina </b> <asp:Label ID="lbPaginaActual" runat="server" Text=" 0 "></asp:Label> <b>De </b>   <asp:Label ID="lbCantidadPagina" runat="server" Text="0"></asp:Label> </td>
                    </tr>
                </tfoot>
            </table>
              <div id="DivPaginacionListadoPrincipal" runat="server" align="center" >
                <div style="margin-top:20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnterior_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipal" runat="server" OnCancelCommand="dtPaginacionListadoPrincipal_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipal_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
        <br />
    </div>
</asp:Content>

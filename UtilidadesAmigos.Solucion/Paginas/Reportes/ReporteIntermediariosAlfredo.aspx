<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteIntermediariosAlfredo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReporteIntermediariosAlfredo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
     .jumbotron{
            color:#000000; 
            background:#1E90FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }

        .btn-sm{
            width:90px;
        }

        .LetrasNegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        

        th {
            background-color: dodgerblue;
            color: white;
        }
    </style>


    <br />

    <div id="DivBloqueReporte" runat="server">
       <div class="form-row">
           <div class="form-group col-md-3">
               <asp:Label ID="lbFechaDesdeReporte" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
               <asp:TextBox ID="txtFechaDesdeReporte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
           </div>

            <div class="form-group col-md-3">
               <asp:Label ID="lbFechaHastaReporte" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
               <asp:TextBox ID="txtFechaHastaReporte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
           </div>

           <div class="form-group col-md-3">
               <asp:Label ID="lbCodigoIntermediarioReporte" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
               <asp:TextBox ID="txtCodigoIntermediarioReporte" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioReporte_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
           </div>

            <div class="form-group col-md-3">
               <asp:Label ID="lbNombreIntermediarioReporte" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
               <asp:TextBox ID="txtNombreIntermediarioReprte" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
           </div>


       </div>
        <br />
        <asp:Label ID="lbExportarA" runat="server" Text="Exportar A:" CssClass="LetrasNegrita"></asp:Label>
        <div class="form-check-inline">
            
            <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="Exportar" CssClass="form-check-input" ToolTip="Generar Reporte en PDF" />
            <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="Exportar" CssClass="form-check-input" ToolTip="Generar Reporte en Excel" />
            <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano" GroupName="Exportar" CssClass="form-check-input" ToolTip="Generar Reporte en Excel Plano" />
        </div>
        <br />
        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Registros Por Pantalla" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnReporte" runat="server" Text="Reporte" ToolTip="Generar Reporte" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnReporte_Click" />
        </div>
        <br />
        <div align="center">
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariables" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbSeparador1" runat="server" Text=" | " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbTotalProduccionTitulo" runat="server" Text="Producción Total (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbTotalProduccionVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbTotalProduccionCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbSeradador2" runat="server" Text=" | " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="TotalCobradoTitulo" runat="server" Text="Total Cobrado (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="TotalCobradoVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="TotalCobradoCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <br />
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:30%" align="left"> INTERMEDIARIO </th>
                        <th style="width:15%" align="left"> PRODUCCION B. </th>
                        <th style="width:15%" align="left"> PRODUCCION N. </th>
                        <th style="width:15%" align="left"> COBRADO B. </th>
                        <th style="width:15%" align="left"> COBRADO N. </th>
                        <th style="width:10%" align="left"> COMISION </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoIntermediarios" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width:30%" align="left"> <%# Eval("") %> </td>
                                <td style="width:15%" align="left"> <%# string.Format("{0,n2}", Eval("")) %> </td>
                                <td style="width:15%" align="left"> <%# string.Format("{0,n2}", Eval("")) %> </td>
                                <td style="width:15%" align="left"> <%# string.Format("{0,n2}", Eval("")) %> </td>
                                <td style="width:15%" align="left"> <%# string.Format("{0,n2}", Eval("")) %> </td>
                                <td style="width:10%" align="left"> <%# string.Format("{0,n2}", Eval("")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div align="center">
                <asp:Label ID="lbPaginaActualTituloControlVisistas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableControlVisistas" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloControlVisistas" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableControlVisistas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionControlVisistas" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaReporteIntermediariosEspecial" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaReporteIntermediariosEspecial_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorReporteIntermediariosEspecial" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorReporteIntermediariosEspecial_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionReporteIntermediariosEspecial" runat="server" OnItemCommand="dtPaginacionReporteIntermediariosEspecial_ItemCommand" OnItemDataBound="dtPaginacionReporteIntermediariosEspecial_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralReporteIntermediariosEspecial" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteReporteIntermediariosEspecial" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteReporteIntermediariosEspecial_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoReporteIntermediariosEspecial" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoReporteIntermediariosEspecial_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
        <br />
    </div>

</asp:Content>

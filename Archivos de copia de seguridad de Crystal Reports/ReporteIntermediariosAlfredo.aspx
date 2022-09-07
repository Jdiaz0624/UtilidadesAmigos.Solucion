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
            background-color: #1E90FF;
            color: #000000;
        }
    </style>


    <script type="text/javascript">
        function CamposFechasVacios() {
            alert("Has dejado campos fechas vacios, estos son necesarios para realizar esta operación, favor de verificar.");
        }

        function FechaDesdeVacio() {
            $("#<%=txtFechaDesdeReporte.ClientID%>").css("border-color", "red");
        }

        function FechaHastaVacio() {
            $("#<%=txtFechaHastaReporte.ClientID%>").css("border-color", "red");
        }
    </script>

    <br />

    <div id="DivBloqueReporte" runat="server">
        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
       <div class="row">
           <div class="col-md-3">
               <asp:Label ID="lbFechaDesdeReporte" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
               <asp:TextBox ID="txtFechaDesdeReporte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
           </div>

            <div class="col-md-3">
               <asp:Label ID="lbFechaHastaReporte" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
               <asp:TextBox ID="txtFechaHastaReporte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
           </div>

           <div class="col-md-3">
               <asp:Label ID="lbCodigoIntermediarioReporte" visible="false" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
               <asp:TextBox ID="txtCodigoIntermediarioReporte" visible="false" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioReporte_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
           </div>

            <div class="col-md-3">
               <asp:Label ID="lbNombreIntermediarioReporte" visible="false" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
               <asp:TextBox ID="txtNombreIntermediarioReprte" visible="false"  runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
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
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Intermediario </th>
                        <th scope="col"> Producción B. </th>
                        <th scope="col"> Producción N. </th>
                        <th scope="col"> Cobrado B. </th>
                        <th scope="col"> Cobrado N. </th>
                        <th scope="col"> Comisión </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoIntermediarios" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td> <%# Eval("Intermediario") %> </td>
                                <td> <%# string.Format("{0:n2}", Eval("ProduccionBruto")) %> </td>
                                <td> <%# string.Format("{0:n2}", Eval("ProduccionNeto")) %> </td>
                                <td> <%# string.Format("{0:n2}", Eval("CobradoBruto")) %> </td>
                                <td> <%# string.Format("{0:n2}", Eval("CobradoNeto")) %> </td>
                                <td> <%# string.Format("{0:n2}", Eval("ALiquidar")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>


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

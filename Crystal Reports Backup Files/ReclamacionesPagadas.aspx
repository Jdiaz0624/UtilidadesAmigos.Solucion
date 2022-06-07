<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReclamacionesPagadas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReclamacionesPagadas" %>
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
      

        th {
            background-color: dodgerblue;
            color: white;
        }

                 .BotonImagen {
                   width:50px;
                   height:50px;
                 
                 }
    </style>

    <script type="text/javascript">
        function CamposFechaVAciosConsulta() {

            alert("Los campos fecha no pueden estar vacios para realizar esta consulta.");
        }
        function CamposFechaVAciosExportar() {

            alert("Los campos fecha no pueden estar vacios para Exportar esta Información.");
        }
        function CamposFechaVAciosReporte() {

            alert("Los campos fecha no pueden estar vacios para Generar este Reporte.");
        }

        function CampoFechaDesdeVacio() {

            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "Red");
        }
        function CampoFechaHastaVacio() {

            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "Red");
         }
    </script>
    <br />
    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbCodigoBeneficiario" runat="server" Text="Codigo de Beneficiario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoBeneficiario" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbNombreBeneficiario" runat="server" Text="Nombre de Beneficiario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreBeneficiario" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbNumeroCheque" runat="server" Text="Numero de Cheque" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroCheque" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
            </div>
             <div class="col-md-6">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control"  TextMode="Date"></asp:TextBox>
            </div>
             <div class="col-md-6">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control"  TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultarRegistros" runat="server" ToolTip="Consultar Registros" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultarRegistros_Click" />
            <asp:ImageButton ID="btnExportarExcel" runat="server" ToolTip="Exportar Registros" CssClass="BotonImagen" ImageUrl="~/Imagenes/excel.png" OnClick="btnExportarExcel_Click" />
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Reporte de Reclamaciones Pagadas" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
            <br />
            <hr />
            <asp:Label ID="lbCanidadRegistrosTitulo" runat="server" Text="Cantidad de Registros (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCanidadRegistrosVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCanidadRegistrosCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbSeparador1" runat="server" Text=" | " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbTotaoTitulo" runat="server" Text="Total (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbTotalVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbTotalCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <br />
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col"> Codigo </th>
                    <th scope="col"> Beneficiario </th>
                    <th scope="col"> Tipo </th>
                    <th scope="col"> Numero </th>
                    <th scope="col"> Valor </th>
                    <th scope="col"> Cheque </th>
                    <th scope="col"> Fecha </th>
                    <th scope="col"> Sucursal </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpReclamacionesPagadas" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td> <%# Eval("CodigoBeneficiario") %> </td>
                            <td> <%# Eval("Beneficiario1") %> </td>
                            <td> <%# Eval("TipoIdentificacion") %>  </td>
                            <td> <%# Eval("NumeroIdentificacion") %> </td>
                            <td> <%#string.Format("{0:n2}", Eval("Valor")) %> </td>
                            <td> <%# Eval("NumeroCheque") %> </td>
                            <td> <%# Eval("FechaCheque") %> </td>
                            <td> <%# Eval("DescSucursal") %> </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div align="center">
                <asp:Label ID="lbPaginaActualTituloReclamacionesPagadas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableReclamacionesPagadas" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloReclamacionesPagadas" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableReclamacionesPagadas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionReclamacionesPagadas" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaReclamacionesPagadas" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaReclamacionesPagadas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorReclamacionesPagadas" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorReclamacionesPagadas_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionReclamacionesPagadas" runat="server" OnItemCommand="dtPaginacionReclamacionesPagadas_ItemCommand" OnItemDataBound="dtPaginacionReclamacionesPagadas_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralReclamacionesPagadas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteReclamacionesPagadas" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteReclamacionesPagadas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoReclamacionesPagadas" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoReclamacionesPagadas_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
    </div>
</asp:Content>

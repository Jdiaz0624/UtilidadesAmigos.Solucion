<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarReporteFianzas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarReporteFianzas" %>
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

        .Letranegrita {
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
    <script type="text/javascript">
        function MensajeConsulta() {
            alert("Error al realizar la consulta, favor de verificar el rango de fecha ingresado");
        }

        function FechaDesdeError() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }

        function FechaHastaError() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }



   
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Reporte de Fianzas"></asp:Label>
        </div>
        <div align="center">
            <asp:Label ID="lbCantidadEncontradaTitulo" runat="server" Text="Cantidad de registros encontrados ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistros" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCerrarParentesis" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtpolizaConsulta" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarSubramo" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSubramo" runat="server" CssClass="form-control" ToolTip="Seleccionar Subramo"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" TextMode="Date" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
        
            </div>
           <div class="form-group col-md-3">
               <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" TextMode="Date" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <button type="button" id="btnHistorico" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-xl">Historico</button>

            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExportar_Click" />
        </div>
        <br />
           <div>
            <asp:GridView ID="gvInventario" runat="server" AllowPaging="true" OnPageIndexChanging="gvInventario_PageIndexChanging" OnSelectedIndexChanged="gvInventario_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="NoFactura" HeaderText="NoFactura" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="SubRamo" HeaderText="SubRamo" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="Intermediario" HeaderText="Intermediario" />
                    <asp:BoundField DataField="FechaFacturacion" HeaderText="Fecha Facturacion" />
                </Columns  >
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" HorizontalAlign="Center" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
    </div>
    </div>

    <div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
    
         <div class="jumbotron" align="center">
             <asp:Label ID="lbHistoricFinzas" runat="server" Text="Historico de Fianzas"></asp:Label>
         </div>
      
         <div class="container-fluid">
         <asp:ScriptManager ID="ScriptHistoricoPoliza" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanelHistoricoPoliza" runat="server">
             <ContentTemplate>
                   <div align="center">
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros (" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
        </div>
                 <div class="form-row">
                     <div class="form-group col-md-3">
                         <asp:Label ID="lbPolizaHistoricoPoliza" runat="server" Text="Poliza"  CssClass="LetrasNegrita"></asp:Label>
                         <asp:TextBox ID="txtPolizaHistoricoPoliza" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled"></asp:TextBox>
                     </div>

                     <div class="form-group col-md-3">
                         <asp:Label ID="lbSubRanoHistoriclPoliza" runat="server" Text="Sub Ramo"  CssClass="LetrasNegrita"></asp:Label>
                         <asp:DropDownList ID="ddlSeleccionarSubramHistoriclPoliza" runat="server" CssClass="form-control" ToolTip="Seleccionar Sub Ramo"></asp:DropDownList>
                     </div>

                     <div class="form-group col-md-3">
                         <asp:Label ID="lbFecgaDesdeHistoricl" runat="server" Text="Fecha Desde"  CssClass="LetrasNegrita"></asp:Label>
                         <asp:TextBox ID="txtFechaDesdeHistoricoPoliza" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>

                      <div class="form-group col-md-3">
                         <asp:Label ID="lbFechaHastaHistoricoPoliza" runat="server" Text="Fecha Hasta"  CssClass="LetrasNegrita"></asp:Label>
                         <asp:TextBox ID="txtFechaHAstaHistoricoPoliza" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>

                 </div>
                 <!--BOTONES-->
                 <div align="center">
                     <asp:Button ID="btnConsultarHistorico" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" OnClick="btnConsultarHistorico_Click" ToolTip="Consultar Registros" />
                 </div>
                 <!--BOTONES-->
                 <br />
                 <div>
            <asp:GridView ID="gvHistoricoPolizaFianza" runat="server" AllowPaging="true" OnPageIndexChanging="gvHistoricoPolizaFianza_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="SubRamo" HeaderText="SubRamo" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Valor" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Valor" />
                     <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                </Columns  >
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" HorizontalAlign="Center" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
    </div>


               
             </ContentTemplate>
         </asp:UpdatePanel>
             <br />
               <!--BOTONES-->
                 <div align="center">
                     <asp:Button ID="btnExportarHistoriclPoliza" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExportarHistoriclPoliza_Click" />

                 </div>
             <br />
                 <!--BOTONES-->
     </div>
    </div>
  </div>
</div>
</asp:Content>

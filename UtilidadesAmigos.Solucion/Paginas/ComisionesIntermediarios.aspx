<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ComisionesIntermediarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ComisionesIntermediarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#7BC5FF;
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


    </style>

    <script type="text/javascript">
        function FechaDesdeComisionesVacio() {
            $("#<%=txtFechaDesdeComisiones.ClientID%>").css("border-color", "red");
        }
        function FechaHastaComisionesVAcio() {
            $("#<%=txtFechaHastaComisiones.ClientID%>").css("border-color", "red");
        }
    </script>
          <div class="container-fluid">
          <div class="jumbotron" align="center">
           
              <asp:Label ID="lbNombreIntermediarioComision" runat="server" Text="COMISIONES DE INTERMEDIARIOS"></asp:Label>
          </div>
          <br />
          <div class="form-row">
              <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaDesdeComisiones" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaDesdeComisiones" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaHastaComisiones" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaHastaComisiones" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>
               <div class="form-group col-md-3">
                  <asp:Label ID="lbCodigoIntermediarioComisiones" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtCodigoIntermediarioComisiones" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbSeleccionarSucursalComisiones" runat="server" Text="Seleccionar Sucursal" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionarSucursalComisiones" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSucursalComisiones_SelectedIndexChanged" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbSeleccionarOficinaComisiones" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionaroficinaComisiones" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
              </div>
          </div>
              <div align="center">
                  <asp:Label ID="lbLeyrtero" runat="server" Text="Seleccionar Tipo de Reporte a Mostrar:" CssClass="LetrasNegrita"></asp:Label>
                  <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:RadioButton ID="rbGenerarReporteResumido" runat="server" Text="Resumido" ToolTip="Generar reporte de comisión resumido" GroupName="Reporte" CssClass="form-check-input LetrasNegrita" />
                          <asp:RadioButton ID="rbGenerarReporteDetalle" runat="server" Text="Detalle" ToolTip="Generar reporte de comsiion detalle" GroupName="Reporte" CssClass="form-check-input LetrasNegrita" />
                      </div>
              </div>
          <div align="center">
              <asp:Button ID="btnConsultarComisiones" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultarComisiones_Click"  />
              <asp:Button ID="btnExortarComisiones" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExortarComisiones_Click" />
              <asp:Button ID="btnReporteCOmisiones" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm" ToolTip="Reporte de Comisiones" OnClick="btnReporteCOmisiones_Click" />
          </div>
          <br />
                      <asp:GridView ID="gvComisionIntermediario" runat="server" AllowPaging="true" OnPageIndexChanging="gvComisionIntermediario_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Bruto" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Bruto" />
                    <asp:BoundField DataField="Neto" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Neto" />
                    <asp:BoundField DataField="PorcientoComision" HeaderText="% Comisión" />
                       <asp:BoundField DataField="Comision" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Comisión" />
                       <asp:BoundField DataField="Retencion" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Retención" />
                       <asp:BoundField DataField="AvanceComision" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Avance" />
                       <asp:BoundField DataField="ALiquidar" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="A Liquidar" />
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

          <br />
      </div>
</asp:Content>

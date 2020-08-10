<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarFacturasPDF.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarFacturasPDF" %>
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
            width:200px;
        }

        .Letranegrita {
        font-weight:bold;
        }
    </style>
     <div class="container-fluid">
        <div align="center" class="jumbotron">
            <asp:Label ID="lbEncabezadoPantalla" runat="server" Text="Generar Facturas PDF"></asp:Label>
        </div>
         <div align="center">
             <asp:Label ID="lbCantidadRegistros" runat="server" Text="Cantidad de registros ( " CssClass="Letranegrita"></asp:Label>
             <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
             <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
         </div>
    </div>
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbConsultarPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" AutoCompleteType="Disabled" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group col-md-3">
                <asp:Label ID="lbCOmprobanteConsulta" runat="server" Text="Comprobante" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtComprobanteConsulta" AutoCompleteType="Disabled" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
        <div align="center">
         <asp:Button ID="btnConsultar" runat="server" Text="Consultar Registros" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click"/>
        </div>
     
        <br />
       <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvListadoRegistros" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoRegistros_PageIndexChanging" OnSelectedIndexChanged="gvListadoRegistros_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Imprimir"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Imprimir" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdComprobante" HeaderText="ID" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Comprobante" HeaderText="Comprobante" />
                    <asp:BoundField DataField="NumeroFactura" HeaderText="NumeroFactura" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Asegurado" HeaderText="Asegurado" />
                    <asp:BoundField DataField="Intermediario" HeaderText="Intermediario" />
                    <asp:BoundField DataField="Total" HeaderText="Valor" DataFormatString="{0:N0}" HtmlEncode="false" />
                    <asp:BoundField DataField="FechaProceso" HeaderText="Fecha" />
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
    <!--FIN DEL GRID-->
    <br />
   
        <div align="center">
         <asp:Button ID="btnGenerarRegistros" runat="server" Text="Generar Registros" ToolTip="Generar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnGenerarRegistros_Click"/>
        </div>
 
</asp:Content>

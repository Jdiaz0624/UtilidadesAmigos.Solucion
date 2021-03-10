<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionPorUsuarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionPorUsuarios" %>
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
        .LetraNegrita {
        font-weight:bold;
        }
    </style>

    <script>
        function ErrorConsulta() {
            alert("Error al realizar la consulta, favor de validar los parametros de busqueda ingresados");

        }
    </script>
<div class="container-fluid">
        <div class="jumbotron" align="center">
        <asp:Label ID="lbTituloPantallaProduccionConUsuario" runat="server" Text="Producción Por Usuario"></asp:Label>
    </div>

    <div align="center">
        <asp:Label ID="lbSeleccionarTipoConsulta" runat="server" CssClass="LetraNegrita" Text="Seleccionar Tipo de Consulta"></asp:Label>
        <br />
        <div class="form-check-inline" >
        <div class="form-group form-check">
            <asp:RadioButton ID="rbBuscarProduccion" runat="server" Text="Producción" AutoPostBack="true" ToolTip ="Buscar la Produccion mediante el rango de fecha seleccionado" GroupName="ProduccionPorUsuarios" CssClass="form-check-input LetraNegrita" OnCheckedChanged="rbBuscarProduccion_CheckedChanged" />
            <asp:RadioButton ID="rbBuscarPagos" runat="server" Text="Pagos" AutoPostBack="true" ToolTip="Buscar los pagos aplicados mediante el rango de fecha seleccionado" GroupName="ProduccionPorUsuarios" CssClass="form-check-input LetraNegrita" OnCheckedChanged="rbBuscarPagos_CheckedChanged" />
        </div>
    </div>
        <hr />
        <div alien="center">
            <asp:Label ID="lbTipoImpresion" runat="server" Text="Tipo de Consulta" CssClass="LetraNegrita"></asp:Label>
            <br />
            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:RadioButton ID="rbGenerarDaraResumido" runat="server" Text="Resumido" AutoPostBack="true" CssClass="form-check-input LetraNegrita" GroupName="TipoData" Checked="true" OnCheckedChanged="rbGenerarDaraResumido_CheckedChanged" />
                    <asp:RadioButton ID="rbGenerarDataDetalle" runat="server" Text="Detalle" AutoPostBack="true" CssClass="form-check-input LetraNegrita" GroupName="TipoData" OnCheckedChanged="rbGenerarDataDetalle_CheckedChanged" />
                </div>
            </div>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetraNegrita"></asp:Label>
            <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-group col-md-6">
            <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetraNegrita"></asp:Label>
            <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <asp:Label ID="lbSucursal" runat="server" Text="Seleccionar Sucursal" CssClass="LetraNegrita"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarSUcursalConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Sucursal" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarSUcursalConsulta_SelectedIndexChanged"></asp:DropDownList>
        </div>

         <div class="form-group col-md-3">
            <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Seleccionar Oficina" CssClass="LetraNegrita"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" CssClass="form-control" ToolTip="Seleccionar Oficina" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarOficina_SelectedIndexChanged"></asp:DropDownList>
        </div>

         <div class="form-group col-md-3">
            <asp:Label ID="lbSeleccionarDepartamento" runat="server" Text="Seleccionar Departamento" CssClass="LetraNegrita"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarDepartamento" runat="server" CssClass="form-control" ToolTip="Seleccionar Departamento" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarDepartamento_SelectedIndexChanged"></asp:DropDownList>
        </div>

         <div class="form-group col-md-3">
            <asp:Label ID="lbSeleccionarUsuario" runat="server" Text="Seleccionar Usuario" CssClass="LetraNegrita"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarUsuario" runat="server" CssClass="form-control" ToolTip="Seleccionar Usuario" AutoPostBack="true"></asp:DropDownList>
        </div>

    </div>

    <div align="center">
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
        <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar a Exel" OnClick="btnExportar_Click"/>
        <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm" ToolTip="Generar Reporte de Produccion" OnClick="btnReporte_Click"/>
    </div>

      <br />
    <div align="center">
        <asp:Label ID="lbTotalMovimientosLetrero" runat="server" Text="Total de Registros (" CssClass="LetraNegrita"></asp:Label>
        <asp:Label ID="lbTotalRegistrosVariable" runat="server" Text="0" CssClass="LetraNegrita"></asp:Label>
        <asp:Label ID="lbTotalRegistrosCerrar" runat="server" Text=" )" CssClass="LetraNegrita"></asp:Label>

        <asp:Label ID="Label1" runat="server" Text=" - " CssClass="LetraNegrita"></asp:Label>

         <asp:Label ID="lbTotalMontoLetrero" runat="server" Text="Total en prima (" CssClass="LetraNegrita"></asp:Label>
        <asp:Label ID="lbTotalMontoVariable" runat="server" Text="0" CssClass="LetraNegrita"></asp:Label>
        <asp:Label ID="lbTotalMontoCerrar" runat="server" Text=" )" CssClass="LetraNegrita"></asp:Label>
    </div>
    <br />
          <!--INICIO DEL GRID-->
    <div class="container-fluid">
        <!--GRID 1-->
            <asp:GridView ID="gvListadoProduccion" runat="server" Visible="true" AllowPaging="true" OnPageIndexChanging="gvListadoProduccion_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                   <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Cantidad" DataFormatString="{0:N0}" HtmlEncode="false" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Total" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Total" />
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
    

     <!--GRID 1-->
            <asp:GridView ID="gvListadoProduccionDetalle" runat="server" Visible="false" AllowPaging="true" OnPageIndexChanging="gvListadoProduccionDetalle_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                   <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Monto" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Monto" />
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
    </div>
</asp:Content>

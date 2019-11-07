﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionDiaria.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionDiaria" %>

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
            text-align:center;
            padding:25px;
        }
    </style>
    <script type="text/javascript">
        function ErrorConsulta()
        {
            alert("Error al Mostrar la consulta, favor de verificar que los parametros esten bien.")

        }
        function ErrorExportar() {
            alert("Error al Exportar la data a exel, favor de verificar si los parametros estan correctos.")
        }
    </script>
<div class="container-fluid">
    <div class="jumbotron">
        <asp:Label ID="lbEncabezado" runat="server" Text="Producción diaria"></asp:Label>
    </div>
</div>
<div class="container-fluid">
    <div class="form-row">
        <div class="form-group col-md-3">
            <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde"></asp:Label>
            <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta"></asp:Label>
            <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
    <div class="form-check">
        <asp:CheckBox ID="cbEspesificarRamo" AutoPostBack="true"  runat="server" Text="Espesificar Ramo" CssClass="form-check-input" ToolTip="Espesificar el ramo para filtrar la consulta" OnCheckedChanged="cbEspesificarRamo_CheckedChanged" />
    </div>
</div>
    <br />
    <div class="form-row">
        <div class="col-4">
            <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Seleccionar Ramo"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" CssClass="form-control" ToolTip="Seleccionar Ramo"></asp:DropDownList>
        </div>
    </div>
    <br />
<div class="container-fluid">
            <asp:Button ID="btnBuscarRegistros" class="btn btn-outline-primary" runat="server" ToolTip="Buscar Registros" Text="Buscar Registros" OnClick="btnBuscarRegistros_Click" />
            <asp:Button ID="btnGenerarReporte" class="btn btn-outline-success" ToolTip="Generar el reporte de los parametros ingresados" runat="server" Text="Exportar a Excel" OnClick="btnGenerarReporte_Click" />
            <asp:Button ID="btnAtras" CssClass="btn btn-outline-dark" ToolTip="Volver Atras" runat="server" Text="Atras" OnClick="btnAtras_Click" Visible="false" />
        </div>
 
    <br />
     <div class="container-fluid">
            <asp:GridView id="gbProduccionDiaria" runat="server" AllowPaging="True" OnPageIndexChanging="gbProduccionDiaria_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbProduccionDiaria_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="CodRamo" HeaderText="CodRamo" />
                    <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                    <asp:BoundField DataField="Facturado" HeaderText="Facturado" />
                    <asp:BoundField DataField="PesosDominicanos" HeaderText="Pesos Dominicanos" />
                    <asp:CommandField ButtonType="Button" HeaderText="Detalle" SelectText="Ver" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>


        </div>
</div>
<br />











    </asp:Content>


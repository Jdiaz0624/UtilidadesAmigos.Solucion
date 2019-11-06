<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionDiaria.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionDiaria" %>

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
<div class="container-fluid">
    <div class="jumbotron">
        <asp:Label ID="lbEncabezado" runat="server" Text="Producción diaria"></asp:Label>
    </div>
</div>
<div class="container-fluid">
    <div class="form-row">
        <div class="col-2">
            <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde"></asp:Label>
            <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-2">
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
</div>
<br />











    </asp:Content>


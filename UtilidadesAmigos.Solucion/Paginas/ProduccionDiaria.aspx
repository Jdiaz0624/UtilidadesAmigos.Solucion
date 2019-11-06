<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionDiaria.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionDiaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <header>
     <div align="center">
         <h1> <small>Producción Diaria</small></h1>
     </div>
 </header>
    <hr class="new1" />
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
        <asp:CheckBox ID="cbEspesificarRamo" AutoPostBack="true"  runat="server" Text="Espesificar Ramo" CssClass="form-check-input" ToolTip="Espesificar el ramo para filtrar la consulta" />
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


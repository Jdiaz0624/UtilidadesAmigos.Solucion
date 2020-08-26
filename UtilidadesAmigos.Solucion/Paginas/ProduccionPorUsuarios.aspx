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

<div class="container-fluid">
        <div class="jumbotron" align="center">
        <asp:Label ID="lbTituloPantallaProduccionConUsuario" runat="server" Text="Producción Por Usuario"></asp:Label>
    </div>
</div>
    <div align="center">
        <asp:Label ID="lbSeleccionarTipoConsulta" runat="server" CssClass="LetraNegrita" Text="Seleccionar Tipo de Consulta"></asp:Label>
        <br />
        <div class="form-check-inline" >
        <div class="form-group form-check">
            <asp:RadioButton ID="rbBuscarProduccion" runat="server" Text="Producción" AutoPostBack="true" ToolTip ="Buscar la Produccion mediante el rango de fecha seleccionado" GroupName="ProduccionPorUsuarios" CssClass="form-check-input LetraNegrita" />
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Producción" AutoPostBack="true" ToolTip="Buscar los pagos aplicados mediante el rango de fecha seleccionado" GroupName="ProduccionPorUsuarios" CssClass="form-check-input LetraNegrita" />
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Producción" AutoPostBack="true" ToolTip="Buscar las reclamacionesaperturadas mediante el rango de fecha seleccionado" GroupName="ProduccionPorUsuarios" CssClass="form-check-input LetraNegrita" />
        </div>
    </div>
    </div>
    
</asp:Content>

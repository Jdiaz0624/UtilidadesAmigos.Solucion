<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProcesarDataGruas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProcesarDataGruas" %>
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
        .LetraNegrita {
        font-weight:bold;
        }
    </style>
    <div class="Bloque-Centro">
        <div class ="Bloque-Izquierda" >
            <asp:Label ID="lbSeleccionarCobertura" runat="server" CssClass="Label" Text="Seleccionar Cobertura"></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarCobertura" runat="server" CssClass="combobox"></asp:DropDownList>
        </div>
        <div class="Bloque-Derecha" >

        </div>


    </div>
</asp:Content>

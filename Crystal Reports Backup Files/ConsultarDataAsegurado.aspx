<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ConsultarDataAsegurado.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Consulta.ConsultarDataAsegurado" %>
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

        .LetrasNegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        

        th {
            background-color: #1E90FF;
            color: #000000;
        }
    </style>

    <div class="container-fluid">
        <br /><br />
        <div class="form-check">
                 <asp:Label ID="lbTipoOperacion" runat="server" Text="Tipo de Operación: " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbConsultarRegistros" runat="server" Text="Consultar" AutoPostBack="true" CssClass="form-check-input" GroupName="TipoOperacion" />
                <asp:RadioButton ID="rbProcesarRegistros" runat="server" Text="Procesar" AutoPostBack="true" CssClass="form-check-input" GroupName="TipoOperacion" />
        </div>
    </div>
</asp:Content>

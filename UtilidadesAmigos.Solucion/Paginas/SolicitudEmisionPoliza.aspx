<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SolicitudEmisionPoliza.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.SolicitudEmisionPoliza" %>
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
            width:400px;
            height:200px;
        }

           .BotonSolicitud {
                width:450px;
               height:250px;
           }


    </style>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="SOLICITUD DE EMISION DE POLIZA"></asp:Label>
        </div>
        <div align="center">

            <asp:ImageButton ID="btnSeguroFull" runat="server" CssClass="BotonSolicitud" ToolTip="Solicitud de Seguros Full" ImageUrl="~/Imagenes/SeguroFull.jpg" />
            <asp:ImageButton ID="btnSeguroLey" runat="server" CssClass="BotonSolicitud" ToolTip="Solicitud de Seguros de Ley" ImageUrl="~/Imagenes/Seguro de Ley.jpg" />
        </div>
    </div>

</asp:Content>

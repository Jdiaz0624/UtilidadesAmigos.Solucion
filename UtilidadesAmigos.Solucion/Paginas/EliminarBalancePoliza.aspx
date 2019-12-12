<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="EliminarBalancePoliza.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.EliminarBalancePoliza" %>
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
            <asp:Label ID="lbEliminarBalance" runat="server" Text="Eliminar Balance Poliza"></asp:Label>
    </div>

    <!--COLOCAMOS LOS RADIOS -->
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGenerarTodo" runat="server" GroupName="Data" Text="Generar Todo" ToolTip="Generar Toda la data ingresada en la data" CssClass="form-check-input"></asp:RadioButton>
            </div>
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGenerarPolizaEspesifica" runat="server" GroupName="Data" Text="Generar Mediante Filtro" ToolTip="Eliminar Balance filtrando mediante la poliza" CssClass="form-check-input"></asp:RadioButton>
            </div>
        </div>
    </div>
</asp:Content>

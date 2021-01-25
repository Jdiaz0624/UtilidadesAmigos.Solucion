<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ConsumoWS.aspx.cs" Inherits="UtilidadesAmigos.Solucion.WS.ConsumoWS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtPoliza" runat="server" ></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
    <asp:GridView ID="gbListado" runat="server"></asp:GridView>

</asp:Content>

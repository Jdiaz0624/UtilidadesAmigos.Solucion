<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="DatosPoliza.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.DatosPoliza" %>
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
            width:100px;
        }
          .LetrasNegrita {
          font-weight:bold;
          }


    </style>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbDatoPoliza" runat="server" Text="Datos Poliza"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbIngresaPoliza" runat="server" Text="Ingresar Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtIngresarPoliza" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
              <div class="form-group col-md-6">
                <asp:Label ID="lbIngresarItem" runat="server" Text="Ingresar Item" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtIngresarItem" runat="server" CssClass="form-control" TextMode="Number" MaxLength="20"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
        </div>
        <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbModificarPrima" runat="server" Text="Cambio de Valor" CssClass="form-check-input" ToolTip="Cambiar el valor a un item de una poliza" />
            </div>
             <div class="form-group form-check">
                <asp:CheckBox ID="cbModificarVigencia" runat="server" Text="Cambio de Vigencia" CssClass="form-check-input" ToolTip="Cambiar la Vigencia de Una poliza" />
            </div>
        </div>
        <br />
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtRamo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbSubramo" runat="server" Text="Sub Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtSubramo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>

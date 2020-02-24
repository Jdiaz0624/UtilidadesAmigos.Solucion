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
            width:100px;
        }
          .LetrasNegrita {
          font-weight:bold;
          }


    </style>
        <script type="text/javascript">
        function Mensaje() {
            alert("Esta Opcion aun no esta disponible");
        }
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="SOLICITUD DE EMISION"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarTiposervicio" Text="Seleccionar Tipo de Solicitud" runat="server" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoServicio" runat="server" AutoPostBack="true" ToolTip="Seleccionar el tipo de servicio" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarTipoServicio_SelectedIndexChanged">
                    <asp:ListItem Value="1">Seguro de Ley</asp:ListItem>
                    <asp:ListItem Value="2">Seguro Full</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="Label1" Text="Seleccionar Producto" runat="server" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarProducto" runat="server" AutoPostBack="true" ToolTip="Seleccionar Producto" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarProducto_SelectedIndexChanged"></asp:DropDownList>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="Label2" Text="Descripción" runat="server" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtDescripcionProducto" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div align="center">
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Comenzar Solicitud" OnClick="btnProcesar_Click" />
        </div>
    </div>
</asp:Content>

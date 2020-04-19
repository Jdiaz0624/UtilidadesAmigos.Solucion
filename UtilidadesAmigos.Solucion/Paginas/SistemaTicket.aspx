<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SistemaTicket.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.SistemaTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
          .jumbotron{
            color:#000000;
            background:#7BC5FF;
            font-size:20px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }
        .LetraNegrita {
        font-weight:bold;
        }
           .btn-sm{
            width:90px;
        }
    </style>

    <!--ENCABEZADO-->
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Sistema de Ticket"></asp:Label>
            <asp:Label ID="lbIdUsuarioTicket" runat="server" Visible="false" Text="IdUsuario"></asp:Label><br />
            <asp:Label ID="lbNumeroConectorAbrir" runat="server" Text="("></asp:Label>
            <asp:Label ID="lbNumeroConectorVariable" runat="server"  Text="NumeroConector"></asp:Label>
            <asp:Label ID="lbNumeroConectorCerrar" runat="server"  Text=")"></asp:Label>
        </div>
        <div align="center">
            <asp:Label ID="lbUsuarioTitulo" runat="server" Text="USUARIO: " CssClass="LetraNegrita"></asp:Label>
            <asp:Label ID="lbUsuarioVariable" runat="server" Text="Usuario"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="     " CssClass="LetraNegrita"></asp:Label>
            <asp:Label ID="lbDepartamentoTitulo" runat="server" Text="DEPARTAMENTO: " CssClass="LetraNegrita"></asp:Label>
            <asp:Label ID="lbDepartamentoVariable" runat="server" Text="Departamento"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="     " CssClass="LetraNegrita"></asp:Label>
            <asp:Label ID="lbTipoTitulo" runat="server" Text="TIPO: " CssClass="LetraNegrita"></asp:Label>
            <asp:Label ID="lbTipoVariable" runat="server" Text="Tipo"></asp:Label>
        </div>
        <hr />
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbTituloTicket" runat="server" Text="Titulo" CssClass="LetraNegrita"></asp:Label>
                <asp:TextBox ID="txtTituloTicket" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-12">
                <asp:Label ID="lbDescripcionTicket" runat="server" Text="Descripción de Ticket" CssClass="LetraNegrita"></asp:Label>
                <asp:TextBox ID="txtDescripcionTicket" runat="server" MaxLength="8000" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
            </div>
        </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbAgregarCapture" runat="server" OnCheckedChanged="cbAgregarCapture_CheckedChanged" Text="Agregar Capture" CssClass="form-check-input" AutoPostBack="true" />
            </div>
        </div>
    </div>
   <div align="center">
        <div class="container">
        <div class="col-md-4 col-md-offset-4">
            <asp:Label ID="lbImagenAgregada" Visible="false" runat="server" Text="Imagen Agregada" CssClass="LetraNegrita"></asp:Label>
            <br />
            <asp:Image ID="ImageCaptureTicket" Visible="false" runat="server" ImageUrl="~/Imagenes/CampoImagen.jpg" Width="200" />
            <br />
            <br />
            <asp:Label ID="lbArchivo" Visible="false" runat="server" Text="Buscar Imagen" CssClass="LetraNegrita"></asp:Label>
            <asp:FileUpload ID="fuImagenCapture" Visible="false" accept=".png,.jpg,.jpeg,.gif" runat="server" CssClass="form-control" />
            <br />
            <asp:Label ID="lbTituloImagen" runat="server" Visible="false" Text="Titulo de Imagen" CssClass="LetraNegrita"></asp:Label>
            <br />
            <asp:TextBox ID="txtTituloImagen" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="btnCompletarProceso" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Completar" ToolTip="Completar Proceso" OnClick="btnCompletarProceso_Click" />
        </div>
    </div>
   </div>
    <br />
    <br />
</asp:Content>

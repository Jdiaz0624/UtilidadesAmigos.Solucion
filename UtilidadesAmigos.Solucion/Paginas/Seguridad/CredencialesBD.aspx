<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="CredencialesBD.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Seguridad.CredencialesBD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">

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
            background-color: dodgerblue;
            color: white;
        }
    </style>

    <script type="text/javascript">
        function ClaveSeguridadNoValida() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar.");
        }

        $(document).ready(function () {
            $("#").click(function () { });
            $("#").click(function () { });
        })
    </script>

    <div class="container-fluid">
        <div id="DivBloqueClaveSeguridad" runat="server">
            <br />

            <div class="form-row" >
                <div class="form-group col-md-6">
                    <asp:Label ID="lbClaveSeguridad" Text="Ingresar Clave de Seguridad" runat="server" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridad" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div align="center">
                <asp:Button ID="btnValidar" runat="server" Text="Validar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Validar la clave de seguridad" />
            </div>

        </div>

        <div id="DivBloqueModificarCredencial" runat="server">
             <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="lbUsuarioBD" Text="Usuario BD" runat="server" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtUsuarioBD" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                  <div class="form-group col-md-6">
                    <asp:Label ID="lbClaveBD" Text="Clave BD" runat="server" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveBD" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div align="center">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar Registro" />
            </div>
            <br />
        </div>

    </div>
</asp:Content>

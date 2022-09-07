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

        function ClaveModificada() {
            alert("Credenciales modificadas con exito.");
        }

        $(document).ready(function () {
            $("#<%=btnValidar.ClientID%>").click(function () {
                var ClaveSeguridad = $("#<%=txtClaveSeguridad.ClientID%>").val().length;
                if (ClaveSeguridad < 1) {
                    alert("El campo clave de seguridad no puede estar vacio para proceder con este proceso, favor de verificar.");
                    $("#<%=txtClaveSeguridad.ClientID%>").css("border-color", "red");
                    return false;
                }

            });
            $("#<%=btnModificar.ClientID%>").click(function () {
                var UsuarioBD = $("#<%=txtUsuarioBD.ClientID%>").val().length;
                if (UsuarioBD < 1) {
                    alert("El campo usuario no puede estar vacio para modificar este registro, favor de verificar.");
                    $("#<%=txtUsuarioBD.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ClaveBD = $("#<%=txtClaveBD.ClientID%>").val().length;
                    if (ClaveBD < 1) {
                        alert("El campo clave no puede estar vacio para modificar este registro, favor de verificar.");
                        $("#<%=txtClaveBD.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }
            });
        })
    </script>

    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <div id="DivBloqueClaveSeguridad" runat="server">
            <br />

            <div class="form-row" >
                <div class="form-group col-md-6">
                    <asp:Label ID="lbClaveSeguridad" Text="Ingresar Clave de Seguridad" runat="server" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridad" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div align="center">
                <asp:Button ID="btnValidar" runat="server" Text="Validar"  CssClass="btn btn-outline-secondary btn-sm" OnClick="btnValidar_Click" ToolTip="Validar la clave de seguridad" />
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
                <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn btn-outline-secondary btn-sm" OnClick="btnModificar_Click" ToolTip="Modificar Registro" />
            </div>
            <br />
        </div>

    </div>
</asp:Content>

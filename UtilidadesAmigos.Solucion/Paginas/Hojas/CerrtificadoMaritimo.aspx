<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="CerrtificadoMaritimo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Hojas.CerrtificadoMaritimo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        function PolizaNoEncontrada() {
            alert("La poliza ingresada no existe o no pertenece al renglón de certificados maritimos, favor de verificar.");
            $("#<%=txtPoliza.ClientID%>").css("border-color", "blue");
        }

        $(function () {
            $("#<%=btnReporte.ClientID%>").click(function () {

                var Poliza = $("#<%=txtPoliza.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo Poliza no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=txtPoliza.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

        })
    </script>
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-6">
                <label class="Letranegrita">Poliza</label>
                <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnReporte" runat="server" CssClass="BotonImagen" ToolTip="Generar Reporte" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporte_Click" />
        </div>
        <br />
    </div>
</asp:Content>

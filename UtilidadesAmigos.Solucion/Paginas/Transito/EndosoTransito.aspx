<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="EndosoTransito.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Transito.EndosoTransito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">

        function PolizaNoEncontrada() {
            alert("El numero de Poliza o el Item Ingresado no existe, favor de validar.");
        }

        $(function () {

            var MensajeComun = " no puede estar vacio para generar este endoso, favor de verificar.";
            $("#<%=btnReporte.ClientID%>").click(function () {

                var Poliza = $("#<%=txtPoliza.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo Poliza " + MensajeComun);
                    $("#<%=txtPoliza.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var NumeroItem = $("#<%=txtNumeroItem.ClientID%>").val().length;
                    if (NumeroItem < 1) {
                        alert("El campo Item " + MensajeComun);
                        $("#<%=txtNumeroItem.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var EndosadoA = $("#<%=txtEndosadoA.ClientID%>").val().length;
                        if (EndosadoA < 1) {
                            alert("El campo Endosado A " + MensajeComun);
                            $("#<%=txtEndosadoA.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {

                            var ValorCedido = $("#<%=txtValorcedido.ClientID%>").val().length;
                            if (ValorCedido < 1) {
                                alert("El campo Valor Cedido " + MensajeComun);
                                $("#<%=txtValorcedido.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var Deducible = $("#<%=txtMontoDeducible.ClientID%>").val().length;
                                if (Deducible < 1) {
                                    alert("El campo Deducible " + MensajeComun);
                                    $("#<%=txtMontoDeducible.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                            }
                        }
                    }
                }
            });
        })
    </script>

    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-3">
                <label class="Letranegrita">Poliza</label>
                <label class="Letranegrita Rojo">*</label>
                <asp:TextBox ID="txtPoliza" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita">Item</label>
                <label class="Letranegrita Rojo">*</label>
                <asp:TextBox ID="txtNumeroItem" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-6">
            </div>
            <div class="col-md-6">
                <label class="Letranegrita">Endosado A</label>
                <label class="Letranegrita Rojo">*</label>
                <asp:TextBox ID="txtEndosadoA" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita">Valor Cedido</label>
                <label class="Letranegrita Rojo">*</label>
                <asp:TextBox ID="txtValorcedido" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita">Monto Deducible</label>
                 <label class="Letranegrita Rojo">*</label>
                <asp:TextBox ID="txtMontoDeducible" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
             
        </div>
        <br />
        <div class="form-check-inline">
            <label class="Letranegrita"> Formato de Endoso</label>
            <asp:RadioButton ID="rpPDF" runat="server" Text="PDF" ToolTip="Generar el Endoso den Formato PDF" GroupName="Formato" />
            <asp:RadioButton ID="rbDocx" runat="server" Text="Docx (Word)" ToolTip="Generar el Endoso den Formato Word" GroupName="Formato" />
        </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Endoso" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporte_Click" />
        </div>
        <br />
    </div>
</asp:Content>

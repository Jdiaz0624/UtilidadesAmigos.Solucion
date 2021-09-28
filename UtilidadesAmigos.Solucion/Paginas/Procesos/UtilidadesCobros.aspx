<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="UtilidadesCobros.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.UtilidadesCobros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#1E90FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }

        .btn-sm{
            width:90px;
        }

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        
        .BotonEspecial {
           width:100%;
           font-weight:bold;
          }

        th {
            background-color: dodgerblue;
            color: white;
        }

        .BotonSolicitud {
                width:50px;
               height:50px;
           }
    </style>

    <script type="text/javascript">

        function ProcesoCompletado() {
            alert("Proceso Completado con exito.");
        }

        function PolizaNoExiste() {
            alert("La poliza ingresada no existe, favor de verificar.");
        }
        function ErrorAlRealizarProceso() {
            alert("Error al realizar el proceso, favor de contactar al administrador del sistema.");
        }
        function RegistroNoEncontrado() {
            alert("El recibo ingresado no es valido, favor de verificar.");
        }

        $(document).ready(function () {



            $("#<%=btnProcesarPolizaSinPagos.ClientID%>").click(function () {
                 var PolizaSinPago = $("#<%=txtPolizaSinPagos.ClientID%>").val().length;
                if (PolizaSinPago < 1) {
                    alert("El campo poliza no puede estar vacio para realizar este proceso, favor de verificar.");
                    $("#<%=txtPolizaSinPagos.ClientID%>").css("border-color", "red");
                    return false;
                }
            })


            $("#<%=btnBuscarPolizaFormaPago.ClientID%>").click(function () {
                var FormapAgo = $("#<%=txtNumeroRecibo.ClientID%>").val().length;
                if (FormapAgo < 1) {
                    alert("El campo recibo no puede estar vacio para buscar un registro, favor de verificar.");
                     $("#<%=txtNumeroRecibo.ClientID%>").css("border-color", "red");
                     return false;
                 }
            })


         });
    </script>

    <br />
    <div class="form-row">
        <div class="form-inline col-md-12">
           <asp:Label ID="lbCorreirPolizaSonPagos" runat="server" Text="Corregir Poliza sin cobro" CssClass="Letranegrita"></asp:Label>
            <asp:TextBox ID="txtPolizaSinPagos" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnProcesarPolizaSinPagos" runat="server" Text="Procesar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Corregir la poliza sin cobros" OnClick="btnProcesarPolizaSinPagos_Click" />
        </div>
    </div>
    <br />
    <hr />
    <div class="form-row">
        <div class="form-inline col-md-12">
            <asp:Label ID="lbConsultarPolizaFormaPago" runat="server" Text="Ingresar Recibo para cambiar forma de pago" CssClass="Letranegrita"></asp:Label>
            <asp:TextBox ID="txtNumeroRecibo" runat="server" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnBuscarPolizaFormaPago" runat="server" Text="Buscar" ToolTip="Buscar Poliza para cambiar la forma de pago" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnBuscarPolizaFormaPago_Click" />
        </div>
    </div>
    <br />
    <div class="table-responsive">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th style="width:10%"> SELECCIONAR </th>
                    <th style="width:20%"> POLIZA </th>
                    <th style="width:20%"> RECIBO </th>
                    <th style="width:10%"> FECHA </th>
                    <th style="width:20%"> TIPO </th>
                    <th style="width:20%"> VALOR </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoFormaPago" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfNumeroRecibo" runat="server" Value='<%# Eval("Numero_Recibo") %>' />

                        <td style="width:10%"> <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionar_Click" ToolTip="Seleccionar Registro" /> </td>
                        <td style="width:20%"> <%# Eval("Poliza") %> </td>
                        <td style="width:20%"> <%# Eval("Numero_Recibo") %>  </td>
                        <td style="width:10%"> <%# Eval("Fecha") %>  </td>
                        <td style="width:20%"> <%# Eval("Tipo") %>  </td>
                        <td style="width:20%"> <%#string.Format("{0:n2}", Eval("Monto")) %>  </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>

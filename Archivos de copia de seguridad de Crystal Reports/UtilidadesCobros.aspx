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
            background-color: #1E90FF;
            color: #000000;
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
    <asp:Label ID="lbNumeroreciboSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
    <div class="row">
        <div class="d-inline-flex col-md-6">
           <asp:Label ID="lbCorreirPolizaSonPagos" runat="server" Text="Corregir Poliza sin cobro" CssClass="Letranegrita"></asp:Label>
            <asp:TextBox ID="txtPolizaSinPagos" runat="server" Height="40px" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnProcesarPolizaSinPagos" runat="server" Text="Procesar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Corregir la poliza sin cobros" OnClick="btnProcesarPolizaSinPagos_Click" />
        </div>
    </div>
    <br />
    <hr />
    <div class="row">
        <div class="d-inline-flex col-md-6">
            <asp:Label ID="lbConsultarPolizaFormaPago" runat="server" Text="Ingresar Recibo para cambiar forma de pago" CssClass="Letranegrita"></asp:Label>
            <asp:TextBox ID="txtNumeroRecibo" runat="server" Height="40px" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnBuscarPolizaFormaPago" runat="server" Text="Buscar" ToolTip="Buscar Poliza para cambiar la forma de pago" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnBuscarPolizaFormaPago_Click" />
        </div>
    </div>
    <br />

        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="col"> Seleccionar </th>
                    <th scope="col"> Poliza </th>
                    <th scope="col"> Recibo </th>
                    <th scope="col"> Fecha </th>
                    <th scope="col"> Tipo </th>
                    <th scope="col"> Valor </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoFormaPago" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfNumeroRecibo" runat="server" Value='<%# Eval("Numero_Recibo") %>' />

                        <td> <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionar_Click" ToolTip="Seleccionar Registro" /> </td>
                        <td> <%# Eval("Poliza") %> </td>
                        <td> <%# Eval("Numero_Recibo") %>  </td>
                        <td> <%# Eval("Fecha") %>  </td>
                        <td> <%# Eval("Tipo") %>  </td>
                        <td> <%#string.Format("{0:n2}", Eval("Monto")) %>  </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    <br />
   <div ID="DivBloqueModificar" visible="false" runat="server">
        <div class="form-check-inline">

            <asp:Label ID="lbSeleccionarTipoPago" runat="server" Text="Seleccionar Tipo de Pago: " CssClass="Letranegrita"></asp:Label>
            <asp:RadioButton ID="rbEfectivo" runat="server" Text="EFECTIVO" ToolTip="Colocar el tipo de pago en Efectivo" CssClass="form-check-input Letranegrita" GroupName="TipoPago" />
            <asp:RadioButton ID="rbTarjeta" runat="server" Text="TARJETA" ToolTip="Colocar el tipo de pago en Tarjeta" CssClass="form-check-input Letranegrita" GroupName="TipoPago" />
            <asp:RadioButton ID="rbTransferencia" runat="server" Text="TRANSFERENCIA" ToolTip="Colocar el tipo de pago en Transferencia" CssClass="form-check-input Letranegrita" GroupName="TipoPago" />
            <asp:RadioButton ID="rbCheque" runat="server" Text="CHEQUE" ToolTip="Colocar el tipo de pago en Cheque" CssClass="form-check-input Letranegrita" GroupName="TipoPago" />
            <asp:RadioButton ID="rbOtros" runat="server" Text="OTROS" ToolTip="Colocar el tipo de pago en Otros Pagos" CssClass="form-check-input Letranegrita" GroupName="TipoPago" />
    
    </div>
    <br />
    <div align="center">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ToolTip="Guardar Información" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" ToolTip="Volver" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnVolver_Click" />
    </div>
   </div>
    <br />
</asp:Content>

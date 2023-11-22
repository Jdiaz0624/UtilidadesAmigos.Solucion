<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="UtilidadesCobros.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.UtilidadesCobros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

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



            $("#<%=btnProcesarPolizasSinPagosFinal.ClientID%>").click(function () {
                 var PolizaSinPago = $("#<%=txtPolizaSinPagos.ClientID%>").val().length;
                if (PolizaSinPago < 1) {
                    alert("El campo poliza no puede estar vacio para realizar este proceso, favor de verificar.");
                    $("#<%=txtPolizaSinPagos.ClientID%>").css("border-color", "red");
                    return false;
                }
            })


            $("#<%=btnBuscarPolizaFormaPagoFinal.ClientID%>").click(function () {
                var FormapAgo = $("#<%=txtNumeroRecibo.ClientID%>").val().length;
                if (FormapAgo < 1) {
                    alert("El campo recibo no puede estar vacio para buscar un registro, favor de verificar.");
                     $("#<%=txtNumeroRecibo.ClientID%>").css("border-color", "red");
                     return false;
                 }
            })


         });
    </script>


    <div class="container-fluid">
        <asp:HiddenField ID="hfNumeroReciboSeleccionado" runat="server" />
        <asp:HiddenField ID="hfIdPerfil" runat="server" />

        <div id="DIVBloquePrincial" runat="server">
                <br />
                <div class="row">
        <div class="d-inline-flex col-md-6">
            <asp:Label ID="lbCorreirPolizaSonPagos" runat="server" Text="Corregir Poliza sin cobro" CssClass="Letranegrita"></asp:Label>
            <asp:TextBox ID="txtPolizaSinPagos" runat="server" Height="40px" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            <asp:ImageButton ID="btnProcesarPolizasSinPagosFinal" runat="server" CssClass="BotonImagen" ToolTip="Corregir la poliza sin cobros" ImageUrl="~/ImagenesBotones/proceso.png" OnClick="btnProcesarPolizasSinPagosFinal_Click" />
        </div>
    </div>
    <br />
    <hr />
    <div class="row">
        <div class="d-inline-flex col-md-6">
            <asp:Label ID="lbConsultarPolizaFormaPago" runat="server" Text="Ingresar Recibo para cambiar forma de pago" CssClass="Letranegrita"></asp:Label>
            <asp:TextBox ID="txtNumeroRecibo" runat="server" Height="40px" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
             <asp:ImageButton ID="btnBuscarPolizaFormaPagoFinal" runat="server" CssClass="BotonImagen" ToolTip="Buscar Poliza para cambiar la forma de pago" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnBuscarPolizaFormaPagoFinal_Click" />
        </div>
    </div>
    <br />
    <div class="table-responsive">
            <table class="table table-striped">
        <thead class="table-dark">
            <tr>
                <th scope="col"> Poliza </th>
                <th scope="col"> Recibo </th>
                <th scope="col"> Fecha </th>
                <th scope="col"> Tipo </th>
                <th scope="col"> Valor </th>
                <th class="ContenidoDerecha" scope="col"> Editar </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpListadoFormaPago" runat="server">
                <ItemTemplate>
                    <asp:HiddenField ID="hfNumeroRecibo" runat="server" Value='<%# Eval("Numero_Recibo") %>' />

                    
                    <td> <%# Eval("Poliza") %> </td>
                    <td> <%# Eval("Numero_Recibo") %>  </td>
                    <td> <%# Eval("Fecha") %>  </td>
                    <td> <%# Eval("Tipo") %>  </td>
                    <td> <%#string.Format("{0:n2}", Eval("Monto")) %>  </td>
                    <td class="ContenidoDerecha"> <asp:ImageButton ID="btnSeleccionarRegistro" runat="server" CssClass="BotonImagen" ToolTip="Editar Registro" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" OnClick="btnSeleccionarRegistro_Click" /> </td>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

<br />
    </div>




        </div>

        <div id="DIVBloqueSegundario" runat="server">

                 
   <div ID="DivBloqueModificar" runat="server">
        <div class="form-check-inline">

            <asp:Label ID="lbSeleccionarTipoPago" runat="server" Text="Seleccionar Tipo de Pago: " CssClass="Letranegrita"></asp:Label> <br />
            <asp:RadioButton ID="rbEfectivo" runat="server" Text="EFECTIVO" ToolTip="Colocar el tipo de pago en Efectivo"  GroupName="TipoPago" /> <br />
            <asp:RadioButton ID="rbTarjeta" runat="server" Text="TARJETA" ToolTip="Colocar el tipo de pago en Tarjeta"  GroupName="TipoPago" /> <br />
            <asp:RadioButton ID="rbTransferencia" runat="server" Text="TRANSFERENCIA" ToolTip="Colocar el tipo de pago en Transferencia"  GroupName="TipoPago" /> <br />
            <asp:RadioButton ID="rbCheque" runat="server" Text="CHEQUE" ToolTip="Colocar el tipo de pago en Cheque"  GroupName="TipoPago" /> <br />
            <asp:RadioButton ID="rbOtros" runat="server" Text="OTROS" ToolTip="Colocar el tipo de pago en Otros Pagos"  GroupName="TipoPago" />
    
    </div>
    <br />
    <div class="ContenidoCentro">
        <asp:ImageButton ID="btnGuardarFinal" runat="server" CssClass="BotonImagen" ToolTip="Guardar Información" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" OnClick="btnGuardarFinal_Click" />
        <asp:ImageButton ID="btnVolverFinal" runat="server" CssClass="BotonImagen" ToolTip="Volver" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverFinal_Click" />
    </div>
   </div>
    <br />

        </div>
    </div>






</asp:Content>

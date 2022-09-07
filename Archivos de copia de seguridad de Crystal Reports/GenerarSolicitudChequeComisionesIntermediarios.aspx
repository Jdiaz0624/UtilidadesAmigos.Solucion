<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarSolicitudChequeComisionesIntermediarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarSolicitudChequeComisionesIntermediarios" %>
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

        .LetrasNegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        

  

                 .BotonImagen {
                   width:50px;
                   height:50px;
                 
                 }
    </style>

    <script type="text/javascript">
        function CamposFechaVacios() {
            alert("Los campos Fecha no pueden estar vacios para realizar esta operación, favor de verificar.");
        }
        function CampoFechaDesdeVacio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }

        function CodigoIntermediarioIngresadoNoValido() {
            var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val();
            alert("El codigo " + CodigoIntermediario + " ingresado no es valido para realizar esta operación favor de verificar.");
        }

        function OpcionDesarrollo() {
            alert("Esta Opción esta en desarrollo por el momento, favor de contactar a Tecnologia para saber el estatus de esta.");
        }

        function SeleccionarBanco() {
            alert("Favor de seleccionar un banco para realizar este proceso.");
            $("#<%=ddlSeleccionarBanco.ClientID%>").css("border-color", "red");
        }
       

        $(document).ready(function () {
            //VALIDAMOS EL BOTON CONSULTA
            $("#<%=btnConsultarNuevo.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para consultar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para consultar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para consultar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            //VALIDAMOS EL BOTON PROCESAR
            $("#<%=btnProcesarNuevo.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para procesar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para procesar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para procesar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

  

        })
    </script>
    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <br /><br />

        <div class="form-check-inline">
                 <asp:RadioButton ID="rbNoEndosable" runat="server" Text="No Endosable" GroupName="TipoCheque" ToolTip="Generar el tipo de cheque de manera no endosable." CssClass="LetrasNegrita" />
                 <asp:RadioButton ID="rbEndosable" runat="server" Text="Endosable" GroupName="TipoCheque" ToolTip="Generar el tipo de cheque de manera endosable." CssClass="LetrasNegrita" />
        </div>

         <div class="form-check-inline" id="DivSolicitudChequeLote" runat="server" visible="false">
  
              <asp:CheckBox ID="cbGenerarSolicitudPorLote" runat="server" Text="Generar Solicitudes por Lote" CssClass="LetrasNegrita" AutoPostBack="true" OnCheckedChanged="cbGenerarSolicitudPorLote_CheckedChanged" ToolTip="Generar las solicitudes de cheques por lotes" />
             <asp:Label ID="lbLetreroRojo" runat="server" Text="Este proceso puede tardar 5 Minutos o mas dependiendo de la cantidad de registros a procesar" Visible="false" CssClass="LetrasNegrita" ForeColor="Red"></asp:Label>

        </div>
        <br />
        <br /><br />
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediario" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbSeleccionarBanco" runat="server" Text="Seleccionar Banco" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarBanco" runat="server" ToolTip="Seleccionar Banco" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Seleccionar Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-2">
                <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txttasa" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
            </div>

             <div class="col-md-2">
                <asp:Label ID="lbMontoMinimo" runat="server" Text="Monto Minimo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtMontoMinimo" runat="server" Enabled="false" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <br /><br />
        <div align="center">
              <asp:ImageButton ID="btnConsultarNuevo" runat="server" ToolTip="Consultar Información por pantalla" OnClick="btnConsultarNuevo_Click" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" />
             <asp:ImageButton ID="btnProcesarNuevo" runat="server" ToolTip="Generar Solicitud de Cheque" OnClick="btnProcesarNuevo_Click" CssClass="BotonImagen" ImageUrl="~/Imagenes/Procesar.png" />
            <br /><br />
            <asp:Label ID="lbCantidadRegistrosTitulo" Visible="false" runat="server" Text="Cantidad de Registros ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" Visible="false" runat="server" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Visible="false" Text=" ) " CssClass="LetrasNegrita"></asp:Label>
            <br />
        </div>


            <table class="table table-striped">
                <thead class="table table-dark">
                    <tr>
            
                        <th scope="col"> Nombre </th>
                        <th scope="col"> Banco </th>
                        <th scope="col"> Monto </th>
                        <th scope="col"> Acumulado </th>
                        <th scope="col"> Total </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoRegistrosComisiones" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfCodigoIntermediario" runat="server" Value='<%# "CodigoIntermediario" %>' />
                                
                                <td> <%# Eval("NombreIntermediario") %> </td>
                                <td> <%# Eval("Banco") %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Monto")) %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Acumulado")) %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Total")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
   

      
    </div>
</asp:Content>

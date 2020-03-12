<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SolicitudSeguroLey.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.SolicitudSeguroLey" %>
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
            width:100%;
             font-weight:bold;
        }
          .LetrasNegrita {
          font-weight:bold;
          }

          .Boton {
          width:100%;
          }
          hr {border: 3px solid #666; border-radius: 300px/10px; height: 0px; text-align: center;}
    </style>
    <script type="text/javascript">
        function BloquearControles() {
            $("#btnProductosAgregados").attr("disabled", "disabled");
            $("#<%=btnGuardarRegistro.ClientID%>").attr("disabled", "disabled");
        }
        function DesbloquearControlesVehiculos() {
            $("#btnProductosAgregados").removeAttr("disabled", true);
            $("#<%=btnGuardarRegistro.ClientID%>").removeAttr("disabled", true);
        }

        function MascaraCedula() {
            $("#<%=txtNumeroIdentificacion.ClientID%>").mask("999-9999999-9");
        }
          function MascaraRnc() {
            $("#<%=txtNumeroIdentificacion.ClientID%>").mask("999-999999");
        }
        jQuery(function ($) {
            $("#<%=txtTelefono.ClientID%>").mask("(999)-999-9999");
            $("#<%=txtCelular.ClientID%>").mask("(999)-999-9999");
            $("#<%=txtOtroTelefono.ClientID%>").mask("(999)-999-9999");


        });
        $(document).ready(function () {

            $("#<%=btnSiguienteCliente.ClientID%>").click(function () {
                var Capacidad = $("#<%=txtCapacidad.ClientID%>").val().length;
                if (Capacidad < 1) {
                    alert("campo vacio");
                    $("#<%=txtCapacidad.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    DesbloquearControlesVehiculos();
                }
            });


            //SOLO NUMEROS Y LIMINAR CARACTERES
            //COBRADOR
            $("#<%=txtCodigoCobrador.ClientID%>").on('keydown keypress', function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 4 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
            });
            //INTERMEDIARIO
              $("#<%=txtCodigoIntermediario.ClientID%>").on("keydown keypress", function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 4 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
            });
        
        });
    </script>


      <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Solicitud de Seguros de Ley"></asp:Label><br />
            <asp:Label ID="lbNumeroSolicitudTirulo" runat="server" Text="Numero de Solicitud: "></asp:Label>
            <asp:Label ID="lbNumeroSolicitudVariable" runat="server" Text="0"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScripManagerSegurosLey" runat="server"></asp:ScriptManager>

                <button class="btn btn-outline-primary btn-sm" id="btnInformacionCliente" type="button" data-toggle="collapse" data-target="#InformacionCliente" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE CLIENTE
                     </button><br />
                <div class="collapse" id="InformacionCliente">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelCliente" runat="server">
                       <ContentTemplate>
                           <div class="form-row">
                       <!--NOMBRE DE CLIENTE-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbNombreCliente" runat="server" Text="Nombre de Cliente *" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtNombreCliente" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="20"></asp:TextBox>
                       </div>
                       <!--APELLIDO DE CLIENTE-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbApellidoCliente" runat="server" Text="Apellido de Cliente *" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtApellidoCLiente" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="20"></asp:TextBox>
                       </div>
                       <!--APODO DE CLIENTE-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbApodoCliente" runat="server" Text="Apodo de Cliente" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtApodoCliente" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="40"></asp:TextBox>
                       </div>
                       <!--TIPO DE IDENTIFICACION-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbSeleccionarTipoIdentificacion" runat="server" Text="Tipo de Identificación" CssClass="LetrasNegrita"></asp:Label>
                       <asp:DropDownList ID="ddlSeleccionarTipoIdentificacion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarTipoIdentificacion_SelectedIndexChanged" ToolTip="Selccionar Tipo de Identificación" CssClass="form-control"></asp:DropDownList>
                       </div>
                      <!--NUMERO DE IDENTIFICACION-->
                      <div class="form-group col-md-4">
                           <asp:Label ID="lbNumeroIdentificacion" runat="server" Text="Numero de Identificación *" CssClass="LetrasNegrita"></asp:Label>
                       <asp:TextBox ID="txtNumeroIdentificacion" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                      </div>
                       <!--TIPO DE COMPROBANTE-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbTipoComprobante" runat="server" Text="Tipo de Comprobante" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarTipoComprobante" runat="server" ToolTip="Seleccionar Tipo de Comprobante" CssClass="form-control"></asp:DropDownList>
                       </div>
                       <!--TELEFONO DE CASA-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbTelefonoCasa" runat="server" Text="Telefono *" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtTelefono" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                       </div>
                       <!--CELULAR-->
                       <div class="form-group col-md-4">
                             <asp:Label ID="lbCelular" runat="server" Text="Celular" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtCelular" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                       </div>
                       <!--TELEFONO DE OFICINA-->
                       <div class="form-group col-md-4">
                             <asp:Label ID="lbOtroTelefono" runat="server" Text="Otro Telefono" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtOtroTelefono" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                       </div>
                       <!--FECHA DE NACIMIENTO-->
                       <div class="form-group col-md-4">
                             <asp:Label ID="lbFechaNacimiento" runat="server" Text="Fecha de Nacimiento *" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                       <!--SELECCIONAR SEXO-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbSeleccionarSexo" runat="server" Text="Sexo" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarSexo" runat="server" ToolTip="Seleccionar Sexo" CssClass="form-control"></asp:DropDownList>
                       </div>
                        <!--SELECCIONAR ESTADO CIVIL-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbSeleccionarEstadoCivil" runat="server" Text="Estado Civil" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarEstadoCivil" runat="server" ToolTip="Seleccionar Estado Civil" CssClass="form-control"></asp:DropDownList>
                       </div>
                       <!--OCUPACION-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbOcupacion" runat="server" Text="Ocupación" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtOcupacion" MaxLength="150" AutoCompleteType="Disabled" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                         <!--COBRADOR-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbCodigoCobrador" runat="server" Text="Codigo de Cobrador *" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtCodigoCobrador" AutoCompleteType="Disabled" AutoPostBack="true" runat="server" CssClass="form-control" OnTextChanged="txtCodigoCobrador_TextChanged"></asp:TextBox>
                       </div>
                         <!--INTERMEDIARIO-->
                       <div class="form-group col-md-4">
                             <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Vendedor *" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtCodigoIntermediario" AutoCompleteType="Disabled" AutoPostBack="true" runat="server" CssClass="form-control" OnTextChanged="txtCodigoIntermediario_TextChanged"></asp:TextBox>
                       </div>
                         <!--PROVINCIA-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbSeleccionarProvincia" runat="server" Text="Provincia" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarProvincia" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarProvincia_SelectedIndexChanged" runat="server" ToolTip="Seleccionar Provincia" CssClass="form-control"></asp:DropDownList>
                       </div>
                         <!--MUNICIPIO-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbSeleccionarMunicipio" runat="server" Text="Municipio" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarMunicipio" runat="server" ToolTip="Seleccionar Provincia" CssClass="form-control"></asp:DropDownList>
                       </div>
                         <!--EMAIL-->
                       <div class="form-group col-md-4">
                            <asp:Label ID="lbEmail" runat="server" Text="Email" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtEmail"  runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                         <!--DIRECCION-->
                       <div class="form-group col-md-12">
                           <asp:Label ID="lbDireccion" runat="server" Text="Direción" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtDireccion" MaxLength="8000"  runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                         <!--DIRECCION DE COBRO-->
                       <div class="form-group col-md-12">
                           <asp:Label ID="lbDireccionCobro" runat="server" Text="Dirección de Cobro" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtDireccionCobro" MaxLength="8000" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                   </div>
                    <div align="center">
                        <asp:Button ID="btnSiguienteCliente" runat="server" CssClass="btn btn-outline-primary" Text="Siguiente" ToolTip="Pasar a completar los datos del vehiculo" OnClick="btnSiguienteCliente_Click" />
                    </div>
                       </ContentTemplate>
                   </asp:UpdatePanel>
                   </div>
                </div>
                <hr />
                <button class="btn btn-outline-primary btn-sm" id="btnInformacionVehiculo" type="button" data-toggle="collapse" data-target="#InformacionVehiculos" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE VEHICULOS</button><br />
                <div class="collapse" id="InformacionVehiculos">
                <div class="card card-body">
                   <div class="form-row">
                       <!--MARCA DE VEHICULO-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbMarcaVehiculo" runat="server" Text="Marca" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarMarcavehiculo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarMarcavehiculo_SelectedIndexChanged" ToolTip="Seleccionar Marca de Vehiculo" CssClass="form-control"></asp:DropDownList>
                       </div>
                       <!--MODELO DE VEHICULO-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbModeloVehiculo" runat="server" Text="Modelo" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarModeloVehiculo" runat="server" ToolTip="Seleccionar Modelo" CssClass="form-control"></asp:DropDownList>
                       </div>
                       <!--AÑO DE VEICULO-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbAnoVehiculo" runat="server" Text="Año" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtAnoVehiculo" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                        <!--CHASIS-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbClasis" runat="server" Text="Chasis" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtChasis" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                       <!--PLACA-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbPlaca" runat="server" Text="Placa" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                        <!--TIPO DE VEHICULO-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbTipoVehiculo" runat="server" Text="Tipo de Vehiculo" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarTipoVehiculo" runat="server" ToolTip="Seleccionar Tipo de Vehiculo" CssClass="form-control"></asp:DropDownList>
                       </div>
                       <!--COLOR DE VEHICULO-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbColorVehiculo" runat="server" Text="Color" CssClass="LetrasNegrita"></asp:Label>
                           <asp:DropDownList ID="ddlSeleccionarColor" runat="server" ToolTip="Seleccionar Color" CssClass="form-control"></asp:DropDownList>
                       </div>
                       <!--CAPACIDAD-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbCapacidad" runat="server" Text="Capacidad" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                       </div>
                        <!--CANTIDAD DE PASAJEROS-->
                       <div class="form-group col-md-4">
                           <asp:Label ID="lbCantidadPasajeros" runat="server" Text="Cantidad de Pasajeros" CssClass="LetrasNegrita"></asp:Label>
                           <asp:TextBox ID="txtCantidadPasajeros" runat="server" CssClass="form-control"></asp:TextBox>
                       </div>
                   </div>
                    <div align="center">
                        <button type="button" id="btnProductosAgregados" class="btn btn-outline-primary" data-toggle="modal" data-target=".bd-example-modal-lg">Vehiculos Agregados</button>
                        <asp:Button ID="btnGuardarRegistro" runat="server" Text="Guardar" ToolTip="Guardar Registros" class="btn btn-outline-primary" />
                    </div>
                   </div>
                </div>
                <hr />
                <button class="btn btn-outline-primary btn-sm" type="button" id="btnInformacionCobertura" data-toggle="collapse" data-target="#InformacionCoberturas" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE COBERTURAS
                     </button><br />
                <div class="collapse" id="InformacionCoberturas">
                <div class="card card-body">
                   INFORMACION DE COBERTURAS
                   </div>
                </div>

       
    </div>

    

</asp:Content>

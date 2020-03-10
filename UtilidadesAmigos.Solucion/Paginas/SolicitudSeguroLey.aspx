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
            width:100px;
        }
          .LetrasNegrita {
          font-weight:bold;
          }

          hr {border: 3px solid #666; border-radius: 300px/10px; height: 0px; text-align: center;}
    </style>

    <script type="text/javascript">
        function MascaraCedula() {
            $("#<%=txtNumeroIdentificacion.ClientID%>").mask("999-9999999-9");
        }
        function MascaraRNC() {
            $("#<%=txtNumeroIdentificacion.ClientID%>").mask("999-999999");
        }
        jQuery(function ($) {
            $("#<%=txtTelefonoCasa.ClientID%>").mask("(999)-999-9999");
            $("#<%=txtCelular.ClientID%>").mask("(999)-999-9999");
            $("#<%=txtOtroTelefono.ClientID%>").mask("(999)-999-9999");
        });

        $(document).ready(function () {


        });
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="LbTitulo" runat="server" Text="Solicitud de Seguros de Ley" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbTipoServicio" runat="server" Text="lbTipoServicio" Visible="false" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbProductoSeleccionado" runat="server" Visible="false" Text="Producto Seleccionado" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <div align="center">
            <asp:Label ID="lbProductoSeleccionadonombre" runat="server" Text="Producto Seleccionado" CssClass="LetrasNegrita"></asp:Label><br />
            <asp:Label ID="lbDescripcioNproducto" runat="server" Text="Descripcion" CssClass="LetrasNegrita"></asp:Label><br />
        </div>
        <hr />
        <div align="center">
            <asp:Label ID="lbTituloCliente" runat="server" Text="Datos del Cliente" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbNombreCliente" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreCliente" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbApellidoCliente" runat="server" Text="Apellido" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtApellidoCliente" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
              <div class="form-group col-md-4">
                <asp:Label ID="lbApodoCliente" runat="server"  Text="Apodo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtApodoCliente" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
            
            <div class="form-group col-md-4">
                <asp:Label ID="lbTipoIdentificacion" runat="server"  Text="Seleccionar Tipo de Identificación" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoIdentificacion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarTipoIdentificacion_SelectedIndexChanged" ToolTip="Seleccionar Tipo de Identificación" CssClass="form-control"></asp:DropDownList>
            </div>
               <div class="form-group col-md-4">
                <asp:Label ID="lbNumeroIdentificacion" runat="server" Text="RNC/Cedula" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroIdentificacion" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbTipoComproBante" runat="server" AutoCompleteType="Disabled" Text="Tipo de Comprobante" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoComprobante" runat="server" ToolTip="Seleccionar Tipo de comprobante" CssClass="form-control"></asp:DropDownList>
            </div>
                 <div class="form-group col-md-4">
                <asp:Label ID="lbTelefonoCasa" runat="server" Text="Telefono Casa" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtTelefonoCasa" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbCelular" runat="server" Text="Celular" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCelular" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbOtroTelefono" runat="server" Text="Otro Telefono" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtOtroTelefono" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbSeleccionarProvincia" runat="server"  Text="Seleccionar Provincia" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarProdincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarProdincia_SelectedIndexChanged" ToolTip="Seleccionar Provincia" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbSeleccionarSector" runat="server"  Text="Seleccionar Municipio" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarMunicipio" runat="server" ToolTip="Seleccionar Municipio" CssClass="form-control"></asp:DropDownList>
            </div>
              <div class="form-group col-md-12">
                <asp:Label ID="lbDireccionCliente" runat="server" Text="Dirección" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtDireccionCliente" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="8000"></asp:TextBox>
            </div>
          <div class="form-group col-md-12">
                <asp:Label ID="lbDireccionCobro" runat="server" Text="Dirección de Cobro" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtDireccionCobro" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="8000"></asp:TextBox>
            </div>
            </div>
             
        <hr />
        <!-- DATOS DEL VEHICULO-->
        <div align="center">
            <asp:Label ID="lbDatosVehiculosTitulo" runat="server" Text="Datos del Vehiculo" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <div class="form-row">
           
            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccioanrMarcas" runat="server" Text="Seleccionar Marca" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccioanrMarcas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccioanrMarcas_SelectedIndexChanged" ToolTip="Seleccionar Marcas" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarModelo" runat="server" Text="Seleccionar Modelo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarModelo" runat="server" ToolTip="Seleccionar Modelos" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarTipoVehiculo" runat="server" Text="Seleccionar Tipo de Vehiculo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoVehiculo" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarTipoVehiculo_SelectedIndexChanged" runat="server" ToolTip="Seleccionar Tipo de Vehiculo" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbIngresarAno" runat="server" Text="Año" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtAnoVehiculo" runat="server" TextMode="Number" MaxLength="4" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbChasis" runat="server" Text="Chasis" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtChasis" runat="server" MaxLength="100" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbPlaca" runat="server" Text="Placa" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPlaca" runat="server" MaxLength="100" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbPasajeros" runat="server" Text="Cantidad de Pasajeros" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCantidadPasajeros" TextMode="Number" runat="server" MaxLength="100" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="ddlSeleccionarCilindraje" runat="server" Text="Seleccionar Cantidad de Cilindros" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarCilindros" runat="server" ToolTip="Seleccionar Cilindros" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarCOlor" runat="server" Text="Seleccionar Color" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarColor" runat="server" ToolTip="Seleccionar Color" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarUso" runat="server" Text="Seleccionar Uso" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarUso" runat="server" ToolTip="Seleccionar Uso" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <asp:Label ID="lbServicioGrua" runat="server" Text="Servicio de Grua" CssClass="LetrasNegrita"></asp:Label><br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbSinGrua" runat="server" Text="Sin Grua" GroupName="ServicioGrua" CssClass="form-check-input" />
            </div>
             <div class="form-group form-check">
                <asp:RadioButton ID="rbGruaBasica" runat="server" Text="Grua Basica" GroupName="ServicioGrua" CssClass="form-check-input" />
            </div>
             <div class="form-group form-check">
                <asp:RadioButton ID="rbGruaSuperior" runat="server" Text="Grua Superior" GroupName="ServicioGrua" CssClass="form-check-input" />
            </div>
             <div class="form-group form-check">
                <asp:RadioButton ID="rbGruaPremium" runat="server" Text="Grua Premium" GroupName="ServicioGrua" CssClass="form-check-input" />
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbCasaConductor" runat="server" Text="Casa del Conductor" CssClass="form-check-input" />
            </div>
        </div>
       
        </div>

</asp:Content>

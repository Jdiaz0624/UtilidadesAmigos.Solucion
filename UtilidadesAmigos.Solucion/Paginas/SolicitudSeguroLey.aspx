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


    </style>


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
                <asp:Label ID="lbTipoComproBante" runat="server" AutoCompleteType="Disabled" Text="Tipo de Comprobante" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoComprobante" runat="server" ToolTip="Seleccionar Tipo de comprobante" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbTipoIdentificacion" runat="server"  Text="Seleccionar Tipo de Identificación" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoIdentificacion" runat="server" ToolTip="Seleccionar Tipo de Identificación" CssClass="form-control"></asp:DropDownList>
            </div>
               <div class="form-group col-md-4">
                <asp:Label ID="lbNumeroIdentificacion" runat="server" Text="RNC/Cedula" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroIdentificacion" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
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
                <asp:DropDownList ID="ddlSeleccionarProdincia" runat="server" ToolTip="Seleccionar Provincia" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbSeleccionarSector" runat="server"  Text="Seleccionar Sector" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSector" runat="server" ToolTip="Seleccionar Sector" CssClass="form-control"></asp:DropDownList>
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
             
          <div align="center">
            <asp:Button ID="brnSiguienteCliente" runat="server" Text="Siguiente" CssClass="btn btn-outline-primary btn-sm" ToolTip="Pasar al Siguiente Paso" OnClick="brnSiguienteCliente_Click" />
        </div>
        <hr />
        <div align="center">
            <asp:Label ID="lbDatosVehiculosTitulo" runat="server" Text="Datos del Vehiculo" CssClass="LetrasNegrita"></asp:Label>
        </div>
        </div>

</asp:Content>

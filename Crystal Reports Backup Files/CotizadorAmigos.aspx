<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="CotizadorAmigos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.CotizadorAmigos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .BloqueDerecha{
            height:50px;
            line-height:50px;
            font-size:inherit;
            margin:0 0 0 auto;
            
        }
    </style>
      <div class="page-header">
            <h1 align="center" > <small>Cotizador Futuro Seguros</small></h1>
        </div>

    <div align="right">
    <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Button ID="btnTipoCotizador" runat="server" Text="Tipo de Cotizador" ToolTip="Tipo de Cotizador" CssClass=" btn btn-outline-primary" Width="250px" OnClick="btnTipoCotizador_Click" />
        <asp:Button ID="btnValorVehiculo" runat="server" Text="Valor del Vehiculo" ToolTip="Valor del Vehiculo" CssClass=" btn btn-outline-primary" Width="250px" OnClick="btnValorVehiculo_Click" />
        <asp:Button ID="btnAnoVehiculo" runat="server"  Text="Año de Vehiculo" ToolTip="Año del Vehiculo" CssClass=" btn btn-outline-primary" Width="250px" OnClick="btnAnoVehiculo_Click" /><br />
       <asp:Button ID="btnImpuesto" runat="server"  Text="Servicios Fijos" ToolTip="Servicios Fijos" CssClass=" btn btn-outline-primary" Width="250px" OnClick="btnImpuesto_Click" />
        <asp:Button ID="btnCoalicion" runat="server"  Text="Comprensivo Incendio y Robo" ToolTip="Comprensivo Incndio y Robo"  CssClass=" btn btn-outline-primary" Width="250px" OnClick="btnCoalicion_Click" />
    </div>


 <div class="form-row">
     <div class="form-group col-md-6">
         <asp:Label ID="lbTipoCotizadorCotizador" runat="server" Text="Tipo de Cotizador"></asp:Label><br />
            <asp:DropDownList ID="ddlTipoCotizador" runat="server" AutoPostBack="true" ToolTip="<%$Resources:Traducciones,SeleccionarTipoCuota %>" CssClass="form-control" OnSelectedIndexChanged="ddlTipoCotizador_SelectedIndexChanged"></asp:DropDownList>
     </div>
       <div class="form-group col-md-6">
           <asp:Label ID="lbValorVehiculoCotizador" runat="server" Text="Valor del Vehiculo"></asp:Label>
            <asp:DropDownList ID="ddlValorVehiculo" runat="server"  ToolTip="Seleccionar el valor del vehiculo" CssClass="form-control" OnSelectedIndexChanged="ddlValorVehiculo_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
     </div>
       <div class="form-group col-md-6">
            <asp:Label ID="lbanovehiculoCotizador" runat="server" Text="Año de Vehiculo"></asp:Label>
            <asp:DropDownList ID="ddlAnoVehiculo" runat="server" ToolTip="Valor de Vehiculo" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlAnoVehiculo_SelectedIndexChanged"></asp:DropDownList>
     </div>
       <div class="form-group col-md-6">
           <asp:Label ID="lbImpuestoCotizador" runat="server" Text="<%$Resources:Traducciones,Impuesto %>"></asp:Label>
            <asp:TextBox ID="txtImpuesto" runat="server" CssClass="form-control" PlaceHolder="Impuesto" TextMode="Number" MaxLength="20"></asp:TextBox>
     </div>
       <div class="form-group col-md-6">
            <asp:Label ID="lbIncendioRobo" runat="server" Text="Comprensivo Incendio y Robo"></asp:Label>
            <asp:DropDownList ID="ddlCoalicion" runat="server" ToolTip="Comprensivo Incendio y Robo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCoalicion_SelectedIndexChanged"></asp:DropDownList>
     </div>
       <div class="form-group col-md-6">
             <asp:Label ID="lbCasaConductorCoiador" runat="server" Text="Casa del Conductor" CssClass="Label"></asp:Label>
            <asp:TextBox ID="txtCasaConductor" runat="server" CssClass="form-control" TextMode="Number" MaxLength="20" PlaceHolder="Casa del Conductor"></asp:TextBox>
     </div>
       <div class="form-group col-md-6">
                       <asp:Label ID="lbFurutoExequial" runat="server" Text="Futuro Exequial" PlaceHolder="FuturoExequial"></asp:Label>
            <asp:TextBox ID="txtFuturoExequial" runat="server" PlaceHolder="Futuro Exequial" CssClass="form-control"></asp:TextBox>
     </div>
       <div class="form-group col-md-6">
            <asp:Label ID="lbAeroAmbulancia" runat="server" Text="Aero Ambulancia"></asp:Label>
            <asp:TextBox ID="txtAeroAmbulacia" runat="server" PlaceHolder="Aeroambulancia" CssClass="form-control"></asp:TextBox>
     </div>
       <div class="form-group col-md-6">
                       <asp:Label ID="lbGruaCotizador" runat="server" Text="Servicio de Grua"></asp:Label>
            <asp:TextBox ID="txtServicioGrua" runat="server" CssClass="form-control" PlaceHolder="Servicio de Grua" TextMode="Number" MaxLength="20"></asp:TextBox>
     </div>
       <div class="form-group col-md-6">
            <asp:Label ID="lbRentaCotizador" runat="server" Text="Vehiculo Rentado"></asp:Label>
            <asp:TextBox ID="txtRentaVehiculo" runat="server" CssClass="form-control" PlaceHolder="Vehiculo Rentado" TextMode="Number" MaxLength="20"></asp:TextBox>
     </div>
       <div class="form-group col-md-6">
           <asp:Label ID="lbServicios" runat="server" ForeColor="DarkRed" Text="Servicios"></asp:Label>
            <asp:TextBox ID="txtServicios" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
     </div>
       <div class="form-group col-md-6">
           <asp:Label ID="lbTotal" runat="server" ForeColor="DarkRed" Text="Total"></asp:Label>
            <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
     </div>
 </div>
            
            
            
           
            
            <%--<asp:DropDownList ID="ddlImpuesto" runat="server" ToolTip="<%$Resources:Traducciones,SeleccionarImpesto %>" CssClass="combobox"></asp:DropDownList><br />--%>
           
          

           

           
            
            
            <div align="Center">
                <asp:Button ID="btnCalcular" runat="server" OnClick="btnCalcular_Click" Text="Cotizar" CssClass="btn btn-outline-primary"  ToolTip="Cotizar" />
                <asp:Button ID="btnRefrescar" runat="server" CssClass="btn btn-outline-primary" Text="Refrescar" ToolTip="Refrescar" OnClick="btnRefrescar_Click" />
            </div>
            <asp:Label ID="lblabelControlConsulta" runat="server" Visible="false" Text="LabelConsulta" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtControlBusqueda" runat="server" Visible="false" CssClass="Caja-Texto-Login" Placeholder="Consultar Registros"></asp:TextBox>



       

        



</asp:Content>

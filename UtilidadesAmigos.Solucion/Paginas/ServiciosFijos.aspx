<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiciosFijos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ServiciosFijos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Servicios Fijos</title>
    <link href="../Estilos/EstilosPaginas.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="ResponsiveDesing">
            <header>
                <h1><asp:Label ID="lbEncabezado" runat="server" Text="Servicios Fijos" CssClass="Label-Encabezado"></asp:Label></h1>
            </header>
            <hr />
            <div>
                <asp:Label ID="lbImpuestoServicioFijo" runat="server" Text="<%$Resources:Traducciones,ServiciosFijos %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtImpuestosServiciosFIjos" runat="server" PlaceHolder="<%$Resources:Traducciones,ServiciosFijos %>" CssClass="Caja-Texto-Login" TextMode="Number" step="0.01" MaxLength="20"></asp:TextBox>
                <asp:CheckBox ID="cbImpuestoFijo" runat="server" Text="<%$Resources:Traducciones,Fijo %>"/><br />
                <asp:Label ID="lbCasaConductorServicioFijos" runat="server" Text="<%$Resources:Traducciones,CasaConductor %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtCasaConductorServiciosFijos" runat="server" PlaceHolder="<%$Resources:Traducciones,CasaConductor %>" CssClass="Caja-Texto-Login" TextMode="Number" step="0.01" MaxLength="20"></asp:TextBox>
                <asp:CheckBox ID="cbCasaConductorFijo" runat="server" Text="<%$Resources:Traducciones,Fijo %>" /><br />
                <asp:Label ID="lbServicioGruaServicioFijo" runat="server" Text="<%$Resources:Traducciones,ServicioGrua %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtServicioGruaServicioFijo" runat="server" PlaceHolder="<%$Resources:Traducciones,ServicioGrua %>" CssClass="Caja-Texto-Login" TextMode="Number" step="0.01" MaxLength="20"></asp:TextBox>
                <asp:CheckBox ID="cbServicioGrua" runat="server" Text="<%$Resources:Traducciones,Fijo %>" /><br />
                <asp:Label ID="lbVehiculoRentado" runat="server" Text="<%$Resources:Traducciones,VehiculoRentado %>" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtVehiculoRentado" runat="server" PlaceHolder="<%$Resources:Traducciones,VehiculoRentado %>" CssClass="Caja-Texto-Login" TextMode="Number" step="0.01" MaxLength="20"></asp:TextBox>
                <asp:CheckBox ID="cbVehiculoRentado" runat="server" Text="<%$Resources:Traducciones,Fijo %>" />
                <asp:Label ID="lbFuturoExequial" runat="server" Text="Futuro Exequial" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtFuturoExequial" runat="server" PlaceHolder="Futuro Exequial" CssClass="Caja-Texto-Login" TextMode="Number" step="0.01" MaxLength="20"></asp:TextBox>
                <asp:CheckBox ID="cbFuturoExequial" runat="server" Text="<%$Resources:Traducciones,Fijo %>" /><br />
                <asp:Label ID="lbAeroAmbulancia" runat="server" Text="Aeroambulancia" CssClass="LabelFormularios"></asp:Label>
                <asp:TextBox ID="txtAeroAmbulancia" runat="server" PlaceHolder="Aeroambulancia" CssClass="Caja-Texto-Login" TextMode="Number" step="0.01" MaxLength="20"></asp:TextBox>
                <asp:CheckBox ID="cbAeroambulancia" runat="server" Text="<%$Resources:Traducciones,Fijo %>" /><br />
                <div align="Center">
                    <asp:Button ID="btnProcesar" runat="server" Text="<%$Resources:Traducciones,Guardar %>" CssClass="Botones" ToolTip="<%$Resources:Traducciones,Guardar %>" OnClick="btnProcesar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

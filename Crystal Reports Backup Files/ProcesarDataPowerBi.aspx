<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProcesarDataPowerBi.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProcesarDataPowerBi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <header class="Encabezado">

    <div  align="center">
        <h1><asp:Label ID="lbProcesarDataPowerbi" class="Label-Encabezado" Text="Procesar Data Power Bi" runat="server"></asp:Label></h1>
    </div>

         </header>
        <hr />
     <div align="center">
                <asp:RadioButton ID="rbSinCargarTabla" GroupName="Radio-Grupo1" runat="server" Text="Sin Cargar Tabla" ToolTip="Generar el archivo de exel sin cargar la tabla, este proceso mejora la velocidad" CssClass="Radio" />
                <asp:RadioButton ID="rbCargarTabla"  GroupName="Radio-Grupo1" runat="server" Text="Cargar Tabla" ToolTip="Generar Este archivo carga la tabla pero es mas lento" CssClass="Radio" />
          </div>
    <div class="Bloque-Centro">
        <div>
         
            <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Label"></asp:Label>
            <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="Texbox-Fecha" TextMode="Date" ToolTip="Fecha inicial"></asp:TextBox>
            <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Label"></asp:Label>
            <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="Texbox-Fecha" TextMode="Date" ToolTip="Fecha Final"></asp:TextBox><br />
            <asp:Label ID="lbSeleccionarData" runat="server" Text="Seleccionar Data" CssClass="Label" ></asp:Label>
            <asp:DropDownList ID="ddlSeleccionarData" runat="server" AutoPostBack="true" ToolTip="Seleccionar Data" CssClass="combobox" OnSelectedIndexChanged="ddlSeleccionarData_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="1">Produccion</asp:ListItem>
                <asp:ListItem Value="2">Reclamacion</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="Botones" ToolTip="Procesar data seleccionada" OnClick="btnProcesar_Click" />
            <asp:Label ID="lbListo" runat="server" Text="LISTO" CssClass="Label-Encabezado"></asp:Label>
        </div>
    </div>
</asp:Content>

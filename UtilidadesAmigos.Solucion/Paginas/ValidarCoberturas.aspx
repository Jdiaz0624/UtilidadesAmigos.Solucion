<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ValidarCoberturas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ValidarCoberturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="Encabezado">
        <div align="center">
            <h1><asp:Label ID="lbEncabezado" runat="server" CssClass="Label-Encabezado" Text="Validar Coberturas"></asp:Label></h1>
        </div>
      
        
    </header>
      <hr />
    <div align="Center">
            <asp:RadioButton ID="rbValidacionManual" runat="server" CssClass="Radio" Text="Validar Manual" ToolTip="Validar la cobertura Manualmente 1 a 1" GroupName="RadioB" AutoPostBack="true"/>
            <asp:RadioButton ID="rbValidarAutomatico" runat="server" CssClass="Radio" Text="Validar Automatico" ToolTip="Validar la cobertura Automaticamentnte" GroupName="RadioB" AutoPostBack="true" />
        </div>
    <div align="Center">
        <h2><asp:Label ID="lbCantidadLetrero" runat="server" Text="Cantidad :" CssClass="Label"></asp:Label> 
       <asp:Label ID="lbCantidadRegistros" runat="server" Text="0000" CssClass="Label"></asp:Label> </h2>
    </div>
        <div class="Bloque-Centro">
            <div class="Bloque-Izquierda">
                <asp:Label ID="lbCobertura" runat="server" CssClass="Label" Text="Cobertura"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarCobertura" runat="server" ToolTip="Seleccionar la cobertura a validar" CssClass="combobox" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarCobertura_SelectedIndexChanged"></asp:DropDownList>
                <asp:Label ID="lbPlan" runat="server" CssClass="Label" Text="Plan"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarplan" runat="server" CssClass="combobox" ToolTip="Seleccionar el plan segun la cobertura seleccionada"></asp:DropDownList><br />
                <asp:Label ID="lbPoliza" runat="server" CssClass="Label" Text="Poliza"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" Placeholder="Ingresar Poliza" CssClass="Caja-Texto-Login"></asp:TextBox>
                <asp:Label ID="lbChasis" runat="server" Text="Chasis" CssClass="Label"></asp:Label>
                <asp:TextBox ID="txtChasis" runat="server" CssClass="Caja-Texto-Login" Placeholder="Ingresar Chasis"></asp:TextBox>
            </div>
            <div class="Bloque-Derecha">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" ToolTip="Agregar Registro" CssClass="Botones" />
                <asp:Button ID="btnValidar" runat="server" Text="Validar" ToolTip="Validar coberturas" CssClass="Botones" /><br />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" ToolTip="Limpiar registros Guardados" CssClass="Botones" />
            </div>
        </div>
    <%--Agregamos los grid correspondientes--%>
    <div>
        
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AntiguedadSaldo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.AntiguedadSaldo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        function CamposVacios() {
            alert("Tienes que seleccionar o agregar un tipo de filtro para generar este reporte.");
            $("#<%=txtPoliza.ClientID%>").css("border-color", "blue");
            $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "blue");
            $("#<%=txtCodigoSupervisor.ClientID%>").css("border-color", "blue");
        }
    </script>

    <div class="row">
        <div class="col-md-6">
            <label class="Letranegrita">Poliza</label>
            <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
        </div>
        <div class="col-md-6">
              <label class="Letranegrita">Ramo</label>
              <asp:DropDownList ID="ddlRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="col-md-2">
             <label class="Letranegrita">Intermediario</label>
             <asp:TextBox ID="txtCodigoIntermediario" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
        </div>
        <div class="col-md-4">
             <label class="Letranegrita">Nombre</label>
             <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
        </div>
        <div class="col-md-2">
             <label class="Letranegrita">Supervisor</label>
             <asp:TextBox ID="txtCodigoSupervisor" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
        </div>
        <div class="col-md-4">
             <label class="Letranegrita">Nombre</label>
             <asp:TextBox ID="txtNombreSupervisor" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="form-check form-switch">
        <input type="checkbox" id="cbGenerarConChasisVehiculo" runat="server" class="form-check-input" />
        <label class="form-check-label Letranegrita"> Generar Información con los chasis del Vehiculo</label>
        <label class="form-check-label Letranegrita Rojo"> Nota: Esta Opción puede duplicar el registro por que va a clasificar por items</label>
    </div>
    <br />
    <div class="ContenidoCentro">
        <asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/ImagenesBotones/Excel.png" OnClick="btnExportar_Click" CssClass="BotonImagen" />
    </div>
    <br />



</asp:Content>

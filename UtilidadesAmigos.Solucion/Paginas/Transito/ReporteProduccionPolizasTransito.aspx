<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteProduccionPolizasTransito.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Transito.ReporteProduccionPolizasTransito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        function FuncioNovalida() {
            alert("Favor de Validar una Opción Valida.")
        }
    </script>
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-3">
                <label class="Letranegrita"> Fecha Desde </label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Fecha Hasta </label>
                  <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Poliza </label>
                  <asp:TextBox ID="txtPoliza" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Item </label>
                <asp:TextBox ID="txtItem" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="Letranegrita"> Supervisor </label>
                 <asp:TextBox ID="txtSUpervisor" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtSUpervisor_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita"> Nombre </label>
                 <asp:TextBox ID="txtNombreSupervisor" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="Letranegrita"> Intermediario </label>
                 <asp:TextBox ID="txtIntermediario" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtIntermediario_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita"> Nombre </label>
                 <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label class="Letranegrita"> Cliente </label>
                 <asp:TextBox ID="txtCliente" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCliente_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita"> Nombre </label>
                 <asp:TextBox ID="txtNombreCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Oficina </label>
                 <asp:DropDownList ID="ddlOficina" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOficina_SelectedIndexChanged" ToolTip="Seleccionar Oficina"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="Letranegrita"> Usuario </label>
                 <asp:DropDownList ID="ddlSeleccionarUsuario" runat="server" CssClass="form-control" ToolTip="Seleccionar Usuario"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            <label class="Letranegrita">Tipo de Reporte: </label>
            <asp:RadioButton ID="rbDetallado" runat="server" Text="Detallado" GroupName="TipoRaporte" AutoPostBack="true" OnCheckedChanged="ValidarCheck" />
            <asp:RadioButton ID="rbResumido" runat="server" Text="Resumido" GroupName="TipoRaporte" AutoPostBack="true" OnCheckedChanged="ValidarCheck" />
            <asp:RadioButton ID="rbAgrupado" runat="server" Text="Agrupado" GroupName="TipoRaporte" AutoPostBack="true" OnCheckedChanged="ValidarCheck" />
            <asp:RadioButton ID="rbPorDia" runat="server" Text="Por Dia" GroupName="TipoRaporte" AutoPostBack="true" OnCheckedChanged="ValidarCheck" />
            <br />
            <div id="DIvBloqueTipoDetallado" runat="server">
                <label class="Letranegrita"> Formato de Detalle:</label>
                <asp:RadioButton ID="rbDetalladoSinVehiculos" runat="server" Text="Sin Vehiculos" AutoPostBack="true" OnCheckedChanged="ColoresDetalle" GroupName="TipoDetalle" />
                <asp:RadioButton ID="rbDetalladoConVehiculos" runat="server" Text="Con Vehiculos" AutoPostBack="true" OnCheckedChanged="ColoresDetalle" GroupName="TipoDetalle" />
            </div>
            
            <div id="DIVBloqueAgrupado" runat="server">
                <br />
                <label class="Letranegrita">Seleccionar Tipo de Agrupación</label> <br />
                <label>1 - </label>  <asp:RadioButton ID="rbAgrupadoPorSupervisor" runat="server" AutoPostBack="true" OnCheckedChanged="ColoresAgrupados" Text="Supervisor" GroupName="Agrupado" /><br />
                <label>2 - </label>  <asp:RadioButton ID="rbAgrupadoPorIntermediario" runat="server" AutoPostBack="true" OnCheckedChanged="ColoresAgrupados" Text="Intermediario" GroupName="Agrupado" /> <br />
                <label>3 - </label>  <asp:RadioButton ID="rbAgrupadoPorRamo" runat="server" Text="Ramo" AutoPostBack="true" OnCheckedChanged="ColoresAgrupados" GroupName="Agrupado" /> <br />
                <label>4 - </label>  <asp:RadioButton ID="rbAgrupadoPorSubRamo" runat="server" Text="Sub Ramo" AutoPostBack="true" OnCheckedChanged="ColoresAgrupados" GroupName="Agrupado" /> <br />
                <label>5 - </label>  <asp:RadioButton ID="rbAgrupadoPorOficina" runat="server" Text="Oficina" AutoPostBack="true" OnCheckedChanged="ColoresAgrupados" GroupName="Agrupado" /> <br />
                <label>6 - </label>  <asp:RadioButton ID="rbAgrupadoPorUsuario" runat="server" Text="Usuario" AutoPostBack="true" OnCheckedChanged="ColoresAgrupados" GroupName="Agrupado" />
            </div>
        </div>
        <br />
        <hr />
        <div id="DivFormatoReporte" runat="server">
                <label class="Letranegrita"> Formato de Detalle:</label>
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="Formato" AutoPostBack="true" OnCheckedChanged="ColoresFormato" />
                <asp:RadioButton ID="rbExcel" runat="server" Text="Excel"  GroupName="Formato" AutoPostBack="true" OnCheckedChanged="ColoresFormato" />
             <asp:RadioButton ID="RbExcelPlano" runat="server" Text="Excel Plano"  GroupName="Formato" AutoPostBack="true" OnCheckedChanged="ColoresFormato" />
            </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnReporte" runat="server" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" CssClass="BotonImagen" OnClick="btnReporte_Click" />
        </div>
        <br />
    </div>
</asp:Content>

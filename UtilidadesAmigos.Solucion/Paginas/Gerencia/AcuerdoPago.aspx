<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AcuerdoPago.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Gerencia.AcuerdoPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        function RegistrosNoEncontrados() {
            alert("No se encontraron registros para generar este archivo, favor de validar.");
        }
    </script>

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <label class="Letranegrita"> Fecha Desde </label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label class="Letranegrita"> Fecha Hasta </label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>


            <div class="col-md-2">
                <label class="Letranegrita"> Supervisor </label>
                <asp:TextBox ID="txtSupervisor" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtSupervisor_TextChanged" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita"> Nombre </label>
                <asp:TextBox ID="txtNombreSupervisor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2"><label class="Letranegrita"> Intermediario </label>
                <asp:TextBox ID="txtIntermediario" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtIntermediario_TextChanged" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label class="Letranegrita"> Nombre </label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <label class="Letranegrita"> Poliza </label>
                <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
           
             <label class="Letranegrita">Formato de Reporte: </label>
             <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="Formato" />
              <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="Formato" />
              <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano" GroupName="Formato" />
        </div>
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporte_Click" CssClass="BotonImagen" />
        </div>
        <br />
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteCuentasProveedores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReporteCuentasProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">

        .btn-sm{
            width:90px;
        }

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        
        .BotonEspecial {
           width:100%;
           font-weight:bold;
          }


        .BotonSolicitud {
               width:50px;
               height:50px;
           }
        .BotonImagen {
               width:40px;
               height:40px;
           }
    </style>

    <script type="text/javascript">
        $(function () {

            $("#<%=btnReporte.ClientID%>").click(function () {

                var Ano = $("#<%=txtAnoConsulta.ClientID%>").val().length;
                if (Ano < 1) {

                    alert("El campo Año no puede estar vacio para generar este reporte, favor de verificar.");
                    $("#<%=txtAnoConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        })
    </script>
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lbAnoConsulta" runat="server" Text="Año" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtAnoConsulta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbCuentaConsulta" runat="server" Text="Cuenta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCuentaConsulta" runat="server" PlaceHolder="Opcional" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="col-md-4">
                <asp:Label ID="lbAuxiliarConsulta" runat="server" Text="Auxiliar" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtAuxiliarConsulta" runat="server" PlaceHolder="Opcional" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            <asp:Label ID="lbTipoReporte" runat="server" Text="Tipo de Reporte" CssClass="Letranegrita"></asp:Label>
            <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Resumido" GroupName="TipoReporte" ToolTip="Generar Reporte de Cuentas a Proveedores Resumido" />
            <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Detallado" GroupName="TipoReporte" ToolTip="Generar Reporte de Cuentas a Proveedores Detallado" />
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
        </div>
        <br />
    </div>
</asp:Content>

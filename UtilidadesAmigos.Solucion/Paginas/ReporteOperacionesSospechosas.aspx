<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteOperacionesSospechosas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ReporteOperacionesSospechosas" %>
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


        .Custom{
            width: 75px;
        }

        .Label-Encabezado{
font-size:20px;
            font-weight:bold;
        }
    </style>
      <!--INICIO DE ENCABEZADO-->
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbEncabezado" runat="server" Text="Reporte de Operaciones Sospechosas"></asp:Label>
          </div>
      </div>
      <!--FIN DE ENCABEZADO-->
    <div class="container-fluid">
        <div align="Center  ">
            <asp:Label ID="lnSeleccionarParametros" runat="server" Text="Seleccionar Parametros" CssClass="Label-Encabezado"></asp:Label>
        </div>

        <div class="form-row">
            <div class="form-group col-md-3">
                 <asp:Label ID="lbFechaDesde" runat="server"  Text="Fecha Desde"></asp:Label>
                 <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaHasta" runat="server"  Text="Fecha Hasta"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbTipoReporte" runat="server"  Text="Tipo de Reporte"></asp:Label>
          <asp:DropDownList ID="ddlTipoReporte" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div align="center">
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" ToolTip="Procesar Data" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnProcesar_Click" />
        </div>

    </div>




</asp:Content>

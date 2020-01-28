<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionDiariaContabilidad.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionDiariaContabilidad" %>
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
            <asp:Label ID="lbTitulo" runat="server" Text="Producción Diaria (Contabilidad)"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbTipoReporte" runat="server" Text="Tipo de Reporte" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoReporte" runat="server" ToolTip="Seleccionar Tipo de Reporte" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSeleccionarTipoReporte_SelectedIndexChanged">
                    <asp:ListItem Value="1">Produccion</asp:ListItem>
                    <asp:ListItem Value="2">Cobros</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                 <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                   <asp:Label ID="lbRamo" runat="server" Text="Seleccionar Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="form-group col-md-3">
                   <asp:Label ID="lbIntermediario" runat="server" Text="Codigo Intermediario" CssClass="LetrasNegrita"></asp:Label>
                 <asp:TextBox ID="txtCodigoIntermediario" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                  <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
    </div>
</asp:Content>

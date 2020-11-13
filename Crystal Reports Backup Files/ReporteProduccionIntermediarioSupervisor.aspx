<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteProduccionIntermediarioSupervisor.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ReporteProduccionIntermediarioSupervisor" %>
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
            width:90px;
        }

        .Letranegrita {
        font-weight:bold;
        }
    </style>

   <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Reporte de Producción"></asp:Label>
    </div>
   <%--    <div class="form-check-inline">
           <div class="form-group form-check">
               <asp:Label ID="lbTipoFiltro" runat="server" Text="Seleccionar Tipo de Filtro" CssClass="Letranegrita"></asp:Label><br />
               <asp:RadioButton ID="rbSupervisor" runat="server" Text="Supervisor" GroupName="FiltroPrincipal" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbIntermediario" runat="server" Text="Intermediario" GroupName="FiltroPrincipal" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbOficina" runat="server" Text="Oficina" GroupName="FiltroPrincipal" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbRamo" runat="server" Text="Ramo" ToolTip="Consultar Por Ramo" GroupName="FiltroPrincipal" CssClass="form-check-input Letranegrita" />

           </div>
       </div>
       <hr />--%>
       <div class="form-check-inline">
           <div class="form-group form-check">
               <asp:Label ID="lbEstatusPoliza" runat="server" Text="Seleccionar Estatus de Poliza" CssClass="Letranegrita"></asp:Label><br />
               <asp:RadioButton ID="rbTodas" runat="server" Text="Todas" ToolTip="Muestra todas las polizas activas y canceladas" GroupName="FiltroEstatus" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbActivas" runat="server" Text="Activas" ToolTip="Muestra solo las polizas activas" GroupName="FiltroEstatus" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbCanceladas" runat="server" Text="Canceladas" ToolTip="Muestra solo las polizas canceladas" GroupName="FiltroEstatus" CssClass="form-check-input Letranegrita" />

           </div>
       </div>
       <hr />
       <div class="form-check-inline">
           <div class="form-group form-check">
               <asp:Label ID="lbTipoInformacion" runat="server" Text="Seleccionar Tipo de Reporte" CssClass="Letranegrita"></asp:Label><br />
               <asp:RadioButton ID="rbDetalle" runat="server" Text="Reporte Detallado" GroupName="TipoReporte" ToolTip="Esta Opcion Muestra el Detalle del reporte solicitado" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbResumido" runat="server" Text="Reporte Resumido" ToolTip="Esta Opción muestra el resumen del reporte solicitado" GroupName="TipoReporte" CssClass="form-check-input Letranegrita" />
           </div>
       </div>
       <hr />
       <div class="form-row">
           <div class="form-group col-md-6">
               <asp:Label ID="lbfechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-6">
               <asp:Label ID="lbfechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-2">
               <asp:Label ID="lbCodSupervisor" runat="server" Text="Codigo de Supervisor" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtCodigoSupervisor" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-4">
               <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre de Supervisor" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtNombreSupervisor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-2">
               <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtCodigoIntermediario" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-4">
               <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre de Intermediario" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-3">
               <asp:Label ID="lbSeleccionarSucursal" runat="server" Text="Seleccionar Sucursal" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarSucursal" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
           </div>
            <div class="form-group col-md-4">
               <asp:Label ID="Label1" runat="server" Text="Seleccionar Sucursal" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
           </div>
            <div class="form-group col-md-4">
               <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Seleccionar Ramo" CssClass="Letranegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
           </div>
            <div class="form-group col-md-1">
               <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtTasa" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
           </div>
       </div>
       <br />
       <div align="center">
                     <asp:Button ID="btnConsultar" runat="server" Text="Consulta" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar por Pantalla"/>
           <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar a excel" />
           <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm" ToolTip="Generar Reporte" />

                 </div>
       <br />
       
   </div>

</asp:Content>

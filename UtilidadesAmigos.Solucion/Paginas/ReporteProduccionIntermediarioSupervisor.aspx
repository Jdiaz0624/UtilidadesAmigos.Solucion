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

    <script type="text/javascript">
        function CamposVacios() {
            alert("Has dejado campos vacios que son necesarios para realizar esta consulta, favor de verificar");
        }
        function CampoTasaVAcio() {
            alert("El campo tasa no puede estar vacio, favor de verificar");
            $("#<%=txtTasa.ClientID%>").css("border-color", "red");
        }

        function CampoFechaDesdeVAcio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHAstaVAcio() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }
        $(document).ready(function () {
            //VALIDAMOS EL CAMPO TASA
            $("#<%=btnConsultar.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                if(Tasa < 1) {
                    CampoTasaVAcio();
                }
            });

            $("#<%=btnExportar.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                if(Tasa < 1) {
                    CampoTasaVAcio();
                  }
            });

            $("#<%=btnReporte.ClientID%>").click(function () {
                var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                if(Tasa < 1) {
                    CampoTasaVAcio();
                  }
              });
        })
    </script>
   <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Reporte de Producción"></asp:Label>
    </div>
       <div class="form-check-inline">
           <div class="form-group form-check">
               <asp:Label ID="lbTipoAgrupacion" runat="server" Text="Agrupar Datos" CssClass="Letranegrita"></asp:Label><br />
               <asp:RadioButton ID="rbNoAgrupar" runat="server" Text="No agrupar" GroupName="AgruparData" ToolTip="No Agrupar Informacion" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbAgruparConcepto" runat="server" Text="Concepto" GroupName="AgruparData" ToolTip="Agrupar Informacion por Concepto" CssClass="form-check-input Letranegrita" />
                <asp:RadioButton ID="rbAgruparPorUsuarios" runat="server" Text="Usuario" GroupName="AgruparData" ToolTip="Agrupar Información por usuario" CssClass="form-check-input Letranegrita" />
         <%--      <asp:RadioButton ID="rbOficina" runat="server" Text="Oficina" GroupName="AgruparData" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbRamo" runat="server" Text="Ramo" ToolTip="Consultar Por Ramo" GroupName="AgruparData" CssClass="form-check-input Letranegrita" />--%>

           </div>
       </div>
       <hr />
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
               <asp:TextBox ID="txtCodigoSupervisor" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-4">
               <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre de Supervisor" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtNombreSupervisor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-2">
               <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtCodigoIntermediario" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
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
                     <asp:Button ID="btnConsultar" runat="server" Text="Consulta" CssClass="btn btn-outline-primary btn-sm" OnClick="btnConsultar_Click" ToolTip="Consultar por Pantalla"/>
           <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" OnClick="btnExportar_Click" ToolTip="Exportar a excel" />
           <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm" OnClick="btnReporte_Click" ToolTip="Generar Reporte" />

                 </div>
       <br />
          <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvListdoProduccion" runat="server" AllowPaging="true" OnPageIndexChanging="gvListdoProduccion_PageIndexChanging" OnSelectedIndexChanged="gvListdoProduccion_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="NumeroFacturaFormateado" HeaderText="Factura" />
                    <asp:BoundField DataField="DescripcionTipo" HeaderText="DescripcionTipo" />
                    <asp:BoundField DataField="Bruto" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Bruto" />
                    <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                </Columns  >
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" HorizontalAlign="Center" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
    </div>
    <!--FIN DEL GRID-->

       
   </div>

</asp:Content>

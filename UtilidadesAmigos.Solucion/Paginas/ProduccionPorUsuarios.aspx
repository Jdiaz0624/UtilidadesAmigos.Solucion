<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionPorUsuarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionPorUsuarios" %>
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
          /*Se lo quiero meter a Riselot*/
        }
    </style>

    <script type="text/javascript">
        function MensajeConsulta(){
            alert("Error al Mostrar la consulta, favor de verificar que los parametros esten bien correctamente")
        }
        function MensajeExportar() {
            alert("Error al Exportar la Información, favor de verificar que los parametros esten bien cor1rectamente")
        }
    </script>

    <div class="container-fluid">
        <div id="Color-Jumboton" class="jumbotron text-center">
        <asp:Label ID="lbEncabezado" runat="server" Text="Producción por Usuarios"></asp:Label>
  
</div>
    </div>

   
         <div class="container-fluid">
             <div class="form-row">
             <div class="form-group col-md-3">
                    <asp:DropDownList ID="ddlTipoReporte" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoReporte_SelectedIndexChanged">
            </asp:DropDownList>
             </div>
         </div>
             </div>

        <div class="form-group form-check">
            <div class="form-check-inline">
                <asp:CheckBox ID="cbAgregarDepartamentos" runat="server" class="form-check-input" Text="Agregar Oficina" AutoPostBack="true" OnCheckedChanged="cbAgregarDepartamentos_CheckedChanged" />
                   
            </div>
          
              <div class="form-check-inline">
                   <asp:CheckBox ID="cbAgregarUsuarios" runat="server" class="form-check-input" Text="Agregar Usuario" AutoPostBack="true" Enabled="false" OnCheckedChanged="cbAgregarUsuarios_CheckedChanged1" />
            </div>
    </div>
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-6">
                  <asp:Label ID="lbFechaDesde" class="Label" runat="server" Text="Fecha Desde"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" class="form-control" Width="200px" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            </div>

         <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbFechaHasta" class="Label" runat="server" Text="Fecha Hasta" ></asp:Label>
                <asp:TextBox ID="txtFechaHasta" class="form-control" Width="200px" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            </div>

    </div>

     <br />
        <div class="container-fluid">

        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:DropDownList ID="ddlSeleccionarOficina" AutoPostBack="true" Width="500px" CssClass="form-control" runat="server" Visible="true" OnSelectedIndexChanged="ddlSeleccionarOficina_SelectedIndexChanged1"></asp:DropDownList>
            </div>
        </div>

            <div class="form-row">
            <div class="form-group col-md-6">
                	  <asp:DropDownList ID="ddlSeleccionarDepartamento" AutoPostBack="true" Width="500px" CssClass="form-control" Visible="false" runat="server" OnSelectedIndexChanged="ddlSeleccionarDepartamento_SelectedIndexChanged1"></asp:DropDownList>
            </div>
        </div>

            <div class="form-row">
            <div class="form-group col-md-6">
                <asp:DropDownList ID="ddlSeleccionarUsuario" AutoPostBack="true" Width="500px" CssClass="form-control" runat="server" Visible="false"></asp:DropDownList>
            </div>
        </div>
            <%--<asp:Label ID="lbSeleccionarDepartamento" class="Label" runat="server" Text="Seleccionar Departamento"></asp:Label>--%>

	  </div>

       
        <div class="container-fluid">
            <asp:Button ID="btnBuscarRegistros" class="btn btn-outline-primary" runat="server" ToolTip="Buscar Registros" Text="Buscar Registros" OnClick="btnBuscarRegistros_Click" />
            <asp:Button ID="btnGenerarReporte" class="btn btn-outline-success" ToolTip="Generar el reporte de los parametros ingresados" runat="server" Text="Exportar a Excel" OnClick="btnGenerarReporte_Click" />
            <asp:Button ID="btnAtras" CssClass="btn btn-outline-dark" ToolTip="Volver Atras" runat="server" Text="Atras" OnClick="btnAtras_Click" Visible="false" />
        </div>
 

    
           
        <br />
        <div class="container-fluid">
            <asp:GridView id="gbListadoUsuarios" runat="server" AllowPaging="True" OnPageIndexChanging="gbListado_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoUsuarios_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:CommandField ButtonType="Button" HeaderText="Detalle" SelectText="Ver" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>


        </div>
        <div class="container-fluid" >
            <asp:GridView id="gbDetalle" runat="server" AllowPaging="True" OnPageIndexChanging="gbDetalle_PageIndexChanging" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbDetalle_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" HeaderText="Detalle" SelectText="Entrar" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </div>
    <br />
    <div class="container">
        <asp:Button ID="btnExportarExelDetalle" runat="server" Text="Exportar Detalle a Exel" ToolTip="Exportar el Detalle a Exel" class="btn btn-outline-success" Visible="false" OnClick="btnExportarExelDetalle_Click" />
    </div>


        <%--Esta parte es para sacar los datos al momento de seleccionar un registro del grid--%>
        <br />
        <div class="container-fluid">
            <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbFechaInicioVigencia" runat="server" Text="Inicio Vigencia"></asp:Label>
             <asp:TextBox ID="txtFechaInicioVigenciaDetalle" CssClass="form-control" runat="server" ToolTip="Inicio de Vigencia" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbFechaFinVigenciaDetalle" runat="server" Text="Fin Vigencia" CssClass="LabelFormularios"></asp:Label>
             <asp:TextBox ID="txtFechaFinVigenciaDetalle" CssClass="form-control" runat="server" ToolTip="Fin de Vigencia" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbPolizaDetalle" runat="server" Text="Poliza" ></asp:Label>
                <asp:TextBox ID="txtPolizaDetalle" runat="server" CssClass="form-control" ToolTip="Poliza del Cliente" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbNombreClienteDetalle" runat="server" Text="Cliente" ></asp:Label>
                <asp:TextBox ID="txtNombreClienteDetalle" runat="server" CssClass="form-control" ToolTip="Nombre del Cliente" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbTipoIdentificacionDetalle" runat="server" Text="Tipo de Identificacion"></asp:Label>
                <asp:TextBox ID="txtTipoIdentificacionDetalle" runat="server" CssClass="form-control" ToolTip="Tipo de Identificacion" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                  <asp:Label ID="lbIdentificacionDetalle" runat="server"  Text="Identificacion"></asp:Label>
                <asp:TextBox ID="txtIdentificacionDetalle" runat="server" CssClass="form-control" ToolTip="Identificacion" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                      <asp:Label ID="lbDireccionDetalle" runat="server" Text="Direccion"></asp:Label>
                 <asp:TextBox ID="txtDireccionDetalle" runat="server" CssClass="form-control" ToolTip="Direccion del Cliente" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbCiudadDetalle" runat="server" Text="Ciudad"></asp:Label>
                 <asp:TextBox ID="txtCiudadDetalle" runat="server" CssClass="form-control" ToolTip="Ciudad del CLiente" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbOficinaDetalle" runat="server" Text="Oficina"></asp:Label>
                 <asp:TextBox ID="txtOficinaDetalle" CssClass="form-control" runat="server" ToolTip="Oficina de la Poliza" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                  <asp:Label ID="lbTelefonoResidenciaDetalle" runat="server" Text="Telefono" ></asp:Label>
                  <asp:TextBox ID="txtTelefonoResidenciaDetalle" runat="server" CssClass="form-control" ToolTip="Telefono de Residencia del Cliente" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbTelefonoOficina" runat="server" Text="Oficina" ></asp:Label>
                  <asp:TextBox ID="txtTelefonoOficinaDetalle" runat="server" CssClass="form-control" ToolTip="Telefono de Oficina del CLiente" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbCelularDetalle" runat="server" Text="Celular"></asp:Label>
                  <asp:TextBox ID="txtCelularDetalle" runat="server" CssClass="form-control" ToolTip="Celular Del Cliente" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                  <asp:Label ID="lbSupervisorDetalle" runat="server" Text="Supervisor"></asp:Label>
                  <asp:TextBox ID="txtSupervisorDetalle" runat="server" CssClass="form-control" ToolTip="Supervisor" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbIntermediarioDetalle" runat="server" Text="Intermediario"></asp:Label>
                  <asp:TextBox ID="txtIntermediarioDetalle" runat="server" CssClass="form-control" ToolTip="Intermediario" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                   <asp:Label ID="lbTotalFacturadoDetalle" runat="server" Text="Total Facturado"></asp:Label>
                  <asp:TextBox ID="txtTotalFacturado" runat="server" CssClass="form-control" ToolTip="Total Facturado" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                   <asp:Label ID="lbTotalCobradoDetalle" runat="server" Text="Total Cobrado"></asp:Label>
                  <asp:TextBox ID="txtTotalCobradoDetalle" CssClass="form-control" runat="server" ToolTip="Total Cobrado" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                  <asp:Label ID="lbBalanceDetalle" runat="server" Text="Balance"></asp:Label>
                  <asp:TextBox ID="txtBalanceDetalle" CssClass="form-control" runat="server" ToolTip="Balance de la Poliza" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbRamoDetalle" runat="server" Text="Ramo"></asp:Label>
                  <asp:TextBox ID="txtRamoDetalle" CssClass="form-control" runat="server" ToolTip="Ramo de la Poliza" Enabled="false"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbSubramoDetalle" runat="server" Text="Seleccionar Sub Ramo"></asp:Label>
                <asp:DropDownList ID="ddlSubRamoDetalle" ToolTip="Seleccionar el Subramo de la poliza" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlSubRamoDetalle_SelectedIndexChanged"></asp:DropDownList>
             </div>

             <div class="form-group col-md-6">
                  <asp:Label ID="lbItemDetalle" runat="server" Text="Seleccionar Item"></asp:Label>
                <asp:DropDownList ID="ddlItemDetalle" runat="server" ToolTip="Seleccionar el Item a Mostrar" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlItemDetalle_SelectedIndexChanged"></asp:DropDownList>
             </div>

             <div class="form-group col-md-6">
                 <asp:Label ID="lbSumaAseguradaDetalle" runat="server" Text="Suma Asegurada"></asp:Label>
                  <asp:TextBox ID="txtSumaAseguradaDetalle" CssClass="form-control" runat="server" ToolTip="Suma Asegurada" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                  <asp:Label ID="lbTipoVehiculoDetalle" runat="server" Text="Tipo de Vehiculo"></asp:Label>
                  <asp:TextBox ID="txtTipoVehiculoDetalle" CssClass="form-control" runat="server" ToolTip="Tipo de Vehiculo" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                   <asp:Label ID="lbMarcaDetalle" runat="server" Text="Marca"></asp:Label>
                  <asp:TextBox ID="txtMarcaDetalle" CssClass="form-control" runat="server" ToolTip="Marca de Vel Vehiculo" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                   <asp:Label ID="lbModeloDetalle" runat="server" Text="Modelo"></asp:Label>
                  <asp:TextBox ID="txtModeloDetalle" CssClass="form-control" runat="server" ToolTip="Modelo del Vehiculo" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                  <asp:Label ID="lbUsoDetalle" runat="server" Text="Uso"></asp:Label>
                  <asp:TextBox ID="txtUsoDetalle" CssClass="form-control" runat="server" ToolTip="Uso del Vehiculo" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                  <asp:Label ID="lbCOlorDetalle" runat="server" Text="Color"></asp:Label>
                  <asp:TextBox ID="txtColorDetalle" CssClass="form-control" runat="server" ToolTip="Color del Vehiculo" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                   <asp:Label ID="lbAnoDetalle" runat="server" Text="Año"></asp:Label>
                  <asp:TextBox ID="txtAnoDetalle" CssClass="form-control" runat="server" ToolTip="Año del Vehiculo" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                  <asp:Label ID="lbValorVehiculoDetalle" runat="server" Text="Valor de Vehiculo"></asp:Label>
                  <asp:TextBox ID="txtValorVehiculoDetalle" CssClass="form-control" runat="server" ToolTip="Valor del Vehiculo" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                   <asp:Label ID="lbChasisDetalle" runat="server" Text="Chasis"></asp:Label>
                  <asp:TextBox ID="txtChasisDetalle" CssClass="form-control" runat="server" ToolTip="Chasis del Vehiculo" Enabled="false"></asp:TextBox>
             </div>

              <div class="form-group col-md-6">
                    <asp:Label ID="lbPlacaDetalle" runat="server" Text="Placa"></asp:Label>
                  <asp:TextBox ID="txtPlacaDetalle" CssClass="form-control" runat="server" ToolTip="Placa de Vehiculo" Enabled="false"></asp:TextBox>
             </div>
        </div>
        </div>
        <div>
    
                
                
               
               
                
                
               
                
               
              
                
                
                 <asp:GridView id="gbListadoOtrosRamos" runat="server" AllowPaging="True" OnPageIndexChanging="gbListadoOtrosRamos_PageIndexChanging" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="98%" OnSelectedIndexChanged="gbListadoOtrosRamos_SelectedIndexChanged" Visible="False">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
            </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarMarbetes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarMarbetes" %>
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
        function CampoPolizaVacio() {
            alert("El campo poliza no puede estar vacio para realizar este tipo de consulta, favor de verificar");
            $("#<%=txtPolizaConsulta.ClientID%>").css("border-color", "red");
        }
        function CamposChasisPlacaVacios() {
            alert("Para realizar una consulta por placa o por chasis, uno de los dos campos debe de estar lleno, favor de verificar");
            var CampoChasis = $("#<%=txtChasisConsulta.ClientID%>").val().length; 
            var CampoPlaca = $("#<%=txtPlacaConsulta.ClientID%>").val().length;
            if (CampoChasis < 1) {
                $("#<%=txtChasisConsulta.ClientID%>").css("border-color", "blue");
            }
            if (CampoPlaca < 1) {
                $("#<%=txtPlacaConsulta.ClientID%>").css("border-color", "blue");
            }
        }

        function PermisoDenegado() {
            alert("No tienes permiso para imprimir este registro, favor de contactar un administrador para asignar el permiso.");
        }

        function FechaDesdeVacio() {
            $("#<%=txtFechaDesdeHistorico.ClientID%>").css("border-color", "red");
            return false;
        }
        function FechaHastaHistorico() {
            $("#<%=txtFechaHastaHistorico.ClientID%>").css("border-color", "red");
            return false;
        }
    </script>

    <div class="container-fluid">
        <br /><br />
          <asp:Label ID="lbIdusuario" Visible="false" runat="server" Text="GENERAR MARBETES"></asp:Label>
        <div align="center">
            <asp:Label ID="lbSeleccionarFiltros" runat="server" Text="Seleccionar Filtros" CssClass="Letranegrita"></asp:Label><br />
            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:CheckBox ID="cbOtrosFiltros" runat="server" Text="Buscar por Chasis o Placa" AutoPostBack="true" CssClass="form-check-input Letranegrita" OnCheckedChanged="cbOtrosFiltros_CheckedChanged" />
                    <asp:RadioButton ID="rbBuscarPorChasis" Visible="false" runat="server" Text="Buscar por Chasis" GroupName="OtrosFiltros" CssClass="form-check-input Letranegrita" />
                    <asp:RadioButton ID="rbBuscarPorPlaca" Visible="false" runat="server" Text="Buscar por Placa" GroupName="OtrosFiltros" CssClass="form-check-input Letranegrita" />

                </div>
            </div><br />
            <div class="form-check-inline">
                <div class="form-group form-check">
                     <asp:RadioButton ID="rbMarbetePVC" runat="server" Text="Solo Marbete PVC" GroupName="TipoMarbete" CssClass="form-check-input Letranegrita" />
                    <asp:RadioButton ID="rbMarbeteHoja" runat="server" Text="Solo Marbete Hoja" GroupName="TipoMarbete" CssClass="form-check-input Letranegrita" />
                    <asp:RadioButton ID="rbTodosMarbetes" runat="server" Text="Ambos" GroupName="TipoMarbete" CssClass="form-check-input Letranegrita" />
                </div>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" MaxLength="50" CssClass="form-control" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbItemConsulta" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtItemConsulta" TextMode="Number" MaxLength="50" AutoCompleteType="Disabled" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbChasisConsulta" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtChasisConsulta" AutoCompleteType="Disabled" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbPlacaConsulta" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPlacaConsulta" AutoCompleteType="Disabled" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div align="center">
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <button type="button" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" id="btnHistoricoImpresion" data-target=".HistoricoImpresion">Historico</button>
        </div>
        <br />
        <div align="center">
            <asp:Label ID="lbCantidadRegistrosTirulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=")" CssClass="Letranegrita"></asp:Label>

        </div>
        <br />
           <div>
            <asp:GridView ID="gvListadoPoliza" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoPoliza_PageIndexChanging" OnSelectedIndexChanged="gvListadoPoliza_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Secuencia" HeaderText="Item" />
                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="Asegurado" HeaderText="Asegurado" />
                    <asp:BoundField DataField="InicioVigencia" HeaderText="Inicio" />
                    <asp:BoundField DataField="FinVigencia" HeaderText="Fin" />
                     <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
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
        <br />
        <div align="center">
            <asp:Label ID="lbTituloDatosPolizas" Visible="false" runat="server" Text="Información de registro seleccionado" CssClass="Letranegrita"></asp:Label><hr />
        </div>
        <!--PRIMERA LINEA-->
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbPolizaMantenimiento" runat="server" Text="Poliza" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaMantenimiento" runat="server" Enabled="false" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbCotizacionMantenimiento" runat="server" Text="Cotización" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCotizacionMantenimeinto" Enabled="false" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoClienteMantenimiento" runat="server" Visible="false" Text="Codigo de Cliente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoClienteMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbItemMantenimiento" runat="server" Text="Numero de Item" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtItemMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <!--SEGUNDA LINEA-->
             <div class="form-group col-md-3">
                <asp:Label ID="lbNombreClienteMantenimiento" runat="server" Text="Nombre de Cliente" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreClienteMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbNombreAseguradoMantenimiento" runat="server" Text="Nombre de Asegurado" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreAseguradoMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbInicioVigenciaMantenimeinto" runat="server" Text="Inicio de Vigencia" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtInicioVigenciaMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbFinVigenciaMantenimiento" runat="server" Text="Fin de Vigencia" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFinVigenciaMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <!--TERCERA LINEA-->
            <div class="form-group col-md-3">
                <asp:Label ID="lbTipoVehiculoMantenimiento" runat="server" Text="Tipo de Vehiculo" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTipoVehiculoMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbMarcaMantenimiento" runat="server" Text="Marca" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtMarcaMantenimeinto" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbModeloMantenimiento" runat="server" Text="Modelo" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtModeloMantenimeinto" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbCapacidadMantenimiento" runat="server" Text="Capacidad" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCapacidadMantenimeinto" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <!--CUARTA LINEA-->
             <div class="form-group col-md-3">
                <asp:Label ID="lbChasisMantenimiento" runat="server" Text="Chasis" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtChasisMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbPlacaMantenimiento" runat="server" Text="Placa" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPlacaMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbColorMantenimiento" runat="server" Text="Color" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtColorMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbAnoMantenimiento" runat="server" Text="Año" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtAnoMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <!--QUINTA LINEA-->
             <div class="form-group col-md-3">
                <asp:Label ID="lbUsoMantenimiento" runat="server" Text="Uso" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtUsoMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbValorVehiculo" runat="server" Text="Valor de Vehiuclo" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtValorVehiculo" Enabled="false" Visible="false" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbFianzaJudicialMantenimiento" runat="server" Text="Fianza Judicial" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFianzaJudicialMantenimiento" Enabled="false" Visible="false" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbVendedorMantenimiento" Visible="false" runat="server" Text="Vendedor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtVendedorMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <!--SEXTA LINEA-->
             <div class="form-group col-md-3">
                <asp:Label ID="lbGruaMantenimiento" runat="server" Text="Grua" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtGruaMantenimiento" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbAeroAmbulanciaMantenimiento" runat="server" Text="Aero Ambulancia" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtAeroAmbulancia" Enabled="false" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                <asp:Label ID="lbOtrosServiciosMantenimiento" runat="server" Text="Otros Servicios" Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtOtrosServiciosMantenimiento" Enabled="false" Visible="false" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>

            

        </div>
       <div align="center">
            <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbImprimirPVC" runat="server" AutoPostBack="false" GroupName="IMPRESION" OnCheckedChanged="rbImprimirPVC_CheckedChanged" Text="Imprimir en PVC" CssClass="form-check-input" ToolTip="Imprimir el marbete en PVC" />
                 <asp:RadioButton ID="rbImprimirHoja" runat="server" Text="Imprimir en Hoja" GroupName="IMPRESION" CssClass="form-check-input" ToolTip="Imprimir el marbete en Hoja" />
            </div>
        </div>
          <div align="center">
             <asp:Button ID="btnImprimirMarbete" runat="server" Visible="false" Text="Imprimir" CssClass="btn btn-outline-primary btn-sm" ToolTip="Imprimir Marbete" OnClick="btnImprimirMarbete_Click" />
               <asp:Button ID="btnRestablecer" runat="server" Text="Volver" Visible="false" CssClass="btn btn-outline-primary btn-sm" ToolTip="Volver" OnClick="btnRestablecer_Click" />
        </div>
        <br />

    </div>


        <div class="modal fade bd-example-modal-xl HistoricoImpresion" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl " role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbHistoricoImpresion" runat="server" CssClass="LetraNegrita" Text="Historico de Impresión"></asp:Label>
          </div>
         <asp:ScriptManager ID="ScripManagerHistorico" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanelHistorico" runat="server">
              <ContentTemplate>
                   <div class="form-row">
              <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaDesdeHistorico" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaDesdeHistorico" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>

              <div class="form-group col-md-3">
                  <asp:Label ID="lbFechaHastaHistorico" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaHastaHistorico" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>

              <div class="form-group col-md-3">
                  <asp:Label ID="lbPolizaHistorico" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                  <asp:TextBox ID="txtPolizaHistorico" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
              </div>

              <div class="form-group col-md-3">
                  <asp:Label ID="lbItemHistorico" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label>
                  <asp:TextBox ID="txtItemHistorico" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
              </div>
          </div>

                 <div align="center">
                    
                     <br />
                     <asp:Button ID="btnConsultarHistorico" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm" OnClick="btnConsultarHistorico_Click" />
                    <br />

                     <asp:Label ID="lbCantidadImpresoPVCTitulo" runat="server" Text="Cantidad en PVC (" CssClass="Letranegrita"></asp:Label>
                     <asp:Label ID="lbCantidadImpresoPVCVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                     <asp:Label ID="lbCantidadImpresoPVCCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
                      <asp:Label ID="lbEspacio" runat="server" Text=" - " CssClass="Letranegrita"></asp:Label>

                     <asp:Label ID="lbCantidadImpresoHojaTitulo" runat="server" Text="Cantidad en Hoja (" CssClass="Letranegrita"></asp:Label>
                     <asp:Label ID="lbCantidadImpresoHojaVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                     <asp:Label ID="lbCantidadImpresoHojaCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
                      <asp:Label ID="Label4" runat="server" Text=" - " CssClass="Letranegrita"></asp:Label>

                      <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
                     <asp:Label ID="lbCantidadRegistrosVariableHistorico" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                     <asp:Label ID="lbCantidadRegistrosCerrarHistorico" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
                     

                 </div>
                  <br />
                     <div>
            <asp:GridView ID="gvHistoricoImpresion" runat="server" AllowPaging="true" OnPageIndexChanging="gvHistoricoImpresion_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="UsuarioImprime" HeaderText="Usuario" />
                    <asp:BoundField DataField="FechaCreado" HeaderText="Fecha" />
                    <asp:BoundField DataField="CantidadImpreso" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Secuencia" HeaderText="Item" />
                    <asp:BoundField DataField="TipoImpresion" HeaderText="Tipo de Impresión" />
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
                  <br />

              </ContentTemplate>
          </asp:UpdatePanel>
       <div align="center">
             <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:RadioButton ID="rbProcesarDataResumidaHistorico" runat="server" Text="Exportar Resumido" CssClass="form-check-input Letranegrita" GroupName="Exportar" />
                          <asp:RadioButton ID="rbProcesarDataDetalleHistorico" runat="server" Text="Exportar Detalle" CssClass="form-check-input Letranegrita" GroupName="Exportar" />
                      </div>
                  </div>
            <asp:Button ID="btnExportarExelHistorixo" runat="server" Text="Exportar" ToolTip="Exportar la data a exel" CssClass="btn btn-outline-primary btn-sm" OnClick="btnExportarExelHistorixo_Click" /><br />
       </div>
          <br />
      </div>
    </div>
  </div>
</div>
</asp:Content>

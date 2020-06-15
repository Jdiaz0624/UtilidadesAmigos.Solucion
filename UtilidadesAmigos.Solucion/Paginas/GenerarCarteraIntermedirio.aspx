<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarCarteraIntermedirio.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarCarteraIntermedirio" %>
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
          .LetrasNegrita {
          font-weight:bold;
          }


    </style>
    <script type="text/javascript">
        function BloquearControles() {

             $("#btnGenerarCartera").attr("disabled", "disabled");
             $("#btnGenerarProduccion").attr("disabled", "disabled");
        }
        function ActivarControles() {

            $("#btnGenerarCartera").removeAttr("disabled", true);
            $("#btnGenerarProduccion").removeAttr("disabled",true);
        }

        function ErrorConsulta() {
            alert("Error al realizar la consulta, favor de verificar los parametros ingresados");
        }
          function OpcionFuncionando() {
            alert("Esta opcion esta funcionando");
        }

        //});
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTituloCOnsulta" runat="server" Text="Generar Cartera de Intermediario"></asp:Label>
             <asp:Label ID="lbGenerarCodifoIntermediario" runat="server" Text="Codigo Intermediario" Visible="false"></asp:Label>
            <asp:Label ID="lbCodigoUsuario" runat="server" Text="Codigo Usuario" Visible="False"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisorConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="5" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediario" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="5" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficinaConsulta" runat="server" ToolTip="Seleccionar la Oficina del Intermediario" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                 <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <div>
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
             <asp:Button ID="btnRestabelecer" runat="server" Text="Restablecer" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnRestabelecer_Click" />
             <button type="button" id="btnGenerarComision" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".GenerarComisionPOPO">Comisión</button>
            <button type="button" id="btnGenerarCartera" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".GenerarCarteraPOPO">Cartera</button>
            <button type="button" id="btnGenerarProduccion" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".GenerarProduccionPOPO">Producción</button>
            </div>
        <br />
           <div>
            <asp:GridView ID="gvListadoIntermediario" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoIntermediario_PageIndexChanging" OnSelectedIndexChanged="gvListadoIntermediario_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="CodSupervisor" HeaderText="CodSupervisor" />
                    <asp:BoundField DataField="Supervisor" HeaderText="Supervisor" />
                    <asp:BoundField DataField="Codigo" HeaderText="CodIntermediario" />
                    <asp:BoundField DataField="NombreVendedor" HeaderText="Intermediario" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
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
    </div>

    <div class="modal fade bd-example-modal-lg GenerarComisionPOPO" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
           
              <asp:Label ID="lbNombreIntermediarioComision" runat="server" Text="Nombre Intermediario"></asp:Label>
          </div>
          <div align="center">
              <asp:Label ID="lbComisionMontoPagar" runat="server" Visible="false" Text="Comision a Pagar ( " CssClass="LetrasNegrita"></asp:Label>
              <asp:Label ID="lbMontoComision" runat="server" Text="0" Visible="false" CssClass="LetrasNegrita"></asp:Label>
              <asp:Label ID="lbParentesis" runat="server" Visible="false" Text=" )" CssClass="LetrasNegrita"></asp:Label>
          </div>
          <asp:ScriptManager ID="IntermediariosScriptManager" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="GenerarComisionUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                  <div class="form-row">
                         <div class="form-group col-md-6">
                      <asp:Label ID="lbFechaDesdeGenerarComision" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                      <asp:TextBox ID="txtFechaDesdeGenerarComision" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div class="form-group col-md-6">
                         <asp:Label ID="lbFechaHastaGenerarComision" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                      <asp:TextBox ID="txtFechaHastaGenerarComision" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                  </div>
                  </div>
                  <div class="form-check-inline">
                      <div class="form-group form-check">
                          <asp:CheckBox ID="cbGenerarComisionGlobal" runat="server" AutoPostBack="true" OnCheckedChanged="cbGenerarComisionGlobal_CheckedChanged" Text="Generar Comisiones Global" CssClass="form-check-input" ToolTip="Generar las comisiones a pagar de todos los intermediarios" />
                      </div>
                  </div>
                  <br />
                  <div class="form-row">
                      <div class="form-group col-md-6">
                          <asp:Label ID="lbSeleccionarOficinaComisiones" runat="server" Visible="false" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionaroficinaComisiones" Visible="false" runat="server" CssClass="form-control" ToolTip="Seleccionar Oficina para generar las comisiones"></asp:DropDownList>
                      </div>

                       <div class="form-group col-md-6">
                          <asp:Label ID="lbSeleccionarRamoComisiones" runat="server" Visible="false" Text="Seleccionar Ramo" CssClass="LetrasNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarRamoComisiones" Visible="false" runat="server" CssClass="form-control" ToolTip="Seleccionar Ramo para generar las comisiones"></asp:DropDownList>
                      </div>
                  </div>
               <div align="center">
                      <asp:Button ID="btnGenerarComisionIntermediario" runat="server" OnClick="btnGenerarComisionIntermediario_Click"  Text="Comisión" ToolTip="Generar la comisión del intermediario seleccionado" CssClass="btn btn-outline-primary btn-sm" />
                  
               </div>
                    <br />
           <div>
            <asp:GridView ID="gvComisionIntermediario" runat="server" AllowPaging="true" OnRowDataBound="gvComisionIntermediario_RowDataBound" OnPageIndexChanging="gvComisionIntermediario_PageIndexChanging" OnSelectedIndexChanged="gvComisionIntermediario_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Bruto" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Bruto" />
                    <asp:BoundField DataField="Neto" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Neto" />
                    <asp:BoundField DataField="PorcientoComision" HeaderText="% Comisión" />
                       <asp:BoundField DataField="Comision" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Comisión" />
                       <asp:BoundField DataField="Retencion" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Retención" />
                       <asp:BoundField DataField="AvanceComision" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Avance" />
                       <asp:BoundField DataField="ALiquidar" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="A Liquidar" />
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
              </ContentTemplate>
          </asp:UpdatePanel>
          <br />
          <div align="center">
               <asp:Button ID="btnExportarExel" runat="server" OnClick="btnExportarExel_Click"  Text="Exportar" ToolTip="Exportar Data a Exel" CssClass="btn btn-outline-primary btn-sm" />
               <asp:Button ID="btnGenerarComisionGeneral" runat="server" OnClick="btnGenerarComisionGeneral_Click" Text="Comisión"  ToolTip="Generar las comisiones General" CssClass="btn btn-outline-primary btn-sm" />
          </div>
          <br />
      </div>
    </div>
  </div>
</div>


        <!--CARTERA-->
<div class="modal fade bd-example-modal-xl GenerarCarteraPOPO" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbNombreIntermediarioCartera" runat="server" Text="Nombre Intermediario"></asp:Label>
          </div>
            <br />
        
          <asp:UpdatePanel ID="UpdatePanelCaretera" runat="server">
              <ContentTemplate>
                   <div>
            <asp:GridView ID="gvCarteraIntermeiarios" runat="server" AllowPaging="true" OnPageIndexChanging="gvCarteraIntermeiarios_PageIndexChanging" OnSelectedIndexChanged="gvCarteraIntermeiarios_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="SumaAsegurada" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Suma Asegurada" />
                    <asp:BoundField DataField="prima" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Prima" />
                    <asp:BoundField DataField="TotalFacturado" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Facturado" />
                       <asp:BoundField DataField="TotalPagado" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Pagado" />
                       <asp:BoundField DataField="Balance" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Balance" />
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
              </ContentTemplate>
          </asp:UpdatePanel>
          <br />
        <div align="center">
              <asp:Button ID="btnExportarCarteraExel" runat="server" Text="Exportar" ToolTip="Exportar a Exel" CssClass="btn btn-outline-primary btn-sm" OnClick="btnExportarCarteraExel_Click" />
        </div>
          <br />
      </div>
    </div>
  </div>
</div>

<!--PRODUCCION-->
    <div class="modal fade bd-example-modal-lg GenerarProduccionPOPO" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbNombreIntermediarioProduccion" runat="server" Text="Nombre Intermediario"></asp:Label>
          </div>
          <asp:UpdatePanel ID="ProduccionUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                  <div align="center">
                      <asp:Label ID="lbTotalTitulo" runat="server" Text="Total ( " CssClass="LetrasNegrita"></asp:Label>
                      <asp:Label ID="lbTotalProduccion" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
                      <asp:Label ID="lbCierre" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
                  </div>
                  <div class="form-row">
                      <div class="form-group col-md-3">
                          <asp:Label ID="lbFechaDesdeProduccion" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                          <asp:TextBox ID="txtFechaDesdeProduccion" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                      </div>
                      <div class="form-group col-md-3">
                           <asp:Label ID="lbFechaHastaProduccion" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                          <asp:TextBox ID="txtFechaHastaProduccion" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                      </div>
                  </div>
                  <div>
                      <asp:Button ID="btnBuscarProduccion" runat="server" Text="Buscar" OnClick="btnBuscarProduccion_Click" CssClass="btn btn-outline-primary btn-sm" ToolTip="Buscar la producción del intermediario seleccionado" />
                  </div>
                  <br />
                   <div>
            <asp:GridView ID="gvListadoProduccion" runat="server" AllowPaging="true" OnRowDataBound="gvListadoProduccion_RowDataBound" OnPageIndexChanging="gvListadoProduccion_PageIndexChanging" OnSelectedIndexChanged="gvListadoProduccion_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="NoFactura" HeaderText="Factura" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Valor" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Valor" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                       <asp:BoundField DataField="Balance" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Balance" />
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
              </ContentTemplate>
          </asp:UpdatePanel>
           <div align="center">
                      <asp:Button ID="btnExportarExelProduccion" runat="server" Text="Exportar" OnClick="btnExportarExelProduccion_Click" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros a exel" />
          </div>
          <br />
      </div>
    </div>
  </div>
</div>
</asp:Content>

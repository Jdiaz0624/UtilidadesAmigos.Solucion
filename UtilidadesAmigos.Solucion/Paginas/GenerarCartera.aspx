    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarCartera.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarCartera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style type="text/css">

                      .Contenedor{
    background:#ffffff;
    padding:10px;
    overflow:hidden;
    width:500px;
}

        .messagealert {
            width: 100%;
            position: fixed;
             top:0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }

          .jumbotron{
            color:#000000; 
            background:#7BC5FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }


        .Custom{
            width: 100px;
        }

        .Comision{
            font-size:20px;
            font-weight:bold;
        }
         .LetraNegrita {
         font-weight:bold;
         }
    </style>

    <script type="text/javascript">

        function BloquearBotones() {
            $("#<%=btnExportar.ClientID%>").attr("Disabled", "Disabled");
            $("#<%=btnExportarListadoCompleto.ClientID%>").attr("Disabled", "Disabled");
            $("#<%=btnRestablecerPantalla.ClientID%>").attr("Disabled", "Disabled");
            $("#btnProduccionSupervisor").attr("Disabled", "Disabled");
        }
        function DesbloquearBotones() {
            $("#<%=btnExportar.ClientID%>").removeAttr("Disabled", true);
            $("#<%=btnExportarListadoCompleto.ClientID%>").removeAttr("Disabled", true);
            $("#<%=btnRestablecerPantalla.ClientID%>").removeAttr("Disabled", true);
            $("#btnProduccionSupervisor").removeAttr("Disabled", true);
        }

        $(document).ready(function () {
            



            $('#<%=btnConsultar.ClientID%>').click(function () {
                var CodigoSupervisor = $('#<%=txtCodigoSupervisor.ClientID%>').val().length;
                if (CodigoSupervisor < 1) {
                    $('#<%=txtCodigoSupervisor.ClientID%>').css("border-color", "red");
                   
                    alert("Favor ingresar el codigo de supervisor")
                    return false;
                }
                return true;



            })

              $("#<%=txtCodigoSupervisor.ClientID%>").on('keydown keypress', function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 4 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
            });
        })

       
    </script>

    <!--INICIO DEL ENCABEZADO-->
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezado" runat="server" Text="Cartera de Supervisores"></asp:Label><br />
            <asp:Label ID="lbNombreSupervisor" runat="server" Visible="false"></asp:Label><br />
            
        </div>
        <div align="Center">
            <asp:Label ID="lbComisionPagar" Text="Comision a Pagar: " CssClass="Comision" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lbMontoComisionPagar" Text="000000" CssClass="Comision" runat="server" Visible="false"></asp:Label>
        </div>
    </div>
    <!--FIN DEL ENCABEZADO-->


    <!--INICIO DE LOS CONTROLES DE BUSQUEDA-->

     
        <div class="container-fluid">
        <div class="form-row">
                <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo de Supervisor"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" AutoCompleteType="Disabled" PlaceHolder="Ingrese Codigo"  CssClass="form-control"></asp:TextBox>
              
           </div>
            <div class="form-group col-md-3">
                    <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre de Intermediario"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario" runat="server" PlaceHolder="Nombre de Intermediario" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="150"></asp:TextBox>
                </div>
                   </div>
            <div class="form-row">
              <%--  <div class="form-group-col-md-3">
                    <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediario" runat="server" PlaceHolder="Codigo de Intermediario" CssClass="form-control" MaxLength="4" TextMode="Number" pattern="[0-9]{2}" ></asp:TextBox>
                </div>--%>
             
            </div>
              <div class="form-group form-check">
                        <div class="form-check-inline">
                        <asp:CheckBox ID="cbComicion" runat="server" AutoPostBack="true" OnCheckedChanged="cbComicion_CheckedChanged" Text="Generar Comicion" CssClass="form-check-input" />

          </div>
                  <div class="form-check-inline">
                      <asp:CheckBox ID="cbAgregarOficina" runat="server" Text="Agregar oficina" CssClass="form-check-input" Visible="false" AutoPostBack="true" OnCheckedChanged="cbAgregarOficina_CheckedChanged" />
                  </div>
          </div>

               <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" Width="200px" TextMode="Date" CssClass="form-control" Visible="false"></asp:TextBox>
                </div>
                  <div class="form-group col-md-3">
                      <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" Visible="false"></asp:Label>
                      <asp:TextBox ID="txtFechaHasta" runat="server" Width="200px" TextMode="Date" CssClass="form-control" Visible="false"></asp:TextBox>
                </div>
                 
            </div>
            <div class="form-row">
                  <div class="form-group col-md-3">
                       <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Seleccionar Oficina" Visible="false"></asp:Label>
                       <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control" Visible="false"></asp:DropDownList>
                   </div>
            </div>
          </div>

               <div align="center">
                   <asp:Button ID="btnConsultar"  runat="server"  Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
                   <asp:Button ID="btnExportar"  runat="server" Text="Exportar" ToolTip="Exportar Registros a Exel" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
                   <asp:Button ID="btnExportarListadoCompleto" runat="server" Text="Exportar Todo" ToolTip="Exportar todo el listado de comisiones" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportarListadoCompleto_Click" />
                   <button type="button" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" id="btnProduccionSupervisor" data-target=".bd-example-modal-xl">Produccón</button>
                   <asp:Button ID="btnRestablecerPantalla" runat="server" Text="Restablecer" ToolTip="Restablecer Pantalla" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnRestablecerPantalla_Click" />
        </div>
    <br />
<!--FIN DE LOS CONTROLES DE BUSQUEDA-->

 <!--INICIO DEL GRID-->

   <%-- Agregamos el Grid para mostrar la data  gbListadoCarteraSupervisor de las coberturas--%>
     <div class="container-fluid">
           


           <asp:GridView id="gbListadoCarteraSupervisor" runat="server" AllowPaging="True" OnPageIndexChanging="gbListadoCarteraSupervisor_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoCarteraSupervisor_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                 <Columns>
                    <asp:BoundField DataField="CodIntermediario" HeaderText="IdIntermediario" />
                    <asp:BoundField DataField="Intermediario" HeaderText="Intermediario" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección"/>
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="OficinaSupervisor" HeaderText="Oficina" />
                    <asp:CommandField ButtonType="Button" HeaderText="Cliente" SelectText="Exportar" ControlStyle-CssClass="btn btn-outline-primary btn-sm Custom" ShowSelectButton="True" />
                     
                </Columns>
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

    <!--INICIO DEL GRID PARA MOSTRAR LAS COMISIONES-->
      <div class="container-fluid">
            <asp:GridView id="gbListadoComisiones" runat="server" Visible="false" AllowPaging="True" OnPageIndexChanging="gbListadoComisiones_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoComisiones_SelectedIndexChanged" OnRowDataBound="gbListadoComisiones_RowDataBound">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Intermediario" HeaderText="Vendedor" />
                    <asp:BoundField DataField="Numero" HeaderText="Factura" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina"/>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="__Comision" HeaderText="% Comisión" />
                    <asp:BoundField DataField="ComisionPagar" HeaderText="Comision Pagar" />
                </Columns>
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
    <!--FIN DEL GRID PARA MOSTRAR LAS COMISIONES-->

    <!--MODAL PARA LA PRODUCCION DE SUPERVISOR-->
    <div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbProduccionPorSupervisor" runat="server" CssClass="LetraNegrita" Text="Producción Por Supervisor"></asp:Label>
          </div>
          <asp:ScriptManager ID="ScripManagerproduccion" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanelProduccion" runat="server">
              <ContentTemplate>
                  <!--COLOCAMOS LOS COMTROLES DE BUSQUEDA-->
                  <div class="form-row" >
                      <div class="form-group col-md-4">
                          <asp:Label ID="lbFechaDesdeProduccion" runat="server" Text="Fecha Desde" CssClass="LetraNegrita"></asp:Label>
                          <asp:TextBox ID="txtFechaDesdeProduccion" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                      </div>

                       <div class="form-group col-md-4">
                          <asp:Label ID="lbFechaHastaProduccion" runat="server" Text="Fecha Hasta" CssClass="LetraNegrita"></asp:Label>
                          <asp:TextBox ID="txtFechaHastaProduccion" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionarRamoProduccion" runat="server" Text="Seleccionar Ramo" CssClass="LetraNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarRamoProduccion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarRamoProduccion_SelectedIndexChanged" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbSeleccionaSubRamoProduccion" runat="server" Text="Seleccionar Sub Ramo" CssClass="LetraNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlSeleccionarSubRamoProduccion" runat="server" ToolTip="Seleccionar Sub Ramo" CssClass="form-control"></asp:DropDownList>
                      </div>

                      <div class="form-group col-md-4">
                          <asp:Label ID="lbExcluirMotoresProduccion" Visible="false" runat="server" Text="Excluir Motores" CssClass="LetraNegrita"></asp:Label>
                          <asp:DropDownList ID="ddlExcluirMotoresProduccion" Visible="false" runat="server" ToolTip="Excluir Motores" CssClass="form-control"></asp:DropDownList>
                      </div>
                  </div>
                  <div align="center">
                      <asp:Button ID="btnConsultarProduccion"  runat="server"  Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultarProduccion_Click" />
                  </div>
                
                  <div align="center">
                      <asp:Label ID="lbTotalFacturadoTiruloProduccion" runat="server" Text="Total Producción (" CssClass="LetraNegrita"></asp:Label>
                      <asp:Label ID="lbTotalFacturadoVariableProduccion" runat="server" Text="0" CssClass="LetraNegrita"></asp:Label>
                      <asp:Label ID="lbTotalFacturadoCerrarProduccion" runat="server" Text=" )" CssClass="LetraNegrita"></asp:Label>
                  </div>
                    <br />

            <asp:GridView id="gvProduccion" runat="server"  AllowPaging="True" OnPageIndexChanging="gvProduccion_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
                    <asp:BoundField DataField="Numero" HeaderText="No Factura"/>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Valor" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Monto" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                </Columns>
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

                


              </ContentTemplate>
          </asp:UpdatePanel>
            <br />
                     <div align="center">
                      <asp:Button ID="btnExportarProduccion"  runat="server"  Text="Exportar" ToolTip="Exportar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportarProduccion_Click" />
                  </div>
          <br />
      </div>
    </div>
  </div>
</div>
</asp:Content>

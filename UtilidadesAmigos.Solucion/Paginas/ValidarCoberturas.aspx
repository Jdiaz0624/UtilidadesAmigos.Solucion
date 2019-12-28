<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ValidarCoberturas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ValidarCoberturas" %>
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
    </style>
    <script type="text/javascript">
      function OcultarControlesCoberturas() {
            $("#<%=cbEstatus.ClientID%>").hide();
            $("#<%=txtCoberturaMantenimiento.ClientID%>").attr("disabled", "disabled");
        }

        function MostrarControlesCoberturas() {
            $("#<%=cbEstatus.ClientID%>").show();
            $("#<%=txtCoberturaMantenimiento.ClientID%>").removeAttr("disabled", true);
        }

        function ActivarControlesPlanCobertura() {
            $("#<%=ddlCoberturaPlanCobertura.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtCodigoCoberturaPlanCobertura.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtPlanCobertura.ClientID%>").removeAttr("disabled", true);
             $("#<%=cbEstatusPlanCobertura.ClientID%>").removeAttr("disabled", true);

        }

        function DesactivarControlesPlanCobertura() {

            $("#<%=ddlCoberturaPlanCobertura.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtCodigoCoberturaPlanCobertura.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtPlanCobertura.ClientID%>").attr("disabled", "disabled");
            $("#<%=cbEstatusPlanCobertura.ClientID%>").attr("disabled", "disabled");

            $("#<%=txtCodigoCoberturaPlanCobertura.ClientID%>").val("");
            $("#<%=txtPlanCobertura.ClientID%>").val("");
            $("#<%=lbIdMantenimientoPlanCobertura.ClientID%>").text("0");
        }


        $(document).ready(function () {

            $("#btnPlan").click(function () {
                DesactivarControlesPlanCobertura();

            })


            //CONTROLAMOS EL EVENTO CLICK DEL BOTON COBERTURA
            $("#btnCobertura").click(function () {
                OcultarControlesCoberturas();

            })

            $("#<%=btnGuardarCobertura.ClientID%>").click(function () {
                var DescripcionCobertura = $('#<%=txtCoberturaMantenimiento.ClientID%>').val().length;
                if (DescripcionCobertura < 1) {
                    alert("El campo Descripción no puede estar vacio")
                    $("#<%=txtCoberturaMantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }

            })


            //CONTROLAMOS EL EVENTO CLICK DEL BOTON CONSULTA
            $("#<%=btnConsultar.ClientID%>").click(function () {
                //VALIDAMOS EL CAMPO COBERTURA
                var Cobertura = $("#<%=ddlSeleccionarCpbertura.ClientID%>").val();
                if (Cobertura < 1) {
                    alert("El campo cobertura no puede estar vacio")
                    $("#<%=ddlSeleccionarCpbertura.ClientID%>").css("border-color", "red");
                    return false;

                }
                else
                {
                    var PlanCobertura = $("#<%=ddlSeleccionarPlanCobertura.ClientID%>").val();
                    if (PlanCobertura < 1) {
                         alert("El campo plan de cobertura no puede estar vacio")
                    $("#<%=ddlSeleccionarPlanCobertura.ClientID%>").css("border-color", "red");
                    return false;


                    }
                }


            })

        })
    </script>
<!--INICIO DEL ENCABEZADO-->
    <div class="container-fluid">
        <div class="jumbotron" align="Center">
            <asp:Label ID="lbEncabezado" runat="server" Text="Sacar Data de Coberturas"></asp:Label>
        </div>
    </div>
<!--FIN DEL ENCABEZADO-->

<!--INICIO DE LOS MENUS DESPLEGABLES Y CONTROLES DE BUSQUEDA-->
    <div class="container-fluid">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarCobertura" runat="server" Text="Seleccionar Cobertura"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarCpbertura" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Seleccionar Cobertura" OnSelectedIndexChanged="ddlSeleccionarCpbertura_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarPlanCobertura" runat="server" Text="Seleccionar Plan"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarPlanCobertura" runat="server" ToolTip="Seleccionar un plan Segun la cobertura seleccionada" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbPolizaFiltro" runat="server" Text="Poliza"></asp:Label>
                <asp:TextBox ID="txtPolizaFiltro" runat="server" AutoCompleteType="Disabled" PlaceHolder="Numero de Poliza" MaxLength="20" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbChasisFiltro" runat="server" Text="Chasis"></asp:Label>
                <asp:TextBox ID="txtChasisFiltro" runat="server" AutoCompleteType="Disabled" PlaceHolder="Chasis" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <!--FIN DE LOS MENUS DESPLEGABLES Y CONTROLES DE BUSQUEDA-->
        <br />
        <!--INICIO DE LOS CONTROLES PARA RANGO DE FECHA-->
         <div class="form-row">
                <div class="form-group col-md-2">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" ToolTip="Inicio de Rango de fecha" TextMode="Date" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" ToolTip="Fin de Rango de fecha" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
        <!--FIN DE LOS CONTROLES PARA RANGO DE FECHA-->

        <!--INICIO DE LOS RADIOS PARA EXPORTAR-->
        <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:RadioButton ID="rbExportarExel" runat="server" Text="Exportar a Exel" CssClass="form-check-input" ToolTip="Exportar a Formato de exel" GroupName="Exportar" />
                </div>
                <div class="form-group form-check">
                    <asp:RadioButton ID="rbExportarcsv" runat="server" Text="Exportar a CSV" CssClass="form-check-input" Enabled="false" ToolTip="Exportar a Formato CSV Delimitado por |" GroupName="Exportar" />
                </div>
                <div class="form-group form-check">
                    <asp:RadioButton ID="rbExportartxt" runat="server" Text="Exportar a TXT" CssClass="form-check-input" Enabled="false" ToolTip="Exportar a formato de texto plano delimitado por |" GroupName="Exportar" />
                </div>
            </div>
        <!--FIN DE LOS RADIOS PARA EXPORTAR-->

        <!--INICIO DE LOS BOTONES-->
        <div>
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExportar_Click" />
                <button type="button" id="btnCobertura" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-lg">Coberturas</button>
             <button type="button" id="btnPlan" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".PlanCobertura">Plan</button>
        </div>
        <br />
        <!--FIN DE LOS BOTONES-->
     <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvListadoCobertura" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoCobertura_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="InicioVigencia" HeaderText="Inicio Vigencia" />
                    <asp:BoundField DataField="FinVigencia" HeaderText="Fin Vigencia" />
                    <asp:BoundField DataField="FechaProceso" HeaderText="Proceso" />
                    <asp:BoundField DataField="Cobertura" HeaderText="Cobertura" />
                    <asp:BoundField DataField="TipoMovimiento" HeaderText="TipoMovimiento" />
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



        <!--INICIO DEL POPO DE LAS COBERTURAS-->


<div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="MantenimientoCoberturas" runat="server" Text="Mantenimiento de Coberturas"></asp:Label>
              <asp:Label ID="lbIdCobertura" Visible="false" runat="server" Text="Mantenimiento de Coberturas"></asp:Label>
          </div>
         <asp:ScriptManager ID="CoberturasScript" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="CoberturaUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                   <div class="form-row">
              <div class="form-group col-md-12">
                  <asp:Label ID="Cobertura" runat="server" Text="Cobertura"></asp:Label>
                  <asp:TextBox ID="txtCoberturaMantenimiento" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <div class="form-check-inline">
              <div class="form-group form-check">
                  <asp:CheckBox ID="cbEstatus" runat="server" Text="Estatus" CssClass="form-check-input" />
              </div>
          </div>
                  <br />
                       <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gbCoberturas" runat="server" AllowPaging="true" OnPageIndexChanging="gbCoberturas_PageIndexChanging" OnSelectedIndexChanged="gbCoberturas_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="IdCobertura" HeaderText="ID" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Cobertura" />
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
    <!--FIN DEL GRID-->
              </ContentTemplate>
          </asp:UpdatePanel>
          <div align="center">
              <asp:Button ID="btnGuardarCobertura" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm" OnClick="btnGuardarCobertura_Click" />
          </div><br />
      </div>
    </div>
  </div>
</div>



           <!--INICIO DEL POPO DE LAS COBERTURAS-->


<div class="modal fade bd-example-modal-lg PlanCobertura" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="lbEncabezadoPlanCobertura" runat="server" Text="Mantenimiento de Plan de Coberturas"></asp:Label>
              <asp:Label ID="lbIdMantenimientoPlanCobertura" runat="server" Text="IdPlanCobertura" Visible="false"></asp:Label>
          </div>
          <!--INICIO DE LOS CONTROLES DEL MANTENIMIENTO-->
      
          <asp:UpdatePanel ID="PlanCoberturaUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                   <div class="form-row">
              <div class="form-group col-md-12">
                  <asp:Label ID="lbCoberturaPlanCobertura" runat="server" Text="Cobertura"></asp:Label>
                  <asp:DropDownList ID="ddlCoberturaPlanCobertura" runat="server" ToolTip="Seleccionar Cobertura" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbCodigoCobertura" runat="server" Text="Codigo de Cobertura"></asp:Label>
                  <asp:TextBox ID="txtCodigoCoberturaPlanCobertura" runat="server" MaxLength="5" TextMode="Number" CssClass="form-control" ></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbPlanCobertura" runat="server" Text="Plan de Cobertura"></asp:Label>
                  <asp:TextBox ID="txtPlanCobertura" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <div class="form-check-inline">
              <div class="form-group form-check">
                  <asp:CheckBox ID="cbEstatusPlanCobertura" runat="server" Text="Estatus" CssClass="form-check-input" />
              </div>
          </div>
          <br />
           <div>
                <asp:GridView ID="gbPlanCobertura" runat="server" AllowPaging="true" OnPageIndexChanging="gbPlanCobertura_PageIndexChanging" OnSelectedIndexChanged="gbPlanCobertura_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="IdPlanCobertura" HeaderText="ID" />
                    <asp:BoundField DataField="Cobertura" HeaderText="Cobertura" />
                    <asp:BoundField DataField="CodigoCobertura" HeaderText="Codigo Plan" />
                    <asp:BoundField DataField="PlanCobertura" HeaderText="Plan" />
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
              </ContentTemplate>
          </asp:UpdatePanel>
          <div align="center">
              <asp:Button ID="btnGuardarPlanCobertura" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm" OnClick="btnGuardarPlanCobertura_Click" ToolTip="Guardar Registro" />
    </div>
          <br />
      </div>
    </div>
  </div>
</div>

</asp:Content>

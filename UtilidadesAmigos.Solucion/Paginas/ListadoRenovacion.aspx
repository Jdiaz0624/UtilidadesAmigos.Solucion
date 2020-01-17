<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ListadoRenovacion.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ListadoRenovacion" %>
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
    <script type="text/javascript">
        function ErrorConsulta() {
            alert("Error al realizar la consulta, favor de verificar el rango de fecha");
        }
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezado" runat="server" Text="Listado de Renovación"></asp:Label>
            <asp:Label ID="lbCotizacionPoliza" runat="server" Text="Cotizacion" Visible="false" ></asp:Label>
        </div>
        <div align="center">
            <asp:Label ID="Label2" runat="server" Text=" Desde " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbMesDesde" runat="server" Text=" Mes " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="Label3" runat="server" Text="  " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="Label4" runat="server" Text=" Hasta " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbMesHasta" runat="server" Text=" Mes " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>
                  <asp:Label ID="Label5" runat="server" Text="Dias ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbDIas" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>
                  <asp:Label ID="Label8" runat="server" Text="Meses ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbMes" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label10" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label12" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>
                  <asp:Label ID="Label11" runat="server" Text="Años ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbano" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="Label13" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <!--AGREGAMOS LOS FILTROS-->
        <div class="form-row">
            <div class="form-group col-md-2">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group col-md-2">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHAsta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group col-md-4">
                        <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarRamo" AutoPostBack="true" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarRamo_SelectedIndexChanged"></asp:DropDownList>
            </div>

              <div class="form-group col-md-4">
                   <asp:Label ID="lbSeleccionarSubRamo" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarSubRamo" runat="server" ToolTip="Seleccionar SubRamo" CssClass="form-control"></asp:DropDownList>
            </div>

              <div class="form-group col-md-3">
                   <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
               <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

              <div class="form-group col-md-3">
                       <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group col-md-3">
                        <asp:Label ID="lbCodSupervisor" runat="server" Text="Cod Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" TextMode="Number" runat="server" MaxLength="5" CssClass="form-control"></asp:TextBox>
            </div>

              <div class="form-group col-md-3">
                  <asp:Label ID="lbCodIntermediario" runat="server" Text="Cod Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFCodIntermediario" TextMode="Number" runat="server" MaxLength="5" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group col-md-3">
                  <asp:Label ID="lbValidarBalance" runat="server" Text="Validar Balance" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlValidarBalance" runat="server" ToolTip="Validar Balance" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-3">
                  <asp:Label ID="lbExcluirMotores" runat="server" Visible="false" Text="Excluir Motores" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlExcluirMotorew" runat="server" Visible="false" ToolTip="Excluir Motores" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <!--FINALIZAN LOS CONTROLES DE FILTROS-->

        <!--INGRESMAOS LOS BOTONES-->
        <div>
            <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" ToolTip="Exportar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
            <button type="button" id="btnCondiciones" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".CondicionesPOPO">Condiciones</button><br /><br />
            <button type="button" id="btnCoberturas" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".CoberturasPOPO">Coberturas</button>
            <button type="button" id="btnReclamaciones" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".ReclamacionesPOPO">Reclamaciones</button>
            <button type="button" id="btnDependientes" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".DependientesPOPO">Dependientes</button>
        </div>
        <!--FINALIZAMOS LOS BOTONES-->
        <br />
        <!--INICIO DEL GRID-->
        <div>
            <asp:GridView ID="gvListadoCoberturas" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoCoberturas_PageIndexChanging" OnSelectedIndexChanged="gvListadoCoberturas_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="FechaInicioVigencia" HeaderText="Inicio" />
                    <asp:BoundField DataField="FechaFinVigencia" HeaderText="Fin" />
                    <asp:BoundField DataField="Prima" HeaderText="Prima" />
                    <asp:BoundField DataField="Facturado" HeaderText="Facturado" />
                    <asp:BoundField DataField="Cobrado" HeaderText="Cobrado" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance" />
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
    </div>
</asp:Content>

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
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGeberarTodo" runat="server" GroupName="Estatus" Text="Generar Todo" ToolTip="Generar las polizas activas y canceladas" CssClass="form-check-input" />
            </div>
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGenerarPolizasActivas" runat="server" GroupName="Estatus" Text="Polizas Activas" ToolTip="Generar Solo las polizas activas" CssClass="form-check-input" />
            </div>
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGenerarPolizasCanceladas" runat="server" GroupName="Estatus" Text="Polizas Canceladas" ToolTip="Generar solo las polizas canceladas" CssClass="form-check-input" />
            </div>
        </div>
        <!--FIN DE LOS MENUS DESPLEGABLES Y CONTROLES DE BUSQUEDA-->
        <br />
        <!--INICIO DE LOS RADIOS-->
    
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGenerarDataCompleta" runat="server" AutoPostBack="true" Text="Generar Data Completa" GroupName="Filtro" CssClass="form-check-input" OnCheckedChanged="rbGenerarDataCompleta_CheckedChanged" />
            </div>
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGenerarDataRangoFecha" runat="server" AutoPostBack="true" Text="Generar Data por Rango de Fecha" GroupName="Filtro" CssClass="form-check-input" OnCheckedChanged="rbGenerarDataRangoFecha_CheckedChanged1" />
            </div>
        </div>
        <!--FIN DE LOS RADIOS-->
        <!--INICIO DE LOS CONTROLES PARA RANGO DE FECHA-->
         <div class="form-row">
                <div class="form-group col-md-2">
                    <asp:Label ID="lbFechaDesde" runat="server" Visible="false" Text="Fecha Desde"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" Visible="false" ToolTip="Inicio de Rango de fecha" TextMode="Date" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <asp:Label ID="lbFechaHasta" runat="server" Visible="false" Text="Fecha Hasta"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" Visible="false" ToolTip="Fin de Rango de fecha" CssClass="form-control" TextMode="Date"></asp:TextBox>
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
                    <asp:BoundField DataField="Chasis" HeaderText="Chasis" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="InicioVigencia" HeaderText="Inicio Vigencia" />
                    <asp:BoundField DataField="FinVigencia" HeaderText="Fin Vigencia" />
                    <asp:BoundField DataField="Cobertura" HeaderText="Cobertura" />
                    <asp:BoundField DataField="TipoPlan" HeaderText="TipoPlan" />
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

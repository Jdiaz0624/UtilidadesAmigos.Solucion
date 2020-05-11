<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteReclamos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ReporteReclamos" %>
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
        .LetrasNegritas {
        font-weight:bold;
        }

         .btn-sm{
            width:100px;
        }
    </style>

    <script type="text/javascript">

        function Mensaje() {
            alert("Esta opción esta en desarrollo");
        }
        $(document).ready(function () {
            //RECLAMACION CONSULTA
              $("#<%=txtReclamacionConsulta.ClientID%>").on("keydown keypress", function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 20 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
            });

            //INTERMEDIARIO
              $("#<%=txtIntermediarioConsulta.ClientID%>").on("keydown keypress", function (e) {
                if (e.key.length == 1) {
                    if ($(this).val().length < 4 && !isNaN(parseFloat(e.key))) {
                        $(this).val($(this).val() + e.key);
                    }
                    return false;
                }
            });

        });
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Reporte de Reclamos"></asp:Label>
            <asp:Label ID="lbIdMantenimiento" runat="server" Text="Numero de Reclamos" Visible="false"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbNumeroReclamacionConsulta" runat="server" Text="Reclamación" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtReclamacionConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbIntermediarioConsulta" runat="server" Text="Intermediario" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtIntermediarioConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbAseguradoCOnsulta" runat="server" Text="Asegurado" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtAseguradoCOnsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbCondicionConsulta" runat="server" Text="Seleccionar Condición" CssClass="LetrasNegritas"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarCondicionConsulta" runat="server" ToolTip="Seleccionar Condición" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbBeneficiarioCOnsulta" runat="server" Text="Beneficiario" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtBeneficiarioConsulta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarTipoConsulta" runat="server" Text="Seleccionar Tipo de Reclamo" CssClass="LetrasNegritas"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoConsulta" runat="server" ToolTip="Seleccionar Tipo de Reclamo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarEstatusConsulta" runat="server" Text="Seleccionar Estatus de Reclamo" CssClass="LetrasNegritas"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarEstatutsConsulta" runat="server" ToolTip="Seleccionar Estatus de Reclamo" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbAgregarRangoFechaConsulta" runat="server" AutoPostBack="true" Text="Agregar Rango de Fecha" OnCheckedChanged="cbAgregarRangoFechaConsulta_CheckedChanged" CssClass="form-check-input" />
            </div>
            
        </div><br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbConsultarInicioVigenciaConsulta" Visible="false" runat="server" Text="inicio de Vigencia" ToolTip="Consultar mediante el Inicio de Vigencia" CssClass="form-check-input" GroupName="Consulta" />    
            </div>
             <div class="form-group form-check">
                <asp:RadioButton ID="rbConsultarFinVigencia" runat="server" Visible="false" Text="Fin de Vigencia" ToolTip="Consultar Mediante el Fin de Vigencia" CssClass="form-check-input" GroupName="Consulta" />    
            </div>
             <div class="form-group form-check">
                <asp:RadioButton ID="rbConsultarFechaApertura" runat="server" Visible="false" Text="Fecha de Apertura" ToolTip="Consultar Mediante la fecha de apertura" CssClass="form-check-input" GroupName="Consulta" />    
            </div>
            <div class="form-group form-check">
                <asp:RadioButton ID="rbConsultarFechaSiniestro" runat="server" Visible="false" Text="Fecha de Siniestro" ToolTip="Consultar Mediante la fecha de siniestro" CssClass="form-check-input" GroupName="Consulta" />    
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-3>
                <asp:Label ID="lbFechaDesdeConsulta" runat="server" Visible="false" Text="Fecha Desde" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" Visible="false" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
               <div class="form-group col-md-3>
                <asp:Label ID="lbFechHAstaConsulta" runat="server" Visible="false" Text="Fecha Hasta" CssClass="LetrasNegritas"></asp:Label>
                <asp:TextBox ID="txtFechaHAstaConsulta" runat="server" Visible="false"  TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <!--INGRESAMOS LOS BOTONES PARA LAS DISTINTAS OPERACIONES DE LA PAGINA-->
        <div>
            <asp:Button ID="btnConsultarRegistros" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Consultar" ToolTip="Consultar Registros" OnClick="btnConsultarRegistros_Click" />
            <asp:Button ID="btnExportarRegistrosConsulta" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Exportar" ToolTip="Exportar Data a Exel" OnClick="btnExportarRegistrosConsulta_Click" />
            <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".MANTENIMIENTOPOPOP">Nuevo</button>
             <button type="button" id="brnModificar" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".MANTENIMIENTOPOPOP">Modificar</button>
            <asp:Button ID="btnEliminarRegistro" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Eliminar" ToolTip="Eliminar Registro" OnClick="btnEliminarRegistro_Click" />
            <button type="button" id="btnCondicion" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".POPOCONDICIONESRECLAMOS">Condición</button>
            <button type="button" id="btnTipo" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".POPOTIPORECLAMO">Tipo</button>
            <button type="button" id="btnEstatus" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".POPOESTATUSRECLAMO">Estatus</button>
        </div>
        <br />
        <!--GRID-->
         <div>
            <asp:GridView ID="gvListadoReclamos" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoReclamos_PageIndexChanging" OnSelectedIndexChanged="gvListadoReclamos_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Reclamacion" HeaderText="Reclamación" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Asegurado" HeaderText="Asegurado" />
                    <asp:BoundField DataField="Beneficiario" HeaderText="Beneficiario" />
                    <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                    <asp:BoundField DataField="TipoReclamacion" HeaderText="Tipo" />
                    <asp:BoundField DataField="EstatusReclamacion" HeaderText="Estatus" />
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

        <!--GRID-->

        <!--MANTENIMIENTO POPOP-->
                <div class="modal fade MANTENIMIENTOPOPOP" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      MANTENIMIENTO POPOP
    </div>
  </div>
</div>
        <!--FIN DE MANTENIMIENTO POPOP-->

        <!--POPOP CONDICIONES-->
        <div class="modal fade POPOCONDICIONESRECLAMOS" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      POPOP DE CONDICIONES DE RECLAMO
    </div>
  </div>
</div>
        <!--FIN DE POPO CONDICIONES-->


<!--POPO TIPO DE RECLAMO-->
                <div class="modal fade POPOTIPORECLAMO" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      POPOP DE TIPO DE RECLAMO
    </div>
  </div>
</div>
        <!--FIN DE POPO TIPO DE RECLAMO-->


        <!--POPO ESTATUS RECLAMOS-->
         <div class="modal fade POPOESTATUSRECLAMO" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      POPOP DE ESTATUS DE RECLAMO
    </div>
  </div>
</div>
        <!--FIN DE ESTATUS ECLAMOS-->
    </div>
</asp:Content>

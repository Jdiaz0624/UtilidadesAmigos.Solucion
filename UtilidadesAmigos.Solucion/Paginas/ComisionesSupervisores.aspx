<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ComisionesSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ComisionesSupervisores" %>
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
    <script>
        function ClaveSeguridadVacia() {
            alert("El campo clave de seguridad no puede estar vacio para realizar esta operación, favor de verificar");
            $("#<%=txtClaveSeguridad.ClientID%>").css("border-color", "red");
            return false;
        }

        function ClaveIngresadanoValida() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar");

        }
    </script>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbComisionSupervisorsTitulo" runat="server" Text="Generar Comisiones de Supervisores"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaHastaConsulta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSupervisorConsulta" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisorConsulta" runat="server" CssClass="form-control" TextMode="Number" MaxLength="4"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="ldSeleccionarSucursalConsulta" runat="server" Text="Seleccionar Sucursal" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarOficinaConsulta" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficinaConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div align="center">
            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:Label ID="lbSeleccionarTipoReporte" runat="server" Text="Seleccionar Tipo de Reporte" CssClass="LetrasNegrita"></asp:Label>
                    <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Resumido" CssClass="form-check-input LetrasNegrita" GroupName="Supervisor" />
                    <asp:RadioButton ID="rbReporteDetalle" runat="server" Text="Detalle" CssClass="form-check-input LetrasNegrita" GroupName="Supervisor" />
                </div>
            </div>
            <br />
            
            
            
        </div>
        <div align="center">
              <asp:Button ID="btnConsultarComisiones" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultarComisiones_Click"  />
              <asp:Button ID="btnExortarComisiones" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExortarComisiones_Click" />
              <asp:Button ID="btnReporteCOmisiones" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm" ToolTip="Reporte de Comisiones" OnClick="btnReporteCOmisiones_Click" />
                    <button type="button" id="btnCodigosPermitidos" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".CodigosPermitodos">Codigos</button>
          </div>
          <br />
                      <asp:GridView ID="gvComisionSupervisor" runat="server" AllowPaging="true" OnPageIndexChanging="gvComisionSupervisor_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Supervisor" HeaderText="Supervisor" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
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

          <br />

    </div>


             <div class="modal fade bd-example-modal-xl CodigosPermitodos" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTituloCodigosPermitidos" runat="server" Text="Codigos de Supervisores Permitidos"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScripManagerCodigosPermitidos" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelCodigosPermitidos" runat="server">
            <ContentTemplate>
<div class="container-fluid">
                    <!--CAMPO PARA LA VALIDAR LA CLAVE DE SEGURIDAD-->
                <div class="form-row">
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbClaveSeguridad" runat="server" Text="Ingresar Clave de Seguridad" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtClaveSeguridad" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
                        <asp:Button ID="btnValidarClaveSeguridad" runat="server" OnClick="btnValidarClaveSeguridad_Click" CssClass="btn btn-outline-primary btn-sm" ToolTip="Validar la Clave de Seguridad" Text="Validar" />
                    </div>
                </div>
                <div class="form-row">
                     <div class="form-group col-md-3">
                        <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtCodigoSupervisor" runat="server" CssClass="form-control" TextMode="Number" MaxLength="4"></asp:TextBox>
                    </div>
        
                     <div class="form-group col-md-3">
                        <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control"  MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <br />
                  <div align="center">
                        <asp:Button ID="btnBuscarRegistros" runat="server" OnClick="btnBuscarRegistros_Click" CssClass="btn btn-outline-primary btn-sm" ToolTip="Buscar registros" Text="Buscar" />
                    </div>
                <br />
                   <div>
            <asp:GridView ID="gvInformacionSupervisor" runat="server" AllowPaging="true" OnPageIndexChanging="gvInformacionSupervisor_PageIndexChanging" OnSelectedIndexChanged="gvInformacionSupervisor_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
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
                <br />
                <!--DATOS DEL SUPERVISOR A PROCESAR-->
                <div class="form-row">
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbCodigoSupervisorMantenimientio" runat="server" Visible="false" Text="Codigo de Supervisor"></asp:Label>
                        <asp:TextBox ID="txtCodigoSupervisorMantenimiento" runat="server" Enabled="false" Visible="false" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbNombreSupervisorMantenimiento" runat="server" Visible="false" Text="Nombre de Supervisor"></asp:Label>
                        <asp:TextBox ID="txtNombreSupervisorMantenimientio" runat="server" CssClass="form-control" Enabled="false" Visible="false"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbOficinaSupervisorMantenimiento" runat="server" Visible="false" Text="Oficina de Supervisor"></asp:Label>
                        <asp:TextBox ID="txtOficinaSupervisorMantenimienti" runat="server" Enabled="false" Visible="false" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbEstatusSupervisorMantenimiento" runat="server" Visible="false" Text="Estatus de Supervisor"></asp:Label>
                        <asp:TextBox ID="txtEstatusSupervisirMantenimiento" runat="server" Enabled="false" Visible="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                
                    <div align="center">
                        <asp:Button ID="btnGuardarDato" runat="server" OnClick="btnGuardarDato_Click" CssClass="btn btn-outline-primary btn-sm" Visible="false" ToolTip="Guardar registros" Text="Guardar" />
                         <asp:Button ID="btnEliminarDato" runat="server" OnClick="btnEliminarDato_Click" CssClass="btn btn-outline-primary btn-sm" Visible="false" Enabled="false" ToolTip="Eliminar registros" Text="Eliminar" />
                        <asp:Button ID="btnRestablecer" runat="server" OnClick="btnRestablecer_Click" CssClass="btn btn-outline-primary btn-sm" Visible="false" ToolTip="Restablecer Pantalla" Text="Restablecer" />
                    </div>
                <br />
    <div align="center">
        <asp:Label ID="lbTituloGrid" runat="server" Text="Listado de Supervisores Permitidos para generar comisión" CssClass="LetrasNegrita"></asp:Label>
    </div>
                        <div>
            <asp:GridView ID="gvCodigosPermitidos" runat="server" AllowPaging="true" OnPageIndexChanging="gvCodigosPermitidos_PageIndexChanging" OnSelectedIndexChanged="gvCodigosPermitidos_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="IdRegistro" HeaderText="IdRegistro" />
                    <asp:BoundField DataField="CodigoSupervisor" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Supervisor" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
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
</div>
                   
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
  </div>
</div>
</asp:Content>

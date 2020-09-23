<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="IntermediariosSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.IntermediariosSupervisores" %>
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

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Mantenimiento Intermediario / Supervisor"></asp:Label>
        </div>
     
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediarioCosulta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre Intermediario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediarioCOnsulta" runat="server" CssClass="form-control" MaxLength="100" ></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbSelecionarOficina" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficinaConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
        </div><br />
        <div align="center">
            <asp:Button ID="btnCOnsultarRegistros" runat="server" Text="Consultar" ToolTip="Consultar Registros" OnClick="btnCOnsultarRegistros_Click" CssClass="btn btn-outline-primary btn-sm"/>
            <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoIntermediario">Nuevo</button>
            <button type="button" id="btnModificar" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoIntermediario">Editar</button>
            <button type="button" id="btnComisiones" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".ComisionesIntermediario">Comisiones</button>
        </div>
        <br />
      <div>
              <asp:GridView ID="gvIntermediarios" runat="server" AllowPaging="true" OnPageIndexChanging="gvIntermediarios_PageIndexChanging" OnSelectedIndexChanged="gvIntermediarios_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="#" HeaderText="Codigo" />
                    <asp:BoundField DataField="#" HeaderText="Intermediario" />
                    <asp:BoundField DataField="#" HeaderText="Estatus" />
                    <asp:BoundField DataField="#" HeaderText="Oficina" />
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



                               <div class="form-check-inline">
            <div class="form-group form-check">
               <asp:RadioButton ID="rbRetensionSiMantenimiento" runat="server" GroupName="Retencion" Text="Retención Si" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbRetensionNOMantenimiento" runat="server" GroupName="Retencion" Text="Retención No" CssClass="form-check-input Letranegrita" />
                <asp:Label ID="LBsEPARADOR1" runat="server" Text=" | " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbEstatusMantenimiento" runat="server" GroupName="Estatus" Text="Activo" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbEstatusInactivoMantenimiento" runat="server" GroupName="Estatus" Text="Inactivo" CssClass="form-check-input Letranegrita" />
                <asp:Label ID="LBsEPARADOR2" runat="server" Text=" | " CssClass="Letranegrita"></asp:Label>
                 <asp:RadioButton ID="rbIntermediarioDirecto" runat="server" GroupName="Directo" Text="Intermediario Directo" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbIntermediarioNoDirecto" runat="server" GroupName="Directo" Text="Intermediario No Directo" CssClass="form-check-input Letranegrita" />

            </div>
        </div>
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Label ID="lbFechaEntradaMantenimiento" runat="server" Text="Fecha de Entrada" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtFechaEntradaMantenimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-3">
                            <asp:Label ID="lbFechaNacimientoMantenimiento" runat="server" Text="Fecha de Nacimiento" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtFechaMAcimientoMantenimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-3">
                            <asp:Label ID="lbSeleccionarTipoIdentificacionMantenimiento" runat="server" Text="Seleccionr Tipo de Identificación" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarTipoIdentificacionMantenimiento" runat="server" ToolTip="Seleccionar Tipo de Identificacion" CssClass="form-control"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-3">
                            <asp:Label ID="lbNumeroIdentificacionMantenimiento" runat="server" Text="Numero de identificación" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNumeroIdentificacionMantenimiento" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lbApellidoIntermediarioMantenimiento" runat="server" Text="Apellido" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtApellidoIntermediarioMantenimiento" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lbNombreIntermediarioMantenimiento" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNombreIntermediarioMantenimiento" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12">
                            <asp:Label ID="lbDireccionIntermediarioMantenimiento" runat="server" Text="Dirección" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtDireccionntermediarioMantenimiento" runat="server" CssClass="form-control" MaxLength="250"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12">
                            <asp:Label ID="lbContactoIntermediarioMantenimiento" runat="server" Text="Contacto Intermediario" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtContactoIntermediarioMantenimiento" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!--UBICACION DE INTERMEDIARIOS-->
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarPaisMantenimiento" runat="server" Text="Seleccionar Pais" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarPaisMantenimiento" runat="server" ToolTip="Seleccionar Pais" CssClass="form-control"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarZonaMantenimiento" runat="server" Text="Seleccionar Zona" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarZonaMantenimiento" runat="server" ToolTip="Seleccionar Zona" CssClass="form-control"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarProvinciaMantenimiento" runat="server" Text="Seleccionar Provincia" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarProvinciaMantenimiento" runat="server" ToolTip="Seleccionar Provincia" CssClass="form-control"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbseleccionarMunicipioMantenimiento" runat="server" Text="Seleccionar Municipio" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarMunicipioMantenimiento" runat="server" ToolTip="Seleccionar Municipio" CssClass="form-control"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarSectorMantenimiento" runat="server" Text="Seleccionar Sector" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarSectorMantenimiento" runat="server" ToolTip="Seleccionar Sector" CssClass="form-control"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarUbicacionMantenimiento" runat="server" Text="Seleccionar Ubicación" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarUbicacionMantenimiento" runat="server" ToolTip="Seleccionar Ubicación" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-3">
                            <asp:Label ID="lbCodigoSupervisorMantenimiento" runat="server" Text="Codigo de Supervisor" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtCodigoSupervisor" runat="server" OnTextChanged="txtCodigoSupervisor_TextChanged" AutoPostBack="true" TextMode="Number" MaxLength="4" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-9">
                            <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre de Supervisor" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNombreSupervisor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-6">
                            <asp:Label ID="ddlSeleccionarOficinaIntermediarioMantenimiento" runat="server" Text="Seleccionar Oficina" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarOficinaIntermeiarioMantenimiento" runat="server" ToolTip="Seleccionar la Oficina del Intermediario" CssClass="form-control"></asp:DropDownList>
                        </div>

                          <div class="form-group col-md-6">
                            <asp:Label ID="lbSeleccionarBancoIntermediarioMantenimiento" runat="server" Text="Seleccionar Banco" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarBancoIntermediarioMantenimeitto" runat="server" ToolTip="Seleccionar el Banco del Intermediario" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-6">
                            <asp:Label ID="lbCuentaBancoMantenimiento" runat="server" Text="Numero de Cuenta" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNumeroCuentaBancoMantenimiento" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lbSeleccionarCanalDistribucionMantenimiento" runat="server" Text="Seleccionar canal de distribución" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarCanalDistribucionMantenimiento" runat="server" ToolTip="Seleccionar Canal de distribución" CssClass="form-control"></asp:DropDownList>
                        </div>
                      
                        
                    </div>
        <asp:Label ID="lbTipoCuentaBancoMantenimiento" runat="server" Text="Tipo de Cuenta" CssClass="Letranegrita"></asp:Label><br />
        <div class="form-check-inline">
            
            <asp:RadioButton ID="rbCuentaAhorroMantenimiento" runat="server" Text="Cuenta de Ahorro" CssClass="form-check-input Letranegrita" GroupName="TipoCuentas" />
            <asp:RadioButton ID="rbCuentaCorrienteMantenimiento" runat="server" Text="Cuenta Corriente" CssClass="form-check-input Letranegrita" GroupName="TipoCuentas" />
            <asp:RadioButton ID="rbTarjetaMantenimiento" runat="server" Text="Tarjeta" CssClass="form-check-input Letranegrita" GroupName="TipoCuentas" />
            <asp:RadioButton ID="rbPrestamoMantenimiento" runat="server" Text="Prestamo" CssClass="form-check-input Letranegrita" GroupName="TipoCuentas" />
        </div>
        <br />

        <asp:Label ID="lbTipoCobroTitulo" runat="server" Text="Tipo de Cobro" CssClass="Letranegrita"></asp:Label><br />
          <div class="form-check-inline">
            <asp:RadioButton ID="rbCobroChequesMantenimiento" runat="server" Text="Cuenta de Ahorro" CssClass="form-check-input Letranegrita" GroupName="TipoCobro" />
            <asp:RadioButton ID="rbCobroEfectivoMantenimiento" runat="server" Text="Cuenta Corriente" CssClass="form-check-input Letranegrita" GroupName="TipoCobro" />
            <asp:RadioButton ID="rbCobroTransferenciaMantenimiento" runat="server" Text="Tarjeta" CssClass="form-check-input Letranegrita" GroupName="TipoCobro" />
            <asp:RadioButton ID="rbCobroCuentasPorPagarMantenimiento" runat="server" Text="Cuentas Por Pagar" CssClass="form-check-input Letranegrita" GroupName="TipoCobro" />
        </div>
      <div class="form-row">
          <div class="form-group col-md-4">
             <asp:Label ID="lbTelefono1Mantenimiento" runat="server" Text="Telefono 1" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtTelefono1Mantenimiento" runat="server" CssClass="form-control"></asp:TextBox>
          </div>

           <div class="form-group col-md-4">
             <asp:Label ID="lbTelefono2Mantenimiento" runat="server" Text="Telefono 2" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtTelefono2Mantenimiento" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="form-group col-md-4">
             <asp:Label ID="lbTelefono3Mantenimiento" runat="server" Text="Telefono 3" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtTelefono3Mantenimiento" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
              <div class="form-group col-md-4">
             <asp:Label ID="lbCelularMantenimiento" runat="server" Text="Celular" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtCelularMantenimiento" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
              <div class="form-group col-md-4">
             <asp:Label ID="lbFaxMantenimiento" runat="server" Text="Fax" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtFaxMantenimiento" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
              <div class="form-group col-md-4">
             <asp:Label ID="lbEmailMantenimiento" runat="server" Text="Email" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtEnailMantenimiento" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
          </div>
      </div>


    </div>
    <asp:ScriptManager ID="ScripManagerIntermediario" runat="server"></asp:ScriptManager>


    <!--POPOP DE COMISIONES-->
     <div class="modal fade bd-example-modal-lg ComisionesIntermediario" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="Label1" runat="server" Text="Mantenimiento de Comisiones de Intermediarios"></asp:Label>
        </div>
        <!--CONTROLES-->
    <div class="container-fluid">
        <asp:UpdatePanel ID="UpdatePanelComisionesIntermediario" runat="server">
            <ContentTemplate>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </div>
  </div>
</div>
</asp:Content>

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

    <script type="text/javascript">

        function BloquearComision() {
            $("#btnComisiones").attr("disabled", "disabled");
        }
        function DesbloquearComision() {
            $("#btnComisiones").removeAttr("disabled", "true");
        }
        $(document).ready(function () {
            //Evento deo boton Guardar
            $("#<%=btnGuardar.ClientID%>").click(function () {
                //Validamos el campo de fecha de entrada
                var FechaEntrada = $("#<%=txtFechaEntradaMantenimiento.ClientID%>").val().length;
                if (FechaEntrada < 1) {
                    alert("El campo fecha de Entrada no pude estar vacio, favor de verificar.");
                    $("#<%=txtFechaEntradaMantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    //VALIDAMOS EL CAMPO FECHA DE NACIMIENTO
                    var FechaNacimiento = $("#<%=txtFechaMAcimientoMantenimiento.ClientID%>").val().length;
                    if (FechaNacimiento < 1) {
                        alert("El campo fecha de nacimiento no puede estar vacio, favor de verificar.");
                        $("#<%=txtFechaMAcimientoMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        //VALIDAMOS EL CAMPO NUMERO DE IDENTIFICACION
                        var NumeroIdentificacion = $("#<%=txtNumeroIdentificacionMantenimiento.ClientID%>").val().length;
                        if (NumeroIdentificacion < 1) {
                            alert("El numero de identificación no puede estar vacio, favor de verificar.");
                            $("#<%=txtNumeroIdentificacionMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            //VALIDAMOS EL NOMBRE DEL INTERMEDIARIO
                            var NombreIntermediario = $("#<%=txtNombreIntermediarioMantenimiento.ClientID%>").val().length;
                            if (NombreIntermediario < 1) {
                                alert("El campo nombre de intermediario no puede estar vacio, favor de verificar");
                                $("#<%=txtNombreIntermediarioMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var Ubicacion = $("#<%=ddlSeleccionarUbicacionMantenimiento.ClientID%>").val();
                                if (Ubicacion < 1) {
                                    alert("El campo ubicación no puede estar vacio, favor de verificar.");
                                    $("#<%=ddlSeleccionarUbicacionMantenimiento.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                                else {
                                    var CodigoSupervisor = $("#<%=txtCodigoSupervisor.ClientID%>").val().length;
                                    if (CodigoSupervisor < 1) {
                                        alert("El codigo de supervisor no puede estar vacio, favor de verificar.");
                                        $("#<%=txtCodigoSupervisor.ClientID%>").css("border-color", "red");
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            });
           

        })
       
    </script>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Mantenimiento Intermediario / Supervisor"></asp:Label>
        </div>
        <div align="center">
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros: ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbSeparadorConsulta" runat="server" Text=" | " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCodigoSeleccionadoTitulo" runat="server" Text="Codigo Seleccionado: ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCodigoSeleccionadoVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCodigoSeleccionadoCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
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
             <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Registros" OnClick="btnNuevo_Click" CssClass="btn btn-outline-primary btn-sm"/>
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" Enabled="false" ToolTip="Modificar Registros" OnClick="btnModificar_Click" CssClass="btn btn-outline-primary btn-sm"/>
            <button type="button" id="btnComisiones" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".ComisionesIntermediario">Comisiones</button>
             <asp:Button ID="btnRestabelcerPantalla" runat="server" Text="Restablecer" Enabled="false" ToolTip="Restablecer Pantalla" OnClick="btnRestabelcerPantalla_Click" CssClass="btn btn-outline-primary btn-sm"/>
        </div>
        <br />
      <div>
              <asp:GridView ID="gvIntermediarios" runat="server" AllowPaging="true" OnPageIndexChanging="gvIntermediarios_PageIndexChanging" OnSelectedIndexChanged="gvIntermediarios_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                    <asp:BoundField DataField="NombreVendedor" HeaderText="Intermediario" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="NombreOficina" HeaderText="Oficina" />
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
               <asp:RadioButton ID="rbRetensionSiMantenimiento" runat="server" Visible="false" GroupName="Retencion" Text="Retención Si" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbRetensionNOMantenimiento" runat="server" Visible="false" GroupName="Retencion" Text="Retención No" CssClass="form-check-input Letranegrita" />
                <asp:Label ID="LBsEPARADOR1" runat="server" Text=" | " Visible="false" CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbEstatusMantenimiento" runat="server" Visible="false" GroupName="Estatus" Text="Activo" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbEstatusInactivoMantenimiento" runat="server" Visible="false" GroupName="Estatus" Text="Inactivo" CssClass="form-check-input Letranegrita" />
                <asp:Label ID="LBsEPARADOR2" runat="server" Visible="false" Text=" | " CssClass="Letranegrita"></asp:Label>
                 <asp:RadioButton ID="rbIntermediarioDirecto" runat="server" Visible="false" GroupName="Directo" Text="Intermediario Directo" CssClass="form-check-input Letranegrita" />
               <asp:RadioButton ID="rbIntermediarioNoDirecto" runat="server" Visible="false" GroupName="Directo" Text="Intermediario No Directo" CssClass="form-check-input Letranegrita" />

            </div>
        </div>
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Label ID="lbFechaEntradaMantenimiento" runat="server" Visible="false" Text="Fecha de Entrada" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtFechaEntradaMantenimiento" runat="server" TextMode="Date" Visible="false"  CssClass="form-control"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-3">
                            <asp:Label ID="lbFechaNacimientoMantenimiento" runat="server" Visible="false" Text="Fecha de Nacimiento" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtFechaMAcimientoMantenimiento" runat="server" TextMode="Date" Visible="false"  CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-3">
                            <asp:Label ID="lbSeleccionarTipoIdentificacionMantenimiento" Visible="false" runat="server" Text="Seleccionr Tipo de Identificación" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarTipoIdentificacionMantenimiento" Visible="false" runat="server" ToolTip="Seleccionar Tipo de Identificacion" CssClass="form-control"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-3">
                            <asp:Label ID="lbNumeroIdentificacionMantenimiento" runat="server" Visible="false" Text="Numero de identificación" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNumeroIdentificacionMantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lbApellidoIntermediarioMantenimiento" runat="server" Visible="false" Text="Apellido" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtApellidoIntermediarioMantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" MaxLength="100" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lbNombreIntermediarioMantenimiento" runat="server" Visible="false" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNombreIntermediarioMantenimiento" runat="server"  AutoCompleteType="Disabled" Visible="false" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12">
                            <asp:Label ID="lbDireccionIntermediarioMantenimiento" runat="server" Visible="false" Text="Dirección" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtDireccionntermediarioMantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" CssClass="form-control" MaxLength="250"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12">
                            <asp:Label ID="lbContactoIntermediarioMantenimiento" runat="server" Visible="false" Text="Contacto Intermediario" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtContactoIntermediarioMantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" MaxLength="100" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!--UBICACION DE INTERMEDIARIOS-->
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarPaisMantenimiento" Visible="false" runat="server" Text="Seleccionar Pais" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarPaisMantenimiento" Visible="false" runat="server" ToolTip="Seleccionar Pais" CssClass="form-control"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarZonaMantenimiento" runat="server" Visible="false" Text="Seleccionar Zona" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarZonaMantenimiento" AutoPostBack="true" Visible="false" runat="server" ToolTip="Seleccionar Zona" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarZonaMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarProvinciaMantenimiento" runat="server" Visible="false" Text="Seleccionar Provincia" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarProvinciaMantenimiento" Visible="false" AutoPostBack="true" runat="server" ToolTip="Seleccionar Provincia" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarProvinciaMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbseleccionarMunicipioMantenimiento" runat="server" Visible="false" Text="Seleccionar Municipio" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarMunicipioMantenimiento" runat="server" Visible="false" AutoPostBack="true" ToolTip="Seleccionar Municipio" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarMunicipioMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarSectorMantenimiento" runat="server" Visible="false" Text="Seleccionar Sector" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarSectorMantenimiento" runat="server" Visible="false" AutoPostBack="true" ToolTip="Seleccionar Sector" CssClass="form-control" OnSelectedIndexChanged="ddlSeleccionarSectorMantenimiento_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                         <div class="form-group col-md-4">
                            <asp:Label ID="lbSeleccionarUbicacionMantenimiento"  Visible="false" runat="server" Text="Seleccionar Ubicación" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarUbicacionMantenimiento" Visible="false" runat="server" ToolTip="Seleccionar Ubicación" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-3">
                            <asp:Label ID="lbCodigoSupervisorMantenimiento" runat="server" Visible="false" Text="Codigo de Supervisor" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtCodigoSupervisor" runat="server" Visible="false" AutoCompleteType="Disabled" OnTextChanged="txtCodigoSupervisor_TextChanged" AutoPostBack="true" TextMode="Number" MaxLength="4" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-9">
                            <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre de Supervisor" Visible="false" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNombreSupervisor" runat="server" AutoCompleteType="Disabled" Enabled="false" Visible="false" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-6">
                            <asp:Label ID="ddlSeleccionarOficinaIntermediarioMantenimiento" runat="server" Visible="false" Text="Seleccionar Oficina" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarOficinaIntermeiarioMantenimiento" runat="server" Visible="false" ToolTip="Seleccionar la Oficina del Intermediario" CssClass="form-control"></asp:DropDownList>
                        </div>

                          <div class="form-group col-md-6">
                            <asp:Label ID="lbSeleccionarBancoIntermediarioMantenimiento" runat="server" Visible="false" Text="Seleccionar Banco" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarBancoIntermediarioMantenimeitto" runat="server" Visible="false" ToolTip="Seleccionar el Banco del Intermediario" CssClass="form-control"></asp:DropDownList>
                        </div>

                        <div class="form-group col-md-6">
                            <asp:Label ID="lbCuentaBancoMantenimiento" runat="server" Visible="false" Text="Numero de Cuenta" CssClass="Letranegrita"></asp:Label>
                            <asp:TextBox ID="txtNumeroCuentaBancoMantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false"  CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="lbSeleccionarCanalDistribucionMantenimiento" runat="server" Visible="false" Text="Seleccionar canal de distribución" CssClass="Letranegrita"></asp:Label>
                            <asp:DropDownList ID="ddlSeleccionarCanalDistribucionMantenimiento" runat="server" Visible="false" ToolTip="Seleccionar Canal de distribución" CssClass="form-control"></asp:DropDownList>
                        </div>
                      
                        
                    </div>
        <asp:Label ID="lbTipoCuentaBancoMantenimiento" runat="server" Visible="false" Text="Tipo de Cuenta" CssClass="Letranegrita"></asp:Label><br />
        <div class="form-check-inline">
            
            <asp:RadioButton ID="rbCuentaAhorroMantenimiento" runat="server" Visible="false" Text=" Cuenta de Ahorro" CssClass="form-check-input Letranegrita" GroupName="TipoCuentas" />
            <asp:RadioButton ID="rbCuentaCorrienteMantenimiento" runat="server" Visible="false" Text=" Cuenta Corriente" CssClass="form-check-input Letranegrita" GroupName="TipoCuentas" />
            <asp:RadioButton ID="rbTarjetaMantenimiento" runat="server" Visible="false" Text=" Tarjeta" CssClass="form-check-input Letranegrita" GroupName="TipoCuentas" />
            <asp:RadioButton ID="rbPrestamoMantenimiento" runat="server" Visible="false" Text=" Prestamo" CssClass="form-check-input Letranegrita" GroupName="TipoCuentas" />
        </div>
        <br />

        <asp:Label ID="lbTipoCobroTitulo" runat="server" Visible="false" Text="Tipo de Cobro" CssClass="Letranegrita"></asp:Label><br />
          <div class="form-check-inline">
            <asp:RadioButton ID="rbCobroChequesMantenimiento" runat="server" Visible="false" Text=" Cheque" CssClass="form-check-input Letranegrita" GroupName="TipoCobro" />
            <asp:RadioButton ID="rbCobroEfectivoMantenimiento" runat="server" Visible="false" Text= "Efectivo" CssClass="form-check-input Letranegrita" GroupName="TipoCobro" />
            <asp:RadioButton ID="rbCobroTransferenciaMantenimiento" runat="server" Visible="false" Text=" Transferencia" CssClass="form-check-input Letranegrita" GroupName="TipoCobro" />
            <asp:RadioButton ID="rbCobroCuentasPorPagarMantenimiento" runat="server" Visible="false" Text=" Cuentas Por Pagar" CssClass="form-check-input Letranegrita" GroupName="TipoCobro" />
        </div>
      <div class="form-row">
          <div class="form-group col-md-4">
             <asp:Label ID="lbTelefono1Mantenimiento" runat="server" Visible="false" Text="Telefono 1" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtTelefono1Mantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" CssClass="form-control"></asp:TextBox>
          </div>

           <div class="form-group col-md-4">
             <asp:Label ID="lbTelefono2Mantenimiento" runat="server" Visible="false" Text="Telefono 2" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtTelefono2Mantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="form-group col-md-4">
             <asp:Label ID="lbTelefono3Mantenimiento" runat="server" Visible="false" Text="Telefono 3" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtTelefono3Mantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" CssClass="form-control"></asp:TextBox>
          </div>
              <div class="form-group col-md-4">
             <asp:Label ID="lbCelularMantenimiento" runat="server" Visible="false" Text="Celular" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtCelularMantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" CssClass="form-control"></asp:TextBox>
          </div>
              <div class="form-group col-md-4">
             <asp:Label ID="lbFaxMantenimiento" runat="server" Visible="false" Text="Fax" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtFaxMantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" CssClass="form-control"></asp:TextBox>
          </div>
              <div class="form-group col-md-4">
             <asp:Label ID="lbEmailMantenimiento" runat="server" Visible="false" Text="Email" CssClass="Letranegrita"></asp:Label>
              <asp:TextBox ID="txtEnailMantenimiento" runat="server" AutoCompleteType="Disabled" Visible="false" TextMode="Email" CssClass="form-control"></asp:TextBox>
          </div>
      </div>
        <div align="center">
             <asp:Button ID="btnGuardar" runat="server" Visible="false" Text="Guardar" ToolTip="Guardar Registros" OnClick="btnGuardar_Click" CssClass="btn btn-outline-primary btn-sm"/>
             <asp:Button ID="btnVolver" runat="server" Visible="false" Text="Volver" ToolTip="Volver Atras" OnClick="btnVolver_Click" CssClass="btn btn-outline-primary btn-sm"/>
        </div>
        <br />

    </div>
    <asp:ScriptManager ID="ScripManagerIntermediario" runat="server"></asp:ScriptManager>


    <!--POPOP DE COMISIONES-->
     <div class="modal fade bd-example-modal-lg ComisionesIntermediario" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbNombreIntermediarioComisionesTitulo" runat="server" Text="Mantenimiento de Comisiones de Intermediarios"></asp:Label>
        </div>
        <!--CONTROLES-->
    <div class="container-fluid">
        <asp:UpdatePanel ID="UpdatePanelComisionesIntermediario" runat="server">
            <ContentTemplate>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <asp:Label ID="lbSeleccionarRamoComisionesConsulta" runat="server" Text="Seleccionar Ramo" CssClass="Letranegrita"></asp:Label>
                        <asp:DropDownList ID="ddlSeleccionarRamoComisionesConsulta" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarRamoComisionesConsulta_SelectedIndexChanged" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <asp:Label ID="lbSeleccionarSubRamoComisionesConsulta" runat="server" Text="Seleccionar Sub Ramo" CssClass="Letranegrita"></asp:Label>
                        <asp:DropDownList ID="ddlSeleccionarSubRamoComisionesConsulta" runat="server" ToolTip="Seleccionar Sub Ramo" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div align="center">
                    <asp:Button ID="btnConsultarComisiobesIntermediario" runat="server" Text="Consultar" ToolTip="Consultar Comisiones" OnClick="btnConsultarComisiobesIntermediario_Click" CssClass="btn btn-outline-primary btn-sm"/>
                </div>
                <br />
                     <div>
              <asp:GridView ID="gvListadoComisionesIntermediario" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoComisionesIntermediario_PageIndexChanging" OnSelectedIndexChanged="gvListadoComisionesIntermediario_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="#" HeaderText="Ramo" />
                    <asp:BoundField DataField="#" HeaderText="Sub Ramo" />
                    <asp:BoundField DataField="#" HeaderText="% de Comisión" />
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
                <!--CONTROLES PARA REALIZAR EL MANTENIMIENTO-->
               <div class="form-row">
                   <div class="form-group col-md-6">
                       <asp:Label ID="lbRamoComsionesMantenimiento" Visible="false" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtRamoComisionesMantenimiento" Visible="false" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-6">
                       <asp:Label ID="lbSubRamoComisionesMantenimiento" Visible="false" runat="server" Text="Sub Ramo" CssClass="Letranegrita"></asp:Label>
                           
                       <asp:TextBox ID="txtSubRamoComisionesMAntenimiento" Visible="false" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-6">
                       <asp:Label ID="lbPorcientoComisionesComisionesMantenimiento" Visible="false" runat="server" Text="% de Comisión" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtPorcientoCOmisionesComisionesMantenimiento" Visible="false" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
                   </div>
                   <div class="form-group col-md-6">
                       <asp:Label ID="lbClaveSeguridadComisionesMAntenimiento"  Visible="false" runat="server" Text="Clave de Seguridad" CssClass="Letranegrita"></asp:Label>
                       <asp:TextBox ID="txtClaveSeguridadComisionesMAntenimiento" Visible="false" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Password"></asp:TextBox>
                   </div>
               </div>
                  <div align="center">
                    <asp:Button ID="btnGuardarComisionesIntermediarios" Visible="false" runat="server" Text="Guardar" ToolTip="Guardar" OnClick="btnGuardarComisionesIntermediarios_Click" CssClass="btn btn-outline-primary btn-sm"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </div>
  </div>
</div>
</asp:Content>

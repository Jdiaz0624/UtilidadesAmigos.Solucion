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
    </div>
    <asp:ScriptManager ID="ScripManagerIntermediario" runat="server"></asp:ScriptManager>
    <!--POPOP DE INTERMEDIARIOS-->
     <div class="modal fade bd-example-modal-lg MantenimientoIntermediario" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezadoMantenimiento" runat="server" Text="Mantenimiento de Intermediario"></asp:Label>
        </div>
        <!--CONTROLES-->
        <div class="container-fluid">
            <asp:UpdatePanel ID="UpdatePanelMantenimiento" runat="server">
                <ContentTemplate>
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

                        
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
  </div>
</div>

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

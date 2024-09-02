<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ValidarCoberturas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ValidarCoberturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        function OpcionNoDisponible() {
            alert("Esta cobertura no requiere archivo TXT para su envio, solo esta habilitada para el Centro del Automovilista.");
        }
        function Archivogenerado() {
            alert("Archivo Generado con Exito, favor consultar la carpeta asignada para y validar este archivo");
        }
        function FuncionNodisponible() {
            alert("Esta Función no esta disponible por el momento");
        }
    </script>

    <div class="container-fluid">
        <div id="DIVBloqueConsulta" runat="server">
            <br />
            <div class="form-check-inline">
                <asp:CheckBox ID="cbValidarData" runat="server" Text="Validar Data" AutoPostBack="true" CssClass="Letranegrita" OnCheckedChanged="cbValidarData_CheckedChanged" ToolTip="Validar Data de Cobertura" />
            </div>
            <br />
            <div class="row">
                <div class="col-md-3">
                    <label class="Letranegrita">Fecha Desde</label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-3">
                     <label class="Letranegrita">Fecha Hasta</label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-3">
                     <label class="Letranegrita">Servicio</label>
                    <asp:DropDownList ID="ddlServicio" runat="server" ToolTip="Seleccionar Servicio" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlServicio_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                     <label class="Letranegrita">Plan</label>
                    <asp:DropDownList ID="ddlPlan" runat="server" ToolTip="Seleccionar Plan" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                     <label class="Letranegrita">Poliza</label>
                    <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="BuscarInformacion"  AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-3">
                     <label class="Letranegrita">Sucursal</label>
                    <asp:DropDownList ID="ddlSucursal" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSucursal_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                     <label class="Letranegrita">Oficina</label>
                     <asp:DropDownList ID="ddlOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div id="SubBloqueConsulta" runat="server">
                <br />
                <div class="form-check-inline">
                    <label class="Letranegrita">Formato de Archivo: </label>
                    <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="Formato" />
                    <asp:RadioButton ID="rbTXT" runat="server" Text="TXT" GroupName="Formato" />
                </div>
                <br />
                <div class="form-check form-switch">
                    <input type="checkbox" runat="server" id="cbValidacionAuditoria" class="form-check-input" />
                    <label class="Letranegrita form-check-label">Validación de Auditoria</label>
                </div>
                <br />
                <div class="ContenidoCentro">
                      <asp:ImageButton ID="btnConsultar" runat="server" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultar_Click" CssClass="BotonImagen" />
                      <asp:ImageButton ID="btnReporte" runat="server" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporte_Click" CssClass="BotonImagen" />
                    <br />
                     <button type="button" id="btnCobertura" class="btn btn-outline-secondary btn-sm Letranegrita" data-toggle="modal" data-target=".bd-example-modal-lg">Servicios</button>
                     <button type="button" id="btnPlan" class="btn btn-outline-secondary btn-sm Letranegrita" data-toggle="modal" data-target=".PlanCobertura">Planes</button>
                </div>
                <br />
                <div class="table-responsive">
                    <table class="table table-striped">
                        <thead class="table-dark">
                            <tr>
                                <th scope="col"> Poliza </th>
                                <th scope="col"> Asegurado </th>
                                <th scope="col"> Concepto </th>
                                <th scope="col"> Fecha </th>
                                <th scope="col"> Cobertura </th>
                                <th scope="col"> Movimiento </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpListadoGeneral" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td> <%# Eval("Poliza") %> </td>
                                        <td> <%# Eval("Asegurado") %> </td>
                                        <td> <%# Eval("Concepto") %> </td>
                                        <td> <%# Eval("Fecha") %> </td>
                                        <td> <%# Eval("Cobertura") %> </td>
                                        <td> <%# Eval("TipoMovimiento") %> </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <table class="table">
                        <tfoot class="table-light">
                            <tr>
                                <td class="ContenidoDerecha">
                                    <label class="Letranegrita">Pagina</label> <asp:Label ID="lbPaginaActual" runat="server" Text="0"></asp:Label>
                                    <label class="Letranegrita">De</label> <asp:Label ID="lbCantidadPAgina" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                 <div id="DivPaginacionListadoPrincipal" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" OnClick="btnPrimeraPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" OnClick="btnPaginaAnterior_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacion" runat="server" OnCancelCommand="dtPaginacion_CancelCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' class="btn btn-outline-dark" />
                                   
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguiente" runat="server" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" OnClick="btnSiguiente_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" OnClick="btnUltimaPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
            <br />
            </div>

            <div id="SubBloqueValidacion" runat="server">
                <br />
           <div id="DivBuscarArchivoExcel" runat="server" class="form-group col-sm-6">
                     <label class="Letranegrita" for="FileUpload1">Buscar Archivo en el equipo</label>
                       <asp:FileUpload ID="FileExcel" CssClass="form-control-file" runat="server" />
                   </div>
            <div class="ContenidoCentro">
                <asp:Label ID="lbEjemeploFormatoExel" runat="server" Text="Formato de Archivo (Columnas)--> Poliza|Chasis|Placa|Cobertura" CssClass="Letranegrita"></asp:Label><br />
                <asp:ImageButton ID="Plantilla" runat="server" ToolTip="Descargar Plantilla" CssClass="BotonImagen" OnClick="Plantilla_Click" ImageUrl="~/ImagenesBotones/Excel.png" />
                <asp:ImageButton ID="btnValidar" runat="server" ToolTip="Validar la información de cobertura" CssClass="BotonImagen" OnClick="btnValidar_Click" ImageUrl="~/ImagenesBotones/proceso.png" />
                
            </div>
            <br />
            </div>
        </div>
    </div>

    
     <!-- POPOP DE LOS SERVICIIOS-->
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <br />
<div class="table-responsive">
    <table class="table table-bordered">
        <thead class="table-light">
            <tr>
                <th>
                    <h3 class="ContenidoCentro"> <label class="Letranegrita">Listado de Servicios</label></h3>
                </th>
            </tr>
        </thead>
    </table>
</div>
         <asp:ScriptManager ID="CoberturasScript" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanelCoberturas" runat="server" Visible="true">
              <ContentTemplate>
                   <br />
                  <div class="table-responsive">
                      <table class="table table-striped">
                          <thead class="table-dark">
                              <tr>
                                  <th scope="col"> Servicio </th>
                                  <th scope="col"> Estatus </th>
                                  <th class="ContenidoDerecha" scope="col"> Modificar </th>
                              </tr>
                          </thead>
                          <tbody>
                              <asp:Repeater ID="rpListadoServicios" runat="server">
                                  <ItemTemplate>
                                      <tr>
                                          <asp:HiddenField ID="hfIdServicios_servicio" runat="server" Value='<%# Eval("IdCobertura") %>' />
                                          <asp:HiddenField ID="hfEstatusServicio" runat="server" Value='<%# Eval("Estatus0") %>' />

                                          <td> <%# Eval("Descripcion") %> </td>
                                          <td> <%# Eval("Estatus") %> </td>
                                          <td class="ContenidoDerecha"> <asp:ImageButton ID="btnModificarCobertura" runat="server" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" OnClick="btnModificarCobertura_Click" CssClass="BotonImagen" /> </td>
                                      </tr>
                                  </ItemTemplate>
                              </asp:Repeater>
                          </tbody>
                      </table>
                  </div>
              </ContentTemplate>
          </asp:UpdatePanel>
        
      </div>
    </div>
  </div>
</div>

    <!-- POPOP DE LOS PLANES-->
   <div class="modal fade bd-example-modal-xl PlanCobertura" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <br />
         <div class="table-responsive">
             <table class="table table-bordered">
                 <thead class="table-light">
                     <tr>
                         <th>
                             <h3 class="ContenidoCentro"> <label class="Letranegrita">Listado de Planes</label></h3>
                         </th>
                     </tr>
                 </thead>
             </table>
         </div>
          <asp:UpdatePanel ID="PlanCoberturaUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                <div class="row">
                    <div class="col-md-6">
                        <label class="Letranegrita">Servicio</label>
                        <asp:DropDownList ID="ddlServicio_POPOP" runat="server" CssClass="form-control" ToolTip="Seleccionar Servicio para consultar" AutoPostBack="true" OnSelectedIndexChanged="ddlServicio_POPOP_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                  <br />
                   <div class="table-responsive">
     <table class="table table-striped">
         <thead class="table-dark">
             <tr>
                 <th scope="col"> Servicio </th>
                 <th scope="col"> Plan </th>
                 <th scope="col"> Estatus </th>
                 <th class="ContenidoDerecha" scope="col"> Modificar </th>
             </tr>
         </thead>
         <tbody>
             <asp:Repeater ID="rpListadoPlan" runat="server">
                 <ItemTemplate>
                     <tr>
                         <asp:HiddenField ID="hfIdServicios_servicio" runat="server" Value='<%# Eval("IdCobertura") %>' />
                         <asp:HiddenField ID="hfIdPlanCobertura" runat="server" Value='<%# Eval("IdPlanCobertura") %>' />
                         <asp:HiddenField ID="hfEstatusServicio" runat="server" Value='<%# Eval("Estatus0") %>' />
                         <asp:HiddenField ID="hfCodigoCobertura" runat="server" Value='<%# Eval("CodigoCobertura") %>' />

                         <td> <%# Eval("Cobertura") %> </td>
                         <td> <%# Eval("PlanCobertura") %> </td>
                         <td> <%# Eval("Estatus") %> </td>
                         <td class="ContenidoDerecha"> <asp:ImageButton ID="btnModificarCoberturaPlan" runat="server" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" OnClick="btnModificarCoberturaPlan_Click" CssClass="BotonImagen" /> </td>
                     </tr>
                 </ItemTemplate>
             </asp:Repeater>
         </tbody>
     </table>
 </div>
              </ContentTemplate>
          </asp:UpdatePanel>
          
          <br />
      </div>
    </div>
  </div>
</div>
</asp:Content>

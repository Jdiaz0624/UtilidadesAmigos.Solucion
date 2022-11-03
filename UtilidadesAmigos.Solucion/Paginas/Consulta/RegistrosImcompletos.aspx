<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="RegistrosImcompletos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Consulta.RegistrosImcompletos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style type="text/css">

        .btn-sm{
            width:90px;
        }

        .LetrasNegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        
       .BotonImagen {
         width:40px;
         height:40px;
       
       }
    </style>

    <script type="text/javascript">
        function PerfilSinPermisoNegocios() {

            alert("No tienes permiso para realizar este proceso, favor de contactar a una persona del departamento de Negocios.");
        }
        function PerfilSinPermisoSuscripcion() {

            alert("No tienes permiso para realizar este proceso, favor de contactar a una persona del departamento de Suscripción.");
        }
    </script>

    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbCantidadClientesSinPoliza" runat="server" Text="Clientes Sin Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtClientesSinPolizaRecuento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbPolizasSinmarbetesRecuento" runat="server" Text="Poliza Sin Marbetes" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPolizasSInMarbeteRecuento" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div class="form-check-inline">
            <asp:Label ID="lbTipoDeDataGenerar" runat="server" CssClass="LetrasNegrita" Text="Tipo Data a Mosrar: "></asp:Label>
            <asp:RadioButton ID="rbCLientesSinPolizas" runat="server" Text="Clientes Sin Polizas" GroupName="TipoInformacion" AutoPostBack="true" OnCheckedChanged="rbCLientesSinPolizas_CheckedChanged" ToolTip="Mostrar el lsitado de los clientes que no tienen poliza asignada" />
            <asp:RadioButton ID="rbPolizasSInImpresionMarbete" runat="server" Text="Polizas Sin Impresion de Marbetes" GroupName="TipoInformacion" AutoPostBack="true" OnCheckedChanged="rbPolizasSInImpresionMarbete_CheckedChanged" ToolTip="Mostrar el listado de las polizas que no tiene marbete impreso" />
            <br />
            <asp:Label ID="lbFormaReporte" runat="server" CssClass="LetrasNegrita" Text="Forma de Reporte: "></asp:Label>
            <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Reporte Resumido" GroupName="FormaReporte"  ToolTip="Genera el Reporte de Manera Resumida" />
            <asp:RadioButton ID="rbReporteDetallado" runat="server" Text="Reporte Detallado" GroupName="FormaReporte"  ToolTip="Genera el Reporte de Manera Detallada" />
            <br />
            <asp:Label ID="lbFormatoReporte" runat="server" CssClass="LetrasNegrita" Text="Formato de Reporte: "></asp:Label>
            <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="FormatoReporte"  ToolTip="Generar Reporte en PDF" />
            <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="FormatoReporte"  ToolTip="Generar Reporte en Excel" />
            <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano" GroupName="FormatoReporte"  ToolTip="Generar el Reporte en Excel Sin Formato" />
        </div>
        <br />
         <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server" CssClass="BotonImagen" ToolTip="Consultar información" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
                <asp:ImageButton ID="btnReporte" runat="server" CssClass="BotonImagen" ToolTip="Generar Reporte" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
            </div>
            <br />
        <div id="DIVBloqueClientesSinPoliza" visible="true" runat="server">
            <br />
            <div align="center">
                <asp:Label ID="lbCientesSinPolizaTitulo" runat="server" Text="Clientes Sin Polizas Asignada" CssClass="LetrasNegrita"></asp:Label>
            </div>
            <br />
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lbCodigoClienteClienteSinPoliza" runat="server" Text="Cod Ciente" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoClienteSinPoliza" runat="server" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-3">
                      <asp:Label ID="lbNumeroidentidicacionClienteSinpoliza" runat="server" Text="No. identificación" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroIdentificacionClienteSinPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-3">
                      <asp:Label ID="lbFechaDesdeClienteSinPoliza" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesdeClienteSinPoliza" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-3">
                      <asp:Label ID="lbFechaHastaClienteSinPoloiza" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHastaClienteSinPoliza" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="col-md-1">
                      <asp:Label ID="lbCodigoSupervisorClienteSinPoliza" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisorClienteSinPoliza" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisorClienteSinPoliza_TextChanged" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-5">
                      <asp:Label ID="lbNombreSupervisorClienteSinPoliza" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisorClienteSinPoliza" runat="server" CssClass="form-control" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-1">
                      <asp:Label ID="lbCodigoIntermediarioClienteSinPoliza" runat="server" Text="Vendedor" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediarioClienteSinPoliza" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioClienteSinPoliza_TextChanged" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-5">
                      <asp:Label ID="lbNombreIntermediarioClienteSinpOliza" runat="server" Text="Cod Ciente" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediarioClienteSinPoliza" runat="server" CssClass="form-control" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="col-md-6">
                      <asp:Label ID="lbNombreClienteClienteSinPoliza" runat="server" Text="Nombre Cliente" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreClienteClienteSinPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                 <div class="col-md-6">
                     <asp:Label ID="lbSeleccionaroficinaClienteSinPoliza" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                     <asp:DropDownList ID="ddlSeleccionaroficinaClienteSinPoliza" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
           <table class="table table-striped">
               <thead class="table-dark">
                   <tr>
                        <th scope="col">Cliente</th>
                        <th scope="col">Supervisor</th>
                        <th scope="col">Intermediario</th>
                        <th scope="col">Fecha</th>
                        <th scope="col">Sigla</th>
                        <th scope="col">Estatus</th>
                        <th scope="col">  </th>
                   </tr>
               </thead>
               <tbody>
                   <asp:Repeater ID="rpListadoClienteSinPolizas" runat="server">
                       <ItemTemplate>
                           <tr>
                               <asp:HiddenField ID="hfCodigoClienteProceso" runat="server" Value='<%# Eval("Codigo") %>' />
                               <asp:HiddenField ID="hfCodigoEstatus" runat="server" Value='<%# Eval("CodigoEstatus") %>' />

                               <td> <%# Eval("Cliente") %> </td>
                               <td> <%# Eval("Supervisor") %> </td>
                               <td> <%# Eval("Intermediario") %> </td>
                               <td> <%# Eval("Fecha") %> </td>
                               <td> <%# Eval("SiglaEstatus") %> </td>
                               <td> <%# Eval("Estatus") %> </td>
                               <td> <asp:ImageButton ID="btnProcesar" runat="server" ToolTip="Procesar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Procesar.png" OnClick="btnProcesar_Click" /> </td>
                           </tr>
                       </ItemTemplate>
                   </asp:Repeater>
               </tbody>
           </table>
             <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina </b> <asp:Label ID="lbPaginaActualClientesSinPoliza" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> <b>De </b>   <asp:Label ID="lbCantidadPaginaClientesSinPoliza" runat="server" Text="0" CssClass="Letranegrita"></asp:Label> </td>
                    </tr>
                </tfoot>
            </table>
             <div id="DivPaginacionListadoPrincipal" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPaginaClientesSinPoliza" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaClientesSinPoliza_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnteriorClientesSinPoliza" runat="server" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnteriorClientesSinPoliza_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipalClientesSinPoliza" runat="server" OnCancelCommand="dtPaginacionListadoPrincipalClientesSinPoliza_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipalClientesSinPoliza_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentralClientesSinPoliza" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePaginaClientesSinPoliza" runat="server" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePaginaClientesSinPoliza_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPaginaClientesSinPoliza" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPaginaClientesSinPoliza_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
            <br />

            <div id="DIVBloqueProcesoClienteSinPoliza" runat="server">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="lbCodigoClienteProcesoClienteSinPoliza" runat="server" Text="Codigo de Cliente" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtCodigoClienteProcesoClienteSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lbNombreClienteProcesoClienteSinPoliza" runat="server" Text="Nombre de Cliente" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtNombreClienteProcesoClienteSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lbTipoIdentificacionProcesoCLienteSinPoliza" runat="server" Text="Tipo Identificación" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtTipoIdentificacionProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lbNumeroIdentificacionProcesoClientesSinPoliza" runat="server" Text="Identificación" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtNumeroIdentificacionProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lbFechaProcesoClienteSinPoliza" runat="server" Text="Fecha" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtFechaProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lbHoraProcesoClientesSinPoliza" runat="server" Text="Hora" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtHoraProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-12">
                        <asp:Label ID="lbDireccionProcesoClientesSinPoliza" runat="server" Text="Dirección" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtDireccionProcesoClientesSInPolizs" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lbTelefonoProcesoClienteSinPoliza" runat="server" Text="Telefono" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtTelefonoProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lbTelefonosOficinaProcesoClientesSInPoliza" runat="server" Text="Telefono Oficina" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtTelefonoOficinaProcesoCLienteSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lbCelularProcesoClienteSinPoliza" runat="server" Text="Celular" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtCelularProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lbSupervisorProcesoClientesSinpOliza" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtSupervisorProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lbIntermediarioProcesoClientesSinPoliza" runat="server" Text="Intermediario" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtIntermediarioProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lbUsuarioProcesoClientesSinPoliza" runat="server" Text="Creado Por" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtUsuarioProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lbEstatusProcesoClientesSinPoliza" runat="server" Text="Estatus" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtEstatusProcesoClientesSinPoliza" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>


        <div id="DIVBloquePolziaSinMarbete" visible="false" runat="server">
            <br />
            <div class="row">
                <div class="col-md-3">
                     <asp:Label ID="lbPolizaPolizaSinImpresion" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtPolizaPolziaSinImpresion" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
          
                <div class="col-md-3">
                        <asp:Label ID="lbfechaDesdePolizasSinImpresion" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtfechaDesdePolizaSinImpresion" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="col-md-3">
                        <asp:Label ID="lbFechaHastaPolziasSinMarbete" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHAstaPolizaSinMarbete" runat="server" CssClass="form-control" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
                </div>


                <div class="col-md-3">
                    <asp:Label ID="lbFechaHastaPolizasSinImpresion" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddloficinaPolziaSinImpresion" runat="server" ToolTip="Seleccionar oficina" CssClass="form-control"></asp:DropDownList>
                </div>


                <div class="col-md-1">
                     <asp:Label ID="lbCodigoSupervisorPolizaSinMarbete" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisorPolizaSinMarbete" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisorPolizaSinMarbete_TextChanged" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-5">
                    <asp:Label ID="lbNombreSupervisorPolizaSinMarbete" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisorPolizaSinMarbete" runat="server" CssClass="form-control" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-1">
                      <asp:Label ID="lbCodigoIntermediarioPolizaSinMarbete" runat="server" Text="Intermediario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediarioPolizaSinMarbete" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioPolizaSinMarbete_TextChanged" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-5">
                     <asp:Label ID="lbNombreIntermediarioPolizaSinMarbete" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediarioPolizaSinMarbete" runat="server" CssClass="form-control" Enabled="false" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                 <div class="col-md-6">
                     <asp:Label ID="lbProductiPolizaSinMarbete" runat="server" Text="Sub Ramo" CssClass="LetrasNegrita"></asp:Label>
                     <asp:DropDownList ID="ddlSubRamoPolizasSinMarbete" runat="server" ToolTip="Seleccionar Producto" CssClass="form-control"></asp:DropDownList>
                </div>


            </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                         <th scope="col"> Poliza </th>
                         <th scope="col"> Prima </th>
                         <th scope="col"> Supervisor </th>
                         <th scope="col"> Intermediario </th>
                         <th scope="col"> Producto </th>
                         <th scope="col"> Fecha </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoPolizaSinMarbete" runat="server">
                        <ItemTemplate>
                            <tr>
                                  <td> <%# Eval("Poliza") %> </td>
                                  <td> <%# Eval("Prima") %> </td>
                                  <td> <%# Eval("Supervisor") %> </td>
                                  <td> <%# Eval("Intermediario") %> </td>
                                  <td> <%# Eval("SubRamo") %> </td>
                                  <td> <%# Eval("FechaCreadoFormateada") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
             <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina </b> <asp:Label ID="lbPaginaActualPolizaSinMarbete" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> <b>De </b>   <asp:Label ID="lbCantidadPaginaPolizaSinMarbete" runat="server" Text="0" CssClass="Letranegrita"></asp:Label> </td>
                    </tr>
                </tfoot>
            </table>
              <div id="DivBloquePaginacionPolizasSinMarbete" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPaginaPolizaSinMarbete" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaPolizaSinMarbete_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnteriorPolizaSinMarbete" runat="server" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnteriorPolizaSinMarbete_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipalPolizaSinMarbete" runat="server" OnCancelCommand="dtPaginacionListadoPrincipalPolizaSinMarbete_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipalPolizaSinMarbete_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentralPolizaSinMarbete" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePaginaPolizaSinMarbete" runat="server" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePaginaPolizaSinMarbete_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPaginaPolizaSinMarbete" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPaginaPolizaSinMarbete_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
        <br />
        </div>
        <br />
        
    </div>
</asp:Content>

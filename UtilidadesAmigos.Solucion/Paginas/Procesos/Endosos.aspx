<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Endosos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.Endosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <style>
/* ══════════════════════════════════════════════════
   ENDOSOS — mismo lenguaje visual del master (tarjetas,
   paleta "Futuro"). Usa las variables CSS ya definidas
   en el master (--accent, --content-bg, --sidebar-bg, etc.)
   para heredar automáticamente el modo oscuro.
══════════════════════════════════════════════════ */
.endosos-page {
    font-family: 'Inter', 'Roboto', sans-serif;
}

/* ── Encabezado de página ── */
.up-page-header {
    display: flex;
    align-items: center;
    gap: 14px;
    margin-bottom: 22px;
}

.up-page-header-icon {
    width: 46px; height: 46px;
    border-radius: 12px;
    display: flex; align-items: center; justify-content: center;
    background: var(--accent-dim, rgba(46,156,202,0.12));
    color: var(--accent, #2E9CCA);
    font-size: 19px;
    flex-shrink: 0;
}

.up-page-title {
    font-size: 20px;
    font-weight: 700;
    color: #1f2937;
    margin: 0;
    line-height: 1.2;
}

.up-page-sub {
    font-size: 12.5px;
    color: #6b7280;
    margin: 2px 0 0;
}

body.dark-mode .up-page-title { color: #ffffff; }
body.dark-mode .up-page-sub   { color: rgba(255,255,255,0.55); }

/* ── Tarjetas ── */
.up-card {
    background: #ffffff;
    border: 1px solid rgba(0,0,0,0.06);
    border-radius: 14px;
    box-shadow: 0 2px 14px rgba(15,23,42,0.05);
    padding: 22px 24px;
    margin-bottom: 22px;
    transition: background .3s, border-color .3s;
}

body.dark-mode .up-card {
    background: var(--navbar-bg, #0b1c30);
    border-color: rgba(255,255,255,0.07);
    box-shadow: 0 4px 20px rgba(0,0,0,0.35);
}

.up-section-title {
    font-size: 12.5px;
    font-weight: 700;
    text-transform: uppercase;
    letter-spacing: 0.06em;
    color: var(--accent, #2E9CCA);
    margin-bottom: 16px;
    display: flex;
    align-items: center;
    gap: 8px;
}

.up-section-title-row {
    display: flex;
    align-items: center;
    justify-content: space-between;
    flex-wrap: wrap;
    gap: 10px;
    margin-bottom: 6px;
}

.up-section-title-row .up-section-title { margin-bottom: 0; }

/* ── Etiquetas ── */
.Letranegrita,
.LetrasNegrita {
    display: block;
    font-size: 11.5px;
    font-weight: 700;
    text-transform: uppercase;
    letter-spacing: 0.04em;
    color: #4b5563;
    margin-bottom: 5px;
}

body.dark-mode .Letranegrita,
body.dark-mode .LetrasNegrita,
body.dark-mode .endosos-page label {
    color: #ffffff !important;
}

/* Valores de detalle (labels con datos) */
.up-value {
    display: block;
    font-size: 13.5px;
    font-weight: 500;
    color: #111827;
    margin-top: 1px;
}

body.dark-mode .up-value { color: #ffffff !important; }

/* ── Grid de detalle de póliza ── */
.up-detail-grid { row-gap: 16px; }

.up-detail-item {
    padding: 4px 6px;
}

/* ── Inputs ── */
.endosos-page .form-control {
    border-radius: 10px;
    border: 1.5px solid #dde3ea;
    padding: 9px 14px;
    font-size: 13.5px;
    transition: border-color .18s ease, box-shadow .18s ease, background .3s, color .3s;
}

.endosos-page .form-control:focus {
    border-color: var(--accent, #2E9CCA);
    box-shadow: 0 0 0 3px var(--accent-dim, rgba(46,156,202,0.15));
}

body.dark-mode .endosos-page .form-control {
    background: rgba(255,255,255,0.06);
    border-color: rgba(255,255,255,0.14);
    color: #ffffff !important;
}

body.dark-mode .endosos-page .form-control::placeholder {
    color: rgba(255,255,255,0.4) !important;
}

body.dark-mode .endosos-page .form-control:focus {
    background: rgba(255,255,255,0.10);
    border-color: var(--accent, #2E9CCA);
    box-shadow: 0 0 0 3px var(--accent-dim, rgba(46,156,202,0.25));
}

/* Autofill oscuro (Chrome) */
body.dark-mode .endosos-page .form-control:-webkit-autofill {
    -webkit-box-shadow: 0 0 0 1000px rgba(255,255,255,0.06) inset !important;
    -webkit-text-fill-color: #ffffff !important;
}

/* ── Botones con imagen ── */
.endosos-page .BotonImagen {
    max-height: 30px;
    padding: 8px;
    border-radius: 10px;
    background: var(--accent-dim, rgba(46,156,202,0.12));
    cursor: pointer;
    transition: background .18s ease, transform .18s ease, box-shadow .18s ease;
}

.endosos-page .BotonImagen:hover {
    background: var(--accent-dim2, rgba(46,156,202,0.22));
    transform: translateY(-2px);
    box-shadow: 0 6px 16px rgba(46,156,202,0.20);
}

body.dark-mode .endosos-page .BotonImagen {
    background: rgba(255,255,255,0.06);
}

body.dark-mode .endosos-page .BotonImagen:hover {
    background: rgba(255,255,255,0.13);
}

.up-actions-center {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 14px;
    flex-wrap: wrap;
}

/* ── Radios ── */
.up-radio-group,
.up-radio-list {
    display: flex;
    gap: 22px;
    flex-wrap: wrap;
    align-items: center;
}

.up-radio-list { flex-direction: column; align-items: flex-start; gap: 12px; }

.endosos-page input[type="radio"] {
    accent-color: var(--accent, #2E9CCA);
    width: 16px; height: 16px;
    margin-right: 7px;
    cursor: pointer;
    vertical-align: middle;
}

.endosos-page .form-check-inline label,
.up-radio-list label {
    font-size: 13.5px;
    font-weight: 500;
    color: #374151;
    cursor: pointer;
    vertical-align: middle;
}

body.dark-mode .endosos-page .form-check-inline label,
body.dark-mode .up-radio-list label {
    color: #ffffff !important;
}

/* ── Tabla ── */
.up-table-wrap { margin-top: 4px; }

.endosos-page .table {
    border-radius: 10px;
    overflow: hidden;
    font-size: 13px;
}

.endosos-page .table thead.table-dark th {
    background: var(--sidebar-bg, #0c2340);
    color: #ffffff;
    border: none;
    font-size: 11.5px;
    text-transform: uppercase;
    letter-spacing: 0.04em;
    font-weight: 600;
}

body.dark-mode .endosos-page .table {
    color: #ffffff;
}

body.dark-mode .endosos-page .table td,
body.dark-mode .endosos-page .table th {
    color: #ffffff !important;
    border-color: rgba(255,255,255,0.08);
}

body.dark-mode .endosos-page .table-striped > tbody > tr:nth-of-type(odd) > * {
    background-color: rgba(255,255,255,0.035);
}

body.dark-mode .endosos-page .table-light,
body.dark-mode .endosos-page .table-light td,
body.dark-mode .endosos-page .table-light th {
    background: rgba(255,255,255,0.04) !important;
    color: #ffffff !important;
}

.ContenidoDerecha { text-align: right; }

/* ── Paginación ── */
.endosos-page .btn-outline-dark {
    border-color: var(--accent, #2E9CCA);
    color: var(--accent, #2E9CCA);
    border-radius: 8px;
    font-size: 12.5px;
    font-weight: 600;
    padding: 5px 12px;
    transition: all .18s ease;
}

.endosos-page .btn-outline-dark:hover {
    background: var(--accent, #2E9CCA);
    color: #ffffff;
    border-color: var(--accent, #2E9CCA);
}

body.dark-mode .endosos-page .btn-outline-dark {
    color: var(--accent-light, #6cc5e8);
    border-color: var(--accent-light, #6cc5e8);
}

body.dark-mode .endosos-page .btn-outline-dark:hover {
    background: var(--accent-light, #6cc5e8);
    color: #0c2340;
}

/* ── Campos condicionales (endoso nuevo) ── */
.up-conditional-fields { row-gap: 16px; }

/* ── Modal de reporte ── */
.up-modal {
    border-radius: 16px !important;
    border: none !important;
    background: #ffffff !important;
    box-shadow: 0 24px 60px rgba(0,0,0,0.35) !important;
    overflow: hidden;
    display: flex;
    flex-direction: column;
}

.up-modal-header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 14px 20px;
    background: var(--sidebar-bg, #0c2340);
    color: #ffffff;
    flex-shrink: 0;
}

.up-modal-header span {
    font-size: 13.5px;
    font-weight: 700;
    display: flex;
    align-items: center;
    gap: 8px;
}

.up-modal-close {
    background: rgba(255,255,255,0.12) !important;
    border-radius: 8px;
    width: 30px; height: 30px;
    display: flex; align-items: center; justify-content: center;
    transition: background .18s ease;
}

.up-modal-close:hover { background: rgba(255,255,255,0.25) !important; }

.up-modal-close img { width: 16px !important; height: 16px !important; filter: brightness(0) invert(1); }

body.dark-mode .up-modal {
    background: var(--navbar-bg, #0b1c30) !important;
}

@media (max-width: 768px) {
    .up-page-header-icon { width: 40px; height: 40px; font-size: 16px; }
    .up-card { padding: 18px; }
}
    </style>

    <script type="text/javascript">
        function RegistroNoEncontrado() {
            alert("Los datos ingresados no concuerdan con algun registro en el sistema, favor de verificar los datos de entrada.");
        }
        function PolizaCancelada() {
            alert("No es posible sacar esta información por que esta poliza esta cancelada.");
        }
        function PolizaNoAplica() {
            alert("Esta poliza no aplica para ningun endoso, favor de verificar las condiciones Particulares.");
        }
        function LicenciaExtrajero() {
            alert("El campo de Licencia de Extrajero es obligatoria para generar este endoso, favor de verificar.");
            $("#<%=txtNumeroLicenciaExtranjero.ClientID%>").css("border-color", "red");
        }

        function CamposVaciosConductorUnico() {
            alert("El campo nombre o el campo cedula no pueden estar vacios para generar este endoso, favor de verificar.");
        }
        function CampoNombreVacioConductorUnico() { $("#<%=txtNombreConductorUnico.ClientID%>").css("border-color", "red"); }
        function CampoCedulaVacioConductorUnico() { $("#<%=txtCedulaConductorUnico.ClientID%>").css("border-color", "red"); }



        function MostrarVentanaEmergente(url) {
            console.log("URL del reporte cargado en iframe:", url); // Esto mostrará la URL en la consola
            document.getElementById('iframeReporte').src = url; // Cargar la URL en el iframe
            document.getElementById('ventanaEmergente').style.display = 'block'; // Mostrar la ventana emergente
        }


        function CerrarVentana() {
            document.getElementById('ventanaEmergente').style.display = 'none';
        }



        $(function () {

            //VALIDAR EL BOTON BUSCAR
            $("#<%=btnConsultar.ClientID%>").click(function () {
                var Poliza = $("#<%=txtPolizaConsulta.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo poliza no puede estar vacio para buscar un registro, favor de verificar.");
                    $("#<%=txtPolizaConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Item = $("#<%=txtNumeroItenComsulta.ClientID%>").val().length;
                    if (Item < 1) {
                        alert("El campo Item no puede estar vacio para buscar un registro, favor de verificar.");
                        $("#<%=txtNumeroItenComsulta.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }
            });
        })
    </script>
    <div class="container-fluid endosos-page">

        <div class="up-page-header">
            <div class="up-page-header-icon"><i class="fa fa-file-signature"></i></div>
            <div>
                <h1 class="up-page-title">Endosos</h1>
                <p class="up-page-sub">Generación e histórico de endosos por póliza</p>
            </div>
        </div>

        <div id="ventanaEmergente" style="display:none; position:fixed; top:10%; left:15%; width:70%; height:80%; z-index:1000;" class="up-modal">
            <div class="up-modal-header">
                <span><i class="fa fa-file-lines"></i> Reporte de Endoso</span>
                <button onclick="CerrarVentana()" style="border:none;" class="up-modal-close">
                    <img src="../../ImagenesBotones/Cerrar.png" alt="Cerrar" />
                </button>
            </div>
            <iframe id="iframeReporte" style="width:100%; height:100%; border:none; flex:1;"></iframe>
        </div>


        <div class="progress">
            <asp:UpdateProgress ID="progress" runat="server"></asp:UpdateProgress>
        </div>
        <asp:Label ID="lbIdPerfil" runat="server" Visible="false" Text="0"></asp:Label>
        <asp:ScriptManager ID="ScripManagerEndosos" runat="server"></asp:ScriptManager>

        <!-- ── Búsqueda ── -->
        <div class="up-card">
            <div class="up-section-title"><i class="fa fa-magnifying-glass"></i> Buscar Póliza</div>
            <div class="row">
                <div class="col-md-6">
                    <label class="Letranegrita">Poliza: </label>
                    <asp:TextBox ID="txtPolizaConsulta" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label class="Letranegrita">Item No.: </label>
                    <asp:TextBox ID="txtNumeroItenComsulta" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="up-actions-center">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultar_Click" />
                <asp:ImageButton ID="btnRestablecerPantalla" runat="server" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Restablecer_Nuevo.png" OnClick="btnRestablecerPantalla_Click" />
            </div>
        </div>

        <div id="DIVBloqueDetallePoliza" runat="server" class="up-card">
            <div class="up-section-title"><i class="fa fa-id-card"></i> Detalle de Póliza</div>
            <div class="row up-detail-grid">
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Poliza: </label>
                    <asp:Label ID="lbPolizaDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Item No.: </label>
                    <asp:Label ID="lbItemNoDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Inicio de Vigencia: </label>
                    <asp:Label ID="lbInicioVigenciaDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Fin de Vigencia: </label>
                    <asp:Label ID="lbFinVIgenciaDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Supervisor: </label>
                    <asp:Label ID="lbSupervisorDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Intermediario: </label>
                    <asp:Label ID="lbIntermediarioDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Estatus: </label>
                    <asp:Label ID="lbEstatusDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Ramo: </label>
                    <asp:Label ID="lbRamoDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Sub Ramo: </label>
                    <asp:Label ID="lbSubRamoDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                    <asp:HiddenField ID="hfCodigoSubRamoVariable" runat="server" />
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Cliente: </label>
                    <asp:Label ID="lbClienteDetalleVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Tipo: </label>
                    <asp:Label ID="lbTipoSeguroVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                </div>
                <div class="col-md-3 up-detail-item">
                    <label class="Letranegrita">Grua: </label>
                    <asp:Label ID="lbGruaVariable" runat="server" Text="Dato" CssClass="up-value"></asp:Label>
                    <asp:HiddenField ID="hfCodigoGrua" runat="server" />
                </div>
            </div>
        </div>

        <div id="DIVBloqueOperacionRealizar" runat="server" class="up-card">
            <div class="up-section-title"><i class="fa fa-list-check"></i> Operación a Realizar</div>
            <div class="form-check-inline up-radio-group">
                <asp:RadioButton ID="rbHistoricoEndoso" runat="server" Text="Historico" AutoPostBack="true" OnCheckedChanged="rbHistoricoEndoso_CheckedChanged" GroupName="TipoOperacion" />
                <asp:RadioButton ID="rbGenerarNuevoEndoso" runat="server" Text="Nuevo Registro" AutoPostBack="true" OnCheckedChanged="rbGenerarNuevoEndoso_CheckedChanged" GroupName="TipoOperacion" />
            </div>
        </div>

        <div id="DIVBloqueHistorico" runat="server" class="up-card">
            <div class="up-section-title-row">
                <div class="up-section-title"><i class="fa fa-clock-rotate-left"></i> Histórico de Endosos</div>
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Reporte de Impresión de Endoso" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporte_Click" />
            </div>
            <br />
            <div class="table-responsive up-table-wrap">
                <table class="table table-striped">
                    <thead class="table-dark">
                        <tr>
                            <th scope="col"> Endoso </th>
                            <th scope="col"> Poliza </th>
                            <th scope="col"> Item </th>
                            <th scope="col"> Secuencia </th>
                            <th scope="col"> Fecha </th>
                            <th scope="col"> Hora </th>
                            <th scope="col"> Usuario </th>
                            <th scope="col">  </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoEndososImpresos" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                                    <asp:HiddenField ID="hfItem" runat="server" Value='<%# Eval("Item") %>' />
                                    <asp:HiddenField ID="hfIdUsuario" runat="server" Value='<%# Eval("IdUsuario") %>' />
                                    <asp:HiddenField ID="hfCodigoTipoEndoso" runat="server" Value='<%# Eval("CodigoTipoEndoso") %>' />
                                    <asp:HiddenField ID="hfSecuencia" runat="server" Value='<%# Eval("Secuencia") %>' />



                                    <td> <%# Eval("TipoEndoso") %> </td>
                                    <td> <%# Eval("Poliza") %> </td>
                                    <td> <%#string.Format("{0:N0}", Eval("Item")) %> </td>
                                    <td> <%# Eval("Secuencia") %> </td>
                                    <td> <%# Eval("Fecha") %> </td>
                                    <td> <%# Eval("Hora") %> </td>
                                    <td> <%# Eval("CreadoPor") %> </td>
                                    <td align="right"> <asp:ImageButton ID="btnReImprimirEndoso" runat="server" ToolTip="GenerarEndoso" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/impresora-de-papel.png" OnClick="btnReImprimirEndoso_Click" /> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <table class="table">
                    <tfoot class="table-light">
                        <tr>
                            <td class="ContenidoDerecha">
                                <label class="Letranegrita" style="display:inline;">Pagina</label> <asp:Label ID="lbPaginaActual" runat="server" Text=" 0 " CssClass="up-value" style="display:inline;"></asp:Label>
                                <label class="Letranegrita" style="display:inline;"> De </label>   <asp:Label ID="lbCantidadPagina" runat="server" Text="0" CssClass="up-value" style="display:inline;"></asp:Label> </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="Letranegrita" style="display:inline;">Endosos Aclaratorios:  </label> <asp:Label ID="lbTotalEndososAclaratorios" runat="server" Text="0" CssClass="up-value" style="display:inline;"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="Letranegrita" style="display:inline;">Endosos Licencia de Extrajeros:  </label> <asp:Label ID="lbTotalEndososLicenciaExtrajero" runat="server" Text="0" CssClass="up-value" style="display:inline;"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="Letranegrita" style="display:inline;">Endosos Conductor Unico:  </label> <asp:Label ID="lbTotalEndososConductorUnico" runat="server" Text="0" CssClass="up-value" style="display:inline;"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="Letranegrita" style="display:inline;"></label> <asp:Label ID="lbTotalEndososAuxilioVial" runat="server" Text="0" CssClass="up-value" style="display:inline;"></asp:Label>

                            </td>
                        </tr>

                    </tfoot>
                </table>
            </div>
            <div id="DivPaginacionListadoPrincipal" runat="server" align="center">
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" OnClick="btnPrimeraPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" OnClick="btnPaginaAnterior_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipal" runat="server" OnCancelCommand="dtPaginacionListadoPrincipal_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipal_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" OnClick="btnSiguientePagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" OnClick="btnUltimaPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>

                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="DIVBloqueNuevoRegistro" runat="server" class="up-card">
            <div class="form-check-inline up-radio-list" id="DIVBloqueTiposEndosos" runat="server">
                <div class="up-section-title"><i class="fa fa-pen-to-square"></i> Tipo de Endoso a Generar</div>
                <asp:RadioButton ID="rbEndosoAclaratorio" runat="server" Text="Endoso Aclaratorio" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso Aclaratorio" OnCheckedChanged="rbEndosoAclaratorio_CheckedChanged" />
                <asp:RadioButton ID="rbEndosoLicenciaExtragero" runat="server" Text="Endoso de Licencia de Extragero" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso De Licencia de Extragero" OnCheckedChanged="rbEndosoLicenciaExtragero_CheckedChanged" />
                <asp:RadioButton ID="rbEndosoAclaratorioPAraCodundorUnico" runat="server" Text="Endoso de Conductor Unico" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso Para Conductor Unico" OnCheckedChanged="rbEndosoAclaratorioPAraCodundorUnico_CheckedChanged" />
                <asp:RadioButton ID="rbENdosoAuxilioVial" runat="server" Text="Endoso Auxilio Vial" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso de Auxilio Vial" OnCheckedChanged="rbENdosoAuxilioVial_CheckedChanged" />
                <asp:RadioButton ID="rbEndosoCasaConductor" runat="server" Text="Centro del Automovilista" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso del Centro del Automovilista" OnCheckedChanged="rbEndosoCasaConductor_CheckedChanged" />
                <asp:RadioButton ID="rbEndosoDVL" runat="server" Text="Endoso de DVL" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso DVL" OnCheckedChanged="rbEndosoDVL_CheckedChanged" />
            </div>
            <br />
            <div class="row up-conditional-fields">
                <div class="col-md-4" id="DIVBloqueLicenciaExtrajero" runat="server">
                    <asp:Label ID="lbNumeroLicenciaExtrajero" runat="server" Text="Licencia Extrajero" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroLicenciaExtranjero" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                </div>
                <div class="col-md-4" id="DIVBloqueNombre" runat="server">
                    <asp:Label ID="lbNombreConductorUnico" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreConductorUnico" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                </div>
                <div class="col-md-4" id="DIVBloqueCedula" runat="server">
                    <asp:Label ID="lbCedulaConductorUnico" runat="server" Text="Cedula" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCedulaConductorUnico" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="txtCedulaConductorUnico" Mask="999-9999999-9"
                        MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                        MaskType="Number" InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                        ErrorTooltipEnabled="True" ID="MaskedEditExtender1" />
                </div>
            </div>
            <br />
            <div class="up-actions-center">
                <asp:ImageButton ID="btnCompletar" runat="server" ToolTip="Completar Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Completado.png" OnClick="btnCompletar_Click" />
            </div>
        </div>

    </div>

</asp:Content>

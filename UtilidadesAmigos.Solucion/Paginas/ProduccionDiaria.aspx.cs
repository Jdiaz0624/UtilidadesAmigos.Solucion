using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//EXPORTAMOS A EXEL
using System.IO;
using System.Drawing;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionDiaria : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region CARGAR LOS RAMOS
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataLogica.Value.BuscaListas("RAMO", null, null));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LA PRODUCCION DIARIA
        private void MostrarProduccionDiaria()
        {
            if (cbEspesificarRamo.Checked)
            {
                var MostrarData = ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToInt32(ddlSeleccionarRamo.SelectedValue),
                    null);
                gbProduccionDiaria.DataSource = MostrarData;
                gbProduccionDiaria.DataBind();
                decimal TotalFacturado = 0, TotalPesosDominicanos = 0;
                foreach (var n in MostrarData)
                {
                    TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                    TotalPesosDominicanos = Convert.ToDecimal(n.TotalPesosDominicanos);
                    lbCantidadFActuradoVariable.Text = TotalFacturado.ToString("N2");
                    lbCantidadFacturadoPesosVariable.Text = TotalPesosDominicanos.ToString("N2");
                }
            }
            else
            {
                var MostrarData = ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text));
                gbProduccionDiaria.DataSource = MostrarData;
                gbProduccionDiaria.DataBind();
                decimal TotalFacturado = 0, TotalPesosDominicanos = 0;
                foreach (var n in MostrarData)
                {
                    TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                    TotalPesosDominicanos = Convert.ToDecimal(n.TotalPesosDominicanos);
                    lbCantidadFActuradoVariable.Text = TotalFacturado.ToString("N2");
                    lbCantidadFacturadoPesosVariable.Text = TotalPesosDominicanos.ToString("N2");
                }
            }
        }
        #endregion
        #region EXPORTAR DATA A EXEL
        private void ExportarDataExel()
        {
            if (cbEspesificarRamo.Checked)
            {
                var Exportar = (from n in ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToInt32(ddlSeleccionarRamo.SelectedValue),
                    null)
                                select new
                                {
                                    Ramo =n.Ramo,
                                    Concepto =n.Concepto,
                                    Cantidad=n.Cantidad,
                                    Moneda=n.Moneda,
                                    Facturado=n.Facturado,
                                    PesosDominicanos=n.PesosDominicanos
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Diaria " + " - " + ddlSeleccionarRamo.SelectedItem, Exportar);
            }
            else
            {
                var Exportar = (from n in ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text))
                                select new
                                {
                                    Ramo = n.Ramo,
                                    Concepto = n.Concepto,
                                    Cantidad = n.Cantidad,
                                    Moneda = n.Moneda,
                                    Facturado = n.Facturado,
                                    PesosDominicanos = n.PesosDominicanos
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Diaria " + " - " + ddlSeleccionarRamo.SelectedItem, Exportar);
            }
        }
        #endregion
        #region MOSTRAR EL DETALLE DE LA PRODUCCION DIARIA
        private void MostrarDetalleProduccionDiaria()
        {
            //SELECCIONAMOS LOS CAMPOS NECESARIOS PAA SACAR LOS DATOS
            try
            {
                GridViewRow gb = gbProduccionDiaria.SelectedRow;

                var SacarDetalle = ObjDataLogica.Value.ProduccionDiariaDetalle(
                    Convert.ToInt32(gb.Cells[0].Text),
                    gb.Cells[2].Text,
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text));
                gbProduccionDiaria.Visible = false;
                gbProduccionDiariaDetalle.Visible = true;
                rbExportarDependientes.Visible = true;
                rbExportarNormal.Visible = true;
                rbExportarNormal.Checked = true;
                txtFechaDesde.Enabled = false;
                txtFechaHasta.Enabled = false;
                btnAtras.Visible = true;
                cbExportarTodo.Visible = true;
                btnBuscarRegistros.Enabled = false;
                btnGenerarReporte.Enabled = false;
                gbProduccionDiariaDetalle.DataSource = SacarDetalle;
                gbProduccionDiariaDetalle.DataBind();
            }
            catch (Exception) { }
        }
        #endregion

        #region PERMISO PERFILES
        enum UsuariosPermiso
        {
            JUAN_MARCELINO_MEDINA_DIAZ = 1,
            ALFREDO_PIMENTEL = 10,
            EDUARD_GARCIA = 12,
            ING_MIGUEL_BERROA = 22,
            NOELIA_GONZALEZ = 28
        }
        private void SacarDatosUsuario(decimal IdUsuario)
        {
            Label lbControlUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
            lbControlUsuarioConectado.Text = "";

            Label lbControlOficinaUsuario = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
            lbControlOficinaUsuario.Text = "";

            var SacarDatos = ObjDataLogica.Value.BuscaUsuarios(IdUsuario,
                null,
                null,
                null,
                null,
                null,
                null);
            foreach (var n in SacarDatos)
            {
                lbControlUsuarioConectado.Text = n.Persona;
                lbControlOficinaUsuario.Text = n.Departamento + " - " + n.Sucursal + " - " + n.Oficina;
                //lbDepartamento.Text = n.Departamento;
                //lbSucursal.Text = n.Sucursal;
                //lbOficina.Text = n.Oficina;
                lbIdPerfil.Text = n.IdPerfil.ToString();
            }


        }
        private void PermisoPerfil()
        {

            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                SacarDatosUsuario(Convert.ToDecimal(Session["IdUsuario"]));
                decimal IdUsuarioConectado = Convert.ToDecimal(Session["IdUsuario"]);
                decimal Hablar = Convert.ToDecimal(Session["Veronica"]);

                LinkButton LinkReporteIntermediarioAlfredo = (LinkButton)Master.FindControl("LinkReporteAlfredoIntermediarios");
                LinkReporteIntermediarioAlfredo.Visible = false;

                if (IdUsuarioConectado == (decimal)UsuariosPermiso.JUAN_MARCELINO_MEDINA_DIAZ) { LinkReporteIntermediarioAlfredo.Visible = true; }
                else if (IdUsuarioConectado == (decimal)UsuariosPermiso.ALFREDO_PIMENTEL) { LinkReporteIntermediarioAlfredo.Visible = true; }
                else if (IdUsuarioConectado == (decimal)UsuariosPermiso.EDUARD_GARCIA) { LinkReporteIntermediarioAlfredo.Visible = true; }
                else if (IdUsuarioConectado == (decimal)UsuariosPermiso.ING_MIGUEL_BERROA) { LinkReporteIntermediarioAlfredo.Visible = true; }
                else if (IdUsuarioConectado == (decimal)UsuariosPermiso.NOELIA_GONZALEZ) { LinkReporteIntermediarioAlfredo.Visible = true; }




                int IdPerfil = Convert.ToInt32(lbIdPerfil.Text);

                #region CONTROLE DEL SISTEMA
                //SUMINISTRO------------------------------------------------------------------------------------------------
                LinkButton LinkAdministracionSuministro = (LinkButton)Master.FindControl("LinkAdministracionSuministro");
                LinkButton LinkSolicitud = (LinkButton)Master.FindControl("LinkSolicitud");


                //CONSULTA----------------------------------------------------------------------------------------------------
                LinkButton LinkCartera = (LinkButton)Master.FindControl("LinkCartera");
                LinkButton LinkConsultarPersonas = (LinkButton)Master.FindControl("LinkConsultarPersonas");
                LinkButton linkProduccionPorUsuarios = (LinkButton)Master.FindControl("linkProduccionPorUsuarios");
                LinkButton linkProduccionDiaria = (LinkButton)Master.FindControl("linkProduccionDiaria");
                LinkButton linkGenerarCartera = (LinkButton)Master.FindControl("linkGenerarCartera");
                LinkButton linkCarteraIntermediarios = (LinkButton)Master.FindControl("linkCarteraIntermediarios");
                LinkButton linkComisionesCobrador = (LinkButton)Master.FindControl("linkComisionesCobrador");
                LinkButton LinkEstadisticaRenovacion = (LinkButton)Master.FindControl("LinkEstadisticaRenovacion");
                LinkButton linkValidarCoberturas = (LinkButton)Master.FindControl("linkValidarCoberturas");
                LinkButton linkGenerarReporteUAF = (LinkButton)Master.FindControl("linkGenerarReporteUAF");
                LinkButton LinkReporteReclamos = (LinkButton)Master.FindControl("LinkReporteReclamos");
                LinkButton LinkControlVisitas = (LinkButton)Master.FindControl("LinkControlVisitas");
                LinkButton LinkConsultarInformacionAsegurado = (LinkButton)Master.FindControl("LinkConsultarInformacionAsegurado");



                //REPORTES------------------------------------------------------------------------------------------------------------
                LinkButton LinkProduccionIntermediarioSupervisor = (LinkButton)Master.FindControl("LinkProduccionIntermediarioSupervisor");
                LinkButton LinkReporteCobrado = (LinkButton)Master.FindControl("LinkReporteCobrado");
                LinkButton LinkReporteAlfredoIntermediarios = (LinkButton)Master.FindControl("LinkReporteAlfredoIntermediarios");
                LinkButton LiniComisionesIntermediarios = (LinkButton)Master.FindControl("LiniComisionesIntermediarios");
                LinkButton LinkComisionesSupervisores = (LinkButton)Master.FindControl("LinkComisionesSupervisores");
                LinkButton LinkSobreComision = (LinkButton)Master.FindControl("LinkSobreComision");
                LinkButton LinkProduccionDiariaContabilidad = (LinkButton)Master.FindControl("LinkProduccionDiariaContabilidad");
                LinkButton LinkReportePrimaDeposito = (LinkButton)Master.FindControl("LinkReportePrimaDeposito");
                LinkButton LinkReporteReclamaciones = (LinkButton)Master.FindControl("LinkReporteReclamaciones");
                LinkButton LinkReclamacionesPagadas = (LinkButton)Master.FindControl("LinkReclamacionesPagadas");


                //PROCESOS
                LinkButton LinkBakupBD = (LinkButton)Master.FindControl("LinkBakupBD");
                LinkButton LinkGenerarSOlicitudChequeComisiones = (LinkButton)Master.FindControl("LinkGenerarSOlicitudChequeComisiones");
                LinkButton LinkProcesarDataAsegurado = (LinkButton)Master.FindControl("LinkProcesarDataAsegurado");
                LinkButton LinkCorregirValorDeclarativa = (LinkButton)Master.FindControl("LinkCorregirValorDeclarativa");
                LinkButton LinkCorregirLimites = (LinkButton)Master.FindControl("LinkCorregirLimites");
                LinkButton LinkEnvioCorreo = (LinkButton)Master.FindControl("LinkEnvioCorreo");
                LinkButton LinkEliminarBalance = (LinkButton)Master.FindControl("LinkEliminarBalance");
                LinkButton LinkGenerarFacturasPDF = (LinkButton)Master.FindControl("LinkGenerarFacturasPDF");
                LinkButton LinkVolantePago = (LinkButton)Master.FindControl("LinkVolantePago");
                LinkButton linkUtilidadesCobros = (LinkButton)Master.FindControl("linkUtilidadesCobros");
                LinkButton LinkAgregarDPAReclamos = (LinkButton)Master.FindControl("LinkAgregarDPAReclamos");


                //MANTENIMIENTOS
                LinkButton LinkClientes = (LinkButton)Master.FindControl("LinkClientes");
                LinkButton LinkIntermediariosSupervisores = (LinkButton)Master.FindControl("LinkIntermediariosSupervisores");
                LinkButton linkOficinas = (LinkButton)Master.FindControl("linkOficinas");
                LinkButton linkDeprtamentos = (LinkButton)Master.FindControl("linkDeprtamentos");
                LinkButton linkEmpleados = (LinkButton)Master.FindControl("linkEmpleados");
                LinkButton linkInventario = (LinkButton)Master.FindControl("linkInventario");
                LinkButton LinkDependientes = (LinkButton)Master.FindControl("LinkDependientes");
                LinkButton LinkCorreoElectronicos = (LinkButton)Master.FindControl("LinkCorreoElectronicos");
                LinkButton LinkMantenimientoPorcientoComisionPorDefecto = (LinkButton)Master.FindControl("LinkMantenimientoPorcientoComisionPorDefecto");
                LinkButton LinkMantenimientoMonedas = (LinkButton)Master.FindControl("LinkMantenimientoMonedas");


                //COTIZADOR
                LinkButton LinkCotizador = (LinkButton)Master.FindControl("LinkCotizador");


                //SEGURIDAD
                LinkButton linkUsuarios = (LinkButton)Master.FindControl("linkUsuarios");
                LinkButton linkPerfilesUsuarios = (LinkButton)Master.FindControl("linkPerfilesUsuarios");
                LinkButton linkClaveSeguridad = (LinkButton)Master.FindControl("linkClaveSeguridad");
                LinkButton LinkCorreosEmisoresProcesos = (LinkButton)Master.FindControl("LinkCorreosEmisoresProcesos");
                LinkButton linkMovimientoUsuarios = (LinkButton)Master.FindControl("linkMovimientoUsuarios");
                LinkButton linkTarjetasAccesos = (LinkButton)Master.FindControl("linkTarjetasAccesos");
                LinkButton linkOpcionMenu = (LinkButton)Master.FindControl("linkOpcionMenu");
                LinkButton linkOpcion = (LinkButton)Master.FindControl("linkOpcion");
                LinkButton linkBotones = (LinkButton)Master.FindControl("linkBotones");
                LinkButton linkPermisoUsuarios = (LinkButton)Master.FindControl("linkPermisoUsuarios");
                LinkButton LinkCredencialesBD = (LinkButton)Master.FindControl("LinkCredencialesBD");
                #endregion


                switch (IdPerfil)
                {

                    //ADMINISTRADOR
                    case 1:
                        //SUMINISTRO
                        LinkAdministracionSuministro.Visible = true;
                        LinkSolicitud.Visible = true;

                        //CONSULTA
                        LinkCartera.Visible = true;
                        LinkConsultarPersonas.Visible = true;
                        linkProduccionPorUsuarios.Visible = false; //DESCARTADO
                        linkProduccionDiaria.Visible = false; //DESCARTADO
                        linkGenerarCartera.Visible = false; //DESCARTADO
                        linkCarteraIntermediarios.Visible = false; //DESCARTADO
                        linkComisionesCobrador.Visible = true;
                        LinkEstadisticaRenovacion.Visible = true;
                        linkValidarCoberturas.Visible = true;
                        linkGenerarReporteUAF.Visible = true;
                        LinkReporteReclamos.Visible = false; //DESCARTADO
                        LinkControlVisitas.Visible = true;
                        LinkConsultarInformacionAsegurado.Visible = true;

                        //REPORTES
                        LinkProduccionIntermediarioSupervisor.Visible = true;
                        LinkReporteCobrado.Visible = true;
                        LinkReporteAlfredoIntermediarios.Visible = true;
                        LiniComisionesIntermediarios.Visible = true;
                        LinkComisionesSupervisores.Visible = true;
                        LinkSobreComision.Visible = true;
                        LinkProduccionDiariaContabilidad.Visible = true;
                        LinkReportePrimaDeposito.Visible = true;
                        LinkReporteReclamaciones.Visible = true;
                        LinkReclamacionesPagadas.Visible = true;

                        //PROCESOS
                        LinkBakupBD.Visible = true;
                        LinkGenerarSOlicitudChequeComisiones.Visible = true;
                        LinkProcesarDataAsegurado.Visible = true;
                        LinkCorregirValorDeclarativa.Visible = true;
                        LinkCorregirLimites.Visible = false; //DESCARTADO
                        LinkEnvioCorreo.Visible = false; //DESCARTADO
                        LinkEliminarBalance.Visible = false; //DESCARTADO
                        LinkGenerarFacturasPDF.Visible = false; //DESCARTADO
                        LinkVolantePago.Visible = true;
                        linkUtilidadesCobros.Visible = true;
                        LinkAgregarDPAReclamos.Visible = true;

                        //MANTENIMIENTOS
                        LinkClientes.Visible = true;
                        LinkIntermediariosSupervisores.Visible = true;
                        linkOficinas.Visible = true;
                        linkDeprtamentos.Visible = true;
                        linkEmpleados.Visible = true;
                        linkInventario.Visible = true;
                        LinkDependientes.Visible = true;
                        LinkCorreoElectronicos.Visible = false; //DESCARTADO
                        LinkMantenimientoPorcientoComisionPorDefecto.Visible = true;
                        LinkMantenimientoMonedas.Visible = true;

                        //COTIZADOR
                        LinkCotizador.Visible = false;

                        //SEGURIDAD
                        linkUsuarios.Visible = true;
                        linkPerfilesUsuarios.Visible = true;
                        linkClaveSeguridad.Visible = true;
                        LinkCorreosEmisoresProcesos.Visible = true;
                        linkMovimientoUsuarios.Visible = true;
                        linkTarjetasAccesos.Visible = true;
                        linkOpcionMenu.Visible = true;
                        linkOpcion.Visible = true;
                        linkBotones.Visible = true;
                        linkPermisoUsuarios.Visible = true;
                        LinkCredencialesBD.Visible = true;
                        break;
                    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    case 2:
                        //PERFIL DE CONTABILIDAD, AUDITORIA Y RRHH
                        //SUMINISTRO
                        LinkAdministracionSuministro.Visible = true;
                        LinkSolicitud.Visible = true;

                        //CONSULTA
                        LinkCartera.Visible = true;
                        LinkConsultarPersonas.Visible = true;
                        linkProduccionPorUsuarios.Visible = false; //DESCARTADO
                        linkProduccionDiaria.Visible = false; //DESCARTADO
                        linkGenerarCartera.Visible = false; //DESCARTADO
                        linkCarteraIntermediarios.Visible = false; //DESCARTADO
                        linkComisionesCobrador.Visible = true;
                        LinkEstadisticaRenovacion.Visible = true;
                        linkValidarCoberturas.Visible = true;
                        linkGenerarReporteUAF.Visible = true;
                        LinkReporteReclamos.Visible = false; //DESCARTADO
                        LinkControlVisitas.Visible = true;
                        LinkConsultarInformacionAsegurado.Visible = true;

                        //REPORTES
                        LinkProduccionIntermediarioSupervisor.Visible = true;
                        LinkReporteCobrado.Visible = true;
                        LinkReporteAlfredoIntermediarios.Visible = true;
                        LiniComisionesIntermediarios.Visible = true;
                        LinkComisionesSupervisores.Visible = true;
                        LinkSobreComision.Visible = true;
                        LinkProduccionDiariaContabilidad.Visible = true;
                        LinkReportePrimaDeposito.Visible = true;
                        LinkReporteReclamaciones.Visible = true;
                        LinkReclamacionesPagadas.Visible = true;

                        //PROCESOS
                        LinkBakupBD.Visible = false;
                        LinkGenerarSOlicitudChequeComisiones.Visible = true;
                        LinkProcesarDataAsegurado.Visible = false;
                        LinkCorregirValorDeclarativa.Visible = false;
                        LinkCorregirLimites.Visible = false; //DESCARTADO
                        LinkEnvioCorreo.Visible = false; //DESCARTADO
                        LinkEliminarBalance.Visible = false; //DESCARTADO
                        LinkGenerarFacturasPDF.Visible = false; //DESCARTADO
                        LinkVolantePago.Visible = true;
                        linkUtilidadesCobros.Visible = true;
                        LinkAgregarDPAReclamos.Visible = true;

                        //MANTENIMIENTOS
                        LinkClientes.Visible = false;
                        LinkIntermediariosSupervisores.Visible = true;
                        linkOficinas.Visible = false;
                        linkDeprtamentos.Visible = false;
                        linkEmpleados.Visible = false;
                        linkInventario.Visible = false;
                        LinkDependientes.Visible = true;
                        LinkCorreoElectronicos.Visible = false; //DESCARTADO
                        LinkMantenimientoPorcientoComisionPorDefecto.Visible = false;
                        LinkMantenimientoMonedas.Visible = true;

                        //COTIZADOR
                        LinkCotizador.Visible = true;

                        //SEGURIDAD
                        linkUsuarios.Visible = false;
                        linkPerfilesUsuarios.Visible = false;
                        linkClaveSeguridad.Visible = false;
                        LinkCorreosEmisoresProcesos.Visible = false;
                        linkMovimientoUsuarios.Visible = false;
                        linkTarjetasAccesos.Visible = false;
                        linkOpcionMenu.Visible = false;
                        linkOpcion.Visible = false;
                        linkBotones.Visible = false;
                        linkPermisoUsuarios.Visible = false;
                        LinkCredencialesBD.Visible = false;
                        break;

                    case 3:
                        //PERFIL DE PROCESO
                        //SUMINISTRO
                        LinkAdministracionSuministro.Visible = false;
                        LinkSolicitud.Visible = false;

                        //CONSULTA
                        LinkCartera.Visible = true;
                        LinkConsultarPersonas.Visible = true;
                        linkProduccionPorUsuarios.Visible = false; //DESCARTADO
                        linkProduccionDiaria.Visible = false; //DESCARTADO
                        linkGenerarCartera.Visible = false; //DESCARTADO
                        linkCarteraIntermediarios.Visible = false; //DESCARTADO
                        linkComisionesCobrador.Visible = true;
                        LinkEstadisticaRenovacion.Visible = true;
                        linkValidarCoberturas.Visible = true;
                        linkGenerarReporteUAF.Visible = true;
                        LinkReporteReclamos.Visible = false; //DESCARTADO
                        LinkControlVisitas.Visible = true;
                        LinkConsultarInformacionAsegurado.Visible = false;

                        //REPORTES
                        LinkProduccionIntermediarioSupervisor.Visible = true;
                        LinkReporteCobrado.Visible = true;
                        LinkReporteAlfredoIntermediarios.Visible = false;
                        LiniComisionesIntermediarios.Visible = true;
                        LinkComisionesSupervisores.Visible = true;
                        LinkSobreComision.Visible = true;
                        LinkProduccionDiariaContabilidad.Visible = false;
                        LinkReportePrimaDeposito.Visible = false;
                        LinkReporteReclamaciones.Visible = true;
                        LinkReclamacionesPagadas.Visible = true;

                        //PROCESOS
                        LinkBakupBD.Visible = false;
                        LinkGenerarSOlicitudChequeComisiones.Visible = false;
                        LinkProcesarDataAsegurado.Visible = false;
                        LinkCorregirValorDeclarativa.Visible = true;
                        LinkCorregirLimites.Visible = false; //DESCARTADO
                        LinkEnvioCorreo.Visible = false; //DESCARTADO
                        LinkEliminarBalance.Visible = false; //DESCARTADO
                        LinkGenerarFacturasPDF.Visible = false; //DESCARTADO
                        LinkVolantePago.Visible = false;
                        linkUtilidadesCobros.Visible = true;
                        LinkAgregarDPAReclamos.Visible = true;

                        //MANTENIMIENTOS
                        LinkClientes.Visible = false;
                        LinkIntermediariosSupervisores.Visible = true;
                        linkOficinas.Visible = false;
                        linkDeprtamentos.Visible = false;
                        linkEmpleados.Visible = false;
                        linkInventario.Visible = false;
                        LinkDependientes.Visible = true;
                        LinkCorreoElectronicos.Visible = false; //DESCARTADO
                        LinkMantenimientoPorcientoComisionPorDefecto.Visible = false;
                        LinkMantenimientoMonedas.Visible = false;

                        //COTIZADOR
                        LinkCotizador.Visible = true;

                        //SEGURIDAD
                        linkUsuarios.Visible = false;
                        linkPerfilesUsuarios.Visible = false;
                        linkClaveSeguridad.Visible = false;
                        LinkCorreosEmisoresProcesos.Visible = false;
                        linkMovimientoUsuarios.Visible = false;
                        linkTarjetasAccesos.Visible = false;
                        linkOpcionMenu.Visible = false;
                        linkOpcion.Visible = false;
                        linkBotones.Visible = false;
                        linkPermisoUsuarios.Visible = false;
                        LinkCredencialesBD.Visible = false;
                        break;

                    case 4:
                        //PERFIL DE CONSULTA
                        //PERFIL DE PROCESO
                        //SUMINISTRO
                        LinkAdministracionSuministro.Visible = false;
                        LinkSolicitud.Visible = false;

                        //CONSULTA
                        LinkCartera.Visible = true;
                        LinkConsultarPersonas.Visible = true;
                        linkProduccionPorUsuarios.Visible = false; //DESCARTADO
                        linkProduccionDiaria.Visible = false; //DESCARTADO
                        linkGenerarCartera.Visible = false; //DESCARTADO
                        linkCarteraIntermediarios.Visible = false; //DESCARTADO
                        linkComisionesCobrador.Visible = true;
                        LinkEstadisticaRenovacion.Visible = true;
                        linkValidarCoberturas.Visible = false;
                        linkGenerarReporteUAF.Visible = true;
                        LinkReporteReclamos.Visible = false; //DESCARTADO
                        LinkControlVisitas.Visible = true;
                        LinkConsultarInformacionAsegurado.Visible = false;

                        //REPORTES
                        LinkProduccionIntermediarioSupervisor.Visible = true;
                        LinkReporteCobrado.Visible = true;
                        LinkReporteAlfredoIntermediarios.Visible = false;
                        LiniComisionesIntermediarios.Visible = false;
                        LinkComisionesSupervisores.Visible = false;
                        LinkSobreComision.Visible = false;
                        LinkProduccionDiariaContabilidad.Visible = false;
                        LinkReportePrimaDeposito.Visible = false;
                        LinkReporteReclamaciones.Visible = true;
                        LinkReclamacionesPagadas.Visible = true;

                        //PROCESOS
                        LinkBakupBD.Visible = false;
                        LinkGenerarSOlicitudChequeComisiones.Visible = false;
                        LinkProcesarDataAsegurado.Visible = false;
                        LinkCorregirValorDeclarativa.Visible = true;
                        LinkCorregirLimites.Visible = false; //DESCARTADO
                        LinkEnvioCorreo.Visible = false; //DESCARTADO
                        LinkEliminarBalance.Visible = false; //DESCARTADO
                        LinkGenerarFacturasPDF.Visible = false; //DESCARTADO
                        LinkVolantePago.Visible = false;
                        linkUtilidadesCobros.Visible = true;
                        LinkAgregarDPAReclamos.Visible = true;

                        //MANTENIMIENTOS
                        LinkClientes.Visible = false;
                        LinkIntermediariosSupervisores.Visible = true;
                        linkOficinas.Visible = false;
                        linkDeprtamentos.Visible = false;
                        linkEmpleados.Visible = false;
                        linkInventario.Visible = false;
                        LinkDependientes.Visible = true;
                        LinkCorreoElectronicos.Visible = false; //DESCARTADO
                        LinkMantenimientoPorcientoComisionPorDefecto.Visible = false;
                        LinkMantenimientoMonedas.Visible = false;

                        //COTIZADOR
                        LinkCotizador.Visible = true;

                        //SEGURIDAD
                        linkUsuarios.Visible = false;
                        linkPerfilesUsuarios.Visible = false;
                        linkClaveSeguridad.Visible = false;
                        LinkCorreosEmisoresProcesos.Visible = false;
                        linkMovimientoUsuarios.Visible = false;
                        linkTarjetasAccesos.Visible = false;
                        linkOpcionMenu.Visible = false;
                        linkOpcion.Visible = false;
                        linkBotones.Visible = false;
                        linkPermisoUsuarios.Visible = false;
                        LinkCredencialesBD.Visible = false;
                        break;
                }




            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamos();
                lbSeleccionarRamo.Visible = false;
                ddlSeleccionarRamo.Visible = false;
                PermisoPerfil();
            }
          

        }


        protected void gbListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gbListado.PageIndex = e.NewPageIndex;
            //CargarData();
        }

        protected void cbEspesificarRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEspesificarRamo.Checked)
            {
                lbSeleccionarRamo.Visible = true;
                ddlSeleccionarRamo.Visible = true;
            }
            else
            {
                lbSeleccionarRamo.Visible = false;
                ddlSeleccionarRamo.Visible = false;
            }
        }

        protected void gbProduccionDiaria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbProduccionDiaria.PageIndex = e.NewPageIndex;
            MostrarProduccionDiaria();
        }

        protected void gbProduccionDiaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbCantidadFacturadoTitulo.Visible = false;
            lbCantidadFActuradoVariable.Visible = false;
            lbCantidadFacturadoCerrar.Visible = false;
            lbEncabezado.Visible = false;
            lbCantidadFacturadoPesosTitulo.Visible = false;
            lbCantidadFacturadoPesosVariable.Visible = false;
            lbCantidadFacturadoPesosCerrar.Visible = false;
            MostrarDetalleProduccionDiaria();
        }

        protected void btnBuscarRegistros_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {
                try
                {
                    lbCantidadFacturadoTitulo.Visible = true;
                    lbCantidadFActuradoVariable.Visible = true;
                    lbCantidadFacturadoCerrar.Visible = true;
                    lbEncabezado.Visible = true;
                    lbCantidadFacturadoPesosTitulo.Visible = true;
                    lbCantidadFacturadoPesosVariable.Visible = true;
                    lbCantidadFacturadoPesosCerrar.Visible = true;
                    MostrarProduccionDiaria();
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                }
            }
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ErrorExportar", "ErrorExportar();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {
                try
                {
                    ExportarDataExel();
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorExportar()", true);
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            //REGRESAMOS TODO A ATRAS NUEVAMENTE
            btnAtras.Visible = false;
            btnBuscarRegistros.Enabled = true;
            btnGenerarReporte.Enabled = true;
            gbProduccionDiariaDetalle.Visible = false;
            rbExportarNormal.Visible = false;
            rbExportarDependientes.Visible = false;
            rbExportarNormal.Checked = true;
            gbProduccionDiaria.Visible = true;
            txtFechaDesde.Enabled = true;
            txtFechaHasta.Enabled = true;
            cbExportarTodo.Visible = false;


            lbCantidadFacturadoTitulo.Visible = true;
            lbCantidadFActuradoVariable.Visible = true;
            lbCantidadFacturadoCerrar.Visible = true;
            lbEncabezado.Visible = true;
            lbCantidadFacturadoPesosTitulo.Visible = true;
            lbCantidadFacturadoPesosVariable.Visible = true;
            lbCantidadFacturadoPesosCerrar.Visible = true;

           
        }

        protected void gbProduccionDiariaDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbProduccionDiariaDetalle.PageIndex = e.NewPageIndex;
            MostrarDetalleProduccionDiaria();
        }

        protected void gbProduccionDiariaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExportarTodo.Checked)
            {
                if (rbExportarNormal.Checked)
                {
                    try
                    {
                        GridViewRow gb = gbProduccionDiariaDetalle.SelectedRow;

                        //SACAMOS EL CODIGO DEL RAMO
                        int Ramo = 0;

                        var ExportarData = ObjDataLogica.Value.ProduccionDiariaDetalle(
                            null, null, null, null, gb.Cells[0].Text);
                        foreach (var n in ExportarData)
                        {
                            Ramo = Convert.ToInt32(n.CodRamo);
                        }
                        //HACEMOS EL FILTRO PARA EXPORTAR
                        var Exel = (from n in ObjDataLogica.Value.ProduccionDiariaDetalle(
                            Ramo,
                            gb.Cells[3].Text,
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text))
                                    select new
                                    {
                                        Factura = n.Numero,
                                        Poliza = n.Poliza,
                                        FechaFacturacion = n.FechaFacturacion,
                                        Concepto = n.Concepto,
                                        CodRamo = n.CodRamo,
                                        Ramo = n.Ramo,
                                        CodSubramo = n.CodSubramo,
                                        Subramo = n.Subramo,
                                        NombreCliente = n.NombreCliente,
                                        Telefonos = n.Telefonos,
                                        Direccion = n.Direccion,
                                        CodSupervisor = n.CodSupervisor,
                                        Supervisor = n.Supervisor,
                                        CodVendedor = n.CodIntermediario,
                                        Vendedor = n.Vendedor,
                                        TotalFacturado = n.Facturado,
                                        TotalCobrado = n.Cobrado,
                                        BalancePendiente = n.Balance,
                                        Oficina = n.Oficina
                                    }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Diaria Normal", Exel);
                    }
                    catch (Exception) { }
                }
                else if (rbExportarDependientes.Checked)
                {

                }
            }
            else
            {
                //EXPORTAMOS LOS DATOS A EXEL
                //EXPORTAMOS LOS CAMPOS MOSTRADOS EN EL GRID MAS LOS REGISTROS FALTANTES
                if (rbExportarNormal.Checked)
                {
                    try
                    {
                        GridViewRow gb = gbProduccionDiariaDetalle.SelectedRow;

                        //SACAMOS EL CODIGO DEL RAMO
                        int Ramo = 0;

                        var ExportarData = ObjDataLogica.Value.ProduccionDiariaDetalle(
                            null, null, null, null, gb.Cells[0].Text);
                        foreach (var n in ExportarData)
                        {
                            Ramo = Convert.ToInt32(n.CodRamo);
                        }
                        //HACEMOS EL FILTRO PARA EXPORTAR
                        var Exel = (from n in ObjDataLogica.Value.ProduccionDiariaDetalle(
                            Ramo,
                            gb.Cells[3].Text,
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            gb.Cells[0].Text)
                                    select new
                                    {
                                        Factura = n.Numero,
                                        Poliza = n.Poliza,
                                        FechaFacturacion = n.FechaFacturacion,
                                        Concepto = n.Concepto,
                                        CodRamo = n.CodRamo,
                                        Ramo = n.Ramo,
                                        CodSubramo = n.CodSubramo,
                                        Subramo = n.Subramo,
                                        NombreCliente = n.NombreCliente,
                                        Telefonos = n.Telefonos,
                                        Direccion = n.Direccion,
                                        CodSupervisor = n.CodSupervisor,
                                        Supervisor = n.Supervisor,
                                        CodVendedor = n.CodIntermediario,
                                        Vendedor = n.Vendedor,
                                        TotalFacturado = n.Facturado,
                                        TotalCobrado = n.Cobrado,
                                        BalancePendiente = n.Balance,
                                        Oficina = n.Oficina
                                    }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Diaria Normal Detalle", Exel);
                    }
                    catch (Exception) { }




                }
                else if (rbExportarDependientes.Checked)
                {
                    //AQUI EXPORTAMOS LOS DATOS DE LOS DEPENDIENTE SIEMPRE Y CUANDO LAS POLIZAS SELECCIONADAS NO SEAN DE VEHICULO NI DE FIANZAS
                }
            }
        }

        protected void btnExportarTodo_Click(object sender, EventArgs e)
        {

        }

        protected void cbExportarTodo_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void gbProduccionDiaria_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void gbProduccionDiaria_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}
 
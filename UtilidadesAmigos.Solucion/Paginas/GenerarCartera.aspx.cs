using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarCartera : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR EL LISTADO DE LA CARTERA
        private void MostrarCartera()
        {
            try {
                if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
                {
               
                }
                else
                {
                   // var _CodIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                    var Listado = ObjData.Value.SacarCarteraSupervisor(
                   Convert.ToDecimal(txtCodigoSupervisor.Text),
                   null,
                   txtNombreIntermediario.Text);
                    gbListadoCarteraSupervisor.DataSource = Listado;
                    gbListadoCarteraSupervisor.DataBind();
                    lbNombreSupervisor.Visible = true;
                    foreach (var n in Listado)
                    {
                        lbNombreSupervisor.Text = n.Supervisor;
                    }
                }

            }
            catch (Exception) { }
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES DE LA PRODUCCION
        private void CargarRamosProduccion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamoProduccion, ObjData.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubramosProduccion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubRamoProduccion, ObjData.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamoProduccion.SelectedValue, null), true);
        }
        private void CargarExliirProduccion() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlExcluirMotoresProduccion, ObjData.Value.BuscaListas("EXCLUIR", null, null));
        }
        #endregion
        #region BUSCAR PRODUCCION
        private void BuscarProduccionSupervisor() {
            try {
                int? _Ramo = ddlSeleccionarRamoProduccion.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubRamoProduccion.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamoProduccion.SelectedValue) : new Nullable<int>();
                decimal TotalFacturado = 0;
                if (Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) == 106 && Convert.ToInt32(ddlExcluirMotoresProduccion.SelectedValue) == 2)
                {
                    //BUSCAMOS SIN MOTORES
                    var Buscar = ObjData.Value.SacarProduccionSupervisor(
                        Convert.ToInt32(txtCodigoSupervisor.Text),
                        null,
                        _Ramo,
                        _SubRamo,
                        Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                        Convert.ToDateTime(txtFechaHastaProduccion.Text),
                        1);
                    gvProduccion.DataSource = Buscar;
                    gvProduccion.DataBind();
                    foreach (var n in Buscar) {
                        TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                        lbTotalFacturadoVariableProduccion.Text = TotalFacturado.ToString("N2");
                    }

                }
                else
                {
                    //BUSCAMOS CON MOTORES
                    var Buscar = ObjData.Value.SacarProduccionSupervisor(
                        Convert.ToInt32(txtCodigoSupervisor.Text),
                        null,
                        _Ramo,
                        _SubRamo,
                        Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                        Convert.ToDateTime(txtFechaHastaProduccion.Text),
                        2);
                    gvProduccion.DataSource = Buscar;
                    gvProduccion.DataBind();
                    foreach (var n in Buscar)
                    {
                        TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                        lbTotalFacturadoVariableProduccion.Text = TotalFacturado.ToString("N2");
                    }
                }
            }
            catch (Exception) { }
        }
        private void ExportarProduccionSupervisor() {
            int? _Ramo = ddlSeleccionarRamoProduccion.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSeleccionarSubRamoProduccion.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamoProduccion.SelectedValue) : new Nullable<int>();
            try
            {
                if (Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) == 106 && Convert.ToInt32(ddlExcluirMotoresProduccion.SelectedValue) == 2)
                {
                    var Exportar = (from n in ObjData.Value.SacarProduccionSupervisor(
                        Convert.ToInt32(txtCodigoSupervisor.Text),
                        null,
                        _Ramo,
                        _SubRamo,
                        Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                        Convert.ToDateTime(txtFechaHastaProduccion.Text),
                        1)
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Estatus = n.Estatus,
                                        Prima = n.Prima,
                                        SumaAsegurada = n.SumaAsegurada,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        CodRamo = n.CodRamo,
                                        Ramo = n.Ramo,
                                        CodSubRamo = n.CodSubRamo,
                                        Subramo = n.Subramo,
                                        CodCliente = n.CodCliente,
                                        Cliente = n.Cliente,
                                        CodSupervisor = n.CodSupervisor,
                                        Supervisor = n.Supervisor,
                                        CodIntermediario = n.CodIntermediario,
                                        Intermediario = n.Intermediario,
                                        Fecha = n.Fecha,
                                        Valor = n.Valor,
                                        Numero = n.Numero,
                                        Concepto = n.Concepto,
                                        CreadoPor = n.CreadoPor,
                                        Facturado = n.Facturado,
                                        Cobrado = n.Cobrado,
                                        Balance = n.Balance
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion por supervisor", Exportar);
                }
                else
                {
                    var Exportar = (from n in ObjData.Value.SacarProduccionSupervisor(
                           Convert.ToInt32(txtCodigoSupervisor.Text),
                           null,
                           _Ramo,
                           _SubRamo,
                           Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                           Convert.ToDateTime(txtFechaHastaProduccion.Text),
                           2)
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Estatus = n.Estatus,
                                        Prima = n.Prima,
                                        SumaAsegurada = n.SumaAsegurada,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        CodRamo = n.CodRamo,
                                        Ramo = n.Ramo,
                                        CodSubRamo = n.CodSubRamo,
                                        Subramo = n.Subramo,
                                        CodCliente = n.CodCliente,
                                        Cliente = n.Cliente,
                                        CodSupervisor = n.CodSupervisor,
                                        Supervisor = n.Supervisor,
                                        CodIntermediario = n.CodIntermediario,
                                        Intermediario = n.Intermediario,
                                        Fecha = n.Fecha,
                                        Valor = n.Valor,
                                        Numero = n.Numero,
                                        Concepto = n.Concepto,
                                        CreadoPor = n.CreadoPor,
                                        Facturado = n.Facturado,
                                        Cobrado = n.Cobrado,
                                        Balance = n.Balance
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion por supervisor", Exportar);

                }
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

            var SacarDatos = ObjData.Value.BuscaUsuarios(IdUsuario,
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
                CargarRamosProduccion();
                CargarSubramosProduccion();
                CargarExliirProduccion();
                ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //if (cbComicion.Checked)
            //{
            //    if (cbAgregarOficina.Checked)
            //    {
            //        try {
            //            var BuscarComisiones = ObjData.Value.ComisionesSupervisores(
            //              Convert.ToDateTime(txtFechaDesde.Text),
            //              Convert.ToDateTime(txtFechaHasta.Text),
            //              Convert.ToDecimal(txtCodigoSupervisor.Text),
            //              Convert.ToInt32(ddlSeleccionaroficina.SelectedValue));
            //            foreach (var n in BuscarComisiones)
            //            {
            //                lbNombreSupervisor.Visible = true;
            //                lbNombreSupervisor.Text = n.Supervisor;
            //            }
            //            gbListadoComisiones.DataSource = BuscarComisiones;
            //            gbListadoComisiones.DataBind();

            //            //SACAMOS EL MONTO
            //            var SacarMonto = ObjData.Value.SacarmontoComisiones(
            //              Convert.ToDateTime(txtFechaDesde.Text),
            //              Convert.ToDateTime(txtFechaHasta.Text),
            //              Convert.ToDecimal(txtCodigoSupervisor.Text),
            //              Convert.ToInt32(ddlSeleccionaroficina.SelectedValue));
            //            foreach (var n in SacarMonto)
            //            {
            //                lbNombreSupervisor.Visible = true;
            //                lbMontoComisionPagar.Text = n.ComisionPagar.ToString();
            //            }
            //        }
            //        catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //    }
            //    else
            //    {
            //        try {
            //           // decimal? _Supervisor = Convert.ToDecimal(string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim());
            //            var BuscarComisiones = ObjData.Value.ComisionesSupervisores(
            //                Convert.ToDateTime(txtFechaDesde.Text),
            //                Convert.ToDateTime(txtFechaHasta.Text),
            //                Convert.ToDecimal(txtCodigoSupervisor.Text),
            //                null);
            //            foreach (var n in BuscarComisiones)
            //            {
            //                lbNombreSupervisor.Visible = true;
            //                lbNombreSupervisor.Text = n.Supervisor;
            //            }
            //            gbListadoComisiones.DataSource = BuscarComisiones;
            //            gbListadoComisiones.DataBind();

            //            //SACAR MONTO
            //            var SacarMonto = ObjData.Value.SacarmontoComisiones(
            //              Convert.ToDateTime(txtFechaDesde.Text),
            //              Convert.ToDateTime(txtFechaHasta.Text),
            //              Convert.ToDecimal(txtCodigoSupervisor.Text),
            //              null);
            //            foreach (var n in SacarMonto)
            //            {
            //                lbMontoComisionPagar.Text = n.ComisionPagar.ToString();
            //            }
            //        }
            //        catch (Exception) {
            //            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true);
            //        }
            //    }

            //}
            //else
            //{
            //    MostrarCartera();
            //}
            //ClientScript.RegisterStartupScript(GetType(), "DesbloquearBotones", "DesbloquearBotones();", true);
            //txtCodigoSupervisor.Enabled = false;
        }

        protected void cbComicion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbComicion.Checked)
            {
                lbFechaDesde.Visible = true;
                txtFechaDesde.Visible = true;
                lbFechaHasta.Visible = true;
                txtFechaHasta.Visible = true;
                cbAgregarOficina.Visible = true;
                cbAgregarOficina.Checked = false;
                gbListadoCarteraSupervisor.Visible = false;
                gbListadoComisiones.Visible = true;
                lbComisionPagar.Visible = true;
                lbMontoComisionPagar.Visible = true;
                //lbCodigoIntermediario.Visible = false;
                //txtCodigoIntermediario.Visible = false;
                lbNombreIntermediario.Visible = false;
                txtNombreIntermediario.Visible = false;
                lbMontoComisionPagar.Text = "000000";
                lbEncabezado.Text = "Generar Comisiones";
            }
            else
            {
                lbFechaDesde.Visible = false;
                txtFechaDesde.Visible = false;
                lbFechaHasta.Visible = false;
                txtFechaHasta.Visible = false;
                cbAgregarOficina.Visible = false;
                cbAgregarOficina.Checked = false;
                lbSeleccionaroficina.Visible = false;
                ddlSeleccionaroficina.Visible = false;
                gbListadoCarteraSupervisor.Visible = true;
                gbListadoComisiones.Visible = false;
                lbComisionPagar.Visible = false;
                lbMontoComisionPagar.Visible = false;
                //lbCodigoIntermediario.Visible = true;
                //txtCodigoIntermediario.Visible = true;
                lbNombreIntermediario.Visible = true;
                txtNombreIntermediario.Visible = true;
                lbEncabezado.Text = "Cartera de Supervisores";
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoCarteraSupervisor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbListadoCarteraSupervisor.PageIndex = e.NewPageIndex;
            MostrarCartera();
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoCarteraSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                GridViewRow gb = gbListadoCarteraSupervisor.SelectedRow;

                var SacarCliente = (from n in ObjData.Value.ListadoClientesintermediarios(Convert.ToDecimal(gb.Cells[0].Text))
                                    select new
                                    {
                                        Poliza=n.Poliza,
                                        Ramo=n.Ramo,
                                        Subramo=n.Subramo,
                                        Estatus=n.Estatus,
                                        Oficina=n.Oficina,
                                        InicioVigencia=n.InicioVigencia,
                                        FinVigencia=n.FinVigencia,
                                        Neto=n.Neto,
                                        Supervisor=n.Supervisor,
                                        Vendedor=n.Vendedor,
                                        TelefonosVendedor=n.TelefonosVendedor,
                                        DireccionVendedor=n.DireccionVendedor,
                                        Cliente=n.Cliente,
                                        Direccion=n.Direccion,
                                        TipoIdentificacion=n.TipoIdentificacion,
                                        NumeroIdentificacion=n.NumeroIdentificacion,
                                        TelefonosClientes=n.TelefonosClientes,
                                        TipoVehiculo=n.TipoVehiculo,
                                        Marca=n.Marca,
                                        Modelo=n.Modelo,
                                        Capacidad=n.Capacidad,
                                        Ano=n.Ano,
                                        Color=n.Color,
                                        Chasis=n.Chasis,
                                        Placa=n.Placa,
                                        Uso=n.Uso,
                                        ValorVehiculo=n.ValorVehiculo,
                                        CantidadPuerta=n.CantidadPuerta,
                                        Fianza=n.Fianza,
                                        Observacion=n.Onservacion,
                                        Deducible=n.Deducible,
                                        Coaseguro=n.Coaseguro,
                                        TotalFacturado=n.TotalFacturado,
                                        TotalCobrado=n.TotalCobrado,
                                        Balance=n.Balance,
                                        _1_30=n.__1_30,
                                        _31_60=n.__31_60,
                                        _61_90=n.__61_90,
                                        _91_120=n.__91_120,
                                        _121_O_MAS=n.__121_O_MAS
                                    }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(gb.Cells[1].Text, SacarCliente);
            }
            catch (Exception) { }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //if (cbComicion.Checked)
            //{
            //    if (cbAgregarOficina.Checked)
            //    {
            //        try
            //        {
            //            var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
            //         Convert.ToDateTime(txtFechaDesde.Text),
            //         Convert.ToDateTime(txtFechaHasta.Text),
            //         Convert.ToDecimal(txtCodigoSupervisor.Text),
            //         Convert.ToInt32(ddlSeleccionaroficina.SelectedValue))
            //                            select new
            //                            {
            //                                Supervisor = n.Supervisor,
            //                                Intermediario = n.Intermediario,
            //                                Factura = n.Numero,
            //                                Valor = n.Valor,
            //                                Oficina = n.Oficina,
            //                                Fecha = n.Fecha,
            //                                Concepto = n.Concepto,
            //                                PorcientoComision = n.__Comision,
            //                                ComisionPagar = n.ComisionPagar,
            //                                ValidadoDesde = n.ValidadoDesde,
            //                                ValidadoHasta = n.ValidadoHasta
            //                            }).ToList();
            //            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor", Exportar);
            //        }
            //        catch (Exception) { }
            //    }
            //    else
            //    {
            //        try {
            //            var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
            //         Convert.ToDateTime(txtFechaDesde.Text),
            //         Convert.ToDateTime(txtFechaHasta.Text),
            //         Convert.ToDecimal(txtCodigoSupervisor.Text),
            //         null)
            //                            select new
            //                            {
            //                                Supervisor =n.Supervisor,
            //                                Intermediario=n.Intermediario,
            //                                Factura=n.Numero,
            //                                Valor=n.Valor,
            //                                Oficina=n.Oficina,
            //                                Fecha=n.Fecha,
            //                                Concepto =n.Concepto,
            //                                PorcientoComision=n.__Comision,
            //                                ComisionPagar=n.ComisionPagar,
            //                                ValidadoDesde=n.ValidadoDesde,
            //                                ValidadoHasta=n.ValidadoHasta
            //                            }).ToList();
            //            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor", Exportar);
            //        }
            //        catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //    }
            //}
            //else
            //{
            //    try {

            //        var Exportar = (from n in ObjData.Value.SacarCarteraSupervisor(
            //      Convert.ToDecimal(txtCodigoSupervisor.Text))
            //                        select new
            //                        {
            //                            Supervisor = n.Supervisor,
            //                            Intermediario = n.Intermediario,
            //                            Telefono = n.Telefono,
            //                            Direccion = n.Direccion,
            //                            Estatus = n.Estatus,
            //                            Oficina = n.OficinaSupervisor
            //                        }).ToList();
            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera de Supervisor " + lbNombreSupervisor.Text, Exportar);
            //    }
            //    catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //}

            //ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoCarteraSupervisor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                e.Row.Cells[0].Visible = false;
            }
            catch (Exception) { }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void cbAgregarOficina_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarOficina.Checked)
            {
                lbSeleccionaroficina.Visible = true;
                ddlSeleccionaroficina.Visible = true;
                //CARGAMOS LAS OFICINAS
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjData.Value.BuscaListas("OFICINAS", null, null));
            }
            else
            {
                lbSeleccionaroficina.Visible = false;
                ddlSeleccionaroficina.Visible = false;
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoComisiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void btnExportarListadoCompleto_Click(object sender, EventArgs e)
        {
            //if (cbAgregarOficina.Checked)
            //{
            //    try
            //    {
            //        var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
            //     Convert.ToDateTime(txtFechaDesde.Text),
            //     Convert.ToDateTime(txtFechaHasta.Text),
            //     null,
            //     Convert.ToInt32(ddlSeleccionaroficina.SelectedValue))
            //                        select new
            //                        {
            //                            Supervisor = n.Supervisor,
            //                            Intermediario = n.Intermediario,
            //                            Factura = n.Numero,
            //                            Valor = n.Valor,
            //                            Oficina = n.Oficina,
            //                            Fecha = n.Fecha,
            //                            Concepto = n.Concepto,
            //                            PorcientoComision = n.__Comision,
            //                            ComisionPagar = n.ComisionPagar,
            //                            ValidadoDesde = n.ValidadoDesde,
            //                            ValidadoHasta = n.ValidadoHasta
            //                        }).ToList();
            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor Completo", Exportar);
            //    }
            //    catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //}
            //else
            //{
            //    try
            //    {
            //        var Exportar = (from n in ObjData.Value.ComisionesSupervisores(
            //     Convert.ToDateTime(txtFechaDesde.Text),
            //     Convert.ToDateTime(txtFechaHasta.Text))
            //                        select new
            //                        {
            //                            Supervisor = n.Supervisor,
            //                            Intermediario = n.Intermediario,
            //                            Factura = n.Numero,
            //                            Valor = n.Valor,
            //                            Oficina = n.Oficina,
            //                            Fecha = n.Fecha,
            //                            Concepto = n.Concepto,
            //                            PorcientoComision = n.__Comision,
            //                            ComisionPagar = n.ComisionPagar,
            //                            ValidadoDesde = n.ValidadoDesde,
            //                            ValidadoHasta = n.ValidadoHasta
            //                        }).ToList();
            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Supervisor Completo", Exportar);
            //    }
            //    catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMostrarConsulta();", true); }
            //}
            //ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gbListadoCarteraSupervisor_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try { e.Row.Cells[0].Visible = false; }
            catch (Exception) { }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void btnRestablecerPantalla_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
            txtCodigoSupervisor.Enabled = true;
            txtCodigoSupervisor.Text = string.Empty;

        }

        protected void btnConsultarProduccion_Click(object sender, EventArgs e)
        {
            BuscarProduccionSupervisor();
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void gvProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProduccion.PageIndex = e.NewPageIndex;
            BuscarProduccionSupervisor();
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void ddlSeleccionarRamoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubramosProduccion();
            if (Convert.ToInt32(ddlSeleccionarRamoProduccion.SelectedValue) == 106)
            {
                lbExcluirMotoresProduccion.Visible = true;
                ddlExcluirMotoresProduccion.Visible = true;
            }
            else {
                lbExcluirMotoresProduccion.Visible = false;
                ddlExcluirMotoresProduccion.Visible = false;
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }

        protected void btnExportarProduccion_Click(object sender, EventArgs e)
        {
            ExportarProduccionSupervisor();
            ClientScript.RegisterStartupScript(GetType(), "BloquearBotones", "BloquearBotones();", true);
        }
    }
}
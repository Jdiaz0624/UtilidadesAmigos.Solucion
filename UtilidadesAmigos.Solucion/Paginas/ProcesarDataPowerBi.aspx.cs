using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProcesarDataPowerBi : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        UtilidadesAmigos.Logica.Comunes.VariablesPowerBi VariablespowerBi = new Logica.Comunes.VariablesPowerBi();
        #region MANTENIMIENTO DE PRODUCCION 
        private void MAMProduccion(string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.ECargarDatosTablaProduccionPowerBi Produccion = new Logica.Entidades.ECargarDatosTablaProduccionPowerBi();

            Produccion.Supervisor = VariablespowerBi.Supervisor;
            Produccion.Intermediario = VariablespowerBi.Intermediario;
            Produccion.Mes = VariablespowerBi.Mes;
            Produccion.Año = VariablespowerBi.Año;
            Produccion.Facturado = VariablespowerBi.Facturado;
            Produccion.FacturadoNeto = VariablespowerBi.FacturadoNeto;
            Produccion.Cobrado = VariablespowerBi.Cobrado;
            Produccion.CobradoNeto = VariablespowerBi.CobradoNeto;
            Produccion.Poliza = VariablespowerBi.Poliza;
            Produccion.Ramo = VariablespowerBi.Ramo;
            Produccion.Prima = VariablespowerBi.Prima;
            Produccion.ValorAsegurado = VariablespowerBi.ValorAsegurado;
            Produccion.ValorFianza = VariablespowerBi.ValorFianza;
            Produccion.ValorVehiculo = VariablespowerBi.ValorVehiculo;
            Produccion.Marca = VariablespowerBi.Marca;
            Produccion.Modelo = VariablespowerBi.Modelo;
            Produccion.AñoVehiculo = VariablespowerBi.AñoVehiculo;

            var MAn = ObjData.Value.CargarDatosTablaProduccionPowerBi(Produccion, Accion);

            
        }
        #endregion
        #region MANTENIMIENTO DE PRODUCCION
        private void MANReclamacion(string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.ECargarDatosTablaReclamacionpowerBi Reclamacion = new Logica.Entidades.ECargarDatosTablaReclamacionpowerBi();

            Reclamacion.Supervisor = VariablespowerBi.SupervisorReclamacion;
            Reclamacion.Intermediario = VariablespowerBi.intermediarioReclamacion;
            Reclamacion.Mes = VariablespowerBi.MesReclamacion;
            Reclamacion.ano = VariablespowerBi.AnoReclamacion;
            Reclamacion.Reclamacion = VariablespowerBi.ReclamacionReclamacion;
            Reclamacion.MontoReclamado = VariablespowerBi.MontoReclamadoReclamacion;
            Reclamacion.MontoAjustado = VariablespowerBi.MontoAjustadoReclamacion;
            Reclamacion.Estatus = VariablespowerBi.EstatusReclamacion;
            Reclamacion.Marca = VariablespowerBi.MarcaReclamacion;
            Reclamacion.Modelo = VariablespowerBi.ModeloReclamacion;
            Reclamacion.Anovehiculo = VariablespowerBi.AnovehiculoReclamacion;

            var MAn = ObjData.Value.CargarDatosTablaReclamacionPowerBi(Reclamacion, Accion);
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
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                lbListo.Text = "LISTO";
                lbListo.ForeColor = System.Drawing.Color.ForestGreen;
                rbSinCargarTabla.Checked = true;
            }
        }

        protected void ddlSeleccionarData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            try {
                //declaramos una variable y le pasamos el valor del drop
                int TipoProceso = 0;
                TipoProceso = Convert.ToInt32(ddlSeleccionarData.SelectedValue);

                //SI EL VALOR PASADO ES UN 1 ENTONCES SE VA A EJECUTAR LA PRODUCCION
                if (TipoProceso == 1)
                {
                    if (rbSinCargarTabla.Checked == true)
                    {
                        var ExportarSincargar = (from n in ObjData.Value.CargarTablaProduccionPowerBi(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text))
                                                 select new
                                                 {
                                                     Supervisor = n.Supervisor,
                                                     Intermediario = n.Intermediario,
                                                     Mes = n.Mes.ToString(),
                                                     Año = n.Ano,
                                                     Facturado = n.Facturado,
                                                     FacturadoNeto = n.FacturadoNeto,
                                                     Cobrado = n.Cobrado,
                                                     CobradoNeto = n.CobradoNeto,
                                                     Poliza = n.Poliza,
                                                     Ramo = n.Ramo,
                                                     Prima = n.Prima,
                                                     ValorAsegurado = n.ValorAsegurado,
                                                     FianzaJudicial = n.Fianza,
                                                     ValorVehiculo = n.ValorVehiculo,
                                                     MarcaVehiculo = n.Marca,
                                                     ModeloVehiculo = n.Modelo,
                                                     AñoVehiculo = n.Año
                                                 }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("PRODUCCION", ExportarSincargar);
                    }
                    else if (rbCargarTabla.Checked == true)
                    {
                        lbListo.Text = "PROCESANDO";
                        lbListo.ForeColor = System.Drawing.Color.Red;
                        MAMProduccion("DELETE");
                        //CARGAMOS LA DATA
                        var CargarDatos = ObjData.Value.CargarTablaProduccionPowerBi(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text));
                        foreach (var n in CargarDatos)
                        {
                            VariablespowerBi.Supervisor = n.Supervisor;
                            VariablespowerBi.Intermediario = n.Intermediario;
                            VariablespowerBi.Mes = n.Mes;
                            VariablespowerBi.Año = n.Ano;
                            VariablespowerBi.Facturado = Convert.ToDecimal(n.Facturado);
                            VariablespowerBi.FacturadoNeto = Convert.ToDecimal(n.FacturadoNeto);
                            VariablespowerBi.Cobrado = Convert.ToDecimal(n.Cobrado);
                            VariablespowerBi.CobradoNeto = Convert.ToDecimal(n.CobradoNeto);
                            VariablespowerBi.Poliza = n.Poliza;
                            VariablespowerBi.Ramo = n.Ramo;
                            VariablespowerBi.Prima = Convert.ToDecimal(n.Prima);
                            VariablespowerBi.ValorAsegurado = Convert.ToDecimal(n.ValorAsegurado);
                            VariablespowerBi.ValorFianza = n.Fianza;
                            VariablespowerBi.ValorVehiculo = Convert.ToDecimal(n.ValorVehiculo);
                            VariablespowerBi.Marca = n.Marca;
                            VariablespowerBi.Modelo = n.Modelo;
                            VariablespowerBi.AñoVehiculo = n.Año;
                            MAMProduccion("INSERT");
                        }
                        var ExportarExel = (from n in ObjData.Value.CargarDataProduccionpowerBi()
                                            select new
                                            {
                                                Supervisor = n.Supervisor,
                                                Intermediario = n.Intermediario,
                                                Mes = n.Mes.ToString(),
                                                Facturado = n.Facturado,
                                                FacturadoNeto = n.FacturadoNeto,
                                                Cobrado = n.Cobrado,
                                                CobradoNeto = n.CobradoNeto,
                                                Poliza = n.Poliza,
                                                Ramo = n.Ramo,
                                                Prima = n.Prima,
                                                ValorAsegurado = n.ValorAsegurado,
                                                FianzaJudicial = n.ValorFianza,
                                                ValorVehiculo = n.ValorVehiculo,
                                                MarcaVehiculo = n.Marca,
                                                ModeloVehiculo = n.Modelo,
                                                AñoVehiculo = n.AñoVehiculo
                                            }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("PRODUCCION", ExportarExel);
                        lbListo.Text = "LISTO";
                        lbListo.ForeColor = System.Drawing.Color.ForestGreen;
                    }
                }
                else if (TipoProceso == 2)
                {
                    //VERIFICAMOS SI EL PROCESO QUE SE VA A REALIZAR ES CARGANDO LA TABLA O NO
                    if (rbSinCargarTabla.Checked == true)
                    {
                        //EXECUTAMOS LA CONSULTA PASANDOLE EL RANGO DE FECHA Y LO MANDAMOS A EXEL
                        var ExportarSinCargartabla = (from n in ObjData.Value.CargarTablaReclamacionpowerBi(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text))
                                                      select new
                                                      {
                                                          Supervisor = n.Supervisor,
                                                          Intermediario = n.intermediario,
                                                          Mes = n.Mes,
                                                          Año = n.Ano,
                                                          Poliza =n.Poliza,
                                                          Reclamacion =n.Reclamacion,
                                                          MontoReclamado =n.MontoReclamado,
                                                          Montoajustado =n.MontoAjustado,
                                                          Estatus =n.Estatus,
                                                          MarcaVehiculo =n.Marca,
                                                          ModeloVehiculo =n.Modelo,
                                                          AñoVehiculo =n.Año
                                                      }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("RECLAMACION", ExportarSinCargartabla);
                    }
                    else if (rbCargarTabla.Checked == true)
                    {
                        //ELIMINAMOS TODOS LOS DATOS DE LA TABLA
                        MANReclamacion("DELETE");
                        //EJECUTAMOS EL PROCEDURE PASANDOLE EL RANGO FECHA CORRESPONDIENTE
                        var CargarData = ObjData.Value.CargarTablaReclamacionpowerBi(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text));
                        //RECORREMOS LA DATA 
                        foreach (var n in CargarData)
                        {
                            //MANDAMOS LOS DATOS A LAS VARIABLES DE LA CLASE PARA PROCEDER A INSERTAR
                            VariablespowerBi.SupervisorReclamacion = n.Supervisor;
                            VariablespowerBi.intermediarioReclamacion = n.intermediario;
                            VariablespowerBi.MesReclamacion = n.Mes;
                            VariablespowerBi.AnoReclamacion = n.Ano;
                            VariablespowerBi.PolizaReclamacion = n.Poliza;
                            VariablespowerBi.ReclamacionReclamacion = Convert.ToDecimal(n.Reclamacion);
                            VariablespowerBi.MontoReclamadoReclamacion = Convert.ToDecimal(n.MontoReclamado);
                            VariablespowerBi.MontoAjustadoReclamacion = Convert.ToDecimal(n.MontoAjustado);
                            VariablespowerBi.EstatusReclamacion = n.Estatus;
                            VariablespowerBi.MarcaReclamacion = n.Marca;
                            VariablespowerBi.ModeloReclamacion = n.Modelo;
                            VariablespowerBi.AnovehiculoReclamacion = n.Año;

                            //PROCEDEMOS A INSERTAR LOS REGISTROS
                            MANReclamacion("INSERT");
                        }
                        //PARA TERMINAR, PROCEDEMOS A ESCRIBIR EL ARCHIVO DE EXEL CON LOS REGISTROS INGRESADOS EN LA TABLA
                        var CargarExelGuardandoEnTabla = (from n in ObjData.Value.CargarDataReclamacionPowerBi()
                                                          select new
                                                          {
                                                              Supervisor =n.Supervisor,
                                                              Intermediario = n.Intermediario,
                                                              Mes =n.Mes,
                                                              Poliza = n.Poliza,
                                                              Reclamacion = n.Reclamacion,
                                                              MontoReclamado =n.MontoReclamado,
                                                              MontoAjustado =n.MontoAjustado,
                                                              Estatus =n.Estatus,
                                                              Marca =n.Marca,
                                                              Modelo =n.Modelo,
                                                              AñoVehiculo =n.Anovehiculo
                                                          }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("RECLAMACION", CargarExelGuardandoEnTabla);
                    }
                }

                
            }
            catch (Exception) { }
        }
    }
}
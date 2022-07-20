using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.MasterPage
{
    public partial class PatallaPrincila : System.Web.UI.MasterPage
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

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

            var SacarDatos = Objdata.Value.BuscaUsuarios(IdUsuario,
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
              




                int IdPerfil = Convert.ToInt32(lbIdPerfil.Text);

               


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
            if (!IsPostBack) {
                PermisoPerfil();


            }
           
        }

 


        protected void llbProcesarDataGruas_Click(object sender, EventArgs e)
        {
            
        }
        protected void llbUsuarios_Click(object sender, EventArgs e)
        {
           
        }


        protected void llbPermisoUsuarios_Click(object sender, EventArgs e)
        {
           
        }

        protected void llbProcesarDataGruas_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ProcesarDataGruas.aspx");
        }

        protected void llbProcesarDataPowerBI_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ProcesarDataPowerBi.aspx");
        }

   

        protected void llbAsignacionTarjetas_Click(object sender, EventArgs e)
        {
            
        }



        protected void llbCotizadorAmigos_Click(object sender, EventArgs e)
        {
           
        }

        protected void llbGenerarDataCoberturas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/SacarDataCoberturas.aspx");
        }

 

        protected void linkCerrarCesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Paginas/MenuPrincipal.aspx");
        }

        protected void linkProduccionPorUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ProduccionPorUsuarios.aspx");
        }

        protected void LinkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MenuPrincipal.aspx");
        }

        protected void linkTicket_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/SistemaTicket.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkProduccionDiaria_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            // Response.Redirect("ProduccionDiaria.aspx");
        }

        protected void linkGenerarCartera_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/GenerarCartera.aspx");
        }

        protected void linkValidarCoberturas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Consulta/ValidarCoberturas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkGenerarReporteUAF_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Consulta/ReporteOperacionesSospechosas.aspx");
        }

        protected void linkGenerarReporteCoberturas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkOficinas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Oficinas.aspx");
        }

        protected void linkDeprtamentos_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
           Response.Redirect("~/Paginas/Departamentos.aspx");
        }

        protected void linkEmpleados_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            Response.Redirect("~/Paginas/Empleados.aspx");
        }

        protected void linkInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Inventario.aspx");
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkCotizadorFuturoSeguros_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            //Response.Redirect("CotizadorAmigos.aspx");
        }

        protected void linkFuturoARS_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);

        }

        protected void linkTarjetasAccesos_Click(object sender, EventArgs e)
        {
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            Response.Redirect("~/Paginas/Seguridad/AsignacionTarjetas.aspx");
        }

        protected void linkMovimientoUsuarios_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkPermisoUsuarios_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            //Response.Redirect("PermisoUsuarios.aspx");
        }

        protected void linkClaveSeguridad_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MantenimientoClaveSeguridad.aspx");
        }

        protected void linkPerfilesUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MantenimeintoPerfiles.aspx");
        }

        protected void linkUsuarios_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/MantenimientoUsuarios.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            
            
        }

        protected void linkCarteraIntermediarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/GenerarCarteraIntermedirio.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkComisionesCobrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas//Consulta/ListadoRenovacion.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkProcesarDataGruas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkEmisionPolizas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkEnvioCorreo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkCorreoElectronicos_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkDependientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Mantenimientos/MantenimientoDependientes.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkClientes_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkOpcionMenu_Click(object sender, EventArgs e)
        {
            //MOSTRAR LOS MODULOS DEL SISTEMA
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/Modulos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkOpcion_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/Pantallas.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkBotones_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/Opciones.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkEliminarBalance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/EliminarBalancePoliza.aspx");
        }

        protected void LinkReporteFianzas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Consulta/GenerarReporteFianzas.aspx");
        }

        protected void LinkReporteReclamos_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE RECLAMOS
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/ReporteReclamos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkProcesoCasaConductor_Click(object sender, EventArgs e)
        {

        }

        protected void LinkProduccionDiariaContabilidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Reportes/ProduccionDiariaContabilidad.aspx");
        }

  

        protected void LinkCorregirValorDeclarativa_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/DatosPoliza.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCorregirLimites_Click(object sender, EventArgs e)
        {

        }

        protected void LinkSolicitudEmision_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/SolicitudEmisionPoliza.aspx");
        }

        protected void LinkBakupBD_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/GenerarBackupBaseDatos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarFacturasPDF_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/GenerarFacturasPDF.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkProcesarDataAsegurado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/ProcesarDataAsegurado.aspx");
            }
            else
            {

                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LiniComisionesIntermediarios_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE INTERMEDARIOS
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ComisionesIntermediarios.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkComisionesSupervisores_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE LOS SUPERVISORES
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ComisionesSupervisores.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarMarbetesBehiculo_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE LOS SUPERVISORES
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/GenerarMarbetes.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkClientes_Click1(object sender, EventArgs e)
        {

        }

        protected void LinkIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Mantenimientos/IntermediariosSupervisores.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkMantenimientoPorcientoComisionPorDefecto_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/MantenimientoPorcientoComisionPorDefecto.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarSOlicitudChequeComisiones_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Procesos/GenerarSolicitudChequeComisionesIntermediarios.aspx");

            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkAntiguedadSaldo_Click(object sender, EventArgs e)
        {

            if (Session["Idusuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/AntiguedadSaldo.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkProduccionIntermediarioSupervisor_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteProduccion.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsumoWS_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("ConsumoWS.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReporteCobrado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Reportes/GenerarReporteCobros.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsultarPersonas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/SuperIntendencia/ConsultaPersonas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkImpresionCheques_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) { 
            
                    Response.Redirect("~/Paginas/Reportes/ImpresionCheques.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsultarInformacionAsegurado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Consulta/ConsultarDataAsegurado.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkVolantePago_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Procesos/VolantesDePagos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCorreosEmisoresProcesos_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/ConfiguracionCorreosEmisorProcesos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCredencialesBD_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/CredencialesBD.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkSobreComision_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteSobreComision.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkControlVisitas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                //ControlVisitas.aspx
                Response.Redirect("~/Paginas/ControlVisitas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReporteAlfredoIntermediarios_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Reportes/ReporteIntermediariosAlfredo.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGestionCObros_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Consulta/GestionCobros.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkUtilidadesCobros_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Procesos/UtilidadesCobros.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkAgregarDPAReclamos_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/AgregarItemsReclamos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkMantenimientoMonedas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Mantenimientos/MantenimientoMonedas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCartera_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Consulta/SacarCarteraIntermediariosSupervisor.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReclamacionesPagadas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReclamacionesPagadas.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCotizador_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {

                Response.Redirect("~/Paginas/ProcesoPoliza/Cotizador.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkEstadisticaRenovacion_Click(object sender, EventArgs e)
        {
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Opción no esta disponible por el momento por que se esta trabajando en una mejora para la misma.');", true);
            if (Session["IdUsuario"] != null)
            {

                Response.Redirect("~/Paginas/Consulta/EstadisticaRenovacion.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReportePrimaDeposito_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {

                Response.Redirect("~/Paginas/Reportes/ReportePrimaDeposito.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkSolicitud_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Suministro/SolicitudSuministro.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkAdministracionSuministro_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Suministro/AdministracionSuministro.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }

        }

        protected void LinkReporteReclamaciones_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteReclamaciones.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReciboDigital_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/ReciboDigital.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCLientesSinPolizaPolizaSinMarbete_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Consulta/RegistrosImcompletos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReporteImpresionMarbetes_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteImpresionMarbetes.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarEndoso_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/Endosos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkProcesoEmision_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/ProcesoEmisionPoliza.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}
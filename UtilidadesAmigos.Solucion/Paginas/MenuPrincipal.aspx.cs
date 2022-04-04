﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Synthesis;
using System.Threading;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas

{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objtata = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region MANTENIMIENTO DE SUGERENCIAS
        private void MAnSugerencias(string Accion, decimal IdSugerencia)
        {
            if (string.IsNullOrEmpty(txtSugerencia.Text.Trim()))
            {

            }
            else
            {
                if (Session["IdUsuario"] != null)
                {
                    UtilidadesAmigos.Logica.Entidades.ESugerencias Mantenimiento = new Logica.Entidades.ESugerencias();

                    Mantenimiento.IdSugerencia = IdSugerencia;
                    Mantenimiento.IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimiento.Sugerencia = txtSugerencia.Text;
                    Mantenimiento.Respuesta = txtRespuesta.Text;

                    var MAn = Objtata.Value.MantenimientoSugeencias(Mantenimiento, Accion);
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }
        #endregion
        #region BUSCAR REGISTROS
        private void BuscarRegistros()
        {
            if (Session["IdUsuario"] != null)
            {
               
                var BuscarRegistros = Objtata.Value.BuscaSugerencias(
                    new Nullable<decimal>(),
                    Convert.ToDecimal(Session["IdUsuario"]));
                gbSugerencia.DataSource = BuscarRegistros;
                gbSugerencia.DataBind();
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        #endregion

        enum UsuariosPermiso {
            JUAN_MARCELINO_MEDINA_DIAZ =1,
            ALFREDO_PIMENTEL=10,
            EDUARD_GARCIA=12,
            ING_MIGUEL_BERROA=22,
            NOELIA_GONZALEZ=28
        }
        private void SacarDatosUsuario(decimal IdUsuario)
        {
            Label lbControlUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
            lbControlUsuarioConectado.Text = "";

            Label lbControlOficinaUsuario = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
            lbControlOficinaUsuario.Text = "";

            var SacarDatos = Objtata.Value.BuscaUsuarios(IdUsuario,
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

            //MOSTRAMOS LAS SUGERENCIAS 
            int IdPerfil = Convert.ToInt32(lbIdPerfil.Text);
            if (IdPerfil != 1)
            {
                //SACAMOS LOS DATOS DE LOS PERFILES SELECCIONADOS
                var SacarSugerencias = Objtata.Value.BuscaSugerencias(
                    new Nullable<decimal>(),
                    Convert.ToDecimal(Session["IdUsuario"]));
                gbSugerencia.DataSource = SacarSugerencias;
                gbSugerencia.DataBind();
                txtRespuesta.Enabled = false;
                lbAccion.Text = "INSERT";
            }
            else
            {
                var SacarSugerencias = Objtata.Value.BuscaSugerencias();
                gbSugerencia.DataSource = SacarSugerencias;
                gbSugerencia.DataBind();
                txtRespuesta.Enabled = true;
                lbAccion.Text = "INSERT";
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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


                    switch (IdPerfil) {

                        //ADMINISTRADOR
                        case 1:
                            //SUMINISTRO
                            LinkAdministracionSuministro.Visible = true;
                            LinkSolicitud.Visible = true;

                            //CONSULTA
                            LinkCartera.Visible = true;
                            LinkConsultarPersonas.Visible = true;
                            linkProduccionPorUsuarios.Visible = true;
                            linkProduccionDiaria.Visible = true;
                            linkGenerarCartera.Visible = true;
                            linkCarteraIntermediarios.Visible = true;
                            linkComisionesCobrador.Visible = true;
                            LinkEstadisticaRenovacion.Visible = true;
                            linkValidarCoberturas.Visible = true;
                            linkGenerarReporteUAF.Visible = true;
                            LinkReporteReclamos.Visible = true;
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
                            LinkCorregirLimites.Visible = true;
                            LinkEnvioCorreo.Visible = true;
                            LinkEliminarBalance.Visible = true;
                            LinkGenerarFacturasPDF.Visible = true;
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
                            LinkCorreoElectronicos.Visible = true;
                            LinkMantenimientoPorcientoComisionPorDefecto.Visible = true;
                            LinkMantenimientoMonedas.Visible = true;

                            //COTIZADOR
                            LinkCotizador.Visible = true;

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
                            //PERFIL DE PROCESO
                            //SUMINISTRO
                            LinkAdministracionSuministro.Visible = false;
                            LinkSolicitud.Visible = false;

                            //CONSULTA
                            LinkCartera.Visible = true;
                            LinkConsultarPersonas.Visible = true;
                            linkProduccionPorUsuarios.Visible = true;
                            linkProduccionDiaria.Visible = true;
                            linkGenerarCartera.Visible = true;
                            linkCarteraIntermediarios.Visible = true;
                            linkComisionesCobrador.Visible = true;
                            LinkEstadisticaRenovacion.Visible = true;
                            linkValidarCoberturas.Visible = true;
                            linkGenerarReporteUAF.Visible = true;
                            LinkReporteReclamos.Visible = true;
                            LinkControlVisitas.Visible = true;
                            LinkConsultarInformacionAsegurado.Visible = true;

                            //REPORTES
                            LinkProduccionIntermediarioSupervisor.Visible = false;
                            LinkReporteCobrado.Visible = false;
                            LinkReporteAlfredoIntermediarios.Visible = false;
                            LiniComisionesIntermediarios.Visible = false;
                            LinkComisionesSupervisores.Visible = false;
                            LinkSobreComision.Visible = false;
                            LinkProduccionDiariaContabilidad.Visible = false;
                            LinkReportePrimaDeposito.Visible = false;
                            LinkReporteReclamaciones.Visible = false;
                            LinkReclamacionesPagadas.Visible = false;

                            //PROCESOS
                            LinkBakupBD.Visible = false;
                            LinkGenerarSOlicitudChequeComisiones.Visible = false;
                            LinkProcesarDataAsegurado.Visible = false;
                            LinkCorregirValorDeclarativa.Visible = false;
                            LinkCorregirLimites.Visible = false;
                            LinkEnvioCorreo.Visible = false;
                            LinkEliminarBalance.Visible = false;
                            LinkGenerarFacturasPDF.Visible = false;
                            LinkVolantePago.Visible = false;
                            linkUtilidadesCobros.Visible = false;
                            LinkAgregarDPAReclamos.Visible = false;

                            //MANTENIMIENTOS
                            LinkClientes.Visible = false;
                            LinkIntermediariosSupervisores.Visible = false;
                            linkOficinas.Visible = false;
                            linkDeprtamentos.Visible = false;
                            linkEmpleados.Visible = false;
                            linkInventario.Visible = false;
                            LinkDependientes.Visible = false;
                            LinkCorreoElectronicos.Visible = false;
                            LinkMantenimientoPorcientoComisionPorDefecto.Visible = false;
                            LinkMantenimientoMonedas.Visible = false;

                            //COTIZADOR
                            LinkCotizador.Visible = false;

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
                            //PERFIL DE CONSULTA
                            //SUMINISTRO
                            //LinkAdministracionSuministro.Visible = false;
                            //LinkSolicitud.Visible = false;

                            //CONSULTA
                            LinkCartera.Visible = false;
                            LinkConsultarPersonas.Visible = false;
                            linkProduccionPorUsuarios.Visible = false;
                            linkProduccionDiaria.Visible = false;
                            linkGenerarCartera.Visible = false;
                            linkCarteraIntermediarios.Visible = false;
                            linkComisionesCobrador.Visible = false;
                            LinkEstadisticaRenovacion.Visible = false;
                            linkValidarCoberturas.Visible = false;
                            linkGenerarReporteUAF.Visible = false;
                            LinkReporteReclamos.Visible = false;
                            LinkControlVisitas.Visible = false;
                            LinkConsultarInformacionAsegurado.Visible = false;

                            //REPORTES
                            LinkProduccionIntermediarioSupervisor.Visible = false;
                            LinkReporteCobrado.Visible = false;
                            LinkReporteAlfredoIntermediarios.Visible = false;
                            LiniComisionesIntermediarios.Visible = false;
                            LinkComisionesSupervisores.Visible = false;
                            LinkSobreComision.Visible = false;
                            LinkProduccionDiariaContabilidad.Visible = false;
                            LinkReportePrimaDeposito.Visible = false;
                            LinkReporteReclamaciones.Visible = false;
                            LinkReclamacionesPagadas.Visible = false;

                            //PROCESOS
                            LinkBakupBD.Visible = false;
                            LinkGenerarSOlicitudChequeComisiones.Visible = false;
                            LinkProcesarDataAsegurado.Visible = false;
                            LinkCorregirValorDeclarativa.Visible = false;
                            LinkCorregirLimites.Visible = false;
                            LinkEnvioCorreo.Visible = false;
                            LinkEliminarBalance.Visible = false;
                            LinkGenerarFacturasPDF.Visible = false;
                            LinkVolantePago.Visible = false;
                            linkUtilidadesCobros.Visible = false;
                            LinkAgregarDPAReclamos.Visible = false;

                            //MANTENIMIENTOS
                            LinkClientes.Visible = false;
                            LinkIntermediariosSupervisores.Visible = false;
                            linkOficinas.Visible = false;
                            linkDeprtamentos.Visible = false;
                            linkEmpleados.Visible = false;
                            linkInventario.Visible = false;
                            LinkDependientes.Visible = false;
                            LinkCorreoElectronicos.Visible = false;
                            LinkMantenimientoPorcientoComisionPorDefecto.Visible = false;
                            LinkMantenimientoMonedas.Visible = false;

                            //COTIZADOR
                            LinkCotizador.Visible = false;

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
          
        }

        protected void gbSugerencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbSugerencia.PageIndex = e.NewPageIndex;
            BuscarRegistros();
        }

        protected void gbSugerencia_SelectedIndexChanged(object sender, EventArgs e)
        {
        

            lbAccion.Text = "UPDATE";
            GridViewRow gb = gbSugerencia.SelectedRow;
            var SacarDatos = Objtata.Value.BuscaSugerencias(
                Convert.ToDecimal(gb.Cells[0].Text));
            foreach (var n in SacarDatos)
            {
                lbIdMantenimiento.Text = n.IdSugerencia.ToString();
                txtSugerencia.Text = n.Sugerencia;
                txtRespuesta.Text = n.Respuesta;
            }
            gbSugerencia.DataSource = SacarDatos;
            gbSugerencia.DataBind();
            int IdPerfil = Convert.ToInt32(lbIdPerfil.Text);
            if (IdPerfil != 1)
            {
                btnEliminar.Visible = false;
            }
            else
            {
                btnEliminar.Visible = true;
            }
        }

        protected void btnAccion_Click(object sender, EventArgs e)
        {
     


            if (lbAccion.Text == "UPDATE")
            {
                lbAccion.Text = "UPDATE";
                MAnSugerencias(lbAccion.Text, Convert.ToDecimal(lbIdMantenimiento.Text));
                btnEliminar.Visible = false;
                txtRespuesta.Text = string.Empty;
                txtSugerencia.Text = string.Empty;
                
                int idperfil = Convert.ToInt32(lbIdPerfil.Text);
                if (idperfil != 1)
                {
                    BuscarRegistros();
                }
                else
                {
                    var SacarSugerencias = Objtata.Value.BuscaSugerencias();
                    gbSugerencia.DataSource = SacarSugerencias;
                    gbSugerencia.DataBind();
                }

            }
            else
            {


                lbAccion.Text = "INSERT";
                lbIdMantenimiento.Text = "0";
                MAnSugerencias(lbAccion.Text, Convert.ToDecimal(lbIdMantenimiento.Text));
                btnEliminar.Visible = false;
                txtRespuesta.Text = string.Empty;
                txtSugerencia.Text = string.Empty;
                int idperfil = Convert.ToInt32(lbIdPerfil.Text);
                if (idperfil != 1)
                {
                    BuscarRegistros();
                }
                else
                {
                    var SacarSugerencias = Objtata.Value.BuscaSugerencias();
                    gbSugerencia.DataSource = SacarSugerencias;
                    gbSugerencia.DataBind();
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {


            lbAccion.Text = "INSERT";
            txtRespuesta.Text = string.Empty;
            txtSugerencia.Text = string.Empty;
            
            BuscarRegistros();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
         

        

         

            lbAccion.Text = "DELETE";
            MAnSugerencias(lbAccion.Text, Convert.ToDecimal(lbIdMantenimiento.Text));
            btnEliminar.Visible = false;
            int idperfil = Convert.ToInt32(lbIdPerfil.Text);
            if (idperfil != 1)
            {
                BuscarRegistros();
            }
            else
            {
                var SacarSugerencias = Objtata.Value.BuscaSugerencias();
                gbSugerencia.DataSource = SacarSugerencias;
                gbSugerencia.DataBind();
            }
        }
    }
}
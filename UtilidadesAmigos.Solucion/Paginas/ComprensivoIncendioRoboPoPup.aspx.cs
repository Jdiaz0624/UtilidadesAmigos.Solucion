using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ComprensivoIncendioRoboPoPup : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCotizador.LogicaCotizador> ObjDataCotizador = new Lazy<Logica.Logica.LogicaCotizador.LogicaCotizador>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAMOS LAS LISTAS DESPLEGABLES PARA LAS CONSULTAS
        //LISTAS DESPLEGABLES PARA CONSULTAS
        private void CargarListasDesplegablesPadreConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorConsulta, ObjDataComun.Value.BuscaListas("TIPOCOTIZADOR", null, null), true);
        }
        private void CargarListadoTipoCotizadorConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoConsulta, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorConsulta.SelectedValue, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculoCOnsulta, ObjDataComun.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizadorConsulta.SelectedValue, ddlValorVehiculoConsulta.SelectedValue), true);
        }
        private void CargarListadoAnoVehiculoConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculoCOnsulta, ObjDataComun.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizadorConsulta.SelectedValue, ddlValorVehiculoConsulta.SelectedValue), true);
        }

        //LISTAS DESPLEGABLES PARA MANTENIMIENTO
        private void CargarListaDesplegablePadreMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizadorMantenimiento, ObjDataComun.Value.BuscaListas("TIPOCOTIZADOR", null, null));
        }
        private void CargarListadoTipoCotizadorMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue, ddlValorVehiculoMantenimiento.SelectedValue));
        }
        private void CargarListadoValorVehiculoMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculoMantenimiento, ObjDataComun.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizadorMantenimiento.SelectedValue, ddlValorVehiculoMantenimiento.SelectedValue));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LA CONSULTA
        private void MostrarListadoConsulta()
        {
            //Declaramos las variables para aceptar valores nulo

            decimal? _TipoCotizador = ddlTipoCotizadorConsulta.SelectedValue != "-1" ? decimal.Parse(ddlTipoCotizadorConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _ValorVehiculo = ddlValorVehiculoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlValorVehiculoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _AnoVehiculo = ddlAnoVehiculoCOnsulta.SelectedValue != "-1" ? decimal.Parse(ddlAnoVehiculoCOnsulta.SelectedValue) : new Nullable<decimal>();
            string _ComprensivoIncendioRobo = string.IsNullOrEmpty(txtComprensivoIncendioRoboConsuta.Text.Trim()) ? null : txtComprensivoIncendioRoboConsuta.Text.Trim();

            var Buscar = ObjDataCotizador.Value.BuscaComprensivoIncendioRobo(
                _TipoCotizador,
                _ValorVehiculo,
                _AnoVehiculo,
                new Nullable<decimal>(),
                _ComprensivoIncendioRobo);
            gvListadoComprensivoIncendioRobo.DataSource = Buscar;
            gvListadoComprensivoIncendioRobo.DataBind();

            gvListadoComprensivoIncendioRobo.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvListadoComprensivoIncendioRobo.Columns[6].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void OcultarControles()
        {
            // CONREOLES SUPERIORES
            lbTipoCotizadorConsulta.Visible = false;
            ddlTipoCotizadorConsulta.Visible = false;
            lbValorVehiculoConsulta.Visible = false;
            ddlValorVehiculoConsulta.Visible = false;
            lbAnoVehiculoConsulta.Visible = false;
            ddlAnoVehiculoCOnsulta.Visible = false;
            lbComprensivoIncendioRoboConsulta.Visible = false;
            txtComprensivoIncendioRoboConsuta.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            gvListadoComprensivoIncendioRobo.Visible = false;

            //CONTROLES INFERIORES
            lbAgregarEditar.Visible = true;
            lbTipoCotizadorMantenimiento.Visible = true;
            ddlTipoCotizadorMantenimiento.Visible = true;
            lbValorVehiculoMantenimiento.Visible = true;
            ddlValorVehiculoMantenimiento.Visible = true;
            lbAnoVehiculoMantenimiento.Visible = true;
            ddlAnoVehiculoMantenimiento.Visible = true;
            lbComprensivoIncendioRoboMantenimiento.Visible = true;
            txtCompresnvisoIncendioRobo.Visible = true;
            cbEstatusMantenimiento.Visible = true;
            btnGardar.Visible = true;
            btnAtras.Visible = true;
            txtCompresnvisoIncendioRobo.Text = string.Empty;

        }
        private void MostrarControles()
        {
            // CONREOLES SUPERIORES
            lbTipoCotizadorConsulta.Visible = true;
            ddlTipoCotizadorConsulta.Visible = true;
            lbValorVehiculoConsulta.Visible = true;
            ddlValorVehiculoConsulta.Visible = true;
            lbAnoVehiculoConsulta.Visible = true;
            ddlAnoVehiculoCOnsulta.Visible = true;
            lbComprensivoIncendioRoboConsulta.Visible = true;
            txtComprensivoIncendioRoboConsuta.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            gvListadoComprensivoIncendioRobo.Visible = true;

            //CONTROLES INFERIORES
            lbAgregarEditar.Visible = false;
            lbTipoCotizadorMantenimiento.Visible = false;
            ddlTipoCotizadorMantenimiento.Visible = false;
            lbValorVehiculoMantenimiento.Visible = false;
            ddlValorVehiculoMantenimiento.Visible = false;
            lbAnoVehiculoMantenimiento.Visible = false;
            ddlAnoVehiculoMantenimiento.Visible = false;
            lbComprensivoIncendioRoboMantenimiento.Visible = false;
            txtCompresnvisoIncendioRobo.Visible = false;
            cbEstatusMantenimiento.Visible = false;
            btnGardar.Visible = false;
            btnAtras.Visible = false;

            //CARGAMOS LOS MENUS DESPLEGABLES
            CargarListasDesplegablesPadreConsulta();
            CargarListadoTipoCotizadorConsulta();

            //LIMPIAMOS LOS CONTROLES
            txtComprensivoIncendioRoboConsuta.Text = string.Empty;

            MostrarListadoConsulta();
        }
        #endregion
        #region MANTENIMIENTO DE COMPRENSIVO INCENDIO Y ROBO
        private void MANComprensivoIncendioRobo(decimal IdComprensivoIncendioRobo, string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.Cotizador.EComprensivoIncendioRobo Mantenimiento = new Logica.Entidades.Cotizador.EComprensivoIncendioRobo();

            if (string.IsNullOrEmpty(txtCompresnvisoIncendioRobo.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para proceder con esta operación')", true);
            }
            else
            {
                Mantenimiento.IdTipoCotizador = Convert.ToDecimal(ddlTipoCotizadorMantenimiento.SelectedValue);
                Mantenimiento.IdValorVehiculo = Convert.ToDecimal(ddlValorVehiculoMantenimiento.SelectedValue);
                Mantenimiento.IdAnoVehiculo = Convert.ToDecimal(ddlAnoVehiculoMantenimiento.SelectedValue);
                Mantenimiento.IdComprensivoIncendioRobo = IdComprensivoIncendioRobo;
                Mantenimiento.ComprensivoIncendioRobo = txtCompresnvisoIncendioRobo.Text;
                Mantenimiento.Estatus0 = cbEstatusMantenimiento.Checked;

                var MAN = ObjDataCotizador.Value.MantenimientoComprensivoIncendioRobo(Mantenimiento, Accion);
            }

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

            var SacarDatos = ObjDataComun.Value.BuscaUsuarios(IdUsuario,
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
                CargarListasDesplegablesPadreConsulta();
                CargarListadoTipoCotizadorConsulta();
                MostrarListadoConsulta();
                PermisoPerfil();
            }
        }

        protected void gvListadoComprensivoIncendioRobo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoComprensivoIncendioRobo.PageIndex = e.NewPageIndex;
            MostrarListadoConsulta();
        }

        protected void gvListadoComprensivoIncendioRobo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvListadoComprensivoIncendioRobo.SelectedRow;
            CargarListaDesplegablePadreMantenimiento();
            CargarListadoTipoCotizadorMantenimiento();
            OcultarControles();
            var SacarDatos = ObjDataCotizador.Value.BuscaComprensivoIncendioRobo(
                null,
                null,
                null,
                Convert.ToDecimal(gv.Cells[1].Text),
                null);
            foreach (var n in SacarDatos)
            {
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoCotizadorMantenimiento, n.IdTipoCotizador.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlValorVehiculoMantenimiento, n.IdValorVehiculo.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlAnoVehiculoMantenimiento, n.IdAnoVehiculo.ToString());
                txtCompresnvisoIncendioRobo.Text = n.ComprensivoIncendioRobo;
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);

                if (cbEstatusMantenimiento.Checked == true)
                {
                    cbEstatusMantenimiento.Visible = false;
                    btnDeshabilitar.Visible = true;
                }
                else
                {
                    cbEstatusMantenimiento.Visible = true;
                    btnDeshabilitar.Visible = false;
                }
                lbIdMantenimiento.Text = gv.Cells[1].Text;
                lbAccion.Text = "UPDATE";
            }
            lbAgregarEditar.Text = "Modificar Registro";
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoConsulta();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            OcultarControles();
            lbIdMantenimiento.Text = "0";
            lbAccion.Text = "INSERT";
            CargarListaDesplegablePadreMantenimiento();
            CargarListadoTipoCotizadorMantenimiento();
            lbAgregarEditar.Text = "Nuevo Registro";
            cbEstatusMantenimiento.Checked = true;
            cbEstatusMantenimiento.Visible = false;
        }

        protected void btnGardar_Click(object sender, EventArgs e)
        {
            MANComprensivoIncendioRobo(Convert.ToDecimal(lbIdMantenimiento.Text), lbAccion.Text);
            MostrarControles();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            MANComprensivoIncendioRobo(Convert.ToDecimal(lbIdMantenimiento.Text), "DISABLE");
            MostrarControles();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            MostrarControles();
        }

        protected void ddlTipoCotizadorConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoTipoCotizadorConsulta();
        }

        protected void ddlValorVehiculoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoAnoVehiculoConsulta();
        }

        protected void ddlTipoCotizadorMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoTipoCotizadorMantenimiento();
        }

        protected void ddlValorVehiculoMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoValorVehiculoMantenimiento();
        }
    }
}
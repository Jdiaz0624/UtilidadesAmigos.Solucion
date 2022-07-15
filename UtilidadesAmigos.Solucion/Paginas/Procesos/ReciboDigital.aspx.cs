using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class ReciboDigital : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProceso = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

   

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

        #region CONTROL DE PAGINACION DE LOS RECIBOS DIGITALES
        readonly PagedDataSource pagedDataSource_ReciboDigital = new PagedDataSource();
        int _PrimeraPagina_ReciboDigital, _UltimaPagina_ReciboDigital;
        private int _TamanioPagina_ReciboDigital = 10;
        private int CurrentPage_ReciboDigital
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }

        }

        private void HandlePaging_ReciboDigital(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ReciboDigital = CurrentPage_ReciboDigital - 5;
            if (CurrentPage_ReciboDigital > 5)
                _UltimaPagina_ReciboDigital = CurrentPage_ReciboDigital + 5;
            else
                _UltimaPagina_ReciboDigital = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ReciboDigital > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ReciboDigital = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ReciboDigital = _UltimaPagina_ReciboDigital - 10;
            }

            if (_PrimeraPagina_ReciboDigital < 0)
                _PrimeraPagina_ReciboDigital = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ReciboDigital;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ReciboDigital; i < _UltimaPagina_ReciboDigital; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ReciboDigital(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ReciboDigital.DataSource = Listado;
            pagedDataSource_ReciboDigital.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ReciboDigital.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ReciboDigital.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ReciboDigital.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ReciboDigital : _NumeroRegistros);
            pagedDataSource_ReciboDigital.CurrentPageIndex = CurrentPage_ReciboDigital;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ReciboDigital.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ReciboDigital.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ReciboDigital.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ReciboDigital.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ReciboDigital;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ReciboDigital
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ReciboDigital(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
        {

            int PaginaActual = 0;
            switch (Accion)
            {

                case 1:
                    //PRIMERA PAGINA
                    lbPaginaActual.Text = "1";

                    break;

                case 2:
                    //SEGUNDA PAGINA
                    PaginaActual = Convert.ToInt32(lbPaginaActual.Text);
                    PaginaActual++;
                    lbPaginaActual.Text = PaginaActual.ToString();
                    break;

                case 3:
                    //PAGINA ANTERIOR
                    PaginaActual = Convert.ToInt32(lbPaginaActual.Text);
                    if (PaginaActual > 1)
                    {
                        PaginaActual--;
                        lbPaginaActual.Text = PaginaActual.ToString();
                    }
                    break;

                case 4:
                    //ULTIMA PAGINA
                    lbPaginaActual.Text = lbCantidadPaginas.Text;
                    break;


            }

        }
        #endregion

        #region CARGAR LISTAS
        private void TipoPagoConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoPagoConsulta, ObjDataComun.Value.BuscaListas("TIPOPAGORECIBO", null, null), true);
        }
        private void TipoPagoMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoPago, ObjDataComun.Value.BuscaListas("TIPOPAGORECIBO", null, null));
        }

        private void Oficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjDataComun.Value.BuscaListas("OFICINASINSUCURSAL", null, null),true);
        }
        #endregion

        #region MOSTRAR EL LISTADO 
        private void MostrarListado()
        {

            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermedirioConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedirioConsulta.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSupervisorConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisorConsulta.Text);
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeCosulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeCosulta.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaConsulta.Text);
            int? _IdTipoPago = ddlTipoPagoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoPagoConsulta.SelectedValue) : new Nullable<int>();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            var MostrarListado = ObjDataProceso.Value.BuscaReciboDigital(
                new Nullable<decimal>(),
                _Intermediario,
                _Supervisor,
                _FechaDesde,
                _FechaHasta,
                _IdTipoPago,
                _Oficina
                );
            if (MostrarListado.Count() < 1)
            {
                rpListadoREcibos.DataSource = null;
                rpListadoREcibos.DataBind();
                CurrentPage_ReciboDigital = 0;
            }
            else
            {

                decimal Efectivo = 0, Transferencia = 0, Deposito = 0, Cheque = 0, Otros = 0;
                foreach (var n in MostrarListado) {
                    Efectivo = (decimal)n.TotalEfectivo;
                    Transferencia = (decimal)n.TotalTransferencia;
                    Deposito = (decimal)n.TotalDeposito;
                    Cheque = (decimal)n.TotalCheque;
                    Otros = (decimal)n.TotalOtro;
                }


                lbTotalEfectivo.Text = Efectivo.ToString("N2");
                lbTotalTransferencia.Text = Transferencia.ToString("N2");
                lbTotalDeposito.Text = Deposito.ToString("N2");
                lbTotalCheque.Text = Cheque.ToString("N2");
                lbTotalOtros.Text = Otros.ToString("N2");

                Paginar_ReciboDigital(ref rpListadoREcibos, MostrarListado, 10, ref lbCantidadPagina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
                HandlePaging_ReciboDigital(ref dtPaginacionListadoPrincipal, ref lbPaginaActual);
            }
        }
        #endregion

        #region SACAR LA OFICINA DE LOS USUARIOS
        private int SacaroficinaUsuario(decimal IdUsuario) {
            int CodigoOficina = 0;

            var SacarInformacion = ObjDataComun.Value.BuscaUsuarios(IdUsuario);
            foreach (var n in SacarInformacion) {
                CodigoOficina = (int)n.IdOficina;
            }
            return CodigoOficina;
        }
        #endregion

        #region PROCESAR INFORMACION
        private void ProcesarInformacion(decimal IdRegistro, string Accion)
        {
            decimal IdUsuario = (decimal)Session["IdUsuario"];
            int IdOficina = SacaroficinaUsuario(IdUsuario);
            

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionREcibosDigitales Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionREcibosDigitales(
                IdRegistro,
                Convert.ToInt32(txtCodigoIntermediario.Text),
                DateTime.Now,
                Convert.ToDecimal(txtValorAplicar.Text),
                Convert.ToInt32(ddlSeleccionarTipoPago.SelectedValue),
                txtDetalle.Text,
                IdUsuario,
                IdOficina,
                Accion);
            Procesar.ProcesarInformacion();
            ConfigurarcionInicial();
        }
        #endregion

        private void ConfigurarcionInicial()
        {
            txtCodigoIntermedirioConsulta.Text = string.Empty;
            txtNombreIntermediarioConsulta.Text = string.Empty;
            txtFechaDesdeCosulta.Text = string.Empty;
            txtFechaHastaConsulta.Text = string.Empty;
            txtSupervisorConsulta.Text = string.Empty;
            txtNombreSupervisorConsulta.Text = string.Empty;


            rbPDF.Checked = true;
   
            TipoPagoConsulta();
            Oficinas();
            DIVBloqueReciboDigitalConsulta.Visible = true;
            BloqueReciboDigitalMantenimiento.Visible = false;

            rpListadoREcibos.DataSource = null;
            rpListadoREcibos.DataBind();
            CurrentPage_ReciboDigital = 0;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "RECIBO DIGITAL";

                ConfigurarcionInicial();

                DateTime _FechaDesde = DateTime.Now, _FechaHasta = DateTime.Now;
                txtFechaDesdeCosulta.Text = _FechaDesde.ToString("yyyy-MM-dd");
                txtFechaHastaConsulta.Text = _FechaHasta.ToString("yyyy-MM-dd");
                CurrentPage_ReciboDigital = 0;
                MostrarListado();
                PermisoPerfil();
            }
        }

        protected void txtCodigoIntermedirioConsulta_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreVendedor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermedirioConsulta.Text);
            txtNombreIntermediarioConsulta.Text = NombreVendedor.SacarNombreIntermediario();
        }

        protected void txtSupervisorConsulta_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreSupervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtSupervisorConsulta.Text);
            txtNombreSupervisorConsulta.Text = NombreSupervisor.SacarNombreSupervisor();
        }

   

      

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital = 0;
            MostrarListado();
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueReciboDigitalConsulta.Visible = false;
            BloqueReciboDigitalMantenimiento.Visible = true;
            txtCodigoIntermediario.Text = string.Empty;
            txtNombreIntermediario.Text = string.Empty;
            txtValorAplicar.Text = string.Empty;
            TipoPagoMantenimiento();
            txtDetalle.Text = string.Empty;
            lbIdRegistroSeleccionado.Text = "0";
            lbAccionTomar.Text = "INSERT";
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermedirioConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedirioConsulta.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSupervisorConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisorConsulta.Text);
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeCosulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeCosulta.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaConsulta.Text);
            int? _IdTipoPago = ddlTipoPagoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoPagoConsulta.SelectedValue) : new Nullable<int>();
            int? _oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

            if (rbExcelPlano.Checked == true)
            {

                var Exportar = (from n in ObjDataProceso.Value.BuscaReciboDigital(
                    new Nullable<decimal>(),
                    _Intermediario,
                    _Supervisor,
                    _FechaDesde,
                    _FechaHasta,
                    _IdTipoPago,
                    _oficina)
                                select new
                                {
                                    NumeroRecibo = n.NumeroRecibo,
                                    Intermediario = n.Intermediario,
                                    Supervisor = n.NombreIntermediario,
                                    Fecha = n.Fecha,
                                    Hora = n.Hora,
                                    ValorRecibo = n.ValorRecibo,
                                    TipoPago = n.TipoPago,
                                    Detalle = n.Detalle,
                                    CreadoPor = n.CreadoPor
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Recibos", Exportar);
            }
            else
            {

                ReportDocument Reporte = new ReportDocument();

                Reporte.Load(Server.MapPath("ReporteRecibos.rpt"));
                Reporte.Refresh();

                Reporte.SetParameterValue("@NumeroRecibo", new Nullable<decimal>());
                Reporte.SetParameterValue("@CodigoIntermediario", _Intermediario);
                Reporte.SetParameterValue("@CodigoSupervisor", _Supervisor);
                Reporte.SetParameterValue("@FechaDesde", _FechaDesde);
                Reporte.SetParameterValue("@FechaHasta", _FechaHasta);
                Reporte.SetParameterValue("@IdTipoPago", _IdTipoPago);
                Reporte.SetParameterValue("@Oficina", _oficina);
                Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

                Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

                if (rbPDF.Checked == true)
                {
                    //Reporte.PrintToPrinter(200, false, 0, 0);
                    //crystalReport.PrintOptions.PrinterName = GetDefaultPrinter();
                    //cprPrinter.PrinterSettings.PrinterName;
                    
                    Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Reporte de Recibos");
                }
                else if (rbExcel.Checked == true)
                {

                    Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Reporte de Recibos");
                }
            }
        }

        protected void btnRestablecer_Click(object sender, ImageClickEventArgs e)
        {
            ConfigurarcionInicial();
        }

        protected void btnRecibo_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var NumeroRecibo = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroRecibo")).Value.ToString();
            var Oficina = ((HiddenField)ItemSeleccionado.FindControl("hfIdOficina")).Value.ToString();

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(Server.MapPath("Recibos.rpt"));
            Reporte.Refresh();

            Reporte.SetParameterValue("@NumeroRecibo", Convert.ToDecimal(NumeroRecibo));
            Reporte.SetParameterValue("@CodigoIntermediario", new Nullable<int>());
            Reporte.SetParameterValue("@CodigoSupervisor", new Nullable<int>());
            Reporte.SetParameterValue("@FechaDesde", new Nullable<DateTime>());
            Reporte.SetParameterValue("@FechaHasta", new Nullable<DateTime>());
            Reporte.SetParameterValue("@IdTipoPago", new Nullable<int>());
            Reporte.SetParameterValue("@Oficina", Convert.ToInt32(Oficina));
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Recibo de Ingreso");

         
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital = 0;
            MostrarListado();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital += -1;
            MostrarListado();
            MoverValoresPaginacion_ReciboDigital((int)OpcionesPaginacionValores_ReciboDigital.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void dtPaginacionListadoPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ReciboDigital = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital += 1;
            MostrarListado();
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListado();
            MoverValoresPaginacion_ReciboDigital((int)OpcionesPaginacionValores_ReciboDigital.UltimaPagina, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreVendedor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = NombreVendedor.SacarNombreIntermediario();
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacion(
                Convert.ToDecimal(lbIdRegistroSeleccionado.Text),
                lbAccionTomar.Text);
        }

        protected void DirectoImpresora_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var NumeroRecibo = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroRecibo")).Value.ToString();
            var Oficina = ((HiddenField)ItemSeleccionado.FindControl("hfIdOficina")).Value.ToString();

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(Server.MapPath("Recibos.rpt"));
            Reporte.Refresh();

            Reporte.SetParameterValue("@NumeroRecibo", Convert.ToDecimal(NumeroRecibo));
            Reporte.SetParameterValue("@CodigoIntermediario", new Nullable<int>());
            Reporte.SetParameterValue("@CodigoSupervisor", new Nullable<int>());
            Reporte.SetParameterValue("@FechaDesde", new Nullable<DateTime>());  
            Reporte.SetParameterValue("@FechaHasta", new Nullable<DateTime>());
            Reporte.SetParameterValue("@IdTipoPago", new Nullable<int>());
            Reporte.SetParameterValue("@Oficina", Convert.ToInt32(Oficina));
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
            //Reporte.PrintOptions.PrinterName = Reporte.PrintOptions.PrinterName;
            Reporte.PrintToPrinter(2, true, 0, 2);
        }

        protected void dtPaginacionListadoPrincipal_CancelCommand1(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ReciboDigital = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            ConfigurarcionInicial();
        }
    }
}
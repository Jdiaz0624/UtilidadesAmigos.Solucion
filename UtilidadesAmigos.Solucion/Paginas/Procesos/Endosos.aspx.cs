using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class Endosos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProcesos = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

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

            var SacarDatos = ObjDataGeneral.Value.BuscaUsuarios(IdUsuario,
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

        enum TiposEndosos { 
        EndosoAclaratorioInfraseguro=1,
        EndosoAclaratorioLicenciaExtrajera=2,
        EndosoAclaratorioConductorUnico=3,
        EndosoAclaratorioAuxilioVial=4,
        EndosoAclaratorioCasaConductor=5,
        EndosoDVL=6
        }
        enum TipoGruaEnumeracion { 
        GruaPremium=32,
        GruaSuperior=37,
        GruaBasica=38
        }

        #region CONTROL DE PAGINACION
        readonly PagedDataSource pagedDataSource = new PagedDataSource();
        int _PrimeraPagina, _UltimaPagina;
        private int _TamanioPagina = 10;
        private int CurrentPage
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

        private void HandlePaging(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina = CurrentPage - 5;
            if (CurrentPage > 5)
                _UltimaPagina = CurrentPage + 5;
            else
                _UltimaPagina = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina = _UltimaPagina - 10;
            }

            if (_PrimeraPagina < 0)
                _PrimeraPagina = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina; i < _UltimaPagina; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina : _NumeroRegistros);
            pagedDataSource.CurrentPageIndex = CurrentPage;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            RptGrid.DataSource = pagedDataSource;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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


        #region BUSCA POLIZAS
        private void MostrarListadoPolizas() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtNumeroItenComsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroItenComsulta.Text);
            string Estatus = "", TipoSeguro = "", Poliza = "", InicioVigencia = "", FinVigencia = "", Supervisor = "", Intrmediario = "", Ramo = "", SubRamo = "", Cliente = "", Grua = "";
            int Item = 0, CodigoGrua = 0;

            var Listado = ObjDataProcesos.Value.BuscaPolizaEndosos(_Poliza, _Item);
            if (Listado.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "RegistroNoEncontrado()", "RegistroNoEncontrado();", true);
                ConfiguracionInicial();
            }
            else {

                foreach (var n in Listado) {
                    Estatus = n.Estatus;
                    TipoSeguro = n.TipoSeguro;
                    Poliza = n.Poliza;
                    Item = (int)n.Item;
                    InicioVigencia = n.InicioVigencia;
                    FinVigencia = n.FinVigencia;
                    Supervisor = n.Supervisor;
                    Intrmediario = n.Intermediario;
                    Ramo = n.NombreRamo;
                    SubRamo = n.NombreSubRamo;
                    Cliente = n.NombreCliente;
                    Grua = n.Grua;
                    CodigoGrua = (int)n.CodigoGrua;
                    LBCodigoSubramoVariable.Text = n.SubRamo.ToString();
                }
                if (Estatus == "CANCELADA") {

                    ClientScript.RegisterStartupScript(GetType(), "PolizaCancelada()", "PolizaCancelada();", true);
                    ConfiguracionInicial();
                }
                else {
                    DIVBloqueDetallePoliza.Visible = true;
                    DIVBloqueOperacionRealizar.Visible = true;
                    rbHistoricoEndoso.Checked = true;
                    DIVBloqueHistorico.Visible = true;
                    lbPolizaDetalleVariable.Text = Poliza;
                    lbItemNoDetalleVariable.Text = Item.ToString("N0");
                    lbInicioVigenciaDetalleVariable.Text = InicioVigencia;
                    lbFinVIgenciaDetalleVariable.Text = FinVigencia;
                    lbSupervisorDetalleVariable.Text = Supervisor;
                    lbIntermediarioDetalleVariable.Text = Intrmediario;
                    lbEstatusDetalleVariable.Text = Estatus;
                    lbRamoDetalleVariable.Text = Ramo;
                    lbSubRamoDetalleVariable.Text = SubRamo;
                    lbClienteDetalleVariable.Text = Cliente;
                    lbTipoSeguroVariable.Text = TipoSeguro;
                    lbGruaVariable.Text = Grua;
                    lbCodigoGruaVariable.Text = CodigoGrua.ToString();

                    if (lbTipoSeguroVariable.Text == "Seguro Full")
                    {
                        rbEndosoAclaratorio.Visible = true;
                        rbEndosoAclaratorioPAraCodundorUnico.Visible = true;
                        rbENdosoAuxilioVial.Visible = true;
                        rbEndosoLicenciaExtragero.Visible = true;
                        rbEndosoAclaratorio.Checked = true;
                    }
                    else
                    {
                        rbEndosoAclaratorio.Visible = false;
                        rbEndosoAclaratorioPAraCodundorUnico.Visible = false;
                        rbENdosoAuxilioVial.Visible = true;
                        rbEndosoLicenciaExtragero.Visible = false;
                        rbENdosoAuxilioVial.Checked = true;
                    }
                    MostrarListadoEndosos();
                }

            }
            
        }
        #endregion

        #region MOSTRAR EL LISTADO DE ENDOSOS
        private void MostrarListadoEndosos() {

            int EndososAclaratorios = 0, EndosoLienciaEntrajero = 0, EndosoConductorUnico = 0, EndosoAuxilioVial = 0;

            var MostrarEndosos = ObjDataProcesos.Value.BuscaInformacionEndosos(
                lbPolizaDetalleVariable.Text,
                Convert.ToInt32(lbItemNoDetalleVariable.Text),
                null, null, null, 1);
            if (MostrarEndosos.Count() < 1) {
                rpListadoEndososImpresos.DataSource = null;
                rpListadoEndososImpresos.DataBind();
                lbTotalEndososAclaratorios.Text = "0";
                lbTotalEndososLicenciaExtrajero.Text = "0";
                lbTotalEndososConductorUnico.Text = "0";
                lbTotalEndososAuxilioVial.Text = "0";
            }
            else {
                foreach (var n in MostrarEndosos) {
                    EndososAclaratorios = (int)n.CantidadEndosoAclaratorio;
                    EndosoLienciaEntrajero = (int)n.CantidadEndosoLicenciaExtranjero;
                    EndosoConductorUnico = (int)n.CantidadEndosoConductorUnico;
                    EndosoAuxilioVial = (int)n.CantidadEndosoAuxilioVial;
                }
                Paginar(ref rpListadoEndososImpresos, MostrarEndosos, 10, ref lbCantidadPagina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
                HandlePaging(ref dtPaginacionListadoPrincipal, ref lbPaginaActual);
                lbTotalEndososAclaratorios.Text = EndososAclaratorios.ToString("N0");
                lbTotalEndososLicenciaExtrajero.Text = EndosoLienciaEntrajero.ToString("N0");
                lbTotalEndososConductorUnico.Text = EndosoConductorUnico.ToString("N0");
                lbTotalEndososAuxilioVial.Text = EndosoAuxilioVial.ToString("N0");
            }
        }
        #endregion

        #region PROCESAR ENDOSOS

        private void GaurdarInformacion(int CodigoENdoso, int TipoGrua) {

            string _LicenciaExtrajera = string.IsNullOrEmpty(txtNumeroLicenciaExtranjero.Text.Trim()) ? "" : txtNumeroLicenciaExtranjero.Text.Trim();
            string _NombreConductorUnico = string.IsNullOrEmpty(txtNombreConductorUnico.Text.Trim()) ? "" : txtNombreConductorUnico.Text.Trim();
            string _CedulaConductorUnico = string.IsNullOrEmpty(txtCedulaConductorUnico.Text.Trim()) ? "" : txtCedulaConductorUnico.Text.Trim();

            //BUSCAMOS LA INFORMACION
            var BuscarInformacion = ObjDataProcesos.Value.BuscaPolizaEndosos(
                lbPolizaDetalleVariable.Text,
                Convert.ToInt32(lbItemNoDetalleVariable.Text));
            foreach (var n in BuscarInformacion) {

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionEndosos Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionEndosos(
                    0,
                    n.Poliza,
                    0,
                    (int)n.Item,
                    n.NombreCliente,
                    1,
                    n.NumeroIdentificacion,
                    n.Direccion,
                    n.TelefonoResidencia,
                    n.TelefonoOficina,
                    n.Celular,
                    n.fax,
                    n.InicioVigencia,
                    n.FinVigencia,
                    n.Estatus,
                    n.Marca,
                    n.Modelo,
                    n.Chasis,
                    n.Placa,
                    n.Color,
                    CodigoENdoso,
                    _LicenciaExtrajera,
                    _NombreConductorUnico,
                    _CedulaConductorUnico,
                    TipoGrua,
                    DateTime.Now,
                    (decimal)Session["IdUsuario"],
                    "INSERT");
                Guardar.ProcesarInformacion();

            }

        }
        private void ProcesarEndoso() {

            int CodigoENdoso = 0;
            int TipoGruaSistema = Convert.ToInt32(lbCodigoGruaVariable.Text);
            int TipoGrua = 0;
            switch (TipoGruaSistema) {

                case (int)TipoGruaEnumeracion.GruaPremium:
                    TipoGrua = 1;
                    break;

                case (int)TipoGruaEnumeracion.GruaSuperior:
                    TipoGrua = 2;
                    break;

                case (int)TipoGruaEnumeracion.GruaBasica:
                    TipoGrua = 3;
                    break;
            }


            if (rbEndosoAclaratorio.Checked == true)
            {
                CodigoENdoso = (int)TiposEndosos.EndosoAclaratorioInfraseguro;

                GaurdarInformacion(CodigoENdoso, TipoGrua);
                GenerarEndoso(lbPolizaDetalleVariable.Text, Convert.ToInt32(lbItemNoDetalleVariable.Text), (decimal)Session["IdUsuario"], (int)TiposEndosos.EndosoAclaratorioInfraseguro, new Nullable<int>(), 1, Server.MapPath("EndodoAclaratorioInfraseguro.rpt"), "Endoso Infraseguro");
            }
            else if (rbEndosoLicenciaExtragero.Checked == true)
            {

                if (string.IsNullOrEmpty(txtNumeroLicenciaExtranjero.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "LicenciaExtrajero()", "LicenciaExtrajero();", true);
                }
                else
                {
                    CodigoENdoso = (int)TiposEndosos.EndosoAclaratorioLicenciaExtrajera;

                    GaurdarInformacion(CodigoENdoso, TipoGrua);
                    GenerarEndoso(lbPolizaDetalleVariable.Text, Convert.ToInt32(lbItemNoDetalleVariable.Text), (decimal)Session["IdUsuario"], (int)TiposEndosos.EndosoAclaratorioLicenciaExtrajera, new Nullable<int>(), 1, Server.MapPath("EndodoAclaratorioLicenciaExtrajero.rpt"), "Endoso Licencia Extrajera");
                }
            }
            else if (rbEndosoAclaratorioPAraCodundorUnico.Checked == true)
            {

                if (string.IsNullOrEmpty(txtNombreConductorUnico.Text.Trim()) || string.IsNullOrEmpty(txtCedulaConductorUnico.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposVaciosConductorUnico()", "CamposVaciosConductorUnico();", true);
                    if (string.IsNullOrEmpty(txtNombreConductorUnico.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "CampoNombreVacioConductorUnico()", "CampoNombreVacioConductorUnico();", true);
                    }
                    if (string.IsNullOrEmpty(txtCedulaConductorUnico.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "CampoCedulaVacioConductorUnico()", "CampoCedulaVacioConductorUnico();", true);
                    }
                }
                else
                {
                    CodigoENdoso = (int)TiposEndosos.EndosoAclaratorioConductorUnico;

                    GaurdarInformacion(CodigoENdoso, TipoGrua);
                    GenerarEndoso(lbPolizaDetalleVariable.Text, Convert.ToInt32(lbItemNoDetalleVariable.Text), (decimal)Session["IdUsuario"], (int)TiposEndosos.EndosoAclaratorioConductorUnico, new Nullable<int>(), 1, Server.MapPath("EndodoAclaratorioConductorUnico.rpt"), "Endoso Conductor Unico");
                }
            }
            else if (rbENdosoAuxilioVial.Checked == true)
            {

                CodigoENdoso = (int)TiposEndosos.EndosoAclaratorioAuxilioVial;

                GaurdarInformacion(CodigoENdoso, TipoGrua);
                GenerarEndoso(lbPolizaDetalleVariable.Text, Convert.ToInt32(lbItemNoDetalleVariable.Text), (decimal)Session["IdUsuario"], (int)TiposEndosos.EndosoAclaratorioAuxilioVial, new Nullable<int>(), 2, Server.MapPath("EndodoAclaratorioAuxilioVial.rpt"), "Endoso Auxilio Vial");
            }
            else if (rbEndosoCasaConductor.Checked == true)
            {

                CodigoENdoso = (int)TiposEndosos.EndosoAclaratorioCasaConductor;

                GaurdarInformacion(CodigoENdoso, TipoGrua);
                GenerarEndoso(lbPolizaDetalleVariable.Text, Convert.ToInt32(lbItemNoDetalleVariable.Text), (decimal)Session["IdUsuario"], (int)TiposEndosos.EndosoAclaratorioCasaConductor, new Nullable<int>(), 1, Server.MapPath("EndosoAclaratorioCasaConductor.rpt"), "Endoso Casa del Conductor");
            }
            else if (rbEndosoDVL.Checked == true)
            {

                CodigoENdoso = (int)TiposEndosos.EndosoDVL;
                GaurdarInformacion(CodigoENdoso, TipoGrua);
                GenerarEndoso(lbPolizaDetalleVariable.Text, Convert.ToInt32(lbItemNoDetalleVariable.Text), (decimal)Session["IdUsuario"], (int)TiposEndosos.EndosoDVL, new Nullable<int>(), 1, Server.MapPath("EndosoDVL.rpt"), "Endoso de DVL");
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "PolizaNoAplica()", "PolizaNoAplica();", true);
            }

          


        }
        #endregion

        #region GENERAR REPORTE
        
        private void GenerarEndoso(string Poliza,int Item, decimal GeneradoPor,int CodigoTipoEndoso,int? Secuencia, int TipoEndoso,string RutaReporte,string NombreEndoso) {

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@Poliza", Poliza);
            Reporte.SetParameterValue("@Item", Item);
            Reporte.SetParameterValue("@GeneradoPor", GeneradoPor);
            Reporte.SetParameterValue("@CodigoTipoEndoso", CodigoTipoEndoso);
            Reporte.SetParameterValue("@Secuencia", Secuencia);
            Reporte.SetParameterValue("@TipoEndoso", TipoEndoso);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreEndoso);


        }
        #endregion

        #region REPORTE DE ENDOSOS IMPRESOS
        private void GenerarListadoEndososImpresos() {

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(Server.MapPath("ReporteImpresionEndosos.rpt"));
            Reporte.Refresh();

            Reporte.SetParameterValue("@Poliza", lbPolizaDetalleVariable.Text);
            Reporte.SetParameterValue("@Item", new Nullable<int>());
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);
            Reporte.SetParameterValue("@CodigoTipoEndoso", new Nullable<int>());
            Reporte.SetParameterValue("@Secuencia", new Nullable<int>());
            Reporte.SetParameterValue("@TipoEndoso", 1);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Reporte de Impresion Endosos");
        }
        #endregion


        private void ConfiguracionInicial() {
            rbHistoricoEndoso.Checked = true;
            txtPolizaConsulta.Text = string.Empty;
            txtNumeroItenComsulta.Text = string.Empty;
            txtCedulaConductorUnico.Text = string.Empty;
            txtNombreConductorUnico.Text = string.Empty;
            txtNumeroLicenciaExtranjero.Text = string.Empty;
         
            DIVBloqueDetallePoliza.Visible = false;
            DIVBloqueOperacionRealizar.Visible = false;
            DIVBloqueHistorico.Visible = false;
            DIVBloqueNuevoRegistro.Visible = false;
            txtNumeroItenComsulta.Text = "1";
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR ENDOSOS";

                ConfiguracionInicial();
                PermisoPerfil();
                btnConsultar.Visible = true;
                btnRestablecerPantalla.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            rbHistoricoEndoso.Checked = true;
            MostrarListadoPolizas();
            btnConsultar.Visible = false;
            btnRestablecerPantalla.Visible = true;

        }

        protected void btnRestablecerPantalla_Click(object sender, ImageClickEventArgs e)
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

        protected void rbHistoricoEndoso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHistoricoEndoso.Checked == true) {
                DIVBloqueHistorico.Visible = true;
                DIVBloqueNuevoRegistro.Visible = false;
            }
            else if (rbGenerarNuevoEndoso.Checked == true) {
                DIVBloqueHistorico.Visible = false;

                DIVBloqueNuevoRegistro.Visible = true;

                rbEndosoAclaratorio.Checked = true;
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
                txtNumeroLicenciaExtranjero.Text = string.Empty;
                txtNombreConductorUnico.Text = string.Empty;
                txtCedulaConductorUnico.Text = string.Empty;
            }
        }

        protected void rbGenerarNuevoEndoso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenerarNuevoEndoso.Checked == true) {
                DIVBloqueNuevoRegistro.Visible = true;
                DIVBloqueHistorico.Visible = false;

                
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
                
                txtNumeroLicenciaExtranjero.Text = string.Empty;
                txtNombreConductorUnico.Text = string.Empty;
                txtCedulaConductorUnico.Text = string.Empty;

                int CodigoSubramo = Convert.ToInt32(LBCodigoSubramoVariable.Text);
                int CodigoGrua = Convert.ToInt32(lbCodigoGruaVariable.Text);
               

                if (lbTipoSeguroVariable.Text == "Seguro Full")
                {
                    rbEndosoAclaratorio.Visible = true;
                    rbEndosoLicenciaExtragero.Visible = true;
                    rbEndosoAclaratorioPAraCodundorUnico.Visible = true;
                    rbENdosoAuxilioVial.Visible = true;
                    rbEndosoCasaConductor.Visible = true;
                    rbEndosoDVL.Visible = false;
                    rbEndosoAclaratorio.Checked = true;
                }
                else
                {
                    rbEndosoAclaratorio.Visible = false;
                    rbEndosoLicenciaExtragero.Visible = false;
                    rbEndosoAclaratorioPAraCodundorUnico.Visible = false;
                    rbENdosoAuxilioVial.Visible = false;
                    rbEndosoCasaConductor.Visible = false;
                    rbEndosoDVL.Visible = false;

                    if (CodigoGrua != 0)
                    {
                        rbENdosoAuxilioVial.Visible = true;
                    }

                    if (CodigoSubramo == 11) {
                        rbEndosoDVL.Visible = true;
                    }

                    if (rbENdosoAuxilioVial.Visible == true && rbEndosoDVL.Visible == true) { rbENdosoAuxilioVial.Checked = true; }
                    else if (rbENdosoAuxilioVial.Visible == false && rbEndosoDVL.Visible == true) { rbEndosoDVL.Checked = true; }
                    else if (rbENdosoAuxilioVial.Visible == true && rbEndosoDVL.Visible == false) { rbENdosoAuxilioVial.Checked = true; }
                    else {
                        rbEndosoAclaratorio.Checked = false;
                        rbEndosoLicenciaExtragero.Checked = false;
                        rbEndosoAclaratorioPAraCodundorUnico.Checked = false;
                        rbENdosoAuxilioVial.Checked = false;
                        rbEndosoCasaConductor.Checked = false;
                        rbEndosoDVL.Checked = false;

                    }

                }

               
            }
            else if (rbHistoricoEndoso.Checked == true) {
                DIVBloqueNuevoRegistro.Visible = false;
                DIVBloqueHistorico.Visible = true;
            }

           
        }

        protected void btnReImprimirEndoso_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;

            var Poliza = ((HiddenField)ItemSeleccionado.FindControl("hfPoliza")).Value.ToString();
            var Item = ((HiddenField)ItemSeleccionado.FindControl("hfItem")).Value.ToString();
            var IdUsuario = ((HiddenField)ItemSeleccionado.FindControl("hfIdUsuario")).Value.ToString();
            var CodigoTipoEndoso = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoTipoEndoso")).Value.ToString();
            var Secuencia = ((HiddenField)ItemSeleccionado.FindControl("hfSecuencia")).Value.ToString();
            int TipoOperacion = 0;
            string RutaReporte = "";
            string NombreEndoso = "";

            if (CodigoTipoEndoso == "1")
            {
                TipoOperacion = 1;
                RutaReporte = Server.MapPath("EndodoAclaratorioInfraseguro.rpt");
                NombreEndoso = "Endoso De Infraseguro";
            }
            else if (CodigoTipoEndoso == "2")
            {
                TipoOperacion = 1;
                RutaReporte = Server.MapPath("EndodoAclaratorioLicenciaExtrajero.rpt");
                NombreEndoso = "Endoso de Licencia Extrajera";
            }
            else if (CodigoTipoEndoso == "3")
            {
                TipoOperacion = 1;
                RutaReporte = Server.MapPath("EndodoAclaratorioConductorUnico.rpt");
                NombreEndoso = "Endoso de Conductor Unico";
            }
            else if (CodigoTipoEndoso == "4")
            {
                TipoOperacion = 2;
                RutaReporte = Server.MapPath("EndodoAclaratorioAuxilioVial.rpt");
                NombreEndoso = "Endoso de Auxilio Vial";
            }
            else if (CodigoTipoEndoso == "5")
            {
                TipoOperacion = 1;
                RutaReporte = Server.MapPath("EndosoAclaratorioCasaConductor.rpt");
                NombreEndoso = "Endoso de Casa del Conductor";
            }
            else if (CodigoTipoEndoso == "6") {
                TipoOperacion = 1;
                RutaReporte = Server.MapPath("EndosoDVL.rpt");
                NombreEndoso = "Endoso de DVL";
            }

            MostrarListadoEndosos();

            GenerarEndoso(
                Poliza, 
                Convert.ToInt32(Item), 
                Convert.ToDecimal(IdUsuario), 
                Convert.ToInt32(CodigoTipoEndoso), 
                Convert.ToInt32(Secuencia), 
                TipoOperacion,
                RutaReporte, 
                NombreEndoso);
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoEndosos();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoEndosos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void dtPaginacionListadoPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoEndosos();

        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoEndosos();

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoEndosos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void rbEndosoAclaratorio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEndosoAclaratorio.Checked == true) {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
            else {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void rbEndosoLicenciaExtragero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEndosoLicenciaExtragero.Checked == true) {
                DIVBloqueLicenciaExtrajero.Visible = true;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
            else {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void rbEndosoAclaratorioPAraCodundorUnico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEndosoAclaratorioPAraCodundorUnico.Checked == true) {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = true;
                DIVBloqueCedula.Visible = true;
            }
            else {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void rbENdosoAuxilioVial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbENdosoAuxilioVial.Checked == true) {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
            else
            {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            GenerarListadoEndososImpresos();
        }

        protected void rbEndosoCasaConductor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEndosoCasaConductor.Checked == true)
            {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
            else
            {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void rbEndosoDVL_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEndosoDVL.Checked == true)
            {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
            else
            {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void btnCompletar_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarEndoso();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReporteProduccion : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDAtaGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();
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

            var SacarDatos = ObjDAtaGeneral.Value.BuscaUsuarios(IdUsuario,
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
        enum TipoAgrupacion { 
        
            Concepto=1,
            Usuario=2,
            Oficina=3,
            Ramo=4,
            Intermediario=5,
            Supervisor=6,
            Moneda=7
        }

        #region CONTROL PARA MOSTRAR LA PAGINACION
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


        private void HandlePaging(ref DataList NombreDataList, ref Label lbPaginaActual)
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
            lbPaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton PaginaSiguiente, ref ImageButton UltimaPagina)
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
            PaginaSiguiente.Enabled = !pagedDataSource.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            RptGrid.DataSource = pagedDataSource;
            RptGrid.DataBind();


            //  divPaginacionBancos.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label CantidadPagina)
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
                    lbPaginaActual.Text = CantidadPagina.Text;
                    break;


            }

        }
        #endregion

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void ListasOficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjDAtaGeneral.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void ListasRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDAtaGeneral.Value.BuscaListas("RAMO", null, null), true);
        }
        private void ListaSubRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubRamo, ObjDAtaGeneral.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamo.SelectedValue.ToString(), null), true);
        }
        private void ListaUsuarios() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjDAtaGeneral.Value.BuscaListas("USUARIOSFACTURACION", null, null), true);
        }
        private void ListaMonedas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMoneda, ObjDAtaGeneral.Value.BuscaListas("MONEDA", null, null), true);
        }
        private void ListaCOnceptos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCOncepto, ObjDAtaGeneral.Value.BuscaListas("CONCEPTOS", null, null), true);
        }
        private void ListaDesplegables() {
            ListasOficinas();
            ListasRamos();
            ListaSubRamo();
            ListaUsuarios();
            ListaMonedas();
            ListaCOnceptos();
        }
        #endregion

        #region MOSTRAR LA PRODUCCION
        private void MostrarProduccion() {

            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAcios()", "CamposFechaVAcios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {

                int? _Intermediario = string.IsNullOrEmpty(txtCodIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodIntermediario.Text);
                int? _Supervisor = string.IsNullOrEmpty(txtCodSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodSupervisor.Text);
                int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                string _Concepto = ddlSeleccionarCOncepto.SelectedValue != "-1" ? ddlSeleccionarCOncepto.SelectedItem.Text : null;
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
                string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
                decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);


                var Listado = ObjDataReportes.Value.BuscarDatosProduccion(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Intermediario,
                    _Supervisor,
                    _Oficina,
                    _Ramo,
                    _SubRamo,
                    _Usuario,
                    _Poliza,
                    _NumeroFactura,
                    _Moneda,
                    null,
                    _Concepto,
                    (decimal)Session["IdUsuario"]);
                Paginar(ref rpListadoProduccion, Listado, 10, ref lbCantidadPaginaVAriableProduccion, ref btnPrimeraPaginaPaginacion, ref btnPaginaAnteriorPaginacion, ref btnPaginaSiguientePaginacion, ref btnUltimaPaginaPaginacion);
                HandlePaging(ref dtPaginacionPolizasProduccion, ref lbPaginaActualVariableProduccion);

            }

        }
        #endregion

        #region GENERAR REPORTE

        enum TiposAgrupaciones {

            CONCEPTO =1,
            USUARIO=2,
            OFICINA=3,
            RAMO=4,
            INTERMEDIARIO=5,
            SUPERVISOR=6,
            MONEDA=7
        }

        private void GenerarReporteFormateado(string RutaReporte, string NombreReporte) {
            int? _Intermediario = string.IsNullOrEmpty(txtCodIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodIntermediario.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodSupervisor.Text);
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
            string _Concepto = ddlSeleccionarCOncepto.SelectedValue != "-1" ? ddlSeleccionarCOncepto.SelectedItem.Text : null;
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
            string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
            decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@Intermediario", _Intermediario);
            Reporte.SetParameterValue("@Supervisor", _Supervisor);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@SubRamo", _SubRamo);
            Reporte.SetParameterValue("@Usuario", _Usuario);
            Reporte.SetParameterValue("@Poliza", _Poliza);
            Reporte.SetParameterValue("@NumeroDocumento", _NumeroFactura);
            Reporte.SetParameterValue("@Moneda", _Moneda);
            Reporte.SetParameterValue("@Tipo", new Nullable<int>());
            Reporte.SetParameterValue("@Concepto", _Concepto);
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {

                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
        }
        private void GenerarReporteAgrupadoFormateado(string RutaReporte, string NombreReporte, int TipoAgrupacion) {

            int? _Intermediario = string.IsNullOrEmpty(txtCodIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodIntermediario.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodSupervisor.Text);
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
            string _Concepto = ddlSeleccionarCOncepto.SelectedValue != "-1" ? ddlSeleccionarCOncepto.SelectedItem.Text : null;
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
            string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
            decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);
            
            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@Intermediario", _Intermediario);
            Reporte.SetParameterValue("@Supervisor", _Supervisor);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@SubRamo", _SubRamo);
            Reporte.SetParameterValue("@Usuario", _Usuario);
            Reporte.SetParameterValue("@Poliza", _Poliza);
            Reporte.SetParameterValue("@NumeroDocumento", _NumeroFactura);
            Reporte.SetParameterValue("@Moneda", _Moneda);
            Reporte.SetParameterValue("@Tipo", new Nullable<int>());
            Reporte.SetParameterValue("@Concepto", _Concepto);
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);
            Reporte.SetParameterValue("@TipoAgrupacion", TipoAgrupacion);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true)
            {

                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExcel.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
        }
        private void GenerarReporteAgrupado(int TipoAgrupacion,string Nombre) {

            int? _Intermediario = string.IsNullOrEmpty(txtCodIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodIntermediario.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodSupervisor.Text);
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
            string _Concepto = ddlSeleccionarCOncepto.SelectedValue != "-1" ? ddlSeleccionarCOncepto.SelectedItem.Text : null;
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
            string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
            decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);

            var ReporteAgrupado = ObjDataReportes.Value.BuscaDatosProduccionAgrupada(
                Convert.ToDateTime(txtFechaDesde.Text),
                Convert.ToDateTime(txtFechaHasta.Text),
                _Intermediario,
                _Supervisor,
                _Oficina,
                _Ramo,
                _SubRamo,
                _Usuario,
                _Poliza,
                _NumeroFactura,
                _Moneda,
                null,
                _Concepto,
                (decimal)Session["IdUSuario"],
                TipoAgrupacion);
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Agrupado Por" + " " + Nombre, ReporteAgrupado);
        }
        private void GenerarReporte(string NombreReporte) {

            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAcios()", "CamposFechaVAcios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {

                int? _Intermediario = string.IsNullOrEmpty(txtCodIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodIntermediario.Text);
                int? _Supervisor = string.IsNullOrEmpty(txtCodSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodSupervisor.Text);
                int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                string _Concepto = ddlSeleccionarCOncepto.SelectedValue != "-1" ? ddlSeleccionarCOncepto.SelectedItem.Text : null;
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
                string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
                decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);

                if (rbExcelPlano.Checked == true)
                {

                    if (rbNoAgruparDatos.Checked == true)
                    {

                        if (rbReporteDetallado.Checked == true)
                        {
                            var ExportarDetalle = (from n in ObjDataReportes.Value.BuscarDatosProduccion(
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                _Intermediario,
                                _Supervisor,
                                _Oficina,
                                _Ramo,
                                _SubRamo,
                                _Usuario,
                                _Poliza,
                                _NumeroFactura,
                                _Moneda,
                                null,
                                _Concepto,
                                (decimal)Session["IdUsuario"])
                                                   select new
                                                   {
                                                       Poliza = n.Poliza,
                                                       Ramo = n.Ramo,
                                                       SubRamo = n.SubRamo,
                                                       Codigo_Cliente = n.Cliente,
                                                       NombreCliente = n.NombreCliente,
                                                       Codigo_Intermediario = n.Vendedor,
                                                       NombreVendedor = n.NombreVendedor,
                                                       Codigo_Supervisor = n.CodigoSupervisor,
                                                       Supervisor = n.Supervisor,
                                                       Usuario = n.Usuario,
                                                       NombreOficina = n.NombreOficina,
                                                       FechaSinFormato = n.Fecha,
                                                       FechaFactura = n.FechaFactura,
                                                       HoraFactura = n.HoraFactura,
                                                       Numero_Comprobante = n.Ncf,
                                                       MontoBruto = n.MontoBruto,
                                                       ISC = n.ISC,
                                                       MontoNeto = n.MontoNeto,
                                                       Moneda = n.Moneda,
                                                       Factura_Sin_Formato = n.Factura,
                                                       NumeroFactura = n.NumeroFactura,
                                                       Concepto = n.Concepto,
                                                       GeneradoPor = n.GeneradoPor
                                                   }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreReporte + " " + "Detallado", ExportarDetalle);




                        }
                        else if (rbReporteResumido.Checked == true) {

                            var ProduccionResumida = (from n in ObjDataReportes.Value.BuscarDatosProduccionResumido(
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                _Intermediario,
                                _Supervisor,
                                _Oficina,
                                _Ramo,
                                _SubRamo,
                                _Usuario,
                                _Poliza,
                                _NumeroFactura,
                                _Moneda,
                                null,
                                _Concepto,
                                (decimal)Session["IdUsuario"])
                                                      select new
                                                      {
                                                          CodigoSupervisor = n.CodigoSupervisor,
                                                          Supervisor = n.Supervisor,
                                                          Ramo = n.Ramo,
                                                          Vendedor = n.Vendedor,
                                                          Intermediario = n.Intermediario,
                                                          Moneda = n.Moneda,
                                                          MontoBruto = n.MontoBruto,
                                                          ISC = n.ISC,
                                                          MontoNeto = n.MontoNeto,
                                                          GeneradoPor = n.GeneradoPor
                                                      }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreReporte + " " + "Resumido", ProduccionResumida);
                        }
                    }
                    else if (rbAgruparPorConcepto.Checked == true) {

                        GenerarReporteAgrupado((int)TipoAgrupacion.Concepto, "Concepto");
                    }
                    else if (rbAgruparPorUsuario.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Usuario, "Usuario");
                    }
                    else if (rbAgruparPorOficina.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Oficina, "Oficina");
                    }
                    else if (rbAgruparPorRamo.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Ramo, "Ramo");
                    }
                    else if (rbAgruparPorIntermediario.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Intermediario, "Intermediario");
                    }
                    else if (rbAgruparPorSupervisor.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Supervisor, "Supervisor");
                    }
                    else if (rbAgruparPorMoneda.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Moneda, "Moneda");
                    }

                }
                else {
                    if (rbNoAgruparDatos.Checked == true) {
                        if (rbReporteDetallado.Checked == true) {
                            GenerarReporteFormateado(Server.MapPath("ProduccionDetallada.rpt"), NombreReporte + " " + "Detallado");
                        }
                        else if (rbReporteResumido.Checked == true) {
                            GenerarReporteFormateado(Server.MapPath("ProduccionResumido.rpt"), NombreReporte + " " + "Resumido");
                        }
                    }
                    else if (rbAgruparPorConcepto.Checked == true) {
                        GenerarReporteAgrupadoFormateado(Server.MapPath("ProduccionAgrupado.rpt"), NombreReporte + " " + "Agrupado Por Concepto", (int)TipoAgrupacion.Concepto);
                    }
                    else if (rbAgruparPorUsuario.Checked == true) {
                        GenerarReporteAgrupadoFormateado(Server.MapPath("ProduccionAgrupado.rpt"), NombreReporte + " " + "Agrupado Por Usuario", (int)TipoAgrupacion.Usuario);
                    }
                    else if (rbAgruparPorOficina.Checked == true) {
                        GenerarReporteAgrupadoFormateado(Server.MapPath("ProduccionAgrupado.rpt"), NombreReporte + " " + "Agrupado Por Oficina", (int)TipoAgrupacion.Oficina);
                    }
                    else if (rbAgruparPorRamo.Checked == true) {
                        GenerarReporteAgrupadoFormateado(Server.MapPath("ProduccionAgrupado.rpt"), NombreReporte + " " + "Agrupado Por Ramo", (int)TipoAgrupacion.Ramo);
                    }
                    else if (rbAgruparPorIntermediario.Checked == true) {
                        GenerarReporteAgrupadoFormateado(Server.MapPath("ProduccionAgrupado.rpt"), NombreReporte + " " + "Agrupado Por Intermediario", (int)TipoAgrupacion.Intermediario);
                    }
                    else if (rbAgruparPorSupervisor.Checked == true) {
                        GenerarReporteAgrupadoFormateado(Server.MapPath("ProduccionAgrupado.rpt"), NombreReporte + " " + "Agrupado Por Supervisor", (int)TipoAgrupacion.Supervisor);
                    }
                    else if (rbAgruparPorMoneda.Checked == true) {
                        GenerarReporteAgrupadoFormateado(Server.MapPath("ProduccionAgrupado.rpt"), NombreReporte + " " + "Agrupado Por Moneda", (int)TipoAgrupacion.Moneda);
                    }
                
                
                }


            }

           
        }
        #endregion


        #region VALIDAR LOS CONTROLES DE VALIDACION
        private void LimpiarCOntrolesValidacion()
        {
            lbFechaDesdeValidacion.Text = "0";
            lbFechaHastaValidacion.Text = "0";
            lbTasaValidacion.Text = "0";
        }
        private bool ValidacionControles(string FechaDesdeEntrada, string FechaHastaEntrada, string TasaEntrada)
        {
            bool Validacion = false;

            string FechaDesdeValidar = "", FechaHastaValidar = "", TasaValidar = "";


            FechaDesdeValidar = lbFechaDesdeValidacion.Text;
            FechaHastaValidar = lbFechaHastaValidacion.Text;
            TasaValidar = lbTasaValidacion.Text;

            if (FechaDesdeValidar == FechaDesdeEntrada &&
                FechaHastaValidar == FechaHastaEntrada &&
                TasaValidar == TasaEntrada)
            {
                Validacion = true;
            }
            else
            {
                Validacion = false;
            }
            return Validacion;
        }

        private void PasarParametrosValidacion()
        {
            string FechaDesde = "", FechaHasta = "", Tasa = "";

            FechaDesde = txtFechaDesde.Text;
            FechaHasta = txtFechaHasta.Text;


            if (string.IsNullOrEmpty(txtTasa.Text.Trim()))
            {
                Tasa = "0";
            }
            else
            {
                Tasa = txtTasa.Text;
            }
            Tasa = txtTasa.Text;
            lbFechaDesdeValidacion.Text = FechaDesde;
            lbFechaHastaValidacion.Text = FechaHasta;
            lbTasaValidacion.Text = Tasa;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                rbNoAgruparDatos.Checked = true;
                rbReporteDetallado.Checked = true;
                rbPDF.Checked = true;

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR REPORTE DE PRODUCCION";

                ListaDesplegables();

                decimal Tasa = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2);
                txtTasa.Text = Tasa.ToString();
                PermisoPerfil();
            }
        }

        protected void rbNoAgruparDatos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoAgruparDatos.Checked == true) {
                DIVTipoReporte.Visible = true;
                rbReporteDetallado.Checked = true;
            }
            else if (rbNoAgruparDatos.Checked == false) {
                DIVTipoReporte.Visible = false;
                rbReporteDetallado.Checked = true;
            }
        }

        protected void txtCodIntermediario_TextChanged(object sender, EventArgs e)
        {
            string NombreIntermediario = "";
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodIntermediario.Text);
            NombreIntermediario = Nombre.SacarNombreIntermediario();
            txtNombreIntermediario.Text = NombreIntermediario;
        }

        protected void txtCodSupervisor_TextChanged(object sender, EventArgs e)
        {
            string NombreSupervisor = "";
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodSupervisor.Text);
            NombreSupervisor = Nombre.SacarNombreIntermediario();
            txtNombreSupervisor.Text = NombreSupervisor;
        }

        protected void ddlSeleccionarRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaSubRamo();
        }

        protected void btnBuscarInformacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarProduccion();
        }

        protected void btnReporteProduccion_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporte("Reporte de Producción");
        }

        protected void dtPaginacionPolizasProduccion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionPolizasProduccion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarProduccion();
        }

        protected void rbAgruparPorConcepto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorConcepto.Checked == true)
            {

                //DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
             //   DIVRecargarData.Visible = true;
              //  cbRecargarData.Checked = false;
            }
            else {
             //   DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
           //     DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorUsuario.Checked == true)
            {

            //    DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
           //     DIVRecargarData.Visible = true;
             //   cbRecargarData.Checked = false;
            }
            else
            {
              //  DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
             //   DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorOficina_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorOficina.Checked == true)
            {

               // DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
              //  DIVRecargarData.Visible = true;
               // cbRecargarData.Checked = false;
            }
            else
            {
               // DIVTipoReporteGenerar.Visible = true;
              //  HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorRamo.Checked == true)
            {

              //  DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
             //   DIVRecargarData.Visible = true;
              //  cbRecargarData.Checked = false;
            }
            else
            {
             //   DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorIntermediario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorIntermediario.Checked == true)
            {

              //  DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
               //DIVRecargarData.Visible = true;
               // cbRecargarData.Checked = false;
            }
            else
            {
               // DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorSupervisor.Checked == true)
            {

               // DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
               // DIVRecargarData.Visible = true;
              //  cbRecargarData.Checked = false;
            }
            else
            {
               // DIVTipoReporteGenerar.Visible = true;
              //  HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorMoneda_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorMoneda.Checked == true)
            {

                //DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
               // DIVRecargarData.Visible = true;
               // cbRecargarData.Checked = false;
            }
            else
            {
               // DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void btnPrimeraPaginaPaginacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarProduccion();
        }

        protected void btnPaginaAnteriorPaginacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarProduccion();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableProduccion, ref lbCantidadPaginaVAriableProduccion);
        }

        protected void btnPaginaSiguientePaginacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostrarProduccion();
        }

        protected void btnUltimaPaginaPaginacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarProduccion();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActualVariableProduccion, ref lbCantidadPaginaVAriableProduccion);
        }
    }
}
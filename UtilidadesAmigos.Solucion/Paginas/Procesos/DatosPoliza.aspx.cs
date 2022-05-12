using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class DatosPoliza : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

        /// <summary>
        /// Esta Enumeracion detalla los tipos de busqueda para buscar información ya sea para buscar por placa o por chasis.
        /// </summary>
        enum TipoDatosOtrosFiltros { 
        BuscarPorChasis=1,
        BuscarPorPlaca=2
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
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


            //    divPaginacionDetalle.Visible = true;
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
        private void BuscarDatosPolizas()
        {

            string _Poliza = string.IsNullOrEmpty(txtIngresarPolizaConsulta.Text.Trim()) ? null : txtIngresarPolizaConsulta.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtIngresarItemConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIngresarItemConsulta.Text);

            var SacarDatoPoliza = Objdata.Value.SacarDatosDatosPoliza(
                _Poliza,
                _Item);
            if (SacarDatoPoliza.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "RegistronoEncontrado()", "RegistronoEncontrado();", true);
            }
            else
            {
                int CantidadRegistros = SacarDatoPoliza.Count;
                lbCantidadRegistrosBloquePrincipalVariable.Text = CantidadRegistros.ToString("N0");
                Paginar(ref rpListadoPrincipal, SacarDatoPoliza, 10, ref lbCantidadPaginaVariableBloquePrincipal, ref LinkPrimeraPaginaBloquePrincipal, ref LinkAnteriorBloquePrincipal, ref LinkSiguienteBloquePrincipal, ref LinkUltimoBloquePrincipal);
                HandlePaging(ref dtPaginacionBloquePrincipal, ref LinkBlbPaginaActualVariableBloquePrincipal);
            }


        }

        private void RestablecerPantallaBloquePrincipal() {
            BuscarDatosPolizas();
            DIVBloqueDecision.Visible = false;
            BloqueControlesPrincipales.Visible = false;
        }

        private void ModificarPrima_Vigencia() {

            if (cbModificarValor.Checked == true) {
                try {
                    if (string.IsNullOrEmpty(txtDetallePrimaNuevaPrincipal.Text.Trim())) {
                        ClientScript.RegisterStartupScript(GetType(), "CampoPrimaVacio()", "CampoPrimaVacio();", true);
                    }
                    else {
                        UtilidadesAmigos.Logica.Entidades.ECambiaValorPolizaCondiciones Actualizar = new Logica.Entidades.ECambiaValorPolizaCondiciones();

                        Actualizar.Cotizacion = Convert.ToDecimal(lbCotizacion.Text);
                        Actualizar.Secuencia = Convert.ToInt32(txtIngresarItem.Text);
                        Actualizar.Neto = Convert.ToDecimal(txtDetallePrimaNuevaPrincipal.Text);
                        Actualizar.MontoImpuesto = 0;
                        Actualizar.PrimaBruta = 0;

                        var MAn = Objdata.Value.CambiaValorPolizaCOndicion(Actualizar, "UPDATE");
                        RestablecerPantallaBloquePrincipal();
                    }
                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorAlCambiarPrima()", "ErrorAlCambiarPrima();", true);
                }
            
            }

            if (cbModificarVigencia.Checked == true) {
                try {
                    if (string.IsNullOrEmpty(txtDetalleInicioVigencia.Text.Trim()) || string.IsNullOrEmpty(txtDetalleFechaFinVigencia.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "CamposVigenciaVacios()", "CamposVigenciaVacios();", true);

                        if (string.IsNullOrEmpty(txtDetalleInicioVigencia.Text.Trim())) {
                            ClientScript.RegisterStartupScript(GetType(), "CampoInicioVigenciaVacio()", "CampoInicioVigenciaVacio();", true);
                        }
                        if (string.IsNullOrEmpty(txtDetalleFechaFinVigencia.Text.Trim())) {
                            ClientScript.RegisterStartupScript(GetType(), "CampoFINVigenciaVacio()", "CampoFINVigenciaVacio();", true);
                        }
                    }
                    else {
                        UtilidadesAmigos.Logica.Entidades.EModificarVigenciaPoliza Modificar = new Logica.Entidades.EModificarVigenciaPoliza();

                        Modificar.Cotizacion = Convert.ToDecimal(lbCotizacion.Text);
                        Modificar.Secuencia = Convert.ToInt32(txtIngresarItem.Text);
                        Modificar.FechaInicioVigencia = Convert.ToDateTime(txtDetalleInicioVigencia.Text);
                        Modificar.FechaFinVigencia = Convert.ToDateTime(txtDetalleFechaFinVigencia.Text);

                        var MAn = Objdata.Value.CambiaVigenciaPoliza(Modificar, "UPDATE");
                        RestablecerPantallaBloquePrincipal();
                    }



                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorCambioVigencia()", "ErrorCambioVigencia();", true);
                }
            }
        }

        private void MostrarCoberturas(string NumeroPoliza, int NumeroItem)
        {

            var Listado = Objdata.Value.BuscarCoberturaPolizas(
                NumeroPoliza,
                NumeroItem,
                null);
            Paginar(ref rpListadoCoberturasItem, Listado, 10, ref lbCantidadPaginaVariableCoberturas, ref LinkPrimeraPaginaCoberturas, ref LinkAnteriorCoberturas, ref LinkSiguienteCoberturas, ref LinkUltimoCoberturas);
            HandlePaging(ref dtPaginacionCoberturas, ref LinkBlbPaginaActualVariableCoberturas);
        }

        #region MODIFICAR DATA COBERTURA
        private void ModificarCobertura()
        {

            try
            {
                // decimal Cotizacion = UtilidadesAmigos.Logica.Comunes.coti
                UtilidadesAmigos.Logica.ProcesoInformacion.ProcesarInformacionModificarCoberturaPoliza Procesar = new Logica.ProcesoInformacion.ProcesarInformacionModificarCoberturaPoliza(
                    30,
                    UtilidadesAmigos.Logica.Comunes.SacarNumeroCotizacionPoliza.SacarNumeroCotiacion(lbPolizaModificarCobertura.Text),
                    0, 0,
                    Convert.ToInt32(lbsecuenciaCotModificarCobertura.Text),
                    Convert.ToInt32(lbSecuenciaModificarCobertura.Text),
                    txtNombreCoberturaSeleccionada.Text,
                    txtLimiteCoberturaSeleccionada.Text,
                    "S",
                    0,
                    0,
                    Convert.ToDecimal(txtPorcientoDeducibleCoberturaSeleccionada.Text),
                    Convert.ToDecimal(txtMinimoDeducibleCoberturaSeleccionada.Text),
                    "",
                    Convert.ToDecimal(txtPorcientoCoberturaCoberturaSeleccionada.Text),
                    0, "UPDATE");
                Procesar.ModificarCoberturas();


              
            }
            catch (Exception) { }
        }
        #endregion

        private void BusquedaOtrosFiltros() {

            int TipoBusqueda = 0;
            if (rbBuscarPorChasis.Checked == true) {
                TipoBusqueda = (int)TipoDatosOtrosFiltros.BuscarPorChasis;
            }
            else if (rbBuscarPorPlaca.Checked == true) {
                TipoBusqueda = (int)TipoDatosOtrosFiltros.BuscarPorPlaca;
            }

            string _DatoBusqurda = string.IsNullOrEmpty(txtCampoOtroFiltro.Text.Trim()) ? null : txtCampoOtroFiltro.Text.Trim();

            var BuscarOtrosFiltros = Objdata.Value.BuscaOtrosTipoFiltros(
                _DatoBusqurda,
                TipoBusqueda,
                null, null);
            int CantidadRegistros = BuscarOtrosFiltros.Count;
            lbCantidadRegistrosVariableOtrosFiltros.Text = CantidadRegistros.ToString();
            Paginar(ref rpListadoOtrosFiltros, BuscarOtrosFiltros, 10, ref lbCantidadPaginaVariableOtrosFiltros, ref LinkPrimeraPaginaOtrosFiltros, ref LinkAnteriorOtrosFiltros, ref LinkSiguienteOtrosFiltros, ref LinkUltimoOtrosFiltros);
            HandlePaging(ref dtPaginacionOtrosFiltros, ref LinkBlbPaginaActualVariableOtrosFiltros);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbUsuarioConectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "DATOS DE POLIZA";
                rbBuscarPorPlaca.Checked = true;
                PermisoPerfil();
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {
            RestablecerPantallaBloquePrincipal();
            BuscarDatosPolizas();
        }

        protected void btnDetallePrincipal_Click(object sender, EventArgs e)
        {
            var PolizaListadoPrncipalSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfPolizaListadoPrncipal = ((HiddenField)PolizaListadoPrncipalSeleccionado.FindControl("hfPolizaListadoPrncipal")).Value.ToString();

            var NumeroItemPrincipalSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfNumeroItemPrincipal = ((HiddenField)NumeroItemPrincipalSeleccionado.FindControl("hfNumeroItemPrincipal")).Value.ToString();

            var BuscarRegistroSeleccionado = Objdata.Value.SacarDatosDatosPoliza(
                hfPolizaListadoPrncipal, Convert.ToInt32(hfNumeroItemPrincipal));
            lbCantidadRegistrosBloquePrincipalVariable.Text = "1";
            Paginar(ref rpListadoPrincipal, BuscarRegistroSeleccionado, 1, ref lbCantidadPaginaVariableBloquePrincipal, ref LinkPrimeraPaginaBloquePrincipal, ref LinkAnteriorBloquePrincipal, ref LinkSiguienteBloquePrincipal, ref LinkUltimoBloquePrincipal);
            HandlePaging(ref dtPaginacionBloquePrincipal, ref LinkBlbPaginaActualVariableBloquePrincipal);

            DIVBloqueDecision.Visible = true;
            BloqueControlesPrincipales.Visible = true;
            rbDetallePoliza.Checked = true;

            cbModificarValor.Checked = false;
            cbModificarVigencia.Checked = false;
            DivPrimaNueva.Visible = false;
            DivFechaInicioVigencia.Visible = false;
            DivFechaFinVigencia.Visible = false;

            string NumeroPolizaSeleccionado = "";
            int NumeroItemSeleccionado = 0;

            //RECORREMOS Y SACAMOS LAS INFORMACION
            foreach (var n in BuscarRegistroSeleccionado) {
                txtDetalleRamoPrincipal.Text = n.Ramo;
                txtDetalleSubramoPrincipal.Text = n.SubRamo;
                txtDetalleInicioVigenciaPrincipal.Text = n.InicioVigencia;
                txtDetalleFinVigenciaPrincipal.Text = n.FinVigencia;
                txtDetalleTipoVehiculoPrincipal.Text = n.Tipo;
                txtDetalleMarcaPrincipal.Text = n.Marca;
                txtDetalleModeloPrincipal.Text = n.Modelo;
                txtDetalleColorPrincipal.Text = n.Color;
                txtDetalleChasisPrincipal.Text = n.Chasis;
                txtDetallePlacaprincipal.Text = n.Placa;
                decimal ValorAsegurado = (decimal)n.Valor;
                txtDetalleValorAseguradoPrinncipal.Text = ValorAsegurado.ToString("N2");
                txtDetalleFianzaPrincipal.Text = n.Fianza;
                txtDetalleAseguradoPrincipal.Text = n.Asegurado;
                txtDetalleClientePrincipal.Text = n.Cliente;
                decimal Neto = (decimal)n.Neto;
                txtDetallePrimaActualPrincipal.Text = Neto.ToString("N2");


                lbCotizacion.Text = n.Cotizacion.ToString();
                txtIngresarItem.Text = n.Item.ToString();

                NumeroPolizaSeleccionado = n.Poliza;
                NumeroItemSeleccionado = n.Item;
            }

            MostrarCoberturas(NumeroPolizaSeleccionado, NumeroItemSeleccionado);
        }

        protected void LinkPrimeraPaginaBloquePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BuscarDatosPolizas();
        }

        protected void LinkAnteriorBloquePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            BuscarDatosPolizas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariableBloquePrincipal, ref lbCantidadPaginaVariableBloquePrincipal);
        }

        protected void dtPaginacionBloquePrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionBloquePrincipal_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BuscarDatosPolizas();
        }

        protected void LinkSiguienteBloquePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BuscarDatosPolizas();

        }

        protected void LinkUltimoBloquePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BuscarDatosPolizas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariableBloquePrincipal, ref lbCantidadPaginaVariableBloquePrincipal);
        }

        protected void cbModificarValor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarValor.Checked == true) {
                DivPrimaNueva.Visible = true;
                txtDetallePrimaNuevaPrincipal.Text = string.Empty;
            }
            else {
                DivPrimaNueva.Visible = false;
            }
        }

        protected void cbModificarVigencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarVigencia.Checked == true) {
                DivFechaInicioVigencia.Visible = true;
                DivFechaFinVigencia.Visible = true;

                txtDetalleInicioVigencia.Text = string.Empty;
                txtDetalleFechaFinVigencia.Text = string.Empty;
            }
            else {
                DivFechaInicioVigencia.Visible = false;
                DivFechaFinVigencia.Visible = false;
            }
        }

        protected void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            if (cbModificarValor.Checked == false && cbModificarVigencia.Checked == false) {
                ClientScript.RegisterStartupScript(GetType(), "SeleccionarOpcionDetalle()", "SeleccionarOpcionDetalle();", true);
            }
            else {
                ModificarPrima_Vigencia();
            }
        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            RestablecerPantallaBloquePrincipal();
        }

        protected void rbDetallePoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDetallePoliza.Checked == true) {
                BloqueControlesPrincipales.Visible = true;
                DivBloqieCoberturas.Visible = false;

                DivFechaFinVigencia.Visible = false;
                DivFechaInicioVigencia.Visible = false;
                DivPrimaNueva.Visible = false;
                rbDetallePoliza.Checked = false;
                rbCoberturasPolizas.Checked = false;
            }
            else {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = false;
            }
        }

        protected void rbCoberturasPolizas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoberturasPolizas.Checked == true) {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = true;
                btnModificarCoberturas.Enabled = false;
            }
            else {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = false;
            }
        }

        protected void btnseleccionarCoberturas_Click(object sender, EventArgs e)
        {
            var NumeroPolizaCobertura = (RepeaterItem)((Button)sender).NamingContainer;
            var hfNumeroPolizaCobertura = ((HiddenField)NumeroPolizaCobertura.FindControl("hfNumeroPolizaCobertura")).Value.ToString();

            var NumeroItemCobertura = (RepeaterItem)((Button)sender).NamingContainer;
            var hfNumeroItemCobertura = ((HiddenField)NumeroItemCobertura.FindControl("hfNumeroItemCobertura")).Value.ToString();

            var CodigoCobertura = (RepeaterItem)((Button)sender).NamingContainer;
            var hfCodigoCobertura = ((HiddenField)CodigoCobertura.FindControl("hfCodigoCobertura")).Value.ToString();

            var BuscarInformacion = Objdata.Value.BuscarCoberturaPolizas(
                hfNumeroPolizaCobertura,
                Convert.ToInt32(hfNumeroItemCobertura),
                Convert.ToInt32(hfCodigoCobertura));
            foreach (var n in BuscarInformacion) {
                txtNombreCoberturaSeleccionada.Text = n.Descripcion;
                txtLimiteCoberturaSeleccionada.Text = n.MontoInformativo;
                txtPorcientoDeducibleCoberturaSeleccionada.Text = n.PorcDeducible.ToString();
                txtMinimoDeducibleCoberturaSeleccionada.Text = n.MinimoDeducible.ToString();
                txtPorcientoCoberturaCoberturaSeleccionada.Text = n.PorcCobertura.ToString();

                lbPolizaModificarCobertura.Text = n.Poliza;
                lbsecuenciaCotModificarCobertura.Text = n.SecuenciaCot.ToString();
                lbSecuenciaModificarCobertura.Text = n.Secuencia.ToString();


                btnModificarCoberturas.Enabled = true;
            }
        }

        protected void LinkPrimeraPaginaCoberturas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarCoberturas(lbPolizaModificarCobertura.Text, Convert.ToInt32(lbsecuenciaCotModificarCobertura.Text));

        }

        protected void LinkAnteriorCoberturas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarCoberturas(lbPolizaModificarCobertura.Text, Convert.ToInt32(lbsecuenciaCotModificarCobertura.Text));
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariableCoberturas, ref lbCantidadPaginaVariableCoberturas);


        }

        protected void dtPaginacionCoberturas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCoberturas_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarCoberturas(lbPolizaModificarCobertura.Text, Convert.ToInt32(lbsecuenciaCotModificarCobertura.Text));
        }

        protected void LinkSiguienteCoberturas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarCoberturas(lbPolizaModificarCobertura.Text, Convert.ToInt32(lbsecuenciaCotModificarCobertura.Text));
        }

        protected void LinkUltimoCoberturas_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarCoberturas(lbPolizaModificarCobertura.Text, Convert.ToInt32(lbsecuenciaCotModificarCobertura.Text));
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariableCoberturas, ref lbCantidadPaginaVariableCoberturas);


        }

        protected void rbBuscarPorPlaca_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbBuscarPorChasis_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarotrosFiltros_Click(object sender, EventArgs e)
        {
            BusquedaOtrosFiltros();
        }

        protected void btnDetalleOtrosFiltros_Click(object sender, EventArgs e)
        {
            var PolizaOtrosFiltros = (RepeaterItem)((Button)sender).NamingContainer;
            var hfPolizaOtrosFiltros = ((HiddenField)PolizaOtrosFiltros.FindControl("hfPolizaOtrosFiltros")).Value.ToString();

            var ItemOtrosFiltros = (RepeaterItem)((Button)sender).NamingContainer;
            var hfItemOtrosFiltros = ((HiddenField)PolizaOtrosFiltros.FindControl("hfItemOtrosFiltros")).Value.ToString();

            DivBloqueDetalleOtrosFiltros.Visible = true;

            var SacarDatoPoliza = Objdata.Value.SacarDatosDatosPoliza(
               hfPolizaOtrosFiltros,
               Convert.ToInt32(hfItemOtrosFiltros));

            int CantidadRegistros = SacarDatoPoliza.Count;
            lbCantidadRegistrosVariableOtrosFiltros.Text = CantidadRegistros.ToString("N0");
            Paginar(ref rpListadoOtrosFiltros, SacarDatoPoliza, 10, ref lbCantidadPaginaVariableOtrosFiltros, ref LinkPrimeraPaginaOtrosFiltros, ref LinkAnteriorOtrosFiltros, ref LinkSiguienteOtrosFiltros, ref LinkUltimoOtrosFiltros);
            HandlePaging(ref dtPaginacionOtrosFiltros, ref LinkBlbPaginaActualVariableOtrosFiltros);
            foreach (var n in SacarDatoPoliza) {

                txtDetalleRamoOtrosFiltros.Text = n.Ramo;
                txtDetalleSubramoOtrosFiltros.Text = n.SubRamo;
                txtDetalleInicioVigenciaOtrosFiltros.Text = n.InicioVigencia;
                txtDetalleFinVigenciaOtrosFiltros.Text = n.FinVigencia;
                txtDetalleTipoVehiculoOtrosFiltros.Text = n.Tipo;
                txtDetalleMarcaOtrosFiltros.Text = n.Marca;
                txtDetalleModeloOtrosFiltros.Text = n.Modelo;
                txtDetalleColorOtrosFiltros.Text = n.Color;
                txtDetalleChasisOtrosFiltros.Text = n.Chasis;
                txtDetallePlacaOtrosFiltros.Text = n.Placa;
                decimal ValorAsegurado = (decimal)n.Valor;
                txtDetalleValorAseguradoOtrosFiltros.Text = ValorAsegurado.ToString("N2");
                txtDetalleFianzaOtrosFiltros.Text = n.Fianza;
                txtDetalleAseguradoOtrosFiltros.Text = n.Asegurado;
                txtDetalleClienteOtrosFiltros.Text = n.Cliente;
                decimal Prima = (decimal)n.Neto;
                txtDetallePrimaActualOtrosFiltros.Text = Prima.ToString("N2");
            }
        }

        protected void LinkPrimeraPaginaOtrosFiltros_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BusquedaOtrosFiltros();

        }

        protected void LinkAnteriorOtrosFiltros_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            BusquedaOtrosFiltros();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariableOtrosFiltros, ref lbCantidadPaginaVariableOtrosFiltros);

        }

        protected void dtPaginacionOtrosFiltros_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionOtrosFiltros_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BusquedaOtrosFiltros();

        }

        protected void LinkSiguienteOtrosFiltros_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BusquedaOtrosFiltros();

        }

        protected void LinkUltimoOtrosFiltros_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BusquedaOtrosFiltros();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariableOtrosFiltros, ref lbCantidadPaginaVariableOtrosFiltros);


        }

        protected void btnModificarCoberturas_Click(object sender, EventArgs e)
        {
            ModificarCobertura();
            MostrarCoberturas(lbPolizaModificarCobertura.Text, Convert.ToInt32(lbsecuenciaCotModificarCobertura.Text));
            btnModificarCoberturas.Enabled = false;
        }

        protected void btnVolverAtrasCobertura_Click(object sender, EventArgs e)
        {
           
            rbDetallePoliza.Checked = true;
            BloqueControlesPrincipales.Visible = true;
            DivBloqieCoberturas.Visible = false;

            DivFechaFinVigencia.Visible = false;
            DivFechaInicioVigencia.Visible = false;
            DivPrimaNueva.Visible = false;
            rbDetallePoliza.Checked = false;
            rbCoberturasPolizas.Checked = false;
            RestablecerPantallaBloquePrincipal();
        }

        protected void btnVolverAtrasOtrosFiltros_Click(object sender, EventArgs e)
        {
            DivBloqueDetalleOtrosFiltros.Visible = false;
        }
    }
}
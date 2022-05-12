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

namespace UtilidadesAmigos.Solucion.Paginas.Suministro
{
    public partial class AdministracionSuministro : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro> ObjDataSuministro = new Lazy<Logica.Logica.LogicaSuministro.LogicaSuministro>();

        #region CONTROL DE PAGINACION DEL INVENTARIO
        readonly PagedDataSource pagedDataSourceInventario = new PagedDataSource();
        int _PrimeraPagina_Inventario, _UltimaPagina_Inventario;
        private int _TamanioPagina_Inventario = 10;
        private int CurrentPage_Inventario
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

        private void HandlePagingInventario(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Inventario = CurrentPage_Inventario - 5;
            if (CurrentPage_Inventario > 5)
                _UltimaPagina_Inventario = CurrentPage_Inventario + 5;
            else
                _UltimaPagina_Inventario = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Inventario > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Inventario = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Inventario = _UltimaPagina_Inventario - 10;
            }

            if (_PrimeraPagina_Inventario < 0)
                _PrimeraPagina_Inventario = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Inventario;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Inventario; i < _UltimaPagina_Inventario; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void PaginarInventario(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSourceInventario.DataSource = Listado;
            pagedDataSourceInventario.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSourceInventario.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSourceInventario.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSourceInventario.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Inventario : _NumeroRegistros);
            pagedDataSourceInventario.CurrentPageIndex = CurrentPage_Inventario;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSourceInventario.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSourceInventario.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSourceInventario.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSourceInventario.IsLastPage;

            RptGrid.DataSource = pagedDataSourceInventario;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValoresInventario
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacionInventario(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE LAS SOLICITUDES
        readonly PagedDataSource pagedDataSourceSolicitudes = new PagedDataSource();
        int _PrimeraPagina_Solicitudes, _UltimaPagina_Solicitudes;
        private int _TamanioPagina_Solicitudes = 10;
        private int CurrentPage_Solicitudes
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

        private void HandlePaging_Solicitudes(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Solicitudes = CurrentPage_Solicitudes - 5;
            if (CurrentPage_Solicitudes > 5)
                _UltimaPagina_Solicitudes = CurrentPage_Solicitudes + 5;
            else
                _UltimaPagina_Solicitudes = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Solicitudes > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Solicitudes = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Solicitudes = _UltimaPagina_Solicitudes - 10;
            }

            if (_PrimeraPagina_Solicitudes < 0)
                _PrimeraPagina_Solicitudes = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Solicitudes;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Solicitudes; i < _UltimaPagina_Solicitudes; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Solicitudes(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSourceSolicitudes.DataSource = Listado;
            pagedDataSourceSolicitudes.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSourceSolicitudes.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSourceSolicitudes.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSourceSolicitudes.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Solicitudes : _NumeroRegistros);
            pagedDataSourceSolicitudes.CurrentPageIndex = CurrentPage_Solicitudes;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSourceSolicitudes.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSourceSolicitudes.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSourceSolicitudes.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSourceSolicitudes.IsLastPage;

            RptGrid.DataSource = pagedDataSourceSolicitudes;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Solicitudes
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Solicitudes(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CONTROL DE PAGINACION DE LAS SOLICITUDES DETALLE
        readonly PagedDataSource pagedDataSource_SolicitudesDetalle = new PagedDataSource();
        int _PrimeraPagina_SolicitudesDetalle, _UltimaPagina_SolicitudesDetalle;
        private int _TamanioPagina_SolicitudesDetalle = 10;
        private int CurrentPage_SolicitudesDetalle
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

        private void HandlePaging_SolicitudesDetalle(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_SolicitudesDetalle = CurrentPage_SolicitudesDetalle - 5;
            if (CurrentPage_Solicitudes > 5)
                _UltimaPagina_SolicitudesDetalle = CurrentPage_SolicitudesDetalle + 5;
            else
                _UltimaPagina_SolicitudesDetalle = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_SolicitudesDetalle > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_SolicitudesDetalle = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_SolicitudesDetalle = _UltimaPagina_SolicitudesDetalle - 10;
            }

            if (_PrimeraPagina_SolicitudesDetalle < 0)
                _PrimeraPagina_SolicitudesDetalle = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_SolicitudesDetalle;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_SolicitudesDetalle; i < _UltimaPagina_SolicitudesDetalle; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_SolicitudesDetalle(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_SolicitudesDetalle.DataSource = Listado;
            pagedDataSource_SolicitudesDetalle.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_SolicitudesDetalle.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_SolicitudesDetalle.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_SolicitudesDetalle.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_SolicitudesDetalle : _NumeroRegistros);
            pagedDataSource_SolicitudesDetalle.CurrentPageIndex = CurrentPage_SolicitudesDetalle;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_SolicitudesDetalle.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_SolicitudesDetalle.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_SolicitudesDetalle.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_SolicitudesDetalle.IsLastPage;

            RptGrid.DataSource = pagedDataSource_SolicitudesDetalle;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_SolicitudesDetalle
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_SolicitudesDetalle(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CONFIGURACION INICIAL DE LA PANTALLA DE INVENTARIO
        private void ConfiguracionInicialPantallaInventario() {

            DIVBloqueConsultaInventario.Visible = true;
            DIVBloqueMantenimientoInventario.Visible = false;
            DIVBloqueSuplirInventario.Visible = false;

            txtDescripcionConsultaInventario.Text = string.Empty;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMedida, ObjData.Value.BuscaListas("SUMINISTROTIPOMEDIDA", null, null), true);

            rbEstatusTodos.Checked = true;
            btnConsultarInventario.Visible = true;
            btnNuevoRegistro.Visible = true;
            btnReporte.Visible = true;
            btnSuplirInventario.Visible = false;
            btnEditarInventario.Visible = false;
            btnEliminarInventario.Visible = false;
            btnRestablecerPantalla.Visible = false;
            rpListadoInventario.DataSource = null;
            rpListadoInventario.DataBind();
            CurrentPage_Inventario = 0;
            divPaginacionInventario.Visible = true;
            DesbloquearControlesInventario();
        }
        #endregion

        #region CONFIGURACION INICIAL DE LA PANTALLA DE SOLICITUDES
        private void ConfiguracionInicialSolicitudes() {
            txtNumeroSolicitudConsulta.Text = string.Empty;
            txtPersonaConsulta.Text = string.Empty;
            txtFechaDesdeConsulta.Text = string.Empty;
            txtFechahastaConsulta.Text = string.Empty;

            rbTodosLosRegistros.Checked = true;

            rpListadoSolicitudes.DataSource = null;
            rpListadoSolicitudes.DataBind();

            BloqueArticulosSeleccionados.Visible = false;

            rpListadoArticulosSolicitud.DataSource = null;
            rpListadoArticulosSolicitud.DataBind();

        }
        #endregion

        #region MOSTRAR EL INVENTARIO
        private void MostrarInventario() {

            string _Articulo = string.IsNullOrEmpty(txtDescripcionConsultaInventario.Text.Trim()) ? null : txtDescripcionConsultaInventario.Text.Trim();
            int? _IdMedida = ddlSeleccionarMedida.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMedida.SelectedValue) : new Nullable<int>();
            string _Estatus = "";

            if (rbEstatusTodos.Checked == true) { _Estatus = null; }
            else if (rbEstatusDisponible.Checked == true) { _Estatus = "DISPONIBLE"; }
            else if (rbEstatusPocos.Checked == true) { _Estatus = "PROXIMO AGOTARSE"; }
            else if (rbEstatusAgotados.Checked == true) { _Estatus = "AGOTADO"; }
            else { _Estatus = null; }

            var Inventario = ObjDataSuministro.Value.BuscaInventarioSuministro(
                new Nullable<decimal>(),
                _Articulo,
                _IdMedida,
                _Estatus,
                (decimal)Session["IdUSuario"]);
            if (Inventario.Count() < 1) {
                rpListadoInventario.DataSource = null;
                rpListadoInventario.DataBind();
            }
            else {
                PaginarInventario(ref rpListadoInventario, Inventario, 10, ref lbCantidadPaginaVAriableInventario, ref btnkPrimeraPaginaInventario, ref btnAnteriorInventario, ref btnSiguienteInventario, ref btnUltimoInventario);
                HandlePagingInventario(ref dtPaginacionInventario, ref lbPaginaActualVariableInventario);
            }

        }
        #endregion

        #region PROCESAR LA INFORMACION DEL INVENTARIO
        private void ProcesarInformacionInventario(decimal CodigoArticulo, int Stock, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroInventario Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroInventario(
                CodigoArticulo,
                txtArticuloMantenimientoInventario.Text,
                Convert.ToInt32(ddlSeleccionarMedidaMantenimientoInventario.SelectedValue),
                Stock,
                (decimal)Session["IdUsuario"],
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion

        #region GENERAR REPORTE DE INVENTARIO
        private void GenerarReporteInventario(string RutaReporte, string NombreReporte) {
            string _Articulo = string.IsNullOrEmpty(txtDescripcionConsultaInventario.Text.Trim()) ? null : txtDescripcionConsultaInventario.Text.Trim();
            int? _IdMedida = ddlSeleccionarMedida.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMedida.SelectedValue) : new Nullable<int>();
            string _Estatus = "";

            if (rbEstatusTodos.Checked == true) { _Estatus = null; }
            else if (rbEstatusDisponible.Checked == true) { _Estatus = "DISPONIBLE"; }
            else if (rbEstatusPocos.Checked == true) { _Estatus = "PROXIMO AGOTARSE"; }
            else if (rbEstatusAgotados.Checked == true) { _Estatus = "AGOTADO"; }
            else { _Estatus = null; }

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@CodigoArticulo", new Nullable<decimal>());
            Reporte.SetParameterValue("@Articulo", _Articulo);
            Reporte.SetParameterValue("@IdMedida", _IdMedida);
            Reporte.SetParameterValue("@Estatus", _Estatus);
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);

        }
        #endregion

        #region BLOQUEAR Y DESBLOQUEAR CONTROLES DEL INVENTARIO
        private void DesbloquearControlesInventario() {

            txtArticuloMantenimientoInventario.Enabled = true;
            ddlSeleccionarMedidaMantenimientoInventario.Enabled = true;
            txtStockMantenimientoInventario.Enabled = true;
        }

        private void BloquearControlesInventario() {
            txtArticuloMantenimientoInventario.Enabled = false;
            ddlSeleccionarMedidaMantenimientoInventario.Enabled = false;
            txtStockMantenimientoInventario.Enabled = false;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "ADMINISTRACION DE SUMINISTRO";

                DIVBloqueConsulta.Visible = true;
                DIVBloqueInventario.Visible = false;

                rbSolicitudes.Checked = true;
                ConfiguracionInicialSolicitudes();
            }
        }

        protected void rbSolicitudes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSolicitudes.Checked == true) {
                DIVBloqueConsulta.Visible = true;
                DIVBloqueInventario.Visible = false;
                ConfiguracionInicialSolicitudes();
            }
            else {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = false;
            }
        }

        protected void rbInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInventario.Checked == true)
            {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = true;
                ConfiguracionInicialPantallaInventario();
            }
            else
            {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = false;
            }
        }

        protected void btnBuscarInformacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnkPrimeraPaginaEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionEncabezadoSolicitud_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionEncabezadoSolicitud_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEliminarArticulo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnkPrimeraPaginaArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionArticulosSeleccionado_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionArticulosSeleccionado_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnConsultarInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsultaInventario.Visible = false;
            DIVBloqueMantenimientoInventario.Visible = true;
            DIVBloqueSuplirInventario.Visible = false;
            lbAccionInventario.Text = "INSERT";
            lbCodigoArticuloInventarioSeleccionado.Text = "0";
            txtArticuloMantenimientoInventario.Text = string.Empty;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMedidaMantenimientoInventario, ObjData.Value.BuscaListas("SUMINISTROTIPOMEDIDA", null, null));
            txtStockMantenimientoInventario.Text = string.Empty;
        }

        protected void btnReporteInventario_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporteInventario(Server.MapPath("ReporteSuministroInventario.rpt"), "Reporte de Inventario");
        }

        protected void btnSuplirInventario_Click(object sender, ImageClickEventArgs e)
        {
            rbIngresarProductos.Checked = true;
            lbAccionInventario.Text = "SUPPLIINVENTORY";
            DIVBloqueConsultaInventario.Visible = false;
            DIVBloqueMantenimientoInventario.Visible = false;
            DIVBloqueSuplirInventario.Visible = true;
            rbIngresarProductos.Checked = true;
            txtCantidadSupliorSacar.Text = string.Empty;
        }

        protected void btnEditarInventario_Click(object sender, ImageClickEventArgs e)
        {
            lbAccionInventario.Text = "UPDATE";
            DIVBloqueConsultaInventario.Visible = false;
            DIVBloqueMantenimientoInventario.Visible = true;
            DIVBloqueSuplirInventario.Visible = false;
        }

        protected void btnEliminarInventario_Click(object sender, ImageClickEventArgs e)
        {
            lbAccionInventario.Text = "DELETE";
            DIVBloqueConsultaInventario.Visible = false;
            DIVBloqueMantenimientoInventario.Visible = true;
            DIVBloqueSuplirInventario.Visible = false;
            BloquearControlesInventario();
        }

        protected void btnRestablecerPantalla_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicialPantallaInventario();
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void btnSeleccionarArticuloINventario_Click(object sender, ImageClickEventArgs e)
        {
            var CodigoArticulo = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfCodigoArticulo = ((HiddenField)CodigoArticulo.FindControl("hfCodigoArticulo")).Value.ToString();
            lbCodigoArticuloInventarioSeleccionado.Text = hfCodigoArticulo;

            var BuscarRegistroSeleccionado = ObjDataSuministro.Value.BuscaInventarioSuministro(Convert.ToDecimal(hfCodigoArticulo));
            foreach (var n in BuscarRegistroSeleccionado) {
                txtArticuloMantenimientoInventario.Text = n.Articulo;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMedidaMantenimientoInventario, ObjData.Value.BuscaListas("SUMINISTROTIPOMEDIDA", null, null));
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarMedidaMantenimientoInventario, n.IdMedida.ToString());
                txtStockMantenimientoInventario.Text = n.Stock.ToString();

                lbDescripcionArticuloSuplirInventarioVariable.Text = n.Articulo;
                lbMedidaSuplirInventarioVariable.Text = n.Medida;
                int Stock = (int)n.Stock;
                lbStockSuplirInventarioVariable.Text = Stock.ToString("N0");
            }
            PaginarInventario(ref rpListadoInventario, BuscarRegistroSeleccionado, 10, ref lbCantidadPaginaVAriableInventario, ref btnkPrimeraPaginaInventario, ref btnAnteriorInventario, ref btnSiguienteInventario, ref btnUltimoInventario);
            HandlePagingInventario(ref dtPaginacionInventario, ref lbPaginaActualVariableInventario);
            divPaginacionInventario.Visible = false;
            btnConsultarInventario.Visible = false;
            btnNuevoRegistro.Visible = false;
            btnReporteInventario.Visible = false;
            btnSuplirInventario.Visible = true;
            btnEditarInventario.Visible = true;
            btnEliminarInventario.Visible = true;
            btnRestablecerPantalla.Visible = true;
        }

        protected void btnkPrimeraPaginaInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void btnAnteriorInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario += -1;
            MostrarInventario();
            MoverValoresPaginacionInventario((int)OpcionesPaginacionValoresInventario.PaginaAnterior, ref lbPaginaActualVariableInventario, ref lbCantidadPaginaVAriableInventario);
        }

        protected void dtPaginacionInventario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionInventario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Inventario = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarInventario();
        }

        protected void btnSiguienteInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario += 1;
            MostrarInventario();
        }

        protected void btnUltimoInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInventario();
            MoverValoresPaginacionInventario((int)OpcionesPaginacionValoresInventario.UltimaPagina, ref lbPaginaActualVariableInventario, ref lbCantidadPaginaVAriableInventario);
        }

        protected void btnGuardarRegistroMantenimientoInventario_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionInventario(
                Convert.ToDecimal(lbCodigoArticuloInventarioSeleccionado.Text),
                Convert.ToInt32(txtStockMantenimientoInventario.Text),
                lbAccionInventario.Text);
            ConfiguracionInicialPantallaInventario();
        }

        protected void rbIngresarProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIngresarProductos.Checked == true) {
                lbAccionInventario.Text = "SUPPLIINVENTORY";
            }
            else { }
        }

        protected void rbSacarProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSacarProductos.Checked == true) {
                lbAccionInventario.Text = "LESSINVENTORY";
            }
            else { }
        }

        protected void btnSuplirSacarProductos_Click(object sender, ImageClickEventArgs e)
        {
            if (rbIngresarProductos.Checked == true) {
                ProcesarInformacionInventario(
                        Convert.ToDecimal(lbCodigoArticuloInventarioSeleccionado.Text),
                        Convert.ToInt32(txtCantidadSupliorSacar.Text),
                        lbAccionInventario.Text);
                ConfiguracionInicialPantallaInventario();
                CurrentPage_Inventario = 0;
                txtDescripcionConsultaInventario.Text = lbDescripcionArticuloSuplirInventarioVariable.Text;
                MostrarInventario();
            }
            else if (rbSacarProductos.Checked == true) {

                int Stock = 0, CantidadNueva = 0;
                Stock = Convert.ToInt32(lbStockSuplirInventarioVariable.Text.Replace(",",""));
                CantidadNueva = Convert.ToInt32(txtCantidadSupliorSacar.Text);

                if (CantidadNueva > Stock) {
                    ClientScript.RegisterStartupScript(GetType(), "CantidadSuperiorStock()", "CantidadSuperiorStock();", true);
                }
                else {
                    ProcesarInformacionInventario(
                    Convert.ToDecimal(lbCodigoArticuloInventarioSeleccionado.Text),
                    Convert.ToInt32(txtCantidadSupliorSacar.Text),
                    lbAccionInventario.Text);
                    ConfiguracionInicialPantallaInventario();
                    CurrentPage_Inventario = 0;
                    txtDescripcionConsultaInventario.Text = lbDescripcionArticuloSuplirInventarioVariable.Text;
                    MostrarInventario();
                }
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "OpcionNovalida()", "OpcionNovalida();", true);
            }
        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicialPantallaInventario();
        }
    }
}
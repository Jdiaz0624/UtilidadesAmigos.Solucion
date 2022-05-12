using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ReporteOperacionesSospechosas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

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


        private void HandlePaging(ref DataList NombreDataList)
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
            lbPaginaActualVariableOperacionesSospechosas.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater ControlRepeater, IEnumerable<object> Listado, int _NumeroRegistros)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPaginaVariableOperacionesSospechosas.Text = pagedDataSource.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina : _NumeroRegistros);
            pagedDataSource.CurrentPageIndex = CurrentPage;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            btnPriemraPagina.Enabled = !pagedDataSource.IsFirstPage;
            btnPaginaAnterior.Enabled = !pagedDataSource.IsFirstPage;
            btnPaginasiguiente.Enabled = !pagedDataSource.IsLastPage;
            btnUltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            ControlRepeater.DataSource = pagedDataSource;
            ControlRepeater.DataBind();


            //  divPaginacionBancos.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion)
        {

            int PaginaActual = 0;
            switch (Accion)
            {

                case 1:
                    //PRIMERA PAGINA
                    lbPaginaActualVariableOperacionesSospechosas.Text = "1";

                    break;

                case 2:
                    //SEGUNDA PAGINA
                    PaginaActual = Convert.ToInt32(lbPaginaActualVariableOperacionesSospechosas.Text);
                    PaginaActual++;
                    lbPaginaActualVariableOperacionesSospechosas.Text = PaginaActual.ToString();
                    break;

                case 3:
                    //PAGINA ANTERIOR
                    PaginaActual = Convert.ToInt32(lbPaginaActualVariableOperacionesSospechosas.Text);
                    if (PaginaActual > 1)
                    {
                        PaginaActual--;
                        lbPaginaActualVariableOperacionesSospechosas.Text = PaginaActual.ToString();
                    }
                    break;

                case 4:
                    //ULTIMA PAGINA
                    lbPaginaActualVariableOperacionesSospechosas.Text = lbCantidadPaginaVariableOperacionesSospechosas.Text;
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
        enum ConceptosOperacionesSospechosas {
            OperacionesSospechosas=1,
            TransaccionesEnEfectivo=2
    }

        private void MostrarListado() {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                int TipoInformacionGenerar = Convert.ToInt32(ddlSeleccionarTipoOperacion.SelectedValue);
                decimal? UsuarioProcesa = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

                if (TipoInformacionGenerar == (int)ConceptosOperacionesSospechosas.OperacionesSospechosas)
                {
                    var MostrarListadoOperacionesSospechosas = ObjData.Value.GenerarReporteDeOperacionesSospechisas(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text),
                        UsuarioProcesa,
                        Convert.ToDecimal(txtMontoCondicion.Text),
                        null, null);
                    Paginar(ref rpListado, MostrarListadoOperacionesSospechosas, 10);
                    HandlePaging(ref dtPaginacionOperacionesSospechosas);

                    int CantidadRegistros = MostrarListadoOperacionesSospechosas.Count;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                }
                else if (TipoInformacionGenerar == (int)ConceptosOperacionesSospechosas.TransaccionesEnEfectivo)
                {

                    var MostrarListado = ObjData.Value.GenerarReporteTransaccionesEfectivo(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text),
                        UsuarioProcesa,
                        Convert.ToDecimal(txtMontoCondicion.Text),
                        null, null);
                    Paginar(ref rpListado, MostrarListado, 10);
                    HandlePaging(ref dtPaginacionOperacionesSospechosas);

                    int CantidadRegistros = MostrarListado.Count;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");


                }
            }
        }
        private void ExportarRegistros() {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                int TipoInformacionGenerar = Convert.ToInt32(ddlSeleccionarTipoOperacion.SelectedValue);
                decimal? UsuarioProcesa = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

                if (TipoInformacionGenerar == (int)ConceptosOperacionesSospechosas.OperacionesSospechosas)
                {
                    var ValidarRegistrosOperacionesSospechosas = ObjData.Value.GenerarReporteDeOperacionesSospechisas(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text),
                        UsuarioProcesa,
                        Convert.ToDecimal(txtMontoCondicion.Text),
                        null, null);
                    if (ValidarRegistrosOperacionesSospechosas.Count() < 1) {
                        GenerarArchivoVacio("Operaciones Sospechosas (ROS)");
                    }
                    else {
                        var ExportarInformacionOperacionesSospechosas = (from n in ObjData.Value.GenerarReporteDeOperacionesSospechisas(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            Convert.ToDecimal(txtTasa.Text),
                            UsuarioProcesa,
                            Convert.ToDecimal(txtMontoCondicion.Text),
                            null, null)
                                                                         select new {
                                                                             NumeroReporte = n.NumeroRecibo,
                                                                             Poliza = n.Poliza,
                                                                             CodigoRegistroEntidad = n.CodigoRegistroEntidad,
                                                                             Usuario = n.Usuario,
                                                                             Oficina = n.Oficina,
                                                                             FechaEnvio = n.FechaEnvio,
                                                                             HoraEnvio = n.HoraEnvio,
                                                                             TipoPersonaCliente = n.TipoPersonaCliente,
                                                                             PEPCliente = n.PEPCliente,
                                                                             PEPClienteTipo = n.PEPClienteTipo,
                                                                             SexoCliente = n.SexoCliente,
                                                                             NombreRazonSocialCliente = n.NombreRazonSocialCliente,
                                                                             ApellidoRazonSocialCliente = n.ApellidoRazonSocialCliente,
                                                                             NacionalidadorigenCliente = n.NacionalidadorigenCliente,
                                                                             NacionalidadAdquiridaCliente = n.NacionalidadAdquiridaCliente,
                                                                             TipoDocumentoCliente = n.TipoDocumentoCliente,
                                                                             NoDocumentoIdentidadCliente = n.NoDocumentoIdentidadCliente,
                                                                             SiTipoDocumentoIgualOtroEspesificar = n.SiTipoDocumentoIgualOtroEspesificar,
                                                                             ActividadEconomicaCliente = n.ActividadEconomicaCliente,
                                                                             TipoProductoCliente = n.TipoProductoCliente,
                                                                             NoCuenta1 = n.NoCuenta1,
                                                                             NoCuenta2 = n.NoCuenta2,
                                                                             NoCuenta3 = n.NoCuenta3,
                                                                             ProvinciaCliente = n.ProvinciaCliente,
                                                                             MunicipioCliente = n.MunicipioCliente,
                                                                             SectorCliente = n.SectorCliente,
                                                                             DireccionCliente = n.DireccionCliente,
                                                                             TelefonoCasaCliente = n.TelefonoCasaCliente,
                                                                             TelefonoOficinaCliente = n.TelefonoOficinaCliente,
                                                                             Celular1Cliente = n.Celular1Cliente,
                                                                             Celular2Cliente = n.Celular2Cliente,
                                                                             TipoTransaccion = n.TipoTransaccion,
                                                                             DescripcionTransaccion = n.DescripcionTransaccion,
                                                                             TipoMoneda = n.TipoMoneda,
                                                                             NumeroRecibo = n.NumeroRecibo,
                                                                             FechaRecibo = n.FechaRecibo,
                                                                             MontoOriginal = n.MontoOriginal,
                                                                             PagoAcumuladoPesos = n.PagoAcumuladoPesos,
                                                                             PagoAcumuladoDollar = n.PagoAcumuladoDollar,
                                                                             TasaCambio = n.TasaCambio,
                                                                             TipoInstrumento = n.TipoInstrumento,
                                                                             FechaTransaccion = n.FechaTransaccion,
                                                                             HoraTransaccion = n.HoraTransaccion,
                                                                             FechaEnvio1 = n.FechaEnvio1,
                                                                             HoraTransaccion1 = n.HoraTransaccion1,
                                                                             OrigenFondos = n.OrigenFondos,
                                                                             TransaccionRealizada = n.TransaccionRealizada,
                                                                             MotivoTransaccion = n.MotivoTransaccion,
                                                                             PaisOrigen = n.PaisOrigen,
                                                                             PaisDestino = n.PaisDestino,
                                                                             EntidadCorresponsal = n.EntidadCorresponsal,
                                                                             Remesador = n.Remesador,
                                                                             IntermediarioIgualCliente = n.IntermediarioIgualCliente,
                                                                             SexoIntermediario = n.SexoIntermediario,
                                                                             NombreRazonIntermediario = n.NombreRazonIntermediario,
                                                                             ApellidoRazonIntermediario = n.ApellidoRazonIntermediario,
                                                                             NacionalidadOrigenIntermediario = n.NacionalidadOrigenIntermediario,
                                                                             NacionalidadAdquiridaIntermediario = n.NacionalidadAdquiridaIntermediario,
                                                                             TipoRncIntermediario = n.TipoRncIntermediario,
                                                                             NoDocumentoIntermediario = n.NoDocumentoIntermediario,
                                                                             SiTipoDocumentoIgualOtroEspesificarIntermdiario = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario,
                                                                             ProvinciaIntermediario = n.ProvinciaIntermediario,
                                                                             MunicipioIntermediario = n.MunicipioIntermediario,
                                                                             SectorIntermediario = n.SectorIntermediario,
                                                                             DireccionIntermediario = n.DireccionIntermediario,
                                                                             BeneficiarioIgualCliente = n.BeneficiarioIgualCliente,
                                                                             SexoBeneficiario = n.SexoBeneficiario,
                                                                             NombreRazonSocialBeneficiario = n.NombreRazonSocialBeneficiario,
                                                                             ApellidoRazonSocialBeneficiario = n.ApellidoRazonSocialBeneficiario,
                                                                             NacionalidadBeneficiario = n.NacionalidadBeneficiario,
                                                                             NacionalidadAdquiridaBeneficiario = n.NacionalidadAdquiridaBeneficiario,
                                                                             TipoIdentificacionBeneficiario = n.TipoIdentificacionBeneficiario,
                                                                             NoDocumentoIdentidadBeneficiario = n.NoDocumentoIdentidadBeneficiario,
                                                                             SiTipoDocumentoIgualOtroEspesificar1 = n.SiTipoDocumentoIgualOtroEspesificar1,
                                                                             ProvinciaBeneficiario = n.ProvinciaBeneficiario,
                                                                             MunicipioBeneficiario = n.MunicipioBeneficiario,
                                                                             SectorBeneficiario = n.SectorBeneficiario,
                                                                             DireccionBeneficiario = n.DireccionBeneficiario,
                                                                             MotivoReporte = n.MotivoReporte,
                                                                             EspesifiquePrioridadReporte = n.EspesifiquePrioridadReporte,
                                                                             Anexo = n.Anexo,
                                                                             ValidadoDesde = n.ValidadoDesde,
                                                                             ValidadoHasta = n.ValidadoHasta,
                                                                             MontoCondicion = n.MontoCondicion,
                                                                             GeneradoPor = n.GeneradoPor
                                                                         }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Operaciones Sospechosas (ROS)", ExportarInformacionOperacionesSospechosas);
                    }

                }
                else if (TipoInformacionGenerar == (int)ConceptosOperacionesSospechosas.TransaccionesEnEfectivo)
                {
                    var MostrarListado = ObjData.Value.GenerarReporteTransaccionesEfectivo(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text),
                        UsuarioProcesa,
                        Convert.ToDecimal(txtMontoCondicion.Text),
                        null, null);
                    if (MostrarListado.Count() < 1) {
                        GenerarArchivoVacio("Transacciones En Efectivo (RTE)");
                    }
                    else
                    {
                        var ExportarInformacion = (from n in ObjData.Value.GenerarReporteTransaccionesEfectivo(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            Convert.ToDecimal(txtTasa.Text),
                            UsuarioProcesa,
                            Convert.ToDecimal(txtMontoCondicion.Text),
                            null, null)
                                                   select new
                                                   {
                                                       NumeroReporte = n.NumeroRecibo,
                                                       Poliza = n.Poliza,
                                                       CodigoRegistroEntidad = n.CodigoRegistroEntidad,
                                                       Usuario = n.Usuario,
                                                       Oficina = n.Oficina,
                                                       FechaEnvio = n.FechaEnvio,
                                                       HoraEnvio = n.HoraEnvio,
                                                       TipoPersonaCliente = n.TipoPersonaCliente,
                                                       PEPCliente = n.PEPCliente,
                                                       PEPClienteTipo = n.PEPClienteTipo,
                                                       SexoCliente = n.SexoCliente,
                                                       NombreRazonSocialCliente = n.NombreRazonSocialCliente,
                                                       ApellidoRazonSocialCliente = n.ApellidoRazonSocialCliente,
                                                       NacionalidadorigenCliente = n.NacionalidadorigenCliente,
                                                       NacionalidadAdquiridaCliente = n.NacionalidadAdquiridaCliente,
                                                       TipoDocumentoCliente = n.TipoDocumentoCliente,
                                                       NoDocumentoIdentidadCliente = n.NoDocumentoIdentidadCliente,
                                                       SiTipoDocumentoIgualOtroEspesificar = n.SiTipoDocumentoIgualOtroEspesificar,
                                                       ActividadEconomicaCliente = n.ActividadEconomicaCliente,
                                                       TipoProductoCliente = n.TipoProductoCliente,
                                                       NoCuenta1 = n.NoCuenta1,
                                                       NoCuenta2 = n.NoCuenta2,
                                                       NoCuenta3 = n.NoCuenta3,
                                                       ProvinciaCliente = n.ProvinciaCliente,
                                                       MunicipioCliente = n.MunicipioCliente,
                                                       SectorCliente = n.SectorCliente,
                                                       DireccionCliente = n.DireccionCliente,
                                                       TelefonoCasaCliente = n.TelefonoCasaCliente,
                                                       TelefonoOficinaCliente = n.TelefonoOficinaCliente,
                                                       Celular1Cliente = n.Celular1Cliente,
                                                       Celular2Cliente = n.Celular2Cliente,
                                                       TipoTransaccion = n.TipoTransaccion,
                                                       DescripcionTransaccion = n.DescripcionTransaccion,
                                                       TipoMoneda = n.TipoMoneda,
                                                       NumeroRecibo = n.NumeroRecibo,
                                                       FechaRecibo = n.FechaRecibo,
                                                       MontoOriginal = n.MontoOriginal,
                                                       PagoAcumuladoPesos = n.PagoAcumuladoPesos,
                                                       PagoAcumuladoDollar = n.PagoAcumuladoDollar,
                                                       TasaCambio = n.TasaCambio,
                                                       TipoInstrumento = n.TipoInstrumento,
                                                       FechaTransaccion = n.FechaTransaccion,
                                                       HoraTransaccion = n.HoraTransaccion,
                                                       FechaEnvio1 = n.FechaEnvio1,
                                                       HoraTransaccion1 = n.HoraTransaccion1,
                                                       OrigenFondos = n.OrigenFondos,
                                                       TransaccionRealizada = n.TransaccionRealizada,
                                                       MotivoTransaccion = n.MotivoTransaccion,
                                                       PaisOrigen = n.PaisOrigen,
                                                       PaisDestino = n.PaisDestino,
                                                       EntidadCorresponsal = n.EntidadCorresponsal,
                                                       Remesador = n.Remesador,
                                                       IntermediarioIgualCliente = n.IntermediarioIgualCliente,
                                                       SexoIntermediario = n.SexoIntermediario,
                                                       NombreRazonIntermediario = n.NombreRazonIntermediario,
                                                       ApellidoRazonIntermediario = n.ApellidoRazonIntermediario,
                                                       NacionalidadOrigenIntermediario = n.NacionalidadOrigenIntermediario,
                                                       NacionalidadAdquiridaIntermediario = n.NacionalidadAdquiridaIntermediario,
                                                       TipoRncIntermediario = n.TipoRncIntermediario,
                                                       NoDocumentoIntermediario = n.NoDocumentoIntermediario,
                                                       SiTipoDocumentoIgualOtroEspesificarIntermdiario = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario,
                                                       ProvinciaIntermediario = n.ProvinciaIntermediario,
                                                       MunicipioIntermediario = n.MunicipioIntermediario,
                                                       SectorIntermediario = n.SectorIntermediario,
                                                       DireccionIntermediario = n.DireccionIntermediario,
                                                       BeneficiarioIgualCliente = n.BeneficiarioIgualCliente,
                                                       SexoBeneficiario = n.SexoBeneficiario,
                                                       NombreRazonSocialBeneficiario = n.NombreRazonSocialBeneficiario,
                                                       ApellidoRazonSocialBeneficiario = n.ApellidoRazonSocialBeneficiario,
                                                       NacionalidadBeneficiario = n.NacionalidadBeneficiario,
                                                       NacionalidadAdquiridaBeneficiario = n.NacionalidadAdquiridaBeneficiario,
                                                       TipoIdentificacionBeneficiario = n.TipoIdentificacionBeneficiario,
                                                       NoDocumentoIdentidadBeneficiario = n.NoDocumentoIdentidadBeneficiario,
                                                       SiTipoDocumentoIgualOtroEspesificar1 = n.SiTipoDocumentoIgualOtroEspesificar1,
                                                       ProvinciaBeneficiario = n.ProvinciaBeneficiario,
                                                       MunicipioBeneficiario = n.MunicipioBeneficiario,
                                                       SectorBeneficiario = n.SectorBeneficiario,
                                                       DireccionBeneficiario = n.DireccionBeneficiario,
                                                       MotivoReporte = n.MotivoReporte,
                                                       EspesifiquePrioridadReporte = n.EspesifiquePrioridadReporte,
                                                       Anexo = n.Anexo,
                                                       ValidadoDesde = n.ValidadoDesde,
                                                       ValidadoHasta = n.ValidadoHasta,
                                                       MontoCondicion = n.MontoCondicion,
                                                       GeneradoPor = n.GeneradoPor
                                                   }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Transacciones en Efectivo (RTE)", ExportarInformacion);
                    }
                }
            }
        }
        private void SacarTasaSistema() {
            txtTasa.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
        }
        private void GenerarArchivoVacio(string NombreRegistro) {
            int Lectura = 0;
            var ListadoVacio = (from n in Lectura.ToString()
                                select new
                                {
                                    NumeroReporte = " ",
                                    Poliza = " ",
                                    CodigoRegistroEntidad = " ",
                                    Usuario = " ",
                                    Oficina = " ",
                                    FechaEnvio = " ",
                                    HoraEnvio = " ",
                                    TipoPersonaCliente = " ",
                                    PEPCliente = " ",
                                    PEPClienteTipo = " ",
                                    SexoCliente = " ",
                                    NombreRazonSocialCliente = " ",
                                    ApellidoRazonSocialCliente = " ",
                                    NacionalidadorigenCliente = " ",
                                    NacionalidadAdquiridaCliente = " ",
                                    TipoDocumentoCliente = " ",
                                    NoDocumentoIdentidadCliente = " ",
                                    SiTipoDocumentoIgualOtroEspesificar = " ",
                                    ActividadEconomicaCliente = " ",
                                    TipoProductoCliente = " ",
                                    NoCuenta1 = " ",
                                    NoCuenta2 = " ",
                                    NoCuenta3 = " ",
                                    ProvinciaCliente = " ",
                                    MunicipioCliente = " ",
                                    SectorCliente = " ",
                                    DireccionCliente = " ",
                                    TelefonoCasaCliente = " ",
                                    TelefonoOficinaCliente = " ",
                                    Celular1Cliente = " ",
                                    Celular2Cliente = " ",
                                    TipoTransaccion = " ",
                                    DescripcionTransaccion = " ",
                                    TipoMoneda = " ",
                                    NumeroRecibo = " ",
                                    FechaRecibo = " ",
                                    MontoOriginal = " ",
                                    PagoAcumuladoPesos = " ",
                                    PagoAcumuladoDollar = " ",
                                    TasaCambio = " ",
                                    TipoInstrumento = " ",
                                    FechaTransaccion = " ",
                                    HoraTransaccion = " ",
                                    FechaEnvio1 = " ",
                                    HoraTransaccion1 = " ",
                                    OrigenFondos = " ",
                                    TransaccionRealizada = " ",
                                    MotivoTransaccion = " ",
                                    PaisOrigen = " ",
                                    PaisDestino = " ",
                                    EntidadCorresponsal = " ",
                                    Remesador = " ",
                                    IntermediarioIgualCliente = " ",
                                    SexoIntermediario = " ",
                                    NombreRazonIntermediario = " ",
                                    ApellidoRazonIntermediario = " ",
                                    NacionalidadOrigenIntermediario = " ",
                                    NacionalidadAdquiridaIntermediario = " ",
                                    TipoRncIntermediario = " ",
                                    NoDocumentoIntermediario = " ",
                                    SiTipoDocumentoIgualOtroEspesificarIntermdiario = " ",
                                    ProvinciaIntermediario = " ",
                                    MunicipioIntermediario = " ",
                                    SectorIntermediario = " ",
                                    DireccionIntermediario = " ",
                                    BeneficiarioIgualCliente = " ",
                                    SexoBeneficiario = " ",
                                    NombreRazonSocialBeneficiario = " ",
                                    ApellidoRazonSocialBeneficiario = " ",
                                    NacionalidadBeneficiario = " ",
                                    NacionalidadAdquiridaBeneficiario = " ",
                                    TipoIdentificacionBeneficiario = " ",
                                    NoDocumentoIdentidadBeneficiario = " ",
                                    SiTipoDocumentoIgualOtroEspesificar1 = " ",
                                    ProvinciaBeneficiario = " ",
                                    MunicipioBeneficiario = " ",
                                    SectorBeneficiario = " ",
                                    DireccionBeneficiario = " ",
                                    MotivoReporte = " ",
                                    EspesifiquePrioridadReporte = " ",
                                    Anexo = " ",
                                    ValidadoDesde = " ",
                                    ValidadoHasta = " ",
                                    MontoCondicion = " ",
                                    GeneradoPor = " "
                                }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreRegistro, ListadoVacio);
        }

        private void RestablecerPantalla() {
            DivBloqueDetalle.Visible = false;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoOperacion, ObjData.Value.BuscaListas("TIPOREPORTEUAF", null, null));
            MostrarListado();
            SacarTasaSistema();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "REPORTE DE OPERACIONES SOSPECHOSAS";
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoOperacion, ObjData.Value.BuscaListas("TIPOREPORTEUAF", null, null));
                DivBloqueDetalle.Visible = false;
                SacarTasaSistema();
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnExportarRegistros_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnRestablecerPantalla_Click(object sender, EventArgs e)
        {
            
        }


        protected void dtPaginacionOperacionesSospechosas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionOperacionesSospechosas_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            RestablecerPantalla();
        }

        protected void btnConsultarRegistrosNuevo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListado();
        }

        protected void btnExportarRegistrosNuevo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            ExportarRegistros();
        }

        protected void btnRestablecerPantallaNuevo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            RestablecerPantalla();
        }

        protected void btnPriemraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListado();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior);
        }

        protected void btnPaginasiguiente_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage += 1;
            MostrarListado();
        }

        protected void btnDetalleNuevo_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueDetalle.Visible = true;
            var PolizaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPoliza")).Value.ToString();

            var NumeroreciboSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfNumeroReciboSeleccionado = ((HiddenField)NumeroreciboSeleccionado.FindControl("hfNumeroRecibo")).Value.ToString();


            int TipoOperacionSeleccionada = Convert.ToInt32(ddlSeleccionarTipoOperacion.SelectedValue);
            decimal? UsuarioProcesa = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
            if (TipoOperacionSeleccionada == (int)ConceptosOperacionesSospechosas.TransaccionesEnEfectivo)
            {
                var SacarDetalle = ObjData.Value.GenerarReporteTransaccionesEfectivo(
                    Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), Convert.ToDecimal(txtTasa.Text), UsuarioProcesa, Convert.ToDecimal(txtMontoCondicion.Text),
                    Convert.ToDecimal(hfNumeroReciboSeleccionado),
                    hfPolizaSeleccionada.ToString());
                foreach (var n in SacarDetalle)
                {
                    txtNumeroReporteDetalle.Text = n.NumeroReporte.ToString();
                    txtPolizaDetalle.Text = n.Poliza;
                    txtCodigoRegistroEntidadDetalle.Text = n.CodigoRegistroEntidad;
                    txtUsuario.Text = n.Usuario;
                    txtOficina.Text = n.Oficina;
                    txtFechaEnvio.Text = n.FechaEnvio;
                    txtHoraEnvio.Text = n.HoraEnvio;
                    txtTipoPersonaCliente.Text = n.TipoPersonaCliente;
                    txtPEPCliente.Text = n.PEPCliente;
                    txtPEPClienteTipo.Text = n.PEPClienteTipo;
                    txtSexoCliente.Text = n.SexoCliente;
                    txtNombreRazonSocialCliente.Text = n.NombreRazonSocialCliente;
                    txtApellidoRazonSocialCliente.Text = n.ApellidoRazonSocialCliente;
                    txtNacionalidadorigenCliente.Text = n.NacionalidadorigenCliente;
                    txtNacionalidadAdquiridaCliente.Text = n.NacionalidadAdquiridaCliente;
                    txtTipoDocumentoCliente.Text = n.TipoDocumentoCliente;
                    txtNoDocumentoIdentidadCliente.Text = n.NoDocumentoIdentidadCliente;
                    txtSiTipoDocumentoIgualOtroEspesificar.Text = n.SiTipoDocumentoIgualOtroEspesificar;
                    txtActividadEconomicaCliente.Text = n.ActividadEconomicaCliente;
                    txtTipoProductoCliente.Text = n.TipoProductoCliente;
                    txtNoCuenta1.Text = n.NoCuenta1;
                    txtNoCuenta2.Text = n.NoCuenta2;
                    txtNoCuenta3.Text = n.NoCuenta3;
                    txtProvinciaCliente.Text = n.ProvinciaCliente;
                    txtMunicipioCliente.Text = n.MunicipioCliente;
                    txtSectorCliente.Text = n.SectorCliente;
                    txtDireccionCliente.Text = n.DireccionCliente;
                    txtTelefonoCasaCliente.Text = n.TelefonoCasaCliente;
                    txtTelefonoOficinaCliente.Text = n.TelefonoOficinaCliente;
                    txtCelular1Cliente.Text = n.Celular1Cliente;
                    txtCelular2Cliente.Text = n.Celular2Cliente;
                    txtTipoTransaccion.Text = n.TipoTransaccion;
                    txtDescripcionTransaccion.Text = n.DescripcionTransaccion;
                    txtTipoMoneda.Text = n.TipoMoneda;
                    txtNumeroRecibo.Text = n.NumeroRecibo.ToString();
                    txtFechaRecibo.Text = n.FechaRecibo;
                    decimal MontoOriginal = (decimal)n.MontoOriginal;
                    txtMontoOriginal.Text = MontoOriginal.ToString("N2");
                    decimal MontoPesos = (decimal)n.PagoAcumuladoPesos;
                    txtPagoAcumuladoPesos.Text = MontoPesos.ToString("N2");
                    decimal MontoDolar = (decimal)n.PagoAcumuladoDollar;
                    txtPagoAcumuladoDollar.Text = MontoDolar.ToString("N2");
                    txtTasaCambio.Text = n.TasaCambio.ToString();
                    txtTipoInstrumento.Text = n.TipoInstrumento;
                    txtFechaTransaccion.Text = n.FechaTransaccion;
                    txtHoraTransaccion.Text = n.HoraTransaccion;
                    txtFechaEnvioDetalle.Text = n.FechaEnvio1;
                    txtHoraTransaccion2.Text = n.HoraTransaccion1;
                    txtOrigenFondos.Text = n.OrigenFondos;
                    txtTransaccionRealizada.Text = n.TransaccionRealizada;
                    txtMotivoTransaccion.Text = n.MotivoTransaccion;
                    txtPaisOrigen.Text = n.PaisOrigen;
                    txtPaisDestino.Text = n.PaisDestino;
                    txtEntidadCorresponsal.Text = n.EntidadCorresponsal;
                    txtRemesador.Text = n.Remesador;
                    txtIntermediarioIgualCliente.Text = n.IntermediarioIgualCliente;
                    txtSexoIntermediario.Text = n.SexoIntermediario;
                    txtNombreRazonIntermediario.Text = n.NombreRazonIntermediario;
                    txtApellidoRazonIntermediario.Text = n.ApellidoRazonIntermediario;
                    txtNacionalidadOrigenIntermediario.Text = n.NacionalidadOrigenIntermediario;
                    txtNacionalidadAdquiridaIntermediario.Text = n.NacionalidadAdquiridaIntermediario;
                    txtTipoRncIntermediario.Text = n.TipoRncIntermediario;
                    txtNoDocumentoIntermediario.Text = n.NoDocumentoIntermediario;
                    txtSiTipoDocumentoIgualOtroEspesificarIntermdiario.Text = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario;
                    txtProvinciaIntermediario.Text = n.ProvinciaIntermediario;
                    txtMunicipioIntermediario.Text = n.MunicipioIntermediario;
                    txtSectorIntermediario.Text = n.SectorIntermediario;
                    txtDireccionIntermediario.Text = n.DireccionIntermediario;
                    txtBeneficiarioIgualCliente.Text = n.BeneficiarioIgualCliente;
                    txtSexoBeneficiario.Text = n.SexoBeneficiario;
                    txtNombreRazonSocialBeneficiario.Text = n.NombreRazonSocialBeneficiario;
                    txtApellidoRazonSocialBeneficiario.Text = n.ApellidoRazonSocialBeneficiario;
                    txtNacionalidadBeneficiario.Text = n.NacionalidadBeneficiario;
                    txtNacionalidadAdquiridaBeneficiario.Text = n.NacionalidadAdquiridaBeneficiario;
                    txtTipoIdentificacionBeneficiario.Text = n.TipoIdentificacionBeneficiario;
                    txtNoDocumentoIdentidadBeneficiario.Text = n.NoDocumentoIdentidadBeneficiario;
                    txtSiTipoDocumentoIgualOtroEspesificarBeneficiario.Text = n.SiTipoDocumentoIgualOtroEspesificar1;
                    txtProvinciaBeneficiario.Text = n.ProvinciaBeneficiario;
                    txtMunicipioBeneficiario.Text = n.MunicipioBeneficiario;
                    txtSectorBeneficiario.Text = n.SectorBeneficiario;
                    txtDireccionBeneficiario.Text = n.DireccionBeneficiario;
                    txtMotivoReporte.Text = n.MotivoReporte;
                    txtEspesifiquePrioridadReporte.Text = n.EspesifiquePrioridadReporte;
                    txtAnexo.Text = n.Anexo;
                    txtValidadoDesde.Text = n.ValidadoDesde;
                    txtValidadoHasta.Text = n.ValidadoHasta;
                    decimal MontoCondicion = (decimal)n.MontoCondicion;
                    txtMontoCondicion2.Text = MontoCondicion.ToString("N2");
                    txtGeneradoPor.Text = n.GeneradoPor;
                }


            }
            else if (TipoOperacionSeleccionada == (int)ConceptosOperacionesSospechosas.OperacionesSospechosas)
            {

                var SacarDetalleOperacionesSospechosas = ObjData.Value.GenerarReporteDeOperacionesSospechisas(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToDecimal(txtTasa.Text),
                    UsuarioProcesa,
                    Convert.ToDecimal(txtMontoCondicion.Text),
                    Convert.ToDecimal(hfNumeroReciboSeleccionado),
                    hfPolizaSeleccionada);
                foreach (var n in SacarDetalleOperacionesSospechosas)
                {
                    txtNumeroReporteDetalle.Text = n.NumeroReporte.ToString();
                    txtPolizaDetalle.Text = n.Poliza;
                    txtCodigoRegistroEntidadDetalle.Text = n.CodigoRegistroEntidad;
                    txtUsuario.Text = n.Usuario;
                    txtOficina.Text = n.Oficina;
                    txtFechaEnvio.Text = n.FechaEnvio;
                    txtHoraEnvio.Text = n.HoraEnvio;
                    txtTipoPersonaCliente.Text = n.TipoPersonaCliente;
                    txtPEPCliente.Text = n.PEPCliente;
                    txtPEPClienteTipo.Text = n.PEPClienteTipo;
                    txtSexoCliente.Text = n.SexoCliente;
                    txtNombreRazonSocialCliente.Text = n.NombreRazonSocialCliente;
                    txtApellidoRazonSocialCliente.Text = n.ApellidoRazonSocialCliente;
                    txtNacionalidadorigenCliente.Text = n.NacionalidadorigenCliente;
                    txtNacionalidadAdquiridaCliente.Text = n.NacionalidadAdquiridaCliente;
                    txtTipoDocumentoCliente.Text = n.TipoDocumentoCliente;
                    txtNoDocumentoIdentidadCliente.Text = n.NoDocumentoIdentidadCliente;
                    txtSiTipoDocumentoIgualOtroEspesificar.Text = n.SiTipoDocumentoIgualOtroEspesificar;
                    txtActividadEconomicaCliente.Text = n.ActividadEconomicaCliente;
                    txtTipoProductoCliente.Text = n.TipoProductoCliente;
                    txtNoCuenta1.Text = n.NoCuenta1;
                    txtNoCuenta2.Text = n.NoCuenta2;
                    txtNoCuenta3.Text = n.NoCuenta3;
                    txtProvinciaCliente.Text = n.ProvinciaCliente;
                    txtMunicipioCliente.Text = n.MunicipioCliente;
                    txtSectorCliente.Text = n.SectorCliente;
                    txtDireccionCliente.Text = n.DireccionCliente;
                    txtTelefonoCasaCliente.Text = n.TelefonoCasaCliente;
                    txtTelefonoOficinaCliente.Text = n.TelefonoOficinaCliente;
                    txtCelular1Cliente.Text = n.Celular1Cliente;
                    txtCelular2Cliente.Text = n.Celular2Cliente;
                    txtTipoTransaccion.Text = n.TipoTransaccion;
                    txtDescripcionTransaccion.Text = n.DescripcionTransaccion;
                    txtTipoMoneda.Text = n.TipoMoneda;
                    txtNumeroRecibo.Text = n.NumeroRecibo.ToString();
                    txtFechaRecibo.Text = n.FechaRecibo;
                    decimal MontoOriginal = (decimal)n.MontoOriginal;
                    txtMontoOriginal.Text = MontoOriginal.ToString("N2");
                    decimal MontoPesos = (decimal)n.PagoAcumuladoPesos;
                    txtPagoAcumuladoPesos.Text = MontoPesos.ToString("N2");
                    decimal MontoDolar = (decimal)n.PagoAcumuladoDollar;
                    txtPagoAcumuladoDollar.Text = MontoDolar.ToString("N2");
                    txtTasaCambio.Text = n.TasaCambio.ToString();
                    txtTipoInstrumento.Text = n.TipoInstrumento;
                    txtFechaTransaccion.Text = n.FechaTransaccion;
                    txtHoraTransaccion.Text = n.HoraTransaccion;
                    txtFechaEnvioDetalle.Text = n.FechaEnvio1;
                    txtHoraTransaccion2.Text = n.HoraTransaccion1;
                    txtOrigenFondos.Text = n.OrigenFondos;
                    txtTransaccionRealizada.Text = n.TransaccionRealizada;
                    txtMotivoTransaccion.Text = n.MotivoTransaccion;
                    txtPaisOrigen.Text = n.PaisOrigen;
                    txtPaisDestino.Text = n.PaisDestino;
                    txtEntidadCorresponsal.Text = n.EntidadCorresponsal;
                    txtRemesador.Text = n.Remesador;
                    txtIntermediarioIgualCliente.Text = n.IntermediarioIgualCliente;
                    txtSexoIntermediario.Text = n.SexoIntermediario;
                    txtNombreRazonIntermediario.Text = n.NombreRazonIntermediario;
                    txtApellidoRazonIntermediario.Text = n.ApellidoRazonIntermediario;
                    txtNacionalidadOrigenIntermediario.Text = n.NacionalidadOrigenIntermediario;
                    txtNacionalidadAdquiridaIntermediario.Text = n.NacionalidadAdquiridaIntermediario;
                    txtTipoRncIntermediario.Text = n.TipoRncIntermediario;
                    txtNoDocumentoIntermediario.Text = n.NoDocumentoIntermediario;
                    txtSiTipoDocumentoIgualOtroEspesificarIntermdiario.Text = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario;
                    txtProvinciaIntermediario.Text = n.ProvinciaIntermediario;
                    txtMunicipioIntermediario.Text = n.MunicipioIntermediario;
                    txtSectorIntermediario.Text = n.SectorIntermediario;
                    txtDireccionIntermediario.Text = n.DireccionIntermediario;
                    txtBeneficiarioIgualCliente.Text = n.BeneficiarioIgualCliente;
                    txtSexoBeneficiario.Text = n.SexoBeneficiario;
                    txtNombreRazonSocialBeneficiario.Text = n.NombreRazonSocialBeneficiario;
                    txtApellidoRazonSocialBeneficiario.Text = n.ApellidoRazonSocialBeneficiario;
                    txtNacionalidadBeneficiario.Text = n.NacionalidadBeneficiario;
                    txtNacionalidadAdquiridaBeneficiario.Text = n.NacionalidadAdquiridaBeneficiario;
                    txtTipoIdentificacionBeneficiario.Text = n.TipoIdentificacionBeneficiario;
                    txtNoDocumentoIdentidadBeneficiario.Text = n.NoDocumentoIdentidadBeneficiario;
                    txtSiTipoDocumentoIgualOtroEspesificarBeneficiario.Text = n.SiTipoDocumentoIgualOtroEspesificar1;
                    txtProvinciaBeneficiario.Text = n.ProvinciaBeneficiario;
                    txtMunicipioBeneficiario.Text = n.MunicipioBeneficiario;
                    txtSectorBeneficiario.Text = n.SectorBeneficiario;
                    txtDireccionBeneficiario.Text = n.DireccionBeneficiario;
                    txtMotivoReporte.Text = n.MotivoReporte;
                    txtEspesifiquePrioridadReporte.Text = n.EspesifiquePrioridadReporte;
                    txtAnexo.Text = n.Anexo;
                    txtValidadoDesde.Text = n.ValidadoDesde;
                    txtValidadoHasta.Text = n.ValidadoHasta;
                    decimal MontoCondicion = (decimal)n.MontoCondicion;
                    txtMontoCondicion2.Text = MontoCondicion.ToString("N2");
                    txtGeneradoPor.Text = n.GeneradoPor;
                }
            }
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina);
        }
    }
}
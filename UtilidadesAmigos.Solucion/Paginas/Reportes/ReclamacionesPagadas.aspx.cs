﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReclamacionesPagadas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReporte = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataSistema = new Lazy<Logica.Logica.LogicaSistema>();
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

        

        #region LISTADO RECLAMACIONES PAGADAS
        private void ListadoReclamacionesPagadas() {

            int? _CodigoBeneficiario = string.IsNullOrEmpty(txtCodigoBeneficiario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoBeneficiario.Text);
            string _Beneficiario = string.IsNullOrEmpty(txtNombreBeneficiario.Text.Trim()) ? null : txtNombreBeneficiario.Text.Trim();
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            int? _NumeroChqeue = string.IsNullOrEmpty(txtNumeroCheque.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroCheque.Text);
            int CantidadRegistros = 0;
            decimal TotalPagado = 0;

            var Listado = ObjDataReporte.Value.BuscaReclamacionesPagadas(
                _CodigoBeneficiario,
                _Beneficiario,
                _Oficina,
                _NumeroChqeue,
                Convert.ToDateTime(txtFechaDesde.Text),
                Convert.ToDateTime(txtFechaHasta.Text));
            if (Listado.Count() < 1)
            {

                rpReclamacionesPagadas.DataSource = null;
                rpReclamacionesPagadas.DataBind();
                lbCanidadRegistrosVariable.Text = "0";
                lbTotalVariable.Text = "0";
            }
            else
            {

                foreach (var n in Listado)
                {

                    CantidadRegistros = (int)n.CantidadRegistros;
                    TotalPagado = (decimal)n.Total;
                }
                lbCanidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                lbTotalVariable.Text = TotalPagado.ToString("N2");
                Paginar(ref rpReclamacionesPagadas, Listado, 10, ref lbCantidadPaginaVAriableReclamacionesPagadas, ref LinkPrimeraPaginaReclamacionesPagadas, ref LinkAnteriorReclamacionesPagadas, ref LinkSiguienteReclamacionesPagadas, ref LinkUltimoReclamacionesPagadas);
                HandlePaging(ref dtPaginacionReclamacionesPagadas, ref lbPaginaActualVariableReclamacionesPagadas);
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

            var SacarDatos = ObjDataSistema.Value.BuscaUsuarios(IdUsuario,
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
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjDataSistema.Value.BuscaListas("OFICINAS", null, null), true);
                btnReporte.Visible = false;

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "GENERAR RECLAMACIONES PAGADAS";
                PermisoPerfil();
            }
        }

        protected void btnConsultarRegistros_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAciosConsulta()", "CamposFechaVAciosConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true); }

            }
            else {
                CurrentPage = 0;
                ListadoReclamacionesPagadas();
            }
        }

        protected void btnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAciosExportar()", "CamposFechaVAciosExportar();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true); }

            }
            else {
                int? _CodigoBeneficiario = string.IsNullOrEmpty(txtCodigoBeneficiario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoBeneficiario.Text);
                string _Beneficiario = string.IsNullOrEmpty(txtNombreBeneficiario.Text.Trim()) ? null : txtNombreBeneficiario.Text.Trim();
                int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
                int? _NumeroChqeue = string.IsNullOrEmpty(txtNumeroCheque.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroCheque.Text);

                var Exportar = (from n in ObjDataReporte.Value.BuscaReclamacionesPagadas(
                    _CodigoBeneficiario,
                    _Beneficiario,
                    _Oficina,
                    _NumeroChqeue,
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text))
                                select new
                                {
                                    CodigoBeneficiario = n.CodigoBeneficiario,
                                    Beneficiario = n.Beneficiario1,
                                    TipoIdentificacion = n.TipoIdentificacion,
                                    NumeroIdentificacion = n.NumeroIdentificacion,
                                    Valor = n.Valor,
                                    Concepto1 = n.Concepto1,
                                    Concepto2 = n.Concepto2,
                                    NumeroCheque = n.NumeroCheque,
                                    FechaCheque = n.FechaCheque,
                                    Oficina = n.DescSucursal
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Reclamaciones pagadas", Exportar);
            }
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAciosReporte()", "CamposFechaVAciosReporte();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true); }

            }
            else { }
        }

        protected void LinkPrimeraPaginaReclamacionesPagadas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            ListadoReclamacionesPagadas();
        }

        protected void LinkAnteriorReclamacionesPagadas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            ListadoReclamacionesPagadas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableReclamacionesPagadas, ref lbCantidadPaginaVAriableReclamacionesPagadas);
        }

        protected void dtPaginacionReclamacionesPagadas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionReclamacionesPagadas_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            ListadoReclamacionesPagadas();
        }

        protected void LinkSiguienteReclamacionesPagadas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            ListadoReclamacionesPagadas();
        }

        protected void LinkUltimoReclamacionesPagadas_Click(object sender, EventArgs e)
        {

            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ListadoReclamacionesPagadas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActualVariableReclamacionesPagadas, ref lbCantidadPaginaVAriableReclamacionesPagadas);
        }
    }
}
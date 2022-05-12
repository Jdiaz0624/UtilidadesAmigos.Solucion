using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class SacarCarteraIntermediariosSupervisor : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

        #region CONTROL DE PAGINACION DE LISTADO INTERMEDIARIOS
        readonly PagedDataSource pagedDataSource_CarteraIntermediarios = new PagedDataSource();
        int _PrimeraPagina_CarteraIntermediarios, _UltimaPagina_CarteraIntermediarios;
        private int _TamanioPagina_CarteraIntermediarios = 10;
        private int CurrentPage_CarteraIntermediarios
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

        private void HandlePaging_CarteraIntermediarios(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_CarteraIntermediarios = CurrentPage_CarteraIntermediarios - 5;
            if (CurrentPage_CarteraIntermediarios > 5)
                _UltimaPagina_CarteraIntermediarios = CurrentPage_CarteraIntermediarios + 5;
            else
                _UltimaPagina_CarteraIntermediarios = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_CarteraIntermediarios > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_CarteraIntermediarios = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_CarteraIntermediarios = _UltimaPagina_CarteraIntermediarios - 10;
            }

            if (_PrimeraPagina_CarteraIntermediarios < 0)
                _PrimeraPagina_CarteraIntermediarios = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_CarteraIntermediarios;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_CarteraIntermediarios; i < _UltimaPagina_CarteraIntermediarios; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_CarteraIntermediarios(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_CarteraIntermediarios.DataSource = Listado;
            pagedDataSource_CarteraIntermediarios.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_CarteraIntermediarios.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_CarteraIntermediarios.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_CarteraIntermediarios.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_CarteraIntermediarios : _NumeroRegistros);
            pagedDataSource_CarteraIntermediarios.CurrentPageIndex = CurrentPage_CarteraIntermediarios;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_CarteraIntermediarios.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_CarteraIntermediarios.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_CarteraIntermediarios.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_CarteraIntermediarios.IsLastPage;

            RptGrid.DataSource = pagedDataSource_CarteraIntermediarios;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_CarteraIntermediarios
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_CarteraIntermediarios(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CONTROL DE PAGINACION DE LISTADO CARTERA SUPERVISORES
        readonly PagedDataSource pagedDataSource_CarteraSupervisores = new PagedDataSource();
        int _PrimeraPagina_CarteraSupervisores, _UltimaPagina_CarteraSupervisores;
        private int _TamanioPagina_CarteraSupervisores = 10;
        private int CurrentPage_CarteraSupervisores
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

        private void HandlePaging_CarteraSupervisores(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_CarteraSupervisores = CurrentPage_CarteraSupervisores - 5;
            if (CurrentPage_CarteraSupervisores > 5)
                _UltimaPagina_CarteraSupervisores = CurrentPage_CarteraSupervisores + 5;
            else
                _UltimaPagina_CarteraSupervisores = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_CarteraSupervisores > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_CarteraSupervisores = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_CarteraSupervisores = _UltimaPagina_CarteraSupervisores - 10;
            }

            if (_PrimeraPagina_CarteraSupervisores < 0)
                _PrimeraPagina_CarteraSupervisores = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_CarteraSupervisores;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_CarteraSupervisores; i < _UltimaPagina_CarteraSupervisores; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_CarteraSupervisores(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_CarteraSupervisores.DataSource = Listado;
            pagedDataSource_CarteraSupervisores.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_CarteraSupervisores.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_CarteraSupervisores.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_CarteraSupervisores.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_CarteraSupervisores : _NumeroRegistros);
            pagedDataSource_CarteraSupervisores.CurrentPageIndex = CurrentPage_CarteraSupervisores;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_CarteraSupervisores.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_CarteraSupervisores.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_CarteraSupervisores.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_CarteraSupervisores.IsLastPage;

            RptGrid.DataSource = pagedDataSource_CarteraSupervisores;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_CarteraSupervisores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_CarteraSupervisores(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region MOSTRAR LA CARTERA DE LOS INTERMEDIARIOS
        private void CarteraIntermediario() {

            int? CodigoVendedor = string.IsNullOrEmpty(txtCodigoIntermedairio.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedairio.Text);
            string Estatus = "";
            int CodigoEstatus = Convert.ToInt32(ddlSeleccionarEstatusPoliza.SelectedValue);

            switch (CodigoEstatus) {

                case 1:
                    Estatus=  "ACTIVO";
                    break;

                case 2:
                    Estatus = "CANCELADA";
                    break;

                case 3:
                    Estatus = "EXCLUSION";
                    break;

                case 4:
                    Estatus = "TRANSITO";
                    break;

                default:
                   Estatus= null;
                    break;
            }

            var SacarCarteraIntermediarios = ObjDataConsulta.Value.SacarCarteraIntermeiario(CodigoVendedor, Estatus);
            if (SacarCarteraIntermediarios.Count() < 1) {
                CurrentPage_CarteraIntermediarios = 0;
                rpCarteraIntermediario.DataSource = null;
                rpCarteraIntermediario.DataBind();
                lbCantidadPolizasActivasVariable.Text = "0";
                lbCantidadPolizasCanceladasVariable.Text = "0";
                lbCantidadPolizasTransitoVariable.Text = "0";
                lbCantidadPolizasExcluidasVariable.Text = "0";
            }
            else {

                Paginar_CarteraIntermediarios(ref rpCarteraIntermediario, SacarCarteraIntermediarios, 10, ref lbCantidadPaginaVAriableCarteraIntermediario, ref btnkPrimeraPaginaCarteraIntermediario, ref btnAnteriorCarteraIntermediario, ref btnSiguienteCarteraIntermediario, ref btnUltimoCarteraIntermediario);
                HandlePaging_CarteraIntermediarios(ref dtPaginacionCarteraIntermediario, ref lbPaginaActualVariableCarteraIntermediario);
                int Activas = 0, Canceladas = 0, Transito = 0, Exclidas = 0;

                foreach (var n in SacarCarteraIntermediarios) {
                    Activas = (int)n.PolizasActivas;
                    Canceladas = (int)n.PolizasCanceladas;
                    Transito = (int)n.PolizasTransito;
                    Exclidas = (int)n.PolizasExclusion;
                }

                lbCantidadPolizasActivasVariable.Text = Activas.ToString("N0");
                lbCantidadPolizasCanceladasVariable.Text = Canceladas.ToString("N0");
                lbCantidadPolizasTransitoVariable.Text = Transito.ToString("N0");
                lbCantidadPolizasExcluidasVariable.Text = Exclidas.ToString("N0");
            }
        }
        #endregion

        #region EXPORTAR CARTERA DE INTERMEDIARIOS
        private void ExportarCarteraVendedores() {

            int? CodigoVendedor = string.IsNullOrEmpty(txtCodigoIntermedairio.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedairio.Text);
            string Estatus = "";
            int CodigoEstatus = Convert.ToInt32(ddlSeleccionarEstatusPoliza.SelectedValue);

            switch (CodigoEstatus)
            {

                case 1:
                    Estatus = "ACTIVO";
                    break;

                case 2:
                    Estatus = "CANCELADA";
                    break;

                case 3:
                    Estatus = "EXCLUSION";
                    break;

                case 4:
                    Estatus = "TRANSITO";
                    break;

                default:
                    Estatus = null;
                    break;
            }

            var Exportar = (from n in ObjDataConsulta.Value.SacarCarteraIntermeiario(CodigoVendedor, Estatus)
                            select new
                            {
                                Poliza = n.Poliza,
                                EstatusPoliza = n.EstatusPoliza,
                                CodigoDeCliente=n.CodigoCliente,
                                Cliente = n.Cliente,
                                CodigoIntermediario = n.Intermediario,
                                Intermediario = n.NombreVendedor,
                                EstatusIntermediario = n.EstatusIntermediario,
                                Facturado = n.Facturado,
                                Cobrado = n.Cobrado,
                                Balance = n.Balance

                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera de Intermediarios", Exportar);
        }
        #endregion

        #region MOSTRAR LA CARTERA DE LOS SUPERVISORES
        private void MostrarCarteraSupervisores() {

            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioSupervisor.Text);

            var SacarCartera = ObjDataConsulta.Value.SacarCarteraEjecutivos(_Supervisor, _Intermediario);
            if (SacarCartera.Count() < 1) {

                lbCantidadIntermediariosVariable.Text = "0";
                rpCarteraSupervisor.DataSource = null;
                rpCarteraSupervisor.DataBind();
                CurrentPage_CarteraSupervisores = 0;
            }
            else {

                Paginar_CarteraSupervisores(ref rpCarteraSupervisor, SacarCartera, 10, ref lbCantidadPaginaVAriableCarteraSupervisor, ref btnPrimeraPaginaCarteraSupervisor, ref btnAnteriorCarteraSupervisor, ref btnSiguienteCarteraIntermediario, ref btnUltimoCarteraSupervisor);
                HandlePaging_CarteraSupervisores(ref dtPaginacionCarteraSupervisor, ref lbPaginaActualVariableCarteraSupervisor);

                int CantidadIntemediaro = 0;

                foreach (var n in SacarCartera) {

                    CantidadIntemediaro = (int)n.TotalIntermediarios;
                }
                lbCantidadIntermediariosVariable.Text = CantidadIntemediaro.ToString("N0");
            }
        }
        #endregion

        #region EXPORTAR CARTERA SUPERVISORES
        private void ExportarCartaraSupervisores() {

            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioSupervisor.Text);

            var Exportar = (from n in ObjDataConsulta.Value.SacarCarteraEjecutivos(_Supervisor, _Intermediario)
                            select new
                            {
                                Codigo_Supervisor = n.IdIntermediarioSupervisa,
                                Supervisor = n.NombreSupervisor,
                                Codigo_Intermediario = n.IdIntermediario,
                                Intermediario = n.NombreIntermediario,
                                Estatus_Intermediario = n.EstatusVendedor
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera de Supervisores", Exportar);
        }

        #endregion

        private void CargarEstatus() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatusPoliza, ObjDataGeneral.Value.BuscaListas("ESTATUSPOLIZA", null, null), true);
        }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                rbCarteraIntermediarios.Checked = true;
                DivBloqueIntermediarios.Visible = true;
                DivBloqueSupervisores.Visible = false;
                CargarEstatus();

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "CARTERA DE INTERMEDIARIOS / SUPERVISORES";
                PermisoPerfil();
            } 
        }

        protected void rbCarteraIntermediarios_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCarteraIntermediarios.Checked == true) {
                DivBloqueIntermediarios.Visible = true;
                DivBloqueSupervisores.Visible = false;
                txtCodigoIntermedairio.Text = string.Empty;
                txtNombreIntermediario.Text = string.Empty;
                txtCodigoIntermedairio.Focus();
                CargarEstatus();
            }
            else {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = false;
            }
        }

        protected void rbCarteraSupervisores_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCarteraSupervisores.Checked == true) {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = true;
                txtCodigoSupervisor.Text = string.Empty;
                txtNombreSupervisor.Text = string.Empty;
                txtCodigoIntermediarioSupervisor.Text = string.Empty;
                txtNombreIntermediarioSupervisor.Text = string.Empty;
                txtCodigoSupervisor.Focus();
            }
            else {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = false;
            }
        }

        protected void btnConsultarIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraIntermediarios = 0;
            CarteraIntermediario();
        }

        protected void txtCodigoIntermedairio_TextChanged(object sender, EventArgs e)
        {
            string NombreVendedor = "", CodigoIntermediario = "";
            CodigoIntermediario = txtCodigoIntermedairio.Text;
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarNombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(CodigoIntermediario);
            NombreVendedor = SacarNombre.SacarNombreIntermediario();
            txtNombreIntermediario.Text = NombreVendedor;
        }


        protected void dtPaginacionCarteraIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCarteraIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_CarteraIntermediarios = Convert.ToInt32(e.CommandArgument.ToString());
            CarteraIntermediario();
        }



        protected void btnBuscarSupervisores_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraSupervisores = 0;
            MostrarCarteraSupervisores();
        }

        protected void dtPaginacionCarteraSupervisor_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCarteraSupervisor_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_CarteraSupervisores = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarCarteraSupervisores();
        }

        protected void btnExportarSupervisores_Click(object sender, ImageClickEventArgs e)
        {
            ExportarCartaraSupervisores();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediarioSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioSupervisor.Text);
            txtNombreIntermediarioSupervisor.Text = Nombre.SacarNombreIntermediario();
        }

        protected void btnkPrimeraPaginaCarteraIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraIntermediarios = 0;
            CarteraIntermediario();
        }

        protected void btnAnteriorCarteraIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraIntermediarios += -1;
            CarteraIntermediario();
            MoverValoresPaginacion_CarteraIntermediarios((int)OpcionesPaginacionValores_CarteraIntermediarios.PaginaAnterior, ref lbPaginaActualVariableCarteraIntermediario, ref lbCantidadPaginaVAriableCarteraIntermediario);
        }

        protected void btnSiguienteCarteraIntermediario_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_CarteraIntermediarios += 1;
            CarteraIntermediario();
        }

        protected void btnPrimeraPaginaCarteraSupervisor_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraSupervisores = 0;
            MostrarCarteraSupervisores();
        }

        protected void btnAnteriorCarteraSupervisor_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraSupervisores += -1;
            MostrarCarteraSupervisores();
            MoverValoresPaginacion_CarteraSupervisores((int)OpcionesPaginacionValores_CarteraSupervisores.PaginaAnterior, ref lbPaginaActualVariableCarteraSupervisor, ref lbCantidadPaginaVAriableCarteraSupervisor);
        }

        protected void btnSiguienteCarteraSupervisor_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraSupervisores += 1;
            MostrarCarteraSupervisores();
        }

        protected void btnUltimoCarteraSupervisor_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraSupervisores = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarCarteraSupervisores();
            MoverValoresPaginacion_CarteraSupervisores((int)OpcionesPaginacionValores_CarteraSupervisores.PaginaAnterior, ref lbPaginaActualVariableCarteraSupervisor, ref lbCantidadPaginaVAriableCarteraSupervisor);
        }

        protected void btnUltimoCarteraIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_CarteraIntermediarios = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            CarteraIntermediario();
            MoverValoresPaginacion_CarteraIntermediarios((int)OpcionesPaginacionValores_CarteraIntermediarios.UltimaPagina, ref lbPaginaActualVariableCarteraIntermediario, ref lbCantidadPaginaVAriableCarteraIntermediario);
        }

        protected void ExportarInformacionIntermediario_Click(object sender, ImageClickEventArgs e)
        {
           //CurrentPage = 0;
            ExportarCarteraVendedores();
        }
    }
}
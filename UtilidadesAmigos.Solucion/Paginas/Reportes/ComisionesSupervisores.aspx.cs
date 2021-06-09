using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ComisionesSupervisores : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReporte = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

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
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarListasDesplegables()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalConsulta, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaConsulta, ObjData.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue, null), true);
        }
        #endregion
        #region MOSTRAR LAS COMISIONES POR PANTALLA
        /// <summary>
        /// Este metodo muestra el listado de las comisiones por pantalla.
        /// </summary>
        private void MostrarComisionesPantalla() {
            var BuscarInformacion = ObjDataReporte.Value.BuscarInformacionComisionSupervisorDetalle((decimal)Session["IdUsuario"]);
            if (BuscarInformacion.Count() < 1) {
                lbCantidadRegistrosEncontradosVariable.Text = "0";
                lbCobradBrutoVariable.Text = "0";
                lbCobradoNetoVariable.Text = "0";
                rpListadoComisionesSupervisores.DataSource = null;
                rpListadoComisionesSupervisores.DataBind();
            }
            else {
                Paginar(ref rpListadoComisionesSupervisores, BuscarInformacion, 10, ref lbCantidadPaginaVariablePrincipal, ref LinkPrimeraPaginaPrincipal, ref LinkAnteriorPrincipal, ref LinkSiguientePrincipal, ref LinkUltimoPrincipal);
                HandlePaging(ref dtPaginacionPrincipal, ref lbPaginaActualTituloPrincipal);
                int CantidadRegistros = 0;
                decimal Cobradobruto = 0, CobradoNeto = 0;

                foreach (var n in BuscarInformacion) {
                    CantidadRegistros = (int)n.CantidadRegistros;
                    Cobradobruto = (decimal)n.TotalBruto;
                    CobradoNeto = (decimal)n.TotalNeto;
                }
                lbCantidadRegistrosEncontradosVariable.Text = CantidadRegistros.ToString("N0");
                lbCobradBrutoVariable.Text = Cobradobruto.ToString("N2");
                lbCobradoNetoVariable.Text = CobradoNeto.ToString("N2");

            }
        }
        #endregion
        #region EXPORTAR LA CONSULTA A EXCEL
        private void ExportarConsultaExcel() {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaConsulta.SelectedValue) : new Nullable<int>();

            if (rbReporteResumido.Checked == true) {
                //EXPORTAR LA DATA DE MANERA RESUMIDA
                //ELIMINAMOS LOS REGISTROS REGISTRADOS BAJO EL USUARIO A PROCESAR

                decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosComisionesSupervisores Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosComisionesSupervisores(
                    IdUsuario, DateTime.Now, DateTime.Now, 0, "", 0, "", "", 0, 0, "", DateTime.Now, 0, "", "", 0, 0, "DELETE");
                Eliminar.ProcesarInformacion();

                //BUSCAMOS LA INFORMAICON NUEVA Y PROCEDEMOS A GUARDARLAR

                var Buscarregistros = ObjData.Value.ComisionesSupervisores(
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHastaConsulta.Text),
                    _CodigoSupervisor,
                    _Oficina, null);
                if (Buscarregistros.Count() < 1) { }
                else {
                    foreach (var n in Buscarregistros) {
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosComisionesSupervisores Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosComisionesSupervisores(
                            IdUsuario,
                            Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                            Convert.ToDateTime(txtFechaHastaConsulta.Text),
                            (int)n.CodigoSupervisor,
                            n.Supervisor,
                            (int)n.CodigoIntermediario,
                            n.Intermediario,
                            n.Poliza,
                            (decimal)n.NumeroFactura,
                            (decimal)n.Valor,
                            n.Fecha,
                            Convert.ToDateTime(n.Fecha0),
                            (int)n.CodigoOficina,
                            n.Oficina,
                            n.Concepto,
                            (decimal)n.PorcuentoComision,
                            (decimal)n.ComisionPagar,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }

                    var DataResumida = (from n in ObjData.Value.ReporteComisionesSupervisorResumido(IdUsuario)
                                        select new { 
                                        Supervisor=n.Supervisor,
                                        Oficina=n.Oficina,
                                        APagar=n.ComisionPagar
                                        }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision Resumida", DataResumida);
                }
            }
            else if (rbReporteDetallado.Checked == true) {
                var DataDetallada = (from n in ObjData.Value.ComisionesSupervisores(
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHastaConsulta.Text),
                    _CodigoSupervisor,
                    _Oficina,
                    null)
                                     select new {
                                         CodigoSupervisor = n.CodigoSupervisor,
                                         Supervisor = n.Supervisor,
                                         CodigoIntermediario = n.CodigoIntermediario,
                                         Intermediario = n.Intermediario,
                                         Poliza = n.Poliza,
                                         NumeroFactura = n.NumeroFactura,
                                         Valor = n.Valor,
                                         Fecha = n.Fecha,
                                         Oficina = n.Oficina,
                                         Concepto = n.Concepto,
                                         PorcuentoComision = n.PorcuentoComision,
                                         ComisionPagar = n.ComisionPagar
                                     }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comisiones Detalle", DataDetallada);
            }
        }
        #endregion
        #region GENERAR REPORTE DE COMISIONES DE SUPERVISORES
        private void GenerarReporteComisionesSupervisores(string RutaReporte, string NombreArchivo) {
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
            
            ReportDocument Reporte = new ReportDocument();
            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdUsuario", IdUsuario);
            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
           
            if (rbGenerarReportePDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbGenerarReporteExcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbGenerarReporteWord.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
        
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS CODIGOS PERMITIDOS PARA MOSTRAR LA COMISION
        private void MostrarListadoCodigospermitidos() {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoCodigospermitidos.Text.Trim()) ? null : txtCodigoCodigospermitidos.Text.Trim();
            string _NombreSupervisor = string.IsNullOrEmpty(txtNombreSupervisorPopop.Text.Trim()) ? null : txtNombreSupervisorPopop.Text.Trim();

            var BuscarDatos = ObjData.Value.BuscarCodigosSupervisoresPermitidos(
                new Nullable<decimal>(),
                _CodigoSupervisor,
                _NombreSupervisor,
                null, null, null);
            int CantidadRegistros = BuscarDatos.Count;
            lbCantidadRegistrosVariablePOPOP.Text = CantidadRegistros.ToString("N0");
            Paginar(ref rpListadoSupervisoresAgregados, BuscarDatos, 10, ref lbCantidadPaginaVariableCodigosPermitidos, ref LinkPrimeraPaginaCodigosPermitidos, ref LinkAnteriorCodigosPermitidos, ref LinkSiguienteCodigosPermitidos, ref LinkUltimoCodigosPermitidos);
            HandlePaging(ref dtPaginacionCodigosPermitidos, ref lbPaginaActualVariavleCodigosPermitidos);
        }
        #endregion
        #region BUSCAR SUPERVISORES PARA AGREGAR
        private void BuscarSupervisoresParaAgregar() {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoCodigospermitidos.Text.Trim()) ? null : txtCodigoCodigospermitidos.Text.Trim();
            string _NombreSupervisor = string.IsNullOrEmpty(txtNombreSupervisorPopop.Text.Trim()) ? null : txtNombreSupervisorPopop.Text.Trim();

            var Buscar = ObjData.Value.BuscaInformacionSUperisor(_CodigoSupervisor, _NombreSupervisor);
            int CantidadRegistros = Buscar.Count;
            lbCantidadRegistrosVariablePOPOP.Text = CantidadRegistros.ToString("N0");
            Paginar(ref rpListadoSupervisoresBuscar, Buscar, 10, ref lbCantidadPaginaVariableBuscarCodigos, ref LinkPrimeraPaginaBuscarCodigos, ref LinkAnteriorBuscarCodigos, ref LinkSiguienteBuscarCodigos, ref LinkUltimoBuscarCodigos);
            HandlePaging(ref dtPaginacionBuscarCodigos, ref lbPaginaActualVariavleBuscarCodigos);
        }
        #endregion
        #region SACAR EL NOMBRE DEL CONCEPTO Y EL PORCIENTO DE COMISION
        private string SacarConcepto(string Poliza, decimal NumeroRecibo) {
            string _Concepto = "";

            var SacarConcepto = ObjDataReporte.Value.SacarConceptoMediantePago(Poliza, NumeroRecibo);
            foreach (var n in SacarConcepto) {
                _Concepto = n.CONCEPTO;
            }
            return _Concepto;


        }

        private decimal SacarPorcientoComisionSupervisor(string Concepto, decimal CodigoSupervisor) {
            decimal PorcientoComision = 0;

            var BuscarRegistros = ObjDataReporte.Value.SacarPorcientoComisionSupervisor(Concepto, CodigoSupervisor);
            foreach (var n in BuscarRegistros) {
                PorcientoComision = (decimal)n.PorcientoComision;
            }
            return PorcientoComision;
        }
        #endregion

        #region GUARDAR INFORMACION PARA LAS COMISIONES
        private void ProcesarComisiones() {
            //DECLARAMOS LAS VARIABLES NECESARIAS PARA REALIZAR ESTE PROCESO
            decimal IdUsuario = 0;
            string Poliza = "";
            decimal Recibo = 0;
            string ConceptoPago = "";
            string ReciboFormateado = "";
            string Anulado = "";
            DateTime FechaPago = DateTime.Now;
            string FechaPagoFormateado = "";
            string TipoPago = "";
            decimal CodigoCliente = 0;
            string NombreCliente = "";
            decimal CodigoIntermediario = 0;
            string NombreIntermediario = "";
            decimal CodigoSupervisor = 0;
            string NombreSupervisor = "";
            decimal CodigoOficina = 0;
            string NombreOficina = "";
            string Usuario = "";
            decimal CodigoRamo = 0;
            string DescripcionRamo = "";
            decimal CodigoMoneda = 0;
            string DescripcionMoneda = "";
            decimal Bruto = 0;
            decimal Impuesto = 0;
            decimal Neto = 0;
            decimal Tasa = 0;
            decimal Pesos = 0;
            string ConceptoFactura = "";
            decimal PorcientoComisionIntermediario = 0;
            string ValidadoDesde = "";
            string ValidadoHasta = "";

            DateTime? _FechaDesdeFiltro = string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeConsulta.Text);
            DateTime? _FechaHastaFiltro = string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaConsulta.Text);
            string _CodigoSupervisorFiltro = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            int? _OficinaFiltro = ddlSeleccionaroficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaConsulta.SelectedValue) : new Nullable<int>();
            
            //CARGAMOS LAS VARIABLES
            IdUsuario = (decimal)Session["IdUsuario"];
            //ELIMINAMOS TODOS LOS DATOS MEDIANTE EL USUARIO INGRESADO
            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionComisionesSupervisores Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionComisionesSupervisores(
                IdUsuario, "", 0, "", "", "", DateTime.Now, "", "", 0, "", 0, "", 0, "", 0, "", "", 0, "", 0, "", 0, 0, 0, 0, 0, "", 0, "", "", "DELETE");
            Eliminar.ProcesarInformacion();

            var SacarInformacionCobrado = ObjDataReporte.Value.BuscarDataReporteCobrosDetalle(
                null,
                null,
                null,
                _FechaDesdeFiltro,
                _FechaHastaFiltro,
                null, null, null,
                _CodigoSupervisorFiltro,
                _OficinaFiltro,
                null, null, null, null, null,
                IdUsuario);
            foreach (var nCobrado in SacarInformacionCobrado) {
                Poliza = nCobrado.Poliza;
                Recibo = (decimal)nCobrado.Numero;
                ConceptoPago = nCobrado.Concepto;
                ReciboFormateado = nCobrado.NumeroFormateado;
                Anulado = nCobrado.Anulado;
                FechaPago = (DateTime)nCobrado.Fecha;
                FechaPagoFormateado = nCobrado.FechaFormateada;
                TipoPago = nCobrado.TipoPago;
                CodigoCliente = (decimal)nCobrado.CodigoCliente;
                NombreCliente = nCobrado.Cliente;
                CodigoIntermediario = (decimal)nCobrado.CodigoIntermediario;
                NombreIntermediario = nCobrado.Intermediario;
                CodigoSupervisor = (decimal)nCobrado.CodSupervisor;
                NombreSupervisor = nCobrado.NombreSupervisor;
                CodigoOficina = (int)nCobrado.CodigoOficina;
                NombreOficina = nCobrado.Oficina;
                Usuario = nCobrado.Usuario;
                CodigoRamo = (decimal)nCobrado.CodigoRamo;
                DescripcionRamo = nCobrado.Ramo;
                CodigoMoneda = (decimal)nCobrado.CodMoneda;
                DescripcionMoneda = nCobrado.Moneda;
                Bruto = (decimal)nCobrado.Bruto;
                Impuesto = (decimal)nCobrado.Impuesto;
                Neto = (decimal)nCobrado.Neto;
                Tasa = (decimal)nCobrado.Tasa;
                Pesos = (decimal)nCobrado.MontoPesos;
                ConceptoFactura = SacarConcepto(Poliza, Recibo);
                PorcientoComisionIntermediario = SacarPorcientoComisionSupervisor(ConceptoFactura, CodigoSupervisor);
                ValidadoDesde = _FechaDesdeFiltro.ToString();
                ValidadoHasta = _FechaHastaFiltro.ToString();

                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionComisionesSupervisores Guardar = new Logica.Comunes.Reportes.ProcesarInformacionComisionesSupervisores(
                     IdUsuario,
                     Poliza,
                     Recibo,
                     ConceptoPago,
                     ReciboFormateado,
                     Anulado,
                     FechaPago,
                     FechaPagoFormateado,
                     TipoPago,
                     CodigoCliente,
                     NombreCliente,
                     CodigoIntermediario,
                     NombreIntermediario,
                     CodigoSupervisor,
                     NombreSupervisor,
                     (int)CodigoOficina,
                     NombreOficina,
                     Usuario,
                    (int)CodigoRamo,
                     DescripcionRamo,
                     (int)CodigoMoneda,
                     DescripcionMoneda,
                     Bruto,
                     Impuesto,
                     Neto,
                     Tasa,
                     Pesos,
                     ConceptoFactura,
                     PorcientoComisionIntermediario,
                     ValidadoDesde,
                     ValidadoHasta,
                     "INSERT");
                Guardar.ProcesarInformacion();
            }

        }
        #endregion

        private void LimpiarControlesCodigosPermitidos() {
            IdRegistroSeleccionadoCodigoPermitidos.Text = "0";
            txtCodigoSupervisorControlesPermitidos.Text = string.Empty;
            txtNombreSupervisorControlesPermitidos.Text = string.Empty;
            txtFechaAgregadosControlesPermitidos.Text = string.Empty;
            txtOficinaSupervisorCOntrolesPermitidos.Text = string.Empty;
            txtClaveSeguridadControlesPermitidos.Text = string.Empty;
            txtCodigoSupervisorConsulta.Text = string.Empty;
            txtNombreSupervisorPopop.Text = string.Empty;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "COMISIONES DE SUPERVISORES";

                CargarListasDesplegables();
                //rbGenerarReportePDF.Checked = true;
                //rbCodigosPermitidos.Checked = true;
                DivBloqueCodigosPermitidos.Visible = true;
                DivBloqueBuscarCodigos.Visible = false;
               // rbReporteResumido.Checked = true;

                //rbGenerarReportePDF.Enabled = false;
                //rbGenerarReporteExcel.Enabled = false;
                //rbGenerarReporteWord.Enabled = false;
                //rbGenerarReporteExcel.Checked = true;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ProcesarComisiones();
                MostrarComisionesPantalla();
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ProcesarComisiones();
                decimal IdUsuario = (decimal)Session["IdUsuario"];
                var BuscarInformacion = ObjDataReporte.Value.BuscarInformacionComisionSupervisorDetalle(IdUsuario);
                if (BuscarInformacion.Count() < 1)
                {
                    var ExportarInformacion = (from n in "Informacion"
                                               select new
                                               {
                                                   Poliza = "",
                                                   Recibo = "",
                                                   ConceptoPago = "",
                                                   ReciboFormateado = "",
                                                   Anulado = "",
                                                   FechaPago = "",
                                                   FechaPagoFormateado = "",
                                                   TipoPago = "",
                                                   CodigoCliente = "",
                                                   NombreCliente = "",
                                                   CodigoIntermediario = "",
                                                   NombreIntermediario = "",
                                                   CodigoSupervisor = "",
                                                   NombreSupervisor = "",
                                                   CodigoOficina = "",
                                                   NombreOficina = "",
                                                   Usuario = "",
                                                   CodigoRamo = "",
                                                   DescripcionRamo = "",
                                                   CodigoMoneda = "",
                                                   DescripcionMoneda = "",
                                                   Bruto = "",
                                                   Impuesto = "",
                                                   Neto = "",
                                                   ComisionPagar = "",
                                                   Tasa = "",
                                                   Pesos = "",
                                                   ConceptoFactura = "",
                                                   PorcientoComisionIntermediario = "",
                                               }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Comisiones", ExportarInformacion);
                }
                else
                {
                    var ExportarInformacion = (from n in ObjDataReporte.Value.BuscarInformacionComisionSupervisorDetalle(IdUsuario)
                                               select new
                                               {
                                                   Poliza = n.Poliza,
                                                   Recibo = n.Recibo,
                                                   ConceptoPago = n.ConceptoPago,
                                                   ReciboFormateado = n.ReciboFormateado,
                                                   Anulado = n.Anulado,
                                                   FechaPago = n.FechaPago,
                                                   FechaPagoFormateado = n.FechaPagoFormateado,
                                                   TipoPago = n.TipoPago,
                                                   CodigoCliente = n.CodigoCliente,
                                                   NombreCliente = n.NombreCliente,
                                                   CodigoIntermediario = n.CodigoIntermediario,
                                                   NombreIntermediario = n.NombreIntermediario,
                                                   CodigoSupervisor = n.CodigoSupervisor,
                                                   NombreSupervisor = n.NombreSupervisor,
                                                   CodigoOficina = n.CodigoOficina,
                                                   NombreOficina = n.NombreOficina,
                                                   Usuario = n.Usuario,
                                                   CodigoRamo = n.CodigoRamo,
                                                   DescripcionRamo = n.DescripcionRamo,
                                                   CodigoMoneda = n.CodigoMoneda,
                                                   DescripcionMoneda = n.DescripcionMoneda,
                                                   Bruto = n.Bruto,
                                                   Impuesto = n.Impuesto,
                                                   Neto = n.Neto,
                                                   ComisionPagar = n.ComisionPagar,
                                                   Tasa = n.Tasa,
                                                   Pesos = n.Pesos,
                                                   ConceptoFactura = n.ConceptoFactura,
                                                   PorcientoComisionIntermediario = n.PorcientoComisionIntermediario,
                                               }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Comisiones", ExportarInformacion);
                }
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                } 
            }
            else {
                ProcesarComisiones();
                if (rbReporteDetallado.Checked == true) {
                    GenerarReporteComisionesSupervisores(Server.MapPath("ReporteComisionSupervisorDetalleNuevo.rpt"), "Comisiones Supervisores Detalle");
                }
                else if (rbReporteResumido.Checked == true) { }

            }
        }

        protected void LinkPrimeraPaginaPrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
           MostrarComisionesPantalla();
        }

        protected void LinkAnteriorPrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
           MostrarComisionesPantalla();
           MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavlePrincipal, ref lbCantidadPaginaVariablePrincipal);
        }

        protected void dtPaginacionPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionPrincipal_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
           MostrarComisionesPantalla();
        }

        protected void LinkSiguientePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarComisionesPantalla();
        }

        protected void LinkUltimoPrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
           MostrarComisionesPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavlePrincipal, ref lbCantidadPaginaVariablePrincipal);
        }

        protected void rbCodigosPermitidos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCodigosPermitidos.Checked == true) {
                DivBloqueCodigosPermitidos.Visible = true;
                DivBloqueBuscarCodigos.Visible = false;
                lbCantidadRegistrosVariablePOPOP.Text = "0";
                rpListadoSupervisoresAgregados.DataSource = null;
                rpListadoSupervisoresBuscar.DataSource = null;
            }
            else {
                DivBloqueCodigosPermitidos.Visible = false;
                DivBloqueBuscarCodigos.Visible = false;
            }
        }

        protected void rbBuscarCodigos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBuscarCodigos.Checked == true) {
                DivBloqueCodigosPermitidos.Visible = false;
                DivBloqueBuscarCodigos.Visible = true;
                lbCantidadRegistrosVariablePOPOP.Text = "0";
                rpListadoSupervisoresAgregados.DataSource = null;
                rpListadoSupervisoresBuscar.DataSource = null;
            }
            else {
                DivBloqueCodigosPermitidos.Visible = false;
                DivBloqueBuscarCodigos.Visible = false;
            }
        }

        protected void btnBuscarPOPOP_Click(object sender, EventArgs e)
        {
            if (rbCodigosPermitidos.Checked == true) {
                MostrarListadoCodigospermitidos();
            }
            else if (rbBuscarCodigos.Checked == true) {
               BuscarSupervisoresParaAgregar();
            }
        }

        protected void btnSeleccionarregistroAgregadoHEaderRpeaterPOPOP_Click(object sender, EventArgs e)
        {
            var RegistroSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfRegistroSeleccionado = ((HiddenField)RegistroSeleccionado.FindControl("hfIdRegistroSeleccionado")).Value.ToString();

            IdRegistroSeleccionadoCodigoPermitidos.Text = hfRegistroSeleccionado.ToString();

            var BuscarSacarInformacion = ObjData.Value.BuscarCodigosSupervisoresPermitidos(
                Convert.ToDecimal(IdRegistroSeleccionadoCodigoPermitidos.Text), null, null, null, null, null);
            foreach (var n in BuscarSacarInformacion) {
                txtCodigoSupervisorControlesPermitidos.Text = n.CodigoSupervisor.ToString();
                txtNombreSupervisorControlesPermitidos.Text = n.Nombre;
                txtFechaAgregadosControlesPermitidos.Text = n.FechaAgregado;
                txtOficinaSupervisorCOntrolesPermitidos.Text = n.Oficina;
            }
        }

        protected void LinkPrimeraPaginaCodigosPermitidos_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoCodigospermitidos();
        }

        protected void LinkAnteriorCodigosPermitidos_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoCodigospermitidos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleCodigosPermitidos, ref lbCantidadPaginaVariableCodigosPermitidos);
        }

        protected void dtPaginacionCodigosPermitidos_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCodigosPermitidos_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoCodigospermitidos();
        }

        protected void LinkSiguienteCodigosPermitidos_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoCodigospermitidos();
        }

        protected void LinkUltimoCodigosPermitidos_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoCodigospermitidos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleCodigosPermitidos, ref lbCantidadPaginaVariableCodigosPermitidos);
        }

        protected void btnEliminarSupervisorAgregado_Click(object sender, EventArgs e)
        {
            //VALIDAMOS LA CLAVE DE SEGURIDAD
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadControlesPermitidos.Text.Trim()) ? null : txtClaveSeguridadControlesPermitidos.Text.Trim();
            bool ResultadoValidacion = false;
            UtilidadesAmigos.Logica.Comunes.Validaciones.ValidarClaveSeguridad ValidarClave = new Logica.Comunes.Validaciones.ValidarClaveSeguridad(_ClaveSeguridad);
            ResultadoValidacion = ValidarClave.ValidacionClave();
            if (ResultadoValidacion == true) {

                //ELIMINAMOS EL REGISTRO
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionCodigosSupervisoresPermitidos Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionCodigosSupervisoresPermitidos(
                    Convert.ToDecimal(IdRegistroSeleccionadoCodigoPermitidos.Text),
                    Convert.ToDecimal(txtCodigoSupervisorControlesPermitidos.Text),
                    (decimal)Session["IdUsuario"],
                    "DELETE");
                Procesar.ProcesarInformacion();

                LimpiarControlesCodigosPermitidos();
                MostrarListadoCodigospermitidos();
            }
        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            LimpiarControlesCodigosPermitidos();
        }

        protected void btnGuardarBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClaveSeguridadBuscarCodigo.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadVacioaBuscarCodigo()", "ClaveSeguridadVacioaBuscarCodigo();", true);
            }
            else {
                //VALIDAMOS LA CLAVE DE SEGURIDAD
                string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadBuscarCodigo.Text.Trim()) ? null : txtClaveSeguridadBuscarCodigo.Text.Trim();
                UtilidadesAmigos.Logica.Comunes.Validaciones.ValidarClaveSeguridad ValidarClave = new Logica.Comunes.Validaciones.ValidarClaveSeguridad(_ClaveSeguridad);
                bool Resultado = ValidarClave.ValidacionClave();
                if (Resultado == true) {
                    var ItemSeleciconado = (RepeaterItem)((Button)sender).NamingContainer;
                    var hfItemSeleccionado = ((HiddenField)ItemSeleciconado.FindControl("hfCodigoSupervisor")).Value.ToString();

                    //guardamos
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionCodigosSupervisoresPermitidos Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionCodigosSupervisoresPermitidos(
                        0, Convert.ToDecimal(hfItemSeleccionado), (decimal)Session["IdUsuario"], "INSERT");
                    Guardar.ProcesarInformacion();
                    CurrentPage = 0;
                    BuscarSupervisoresParaAgregar();


                }
            }
        }

        protected void LinkPrimeraPaginaBuscarCodigos_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BuscarSupervisoresParaAgregar();
        }

        protected void LinkAnteriorBuscarCodigos_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            BuscarSupervisoresParaAgregar();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleBuscarCodigos, ref lbCantidadPaginaVariableBuscarCodigos);
        }

        protected void dtPaginacionBuscarCodigos_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionBuscarCodigos_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BuscarSupervisoresParaAgregar();
        }

        protected void LinkSiguienteBuscarCodigos_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BuscarSupervisoresParaAgregar();
        }

        protected void ddlSeleccionarSucursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaConsulta, ObjData.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue, null), true);
        }

        protected void txtCodigoSupervisorConsulta_TextChanged(object sender, EventArgs e)
        {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarNombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoSupervisor);
            txtNombreSupervisorConsulta.Text = SacarNombre.SacarNombreSupervisor();
        }

        protected void rbReporteResumido_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReporteDetallado.Checked == true)
            {
                rbGenerarReportePDF.Enabled = false;
                rbGenerarReporteExcel.Enabled = true;
                rbGenerarReporteWord.Enabled = false;
                rbGenerarReporteExcel.Checked = true;
            }
            else if (rbReporteResumido.Checked == true)
            {
                rbGenerarReportePDF.Enabled = false;
                rbGenerarReporteExcel.Enabled = false;
                rbGenerarReporteWord.Enabled = false;


            }
        }

        protected void rbReporteDetallado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReporteDetallado.Checked == true) {
                rbGenerarReportePDF.Enabled = true;
                rbGenerarReporteExcel.Enabled = true;
                rbGenerarReporteWord.Enabled = true;
                rbGenerarReportePDF.Checked = true;
            }
            else if (rbReporteResumido.Checked == true) {
                rbGenerarReportePDF.Enabled = false;
                rbGenerarReporteExcel.Enabled = false;
                rbGenerarReportePDF.Enabled = false;
               
            }
        }

        protected void LinkUltimoBuscarCodigos_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BuscarSupervisoresParaAgregar();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleBuscarCodigos, ref lbCantidadPaginaVariableBuscarCodigos);
        }
    }
}
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
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaConsulta.SelectedValue) : new Nullable<int>();

            var Consultar = ObjData.Value.ComisionesSupervisores(
                Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                Convert.ToDateTime(txtFechaHastaConsulta.Text),
                _CodigoSupervisor,
                _Oficina,
                null);
            int CantidadRegistros = Consultar.Count;
            lbCantidadRegistrosEncontradosVariable.Text = CantidadRegistros.ToString("N0");
            Paginar(ref rpListadoComisionesSupervisores, Consultar, 10, ref lbCantidadPaginaVariablePrincipal, ref LinkPrimeraPaginaPrincipal, ref LinkAnteriorPrincipal, ref LinkSiguientePrincipal, ref LinkUltimoPrincipal);
            HandlePaging(ref dtPaginacionPrincipal, ref lbPaginaActualVariavlePrincipal);
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
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaConsulta.SelectedValue) : new Nullable<int>();

            ReportDocument Reporte = new ReportDocument();
            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            if (rbReporteResumido.Checked == true) {
                Reporte.SetParameterValue("@IdUsuario", IdUsuario);
            }
            else if (rbReporteDetallado.Checked == true) {
                Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesdeConsulta.Text));
                Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHastaConsulta.Text));
                Reporte.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
                Reporte.SetParameterValue("@Oficina", _Oficina);
                Reporte.SetParameterValue("@UsuarioGenera", IdUsuario);
            }

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CargarListasDesplegables();
                rbGenerarReportePDF.Checked = true;
                rbCodigosPermitidos.Checked = true;
                DivBloqueCodigosPermitidos.Visible = true;
                DivBloqueBuscarCodigos.Visible = false;
                rbReporteResumido.Checked = true;
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
                ExportarConsultaExcel();
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

                if (rbReporteDetallado.Checked == true) {
                    GenerarReporteComisionesSupervisores(Server.MapPath("ComisionesSupervisoresDetalleFinal.rpt"), "Comisiones Supervisores Detalle");
                }
                else {
                    decimal _IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
                    string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
                    int? _Oficina = ddlSeleccionaroficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaConsulta.SelectedValue) : new Nullable<int>();

                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosComisionesSupervisores Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosComisionesSupervisores(
                        _IdUsuario, DateTime.Now, DateTime.Now, 0, "", 0, "", "", 0, 0, "", DateTime.Now, 0, "", "", 0, 0, "DELETE");
                    Eliminar.ProcesarInformacion();

                    var Buscarregistros = ObjData.Value.ComisionesSupervisores(
                        Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                        Convert.ToDateTime(txtFechaHastaConsulta.Text),
                        _CodigoSupervisor,
                        _Oficina,
                        _IdUsuario);
                    if (Buscarregistros.Count() < 1) { }
                    else {
                        foreach (var n in Buscarregistros) {
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosComisionesSupervisores Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosComisionesSupervisores(
                               _IdUsuario,
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


                        GenerarReporteComisionesSupervisores(Server.MapPath("ReporteComisionSupervisorResumidoFinal.rpt"), "Comisiones Supervisores Resumido");
                    }
                        



                    
                }
            }
        }

        protected void LinkPrimeraPaginaPrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorPrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionPrincipal_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguientePrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoPrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void rbCodigosPermitidos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCodigosPermitidos.Checked == true) {
                DivBloqueCodigosPermitidos.Visible = true;
                DivBloqueBuscarCodigos.Visible = false;
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
            }
            else {
                DivBloqueCodigosPermitidos.Visible = false;
                DivBloqueBuscarCodigos.Visible = false;
            }
        }

        protected void btnBuscarPOPOP_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarregistroAgregadoHEaderRpeaterPOPOP_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaCodigosPermitidos_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorCodigosPermitidos_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionCodigosPermitidos_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCodigosPermitidos_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteCodigosPermitidos_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoCodigosPermitidos_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarSupervisorAgregado_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarBuscarCodigo_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaBuscarCodigos_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorBuscarCodigos_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionBuscarCodigos_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionBuscarCodigos_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteBuscarCodigos_Click(object sender, EventArgs e)
        {

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

        protected void LinkUltimoBuscarCodigos_Click(object sender, EventArgs e)
        {

        }
    }
}
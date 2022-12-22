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
    public partial class ReporteImpresionMarbetes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDaraReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        #region CARGAR LISTAS 
        private void Cargaroficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjData.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void CargarRamos()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamo, ObjData.Value.BuscaListas("RAMOFILTRADO", null, null), true);
        }
        private void CargarSubRamos()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubramo, ObjData.Value.BuscaListas("SUBRAMO", ddlRamo.SelectedValue.ToString(), null), true);
        }
        #endregion

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

        #region MOSTRAR IMPRESION DE MARBETES POR PANTALLA
        private void MostrarInformacionporPantalla() {

            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            decimal? _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoCliente.Text);
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            int? _Subramo = ddlSubramo.SelectedValue != "-1" ? Convert.ToInt32(ddlSubramo.SelectedValue) : new Nullable<int>();
            decimal IdUsuario = (decimal)Session["IdUsuario"];

            var Listado = ObjDaraReportes.Value.ReporteImpresionMarbete(
                _Poliza,
                _Cliente,
                _Supervisor,
                _Intermediario,
                _Oficina,
                _Ramo,
                _Subramo,
                _FechaDesde,
                _FechaHasta,
                IdUsuario);
            if (Listado.Count() < 1) {
                rpListadoImpresionmarbete.DataSource = null;
                rpListadoImpresionmarbete.DataBind();
                CurrentPage = 0;
            }
            else {
                int CantidadImpresiones = 0;
                foreach (var n in Listado) {
                    CantidadImpresiones = (int)n.CantidadImpresiones;

                }
                lbCantidadImpresiones.Text = CantidadImpresiones.ToString("N0");
                Paginar(ref rpListadoImpresionmarbete, Listado, 10, ref lbCantidadPagina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
                HandlePaging(ref dtPaginacionListadoPrincipal, ref lbPaginaActual);
            }
        }
        #endregion

        #region EXPORTAR INFORMACION A EXCEL
        private void GenerarReporte() {
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            decimal? _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoCliente.Text);
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            int? _Subramo = ddlSubramo.SelectedValue != "-1" ? Convert.ToInt32(ddlSubramo.SelectedValue) : new Nullable<int>();
            decimal IdUsuario = (decimal)Session["IdUsuario"];

            if (rbFormatoExcelPlano.Checked == true) {
                var Exportar = (from n in ObjDaraReportes.Value.ReporteImpresionMarbete(
                    _Poliza,
                    _Cliente,
                    _Supervisor,
                    _Intermediario,
                    _Oficina,
                    _Ramo,
                    _Subramo,
                    _FechaDesde,
                    _FechaHasta,
                    IdUsuario)
                                select new
                                {
                                    Poliza = n.Poliza,
                                    Prima = n.Prima,
                                    UltimoMovimiento = n.UltimoMovimiento,
                                    FechaMovimiento = n.FechaMovimiento,
                                    Cliente = n.Cliente,
                                    Supervisor = n.Supervisor,
                                    Intermediario = n.Intermediario,
                                    Oficina = n.Oficina,
                                    Ramo = n.Ramo,
                                    SubRamo = n.Ramo1, //(SUB RAMO)
                                    Cotizacion = n.Cotizacion,
                                    FechaImpresion = n.FechaImpresion,
                                    HoraImpresion = n.HoraImpresion,
                                    Usuario = n.Usuario

                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Impresión de Marbetes Plano", Exportar);
            }
            else {


                ReportDocument Reporte = new ReportDocument();

                Reporte.Load(Server.MapPath("ReporteImpresionMarbete.rpt"));
                Reporte.Refresh();

                Reporte.SetParameterValue("@Poliza", _Poliza);
                Reporte.SetParameterValue("@Cliente", _Cliente);
                Reporte.SetParameterValue("@CodigoSupervisor", _Supervisor);
                Reporte.SetParameterValue("@CodigoIntermediario", _Intermediario);
                Reporte.SetParameterValue("@CodigoOficina", _Oficina);
                Reporte.SetParameterValue("@CodigoRamo", _Ramo);
                Reporte.SetParameterValue("@CodigoSubRamo", _Subramo);
                Reporte.SetParameterValue("@FechaImpresionDesde", _FechaDesde);
                Reporte.SetParameterValue("@FechaImpresionHasta", _FechaHasta);
                Reporte.SetParameterValue("@GeneradoPor", IdUsuario);

                Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

                if (rbFormatoReporte.Checked == true) {
                    Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Impresión de Marbetes PDF");
                }
                else if (rbFormatoExcel.Checked == true) {
                    Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Impresión de Marbetes Excel");
                }

                Reporte.Close();
                Reporte.Dispose();
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "REPORTE DE IMPRESION DE MARBETES";
                Cargaroficinas();
                CargarRamos();
                CargarSubRamos();
                rbFormatoReporte.Checked = true;
                DateTime FechaDesde = DateTime.Now, FechaHasta = DateTime.Now;
                txtFechaDesde.Text = FechaDesde.ToString("yyyy-MM-dd");
                txtFechaHasta.Text = FechaHasta.ToString("yyyy-MM-dd");

                CurrentPage = 0;
                MostrarInformacionporPantalla();
            }
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreSupervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = NombreSupervisor.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreIntermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = NombreIntermediario.SacarNombreIntermediario();
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoCliente.Text.Trim())) { }
            else {
                UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente NombreCliente = new Logica.Comunes.ESacarNombreCliente(txtCodigoCliente.Text);
                txtNombreCliente.Text = NombreCliente.SacarCodigoCLiente();
            }
            
        }

        protected void btnGenerarReporte_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporte();
        }

        protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubRamos();
        }

        protected void btnMostrarPorPantalla_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarInformacionporPantalla();
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
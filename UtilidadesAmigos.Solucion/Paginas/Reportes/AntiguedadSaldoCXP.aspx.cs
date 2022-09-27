using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{


    public partial class AntiguedadSaldoCXP : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjData = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDAtaCOmin = new Lazy<Logica.Logica.LogicaSistema>();

        #region CONTROL DE PAGINACION DE LA ANTIGUEDAD DE CXP
        readonly PagedDataSource pagedDataSource_Antiguedadcxp = new PagedDataSource();
        int _PrimeraPagina_Antiguedadcxp, _UltimaPagina_Antiguedadcxp;
        private int _TamanioPagina_Antiguedadcxp = 10;
        private int CurrentPage_Antiguedadcxp
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

        private void HandlePaging_Antiguedadcxp(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Antiguedadcxp = CurrentPage_Antiguedadcxp - 5;
            if (CurrentPage_Antiguedadcxp > 5)
                _UltimaPagina_Antiguedadcxp = CurrentPage_Antiguedadcxp + 5;
            else
                _UltimaPagina_Antiguedadcxp = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Antiguedadcxp > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Antiguedadcxp = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Antiguedadcxp = _UltimaPagina_Antiguedadcxp - 10;
            }

            if (_PrimeraPagina_Antiguedadcxp < 0)
                _PrimeraPagina_Antiguedadcxp = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Antiguedadcxp;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Antiguedadcxp; i < _UltimaPagina_Antiguedadcxp; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Antiguedadcxp(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Antiguedadcxp.DataSource = Listado;
            pagedDataSource_Antiguedadcxp.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Antiguedadcxp.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Antiguedadcxp.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Antiguedadcxp.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Antiguedadcxp : _NumeroRegistros);
            pagedDataSource_Antiguedadcxp.CurrentPageIndex = CurrentPage_Antiguedadcxp;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Antiguedadcxp.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Antiguedadcxp.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Antiguedadcxp.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Antiguedadcxp.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Antiguedadcxp;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Antiguedadcxp
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Antiguedadcxp(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region SACAR NOMBRE PROVEEDOR
        private string SacarNombreProveedor(int CodigoProveedor) {

            string Nombre = "";
            if (string.IsNullOrEmpty(txtCodigoProveedor.Text.Trim())) {
                Nombre = "";
            }
            else {

                var Informacion = ObjData.Value.SacarNombreProveedor(CodigoProveedor);
                if (Informacion.Count() < 1) {
                    Nombre = "";
                }
                else {
                    foreach (var n in Informacion) {

                        Nombre = n.Proveedor;
                    }
                }

            }
            return Nombre;
        }
        #endregion

        #region CARGAR LAS LISTAS
        private void CargarDias() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDias, ObjDAtaCOmin.Value.BuscaListas("DIASCXP", null, null), true);
        }
        private void CargarTipoDocumento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoDocumento, ObjDAtaCOmin.Value.BuscaListas("TIPODOCUMENTOCXP", null, null), true);
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LA ANTIGUEDAD DE SALDO DE CXP
        private void MostrarAntigeudadCXP() {

            DateTime _FechaCorte = Convert.ToDateTime(txtFechaCorte.Text);
            int? _CodigoProveedor = string.IsNullOrEmpty(txtCodigoProveedor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoProveedor.Text);
            int? _Dias = ddlDias.SelectedValue != "-1" ? Convert.ToInt32(ddlDias.SelectedValue) : new Nullable<int>();
            int? _TipoDocumento = ddlTipoDocumento.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoDocumento.SelectedValue) : new Nullable<int>();
            int? _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroFactura.Text);
            DateTime? _FechaDesde = cbAgregarRangoFecha.Checked == false ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = cbAgregarRangoFecha.Checked == false ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
            string _NCF = string.IsNullOrEmpty(txtNCF.Text.Trim()) ? null : txtNCF.Text.Trim();

            var Listado = ObjData.Value.BuscaAntiguedadsaldoCXP(
                _FechaCorte,
                _CodigoProveedor,
                _Dias,
                _TipoDocumento,
                _NumeroFactura,
                _FechaDesde,
                _FechaHasta,
                _NCF,
                (decimal)Session["IdUsuario"]);
            if (Listado.Count() < 1) {
                rpAntiguedadSaldoCXP.DataSource = null;
                rpAntiguedadSaldoCXP.DataBind();
            }
            else {
                Paginar_Antiguedadcxp(ref rpAntiguedadSaldoCXP, Listado, 10, ref lbCantidadPaginaVariable_Antiguedad, ref btnPrimeraPagina_Antiguedad, ref btnPaginaAnterior_Antiguedad, ref btnPaginaSiguiente_Antiguedad, ref btnUltimaPagina_Antiguedad);
                HandlePaging_Antiguedadcxp(ref dtPaginacion_Antiguedad, ref lbPaginaActual_Antiguedad);
            }
        }
        #endregion

        #region GENERAR REPORTE DE ANTIGUEDAD
        private void GenerarReporteAntiguedad() {

            string  RutaReporte = "", NombreReporte = "";

       
            RutaReporte = Server.MapPath("AntiguedadSaldoCXP.rpt");
            NombreReporte = "Antiguedad CXP";

            //FILTROS
            DateTime _FechaCorte = Convert.ToDateTime(txtFechaCorte.Text);
            int? _CodigoProveedor = string.IsNullOrEmpty(txtCodigoProveedor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoProveedor.Text);
            int? _Dias = ddlDias.SelectedValue != "-1" ? Convert.ToInt32(ddlDias.SelectedValue) : new Nullable<int>();
            int? _TipoDocumento = ddlTipoDocumento.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoDocumento.SelectedValue) : new Nullable<int>();
            int? _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroFactura.Text);
            DateTime? _FechaDesde = cbAgregarRangoFecha.Checked == false ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = cbAgregarRangoFecha.Checked == false ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
            string _NCF = string.IsNullOrEmpty(txtNCF.Text.Trim()) ? null : txtNCF.Text.Trim();

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@FechaCorte", Convert.ToDateTime(txtFechaCorte.Text));
            Reporte.SetParameterValue("@Proveedor", _CodigoProveedor);
            Reporte.SetParameterValue("@CodigoDia", _Dias);
            Reporte.SetParameterValue("@TipoDocumento", _TipoDocumento);
            Reporte.SetParameterValue("@NumeroFactura", _NumeroFactura);
            Reporte.SetParameterValue("@FechaFacturaDesde", new Nullable<DateTime>());
            Reporte.SetParameterValue("@FechaFacturaHasta", new Nullable<DateTime>());
            Reporte.SetParameterValue("@NCF", _NCF);
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                //DateTime Hoy = DateTime.Now;
                //txtFechaCorte.Text = Hoy.ToString("yyyy-MM-dd");

                cbAgregarRangoFecha.Checked = false;
                DivFechaDesde.Visible = false;
                DivFechaHasta.Visible = false;
                btnConsutar.Visible = true;
                btnExportarExcel.Visible = true;
                btnReporte.Visible = true;
                btnGrupo.Visible = true;
                btnExcluir.Visible = false;
                btnRestabelcerPantalla.Visible = false;

                DIVBloqueConsulta.Visible = true;
                DIVBloqueProceso.Visible = false;

                CargarDias();
                CargarTipoDocumento();
            }
        }

        protected void cbAgregarRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarRangoFecha.Checked == true) {
                DivFechaDesde.Visible = true;
                DivFechaHasta.Visible = true;
                DateTime date = DateTime.Now;
                //Asi obtenemos el primer dia del mes actual
                DateTime PrimerDia = new DateTime(date.Year, date.Month, 1);
                DateTime DiaActual = DateTime.Now;
                txtFechaDesde.Text = PrimerDia.ToString("yyyy-MM-dd");
                txtFechaHasta.Text = DiaActual.ToString("yyyy-MM-dd");
            }
            else {

                DivFechaDesde.Visible = false;
                DivFechaHasta.Visible = false;
            }
        }

        protected void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            try {
                txtNombreProveedor.Text = SacarNombreProveedor(Convert.ToInt32(txtCodigoProveedor.Text));
            }
            catch (Exception) {
                txtNombreProveedor.Text = "";
            }
        }

        protected void btnConsutar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Antiguedadcxp = 0;
            MostrarAntigeudadCXP();
        }

        protected void btnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {
            DateTime _FechaCorte = Convert.ToDateTime(txtFechaCorte.Text);
            int? _CodigoProveedor = string.IsNullOrEmpty(txtCodigoProveedor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoProveedor.Text);
            int? _Dias = ddlDias.SelectedValue != "-1" ? Convert.ToInt32(ddlDias.SelectedValue) : new Nullable<int>();
            int? _TipoDocumento = ddlTipoDocumento.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoDocumento.SelectedValue) : new Nullable<int>();
            int? _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroFactura.Text);
            DateTime? _FechaDesde = cbAgregarRangoFecha.Checked == false ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = cbAgregarRangoFecha.Checked == false ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
            string _NCF = string.IsNullOrEmpty(txtNCF.Text.Trim()) ? null : txtNCF.Text.Trim();

            var Exportar = (from n in ObjData.Value.BuscaAntiguedadsaldoCXP(
                _FechaCorte,
                _CodigoProveedor,
                _Dias,
                _TipoDocumento,
                _NumeroFactura,
                _FechaDesde,
                _FechaHasta,
                _NCF,
                (decimal)Session["IdUsuario"])
                            select new
                            {
                                Codigo_Proveedor = n.Proveedor,
                                Nombre = n.NombreProveedor,
                                DescripcionDias = n.DescripcionDias,
                                Tipo = n.Tipo,
                                Siglas = n.Siglas,
                                Descripcion = n.Descripcion,
                                Factura = n.Factura,
                                Fecha = n.Fecha,
                                Dias = n.Dias,
                                FacturaProveedor = n.FacturaProveedor,
                                Ncf = n.Ncf,
                                Reclamacion = n.Reclamacion,
                                TotalDeuda = n.TotalDeuda,
                                Valor = n.Valor,
                                CXP_0_30 = n.CXP_0_30,
                                CXP_31_60 = n.CXP_31_60,
                                CXP_61_90 = n.CXP_61_90,
                                CXP_91_120 = n.CXP_91_120,
                                CXP_121_MAS = n.CXP_121_MAS,
                                GeneradoPor = n.GeneradoPor
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Antiguedad Saldo CXP", Exportar);
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporteAntiguedad();
        }

        protected void btnGrupo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnRestabelcerPantalla_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Antiguedad_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_Antiguedad_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
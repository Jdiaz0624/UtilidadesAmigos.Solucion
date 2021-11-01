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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton PaginaSiguiente, ref LinkButton UltimaPagina)
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
                decimal? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarMoneda.SelectedValue) : new Nullable<decimal>();
                string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
                decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);

                var Listado = ObjDataReportes.Value.BuscaProduccion(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToDecimal(txtTasa.Text),
                    _Intermediario,
                    _Supervisor,
                    _Oficina,
                    _Ramo,
                    _SubRamo,
                    _Concepto,
                    _Poliza,
                    _Moneda,
                    _Usuario,
                    _NumeroFactura,
                    (decimal)Session["IdUsuario"]);
                Paginar(ref rpListadoProduccion, Listado, 10, ref lbCantidadPaginaVAriableProduccion, ref LinkPrimeraPaginaPolizasProduccion, ref LinkAnteriorPolizasProduccion, ref LinkSiguienteProduccion, ref LinkUltimoPolizasProduccion);
                HandlePaging(ref dtPaginacionPolizasProduccion, ref lbPaginaActualVariableProduccion);
            }

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
            }
        }

        protected void rbNoAgruparDatos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoAgruparDatos.Checked == true) {
                DIVTipoReporteGenerar.Visible = true;
                HRSeparadorTipoReporte.Visible = true;
                rbReporteDetallado.Checked = true;
            }
            else if (rbNoAgruparDatos.Checked == false) {
                DIVTipoReporteGenerar.Visible = false;
                HRSeparadorTipoReporte.Visible = false;
            }
        }

        protected void txtCodIntermediario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodSupervisor_TextChanged(object sender, EventArgs e)
        {

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

        }

        protected void LinkPrimeraPaginaPolizasProduccion_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarProduccion();
        }

        protected void LinkAnteriorPolizasProduccion_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarProduccion();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableProduccion, ref lbCantidadPaginaVAriableProduccion);
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

        protected void LinkSiguienteProduccion_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarProduccion();
        }

        protected void rbAgruparPorConcepto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorConcepto.Checked == true)
            {

                DIVTipoReporteGenerar.Visible = false;
                HRSeparadorTipoReporte.Visible = false;
            }
            else {
                DIVTipoReporteGenerar.Visible = true;
                HRSeparadorTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparPorUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorUsuario.Checked == true)
            {

                DIVTipoReporteGenerar.Visible = false;
                HRSeparadorTipoReporte.Visible = false;
            }
            else
            {
                DIVTipoReporteGenerar.Visible = true;
                HRSeparadorTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparPorOficina_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorOficina.Checked == true)
            {

                DIVTipoReporteGenerar.Visible = false;
                HRSeparadorTipoReporte.Visible = false;
            }
            else
            {
                DIVTipoReporteGenerar.Visible = true;
                HRSeparadorTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparPorRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorRamo.Checked == true)
            {

                DIVTipoReporteGenerar.Visible = false;
                HRSeparadorTipoReporte.Visible = false;
            }
            else
            {
                DIVTipoReporteGenerar.Visible = true;
                HRSeparadorTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparPorIntermediario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorIntermediario.Checked == true)
            {

                DIVTipoReporteGenerar.Visible = false;
                HRSeparadorTipoReporte.Visible = false;
            }
            else
            {
                DIVTipoReporteGenerar.Visible = true;
                HRSeparadorTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparPorSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorSupervisor.Checked == true)
            {

                DIVTipoReporteGenerar.Visible = false;
                HRSeparadorTipoReporte.Visible = false;
            }
            else
            {
                DIVTipoReporteGenerar.Visible = true;
                HRSeparadorTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparPorMoneda_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorMoneda.Checked == true)
            {

                DIVTipoReporteGenerar.Visible = false;
                HRSeparadorTipoReporte.Visible = false;
            }
            else
            {
                DIVTipoReporteGenerar.Visible = true;
                HRSeparadorTipoReporte.Visible = true;
            }
        }

        protected void LinkUltimoPolizasProduccion_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarProduccion();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActualVariableProduccion, ref lbCantidadPaginaVAriableProduccion);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReporteReclamaciones : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        #region CONTROL DE PAGINACION
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

        #region MOSTRAR EL LISTADO DE LAS RECLAMACIONES
        private void MostrarListadoReclamaciones() {

            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
            decimal? _Reclamacion = string.IsNullOrEmpty(txtReclamacion.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtReclamacion.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _EstatusReclamacion = ddlEstatusReclamacion.SelectedValue != "-1" ? Convert.ToInt32(ddlEstatusReclamacion.SelectedValue) : new Nullable<int>();
            int? _TipoReclamacion = ddlTipoReclamacion.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoReclamacion.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            string _Reclamante = string.IsNullOrEmpty(txtReclamante.Text.Trim()) ? null : txtReclamante.Text.Trim();

            var MostrarListado = ObjDataReportes.Value.ListadoReclamaciones(
                _Reclamacion,
                _Poliza,
                null,
                _FechaDesde,
                _FechaHasta,
                _Supervisor,
                _Intermediario,
                _TipoReclamacion,
                _EstatusReclamacion,
                _Reclamante,
                null,
                null,
                null,
                (decimal)Session["IdUsuario"]);
            Paginar(ref rpListadoReclamos, MostrarListado, 10,ref lbCantidadPaginaVariable,ref btnPrimeraPaginaReclamaciones,ref btnPaginaAnteriorReclamaciones,ref btnPaginaSiguienteReclamaciones,ref btnUltimaPaginaReclamaciones);
            HandlePaging(ref dtPaginacionReclamaciones, ref lbPaginaActualVariavle);
        }
        #endregion

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void ListadoEstatusReclamacion() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatusReclamacion, ObjDataConexion.Value.BuscaListas("ESTATUSRECLAMACIONSYSFLEX", null, null), true);
        }
        private void ListadoTipoReclamacion() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoReclamacion, ObjDataConexion.Value.BuscaListas("TIPORECLAMACIONSYSFLEX", null, null), true);
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
                lbPantalla.Text = "REPORTE DE RECLAMACIONES";

                ListadoEstatusReclamacion();
                ListadoTipoReclamacion();
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoReclamaciones();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnDetalleReclamo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPaginaReclamaciones_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnteriorReclamaciones_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionReclamaciones_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionReclamaciones_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnPaginaSiguienteReclamaciones_Click(object sender, ImageClickEventArgs e)
        {

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

        protected void btnUltimaPaginaReclamaciones_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
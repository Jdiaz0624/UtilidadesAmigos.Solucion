using System;
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

            }
            else
            {

                foreach (var n in Listado)
                {

                    CantidadRegistros = (int)n.CantidadRegistros;
                }
                lbCanidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                Paginar(ref rpReclamacionesPagadas, Listado, 10, ref lbCantidadPaginaVAriableReclamacionesPagadas, ref LinkPrimeraPaginaReclamacionesPagadas, ref LinkAnteriorReclamacionesPagadas, ref LinkSiguienteReclamacionesPagadas, ref LinkUltimoReclamacionesPagadas);
                HandlePaging(ref dtPaginacionReclamacionesPagadas, ref lbPaginaActualVariableReclamacionesPagadas);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjDataSistema.Value.BuscaListas("OFICINAS", null, null), true);
                btnReporte.Visible = false;
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
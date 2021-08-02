using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ControlVisitas : System.Web.UI.Page
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
        private void HandlePaging(ref DataList NombreDataList, ref Label PaginaActual)
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
            PaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label CantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            CantidadPagina.Text = pagedDataSource.PageCount.ToString();

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


            //divPaginacionCliente.Visible = true;
            //DivPaginacionIntermediario.Visible = true;
            //OcultarDetalle();
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPagina)
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
                    lbPaginaActual.Text = lbCantidadPagina.Text;
                    break;


            }

        }


        #endregion
        #region MOSTRAR EL LISTADO DEL CONTROL DE LAS VISITAS
        private void MostrarListadoControlCisitas() {
            int? _TipoProceso = ddlSeleccionarTipoProcesoCOnsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoProcesoCOnsulta.SelectedValue) : new Nullable<int>();
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();
            string _Remitente = string.IsNullOrEmpty(txtRemitenteConsulta.Text.Trim()) ? null : txtRemitenteConsulta.Text.Trim();

            var Listado = ObjData.Value.BuscaControlVisitas(
                new Nullable<decimal>(),
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);
            Paginar(ref rpListadoControlVisitas, Listado, 10, ref lbCantidadPaginaVAriableControlVisistas, ref LinkPrimeraPaginaControlVisistas, ref LinkAnteriorControlVisistas, ref LinkSiguienteControlVisistas, ref LinkUltimoControlVisistas);
            HandlePaging(ref dtPaginacionControlVisistas, ref lbPaginaActualVariableControlVisistas);
        }
        #endregion
        #region CARGAR EL LISTADO DE RECEPCON DE DOCUMENTOS
        private void CargarTipoProcesoCOsnsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoProcesoCOnsulta, ObjData.Value.BuscaListas("TIPOPROCESORECEPCION", null, null), true);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DivFechaDesde.Visible = false;
                DivFechaHAsta.Visible = false;

                CargarTipoProcesoCOsnsulta();
                MostrarListadoControlCisitas();
                
            }
        }

        protected void cbAgregarRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarRangoFecha.Checked == true) {
                DivFechaDesde.Visible = true;
                DivFechaHAsta.Visible = true;
            }
            else {
                DivFechaDesde.Visible = false;
                DivFechaHAsta.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaControlVisistas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorControlVisistas_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionControlVisistas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionControlVisistas_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteControlVisistas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoControlVisistas_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarRegistros_Click(object sender, EventArgs e)
        {

        }
    }
}
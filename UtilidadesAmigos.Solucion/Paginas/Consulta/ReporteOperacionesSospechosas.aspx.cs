using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ReporteOperacionesSospechosas : System.Web.UI.Page
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


        private void HandlePaging(ref DataList NombreDataList)
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
            lbPaginaActualVariableOperacionesSospechosas.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater ControlRepeater, IEnumerable<object> Listado, int _NumeroRegistros)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPaginaVariableOperacionesSospechosas.Text = pagedDataSource.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina : _NumeroRegistros);
            pagedDataSource.CurrentPageIndex = CurrentPage;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            LinkPrimeraOperacionesSospechosas.Enabled = !pagedDataSource.IsFirstPage;
            LinkAnteriorOperacionesSospechosas.Enabled = !pagedDataSource.IsFirstPage;
            LinkSiguienteOperacionesSospechosas.Enabled = !pagedDataSource.IsLastPage;
            LinkUltimoOperacionesSospechosas.Enabled = !pagedDataSource.IsLastPage;

            ControlRepeater.DataSource = pagedDataSource;
            ControlRepeater.DataBind();


            //  divPaginacionBancos.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion)
        {

            int PaginaActual = 0;
            switch (Accion)
            {

                case 1:
                    //PRIMERA PAGINA
                    lbPaginaActualVariableOperacionesSospechosas.Text = "1";

                    break;

                case 2:
                    //SEGUNDA PAGINA
                    PaginaActual = Convert.ToInt32(lbPaginaActualVariableOperacionesSospechosas.Text);
                    PaginaActual++;
                    lbPaginaActualVariableOperacionesSospechosas.Text = PaginaActual.ToString();
                    break;

                case 3:
                    //PAGINA ANTERIOR
                    PaginaActual = Convert.ToInt32(lbPaginaActualVariableOperacionesSospechosas.Text);
                    if (PaginaActual > 1)
                    {
                        PaginaActual--;
                        lbPaginaActualVariableOperacionesSospechosas.Text = PaginaActual.ToString();
                    }
                    break;

                case 4:
                    //ULTIMA PAGINA
                    lbPaginaActualVariableOperacionesSospechosas.Text = lbCantidadPaginaVariableOperacionesSospechosas.Text;
                    break;


            }

        }
        #endregion

        enum ConceptosOperacionesSospechosas {
            OperacionesSospechosas=1,
            TransaccionesEnEfectivo=2
    }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoOperacion, ObjData.Value.BuscaListas("TIPOREPORTEUAF", null, null));
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportarRegistros_Click(object sender, EventArgs e)
        {

        }

        protected void btnRestablecerPantalla_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraOperacionesSospechosas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorOperacionesSospechosas_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionOperacionesSospechosas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionOperacionesSospechosas_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteOperacionesSospechosas_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoOperacionesSospechosas_Click(object sender, EventArgs e)
        {

        }
    }
}
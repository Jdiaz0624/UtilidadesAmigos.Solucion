using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class CartaCancelacion : System.Web.UI.Page
    {
        #region CONTROL DE PAGINACION DE CARTA DE CANCELACION DE ASEGURADO	
        readonly PagedDataSource pagedDataSource_CartaAsegurado = new PagedDataSource();
        int _PrimeraPagina_CartaAsegurado, _UltimaPagina_CartaAsegurado;
        private int _TamanioPagina_CartaAsegurado = 10;
        private int CurrentPage_CartaAsegurado
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

        private void HandlePaging_CartaAsegurado(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_CartaAsegurado = CurrentPage_CartaAsegurado - 5;
            if (CurrentPage_CartaAsegurado > 5)
                _UltimaPagina_CartaAsegurado = CurrentPage_CartaAsegurado + 5;
            else
                _UltimaPagina_CartaAsegurado = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_CartaAsegurado > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_CartaAsegurado = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_CartaAsegurado = _UltimaPagina_CartaAsegurado - 10;
            }

            if (_PrimeraPagina_CartaAsegurado < 0)
                _PrimeraPagina_CartaAsegurado = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_CartaAsegurado;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_CartaAsegurado; i < _UltimaPagina_CartaAsegurado; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_CartaAsegurado(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_CartaAsegurado.DataSource = Listado;
            pagedDataSource_CartaAsegurado.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_CartaAsegurado.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_CartaAsegurado.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_CartaAsegurado.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_CartaAsegurado : _NumeroRegistros);
            pagedDataSource_CartaAsegurado.CurrentPageIndex = CurrentPage_CartaAsegurado;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_CartaAsegurado.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_CartaAsegurado.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_CartaAsegurado.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_CartaAsegurado.IsLastPage;

            RptGrid.DataSource = pagedDataSource_CartaAsegurado;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_CartaAsegurado
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_CartaAsegurado(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE CARTA DE CANCELACION DE INTERMEDIARIO
        readonly PagedDataSource pagedDataSource_CartaIntermediario = new PagedDataSource();
        int _PrimeraPagina_CartaIntermediario, _UltimaPagina_CartaIntermediario;
        private int _TamanioPagina_CartaIntermediario = 10;
        private int CurrentPage_CartaIntermediario
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

        private void HandlePaging_CartaIntermediario(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_CartaIntermediario = CurrentPage_CartaIntermediario - 5;
            if (CurrentPage_CartaIntermediario > 5)
                _UltimaPagina_CartaIntermediario = CurrentPage_CartaIntermediario + 5;
            else
                _UltimaPagina_CartaIntermediario = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_CartaIntermediario > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_CartaIntermediario = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_CartaIntermediario = _UltimaPagina_CartaIntermediario - 10;
            }

            if (_PrimeraPagina_CartaIntermediario < 0)
                _PrimeraPagina_CartaIntermediario = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_CartaIntermediario;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_CartaIntermediario; i < _UltimaPagina_CartaIntermediario; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_CartaIntermediario(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_CartaIntermediario.DataSource = Listado;
            pagedDataSource_CartaIntermediario.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_CartaIntermediario.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_CartaIntermediario.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_CartaIntermediario.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_CartaIntermediario : _NumeroRegistros);
            pagedDataSource_CartaIntermediario.CurrentPageIndex = CurrentPage_CartaIntermediario;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_CartaIntermediario.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_CartaIntermediario.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_CartaIntermediario.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_CartaIntermediario.IsLastPage;

            RptGrid.DataSource = pagedDataSource_CartaIntermediario;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_CartaIntermediario
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_CartaIntermediario(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbCartaCancelacionAsegurado_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbCartaCancelacionIntermediario_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtCodigoSupervisor_CartaAsegurado_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoIntermediario_CartaAsegurado_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoAsegurado_CartaAsegurado_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_CartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_CartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_CartaAsegurado_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_CartaAsegurado_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_CartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_CartaAsegurado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtCodigoSupervisor_CartaIntermediario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoIntermediario_CartaIntermediario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsukltar_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_CartaIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_CartaIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_CartaIntermediario_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
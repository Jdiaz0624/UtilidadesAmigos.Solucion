using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class SacarCarteraIntermediariosSupervisor : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

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

        private void CargarEstatus() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatusPoliza, ObjDataGeneral.Value.BuscaListas("ESTATUSPOLIZA", null, null), true);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                rbCarteraIntermediarios.Checked = true;
                DivBloqueIntermediarios.Visible = true;
                DivBloqueSupervisores.Visible = false;
                CargarEstatus();
            }
        }

        protected void rbCarteraIntermediarios_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCarteraIntermediarios.Checked == true) {
                DivBloqueIntermediarios.Visible = true;
                DivBloqueSupervisores.Visible = false;
                txtCodigoIntermedairio.Text = string.Empty;
                txtNombreIntermediario.Text = string.Empty;
                txtCodigoIntermedairio.Focus();
                CargarEstatus();
            }
            else {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = false;
            }
        }

        protected void rbCarteraSupervisores_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCarteraSupervisores.Checked == true) {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = true;
                txtCodigoSupervisor.Text = string.Empty;
                txtNombreSupervisor.Text = string.Empty;
                txtCodigoIntermediarioSupervisor.Text = string.Empty;
                txtNombreIntermediarioSupervisor.Text = string.Empty;
                txtCodigoSupervisor.Focus();
            }
            else {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = false;
            }
        }

        protected void btnConsultarIntermediario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtCodigoIntermedairio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaCarteraIntermediario_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorCarteraIntermediario_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionCarteraIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCarteraIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteCarteraIntermediario_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoCarteraIntermediario_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarSupervisores_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LinkPrimeraPaginaCarteraSupervisor_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorCarteraSupervisor_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionCarteraSupervisor_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCarteraSupervisor_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteCarteraSupervisor_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoCarteraSupervisor_Click(object sender, EventArgs e)
        {

        }

        protected void ExportarInformacionIntermediario_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
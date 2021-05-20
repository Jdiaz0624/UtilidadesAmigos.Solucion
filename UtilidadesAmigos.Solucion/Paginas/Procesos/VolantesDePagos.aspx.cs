using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class VolantesDePagos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProceso = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();

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

        #region BUSCAR EL LISTADO DE LOS CODIGOS
        private void BuscarCodigosEmpleados() {
            string _NombreEmpleado = string.IsNullOrEmpty(txtNombreEmpleadoConsulta.Text.Trim()) ? null : txtNombreEmpleadoConsulta.Text.Trim();

            var BuscarEmpleado = ObjDataProceso.Value.BuscaInformacionEmpleados(
                new Nullable<int>(),
                _NombreEmpleado,
                null, null, null, null, null, null);
            Paginar(ref rpListadoCodigos, BuscarEmpleado, 10, ref lbCantidadPaginaVariableVolantePago, ref LinkPrimeraPaginaVolantePago, ref LinkAnteriorVolantePago, ref LinkSiguienteVolantePago, ref LinkUltimoVolantePago);
            HandlePaging(ref dtPaginacionVolantePago, ref lbPaginaActualVariavleVolantePago);
        }
        #endregion

        private void IniciarPantalla() {
            DivBloqueProceso.Visible = true;
            DivBloqueBuscarCodigo.Visible = false;
            CurrentPage = 0;
            BuscarCodigosEmpleados();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "GENERAR VOLANTES DE PAGOS";
                IniciarPantalla();
            }

        }

        protected void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCodigos_Click(object sender, EventArgs e)
        {
            DivBloqueProceso.Visible = false;
            DivBloqueBuscarCodigo.Visible = true;
            txtNombreEmpleadoConsulta.Text = string.Empty;
            CurrentPage = 0;
            BuscarCodigosEmpleados();
        }

 

        protected void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BuscarCodigosEmpleados();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaVolantePago_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BuscarCodigosEmpleados();
        }

        protected void LinkAnteriorVolantePago_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            BuscarCodigosEmpleados();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleVolantePago, ref lbCantidadPaginaVariableVolantePago);
        }

        protected void dtPaginacionVolantePago_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionVolantePago_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BuscarCodigosEmpleados();
        }

        protected void LinkSiguienteVolantePago_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BuscarCodigosEmpleados();
        }

        protected void LinkUltimoVolantePago_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BuscarCodigosEmpleados();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleVolantePago, ref lbCantidadPaginaVariableVolantePago);
        }

        protected void btnVolverVolantePago_Click(object sender, EventArgs e)
        {
            IniciarPantalla();
        }
    }
}
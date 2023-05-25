using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Suministro
{
    public partial class AdministracionSuministro : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro> ObjDataSuministro = new Lazy<Logica.Logica.LogicaSuministro.LogicaSuministro>();

        #region CONTROL DE PAGINACION DEl INVENTARIO CONSULTA
        readonly PagedDataSource pagedDataSource_InventarioConsulta = new PagedDataSource();
        int _PrimeraPagina_InventarioConsulta, _UltimaPagina_InventarioConsulta;
        private int _TamanioPagina_InventarioConsulta = 10;
        private int CurrentPage_InventarioConsulta
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

        private void HandlePaging_InventarioConsulta(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_InventarioConsulta = CurrentPage_InventarioConsulta - 5;
            if (CurrentPage_InventarioConsulta > 5)
                _UltimaPagina_InventarioConsulta = CurrentPage_InventarioConsulta + 5;
            else
                _UltimaPagina_InventarioConsulta = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_InventarioConsulta > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_InventarioConsulta = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_InventarioConsulta = _UltimaPagina_InventarioConsulta - 10;
            }

            if (_PrimeraPagina_InventarioConsulta < 0)
                _PrimeraPagina_InventarioConsulta = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_InventarioConsulta;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_InventarioConsulta; i < _UltimaPagina_InventarioConsulta; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_InventarioConsulta(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_InventarioConsulta.DataSource = Listado;
            pagedDataSource_InventarioConsulta.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_InventarioConsulta.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_InventarioConsulta.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_InventarioConsulta.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_InventarioConsulta : _NumeroRegistros);
            pagedDataSource_InventarioConsulta.CurrentPageIndex = CurrentPage_InventarioConsulta;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_InventarioConsulta.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_InventarioConsulta.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_InventarioConsulta.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_InventarioConsulta.IsLastPage;

            RptGrid.DataSource = pagedDataSource_InventarioConsulta;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_InventarioConsulta
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_InventarioConsulta(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DEl HEADER DE LAS SOLICITUDES
        readonly PagedDataSource pagedDataSource_SolicitudHeader = new PagedDataSource();
        int _PrimeraPagina_SolicitudHeader, _UltimaPagina_SolicitudHeader;
        private int _TamanioPagina_SolicitudHeader = 10;
        private int CurrentPage_SolicitudHeader
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

        private void HandlePaging_SolicitudHeader(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_SolicitudHeader = CurrentPage_SolicitudHeader - 5;
            if (CurrentPage_SolicitudHeader > 5)
                _UltimaPagina_SolicitudHeader = CurrentPage_SolicitudHeader + 5;
            else
                _UltimaPagina_SolicitudHeader = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_SolicitudHeader > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_SolicitudHeader = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_SolicitudHeader = _UltimaPagina_SolicitudHeader - 10;
            }

            if (_PrimeraPagina_SolicitudHeader < 0)
                _PrimeraPagina_SolicitudHeader = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_SolicitudHeader;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_SolicitudHeader; i < _UltimaPagina_SolicitudHeader; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_SolicitudHeader(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_SolicitudHeader.DataSource = Listado;
            pagedDataSource_SolicitudHeader.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_SolicitudHeader.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_SolicitudHeader.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_SolicitudHeader.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_SolicitudHeader : _NumeroRegistros);
            pagedDataSource_SolicitudHeader.CurrentPageIndex = CurrentPage_SolicitudHeader;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_SolicitudHeader.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_SolicitudHeader.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_SolicitudHeader.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_SolicitudHeader.IsLastPage;

            RptGrid.DataSource = pagedDataSource_SolicitudHeader;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_SolicitudHeader
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_SolicitudHeader(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CARGAR LAS LISTAS DESPLEGABLES DE LA PANTALLA DE LA CONSULTA DE INVENTARIO
        private void ListaDesplegablesConsultaInventario() {
            SucuesalesConsultaInventario();
            OficinasConsultaInventario();
            CategoriasConsultaInventario();
            MedidasConsultaInventario();
        }
        private void SucuesalesConsultaInventario() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursalInventarioConsulta, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void OficinasConsultaInventario() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaInventarioConsulta, ObjData.Value.BuscaListas("OFICINA", ddlSucursalInventarioConsulta.SelectedValue.ToString(), null), true);
        }
        private void CategoriasConsultaInventario() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCategoriaInventarioConsulta, ObjData.Value.BuscaListas("SUMINISTROCATEGORIA", null, null), true);
        }
        private void MedidasConsultaInventario() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlMedidaInventarioConsulta, ObjData.Value.BuscaListas("SUMINISTROTIPOMEDIDA", null, null), true);
        }
        #endregion
        #region MOSTRAR EL LISTADO DEL INVENTARIO
        private void MostrarInventario() {

            int? _Sucursal = ddlSucursalInventarioConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSucursalInventarioConsulta.SelectedValue) : new Nullable<int>();
            int? _oficina = ddlOficinaInventarioConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlOficinaInventarioConsulta.SelectedValue) : new Nullable<int>();
            int? _Categoria = ddlCategoriaInventarioConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlCategoriaInventarioConsulta.SelectedValue) : new Nullable<int>();
            int? _UnidadMedida = ddlMedidaInventarioConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlMedidaInventarioConsulta.SelectedValue) : new Nullable<int>();
            string _Descripcion = string.IsNullOrEmpty(txtArticuloInventarioConsulta.Text.Trim()) ? null : txtArticuloInventarioConsulta.Text.Trim();
            int CantidadRegistros = 0, RegistrosAgotados = 0;

            var Listado = ObjDataSuministro.Value.BuscaInventario(
                new Nullable<decimal>(),
                _Sucursal,
                _oficina,
                _Categoria,
                _UnidadMedida,
                _Descripcion);
            if (Listado.Count() < 1)
            {

                rpListadoInventario.DataSource = null;
                rpListadoInventario.DataBind();
                lbCantidadRegistros_InventarioConsulta.Text = "0";
                lbregistrosAgotados_InventarioConsulta.Text = "0";
            }
            else {

                Paginar_InventarioConsulta(ref rpListadoInventario, Listado, 10, ref lbCantidadPaginaVariable_InventarioConsulta, ref btnPrimeraPagina_InventarioConsulta, ref btnPaginaAnterior_InventarioConsulta, ref btnSiguientePagina_InventarioConsulta, ref btnUltimaPagina_InventarioConsulta);
                HandlePaging_InventarioConsulta(ref dtInventarioConsulta, ref lbPaginaActualVariable);
                foreach (var n in Listado) {

                    CantidadRegistros = (int)n.CantidadRegistros;
                    RegistrosAgotados = (int)n.CantidadRegistrosAgotadosAgotados;
                }
                lbCantidadRegistros_InventarioConsulta.Text = CantidadRegistros.ToString("N0");
                lbregistrosAgotados_InventarioConsulta.Text = RegistrosAgotados.ToString("N0");
            }
        }
        #endregion

        #region CONFIGURACION INICIAL CONSULTA INVENTARIO
        private void ConfiguracionInicialConsultaInventario() {
            ListaDesplegablesConsultaInventario();
            btnConsultarInventarioConsulta.Visible = true;
            btnNuevoRegistroInventarioConsulta.Visible = true;
            btnReporteInventarioConsulta.Visible = true;
            btnSuplirInventarioConsulta.Visible = false;
            btnEditarReporteInventarioCOnsulta.Visible = false;
            btnBorrarInventarioCOnsulta.Visible = false;
            btnRestablecerInventarioConsulta.Visible = false;
            CurrentPage_InventarioConsulta = 0;
            MostrarInventario();
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
                lbPantalla.Text = "ADMINISTRACION DE INVENTARIO";
                rbSolicitudes.Checked = true;
                rbTodos.Checked = true;
                DIVBloqueSolicitudes.Visible = true;
                DIVBloqueAdministracionInventario.Visible = false;
                DivSubBloqueInventarioConsulta.Visible = false;
                DivSubBloqueInventarioMantenimiento.Visible = false;
                UtilidadesAmigos.Logica.Comunes.Rangofecha Fechas = new Logica.Comunes.Rangofecha();
                Fechas.FechaMes(ref txtFechaDesde, ref txtFEcfaHasta);
            }
        }

  

        protected void rbAdministracionInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdministracionInventario.Checked == true) {

                DIVBloqueSolicitudes.Visible = false;
                DIVBloqueAdministracionInventario.Visible = true;
                DivSubBloqueInventarioConsulta.Visible = true;
                DivSubBloqueInventarioMantenimiento.Visible = false;
                ConfiguracionInicialConsultaInventario();
            }
            else {
                DIVBloqueSolicitudes.Visible = false;
                DIVBloqueAdministracionInventario.Visible = false;
                DivSubBloqueInventarioConsulta.Visible = false;
                DivSubBloqueInventarioMantenimiento.Visible = false;
            }
        }

        protected void rbSolicitudes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSolicitudes.Checked == true) {
                DIVBloqueSolicitudes.Visible = true;
                DIVBloqueAdministracionInventario.Visible = false;
                DivSubBloqueInventarioConsulta.Visible = false;
                DivSubBloqueInventarioMantenimiento.Visible = false;
            }
            else {
                DIVBloqueSolicitudes.Visible = false;
                DIVBloqueAdministracionInventario.Visible = false;
                DivSubBloqueInventarioConsulta.Visible = false;
                DivSubBloqueInventarioMantenimiento.Visible = false;
            }
        }

        protected void ddlSucursalCOnsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDepartamentoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporteSolicitudes_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVer_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_SolicitudesHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_SolicitudesHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_SolicitudesHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_SolicitudesHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnQuitar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnProcesar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSucursalInventarioConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            OficinasConsultaInventario();
        }

      

        protected void btnConsultarInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_InventarioConsulta = 0;
            MostrarInventario();
        }

        protected void btnNuevoRegistroInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporteInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEditarReporteInventarioCOnsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBorrarInventarioCOnsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnRestablecerInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSuplirInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_InventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_InventarioConsulta = 0;
            MostrarInventario();
        }

        protected void btnPaginaAnterior_InventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_InventarioConsulta += -1;
            MostrarInventario();
            MoverValoresPaginacion_InventarioConsulta((int)OpcionesPaginacionValores_InventarioConsulta.PaginaAnterior, ref lbPaginaActualVariable_InventarioConsulta, ref lbCantidadPaginaVariable_InventarioConsulta);
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_InventarioConsulta = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarInventario();
        }

        protected void btnSiguientePagina_InventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_InventarioConsulta += 1;
            MostrarInventario();
        }

        protected void btnUltimaPagina_InventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_InventarioConsulta = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInventario();
            MoverValoresPaginacion_InventarioConsulta((int)OpcionesPaginacionValores_InventarioConsulta.PaginaAnterior, ref lbPaginaActualVariable_InventarioConsulta, ref lbCantidadPaginaVariable_InventarioConsulta);
        }

        protected void ddlSucursalMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtArticuloInventarioConsulta_TextChanged(object sender, EventArgs e)
        {
            CurrentPage_InventarioConsulta = 0;
            MostrarInventario();
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
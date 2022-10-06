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
    public partial class SolicitudSuministro : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro> ObjDataSuministro = new Lazy<Logica.Logica.LogicaSuministro.LogicaSuministro>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CONTROL DE PAGINACION DEL INVENTARIO
        readonly PagedDataSource pagedDataSourceInventario = new PagedDataSource();
        int _PrimeraPagina_Inventario, _UltimaPagina_Inventario;
        private int _TamanioPagina_Inventario = 10;
        private int CurrentPage_Inventario
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

        private void HandlePagingInventario(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Inventario = CurrentPage_Inventario - 5;
            if (CurrentPage_Inventario > 5)
                _UltimaPagina_Inventario = CurrentPage_Inventario + 5;
            else
                _UltimaPagina_Inventario = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Inventario > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Inventario = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Inventario = _UltimaPagina_Inventario - 10;
            }

            if (_PrimeraPagina_Inventario < 0)
                _PrimeraPagina_Inventario = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Inventario;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Inventario; i < _UltimaPagina_Inventario; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void PaginarInventario(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSourceInventario.DataSource = Listado;
            pagedDataSourceInventario.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSourceInventario.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSourceInventario.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSourceInventario.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Inventario : _NumeroRegistros);
            pagedDataSourceInventario.CurrentPageIndex = CurrentPage_Inventario;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSourceInventario.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSourceInventario.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSourceInventario.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSourceInventario.IsLastPage;

            RptGrid.DataSource = pagedDataSourceInventario;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValoresInventario
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacionInventario(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CONTROL DE PAGINACION DE LOS PRODUCTOS AGREGADOS
        readonly PagedDataSource pagedDataSource_ProductosAgregados = new PagedDataSource();
        int _PrimeraPagina_ProductosAgregados, _UltimaPagina_ProductosAgregados;
        private int _TamanioPagina_ProductosAgregados = 10;
        private int CurrentPage_ProductosAgregados
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

        private void HandlePaging_ProductosAgregados(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ProductosAgregados = CurrentPage_ProductosAgregados - 5;
            if (CurrentPage_ProductosAgregados > 5)
                _UltimaPagina_ProductosAgregados = CurrentPage_ProductosAgregados + 5;
            else
                _UltimaPagina_ProductosAgregados = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ProductosAgregados > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ProductosAgregados = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ProductosAgregados = _UltimaPagina_ProductosAgregados - 10;
            }

            if (_PrimeraPagina_ProductosAgregados < 0)
                _PrimeraPagina_ProductosAgregados = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ProductosAgregados;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ProductosAgregados; i < _UltimaPagina_ProductosAgregados; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ProductosAgregados(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ProductosAgregados.DataSource = Listado;
            pagedDataSource_ProductosAgregados.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ProductosAgregados.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ProductosAgregados.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ProductosAgregados.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ProductosAgregados : _NumeroRegistros);
            pagedDataSource_ProductosAgregados.CurrentPageIndex = CurrentPage_ProductosAgregados;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ProductosAgregados.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ProductosAgregados.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ProductosAgregados.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ProductosAgregados.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ProductosAgregados;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ProductosAgregados
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ProductosAgregados(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region MOSTRAR INVENTARIO
        private void MostrarInventario() {

            string _Articulo = string.IsNullOrEmpty(txtNombreArticuloConsulta.Text.Trim()) ? null : txtNombreArticuloConsulta.Text.Trim();

            var Buscar = ObjDataSuministro.Value.BuscaInventarioSuministro(
                new Nullable<decimal>(),
                _Articulo,
                null,
                null,
                null);
            PaginarInventario(ref rbListadoSeleccionarArticulo,Buscar,10, ref lbCantidadPaginaVAriableSeleccionarArticulo, ref btnkPrimeraPaginaSeleccionarArticulo, ref btnAnteriorEliminarArticulo, ref btnSiguienteSeleccionarArticulo, ref btnUltimoEliminarArticulo);
            HandlePagingInventario(ref dtPaginacionSeleccionarArticulo, ref lbPaginaActualVariableSeleccionarArticulo);
        }
        #endregion

        #region RESTABLECER PANTALLA
        private void RestablecerPantalla() {

            txtNombreArticuloConsulta.Text = string.Empty;
            txtArticuloSeleccionado.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtStockSeleccionado.Text = string.Empty;
            lbCodigoArtiuloSeleccionado.Text = "0";
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }
        #endregion

        #region PROCESAR LA INFORMACION DE SUMINISTRO ESPEJO
        private void ProcesarInformacionSuministroEspejo(decimal IdUsuario, decimal CodigoArticulo,int Stock, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudSuministroEspejo Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudSuministroEspejo(
                IdUsuario,
                CodigoArticulo,
                txtArticuloSeleccionado.Text,
                Convert.ToInt32(lbIdMedidaSeleccionaa.Text),
                Stock,
                Accion);
            Procesar.ProcesarInformacion();

        }
        #endregion

        #region MOSTRAR LOS REGISTROS AGREGADOS
        private void MostrarRegistroAgregados(decimal IdUsuario) {

            var MostrarRegistros = ObjDataSuministro.Value.BuscaSuministroEspejo(IdUsuario);
            Paginar_ProductosAgregados(ref rpArticulosAgregados, MostrarRegistros, 10, ref lbCantidadPaginaVAriableEliminarArticulo, ref btnkPrimeraPaginaEliminarArticulo, ref btnAnteriorEliminarArticulo, ref btnSiguienteEliminarArticulo, ref btnUltimoEliminarArticulo);
            HandlePagingInventario(ref dtPaginacionEliminarArticulo, ref lbPaginaActualEliminarArticulo);
            
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
                lbPantalla.Text = "SOLICITUD DE MATERIALES";

                DIVBloqueCOmpletado.Visible = false;

                ProcesarInformacionSuministroEspejo((decimal)Session["IdUsuario"], 0,0, "DELETEALL");
               // PermisoPerfil();
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void txtNombreArticuloConsulta_TextChanged(object sender, EventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void btnSeleccionarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfCodigoArticulo = ((HiddenField)RegistroSeleccionado.FindControl("hfCodigoArticulo")).Value.ToString();
            lbCodigoArtiuloSeleccionado.Text = hfCodigoArticulo;

            var BuscarRegistro = ObjDataSuministro.Value.BuscaInventarioSuministro(Convert.ToDecimal(hfCodigoArticulo));
            PaginarInventario(ref rbListadoSeleccionarArticulo, BuscarRegistro, 10, ref lbCantidadPaginaVAriableSeleccionarArticulo, ref btnkPrimeraPaginaSeleccionarArticulo, ref btnAnteriorEliminarArticulo, ref btnSiguienteSeleccionarArticulo, ref btnUltimoEliminarArticulo);
            HandlePagingInventario(ref dtPaginacionSeleccionarArticulo, ref lbPaginaActualVariableSeleccionarArticulo);
            foreach (var n in BuscarRegistro) {
                txtArticuloSeleccionado.Text = n.Articulo;
                int Cantidad = (int)n.Stock;
                txtStockSeleccionado.Text = Cantidad.ToString("N0");
                txtCantidad.Text = "1";
                lbIdMedidaSeleccionaa.Text = n.IdMedida.ToString();
            }
        }

        protected void btnkPrimeraPaginaSeleccionarArticulo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void btnAnteriorSeleccionarArticulo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario += -1;
            MostrarInventario();
            MoverValoresPaginacionInventario((int)OpcionesPaginacionValoresInventario.PaginaAnterior, ref lbPaginaActualVariableSeleccionarArticulo, ref lbCantidadPaginaVAriableSeleccionarArticulo);
        }

        protected void dtPaginacionSeleccionarArticulo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionSeleccionarArticulo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Inventario = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarInventario();
        }

        protected void btnSiguienteSeleccionarArticulo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario += 1;
            MostrarInventario();
        }

        protected void btnUltimoSeleccionarArticulo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInventario();
            MoverValoresPaginacionInventario((int)OpcionesPaginacionValoresInventario.UltimaPagina, ref lbPaginaActualVariableSeleccionarArticulo, ref lbCantidadPaginaVAriableSeleccionarArticulo);
        }

        protected void btnAgregarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            int CantidadSOlicitada = 0, Stock = 0;
            CantidadSOlicitada = Convert.ToInt32(txtCantidad.Text);
            Stock = Convert.ToInt32(txtStockSeleccionado.Text.Replace(",",""));
            if (CantidadSOlicitada > Stock)
            {
                ClientScript.RegisterStartupScript(GetType(), "CantidadAlmacenSuperior();", "CantidadAlmacenSuperior();", true);
            }
            else {
                //VALIDAMOS QUE EL REGISTRO NO ESTE AGREGADO

                var ValidarRegistro = ObjDataSuministro.Value.BuscaSuministroEspejo((decimal)Session["IdUsuario"], Convert.ToDecimal(lbCodigoArtiuloSeleccionado.Text));
                if (ValidarRegistro.Count() < 1) {


                    decimal IdUsuario = (decimal)Session["IdUsuario"];
                    ProcesarInformacionSuministroEspejo(IdUsuario, Convert.ToDecimal(lbCodigoArtiuloSeleccionado.Text),Convert.ToInt32(txtCantidad.Text), "INSERT");
                    RestablecerPantalla();
                    CurrentPage_ProductosAgregados = 0;
                    MostrarRegistroAgregados(IdUsuario);
                }
                else {
                    ClientScript.RegisterStartupScript(GetType(), "RegistroAgregado()", "RegistroAgregado();", true);
                }
            }
        }

        protected void btbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            RestablecerPantalla();
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            var CodigoSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfCodigoSeleccionado = ((HiddenField)CodigoSeleccionado.FindControl("hfEliminarRegistro")).Value.ToString();

            ProcesarInformacionSuministroEspejo((decimal)Session["IdUsuario"], Convert.ToDecimal(hfCodigoSeleccionado), 0, "DELETE");
            CurrentPage_ProductosAgregados = 0;
            MostrarRegistroAgregados((decimal)Session["IdUsuario"]);
        }

        protected void btnkPrimeraPaginaEliminarArticulo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProductosAgregados = 0;
            MostrarRegistroAgregados((decimal)Session["IdUsuario"]);
        }

        protected void btnAnteriorEliminarArticulo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProductosAgregados += -1;
            MostrarRegistroAgregados((decimal)Session["IdUsuario"]);
            MoverValoresPaginacion_ProductosAgregados((int)OpcionesPaginacionValores_ProductosAgregados.PaginaAnterior, ref lbPaginaActualVariableEliminarArticulo, ref lbCantidadPaginaVAriableEliminarArticulo);
        }

        protected void dtPaginacionEliminarArticulo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionEliminarArticulo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ProductosAgregados = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarRegistroAgregados((decimal)Session["IdUsuario"]);
        }

        protected void btnSiguienteEliminarArticulo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProductosAgregados += 1;
            MostrarRegistroAgregados((decimal)Session["IdUsuario"]);
           
        }

        protected void btnCrearNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            RestablecerPantalla();
            ProcesarInformacionSuministroEspejo((decimal)Session["IdUsuario"], 0, 0, "DELETEALL");
            DIVBloqueConsulta.Visible = true;
            DIVBloqueCOmpletado.Visible = false;
            CurrentPage_Inventario = 0;
            CurrentPage_ProductosAgregados = 0;
            rbListadoSeleccionarArticulo.DataSource = null;
            rbListadoSeleccionarArticulo.DataBind();
        }

        protected void btnUltimoEliminarArticulo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ProductosAgregados = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarRegistroAgregados((decimal)Session["IdUsuario"]);
            MoverValoresPaginacionInventario((int)OpcionesPaginacionValores_ProductosAgregados.UltimaPagina, ref lbPaginaActualVariableEliminarArticulo, ref lbCantidadPaginaVAriableEliminarArticulo);
        }

        protected void btnCompletarProceso_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DIVBloqueCOmpletado.Visible = true;
        }
    }
}
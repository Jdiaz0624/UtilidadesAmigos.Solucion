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
using UtilidadesAmigos.Logica.Entidades;

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
            decimal? _Codigo = string.IsNullOrEmpty(txtCodigoItem.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoItem.Text);
            int CantidadRegistros = 0, RegistrosAgotados = 0;

            var Listado = ObjDataSuministro.Value.BuscaInventario(
                _Codigo,
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
                HandlePaging_InventarioConsulta(ref dtInventarioConsulta, ref lbPaginaActualVariable_InventarioConsulta);
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
            DivSubBloqueInventarioConsulta.Visible = true;
            DivSubBloqueInventarioMantenimiento.Visible = false;
            DIVSubBloqueSuplirSacar.Visible = false;
            btnConsultarInventarioConsulta.Visible = true;
            btnNuevoRegistroInventarioConsulta.Visible = true;
            btnReporteInventarioConsulta.Visible = true;
            btnSuplirInventarioConsulta.Visible = false;
            btnEditarReporteInventarioCOnsulta.Visible = false;
            btnBorrarInventarioCOnsulta.Visible = false;
            btnRestablecerInventarioConsulta.Visible = false;
            txtArticuloInventarioConsulta.Text = string.Empty;
            txtCodigoItem.Text = string.Empty;
            CurrentPage_InventarioConsulta = 0;
            MostrarInventario();
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES DE LA PANTALLA DE MANTENIMIENTO 
        private void ListasDesplegablesPantallaMantenimiento() {
            ListadoSucursalesMantenimientoInventario();
            ListadoOficinasMantenimientoInventario();
            ListadoCategoriasMantenimientoInventario();
            ListadoUnidadMedidaMantenimientoInventario();
        }
        private void ListadoSucursalesMantenimientoInventario() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursalMantenimiento, ObjData.Value.BuscaListas("SUCURSAL", null, null));
        }
        private void ListadoOficinasMantenimientoInventario() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjData.Value.BuscaListas("OFICINA", ddlSucursalMantenimiento.SelectedValue.ToString(), null));
        }
        private void ListadoCategoriasMantenimientoInventario() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCategoriaMantenimiento, ObjData.Value.BuscaListas("SUMINISTROCATEGORIA", null, null));
        }
        private void ListadoUnidadMedidaMantenimientoInventario() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlMedidaMantenimiento, ObjData.Value.BuscaListas("SUMINISTROTIPOMEDIDA", null, null));
        }
        #endregion
        #region PROCESAR INFORMACION INVENTARIO
        private void ProcesarInformacionInventario(decimal IdRegistro,int Stock, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroInventario Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroInventario(
                IdRegistro,
                Convert.ToInt32(ddlSucursalMantenimiento.SelectedValue),
                Convert.ToInt32(ddlOficinaMantenimiento.SelectedValue),
                Convert.ToInt32(ddlCategoriaMantenimiento.SelectedValue),
                Convert.ToInt32(ddlMedidaMantenimiento.SelectedValue),
                txtDescripcionMantenimiento.Text,
                Stock,
                Convert.ToInt32(txtStockMinimoMantenimiento.Text),
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion
        #region GENERAR REPORTE DE INVENTARIO
        private void GenerarReporteInventario() {

            //ReporteInventario.rpt
            string RutaReporte = "", NombreReporte = "", UsuarioBD = "", ClaveBD = "";
            int? _Sucursal = ddlSucursalInventarioConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSucursalInventarioConsulta.SelectedValue) : new Nullable<int>();
            int? _oficina = ddlOficinaInventarioConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlOficinaInventarioConsulta.SelectedValue) : new Nullable<int>();
            int? _Categoria = ddlCategoriaInventarioConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlCategoriaInventarioConsulta.SelectedValue) : new Nullable<int>();
            int? _UnidadMedida = ddlMedidaInventarioConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlMedidaInventarioConsulta.SelectedValue) : new Nullable<int>();
            string _Descripcion = string.IsNullOrEmpty(txtArticuloInventarioConsulta.Text.Trim()) ? null : txtArticuloInventarioConsulta.Text.Trim();
            decimal? _Codigo = string.IsNullOrEmpty(txtCodigoItem.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoItem.Text);

            RutaReporte = Server.MapPath("ReporteInventario.rpt");
            NombreReporte = "Reporte de Inventario";
            UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
            UsuarioBD = Credenciales.SacarUsuario();
            ClaveBD = Credenciales.SacarClaveBD();

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdRegistro", _Codigo);
            Reporte.SetParameterValue("@IdSucursal", _Sucursal);
            Reporte.SetParameterValue("@IdOficina", _oficina);
            Reporte.SetParameterValue("@IdCategoria", _Categoria);
            Reporte.SetParameterValue("@IdUnidadMedida", _UnidadMedida);
            Reporte.SetParameterValue("@Descripcion", _Descripcion);
            Reporte.SetParameterValue("@Stock", new Nullable<int>());
            Reporte.SetParameterValue("@FechaDesde", new Nullable<DateTime>());
            Reporte.SetParameterValue("@FechaHasta", new Nullable<DateTime>());
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
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
            DivSubBloqueInventarioConsulta.Visible = false;
            DivSubBloqueInventarioMantenimiento.Visible = true;
            DIVSubBloqueSuplirSacar.Visible = false;
            ListasDesplegablesPantallaMantenimiento();
            txtDescripcionMantenimiento.Text = string.Empty;
            txtStockMantenimiento.Text = "1";
            txtStockMinimoMantenimiento.Text = "1";
            lbIdregistroSeleccionado.Text = "0";
            lbAccionTomarInventario.Text = "INSERT";
            txtStockMantenimiento.Enabled = true;
            txtStockMinimoMantenimiento.Enabled = true;
        }

        protected void btnReporteInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporteInventario();
        }

        protected void btnEditarReporteInventarioCOnsulta_Click(object sender, ImageClickEventArgs e)
        {
            DivSubBloqueInventarioConsulta.Visible = false;
            DivSubBloqueInventarioMantenimiento.Visible = true;
            DIVSubBloqueSuplirSacar.Visible = false;
            lbAccionTomarInventario.Text = "UPDATE";
            txtStockMantenimiento.Enabled = false;
            txtStockMinimoMantenimiento.Enabled = false;
        }

        protected void btnBorrarInventarioCOnsulta_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionInventario(Convert.ToInt32(lbIdregistroSeleccionado.Text), 0, "DELETE");
            ClientScript.RegisterStartupScript(GetType(), "ProcesoCompletado()", "ProcesoCompletado();", true);
            ConfiguracionInicialConsultaInventario();
        }

        protected void btnRestablecerInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicialConsultaInventario();
        }

        protected void btnSuplirInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {
            DivSubBloqueInventarioConsulta.Visible = false;
            DivSubBloqueInventarioMantenimiento.Visible = false;
            DIVSubBloqueSuplirSacar.Visible = true;
            
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
            ListadoOficinasMantenimientoInventario();
        }

        protected void txtArticuloInventarioConsulta_TextChanged(object sender, EventArgs e)
        {
            CurrentPage_InventarioConsulta = 0;
            MostrarInventario();
        }

        protected void btnVerItemInventario_Click(object sender, ImageClickEventArgs e)
        {
            var ArticuloSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;

            var IdArticulo = ((HiddenField)ArticuloSeleccionado.FindControl("hfIdArticulo")).Value.ToString();
            lbIdregistroSeleccionado.Text = IdArticulo;
            var SacarInformacion = ObjDataSuministro.Value.BuscaInventario(Convert.ToDecimal(IdArticulo));
            foreach (var n in SacarInformacion) {
                ListadoSucursalesMantenimientoInventario();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSucursalMantenimiento, n.IdSucursal.ToString());
                ListadoOficinasMantenimientoInventario();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.ToString());
                ListadoCategoriasMantenimientoInventario();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlCategoriaMantenimiento, n.IdCategoria.ToString());
                ListadoUnidadMedidaMantenimientoInventario();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlMedidaMantenimiento, n.IdUnidadMedida.ToString());
                txtDescripcionMantenimiento.Text = n.Articulo;
                txtStockMantenimiento.Text = n.Stock.ToString();
                txtStockMinimoMantenimiento.Text = n.StockMinimo.ToString();
                txtDescripcion_Suplir_Sacar.Text = n.Articulo;
                txtStockActual_Suplir_Sacar.Text = n.Stock.ToString();
                txtStockNuevo_Suplir_Sacar.Text = "1";
            }
            Paginar_InventarioConsulta(ref rpListadoInventario, SacarInformacion, 10, ref lbCantidadPaginaVariable_InventarioConsulta, ref btnPrimeraPagina_InventarioConsulta, ref btnPaginaAnterior_InventarioConsulta, ref btnSiguientePagina_InventarioConsulta, ref btnUltimaPagina_InventarioConsulta);
            HandlePaging_InventarioConsulta(ref dtInventarioConsulta, ref lbPaginaActualVariable_InventarioConsulta);
            lbCantidadRegistros_InventarioConsulta.Text = "1";
            lbregistrosAgotados_InventarioConsulta.Text = "1";
            btnConsultarInventarioConsulta.Visible = false;
            btnNuevoRegistroInventarioConsulta.Visible = false;
            btnReporteInventarioConsulta.Visible = false;
            btnSuplirInventarioConsulta.Visible = true;
            btnEditarReporteInventarioCOnsulta.Visible = true;
            btnBorrarInventarioCOnsulta.Visible = true;
            btnRestablecerInventarioConsulta.Visible = true;
            rbAgregarItems.Checked = true;
        }

        protected void btnGuardar_Suplir_Sacar_Click(object sender, ImageClickEventArgs e)
        {
            string Accion = "";
            if (rbAgregarItems.Checked == true) {
                Accion = "ADDITEM";
            }
            else if (rbSacaritems.Checked == true) {
                Accion = "LESSITEM";
            }
            else {
                Accion = "";
            }

            if (Accion == "LESSITEM") {

                int StockActual = Convert.ToInt32(txtStockActual_Suplir_Sacar.Text);
                int StockNuevo = Convert.ToInt32(txtStockNuevo_Suplir_Sacar.Text);

                if (StockNuevo > StockActual)
                {
                    ClientScript.RegisterStartupScript(GetType(), "CantidadMayor()", "CantidadMayor();", true);
                }
                else {
                    ProcesarInformacionInventario(Convert.ToInt32(lbIdregistroSeleccionado.Text), Convert.ToInt32(txtStockNuevo_Suplir_Sacar.Text), Accion);
                    ClientScript.RegisterStartupScript(GetType(), "ProcesoCompletado()", "ProcesoCompletado();", true);
                    ConfiguracionInicialConsultaInventario();
                }
            }
            else {
                ProcesarInformacionInventario(Convert.ToInt32(lbIdregistroSeleccionado.Text), Convert.ToInt32(txtStockNuevo_Suplir_Sacar.Text), Accion);
                ClientScript.RegisterStartupScript(GetType(), "ProcesoCompletado()", "ProcesoCompletado();", true);
                ConfiguracionInicialConsultaInventario();
            }
        }

        protected void btnVolverAtras_Suplir_Sacar_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicialConsultaInventario();
        }

        protected void txtCodigoItem_TextChanged(object sender, EventArgs e)
        {
            CurrentPage_InventarioConsulta = 0;
            MostrarInventario();
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionInventario(Convert.ToInt32(lbIdregistroSeleccionado.Text),Convert.ToInt32(txtStockMantenimiento.Text), lbAccionTomarInventario.Text);
            ConfiguracionInicialConsultaInventario();
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicialConsultaInventario();
        }
    }
}
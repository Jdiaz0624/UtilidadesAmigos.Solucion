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
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas.Suministro
{
    public partial class AdministracionSuministro : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro> ObjDataSuministro = new Lazy<Logica.Logica.LogicaSuministro.LogicaSuministro>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProceso = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();

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
            Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
            lbPantalla.Text = "CONTROL DE INVENTARIO";
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
        private void ProcesarInformacionInventario(decimal IdRegistro, int Stock, string Accion) {

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
        #region CARGAR LAS LISTAS DESPLEGABLES DE LA PANTALLA DE DESPACHO
        private void CargarSucursales() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursalCOnsulta, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficina() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjData.Value.BuscaListas("OFICINA", ddlSucursalCOnsulta.SelectedValue.ToString(), null), true);
        }
        private void CargarDepartamentos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue.ToString(), ddlOficinaConsulta.SelectedValue.ToString()), true);
        }
        private void Cargarusuarios() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlUsuarioConsulta, ObjData.Value.BuscaListas("USUARIOLISTA", ddlSucursalCOnsulta.SelectedValue.ToString(), ddlOficinaConsulta.SelectedValue.ToString(), ddlDepartamentoConsulta.SelectedValue.ToString()), true);
        }
        private void CargarEstatus() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatusSolicitud, ObjData.Value.BuscaListas("ESTATUSSOLICITUD", null, null), true);
        }
        private void CargarListasDesplegablesDespacho() {
            CargarSucursales();
            CargarOficina();
            CargarDepartamentos();
            Cargarusuarios();
            CargarEstatus();

        }
        #endregion
        #region CONFIGURACION INICIAL PANTALLA DE DESPACHO
        private void ConfiguracionInicialDespacho() {
            Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
            lbPantalla.Text = "DEPACHO DE SOLICITUD";
            rbSolicitudes.Checked = true;
            DIVBloqueSolicitudes.Visible = true;
            DIVBloqueAdministracionInventario.Visible = false;
            DivSubBloqueInventarioConsulta.Visible = false;
            DivSubBloqueInventarioMantenimiento.Visible = false;
            UtilidadesAmigos.Logica.Comunes.Rangofecha Fechas = new Logica.Comunes.Rangofecha();
            Fechas.FechaMes(ref txtFechaDesde, ref txtFEcfaHasta);
            CargarListasDesplegablesDespacho();
            DIvBloqueDetalleRegistro.Visible = false;
            CurrentPage_SolicitudHeader = 0;
            MostrarSolicitudes();
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS SOLICITUDES
        private void MostrarSolicitudes() {
            decimal? _NumeroSolciitud = string.IsNullOrEmpty(txtNumeroSolicitud.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroSolicitud.Text);
            int? _Sucursal = ddlSucursalCOnsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSucursalCOnsulta.SelectedValue) : new Nullable<int>();
            int? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlOficinaConsulta.SelectedValue) : new Nullable<int>();
            int? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlDepartamentoConsulta.SelectedValue) : new Nullable<int>();
            decimal? _Usuario = ddlUsuarioConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlUsuarioConsulta.SelectedValue) : new Nullable<decimal>();
            DateTime? _FechaDesde = cbAgregarRangoFecha.Checked == false ? Convert.ToDateTime(txtFechaDesde.Text) : new Nullable<DateTime>();
            DateTime? _FechaHasta = cbAgregarRangoFecha.Checked == false ? Convert.ToDateTime(txtFEcfaHasta.Text) : new Nullable<DateTime>();
            int? _Estatus = ddlEstatusSolicitud.SelectedValue != "-1" ? Convert.ToInt32(ddlEstatusSolicitud.SelectedValue) : new Nullable<int>();
            int CantidadSolicitudes = 0, Activas = 0, Procesadas = 0, Canceladas = 0, Rechazadas = 0, Pendientes = 0;

            var Listado = ObjDataSuministro.Value.BuscaListadoSolicitudesHeader(
                _Sucursal,
                _Oficina,
                _Departamento,
                _Usuario,
                _NumeroSolciitud,
                _FechaDesde,
                _FechaHasta,
                _Estatus);
            if (Listado.Count() < 1) {

                lbCantidadSolicitudes.Text = "0";
                lbSolicitudesActivas.Text = "0";
                lbSolicitudesProcesadas.Text = "0";
                lbSolicitudesCanceladas.Text = "0";
                lbSolicitudesRechazadas.Text = "0";
                rpSolicitudesHeader.DataSource = null;
                rpSolicitudesHeader.DataBind();
            }
            else {

                foreach (var n in Listado) {
                    CantidadSolicitudes = (int)n.CantidadSolicitudes;
                    Activas = (int)n.CantidadSolicitudes_Activas;
                    Procesadas = (int)n.CantidadSolicitudes_Procesadas;
                    Canceladas = (int)n.CantidadSolicitudes_Canceladas;
                    Rechazadas = (int)n.CantidadSolicitudes_Rechazadas;
                    Pendientes = (int)n.CantidadSolicitudes_Pendientes;
                }
                lbCantidadSolicitudes.Text = CantidadSolicitudes.ToString("N0");
                lbSolicitudesActivas.Text = Activas.ToString("N0");
                lbSolicitudesProcesadas.Text = Procesadas.ToString("N0");
                lbSolicitudesCanceladas.Text = Canceladas.ToString("N0");
                lbSolicitudesRechazadas.Text = Rechazadas.ToString("N0");
                lbSolicitudesPendientes.Text = Pendientes.ToString("N0");
                Paginar_SolicitudHeader(ref rpSolicitudesHeader, Listado, 10, ref lbCantidadPaginaVariable, ref btnPrimeraPagina_SolicitudesHeader, ref btnPaginaAnterior_SolicitudesHeader, ref btnSiguientePagina_SolicitudesHeader, ref btnUltimaPagina_SolicitudesHeader);
                HandlePaging_SolicitudHeader(ref dtPaginacion, ref lbPaginaActualVariable);
            }
        }
        #endregion
        #region CAMBIAR EL ESTATUS DE LA SOLICITUD
        private void CambiarEstatusSolicitud(decimal NumeroSolicitud, string NumeroConector, int Estatus) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroHeader Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroHeader(
                NumeroSolicitud,
                NumeroConector,
                0,
                Estatus,
                "CHANGESTATUS");
            Procesar.ProcesarInformacion();
            DIVBloqueCOmpletado.Visible = true;
            DIVBloqueAdministracionInventario.Visible = false;
            DIVBloqueSolicitudes.Visible = false;
            DivTipoOperacion.Visible = false;
        }
        #endregion
        #region ENVIO DE CORREO
        private void EnvioCorreo(string CorreoEmisor, string Alias, string Asunto, string ClaveCorreo, int Puerto, string SMTP, string Cuerpo, string CorreoEmpleado)
        {
            UtilidadesAmigos.Logica.Comunes.EnvioCorreos MAil = new Logica.Comunes.EnvioCorreos
            {
                Mail = CorreoEmisor,
                Alias = Alias,
                Asunto = Asunto,
                Clave = ClaveCorreo,
                Puerto = Puerto,
                smtp = SMTP,
                RutaImagen = Server.MapPath("LogoReducido.jpg"),
                Cuerpo = Cuerpo,
                Destinatarios = new List<string>(),
                Adjuntos = new List<string>()
            };

            MAil.Destinatarios.Add(CorreoEmpleado);
          //  MAil.Adjuntos.Add(VolantePagoTXT);
            // MAil.Adjuntos.Add(VolantePagoTXT);

            // MAil.Enviar(MAil);

            if (MAil.Enviar(MAil))
            {

            }
        }

        #endregion
        #region ENVIAR CORREO ELECTRONICO
        private void EnviarCorreoElectronico(string Estatus,string CorreoUsuario, ref TextBox Comentario) {

            try {
                string ComentarioValor = "";
                if (string.IsNullOrEmpty(Comentario.Text.Trim())) {
                    ComentarioValor = "";
                }
                else {
                    ComentarioValor = " | Comentario de Despacho: " + Comentario.Text;
                }
                //SACAMOS TODA LA INFORMACION DEL CORREO EMISOR DESDE DONDE SE ENVIARAN LOS VOLANTES DE PAGOS.
                string CorreoEmisor = "", Alias = "Utilidades Futuro Seguros", Asunto = "Solicitud " + Estatus, ClaveCorreo = "", SMTP = "", Cuerpo = "Su solicitud No. " + lbNumeroSolicitud_Detalle_Variable.Text + " en fecha " + lbFecha_Detalle_Variable.Text + " a las " + lbHora_Detalle_Variable.Text + " Fue " + Estatus + ComentarioValor;
                int Puerto = 0;
                var SacarInformacionCorreos = ObjDataProceso.Value.ListadoCorreosEmisores(1, (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CorreosEmisiorSistema.Suministro_Inventario);
                foreach (var nCorreo in SacarInformacionCorreos)
                {
                    CorreoEmisor = nCorreo.Correo;
                    ClaveCorreo = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(nCorreo.Clave);
                    SMTP = nCorreo.SMTP;
                    Puerto = (int)nCorreo.Puerto;
                }

                EnvioCorreo(
                                 CorreoEmisor,
                                 Alias,
                                 Asunto,
                                 ClaveCorreo,
                                 Puerto,
                                 SMTP,
                                 Cuerpo,
                                 CorreoUsuario);
                lbNotificacionEnviadaAlCorreoVariable.Text = "SI";
            }
            catch (Exception Error) {
                lbNotificacionEnviadaAlCorreoVariable.Text = "NO";
                lbCodigoError.Visible = true;
                lbCodigoError.ForeColor = System.Drawing.Color.Red;
                lbCodigoErrorVariable.Text = Error.Message;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                ConfiguracionInicialDespacho();
                DIVBloqueCOmpletado.Visible = false;
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
                ConfiguracionInicialDespacho();
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
            CargarOficina();
            CargarDepartamentos();
            Cargarusuarios();
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentos();
            Cargarusuarios();
        }

        protected void ddlDepartamentoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargarusuarios();

        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_SolicitudHeader = 0;
            MostrarSolicitudes();
        }

        protected void btnReporteSolicitudes_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVer_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var NumeroSolicitud = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroSolicitudHeader")).Value.ToString();
            var NumeroCOnector = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroConectorHeader")).Value.ToString();
            string NumeroSoliciud = "",NumeroConector="", FechaSolicitud = "", HoraSolicitud = "", Sucursal = "", Oficina = "", Departamento = "", Usuario = "",  EsatusActual = "";
            int CantidadArticulos = 0, EstatusSolicitud = 0;
            decimal IdUsuario = 0;


            //CARGAMOS LAS VARIABLES
            var CargarVariables = ObjDataSuministro.Value.BuscaListadoSolicitudesHeader(
                null, null, null, null,
                Convert.ToDecimal(NumeroSolicitud),
                null, null, null);
            foreach (var n in CargarVariables) {
                NumeroSoliciud = n.NumeroSolicitud.ToString();
                NumeroConector = n.NumeroConector;
                FechaSolicitud = n.Fecha;
                HoraSolicitud = n.Hora;
                Sucursal = n.Sucursal;
                Oficina = n.Oficina;
                Departamento = n.Departamento;
                Usuario = n.Persona;
                CantidadArticulos = (int)n.CantidadItems;
                EsatusActual = n.Estatus;
                EstatusSolicitud = (int)n.EstatusSolicitud;
                IdUsuario = (decimal)n.IdUsuario;
            }
            lbNumeroSolicitud_Detalle_Variable.Text = NumeroSoliciud;
            lbNumeroConector_Detalle_Variable.Text = 
            lbFecha_Detalle_Variable.Text = FechaSolicitud;
            lbHora_Detalle_Variable.Text = HoraSolicitud;
            lbSucursal_Detalle_Variable.Text = Sucursal;
            lbOficina_Detalle_Variable.Text = Oficina;
            lbDepartamento_Detalle_Variable.Text = Departamento;
            lbUsuario_Detalle_Variable.Text = Usuario;
            lbArticulos_Detalle_Variable.Text = EsatusActual;
            lbEstatus_Detalle_Variable.Text = CantidadArticulos.ToString("N0");
            lbNumeroConector_Detalle_Variable.Text = NumeroConector;
            lbIdUsuario_Detalle_variable.Text = IdUsuario.ToString();




            DIvBloqueDetalleRegistro.Visible = true;
            DivSubBloqueHeader.Visible = false;
            DivTipoOperacion.Visible = false;

            var SacarInformacionDetalle = ObjDataSuministro.Value.BuscaDetalleSolicitud(NumeroCOnector);
            rpSolicitudDetalle.DataSource = SacarInformacionDetalle;
            rpSolicitudDetalle.DataBind();

            if (EstatusSolicitud == (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Activa || EstatusSolicitud == (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Pendiente)
            {
                btnProcesar.Visible = true;
                btnCancelarSolicitud.Visible = true;
                btnRechazarSolicitud.Visible = true;
            }
            else
            {
                btnProcesar.Visible = false;
                btnCancelarSolicitud.Visible = false;
                btnRechazarSolicitud.Visible = false;

            }
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
            decimal NumeroSolicitud = Convert.ToDecimal(lbNumeroSolicitud_Detalle_Variable.Text);
            string NumeroConector = lbNumeroConector_Detalle_Variable.Text;
            decimal IdUsuario = Convert.ToDecimal(lbIdUsuario_Detalle_variable.Text);
            UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Dato = new Logica.Comunes.SacarNombreUsuario(IdUsuario);
            string Correo = Dato.SacarCorreoUsuario();
            CambiarEstatusSolicitud(
                NumeroSolicitud,
                NumeroConector,
                (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Procesada);


            EnviarCorreoElectronico("Procesada", Correo, ref txtComentarioSolicitud);
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
            cbObviarNoProcede.Checked = false;
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

        protected void btnCancelarSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            decimal NumeroSolicitud = Convert.ToDecimal(lbNumeroSolicitud_Detalle_Variable.Text);
            string NumeroConector = lbNumeroConector_Detalle_Variable.Text;
            decimal IdUsuario = Convert.ToDecimal(lbIdUsuario_Detalle_variable.Text);
            UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Dato = new Logica.Comunes.SacarNombreUsuario(IdUsuario);
            string Correo = Dato.SacarCorreoUsuario();
            CambiarEstatusSolicitud(
                NumeroSolicitud,
                NumeroConector,
                (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Cancelada);
            EnviarCorreoElectronico("Cancelada", Correo,ref txtComentarioSolicitud);

        }

        protected void btnRechazarSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            decimal NumeroSolicitud = Convert.ToDecimal(lbNumeroSolicitud_Detalle_Variable.Text);
            string NumeroConector = lbNumeroConector_Detalle_Variable.Text;
            decimal IdUsuario = Convert.ToDecimal(lbIdUsuario_Detalle_variable.Text);
            UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Dato = new Logica.Comunes.SacarNombreUsuario(IdUsuario);
            string Correo = Dato.SacarCorreoUsuario();
            CambiarEstatusSolicitud(
                NumeroSolicitud,
                NumeroConector,
                (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Rechazada);
            EnviarCorreoElectronico("Rechazada", Correo,ref txtComentarioSolicitud);
        }

        protected void btnVolverAtrasSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            DIvBloqueDetalleRegistro.Visible = false;
            DivSubBloqueHeader.Visible = true;
            DivTipoOperacion.Visible = true;
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Suministro/AdministracionSuministro.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
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
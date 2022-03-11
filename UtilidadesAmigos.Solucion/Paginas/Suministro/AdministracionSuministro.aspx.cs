﻿using System;
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

        #region CONFIGURACION INICIAL DE LA PANTALLA DE INVENTARIO
        private void ConfiguracionInicialPantallaInventario() {

            DIVBloqueConsultaInventario.Visible = true;
            DIVBloqueMantenimientoInventario.Visible = false;

            txtDescripcionConsultaInventario.Text = string.Empty;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMedida, ObjData.Value.BuscaListas("SUMINISTROTIPOMEDIDA", null, null), true);

            rbEstatusTodos.Checked = true;
            btnConsultarInventario.Visible = true;
            btnNuevoRegistro.Visible = true;
            btnReporte.Visible = true;
            btnSuplirInventario.Visible = false;
            btnEditarInventario.Visible = false;
            btnEliminarInventario.Visible = false;
            btnRestablecerPantalla.Visible = false;
            rpListadoInventario.DataSource = null;
            rpListadoInventario.DataBind();
            CurrentPage_Inventario = 0;
        }
        #endregion

        #region MOSTRAR EL INVENTARIO
        private void MostrarInventario() {

            string _Articulo = string.IsNullOrEmpty(txtDescripcionConsultaInventario.Text.Trim()) ? null : txtDescripcionConsultaInventario.Text.Trim();
            int? _IdMedida = ddlSeleccionarMedida.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMedida.SelectedValue) : new Nullable<int>();
            string _Estatus = "";

            if (rbEstatusTodos.Checked == true) { _Estatus = null; }
            else if (rbEstatusDisponible.Checked == true) { _Estatus = "DISPONIBLE"; }
            else if (rbEstatusPocos.Checked == true) { _Estatus = "PROXIMO AGOTARSE"; }
            else if (rbEstatusAgotados.Checked == true) { _Estatus = "AGOTADO"; }
            else { _Estatus = null; }

            var Inventario = ObjDataSuministro.Value.BuscaInventarioSuministro(
                new Nullable<decimal>(),
                _Articulo,
                _IdMedida,
                _Estatus,
                (decimal)Session["IdUSuario"]);
            if (Inventario.Count() < 1) {
                rpListadoInventario.DataSource = null;
                rpListadoInventario.DataBind();
            }
            else {
                PaginarInventario(ref rpListadoInventario, Inventario, 10, ref lbCantidadPaginaVAriableInventario, ref btnkPrimeraPaginaInventario, ref btnAnteriorInventario, ref btnSiguienteInventario, ref btnUltimoInventario);
                HandlePagingInventario(ref dtPaginacionInventario, ref lbPaginaActualVariableInventario);
            }

        }
        #endregion

        #region PROCESAR LA INFORMACION DEL INVENTARIO
        private void ProcesarInformacionInventario(decimal CodigoArticulo, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroInventario Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroInventario(
                CodigoArticulo,
                txtArticuloMantenimientoInventario.Text,
                Convert.ToInt32(ddlSeleccionarMedidaMantenimientoInventario.SelectedValue),
                Convert.ToInt32(txtStockMantenimientoInventario.Text),
                (decimal)Session["IdUsuario"],
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion

        #region GENERAR REPORTE DE INVENTARIO
        private void GenerarReporteInventario(string RutaReporte, string NombreReporte) {
            string _Articulo = string.IsNullOrEmpty(txtDescripcionConsultaInventario.Text.Trim()) ? null : txtDescripcionConsultaInventario.Text.Trim();
            int? _IdMedida = ddlSeleccionarMedida.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMedida.SelectedValue) : new Nullable<int>();
            string _Estatus = "";

            if (rbEstatusTodos.Checked == true) { _Estatus = null; }
            else if (rbEstatusDisponible.Checked == true) { _Estatus = "DISPONIBLE"; }
            else if (rbEstatusPocos.Checked == true) { _Estatus = "PROXIMO AGOTARSE"; }
            else if (rbEstatusAgotados.Checked == true) { _Estatus = "AGOTADO"; }
            else { _Estatus = null; }

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@CodigoArticulo", new Nullable<decimal>());
            Reporte.SetParameterValue("@Articulo", _Articulo);
            Reporte.SetParameterValue("@IdMedida", _IdMedida);
            Reporte.SetParameterValue("@Estatus", _Estatus);
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

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
                lbPantalla.Text = "ADMINISTRACION DE SUMINISTRO";

                DIVBloqueConsulta.Visible = true;
                DIVBloqueInventario.Visible = false;
            }
        }

        protected void rbSolicitudes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSolicitudes.Checked == true) {
                DIVBloqueConsulta.Visible = true;
                DIVBloqueInventario.Visible = false;
            }
            else {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = false;
            }
        }

        protected void rbInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInventario.Checked == true)
            {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = true;
                ConfiguracionInicialPantallaInventario();
            }
            else
            {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = false;
            }
        }

        protected void btnBuscarInformacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnkPrimeraPaginaEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionEncabezadoSolicitud_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionEncabezadoSolicitud_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEliminarArticulo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnkPrimeraPaginaArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionArticulosSeleccionado_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionArticulosSeleccionado_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnConsultarInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsultaInventario.Visible = false;
            DIVBloqueMantenimientoInventario.Visible = true;
            lbAccionInventario.Text = "INSERT";
            lbCodigoArticuloInventarioSeleccionado.Text = "0";
            txtArticuloMantenimientoInventario.Text = string.Empty;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMedidaMantenimientoInventario, ObjData.Value.BuscaListas("SUMINISTROTIPOMEDIDA", null, null));
            txtStockMantenimientoInventario.Text = string.Empty;
            

        }

        protected void btnReporteInventario_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporteInventario(Server.MapPath("ReporteSuministroInventario.rpt"), "Reporte de Inventario");
        }

        protected void btnSuplirInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEditarInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEliminarInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnRestablecerPantalla_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicialPantallaInventario();
        }

        protected void btnSeleccionarArticuloINventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnkPrimeraPaginaInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void btnAnteriorInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario += -1;
            MostrarInventario();
            MoverValoresPaginacionInventario((int)OpcionesPaginacionValoresInventario.PaginaAnterior, ref lbPaginaActualVariableInventario, ref lbCantidadPaginaVAriableInventario);
        }

        protected void dtPaginacionInventario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionInventario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Inventario = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarInventario();
        }

        protected void btnSiguienteInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario += 1;
            MostrarInventario();
        }

        protected void btnUltimoInventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInventario();
            MoverValoresPaginacionInventario((int)OpcionesPaginacionValoresInventario.UltimaPagina, ref lbPaginaActualVariableInventario, ref lbCantidadPaginaVAriableInventario);
        }

        protected void btnGuardarRegistroMantenimientoInventario_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionInventario(
                Convert.ToDecimal(lbCodigoArticuloInventarioSeleccionado.Text),
                lbAccionInventario.Text);
        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicialPantallaInventario();
        }
    }
}
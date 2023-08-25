using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.ServiceModel.Channels;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Transito
{
    public partial class PolizasConPagosPendientes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaTransito.LogicaTransito> ObjDataTransito = new Lazy<Logica.Logica.LogicaTransito.LogicaTransito>();

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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
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
        #region LISTAS DESPLEGABLES
        private void ListasDesplegables() {
            ListaOficinas();
            ListaRamo();
            ListaSubRamo();
        }
        private void ListaOficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjDataComun.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void ListaRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamo, ObjDataComun.Value.BuscaListas("RAMO", null, null), true);
        }
        private void ListaSubRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubRamo, ObjDataComun.Value.BuscaListas("SUBRAMO", ddlRamo.SelectedValue.ToString(), null), true);
        }
        #endregion
        #region MOSTRAR EL LISTADO 
        private void MostrarListado() {

            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            decimal? _Cliente = string.IsNullOrEmpty(txtCliente.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCliente.Text);
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamo.SelectedValue) : new Nullable<int>();
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            decimal? _Usuario = (decimal)Session["IdUsuario"];

            var Listado = ObjDataTransito.Value.BuscaPolizasConPagosPPendientes(
                _FechaDesde,
                _FechaHasta,
                _Poliza,
                _Cliente,
                _Intermediario,
                _Supervisor,
                _Ramo,
                _SubRamo,
                _Oficina,
                null,
                _Usuario);
            if (Listado.Count() < 1) {

                rpListado.DataSource = null;
                rpListado.DataBind();
            }
            else {

                Paginar(ref rpListado, Listado, 10, ref lbCantidadPagina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
                HandlePaging(ref dtPaginacion, ref lbPaginaActual);
            }
        }
        #endregion

        #region GENERAR REPORTE DE POLIZAS CON PAGOS PENDIENTES
        private void MostrarReportePolizasPagosPendientes() {
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            decimal? _Cliente = string.IsNullOrEmpty(txtCliente.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCliente.Text);
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamo.SelectedValue) : new Nullable<int>();
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            decimal? _Usuario = (decimal)Session["IdUsuario"];

            if (rbExcel.Checked == true) {

                var Exportar = (from n in ObjDataTransito.Value.BuscaPolizasConPagosPPendientes(
                    _FechaDesde,
                    _FechaHasta,
                    _Poliza,
                    _Cliente,
                    _Intermediario,
                    _Supervisor,
                    _Ramo,
                    _SubRamo,
                    _Oficina,
                    null,
                    _Usuario)
                                select new
                                {
                                    Poliza = n.Poliza,
                                    Fecha_Proceso = n.FechaProceso,
                                    Ramo = n.Ramo,
                                    SubRamo = n.SubRamo,
                                    Estatus = n.Estatus,
                                    Oficina = n.Oficina,
                                    Moneda = n.Moneda,
                                    Tasa = n.Tasa,
                                    Codigo_Cliente = n.Cliente,
                                    Nombre_Cliente = n.NombreCliente,
                                    TelefonoOficina = n.TelefonoOficina,
                                    TelefonoResidencia = n.TelefonoResidencia,
                                    Celular = n.Celular,
                                    CodigoI_ntermediario = n.CodigoIntermediario,
                                    Intermediario = n.Intermediario,
                                    Codigo_Supervisor = n.CodigoSupervisor,
                                    NombreSupervisor = n.NombreSupervisor,
                                    Incio_Vigencia = n.IncioVigencia,
                                    Fin_Vigencia = n.FinVigencia,
                                    Valor_Poliza = n.ValorPoliza,
                                    Cobrado = n.Cobrado,
                                    Monto_Pendiente = n.MontoPendiente,
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Polizas con Pagos Pendientes", Exportar);
            }
            else {

                string RutaReporte = "", NombreReporte = "", UsuarioBD = "", ClaveBD = "";

                RutaReporte = Server.MapPath("ReportePolizasConPagospendientes.rpt");
                NombreReporte = "Polizas Con Pagos pendientes";

                UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
                UsuarioBD = Credenciales.SacarUsuario();
                ClaveBD = Credenciales.SacarClaveBD();

                ReportDocument Reporte = new ReportDocument();

                Reporte.Load(RutaReporte);
                Reporte.Refresh();

                Reporte.SetParameterValue("@FechaDesde", _FechaDesde.ToString("yyyy-MM-dd"));
                Reporte.SetParameterValue("@FechaHasta", _FechaHasta.ToString("yyyy-MM-dd"));
                Reporte.SetParameterValue("@Poliza", _Poliza);
                Reporte.SetParameterValue("@Cliente", _Cliente);
                Reporte.SetParameterValue("@Intermediario", _Intermediario);
                Reporte.SetParameterValue("@Supervisor", _Supervisor);
                Reporte.SetParameterValue("@Ramo", _Ramo);
                Reporte.SetParameterValue("@SubRamo", _SubRamo);
                Reporte.SetParameterValue("@Oficina", _Oficina);
                Reporte.SetParameterValue("@Moneda", new Nullable<int>());
                Reporte.SetParameterValue("@IdUsuario", _Usuario);

                Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);

                Reporte.Dispose();
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

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "POLIZAS PENDIENTE DE PAGOS";

                UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
                Fecha.FechaMes(ref txtFechaDesde, ref txtFechaHasta);

                ListasDesplegables();
                rbPDF.Checked = true;
            }
        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            try {
                if (string.IsNullOrEmpty(txtCliente.Text.Trim())) {
                    txtNombreCliente.Text = string.Empty;
                }
                else {
                    UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente Nombre = new Logica.Comunes.ESacarNombreCliente(txtCliente.Text);
                    txtNombreCliente.Text = Nombre.SacarCodigoCLiente();
                }
            }
            catch(Exception) {
            
            }
        }

        protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaSubRamo();
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            try {
                if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim())) {

                    txtNombreIntermediario.Text = string.Empty;
                }
                else {

                    UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
                    txtNombreIntermediario.Text = Nombre.SacarNombreIntermediario();
                }
            }
            catch (Exception) { }
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            try {

                if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
                {

                    txtNombreSupervisor.Text = string.Empty;
                }
                else
                {

                    UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
                    txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
                }
            }
            catch (Exception) { }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListado();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            MostrarReportePolizasPagosPendientes();
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListado();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostrarListado();
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActual, ref lbCantidadPagina);
        }
        protected void ListadoPorPantalla(object sender, EventArgs e) {
            CurrentPage = 0;
            MostrarListado();
        }
    }
}
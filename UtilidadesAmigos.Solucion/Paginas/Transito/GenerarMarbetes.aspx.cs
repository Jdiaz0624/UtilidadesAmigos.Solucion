using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarMarbetes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjdataProcesos = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDaaReporte = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();
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

        #region CARGAR LISTAS DESPLEGABLES
        private void CargarListaDesplegable() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjDataGeneral.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void UsuariosMarbete() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlUsuario, ObjDataGeneral.Value.BuscaListas("USUARIOSMARBETE", ddlOficina.SelectedValue.ToString(), null), true);
        }
        #endregion


        #region MOSTRAR EL LISTADO POR PANTALLA
        private void MostrarListado() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtNumeroItem.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroItem.Text);
            DateTime? _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtVendedor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtVendedor.Text);
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            string _Usuario = ddlUsuario.SelectedValue != "-1" ? ddlUsuario.SelectedItem.Text : null;

            var Listado = ObjDataTransito.Value.GenerarMarbeteTransito(
                _Poliza,
                _Item,
                _FechaDesde,
                _FechaHasta,
                _Supervisor,
                _Intermediario,
                _Oficina,
                null, _Usuario);
            if (Listado.Count() < 1) {
                rpListado.DataSource = null;
                rpListado.DataBind();
            }
            else {

                Paginar(ref rpListado, Listado, 10, ref lbCantidadPagina, ref btnPrimeraPagina_Listado, ref btnPaginaAnterior_Listado, ref btnSiguientePagina_Listado, ref btnUltimaPagina_Listado);
                HandlePaging(ref dtPaginacion_Listado, ref lbPaginaactuall);
            }
        }
        #endregion

        #region IMPRIMIR REPORTE
        private void ImprimirMarbete()
        {
            try
            {
                string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                int? _Item = string.IsNullOrEmpty(txtNumeroItem.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroItem.Text);
                DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
                DateTime _FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
                int? _Supervisor = string.IsNullOrEmpty(txtSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisor.Text);
                int? _Intermediario = string.IsNullOrEmpty(txtVendedor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtVendedor.Text);
                int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
                string _Usuario = ddlUsuario.SelectedValue != "-1" ? ddlUsuario.SelectedItem.Text : null;
                string RutaReporte = "", NombreReporte = "", UsuarioBD = "", ClaveBD = "";

                if (cbImprimirDirectoImpresora.Checked == true) {

                    RutaReporte = Server.MapPath("MarbeteTransitoPDF.rpt");
                }
                else {
                    RutaReporte = Server.MapPath("MarbeteTransitoPDF.rpt");
                }
                NombreReporte = "Listado de Marbetes en Transito";

                UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
                UsuarioBD = Credenciales.SacarUsuario();
                ClaveBD = Credenciales.SacarClaveBD();

                ReportDocument Listado = new ReportDocument();

                Listado.Load(RutaReporte);
                Listado.Refresh();

                Listado.SetParameterValue("@Poliza", _Poliza);
                Listado.SetParameterValue("@Item", _Item);
                Listado.SetParameterValue("@FechaProcesoDesde", _FechaDesde.ToString("yyyy-MM-dd"));
                Listado.SetParameterValue("@FechaProcesoHasta", _FechaHasta.ToString("yyyy-MM-dd"));
                Listado.SetParameterValue("@Supervisor", _Supervisor);
                Listado.SetParameterValue("@Intermediario", _Intermediario);
                Listado.SetParameterValue("@Oficina", _Oficina);
                Listado.SetParameterValue("@PolizaImpresa", null);
                Listado.SetParameterValue("@Usuario", _Usuario);

                Listado.SetDatabaseLogon(UsuarioBD, ClaveBD);

                if (cbImprimirDirectoImpresora.Checked == true) {

                    Listado.PrintOptions.PrinterName = ddlImpresoras.SelectedItem.Text;
                    Listado.PrintToPrinter(1, false, 0, 0);
                }
                else {
                    Listado.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
                }
                Listado.Dispose();
            }
            catch (Exception) { }

        }
        private void ImprimirMarbeteUnico(string Poliza, int NumeroItem)
        {
            try
            {
                string _Usuario = ddlUsuario.SelectedValue != "-1" ? ddlUsuario.SelectedItem.Text : null;
                string RutaReporte = "", NombreReporte = "", UsuarioBD = "", ClaveBD = "";

                if (cbImprimirDirectoImpresora.Checked == true)
                {

                    RutaReporte = Server.MapPath("MarbeteTransitoPDF.rpt");
                }
                else
                {
                    RutaReporte = Server.MapPath("MarbeteTransitoPDF.rpt");
                }
                NombreReporte = "Listado de Marbetes en Transito";

                UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
                UsuarioBD = Credenciales.SacarUsuario();
                ClaveBD = Credenciales.SacarClaveBD();

                ReportDocument Listado = new ReportDocument();

                Listado.Load(RutaReporte);
                Listado.Refresh();

                Listado.SetParameterValue("@Poliza", Poliza);
                Listado.SetParameterValue("@Item", NumeroItem);
                Listado.SetParameterValue("@FechaProcesoDesde", new Nullable<DateTime>());
                Listado.SetParameterValue("@FechaProcesoHasta", new Nullable<DateTime>());
                Listado.SetParameterValue("@Supervisor", new Nullable<int>());
                Listado.SetParameterValue("@Intermediario", new Nullable<int>());
                Listado.SetParameterValue("@Oficina", new Nullable<int>());
                Listado.SetParameterValue("@PolizaImpresa", null);
                Listado.SetParameterValue("@Usuario", null);

                Listado.SetDatabaseLogon(UsuarioBD, ClaveBD);

                if (cbImprimirDirectoImpresora.Checked == true)
                {

                    Listado.PrintOptions.PrinterName = ddlImpresoras.SelectedItem.Text;
                    Listado.PrintToPrinter(1, false, 0, 0);
                }
                else
                {
                    Listado.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
                }
                Listado.Dispose();
            }
            catch (Exception) { }

        }

        #endregion




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR MARBETES";


                foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    ddlImpresoras.Items.Add(strPrinter.ToString());
                }
                UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
                Fecha.FechaMes(ref txtFechaDesde, ref txtFechaHasta);
                CargarListaDesplegable();
                UsuariosMarbete();
                rbTodos.Checked = true;
            }
        }

        protected void btnConsultarInformacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListado();
        }

        protected void txtSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Supervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtSupervisor.Text);
            txtNombreSupervisor.Text = Supervisor.SacarNombreSupervisor();
        }

        protected void txtVendedor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Intermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtVendedor.Text);
            txtNombreVendedor.Text = Intermediario.SacarNombreIntermediario();
        }

        protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
        {
            ImprimirMarbete();
        }

        protected void btnImpresionUnica_Click(object sender, ImageClickEventArgs e)
        {
            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var Poliza = ((HiddenField)RegistroSeleccionado.FindControl("hfPoliza")).Value.ToString();
            var Item = ((HiddenField)RegistroSeleccionado.FindControl("hfSecuencia")).Value.ToString();
            ImprimirMarbeteUnico(Poliza, Convert.ToInt32(Item));
        }

        protected void btnPrimeraPagina_Listado_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListado();
        }

        protected void btnPaginaAnterior_Listado_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaactuall, ref lbCantidadPagina);
        }

        protected void dtPaginacion_Listado_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_Listado_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void btnSiguientePagina_Listado_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostrarListado();
        }

        protected void ddlOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuariosMarbete();
        }

        protected void btnUltimaPagina_Listado_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaactuall, ref lbCantidadPagina);
        }
    }
}
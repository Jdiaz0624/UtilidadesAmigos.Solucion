using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ImpresionCheques : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();
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


           // DivPaginacion.Visible = true;
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
        #region CARGAR EL LISTADO DE LOS BANCOS
        public void CargarListadoBancos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarBanco, ObjDataGeneral.Value.BuscaListas("LISTADOBANCOS", null, null), true);
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS CHEQUES
        private void MostarrListado() {
            string _NumeroCheque = string.IsNullOrEmpty(txtNumeroChequeConsulta.Text.Trim()) ? null : txtNumeroChequeConsulta.Text.Trim();
            string _Beneficiario = string.IsNullOrEmpty(txtBeneficiario.Text.Trim()) ? null : txtBeneficiario.Text.Trim();
            int? _Banco = ddlSeleccionarBanco.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarBanco.SelectedValue) : new Nullable<int>();
            DateTime? _FechaDesde = DateTime.Now;
            DateTime? _FechaHasta = DateTime.Now;
            decimal? _NumeroChequeDesde = 0;
            decimal? _NumeroChequeHasta = 0;
            decimal? _RangoValorDesde = 0;
            decimal? _RangoValorHasta = 0;
            string _Anulado = "";

            if (rbSinParametros.Checked == true)
            {
                _FechaDesde = new Nullable<DateTime>();
                _FechaHasta = new Nullable<DateTime>();
                _NumeroChequeDesde = new Nullable<decimal>();
                _NumeroChequeHasta = new Nullable<decimal>();
                _RangoValorDesde = new Nullable<decimal>();
                _RangoValorHasta = new Nullable<decimal>();

            }
            else if (rbRangoFecha.Checked == true)
            {
                _FechaDesde = string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
                _FechaHasta = string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
                _NumeroChequeDesde = new Nullable<decimal>();
                _NumeroChequeHasta = new Nullable<decimal>();
                _RangoValorDesde = new Nullable<decimal>();
                _RangoValorHasta = new Nullable<decimal>();
            }
            else if (rbRangoCheque.Checked == true)
            {
                _FechaDesde = new Nullable<DateTime>();
                _FechaHasta = new Nullable<DateTime>();
                _NumeroChequeDesde = string.IsNullOrEmpty(txtChequeDesde.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtChequeDesde.Text);
                _NumeroChequeHasta = string.IsNullOrEmpty(txtNumeroChequeHasta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroChequeHasta.Text);
                _RangoValorDesde = new Nullable<decimal>();
                _RangoValorHasta = new Nullable<decimal>();
            }
            else if (rbRangoValor.Checked == true) {
                _FechaDesde = new Nullable<DateTime>();
                _FechaHasta = new Nullable<DateTime>();
                _NumeroChequeDesde = new Nullable<decimal>();
                _NumeroChequeHasta = new Nullable<decimal>();
                _RangoValorDesde = string.IsNullOrEmpty(txtValorDesde.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtValorDesde.Text);
                _RangoValorHasta = string.IsNullOrEmpty(txtVAlorHasta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtVAlorHasta.Text);
            }

            if (rbActivos.Checked == true) {
                _Anulado = "N";
            }
            else if (rbAnulados.Checked == true) {
                _Anulado = "S";
            }
            else if (rbTodos.Checked == true) {
                _Anulado = null;
            }

            var Buscar = ObjDataReportes.Value.GenerarInformacionCheque(
                _NumeroCheque,
                _Beneficiario,
                _FechaDesde,
                _FechaHasta,
                _NumeroChequeDesde,
                _NumeroChequeHasta,
                _RangoValorDesde,
                _RangoValorHasta,
                _Banco,
                _Anulado);
            int CantidadRegistros = Buscar.Count;
            lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
            Paginar(ref rbListadoCheques, Buscar, 10, ref lbCantidadPagina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
            HandlePaging(ref dtPaginacionListadoPrincipal, ref lbPaginaActual);
                
        }
        //GenerarInformacionCheque
        #endregion
        #region GENERAR CHEQUE
        private void GenerarCheque(decimal NumeroCheque, string RutaCheque, string NombreCheque) {

            decimal Idusuario = Session["IdUsuario"] != null ? Convert.ToDecimal(Session["IdUsuario"]) : 0;
            
            ReportDocument Cheque = new ReportDocument();

            Cheque.Load(RutaCheque);
            Cheque.Refresh();

            Cheque.SetParameterValue("@IdUsuario", Idusuario);
            Cheque.SetParameterValue("@NumeroCheque", NumeroCheque);
            Cheque.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                //Cheque.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreCheque);
                // Cheque.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreCheque);
                // Cheque.PrintOptions.PrinterName = GetDefaultPrinter();
                Cheque.PrintOptions.PrinterName = ddlImpresoras.SelectedItem.Text;
                Cheque.PrintToPrinter(1, false, 0, 0);
            }
            else if (rbExcel.Checked == true) {
                Cheque.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreCheque);
            }
            else if (rbWord.Checked == true) {
                Cheque.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreCheque);
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
                lbPantalla.Text = "IMPRESION DE CHEQUES";

                rbActivos.Checked = true;
                rbPDF.Checked = true;
                rbSinParametros.Checked = true;
                DivRangoFecha.Visible = false;
                DivRangoCheque.Visible = false;
                divRangoValor.Visible = false;
                CargarListadoBancos();

                DIVFormatos.Visible = false;

                foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    ddlImpresoras.Items.Add(strPrinter.ToString());
                }
            }
        }

        protected void rbSinParametros_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSinParametros.Checked == true) {
                DivRangoFecha.Visible = false;
                DivRangoCheque.Visible = false;
                divRangoValor.Visible = false;
            }
            else {
                DivRangoFecha.Visible = false;
                DivRangoCheque.Visible = false;
                divRangoValor.Visible = false;
            }
        }

        protected void rbRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRangoFecha.Checked == true) {
                DivRangoFecha.Visible = true;
                DivRangoCheque.Visible = false;
                divRangoValor.Visible = false;
            }
            else {
                DivRangoFecha.Visible = false;
                DivRangoCheque.Visible = false;
                divRangoValor.Visible = false;
            }
        }

        protected void rbRangoValor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRangoValor.Checked == true) {
                DivRangoFecha.Visible = false;
                DivRangoCheque.Visible = false;
                divRangoValor.Visible = true;
            }
            else {
                DivRangoFecha.Visible = false;
                DivRangoCheque.Visible = false;
                divRangoValor.Visible = false;
            }
        }

        protected void rbRangoCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRangoCheque.Checked == true) {
                DivRangoFecha.Visible = false;
                DivRangoCheque.Visible = true;
                divRangoValor.Visible = false;
            }
            else {
                DivRangoFecha.Visible = false;
                DivRangoCheque.Visible = false;
                divRangoValor.Visible = false;
            }
        }


        protected void btnConsultarRegistros_Click(object sender, ImageClickEventArgs e)
        {
            MostarrListado();
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostarrListado();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostarrListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void dtPaginacionListadoPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostarrListado();
        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostarrListado();
        }

        protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
        {
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionChequesImprimir Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionChequesImprimir(
                IdUsuario, 0, DateTime.Now, "", 0, "", "", "", "", "", "DELETE");
            Eliminar.ProcesarInformacion();

            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfNumeroChequeSeleccionado = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroChqeue")).Value.ToString();

            var BuscarRegistros = ObjDataReportes.Value.GenerarInformacionCheque(
                hfNumeroChequeSeleccionado,
                null, null, null, null, null, null, null, null, null);
            string NombreCheque = "";
            string ValorLetras = "";
            decimal NumeroCheque = 0;
            foreach (var n in BuscarRegistros)
            {
                ValorLetras = UtilidadesAmigos.Logica.Comunes.ConvertirNumeroLetras.NumeroALetras(Convert.ToDecimal(n.Valor));

                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionChequesImprimir Procesar = new Logica.Comunes.Reportes.ProcesarInformacionChequesImprimir(
                    IdUsuario,
                    (Decimal)n.NumeroCheque,
                    (DateTime)n.FechaCheque0,
                    n.Concepto1,
                    (decimal)n.Valor,
                    n.Beneficiario1,
                    ValorLetras,
                    n.DiaCheque,
                    n.MesCheque,
                    n.AnoCheque.ToString(),
                    "INSERT");
                Procesar.ProcesarInformacion();
                NumeroCheque = (decimal)n.NumeroCheque;
                NombreCheque = n.Beneficiario1 + " - " + n.Valor.ToString();
            }
            GenerarCheque(NumeroCheque, Server.MapPath("Cheque.rpt"), NombreCheque);
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostarrListado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPagina);
        }

       
    }
}
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

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReporteSobreComision : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

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
        private void HandlePaging(ref DataList NombreDataList, ref Label PaginaActual)
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
            PaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label CantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            CantidadPagina.Text = pagedDataSource.PageCount.ToString();

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
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPagina)
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
                    lbPaginaActual.Text = lbCantidadPagina.Text;
                    break;


            }

        }


        #endregion

        #region BENEFICIARIOS DE SOBRE COMISIONES
        private void MostrarBeneficiariosSobreComisiones() {
            var Listado = ObjDataReportes.Value.BuscaBeneficiariosSobreComisiones();
            rpListadoCodigosSobreComision.DataSource = Listado;
            rpListadoCodigosSobreComision.DataBind();
        }
        #endregion

        #region GENERAR REPORTE DE SOBRE COMISION

        private void GenerarReporte(string RutaReporte, string NombreArchivo) {

            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@CodigoBeneficiario", Convert.ToDecimal(lbCodigobeneficiarioSeleccionado.Text));
            Reporte.SetParameterValue("@IdUsuario", IdUsuario);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "REPORTE DE SOBRE COMISION";

                MostrarBeneficiariosSobreComisiones();
            }
        }

        protected void btnCodigosPermitidos_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultarInformacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechadesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAsta.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtFechadesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHAsta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio()", "FechaHastaVacio();", true);
                }
            }
            else {
                var CodigoBeneficiarioSeleccionado = ((Button)sender).NamingContainer;
                var hfCodigoseleccionado = ((HiddenField)CodigoBeneficiarioSeleccionado.FindControl("hfCodigoBeneficiario")).Value.ToString();

                var PorcientoComisionBeneficiario = ((Button)sender).NamingContainer;
                var hfPorcientoComisionBeneficiario = ((HiddenField)PorcientoComisionBeneficiario.FindControl("hfPorcientoComisionBeneficiario")).Value.ToString();

                lbCodigobeneficiarioSeleccionado.Text = hfCodigoseleccionado;
                lbPorcientoComisionBeneficiario.Text = hfPorcientoComisionBeneficiario;

                //ELIMINAMOS TODA LA INFORMACION REGISTRADA BAJO EL USUAIRO
                decimal IdUsaurio = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionDataCobrosSobreComision EliminarInformacion = new Logica.Comunes.Reportes.ProcesarInformacionDataCobrosSobreComision(
                    0, 0, IdUsaurio, DateTime.Now, DateTime.Now, "", 0, "", "", "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, 0, 0, 0, 0, "DELETE");
                EliminarInformacion.ProcesarInformacion();

                //CONSULTAMOS EL REPORTE DE COBROS PARA LUEGO GUARDAR ESA INFORMACION EN BASE DE DATOS Y MOSTRARLA EN EL RPEATER
                var ReporteCobro = ObjDataReportes.Value.BuscarDataReporteCobrosDetalle(
                    null, null, null,
                    Convert.ToDateTime(txtFechadesde.Text),
                    Convert.ToDateTime(txtFechaHAsta.Text),
                    null, null, null, null, null, null, null, null, null, null, IdUsaurio);
                foreach (var n in ReporteCobro) {
                    UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionDataCobrosSobreComision GuardarInformacion = new Logica.Comunes.Reportes.ProcesarInformacionDataCobrosSobreComision(
                        Convert.ToDecimal(lbCodigobeneficiarioSeleccionado.Text),
                        Convert.ToDecimal(lbPorcientoComisionBeneficiario.Text),
                        IdUsaurio,
                        Convert.ToDateTime(txtFechadesde.Text),
                        Convert.ToDateTime(txtFechaHAsta.Text),
                        n.Poliza,
                        (decimal)n.Numero,
                        n.Concepto,
                        n.NumeroFormateado,
                        n.TipoPago,
                        (decimal)n.CodigoCliente,
                        n.Cliente,
                        (decimal)n.CodigoIntermediario,
                        n.Intermediario,
                        (decimal)n.CodSupervisor,
                        n.NombreSupervisor,
                        (decimal)n.CodigoOficina,
                       n.Oficina,
                       (decimal)n.CodigoRamo,
                       n.Ramo,
                       (decimal)n.CodMoneda,
                       n.Moneda,
                       (decimal)n.Bruto,
                       (decimal)n.Impuesto,
                       (decimal)n.Neto,
                        n.Tasa != null ? (decimal)n.Tasa : 1 ,
                       n.MontoPesos != null ? (decimal)n.MontoPesos : 0,
                       "INSERT");
                    GuardarInformacion.ProcesarInformacion();
                }

                var MostrarListado = ObjDataReportes.Value.ReporteSobreComision(Convert.ToDecimal(lbCodigobeneficiarioSeleccionado.Text), IdUsaurio);
                if (MostrarListado.Count() < 1)
                {
                    lbTotalCobradoVariable.Text = "0";
                    lbComisionPagarVariable.Text = "0";
                    rpCobradoSupervisores.DataSource = null;
                    rpCobradoSupervisores.DataBind();
                }
                else {
                    decimal TotalCObradoNeto = 0, TotalPagar = 0;
                    foreach (var n2 in MostrarListado) {
                        TotalCObradoNeto = (decimal)n2.TotalCobradoNeto;
                        TotalPagar = (decimal)n2.TotalPagar;
                    }
                    lbTotalCobradoVariable.Text = TotalCObradoNeto.ToString("N2");
                    lbComisionPagarVariable.Text = TotalPagar.ToString("N2");
                    Paginar(ref rpCobradoSupervisores, MostrarListado, 10, ref lbCantidadPaginaVAriableCobradoSupervisores, ref LinkPrimeraPaginaCobradoSupervisores, ref LinkAnteriorCobradoSupervisores, ref LinkSiguienteCobradoSupervisores, ref LinkUltimoCobradoSupervisores);
                    HandlePaging(ref dtPaginacionCobradoSupervisores, ref lbPaginaActualVariavleCobradoSupervisores);
                }
            }
        }

        protected void LinkPrimeraPaginaCobradoSupervisores_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorCobradoSupervisores_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionCobradoSupervisores_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCobradoSupervisores_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteCobradoSupervisores_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte(Server.MapPath("ReporteSobreComision.rpt"), "Reporte Sobre Comision");
        }

        protected void LinkUltimoCobradoSupervisores_Click(object sender, EventArgs e)
        {

        }



    
    }
}
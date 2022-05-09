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
    public partial class ReportePrimaDeposito : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjData = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        enum PermisoUsuariosProceso { 
        
            JuanMarcelinoMedinaDiaz=1,
            GinayraLopez=8,
            AlfredoPimentel=10,
            EduardGarcia=12,
            GracyFeliz=19,
            RiselotRojasSantana=21,
            HanoyDiaz=39
        }

        #region CONTROL DE PAGINACION DE LOS PRIMA DEPOSITOS
        readonly PagedDataSource pagedDataSource_PrimaDeposito = new PagedDataSource();
        int _PrimeraPagina_PrimaDeposito, _UltimaPagina_PrimaDeposito;
        private int _TamanioPagina_PrimaDeposito = 10;
        private int CurrentPage_PrimaDeposito
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

        private void HandlePaging_PrimaDeposito(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_PrimaDeposito = CurrentPage_PrimaDeposito - 5;
            if (CurrentPage_PrimaDeposito > 5)
                _UltimaPagina_PrimaDeposito = CurrentPage_PrimaDeposito + 5;
            else
                _UltimaPagina_PrimaDeposito = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_PrimaDeposito > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_PrimaDeposito = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_PrimaDeposito = _UltimaPagina_PrimaDeposito - 10;
            }

            if (_PrimeraPagina_PrimaDeposito < 0)
                _PrimeraPagina_PrimaDeposito = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_PrimaDeposito;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_PrimaDeposito; i < _UltimaPagina_PrimaDeposito; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_PrimaDeposito(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_PrimaDeposito.DataSource = Listado;
            pagedDataSource_PrimaDeposito.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_PrimaDeposito.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_PrimaDeposito.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_PrimaDeposito.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_PrimaDeposito : _NumeroRegistros);
            pagedDataSource_PrimaDeposito.CurrentPageIndex = CurrentPage_PrimaDeposito;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_PrimaDeposito.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_PrimaDeposito.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_PrimaDeposito.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_PrimaDeposito.IsLastPage;

            RptGrid.DataSource = pagedDataSource_PrimaDeposito;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_PrimaDeposito
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_PrimaDeposito(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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




        #region MOSTRAR EL LISTADO DE LOS DEPOSITOS 
        private void MostrarListadoPromaDeposito() {

            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
            decimal? _NumeroDeposito = string.IsNullOrEmpty(txtNumeroDeposito.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDeposito.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            string Estatus = "";
            if (rbTodos.Checked == true) {
                Estatus = null;
            }
            else if (rbPendientes.Checked == true) {
                Estatus = "Pendiente";
            }
            else if (rbPagados.Checked == true) {
                Estatus = "Pagado";
            }

            var Listado = ObjData.Value.BuscaPrimaDeposito(
                _NumeroDeposito,
                _FechaDesde,
                _FechaHasta,
                _Supervisor,
                _Intermediario,
                Estatus,
                (decimal)Session["Idusuario"]);
            if (Listado.Count() < 1) {
                rpListadoPrimaDeposito.DataSource = null;
                rpListadoPrimaDeposito.DataBind();
            }
            else {
                Paginar_PrimaDeposito(ref rpListadoPrimaDeposito, Listado, 10, ref lbCantidadPaginaVAriablePrimaDeposito, ref btnPrimeraPaginaPrimaDeposito, ref btnPrimeraPaginaPrimaDeposito, ref btnSiguientePrimaDeposito, ref btnUltimoPrimaDeposito);
                HandlePaging_PrimaDeposito(ref dtPaginacionPrimaDeposito, ref lbPaginaActualVariablePrimaDeposito);
            }
        }
        #endregion

        #region VALIDACION DE PRIMA A DEPOSITO
        private string ValidarDeposito(decimal Deposito, decimal Monto) {

            string Resltado = "";

            var Validar = ObjData.Value.ValidarDepositosPagados(Deposito, Monto);
            foreach (var n in Validar) {
                Resltado = n.Validacion;
            }
            return Resltado;
        }
        #endregion

        #region PROCESAR LA INFORMACION DE LOS DEPOSITOS
        private void ProcesarInformacionDepositos(decimal Deposito, decimal Monto, string Accion) {

            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionPrimaDepositos Procesar = new Logica.Comunes.Reportes.ProcesarInformacionPrimaDepositos(
                Deposito,
                Monto,
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion

        #region GENERAR REPORTES
        private void GenerarReporte(string RutaReporte, string NombreReporte) {

            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHasta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);
            decimal? _NumeroDeposito = string.IsNullOrEmpty(txtNumeroDeposito.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDeposito.Text);
            //decimal? _NumeroRecibo = string.IsNullOrEmpty(txtRecibo.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtRecibo.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
            string Estatus = "";
            if (rbTodos.Checked == true)
            {
                Estatus = null;
            }
            else if (rbPendientes.Checked == true)
            {
                Estatus = "Pendiente";
            }
            else if (rbPagados.Checked == true)
            {
                Estatus = "Pagado";
            }

            if (rbExelPlano.Checked == true) {

                var Exportar = (from n in ObjData.Value.BuscaPrimaDeposito(
                    _NumeroDeposito,
                    _FechaDesde,
                    _FechaHasta,
                    _Supervisor,
                    _Intermediario,
                   Estatus,
                   (decimal)Session["IdUsuario"])
                                select new
                                {
                                    Deposito = n.NumeroDeposito,
                                    Fecha = n.Fecha,
                                    MontoAplicado = n.MontoPagado,
                                    MontoDeposito = n.MontoDeposito,
                                    MontoEnPrima = n.MontoPrima,
                                    Supervisor = n.Supervisor,
                                    Intermediario = n.Intermediario,
                                    Estatus = n.Estatus
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreReporte, Exportar);
            
            }
            else {

                ReportDocument Reporte = new ReportDocument();

                Reporte.Load(RutaReporte);
                Reporte.Refresh();

                Reporte.SetParameterValue("@NumeroDeposito", _NumeroDeposito);
                Reporte.SetParameterValue("@FechaDesde", _FechaDesde);
                Reporte.SetParameterValue("@FechaHasta", _FechaHasta);
                Reporte.SetParameterValue("@Supervisor", _Supervisor);
                Reporte.SetParameterValue("@Intermediario", _Intermediario);
                Reporte.SetParameterValue("@Estatus", Estatus);
                Reporte.SetParameterValue("@Usuario", (decimal)Session["IdUsuario"]);

                Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

                if (rbPDF.Checked == true)
                {
                    Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
                }
                else if (rbExcel.Checked == true)
                {
                    Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                rbPendientes.Checked = true;
                rbPDF.Checked = true;
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PrimaDeposito = 0;
            MostrarListadoPromaDeposito();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporte(Server.MapPath("DepositosEnPrima.rpt"), "Depositos en prima");
        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {
            var DepositoSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfDepositoSeleccionado = ((HiddenField)DepositoSeleccionado.FindControl("hfNumeroDeposito")).Value.ToString();

            var MontoSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfMontoSeleccionado = ((HiddenField)MontoSeleccionado.FindControl("hfMontoDeposito")).Value.ToString();

            string Validacion = ValidarDeposito(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado));
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
            switch (Validacion) {

                case "SI":
                    //VALIDAMOS SI EL USUARIO TIENE PERMISO PARA ELIMINAR EL REGISTRO
                    

                    switch (IdUsuario) {

                        case (decimal)PermisoUsuariosProceso.JuanMarcelinoMedinaDiaz:
                            ProcesarInformacionDepositos(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado), "DELETE");
                            MostrarListadoPromaDeposito();
                            break;

                        default:
                            ClientScript.RegisterStartupScript(GetType(), "USuarioNoValido()", "USuarioNoValido();", true);
                            break;
                    }
                    break;

                case "NO":

                    switch (IdUsuario) {

                        case (decimal)PermisoUsuariosProceso.JuanMarcelinoMedinaDiaz:
                            ProcesarInformacionDepositos(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado), "INSERT");
                            MostrarListadoPromaDeposito();
                            break;

                        case (decimal)PermisoUsuariosProceso.GinayraLopez:
                            ProcesarInformacionDepositos(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado), "INSERT");
                            MostrarListadoPromaDeposito();
                            break;

                        case (decimal)PermisoUsuariosProceso.AlfredoPimentel:
                            ProcesarInformacionDepositos(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado), "INSERT");
                            MostrarListadoPromaDeposito();
                            break;

                        case (decimal)PermisoUsuariosProceso.EduardGarcia:
                            ProcesarInformacionDepositos(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado), "INSERT");
                            MostrarListadoPromaDeposito();
                            break;

                        case (decimal)PermisoUsuariosProceso.GracyFeliz:
                            ProcesarInformacionDepositos(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado), "INSERT");
                            MostrarListadoPromaDeposito();
                            break;

                        case (decimal)PermisoUsuariosProceso.RiselotRojasSantana:
                            ProcesarInformacionDepositos(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado), "INSERT");
                            MostrarListadoPromaDeposito();
                            break;

                        case (decimal)PermisoUsuariosProceso.HanoyDiaz:
                            ProcesarInformacionDepositos(Convert.ToDecimal(hfDepositoSeleccionado), Convert.ToDecimal(hfMontoSeleccionado), "INSERT");
                            MostrarListadoPromaDeposito();
                            break;

                        default:
                            ClientScript.RegisterStartupScript(GetType(), "USuarioNoValido()", "USuarioNoValido();", true);
                            break;


                    }


                  
                    break;

                default:
                    ClientScript.RegisterStartupScript(GetType(), "ErrorValidacion()", "ErrorValidacion();", true);
                    break;
            }
        }

        protected void btnPrimeraPaginaPrimaDeposito_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PrimaDeposito = 0;
            MostrarListadoPromaDeposito();
        }

        protected void btnAnteriorPrimaDeposito_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PrimaDeposito += -1;
            MostrarListadoPromaDeposito();
            MoverValoresPaginacion_PrimaDeposito((int)OpcionesPaginacionValores_PrimaDeposito.PaginaAnterior, ref lbPaginaActualVariablePrimaDeposito, ref lbCantidadPaginaVAriablePrimaDeposito);
        }

        protected void dtPaginacionPrimaDeposito_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionPrimaDeposito_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_PrimaDeposito = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoPromaDeposito();
        }

        protected void btnSiguientePrimaDeposito_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PrimaDeposito += 1;
            MostrarListadoPromaDeposito();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = Nombre.SacarNombreIntermediario();
        }

        protected void btnProcesarInformacionNuevo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoPrimaDeposito_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PrimaDeposito = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoPromaDeposito();
            MoverValoresPaginacion_PrimaDeposito((int)OpcionesPaginacionValores_PrimaDeposito.UltimaPagina, ref lbPaginaActualVariablePrimaDeposito, ref lbCantidadPaginaVAriablePrimaDeposito);
        }
    }
}
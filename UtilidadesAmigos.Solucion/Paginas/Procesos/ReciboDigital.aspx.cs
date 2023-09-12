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

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class ReciboDigital : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProceso = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

   

     

        #region CONTROL DE PAGINACION DE LOS RECIBOS DIGITALES
        readonly PagedDataSource pagedDataSource_ReciboDigital = new PagedDataSource();
        int _PrimeraPagina_ReciboDigital, _UltimaPagina_ReciboDigital;
        private int _TamanioPagina_ReciboDigital = 10;
        private int CurrentPage_ReciboDigital
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

        private void HandlePaging_ReciboDigital(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ReciboDigital = CurrentPage_ReciboDigital - 5;
            if (CurrentPage_ReciboDigital > 5)
                _UltimaPagina_ReciboDigital = CurrentPage_ReciboDigital + 5;
            else
                _UltimaPagina_ReciboDigital = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ReciboDigital > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ReciboDigital = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ReciboDigital = _UltimaPagina_ReciboDigital - 10;
            }

            if (_PrimeraPagina_ReciboDigital < 0)
                _PrimeraPagina_ReciboDigital = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ReciboDigital;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ReciboDigital; i < _UltimaPagina_ReciboDigital; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ReciboDigital(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ReciboDigital.DataSource = Listado;
            pagedDataSource_ReciboDigital.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ReciboDigital.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ReciboDigital.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ReciboDigital.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ReciboDigital : _NumeroRegistros);
            pagedDataSource_ReciboDigital.CurrentPageIndex = CurrentPage_ReciboDigital;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ReciboDigital.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ReciboDigital.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ReciboDigital.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ReciboDigital.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ReciboDigital;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ReciboDigital
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ReciboDigital(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CARGAR LISTAS
        private void TipoPagoConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoPagoConsulta, ObjDataComun.Value.BuscaListas("TIPOPAGORECIBO", null, null), true);
        }
        private void TipoPagoMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoPago, ObjDataComun.Value.BuscaListas("TIPOPAGORECIBO", null, null));
        }

        private void Oficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjDataComun.Value.BuscaListas("OFICINASINSUCURSAL", null, null),true);
        }
        #endregion

        #region MOSTRAR EL LISTADO 
        private void MostrarListado()
        {

            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermedirioConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedirioConsulta.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSupervisorConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisorConsulta.Text);
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeCosulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeCosulta.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaConsulta.Text);
            int? _IdTipoPago = ddlTipoPagoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoPagoConsulta.SelectedValue) : new Nullable<int>();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            var MostrarListado = ObjDataProceso.Value.BuscaReciboDigital(
                new Nullable<decimal>(),
                _Intermediario,
                _Supervisor,
                _FechaDesde,
                _FechaHasta,
                _IdTipoPago,
                _Oficina
                );
            if (MostrarListado.Count() < 1)
            {
                rpListadoREcibos.DataSource = null;
                rpListadoREcibos.DataBind();
                CurrentPage_ReciboDigital = 0;
            }
            else
            {

                decimal Efectivo = 0, Transferencia = 0, Deposito = 0, Cheque = 0, Otros = 0;
                foreach (var n in MostrarListado) {
                    Efectivo = (decimal)n.TotalEfectivo;
                    Transferencia = (decimal)n.TotalTransferencia;
                    Deposito = (decimal)n.TotalDeposito;
                    Cheque = (decimal)n.TotalCheque;
                    Otros = (decimal)n.TotalOtro;
                }


                lbTotalEfectivo.Text = Efectivo.ToString("N2");
                lbTotalTransferencia.Text = Transferencia.ToString("N2");
                lbTotalDeposito.Text = Deposito.ToString("N2");
                lbTotalCheque.Text = Cheque.ToString("N2");
                lbTotalOtros.Text = Otros.ToString("N2");

                Paginar_ReciboDigital(ref rpListadoREcibos, MostrarListado, 10, ref lbCantidadPagina, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePagina, ref btnUltimaPagina);
                HandlePaging_ReciboDigital(ref dtPaginacionListadoPrincipal, ref lbPaginaActual);
            }
        }
        #endregion

        #region SACAR LA OFICINA DE LOS USUARIOS
        private int SacaroficinaUsuario(decimal IdUsuario) {
            int CodigoOficina = 0;

            var SacarInformacion = ObjDataComun.Value.BuscaUsuarios(IdUsuario);
            foreach (var n in SacarInformacion) {
                CodigoOficina = (int)n.IdOficina;
            }
            return CodigoOficina;
        }
        #endregion

        #region PROCESAR INFORMACION
        private void ProcesarInformacion(decimal IdRegistro, string Accion)
        {
            decimal IdUsuario = (decimal)Session["IdUsuario"];
            int IdOficina = SacaroficinaUsuario(IdUsuario);
            

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionREcibosDigitales Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionREcibosDigitales(
                IdRegistro,
                Convert.ToInt32(txtCodigoIntermediario.Text),
                DateTime.Now,
                Convert.ToDecimal(txtValorAplicar.Text),
                Convert.ToInt32(ddlSeleccionarTipoPago.SelectedValue),
                txtDetalle.Text,
                IdUsuario,
                IdOficina,
                Accion);
            Procesar.ProcesarInformacion();
            ConfigurarcionInicial();
        }
        #endregion

        #region GENERAR REPORTE EN LOTE
        private void GenerarReporteEnLote() {

            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermedirioConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedirioConsulta.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSupervisorConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisorConsulta.Text);
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesdeCosulta.Text);
            DateTime _FechaHasta = Convert.ToDateTime(txtFechaHastaConsulta.Text);
            int? _IdTipoPago = ddlTipoPagoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoPagoConsulta.SelectedValue) : new Nullable<int>();
            int? _oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            string UsuarioBD = "", ClavdBD = "";

            UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
            UsuarioBD = Credenciales.SacarUsuario();
            ClavdBD = Credenciales.SacarClaveBD();

            ReportDocument Reporte = new ReportDocument();

            if (cbGenerarReciboConCopia.Checked == true) {
                Reporte.Load(Server.MapPath("RecibosLote.rpt"));
            }
            else {
                Reporte.Load(Server.MapPath("RecibosLoteSinCopia.rpt"));
            }
            Reporte.Refresh();

            Reporte.SetParameterValue("@NumeroRecibo", new Nullable<decimal>());
            Reporte.SetParameterValue("@CodigoIntermediario", _Intermediario);
            Reporte.SetParameterValue("@CodigoSupervisor", _Supervisor);
            Reporte.SetParameterValue("@FechaDesde", _FechaDesde.ToString("yyyy-MM-dd"));
            Reporte.SetParameterValue("@FechaHasta", _FechaHasta.ToString("yyyy-MM-dd"));
            Reporte.SetParameterValue("@IdTipoPago", new Nullable<int>());
            Reporte.SetParameterValue("@Oficina", _oficina);
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon(UsuarioBD, ClavdBD);
            //Reporte.PrintOptions.PrinterName = Reporte.PrintOptions.PrinterName;
            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Recibos en lote");

            Reporte.Close();
            Reporte.Dispose();
        }
        #endregion

        private void ConfigurarcionInicial()
        {
            txtCodigoIntermedirioConsulta.Text = string.Empty;
            txtNombreIntermediarioConsulta.Text = string.Empty;
            txtFechaDesdeCosulta.Text = string.Empty;
            txtFechaHastaConsulta.Text = string.Empty;
            txtSupervisorConsulta.Text = string.Empty;
            txtNombreSupervisorConsulta.Text = string.Empty;


            rbPDF.Checked = true;
   
            TipoPagoConsulta();
            Oficinas();
            DIVBloqueReciboDigitalConsulta.Visible = true;
            BloqueReciboDigitalMantenimiento.Visible = false;

            rpListadoREcibos.DataSource = null;
            rpListadoREcibos.DataBind();
            CurrentPage_ReciboDigital = 0;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "RECIBO DIGITAL";

                ConfigurarcionInicial();

                DateTime _FechaDesde = DateTime.Now, _FechaHasta = DateTime.Now;
                txtFechaDesdeCosulta.Text = _FechaDesde.ToString("yyyy-MM-dd");
                txtFechaHastaConsulta.Text = _FechaHasta.ToString("yyyy-MM-dd");
                CurrentPage_ReciboDigital = 0;
                MostrarListado();
     
            }
        }

        protected void txtCodigoIntermedirioConsulta_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreVendedor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermedirioConsulta.Text);
            txtNombreIntermediarioConsulta.Text = NombreVendedor.SacarNombreIntermediario();
        }

        protected void txtSupervisorConsulta_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreSupervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtSupervisorConsulta.Text);
            txtNombreSupervisorConsulta.Text = NombreSupervisor.SacarNombreSupervisor();
        }

   

      

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital = 0;
            MostrarListado();
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueReciboDigitalConsulta.Visible = false;
            BloqueReciboDigitalMantenimiento.Visible = true;
            txtCodigoIntermediario.Text = string.Empty;
            txtNombreIntermediario.Text = string.Empty;
            txtValorAplicar.Text = string.Empty;
            TipoPagoMantenimiento();
            txtDetalle.Text = string.Empty;
            lbIdRegistroSeleccionado.Text = "0";
            lbAccionTomar.Text = "INSERT";
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermedirioConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedirioConsulta.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSupervisorConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisorConsulta.Text);
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeCosulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeCosulta.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaConsulta.Text);
            int? _IdTipoPago = ddlTipoPagoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlTipoPagoConsulta.SelectedValue) : new Nullable<int>();
            int? _oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

            if (rbExcelPlano.Checked == true)
            {

                var Exportar = (from n in ObjDataProceso.Value.BuscaReciboDigital(
                    new Nullable<decimal>(),
                    _Intermediario,
                    _Supervisor,
                    _FechaDesde,
                    _FechaHasta,
                    _IdTipoPago,
                    _oficina)
                                select new
                                {
                                    NumeroRecibo = n.NumeroRecibo,
                                    Intermediario = n.Intermediario,
                                    Supervisor = n.NombreIntermediario,
                                    Fecha = n.Fecha,
                                    Hora = n.Hora,
                                    ValorRecibo = n.ValorRecibo,
                                    TipoPago = n.TipoPago,
                                    Detalle = n.Detalle,
                                    CreadoPor = n.CreadoPor
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Recibos", Exportar);
            }
            else
            {

                ReportDocument Reporte = new ReportDocument();

                Reporte.Load(Server.MapPath("ReporteRecibos.rpt"));
                Reporte.Refresh();

                Reporte.SetParameterValue("@NumeroRecibo", new Nullable<decimal>());
                Reporte.SetParameterValue("@CodigoIntermediario", _Intermediario);
                Reporte.SetParameterValue("@CodigoSupervisor", _Supervisor);
                Reporte.SetParameterValue("@FechaDesde", _FechaDesde);
                Reporte.SetParameterValue("@FechaHasta", _FechaHasta);
                Reporte.SetParameterValue("@IdTipoPago", _IdTipoPago);
                Reporte.SetParameterValue("@Oficina", _oficina);
                Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

                Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

                if (rbPDF.Checked == true)
                {
                    //Reporte.PrintToPrinter(200, false, 0, 0);
                    //crystalReport.PrintOptions.PrinterName = GetDefaultPrinter();
                    //cprPrinter.PrinterSettings.PrinterName;
                    
                    Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Reporte de Recibos");
                }
                else if (rbExcel.Checked == true)
                {

                    Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Reporte de Recibos");
                }

                Reporte.Close();
                Reporte.Dispose();
            }
        }

        protected void btnRestablecer_Click(object sender, ImageClickEventArgs e)
        {
            ConfigurarcionInicial();
        }

        protected void btnRecibo_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var NumeroRecibo = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroRecibo")).Value.ToString();
            var Oficina = ((HiddenField)ItemSeleccionado.FindControl("hfIdOficina")).Value.ToString();

            ReportDocument Reporte = new ReportDocument();

            if (cbGenerarReciboConCopia.Checked == true) {
                Reporte.Load(Server.MapPath("Recibos.rpt"));
            }
            else {
                Reporte.Load(Server.MapPath("RecibosSinCopia.rpt"));
            }
            Reporte.Refresh();

            Reporte.SetParameterValue("@NumeroRecibo", Convert.ToDecimal(NumeroRecibo));
            Reporte.SetParameterValue("@CodigoIntermediario", new Nullable<int>());
            Reporte.SetParameterValue("@CodigoSupervisor", new Nullable<int>());
            Reporte.SetParameterValue("@FechaDesde", new Nullable<DateTime>());
            Reporte.SetParameterValue("@FechaHasta", new Nullable<DateTime>());
            Reporte.SetParameterValue("@IdTipoPago", new Nullable<int>());
            Reporte.SetParameterValue("@Oficina", Convert.ToInt32(Oficina));
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Recibo de Ingreso");

            Reporte.Close();
            Reporte.Dispose();

        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital = 0;
            MostrarListado();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital += -1;
            MostrarListado();
            MoverValoresPaginacion_ReciboDigital((int)OpcionesPaginacionValores_ReciboDigital.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void dtPaginacionListadoPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ReciboDigital = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital += 1;
            MostrarListado();
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ReciboDigital = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListado();
            MoverValoresPaginacion_ReciboDigital((int)OpcionesPaginacionValores_ReciboDigital.UltimaPagina, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreVendedor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = NombreVendedor.SacarNombreIntermediario();
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacion(
                Convert.ToDecimal(lbIdRegistroSeleccionado.Text),
                lbAccionTomar.Text);
        }

        protected void DirectoImpresora_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var NumeroRecibo = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroRecibo")).Value.ToString();
            var Oficina = ((HiddenField)ItemSeleccionado.FindControl("hfIdOficina")).Value.ToString();

            string UsuarioBD = "", ClavdBD = "";
            UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
            UsuarioBD = Credenciales.SacarUsuario();
            ClavdBD = Credenciales.SacarClaveBD();

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(Server.MapPath("Recibos.rpt"));
            Reporte.Refresh();

            Reporte.SetParameterValue("@NumeroRecibo", Convert.ToDecimal(NumeroRecibo));
            Reporte.SetParameterValue("@CodigoIntermediario", new Nullable<int>());
            Reporte.SetParameterValue("@CodigoSupervisor", new Nullable<int>());
            Reporte.SetParameterValue("@FechaDesde", new Nullable<DateTime>());  
            Reporte.SetParameterValue("@FechaHasta", new Nullable<DateTime>());
            Reporte.SetParameterValue("@IdTipoPago", new Nullable<int>());
            Reporte.SetParameterValue("@Oficina", Convert.ToInt32(Oficina));
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon(UsuarioBD, ClavdBD);
            //Reporte.PrintOptions.PrinterName = Reporte.PrintOptions.PrinterName;
            Reporte.PrintToPrinter(2, true, 0, 2);

            Reporte.Close();
            Reporte.Dispose();
        }

        protected void dtPaginacionListadoPrincipal_CancelCommand1(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ReciboDigital = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListado();
        }

        protected void btnRecibosLote_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporteEnLote();
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            ConfigurarcionInicial();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class GestionCobros : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();

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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
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
        #region BUSCAR REGISTRO
        private void BuscarRegistro() {

            var Listado = ObjDataConsulta.Value.BuscaPolizaGestionCobros(
                txtIngresarPoliza.Text,
                new Nullable<decimal>());
            if (Listado.Count() < 1) {
                ClientScript.RegisterStartupScript(GetType(), "RegistroNoEncontrado()", "RegistroNoEncontrado();", true);
            }
            else {
                DivBloquePrincipal.Visible = false;
                DivInformacionPolizaGeneral.Visible = true;
                DivReporteCOmentarios.Visible = false;
                DivBloqueReporteCOmentario.Visible = false;
                foreach (var n in Listado) {
                    txtPoliza.Text = n.Poliza;
                    txtEstatus.Text = n.Estatus;
                    txtRamp.Text = n.Ramo;
                    txtCliente.Text = n.NombreCliente;
                    lbTelefonos.Text = n.Telefonos;
                    txtDireccion.Text = n.Direccion;
                    txtSupervisor.Text = n.Supervisor;
                    txtIntermediario.Text = n.Intermediario;
                    txtLicencia.Text = n.LicenciaSeguro;
                    txtFechaCreada.Text = n.FechaCreada;
                    txtInicioVigencia.Text = n.InicioVigencia;
                    txtFinVigencia.Text = n.FinVigencia;
                    decimal Facturado = (decimal)n.Facturado;
                    txtFacturado.Text = Facturado.ToString("N2");
                    decimal Cobrado = (decimal)n.Cobrado;
                    txtCobrado.Text = Cobrado.ToString("N2");
                    decimal Balance = (decimal)n.Balance;
                    txtBalance.Text = Balance.ToString("N2");
                    int TotalFacturas = (int)n.TotalFacturas;
                    txtTotalFacturado.Text = TotalFacturas.ToString("N0");
                    int TotalRecibos = (int)n.TotalRecibos;
                    txtTotalRecibos.Text = TotalRecibos.ToString("N0");
                    int TotalReclamaciones = (int)n.TotalReclamaciones;
                    txtTotalRelcamos.Text = TotalReclamaciones.ToString("N0");
                }
                MostrarComentarios(txtPoliza.Text);
                txtCoentario.Text = string.Empty;
                LBid.Text = "0";
                lbAccion.Text = "INSERT";
            }
        }
        #endregion
        #region MOSTRAR LOS COMENTARIOS
        private void MostrarComentarios(string Poliza) {
            var MostrarComentarios = ObjDataConsulta.Value.BuscarComentariosAgregadosPoliza(
                new Nullable<decimal>(),
                Poliza);
            if (MostrarComentarios.Count() < 1) {
                rpListadoCOmentarios.DataSource = null;
                rpListadoCOmentarios.DataBind();
                lbCantidadCOmentariosVariable.Text = "0";
            }
            else {
                Paginar(ref rpListadoCOmentarios, MostrarComentarios, 10, ref lbCantidadPaginaVariableGestionCobros, ref LinkPrimeraPaginaGestionCobros, ref LinkAnteriorGestionCobros, ref LinkSiguienteGestionCobros, ref LinkUltimoGestionCobros);
                HandlePaging(ref dtPaginacionGestionCobros, ref lbPaginaActualVariavleGestionCobros);
                int Cantidad = 0;
                foreach (var n in MostrarComentarios) {
                    Cantidad = (int)n.CantidadRegistros;
                }
                lbCantidadCOmentariosVariable.Text = Cantidad.ToString("N0");
            }
        }
        #endregion
        #region PROCESAR INFORMACION
        /// <summary>
        /// Guardar y Modificar Registros
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Poliza"></param>
        /// <param name="Accion"></param>
        private void ProcesarInformacion(decimal ID, string Poliza, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionComentarioGestionCObros Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionComentarioGestionCObros(
                ID,
                Poliza,
                txtCoentario.Text,
                (decimal)Session["IdUsuario"],
                DateTime.Now,
                Accion);
            Procesar.ProcesarInformacion();
            MostrarComentarios(txtPoliza.Text);
            txtCoentario.Text = string.Empty;
            lbAccion.Text = "INSERT";
            LBid.Text = "0";
        }
        #endregion
        #region GENERAR REPORTE
        private void GenerarReporte(string RutaArchivo, string NombreArchivo) {
            string _Poliza = string.IsNullOrEmpty(txtPolizaReporte.Text.Trim()) ? null : txtPolizaReporte.Text.Trim();
            DateTime? _FechaDesde = cbNoAgregarRangoFecha.Checked == true ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeReporte.Text);
            DateTime? _FechaHAsta = cbNoAgregarRangoFecha.Checked == true ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHAstaReporte.Text);

            try {
                if (rbExcelPlano.Checked == true) {
                    var GenerarExcelPlano = (from n in ObjDataConsulta.Value.BuscarComentariosAgregadosPoliza(
                      new Nullable<decimal>(),
                      _Poliza,
                      _FechaDesde,
                      _FechaHAsta)
                                             select new
                                             {
                                                 Poliza = n.Poliza,
                                                 Comentario = n.Comentario,
                                                 CreadoPor = n.Usuario,
                                                 Fecha = n.Fecha,
                                                 Hora = n.Hora
                                             }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreArchivo, GenerarExcelPlano);
                }
                else {
                    decimal IdUsuarioGenera = (decimal)Session["IdUsuario"];
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionReporteComentarioGestionCobros Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionReporteComentarioGestionCobros(
                        0, "", "", 0, "", DateTime.Now, "", "", 0, IdUsuarioGenera, "DELETE");
                    Eliminar.ProcesarInformacion();

                    var InformacionReporte = ObjDataConsulta.Value.BuscarComentariosAgregadosPoliza(
                        new Nullable<decimal>(),
                      _Poliza,
                      _FechaDesde,
                      _FechaHAsta);
                    if (InformacionReporte.Count() < 1) {
                        ClientScript.RegisterStartupScript(GetType(), "RegistrosNoEncontrados()", "RegistrosNoEncontrados();", true);
                    }
                    else {
                        foreach (var n in InformacionReporte) {
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionReporteComentarioGestionCobros Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionReporteComentarioGestionCobros(
                                0,
                                n.Poliza,
                                n.Comentario,
                                (decimal)n.IdUsuario,
                                n.Usuario,
                                (DateTime)n.FechaProceso,
                                n.Fecha,
                                n.Hora,
                                (int)n.CantidadRegistros,
                                IdUsuarioGenera,
                                "INSERT");
                            Guardar.ProcesarInformacion();
                        }

                        ReportDocument Reporte = new ReportDocument();

                        Reporte.Load(RutaArchivo);
                        Reporte.Refresh();

                        Reporte.SetParameterValue("@IdUsuarioGenera", IdUsuarioGenera);

                        Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

                        if (rbPDF.Checked == true) {
                            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
                        
                        }
                        else if (rbExcel.Checked == true) {
                            Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
                        }

                    }
                }
            }
            catch (Exception EX){
                string Mensaje = EX.Message;
                ClientScript.RegisterStartupScript(GetType(), "ErrorGenerarReporte()", "ErrorGenerarReporte();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVAcio()", "CampoFechaDesdeVAcio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHAstaReporte.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }

            }
           
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                lbAccion.Text = "INSERT";
                LBid.Text = "0";
                btnDeselccionar.Visible = false;
                DivBloqueReporteCOmentario.Visible = false;
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "GESTION DE COBROS";
            }
        }

        protected void btnCOnsultarPOliza_Click(object sender, EventArgs e)
        {
            BuscarRegistro();
            
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lbAccion.Text == "INSERT") {
                ProcesarInformacion(Convert.ToDecimal(LBid.Text), txtPoliza.Text, "INSERT");
            }
            else { ProcesarInformacion(Convert.ToDecimal(LBid.Text), txtPoliza.Text, "UPDATE"); }
        }

        //protected void btnEditar_Click(object sender, EventArgs e)
        //{
        //    /* var RegistroSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
        //    var hfIdRegistroSeleccionado = ((HiddenField)RegistroSeleccionado.FindControl("hfIdRegistroSeleccionado")).Value.ToString();*/
        //    var IDSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
        //    var HFID = ((HiddenField)IDSeleccionado.FindControl("HFID")).Value.ToString();

        //    var PolizaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
        //    var hfPOliza = ((HiddenField)PolizaSeleccionada.FindControl("hfPoliza")).Value.ToString();

        //    LBid.Text = HFID;
        //    lbAccion.Text = "UPDATE";

        //    var BuscarRegistroSeleccionado = ObjDataConsulta.Value.BuscarComentariosAgregadosPoliza(
        //        Convert.ToDecimal(HFID),
        //        hfPOliza);
        //    Paginar(ref rpListadoCOmentarios, BuscarRegistroSeleccionado, 1, ref lbCantidadPaginaVariableGestionCobros, ref LinkPrimeraPaginaGestionCobros, ref LinkAnteriorGestionCobros, ref LinkSiguienteGestionCobros, ref LinkUltimoGestionCobros);
        //    HandlePaging(ref dtPaginacionGestionCobros, ref lbPaginaActualVariavleGestionCobros);
        //    foreach (var n in BuscarRegistroSeleccionado) {
        //        txtCoentario.Text = n.Comentario;
        //    }

        //    LinkPrimeraPaginaGestionCobros.Enabled = false;
        //    LinkAnteriorGestionCobros.Enabled = false;
        //    LinkSiguienteGestionCobros.Enabled = false;
        //    LinkUltimoGestionCobros.Enabled = false;
        //    dtPaginacionGestionCobros.Enabled = false;
        //    btnDeselccionar.Visible = true;
        //}

        protected void LinkPrimeraPaginaGestionCobros_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarComentarios(txtPoliza.Text);
        }

        protected void LinkAnteriorGestionCobros_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarComentarios(txtPoliza.Text);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleGestionCobros, ref lbCantidadPaginaVariableGestionCobros);
        }

        protected void dtPaginacionGestionCobros_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionGestionCobros_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarComentarios(txtPoliza.Text);
        }

        protected void LinkSiguienteGestionCobros_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarComentarios(txtPoliza.Text);
        }

        protected void btnDeselccionar_Click(object sender, EventArgs e)
        {
            LinkPrimeraPaginaGestionCobros.Enabled = true;
            LinkAnteriorGestionCobros.Enabled = true;
            LinkSiguienteGestionCobros.Enabled = true;
            LinkUltimoGestionCobros.Enabled = true;
            dtPaginacionGestionCobros.Enabled = true;
            MostrarComentarios(txtPoliza.Text);
            txtCoentario.Text = string.Empty;
            lbAccion.Text = "INSERT";
            LBid.Text = "0";
            btnDeselccionar.Visible = false;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            DivBloquePrincipal.Visible = true;
            DivInformacionPolizaGeneral.Visible = false;
            txtCoentario.Text = string.Empty;
            txtIngresarPoliza.Text = string.Empty;
            DivReporteCOmentarios.Visible = true;
            cbMostrarReporteCOmentarios.Checked = false;
            DivBloqueReporteCOmentario.Visible = false;
        }

        protected void cbMostrarReporteCOmentarios_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMostrarReporteCOmentarios.Checked == true) {
                DivBloqueReporteCOmentario.Visible = true;
                rbPDF.Checked = true;
                cbNoAgregarRangoFecha.Checked = false;
            }
            else {
                DivBloqueReporteCOmentario.Visible = false;
            }
           
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {

            GenerarReporte(Server.MapPath("ReporteComentarioGestionCobro.rpt"), "Reporte de Comentarios");
        }

        protected void LinkUltimoGestionCobros_Click(object sender, EventArgs e)
        {

            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarComentarios(txtPoliza.Text);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleGestionCobros, ref lbCantidadPaginaVariableGestionCobros);
        }
    }
}
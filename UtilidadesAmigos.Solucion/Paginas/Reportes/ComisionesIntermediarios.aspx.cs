using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ComisionesIntermediarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();

        #region BUSCAR COMISIONES DE INTERMEDIARIOS
        private void GenerarComisionesIntermediarios()
        {
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            string _NumeroPoliza = string.IsNullOrEmpty(txtNumeroPoliza.Text.Trim()) ? null : txtNumeroPoliza.Text.Trim();
            string _Numerorecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? null : txtNumeroRecibo.Text.Trim();
            string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();

            var BuscarRegistros = ObjDataConexion.Value.GenerarComisionIntermediario(
                Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                Convert.ToDateTime(txtFechaHastaComisiones.Text),
                _CodigoIntermediario,
                _Oficina,
                _Ramo,
                Convert.ToDecimal(txtMontoMinimo.Text),
                _NumeroPoliza,
                _Numerorecibo,
                _NumeroFactura,
                Convert.ToDecimal(txtTasaDollar.Text));
            Paginar(ref rpListadoComision, BuscarRegistros, 10, ref lbCantidadPaginaVariable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
            HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);
        }
        #endregion
        #region EXPORTAR LA CONSULTA A EXCEL
        private void ExportarConsultaExcel() {
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            string _NumeroPoliza = string.IsNullOrEmpty(txtNumeroPoliza.Text.Trim()) ? null : txtNumeroPoliza.Text.Trim();
            string _Numerorecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? null : txtNumeroRecibo.Text.Trim();
            string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();

            var ExportarInformacion = (from n in ObjDataConexion.Value.GenerarComisionIntermediario(
                Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                Convert.ToDateTime(txtFechaHastaComisiones.Text),
                _CodigoIntermediario,
                _Oficina,
                _Ramo,
                Convert.ToDecimal(txtMontoMinimo.Text),
               _NumeroPoliza,
               _Numerorecibo,
               _NumeroFactura,
                Convert.ToDecimal(txtTasaDollar.Text))
                                       select new
                                       {
                                           Supervisor = n.Supervisor,
                                           Codigo = n.Codigo,
                                           Intermediario = n.Intermediario,
                                           Oficina = n.Oficina,
                                           NumeroIdentificacion = n.NumeroIdentificacion,
                                           CuentaBanco = n.CuentaBanco,
                                           TipoCuenta = n.TipoCuenta,
                                           Banco = n.Banco,
                                           Cliente = n.Cliente,
                                           Recibo = n.Recibo,
                                           Fecha = n.Fecha,
                                           Factura = n.Factura,
                                           FechaFactura = n.FechaFactura,
                                           Moneda = n.Moneda,
                                           Poliza = n.Poliza,
                                           Producto = n.Producto,
                                           Bruto = n.Bruto,
                                           Neto = n.Neto,
                                           PorcientoComision = n.PorcientoComision,
                                           Comision = n.Comision,
                                           Retencion = n.Retencion,
                                           AvanceComision = n.AvanceComision,
                                           ALiquidar = n.ALiquidar,
                                           //CantidadRegistros = n.CantidadRegistros
                                       }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comisiones de intermediarios", ExportarInformacion);
        }
        #endregion
        #region EXPORTAR COMISIONES
        private void ExportarComisionesIntermediarios()
        {

            try
            {
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta()", "ErrorConsulta();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                    }
                }
                else
                {
                    //ELIMINAMOS LOS REGISTROS
                    UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                        Convert.ToDecimal(Session["IdUsuario"]), "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
                    Eliminar.ProcesarInformacion();

                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
                    int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    string _NumeroPoliza = string.IsNullOrEmpty(txtNumeroPoliza.Text.Trim()) ? null : txtNumeroPoliza.Text.Trim();
                    string _Numerorecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? null : txtNumeroRecibo.Text.Trim();
                    string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();

                    var GenerarComisiones = ObjDataConexion.Value.GenerarComisionIntermediario(
                        Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                        Convert.ToDateTime(txtFechaHastaComisiones.Text),
                        _CodigoIntermediario,
                        _Oficina,
                        _Ramo,
                        Convert.ToDecimal(txtMontoMinimo.Text),
                        _NumeroPoliza,
                        _Numerorecibo,
                        _NumeroFactura,
                        Convert.ToDecimal(txtTasaDollar.Text));
                    foreach (var n in GenerarComisiones)
                    {
                        UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Guardar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                            Convert.ToDecimal(Session["IdUsuario"]),
                            n.Supervisor,
                            Convert.ToInt32(n.Codigo),
                            n.Intermediario,
                            n.Oficina,
                            n.NumeroIdentificacion,
                            n.CuentaBanco,
                            n.TipoCuenta,
                            n.Banco,
                            n.Cliente,
                            n.Recibo,
                            n.Fecha,
                            n.Factura,
                            n.FechaFactura,
                            n.Moneda,
                            n.Poliza,
                            n.Producto,
                            Convert.ToDecimal(n.Bruto),
                            Convert.ToDecimal(n.Neto),
                            Convert.ToDecimal(n.PorcientoComision),
                            Convert.ToDecimal(n.Comision),
                            Convert.ToDecimal(n.Retencion),
                            Convert.ToDecimal(n.AvanceComision),
                            Convert.ToDecimal(n.ALiquidar),
                            Convert.ToDecimal(n.CantidadRegistros),
                            Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                            Convert.ToDateTime(txtFechaHastaComisiones.Text),
                            "INSERT");
                        Guardar.ProcesarInformacion();

                    }
                    // ImprimirReporteResumido(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteComisionIntermediarioResumido.rpt"), "sa", "Pa$$W0rd", "Listado de Comisiones Resumido");
                    if (rbGenerarReporteResumido.Checked)
                    {
                        var ExportarResumen = (from n in ObjDataConexion.Value.ComisionIntermediarioResumido(Convert.ToDecimal(Session["IdUsuario"]))
                                               select new
                                               {
                                                   //IdUsuario = n.IdUsuario,
                                                   //GeneradoPor = n.GeneradoPor,
                                                   Supervisor = n.Supervisor,
                                                   //CodigoIntermediario = n.CodigoIntermediario,
                                                   Intermediario = n.Intermediario,
                                                   Oficina = n.Oficina,
                                                   NumeroIdentificacion = n.NumeroIdentificacion,
                                                   CuentaBanco = n.CuentaBanco,
                                                   TipoCuenta = n.TipoCuenta,
                                                   Banco = n.Banco,
                                                   Producto = n.Producto,
                                                   MontoBruto = n.MontoBruto,
                                                   MontoNeto = n.MontoNeto,
                                                   Comision = n.Comision,
                                                   Retencion = n.Retencion,
                                                   AvanceComision = n.AvanceComision,
                                                   ALiquidar = n.ALiquidar,
                                                   //ValidadoDesde = n.ValidadoDesde,
                                                   FechaDesde = n.FechaDesde,
                                                   FechaHasta = n.FechaHasta
                                               }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comisión de Intermediario Fesumen " + txtFechaDesdeComisiones.Text + " - " + txtFechaHastaComisiones.Text, ExportarResumen);
                    }

                    else if (rbGenerarReporteDetalle.Checked)
                    {
                        var ExportarDetalle = (from n in ObjDataConexion.Value.ComisionIntermediarioDetalle(Convert.ToDecimal(Convert.ToDecimal(Session["IdUsuario"])))
                                               select new
                                               {
                                                   Supervisor = n.Supervisor,
                                                   Intermediario = n.Intermediario,
                                                   Oficina = n.Oficina,
                                                   NumeroIdentificacion = n.NumeroIdentificacion,
                                                   CuentaBanco = n.CuentaBanco,
                                                   TipoCuenta = n.TipoCuenta,
                                                   Banco = n.Banco,
                                                   Cliente = n.Cliente,
                                                   NumeroRecibo = n.NumeroRecibo,
                                                   FechaRecibo = n.FechaRecibo,
                                                   NumeroFactura = n.NumeroFactura,
                                                   FechaFactura = n.FechaFactura,
                                                   Moneda = n.Moneda,
                                                   Poliza = n.Poliza,
                                                   Producto = n.Producto,
                                                   MontoBruto = n.MontoBruto,
                                                   MontoNeto = n.MontoNeto,
                                                   PorcientoComision = n.PorcientoComision,
                                                   Comsiion = n.Comsiion,
                                                   Retencion = n.Retencion,
                                                   AvanceComision = n.AvanceComision,
                                                   ALiquidar = n.ALiquidar,
                                                   FechaDesde = n.FechaDesde,
                                                   FechaHasta = n.FechaHasta
                                               }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comisión de Intermediario Detalle " + txtFechaDesdeComisiones.Text + " - " + txtFechaHastaComisiones.Text, ExportarDetalle);
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion
        #region PROCESAR INFORMACION
        private void ProcesarInformacionComisiones() {
          

            //BUSCAMOS LOS REGISTROS

            if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta()", "ErrorConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                }
            }
            else
            {
                

            }
        }
        #endregion
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


            divPaginacion.Visible = true;
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
        #region MOSTRAR EL LISTADO DE LAS COMISIONES
        private void MostrarListadoComisioneAcumulados() {
            int? _oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();

            var BuscarRegistros = ObjDataConexion.Value.ComisionesAcumuladasIntermediarios(
                new Nullable<int>(),
                _oficina,
                _Ramo,
                Convert.ToDecimal(txtMontoMinimo.Text));
            int CantidadRegistros = BuscarRegistros.Count;
            lbcantidadRegistrosEncontradosAcumulativosVariable.Text = CantidadRegistros.ToString("N0");
            Paginar(ref rpListadoMontosIntermediariosAcumulados, BuscarRegistros, 10, ref lbCantidadPaginaVariableDetalle, ref LinkPrimeraPaginaDetalle, ref LinkAnteriorDetalle, ref LinkSiguienteDetalle, ref LinkUltimoDetalle);
            HandlePaging(ref dtPaginacionDetalle, ref LinkBlbPaginaActualVariavleDetalleutton2);
        }
        #endregion
        #region ACTUALIZAR MONTOS COMISIONES INTERMEDIARIOS
        private void ActualizarComisionesAcumuladas() {

            string _CodigoIntermeiario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtNumeroPoliza.Text.Trim()) ? null : txtNumeroPoliza.Text.Trim();
            string _Numerorecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? null : txtNumeroRecibo.Text.Trim();
            string _Numerofactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();

            var BuscarInformacion = ObjDataConexion.Value.SacarComisionesIntermediariosMontoMinimo(
                Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                Convert.ToDateTime(txtFechaHastaComisiones.Text),
                _CodigoIntermeiario,
                _oficina,
                _Ramo,
                _Poliza,
                _Numerorecibo,
                _Numerofactura,
                Convert.ToDecimal(txtTasaDollar.Text),
                null);
            foreach (var n in BuscarInformacion) {

                bool ResultadoValidacion = false;

                UtilidadesAmigos.Logica.Comunes.Validaciones.ValidarMontosAcumuladosIntermediarios ValidarInformacion = new Logica.Comunes.Validaciones.ValidarMontosAcumuladosIntermediarios(
                    (int)n.Codigo,
                    (int)n.CodigoOficina,
                    (int)n.Ramo,
                    (decimal)n.NumeroRecibo,
                    (decimal)n.Factura,
                    n.Poliza);
                ResultadoValidacion = ValidarInformacion.ValidarIntermediario();
                if (ResultadoValidacion == false)
                {
                    //GUARDAMOS EL REGISTRO
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionComisionesMontosAcumulados Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionComisionesMontosAcumulados(
                        (int)n.Codigo,
                        (decimal)n.NumeroRecibo,
                        Convert.ToDateTime(n.Fecha),
                        (decimal)n.Factura,
                        n.Poliza,
                        (int)n.Ramo,
                        (decimal)n.Bruto,
                        (decimal)n.Neto,
                        (decimal)n.PorcientoComision,
                        (decimal)n.Comision,
                        (decimal)n.Retencion,
                        (decimal)n.AvanceComision,
                        (decimal)n.ALiquidar,
                        false,
                        (int)n.CodigoOficina,
                        "INSERT");
                    Guardar.ProcesarInformacion();


                }
                else { 
                
                }

            }
            MostrarListadoComisioneAcumulados();


        }
        #endregion

        private void GenerarReporteComisiones(decimal UsuarioGenera, string RutaReporte, string Nombrearchivo) {

            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            decimal? _MontoMinimo = string.IsNullOrEmpty(txtMontoMinimo.Text.Trim()) ? 0 : Convert.ToDecimal(txtMontoMinimo.Text);
            string _NumeroPoliza = string.IsNullOrEmpty(txtNumeroPoliza.Text.Trim()) ? null : txtNumeroPoliza.Text.Trim();
            string _NumeroRecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? null : txtNumeroRecibo.Text.Trim();
            string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            if (cbMostrarIntermediariosAcumulativos.Checked == true) {
                int? Intermediario = null;
                decimal MontoMinimo = 500;
                Reporte.SetParameterValue("@Intermediario", Intermediario);
                Reporte.SetParameterValue("@Oficina", _Oficina);
                Reporte.SetParameterValue("@Ramo", _Ramo);
                Reporte.SetParameterValue("@MontoMinimo", MontoMinimo);
            }
            //----------------------------------------------------------------------------------
            else if (cbMostrarIntermediariosAcumulativos.Checked == false) {
                if (rbGenerarReporteDetalle.Checked == true)
                {
                    Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesdeComisiones.Text));
                    Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHastaComisiones.Text));
                    Reporte.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
                    Reporte.SetParameterValue("@Oficina", _Oficina);
                    Reporte.SetParameterValue("@Ramo", _Ramo);
                    Reporte.SetParameterValue("@MontoMinimo", _MontoMinimo);
                    Reporte.SetParameterValue("@Poliza", _NumeroPoliza);
                    Reporte.SetParameterValue("@NumeroRecibo", _NumeroRecibo);
                    Reporte.SetParameterValue("@NumeroFactura", _NumeroFactura);
                    Reporte.SetParameterValue("@Tasa", Convert.ToDecimal(txtTasaDollar.Text));
                    Reporte.SetParameterValue("@Usuario", UsuarioGenera);
                }
                else
                {
                    Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesdeComisiones.Text));
                    Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHastaComisiones.Text));
                    Reporte.SetParameterValue("@Usuario", UsuarioGenera);
                }
            }

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, Nombrearchivo);
            }
            else if (rbExcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, Nombrearchivo);
            }
            else if (rbWord.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, Nombrearchivo);
            }

           

        }

        private void ProcesoComisionesIntermediario() {
            decimal _Usuario = Session["IdUsuario"] != null ? (decimal)Session["Idusuario"] : 0;

            //ELIMINAMOS AL INFORMACION REGISTRADA BAJO EL USUARIO
            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                _Usuario, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
            Eliminar.ProcesarInformacion();

            //BUSCAMOS LA INFORMACION QUE SE VA A MANDAR A LA TABLA PARA SELECCIONAR LOS REPORTES

            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            string _NumeroPoliza = string.IsNullOrEmpty(txtNumeroPoliza.Text.Trim()) ? null : txtNumeroPoliza.Text.Trim();
            string _Numerorecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? null : txtNumeroRecibo.Text.Trim();
            string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

            var BuscarRegistros = ObjDataConexion.Value.GenerarComisionIntermediario(
                Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                Convert.ToDateTime(txtFechaHastaComisiones.Text),
                _CodigoIntermediario,
                _Oficina,
                _Ramo,
                Convert.ToDecimal(txtMontoMinimo.Text),
                _NumeroPoliza,
                _Numerorecibo,
                _NumeroFactura,
                Convert.ToDecimal(txtTasaDollar.Text),
                IdUsuario);

            foreach (var n in BuscarRegistros) {
                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Guardar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                    _Usuario,
                    n.Supervisor,
                    (int)n.Codigo,
                    n.Intermediario,
                    n.Oficina,
                    n.NumeroIdentificacion,
                    n.CuentaBanco,
                    n.TipoCuenta,
                    n.Banco,
                    n.Cliente,
                    n.Recibo,
                    n.Fecha,
                    n.Factura,
                    n.FechaFactura,
                    n.Moneda,
                    n.Poliza,
                    n.Producto,
                    (decimal)n.Bruto,
                    (decimal)n.Neto,
                    (decimal)n.PorcientoComision,
                    (decimal)n.Comision,
                    (decimal)n.Retencion,
                    (decimal)n.AvanceComision,
                    (decimal)n.ALiquidar,
                    (decimal)n.CantidadRegistros,
                    Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                    Convert.ToDateTime(txtFechaHastaComisiones.Text),
                    "INSERT");
                Guardar.ProcesarInformacion();
            }

            //if (rbGenerarReporteDetalle.Checked == true) {
            //    GenerarReporteComisiones(_Usuario, Server.MapPath("ReporteComisionesIntermediario.rpt"), "Comisiones Detalle");
            //}
            //else if (rbGenerarReporteResumido.Checked == true) {
            //    GenerarReporteComisiones(_Usuario, Server.MapPath("ReporteComisionIntermediarioResumido.rpt"), "Comisiones Resumido");
            //}
            //else if (rbGenerarReporteInterno.Checked == true) {
            //    GenerarReporteComisiones(_Usuario, Server.MapPath("ReporteComisionIntermediarioInterno.rpt"), "Comisiones Interno");
            //}

        }


        private void CargarSucursalesComisiones()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalComisiones, ObjDataConexion.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinasComisiones()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaComisiones, ObjDataConexion.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalComisiones.SelectedValue, null), true);
        }
        private void CargarListadoRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataConexion.Value.BuscaListas("RAMO", null, null), true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "COMISIONES DE INTERMEDIARIOS";

                CargarSucursalesComisiones();
                CargarOficinasComisiones();
                CargarListadoRamos();
                rbGenerarReporteResumido.Checked = true;
                txtTasaDollar.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
                rbPDF.Checked = true;
            }
        }

        protected void btnConsultarComisiones_Click(object sender, EventArgs e)
        {
           

          
            
        }

        protected void btnExortarComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnReporteCOmisiones_Click(object sender, EventArgs e)
        {
        }


        protected void ddlSeleccionarSucursalComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinasComisiones();
        }

        protected void txtCodigoIntermediarioComisiones_TextChanged(object sender, EventArgs e)
        {
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreVendedor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoIntermediario);
            txtNombreVendedorComsiiones.Text = NombreVendedor.SacarNombreIntermediario();
        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            GenerarComisionesIntermediarios();

        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            GenerarComisionesIntermediarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            GenerarComisionesIntermediarios();
        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            GenerarComisionesIntermediarios();
        }

        protected void cbMostrarIntermediariosAcumulativos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMostrarIntermediariosAcumulativos.Checked == true) {
                DivRepeaterNormal.Visible = false;
                DivBloqueRepeaterAcumulativo.Visible = true;
                btnActualizarListadoNuevo.Visible = true;
            }
            else if (cbMostrarIntermediariosAcumulativos.Checked == false) {
                DivRepeaterNormal.Visible = true;
                DivBloqueRepeaterAcumulativo.Visible = false;
                btnActualizarListadoNuevo.Visible = false;
            }
        }

        protected void btnDetalleMontoAcumulado_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfCodigoIntermediario = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoIntermediario")).Value.ToString();

            var ExportarInformacion = (from n in ObjDataConexion.Value.ValidarDetalleIntermediarioComisiones(Convert.ToInt32(hfCodigoIntermediario), null, null, null, null, null)
                                       select new {
                                           CodigoIntermediario = n.CodigoIntermediario,
                                           NumeroRecibo = n.NumeroRecibo,
                                           FechaRecibo = n.FechaRecibo,
                                           NumeroFacturaAfecta = n.NumeroFacturaAfecta,
                                           Poliza = n.Poliza,
                                           NombreRamo = n.NombreRamo,
                                           ValorReciboBruto = n.ValorReciboBruto,
                                           ValorReciboNeto = n.ValorReciboNeto,
                                           PorcientoComision = n.PorcientoComision,
                                           ComisionGenerada = n.ComisionGenerada,
                                           Retencion = n.Retencion,
                                           AvanceComision = n.AvanceComision,
                                           ALiquidar = n.ALiquidar,
                                           Estatus = n.Estatus,
                                           NombreOficina = n.NombreOficina
                                       }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Detalle Comisiones Acumuladas", ExportarInformacion);
        }

        protected void LinkPrimeraPaginaDetalle_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoComisioneAcumulados();
        }

        protected void LinkAnteriorDetalle_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoComisioneAcumulados();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariavleDetalleutton2, ref lbCantidadPaginaVariableDetalle);
        }

        protected void dtPaginacionDetalle_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionDetalle_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoComisioneAcumulados();
        }

        protected void LinkSiguienteDetalle_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoComisioneAcumulados();
        }

        protected void LinkUltimoDetalle_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoComisioneAcumulados();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariavleDetalleutton2, ref lbCantidadPaginaVariableDetalle);
        }

        protected void btnActualizarListado_Click(object sender, EventArgs e)
        {
        }

        protected void btnConsultarComisionesNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (cbMostrarIntermediariosAcumulativos.Checked == true)
            {
                MostrarListadoComisioneAcumulados();
            }
            else if (cbMostrarIntermediariosAcumulativos.Checked == false)
            {
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                    }
                }
                else
                {
                    GenerarComisionesIntermediarios();
                }
            }
        }

        protected void btnExortarComisionesNuevo_Click(object sender, ImageClickEventArgs e)
        {

            if (cbMostrarIntermediariosAcumulativos.Checked == true)
            {
                int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();

                var ExportarInformacion = (from n in ObjDataConexion.Value.ComisionesAcumuladasIntermediarios(
                    new Nullable<int>(),
                    _Oficina,
                    _Ramo,
                    Convert.ToDecimal(txtMontoMinimo.Text))
                                           select new
                                           {
                                               CodigoIntermediario = n.CodigoIntermediario,
                                               Intermediario = n.Intermediario,
                                               Oficina = n.Oficina,
                                               ValorReciboBruto = n.ValorReciboBruto,
                                               ValorReciboNeto = n.ValorReciboNeto,
                                               ComisionGenerada = n.ComisionGenerada,
                                               Retencion = n.Retencion,
                                               AvanceComision = n.AvanceComision,
                                               Aliquidar = n.Aliquidar,
                                               Estatus = n.GeneraCheque,
                                               CantiadRegistros = n.CantiadRegistros
                                           }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Comisiones Acumuladas", ExportarInformacion);
            }
            else if (cbMostrarIntermediariosAcumulativos.Checked == false)
            {
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                    }
                }
                else
                {
                    ExportarConsultaExcel();
                }
            }
        }

        protected void btnReporteCOmisionesNuevo_Click(object sender, ImageClickEventArgs e)
        {

            if (cbMostrarIntermediariosAcumulativos.Checked == true)
            {
                decimal UsuarioGenera = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
                string RutaReporte = "ReporteAcumuladoIntermediariosComisiones.rpt";
                string NombreReporte = "Acumulado Comisiones Intermediarios";

                GenerarReporteComisiones(UsuarioGenera, Server.MapPath(RutaReporte), NombreReporte);
            }
            //--------------------------------------------------------------
            else if (cbMostrarIntermediariosAcumulativos.Checked == false)
            {
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                    }
                }
                else
                {
                    decimal UsuarioGenera = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
                    string RutaReporte = "";
                    string NombreReporte = "";

                    if (rbGenerarReporteDetalle.Checked == true)
                    {
                        RutaReporte = "ReporteComisionesIntermediarioDetalleDefinitivo.rpt";
                        NombreReporte = "Comisiones Intermediario Detalle";
                    }
                    else if (rbGenerarReporteResumido.Checked == true)
                    {
                        RutaReporte = "ReporteComisionesResumidoFinal.rpt";
                        NombreReporte = "Comisiones Intermediario Resumido";
                        ProcesoComisionesIntermediario();
                    }
                    else if (rbGenerarReporteInterno.Checked == true)
                    {
                        RutaReporte = "ReporteComisionIntermediarioInterno.rpt";
                        NombreReporte = "Comisiones Intermediario Interno";
                        ProcesoComisionesIntermediario();
                    }
                    GenerarReporteComisiones(UsuarioGenera, Server.MapPath(RutaReporte), NombreReporte);
                }
            }
        }

        protected void btnActualizarListadoNuevo_Click(object sender, ImageClickEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                }
            }
            else
            {
                ActualizarComisionesAcumuladas();
            }
        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            GenerarComisionesIntermediarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }
    }
}
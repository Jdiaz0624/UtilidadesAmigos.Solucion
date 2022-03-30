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

        /*
                                                                        RECUENTO DE PROCESO
         
         * PRIMERO BUSCAMOS LA INFORMACION QUE SE VA A PROCESAR PARA ESO UTILIZAMOS EL PROCEDURE --> [Utililades].[SP_REPORTE_COMISION_INTERMEDIARIO_ORIGEN]
         * ELIMINAMOS TODOS LOS REGISTROS EN LA TABLA --> [Utililades].[InformacionProcesoReporteComisiones] MEDIANTE EL CODIGO DEL USUARIO QUE ESTA CONECTADO
         * LUEGO GUARDAMOS TODA ESA INFORMACION EN LA TABLA --> [Utililades].[InformacionProcesoReporteComisiones] PARA MOLDEAR LA INFORMACION A GUSTO
         */
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        #region CONTROL DE PAGINACION DE LAS COMISIONES
        readonly PagedDataSource pagedDataSource_Comisiones = new PagedDataSource();
        int _PrimeraPagina_Comisiones, _UltimaPagina_Comisiones;
        private int _TamanioPagina_Comisiones = 10;
        private int CurrentPage_Comisiones
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

        private void HandlePaging_Comisiones(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Comisiones = CurrentPage_Comisiones - 5;
            if (CurrentPage_Comisiones > 5)
                _UltimaPagina_Comisiones = CurrentPage_Comisiones + 5;
            else
                _UltimaPagina_Comisiones = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Comisiones > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Comisiones = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Comisiones = _UltimaPagina_Comisiones - 10;
            }

            if (_PrimeraPagina_Comisiones < 0)
                _PrimeraPagina_Comisiones = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Comisiones;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Comisiones; i < _UltimaPagina_Comisiones; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Comisiones(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Comisiones.DataSource = Listado;
            pagedDataSource_Comisiones.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Comisiones.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Comisiones.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Comisiones.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Comisiones : _NumeroRegistros);
            pagedDataSource_Comisiones.CurrentPageIndex = CurrentPage_Comisiones;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Comisiones.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Comisiones.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Comisiones.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Comisiones.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Comisiones;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Comisiones
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Comisiones(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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



        private void SacarElNombreDelIntermediario() {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarInformacion = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioComisiones.Text);
            txtNombreVendedorComsiiones.Text = SacarInformacion.SacarNombreIntermediario();
        }

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarListasDesplegables() {
            CargarListadoSucursales();
            CargarListadoOficinas();
            CargarRamos();
        }

        private void CargarListadoSucursales() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalComisiones, ObjDataConexion.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarListadoOficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaComisiones, ObjDataConexion.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalComisiones.SelectedValue, null), true);
        }
        private void CargarRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataConexion.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion

        #region PROCESO DE DE CARGA DE INFORMACION DE LOS DATOS DE  LAS COMISIONES
        private void ProcesarInformacionDataComisiones(decimal IdUSuario) {

            //ELIMINAMOS LOS DATOS DEL REGISTRO
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionReporteComisionIntermediariosOrigen Eliminar = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionReporteComisionIntermediariosOrigen(
                IdUSuario,
                0, "", 0, "", 0, "", "", "", "", 0, "", 0, DateTime.Now, "", "", "", 0, "", DateTime.Now, "", "", 0, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, "", "", "DELETE");
            Eliminar.ProcesarInformacion();

            var Informacion = ObjDataReportes.Value.BuscaDateComisionIntermediarioOrigen(
                Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                Convert.ToDateTime(txtFechaHastaComisiones.Text),
                IdUSuario);
            foreach (var n in Informacion) {

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionReporteComisionIntermediariosOrigen Guardar = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionReporteComisionIntermediariosOrigen(
                    IdUSuario,
                    (int)n.CodigoSupervisor,
                    n.Supervisor,
                    (int)n.CodigoIntermediario,
                    n.Intermediario,
                    (int)n.Oficina,
                    n.NombreOficina,
                    n.NumeroIdentificacion,
                    n.NumeroCuenta,
                    n.TipoCuentaBanco,
                    (int)n.Banco,
                    n.NombreBanco,
                    (decimal)n.NumeroRecibo,
                    (DateTime)n.FechaRecibo0,
                    n.FechaRecibo,
                    n.HoraRecibo,
                    n.NumeroReciboFormateado,
                    (decimal)n.NumeroFactura,
                    n.NumeroFacturaFormateada,
                    (DateTime)n.FechaFactura0,
                    n.FechaFactura,
                    n.HoraFactura,
                    (int)n.CodMoneda,
                    n.NoPoliza,
                    (int)n.Ramo,
                    n.NombreRamo,
                    (decimal)n.TasaPesos,
                    (decimal)n.TasaDollar,
                    (decimal)n.TasaEuro,
                    (decimal)n.ValorRecibo,
                    (decimal)n.PorcientoComision,
                    (decimal)n.Bruto,
                    (decimal)n.Neto,
                    (decimal)n.Comision,
                    (decimal)n.Retencion,
                    (decimal)n.AvanceComision,
                    (decimal)n.Aliquidar,
                    n.GeneradoPor,
                    (decimal)n.CodigoUsuario,
                    n.ValidadoDesde,
                    n.ValidadoHasta,
                    "INSERT");
                Guardar.ProcesarInformacion();
            }


        }
        #endregion

        #region MOSTRAR LOS DATOS DE LAS COMISIONES
        private void ReporteComisionesInterno_Resumido(decimal IdUsuario) {

            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioComisiones.Text);
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtNumeroPoliza.Text.Trim()) ? null : txtNumeroPoliza.Text.Trim();
            decimal? _NumeroRecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroRecibo.Text);
            decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroFactura.Text);

            var Reporte = ObjDataReportes.Value.MostrarReporteComisionesIntermediarioResumido_Interno(
                _Intermediario,
                _Oficina,
                _Ramo,
                _Poliza,
                _NumeroRecibo,
                _NumeroFactura,
                Convert.ToDecimal(txtMontoMinimo.Text),
                IdUsuario,
                1);
            if (Reporte.Count() < 1) {
                rpListadoComision.DataSource = null;
                rpListadoComision.DataBind();
            }
            else {
                Paginar_Comisiones(ref rpListadoComision, Reporte, 10,ref lbCantidadPaginaVariable, ref btnPrimeraPaginaComisiones, ref btnPaginaAnteriorComisiones, ref btnPaginaSiguienteComisiones, ref btnUltimaPaginaComisiones);
                HandlePaging_Comisiones(ref dtPaginacionComisiones, ref lbPaginaActualVariavle);
            }
        }
        #endregion

        #region GENERAR EL REPORTE DE COMISIONES
        private void GenerarReporteComisiones(string RutaReporte,decimal IdUsuario) {
            //COLOCAMOS LOS FILTROS
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioComisiones.Text);
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtNumeroPoliza.Text.Trim()) ? null : txtNumeroPoliza.Text.Trim();
            decimal? _NumeroRecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroRecibo.Text);
            decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroFactura.Text);

            //VALIDAMOS EL TIPO DE OPCION A GENERAR
            if (rbExcelPlano.Checked == true) {
                if (rbGenerarReporteDetalle.Checked == true) {

                    var Reporte_Detallado = (from n in ObjDataReportes.Value.MostrarReporteComisionesIntermediario_Detalladp(
                        _Intermediario,
                        _Oficina,
                        _Ramo,
                        _Poliza,
                        _NumeroRecibo,
                        _NumeroFactura,
                        Convert.ToDecimal(txtMontoMinimo.Text),
                        IdUsuario)
                                             select new
                                             {
                                                 Supervisor = n.Supervisor,
                                                 Intermediario = n.Intermediario,
                                                 Oficina = n.NombreOficina,
                                                 NumeroIdentificacion = n.NumeroIdentificacion,
                                                 NumeroCuenta = n.NumeroCuenta,
                                                 TipoCuentaBanco = n.TipoCuentaBanco,
                                                 Banco = n.NombreBanco,
                                                 Numero_Recibo = n.NumeroReciboFormateado,
                                                 Fecha_Recibo = n.FechaRecibo,
                                                 Hora_Recibo = n.HoraRecibo,
                                                 Numero_Factura = n.NumeroFacturaFormateada,
                                                 Fecha_Factura = n.FechaFactura,
                                                 Hora_Factura = n.HoraFactura,
                                                 Moneda = n.Moneda,
                                                 Poliza = n.NoPoliza,
                                                 Ramo = n.NombreRamo,
                                                 Tasa = n.TasaUSada,
                                                 Valor_Recibo = n.ValorRecibo,
                                                 Porciento_Comision = n.PorcientoComision,
                                                 Bruto = n.Bruto,
                                                 Neto = n.Neto,
                                                 Comision = n.Comision,
                                                 Retencion = n.Retencion,
                                                 Avance_Comision = n.AvanceComision,
                                                 Aliquidar = n.Aliquidar
                                             }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Comisiones Detallado", Reporte_Detallado);



                }
                //REPORTE INTERNO
                else if (rbGenerarReporteInterno.Checked == true) {
                    var Reporte_Interno = (from n in ObjDataReportes.Value.MostrarReporteComisionesIntermediarioResumido_Interno(
                           _Intermediario,
                           _Oficina,
                           _Ramo,
                           _Poliza,
                           _NumeroRecibo,
                           _NumeroFactura,
                           Convert.ToDecimal(txtMontoMinimo.Text),
                           IdUsuario,
                           1)
                                            select new
                                            {
                                                Supervisor = n.Supervisor,
                                                Intermediario = n.Intermediario,
                                                Bruto = n.Bruto,
                                                Neto = n.Neto,
                                                Comision = n.Comision,
                                                Retencion = n.Retencion,
                                                AvanceComision = n.AvanceComision,
                                                Aliquidar = n.Aliquidar
                                            }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Comisiones Interno", Reporte_Interno);
                }
                //REPORTE DETALLADO
                else if (rbGenerarReporteResumido.Checked == true) {
                    var Reporte_Resumido = (from n in ObjDataReportes.Value.MostrarReporteComisionesIntermediarioResumido_Interno(
                        _Intermediario,
                        _Oficina,
                        _Ramo,
                        _Poliza,
                        _NumeroRecibo,
                        _NumeroFactura,
                        Convert.ToDecimal(txtMontoMinimo.Text),
                        IdUsuario,
                        1)
                                            select new
                                            {
                                                Supervisor = n.Supervisor,
                                                Intermediario = n.Intermediario,
                                                Bruto = n.Bruto,
                                                Neto = n.Neto,
                                                Comision = n.Comision,
                                                Retencion = n.Retencion,
                                                AvanceComision = n.AvanceComision,
                                                Aliquidar = n.Aliquidar
                                            }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Comisiones Resumido", Reporte_Resumido);

                }
            }
            else {
                if (rbPDF.Checked == true) {
                    if (rbGenerarReporteDetalle.Checked == true) {
                        ReportDocument ReporteInterno = new ReportDocument();
                        string Ruta = Server.MapPath("ReporteComisionIntermediariosDetallado.rpt");


                        ReporteInterno.Load(Ruta);
                        ReporteInterno.Refresh();

                        ReporteInterno.SetParameterValue("@CodigoIntermediario", _Intermediario);
                        ReporteInterno.SetParameterValue("@Oficina", _Oficina);
                        ReporteInterno.SetParameterValue("@Ramo", _Ramo);
                        ReporteInterno.SetParameterValue("@Poliza", _Poliza);
                        ReporteInterno.SetParameterValue("@Recibo", _NumeroRecibo);
                        ReporteInterno.SetParameterValue("@Factura", _NumeroFactura);
                        ReporteInterno.SetParameterValue("@MontoMinimo", Convert.ToDecimal(txtMontoMinimo.Text));
                        ReporteInterno.SetParameterValue("@IdUsuario", IdUsuario);

                        ReporteInterno.SetDatabaseLogon("sa", "Pa$$W0rd");
                        ReporteInterno.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Comisiones Intermediario Detallado");
                    }
                    else if (rbGenerarReporteInterno.Checked == true) {
                        ReportDocument ReporteInterno = new ReportDocument();
                        string Ruta = Server.MapPath("ReporteComisionIntermediariosResumidoInterno.rpt");
                        int _TipoReporte = 2;

                        ReporteInterno.Load(Ruta);
                        ReporteInterno.Refresh();

                        ReporteInterno.SetParameterValue("@CodigoIntermediario", _Intermediario);
                        ReporteInterno.SetParameterValue("@Oficina", _Oficina);
                        ReporteInterno.SetParameterValue("@Ramo", _Ramo);
                        ReporteInterno.SetParameterValue("@Poliza", _Poliza);
                        ReporteInterno.SetParameterValue("@Recibo", _NumeroRecibo);
                        ReporteInterno.SetParameterValue("@Factura", _NumeroFactura);
                        ReporteInterno.SetParameterValue("@MontoMinimo", Convert.ToDecimal(txtMontoMinimo.Text));
                        ReporteInterno.SetParameterValue("@IdUsuario", IdUsuario);
                        ReporteInterno.SetParameterValue("@TipoProceso", _TipoReporte);

                        ReporteInterno.SetDatabaseLogon("sa", "Pa$$W0rd");
                        ReporteInterno.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Comisiones Intermediario Interno");
                    }
                    else if (rbGenerarReporteResumido.Checked == true) {
                        ReportDocument ReporteInterno = new ReportDocument();
                        string Ruta = Server.MapPath("ReporteComisionIntermediariosResumidoInterno.rpt");
                        int _TipoReporte = 1;

                        ReporteInterno.Load(Ruta);
                        ReporteInterno.Refresh();

                        ReporteInterno.SetParameterValue("@CodigoIntermediario", _Intermediario);
                        ReporteInterno.SetParameterValue("@Oficina", _Oficina);
                        ReporteInterno.SetParameterValue("@Ramo", _Ramo);
                        ReporteInterno.SetParameterValue("@Poliza", _Poliza);
                        ReporteInterno.SetParameterValue("@Recibo", _NumeroRecibo);
                        ReporteInterno.SetParameterValue("@Factura", _NumeroFactura);
                        ReporteInterno.SetParameterValue("@MontoMinimo", Convert.ToDecimal(txtMontoMinimo.Text));
                        ReporteInterno.SetParameterValue("@IdUsuario", IdUsuario);
                        ReporteInterno.SetParameterValue("@TipoProceso", _TipoReporte);

                        ReporteInterno.SetDatabaseLogon("sa", "Pa$$W0rd");
                        ReporteInterno.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Comisiones Intermediario Resumido");
                    }
                }
                else if (rbExcel.Checked == true) {
                    if (rbGenerarReporteDetalle.Checked == true) {
                        ReportDocument ReporteInterno = new ReportDocument();
                        string Ruta = Server.MapPath("ReporteComisionIntermediariosDetallado.rpt");


                        ReporteInterno.Load(Ruta);
                        ReporteInterno.Refresh();

                        ReporteInterno.SetParameterValue("@CodigoIntermediario", _Intermediario);
                        ReporteInterno.SetParameterValue("@Oficina", _Oficina);
                        ReporteInterno.SetParameterValue("@Ramo", _Ramo);
                        ReporteInterno.SetParameterValue("@Poliza", _Poliza);
                        ReporteInterno.SetParameterValue("@Recibo", _NumeroRecibo);
                        ReporteInterno.SetParameterValue("@Factura", _NumeroFactura);
                        ReporteInterno.SetParameterValue("@MontoMinimo", Convert.ToDecimal(txtMontoMinimo.Text));
                        ReporteInterno.SetParameterValue("@IdUsuario", IdUsuario);

                        ReporteInterno.SetDatabaseLogon("sa", "Pa$$W0rd");
                        ReporteInterno.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Comisiones Intermediario Detallado");
                    }
                    else if (rbGenerarReporteInterno.Checked == true) {
                        ReportDocument ReporteInterno = new ReportDocument();
                        string Ruta = Server.MapPath("ReporteComisionIntermediariosResumidoInterno.rpt");
                        int _TipoReporte = 2;

                        ReporteInterno.Load(Ruta);
                        ReporteInterno.Refresh();

                        ReporteInterno.SetParameterValue("@CodigoIntermediario", _Intermediario);
                        ReporteInterno.SetParameterValue("@Oficina", _Oficina);
                        ReporteInterno.SetParameterValue("@Ramo", _Ramo);
                        ReporteInterno.SetParameterValue("@Poliza", _Poliza);
                        ReporteInterno.SetParameterValue("@Recibo", _NumeroRecibo);
                        ReporteInterno.SetParameterValue("@Factura", _NumeroFactura);
                        ReporteInterno.SetParameterValue("@MontoMinimo", Convert.ToDecimal(txtMontoMinimo.Text));
                        ReporteInterno.SetParameterValue("@IdUsuario", IdUsuario);
                        ReporteInterno.SetParameterValue("@TipoProceso", _TipoReporte);

                        ReporteInterno.SetDatabaseLogon("sa", "Pa$$W0rd");
                        ReporteInterno.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Comisiones Intermediario Interno");
                    }
                    else if (rbGenerarReporteResumido.Checked == true) {
                        ReportDocument ReporteInterno = new ReportDocument();
                        string Ruta = Server.MapPath("ReporteComisionIntermediariosResumidoInterno.rpt");
                        int _TipoReporte = 1;

                        ReporteInterno.Load(Ruta);
                        ReporteInterno.Refresh();

                        ReporteInterno.SetParameterValue("@CodigoIntermediario", _Intermediario);
                        ReporteInterno.SetParameterValue("@Oficina", _Oficina);
                        ReporteInterno.SetParameterValue("@Ramo", _Ramo);
                        ReporteInterno.SetParameterValue("@Poliza", _Poliza);
                        ReporteInterno.SetParameterValue("@Recibo", _NumeroRecibo);
                        ReporteInterno.SetParameterValue("@Factura", _NumeroFactura);
                        ReporteInterno.SetParameterValue("@MontoMinimo", Convert.ToDecimal(txtMontoMinimo.Text));
                        ReporteInterno.SetParameterValue("@IdUsuario", IdUsuario);
                        ReporteInterno.SetParameterValue("@TipoProceso", _TipoReporte);

                        ReporteInterno.SetDatabaseLogon("sa", "Pa$$W0rd");
                        ReporteInterno.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Comisiones Intermediario Resumido");
                    }
                }
            }


        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "COMISIONES DE INTERMEDIARIOS";

                rbGenerarReporteResumido.Checked = true;
                rbPDF.Checked = true;
                cbMostrarIntermediariosAcumulativos.Checked = false;

                CargarListasDesplegables();
            }
        }

        protected void dtPaginacionComisiones_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Comisiones = Convert.ToInt32(e.CommandArgument.ToString());
            decimal IdUSuario = (decimal)Session["IdUsuario"];
            ReporteComisionesInterno_Resumido(IdUSuario);
        }

        protected void dtPaginacionComisiones_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void DTPaginacionMontosAcumulados_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void DTPaginacionMontosAcumulados_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void cbMostrarIntermediariosAcumulativos_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultarComisionesNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAcios()", "CamposFechaVAcios();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                decimal IdUSuario = (decimal)Session["IdUsuario"];
                ProcesarInformacionDataComisiones(IdUSuario);
                ReporteComisionesInterno_Resumido(IdUSuario);
            }
        }

        protected void btnReporteCOmisionesNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAcios()", "CamposFechaVAcios();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                decimal IdUSuario = (decimal)Session["IdUsuario"];
                ProcesarInformacionDataComisiones(IdUSuario);
                string RutaReporte = "";
                GenerarReporteComisiones(RutaReporte, IdUSuario);
            }
        }

        protected void btnActualizarListadoNuevo_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void btnPrimeraPaginaComisiones_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comisiones = 0;
            decimal IdUSuario = (decimal)Session["IdUsuario"];
            ReporteComisionesInterno_Resumido(IdUSuario);
        }

        protected void btnPaginaAnteriorComisiones_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comisiones += -1;
            decimal IdUSuario = (decimal)Session["IdUsuario"];
            ReporteComisionesInterno_Resumido(IdUSuario);
            MoverValoresPaginacion_Comisiones((int)OpcionesPaginacionValores_Comisiones.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }

        protected void btnPaginaSiguienteComisiones_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comisiones += 1;
            decimal IdUSuario = (decimal)Session["IdUsuario"];
            ReporteComisionesInterno_Resumido(IdUSuario);
        }

        protected void btnUltimaPaginaComisiones_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comisiones = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            decimal IdUSuario = (decimal)Session["IdUsuario"];
            ReporteComisionesInterno_Resumido(IdUSuario);
            MoverValoresPaginacion_Comisiones((int)OpcionesPaginacionValores_Comisiones.UltimaPagina, ref lbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }

        protected void btnExportarListadoRecibos_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPAginaMontosAcumulados_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnteriorMontosAcumulados_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSiguientePaginaMontosAcumulados_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPaginaMontosAcumulados_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtCodigoIntermediarioComisiones_TextChanged(object sender, EventArgs e)
        {
            SacarElNombreDelIntermediario();
        }

        protected void ddlSeleccionarSucursalComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListadoOficinas();
        }
    }
}
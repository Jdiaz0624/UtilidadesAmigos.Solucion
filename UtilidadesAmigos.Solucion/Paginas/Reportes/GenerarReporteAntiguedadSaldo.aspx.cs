using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteAntiguedadSaldo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObDataMantenimiento = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();


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
        #region ENUMERACIONES
        enum TipoMonedas { 
        Pesos=1,
        Dollar=2,
        Euro=3
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjdataGeneral.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarTipoMovimientos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoMovimiento, ObjdataGeneral.Value.BuscaListas("TIPOMOVIMIENTOS", null, null), true);
        }
        private void CargarOficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjdataGeneral.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void CargarMonedas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMoneda, ObjdataGeneral.Value.BuscaListas("MONEDA", null, null), true);
        }
        #endregion

        private void MostrarListadoPorPantalla() {
            string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _Tipo = ddlSeleccionarTipoMovimiento.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoMovimiento.SelectedValue) : new Nullable<int>();
            string _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? null : txtCodigoCliente.Text.Trim();
            string _Vendedor = string.IsNullOrEmpty(txtCodigoVendedor.Text.Trim()) ? null : txtCodigoVendedor.Text.Trim();
            int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
            int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
            var Buscar = ObDataMantenimiento.Value.BuscarDatosAntiguedadSaldo(
                Convert.ToDateTime(txtFechaCorte.Text),
                _NumeroFactura,
                _Poliza,
                _Ramo,
                Convert.ToDecimal(txtTasaDollar.Text),
                _Tipo,
                _Cliente,
                _Vendedor,
                _Oficina,
                null,
                _Moneda);
            int CantidadRegistros = Buscar.Count;
            lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");

            Paginar(ref rpListadoAntiguedaSando, Buscar, 10, ref lbCantidadPaginaVariable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
            HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);
        }


        private void ExportarInformacionExcel() {

            string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _Tipo = ddlSeleccionarTipoMovimiento.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoMovimiento.SelectedValue) : new Nullable<int>();
            string _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? null : txtCodigoCliente.Text.Trim();
            string _Vendedor = string.IsNullOrEmpty(txtCodigoVendedor.Text.Trim()) ? null : txtCodigoVendedor.Text.Trim();
            int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
            int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;


            if (rbReporteDetallado.Checked == true) {
                var ExportarDetalle = (from n in ObDataMantenimiento.Value.BuscarDatosAntiguedadSaldo(
                    Convert.ToDateTime(txtFechaCorte.Text),
                    _NumeroFactura,
                    _Poliza,
                    _Ramo,
                    Convert.ToDecimal(txtTasaDollar.Text),
                    _Tipo,
                    _Cliente,
                    _Vendedor,
                    _Oficina,
                    null,
                    _Moneda)
                                       select new {
                                           NumeroDocumento = n.Documento,
                                           DescripcionTipo = n.DescripcionTipo,
                                           Asegurado = n.Asegurado,
                                           Fecha = n.Fecha,
                                           Intermediario = n.Intermediario,
                                           Poliza = n.Poliza,
                                           Moneda = n.DescripcionMoneda,
                                           Estatus = n.Estatus,
                                           Ramo = n.DescripcionRamo,
                                           InicioVigencia = n.Inicio,
                                           FinVigencia = n.Fin,
                                           Oficina = n.Oficina,
                                           DiasTranscurridos = n.Dias,
                                           Facturado = n.Facturado,
                                           Cobrado = n.Cobrado,
                                           Balance = n.Balance,
                                           Impuesto = n.Impuesto,
                                           PorcComision = n.PorcComision,
                                           ValorComision = n.ValorComision,
                                           ComisionPendiente = n.ComisionPendiente,
                                           De_0_10 = n.__0_10,
                                           De_0_30 = n.__0_30,
                                           De_31_60 = n.__31_60,
                                           De_61_90 = n.__61_90,
                                           De_91_120 = n.__91_120,
                                           De_121_150 = n.__121_150,
                                           De_151_MAS = n.__151_MAS,
                                           Total = n.Total,
                                           Diferencia = n.Diferencia,
                                           OrdenTipo = n.OrdenTipo
                                       }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Antiguedad de Saldo al " + txtFechaCorte.Text + " Detalle", ExportarDetalle);

            }
            else if (rbReporteResumido.Checked == true) {
                //ELIMINAMOS TODOS LOS DATOS DE LA TABLA DatosReporteAntiguedadSaldo CON EL USUAIRIO QUE ESTA PROCESANDO LA INFORMACION
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Delete = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                    IdUsuario, DateTime.Now, "", 0, 0, "", "", 0, "", "", 0, "", 0, "", "", 0, "", DateTime.Now, "", DateTime.Now, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "DELETE");
                Delete.ProcesarInformacion();

                //PROCEDEMOS A BUSCAR LA INFORMACION Y GUARDAR EN LA TABLA LOS NUEVOS DATOS A PROCESAR
                var BuscarInformacion = ObDataMantenimiento.Value.BuscarDatosAntiguedadSaldo(
                    Convert.ToDateTime(txtFechaCorte.Text),
                    _NumeroFactura,
                    _Poliza,
                    _Ramo,
                    Convert.ToDecimal(txtTasaDollar.Text),
                    _Tipo,
                    _Cliente,
                    _Vendedor,
                    _Oficina,
                    IdUsuario,
                    _Moneda);
                foreach (var n in BuscarInformacion) {
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Save = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                        IdUsuario,
                        Convert.ToDateTime(txtFechaCorte.Text),
                        n.Documento,
                        (decimal)n.NumeroFacturaFiltro,
                        (int)n.Tipo,
                        n.DescripcionTipo,
                        n.Asegurado,
                        (decimal)n.ClienteFiltro,
                        n.Fecha,
                        n.Intermediario,
                        (int)n.VendedorFiltro,
                        n.Poliza,
                        (int)n.CodMoneda,
                        n.DescripcionMoneda,
                        n.Estatus,
                        (int)n.CodRamo,
                        n.InicioVigencia,
                        (DateTime)n.Inicio,
                        n.FinVigencia,
                        (DateTime)n.Fin,
                        (int)n.CodOficina,
                        n.Oficina,
                        (int)n.Dias,
                        (decimal)n.Facturado,
                        (decimal)n.Cobrado,
                        (decimal)n.Balance,
                        (decimal)n.Impuesto,
                        (decimal)n.PorcComision,
                        (decimal)n.ValorComision,
                        (decimal)n.ComisionPendiente,
                        (decimal)n.__0_10,
                        (decimal)n.__0_30,
                        (decimal)n.__31_60,
                        (decimal)n.__61_90,
                        (decimal)n.__91_120,
                        (decimal)n.__121_150,
                        (decimal)n.__151_MAS,
                        (decimal)n.Total,
                        (decimal)n.Diferencia,
                        (int)n.OrdenTipo,
                        "INSERT");
                    Save.ProcesarInformacion();
                }
                var ExportarReporteResumido = (from n in ObDataMantenimiento.Value.ReporteAntiguedadSaldoResumido(
                        IdUsuario,
                        Convert.ToDecimal(txtTasaDollar.Text),
                        0)
                                               select new
                                               {
                                                   FechaCorte = n.FechaCorte,
                                                   DescripcionMoneda = n.DescripcionMoneda,
                                                   Ramo = n.Ramo,
                                                   CantidadFactura = n.CantidadFactura,
                                                   CantidadCreditos = n.CantidadCreditos,
                                                   CantidadPrimaDeposito = n.CantidadPrimaDeposito,
                                                   CantidadRegistros = n.CantidadRegistros,
                                                   Balance = n.Balance,
                                                   __0_30 = n.__0_30,
                                                   __31_60 = n.__31_60,
                                                   __61_90 = n.__61_90,
                                                   __91_120 = n.__91_120,
                                                   __121_150 = n.__121_150,
                                                   __151_Mas = n.__151_Mas,
                                                   Total = n.Total,
                                                   GeneradoPor = n.GeneradoPor,
                                                   TotalPesos = n.TotalPesos,
                                                   Tasa = n.Tasa
                                               }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Antiguedad de Saldo Resumido", ExportarReporteResumido);
            }
            else if (rbReporteNeteado.Checked == true) {
                //ELIMINAMOS TODOS LOS DATOS DE LA TABLA DatosReporteAntiguedadSaldo CON EL USUAIRIO QUE ESTA PROCESANDO LA INFORMACION
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Delete = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                    IdUsuario, DateTime.Now, "", 0, 0, "", "", 0, "", "", 0, "", 0, "", "", 0, "", DateTime.Now, "", DateTime.Now, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "DELETE");
                Delete.ProcesarInformacion();

                //PROCEDEMOS A BUSCAR LA INFORMACION Y GUARDAR EN LA TABLA LOS NUEVOS DATOS A PROCESAR
                var BuscarInformacion = ObDataMantenimiento.Value.BuscarDatosAntiguedadSaldo(
                    Convert.ToDateTime(txtFechaCorte.Text),
                    _NumeroFactura,
                    _Poliza,
                    _Ramo,
                    Convert.ToDecimal(txtTasaDollar.Text),
                    _Tipo,
                    _Cliente,
                    _Vendedor,
                    _Oficina,
                    IdUsuario,
                    _Moneda);
                foreach (var n in BuscarInformacion)
                {
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Save = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                        IdUsuario,
                        Convert.ToDateTime(txtFechaCorte.Text),
                        n.Documento,
                        (decimal)n.NumeroFacturaFiltro,
                        (int)n.Tipo,
                        n.DescripcionTipo,
                        n.Asegurado,
                        (decimal)n.ClienteFiltro,
                        n.Fecha,
                        n.Intermediario,
                        (int)n.VendedorFiltro,
                        n.Poliza,
                        (int)n.CodMoneda,
                        n.DescripcionMoneda,
                        n.Estatus,
                        (int)n.CodRamo,
                        n.InicioVigencia,
                        (DateTime)n.Inicio,
                        n.FinVigencia,
                        (DateTime)n.Fin,
                        (int)n.CodOficina,
                        n.Oficina,
                        (int)n.Dias,
                        (decimal)n.Facturado,
                        (decimal)n.Cobrado,
                        (decimal)n.Balance,
                        (decimal)n.Impuesto,
                        (decimal)n.PorcComision,
                        (decimal)n.ValorComision,
                        (decimal)n.ComisionPendiente,
                        (decimal)n.__0_10,
                        (decimal)n.__0_30,
                        (decimal)n.__31_60,
                        (decimal)n.__61_90,
                        (decimal)n.__91_120,
                        (decimal)n.__121_150,
                        (decimal)n.__151_MAS,
                        (decimal)n.Total,
                        (decimal)n.Diferencia,
                        (int)n.OrdenTipo,
                        "INSERT");
                    Save.ProcesarInformacion();
                }
                var ExportarReporteNeteado = (from n in ObDataMantenimiento.Value.ReporteAntiguedadSaldoNeteadoDetalle(
                    IdUsuario,
                    Convert.ToDecimal(txtTasaDollar.Text))
                                              select new {
                                                  FechaCorte = n.FechaCorteFormateado,
                                                  Asegurado = n.Asegurado,
                                                  Intermediario = n.Intermediario,
                                                  Poliza = n.Poliza,
                                                  DescripcionMoneda = n.DescripcionMoneda,
                                                  Estatus = n.Estatus,
                                                  Ramo = n.Ramo,
                                                  InicioVigencia = n.InicioVigencia,
                                                  FinVigencia = n.FinVigencia,
                                                  Facturado = n.Facturado,
                                                  Cobrado = n.Cobrado,
                                                  Balance = n.Balance,
                                                  Impuesto = n.Impuesto,
                                                  ValorComision = n.ValorComision,
                                                  ComisionPendiente = n.ComisionPendiente,
                                                  __0_30 = n.__0_30,
                                                  __31_60 = n.__31_60,
                                                  __61_90 = n.__61_90,
                                                  __91_120 = n.__91_120,
                                                  __121_150 = n.__121_150,
                                                  __151_mas = n.__151_mas,
                                                  Total = n.Total,
                                                  TotalPesos = n.TotalPesos,
                                                  TasaDollar = n.TasaDollar,
                                                  Diferencia = n.Diferencia
                                              }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Antiguedad Saldo Neteado", ExportarReporteNeteado);
            }
            
        }

        #region GENERAR REPORTE DE ANTIGUEDAD DE SALDO
        private void GenerarReporteAntiguedad(string RutaReporte, string NombreReporte) {

            string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFactura.Text.Trim()) ? null : txtNumeroFactura.Text.Trim();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _Tipo = ddlSeleccionarTipoMovimiento.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoMovimiento.SelectedValue) : new Nullable<int>();
            string _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? null : txtCodigoCliente.Text.Trim();
            string _Vendedor = string.IsNullOrEmpty(txtCodigoVendedor.Text.Trim()) ? null : txtCodigoVendedor.Text.Trim();
            int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
            int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();

            decimal UsuarioGenera = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

            ReportDocument Antiguedad = new ReportDocument();

            Antiguedad.Load(RutaReporte);
            Antiguedad.Refresh();

            Antiguedad.SetParameterValue("@FechaCorte", Convert.ToDateTime(txtFechaCorte.Text));
            Antiguedad.SetParameterValue("@NumeroFactura", _NumeroFactura);
            Antiguedad.SetParameterValue("@Poliza", _Poliza);
            Antiguedad.SetParameterValue("@Ramo", _Ramo);
            Antiguedad.SetParameterValue("@Tasa", Convert.ToDecimal(txtTasaDollar.Text));
            Antiguedad.SetParameterValue("@Tipo", _Tipo);
            Antiguedad.SetParameterValue("@CodigoCliente", _Cliente);
            Antiguedad.SetParameterValue("@CodigoVendedor", _Vendedor);
            Antiguedad.SetParameterValue("@Oficina", _Oficina);
            Antiguedad.SetParameterValue("@UsuarioGenera", UsuarioGenera);
            Antiguedad.SetParameterValue("@Moneda", _Moneda);

            Antiguedad.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                Antiguedad.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExcel.Checked == true) {
                Antiguedad.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
            else if (rbWord.Checked == true) {
                Antiguedad.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreReporte);
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
                lbPantalla.Text = "REPORTE DE ANTIGUEDAD DE SALDO";

                rbReporteResumido.Checked = true;
                rbPDF.Checked = true;
                rbSistema.Checked = true;
                CargarRamos();
                CargarTipoMovimientos();
                CargarOficinas();
                CargarMonedas();

                //SACAMOS LA TASA POR DEFECTO DEL SISTEMA
                decimal? Tasa = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda((int)TipoMonedas.Dollar);
                txtTasaDollar.Text = Tasa.ToString();
            }
        }

        protected void rbSistema_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbHistorico_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            string _CodigoCliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? null : txtCodigoCliente.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente SacarNombre = new Logica.Comunes.ESacarNombreCliente(_CodigoCliente);
            txtNombreCliente.Text = SacarNombre.SacarCodigoCLiente();
        }

        protected void txtCodigoVendedor_TextChanged(object sender, EventArgs e)
        {
            string _CodigoVendedor = string.IsNullOrEmpty(txtCodigoVendedor.Text.Trim()) ? null : txtCodigoVendedor.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarNombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoVendedor);
            txtNombreVendedor.Text = SacarNombre.SacarNombreIntermediario();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaCorte.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoFechaCorteVacio()", "CampoFechaCorteVacio();", true);
            }
            else
            {
                ExportarInformacionExcel();
            }
            
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaCorte.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoFechaCorteVacio()", "CampoFechaCorteVacio();", true);
            }
            else
            {
                if (rbReporteDetallado.Checked == true) {
                    GenerarReporteAntiguedad(Server.MapPath("ReporteAntiguedadSaldoDetallado.rpt"), "Antiguedad Saldo al " + txtFechaCorte.Text + " Detallado");
                }
                else if (rbReporteNeteado.Checked == true) { }
                else if (rbReporteResumido.Checked == true) { }
                

               
            }
            
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaCorte.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CampoFechaCorteVacio()", "CampoFechaCorteVacio();", true);
            }
            else {
                MostrarListadoPorPantalla();
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoPorPantalla();
        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoPorPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoPorPantalla();

        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoPorPantalla();
        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoPorPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }
    }
}
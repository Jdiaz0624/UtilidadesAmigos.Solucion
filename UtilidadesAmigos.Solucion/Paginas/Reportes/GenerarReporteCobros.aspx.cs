using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteCobros : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReporte = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();


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

        #region OCULTAR Y MOSTRAR GRAFICOS
        private void OcultarGraficos() {
            divGraficarSupervisores.Visible = false;
            divGraficarIntermediarios.Visible = false;
            divGraficarTipoPago.Visible = false;
            divGraficarConcepto.Visible = false;
            divGraficarRamo.Visible = false;
            divGraficaroficina.Visible = false;
            divGraficarusuario.Visible = false;
        }
        private void MostrarGraficos() {

            divGraficarSupervisores.Visible = true;
            divGraficarIntermediarios.Visible = true;
            divGraficarTipoPago.Visible = true;
            divGraficarConcepto.Visible = true;
            divGraficarRamo.Visible = true;
            divGraficaroficina.Visible = true;
            divGraficarusuario.Visible = true;
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarSucursales() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalConsulta, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);

        }
        private void CargarOficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaConsulta, ObjData.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue.ToString(), null), true);
        }
        private void CargarRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamoConsulta, ObjData.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarConceptos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarConceptoConsulta, ObjData.Value.BuscaListas("CONCEPTOCOBROS", null, null), true);
        }
        #endregion
        #region SACAR LA TASA POR DEFECTO
        private void SacarTasa() {
            txtTasaConsulta.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
        }
        #endregion
        #region CONSULTAR INFORMACION

        /// <summary>
        /// Este metodo es para mostrar el numero de paginas y la pagina actual en la que uno se encuentra actualmente.
        /// </summary>
        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); //Start from 0
            dt.Columns.Add("PageText"); //Start from 1

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
            lbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina; i < _UltimaPagina; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }
        /// <summary>
        /// Este metodo es para paginar el listado de la consulta mostrada
        /// </summary>
        /// <param name="RptGrid"></param>
        /// <param name="Listado"></param>
        /// <param name="_NumeroRegistros"></param>
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPaginasVariable.Text = pagedDataSource.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina : _NumeroRegistros);
            pagedDataSource.CurrentPageIndex = CurrentPage;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            lbPrimeraPagina.Enabled = !pagedDataSource.IsFirstPage;
            lbPaginaAnterior.Enabled = !pagedDataSource.IsFirstPage;
            lbSiguientePagina.Enabled = !pagedDataSource.IsLastPage;
            LinkUltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            rpListadoCobro.DataSource = pagedDataSource;
            rpListadoCobro.DataBind();


            divPaginacionrepeater.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion)
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
                    lbPaginaActual.Text = lbCantidadPaginasVariable.Text;
                    break;


            }

        }
        private void ConsultarInformacionPantalla() {
            if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()) || string.IsNullOrEmpty(txtTasaConsulta.Text.Trim()))
            {

            }
            else {
                string _Anulado = "";
                if (rbTodosRecibos.Checked == true) { _Anulado = null; }
                else if (rbRecibosActivos.Checked == true) { _Anulado = "N"; }
                else if (rbRecibosAnulados.Checked == true) { _Anulado = "S"; }


                string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
                int? _CodigoOficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
                int? _CodigoRamo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
                string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;
                decimal? _IdUsuario = 0;
                if (Session["IdUsuario"] != null)
                {
                    _IdUsuario = Convert.ToDecimal(Session["Idusuario"]);
                }
                else
                {
                    _IdUsuario = 0;
                }

                string _Poliza = string.IsNullOrEmpty(txtNumeroPolizaCOnsulta.Text.Trim()) ? null : txtNumeroPolizaCOnsulta.Text.Trim();
                string _NumeroRecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? null : txtNumeroRecibo.Text.Trim();
                var Buscarregistros = ObjDataReporte.Value.BuscarDataReporteCobrosDetalle(
                    _Poliza,
                    _NumeroRecibo,
                    _Anulado,
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHastaConsulta.Text),
                    null, null,
                    _CodigoIntermediario,
                    _CodigoSupervisor,
                    _CodigoOficina,
                    _CodigoRamo,
                    null, null,
                    _Concepto,
                    Convert.ToDecimal(txtTasaConsulta.Text),
                    _IdUsuario);
                if (Buscarregistros.Count() < 1) {
                    lbCantidadRegistrosVariable.Text = "0";
                    lbTotalCobradoPesosVariable.Text = "0";
                    lbTotalCobradoDollarVariable.Text = "0";
                }
                else {
                    int CantidadRegistros = 0;
                    decimal CobradoPesos = 0, CobradoDollar = 0, Tasa = 0, ConversionDollar = 0;


                    foreach (var n in Buscarregistros) {
                        CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                        CobradoPesos = Convert.ToDecimal(n.TotalCobradoPesos);
                        CobradoDollar = Convert.ToDecimal(n.TotalCobradoDolar);
                    }

                    Tasa = Convert.ToDecimal(txtTasaConsulta.Text);
                    ConversionDollar = CobradoDollar * Tasa;
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                    lbTotalCobradoPesosVariable.Text = CobradoPesos.ToString("N2");
                    lbTotalCobradoDollarVariable.Text = CobradoDollar.ToString("N2");
                    lbPesosDollarConvertidoVariable.Text = ConversionDollar.ToString("N2");
                }
                Paginar(ref rpListadoCobro, Buscarregistros, 10);

                //gvListadoCobros.DataSource = Buscarregistros;
                //gvListadoCobros.DataBind();

                if (cbGraficar.Checked == true) {
                    GenerarGraficos();
                }
                HandlePaging();
            }
        }
        #endregion
        #region GENERAR LOS GRAFICOS
        private void GenerarGraficos() {
            GraficarConcepto();
            GraficarTipoPago();
            GraficarIntermediario();
            GraficarSupervisor();
            GraficarOficina();
            GraficarRamo();
            Graficarusuario();
        }
        private void GraficarConcepto() {
            decimal[] MontoConcepto = new decimal[10];
            string[] NombreConcepto = new string[10];
            int Contador = 0;

            //VALIDAMOS LOS CAMPOS PARA PASARLOS COMO PARAMETROS
            string _Poliza = "N/A";
            string _NumeroRecibo = "N/A";
            string _Anulado = "";
            if (rbTodosRecibos.Checked == true) {
                _Anulado = "P";
            }
            else if (rbRecibosActivos.Checked == true) {
                _Anulado = "N";
            }
            else if (rbRecibosAnulados.Checked == true) {
                _Anulado = "S";
            }
            string _TipoPago = "N/A";
            string _CodigoCliente = "N/A";
            string _CodigoIntermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()))
            {
                _CodigoIntermediario = "N/A";
            }
            else {
                _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            }
            string _CodigoSupervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim())) {
                _CodigoSupervisor = "N/A";
            }
            else {
                _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            }
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            if (_Oficina == null) {
                _Oficina = 0;
            }
            int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
            if (_Ramo == null) {
                _Ramo = 0;
            }
            string _Usuario = "N/A";
            int? _Moneda = 0;
            string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;
            if (_Concepto == null) {
                _Concepto = "N/A";
            }

            //GENERAMOS EL GRAFICO CON LOS DATOS RECOLECTADOS

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICO_REPORTE_COBROS] @Poliza,@Numero,@Anulado,@FechaDesde,@FechaHasta,@TipoPago,@CodigoCliente,@CodigoIntermediario,@CodigoSupervisor,@CodigoOficina,@CodigoRamo,@Usuario,@CodigoMoneda,@Concepto,@Tasa,@TipoGrafico", Conexion);

            Comando.Parameters.AddWithValue("@Poliza", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Numero", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Anulado", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoCliente", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoOficina", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@CodigoRamo", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoMoneda", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Concepto", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Tasa", SqlDbType.Decimal);
            Comando.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);

            Comando.Parameters["@Poliza"].Value = _Poliza;
            Comando.Parameters["@Numero"].Value = _NumeroRecibo;
            Comando.Parameters["@Anulado"].Value = _Anulado;
            Comando.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesdeConsulta.Text);
            Comando.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHastaConsulta.Text);
            Comando.Parameters["@TipoPago"].Value = _TipoPago;
            Comando.Parameters["@CodigoCliente"].Value = _CodigoCliente;
            Comando.Parameters["@CodigoIntermediario"].Value = _CodigoIntermediario;
            Comando.Parameters["@CodigoSupervisor"].Value = _CodigoSupervisor;
            Comando.Parameters["@CodigoOficina"].Value = Convert.ToInt32(_Oficina);
            Comando.Parameters["@CodigoRamo"].Value = Convert.ToInt32(_Ramo);
            Comando.Parameters["@Usuario"].Value = _Usuario;
            Comando.Parameters["@CodigoMoneda"].Value = Convert.ToInt32(_Moneda);
            Comando.Parameters["@Concepto"].Value = _Concepto;
            Comando.Parameters["@Tasa"].Value = Convert.ToDecimal(txtTasaConsulta.Text);
            Comando.Parameters["@TipoGrafico"].Value = 1;

            Conexion.Open();

            SqlDataReader Reader = Comando.ExecuteReader();
            while (Reader.Read()) {
                MontoConcepto[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreConcepto[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();

            GraConcepto.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraConcepto.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraConcepto.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraConcepto.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraConcepto.Series["Serie"].Points.DataBindXY(NombreConcepto, MontoConcepto);


        }
        private void GraficarTipoPago() {
            decimal[] MontoTipoPago = new decimal[10];
            string[] NombreTipoPago = new string[10];
            int Contador = 0;

            //VALIDAMOS LOS CAMPOS PARA PASARLOS COMO PARAMETROS
            string _Poliza = "N/A";
            string _NumeroRecibo = "N/A";
            string _Anulado = "";
            if (rbTodosRecibos.Checked == true)
            {
                _Anulado = "P";
            }
            else if (rbRecibosActivos.Checked == true)
            {
                _Anulado = "N";
            }
            else if (rbRecibosAnulados.Checked == true)
            {
                _Anulado = "S";
            }
            string _TipoPago = "N/A";
            string _CodigoCliente = "N/A";
            string _CodigoIntermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()))
            {
                _CodigoIntermediario = "N/A";
            }
            else
            {
                _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            }
            string _CodigoSupervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()))
            {
                _CodigoSupervisor = "N/A";
            }
            else
            {
                _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            }
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            if (_Oficina == null)
            {
                _Oficina = 0;
            }
            int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }
            string _Usuario = "N/A";
            int? _Moneda = 0;
            string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;
            if (_Concepto == null)
            {
                _Concepto = "N/A";
            }

            //GENERAMOS EL GRAFICO CON LOS DATOS RECOLECTADOS

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICO_REPORTE_COBROS] @Poliza,@Numero,@Anulado,@FechaDesde,@FechaHasta,@TipoPago,@CodigoCliente,@CodigoIntermediario,@CodigoSupervisor,@CodigoOficina,@CodigoRamo,@Usuario,@CodigoMoneda,@Concepto,@Tasa,@TipoGrafico", Conexion);

            Comando.Parameters.AddWithValue("@Poliza", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Numero", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Anulado", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoCliente", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoOficina", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@CodigoRamo", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoMoneda", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Concepto", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Tasa", SqlDbType.Decimal);
            Comando.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);

            Comando.Parameters["@Poliza"].Value = _Poliza;
            Comando.Parameters["@Numero"].Value = _NumeroRecibo;
            Comando.Parameters["@Anulado"].Value = _Anulado;
            Comando.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesdeConsulta.Text);
            Comando.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHastaConsulta.Text);
            Comando.Parameters["@TipoPago"].Value = _TipoPago;
            Comando.Parameters["@CodigoCliente"].Value = _CodigoCliente;
            Comando.Parameters["@CodigoIntermediario"].Value = _CodigoIntermediario;
            Comando.Parameters["@CodigoSupervisor"].Value = _CodigoSupervisor;
            Comando.Parameters["@CodigoOficina"].Value = Convert.ToInt32(_Oficina);
            Comando.Parameters["@CodigoRamo"].Value = Convert.ToInt32(_Ramo);
            Comando.Parameters["@Usuario"].Value = _Usuario;
            Comando.Parameters["@CodigoMoneda"].Value = Convert.ToInt32(_Moneda);
            Comando.Parameters["@Concepto"].Value = _Concepto;
            Comando.Parameters["@Tasa"].Value = Convert.ToDecimal(txtTasaConsulta.Text);
            Comando.Parameters["@TipoGrafico"].Value = 2;

            Conexion.Open();

            SqlDataReader Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                MontoTipoPago[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreTipoPago[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();

            GraTipoPago.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraTipoPago.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraTipoPago.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraTipoPago.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraTipoPago.Series["Serie"].Points.DataBindXY(NombreTipoPago, MontoTipoPago);
        }
        private void GraficarIntermediario() {
            decimal[] MontoIntermediario = new decimal[10];
            string[] NombreIntermediario = new string[10];
            int Contador = 0;

            //VALIDAMOS LOS CAMPOS PARA PASARLOS COMO PARAMETROS
            string _Poliza = "N/A";
            string _NumeroRecibo = "N/A";
            string _Anulado = "";
            if (rbTodosRecibos.Checked == true)
            {
                _Anulado = "P";
            }
            else if (rbRecibosActivos.Checked == true)
            {
                _Anulado = "N";
            }
            else if (rbRecibosAnulados.Checked == true)
            {
                _Anulado = "S";
            }
            string _TipoPago = "N/A";
            string _CodigoCliente = "N/A";
            string _CodigoIntermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()))
            {
                _CodigoIntermediario = "N/A";
            }
            else
            {
                _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            }
            string _CodigoSupervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()))
            {
                _CodigoSupervisor = "N/A";
            }
            else
            {
                _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            }
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            if (_Oficina == null)
            {
                _Oficina = 0;
            }
            int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }
            string _Usuario = "N/A";
            int? _Moneda = 0;
            string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;
            if (_Concepto == null)
            {
                _Concepto = "N/A";
            }

            //GENERAMOS EL GRAFICO CON LOS DATOS RECOLECTADOS

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICO_REPORTE_COBROS] @Poliza,@Numero,@Anulado,@FechaDesde,@FechaHasta,@TipoPago,@CodigoCliente,@CodigoIntermediario,@CodigoSupervisor,@CodigoOficina,@CodigoRamo,@Usuario,@CodigoMoneda,@Concepto,@Tasa,@TipoGrafico", Conexion);

            Comando.Parameters.AddWithValue("@Poliza", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Numero", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Anulado", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoCliente", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoOficina", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@CodigoRamo", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoMoneda", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Concepto", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Tasa", SqlDbType.Decimal);
            Comando.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);

            Comando.Parameters["@Poliza"].Value = _Poliza;
            Comando.Parameters["@Numero"].Value = _NumeroRecibo;
            Comando.Parameters["@Anulado"].Value = _Anulado;
            Comando.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesdeConsulta.Text);
            Comando.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHastaConsulta.Text);
            Comando.Parameters["@TipoPago"].Value = _TipoPago;
            Comando.Parameters["@CodigoCliente"].Value = _CodigoCliente;
            Comando.Parameters["@CodigoIntermediario"].Value = _CodigoIntermediario;
            Comando.Parameters["@CodigoSupervisor"].Value = _CodigoSupervisor;
            Comando.Parameters["@CodigoOficina"].Value = Convert.ToInt32(_Oficina);
            Comando.Parameters["@CodigoRamo"].Value = Convert.ToInt32(_Ramo);
            Comando.Parameters["@Usuario"].Value = _Usuario;
            Comando.Parameters["@CodigoMoneda"].Value = Convert.ToInt32(_Moneda);
            Comando.Parameters["@Concepto"].Value = _Concepto;
            Comando.Parameters["@Tasa"].Value = Convert.ToDecimal(txtTasaConsulta.Text);
            Comando.Parameters["@TipoGrafico"].Value = 3;

            Conexion.Open();

            SqlDataReader Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                MontoIntermediario[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreIntermediario[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();

            GraIntermediarios.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraIntermediarios.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraIntermediarios.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraIntermediarios.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraIntermediarios.Series["Serie"].Points.DataBindXY(NombreIntermediario, MontoIntermediario);
        }
        private void GraficarSupervisor() {
            decimal[] MontoSupervisor = new decimal[10];
            string[] NombreSupervisor = new string[10];
            int Contador = 0;

            //VALIDAMOS LOS CAMPOS PARA PASARLOS COMO PARAMETROS
            string _Poliza = "N/A";
            string _NumeroRecibo = "N/A";
            string _Anulado = "";
            if (rbTodosRecibos.Checked == true)
            {
                _Anulado = "P";
            }
            else if (rbRecibosActivos.Checked == true)
            {
                _Anulado = "N";
            }
            else if (rbRecibosAnulados.Checked == true)
            {
                _Anulado = "S";
            }
            string _TipoPago = "N/A";
            string _CodigoCliente = "N/A";
            string _CodigoIntermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()))
            {
                _CodigoIntermediario = "N/A";
            }
            else
            {
                _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            }
            string _CodigoSupervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()))
            {
                _CodigoSupervisor = "N/A";
            }
            else
            {
                _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            }
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            if (_Oficina == null)
            {
                _Oficina = 0;
            }
            int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }
            string _Usuario = "N/A";
            int? _Moneda = 0;
            string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;
            if (_Concepto == null)
            {
                _Concepto = "N/A";
            }

            //GENERAMOS EL GRAFICO CON LOS DATOS RECOLECTADOS

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICO_REPORTE_COBROS] @Poliza,@Numero,@Anulado,@FechaDesde,@FechaHasta,@TipoPago,@CodigoCliente,@CodigoIntermediario,@CodigoSupervisor,@CodigoOficina,@CodigoRamo,@Usuario,@CodigoMoneda,@Concepto,@Tasa,@TipoGrafico", Conexion);

            Comando.Parameters.AddWithValue("@Poliza", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Numero", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Anulado", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoCliente", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoOficina", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@CodigoRamo", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoMoneda", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Concepto", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Tasa", SqlDbType.Decimal);
            Comando.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);

            Comando.Parameters["@Poliza"].Value = _Poliza;
            Comando.Parameters["@Numero"].Value = _NumeroRecibo;
            Comando.Parameters["@Anulado"].Value = _Anulado;
            Comando.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesdeConsulta.Text);
            Comando.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHastaConsulta.Text);
            Comando.Parameters["@TipoPago"].Value = _TipoPago;
            Comando.Parameters["@CodigoCliente"].Value = _CodigoCliente;
            Comando.Parameters["@CodigoIntermediario"].Value = _CodigoIntermediario;
            Comando.Parameters["@CodigoSupervisor"].Value = _CodigoSupervisor;
            Comando.Parameters["@CodigoOficina"].Value = Convert.ToInt32(_Oficina);
            Comando.Parameters["@CodigoRamo"].Value = Convert.ToInt32(_Ramo);
            Comando.Parameters["@Usuario"].Value = _Usuario;
            Comando.Parameters["@CodigoMoneda"].Value = Convert.ToInt32(_Moneda);
            Comando.Parameters["@Concepto"].Value = _Concepto;
            Comando.Parameters["@Tasa"].Value = Convert.ToDecimal(txtTasaConsulta.Text);
            Comando.Parameters["@TipoGrafico"].Value = 4;

            Conexion.Open();

            SqlDataReader Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                MontoSupervisor[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreSupervisor[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();

            GraSupervisores.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraSupervisores.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraSupervisores.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraSupervisores.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraSupervisores.Series["Serie"].Points.DataBindXY(NombreSupervisor, MontoSupervisor);
        }
        private void GraficarOficina() {
            decimal[] Montooficina = new decimal[10];
            string[] NombreOficina = new string[10];
            int Contador = 0;

            //VALIDAMOS LOS CAMPOS PARA PASARLOS COMO PARAMETROS
            string _Poliza = "N/A";
            string _NumeroRecibo = "N/A";
            string _Anulado = "";
            if (rbTodosRecibos.Checked == true)
            {
                _Anulado = "P";
            }
            else if (rbRecibosActivos.Checked == true)
            {
                _Anulado = "N";
            }
            else if (rbRecibosAnulados.Checked == true)
            {
                _Anulado = "S";
            }
            string _TipoPago = "N/A";
            string _CodigoCliente = "N/A";
            string _CodigoIntermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()))
            {
                _CodigoIntermediario = "N/A";
            }
            else
            {
                _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            }
            string _CodigoSupervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()))
            {
                _CodigoSupervisor = "N/A";
            }
            else
            {
                _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            }
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            if (_Oficina == null)
            {
                _Oficina = 0;
            }
            int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }
            string _Usuario = "N/A";
            int? _Moneda = 0;
            string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;
            if (_Concepto == null)
            {
                _Concepto = "N/A";
            }

            //GENERAMOS EL GRAFICO CON LOS DATOS RECOLECTADOS

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICO_REPORTE_COBROS] @Poliza,@Numero,@Anulado,@FechaDesde,@FechaHasta,@TipoPago,@CodigoCliente,@CodigoIntermediario,@CodigoSupervisor,@CodigoOficina,@CodigoRamo,@Usuario,@CodigoMoneda,@Concepto,@Tasa,@TipoGrafico", Conexion);

            Comando.Parameters.AddWithValue("@Poliza", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Numero", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Anulado", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoCliente", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoOficina", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@CodigoRamo", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoMoneda", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Concepto", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Tasa", SqlDbType.Decimal);
            Comando.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);

            Comando.Parameters["@Poliza"].Value = _Poliza;
            Comando.Parameters["@Numero"].Value = _NumeroRecibo;
            Comando.Parameters["@Anulado"].Value = _Anulado;
            Comando.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesdeConsulta.Text);
            Comando.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHastaConsulta.Text);
            Comando.Parameters["@TipoPago"].Value = _TipoPago;
            Comando.Parameters["@CodigoCliente"].Value = _CodigoCliente;
            Comando.Parameters["@CodigoIntermediario"].Value = _CodigoIntermediario;
            Comando.Parameters["@CodigoSupervisor"].Value = _CodigoSupervisor;
            Comando.Parameters["@CodigoOficina"].Value = Convert.ToInt32(_Oficina);
            Comando.Parameters["@CodigoRamo"].Value = Convert.ToInt32(_Ramo);
            Comando.Parameters["@Usuario"].Value = _Usuario;
            Comando.Parameters["@CodigoMoneda"].Value = Convert.ToInt32(_Moneda);
            Comando.Parameters["@Concepto"].Value = _Concepto;
            Comando.Parameters["@Tasa"].Value = Convert.ToDecimal(txtTasaConsulta.Text);
            Comando.Parameters["@TipoGrafico"].Value = 5;

            Conexion.Open();

            SqlDataReader Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                Montooficina[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreOficina[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();

            GraOficina.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraOficina.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraOficina.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraOficina.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraOficina.Series["Serie"].Points.DataBindXY(NombreOficina, Montooficina);
        }
        private void GraficarRamo() {
            decimal[] MontoRamo = new decimal[10];
            string[] NombreRamo = new string[10];
            int Contador = 0;

            //VALIDAMOS LOS CAMPOS PARA PASARLOS COMO PARAMETROS
            string _Poliza = "N/A";
            string _NumeroRecibo = "N/A";
            string _Anulado = "";
            if (rbTodosRecibos.Checked == true)
            {
                _Anulado = "P";
            }
            else if (rbRecibosActivos.Checked == true)
            {
                _Anulado = "N";
            }
            else if (rbRecibosAnulados.Checked == true)
            {
                _Anulado = "S";
            }
            string _TipoPago = "N/A";
            string _CodigoCliente = "N/A";
            string _CodigoIntermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()))
            {
                _CodigoIntermediario = "N/A";
            }
            else
            {
                _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            }
            string _CodigoSupervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()))
            {
                _CodigoSupervisor = "N/A";
            }
            else
            {
                _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            }
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            if (_Oficina == null)
            {
                _Oficina = 0;
            }
            int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }
            string _Usuario = "N/A";
            int? _Moneda = 0;
            string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;
            if (_Concepto == null)
            {
                _Concepto = "N/A";
            }

            //GENERAMOS EL GRAFICO CON LOS DATOS RECOLECTADOS

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICO_REPORTE_COBROS] @Poliza,@Numero,@Anulado,@FechaDesde,@FechaHasta,@TipoPago,@CodigoCliente,@CodigoIntermediario,@CodigoSupervisor,@CodigoOficina,@CodigoRamo,@Usuario,@CodigoMoneda,@Concepto,@Tasa,@TipoGrafico", Conexion);

            Comando.Parameters.AddWithValue("@Poliza", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Numero", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Anulado", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoCliente", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoOficina", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@CodigoRamo", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoMoneda", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Concepto", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Tasa", SqlDbType.Decimal);
            Comando.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);

            Comando.Parameters["@Poliza"].Value = _Poliza;
            Comando.Parameters["@Numero"].Value = _NumeroRecibo;
            Comando.Parameters["@Anulado"].Value = _Anulado;
            Comando.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesdeConsulta.Text);
            Comando.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHastaConsulta.Text);
            Comando.Parameters["@TipoPago"].Value = _TipoPago;
            Comando.Parameters["@CodigoCliente"].Value = _CodigoCliente;
            Comando.Parameters["@CodigoIntermediario"].Value = _CodigoIntermediario;
            Comando.Parameters["@CodigoSupervisor"].Value = _CodigoSupervisor;
            Comando.Parameters["@CodigoOficina"].Value = Convert.ToInt32(_Oficina);
            Comando.Parameters["@CodigoRamo"].Value = Convert.ToInt32(_Ramo);
            Comando.Parameters["@Usuario"].Value = _Usuario;
            Comando.Parameters["@CodigoMoneda"].Value = Convert.ToInt32(_Moneda);
            Comando.Parameters["@Concepto"].Value = _Concepto;
            Comando.Parameters["@Tasa"].Value = Convert.ToDecimal(txtTasaConsulta.Text);
            Comando.Parameters["@TipoGrafico"].Value = 6;

            Conexion.Open();

            SqlDataReader Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                MontoRamo[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreRamo[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();

            GraRamo.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraRamo.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraRamo.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraRamo.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraRamo.Series["Serie"].Points.DataBindXY(NombreRamo, MontoRamo);
        }
        private void Graficarusuario() {
            decimal[] MontoUsuario = new decimal[10];
            string[] NombreUsuario = new string[10];
            int Contador = 0;

            //VALIDAMOS LOS CAMPOS PARA PASARLOS COMO PARAMETROS
            string _Poliza = "N/A";
            string _NumeroRecibo = "N/A";
            string _Anulado = "";
            if (rbTodosRecibos.Checked == true)
            {
                _Anulado = "P";
            }
            else if (rbRecibosActivos.Checked == true)
            {
                _Anulado = "N";
            }
            else if (rbRecibosAnulados.Checked == true)
            {
                _Anulado = "S";
            }
            string _TipoPago = "N/A";
            string _CodigoCliente = "N/A";
            string _CodigoIntermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()))
            {
                _CodigoIntermediario = "N/A";
            }
            else
            {
                _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            }
            string _CodigoSupervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()))
            {
                _CodigoSupervisor = "N/A";
            }
            else
            {
                _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            }
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            if (_Oficina == null)
            {
                _Oficina = 0;
            }
            int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }
            string _Usuario = "N/A";
            int? _Moneda = 0;
            string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;
            if (_Concepto == null)
            {
                _Concepto = "N/A";
            }

            //GENERAMOS EL GRAFICO CON LOS DATOS RECOLECTADOS

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICO_REPORTE_COBROS] @Poliza,@Numero,@Anulado,@FechaDesde,@FechaHasta,@TipoPago,@CodigoCliente,@CodigoIntermediario,@CodigoSupervisor,@CodigoOficina,@CodigoRamo,@Usuario,@CodigoMoneda,@Concepto,@Tasa,@TipoGrafico", Conexion);

            Comando.Parameters.AddWithValue("@Poliza", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Numero", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Anulado", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoCliente", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoOficina", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@CodigoRamo", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@CodigoMoneda", SqlDbType.Int);
            Comando.Parameters.AddWithValue("@Concepto", SqlDbType.VarChar);
            Comando.Parameters.AddWithValue("@Tasa", SqlDbType.Decimal);
            Comando.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);

            Comando.Parameters["@Poliza"].Value = _Poliza;
            Comando.Parameters["@Numero"].Value = _NumeroRecibo;
            Comando.Parameters["@Anulado"].Value = _Anulado;
            Comando.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesdeConsulta.Text);
            Comando.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHastaConsulta.Text);
            Comando.Parameters["@TipoPago"].Value = _TipoPago;
            Comando.Parameters["@CodigoCliente"].Value = _CodigoCliente;
            Comando.Parameters["@CodigoIntermediario"].Value = _CodigoIntermediario;
            Comando.Parameters["@CodigoSupervisor"].Value = _CodigoSupervisor;
            Comando.Parameters["@CodigoOficina"].Value = Convert.ToInt32(_Oficina);
            Comando.Parameters["@CodigoRamo"].Value = Convert.ToInt32(_Ramo);
            Comando.Parameters["@Usuario"].Value = _Usuario;
            Comando.Parameters["@CodigoMoneda"].Value = Convert.ToInt32(_Moneda);
            Comando.Parameters["@Concepto"].Value = _Concepto;
            Comando.Parameters["@Tasa"].Value = Convert.ToDecimal(txtTasaConsulta.Text);
            Comando.Parameters["@TipoGrafico"].Value = 7;

            Conexion.Open();

            SqlDataReader Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                MontoUsuario[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreUsuario[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();

            GraUsuario.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraUsuario.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraUsuario.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraUsuario.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraUsuario.Series["Serie"].Points.DataBindXY(NombreUsuario, MontoUsuario);
        }
        #endregion
        #region GENERAR REPORTES DE COBROS
        private void GenerarReporteCobro(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBD, string NombreReporte) {
            //ESTABLECEMOS LOS FILTROS QUE SE VAN A UTILIZAR
            string _Poliza = string.IsNullOrEmpty(txtNumeroPolizaCOnsulta.Text.Trim()) ? null : txtNumeroPolizaCOnsulta.Text.Trim();
            string _Numerorecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? null : txtNumeroRecibo.Text.Trim();

            string _Anulado = "";
            if (rbTodosRecibos.Checked == true) {
                _Anulado = null;
            }
            else if (rbRecibosActivos.Checked == true) {
                _Anulado = "N";
            }
            else if (rbRecibosAnulados.Checked == true) {
                _Anulado = "S";
            }
            string _TipoPago = null;
            string _CodigoCliente = null;
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
            string _Usuario = null;
            int? _Moneda = null;
            string _Concepto = ddlSeleccionarConceptoConsulta.SelectedValue != "-1" ? ddlSeleccionarConceptoConsulta.SelectedItem.Text : null;

            ReportDocument ReporteNoAgrupadoDetalle = new ReportDocument();

            ReporteNoAgrupadoDetalle.Load(RutaReporte);
            ReporteNoAgrupadoDetalle.Refresh();
            ReporteNoAgrupadoDetalle.SetParameterValue("@Poliza", _Poliza);
            ReporteNoAgrupadoDetalle.SetParameterValue("@Numero", _Numerorecibo);
            ReporteNoAgrupadoDetalle.SetParameterValue("@Anulado", _Anulado);
            ReporteNoAgrupadoDetalle.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesdeConsulta.Text));
            ReporteNoAgrupadoDetalle.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHastaConsulta.Text));
            ReporteNoAgrupadoDetalle.SetParameterValue("@TipoPago", _TipoPago);
            ReporteNoAgrupadoDetalle.SetParameterValue("@CodigoCliente", _CodigoCliente);
            ReporteNoAgrupadoDetalle.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            ReporteNoAgrupadoDetalle.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            ReporteNoAgrupadoDetalle.SetParameterValue("@CodigoOficina", _Oficina);
            ReporteNoAgrupadoDetalle.SetParameterValue("@CodigoRamo", _Ramo);
            ReporteNoAgrupadoDetalle.SetParameterValue("@Usuario", _Usuario);
            ReporteNoAgrupadoDetalle.SetParameterValue("@CodigoMoneda", _Moneda);
            ReporteNoAgrupadoDetalle.SetParameterValue("@Concepto", _Concepto);
            ReporteNoAgrupadoDetalle.SetParameterValue("@Tasa", Convert.ToDecimal(txtTasaConsulta.Text));
            ReporteNoAgrupadoDetalle.SetParameterValue("@IdUsuarioProcesa", IdUsuario);
            ReporteNoAgrupadoDetalle.SetDatabaseLogon(UsuarioBD, ClaveBD);
            if (rbExportarPDF.Checked == true) {
                ReporteNoAgrupadoDetalle.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExportarExcel.Checked == true) {
                ReporteNoAgrupadoDetalle.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
            else if (rbExportarWord.Checked == true) {
                ReporteNoAgrupadoDetalle.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreReporte);
            }
            else if (rbExportarTXT.Checked == true) {
                ReporteNoAgrupadoDetalle.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreReporte);
            }
            else if (rbExportarCSV.Checked == true) {
                ReporteNoAgrupadoDetalle.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreReporte);
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
                lbPantalla.Text = "GENERAR REPORTE DE COBRO";

                divPaginacionrepeater.Visible = false;
                rbNoAgruparDatos.Checked = true;
                rbReporteDetallado.Checked = true;
                rbTodosRecibos.Checked = true;
                rbExportarPDF.Checked = true;
                OcultarGraficos();
                CargarSucursales();
                CargarOficinas();
                CargarRamos();
                CargarConceptos();
                SacarTasa();
            }
        }

        protected void rbNoAgruparDatos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoAgruparDatos.Checked == true)
            {
                lbTipoReporte.Visible = true;
                divTipoReporte.Visible = true;
            }
            else
            {
                lbTipoReporte.Visible = false;
                divTipoReporte.Visible = false;
            }
        }

        protected void rbAgruparPorConcepto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorConcepto.Checked == true)
            {
                lbTipoReporte.Visible = false;
                divTipoReporte.Visible = false;
            }
            else
            {
                lbTipoReporte.Visible = true;
                divTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparTipoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparTipoPago.Checked == true)
            {
                lbTipoReporte.Visible = false;
                divTipoReporte.Visible = false;
            }
            else
            {
                lbTipoReporte.Visible = true;
                divTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparIntermediario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparIntermediario.Checked == true)
            {
                lbTipoReporte.Visible = false;
                divTipoReporte.Visible = false;
            }
            else
            {
                lbTipoReporte.Visible = true;
                divTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparSupervisor.Checked == true)
            {
                lbTipoReporte.Visible = false;
                divTipoReporte.Visible = false;
            }
            else
            {
                lbTipoReporte.Visible = true;
                divTipoReporte.Visible = true;
            }
        }

        protected void rbAgruparPorOficina_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorOficina.Checked == true)
            {
                lbTipoReporte.Visible = false;
                divTipoReporte.Visible = false;
            }
            else
            {
                lbTipoReporte.Visible = true;
                divTipoReporte.Visible = true;
            }
        }

        protected void rbAgrupaRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgrupaRamo.Checked == true) 
                {
                lbTipoReporte.Visible = false;
                divTipoReporte.Visible = false;
                }
            else
                {
                lbTipoReporte.Visible = true;
                divTipoReporte.Visible = true;
                }
            }

        protected void rbAgruparUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparUsuario.Checked == true) {
                lbTipoReporte.Visible = false;
                divTipoReporte.Visible = false;
            }
            else {
                lbTipoReporte.Visible = true;
                divTipoReporte.Visible = true;
            }
        }

        protected void txtCodigoSupervisorConsulta_TextChanged(object sender, EventArgs e)
        {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarInformacion = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoSupervisor);
            txtNombreSupervisorConsulta.Text = SacarInformacion.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediarioConsulta_TextChanged(object sender, EventArgs e)
        {
            string _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarInformacion = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_Intermediario);
            txtNombreIntermediarioConsulta.Text = SacarInformacion.SacarNombreIntermediario();
        }

        protected void ddlSeleccionarSucursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinas();
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdevacio()", "CampoFechaDesdevacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void btnExportarRegistros_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdevacio()", "CampoFechaDesdevacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {
                decimal IdUsuarioProcesa = 0;
                if (Session["IdUsuario"] != null)
                {
                    IdUsuarioProcesa = Convert.ToDecimal(Session["IdUsuario"]);
                }
                else
                {
                    IdUsuarioProcesa = 0;
                }

                if (rbNoAgruparDatos.Checked == true)
                {
                  

                    if (rbReporteDetallado.Checked == true)
                    {


                        GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoNoAgrupadoDetalle.rpt"), "sa", "Pa$$W0rd", "Reporte de Cobros Detallado");
                    }
                    else if (rbReporteResumido.Checked == true) {

                        GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoResumen.rpt"), "sa", "Pa$$W0rd", "Reporte de Cobros no Agrupado Resumido");


                    }
                }
                else if (rbAgruparPorConcepto.Checked == true) {
                    GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoAgrupadoConcepto.rpt"), "sa", "Pa$$W0rd", "Reporte Cobrado Agrupado Por Concepto");
                }
                else if (rbAgruparTipoPago.Checked == true) {
                    GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoAgrupadoTipoPago.rpt"), "sa", "Pa$$W0rd", "Reporte Cobrado Agrupado Por Tipo de Pago");
                }
                else if (rbAgruparIntermediario.Checked == true) {
                    GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoAgrupadoIntermediario.rpt"), "sa", "Pa$$W0rd", "Reporte Cobrado Agrupado Por Intermediario");
                }
                else if (rbAgruparSupervisor.Checked == true) {
                    GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoAgrupadoSupervisor.rpt"), "sa", "Pa$$W0rd", "Reporte Cobrado Agrupado Por Supervisor");
                }
                else if (rbAgruparPorOficina.Checked == true) {
                    GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoAgrupadoOficina.rpt"), "sa", "Pa$$W0rd", "Reporte Cobrado Agrupado por Oficina");
                }
                else if (rbAgrupaRamo.Checked == true) {
                    GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoAgrupadoPorRamo.rpt"), "sa", "Pa$$W0rd", "Reporte Cobrado Agrupado Por Ramo");
                }
                else if (rbAgruparUsuario.Checked == true) {
                    GenerarReporteCobro(IdUsuarioProcesa, Server.MapPath("ReporteCobradoAgrupadoPorUsuario.rpt"), "sa", "Pa$$W0rd", "Reporte Cobrado Agrupado por Usuaio");
                }
            }
        }

        protected void gvListadoCobros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvListadoCobros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cbGraficar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGraficar.Checked == true) {
                MostrarGraficos();
               
            }
            else {
                OcultarGraficos();
            }
        }

        protected void lbPrimeraPagina_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            ConsultarInformacionPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PrimeraPagina);
        }

        protected void lbPaginaAnterior_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            ConsultarInformacionPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior);
        }

        protected void lbSiguientePagina_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;

            ConsultarInformacionPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.SiguientePagina);
        }

        protected void LinkUltimaPagina_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ConsultarInformacionPantalla();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina);
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            ConsultarInformacionPantalla();
        }

        protected void rbAgrupadoPorDia_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
        }
    }
}
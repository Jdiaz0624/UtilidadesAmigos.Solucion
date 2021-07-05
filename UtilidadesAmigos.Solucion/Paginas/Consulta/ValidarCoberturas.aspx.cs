using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ValidarCoberturas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        enum CodigosCoberturas { 
        TuAsistencia=1,
        AeroAmbulancia=2,
        ServiGrua=3,
        CaribeAsistencia=4,
        CasaConductor=5,
        Cedensa=6
        }

        enum CodigosPlanCoberturas { 
        AeroAmbulancia2=0,
        CasaConductor=17,
        TuAsistenciaPremium=32,
        AeroAmbulancia=35,
        TuAsistenciaSuperior=37,
        TuAsistenciaBasica=38
        }



        #region GENERAR REPORTE DE COBERTURAS
        private void GenerarReporteCoberturas(string RutaReporte, string NombreReporte) {
            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _PlanCobertura = ddlSeleccionarPlanCobertura.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue) : new Nullable<int>();
            decimal? _UsuarioGenera = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0 ;

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();
            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@Poliza", _Poliza);
            Reporte.SetParameterValue("@Cobertura", _PlanCobertura);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@UsuarioGenera", _UsuarioGenera);
            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");
            if (rbExportarPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExportarExel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
            else if (rbExportartxt.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreReporte);
            }
            else if (rbExportarcsv.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreReporte);
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


        private void HandlePaging(ref DataList NombreDataList, ref Label lbPaginaActual)
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
            lbPaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton PaginaSiguiente, ref LinkButton UltimaPagina)
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
            PaginaSiguiente.Enabled = !pagedDataSource.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            RptGrid.DataSource = pagedDataSource;
            RptGrid.DataBind();


            //  divPaginacionBancos.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label CantidadPagina)
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
                    lbPaginaActual.Text = CantidadPagina.Text;
                    break;


            }

        }
        #endregion



        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarCoberturas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCpbertura, ObjData.Value.BuscaListas("COBERTURA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCoberturaPlanCobertura, ObjData.Value.BuscaListas("COBERTURA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null));
        }
        private void CargarPlanCoberturas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null));
        }
        #endregion

        #region MOSTRAR LAS COBERTURAS
        private void MostrarCoberturas()
        {
            txtCoberturaMantenimiento.Text = string.Empty;
            string _Cobertura = string.IsNullOrEmpty(txtCoberturaMantenimiento.Text.Trim()) ? null : txtCoberturaMantenimiento.Text.Trim();

            var Buscar = ObjData.Value.BuscaCoberturaMantenimiento(
                new Nullable<decimal> (),
                _Cobertura);
            Paginar(ref rpListadoCoberturas, Buscar, 10, ref lbCantidadPaginaVariableCoberturas, ref LinkPrimeroCoberturas, ref LinkAnteriorCoberturas, ref LinkSiguienteCoberturas, ref LinkUltimoCoberturas);
            HandlePaging(ref dtPaginacionCoberturas, ref lbPaginaActualVariableCoberturas);
           
        }
        #endregion
        #region MANTENIMIENTO DE COBERTURAS
        private void MAnCoberturas(decimal? IdCobertura)
        {
            try {
                if (Session["IdUsuario"] != null)
                {
                    UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento Mantenimiento = new Logica.Entidades.EBuscaCoberturasMantenimiento();

                    Mantenimiento.IdCobertura = IdCobertura;
                    Mantenimiento.Descripcion = txtCoberturaMantenimiento.Text;
                    Mantenimiento.Estatus0 = cbEstatus.Checked;

                    var MAN = ObjData.Value.MantenimientoCobertura(Mantenimiento, "UPDATE");
                    MostrarCoberturas();
                    CargarCoberturas();
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (Exception) { }
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS PLANES DE CBERTURAS
        private void ListadoPlanCoberturas()
        {
            var Buscar = ObjData.Value.BuscaPlanCoberturas();
            Paginar(ref rpListadoPlanCobertura, Buscar, 10, ref lbCantidadPaginaVariablePlanCoberturas, ref LinkPrimeroPlanCobertura, ref LinkAnteriorPlanCobertura, ref LinkSiguientePlanCobertura, ref LinkUltimoPlanCobertura);
            HandlePaging(ref dlPlanCobertura, ref lbPaginaActualVariablePlanCoberturas);
        }
        #endregion
        #region MANTENIMIENTO DE PLAN DE COBERTURAS
        private void MANPlanCoberturas()
        {
            try {
                if (Session["IdUsuario"] != null)
                {
                    UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento Mantenimiento = new Logica.Entidades.EPlanCoberturasMantenimiento();

                    Mantenimiento.IdPlanCobertura = Convert.ToDecimal(lbIdMantenimientoPlanCobertura.Text);
                    Mantenimiento.IdCobertura = Convert.ToDecimal(ddlCoberturaPlanCobertura.SelectedValue);
                    Mantenimiento.CodigoCobertura = Convert.ToDecimal(txtCodigoCoberturaPlanCobertura.Text);
                    Mantenimiento.PlanCobertura = txtPlanCobertura.Text;
                    Mantenimiento.Estatus0 = cbEstatusPlanCobertura.Checked;

                    var MAN = ObjData.Value.MantenimientoPlanCoberturas(Mantenimiento, "UPDATE");
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }

            }
            catch (Exception) { }
        }
        #endregion
        #region MOSTRAR LA DATA DE LAS COBERTURAS
        private void MostrarDataCoberturas()
        {
           
            if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 1)
            {
                try
                {
                    //SACAMOS LA DATA DE TU ASISTENCIA
                    var SacarDataTuAsistencia = ObjData.Value.SacarDataTuAsistencia(
                      Convert.ToDateTime(txtFechaDesde.Text),
                      Convert.ToDateTime(txtFechaHasta.Text),
                      txtPolizaFiltro.Text,
                      Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));

                    ContarCantidadRegistrosMostrados();
                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 2)
            {
                try {
                    //EXPORTAR LA DATA DE LA CASA DE AERO AMBULANCIA
                    var SacarDataCasaConductor = ObjData.Value.SacarDataCasaConductor(
                       Convert.ToDateTime(txtFechaDesde.Text),
                       Convert.ToDateTime(txtFechaHasta.Text),
                       txtPolizaFiltro.Text,
                       Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
  
                    ContarCantidadRegistrosMostrados();

                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
                try {

                    

                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 3)
            {
                try { }
                catch (Exception) {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 4)
            {
                try { }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 5)
            {
                try {
                    //SACAMOS LA DATA DE LA CASA DEL CONDUCTOR

                    var SacarDataCasaConductor = ObjData.Value.SacarDataCasaConductor(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        txtPolizaFiltro.Text,
                        17);
            
                    ContarCantidadRegistrosMostrados();
                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
               


            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 6)
            {
                try {
                    //SACAMOS LA DATA DE CEDENSA
                    ClientScript.RegisterStartupScript(GetType(), "DataCedensa", "DataCedensa();", true);

                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            

            }
        }
        #endregion
        #region CONTAR LA CANTIDAD DE REGISTROS MOSTRADOS
        private void ContarCantidadRegistrosMostrados()
        {
            if (Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue) == 1)
            {
                //CONTAMOS LA DATA DE TU ASISTENCIA
                try {
                    var Contar = ObjData.Value.ContarRegistrosTuAsistencia(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        txtPolizaFiltro.Text,
                        Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
                    foreach (var n in Contar)
                    {
                        lbCantidadRegistrosListadoGeneralVariable.Text = n.Total.ToString();
                    }

                }
                catch (Exception) { }
            }
            else if (Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue) == 2)
            {
                //CONTAMOS LA DATA DE AEROAMBULANCIA
                try {
                    var Contar = ObjData.Value.ContarRegistrosCasaConductoraeroAmbulancia(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        txtPolizaFiltro.Text,
                        Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
                    foreach (var n in Contar)
                    {
                        lbCantidadRegistrosListadoGeneralVariable.Text = n.Total.ToString();
                    }
                }
                catch (Exception) { }
            }
            else if (Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue) == 3)
            {

            }
            else if (Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue) == 4)
            {

            }
            else if (Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue) == 5)
            {
                //CONTAMOS LA DATA DE CASA DEL CONDUCTOR
                try
                {
                    var Contar = ObjData.Value.ContarRegistrosCasaConductoraeroAmbulancia(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        txtPolizaFiltro.Text,
                        Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
                    foreach (var n in Contar)
                    {
                        lbCantidadRegistrosListadoGeneralVariable.Text = n.Total.ToString();
                    }
                }
                catch (Exception) { }
            }
            else if (Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue) == 6)
            {
                //CONTAMOS LA DATA CORRESPONDIENTE A CEDENSA
                try {
                    var Contar = ObjData.Value.ContarRegistrosCedensa(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        txtPolizaFiltro.Text,
                        Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
                    foreach (var n in Contar)
                    {
                        lbCantidadRegistrosListadoGeneralVariable.Text = n.Total.ToString();
                    }
                }
                catch (Exception) { }
            }
            else
            {
                lbCantidadRegistrosListadoGeneralVariable.Text = "0";
            }
        }
        #endregion
        //----------------------------------------------------------------------------------------------------------------------------------------
        private void CargarSucursales() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursal, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void Cargaroficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjData.Value.BuscaListas("OFICINA", ddlSeleccionarSucursal.SelectedValue.ToString(), null), true);
        }

        #region MOSTRAR EL LISTADO DE LAS COBERTURAS FINAL
        private void MostrarListadoCoberturaFinal() {

            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
                
            }
            else {
                string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                int? _Cobertura = ddlSeleccionarPlanCobertura.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue) : new Nullable<int>();
                int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

                var BuscarListadoCoberturas = ObjData.Value.SacarDataCoberturasFinal(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Poliza,
                    _Cobertura,
                    _Oficina,
                    null);
                if (BuscarListadoCoberturas.Count() < 1)
                {
                    lbCantidadRegistrosListadoGeneralVariable.Text = "0";
                }
                else
                {
                    int CantidadRegistros = 0;
                    foreach (var n in BuscarListadoCoberturas)
                    {
                        CantidadRegistros = (int)n.CantidadRegistros;
                    }
                    lbCantidadRegistrosListadoGeneralVariable.Text = CantidadRegistros.ToString("N0");
                    Paginar(ref rpListadoCoberturasPrincipal, BuscarListadoCoberturas, 10, ref lbCantidadPaginaVariableListadoPrincipal, ref LinkPrimeraListadoPrincipal, ref LinkAnteriorListadoPrincipal, ref LinkSiguienteListadoPrincipal, ref LinkUltimoListadoPrincipal);
                    HandlePaging(ref dtPaginacionListadoPrincipal, ref lbPaginaActualVariableListadoPrincipal);
                    DivPaginacionListadoPrincipal.Visible = true;

                    GenerarGrafico();
                }
            }
        }
        #endregion
        #region GENERAR GRAFICO
        private void GenerarGrafico() {
            int[] CantidadRegistros = new int[2];
            string[] Nombre = new string[2];
            int Contador = 0;

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICO_ESTATUS_COBERTURA_FINAL] @FechaDesde,@FechaHasta,@Poliza,@Cobertura,@Oficina", Conexion);

            //FILTROS
            string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? "N/A" : txtPolizaFiltro.Text.Trim();
            int? _oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : 0;

            Comando.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date).Value = Convert.ToDateTime(txtFechaDesde.Text);
            Comando.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date).Value = Convert.ToDateTime(txtFechaHasta.Text);
            Comando.Parameters.AddWithValue("@Poliza", SqlDbType.VarChar).Value = _Poliza;
            Comando.Parameters.AddWithValue("@Cobertura", SqlDbType.Int).Value = Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue);
            Comando.Parameters.AddWithValue("@Oficina", SqlDbType.Int).Value = _oficina;
            //Comando.Parameters.AddWithValue("@UsuarioGenera", SqlDbType.Int).Value = _UsuarioGenera;

            Conexion.Open();
            SqlDataReader reader = Comando.ExecuteReader();
            while (reader.Read()) {
                CantidadRegistros[Contador] = Convert.ToInt32(reader.GetInt32(1));
                Nombre[Contador] = reader.GetString(0);
                Contador++;
            }
            reader.Close();
            Conexion.Close();

            GraEstatus.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraEstatus.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraEstatus.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraEstatus.Series["Serie"].Points.DataBindXY(Nombre, CantidadRegistros);

        }
        #endregion
        #region EXPORTAR LA DATA PLANO
        private void ExportarConsultaExcel(int Cobertura, int PlanCobertura) {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                string _Poliza = string.IsNullOrEmpty(txtPolizaFiltro.Text.Trim()) ? null : txtPolizaFiltro.Text.Trim();
                int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

                if (Cobertura == (int)CodigosCoberturas.CasaConductor || Cobertura == (int)CodigosCoberturas.AeroAmbulancia) {
                    var EscribirExcel = (from n in ObjData.Value.SacarDataCoberturasFinal(
                       Convert.ToDateTime(txtFechaDesde.Text),
                       Convert.ToDateTime(txtFechaHasta.Text),
                       _Poliza,
                       PlanCobertura,
                       _Oficina,
                       null)
                                         select new
                                         {
                                             Poliza=n.Poliza,
                                             Items=n.Items,
                                             Estatus=n.Estatus,
                                             Concepto=n.Concepto,
                                             Cliente=n.Cliente,
                                             TipoRNC=n.TipoIdentificacion,
                                             RNC=n.NumeroIdentificacion,
                                             Vendedor=n.Intermediario,
                                             Inicio=n.InicioVigencia,
                                             Fin=n.FinVigencia,
                                             Proceso=n.FechaProceso,
                                             Mes=n.MesValidado,
                                             TipoVehiculo=n.Tipovehiculo,
                                             Marca=n.Marca,
                                             Modelo=n.Modelo,
                                             Capacidad=n.Capacidad,
                                             Ano=n.Ano,
                                             Color=n.Color,
                                             Chasis=n.Chasis,
                                             Placa=n.Placa,
                                             ValorAsegurado=n.ValorAsegurado,
                                             Cobertura=n.Cobertura,
                                             Movimiento=n.TipoMovimiento
                                         }).ToList();
                    string NombreArchivo = "";
                    string NombreOficina = ddlSeleccionaroficina.SelectedValue != "-1" ? ddlSeleccionaroficina.SelectedItem.Text  : "Todas las Oficinas";
                    NombreArchivo = ddlSeleccionarCpbertura.SelectedItem.Text + " - " + NombreOficina;
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreArchivo, EscribirExcel);
                }
                else if (Cobertura == (int)CodigosCoberturas.TuAsistencia) {
                    var EscribirExcel = (from n in ObjData.Value.SacarDataCoberturasFinal(
                       Convert.ToDateTime(txtFechaDesde.Text),
                       Convert.ToDateTime(txtFechaHasta.Text),
                       _Poliza,
                       PlanCobertura,
                       _Oficina,null)
                                         select new
                                         {
                                             Nombre=n.NombreCliente,
                                             Apellido=n.ApellidoCliente,
                                             Poliza=n.Poliza,
                                             Ciudad=n.Ciudad,
                                             Direccion=n.DireccionCliente,
                                             Telefono=n.Telefono,
                                             TipoRNC=n.TipoIdentificacion,
                                             RNC=n.NumeroIdentificacion,
                                             TipoVehiculo=n.Tipovehiculo,
                                             Marca=n.Marca,
                                             Modelo=n.Modelo,
                                             Ano=n.Ano,
                                             Color=n.Color,
                                             Chasis=n.Chasis,
                                             Placa=n.Placa,
                                             Inicio=n.InicioVigencia,
                                             Fin=n.FinVigencia,
                                             Estatus=n.Estatus,
                                             Cobertura=n.Cobertura,
                                             Movimiento=n.TipoMovimiento
                                         }).ToList();
                    string NombreArchivo = "";
                    string NombreOficina = ddlSeleccionaroficina.SelectedValue != "-1" ? ddlSeleccionaroficina.SelectedItem.Text : "Todas las Oficinas";
                    NombreArchivo = ddlSeleccionarCpbertura.SelectedItem.Text + " - " + NombreOficina;
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreArchivo, EscribirExcel);
                }

                
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR DATA DE COBERTURAS";
                CargarCoberturas();
                MostrarCoberturas();
                ListadoPlanCoberturas();
                CargarSucursales();
                Cargaroficinas();
                rbExportarExel.Checked = true;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            // MostrarDataCoberturas();
            CurrentPage = 0;
            MostrarListadoCoberturaFinal();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            
            int PlanCobertura = Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue);

            switch (PlanCobertura)
            {

                case (int)CodigosPlanCoberturas.AeroAmbulancia:
                    //EXPORTAMOS LA DATA DE AEROAMBULANCIA
                    ExportarConsultaExcel(Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue), (int)CodigosPlanCoberturas.AeroAmbulancia);
                    break;

                case (int)CodigosPlanCoberturas.AeroAmbulancia2:
                    //EXPORTAMOS LA DATA DE AEROAMBULANCIA 2
                    ExportarConsultaExcel(Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue), (int)CodigosPlanCoberturas.AeroAmbulancia2);
                    break;

                case (int)CodigosPlanCoberturas.CasaConductor:
                    //EXPORTAMOS LA DATA DE CASA DEL CONDUCTOR
                    ExportarConsultaExcel(Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue), (int)CodigosPlanCoberturas.CasaConductor);
                    break;

                case (int)CodigosPlanCoberturas.TuAsistenciaPremium:
                    //EXPORTAMOS LA DATA DE GRUPO NOBE PREMIUM
                    ExportarConsultaExcel(Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue), (int)CodigosPlanCoberturas.TuAsistenciaPremium);
                    break;

                case (int)CodigosPlanCoberturas.TuAsistenciaSuperior:
                    //EXPORTAR LA DATA DE GRUPO NOBE SUERIOR
                    ExportarConsultaExcel(Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue), (int)CodigosPlanCoberturas.TuAsistenciaSuperior);
                    break;

                case (int)CodigosPlanCoberturas.TuAsistenciaBasica:
                    //EXPORTAR LA DATA DE GRUPO NOBE SUPERIOR
                    ExportarConsultaExcel(Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue), (int)CodigosPlanCoberturas.TuAsistenciaBasica);
                    break;
            }



            #region CODIGO ANTERIOR
            //if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 1)
            //{
            //    try
            //    {
            //        //EXPORTAMOS LA DATA DE TU ASISTENCIA
            //        //VERIFICAMOS QUE TIPO DE EXPORTACION SE VA A UTILIZAR
            //        if (rbExportarExel.Checked)
            //        {
            //            //EXPORTAMOS LA DATA A EXEL
            //            var ExportarExel = (from n in ObjData.Value.SacarDataTuAsistencia(
            //                Convert.ToDateTime(txtFechaDesde.Text),
            //                Convert.ToDateTime(txtFechaHasta.Text),
            //                txtPolizaFiltro.Text,
            //                Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue))
            //                                select new
            //                                {
            //                                    Nombre = n.Nombre,
            //                                    Apellido = n.Apellido,
            //                                    Poliza = n.Poliza,
            //                                    Ciudad = n.Ciudad,
            //                                    Direccion = n.Direccion,
            //                                    Telefono = n.Telefono,
            //                                    TipoIdentificacion = n.TipoIdentificacion,
            //                                    NoIdentificacion = n.NumeroIdentificacion,
            //                                    TipoVehiculo = n.Tipovehiculo,
            //                                    Marca = n.Marca,
            //                                    Modelo = n.Modelo,
            //                                    Ano = n.Ano,
            //                                    Color = n.Color,
            //                                    Chasis = n.Chasis,
            //                                    Placa = n.Placa,
            //                                    InicioVigencia = n.InicioVigencia,
            //                                    FinVigencia = n.FinVigencia,
            //                                    Estatus = n.Estatus,
            //                                    Cobertura = n.Cobertura,
            //                                    TipoMovimiento = n.TipoMovimiento
            //                                }).ToList();
            //            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Tu Asistencia", ExportarExel);

            //        }
            //        else if (rbExportarcsv.Checked)
            //        {
            //            //EXPORTAMOS LA DATA A CSV

            //            var ExportarDataCSV = ObjData.Value.SacarDataTuAsistencia(
            //                Convert.ToDateTime(txtFechaDesde.Text),
            //                Convert.ToDateTime(txtFechaHasta.Text),
            //                txtPolizaFiltro.Text,
            //                Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
            //            string nombrea = "";
            //            int TipoPlan = Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue);
            //            string Ano = Convert.ToDateTime(txtFechaHasta.Text).Year.ToString();
            //            string Dia = Convert.ToDateTime(txtFechaHasta.Text).Day.ToString();
            //            string Mes = Convert.ToDateTime(txtFechaHasta.Text).Month.ToString();
            //            if (TipoPlan == 32)
            //            {
            //                nombrea = "S001-GrupoNobeFull-" + Ano + Dia + Mes;
            //            }
            //            else
            //            {
            //                nombrea = "S002-GrupoNobeLey-" + Ano + Dia + Mes;
            //            }
            //            //   UtilidadesAmigos.Logica.Comunes.ExportarDataExel.ExportarCSV(nombrea, ExportarDataCSV);UtilidadesAmigos.Logica.Entidades.EExportarDatatxtCSV Exportar = new Logica.Entidades.EExportarDatatxtCSV();
            //            UtilidadesAmigos.Logica.Entidades.EExportarDatatxtCSV Exportar = new Logica.Entidades.EExportarDatatxtCSV();

            //            foreach (var n in ExportarDataCSV)
            //            {
            //                Exportar.Nombre = n.Nombre;
            //                Exportar.Apellido = n.Apellido;
            //                Response.Clear();
            //                Response.ContentType = "text/csv";
            //                Response.AddHeader("Content-Disposition", "attachment;filename=Plantilla.csv");
            //                Response.Write(Exportar.ToString());
            //                Response.End();
            //            }



            //        }
            //    }
            //    catch (Exception)
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
            //    }
            //}
            //else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 2)
            //{
            //    try
            //    {
            //        //EXPORTAR DATA AEROAMBULANCIA
            //        var Exportar = (from n in ObjData.Value.SacarDataCasaConductor(
            //        Convert.ToDateTime(txtFechaDesde.Text),
            //        Convert.ToDateTime(txtFechaHasta.Text),
            //        txtPolizaFiltro.Text,
            //        Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue))
            //                        select new
            //                        {
            //                            Poliza = n.Poliza,
            //                            Items = n.Items,
            //                            Estatus = n.Estatus,
            //                            Concepto = n.Concepto,
            //                            Cliente = n.Cliente,
            //                            TipoIdentificacion = n.TipoIdentificacion,
            //                            NumeroIdentificacion = n.NumeroIdentificacion,
            //                            Intermediario = n.Intermediario,
            //                            InicioVigencia = n.InicioVigencia,
            //                            FinVigencia = n.FinVigencia,
            //                            FechaProceso = n.FechaProceso,
            //                            MesValidado = n.MesValidado,
            //                            TipoVehiculo = n.Tipovehiculo,
            //                            Marca = n.Marca,
            //                            Modelo = n.Modelo,
            //                            Capacidad = n.Capacidad,
            //                            Ano = n.Ano,
            //                            Color = n.Color,
            //                            Chasis = n.Chasis,
            //                            Placa = n.Placa,
            //                            ValorAsegurado = n.ValorAsegurado,
            //                            Cobertura = n.Cobertura,
            //                            TipoMovimiento = n.TipoMovimiento,

            //                        }).ToList();
            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Registros Casa del Conductor", Exportar);
            //    }
            //    catch (Exception)
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
            //    }

            //}
            //else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 3)
            //{
            //    try { }
            //    catch (Exception)
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
            //    }

            //}
            //else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 4)
            //{
            //    try { }
            //    catch (Exception)
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
            //    }
            //}
            //else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 5)
            //{
            //    try
            //    {
            //        //EXPORTAR CASA DEL CONDUCTOR
            //        var Exportar = (from n in ObjData.Value.SacarDataCasaConductor(
            //        Convert.ToDateTime(txtFechaDesde.Text),
            //        Convert.ToDateTime(txtFechaHasta.Text),
            //        txtPolizaFiltro.Text,
            //        17)
            //                        select new
            //                        {
            //                            Poliza = n.Poliza,
            //                            Items = n.Items,
            //                            Estatus = n.Estatus,
            //                            Concepto = n.Concepto,
            //                            Cliente = n.Cliente,
            //                            TipoIdentificacion = n.TipoIdentificacion,
            //                            NumeroIdentificacion = n.NumeroIdentificacion,
            //                            Intermediario = n.Intermediario,
            //                            InicioVigencia = n.InicioVigencia,
            //                            FinVigencia = n.FinVigencia,
            //                            FechaProceso = n.FechaProceso,
            //                            MesValidado = n.MesValidado,
            //                            TipoVehiculo = n.Tipovehiculo,
            //                            Marca = n.Marca,
            //                            Modelo = n.Modelo,
            //                            Capacidad = n.Capacidad,
            //                            Ano = n.Ano,
            //                            Color = n.Color,
            //                            Chasis = n.Chasis,
            //                            Placa = n.Placa,
            //                            ValorAsegurado = n.ValorAsegurado,
            //                            Cobertura = n.Cobertura,
            //                            TipoMovimiento = n.TipoMovimiento,

            //                        }).ToList();
            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Registros Casa del Conductor", Exportar);
            //    }
            //    catch (Exception)
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
            //    }

            //}
            //else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 6)
            //{
            //    try
            //    {
            //        //EXPORTAR CEDENSA
            //        var ExportarCedensa = (from n in ObjData.Value.GenerarDataCedensa()
            //                               select new
            //                               {
            //                                   Poliza = n.Poliza,
            //                                   Fecha_de_Adiciona = n.Fecha_de_Adiciona,
            //                                   Inicio_de_Vigencia = n.Inicio_de_Vigencia,
            //                                   Fin_de_Vigencia = n.Fin_de_Vigencia,
            //                                   Tipo_de_Plan = n.Tipo_de_Plan,
            //                                   Estatus = n.Estatus,
            //                                   Parentezco = n.Parentezco,
            //                                   Nombre = n.Nombre,
            //                                   Provincia = n.Provincia,
            //                                   Direccion = n.Direccion,
            //                                   Telefono = n.Telefono,
            //                                   Cedula = n.Cedula,
            //                                   Fecha_de_Nacimiento = n.Fecha_de_Nacimiento,
            //                                   Prima = n.Prima
            //                               }).ToList();

            //        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Data Cedensa", ExportarCedensa);
            //    }
            //    catch (Exception)
            //    {
            //        ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
            //    }

            //}
            #endregion

        }



        protected void rbGenerarDataRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        protected void rbGenerarDataCompleta_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void rbGenerarDataRangoFecha_CheckedChanged1(object sender, EventArgs e)
        {
          
        }

        protected void ddlSeleccionarCpbertura_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanCoberturas();
        }

        protected void btnGuardarCobertura_Click(object sender, EventArgs e)
        {
            MAnCoberturas(Convert.ToDecimal(lbIdCobertura.Text));
            ListadoPlanCoberturas();
            CargarCoberturas();
        }


        protected void btnGuardarPlanCobertura_Click(object sender, EventArgs e)
        {
            MANPlanCoberturas();
            ListadoPlanCoberturas();
            CargarCoberturas();
        }

        protected void ddlSeleccionarSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargaroficinas();
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())){
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())){
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                int CoberturaSeleccionada = Convert.ToInt32(ddlSeleccionarCpbertura.SelectedValue);

                if (CoberturaSeleccionada == (int)CodigosCoberturas.CasaConductor || CoberturaSeleccionada == (int)CodigosCoberturas.AeroAmbulancia)
                {
                    string NombreReporte = "";
                    if (CoberturaSeleccionada == (int)CodigosCoberturas.CasaConductor)
                    {
                        NombreReporte = "Reporte de Casa del Conductor";
                    }
                    else if (CoberturaSeleccionada == (int)CodigosCoberturas.AeroAmbulancia)
                    {
                        NombreReporte = "Reporte de Aero Ambulancia";
                    }
                    GenerarReporteCoberturas(Server.MapPath("ReporteCoberturaCasaConductor.rpt"), NombreReporte);
                }
                else if (CoberturaSeleccionada == (int)CodigosCoberturas.TuAsistencia)
                {
                    if (rbExportarcsv.Checked == true || rbExportartxt.Checked == true)
                    {
                        GenerarReporteCoberturas(Server.MapPath("ReporteCoberturaTuAsistenciaArchivoPlano.rpt"), "Reporte de Tu Asistencia");
                    }
                    else
                    {
                        GenerarReporteCoberturas(Server.MapPath("ReporteCoberturaTuAsistencia.rpt"), "Reporte de Tu Asistencia");
                    }

                }
            }
          
        }

        protected void LinkPrimeraListadoPrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoCoberturaFinal();
        }

        protected void LinkAnteriorListadoPrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoCoberturaFinal();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableListadoPrincipal, ref lbCantidadPaginaVariableListadoPrincipal);
        }

        protected void dtPaginacionListadoPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoCoberturaFinal();
        }

        protected void LinkSiguienteListadoPrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoCoberturaFinal();
        }

        protected void btnSeleccionarCobertura_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdCobertura = ((HiddenField)ItemSeleccionado.FindControl("hfIdCobertura")).Value.ToString();
            lbIdCobertura.Text = hfIdCobertura.ToString();

            var SeleccionarRegistro = ObjData.Value.BuscaCoberturaMantenimiento(Convert.ToDecimal(hfIdCobertura), null);
            foreach (var n in SeleccionarRegistro) {
                txtCoberturaMantenimiento.Text = n.Descripcion;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
        }

        protected void LinkPrimeroCoberturas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarCoberturas();
        }

        protected void LinkAnteriorCoberturas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarCoberturas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableCoberturas, ref lbCantidadPaginaVariableCoberturas);
        }

        protected void dtPaginacionCoberturas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCoberturas_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarCoberturas();
        }

        protected void LinkSiguienteCoberturas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarCoberturas();
        }

        protected void LinkUltimoCoberturas_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarCoberturas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableCoberturas, ref lbCantidadPaginaVariableCoberturas);
        }

        protected void btnSeleccionarPlanCobertura_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdPlanCobertura = ((HiddenField)ItemSeleccionado.FindControl("hfIdPlanCobertura")).Value.ToString();

            var MostrarPlanCoberturaSeleccionado = ObjData.Value.BuscaPlanCoberturas(Convert.ToDecimal(hfIdPlanCobertura));
            Paginar(ref rpListadoPlanCobertura, MostrarPlanCoberturaSeleccionado, 1, ref lbCantidadPaginaVariablePlanCoberturas, ref LinkPrimeroPlanCobertura, ref LinkAnteriorPlanCobertura, ref LinkSiguientePlanCobertura, ref LinkUltimoPlanCobertura);
            HandlePaging(ref dlPlanCobertura, ref lbPaginaActualVariablePlanCoberturas);
            lbIdMantenimientoPlanCobertura.Text = hfIdPlanCobertura.ToString();

            foreach (var n in MostrarPlanCoberturaSeleccionado) {
                CargarPlanCoberturas();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlCoberturaPlanCobertura, n.IdCobertura.ToString());
                txtCodigoCoberturaPlanCobertura.Text = n.CodigoCobertura.ToString();
                txtPlanCobertura.Text = n.PlanCobertura;
                cbEstatusPlanCobertura.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }

            txtCodigoCoberturaPlanCobertura.Enabled = false;

        }

        protected void LinkPrimeroPlanCobertura_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorPlanCobertura_Click(object sender, EventArgs e)
        {

        }

        protected void dlPlanCobertura_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dlPlanCobertura_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguientePlanCobertura_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoPlanCobertura_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoListadoPrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoCoberturaFinal();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina,ref lbPaginaActualVariableListadoPrincipal,ref lbCantidadPaginaVariableListadoPrincipal);
        }
    }
}
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


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ListadoRenovacion : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();

        enum PermisoReporteMachado { 
        JuanMarcelino=1,
        AlfredoPimentel=10,
        AdalgisaAlmonte=18,
        MiguelBerroa=22,
        JessicaPayano=31,
        EriksonVeras=30,
        DismailisAcosta=27,
        IngriHerrera=17,
        RiselotRojas=21
        }

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, Objdata.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubramos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubRamo, Objdata.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamo.SelectedValue, null), true);

        }
        private void CargarOficina()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, Objdata.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }

        private void ValidarBalance()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValidarBalance, Objdata.Value.BuscaListas("VALIDABALANCE", null, null));
        }
        private void ExcluirMotores()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlExcluirMotorew, Objdata.Value.BuscaListas("EXCLUIR", null, null));
        }
        private void CargarMesesAño() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMes, Objdata.Value.BuscaListas("MESES", null, null));
            int Mes = 0, Ano = 0;

            Mes = (int)DateTime.Now.Month;
            Ano = (int)DateTime.Now.Year;

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarMes, Mes.ToString());
            txtAno.Text = Ano.ToString();

        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES PARA LA ESTADISTICA
        private void CargarRamosEstadistica()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamoEstadistica, Objdata.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubramosEstadistica()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubramoEstadistica, Objdata.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamoEstadistica.SelectedValue, null), true);

        }
        private void CargarOficinaEstadistica()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaEstadistica, Objdata.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }

        private void ValidarBalanceEstadistica()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValidarBalanceEstadistica, Objdata.Value.BuscaListas("VALIDABALANCE", null, null));
        }
        private void ExcluirMotoresEstadistica()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlExcluirMotoresEstadistica, Objdata.Value.BuscaListas("EXCLUIR", null, null));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS RENOVACIONES
        private void MostrarListadoRenovaciones()
        {
            try {

                int RamoSeleccionado = Convert.ToInt32(ddlSeleccionarRamo.SelectedValue);
                int Excluir = Convert.ToInt32(ddlExcluirMotorew.SelectedValue);

                if (RamoSeleccionado == 106 && Excluir == 2)
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Subramo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _ValidarBalance = ddlValidarBalance.SelectedValue != "-1" ? Convert.ToInt32(ddlValidarBalance.SelectedValue) : new Nullable<int>();
                    string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                    string _CodSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
                    string _CodIntermediario = string.IsNullOrEmpty(txtFCodIntermediario.Text.Trim()) ? null : txtFCodIntermediario.Text.Trim();

                    var Buscar = Objdata.Value.ReporteRenovacionPoliza(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHAsta.Text),
                        _Ramo,
                        _Subramo,
                        _Poliza,
                        null,
                        _Oficina,
                        _CodSupervisor,
                        _CodIntermediario,
                        _ValidarBalance,
                        2);
                    //foreach (var n in Buscar)
                    //{
                    //    lbMesDesde.Text = n.FechaDesde;
                    //    lbMesHasta.Text = n.FechaHasta;
                    //    lbDIas.Text = n.Dias.ToString();
                    //    lbMes.Text = n.Mes.ToString();
                    //    lbano.Text = n.Anos.ToString();
                    //}
                    Paginar(ref rpListadoRenovacion, Buscar, 10, ref lbCantidadPaginaVAriable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
                    HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);
                    divPaginacion.Visible = true;
                }
                else
                {
                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Subramo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _ValidarBalance = ddlValidarBalance.SelectedValue != "-1" ? Convert.ToInt32(ddlValidarBalance.SelectedValue) : new Nullable<int>();
                    string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                    string _CodSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
                    string _CodIntermediario = string.IsNullOrEmpty(txtFCodIntermediario.Text.Trim()) ? null : txtFCodIntermediario.Text.Trim();

                    var Buscar = Objdata.Value.ReporteRenovacionPoliza(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHAsta.Text),
                        _Ramo,
                        _Subramo,
                        _Poliza,
                        null,
                        _Oficina,
                        _CodSupervisor,
                        _CodIntermediario,
                        _ValidarBalance,
                        1);
                    //foreach (var n in Buscar)
                    //{
                    //    lbMesDesde.Text = n.FechaDesde;
                    //    lbMesHasta.Text = n.FechaHasta;
                    //    lbDIas.Text = n.Dias.ToString();
                    //    lbMes.Text = n.Mes.ToString();
                    //    lbano.Text = n.Anos.ToString();
                    //}
                    Paginar(ref rpListadoRenovacion, Buscar, 10, ref lbCantidadPaginaVAriable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
                    HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);
                    divPaginacion.Visible = true;
                }
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }
        #endregion
        #region CARGAR LISTADO ESTADISTICA
        private void CargarListadoEstadistica()
        {
            try {
                //CONSULTAMOS
                //VERIFICAMOS LA CONDICION ESPECIAL
                int Persona = 0;
                int? _Ramo = ddlSeleccionarRamoEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoEstadistica.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubramoEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramoEstadistica.SelectedValue) : new Nullable<int>();
                int? _Oficina = ddlSeleccionaroficinaEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaEstadistica.SelectedValue) : new Nullable<int>();
                int? _ValidarBalance = ddlValidarBalanceEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlValidarBalanceEstadistica.SelectedValue) : new Nullable<int>();
                int? _ExcluirMotores = ddlExcluirMotoresEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlExcluirMotoresEstadistica.SelectedValue) : new Nullable<int>();

                if (rbEstadisticaSupervisor.Checked == true)
                {
                    Persona = 1;
                }
                else if (rbEstadisticaIntermediario.Checked == true)
                {
                    Persona = 2;
                }
                if (Convert.ToInt32(ddlSeleccionarRamoEstadistica.SelectedValue) == 106 && Convert.ToInt32(ddlExcluirMotoresEstadistica.SelectedValue) == 2)
                {
                    var BuscarRegistros = Objdata.Value.SacarEstadisticaRenovacion(
                        Convert.ToDateTime(txtFechaDesdeEstadistica.Text),
                        Convert.ToDateTime(txtFechaHastaEstadistica.Text),
                        _Ramo,
                        _SubRamo,
                        _Oficina,
                        _ValidarBalance,
                        _ExcluirMotores,
                        Persona);
                    Paginar(ref rpListadoEstadistica, BuscarRegistros, 10, ref lbCantidadPaginaVAriableEstadistica, ref linkPrimerostadistica, ref LinkAnteirorEstadistica, ref LinkSiguienteEstadistica, ref LinkUltimoEstadistica);
                    HandlePaging(ref dtEstadistica, ref lbPaginaActualVariavleEstadistica);
                    DivPaginacionEstadistica.Visible = true;
                }
                else
                {
                    var BuscarRegistros = Objdata.Value.SacarEstadisticaRenovacion(
                       Convert.ToDateTime(txtFechaDesdeEstadistica.Text),
                       Convert.ToDateTime(txtFechaHastaEstadistica.Text),
                       _Ramo,
                       _SubRamo,
                       _Oficina,
                       _ValidarBalance,
                       _ExcluirMotores,
                       Persona);
                    Paginar(ref rpListadoEstadistica, BuscarRegistros, 10, ref lbCantidadPaginaVAriableEstadistica, ref linkPrimerostadistica, ref LinkAnteirorEstadistica, ref LinkSiguienteEstadistica, ref LinkUltimoEstadistica);
                    HandlePaging(ref dtEstadistica, ref lbPaginaActualVariavleEstadistica);
                    DivPaginacionEstadistica.Visible = true;
                }
            }
            catch (Exception) { }
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
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas )
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

        #region GENERAR REPORTES DE COBROS
        private void GenerarReporteListadoRenovacion(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBD, string NombreReporte)
        {
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
            int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            decimal? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoSupervisor.Text);
            decimal? _Intermediario = string.IsNullOrEmpty(txtFCodIntermediario.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtFCodIntermediario.Text);
            int? ExcluirMotores = cbExclirMotoresMachado.Checked == true ? 2 : 1;

            ReportDocument Reporte = new ReportDocument();
            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@SubRamo", _SubRamo);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Poliza", _Poliza);
            Reporte.SetParameterValue("@CodSupervisor", _Supervisor);
            Reporte.SetParameterValue("@CodIntermediario", _Intermediario);
            Reporte.SetParameterValue("@ExcluirMotores", ExcluirMotores);
            Reporte.SetParameterValue("@Mes", Convert.ToInt32(ddlSeleccionarMes.SelectedValue));
            Reporte.SetParameterValue("@Ano", Convert.ToInt32(txtAno.Text));

            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

            if (rbReportePDFMachado.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbReporteExcelMachado.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
            else if (rbReporteWordMachado.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreReporte);
            }
        }

        #endregion

        #region SACAR INFORMACION DE POLIZA SELECCIONAD
        /// <summary>
        /// Este metodo es para sacar la información del registro seleccionado
        /// </summary>
        /// <param name="Poliza"></param>
        private void SacarInformacionPoliza(string Poliza) {

            var SacarInformacion = ObjDataConsulta.Value.BuscaPolizaGestionCobros(
                Poliza, null);
            foreach (var n in SacarInformacion) {
                txtPolizaGestionCObros.Text = n.Poliza;
                txtEstatusGestionCobros.Text = n.Estatus;
                txtRamoGestionCobros.Text = n.Ramo;
                txtClienteGestionCobros.Text = n.NombreCliente;
                txtTelefonosGestonCobros.Text = n.Telefonos;
                txtDireccionGestionCobros.Text = n.Direccion;
                txtSupervisorGEstionCobros.Text = n.Supervisor;
                txtIntermediarioGestionCobro.Text = n.Intermediario;
                txtLicencia.Text = n.LicenciaSeguro;
                txtFechaCreadaGestionCobros.Text = n.FechaCreada;
                txtInicioVigencia.Text = n.InicioVigencia;
                txtFInVigenciaGestionCobros.Text = n.FinVigencia;
                decimal TotalFActurado = (decimal)n.Facturado;
                txtTotalFacturado.Text = TotalFActurado.ToString("N2");
                decimal TotalCobrado = (decimal)n.Cobrado;
                txtTotalCobradoGestionCobros.Text = TotalCobrado.ToString("N2");
                decimal Balance = (decimal)n.Balance;
                txtBalanceGestionCobros.Text = Balance.ToString("N2");
                int TotalFacturas = (int)n.TotalFacturas;
                txtTotalFacturasGestionCobros.Text = TotalFacturas.ToString("N0");
                int TotalRecibos = (int)n.TotalRecibos;
                txtTotalRecibosGestionCobros.Text = TotalRecibos.ToString("N0");
                int TotalReclamaciones = (int)n.TotalReclamaciones;
                txtTotalReclamacionesGestionCobros.Text = TotalReclamaciones.ToString("N0");

                string Ramo = txtRamoGestionCobros.Text;

                if (Ramo == "Vehiculo De Motor") {
                    DivDatoVehiculo.Visible = true;
                    BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
                }
                else {
                    DivDatoVehiculo.Visible = false;
                }
            }
        }
        #endregion

        #region MOSTRAR LOS COMENTARIOS DE LA POLIZA SELECCIONADA
        private void MostrarComentariosPoliza(string POliza) {

            var MostrarCOmentario = ObjDataConsulta.Value.BuscarComentariosAgregadosPoliza(
                new Nullable<decimal>(),
                POliza,
                null, null, null, null);
            if (MostrarCOmentario.Count() < 1) {
                rpGestionCobros.DataSource = null;
                rpGestionCobros.DataBind();
                lbCantidadRegistrosVariable.Text = "0";
            }
            else {
                Paginar(ref rpGestionCobros, MostrarCOmentario, 10, ref lbCantidadPaginaVAriableGestionCobros, ref LinkPrimeroGestionCobros, ref LinkAnteriorGestionCobros, ref LinkSiguienteGestionCobros, ref LinkUltimoGestionCobros);
                HandlePaging(ref dtPaginacionGestionCobros, ref lbPaginaActualVariableGestionCobros);
                int CantidadRegistros = 0;
                foreach (var n in MostrarCOmentario) {
                    CantidadRegistros = (int)n.CantidadRegistros;

                }
                lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
            }
        }
        #endregion

        #region LISTAS DESPLEGABLES PARA LA GESTION DE COBROS
        private void CargarLosEstatusDeLlamada() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatusLLamadaGestionCobros, Objdata.Value.BuscaListas("ESTATUSLLAMADA", null, null));
        }
        private void CargarLosConceptosDeLlamada() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarConceptoGestionCobros, Objdata.Value.BuscaListas("CONCEPTOLLAMADA", ddlSeleccionarEstatusLLamadaGestionCobros.SelectedValue.ToString(), null));
        }
        #endregion

        #region PROCESAR INFORMACION DE LOS COMENTARIOS
        private void ProcesarInformacionComentarios(string Poliza, string FechaFinVigencia, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionComentarioGestionCObros Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionComentarioGestionCObros(
                0,
                lbPolizaSeleccionada.Text,
                txtComentarioGestionCobros.Text,
                (decimal)Session["IdUsuario"],
                DateTime.Now,
                Convert.ToInt32(ddlSeleccionarEstatusLLamadaGestionCobros.SelectedValue),
                Convert.ToInt32(ddlSeleccionarConceptoGestionCobros.SelectedValue),
                lbFinVigenciaSeleccionada.Text,
                0,
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion

        #region MOSTRAR LAS POLIZAS NO CONTACTADAS

        #endregion

        #region BUSCAR LOS DATOS DEL VEHICULO SELECCIONADO
        private void BuscaDatosVehiculos(string Poliza) {

            var BuscarDatos = ObjDataConsulta.Value.BuscaDatosVehiculoGestion(Poliza);
            if (BuscarDatos.Count() < 1) {

                rpDatosVehiculo.DataSource = null;
                rpDatosVehiculo.DataBind();
            }
            else {
                Paginar(ref rpDatosVehiculo, BuscarDatos, 10, ref lbCantidadPaginaTituloDatoVehiculo, ref LinkPrimeroDatoVehiculo, ref LinkAnteriorDatoVehiculo, ref LinkSiguienteDatoVehiculo, ref LinkUltimoDatoVehiculo);
                HandlePaging(ref dtPaginacionDatoVehiculo, ref lbPaginaActualTituloDatoVehiculo);
            }
        }
        #endregion

        private void MostrarInformacionReporteMacjado() {
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
            int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            decimal? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoSupervisor.Text);
            decimal? _Intermediario = string.IsNullOrEmpty(txtFCodIntermediario.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtFCodIntermediario.Text);
            int? ExcluirMotores = cbExclirMotoresMachado.Checked == true ? 2 : 1;


            var Listado = ObjDataReportes.Value.ReporteRenovacionMachado(
                _Ramo,
                _SubRamo,
                _Oficina,
                _Poliza,
                _Supervisor,
                _Intermediario,
                ExcluirMotores,
                Convert.ToInt32(ddlSeleccionarMes.SelectedValue),
                Convert.ToInt32(txtAno.Text));
            Paginar(ref rpListadoRenovacionMachado, Listado, 10, ref lbCantidadPaginaVAriableMachado, ref LinkPrimeroProceso, ref LinkAnteriorProceso, ref LinkSiguienteProceso, ref LinkUltimoProceso);
            HandlePaging(ref dtPaginacionProceso, ref lbPaginaActualVariavle);


        }


        #region PROCESAR LA INFORMACION DE LOS REGISTROS GAURDADOS PARA LA GESTION DE COBROS
        /// <summary>
        /// Este metodo es para procesar la información (Guardar, Modificar y Eliminar) registros para los avisos de gestion de cobros).
        /// </summary>
        /// <param name="NumeroRegistro"></param>
        /// <param name="Poliza"></param>
        /// <param name="Accion"></param>
        private void ProcesarInformacionPolizasAvisoGestionCobros(decimal NumeroRegistro,string Poliza,string Estatus,int EstatusLLamada,int ConceptoLlamada, string Accion) {

            bool _Estatus = false;

            if (Estatus == "PROCESADO") { _Estatus = false; }
            else if (Estatus == "PENDIENTE") { _Estatus = true; }

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionPolizasAvisosGestionCobros Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionPolizasAvisosGestionCobros(
                NumeroRegistro,
                Poliza,
                EstatusLLamada,
                ConceptoLlamada,
                txtComentarioGestionCobros.Text,
                (decimal)Session["IdUsuario"],
                DateTime.Now,
                txtInicioVigencia.Text,
                txtFInVigenciaGestionCobros.Text,
                _Estatus,
                Accion);
            Procesar.ProcesarInformacion();
        }
        private void ProcesarInformacionRegistrosGuardados() {

            //1-VALIDAMOS EL CONCEPTO DE LA LLAMADA PARA SABER SI EL REGISTRO PROCEDE PARA GUARDAR
            UtilidadesAmigos.Logica.Comunes.Validaciones.ValidarConceptoLLamadas Validar = new Logica.Comunes.Validaciones.ValidarConceptoLLamadas(Convert.ToInt32(ddlSeleccionarConceptoGestionCobros.SelectedValue));
            bool AplicaParaGuardar = Validar.ValidarInformacion();

            if (AplicaParaGuardar == true) {

                //2-VALIDAMOS SI EL REGISTRO A REGISTRAR YA ESTA GUARDADO EN EL SISTEMA
                string _Poliza = string.IsNullOrEmpty(txtPolizaGestionCObros.Text.Trim()) ? null : txtPolizaGestionCObros.Text.Trim();
                int EstatusLLamada = ddlSeleccionarEstatusLLamadaGestionCobros.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarEstatusLLamadaGestionCobros.SelectedValue) : 1;
                int ConceptoLlamada = ddlSeleccionarConceptoGestionCobros.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarConceptoGestionCobros.SelectedValue) : 1;
               
                var ValidarPoliza = ObjDataConsulta.Value.BuscaPolizaAvisoGestionCobro(
                    new Nullable<decimal>(),
                    _Poliza,
                    null, null, null, null, null, false);
                if (ValidarPoliza.Count() < 1)
                {
                    

                    ProcesarInformacionPolizasAvisoGestionCobros(0, _Poliza, "PROCESADO", EstatusLLamada,ConceptoLlamada, "DELETE");

                    //PROCESAMOS EL REGISTRO
                    ProcesarInformacionPolizasAvisoGestionCobros(0, _Poliza, "PROCESADO",EstatusLLamada,ConceptoLlamada, "INSERT");
                }
                else {

                    //PROCESAMOS EL REGISTRO
                    ProcesarInformacionPolizasAvisoGestionCobros(0, _Poliza, "PROCESADO",EstatusLLamada,ConceptoLlamada, "INSERT");

                }
            }
        }

        private void MostrarListadoGestionCobros() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsultaGestionCobro.Text.Trim()) ? null : txtPolizaConsultaGestionCobro.Text.Trim();
            bool? _Estatus = false;

            if (rbRegistrosPendientesGestionCobros.Checked == true) { _Estatus = false; }
            else if (rbRegistrosProcesadosGestionCobros.Checked == true) { _Estatus = true; }
            else if (rbTodosLosRegistrosGestionCobros.Checked == true) { _Estatus = new Nullable<bool>(); }

            var MostrarListadoGestionCobros = ObjDataConsulta.Value.BuscaPolizaAvisoGestionCobro(
                new Nullable<decimal>(),
                _Poliza, null, null, null, null, null, _Estatus);
            if (MostrarListadoGestionCobros.Count() < 1) {
                rpPolizasNoContactadas.DataSource = null;
                rpPolizasNoContactadas.DataBind();
            }
            else {
                Paginar(ref rpPolizasNoContactadas, MostrarListadoGestionCobros, 10, ref lbCantidadPaginaVAriablePolizasNoContactadas, ref LinkPrimeraPaginaPolizasNoContactadas, ref LinkAnteriorPolizasNoContactadas, ref LinkSiguientePolizasNoContactadas, ref LinkUltimoPolizasNoContactadas);
                HandlePaging(ref dtPaginacionPolizasNoContactadas, ref lbPaginaActualVariablePolizasNoContactadas);

                decimal CantidadPolizasPendientes = 0, CantidadPolizasProcesadas = 0;

                foreach (var n in MostrarListadoGestionCobros) {
                    CantidadPolizasPendientes = (decimal)n.CantidadRegistrosNoProcesados;
                    CantidadPolizasProcesadas = (decimal)n.CantidadRegistrosProcesados;
                }
                lbCantidadPolizasPendientesVariable.Text = CantidadPolizasPendientes.ToString("N0");
                lbCantidadPolizasProcesadasVariableGestion.Text = CantidadPolizasProcesadas.ToString("N0");
                //MostrarPolizasNoContactadas(CantidadPolizasPendientes, CantidadPolizasProcesadas);
            }
        }
        #endregion

        private void ActualizarEstadistica() {
            var MostrarListadoGestionCobros = ObjDataConsulta.Value.BuscaPolizaAvisoGestionCobro(
                   new Nullable<decimal>(),
                   null, null, null, null, null, null, null);
            int Pendientes = 0, Procesados = 0;
            foreach (var n in MostrarListadoGestionCobros)
            {
                Pendientes = (int)n.CantidadRegistrosNoProcesados;
                Procesados = (int)n.CantidadRegistrosProcesados;
            }
            lbCantidadPolizasPendientesVariable.Text = Pendientes.ToString("N0");
            lbCantidadPolizasProcesadasVariableGestion.Text = Procesados.ToString("N0");
        }

        private void CargarUsuariosGestionCobros() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuarioReporte, Objdata.Value.BuscaListas("USUARIOGESTIONCOBRO", null, null), true);
        }

        private void GenerarReporteGestionCobros() {

            
            string RutaReporte = Server.MapPath("ReporteGestionCobrosFinal.rpt");
            string UsuarioBD = "sa";
            string ClaveBD = "Pa$$W0rd";
            string NombreReporte = "Reporte de Gestion de Cobros";

            string _PolizaFiltro = string.IsNullOrEmpty(txtPolizaReporte.Text.Trim()) ? null : txtPolizaReporte.Text.Trim();
            decimal? _UsuarioCreo = ddlSeleccionarUsuarioReporte.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarUsuarioReporte.SelectedValue) : new Nullable<decimal>();
            DateTime? _FechaDesde = cbNoAgregarRangoFechaReporte.Checked == false ? Convert.ToDateTime(txtFechaDesdeReporte.Text) : new Nullable<DateTime>();
            DateTime? _FechaHasta = cbNoAgregarRangoFechaReporte.Checked == false ? Convert.ToDateTime(txtFechaHastaReporte.Text) : new Nullable<DateTime>();
            decimal IdUsuarioGenera = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
            bool _NollevaRangoFecha = cbNoAgregarRangoFechaReporte.Checked;

            ReportDocument ReporteGestion = new ReportDocument();
            ReporteGestion.Load(RutaReporte);
            ReporteGestion.Refresh();

            ReporteGestion.SetParameterValue("@Poliza", _PolizaFiltro);
            ReporteGestion.SetParameterValue("@IdUsuarioCreo", _UsuarioCreo);
            ReporteGestion.SetParameterValue("@FechaProcesoDesde", _FechaDesde);
            ReporteGestion.SetParameterValue("@FechaProcesoHasta", _FechaHasta);
            ReporteGestion.SetParameterValue("@UsuarioGenera", IdUsuarioGenera);
            ReporteGestion.SetParameterValue("@NOLLevaRangoFecha", _NollevaRangoFecha);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "LISTADO DE RENOVACION";

                divPaginacion.Visible = false;
                DivPaginacionEstadistica.Visible = false;
                CargarRamos();
                CargarSubramos();
                CargarOficina();
                ValidarBalance();
                ExcluirMotores();
                rbEstadisticaSupervisor.Checked = true;
                CargarRamosEstadistica();
                CargarSubramosEstadistica();
                CargarOficinaEstadistica();
                ValidarBalanceEstadistica();
                ExcluirMotoresEstadistica();
                rbTodosLosRegistrosGestionCobros.Checked = true;               
                MostrarListadoGestionCobros();

                decimal IdUsuarioProcesa = (decimal)Session["IdUsuario"];
                cbProcesarRegistros.Visible = false;

                if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.JuanMarcelino) { cbProcesarRegistros.Visible = true; }
                else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.AlfredoPimentel) { cbProcesarRegistros.Visible = true; }
                else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.AdalgisaAlmonte) { cbProcesarRegistros.Visible = true; }
                else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.MiguelBerroa) { cbProcesarRegistros.Visible = true; }
                else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.JessicaPayano) { cbProcesarRegistros.Visible = true; }
                else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.EriksonVeras) { cbProcesarRegistros.Visible = true; }
                else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.DismailisAcosta) { cbProcesarRegistros.Visible = true; }
                else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.IngriHerrera) { cbProcesarRegistros.Visible = true; }
                else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.RiselotRojas) { cbProcesarRegistros.Visible = true; }

                ActualizarEstadistica();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAsta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHAsta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio", "FechaHastaVacio();", true);
                }
            }
            else
            {
                CurrentPage = 0;
                MostrarListadoRenovaciones();
            }
            
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
           
        }


        protected void ddlSeleccionarRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubramos();
            int Ramo = Convert.ToInt32(ddlSeleccionarRamo.SelectedValue);
            if (Ramo == 106)
            {
                lbExcluirMotores.Visible = true;
                ddlExcluirMotorew.Visible = true;
            }
            else
            {
                lbExcluirMotores.Visible = false;
                ddlExcluirMotorew.Visible = false;
            }
        }


        protected void btnConsultarEstadistica_Click(object sender, EventArgs e)
        {
            //CONSULTAMOS LOS REGISTROS
            //VALIDAMOS QUE LOS CAMPOS DE FECHA NO ESTEN VACIOS
            if (string.IsNullOrEmpty(txtFechaDesdeEstadistica.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaEstadistica.Text.Trim()))
            {
                
                if (string.IsNullOrEmpty(txtFechaDesdeEstadistica.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaEstadistica.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio", "FechaHastaVacio();", true);
                }
               // ClientScript.RegisterStartupScript(GetType(), "CamposVaciosEstadistica", "CamposVaciosEstadistica();", true);
            }
            else
            {
                CargarListadoEstadistica();
            }
        }

        protected void btnExportarEstadistica_Click(object sender, EventArgs e)
        {
            try
            {
                //CONSULTAMOS
                //VERIFICAMOS LA CONDICION ESPECIAL
                int Persona = 0;
                int? _Ramo = ddlSeleccionarRamoEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoEstadistica.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubramoEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramoEstadistica.SelectedValue) : new Nullable<int>();
                int? _Oficina = ddlSeleccionaroficinaEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaEstadistica.SelectedValue) : new Nullable<int>();
                int? _ValidarBalance = ddlValidarBalanceEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlValidarBalanceEstadistica.SelectedValue) : new Nullable<int>();
                int? _ExcluirMotores = ddlExcluirMotoresEstadistica.SelectedValue != "-1" ? Convert.ToInt32(ddlExcluirMotoresEstadistica.SelectedValue) : new Nullable<int>();

                if (rbEstadisticaSupervisor.Checked == true)
                {
                    Persona = 1;
                }
                else if (rbEstadisticaIntermediario.Checked == true)
                {
                    Persona = 2;
                }
                if (Convert.ToInt32(ddlSeleccionarRamoEstadistica.SelectedValue) == 106 && Convert.ToInt32(ddlExcluirMotoresEstadistica.SelectedValue) == 2)
                {

                    if (rbEstadisticaSupervisor.Checked == true)
                    {
                        var Exportar = (from n in Objdata.Value.SacarEstadisticaRenovacion(
                       Convert.ToDateTime(txtFechaDesdeEstadistica.Text),
                       Convert.ToDateTime(txtFechaHastaEstadistica.Text),
                       _Ramo,
                       _SubRamo,
                       _Oficina,
                       _ValidarBalance,
                       _ExcluirMotores,
                       Persona)
                                        select new
                                        {
                                            Supervisor = n.Persona,
                                            CantidadPoliza = n.CantidadPoliza,
                                            Monto = n.Monto
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Estadistica por Supervisor", Exportar);
                    }
                    else if (rbEstadisticaIntermediario.Checked == true)
                    {
                        var Exportar = (from n in Objdata.Value.SacarEstadisticaRenovacion(
                       Convert.ToDateTime(txtFechaDesdeEstadistica.Text),
                       Convert.ToDateTime(txtFechaHastaEstadistica.Text),
                       _Ramo,
                       _SubRamo,
                       _Oficina,
                       _ValidarBalance,
                       _ExcluirMotores,
                       Persona)
                                        select new
                                        {
                                            Intermediario = n.Persona,
                                            CantidadPoliza = n.CantidadPoliza,
                                            Monto = n.Monto
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Estadistica por Intermediario", Exportar);
                    }

                }
                else
                {
                    if (rbEstadisticaSupervisor.Checked == true)
                    {
                        var Exportar = (from n in Objdata.Value.SacarEstadisticaRenovacion(
                       Convert.ToDateTime(txtFechaDesdeEstadistica.Text),
                       Convert.ToDateTime(txtFechaHastaEstadistica.Text),
                       _Ramo,
                       _SubRamo,
                       _Oficina,
                       _ValidarBalance,
                       _ExcluirMotores,
                       Persona)
                                        select new
                                        {
                                            Supervisor = n.Persona,
                                            CantidadPoliza = n.CantidadPoliza,
                                            Monto = n.Monto
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Estadistica por Supervisor", Exportar);
                    }
                    else if (rbEstadisticaIntermediario.Checked == true)
                    {
                        var Exportar = (from n in Objdata.Value.SacarEstadisticaRenovacion(
                       Convert.ToDateTime(txtFechaDesdeEstadistica.Text),
                       Convert.ToDateTime(txtFechaHastaEstadistica.Text),
                       _Ramo,
                       _SubRamo,
                       _Oficina,
                       _ValidarBalance,
                       _ExcluirMotores,
                       Persona)
                                        select new
                                        {
                                            Intermediario = n.Persona,
                                            CantidadPoliza = n.CantidadPoliza,
                                            Monto = n.Monto
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Estadistica por Intermediario", Exportar);
                    }
                }
            }
            catch (Exception) { }
        }

        protected void ddlSeleccionarRamoEstadistica_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubramosEstadistica();
            if (Convert.ToInt32(ddlSeleccionarRamoEstadistica.SelectedValue) == 106)
            {
                lbExcluirMotoresEstadistica.Visible = true;
                ddlExcluirMotoresEstadistica.Visible = true;
            }
            else {
                lbExcluirMotoresEstadistica.Visible = false;
                ddlExcluirMotoresEstadistica.Visible = false;
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "OpcionEnDesarrollo", "OpcionEnDesarrollo();", true);
        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoRenovaciones();
        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoRenovaciones();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior,ref lbPaginaActualVariavle, ref lbCantidadPaginaVAriable);
        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoRenovaciones();
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoRenovaciones();
        }

        protected void linkPrimerostadistica_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            CargarListadoEstadistica();
        }

        protected void LinkAnteirorEstadistica_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            CargarListadoEstadistica();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleEstadistica, ref lbCantidadPaginaVAriableEstadistica);
        }

        protected void dtEstadistica_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            CargarListadoEstadistica();
        }

        protected void dtEstadistica_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void LinkSiguienteEstadistica_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            CargarListadoEstadistica();
        }

        protected void LinkUltimoEstadistica_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            CargarListadoEstadistica();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleEstadistica, ref lbCantidadPaginaVAriableEstadistica);
        }

        protected void cbProcesarRegistros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProcesarRegistros.Checked == true) {
                DivBloqueConsultaNormal.Visible = false;
                DivBloqueProcesarRegistros.Visible = true;
                DivMes.Visible = true;
                DivAno.Visible = true;
                CargarMesesAño();
                rbReportePDFMachado.Checked = true;
            }
            else if (cbProcesarRegistros.Checked == false) {
                DivBloqueConsultaNormal.Visible = true;
                DivBloqueProcesarRegistros.Visible = false;
                DivMes.Visible = false;
                DivAno.Visible = false;
            }
            MostrarListadoGestionCobros();
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAsta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHAsta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio()", "FechaHastaVacio();", true);
                }
            }
            else {

                //1-BUSCAMOS TODA LA INFORMACION MEDIANTE LOS FILTROS INGRESADOS
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                int? _oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
                string _CodigoIntermediario = string.IsNullOrEmpty(txtFCodIntermediario.Text.Trim()) ? null : txtFCodIntermediario.Text.Trim();
                int? _ValidarBalance = ddlValidarBalance.SelectedValue != "-1" ? Convert.ToInt32(ddlValidarBalance.SelectedValue) : new Nullable<int>();

                var BuscarInformacion = Objdata.Value.ReporteRenovacionPoliza(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHAsta.Text),
                    _Ramo,
                    _SubRamo,
                    _Poliza,
                    null,
                    _oficina,
                    _CodigoSupervisor,
                    _CodigoIntermediario,
                    _ValidarBalance,
                    1);
                if (BuscarInformacion.Count() < 1) { }
                else
                {
                    //VALIDAMOS LA INFORMACION
                    decimal __CodigoIntermediario = 0;
                    decimal __CodigoSupervisor = 0;
                    string __Poliza = "";
                    int __Ramo = 0;
                    int __SubRamo = 0;
                    DateTime __InicioVigencia = DateTime.Now;
                    DateTime __FinVigencia = DateTime.Now;


                    foreach (var n in BuscarInformacion) {
                        __CodigoIntermediario = (decimal)n.CodIntermediario;
                        __CodigoSupervisor = (decimal)n.CodSupervisor;
                        __Poliza = n.Poliza;
                        __Ramo = (int)n.CodRamo;
                        __SubRamo = (int)n.CodSubramo;
                        __InicioVigencia = (DateTime)n.FechaInicioVigencia0;
                        __FinVigencia = (DateTime)n.FechaFinVigencia0;
                        int ResultadoValidacion = 0;
                        UtilidadesAmigos.Logica.Comunes.ValidarPolizasARenovar ValidacionPolizasRenovar = new Logica.Comunes.ValidarPolizasARenovar(
                            __CodigoIntermediario,
                            __CodigoSupervisor,
                            __Poliza,
                            __Ramo,
                            __SubRamo,
                            __InicioVigencia,
                            __FinVigencia,
                            Convert.ToInt32(ddlSeleccionarMes.SelectedValue),
                            Convert.ToInt32(txtAno.Text));
                        ResultadoValidacion = ValidacionPolizasRenovar.ValidacionPolizasRenovar();
                        switch (ResultadoValidacion) {
                            case 0:
                                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionPolizasARenovar Guardar = new Logica.Comunes.Reportes.ProcesarInformacionPolizasARenovar(
                                 __CodigoIntermediario,
                                 __CodigoSupervisor,
                                 __Poliza,
                                 __Ramo,
                                 __SubRamo,
                                 (decimal)n.Prima,
                                 __InicioVigencia,
                                 __FinVigencia,
                                 Convert.ToInt32(ddlSeleccionarMes.SelectedValue),
                                 Convert.ToInt32(txtAno.Text),
                                 (decimal)n.Facturado,
                                 (decimal)n.Cobrado,
                                 (decimal)n.Balance,
                                 Convert.ToDateTime(txtFechaDesde.Text),
                                 Convert.ToDateTime(txtFechaHAsta.Text),
                                 "INSERT");
                                Guardar.ProcesarInformacion();
                                break;
                        }
                      
                    }
                    MostrarInformacionReporteMacjado();
                    ClientScript.RegisterStartupScript(GetType(), "RegistrosPolizasARenovar()", "RegistrosPolizasARenovar();", true);
                }
               
            }

         
        }

        protected void btnConsultarRegistrosProcesados_Click(object sender, EventArgs e)
        {
            MostrarInformacionReporteMacjado();
        }

        protected void btnReporteRegistrosProcesados_Click(object sender, EventArgs e)
        {

            GenerarReporteListadoRenovacion((decimal)Session["IdUsuario"], Server.MapPath("ReporteRenovacionMachadoPorSupervisor.rpt"), "sa", "Pa$$W0rd", "Listado de Renovacion Machado Supervisor");
        }

        protected void LinkPrimeroProceso_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarInformacionReporteMacjado();
        }

        protected void LinkAnteriorProceso_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarInformacionReporteMacjado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleMachado, ref lbCantidadPaginaVAriableMachado);
        }

        protected void dtPaginacionProceso_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionProceso_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarInformacionReporteMacjado();
        }

        protected void LinkSiguienteProceso_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarInformacionReporteMacjado();
        }

        protected void LinkUltimoProceso_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInformacionReporteMacjado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleMachado, ref lbCantidadPaginaVAriableMachado);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //MostrarInformacionReporteMacjado();
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAsta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHAsta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio()", "FechaHastaVacio();", true);
                }
            }
            else
            {

                var BuscarInformacion = ObjDataReportes.Value.BuscaPolizasRenovadas(
                    null,
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHAsta.Text));

                decimal IdIntermediario = 0;
                decimal IdSupervisor = 0;
                string Poliza = "";
                int Ramo = 0;
                int SubRamo = 0;

                foreach (var n in BuscarInformacion)
                {
                    IdIntermediario = (decimal)n.CodigoIntermediario;
                    IdSupervisor = (decimal)n.CodigoSupervisor;
                    Poliza = n.Poliza;
                    Ramo = (int)n.Ramo;
                    SubRamo = (int)n.SubRamo;
                    int CantidadRegistros = 1;
                    string AccionTomar = "";

                    var ValidarInformacion = ObjDataReportes.Value.ValidarPolizasRenovadas(
                        IdIntermediario,
                        IdSupervisor,
                        Poliza,
                        Ramo,
                        SubRamo);
                    foreach (var nn in ValidarInformacion)
                    {
                        CantidadRegistros = (int)nn.CantidadRegistros;
                    }
                    if (CantidadRegistros == 0)
                    {
                        //GUARDAMOS
                        AccionTomar = "INSERT";
                    }
                    else if (CantidadRegistros != 0)
                    {
                        //MODIFICAMOS
                        AccionTomar = "UPDATE";
                    }

                    //PROCESAMOS LA INFORMACION
                    UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionPolizasRenovadas Procesar = new Logica.Comunes.Reportes.ProcesarInformacionPolizasRenovadas(
                        IdIntermediario,
                        IdSupervisor,
                        Poliza,
                        Ramo,
                        SubRamo,
                        (decimal)n.Prima,
                        (DateTime)n.FechaInicioVigencia,
                        (DateTime)n.FechaFinVigencia,
                        (DateTime)n.Fecha,
                        (int)n.Mes,
                        (int)n.Ano,
                        (decimal)n.Cobrado,
                        (decimal)n.FacturadoTotal,
                        (decimal)n.CobradoTotal,
                        (decimal)n.BalanceTotal,
                        AccionTomar);
                    Procesar.ProcesarInformacion();
                }

                MostrarInformacionReporteMacjado();
                ClientScript.RegisterStartupScript(GetType(), "RegistrsPolizasRenovadas()", "RegistrsPolizasRenovadas();", true);
            }
        }

        protected void btnEliminarRegistrosMAchados_Click(object sender, EventArgs e)
        {
            //ELIMINAR REGISTROS DE LAS POLIZAS A RENOVAR
            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionPolizasARenovar EliminarPolizasARenovar = new Logica.Comunes.Reportes.ProcesarInformacionPolizasARenovar(
                0, 0, "", 0, 0, 0, DateTime.Now, DateTime.Now, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
            EliminarPolizasARenovar.ProcesarInformacion();

            //ELIMINAR REGISTROS DE LAS POLIZAS RENOVADAS
            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionPolizasRenovadas EliminarPolizasRenovadas = new Logica.Comunes.Reportes.ProcesarInformacionPolizasRenovadas(
                0, 0, "", 0, 0, 0, DateTime.Now, DateTime.Now, DateTime.Now, 0, 0, 0, 0, 0, 0, "DELETE");
            EliminarPolizasRenovadas.ProcesarInformacion();

            MostrarInformacionReporteMacjado();
            ClientScript.RegisterStartupScript(GetType(), "RegistrosEliminados()", "RegistrosEliminados();", true);
        }

        protected void btnGestion_Click(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarEstatusLLamadaGestionCobros_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLosConceptosDeLlamada();
        }

        protected void LinkPrimeroGestionCobros_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
        }

        protected void LinkAnteriorGestionCobros_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableGestionCobros, ref lbCantidadPaginaVAriableGestionCobros);
        }

        protected void dtPaginacionGestionCobros_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionGestionCobros_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
        }

        protected void LinkSiguienteGestionCobros_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
        }

        protected void LinkUltimoGestionCobros_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableGestionCobros, ref lbCantidadPaginaVAriableGestionCobros);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnGestionarPolizasNoContactadas_Click(object sender, EventArgs e)
        {
           

        }

        protected void LinkPrimeraPaginaPolizasNoContactadas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoGestionCobros();
        }

        protected void LinkAnteriorPolizasNoContactadas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoGestionCobros();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariablePolizasNoContactadas, ref lbCantidadPaginaVAriablePolizasNoContactadas);
        }

        protected void dtPaginacionPolizasNoContactadas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionPolizasNoContactadas_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoGestionCobros();
        }

        protected void LinkSiguientePolizasNoContactadas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoGestionCobros();
        }

        protected void LinkUltimoPolizasNoContactadas_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoGestionCobros();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariablePolizasNoContactadas, ref lbCantidadPaginaVAriablePolizasNoContactadas);
        }

        protected void btnBuscarPolizaGestionCobros_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnActualizarEstadistica_Click(object sender, ImageClickEventArgs e)
        {
            ActualizarEstadistica();
        }

        protected void btnBuscarPolizaGestionCobrosNuevo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoGestionCobros();
        }

        protected void btnConsultarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAsta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHAsta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio", "FechaHastaVacio();", true);
                }
            }
            else
            {
                CurrentPage = 0;
                MostrarListadoRenovaciones();
            }
        }

        protected void btnExportarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int RamoSeleccionado = Convert.ToInt32(ddlSeleccionarRamo.SelectedValue);
                int Excluir = Convert.ToInt32(ddlExcluirMotorew.SelectedValue);

                if (RamoSeleccionado == 106 && Excluir == 2)
                {

                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Subramo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _ValidarBalance = ddlValidarBalance.SelectedValue != "-1" ? Convert.ToInt32(ddlValidarBalance.SelectedValue) : new Nullable<int>();
                    string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                    string _CodSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
                    string _CodIntermediario = string.IsNullOrEmpty(txtFCodIntermediario.Text.Trim()) ? null : txtFCodIntermediario.Text.Trim();

                    var Exportar = (from n in Objdata.Value.ReporteRenovacionPoliza(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHAsta.Text),
                        _Ramo,
                        _Subramo,
                        _Poliza,
                        null,
                        _Oficina,
                        _CodSupervisor,
                        _CodIntermediario,
                        _ValidarBalance,
                        2)
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Cotizacion = n.Cotizacion,
                                        Estatus = n.Estatus,
                                        Prima = n.Prima,
                                        SumaAsegurada = n.SumaAsegurada,
                                        Ramo = n.Ramo,
                                        SubRamo = n.SubRamo,
                                        Asegurado = n.Asegurado,
                                        TelefonoResidencia = n.TelefonoResidencia,
                                        Celular = n.Celular,
                                        TelefonoOficina = n.TelefonoOficina,
                                        Items = n.Items,
                                        FechaInicioVigencia = n.FechaInicioVigencia,
                                        FechaFinVigencia = n.FechaFinVigencia,
                                        Supervisor = n.Supervisor,
                                        Intermediario = n.Intermediario,
                                        TipoVehiculo = n.TipoVehiculo,
                                        Marca = n.Marca,
                                        Modelo = n.Modelo,
                                        Capacidad = n.Capacidad,
                                        Ano = n.Ano,
                                        Color = n.Color,
                                        Chasis = n.Chasis,
                                        Placa = n.Placa,
                                        Uso = n.Uso,
                                        ValorVehiculo = n.ValorVehiculo,
                                        NombreAsegurado = n.NombreAsegurado,
                                        Fianza = n.Fianza,
                                        Oficina = n.Oficina,
                                        Facturado = n.Facturado,
                                        Cobrado = n.Cobrado,
                                        Balance = n.Balance
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Renovacion", Exportar);
                }
                else
                {

                    int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                    int? _Subramo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                    int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                    int? _ValidarBalance = ddlValidarBalance.SelectedValue != "-1" ? Convert.ToInt32(ddlValidarBalance.SelectedValue) : new Nullable<int>();
                    string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                    string _CodSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
                    string _CodIntermediario = string.IsNullOrEmpty(txtFCodIntermediario.Text.Trim()) ? null : txtFCodIntermediario.Text.Trim();

                    var Exportar = (from n in Objdata.Value.ReporteRenovacionPoliza(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHAsta.Text),
                        _Ramo,
                        _Subramo,
                        _Poliza,
                        null,
                        _Oficina,
                        _CodSupervisor,
                        _CodIntermediario,
                        _ValidarBalance,
                        1)
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Cotizacion = n.Cotizacion,
                                        Estatus = n.Estatus,
                                        Prima = n.Prima,
                                        SumaAsegurada = n.SumaAsegurada,
                                        Ramo = n.Ramo,
                                        SubRamo = n.SubRamo,
                                        Asegurado = n.Asegurado,
                                        TelefonoResidencia = n.TelefonoResidencia,
                                        Celular = n.Celular,
                                        TelefonoOficina = n.TelefonoOficina,
                                        Items = n.Items,
                                        FechaInicioVigencia = n.FechaInicioVigencia,
                                        FechaFinVigencia = n.FechaFinVigencia,
                                        Supervisor = n.Supervisor,
                                        Intermediario = n.Intermediario,
                                        TipoVehiculo = n.TipoVehiculo,
                                        Marca = n.Marca,
                                        Modelo = n.Modelo,
                                        Capacidad = n.Capacidad,
                                        Ano = n.Ano,
                                        Color = n.Color,
                                        Chasis = n.Chasis,
                                        Placa = n.Placa,
                                        Uso = n.Uso,
                                        ValorVehiculo = n.ValorVehiculo,
                                        NombreAsegurado = n.NombreAsegurado,
                                        Fianza = n.Fianza,
                                        Oficina = n.Oficina,
                                        Facturado = n.Facturado,
                                        Cobrado = n.Cobrado,
                                        Balance = n.Balance
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Renovacion", Exportar);
                }
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }

        protected void btnGestionNuevo_Click(object sender, ImageClickEventArgs e)
        {



            var PolizaSeleccionadaGestionCobros = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPolizaSeleccionadaGestionCobros = ((HiddenField)PolizaSeleccionadaGestionCobros.FindControl("hfPolizaGestionCobros")).Value.ToString();

            var FechaFinVigenciaSeleccionadaGestionCobros = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfFechaFinVigenciaSeleccionadaGestionCObros = ((HiddenField)FechaFinVigenciaSeleccionadaGestionCobros.FindControl("hfFechaFinVigenciaGestionCobros")).Value.ToString();

            lbPolizaSeleccionada.Text = hfPolizaSeleccionadaGestionCobros;
            lbFinVigenciaSeleccionada.Text = hfFechaFinVigenciaSeleccionadaGestionCObros;

            SacarInformacionPoliza(hfPolizaSeleccionadaGestionCobros);
            CurrentPage = 0;
            MostrarComentariosPoliza(hfPolizaSeleccionadaGestionCobros);



            var ValidarComentarioPoliza = ObjDataConsulta.Value.BuscarComentariosAgregadosPoliza(
                new Nullable<decimal>(),
                hfPolizaSeleccionadaGestionCobros,
                null,
                null,
                null,
                hfFechaFinVigenciaSeleccionadaGestionCObros);
            if (ValidarComentarioPoliza.Count() < 1)
            {
                CargarLosEstatusDeLlamada();
                CargarLosConceptosDeLlamada();
            }
            else
            {
                foreach (var n in ValidarComentarioPoliza)
                {
                    CargarLosEstatusDeLlamada();
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarEstatusLLamadaGestionCobros, n.IdEstatusLlamada.ToString());
                    CargarLosConceptosDeLlamada();
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarConceptoGestionCobros, n.IdConceptoLlamada.ToString());
                }
            }
            DivBloquePrincipal.Visible = false;
            DivGestionCobros.Visible = true;
        }

        protected void btnGuardarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            ProcesarInformacionComentarios(
               lbPolizaSeleccionada.Text,
               lbFinVigenciaSeleccionada.Text,
               "INSERT");
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
            ProcesarInformacionRegistrosGuardados();
        }

        protected void btnVolverNuevo_Click(object sender, ImageClickEventArgs e)
        {
            DivGestionCobros.Visible = false;
            DivBloquePrincipal.Visible = true;
        }

        protected void btnGestionarPolizasNoContactadasNuevo_Click(object sender, ImageClickEventArgs e)
        {
            var NumeroRegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfNumeroRegistroSeleccionado = ((HiddenField)NumeroRegistroSeleccionado.FindControl("hfNumeroRegistroGestion")).Value.ToString();

            var PolizaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPolizaSeleccionad = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaGestion")).Value.ToString();

            var EstatusSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfEstatusSeleccionado = ((HiddenField)EstatusSeleccionado.FindControl("hfEstatusGEstion")).Value.ToString();


            //CAMBIAMOS EL ESTATUS DEL REGISTRO
            ProcesarInformacionPolizasAvisoGestionCobros(Convert.ToDecimal(hfNumeroRegistroSeleccionado), hfPolizaSeleccionad, hfEstatusSeleccionado.ToString(), 1, 1, "UPDATE");
            CurrentPage = 0;
            MostrarListadoGestionCobros();
        }

        protected void LinkPrimeroDatoVehiculo_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
        }

        protected void LinkAnteriorDatoVehiculo_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableDatoVehiculo, ref lbCantidadPaginaVAriableDatoVehiculo);
        }

        protected void dtPaginacionDatoVehiculo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionDatoVehiculo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
        }

        protected void LinkSiguienteDatoVehiculo_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
        }

        protected void LinkUltimoDatoVehiculo_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableDatoVehiculo, ref lbCantidadPaginaVAriableDatoVehiculo);
        }

        protected void btnEliminarRegistrosPolizasGestionadas_Click(object sender, ImageClickEventArgs e)
        {
            var NumeroRegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfNumeroRegistroSeleccionado = ((HiddenField)NumeroRegistroSeleccionado.FindControl("hfNumeroRegistroGestion")).Value.ToString();

            var PolizaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaGestion")).Value.ToString();

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionPolizasAvisosGestionCobros Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionPolizasAvisosGestionCobros(
                Convert.ToDecimal(hfNumeroRegistroSeleccionado),
                hfPolizaSeleccionada, 0, 0, "", 0, DateTime.Now, "", "", false, "DELETE");
            Eliminar.ProcesarInformacion();
            MostrarListadoGestionCobros();
        }

        protected void btnReportePolizasGestionCobros_Click(object sender, ImageClickEventArgs e)
        {
            bool? _Estatus = false;
            if (rbTodosLosRegistrosGestionCobros.Checked == true) { _Estatus = new Nullable<bool>(); }
            else if (rbRegistrosProcesadosGestionCobros.Checked == true) { _Estatus = true; }
            else if (rbRegistrosPendientesGestionCobros.Checked == true) { _Estatus = false; }
            else { _Estatus = new Nullable<bool>(); }

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsultaGestionCobro.Text.Trim()) ? null : txtPolizaConsultaGestionCobro.Text.Trim();
            decimal? _IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;

            ReportDocument ReporteGestion = new ReportDocument();
            ReporteGestion.Load(Server.MapPath("ReportePolizasAvisoGestionCobros.rpt"));
            ReporteGestion.Refresh();

            ReporteGestion.SetParameterValue("@Estatus", _Estatus);
            ReporteGestion.SetParameterValue("@Poliza", _Poliza);
            ReporteGestion.SetParameterValue("@UsuarioGenera", _IdUsuario);

            ReporteGestion.SetDatabaseLogon("sa", "Pa$$W0rd");

            ReporteGestion.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Reporte Polizas Aviso Gestion");
        }

        protected void cbGenerarReporteGestionCobros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGenerarReporteGestionCobros.Checked == true) {
                DivReporteGestionCobros.Visible = true;
                CargarUsuariosGestionCobros();
                txtPolizaReporte.Text = string.Empty;
                txtFechaDesdeReporte.Text = string.Empty;
                txtFechaHastaReporte.Text = string.Empty;
                rbFormatoPDFGestion.Checked = true;
            }
            else {
                DivReporteGestionCobros.Visible = false;
            }
        }

        protected void btnReporteGestionCobros_Click(object sender, ImageClickEventArgs e)
        {
            if (cbNoAgregarRangoFechaReporte.Checked == true) { }
            else {

                if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CamposFechaReporteVacios()", "CamposFechaReporteVacios();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaDesdeReporteVacio()", "FechaDesdeReporteVacio();", true); }
                    if (string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaHastaReportevacio()", "FechaHastaReportevacio();", true); }
                }
                else { }
            }
        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoRenovaciones();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVAriable);
        }
    }
}
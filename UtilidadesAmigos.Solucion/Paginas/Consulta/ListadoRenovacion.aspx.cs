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


        enum ConceptosDeLlamada
        {
            Cliente_va_a_Renovar = 7,
            Cliente_no_va_a_Renovar = 8,
            Llamar_mas_tarde = 9,
            Cliente_ya_realizo_el_pago = 10,
            Cliente_Vendio_El_Vehiculo = 11,
            El_Cliente_ya_Renovo_su_Poliza = 12,
            Cliente_Quiere_Cancelar_Su_Poliza = 13,
            Cancelar_Poliza_por_cambio_de_compañia = 14,
            Cliente_no_puede_recibir_llamada, _llamar_mas_tarde = 15
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
                    Paginar_ListadoGeneral(ref rpListadoRenovacion, Buscar, 10, ref lbCantidadPaginaVAriable, ref btnPrimeraPaginaListadoGeneral, ref btnPaginaAnteriorListadoGeneral, ref btnPaginaSiguienteListadoGeneral, ref btnUltimaPaginaListadoGeneral);
                    HandlePaging_ListadoGeneral(ref dtPaginacion, ref lbPaginaActualVariavle);
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
                    Paginar_ListadoGeneral(ref rpListadoRenovacion, Buscar, 10, ref lbCantidadPaginaVAriable, ref btnPrimeraPaginaListadoGeneral, ref btnPaginaAnteriorListadoGeneral, ref btnPaginaSiguienteListadoGeneral, ref btnUltimaPaginaListadoGeneral);
                    HandlePaging_ListadoGeneral(ref dtPaginacion, ref lbPaginaActualVariavle);
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
                    //var BuscarRegistros = Objdata.Value.SacarEstadisticaRenovacion(
                    //    Convert.ToDateTime(txtFechaDesdeEstadistica.Text),
                    //    Convert.ToDateTime(txtFechaHastaEstadistica.Text),
                    //    _Ramo,
                    //    _SubRamo,
                    //    _Oficina,
                    //    _ValidarBalance,
                    //    _ExcluirMotores,
                    //    Persona);
                    //Paginar(ref rpListadoEstadistica, BuscarRegistros, 10, ref lbCantidadPaginaVAriableEstadistica, ref linkPrimerostadistica, ref LinkAnteirorEstadistica, ref LinkSiguienteEstadistica, ref LinkUltimoEstadistica);
                    //HandlePaging(ref dtEstadistica, ref lbPaginaActualVariavleEstadistica);
                    //DivPaginacionEstadistica.Visible = true;
                }
                else
                {
                    //var BuscarRegistros = Objdata.Value.SacarEstadisticaRenovacion(
                    //   Convert.ToDateTime(txtFechaDesdeEstadistica.Text),
                    //   Convert.ToDateTime(txtFechaHastaEstadistica.Text),
                    //   _Ramo,
                    //   _SubRamo,
                    //   _Oficina,
                    //   _ValidarBalance,
                    //   _ExcluirMotores,
                    //   Persona);
                    //Paginar(ref rpListadoEstadistica, BuscarRegistros, 10, ref lbCantidadPaginaVAriableEstadistica, ref linkPrimerostadistica, ref LinkAnteirorEstadistica, ref LinkSiguienteEstadistica, ref LinkUltimoEstadistica);
                    //HandlePaging(ref dtEstadistica, ref lbPaginaActualVariavleEstadistica);
                    //DivPaginacionEstadistica.Visible = true;
                }
            }
            catch (Exception) { }
        }
        #endregion
        #region CONTROL DE PAGINACION DE LAS POLIZAS NO CONTACTADAS
        readonly PagedDataSource pagedDataSource_PolizasNoContactadas = new PagedDataSource();
        int _PrimeraPagina_PolizasNoContactadas, _UltimaPagina_PolizasNoContactadas;
        private int _TamanioPagina_PolizasNoContactadas = 10;
        private int CurrentPage_PolizasNoContactadas
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

        private void HandlePaging_PolizasNoContactadas(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_PolizasNoContactadas = CurrentPage_PolizasNoContactadas - 5;
            if (CurrentPage_PolizasNoContactadas > 5)
                _UltimaPagina_PolizasNoContactadas = CurrentPage_PolizasNoContactadas + 5;
            else
                _UltimaPagina_PolizasNoContactadas = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_PolizasNoContactadas > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_PolizasNoContactadas = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_PolizasNoContactadas = _UltimaPagina_PolizasNoContactadas - 10;
            }

            if (_PrimeraPagina_PolizasNoContactadas < 0)
                _PrimeraPagina_PolizasNoContactadas = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_PolizasNoContactadas;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_PolizasNoContactadas; i < _UltimaPagina_PolizasNoContactadas; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_NoContactadas(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_PolizasNoContactadas.DataSource = Listado;
            pagedDataSource_PolizasNoContactadas.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_PolizasNoContactadas.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_PolizasNoContactadas.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_PolizasNoContactadas.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_PolizasNoContactadas : _NumeroRegistros);
            pagedDataSource_PolizasNoContactadas.CurrentPageIndex = CurrentPage_PolizasNoContactadas;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_PolizasNoContactadas.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_PolizasNoContactadas.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_PolizasNoContactadas.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_PolizasNoContactadas.IsLastPage;

            RptGrid.DataSource = pagedDataSource_PolizasNoContactadas;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_PolizasNoContactadas
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_PolizasNoContactadas(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE LISTADO DE RENOVACIONES
        readonly PagedDataSource pagedDataSource_ListadoRenovaciones = new PagedDataSource();
        int _PrimeraPagina_ListadoRenovaciones, _UltimaPagina_ListadoRenovaciones;
        private int _TamanioPagina_ListadoRenovaciones = 10;
        private int CurrentPage_ListadoRenovaciones
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

        private void HandlePaging_ListadoRenovaciones(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ListadoRenovaciones = CurrentPage_ListadoRenovaciones - 5;
            if (CurrentPage_ListadoRenovaciones > 5)
                _UltimaPagina_ListadoRenovaciones = CurrentPage_ListadoRenovaciones + 5;
            else
                _UltimaPagina_ListadoRenovaciones = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ListadoRenovaciones > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ListadoRenovaciones = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ListadoRenovaciones = _UltimaPagina_ListadoRenovaciones - 10;
            }

            if (_PrimeraPagina_ListadoRenovaciones < 0)
                _PrimeraPagina_ListadoRenovaciones = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ListadoRenovaciones;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ListadoRenovaciones; i < _UltimaPagina_ListadoRenovaciones; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ListadoRenovaciones(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ListadoRenovaciones.DataSource = Listado;
            pagedDataSource_ListadoRenovaciones.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ListadoRenovaciones.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ListadoRenovaciones.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ListadoRenovaciones.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ListadoRenovaciones : _NumeroRegistros);
            pagedDataSource_ListadoRenovaciones.CurrentPageIndex = CurrentPage_ListadoRenovaciones;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ListadoRenovaciones.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ListadoRenovaciones.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ListadoRenovaciones.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ListadoRenovaciones.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ListadoRenovaciones;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ListadoRenovaciones
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ListadoRenovaciones(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DEL DETALLE DE LOS VEHICULOS
        readonly PagedDataSource pagedDataSource_DetalleVehiculo = new PagedDataSource();
        int _PrimeraPagina_DetalleVehiculo, _UltimaPagina_DetalleVehiculo;
        private int _TamanioPagina_DetalleVehiculo = 10;
        private int CurrentPage_DetalleVehiculo
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

        private void HandlePaging_DetalleVehiculo(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_DetalleVehiculo = CurrentPage_DetalleVehiculo - 5;
            if (CurrentPage_DetalleVehiculo > 5)
                _UltimaPagina_DetalleVehiculo = CurrentPage_DetalleVehiculo + 5;
            else
                _UltimaPagina_DetalleVehiculo = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_DetalleVehiculo > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_DetalleVehiculo = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_DetalleVehiculo = _UltimaPagina_DetalleVehiculo - 10;
            }

            if (_PrimeraPagina_DetalleVehiculo < 0)
                _PrimeraPagina_DetalleVehiculo = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_DetalleVehiculo;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_DetalleVehiculo; i < _UltimaPagina_DetalleVehiculo; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_DetalleVehiculo(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_DetalleVehiculo.DataSource = Listado;
            pagedDataSource_DetalleVehiculo.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_DetalleVehiculo.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_DetalleVehiculo.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_DetalleVehiculo.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_DetalleVehiculo : _NumeroRegistros);
            pagedDataSource_DetalleVehiculo.CurrentPageIndex = CurrentPage_DetalleVehiculo;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_DetalleVehiculo.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_DetalleVehiculo.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_DetalleVehiculo.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_DetalleVehiculo.IsLastPage;

            RptGrid.DataSource = pagedDataSource_DetalleVehiculo;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_DetalleVehiculo
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_DetalleVehiculo(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE LOS COMENTARIOS
        readonly PagedDataSource pagedDataSource_Comentario = new PagedDataSource();
        int _PrimeraPagina_Comentario, _UltimaPagina_Comentario;
        private int _TamanioPagina_Comentario = 10;
        private int CurrentPage_Comentario
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

        private void HandlePaging_Comentario(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Comentario = CurrentPage_Comentario - 5;
            if (CurrentPage_Comentario > 5)
                _UltimaPagina_Comentario = CurrentPage_Comentario + 5;
            else
                _UltimaPagina_Comentario = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Comentario > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Comentario = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Comentario = _UltimaPagina_Comentario - 10;
            }

            if (_PrimeraPagina_Comentario < 0)
                _PrimeraPagina_Comentario = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Comentario;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Comentario; i < _UltimaPagina_Comentario; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Comentario(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Comentario.DataSource = Listado;
            pagedDataSource_Comentario.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Comentario.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Comentario.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Comentario.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Comentario : _NumeroRegistros);
            pagedDataSource_Comentario.CurrentPageIndex = CurrentPage_Comentario;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Comentario.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Comentario.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Comentario.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Comentario.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Comentario;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Comentario
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Comentario(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE LISTADO GENERAL
        readonly PagedDataSource pagedDataSource_ListadoGeneral = new PagedDataSource();
        int _PrimeraPagina_ListadoGeneral, _UltimaPagina_ListadoGeneral;
        private int _TamanioPagina_ListadoGeneral = 10;
        private int CurrentPage_ListadoGeneral
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

        private void HandlePaging_ListadoGeneral(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ListadoGeneral = CurrentPage_ListadoGeneral - 5;
            if (CurrentPage_ListadoGeneral > 5)
                _UltimaPagina_ListadoGeneral = CurrentPage_ListadoGeneral + 5;
            else
                _UltimaPagina_ListadoGeneral = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ListadoGeneral > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ListadoGeneral = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ListadoGeneral = _UltimaPagina_ListadoGeneral - 10;
            }

            if (_PrimeraPagina_ListadoGeneral < 0)
                _PrimeraPagina_ListadoGeneral = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ListadoGeneral;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ListadoGeneral; i < _UltimaPagina_ListadoGeneral; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ListadoGeneral(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ListadoGeneral.DataSource = Listado;
            pagedDataSource_ListadoGeneral.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ListadoGeneral.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ListadoGeneral.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ListadoGeneral.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ListadoGeneral : _NumeroRegistros);
            pagedDataSource_ListadoGeneral.CurrentPageIndex = CurrentPage_ListadoGeneral;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ListadoGeneral.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ListadoGeneral.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ListadoGeneral.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ListadoGeneral.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ListadoGeneral;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ListadoGeneral
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ListadoGeneral(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE DETALLE GENERALES DE LA POLIZA SELECCIONADA
        readonly PagedDataSource pagedDataSource_DetalleGeneralesPolizaSeleccionada = new PagedDataSource();
        int _PrimeraPagina_DetalleGeneralesPolizaSeleccionada, _UltimaPagina_DetalleGeneralesPolizaSeleccionada;
        private int _TamanioPagina_DetalleGeneralesPolizaSeleccionada = 10;
        private int CurrentPage_DetalleGeneralesPolizaSeleccionada
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

        private void HandlePaging_DetalleGeneralesPolizaSeleccionada(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_DetalleGeneralesPolizaSeleccionada = CurrentPage_DetalleGeneralesPolizaSeleccionada - 5;
            if (CurrentPage_DetalleGeneralesPolizaSeleccionada > 5)
                _UltimaPagina_DetalleGeneralesPolizaSeleccionada = CurrentPage_DetalleGeneralesPolizaSeleccionada + 5;
            else
                _UltimaPagina_DetalleGeneralesPolizaSeleccionada = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_DetalleGeneralesPolizaSeleccionada > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_DetalleGeneralesPolizaSeleccionada = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_DetalleGeneralesPolizaSeleccionada = _UltimaPagina_DetalleGeneralesPolizaSeleccionada - 10;
            }

            if (_PrimeraPagina_DetalleGeneralesPolizaSeleccionada < 0)
                _PrimeraPagina_DetalleGeneralesPolizaSeleccionada = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_DetalleGeneralesPolizaSeleccionada;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_DetalleGeneralesPolizaSeleccionada; i < _UltimaPagina_DetalleGeneralesPolizaSeleccionada; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_DetalleGeneralesPolizaSeleccionada(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_DetalleGeneralesPolizaSeleccionada.DataSource = Listado;
            pagedDataSource_DetalleGeneralesPolizaSeleccionada.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_DetalleGeneralesPolizaSeleccionada.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_DetalleGeneralesPolizaSeleccionada.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_DetalleGeneralesPolizaSeleccionada.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_DetalleGeneralesPolizaSeleccionada : _NumeroRegistros);
            pagedDataSource_DetalleGeneralesPolizaSeleccionada.CurrentPageIndex = CurrentPage_DetalleGeneralesPolizaSeleccionada;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_DetalleGeneralesPolizaSeleccionada.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_DetalleGeneralesPolizaSeleccionada.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_DetalleGeneralesPolizaSeleccionada.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_DetalleGeneralesPolizaSeleccionada.IsLastPage;

            RptGrid.DataSource = pagedDataSource_DetalleGeneralesPolizaSeleccionada;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_DetalleGeneralesPolizaSeleccionada
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_DetalleGeneralesPolizaSeleccionada(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DE COMENTARIO DE POLIZA
        readonly PagedDataSource pagedDataSource_ComentarioPoliza = new PagedDataSource();
        int _PrimeraPagina_ComentarioPoliza, _UltimaPagina_ComentarioPoliza;
        private int _TamanioPagina_ComentarioPoliza = 10;
        private int CurrentPage_ComentarioPoliza
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

        private void HandlePaging_ComentarioPoliza(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ComentarioPoliza = CurrentPage_ComentarioPoliza - 5;
            if (CurrentPage_ComentarioPoliza > 5)
                _UltimaPagina_ComentarioPoliza = CurrentPage_ComentarioPoliza + 5;
            else
                _UltimaPagina_ComentarioPoliza = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ComentarioPoliza > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ComentarioPoliza = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ComentarioPoliza = _UltimaPagina_ComentarioPoliza - 10;
            }

            if (_PrimeraPagina_ComentarioPoliza < 0)
                _PrimeraPagina_ComentarioPoliza = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ComentarioPoliza;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ComentarioPoliza; i < _UltimaPagina_ComentarioPoliza; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ComentarioPoliza(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ComentarioPoliza.DataSource = Listado;
            pagedDataSource_ComentarioPoliza.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ComentarioPoliza.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ComentarioPoliza.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ComentarioPoliza.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ComentarioPoliza : _NumeroRegistros);
            pagedDataSource_ComentarioPoliza.CurrentPageIndex = CurrentPage_ComentarioPoliza;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ComentarioPoliza.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ComentarioPoliza.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ComentarioPoliza.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ComentarioPoliza.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ComentarioPoliza;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ComentarioPoliza
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ComentarioPoliza(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

            Reporte.Close();
            Reporte.Dispose();
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
                Paginar_Comentario(ref rpGestionCobros, MostrarCOmentario, 10, ref lbCantidadPaginaVAriableGestionCobros, ref btnPrimeraPaginaComentarios, ref btnPaginaAnteriorComentarios, ref btnPaginaSiguienteComentarios, ref btnUltimaPaginaComentarios);
                HandlePaging_Comentario(ref dtPaginacionGestionCobros, ref lbPaginaActualVariableGestionCobros);
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

            try {
                DateTime? FechaNuevaLLamada = string.IsNullOrEmpty(txtFechaNuevaLLamada.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaNuevaLLamada.Text);

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
                    FechaNuevaLLamada,
                    txtHoraNuevaLLamada.Text,
                    Accion);
                Procesar.ProcesarInformacion();
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorProcesarComentrio()", "ErrorProcesarComentrio();", true);
            }
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
                Paginar_DetalleVehiculo(ref rpDatosVehiculo, BuscarDatos, 10, ref lbPaginaActualVariableDatoVehiculo, ref btnPrimeraPaginaDatoVehiculo, ref btnPaginaAnteriorDatoVehiculo, ref btnSiguientePaginaDatoVehiculo, ref btnUltimaPaginaDatoVehiculo);
                HandlePaging_DetalleVehiculo(ref dtPaginacionDatoVehiculo, ref lbCantidadPaginaVAriableDatoVehiculo);
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
            Paginar_NoContactadas(ref rpListadoRenovacionMachado, Listado, 10, ref lbCantidadPaginaVAriableMachado, ref btnPrimeraPaginaPolizasNoContactadas, ref btnAnteriorPolizasNoContactadas, ref btnSiguientePolizasNoContactadas, ref btnUltimoPolizasNoContactadas);
          //  HandlePaging_PolizasNoContactadas(ref dtPaginacionProceso, ref lbPaginaActualVariavle);


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

            DateTime? FechaNuevaLlamada = string.IsNullOrEmpty(txtFechaNuevaLLamada.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaNuevaLLamada.Text);

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
                FechaNuevaLlamada,
                txtHoraNuevaLLamada.Text,
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
                Paginar_NoContactadas(ref rpPolizasNoContactadas, MostrarListadoGestionCobros, 10, ref lbCantidadPaginaVAriablePolizasNoContactadas, ref btnPrimeraPaginaPolizasNoContactadas, ref btnAnteriorPolizasNoContactadas, ref btnSiguientePolizasNoContactadas, ref btnUltimoPolizasNoContactadas);
                HandlePaging_PolizasNoContactadas(ref dtPaginacionPolizasNoContactadas, ref lbPaginaActualVariablePolizasNoContactadas);

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

            if (rbFormatoExcelPlanoGestion.Checked == true) {

                var Exportar = (from n in ObjDataConsulta.Value.ReporteGestionCObroPlano(
                    _PolizaFiltro,
                    _UsuarioCreo,
                    _FechaDesde,
                    _FechaHasta,
                    IdUsuarioGenera,
                    _NollevaRangoFecha)
                                select new
                                {
                                    Poliza = n.Poliza,
                                    Comentario = n.Comentario,
                                    CreadoPor = n.CreadoPor,
                                    Fecha = n.Fecha,
                                    Hora = n.Hora,
                                    Estatus = n.EstatusLlamada,
                                    Concepto = n.ConceptoLlamada,
                                    Fin_Vigencia = n.FechaFinVigencia,
                                    Secuencia = n.NumeroSeguimiento,
                                    

                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreReporte, Exportar);
                
            }
            else {
                ReportDocument ReporteGestion = new ReportDocument();
                ReporteGestion.Load(RutaReporte);
                ReporteGestion.Refresh();

                ReporteGestion.SetParameterValue("@Poliza", _PolizaFiltro);
                ReporteGestion.SetParameterValue("@IdUsuarioCreo", _UsuarioCreo);
                ReporteGestion.SetParameterValue("@FechaProcesoDesde", _FechaDesde);
                ReporteGestion.SetParameterValue("@FechaProcesoHasta", _FechaHasta);
                ReporteGestion.SetParameterValue("@UsuarioGenera", IdUsuarioGenera);
                ReporteGestion.SetParameterValue("@NOLLevaRangoFecha", _NollevaRangoFecha);

                ReporteGestion.SetDatabaseLogon(UsuarioBD, ClaveBD);

                if (rbFormatoPDFGestion.Checked == true) { ReporteGestion.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte); }
                else if (rbFormatoExcelGestion.Checked == true) { ReporteGestion.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte); }

                ReporteGestion.Close();
                ReporteGestion.Dispose();
            }

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

                UtilidadesAmigos.Logica.Comunes.Rangofecha FechaMes = new Logica.Comunes.Rangofecha();
                FechaMes.FechaMes(ref txtFechaDesde, ref txtFechaHAsta);
                FechaMes.FechaMes(ref txtFechaDesdeEstadistica, ref txtFechaHastaEstadistica);
                FechaMes.FechaMes(ref txtFechaDesdeReporte, ref txtFechaHastaReporte);
         

                divPaginacion.Visible = false;
            //    DivPaginacionEstadistica.Visible = false;
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
                CurrentPage_PolizasNoContactadas = 0;
                MostrarListadoGestionCobros();

                decimal IdUsuarioProcesa = (decimal)Session["IdUsuario"];
               // cbProcesarRegistros.Visible = false;

                //if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.JuanMarcelino) { cbProcesarRegistros.Visible = true; }
                //else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.AlfredoPimentel) { cbProcesarRegistros.Visible = true; }
                //else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.AdalgisaAlmonte) { cbProcesarRegistros.Visible = true; }
                //else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.MiguelBerroa) { cbProcesarRegistros.Visible = true; }
                //else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.JessicaPayano) { cbProcesarRegistros.Visible = true; }
                //else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.EriksonVeras) { cbProcesarRegistros.Visible = true; }
                //else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.DismailisAcosta) { cbProcesarRegistros.Visible = true; }
                //else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.IngriHerrera) { cbProcesarRegistros.Visible = true; }
                //else if (IdUsuarioProcesa == (decimal)PermisoReporteMachado.RiselotRojas) { cbProcesarRegistros.Visible = true; }

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
                CurrentPage_ListadoGeneral = 0;
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

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ListadoGeneral = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoRenovaciones();
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtEstadistica_ItemDataBound(object sender, DataListItemEventArgs e)
        {

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
            CurrentPage_PolizasNoContactadas = 0;
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
                        //__InicioVigencia = (DateTime)n.FechaInicioVigencia0;
                        //__FinVigencia = (DateTime)n.FechaFinVigencia0;
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



        protected void dtPaginacionProceso_ItemDataBound(object sender, DataListItemEventArgs e)
        {

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

        protected void dtPaginacionGestionCobros_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionGestionCobros_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Comentario = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
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



        protected void dtPaginacionPolizasNoContactadas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionPolizasNoContactadas_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_PolizasNoContactadas = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoGestionCobros();
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
            CurrentPage_PolizasNoContactadas = 0;
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
                CurrentPage_ListadoGeneral = 0;
                MostrarListadoRenovaciones();
            }
        }

        protected void btnExportarNuevo_Click(object sender, ImageClickEventArgs e)
        {

            if (cbExportarDataResumida.Checked == true) {
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

                        

                        var Exportar = (from n in ObjDataConsulta.Value.BuscaListadoRenovacionResumen(
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
                                            Estatus_Llalada=n.EstatusLlamada,
                                            Concepto_Llamada=n.ConceptoLLamada,
                                            Cantidad=n.Cantidad
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

                        var Exportar = (from n in ObjDataConsulta.Value.BuscaListadoRenovacionResumen(
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
                                            Estatus_Llalada = n.EstatusLlamada,
                                            Concepto_Llamada = n.ConceptoLLamada,
                                            Cantidad = n.Cantidad
                                        }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Renovacion", Exportar);
                    }
                }
                catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
            }
            else {
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
                                            Chasis = n.Chasis,
                                            InicioVigencia = n.InicioVigenciaFormateado,
                                            FinVigencia = n.FinVigenciaFormateado,
                                            CantidadReclamaciones = n.CantidadReclamaciones,
                                            UltimaReclamacion = n.UltimaReclamacion,
                                            Fecha_Ultima_Comentario = n.FechaUltimoComentario,
                                            Hora_Ultimo_Comentario = n.HoraUltimoComentario,
                                            Ultimo_Estatus_Llamada = n.UltimoEstatusLlamada,
                                            Ultimo_Concepto_Llamada = n.UltimoConceptollamada,
                                            Ultimo_Comentario = n.UltimoComentario,
                                            UsuarioComento = n.UsuarioComento,
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
                                            Supervisor = n.Supervisor,
                                            Intermediario = n.Intermediario,
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
                                            Chasis = n.Chasis,
                                            InicioVigencia = n.InicioVigenciaFormateado,
                                            FinVigencia = n.FinVigenciaFormateado,
                                            CantidadReclamaciones = n.CantidadReclamaciones,
                                            UltimaReclamacion = n.UltimaReclamacion,
                                            Fecha_Ultima_Comentario = n.FechaUltimoComentario,
                                            Hora_Ultimo_Comentario = n.HoraUltimoComentario,
                                            Ultimo_Estatus_Llamada = n.UltimoEstatusLlamada,
                                            Ultimo_Concepto_Llamada = n.UltimoConceptollamada,
                                            Ultimo_Comentario = n.UltimoComentario,
                                            UsuarioComento = n.UsuarioComento,
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
                                            Supervisor = n.Supervisor,
                                            Intermediario = n.Intermediario,
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
         
        }

        protected void btnGestionNuevo_Click(object sender, ImageClickEventArgs e)
        {
            var PolizaSeleccionadaGestionCobros = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPolizaSeleccionadaGestionCobros = ((HiddenField)PolizaSeleccionadaGestionCobros.FindControl("hfPolizaGestionCobros")).Value.ToString();

            var FechaFinVigenciaSeleccionadaGestionCobros = (RepeaterItem)((ImageButton)sender).NamingContainer;
            //var hfFechaFinVigenciaSeleccionadaGestionCObros = ((HiddenField)FechaFinVigenciaSeleccionadaGestionCobros.FindControl("hfFechaFinVigenciaGestionCobros")).Value.ToString();

            lbPolizaSeleccionada.Text = hfPolizaSeleccionadaGestionCobros;
          //  lbFinVigenciaSeleccionada.Text = hfFechaFinVigenciaSeleccionadaGestionCObros;

            SacarInformacionPoliza(hfPolizaSeleccionadaGestionCobros);
            CurrentPage_Comentario = 0;
            MostrarComentariosPoliza(hfPolizaSeleccionadaGestionCobros);



            var ValidarComentarioPoliza = ObjDataConsulta.Value.BuscarComentariosAgregadosPoliza(
                new Nullable<decimal>(),
                hfPolizaSeleccionadaGestionCobros,
                null,
                null,
                null,
                null);
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


            if (hfEstatusSeleccionado == "PENDIENTE") {
                //CAMBIAMOS EL ESTATUS DEL REGISTRO
                ProcesarInformacionPolizasAvisoGestionCobros(Convert.ToDecimal(hfNumeroRegistroSeleccionado), hfPolizaSeleccionad, hfEstatusSeleccionado.ToString(), 1, 1, "UPDATE");
                CurrentPage_PolizasNoContactadas = 0;
                MostrarListadoGestionCobros();
            }
            else { ClientScript.RegisterStartupScript(GetType(), "CambioEstatus()", "CambioEstatus();", true); }



        }

        protected void dtPaginacionDatoVehiculo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionDatoVehiculo_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_DetalleVehiculo = Convert.ToInt32(e.CommandArgument.ToString());
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
        }

        protected void btnPrimeraPaginaPolizasNoContactadas_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PolizasNoContactadas = 0;
            MostrarListadoGestionCobros();
        }

        protected void btnAnteriorPolizasNoContactadas_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PolizasNoContactadas += -1;
            MostrarListadoGestionCobros();
            MoverValoresPaginacion_PolizasNoContactadas((int)OpcionesPaginacionValores_PolizasNoContactadas.PaginaAnterior, ref lbPaginaActualVariablePolizasNoContactadas, ref lbCantidadPaginaVAriablePolizasNoContactadas);
        }

        protected void btnSiguientePolizasNoContactadas_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PolizasNoContactadas += 1;
            MostrarListadoGestionCobros();
        }

        protected void btnUltimoPolizasNoContactadas_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PolizasNoContactadas = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoGestionCobros();
            MoverValoresPaginacion_PolizasNoContactadas((int)OpcionesPaginacionValores_PolizasNoContactadas.UltimaPagina, ref lbPaginaActualVariablePolizasNoContactadas, ref lbCantidadPaginaVAriablePolizasNoContactadas);
        }

        protected void btnPrimeraPaginaListadoGeneral_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ListadoGeneral = 0;
            MostrarListadoRenovaciones();
        }

        protected void btnPaginaSiguienteListadoGeneral_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ListadoGeneral += 1;
            MostrarListadoRenovaciones();
        }

        protected void btnUltimaPaginaListadoGeneral_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ListadoGeneral = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoRenovaciones();
            MoverValoresPaginacion_ListadoGeneral((int)OpcionesPaginacionValores_ListadoGeneral.UltimaPagina, ref lbPaginaActualVariavle, ref lbCantidadPaginaVAriable);
        }

        protected void btnPrimeraPaginaDatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_DetalleVehiculo = 0;
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);

        }

        protected void btnPaginaAnteriorDatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_DetalleVehiculo += -1;
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
            MoverValoresPaginacion_DetalleVehiculo((int)OpcionesPaginacionValores_DetalleVehiculo.PaginaAnterior, ref lbPaginaActualVariableDatoVehiculo, ref lbCantidadPaginaVAriableDatoVehiculo);

        }

        protected void btnPrimeraPaginaComentarios_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comentario = 0;
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
        }

        protected void btnPaginaAnteriorComentarios_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_Comentario += -1;
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
            MoverValoresPaginacion_Comentario((int)OpcionesPaginacionValores_Comentario.PaginaAnterior, ref lbPaginaActualVariableGestionCobros, ref lbCantidadPaginaVAriableGestionCobros);
        }

        protected void btnPaginaSiguienteComentarios_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comentario += 1;
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
        }

        protected void btnUltimaPaginaComentarios_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comentario = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarComentariosPoliza(lbPolizaSeleccionada.Text);
            MoverValoresPaginacion_Comentario((int)OpcionesPaginacionValores_Comentario.UltimaPagina, ref lbPaginaActualVariableGestionCobros, ref lbCantidadPaginaVAriableGestionCobros);
        }

        protected void btnSiguientePaginaDatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_DetalleVehiculo += 1;
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
        }

        protected void btnUltimaPaginaDatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {


            CurrentPage_DetalleVehiculo = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BuscaDatosVehiculos(txtPolizaGestionCObros.Text);
            MoverValoresPaginacion_DetalleVehiculo((int)OpcionesPaginacionValores_DetalleVehiculo.UltimaPagina, ref lbPaginaActualVariableDatoVehiculo, ref lbCantidadPaginaVAriableDatoVehiculo);
        }

        protected void btnPaginaAnteriorListadoGeneral_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ListadoGeneral += -1;
            MostrarListadoRenovaciones();
            MoverValoresPaginacion_ListadoGeneral((int)OpcionesPaginacionValores_ListadoGeneral.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVAriable);

        }

        protected void btnEliminarRegistrosPolizasGestionadas_Click(object sender, ImageClickEventArgs e)
        {
            var NumeroRegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfNumeroRegistroSeleccionado = ((HiddenField)NumeroRegistroSeleccionado.FindControl("hfNumeroRegistroGestion")).Value.ToString();

            var PolizaSeleccionada = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaGestion")).Value.ToString();

            if (hfPolizaSeleccionada == "PENDIENTE") {
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionPolizasAvisosGestionCobros Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionPolizasAvisosGestionCobros(
                    Convert.ToDecimal(hfNumeroRegistroSeleccionado),
                    hfPolizaSeleccionada, 0, 0, "", 0, DateTime.Now, "", "", false,DateTime.Now,"", "DELETE");
                Eliminar.ProcesarInformacion();
                CurrentPage_PolizasNoContactadas = 0;
                MostrarListadoGestionCobros();
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "EliminarRegistro()", "EliminarRegistro();", true);
            }

            
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

            ReporteGestion.Close();
            ReporteGestion.Dispose();
        }

        protected void cbGenerarReporteGestionCobros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGenerarReporteGestionCobros.Checked == true) {
                DivReporteGestionCobros.Visible = true;
                CargarUsuariosGestionCobros();
                txtPolizaReporte.Text = string.Empty;
                UtilidadesAmigos.Logica.Comunes.Rangofecha FechaMes = new Logica.Comunes.Rangofecha();
                FechaMes.FechaMes(ref txtFechaDesdeReporte, ref txtFechaHastaReporte);

                rbFormatoPDFGestion.Checked = true;
            }
            else {
                DivReporteGestionCobros.Visible = false;
            }
        }

        protected void btnReporteGestionCobros_Click(object sender, ImageClickEventArgs e)
        {
            if (cbNoAgregarRangoFechaReporte.Checked == true) { GenerarReporteGestionCobros(); }
            else {

                if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CamposFechaReporteVacios()", "CamposFechaReporteVacios();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaDesdeReporteVacio()", "FechaDesdeReporteVacio();", true); }
                    if (string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaHastaReportevacio()", "FechaHastaReportevacio();", true); }
                }
                else {
                    GenerarReporteGestionCobros();
                }
            }
        }

        protected void ddlSeleccionarConceptoGestionCobros_SelectedIndexChanged(object sender, EventArgs e)
        {
            int LLamarMasTarde = Convert.ToInt32(ddlSeleccionarConceptoGestionCobros.SelectedValue);

            if (LLamarMasTarde == (int)ConceptosDeLlamada.Llamar_mas_tarde)
            {

                DivFechaLlamada.Visible = true;
                DIVHoraLLamada.Visible = true;
                txtFechaNuevaLLamada.Text = string.Empty;
                txtHoraNuevaLLamada.Text = string.Empty;
            }
            else {
                DivFechaLlamada.Visible = false;
                DIVHoraLLamada.Visible = false;
            }
        }
    }
}
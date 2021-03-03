using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ListadoRenovacion : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

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
                    foreach (var n in Buscar)
                    {
                        lbMesDesde.Text = n.FechaDesde;
                        lbMesHasta.Text = n.FechaHasta;
                        lbDIas.Text = n.Dias.ToString();
                        lbMes.Text = n.Mes.ToString();
                        lbano.Text = n.Anos.ToString();
                    }
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
                    foreach (var n in Buscar)
                    {
                        lbMesDesde.Text = n.FechaDesde;
                        lbMesHasta.Text = n.FechaHasta;
                        lbDIas.Text = n.Dias.ToString();
                        lbMes.Text = n.Mes.ToString();
                        lbano.Text = n.Anos.ToString();
                    }
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
                MostrarListadoRenovaciones();
            }
            
        }

        protected void btnExportar_Click(object sender, EventArgs e)
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

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoRenovaciones();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVAriable);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    gvListadoCoberturas.DataSource = Buscar;
                    gvListadoCoberturas.DataBind();
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
                    gvListadoCoberturas.DataSource = Buscar;
                    gvListadoCoberturas.DataBind();
                }
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamos();
                CargarSubramos();
                CargarOficina();
                ValidarBalance();
                ExcluirMotores();
                rbEstadisticaSupervisor.Checked = true;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoRenovaciones();
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

        protected void gvListadoCoberturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoCoberturas.PageIndex = e.NewPageIndex;
            MostrarListadoRenovaciones();
        }

        protected void gvListadoCoberturas_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void gvListadoEstadistica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvListadoEstadistica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultarEstadistica_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportarEstadistica_Click(object sender, EventArgs e)
        {

        }
    }
}
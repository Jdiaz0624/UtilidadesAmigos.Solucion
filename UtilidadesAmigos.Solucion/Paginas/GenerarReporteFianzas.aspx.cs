using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteFianzas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR LOS SUBRAMOS
        private void CargarSubramo(string Ramo)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubramo, ObjData.Value.BuscaListas("SUBRAMO", Ramo, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubramHistoriclPoliza, ObjData.Value.BuscaListas("SUBRAMO", Ramo, null), true);
        }
        #endregion

        #region MOSTRAR LOS REGISTROS
        private void MostrarRegistros()
        {
            //VALIDAMOS LOS RANGOS DE FECHA
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MensajeConsulta", "MensajeConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeError", "FechaDesdeError();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaError", "FechaHastaError();", true);
                }
            }
            else
            {
                //consultamos
                string _Poliza = string.IsNullOrEmpty(txtpolizaConsulta.Text.Trim()) ? null : txtpolizaConsulta.Text.Trim();
                decimal? _Subramo = ddlSeleccionarSubramo.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSubramo.SelectedValue) : new Nullable<decimal>();

                var Buscar = ObjData.Value.GenerarProduccionFianzas(
                    _Poliza,
                    _Subramo,
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text));
                foreach (var n in Buscar)
                {
                    int Cantidad = Convert.ToInt32(n.Cantidad);
                    lbCantidadRegistros.Text = Cantidad.ToString("N0");
                }
                gvInventario.DataSource = Buscar;
                gvInventario.DataBind();
            }
        }
        #endregion
        #region CONSULTAR HISTORICO
        private void ConsultarHistorico()
        {
            string _poliza = string.IsNullOrEmpty(txtPolizaHistoricoPoliza.Text.Trim()) ? null : txtPolizaHistoricoPoliza.Text.Trim();
            int? _Subramo = ddlSeleccionarSubramHistoriclPoliza.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramHistoriclPoliza.SelectedValue) : new Nullable<int>();

            var Buscar = ObjData.Value.BuscaHistoriclPoliza(
                _poliza,
                _Subramo,
                Convert.ToDateTime(txtFechaDesdeHistoricoPoliza.Text),
                Convert.ToDateTime(txtFechaHAstaHistoricoPoliza.Text));
            gvHistoricoPolizaFianza.DataSource = Buscar;
            gvHistoricoPolizaFianza.DataBind();
            int CantidadRegistros;
            foreach (var n in Buscar)
            {
                CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSubramo("103");
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try {
                //VALIDAMOS LOS RANGOS DE FECHA
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "MensajeConsulta", "MensajeConsulta();", true);
                    if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeError", "FechaDesdeError();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaError", "FechaHastaError();", true);
                    }
                }
                else
                {
                    string _Poliza = string.IsNullOrEmpty(txtpolizaConsulta.Text.Trim()) ? null : txtpolizaConsulta.Text.Trim();
                    decimal? _Subramo = ddlSeleccionarSubramo.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSubramo.SelectedValue) : new Nullable<decimal>();

                    var Exportar = (from n in ObjData.Value.GenerarProduccionFianzas(
                        _Poliza,
                        _Subramo,
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text))
                                    select new
                                    {
                                        NoFactura = n.NoFactura,
                                        Poliza = n.Poliza,
                                        Estatus = n.Estatus,
                                        NoFormulario=n.NoFormulario,
                                        Ramo = n.Ramo,
                                        SubRamo = n.SubRamo,
                                        Cliente = n.Cliente,
                                        TelefonoResidencia = n.TelefonoResidencia,
                                        TelefonoOficina = n.TelefonoOficina,
                                        Celular = n.Celular,
                                        fax = n.fax,
                                        Otro = n.Otro,
                                        Direccion = n.Direccion,
                                        UbicacionCliente = n.UbicacionCliente,
                                        ProvinciaCliente = n.ProvinciaCliente,
                                        MunicipioCliente = n.MunicipioCliente,
                                        SectorCliente = n.SectorCliente,
                                        Supervisor = n.Supervisor,
                                        Intermediario = n.Intermediario,
                                        UbicacionIntermediario = n.UbicacionIntermediario,
                                        ProvinciaIntermediario = n.ProvinciaIntermediario,
                                        MunicipioIntermediario = n.MunicipioIntermediario,
                                        SectorIntermediario = n.SectorIntermediario,
                                        FechaFacturacion = n.FechaFacturacion,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        SumaAsegurada = n.SumaAsegurada,
                                        Neto = n.Neto,
                                        Tasa = n.Tasa,
                                        Impuesto = n.Impuesto,
                                        PorcComision = n.PorcComision,
                                        Facturado = n.Facturado,
                                        Cobrado = n.Cobrado,
                                        Balance = n.Balance,
                                        LeyInfraccionImputado = n.LeyInfraccionImputado

                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion de Fianzas", Exportar);
                }
            }
            catch (Exception) { }
        }

        protected void gvInventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInventario.PageIndex = e.NewPageIndex;
            MostrarRegistros();
        }

        protected void gvInventario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvHistoricoPolizaFianza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHistoricoPolizaFianza.PageIndex = e.NewPageIndex;
            ConsultarHistorico();
        }

        protected void btnConsultarHistorico_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeHistoricoPoliza.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAstaHistoricoPoliza.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MensajeConsulta", "MensajeConsulta();", true);
            }
            else {

                try {
                    ConsultarHistorico();
                }
                catch (Exception) { }

            }
        }

        protected void btnExportarHistoriclPoliza_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeHistoricoPoliza.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAstaHistoricoPoliza.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MensajeConsulta", "MensajeConsulta();", true);
            }
            else
            {
                try {
                    string _poliza = string.IsNullOrEmpty(txtPolizaHistoricoPoliza.Text.Trim()) ? null : txtPolizaHistoricoPoliza.Text.Trim();
                    int? _Subramo = ddlSeleccionarSubramHistoriclPoliza.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramHistoriclPoliza.SelectedValue) : new Nullable<int>();

                    var Exportar = (from n in ObjData.Value.BuscaHistoriclPoliza(
                        _poliza,
                        _Subramo,
                        Convert.ToDateTime(txtFechaDesdeHistoricoPoliza.Text),
                        Convert.ToDateTime(txtFechaHAstaHistoricoPoliza.Text))
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Estatus = n.Estatus,
                                        Cliente = n.Cliente,
                                        Intermediario = n.Intermediario,
                                        Prima = n.Prima,
                                        SumaAsegurada = n.SumaAsegurada,
                                        Ramo = n.Ramo,
                                        Subramo = n.Subramo,
                                        Concepto = n.Concepto,
                                        FechaFacturacionFormateada = n.Fecha,
                                        FechaFacturacion = n.Fecha0,
                                        Usuario = n.Usuario,
                                        Valor = n.Valor,
                                        TotalFacturado = n.TotalFacturado,
                                        TotalCobrado = n.TotalCobrado,
                                        Balance = n.Balance,
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Historico de Polizas Fianzas", Exportar);
                }
                catch (Exception) { }
                //EXPORTAR
            }
        }
    }
}
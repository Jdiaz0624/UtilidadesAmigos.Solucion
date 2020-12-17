using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteCobros : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReporte = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();


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

                var Buscarregistros = ObjDataReporte.Value.BuscarDataReporteCobrosDetalle(
                    null,
                    null,
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
                    Convert.ToDecimal(txtTasaConsulta.Text));
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
                gvListadoCobros.DataSource = Buscarregistros;
                gvListadoCobros.DataBind();
                    
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
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
    }
}
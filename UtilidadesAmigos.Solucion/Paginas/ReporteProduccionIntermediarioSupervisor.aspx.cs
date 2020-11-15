using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ReporteProduccionIntermediarioSupervisor : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjData = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        protected void Page_Load(object sender, EventArgs e)
        {
            rbNoAgrupar.Checked = true;
            rbTodas.Checked = true;
            rbDetalle.Checked = true;
            txtTasa.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            txtNombreSupervisor.Text = "Supervisor";
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            txtNombreIntermediario.Text = "Intermediario";
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())){
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVAcio", "CampoFechaDesdeVAcio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())){
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHAstaVAcio", "CampoFechaHAstaVAcio();", true);
                }
            }
            else {
                //REALIZAMOS LA COSULTA
                var MostrarConsultaGeneral = ObjData.Value.BuscaReporteProduccionOrigen(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToDecimal(txtTasa.Text));
                gvListdoProduccion.DataSource = MostrarConsultaGeneral;
                gvListdoProduccion.DataBind();
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVAcio", "CampoFechaDesdeVAcio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHAstaVAcio", "CampoFechaHAstaVAcio();", true);
                }
            }
            else { }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVAcio", "CampoFechaDesdeVAcio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHAstaVAcio", "CampoFechaHAstaVAcio();", true);
                }
            }
            else { }
        }

        protected void gvListdoProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvListdoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
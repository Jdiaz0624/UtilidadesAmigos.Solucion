using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReporteIntermediariosAlfredo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "REPORTE DE INTERMEDIARIOS MOVIMIENTOS";

                rbPDF.Checked = true;
            }
        }

        protected void txtCodigoIntermediarioReporte_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio()", "FechaHastaVacio();", true); }
            }
            else { }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio()", "FechaHastaVacio();", true); }
            }
            else { }
        }

        protected void LinkPrimeraPaginaReporteIntermediariosEspecial_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorReporteIntermediariosEspecial_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionReporteIntermediariosEspecial_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionReporteIntermediariosEspecial_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteReporteIntermediariosEspecial_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoReporteIntermediariosEspecial_Click(object sender, EventArgs e)
        {

        }
    }
}
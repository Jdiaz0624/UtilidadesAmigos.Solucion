using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class PolizasConBalancesPorAntiguedad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                ReportesAgrupados.Visible = false;
                rbReporteDetallado.Checked = true;
                rbPDF.Checked = true;
                rbAgrupadoPorRamo.Checked = true;
  
                DateTime DiaActual = DateTime.Now;
     
                txtFechaCorte.Text = DiaActual.ToString("yyyy-MM-dd");
            }
        }

        protected void rbReporteDetallado_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbReporteResumido_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbReporteAgrupado_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtIntermediario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
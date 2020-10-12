using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteAntiguedadSaldo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rbReporteResumido.Checked = true;
               // rbPorRamo.Checked = true;
                rbTodosMovimientos.Checked = true;
            }
        }

        protected void btnExportarRegistros_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {

        }
    }
}
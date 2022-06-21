using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class AntiguedadSaldo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "ANTIGUEDAD DE SALDO";
            }
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
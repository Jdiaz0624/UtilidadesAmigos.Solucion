using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class VolantesDePagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "GENERAR VOLANTES DE PAGOS";
            }

        }

        protected void txtCodigoEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCodigos_Click(object sender, EventArgs e)
        {

        }

        protected void btnConfigurar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarCodigo_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaVolantePago_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorVolantePago_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionVolantePago_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionVolantePago_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteVolantePago_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoVolantePago_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverVolantePago_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class Endosos : System.Web.UI.Page
    {


        private void ConfiguracionInicial() {
            txtPolizaConsulta.Text = string.Empty;
            txtNumeroItenComsulta.Text = string.Empty;
            txtCedulaConductorUnico.Text = string.Empty;
            txtNombreConductorUnico.Text = string.Empty;
            txtNumeroLicenciaExtranjero.Text = string.Empty;
         
            DIVBloqueDetallePoliza.Visible = false;
            DIVBloqueHistorico.Visible = false;
            DIVBloqueNuevoRegistro.Visible = false;
            txtNumeroItenComsulta.Text = "1";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR ENDOSOS";

                ConfiguracionInicial();
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnRestablecerPantalla_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicial();
        }

        protected void rbHistoricoEndoso_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbGenerarNuevoEndoso_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnReImprimirEndoso_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void rbEndosoAclaratorio_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbEndosoLicenciaExtragero_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbEndosoAclaratorioPAraCodundorUnico_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbENdosoAuxilioVial_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnCompletar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
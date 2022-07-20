using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class ProcesoEmisionPoliza : System.Web.UI.Page
    {

        private void ConfiguracionInicial() {
            cbClienteCreadoEditar.ForeColor = System.Drawing.Color.Green;
            cbClienteCreadoEditar.Checked = true;
            cbClienteCreadoEditar.Enabled = false;

            cbDocumentosRevisados.ForeColor = System.Drawing.Color.Red;
            cbEmisionPoliza.ForeColor = System.Drawing.Color.Red;
            cbSegundaRevision.ForeColor = System.Drawing.Color.Red;
            cbImpresiónMarbete.ForeColor = System.Drawing.Color.Red;
            cbPolizaDespachada.ForeColor = System.Drawing.Color.Red;

            cbClienteCreadoEditar.Enabled = false;
            cbDocumentosRevisados.Enabled = true;
            cbEmisionPoliza.Enabled = false;
            cbSegundaRevision.Enabled = false;
            cbImpresiónMarbete.Enabled = false;
            cbPolizaDespachada.Enabled = false;

            DIVBloqueConsulta.Visible = true;
            DIVBloqueNuevoRegistro.Visible = true;
            DIvBloqueModificarRegistro.Visible = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "SEGUIMIENTO DE EMISION DE POLIZA";
                ConfiguracionInicial();
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnRestablecerPantalla_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEditarRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPaginaHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnteriorHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalHeader_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalHeader_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePaginaHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPaginaHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGaurdarNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtCodigoClienteNuevoRegistro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditarRegistro_Click1(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnColverAtrasEditarRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void cbDocumentosRevisados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDocumentosRevisados.Checked == true) {
                cbDocumentosRevisados.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = true;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbDocumentosRevisados.Checked == false) {
                cbDocumentosRevisados.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
        }

        protected void cbEmisionPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEmisionPoliza.Checked == true)
            {
                cbEmisionPoliza.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = true;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbEmisionPoliza.Checked == false)
            {
                cbEmisionPoliza.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
        }

        protected void cbSegundaRevision_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSegundaRevision.Checked == true)
            {
                cbSegundaRevision.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = true;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbSegundaRevision.Checked == false)
            {
                cbSegundaRevision.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
        }

        protected void cbImpresiónMarbete_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImpresiónMarbete.Checked == true)
            {
                cbImpresiónMarbete.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = true;
            }
            else if (cbImpresiónMarbete.Checked == false)
            {
                cbImpresiónMarbete.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
        }

        protected void cbPolizaDespachada_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPolizaDespachada.Checked == true)
            {
                cbPolizaDespachada.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbPolizaDespachada.Checked == false)
            {
                cbPolizaDespachada.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void btnPrimeraPaginaDetalle_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnteriorDetalle_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalDetalle_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalDetalle_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePaginaDetalle_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPaginaDetalle_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
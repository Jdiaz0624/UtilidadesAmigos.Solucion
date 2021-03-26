using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class DatosPoliza : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbUsuarioConectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "DATOS DE POLIZA";
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetallePrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaBloquePrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorBloquePrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionBloquePrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionBloquePrincipal_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteBloquePrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoBloquePrincipal_Click(object sender, EventArgs e)
        {

        }

        protected void cbModificarValor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarValor.Checked == true) {
                DivPrimaNueva.Visible = true;
                txtDetallePrimaNuevaPrincipal.Text = string.Empty;
            }
            else {
                DivPrimaNueva.Visible = false;
            }
        }

        protected void cbModificarVigencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarVigencia.Checked == true) {
                DivFechaInicioVigencia.Visible = true;
                DivFechaFinVigencia.Visible = true;

                txtDetalleInicioVigencia.Text = string.Empty;
                txtDetalleFechaFinVigencia.Text = string.Empty;
            }
            else {
                DivFechaInicioVigencia.Visible = false;
                DivFechaFinVigencia.Visible = false;
            }
        }

        protected void btnGuardarDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {

        }

        protected void rbDetallePoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDetallePoliza.Checked == true) {
                BloqueControlesPrincipales.Visible = true;
                DivBloqieCoberturas.Visible = false;

                DivFechaFinVigencia.Visible = false;
                DivFechaInicioVigencia.Visible = false;
                DivPrimaNueva.Visible = false;
                rbDetallePoliza.Checked = false;
                rbCoberturasPolizas.Checked = false;
            }
            else {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = false;
            }
        }

        protected void rbCoberturasPolizas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoberturasPolizas.Checked == true) {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = true;
            }
            else {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = false;
            }
        }

        protected void btnseleccionarCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionCoberturas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCoberturas_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void rbBuscarPorPlaca_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbBuscarPorChasis_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarotrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalleOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionOtrosFiltros_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionOtrosFiltros_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtrasOtrosFiltros_Click(object sender, EventArgs e)
        {

        }
    }
}
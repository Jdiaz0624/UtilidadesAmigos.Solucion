using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Transito
{
    public partial class PolizasConPagosPendientes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        #region LISTAS DESPLEGABLES
        private void ListasDesplegables() {
            ListaOficinas();
            ListaRamo();
            ListaSubRamo();
        }
        private void ListaOficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjDataComun.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void ListaRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamo, ObjDataComun.Value.BuscaListas("RAMO", null, null), true);
        }
        private void ListaSubRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubRamo, ObjDataComun.Value.BuscaListas("SUBRAMO", ddlRamo.SelectedValue.ToString(), null), true);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "POLIZAS PENDIENTE DE PAGOS";

                UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
                Fecha.FechaMes(ref txtFechaDesde, ref txtFechaHasta);

                ListasDesplegables();
            }
        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            try {
                if (string.IsNullOrEmpty(txtCliente.Text.Trim())) {
                    txtNombreCliente.Text = string.Empty;
                }
                else {
                    UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente Nombre = new Logica.Comunes.ESacarNombreCliente(txtCliente.Text);
                    txtNombreCliente.Text = Nombre.SacarCodigoCLiente();
                }
            }
            catch(Exception) {
            
            }
        }

        protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaSubRamo();
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            try { }
            catch (Exception) { }
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            try { }
            catch (Exception) { }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
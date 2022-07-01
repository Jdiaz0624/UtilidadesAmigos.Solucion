using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReporteImpresionMarbetes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDaraReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        #region CARGAR LISTAS 
        private void Cargaroficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjData.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void CargarRamos()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamo, ObjData.Value.BuscaListas("RAMOFILTRADO", null, null), true);
        }
        private void CargarSubRamos()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubramo, ObjData.Value.BuscaListas("SUBRAMO", ddlRamo.SelectedValue.ToString(), null), true);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "REPORTE DE IMPRESION DE MARBETES";
                Cargaroficinas();
                CargarRamos();
                CargarSubRamos();
                rbFormatoReporte.Checked = true;
                DateTime FechaDesde = DateTime.Now, FechaHasta = DateTime.Now;
                txtFechaDesde.Text = FechaDesde.ToString("yyyy-MM-dd");
                txtFechaHasta.Text = FechaHasta.ToString("yyyy-MM-dd");
            }
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreSupervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = NombreSupervisor.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreIntermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = NombreIntermediario.SacarNombreIntermediario();
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoCliente.Text.Trim())) { }
            else {
                UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente NombreCliente = new Logica.Comunes.ESacarNombreCliente(txtCodigoCliente.Text);
                txtNombreCliente.Text = NombreCliente.SacarCodigoCLiente();
            }
            
        }

        protected void btnGenerarReporte_Click(object sender, ImageClickEventArgs e)
        {
            if (rbFormatoExcelPlano.Checked == true) { }
            else { }
        }

        protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubRamos();
        }

        protected void btnMostrarPorPantalla_Click(object sender, ImageClickEventArgs e)
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
    }
}
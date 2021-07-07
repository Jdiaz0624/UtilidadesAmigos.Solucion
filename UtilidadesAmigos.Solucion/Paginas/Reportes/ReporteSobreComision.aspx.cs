using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReporteSobreComision : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        #region BENEFICIARIOS DE SOBRE COMISIONES
        private void MostrarBeneficiariosSobreComisiones() {
            var Listado = ObjDataReportes.Value.BuscaBeneficiariosSobreComisiones();
            rpListadoCodigosSobreComision.DataSource = Listado;
            rpListadoCodigosSobreComision.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "REPORTE DE SOBRE COMISION";

                MostrarBeneficiariosSobreComisiones();
            }
        }

        protected void btnCodigosPermitidos_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultarInformacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechadesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHAsta.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtFechadesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHAsta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio()", "FechaHastaVacio();", true);
                }
            }
            else {
                var CodigoBeneficiarioSeleccionado = ((Button)sender).NamingContainer;
                var hfCodigoseleccionado = ((HiddenField)CodigoBeneficiarioSeleccionado.FindControl("hfCodigoBeneficiario")).Value.ToString();

                var PorcientoComisionBeneficiario = ((Button)sender).NamingContainer;
                var hfPorcientoComisionBeneficiario = ((HiddenField)PorcientoComisionBeneficiario.FindControl("hfPorcientoComisionBeneficiario")).Value.ToString();

                lbCodigobeneficiarioSeleccionado.Text = hfCodigoseleccionado;
                lbPorcientoComisionBeneficiario.Text = hfPorcientoComisionBeneficiario;
            }
        }

        protected void LinkPrimeraPaginaCobradoSupervisores_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorCobradoSupervisores_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionCobradoSupervisores_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCobradoSupervisores_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteCobradoSupervisores_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoCobradoSupervisores_Click(object sender, EventArgs e)
        {

        }



        //protected void btnSeleccionarIntermediarioRepeater_Click(object sender, EventArgs e)
        //{
        //    var PolizaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
        //    var hfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfCodigoGenerarSobreComision")).Value.ToString();
        //}
    }
}
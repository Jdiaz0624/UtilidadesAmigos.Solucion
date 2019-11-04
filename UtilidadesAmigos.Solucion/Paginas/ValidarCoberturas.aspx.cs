using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ValidarCoberturas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS COBERTURAS
        private void CargarCoberturas()
        {
            var Cargar = Objdata.Value.CargarListadoCoberturas();
            ddlSeleccionarCobertura.DataSource = Cargar;
            ddlSeleccionarCobertura.DataTextField = "Cobertura";
            ddlSeleccionarCobertura.DataValueField = "IdCobertura";
            ddlSeleccionarCobertura.DataBind();
        }
        #endregion

        #region CARGAR LOS PLANES DE COBERTURAS
        private void CargarPlanesCoberturas()
        {
            var CargarPlan = Objdata.Value.CargarPlanCoberturas(
                Convert.ToDecimal(ddlSeleccionarCobertura.SelectedValue));
            ddlSeleccionarplan.DataSource = CargarPlan;
            ddlSeleccionarplan.DataTextField = "planCobertura";
            ddlSeleccionarplan.DataValueField = "IdPlanCobertura";
            ddlSeleccionarplan.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCoberturas();
                CargarPlanesCoberturas();
                rbValidacionManual.Checked = true;
            }
        }

        protected void ddlSeleccionarCobertura_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanesCoberturas();
        }
    }
}
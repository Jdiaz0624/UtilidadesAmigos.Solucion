using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarCarteraIntermedirio : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();


        #region CARGAR LAS OFICINAS
        private void CargarOficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaConsulta, ObjDataConexion.Value.BuscaListas("OFICINA", null, null), true);
        }
        #endregion
        #region MOSTRAR EL LISTADO DE INTERMEDIARIO
        private void MostrarListadoIntermediaioro()
        {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            string _NombreVendedor = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();

            var Consultar = ObjDataConexion.Value.SacarDatosIntermediarios(
                _CodigoSupervisor,
               _CodigoIntermediario,
                _Oficina,
                _NombreVendedor);
            gvListadoIntermediario.DataSource = Consultar;
            gvListadoIntermediario.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarOficinas();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoIntermediaioro();
        }

        protected void btnRestabelecer_Click(object sender, EventArgs e)
        {

        }

        protected void gvListadoIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoIntermediario.PageIndex = e.NewPageIndex;
            MostrarListadoIntermediaioro();
        }

        protected void gvListadoIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
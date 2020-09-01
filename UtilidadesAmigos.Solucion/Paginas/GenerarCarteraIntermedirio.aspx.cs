using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarCarteraIntermedirio : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS LISTSA DESPLEGABLES
        private void CargarSucursales() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalConsulta, ObjDataConexion.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinasCOnsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaConsulta, ObjDataConexion.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue, null), true);
        }
        #endregion
        #region BUSCAR INTERMEDIARIOS
        private void BuscarIntermediarios() {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
            string NombreIntermediario = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();

            var BuscarRegistros = ObjDataConexion.Value.SacarDatosIntermediarios(
                _CodigoSupervisor,
                _CodigoIntermediario,
                _Oficina,
                NombreIntermediario);
            gvListadoIntermediario.DataSource = BuscarRegistros;
            gvListadoIntermediario.DataBind();
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSucursales();
                CargarOficinasCOnsulta();

            }
        }

        protected void ddlSeleccionarSucursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinasCOnsulta();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            BuscarIntermediarios();
        }

        protected void btnRestabelecer_Click(object sender, EventArgs e)
        {
            BuscarIntermediarios();
        }

        protected void gvListadoIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoIntermediario.PageIndex = e.NewPageIndex;
            BuscarIntermediarios();
        }

        protected void gvListadoIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gvComisionIntermediario_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvComisionIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}
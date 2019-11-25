using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{//decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
    
    public partial class AsignacionTarjetas : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            //decimal? dd = txtNumerotarjetaMantenimiento.Text != "-1" ? decimal.Parse(txtNumerotarjetaMantenimiento.Text) : new Nullable<decimal>();


        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void gvTarjetaAcceso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvTarjetaAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvTarjetaAcceso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try { e.Row.Cells[1].Visible = false; }
            catch (Exception) { }
        }

        protected void cbFiltrarPorRangoFechaConsulta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFiltrarPorRangoFechaConsulta.Checked)
            {
                lbFechaDesdeConsulta.Visible = true;
                txtFechaDesdeConsulta.Visible = true;
                lbFechaHastaConsulta.Visible = true;
                txtFechaHastaConsulta.Visible = true;
            }
            else
            {
                lbFechaDesdeConsulta.Visible = false;
                txtFechaDesdeConsulta.Visible = false;
                lbFechaHastaConsulta.Visible = false;
                txtFechaHastaConsulta.Visible = false;
            }
        }
    }
}
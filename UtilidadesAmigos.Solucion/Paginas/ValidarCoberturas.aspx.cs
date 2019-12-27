using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ValidarCoberturas : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarCoberturas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCpbertura, ObjData.Value.BuscaListas("COBERTURA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null));
        }
        private void CargarPlanCoberturas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null));
        }
        #endregion

        #region MOSTRAR LAS COBERTURAS
        private void MostrarCoberturas()
        {
            txtCoberturaMantenimiento.Text = string.Empty;
            string _Cobertura = string.IsNullOrEmpty(txtCoberturaMantenimiento.Text.Trim()) ? null : txtCoberturaMantenimiento.Text.Trim();

            var Buscar = ObjData.Value.BuscaCoberturaMantenimiento(
                new Nullable<decimal> (),
                _Cobertura);
            gbCoberturas.DataSource = Buscar;
            gbCoberturas.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE COBERTURAS
        private void MAnCoberturas(decimal? IdCobertura)
        {
            try {
                if (Session["IdUsuario"] != null)
                {
                    UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento Mantenimiento = new Logica.Entidades.EBuscaCoberturasMantenimiento();

                    Mantenimiento.IdCobertura = IdCobertura;
                    Mantenimiento.Descripcion = txtCoberturaMantenimiento.Text;
                    Mantenimiento.Estatus0 = cbEstatus.Checked;

                    var MAN = ObjData.Value.MantenimientoCobertura(Mantenimiento, "UPDATE");
                    MostrarCoberturas();
                    CargarCoberturas();
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (Exception) { }
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCoberturas();
                MostrarCoberturas();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            txtPolizaFiltro.Text = "hola";
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
          
        }

        protected void gvListadoCobertura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
          
        }

        protected void gvListadoCobertura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rbGenerarDataRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        protected void rbGenerarDataCompleta_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void rbGenerarDataRangoFecha_CheckedChanged1(object sender, EventArgs e)
        {
          
        }

        protected void ddlSeleccionarCpbertura_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanCoberturas();
        }

        protected void gbCoberturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbCoberturas.PageIndex = e.NewPageIndex;
            MostrarCoberturas();
        }

        protected void gbCoberturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gbCoberturas.SelectedRow;

            var Buscar = ObjData.Value.BuscaCoberturaMantenimiento(Convert.ToDecimal(gb.Cells[0].Text));
            foreach (var n in Buscar)
            {
                txtCoberturaMantenimiento.Text = n.Descripcion;
                lbIdCobertura.Text = n.IdCobertura.ToString();
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
         
            }

        }

        protected void btnGuardarCobertura_Click(object sender, EventArgs e)
        {
            MAnCoberturas(Convert.ToDecimal(lbIdCobertura.Text));
        }

        protected void gbPlanCobertura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbPlanCobertura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardarPlanCobertura_Click(object sender, EventArgs e)
        {

        }
    }
}
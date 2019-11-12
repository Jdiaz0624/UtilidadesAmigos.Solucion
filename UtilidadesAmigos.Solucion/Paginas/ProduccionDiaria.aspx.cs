using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//EXPORTAMOS A EXEL
using System.IO;
using System.Drawing;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionDiaria : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region CARGAR LOS RAMOS
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataLogica.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LA PRODUCCION DIARIA
        private void MostrarProduccionDiaria()
        {
            if (cbEspesificarRamo.Checked)
            {
                var MostrarData = ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToInt32(ddlSeleccionarRamo.SelectedValue),
                    null);
                gbProduccionDiaria.DataSource = MostrarData;
                gbProduccionDiaria.DataBind();
            }
            else
            {
                var MostrarData = ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text));
                gbProduccionDiaria.DataSource = MostrarData;
                gbProduccionDiaria.DataBind();
            }
        }
        #endregion
        #region EXPORTAR DATA A EXEL
        private void ExportarDataExel()
        {
            if (cbEspesificarRamo.Checked)
            {
                var Exportar = (from n in ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToInt32(ddlSeleccionarRamo.SelectedValue),
                    null)
                                select new
                                {
                                    Ramo =n.Ramo,
                                    Concepto =n.Concepto,
                                    Cantidad=n.Cantidad,
                                    Moneda=n.Moneda,
                                    Facturado=n.Facturado,
                                    PesosDominicanos=n.PesosDominicanos
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Diaria " + " - " + ddlSeleccionarRamo.SelectedItem, Exportar);
            }
            else
            {
                var Exportar = (from n in ObjDataLogica.Value.ProduccionDiaria(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text))
                                select new
                                {
                                    Ramo = n.Ramo,
                                    Concepto = n.Concepto,
                                    Cantidad = n.Cantidad,
                                    Moneda = n.Moneda,
                                    Facturado = n.Facturado,
                                    PesosDominicanos = n.PesosDominicanos
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Produccion Diaria " + " - " + ddlSeleccionarRamo.SelectedItem, Exportar);
            }
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamos();
                lbSeleccionarRamo.Visible = false;
                ddlSeleccionarRamo.Visible = false;
            }
          

        }


        protected void gbListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gbListado.PageIndex = e.NewPageIndex;
            //CargarData();
        }

        protected void cbEspesificarRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEspesificarRamo.Checked)
            {
                lbSeleccionarRamo.Visible = true;
                ddlSeleccionarRamo.Visible = true;
            }
            else
            {
                lbSeleccionarRamo.Visible = false;
                ddlSeleccionarRamo.Visible = false;
            }
        }

        protected void gbProduccionDiaria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbProduccionDiaria.PageIndex = e.NewPageIndex;
            MostrarProduccionDiaria();
        }

        protected void gbProduccionDiaria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarRegistros_Click(object sender, EventArgs e)
        {
            try {
                MostrarProduccionDiaria();
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorConsulta()", true);
            }
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try {
                ExportarDataExel();
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorExportar()", true);
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

        }
    }
}
 
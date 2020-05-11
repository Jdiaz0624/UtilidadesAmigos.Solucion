using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    
    public partial class ReporteReclamos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAMOS LAS LISTAS DESPLEGABLES PARA LA CONSULTA
        private void CargarListasDesplegablesConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCondicionConsulta, ObjData.Value.BuscaListas("CONDICIONRECLAMACION", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoConsulta, ObjData.Value.BuscaListas("TIPORECLAMACION", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatutsConsulta, ObjData.Value.BuscaListas("ESTATUSRECLAMACION", null, null), true);
        }
        #endregion
        #region CONSULTAR REGISTROS
        private void ConsultarRegistros()
        {
            try {
                decimal? _CondicionReclamacion = ddlSeleccionarCondicionConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarCondicionConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _TipoReclamacion = ddlSeleccionarTipoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarTipoConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _EstatusReclamacion = ddlSeleccionarEstatutsConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarEstatutsConsulta.SelectedValue) : new Nullable<decimal>();
                string _Numeroreclamacion = string.IsNullOrEmpty(txtReclamacionConsulta.Text.Trim()) ? null : txtReclamacionConsulta.Text.Trim();
                string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                string _Intermediario = string.IsNullOrEmpty(txtIntermediarioConsulta.Text.Trim()) ? null : txtIntermediarioConsulta.Text.Trim();
                string _Asegurado = string.IsNullOrEmpty(txtAseguradoCOnsulta.Text.Trim()) ? null : txtAseguradoCOnsulta.Text.Trim();
                string _Beneficiario = string.IsNullOrEmpty(txtBeneficiarioConsulta.Text.Trim()) ? null : txtBeneficiarioConsulta.Text.Trim();

                if (cbAgregarRangoFechaConsulta.Checked)
                {

                }
                else
                {
                    //CONSULTAMOS SIN UTILIZAR LOS RANGOS DE FECHA
                    var Consultar = ObjData.Value.BuscaReclamaciones(
                        new Nullable<decimal>(),
                        _Numeroreclamacion,
                        _Poliza,
                        _Intermediario,
                        _Asegurado,
                        _CondicionReclamacion,
                        _Beneficiario,
                        _TipoReclamacion,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        _EstatusReclamacion);
                    gvListadoReclamos.DataSource = Consultar;
                    gvListadoReclamos.DataBind();
                }
            }
            catch (Exception ex) { }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListasDesplegablesConsulta();
                ConsultarRegistros();
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {
            ConsultarRegistros();
        }

        protected void btnExportarRegistrosConsulta_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "Mensaje();", true);
        }

        protected void btnEliminarRegistro_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "Mensaje();", true);
        }

        protected void gvListadoReclamos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoReclamos.PageIndex = e.NewPageIndex;
            ConsultarRegistros();
        }

        protected void gvListadoReclamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "Mensaje();", true);
        }

        protected void cbAgregarRangoFechaConsulta_CheckedChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "Mensaje();", true);
            cbAgregarRangoFechaConsulta.Checked = false;
        }
    }
}
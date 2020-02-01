using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionDiariaContabilidad : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LOS RAMOS
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjData.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion
        #region CARGAR LAS OFICINAS
        private void CargarOficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjData.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }
        #endregion
        #region CARGAR EL LISTADO DE PRODUCCION Y COBRADO DE CONTABILIDAD
        private void CargarListado()
        {
            if (Convert.ToInt32(ddlSeleccionarTipoReporte.SelectedValue) == 1)
            {
                //CARGAMOS TODA LA DATA DE PRODUCCION
                if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 1)
                {
                    //CARGAMOS LA DATA SIN CONTAR CON LOS INTERMEDIARIOS
                    try {
                        int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                        int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                        int? _LlevaIntermediario = ddlLlevaIntermediario.SelectedValue != "-1" ? Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) : new Nullable<int>();

                        var SacarData = ObjData.Value.SacarProduccionDiariaContabilidad(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            _Ramo,
                            _Oficina,
                            null,
                            null,
                            _LlevaIntermediario);
                        foreach (var n in SacarData)
                        {
                            decimal FacturacionHoy = Convert.ToDecimal(n.Hoy);
                            lbFacturadoHoyVariable.Text = FacturacionHoy.ToString("N2");

                            decimal CantidadDebitos = Convert.ToDecimal(n.TotalDebito);
                            lbCantidadDebitosVariable.Text = CantidadDebitos.ToString("N2");

                            decimal CantidadCreditos = Convert.ToDecimal(n.TotalCredito);
                            lbTotalCretitoVariable.Text = CantidadCreditos.ToString("N2");

                            decimal CantidadOtros = Convert.ToDecimal(n.TotalOtros);
                            lbOtrosVariable.Text = CantidadOtros.ToString("N2");

                            decimal Total = Convert.ToDecimal(n.Total);
                            LablbTotalVariableel7.Text = Total.ToString("N2");

                            decimal MesAnterior = Convert.ToDecimal(n.MesAnterior);
                            lbMesAnteriorvariable.Text = MesAnterior.ToString("N2");

                        }
                        gvGridSinIntermediario.DataSource = SacarData;
                        gvGridSinIntermediario.DataBind();
                    }
                    catch (Exception) {
                        ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                    }
                }
                else
                {
                    if (cbTodosLosIntermediarios.Checked == true)
                    {
                        //CARGAMOS LA DATA CON TODOS LOS INTERMEDIARIOS
                        try
                        {


                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                        }
                    }
                    else
                    {
                        //CARGAMOS LA DATA VALIDANDO UN SOLO INTERMEDIARIO
                        try
                        {


                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                        }
                    }
                }
            }
            else
            {
                //CARGAMOS TODA LA DATA DE LO COBRADO
                try
                {


                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamos();
                CargarOficinas();
            }
        }

        protected void ddlSeleccionarTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLlevaIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlLlevaIntermediario.SelectedValue) == 2)
            {
                lbIntermediario.Visible = true;
                txtCodigoIntermediario.Visible = true;
                cbTodosLosIntermediarios.Visible = true;
                txtCodigoIntermediario.Text = string.Empty;
                gvGridConIntermediario.Visible = true;
                gvGridSinIntermediario.Visible = false;
            }
            else
            {
                lbIntermediario.Visible = false;
                txtCodigoIntermediario.Visible = false;
                cbTodosLosIntermediarios.Visible = false;
                gvGridConIntermediario.Visible = false;
                gvGridSinIntermediario.Visible = true;
            }
        }

        protected void cbTodosLosIntermediarios_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodosLosIntermediarios.Checked)
            {
                lbLetreroTodosIntermediairos.Visible = true;
            }
            else
            {
                lbLetreroTodosIntermediairos.Visible = false;
            }
        }

        protected void gvGridSinIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGridConIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }
    }
}
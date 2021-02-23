using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteAntiguedadSaldo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObDataMantenimiento = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjdataGeneral.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarTipoMovimientos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoMovimiento, ObjdataGeneral.Value.BuscaListas("TIPOMOVIMIENTOS", null, null), true);
        }
        private void CargarOficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjdataGeneral.Value.BuscaListas("OFICINAS", null, null), true);
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rbReporteResumido.Checked = true;
                rbPDF.Checked = true;
                rbSistema.Checked = true;
                CargarRamos();
                CargarTipoMovimientos();
                CargarOficinas();
            }
        }

        protected void rbSistema_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbHistorico_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            string _CodigoCliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? null : txtCodigoCliente.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente SacarNombre = new Logica.Comunes.ESacarNombreCliente(_CodigoCliente);
            txtNombreCliente.Text = SacarNombre.SacarCodigoCLiente();
        }

        protected void txtCodigoVendedor_TextChanged(object sender, EventArgs e)
        {
            string _CodigoVendedor = string.IsNullOrEmpty(txtCodigoVendedor.Text.Trim()) ? null : txtCodigoVendedor.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarNombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoVendedor);
            txtNombreVendedor.Text = SacarNombre.SacarNombreIntermediario();
        }
    }
}
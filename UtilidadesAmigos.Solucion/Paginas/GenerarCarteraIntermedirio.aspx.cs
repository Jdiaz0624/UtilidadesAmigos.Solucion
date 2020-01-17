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
            try {
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
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }
        #endregion
        #region MOSTRAR LAS COMISIONES DE LOS INTERMEDIARIOS
        private void MostrarComisionesIntermediario()
        {
            try {
                var MostrarComisionesIntermediario = ObjDataConexion.Value.GenerarComisionIntermediario(
               Convert.ToDateTime(txtFechaDesdeGenerarComision.Text),
               Convert.ToDateTime(txtFechaHastaGenerarComision.Text),
               Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));
                foreach (var n in MostrarComisionesIntermediario)
                {

                }
                gvComisionIntermediario.DataSource = MostrarComisionesIntermediario;
                gvComisionIntermediario.DataBind();
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }

      
        }
        #endregion
        #region MOSTRAR LA CARTERA DE LOS INTERMEDIARIOS
        private void MostrarCarteraIntermediarios(decimal CofigoIntermediario)
        {
            try {
                var Cartera = ObjDataConexion.Value.BuscaSacarCarteraIntermediario(
               null,
               Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));
                gvCarteraIntermeiarios.DataSource = Cartera;
                gvCarteraIntermeiarios.DataBind();
            }
            catch (Exception) {

                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }
        #endregion
        #region SACAR LA PRODUCCION DE LOS INTERMEDIARIOS
        private void SacarProduccionIntermediarios()
        {
            try {
                var SacarProduccion = ObjDataConexion.Value.SacarProduccionIntermediario(
                    Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                    Convert.ToDateTime(txtFechaHastaProduccion.Text),
                    Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));
                foreach (var n in SacarProduccion)
                {
                    decimal Total = Convert.ToDecimal(n.Total.ToString());
                    lbTotalProduccion.Text = Total.ToString("N2");
                }
                gvListadoProduccion.DataSource = SacarProduccion;
                gvListadoProduccion.DataBind();
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarOficinas();
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();",true);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoIntermediaioro();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnRestabelecer_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void gvListadoIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoIntermediario.PageIndex = e.NewPageIndex;
            MostrarListadoIntermediaioro();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void gvListadoIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvListadoIntermediario.SelectedRow;

            var SacarCodigoIntermediario = ObjDataConexion.Value.SacarDatosIntermediarios(
                null,
                gb.Cells[2].Text);
            foreach (var n in SacarCodigoIntermediario)
            {
                lbNombreIntermediarioComision.Text = n.NombreVendedor;
                lbNombreIntermediarioCartera.Text = n.NombreVendedor;
                lbNombreIntermediarioProduccion.Text = n.NombreVendedor;
            }
            lbGenerarCodifoIntermediario.Text = gb.Cells[2].Text;
            gvListadoIntermediario.DataSource = SacarCodigoIntermediario;
            gvListadoIntermediario.DataBind();
            MostrarCarteraIntermediarios(Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));


            ClientScript.RegisterStartupScript(GetType(), "ActivarControles", "ActivarControles();", true);
        }

        protected void btnGenerarComisionIntermediario_Click(object sender, EventArgs e)
        {
            MostrarComisionesIntermediario();
        }

        protected void btnExportarExel_Click(object sender, EventArgs e)
        {
            try {
                var Exportar = (from n in ObjDataConexion.Value.GenerarComisionIntermediario(
                Convert.ToDateTime(txtFechaDesdeGenerarComision.Text),
                Convert.ToDateTime(txtFechaHastaGenerarComision.Text),
                Convert.ToDecimal(lbGenerarCodifoIntermediario.Text))
                                select new
                                {
                                    Supervisor = n.Supervisor,
                                    Intermediario = n.Intermediario,
                                    Cliente = n.Cliente,
                                    Recibo = n.Recibo,
                                    FechaRecibo = n.Fecha,
                                    Factura = n.Factura,
                                    FechaFactura = n.FechaFactura,
                                    Moneda = n.Moneda,
                                    Poliza = n.Poliza,
                                    Producto = n.Producto,
                                    Bruto = n.Bruto,
                                    Neto = n.Neto,
                                    PorcientoComision = n.PorcientoComision,
                                    Comision = n.Comision,
                                    Retencion = n.Retencion,
                                    AvanceComision = n.AvanceComision,
                                    ALiquidar = n.ALiquidar
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision " + lbNombreIntermediarioComision.Text + "", Exportar);
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }

        protected void gvComisionIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvComisionIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvCarteraIntermeiarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCarteraIntermeiarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnExportarCarteraExel_Click(object sender, EventArgs e)
        {
            try {
                var Cartera = (from n in ObjDataConexion.Value.BuscaSacarCarteraIntermediario(
             null,
             Convert.ToDecimal(lbGenerarCodifoIntermediario.Text))
                               select new
                               {
                                   Supervisor = n.Supervisor,
                                   Intermediario = n.Intermediario,
                                   Poliza = n.Poliza,
                                   Estatus = n.Estatus,
                                   Ramo = n.Ramo,
                                   SubRamo = n.SubRamo,
                                   Cliente = n.Cliente,
                                   Telefonos=n.Telefonos,
                                   SumaAsegurada = n.SumaAsegurada,
                                   Prima = n.prima,
                                   TotalFacturado = n.TotalFacturado,
                                   TotalPagado = n.TotalPagado,
                                   Balance = n.Balance
                               }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera " + lbNombreIntermediarioCartera.Text + "", Cartera);
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }

        protected void gvListadoProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoProduccion.PageIndex = e.NewPageIndex;
            SacarProduccionIntermediarios();
        }

        protected void gvListadoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarProduccion_Click(object sender, EventArgs e)
        {
            SacarProduccionIntermediarios();
        }

        protected void btnExportarExelProduccion_Click(object sender, EventArgs e)
        {
            try {
                var Exportar = (from n in ObjDataConexion.Value.SacarProduccionIntermediario(
                    Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                    Convert.ToDateTime(txtFechaHastaProduccion.Text),
                    Convert.ToDecimal(lbGenerarCodifoIntermediario.Text))
                                select new
                                {
                                    Poliza=n.Poliza,
                                    NoFactura=n.NoFactura,
                                    Fecha=n.Fecha,
                                    Valor=n.Valor,
                                    Cliente=n.Cliente,
                                    Vendedor=n.Vendedor,
                                    Cobrador=n.Cobrador,
                                    Concepto=n.Concepto,
                                    Balance=n.Balance,
                                    Ncf=n.Ncf,
                                    Tasa=n.Tasa,
                                    Moneda=n.Moneda,
                                    Oficina=n.Oficina,
                                    Total=n.Total
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción " + lbNombreIntermediarioCartera.Text + "", Exportar);
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }
    }
}
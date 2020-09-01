using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ComisionesIntermediarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();

        #region BUSCAR COMISIONES DE INTERMEDIARIOS
        private void GenerarComisionesIntermediarios()
        {
            try
            {
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta()", "ErrorConsulta();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                    }
                }
                else
                {
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
                    int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();

                    var GenerarComisiones = ObjDataConexion.Value.GenerarComisionIntermediario(
                        Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                        Convert.ToDateTime(txtFechaHastaComisiones.Text),
                        _CodigoIntermediario,
                        _Oficina);
                    gvComisionIntermediario.DataSource = GenerarComisiones;
                    gvComisionIntermediario.DataBind();

                }
            }
            catch (Exception) { }
        }
        #endregion
        #region EXPORTAR COMISIONES
        private void ExportarComisionesIntermediarios()
        {

            try
            {
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta()", "ErrorConsulta();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                    }
                }
                else
                {
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
                    int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();

                    var Exportar = (from n in ObjDataConexion.Value.GenerarComisionIntermediario(
                        Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                        Convert.ToDateTime(txtFechaHastaComisiones.Text),
                        _CodigoIntermediario,
                        _Oficina)
                                    select new
                                    {
                                        Supervisor = n.Supervisor,
                                        Intermediario = n.Intermediario,
                                        Oficina = n.Oficina,
                                        Numeroidentificacion = n.NumeroIdentificacion,
                                        CuentaBanco = n.CuentaBanco,
                                        TipoCuenta = n.TipoCuenta,
                                        Banco = n.Banco,
                                        Cliente = n.Cliente,
                                        NumeroRecibo = n.Recibo,
                                        FechaPago = n.Fecha,
                                        NumeroFactura = n.Factura,
                                        FechaFactura = n.FechaFactura,
                                        Moneda = n.Moneda,
                                        Poliza = n.Poliza,
                                        Producto = n.Producto,
                                        MontoBruto = n.Bruto,
                                        MontoNeto = n.Neto,
                                        PorcientoComision = n.PorcientoComision,
                                        Comision = n.Comision,
                                        Retencion = n.Retencion,
                                        AvanceComision = n.AvanceComision,
                                        ALiquidar = n.ALiquidar

                                    }).ToList();

                }
            }
            catch (Exception) { }
        }
        #endregion
        private void CargarSucursalesComisiones()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalComisiones, ObjDataConexion.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinasComisiones()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaComisiones, ObjDataConexion.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalComisiones.SelectedValue, null), true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSucursalesComisiones();
            CargarOficinasComisiones();
        }
    }
}
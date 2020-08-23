using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class DatosPoliza : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

        #region SACAR DATOS POLIZA
        private void SacarDatosPoliza()
        {
            var SacarDatos = Objdata.Value.SacarDatosDatosPoliza(
                txtIngresarPoliza.Text,
                Convert.ToInt32(txtIngresarItem.Text));
            if (SacarDatos.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "RegistroNoEncontrado", "RegistroNoEncontrado();", true);
            }
            else
            {
                foreach (var n in SacarDatos)
                {
                    txtRamo.Text = n.Ramo;
                    lbCotizacion.Text = n.Cotizacion.ToString();
                    txtSubramo.Text = n.SubRamo;
                    txtTipoVehiculo.Text = n.Tipo;
                    txtMarca.Text = n.Marca;
                    txtModelo.Text = n.Modelo;
                    txtColor.Text = n.Color;
                    txtChasis.Text = n.Chasis;
                    txtPlaca.Text = n.Placa;
                    int ValorAsegurado = (int)n.Valor;
                    txtValorAsegurado.Text = ValorAsegurado.ToString("N2");
                    txtFianza.Text = n.Fianza;
                    txtAsegurado.Text = n.Asegurado;
                    txtCliente.Text = n.Cliente;
                    decimal Neto = (decimal)n.Neto;
                    txtPromaActual.Text = Neto.ToString("N2");
                    int CodRamo = Convert.ToInt32(n.CodRamo);
                    if (CodRamo == 106)
                    {
                        MostrarControlesVehiculo();
                    }
                    else
                    {
                        MostrarControlesOtros();
                    }
                    txtIngresarPoliza.Enabled = false;
                    txtIngresarItem.Enabled = false;
                    btnConsultar.Enabled = false;
                    btnGuardar.Visible = true;
                    btnRegresar.Visible = true;
                }
                MostrarCoberturas();
            }
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void OcultarControles()
        {
            cbModificarPrima.Visible = false;
            cbModificarVigencia.Visible = false;
            lbRamo.Visible = false;
            txtRamo.Visible = false;
            lbSubramo.Visible = false;
            txtSubramo.Visible = false;
            lbTipoVegiculo.Visible = false;
            txtTipoVehiculo.Visible = false;
            lbMarca.Visible = false;
            txtMarca.Visible = false;
            lbModelo.Visible = false;
            txtModelo.Visible = false;
            lbColor.Visible = false;
            txtColor.Visible = false;
            lbChasis.Visible = false;
            txtChasis.Visible = false;
            lbPlaca.Visible = false;
            txtPlaca.Visible = false;
            lbValorAsegurado.Visible = false;
            txtValorAsegurado.Visible = false;
            lbFianza.Visible = false;
            txtFianza.Visible = false;
            lbAsegurado.Visible = false;
            txtAsegurado.Visible = false;
            lbCliente.Visible = false;
            txtCliente.Visible = false;
            lbPrimaActual.Visible = false;
            txtPromaActual.Visible = false;
            lbPrimaNueva.Visible = false;
            txtPrimaNueva.Visible = false;
            lbInicioVigencia.Visible = false;
            txtInicioVigencia.Visible = false;
            lbFinVigencia.Visible = false;
            txtFInVigencia.Visible = false;
            btnGuardar.Visible = false;
            btnRegresar.Visible = false;
            txtIngresarPoliza.Enabled = true;
            txtIngresarItem.Enabled = true;
            btnConsultar.Enabled = true;
        }
        private void MostrarControlesVehiculo()
        {
            cbModificarPrima.Visible = true;
            cbModificarVigencia.Visible = true;
            lbRamo.Visible = true;
            txtRamo.Visible = true;
            lbSubramo.Visible = true;
            txtSubramo.Visible = true;
            lbTipoVegiculo.Visible = true;
            txtTipoVehiculo.Visible = true;
            lbMarca.Visible = true;
            txtMarca.Visible = true;
            lbModelo.Visible = true;
            txtModelo.Visible = true;
            lbColor.Visible = true;
            txtColor.Visible = true;
            lbChasis.Visible = true;
            txtChasis.Visible = true;
            lbPlaca.Visible = true;
            txtPlaca.Visible = true;
            lbValorAsegurado.Visible = true;
            txtValorAsegurado.Visible = true;
            lbFianza.Visible = true;
            txtFianza.Visible = true;
            lbAsegurado.Visible = true;
            txtAsegurado.Visible = true;
            lbCliente.Visible = true;
            txtCliente.Visible = true;
            lbPrimaActual.Visible = true;
            txtPromaActual.Visible = true;
            lbPrimaNueva.Visible = false;
            txtPrimaNueva.Visible = false;
            lbInicioVigencia.Visible = false;
            txtInicioVigencia.Visible = false;
            lbFinVigencia.Visible = false;
            txtFInVigencia.Visible = false;
            btnGuardar.Visible = true;
        }
        private void MostrarControlesOtros() {

            cbModificarPrima.Visible = true;
            cbModificarVigencia.Visible = true;
            lbRamo.Visible = true;
            txtRamo.Visible = true;
            lbSubramo.Visible = true;
            txtSubramo.Visible = true;
            lbTipoVegiculo.Visible = false;
            txtTipoVehiculo.Visible = false;
            lbMarca.Visible = false;
            txtMarca.Visible = false;
            lbModelo.Visible = false;
            txtModelo.Visible = false;
            lbColor.Visible = false;
            txtColor.Visible = false;
            lbChasis.Visible = false;
            txtChasis.Visible = false;
            lbPlaca.Visible = false;
            txtPlaca.Visible = false;
            lbValorAsegurado.Visible = false;
            txtValorAsegurado.Visible = false;
            lbFianza.Visible = true;
            txtFianza.Visible = true;
            lbAsegurado.Visible = true;
            txtAsegurado.Visible = true;
            lbCliente.Visible = true;
            txtCliente.Visible = true;
            lbPrimaActual.Visible = true;
            txtPromaActual.Visible = true;
            lbPrimaNueva.Visible = false;
            txtPrimaNueva.Visible = false;
            lbInicioVigencia.Visible = false;
            txtInicioVigencia.Visible = false;
            lbFinVigencia.Visible = false;
            txtFInVigencia.Visible = false;
            btnGuardar.Visible = true;
        }
        #endregion
        #region MANTENIMIENTO DE DATOS POLIZA
        private void ActuaizarValor()
        {
            try {
                UtilidadesAmigos.Logica.Entidades.ECambiaValorPolizaCondiciones Actualizar = new Logica.Entidades.ECambiaValorPolizaCondiciones();

                Actualizar.Cotizacion = Convert.ToDecimal(lbCotizacion.Text);
                Actualizar.Secuencia = Convert.ToInt32(txtIngresarItem.Text);
                Actualizar.Neto = Convert.ToDecimal(txtPrimaNueva.Text);
                Actualizar.MontoImpuesto = 0;
                Actualizar.PrimaBruta = 0;

                var MAn = Objdata.Value.CambiaValorPolizaCOndicion(Actualizar, "UPDATE");

              
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorCambio", "ErrorCambio()", true);
            }

        }
        private void CambiaVigencia()
        {
            try {
                UtilidadesAmigos.Logica.Entidades.EModificarVigenciaPoliza Modificar = new Logica.Entidades.EModificarVigenciaPoliza();

                Modificar.Cotizacion = Convert.ToDecimal(lbCotizacion.Text);
                Modificar.Secuencia = Convert.ToInt32(txtIngresarItem.Text);
                Modificar.FechaInicioVigencia = Convert.ToDateTime(txtInicioVigencia.Text);
                Modificar.FechaFinVigencia = Convert.ToDateTime(txtFInVigencia.Text);

                var MAn = Objdata.Value.CambiaVigenciaPoliza(Modificar, "UPDATE");
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorCambio", "ErrorCambio()", true); }
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS COBERTURAS DE LA POLIZA CONSULTADA
        private void MostrarCoberturas() {
            var Listado = Objdata.Value.BuscarCoberturaPolizas(
                txtIngresarPoliza.Text,
                Convert.ToInt32(txtIngresarItem.Text));
            gvCoberturasPoliza.DataSource = Listado;
            gvCoberturasPoliza.DataBind();
            foreach (var n in Listado) {
                lbPolizaConsultaVariable.Text = n.Poliza;
                lbItemSeleccionadoVariable.Text = n.SecuenciaCot.ToString();
                lbEstatusPolizaVariableVariable.Text = n.Estatus;
                lbInicioVigenciaVariable.Text = n.InicioVigencia;
                lbFinVigenciaVariable.Text = n.FinVigencia;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OcultarControles();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            SacarDatosPoliza();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbModificarPrima.Checked == true && cbModificarVigencia.Checked == true)
            {
                if (string.IsNullOrEmpty(txtPrimaNueva.Text.Trim()) || string.IsNullOrEmpty(txtInicioVigencia.Text.Trim()) || string.IsNullOrEmpty(txtFInVigencia.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                    if (string.IsNullOrEmpty(txtPrimaNueva.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "PrimaVacia", "PrimaVacia();", true);
                    }
                    if (string.IsNullOrEmpty(txtInicioVigencia.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "InciioVigencia", "InciioVigencia();", true);
                    }
                    if (string.IsNullOrEmpty(txtFInVigencia.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FInVigenciaVacio", "FInVigenciaVacio();", true);
                    }
                }
                else
                {
                    ActuaizarValor();
                    CambiaVigencia();
                    SacarDatosPoliza();
                    txtPrimaNueva.Text = string.Empty;
                    cbModificarPrima.Checked = false;
                    cbModificarVigencia.Checked = false;
                }
            }
            else if (cbModificarPrima.Checked == true && cbModificarVigencia.Checked == false)
            {
                if (string.IsNullOrEmpty(txtPrimaNueva.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                    if (string.IsNullOrEmpty(txtPrimaNueva.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "PrimaVacia", "PrimaVacia();", true);
                    }
                }
                else
                {
                    ActuaizarValor();
                    SacarDatosPoliza();
                    txtPrimaNueva.Text = string.Empty;
                    cbModificarPrima.Checked = false;
                    cbModificarVigencia.Checked = false;
                }
            }
            else if (cbModificarPrima.Checked == false && cbModificarVigencia.Checked == true)
            {
                if (string.IsNullOrEmpty(txtInicioVigencia.Text.Trim()) || string.IsNullOrEmpty(txtFInVigencia.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                    if (string.IsNullOrEmpty(txtInicioVigencia.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "InciioVigencia", "InciioVigencia();", true);
                    }
                    if (string.IsNullOrEmpty(txtFInVigencia.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FInVigenciaVacio", "FInVigenciaVacio();", true);
                    }

                }
                else
                {
                    CambiaVigencia();
                    SacarDatosPoliza();
                    txtPrimaNueva.Text = string.Empty;
                    cbModificarPrima.Checked = false;
                    cbModificarVigencia.Checked = false;
                }
            }
            else if (cbModificarPrima.Checked == false && cbModificarVigencia.Checked == false)
            {
                ClientScript.RegisterStartupScript(GetType(), "SeleccionaOpcion", "SeleccionaOpcion();", true);
            }
        }

        protected void cbModificarVigencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarVigencia.Checked)
            {
                lbInicioVigencia.Visible = true;
                txtInicioVigencia.Visible = true;
                lbFinVigencia.Visible = true;
                txtFInVigencia.Visible = true;
                txtInicioVigencia.Text = string.Empty;
                txtFInVigencia.Text = string.Empty;
            }
            else
            {
                lbInicioVigencia.Visible = false;
                txtInicioVigencia.Visible = false;
                lbFinVigencia.Visible = false;
                txtFInVigencia.Visible = false;
            }
        }

        protected void cbModificarPrima_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarPrima.Checked)
            {
                lbPrimaNueva.Visible = true;
                txtPrimaNueva.Visible = true;
                txtPrimaNueva.Text = string.Empty;
            }
            else
            {
                lbPrimaNueva.Visible = false;
                txtPrimaNueva.Visible = false;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            txtIngresarPoliza.Text = string.Empty;
            txtIngresarItem.Text = string.Empty;
            OcultarControles();
        }

        protected void gvCoberturasPoliza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCoberturasPoliza_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
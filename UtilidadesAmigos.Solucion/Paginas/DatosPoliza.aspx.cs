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
    }
}
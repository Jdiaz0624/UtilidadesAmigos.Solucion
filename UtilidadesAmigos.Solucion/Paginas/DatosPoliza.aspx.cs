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
                Convert.ToInt32(txtIngresarItem.Text),
                null);
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

        #region MODIFICAR DATA COBERTURA
        private void ModificarCobertura() {

            try {
                // decimal Cotizacion = UtilidadesAmigos.Logica.Comunes.coti
                UtilidadesAmigos.Logica.ProcesoInformacion.ProcesarInformacionModificarCoberturaPoliza Procesar = new Logica.ProcesoInformacion.ProcesarInformacionModificarCoberturaPoliza(
                    30,
                    UtilidadesAmigos.Logica.Comunes.SacarNumeroCotizacionPoliza.SacarNumeroCotiacion(txtIngresarPoliza.Text),
                    0, 0,
                    Convert.ToInt32(txtIngresarItem.Text),
                    Convert.ToInt32(lbCodigoCobertura.Text),
                    txtCoberturaSeleccionada.Text,
                    txtMontoInformativo.Text,
                    "S",
                    0,
                    0,
                    Convert.ToDecimal(txtPorciendoDeducible.Text),
                    Convert.ToDecimal(txtMinimoDeducible.Text),
                    "",
                    Convert.ToDecimal(txtPorcientoCobertura.Text),
                    0, "UPDATE");
                Procesar.ModificarCoberturas();


                txtCoberturaSeleccionada.Text = string.Empty;
                txtMontoInformativo.Text = string.Empty;
                txtPorciendoDeducible.Text = string.Empty;
                txtMinimoDeducible.Text = string.Empty;
                txtPorcientoCobertura.Text = string.Empty;
                lbCodigoCobertura.Text = "999";
                MostrarCoberturas();
            }
            catch (Exception) { }
        }
        #endregion
        private void MostrarotrosFiltros() {
            int TipoDato = 0;
            if (rbBuscarChasis.Checked)
            {
                TipoDato = 1;
            }
            else if (rbBuscarPorPlaca.Checked)
            {
                TipoDato = 2;
            }

            var BuscarRegistros = Objdata.Value.BuscaOtrosTipoFiltros(txtDatoOtrosFiltros.Text, TipoDato);
            if (BuscarRegistros.Count() < 1) {
                ClientScript.RegisterStartupScript(GetType(), "RegistroNoEncontrado", "RegistroNoEncontrado();", true);
            }
            else {
                gvOtrosFiltros.DataSource = BuscarRegistros;
                gvOtrosFiltros.DataBind();
            }
           

        }

        private void MostrarControles() {
            btnRegresar.Visible = true;
            txtDatoOtrosFiltros.Enabled = false;
            rbBuscarChasis.Enabled = false;
            rbBuscarPorPlaca.Enabled = false;
            lbPolizaOtrosFiltros.Visible = true;
            txtPolizaOtrosFiltros.Visible = true;
            lbItemOtrosFiltros.Visible = true;
            txtNumeroItemOtrosFiltros.Visible = true;
            lbEstatusOtrosFiltros.Visible = true;
            txtEstatusOtrosFiltros.Visible = true;
            lbSumaAseguradaOtrosFiltros.Visible = true;
            txtSumaAseguradaOtrosFiltros.Visible = true;
            lbClienteOtrosFiltros.Visible = true;
            txtClienteOtrosFiltros.Visible = true;
            lbAseguradoOtrosFiltros.Visible = true;
            txtAseguradoOtrosFiltros.Visible = true;
            lbIntermediarioOtrosFiltros.Visible = true;
            txtIntermediarioOtrosFiltros.Visible = true;
            lbPrimaOtrosFiltros.Visible = true;
            txtPrimaOtrosFiltros.Visible = true;
            lbCotizacionOtrosFiltros.Visible = true;
            txtCotizacionotrosFiltros.Visible = true;
            lbValorVehiculoOtrosFiltros.Visible = true;
            txtValorVehiculoOtrosFiltros.Visible = true;
            lbRamoOtrosFiltros.Visible = true;
            txtRamoOtrosFiltros.Visible = true;
            lbSubramoOtrosFiltros.Visible = true;
            txtSubramoOtrosFiltros.Visible = true;
            lbTipoVehiculoOtrosFiltros.Visible = true;
            txtTipoVehiculoOtrosFiltros.Visible = true;
            lbMarcaOtrosFiltros.Visible = true;
            txtMarcaOtrosFiltros.Visible = true;
            lbModeloOtrosFiltros.Visible = true;
            txtModelosOtrosFiltros.Visible = true;
            lbCapacidadOtrosFiltros.Visible = true;
            txtCapacidadOtrosFiltros.Visible = true;
            lbAnoOtrosFiltros.Visible = true;
            txtAnoOtrosFiltros.Visible = true;
            lbColorOtrosFiltros.Visible = true;
            txtColorOtrosFiltros.Visible = true;
            lbChasisOtrosFiltros.Visible = true;
            txtChasisOtrosFiltros.Visible = true;
            lbPlacaOtrosFiltros.Visible = true;
            txtPlacaOtrosFiltros.Visible = true;
            lbUsoOtrosFiltros.Visible = true;
            txtUsoOtrosFiltros.Visible = true;
        }

        private void OcultarControlesOtrosFiltros() {
            btnRegresar.Visible = false;
            txtDatoOtrosFiltros.Enabled = true;
            rbBuscarChasis.Enabled = true;
            rbBuscarPorPlaca.Enabled = true;
            rbBuscarChasis.Checked = true;
            lbPolizaOtrosFiltros.Visible = false;
            txtPolizaOtrosFiltros.Visible = false;
            lbItemOtrosFiltros.Visible = false;
            txtNumeroItemOtrosFiltros.Visible = false;
            lbEstatusOtrosFiltros.Visible = false;
            txtEstatusOtrosFiltros.Visible = false;
            lbSumaAseguradaOtrosFiltros.Visible = false;
            txtSumaAseguradaOtrosFiltros.Visible = false;
            lbClienteOtrosFiltros.Visible = false;
            txtClienteOtrosFiltros.Visible = false;
            lbAseguradoOtrosFiltros.Visible = false;
            txtAseguradoOtrosFiltros.Visible = false;
            lbIntermediarioOtrosFiltros.Visible = false;
            txtIntermediarioOtrosFiltros.Visible = false;
            lbPrimaOtrosFiltros.Visible = false;
            txtPrimaOtrosFiltros.Visible = false;
            lbCotizacionOtrosFiltros.Visible = false;
            txtCotizacionotrosFiltros.Visible = false;
            lbValorVehiculoOtrosFiltros.Visible = false;
            txtValorVehiculoOtrosFiltros.Visible = false;
            lbRamoOtrosFiltros.Visible = false;
            txtRamoOtrosFiltros.Visible = false;
            lbSubramoOtrosFiltros.Visible = false;
            txtSubramoOtrosFiltros.Visible = false;
            lbTipoVehiculoOtrosFiltros.Visible = false;
            txtTipoVehiculoOtrosFiltros.Visible = false;
            lbMarcaOtrosFiltros.Visible = false;
            txtMarcaOtrosFiltros.Visible = false;
            lbModeloOtrosFiltros.Visible = false;
            txtModelosOtrosFiltros.Visible = false;
            lbCapacidadOtrosFiltros.Visible = false;
            txtCapacidadOtrosFiltros.Visible = false;
            lbAnoOtrosFiltros.Visible = false;
            txtAnoOtrosFiltros.Visible = false;
            lbColorOtrosFiltros.Visible = false;
            txtColorOtrosFiltros.Visible = false;
            lbChasisOtrosFiltros.Visible = false;
            txtChasisOtrosFiltros.Visible = false;
            lbPlacaOtrosFiltros.Visible = false;
            txtPlacaOtrosFiltros.Visible = false;
            lbUsoOtrosFiltros.Visible = false;
            txtUsoOtrosFiltros.Visible = false;
            rbBuscarChasis.Checked = true;
            txtDatoOtrosFiltros.Text = string.Empty;




            txtPolizaOtrosFiltros.Text = string.Empty;
            txtNumeroItemOtrosFiltros.Text = string.Empty;
            txtEstatusOtrosFiltros.Text = string.Empty;
            txtSumaAseguradaOtrosFiltros.Text = string.Empty;
            txtClienteOtrosFiltros.Text = string.Empty;
            txtAseguradoOtrosFiltros.Text = string.Empty;
            txtIntermediarioOtrosFiltros.Text = string.Empty;
            txtPrimaOtrosFiltros.Text = string.Empty;
            txtCotizacionotrosFiltros.Text = string.Empty;
            txtValorVehiculoOtrosFiltros.Text = string.Empty;
            txtRamoOtrosFiltros.Text = string.Empty;
            txtSubramoOtrosFiltros.Text = string.Empty;
            txtTipoVehiculoOtrosFiltros.Text = string.Empty;
            txtMarcaOtrosFiltros.Text = string.Empty;
            txtModelosOtrosFiltros.Text = string.Empty;
            txtCapacidadOtrosFiltros.Text = string.Empty;
            txtAnoOtrosFiltros.Text = string.Empty;
            txtColorOtrosFiltros.Text = string.Empty;
            txtChasisOtrosFiltros.Text = string.Empty;
            txtPlacaOtrosFiltros.Text = string.Empty;
            txtUsoOtrosFiltros.Text = string.Empty;
        }
        private void RestablecerPantalla() {
            txtDatoOtrosFiltros.Enabled = true;
            rbBuscarChasis.Enabled = true;
            rbBuscarPorPlaca.Enabled = true;
            txtDatoOtrosFiltros.Text = string.Empty;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OcultarControles();
                rbBuscarChasis.Checked = true;
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
            ClientScript.RegisterStartupScript(GetType(), "LimpiarControlesCoberturas", "LimpiarControlesCoberturas();", true);
        }

        protected void gvCoberturasPoliza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCoberturasPoliza.PageIndex = e.NewPageIndex;
            MostrarCoberturas();

        }

        protected void gvCoberturasPoliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvCoberturasPoliza.SelectedRow;

            var BuscarInformacion = Objdata.Value.BuscarCoberturaPolizas(
                txtIngresarPoliza.Text,
                Convert.ToInt32(txtIngresarItem.Text),
                Convert.ToInt32(gb.Cells[1].Text));
            foreach (var n in BuscarInformacion) {
                txtCoberturaSeleccionada.Text = n.Descripcion;
                txtMontoInformativo.Text = n.MontoInformativo;
                txtPorciendoDeducible.Text = n.PorcDeducible.ToString();
                txtMinimoDeducible.Text = n.MinimoDeducible.ToString();
                txtPorcientoCobertura.Text = n.PorcCobertura.ToString();
                lbCodigoCobertura.Text = n.Secuencia.ToString();
            }
            ClientScript.RegisterStartupScript(GetType(), "ActivarBotonModificar", "ActivarBotonModificar();", true);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarCobertura();
            ClientScript.RegisterStartupScript(GetType(), "LimpiarControlesCoberturas", "LimpiarControlesCoberturas();", true);
        }

        protected void btnCFonsultarOtrosRegistros_Click(object sender, EventArgs e)
        {
            MostrarotrosFiltros();
           
        }
        protected void gvOtrosFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow Grid = gvOtrosFiltros.SelectedRow;

            int TipoDato = 0;
            if (rbBuscarChasis.Checked) {
                TipoDato = 1;
            }
            else if (rbBuscarPorPlaca.Checked) {
                TipoDato = 2;
            }
            MostrarControles();
            var BuscarRegistros = Objdata.Value.BuscaOtrosTipoFiltros(
                txtDatoOtrosFiltros.Text,
                TipoDato,
                Convert.ToDecimal(Grid.Cells[4].Text),
                Convert.ToInt32(Grid.Cells[2].Text));
            foreach (var n in BuscarRegistros) {
                decimal SumaAsegurada = 0, Prima = 0, ValorVehiculo = 0;
                SumaAsegurada = Convert.ToDecimal(n.SumaAsegurada);
                Prima = Convert.ToDecimal(n.Prima);
                ValorVehiculo = Convert.ToDecimal(n.ValorVehiculo);

                txtPolizaOtrosFiltros.Text = n.Poliza;
                txtNumeroItemOtrosFiltros.Text = n.Item.ToString();
                txtEstatusOtrosFiltros.Text = n.Estatus;
                txtSumaAseguradaOtrosFiltros.Text = SumaAsegurada.ToString("N2");
                txtClienteOtrosFiltros.Text = n.Cliente;
                txtAseguradoOtrosFiltros.Text = n.Asegurado;
                txtIntermediarioOtrosFiltros.Text = n.Intermediario;
                txtPrimaOtrosFiltros.Text = Prima.ToString("N2");
                txtCotizacionotrosFiltros.Text = n.Cotizacion.ToString();
                txtValorVehiculoOtrosFiltros.Text = ValorVehiculo.ToString("N2");
                txtRamoOtrosFiltros.Text = n.Ramo.ToString();
                txtSubramoOtrosFiltros.Text = n.Subramo.ToString();
                txtTipoVehiculoOtrosFiltros.Text = n.TipoVehiculo;
                txtMarcaOtrosFiltros.Text = n.Marca;
                txtModelosOtrosFiltros.Text = n.Modelo;
                txtCapacidadOtrosFiltros.Text = n.Capacidad;
                txtAnoOtrosFiltros.Text = n.Ano;
                txtColorOtrosFiltros.Text = n.Color;
                txtChasisOtrosFiltros.Text = n.Chasis;
                txtPlacaOtrosFiltros.Text = n.Placa;
                txtUsoOtrosFiltros.Text = n.Uso;
            }
        }
        protected void gvOtrosFiltros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOtrosFiltros.PageIndex = e.NewPageIndex;
            MostrarotrosFiltros();

        }

        protected void btnRestablecerOtrosFiltros_Click(object sender, EventArgs e)
        {
            OcultarControlesOtrosFiltros();
        }
    }
}
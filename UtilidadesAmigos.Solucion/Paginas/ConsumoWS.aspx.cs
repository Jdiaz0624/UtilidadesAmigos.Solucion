using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ConsumoWS : System.Web.UI.Page
    {
      //  UtilidadesAmigos.Solucion.Paginas.ConsumoWS MetodosWS = new ConsumoWS();

        private void BloquearCOntroles() {

            lbNumeroPolizaControl.Enabled = false;
            txtPolizaControl.Enabled = false;
            lbNumeroItemControl.Enabled = false;
            txtItemControl.Enabled = false;
            lbNombreClienteControl.Enabled = false;
            txtNombreCLienteControl.Enabled = false;
            lbNumeroIdentificacionControl.Enabled = false;
            txtNumeroIdentificacionControl.Enabled = false;
            lbAseguradoCOntrol.Enabled = false;
            txtNombreAseguradoCOntrol.Enabled = false;
            lbMArcaControl.Enabled = false;
            txtMarcaControl.Enabled = false;
            lbModeloControl.Enabled = false;
            txtModeloControl.Enabled = false;
            lbChasisControl.Enabled = false;
            txtChasisControl.Enabled = false;
            lbPlacaControl.Enabled = false;
            txtPlacaControl.Enabled = false;
        }


        private void COnsultarRegistros() {
            string _Poliza = string.IsNullOrEmpty(txtPolizaControl.Text.Trim()) ? null : txtPolizaControl.Text.Trim();

      

            if (rbBuscarRamoPoliza.Checked == true) { 
            
              

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BloquearCOntroles();
                rbBuscarRamoPoliza.Checked = true;
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarRamoPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBuscarRamoPoliza.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
          
        }

        protected void rbBuscarDatosVehiculoMotor_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosVehiculoMotor.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosFianzas_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosFianzas.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosFidelidad_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosFidelidad.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosIncendioAliadas_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosIncendioAliadas.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosNavesMaritimasAereas_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosNavesMaritimasAereas.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosRamosTecnicos_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosRamosTecnicos.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosSalud_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosSalud.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosTransporteCarga_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosTransporteCarga.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosVidaIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosVidaIndividual.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosVidaColectivo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosVidaColectivo.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosOdontologico_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosOdontologico.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void rbBuscarDatosDependientes_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBuscarDatosDependientes.Checked == true) {
                BloquearCOntroles();
                txtPolizaControl.Enabled = true;
                txtPolizaControl.Focus();
            }
        }

        protected void gvListadoPantalla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvListadoPantalla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Transito
{
    public partial class ReporteProduccionPolizasTransito : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

        #region VALIDAR CHECK
        private void ValidarCheck() {

            if (rbDetallado.Checked == true) {

                DIvBloqueTipoDetallado.Visible = true;
                DIVBloqueAgrupado.Visible = false;
                rbDetalladoSinVehiculos.Checked = true;
            }
            else if (rbResumido.Checked == true) {
                DIvBloqueTipoDetallado.Visible = false;
                DIVBloqueAgrupado.Visible = false;
            }
            else if (rbAgrupado.Checked == true) {
                DIvBloqueTipoDetallado.Visible = false;
                DIVBloqueAgrupado.Visible = true;
                rbAgrupadoPorSupervisor.Checked = true;
            }
            else if (rbPorDia.Checked == true) {
                DIvBloqueTipoDetallado.Visible = false;
                DIVBloqueAgrupado.Visible = false;
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "FuncioNovalida()", "FuncioNovalida();", true);
            }
        }

        private void ColorCheck() {
            if (rbDetallado.Checked == true)
            {
                rbDetallado.ForeColor = System.Drawing.Color.Green;
                rbResumido.ForeColor = System.Drawing.Color.Black;
                rbAgrupado.ForeColor = System.Drawing.Color.Black;
                rbPorDia.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbResumido.Checked == true)
            {
                rbDetallado.ForeColor = System.Drawing.Color.Black;
                rbResumido.ForeColor = System.Drawing.Color.Green;
                rbAgrupado.ForeColor = System.Drawing.Color.Black;
                rbPorDia.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupado.Checked == true)
            {
                rbDetallado.ForeColor = System.Drawing.Color.Black;
                rbResumido.ForeColor = System.Drawing.Color.Black;
                rbAgrupado.ForeColor = System.Drawing.Color.Green;
                rbPorDia.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbPorDia.Checked == true)
            {
                rbDetallado.ForeColor = System.Drawing.Color.Black;
                rbResumido.ForeColor = System.Drawing.Color.Black;
                rbAgrupado.ForeColor = System.Drawing.Color.Black;
                rbPorDia.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "FuncioNovalida()", "FuncioNovalida();", true);
            }


          


            



        }
        private void ColoresDetalle() {
            if (rbDetalladoSinVehiculos.Checked == true)
            {
                rbDetalladoSinVehiculos.ForeColor = System.Drawing.Color.Green;
                rbDetalladoConVehiculos.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbDetalladoConVehiculos.Checked == true)
            {
                rbDetalladoSinVehiculos.ForeColor = System.Drawing.Color.Black;
                rbDetalladoConVehiculos.ForeColor = System.Drawing.Color.Green;
            }
        }
        private void ColoresAgrupados() {
            if (rbAgrupadoPorSupervisor.Checked == true)
            {

                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorIntermediario.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorRamo.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorSubRamo.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorOficina.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorUsuario.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Green;
            }
        }
        private void ColorFormato() {
            if (rbPDF.Checked == true) { 
              rbPDF.ForeColor = System.Drawing.Color.Green;
               rbExcel.ForeColor = System.Drawing.Color.Black;
                RbExcelPlano.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbExcel.Checked == true) {
                rbPDF.ForeColor = System.Drawing.Color.Black;
                rbExcel.ForeColor = System.Drawing.Color.Green;
                RbExcelPlano.ForeColor = System.Drawing.Color.Black;
            }
            else if (RbExcelPlano.Checked == true) {
                rbPDF.ForeColor = System.Drawing.Color.Black;
                rbExcel.ForeColor = System.Drawing.Color.Black;
                RbExcelPlano.ForeColor = System.Drawing.Color.Green;
            }
        }
        #endregion

        #region SACAR RANGO DE FECHA
        private void SacarRangoFecha() {

            UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
            Fecha.FechaMes(ref txtFechaDesde, ref txtFechaHasta);
        }
        #endregion

        #region SACAR LOS DATOS DE LOS SUPERVISORES, INTERMDIARIOS Y CLIENTES
        private void SacarNombreSupervisor() {

            try {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtSUpervisor.Text);
                txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
            }
            catch (Exception) {
                txtNombreSupervisor.Text = "SUPERVISOR NO VALIDO";
            }
        }
        private void SacarNombreIntermediario() {
            try
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtIntermediario.Text);
                txtNombreIntermediario.Text = Nombre.SacarNombreIntermediario();
            }
            catch (Exception)
            {
                txtNombreIntermediario.Text = "INTERMEDIARIO NO VALIDO";
            }
        }
        private void SacarNombreCliente() {
            try
            {
                UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente Nombre = new Logica.Comunes.ESacarNombreCliente(txtCliente.Text);
                txtNombreCliente.Text = Nombre.SacarCodigoCLiente();
            }
            catch (Exception)
            {
                txtNombreCliente.Text = "CLIENTE NO VALIDO";
            }
        }
        #endregion

        #region CARGAR LISTAS DESPLEGABLES
        private void CargarListaDesplegable()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjDataGeneral.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void CargarUsuarios()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjDataGeneral.Value.BuscaListas("USUARIOSMARBETE", ddlOficina.SelectedValue.ToString(), null), true);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "REPORTE DE POLIZAS EN TRANSITO";

                rbDetallado.Checked = true;
                rbDetalladoSinVehiculos.Checked = true;
                rbDetalladoSinVehiculos.ForeColor = System.Drawing.Color.Green;
                rbPDF.Checked = true;
                rbPDF.ForeColor = System.Drawing.Color.Green;
                ValidarCheck();
                ColorCheck();

                SacarRangoFecha();
                CargarListaDesplegable();
                CargarUsuarios();
            }
        }

        protected void txtSUpervisor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSUpervisor.Text.Trim())) {
                txtNombreSupervisor.Text = string.Empty;
            }
            else {
                SacarNombreSupervisor();
            }
        }

        protected void txtIntermediario_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIntermediario.Text.Trim())) { 
            txtNombreIntermediario.Text=string.Empty;
            }
            else {
                SacarNombreIntermediario();
            }
        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text.Trim())) {
                txtNombreCliente.Text = string.Empty;
            }
            else {
                SacarNombreCliente();
            }
        }

        protected void ddlOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void ValidarCheck(object sender, EventArgs e) {
            ValidarCheck();
            ColorCheck();
            ColoresDetalle();
            ColoresAgrupados();
            rbDetalladoSinVehiculos.ForeColor = System.Drawing.Color.Green;
        }
        protected void ColoresDetalle(object sender, EventArgs e) {
            ColoresDetalle();
        }
        protected void ColoresAgrupados(object sender, EventArgs e) {
            ColoresAgrupados();
        }
        protected void ColoresFormato(object sender, EventArgs e) {

            ColorFormato();
        }
    }
}
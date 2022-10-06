using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.ProcesoPoliza
{
    public partial class Cotizador : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataComun = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS LISTAS DESPLEGABLES PARA COTIZAR LOS SEGUROS FULL
        private void CargarTipoVehiculoFull() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoVehiculo, ObjdataComun.Value.BuscaListas("COTIZADORTIPOFULL", null, null));
        }
        private void CargarAnoFull() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarAnoVehiculo, ObjdataComun.Value.BuscaListas("COTIZADORANOFULL", null, null));
        }
        private void CargarPorcentaje() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPorcentaje, ObjdataComun.Value.BuscaListas("COTIZADORPORCENTAJEFULL", ddlSeleccionarTipoVehiculo.SelectedValue.ToString(), ddlSeleccionarAnoVehiculo.SelectedValue.ToString()));
        }
        #endregion

        #region CALCULAR PRIMA SEGUROS FULL
        private double CalcularPrimaSegurosFull(double Porcentaje, double ValorVehiculo) {

            double Resultado = 0;
            Resultado = ValorVehiculo * Porcentaje;
            return Resultado;
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "COTIZADOR";

                rbSegurosFull.Checked = true;
                DIVBloqueSegurosFull.Visible = true;
                DIVBloqueCotizador.Visible = true;
                DIVBloqueAno.Visible = false;
                DIVBloqueTipoVehiculo.Visible = false;
                DIVBloquePorcentaje.Visible = false;

                DIVBloqueSegurosLey.Visible = false;
                CargarTipoVehiculoFull();
                CargarAnoFull();
                CargarPorcentaje();
   
            }
        }

        protected void btnCotizar_Click(object sender, ImageClickEventArgs e)
        {
            string PorcentajeLetra = ddlSeleccionarPorcentaje.SelectedItem.Text;
            double Porcentaje = Convert.ToDouble(PorcentajeLetra);
            lbPrimaFullVariable.Text = CalcularPrimaSegurosFull((Porcentaje / 100), Convert.ToDouble(txtValorVehiculo.Text)).ToString("N2");
        }

        protected void rbSegurosFull_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSegurosFull.Checked == true) {
                DIVBloqueSegurosFull.Visible = true;
                DIVBloqueSegurosLey.Visible = false;
                DIVBloqueCotizador.Visible = true;
                DIVBloqueAno.Visible = false;
                DIVBloqueTipoVehiculo.Visible = false;
                DIVBloquePorcentaje.Visible = false;
            }
            else {
                DIVBloqueSegurosFull.Visible = false;
                DIVBloqueSegurosLey.Visible = false;
                DIVBloqueCotizador.Visible = false;
                DIVBloqueAno.Visible = false;
                DIVBloqueTipoVehiculo.Visible = false;
                DIVBloquePorcentaje.Visible = false;
            }
        }

        protected void rbSegurosLey_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSegurosLey.Checked == true) {
                DIVBloqueSegurosFull.Visible = false;
                DIVBloqueSegurosLey.Visible = true;
                DIVBloqueCotizador.Visible = false;
                DIVBloqueAno.Visible = false;
                DIVBloqueTipoVehiculo.Visible = false;
                DIVBloquePorcentaje.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible()", "OpcionNoDisponible();", true);
            }
            else {
                DIVBloqueSegurosFull.Visible = false;
                DIVBloqueSegurosLey.Visible = false;
                DIVBloqueCotizador.Visible = false;
                DIVBloqueAno.Visible = false;
                DIVBloqueTipoVehiculo.Visible = false;
                DIVBloquePorcentaje.Visible = false;
            }
        }

        protected void ddlSeleccionarAnoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPorcentaje();
        }

        protected void ddlSeleccionarTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPorcentaje();
        }
    }
}
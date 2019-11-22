using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.MasterPage
{
    public partial class PatallaPrincila : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
        }

     
        protected void llbProcesarDataGruas_Click(object sender, EventArgs e)
        {
            
        }
        protected void llbUsuarios_Click(object sender, EventArgs e)
        {
           
        }


        protected void llbPermisoUsuarios_Click(object sender, EventArgs e)
        {
           
        }

        protected void llbProcesarDataGruas_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ProcesarDataGruas.aspx");
        }

        protected void llbProcesarDataPowerBI_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProcesarDataPowerBi.aspx");
        }

   

        protected void llbAsignacionTarjetas_Click(object sender, EventArgs e)
        {
            
        }



        protected void llbCotizadorAmigos_Click(object sender, EventArgs e)
        {
           
        }

        protected void llbGenerarDataCoberturas_Click(object sender, EventArgs e)
        {
            Response.Redirect("SacarDataCoberturas.aspx");
        }

 

        protected void linkCerrarCesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("MenuPrincipal.aspx");
        }

        protected void linkProduccionPorUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProduccionPorUsuarios.aspx");
        }

        protected void LinkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipal.aspx");
        }

        protected void linkTicket_Click(object sender, EventArgs e)
        {

        }

        protected void linkProduccionDiaria_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProduccionDiaria.aspx");
        }

        protected void linkGenerarCartera_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerarCartera.aspx");
        }

        protected void linkValidarCoberturas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ValidarCoberturas.aspx");
        }

        protected void linkGenerarReporteUAF_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReporteOperacionesSospechosas.aspx");
        }

        protected void linkGenerarReporteCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void linkOficinas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Oficinas.aspx");
        }

        protected void linkDeprtamentos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Departamentos.aspx");
        }

        protected void linkEmpleados_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }

        protected void linkInventario_Click(object sender, EventArgs e)
        {

        }

        protected void linkCotizadorFuturoSeguros_Click(object sender, EventArgs e)
        {
            Response.Redirect("CotizadorAmigos.aspx");
        }

        protected void linkFuturoARS_Click(object sender, EventArgs e)
        {

        }

        protected void linkTarjetasAccesos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionTarjetas.aspx");
        }

        protected void linkMovimientoUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void linkPermisoUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("PermisoUsuarios.aspx");
        }

        protected void linkClaveSeguridad_Click(object sender, EventArgs e)
        {

        }

        protected void linkPerfilesUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void linkUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoUsuarios.aspx");
        }

        protected void linkCarteraIntermediarios_Click(object sender, EventArgs e)
        {

        }

        protected void linkComisionesCobrador_Click(object sender, EventArgs e)
        {

        }

        protected void linkProcesarDataGruas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkEmisionPolizas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkEnvioCorreo_Click(object sender, EventArgs e)
        {

        }

        protected void LinkCorreoElectronicos_Click(object sender, EventArgs e)
        {

        }

        protected void LinkDependientes_Click(object sender, EventArgs e)
        {

        }

        protected void linkClientes_Click(object sender, EventArgs e)
        {

        }
    }
}
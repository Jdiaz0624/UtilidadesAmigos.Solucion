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
            Response.Redirect("~/Paginas/ProcesarDataGruas.aspx");
        }

        protected void llbProcesarDataPowerBI_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ProcesarDataPowerBi.aspx");
        }

   

        protected void llbAsignacionTarjetas_Click(object sender, EventArgs e)
        {
            
        }



        protected void llbCotizadorAmigos_Click(object sender, EventArgs e)
        {
           
        }

        protected void llbGenerarDataCoberturas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/SacarDataCoberturas.aspx");
        }

 

        protected void linkCerrarCesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Paginas/MenuPrincipal.aspx");
        }

        protected void linkProduccionPorUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ProduccionPorUsuarios.aspx");
        }

        protected void LinkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MenuPrincipal.aspx");
        }

        protected void linkTicket_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/SistemaTicket.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkProduccionDiaria_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            // Response.Redirect("ProduccionDiaria.aspx");
        }

        protected void linkGenerarCartera_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/GenerarCartera.aspx");
        }

        protected void linkValidarCoberturas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Consulta/ValidarCoberturas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkGenerarReporteUAF_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Consulta/ReporteOperacionesSospechosas.aspx");
        }

        protected void linkGenerarReporteCoberturas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkOficinas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Oficinas.aspx");
        }

        protected void linkDeprtamentos_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
           Response.Redirect("~/Paginas/Departamentos.aspx");
        }

        protected void linkEmpleados_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            Response.Redirect("~/Paginas/Empleados.aspx");
        }

        protected void linkInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Inventario.aspx");
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkCotizadorFuturoSeguros_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            //Response.Redirect("CotizadorAmigos.aspx");
        }

        protected void linkFuturoARS_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);

        }

        protected void linkTarjetasAccesos_Click(object sender, EventArgs e)
        {
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            Response.Redirect("~/Paginas/AsignacionTarjetas.aspx");
        }

        protected void linkMovimientoUsuarios_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkPermisoUsuarios_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            //Response.Redirect("PermisoUsuarios.aspx");
        }

        protected void linkClaveSeguridad_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MantenimientoClaveSeguridad.aspx");
        }

        protected void linkPerfilesUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MantenimeintoPerfiles.aspx");
        }

        protected void linkUsuarios_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/MantenimientoUsuarios.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            
            
        }

        protected void linkCarteraIntermediarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/GenerarCarteraIntermedirio.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkComisionesCobrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas//Consulta/ListadoRenovacion.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkProcesarDataGruas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkEmisionPolizas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkEnvioCorreo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkCorreoElectronicos_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkDependientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MantenimientoDependientes.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkClientes_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkOpcionMenu_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkOpcion_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkBotones_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkEliminarBalance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/EliminarBalancePoliza.aspx");
        }

        protected void LinkReporteFianzas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Consulta/GenerarReporteFianzas.aspx");
        }

        protected void LinkReporteReclamos_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE RECLAMOS
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/ReporteReclamos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkProcesoCasaConductor_Click(object sender, EventArgs e)
        {

        }

        protected void LinkProduccionDiariaContabilidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Reportes/ProduccionDiariaContabilidad.aspx");
        }

  

        protected void LinkCorregirValorDeclarativa_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/DatosPoliza.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCorregirLimites_Click(object sender, EventArgs e)
        {

        }

        protected void LinkSolicitudEmision_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/SolicitudEmisionPoliza.aspx");
        }

        protected void LinkBakupBD_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/GenerarBackupBaseDatos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarFacturasPDF_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/GenerarFacturasPDF.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkProcesarDataAsegurado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/ProcesarDataAsegurado.aspx");
            }
            else
            {

                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LiniComisionesIntermediarios_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE INTERMEDARIOS
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ComisionesIntermediarios.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkComisionesSupervisores_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE LOS SUPERVISORES
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ComisionesSupervisores.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarMarbetesBehiculo_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE LOS SUPERVISORES
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/GenerarMarbetes.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkClientes_Click1(object sender, EventArgs e)
        {

        }

        protected void LinkIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Mantenimientos/IntermediariosSupervisores.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkMantenimientoPorcientoComisionPorDefecto_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/MantenimientoPorcientoComisionPorDefecto.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarSOlicitudChequeComisiones_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Procesos/GenerarSolicitudChequeComisionesIntermediarios.aspx");

            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkAntiguedadSaldo_Click(object sender, EventArgs e)
        {
            if (Session["Idusuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/GenerarReporteAntiguedadSaldo.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkProduccionIntermediarioSupervisor_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteProduccionIntermediarioSupervisor.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsumoWS_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("ConsumoWS.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReporteCobrado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Reportes/GenerarReporteCobros.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsultarPersonas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/SuperIntendencia/ConsultaPersonas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkImpresionCheques_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) { 
            
                    Response.Redirect("~/Paginas/Reportes/ImpresionCheques.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsultarInformacionAsegurado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Consulta/ConsultarDataAsegurado.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkVolantePago_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Procesos/VolantesDePagos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCorreosEmisoresProcesos_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/ConfiguracionCorreosEmisorProcesos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCredencialesBD_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/CredencialesBD.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkSobreComision_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteSobreComision.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkControlVisitas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                //ControlVisitas.aspx
                Response.Redirect("~/Paginas/ControlVisitas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}
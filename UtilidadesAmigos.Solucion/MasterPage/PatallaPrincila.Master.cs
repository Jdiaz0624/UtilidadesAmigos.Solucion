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
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("SistemaTicket.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkOficinas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Oficinas.aspx");
        }

        protected void linkDeprtamentos_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
           Response.Redirect("Departamentos.aspx");
        }

        protected void linkEmpleados_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            Response.Redirect("Empleados.aspx");
        }

        protected void linkInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventario.aspx");
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
            Response.Redirect("AsignacionTarjetas.aspx");
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
            Response.Redirect("MantenimientoClaveSeguridad.aspx");
        }

        protected void linkPerfilesUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimeintoPerfiles.aspx");
        }

        protected void linkUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoUsuarios.aspx");
        }

        protected void linkCarteraIntermediarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerarCarteraIntermedirio.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkComisionesCobrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoRenovacion.aspx");
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
            Response.Redirect("MantenimientoDependientes.aspx");
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
            Response.Redirect("EliminarBalancePoliza.aspx");
        }

        protected void LinkReporteFianzas_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerarReporteFianzas.aspx");
        }

        protected void LinkReporteReclamos_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE RECLAMOS
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("ReporteReclamos.aspx");
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
            Response.Redirect("ProduccionDiariaContabilidad.aspx");
        }

  

        protected void LinkCorregirValorDeclarativa_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("DatosPoliza.aspx");
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
            Response.Redirect("SolicitudEmisionPoliza.aspx");
        }

        protected void LinkBakupBD_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("GenerarBakupBD.aspx");
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
                Response.Redirect("GenerarFacturasPDF.aspx");
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
                Response.Redirect("ProcesarDataAsegurado.aspx");
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
                Response.Redirect("ComisionesIntermediarios.aspx");
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
                Response.Redirect("ComisionesSupervisores.aspx");
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
                Response.Redirect("GenerarMarbetes.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}
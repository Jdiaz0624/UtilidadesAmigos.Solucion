using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class GestionCobros : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["Idusuario"]);
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");

                lbUsuarioConectado.Text = Nombre.SacarNombreUsuarioConectado();
                lbPantalla.Text = "Gestion de Cobros";

                DIVBloqueProceso.Visible = false;
                DIVBloqueConsulta.Visible = true;
            }
        }

        protected void cbReporteComentaro_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRamoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoIntermediarioConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGestionCobros_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Antiguedad_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_Antiguedad_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Antiguedad_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_DatoVehiculo_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_DatoVehiculo_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_DatoVehiculo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSeleccionarEstatusLLamadaGestionCobros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarConceptoGestionCobros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_GestionCobros_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolver_GestionCobros_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Comentarios_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void btnPaginaSiguiente_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Comentarios_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_Comentarios_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }
    }

    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Suministro
{
    public partial class AdministracionSuministro : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro> ObjDataSuministro = new Lazy<Logica.Logica.LogicaSuministro.LogicaSuministro>();

     

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "ADMINISTRACION DE INVENTARIO";
                rbSolicitudes.Checked = true;
                rbTodos.Checked = true;
                DIVBloqueSolicitudes.Visible = true;
                DIVBloqueAdministracionInventario.Visible = false;
                DivSubBloqueInventarioConsulta.Visible = false;
                DivSubBloqueInventarioMantenimiento.Visible = false;
                UtilidadesAmigos.Logica.Comunes.Rangofecha Fechas = new Logica.Comunes.Rangofecha();
                Fechas.FechaMes(ref txtFechaDesde, ref txtFEcfaHasta);
            }
        }

  

        protected void rbAdministracionInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdministracionInventario.Checked == true) {

                DIVBloqueSolicitudes.Visible = false;
                DIVBloqueAdministracionInventario.Visible = true;
                DivSubBloqueInventarioConsulta.Visible = true;
                DivSubBloqueInventarioMantenimiento.Visible = false;
            }
            else {
                DIVBloqueSolicitudes.Visible = false;
                DIVBloqueAdministracionInventario.Visible = false;
                DivSubBloqueInventarioConsulta.Visible = false;
                DivSubBloqueInventarioMantenimiento.Visible = false;
            }
        }

        protected void rbSolicitudes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSolicitudes.Checked == true) {
                DIVBloqueSolicitudes.Visible = true;
                DIVBloqueAdministracionInventario.Visible = false;
                DivSubBloqueInventarioConsulta.Visible = false;
                DivSubBloqueInventarioMantenimiento.Visible = false;
            }
            else {
                DIVBloqueSolicitudes.Visible = false;
                DIVBloqueAdministracionInventario.Visible = false;
                DivSubBloqueInventarioConsulta.Visible = false;
                DivSubBloqueInventarioMantenimiento.Visible = false;
            }
        }

        protected void ddlSucursalCOnsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDepartamentoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporteSolicitudes_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVer_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_SolicitudesHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_SolicitudesHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_SolicitudesHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_SolicitudesHeader_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnQuitar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnProcesar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSucursalInventarioConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSucursalInventarioConsulta_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnConsultarInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnNuevoRegistroInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporteInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEditarReporteInventarioCOnsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBorrarInventarioCOnsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnRestablecerInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSuplirInventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_InventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_InventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_InventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_InventarioConsulta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSucursalMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
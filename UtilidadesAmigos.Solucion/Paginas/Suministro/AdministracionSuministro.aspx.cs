using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Suministro
{
    public partial class AdministracionSuministro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                DIVBloqueConsulta.Visible = true;
                DIVBloqueInventario.Visible = false;
            }
        }

        protected void rbSolicitudes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSolicitudes.Checked == true) {
                DIVBloqueConsulta.Visible = true;
                DIVBloqueInventario.Visible = false;
            }
            else {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = false;
            }
        }

        protected void rbInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInventario.Checked == true)
            {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = true;
            }
            else
            {
                DIVBloqueConsulta.Visible = false;
                DIVBloqueInventario.Visible = false;
            }
        }

        protected void btnBuscarInformacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnkPrimeraPaginaEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionEncabezadoSolicitud_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionEncabezadoSolicitud_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoEncabezadoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEliminarArticulo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnkPrimeraPaginaArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionArticulosSeleccionado_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionArticulosSeleccionado_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoArticulosSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnConsultarInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporteInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSuplirInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEditarInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEliminarInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnRestablecerPantalla_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSeleccionarArticuloINventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnkPrimeraPaginaInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionInventario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionInventario_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGuardarRegistroMantenimientoInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
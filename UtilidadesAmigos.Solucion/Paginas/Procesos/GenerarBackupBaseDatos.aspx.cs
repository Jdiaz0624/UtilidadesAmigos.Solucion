using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class GenerarBackupBaseDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "GENERAR BACKUP DE BD";

                rbGenerarBackuup.Checked = true;
                rbPDF.Checked = true;
                DivBloqueBackup.Visible = true;
            }
        }

        protected void rbGenerarBackuup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenerarBackuup.Checked == true) {
                DivBloqueBackup.Visible = true;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
            else {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
        }

        protected void rbHistorialBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHistorialBackup.Checked == true) {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = true;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
            else {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
        }

        protected void rbConfiguracion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConfiguracion.Checked == true) {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = true;
            }
            else {
                DivBloqueBackup.Visible = false;
                DivBloqueHistorialBaseDatos.Visible = false;
                DivBloqueConfiguracionBaseDatos.Visible = false;
            }
        }

        protected void btnGenerarBackup_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
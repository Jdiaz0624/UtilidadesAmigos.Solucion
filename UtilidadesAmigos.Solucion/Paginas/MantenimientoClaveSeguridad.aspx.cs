using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoClaveSeguridad : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objadata = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjdataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        #region MOSTRAR EL LISTADO DE LA CLAVE DE SEGURIDAD
        private void MostrarListadoClaveSeguridad()
        {
            var Mostrar = Objadata.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                null);
            gbListadoClaveSeguridad.DataSource = Mostrar;
            gbListadoClaveSeguridad.DataBind();
        }
        #endregion
        #region MOSTRAR Y OCLTAR CONTROLES
        private void MostrarControles()
        {
            lbusuario.Visible = false;
            txtUsuario.Visible = false;
            btnNuevo.Visible = false;
            btnConsultar.Visible = false;
            btnModificar.Visible = false;
            btnDeshabilitar.Visible = false;
            gbListadoClaveSeguridad.Visible = false;
            lbClaveNueva.Visible = true;
            txtClaveNueva.Visible = true;
            lbConfirmarClave.Visible = true;
            txtConfirmarClave.Visible = true;
            lbSeleccionarUsuario.Visible = true;
            ddlSeleccionarusuario.Visible = true;
            lbClaveSeguridad.Visible = true;
            txtClaveSeguridad.Visible = true;
            btnGuardar.Visible = true;
            btnVolver.Visible = true;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarusuario, Objadata.Value.BuscaListas("USUARIOS", null, null));
        }
        private void OcultarControles()
        {
            lbusuario.Visible = true;
            txtUsuario.Visible = true;
            btnNuevo.Visible = true;
            btnConsultar.Visible = true;
            btnModificar.Visible = true;
            btnDeshabilitar.Visible = true;
            gbListadoClaveSeguridad.Visible = true;
            lbClaveNueva.Visible = false;
            txtClaveNueva.Visible = false;
            lbConfirmarClave.Visible = false;
            txtConfirmarClave.Visible = false;
            lbSeleccionarUsuario.Visible = false;
            ddlSeleccionarusuario.Visible = false;
            lbClaveSeguridad.Visible = false;
            txtClaveSeguridad.Visible = false;
            btnGuardar.Visible = false;
            btnVolver.Visible = false;
        }
        #endregion
        #region Mantenimiento de clave de seguridad3
        private void MANClaveSeguridad(string Accion)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try {
                    UtilidadesAmigos.Logica.Entidades.Seguridad.EMantenimientoClaveSeguridad Mantenimeitn = new Logica.Entidades.Seguridad.EMantenimientoClaveSeguridad();

                    Mantenimeitn.IdClaveSeguridad = Convert.ToDecimal(lbIdClaveSeguridad.Text);
                    Mantenimeitn.IdUsuario = Convert.ToDecimal(ddlSeleccionarusuario.SelectedValue);
                    Mantenimeitn.Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveNueva.Text);
                    Mantenimeitn.Estatus = cbEstatus.Checked;

                    var MAN = ObjdataSeguridad.Value.MAntenimientoClaveSeguridad(Mantenimeitn, Accion);
                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMantenimiento();", true);

                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarListadoClaveSeguridad();
            }
        }

        protected void gbListadoClaveSeguridad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoClaveSeguridad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gbListadoClaveSeguridad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                e.Row.Cells[1].Visible = false;
            }
            catch (Exception) { }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "INSERT";
            MostrarControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lbAccion.Text == "INSERT")
            {
                //VERIFICAMOS LOS CAMPOS VACIOS
            }
            else if (lbAccion.Text == "UPDATE")
            {

            }
            else if (lbAccion.Text == "DISABLE")
            {

            }
        }
    }
}
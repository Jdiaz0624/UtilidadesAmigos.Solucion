using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimeintoPerfiles : System.Web.UI.Page
        
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjdataLogica = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR EL LISTADO DE LOS PERFILES
        private void MostrarListado()
        {
            string _Perfil = string.IsNullOrEmpty(txtDescripcionPerfil.Text.Trim()) ? null : txtDescripcionPerfil.Text.Trim();

            var Buscar = ObjdataLogica.Value.ListadoPerfiles(
                new Nullable<decimal>(),
                _Perfil);
            gbListadoPerfiles.DataSource = Buscar;
            gbListadoPerfiles.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE PERFILES
        private void ManPerfiles()
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try {
                    UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles Mantenimiento = new Logica.Entidades.Seguridad.EPerfiles();

                    Mantenimiento.IdPerfil = Convert.ToDecimal(lbIdPerfil.Text);
                    Mantenimiento.perfil = txtDescripcionPerfil.Text;
                    Mantenimiento.Estatus0 = cbEstatus.Checked;

                    var MAN = ObjdataLogica.Value.MantenimientoPerfiles(Mantenimiento, lbEstatus.Text);
                }
                catch (Exception) { }
            }
        }
        #endregion
        #region VOLVER
        private void Volver()
        {
            btnNuevo.Enabled = true;
            btnConsultar.Enabled = true;
            btnExportar.Enabled = true;
            btnDeshabilitar.Enabled = false;
            btnModificar.Enabled = false;
            btnAtras.Enabled = false;
            txtClaveSeguridad.Text = string.Empty;
            txtDescripcionPerfil.Text = string.Empty;
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
            MostrarListado();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarListado();
            }
        }

        protected void gbListadoPerfiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gbListadoPerfiles.SelectedRow;

            var BuscarRegistro = ObjdataLogica.Value.ListadoPerfiles(
                Convert.ToDecimal(gb.Cells[1].Text));
            gbListadoPerfiles.DataSource = BuscarRegistro;
            gbListadoPerfiles.DataBind();
            foreach (var n in BuscarRegistro)
            {
                lbIdPerfil.Text = n.IdPerfil.ToString();
                txtDescripcionPerfil.Text = n.perfil;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                if (cbEstatus.Checked == true)
                {
                    cbEstatus.Visible = false;
                }
                else
                {
                    cbEstatus.Visible = true;
                }
                btnNuevo.Enabled = false;
                btnConsultar.Enabled = false;
                btnExportar.Enabled = false;
                btnDeshabilitar.Enabled = true;
                btnModificar.Enabled = true;
                btnAtras.Enabled = true;
            }
        }

        protected void gbListadoPerfiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                e.Row.Cells[1].Visible = false;
            }
            catch (Exception) { }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Volver();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS LA CLAVE DE SEGURIDAD
            if (string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "ClaveSeguridadNoValida();", true);
            }
            else
            {
                if (string.IsNullOrEmpty(txtDescripcionPerfil.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "CamposVacios();", true);
                }
                else
                {
                    var ValidarClave = ObjData.Value.BuscaClaveSeguridad(
                        new Nullable<decimal>(),
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridad.Text));
                    if (ValidarClave.Count() < 1)
                    {

                        ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "ClaveSeguridadNoValida();", true);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtDescripcionPerfil.Text.Trim()))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "CamposVacios();", true);
                        }
                        else
                        {
                            lbEstatus.Text = "INSERT";
                            ManPerfiles();
                            Volver();
                            ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "MensajeGuardar();", true);
                        }
                      
                    }
                
                }
            }
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS LA CLAVE DE SEGURIDAD
            if (string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "ClaveSeguridadNoValida();", true);
            }
            else
            {
                if (string.IsNullOrEmpty(txtDescripcionPerfil.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "CamposVacios();", true);
                }
                else
                {
                    var ValidarClave = ObjData.Value.BuscaClaveSeguridad(
                        new Nullable<decimal>(),
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridad.Text));
                    if (ValidarClave.Count() < 1)
                    {

                        ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "ClaveSeguridadNoValida();", true);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtDescripcionPerfil.Text.Trim()))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "CamposVacios();", true);
                        }
                        else
                        {
                            lbEstatus.Text = "UPDATE";
                            ManPerfiles();
                            Volver();
                            ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "MensajrActualizar();", true);
                        }

                    }

                }
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS LA CLAVE DE SEGURIDAD
            if (string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "ClaveSeguridadNoValida();", true);
            }
            else
            {
                if (string.IsNullOrEmpty(txtDescripcionPerfil.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "CamposVacios();", true);
                }
                else
                {
                    var ValidarClave = ObjData.Value.BuscaClaveSeguridad(
                        new Nullable<decimal>(),
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridad.Text));
                    if (ValidarClave.Count() < 1)
                    {

                        ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "ClaveSeguridadNoValida();", true);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtDescripcionPerfil.Text.Trim()))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "CamposVacios();", true);
                        }
                        else
                        {
                            lbEstatus.Text = "DISABLE";
                            ManPerfiles();
                            Volver();
                            ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "MensajeDeshabilitar();", true);
                        }

                    }

                }
            }
        }
    }
}
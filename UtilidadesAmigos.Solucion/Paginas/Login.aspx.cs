using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Speech.Synthesis;
using System.Threading;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();
        #region INGRESAR AL SISTEMA
        private void IngresarSistema(string Usuario, string Clave)
        {
            //VERIFICAMOS SI LOS CAMPOS ESTAN VACIOS
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()) || string.IsNullOrEmpty(txtClave.Text.Trim()))
            {

                try {

                    ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "CamposVaciosLogin();", true);
                }
                catch {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para ingresar al sistema');", true);
                }
            }
            else
            {
                string _Usuario = string.IsNullOrEmpty(txtUsuario.Text.Trim()) ? null : txtUsuario.Text.Trim();
                string _Clave = string.IsNullOrEmpty(txtClave.Text.Trim()) ? null : txtClave.Text.Trim();

                VariablesGlobales.ClaveEncriptada = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_Clave);

                var ValidarUsuario = ObjDataLogica.Value.BuscaUsuarios(
                    new Nullable<decimal>(),
                    null,
                    null,
                    null,
                    _Usuario,
                    VariablesGlobales.ClaveEncriptada,
                    null);
                if (ValidarUsuario.Count() < 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mostrarmensaje", "UsuarioNoValido();", true);
                    txtUsuario.Text = string.Empty;
                    txtClave.Text = string.Empty;
                }
                else
                {
                    foreach (var n in ValidarUsuario)
                    {
                        VariablesGlobales.IdUsuario = Convert.ToDecimal(n.IdUsuario);
                        VariablesGlobales.EstatusUsuario = Convert.ToBoolean(n.Estatus0);
                        VariablesGlobales.CambiaClave = Convert.ToBoolean(n.CambiaClave0);
                    }
                    if (VariablesGlobales.EstatusUsuario == true)
                    {
                        //VERIFICAMOS SI SE LE VA A CAMBIAR LA CLAVE
                        if (VariablesGlobales.CambiaClave == true)
                        {
                            txtUsuario.Enabled = false;
                            txtClave.Enabled = false;
                            btnIngresarSistema.Enabled = false;
                            txtNuevaClave.Visible = true;
                            txtConfirmarClave.Visible = true;
                            btnCambiarClave.Visible = true;
                            Session["IdUsuario"] = Convert.ToDecimal(VariablesGlobales.IdUsuario);
                        }
                        else
                        {
                            Session["IdUsuario"] = Convert.ToDecimal(VariablesGlobales.IdUsuario);
                            FormsAuthentication.RedirectFromLoginPage(_Usuario, false);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "UsuarioBloqueado", true);
                    }
                }
            }
        }
        #endregion
        #region BAJAR O SUBIR EL CONTADOR
        private void MantenimientoUsuarios(string AccionTomar)
        {
            UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Mantenimiento = new Logica.Entidades.EMantenimientoUsuarios();

            Mantenimiento.IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);
            Mantenimiento.Clave = VariablesGlobales.ClaveEncriptada;

            var MAN = ObjDataLogica.Value.MantenimientoUsuarios(Mantenimiento, AccionTomar);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNuevaClave.Visible = false;
                txtConfirmarClave.Visible = false;
                btnCambiarClave.Visible = false;
                rbcolaborador.Checked = true;
            }
        }

        protected void btnIngresarSistema_Click(object sender, EventArgs e)
        {
            if (rbcolaborador.Checked)
            {
                IngresarSistema(txtUsuario.Text, txtClave.Text);
            }
            else if (rbSupervisor.Checked)
            {

            }
            else if (rbIntermediario.Checked)
            {

            }

        }

        protected void llbRegistrarse_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCambiarClave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNuevaClave.Text.Trim()) || string.IsNullOrEmpty(txtConfirmarClave.Text.Trim()))
            {

                ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "CamposVaciosClave();", true);
            }
            else
            {
                string _ClaveNueva = string.IsNullOrEmpty(txtNuevaClave.Text.Trim()) ? null : txtNuevaClave.Text.Trim();
                string _ConfirmarClave = string.IsNullOrEmpty(txtConfirmarClave.Text.Trim()) ? null : txtConfirmarClave.Text.Trim();

                if (_ClaveNueva == _ConfirmarClave)
                {
                    VariablesGlobales.ClaveEncriptada = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveNueva);

                    //CAMBIAMOS LA CLAVE
                    MantenimientoUsuarios("CHANGEPASSWORD");
                    Response.Redirect("MenuPrincipal.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "ClavesInvalidas();", true);
                    txtNuevaClave.Text = string.Empty;
                    txtConfirmarClave.Text = string.Empty;
                   
                }

            }


        }

        protected void rbcolaborador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcolaborador.Checked)
            {
                lbIngresarUsuarioClave.Text = "Ingresar Nombre de Usuario y Clave";
            }
            else
            {
                lbIngresarUsuarioClave.Text = "";
            }
        }

        protected void rbSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSupervisor.Checked)
            {
                lbIngresarUsuarioClave.Text = "Ingresar Codigo de Supervisor y Clave";
            }
            else
            {
                lbIngresarUsuarioClave.Text = "";
            }
        }

        protected void rbIntermediario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIntermediario.Checked)
            {
                lbIngresarUsuarioClave.Text = "Ingresar Codigo de Intermediario y clave";
            }
            else
            {
                lbIngresarUsuarioClave.Text = "";
            }
        }
    }
}
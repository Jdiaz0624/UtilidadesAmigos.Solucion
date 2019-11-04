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
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El Usuario esta deshabilitado actualmente, favor de comunicarse con un administrador para desbloquear esta cuenta');", true);
        #region INGRESAR AL SISTEMA
        private void IngresarSistema(string Usuario, string Clave)
        {
            //VERIFICAMOS SI LOS CAMPOS ESTAN VACIOS
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()) || string.IsNullOrEmpty(txtClave.Text.Trim()))
            {
                //
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<Script>alert('No puedes dejar campos vacios para ingresar al sistema');</Script>");
                try {
                    Thread tarea = new Thread(new ParameterizedThreadStart(UtilidadesAmigos.Logica.Comunes.VozVeronica.Hablar));
                    tarea.Start("No puedes dejar campos vacíos para ingresar al sistema");
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
                    null,
                    1, 1);
                if (ValidarUsuario.Count() < 1)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El usuario o la clave ingresada no es correcta favor de verificar');", true);
                    Thread tarea = new Thread(new ParameterizedThreadStart(UtilidadesAmigos.Logica.Comunes.VozVeronica.Hablar));
                    tarea.Start("El usuario o la clave ingresada no es correcta favor de verificar e intentarlo nuevamente, si no recuerda su usuario comuniquese con Tecnologia");
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
                           
                          //  Response.Redirect("MenuPrincipal.aspx");
                            

                        }
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Este usuario se encuentra bloqueado, favor comunicarse con un administrador para desbloquear la cuenta');", true);
                        Thread tarea = new Thread(new ParameterizedThreadStart(UtilidadesAmigos.Logica.Comunes.VozVeronica.Hablar));
                        tarea.Start("Este usuario se encuentra bloqueado, favor comunicarse con un administrador para desbloquear la cuenta");
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

        //private void Hablar(object texto)
        //{
        //    SpeechSynthesizer veronica = new SpeechSynthesizer();
        //    veronica.SetOutputToDefaultAudioDevice();
        //    veronica.Speak(texto.ToString());
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNuevaClave.Visible = false;
                txtConfirmarClave.Visible = false;
                btnCambiarClave.Visible = false;
               // Response.Write("Current Culture is " + CultureInfo.CurrentCulture.EnglishName);
            }
        }

        protected void btnIngresarSistema_Click(object sender, EventArgs e)
        {
            IngresarSistema(txtUsuario.Text, txtClave.Text);
        }

        protected void llbRegistrarse_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCambiarClave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNuevaClave.Text.Trim()) || string.IsNullOrEmpty(txtConfirmarClave.Text.Trim()))
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para cambiar la clave');", true);
                Thread tarea = new Thread(new ParameterizedThreadStart(UtilidadesAmigos.Logica.Comunes.VozVeronica.Hablar));
                tarea.Start("No puedes dejar campos vacios para cambiar la clave");
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
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Las claves ingresada no concuerdan favor de verificar');", true);
                    Thread tarea = new Thread(new ParameterizedThreadStart(UtilidadesAmigos.Logica.Comunes.VozVeronica.Hablar));
                    tarea.Start("Las claves ingresada no concuerdan favor de verificar");
                    txtNuevaClave.Text = string.Empty;
                    txtConfirmarClave.Text = string.Empty;
                   
                }

            }


        }

       
    }
}
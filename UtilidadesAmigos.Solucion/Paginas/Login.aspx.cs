using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Speech.Synthesis;
using System.Threading;
using System.Security.Principal;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        /// <summary>
        /// Este metodo es para ingresar al sistema
        /// </summary>
        private void IngresarSistema()
        {
            try
            {
                //validamos los campos vacios
                if (string.IsNullOrEmpty(txtUsuario.Text.Trim()) || string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposVacios()", "CamposVacios()", true);
                }
                else
                {
                    string _usuario = string.IsNullOrEmpty(txtUsuario.Text.Trim()) ? null : txtUsuario.Text.Trim();
                    string _Clave = string.IsNullOrEmpty(txtPassword.Text.Trim()) ? null : txtPassword.Text.Trim();

                    var ValidarUsuario = ObjData.Value.BuscaUsuarios(
                        new Nullable<decimal>(),
                        null, null, null, null, null,
                        _usuario,
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_Clave),
                        null);
                    if (ValidarUsuario.Count() < 1)
                    {
                        int ContadorBloqueo = Convert.ToInt32(lbContador.Text);

                        if (ContadorBloqueo == 100)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "UsuarioBloqueado()", "UsuarioBloqueado()", true);
                            var BloquearUsuario = ObjData.Value.BuscaUsuarios(
                                new Nullable<int>(),
                                null, null, null, null, null, _usuario, null, null);
                            foreach (var n in BloquearUsuario)
                            {
                                UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Disable = new Logica.Entidades.EMantenimientoUsuarios();
                                Disable.IdUsuario = Convert.ToDecimal(n.IdUsuario);
                                var MAN = ObjData.Value.MantenimientoUsuarios(Disable, "DISABLE");
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "UsuarioNoValido()", "UsuarioNoValido();", true);
                            txtUsuario.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            txtUsuario.Focus();

                            ContadorBloqueo++;
                            lbContador.Text = ContadorBloqueo.ToString();
                        }
                    }
                    else
                    {
                        decimal IdUsuario = 0;
                        bool Estatus = false, CambiaClave = false;

                        foreach (var n in ValidarUsuario)
                        {
                            IdUsuario = Convert.ToDecimal(n.IdUsuario);
                            Estatus = Convert.ToBoolean(n.Estatus0);
                            CambiaClave = Convert.ToBoolean(n.CambiaClave0);
                        }

                        //verificamos si el usuario esta bloqueado
                        if (Estatus == false)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "UsuarioDeshabilitado()", "UsuarioDeshabilitado();", true);
                        }
                        else
                        {
                            Session["IdUsuario"] = Convert.ToDecimal(IdUsuario);
                            //verificamos si el usuario va a cambiar clave
                            if (CambiaClave == false)
                            {

                                Session["Veronica"] = 1;
                                FormsAuthentication.RedirectFromLoginPage(_usuario, true);


                            }
                            else
                            {
                                DivBloqueLogin.Visible = false;
                                DivBloqueCambiaClave.Visible = true;

                                btnIngresarSistema.Visible = false;
                                btnCambioClave.Visible = true;
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string MensajeError = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al ingresar al sistema, favor de contactar a Tecnologia, codigo de error" + MensajeError + "');", true);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MaintainScrollPositionOnPostBack = true;
                if (!IsPostBack) {

                    DivBloqueLogin.Visible = true;
                    btnIngresarSistema.Visible = true;

                    DivBloqueCambiaClave.Visible = false;
                    btnCambioClave.Visible = false;
                }
            }
        }
        protected void btnIngresarSistema_Click(object sender, ImageClickEventArgs e)
        {
            IngresarSistema();
        }

        protected void btnCambioClave_Click(object sender, ImageClickEventArgs e)
        {
            UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios ActualizaClave = new Logica.Entidades.EMantenimientoUsuarios();
            ActualizaClave.IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);
            ActualizaClave.Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtNuevaClave.Text);
            var MAN = ObjData.Value.MantenimientoUsuarios(ActualizaClave, "CHANGEPASSWORD");
            FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, true);
        }
    }
}
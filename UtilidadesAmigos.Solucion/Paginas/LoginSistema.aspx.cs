﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class LoginSistema : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
       
        /// <summary>
        /// Este metodo es para ingresar al sistema
        /// </summary>
        private void IngresarSistema() {
            try {
                //validamos los campos vacios
                if (string.IsNullOrEmpty(txtUsuarioLogin.Text.Trim()) || string.IsNullOrEmpty(txtClaveLogin.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposVacios()", "CamposVacios()", true);
                }
                else {
                    string _usuario = string.IsNullOrEmpty(txtUsuarioLogin.Text.Trim()) ? null : txtUsuarioLogin.Text.Trim();
                    string _Clave = string.IsNullOrEmpty(txtClaveLogin.Text.Trim()) ? null : txtClaveLogin.Text.Trim();

                    var ValidarUsuario = ObjData.Value.BuscaUsuarios(
                        new Nullable<decimal>(),
                        null, null, null, null, null,
                        _usuario,
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_Clave),
                        null);
                    if (ValidarUsuario.Count() < 1) {
                        int ContadorBloqueo = Convert.ToInt32(lbContador.Text);

                        if (ContadorBloqueo == 3)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "UsuarioBloqueado()", "UsuarioBloqueado()", true);
                            var BloquearUsuario = ObjData.Value.BuscaUsuarios(
                                new Nullable<int>(),
                                null, null, null, null, null, _usuario, null, null);
                            foreach (var n in BloquearUsuario) {
                                UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Disable = new Logica.Entidades.EMantenimientoUsuarios();
                                Disable.IdUsuario = Convert.ToDecimal(n.IdUsuario);
                                var MAN = ObjData.Value.MantenimientoUsuarios(Disable, "DISABLE");
                            }
                        }
                        else {
                            ClientScript.RegisterStartupScript(GetType(), "UsuarioNovalido()", "UsuarioNovalido();", true);
                            txtUsuarioLogin.Text = string.Empty;
                            txtClaveLogin.Text = string.Empty;
                            txtUsuarioLogin.Focus();

                            ContadorBloqueo++;
                            lbContador.Text = ContadorBloqueo.ToString();
                            

                        }
                    }
                    else {
                        decimal IdUsuario = 0;
                        bool Estatus = false, CambiaClave = false;

                        foreach (var n in ValidarUsuario) {
                            IdUsuario = Convert.ToDecimal(n.IdUsuario);
                            Estatus = Convert.ToBoolean(n.Estatus0);
                            CambiaClave = Convert.ToBoolean(n.CambiaClave0);
                        }

                        //verificamos si el usuario esta bloqueado
                        if (Estatus == false)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "UsuarioBloqueado()", "UsuarioBloqueado();", true);
                        }
                        else {
                            //verificamos si el usuario va a cambiar clave
                            if (CambiaClave == false) {
                                Session["IdUsuario"] = Convert.ToDecimal(IdUsuario);
                                Session["Veronica"] = 1;
                                FormsAuthentication.RedirectFromLoginPage(_usuario, true);

                                
                            }
                            else { }

                        }

                    }
                }
            }
            catch (Exception ex) {
                string MensajeError = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('Error al ingresar al sistema, favor de contactar a Tecnologia, codigo de error" + MensajeError + "');", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresarSistema_Click(object sender, EventArgs e)
        {
            IngresarSistema();   
        }
    }
}
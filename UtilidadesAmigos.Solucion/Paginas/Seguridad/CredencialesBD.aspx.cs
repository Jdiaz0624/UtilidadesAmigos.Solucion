using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Seguridad
{
    public partial class CredencialesBD : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProceso = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();


        private void ModificarCredenciales(string Accion) {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionCredencialesBD Modificar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionCredencialesBD(
                1,
                txtUsuarioBD.Text,
                UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveBD.Text),
                Accion);
            Modificar.ProcesarInformacion();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "MODIFICAR CREDENCIALES DE BASE DE DATOS";
                DivBloqueClaveSeguridad.Visible = true;
                DivBloqueModificarCredencial.Visible = false;

            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            bool RespuestavAlidacion = false;
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()) ? null : txtClaveSeguridad.Text.Trim();

            UtilidadesAmigos.Logica.Comunes.ValidarClaveSeguridad Validar = new Logica.Comunes.ValidarClaveSeguridad(_ClaveSeguridad);
            RespuestavAlidacion = Validar.ValidarClave();

            switch (RespuestavAlidacion) {
                case true:
                    DivBloqueClaveSeguridad.Visible = false;
                    DivBloqueModificarCredencial.Visible = true;
                    var SacarCredenciales = ObjDataProceso.Value.SacarCredencialesBD(1);
                    foreach (var n in SacarCredenciales) {
                        txtUsuarioBD.Text = n.Usuario;
                        txtClaveBD.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                    }
                    break;

                case false:
                    ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida()", "ClaveSeguridadNoValida();", true);
                    txtClaveSeguridad.Text = string.Empty;
                    txtClaveSeguridad.Focus();
                    break;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarCredenciales("UPDATE");
            ClientScript.RegisterStartupScript(GetType(), "ClaveModificada()", "ClaveModificada();", true);
            DivBloqueClaveSeguridad.Visible = true;
            DivBloqueModificarCredencial.Visible = false;
            txtClaveSeguridad.Text = string.Empty;
            txtUsuarioBD.Text = string.Empty;
            txtClaveBD.Text = string.Empty;
        }
    }
}
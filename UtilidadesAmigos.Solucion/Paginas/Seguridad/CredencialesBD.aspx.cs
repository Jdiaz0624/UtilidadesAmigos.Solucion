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

        }
    }
}
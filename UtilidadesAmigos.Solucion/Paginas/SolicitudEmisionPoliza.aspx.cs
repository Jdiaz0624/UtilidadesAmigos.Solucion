using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    
public partial class SolicitudEmisionPoliza : System.Web.UI.Page
    {
        enum EnumeracionEsTipoServicio
        {
            SegurosLey =1,
            SegurosFull =2
        }
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDatasistema = new Lazy<Logica.Logica.LogicaSistema>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
          
            }
        }

        protected void btnSolicitudLey_Click(object sender, EventArgs e)
        {

        }

        protected void btnSolicitudFull_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeguroFull_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "OpcionNoDisponible", "OpcionNoDisponible();", true);
        }

        protected void btnSeguroLey_Click(object sender, ImageClickEventArgs e)
        {
            try {
                if (Session["IdUsuario"] != null)
                {
                    Response.Redirect("SolicitudSeguroLey.aspx");
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (Exception) { }

        }
    }
}
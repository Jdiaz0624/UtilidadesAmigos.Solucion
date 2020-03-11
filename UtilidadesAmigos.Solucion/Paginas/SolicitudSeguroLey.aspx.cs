using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class SolicitudSeguroLey : System.Web.UI.Page
    {
        UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.Logica.LogicaSistema();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
            }
        }

        protected void ddlSeleccionarTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSiguienteCliente_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearControles", "DesbloquearControles();", true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoUsuarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();





        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void gvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
           
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

         
        }

        protected void ddlSeleccionaroficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarSucursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarSucursalMantenimeinto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
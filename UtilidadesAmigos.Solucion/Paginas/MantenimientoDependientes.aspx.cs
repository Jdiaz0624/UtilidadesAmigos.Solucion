using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoDependientes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LOS DROPS
        private void CargarDrops() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarParentezzcoMantenimiento, ObjData.Value.BuscaListas("PARENTEZCO", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSexoMantenimiento, ObjData.Value.BuscaListas("SEXO", null, null));
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDrops();
            }
        }

        protected void gvDependientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvDependientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {

        }
    }
}
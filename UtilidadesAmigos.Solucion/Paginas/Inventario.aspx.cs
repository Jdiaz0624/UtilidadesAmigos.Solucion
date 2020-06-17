using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class Inventario : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CARGAMOS LAS LISTAS DESPLEGABLES
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursalCOnsulta, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
            }
        }

        protected void gvInventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvInventario_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
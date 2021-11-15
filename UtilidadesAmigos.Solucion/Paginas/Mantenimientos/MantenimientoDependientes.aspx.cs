using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoDependientes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnConsultarRegistros_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnExportarInformacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnEditarRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBorrarRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LinkPrimeraPaginaDependientes_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorDependientes_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionDependientes_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionDependientes_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteDependientes_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoDependientes_Click(object sender, EventArgs e)
        {

        }
    }
}
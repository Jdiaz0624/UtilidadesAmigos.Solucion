using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoClaveSeguridad : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objadata = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR EL LISTADO DE LA CLAVE DE SEGURIDAD
        private void MostrarListadoClaveSeguridad()
        {
            var Mostrar = Objadata.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                null);
            gbListadoClaveSeguridad.DataSource = Mostrar;
            gbListadoClaveSeguridad.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarListadoClaveSeguridad();
            }
        }

        protected void gbListadoClaveSeguridad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoClaveSeguridad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
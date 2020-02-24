using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        #region MOSTRAR EL LISTADO DE LOS SUBRAMO
        private void MostrarListadoSubramos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarProducto, ObjDatasistema.Value.BuscaListas("PRODUCTOSUBRAMO", ddlSeleccionarTipoServicio.SelectedValue.ToString(), null));
        }
        #endregion

        #region SACAR LA DESCRIPCION DEL PRODUCTO SELECCIONADO
        private void SacarDescripcionproductoSelecionado()
        {
            var Descripcio = ObjDatasistema.Value.SacarDescripcionProducto(Convert.ToInt32(ddlSeleccionarTipoServicio.SelectedValue), Convert.ToInt32(ddlSeleccionarProducto.SelectedValue));
            foreach (var n in Descripcio)
            {
                txtDescripcionProducto.Text = n.Descripcion;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarListadoSubramos();
                SacarDescripcionproductoSelecionado();
            }
        }

        protected void ddlSeleccionarTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarListadoSubramos();
            SacarDescripcionproductoSelecionado();
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlSeleccionarTipoServicio.SelectedValue) == (int)EnumeracionEsTipoServicio.SegurosLey)
            {
                //CAMBIAMOS DE PAGINA
                Session["ProductoSeleccionado"] = Convert.ToInt32(ddlSeleccionarProducto.SelectedValue);
                Response.Redirect("SolicitudSeguroLey.aspx");

            }
            else if (Convert.ToInt32(ddlSeleccionarTipoServicio.SelectedValue) == (int)EnumeracionEsTipoServicio.SegurosFull)
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "Mensaje();", true);
            }
        }

        protected void ddlSeleccionarProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            SacarDescripcionproductoSelecionado();
        }
    }
}
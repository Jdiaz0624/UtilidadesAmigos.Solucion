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


        enum Enumeracion
        {
            SeguroLey = 1,
            SeguroFull=2
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbProductoSeleccionado.Text= Session["ProductoSeleccionado"].ToString();
            lbTipoProductoSeleccionadoNombre.Text = "Seguro de Ley";
            //SACAMOS LOS DATOS DEL PRODUCTO SELECCIONADO

            var SacarSubRamo = ObjData.SacarDescripcionProducto(
               1, Convert.ToInt32(lbProductoSeleccionado.Text));
            foreach (var n in SacarSubRamo)
            {
                lbProductoSeleccionadonombre.Text = n.DescripcionSubramo;
                lbDescripcioNproducto.Text = n.Descripcion;
            }
        }
    }
}
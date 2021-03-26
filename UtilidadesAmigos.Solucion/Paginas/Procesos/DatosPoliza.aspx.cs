using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class DatosPoliza : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              



//                lbUsuarioConectado
//lbOficinaUsuairoPantalla
            }
        }

    }
}
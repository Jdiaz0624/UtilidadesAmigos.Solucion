using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class Redireccionamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRedireccionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://172.26.24.199/UtilidadesFuturoSeguros/Paginas/Login.aspx?ReturnUrl=%2fUtilidadesFuturoSeguros%2fPaginas%2fMenuPrincipal.aspx");
        }
    }
}
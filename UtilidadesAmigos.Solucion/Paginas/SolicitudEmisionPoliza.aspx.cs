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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
          
            }
        }

        protected void btnSolicitudLey_Click(object sender, EventArgs e)
        {

        }

        protected void btnSolicitudFull_Click(object sender, EventArgs e)
        {

        }
    }
}
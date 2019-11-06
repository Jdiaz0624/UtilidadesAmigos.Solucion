using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//EXPORTAMOS A EXEL
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Drawing;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionDiaria : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region CARGAR LOS RAMOS
        private void CargarRamos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataLogica.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRamos();
                lbSeleccionarRamo.Visible = false;
                ddlSeleccionarRamo.Visible = false;
            }
          

        }


        protected void gbListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gbListado.PageIndex = e.NewPageIndex;
            //CargarData();
        }

        protected void cbEspesificarRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEspesificarRamo.Checked)
            {
                lbSeleccionarRamo.Visible = true;
                ddlSeleccionarRamo.Visible = true;
            }
            else
            {
                lbSeleccionarRamo.Visible = false;
                ddlSeleccionarRamo.Visible = false;
            }
        }
    }
}
 
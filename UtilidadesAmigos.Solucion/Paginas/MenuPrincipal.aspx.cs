using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Synthesis;
using System.Threading;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas

{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objtata = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();




        
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbUsuarioConectado.Text = Nombre.SacarNombreUsuarioConectado();
                lbPantalla.Text = "Menu Principal";

                
            }
          
        }

        protected void LinkSinPagoInicial_Click(object sender, EventArgs e)
        {

        }

        protected void btnSinPagoInicial_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrimerPagoSinCobros_Click(object sender, EventArgs e)
        {

        }

        protected void btnSegundoPagoSinCobros_Click(object sender, EventArgs e)
        {

        }

        protected void btnTercerPagoSinCobros_Click(object sender, EventArgs e)
        {

        }

        protected void btnCuartoPagoSinCobros_Click(object sender, EventArgs e)
        {

        }

        protected void btnMasDeCientoVeinteDiasSinCobros_Click(object sender, EventArgs e)
        {

        }
    }
}
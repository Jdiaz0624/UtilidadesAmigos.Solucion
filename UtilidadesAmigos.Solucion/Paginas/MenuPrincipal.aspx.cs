using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Synthesis;
using System.Threading;
namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objtata = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

     

        private void SacarDatosUsuario(decimal IdUsuario)
        {
            var SacarDatos = Objtata.Value.BuscaUsuarios(IdUsuario,
                null,
                null,
                null,
                null,
                null,
                null,
                1, 1);
            foreach (var n in SacarDatos)
            {
                lbUsuarioConectado.Text = n.Persona;
                lbDepartamento.Text = n.Departamento;
            }

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SacarDatosUsuario(Convert.ToDecimal(Session["IdUsuario"]));
            if (!IsPostBack)
            {
            }
            decimal idiusuario = Convert.ToDecimal(Session["IdUsuario"]);
            if (idiusuario == 1)
            {
                // this.Master.FindControl("lbTiket").Visible = false;
            }
        }
    }
}
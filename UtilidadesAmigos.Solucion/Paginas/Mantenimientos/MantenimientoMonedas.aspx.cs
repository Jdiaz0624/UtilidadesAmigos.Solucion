using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Mantenimientos
{
    public partial class MantenimientoMonedas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObjData = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();

        private void MostrarListadoMonedas() {

            var Listado = ObjData.Value.BuscaMonedas(
                new Nullable<int>());
            rpListadoMoneda.DataSource = Listado;
            rpListadoMoneda.DataBind();
        }


        private void VolverAtras() {

            txtNombreMneda.Text = string.Empty;
            txtSiglaMoneda.Text = string.Empty;
            txtTasa.Text = string.Empty;
            MostrarListadoMonedas();
            DivBloqueModificar.Visible = false;
            lbCodigoMoneda.Text = "0";
        }

        private void ModificarRegistro(int Codigo, decimal Tasa) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos.ProcesarInformacionTasaMoneda Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos.ProcesarInformacionTasaMoneda(
                Codigo, Tasa);
            Procesar.ProcesarInformacion();
            VolverAtras();
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                MostrarListadoMonedas();
                DivBloqueModificar.Visible = false;

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "MANTENIMIENTO DE MONEDAS";
            }
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            ModificarRegistro(
                 Convert.ToInt32(lbCodigoMoneda.Text),
                 Convert.ToDecimal(txtTasa.Text));
        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            
            VolverAtras();
        }

        protected void btnSeleccionarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfItemSeleccionado = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoMoneda")).Value.ToString();

            lbCodigoMoneda.Text = hfItemSeleccionado;
            DivBloqueModificar.Visible = true;
            var BuscarRegistro = ObjData.Value.BuscaMonedas(Convert.ToInt32(hfItemSeleccionado));
            foreach (var n in BuscarRegistro) {

                txtNombreMneda.Text = n.Descripcion;
                txtSiglaMoneda.Text = n.Sigla;
                txtTasa.Text = n.Tasa.ToString();
            }
        }
    }
}
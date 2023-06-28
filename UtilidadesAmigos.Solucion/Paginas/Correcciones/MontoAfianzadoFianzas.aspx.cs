using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Correcciones
{
    public partial class MontoAfianzadoFianzas : System.Web.UI.Page
    {

        #region CONFIGURACION INICIAL
        private void ConfiguracionInicial() {

            cbNoAgregarRangoFecha.Checked = false;
            txtPolizaConsulta.Text = string.Empty;
            UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
            Fecha.FechaMes(ref txtFechaDesde, ref txtFechaHasta);
            DivBloqueConsulta.Visible = true;
            DIVBloqueModificacion.Visible = false;
            SubBloqueConsulta.Visible = false;
            SubBloqueModificar.Visible = false;
            txtPolizaValidacion.Text=string.Empty;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "MODIFICACION DE MONTO AFIANZADO";

                ConfiguracionInicial();
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePaginar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnValidar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverValidacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
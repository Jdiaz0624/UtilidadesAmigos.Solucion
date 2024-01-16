using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SpreadsheetLight;
using System.IO;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ValidarCoberturas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        enum CodigosCoberturas { 
        TuAsistencia=1,
        AeroAmbulancia=2,
        ServiGrua=3,
        CaribeAsistencia=4,
        CasaConductor=5,
        Cedensa=6
        }

        enum CodigosPlanCoberturas { 
        AeroAmbulancia2=0,
        CasaConductor=17,
        TuAsistenciaPremium=32,
        AeroAmbulancia=35,
        TuAsistenciaSuperior=37,
        TuAsistenciaBasica=38
        }



       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR DATA DE COBERTURAS";

                SubBloqueConsulta.Visible = true;
                SubBloqueValidacion.Visible = false;
            }
        }

        protected void cbValidarData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbValidarData.Checked == true) {
                SubBloqueConsulta.Visible = false;
                SubBloqueValidacion.Visible = true;
            }
            else if (cbValidarData.Checked == false) {
                SubBloqueConsulta.Visible = true;
                SubBloqueValidacion.Visible = false;
            }
        }

        protected void BuscarInformacion(object sender, EventArgs e) { }

        protected void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnModificarCobertura_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlServicio_POPOP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnModificarCoberturaPlan_Click(object sender, ImageClickEventArgs e)
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

        protected void dtPaginacion_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnValidar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Plantilla_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
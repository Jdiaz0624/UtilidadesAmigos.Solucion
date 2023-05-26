using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Suministro
{
    public partial class SolicitudSuministro : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro> ObjDataSuministro = new Lazy<Logica.Logica.LogicaSuministro.LogicaSuministro>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        #region SACAR LOS DATOS DEL USUARIO
        private void CargarDatosUSuario(decimal IdUsuario) {

            var SacarInformacionUSuario = ObjData.Value.BuscaUsuarios(IdUsuario);
            foreach (var n in SacarInformacionUSuario) {

                lbSucursal_ConsultaSolicitud.Text = n.Sucursal;
                lbOficina_ConsultaSolicitud.Text = n.Oficina;
                lbDepartamento_ConsultaSolicitud.Text = n.Departamento;
                lbSolicitante_ConsultaSolicitud.Text = n.Persona;
            }
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void EstatusSolicitudConsulta() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatus_ConsultaSolicitud, ObjData.Value.BuscaListas("ESTATUSSOLICITUD", null, null), true);
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "SOLICITUD DE MATERIALES";

                CargarDatosUSuario((decimal)Session["IdUsuario"]);
                UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
                Fecha.FechaMes(ref txtFechaDesde_ConsultaSolicitud, ref txtFechaHasta_ConsultaSolicitud);
                EstatusSolicitudConsulta();
            }
        }

        protected void btnConsultarInformacion_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnNuevaSolicitud_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ConsultaSolicitud_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ConsultaSolicitud_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSucursalProceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlOficinaProceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDepartamentoProceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultarInformacionInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSeleccionarInventario_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_ProcesoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_ProcesoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ProcesoSolicitud_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ProcesoSolicitud_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_ProcesoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_ProcesoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAgregarRegistroSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverRegistroSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGuardarSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
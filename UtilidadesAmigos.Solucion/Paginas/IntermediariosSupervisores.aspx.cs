using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class IntermediariosSupervisores : System.Web.UI.Page
    {
        UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.Logica.LogicaSistema();
        private void MostrarPais() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPaisMantenimiento, ObjData.BuscaListas("LISTADOPAIS", null, null));
        }
        private void MostrarZonas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarZonaMantenimiento, ObjData.BuscaListas("LISTADOZONAS", ddlSeleccionarPaisMantenimiento.SelectedValue, null));
        }
        private void MostrarProvincias() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarProvinciaMantenimiento, ObjData.BuscaListas("LISTADOPROVINCIAS", ddlSeleccionarPaisMantenimiento.SelectedValue, ddlSeleccionarZonaMantenimiento.SelectedValue));
        }
        private void MostrarMunicipios() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMunicipioMantenimiento, ObjData.BuscaListas("LISTADOMUNICIPIO", ddlSeleccionarPaisMantenimiento.SelectedValue, ddlSeleccionarZonaMantenimiento.SelectedValue, ddlSeleccionarProvinciaMantenimiento.SelectedValue));
        }
        private void MostrarSector() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSectorMantenimiento, ObjData.BuscaListas("LISTADOSECTOR", ddlSeleccionarPaisMantenimiento.SelectedValue, ddlSeleccionarZonaMantenimiento.SelectedValue, ddlSeleccionarProvinciaMantenimiento.SelectedValue, ddlSeleccionarMunicipioMantenimiento.SelectedValue));
        }
        private void MostrarBarrio() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUbicacionMantenimiento, ObjData.BuscaListas("LISTADOBARRIO", ddlSeleccionarPaisMantenimiento.SelectedValue, ddlSeleccionarZonaMantenimiento.SelectedValue, ddlSeleccionarProvinciaMantenimiento.SelectedValue, ddlSeleccionarMunicipioMantenimiento.SelectedValue, ddlSeleccionarSectorMantenimiento.SelectedValue));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rbRetensionNOMantenimiento.Checked = true;
                rbEstatusMantenimiento.Checked = true;
                rbIntermediarioNoDirecto.Checked = true;

                //MOSTRAR LOS TIPOS DE IDENTIFICACION
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoIdentificacionMantenimiento, ObjData.BuscaListas("TIPOIDENTIFICACION", null, null));

                MostrarPais();
                MostrarZonas();
                MostrarProvincias();
                MostrarMunicipios();
                MostrarSector();
                MostrarBarrio();
            }
        }

        protected void btnCOnsultarRegistros_Click(object sender, EventArgs e)
        {

        }

        protected void gvIntermediarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvIntermediarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarZonaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarProvincias();
            MostrarMunicipios();
            MostrarSector();
            MostrarBarrio();
        }

        protected void ddlSeleccionarProvinciaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMunicipios();
            MostrarSector();
            MostrarBarrio();
        }

        protected void ddlSeleccionarMunicipioMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarSector();
            MostrarBarrio();
        }

        protected void ddlSeleccionarSectorMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarBarrio();
        }
    }
}
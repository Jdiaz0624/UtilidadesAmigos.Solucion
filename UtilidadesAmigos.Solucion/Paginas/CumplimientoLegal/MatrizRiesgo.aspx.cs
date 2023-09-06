using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.CumplimientoLegal
{
    public partial class MatrizRiesgo : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

        #region LISTAS GENERALES
        private void CargarListas() {
            ListaTipoIdentificaciion();
            ListaTipoTercero();
            ListaNivelRiesto_TipoTercero();
            ListaArea();
            ListaNivelRiesto_Area();
            ListaPosiciion();
            ListaNivelRiesto_Posicion();
            ListanivelAcademico();
            ListaNivelRiesto_NivelAcademico();
            ListaPaisProcedencia();
            ListaNivelRiesto_PaisProcedencia();
            ListaPaisResidencia();
            ListaNivelRiesto_PaisResidencia();
            ListaProvincia();
            ListaNivelRiesto_Provincia();
            ListaSalarioDevengado();
            ListaNivelRiesto_SalarioDevengado();
            ListaPEP();
            ListaNivelRiesto_PEP();
            ListaTipoMonitoreo();
            TipoDebidaDiligencia();
            ListaNivelRiesto_NIVELRIESGOCONSOLIDADO();
            ListaNivelRiesto_ActividadSegundaria();
            ListaNivelRiesto_IngresosAdicionales();
            ListaNivelRiesto_PrimaAnual();
        }

        private void ListaTipoIdentificaciion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoIdentificacion_Matriz, ObjDataGeneral.Value.BuscaListas("TIPO_IDENTIFICACION_MATRIZ", null, null));
        }
        private void ListaTipoTercero() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoTercero_Matriz, ObjDataGeneral.Value.BuscaListas("TIPO_TERCERO_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_TipoTercero() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRIesgo_TipoRiesgo_MAtriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaArea()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlArea_Matriz, ObjDataGeneral.Value.BuscaListas("AREA_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_Area()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_Area_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaPosiciion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPocision_Matriz, ObjDataGeneral.Value.BuscaListas("POCISION_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_Posicion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_Posicion_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListanivelAcademico()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelAcademico_Matriz, ObjDataGeneral.Value.BuscaListas("NIVELACADEMICO_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_NivelAcademico()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_NivelAcademico_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaPaisProcedencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPaisProcedencia_Matriz, ObjDataGeneral.Value.BuscaListas("PAIS_PROCEDENCIA_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_PaisProcedencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_PaisProcedencia_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaPaisResidencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPaisResidencia_Matriz, ObjDataGeneral.Value.BuscaListas("PAIS_RESIDENCIA_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_PaisResidencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_PaisResidencia_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaProvincia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlProvincia_Matriz, ObjDataGeneral.Value.BuscaListas("PROVINCIA_MATRIZ", ddlPaisResidencia_Matriz.SelectedValue.ToString(), null));
        }
        private void ListaNivelRiesto_Provincia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_Provincia_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaSalarioDevengado()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSalarioDevengado_Matriz, ObjDataGeneral.Value.BuscaListas("SALARIO_DEVENGADO_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_SalarioDevengado()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgoSalarioDevengado, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaPEP()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPEP_Matriz, ObjDataGeneral.Value.BuscaListas("PEP_MATRIZ", null, null));
        }
        private void ListaNivelRiesto_PEP()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_PEP_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaTipoMonitoreo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoMonitoreo_Matriz, ObjDataGeneral.Value.BuscaListas("TIPO_MONITOREO_MATRIZ", null, null));
        }

        private void TipoDebidaDiligencia() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoDebidaDiligencia, ObjDataGeneral.Value.BuscaListas("TIPO_DEBIDA_DILIGENCIA_MATRIZ", null, null));

        }

        private void ListaNivelRiesto_NIVELRIESGOCONSOLIDADO()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_Consolidado_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaNivelRiesto_ActividadSegundaria()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_ActividaSegundaria, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaNivelRiesto_IngresosAdicionales()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_IngresosAdicionales_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }

        private void ListaNivelRiesto_PrimaAnual()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlNivelRiesgo_PrimaAnual_Matriz, ObjDataGeneral.Value.BuscaListas("NIVEL_RIESGO_MATRIZ", null, null));
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                DivBloqueConsulta.Visible = true;
                DIVBloqueMatriz.Visible = false;

                
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DIVBloqueMatriz.Visible = true;
            CargarListas();
            txtNombre_Matriz.Text = string.Empty;
            txtNumeroidentificacion.Text = string.Empty;
            txtActividadSegundaria_Matriz.Text = string.Empty;
            txtIngresosAdicionales.Text = string.Empty;
            txtPrimaAnual.Text = "0";
            txtObservaciones.Text = string.Empty;
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
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

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueConsulta.Visible = true;
            DIVBloqueMatriz.Visible = false;
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
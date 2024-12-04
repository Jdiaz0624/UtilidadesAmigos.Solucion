using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.MatrizRiezgo
{
    public partial class MatrizDeRiezgo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LISTAS DESPLEGABLES
        private void TipoIdentificcion() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoIdentificacion_Proceso, ObjDataComun.Value.BuscaListas("TIPOIDENTIFICCIONMATRIZ", null, null), true);
            if (ddlTipoIdentificacion_Proceso.SelectedValue != "-1")
            {
                txtNumeroIDentificcion_Proceso.Enabled = true;
                txtNumeroIDentificcion_Proceso.Focus();
            }
            else {
                txtNumeroIDentificcion_Proceso.Text = string.Empty;
                txtNumeroIDentificcion_Proceso.Enabled = false;
            }
           
        }

        enum TipoRiesgo { 
        
            Bajo=1,
            Medio=2,
            Alto=3
        }
        private void ValidaNivelRiezgo(ref DropDownList ddlControl, ref DropDownList ddlFiltro, string SegundoFiltro, string NombreLista) {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlControl, ObjDataComun.Value.BuscaListas(NombreLista, ddlFiltro.SelectedValue.ToString(), SegundoFiltro));



            try {
                int IdTipoRiesgo = ddlControl.SelectedValue != "-1" ? Convert.ToInt32(ddlControl.SelectedValue) : 0;

                switch (IdTipoRiesgo)
                {

                    case (int)TipoRiesgo.Bajo:
                        ddlControl.BorderColor = System.Drawing.Color.Green;
                        break;

                    case (int)TipoRiesgo.Medio:
                        ddlControl.BorderColor = System.Drawing.Color.Yellow;
                        break;

                    case (int)TipoRiesgo.Alto:
                        ddlControl.BorderColor = System.Drawing.Color.Red;
                        break;

                    case 0:
                        ddlControl.BorderColor = System.Drawing.Color.White;
                        break;
                }
            }
            catch (Exception) {
                ddlControl.BorderColor = System.Drawing.Color.White;
            }
           

        }


        private void Ramo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlProducto_Proceso, ObjDataComun.Value.BuscaListas("PRODUCTOMATRIZ", null, null), true);
        }

        private void SubRamo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubProducto_Proceso, ObjDataComun.Value.BuscaListas("SUBPRODUCTOMATRIZ", ddlProducto_Proceso.SelectedValue.ToString(), null), true);
            
        }

        private void CanalDistribucion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCanalDistribucion_Proceso, ObjDataComun.Value.BuscaListas("CANALDISTRIBUCIONMATRIZ", null, null), true);
        }

        private void PaisProcedencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPaisProcedencia_Proceso, ObjDataComun.Value.BuscaListas("PAISMATRIZPROCEDENCIA", null, null), true);
        }

        private void PaisResidencia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPaisResidencia_Proceso, ObjDataComun.Value.BuscaListas("PAISMATRIZPROCEDENCIA", null, null), true);
        }

        private void Provincia()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlProvincia_Proceso, ObjDataComun.Value.BuscaListas("PROVINCIAMATRIZ", ddlPaisResidencia_Proceso.SelectedValue.ToString(), null), true);
        }

        private void MontoRiesgo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlMontoRiezgo_Proceso, ObjDataComun.Value.BuscaListas("MONTORIEZGOMATRIZ", null, null), true);
        }
        private void ActividadEconomica()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlActividadEconomica_Proceso, ObjDataComun.Value.BuscaListas("ACTIVIDADECONOMICAMATRIZ", null, null), true);
        }

        private void PromedioIngresoAnual()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPromedioIngresoAnuales_Proceso, ObjDataComun.Value.BuscaListas("INGRESOANUALMATRIZ", null, null), true);
        }
        private void PEP()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPersonaPEP_Proceso, ObjDataComun.Value.BuscaListas("PEPMATRIZ", null, null), true);
        }

        private void PRIMAANUAL()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPrimaAnual_Proceso, ObjDataComun.Value.BuscaListas("PRIMAANUALMATRIZ", null, null), true);
        }

        private void TIPOMONITOREO()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoMonitoreo_Proceso, ObjDataComun.Value.BuscaListas("TIPOMONITOREO", null, null));
        }
        private void TIPODEBIDADILIGENCIA()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoDebidaDiligencia_Proceso, ObjDataComun.Value.BuscaListas("TIPODEBIDADILIGENCIA", null, null));
        }

        #endregion

        private void ConfiguracionInicial() {
            txtNumeroIDentificcion_Proceso.Enabled = false;

            TipoIdentificcion();
            Ramo();
            SubRamo();
            CanalDistribucion();
            PaisProcedencia();
            PaisResidencia();
            Provincia();
            MontoRiesgo();
            ActividadEconomica();
            PromedioIngresoAnual();
            PEP();
            PRIMAANUAL();
            TIPOMONITOREO();
            TIPODEBIDADILIGENCIA();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "MATRIZ DE RIESGO";

                ConfiguracionInicial();
            }
        }

        enum TipoIdentificaiom { 
        
            Cedula=1,
            RNC=2,
            Pasaporte=3
        }
        protected void ddlTipoIdentificacion_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoIdentificacion_Proceso.SelectedValue != "-1")
            {
                txtNumeroIDentificcion_Proceso.Text = string.Empty;
                txtNumeroIDentificcion_Proceso.Enabled = true;
                txtNumeroIDentificcion_Proceso.Focus();
                int TipoIdentificacion = Convert.ToInt32(ddlTipoIdentificacion_Proceso.SelectedValue);

                switch (TipoIdentificacion) {

                    case (int)TipoIdentificaiom.Cedula:
                        MascaraCedula.Enabled = true;
                        MascaraRNC.Enabled = false;
                        break;

                    case (int)TipoIdentificaiom.RNC:
                        MascaraCedula.Enabled = false;
                        MascaraRNC.Enabled = true;
                        break;

                    case (int)TipoIdentificaiom.Pasaporte:
                        MascaraCedula.Enabled = false;
                        MascaraRNC.Enabled = false;
                        break;
                }
                
            }
            else
            {
                txtNumeroIDentificcion_Proceso.Text = string.Empty;
                txtNumeroIDentificcion_Proceso.Enabled = false;
            }
        }

        protected void ddlProducto_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoProducto_Proceso, ref ddlProducto_Proceso,null, "NIVEL_PRODUCTOMATRIZ");
            SubRamo();
        }

        protected void ddlSubProducto_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoSubProducto_Proceso, ref ddlProducto_Proceso, ddlSubProducto_Proceso.SelectedValue.ToString(), "NIVEL_SUBPRODUCTOMATRIZ");
        }

        protected void ddlCanalDistribucion_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoCanalDistribucion_Proceso, ref ddlCanalDistribucion_Proceso, null, "NIVEL_CANALDISTRIBUCIONMATRIZ");
        }

        protected void ddlPaisProcedencia_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoPaisProcedencia_Proceso, ref ddlPaisProcedencia_Proceso, null, "NIVEL_PAISMATRIZPROCEDENCIA");
        }

        protected void ddlPaisResidencia_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoPaisResidencia_Proceso, ref ddlPaisResidencia_Proceso, null, "NIVEL_PAISMATRIZPROCEDENCIA");
            Provincia();
        }

        protected void ddlProvincia_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoProvincia_Proceso, ref ddlProvincia_Proceso, ddlPaisResidencia_Proceso.SelectedValue.ToString(), "NIVEL_PROVINCIAMATRIZ");
        }

        protected void ddlMontoRiezgo_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoMontoRiesgo_Proceso, ref ddlMontoRiezgo_Proceso, null, "NIVEL_MONTORIEZGOMATRIZ");
        }

        protected void ddlActividadEconomica_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoActividadEconomica_Proceso, ref ddlActividadEconomica_Proceso, null, "NIVEL_ACTIVIDADECONOMICAMATRIZ");
        }

        protected void ddlPromedioIngresoAnuales_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoPromedioIngresoAnuales, ref ddlPromedioIngresoAnuales_Proceso, null, "NIVEL_INGRESOANUALMATRIZ");
        }

        protected void ddlPersonaPEP_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgoPersonaPEP_Proceso, ref ddlPersonaPEP_Proceso, null, "NIVEL_PEPMATRIZ");
        }

        protected void ddlPrimaAnual_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaNivelRiezgo(ref ddlNivelRiesgo_PrimaAnual_Proceso, ref ddlPrimaAnual_Proceso, null, "NIVEL_PRIMAANUALMATRIZ");
        }

        protected void btnCompletar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSubProducto_Proceso2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
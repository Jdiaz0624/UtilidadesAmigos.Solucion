using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    
    public partial class GenerarSolicitudChequeComisionesIntermediarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObjDataMantenimientos = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarListasDesplegables() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarBanco, ObjDataGeneral.Value.BuscaListas("LISTADOBANCOS", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjDataGeneral.Value.BuscaListas("OFICINANORMAL", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataGeneral.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion

        /// <summary>
        /// Este metodo es para consultar los registros y mostrarlo en pantalla dependiendo de ls filtros colocados
        /// </summary>
        private void ConsultarInformacionPantalla() {

            //ELIMINAMOS LOS REGISTROS MEDIANTE EL CODIGO DEL USUARIO CONECTADO
            decimal IdUsuario = Session["IdUsuario"] != null ? (decimal)Session["Idusuario"] : 0;

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionConsultaInformacionPrPantalla(
                IdUsuario, 0, 0, 0, 0, "DELETE");
            Eliminar.ProcesarInformacion();

            int CodigoIntermediario = 0, CodigoBAnco = 0;
            decimal Monto = 0, Acumulado = 0;
            //BUSCAMOS LA INFORMACION Y LA GUARDAMOS DEPENDIENDO SI ES EN LOTE O NORMAL
            if (cbGenerarSolicitudPorLote.Checked == false) {

                if (cbTomarCuentaMontosAcmulativos.Checked == false) {
                    var BuscarInformacionComisiones = ObjDataGeneral.Value.GenerarComisionIntermediario(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        null, null, null, null, null, null, null, null, IdUsuario);
                    foreach (var n in BuscarInformacionComisiones) {
                        CodigoIntermediario = (int)n.Codigo;
                        //   CodigoBAnco = (int)n.codi
                        Monto = (decimal)n.ALiquidar;
                    }
                }
                else if(cbTomarCuentaMontosAcmulativos.Checked==true) { 
                
                }
            }
            else if(cbGenerarSolicitudPorLote.Checked==true) { }



        }
        /// <summary>
        /// Este metodo es para exportar la informacion a excel dependiendo de los filtros colocados
        /// </summary>
        private void ExportarInformacionExcel() { }

        /// <summary>
        /// Este metodo es para generar las solicitudes de cheques dependiendo de los filtros colocados
        /// </summary>
        private void ProcesarInformacionSOlicitudChqeue() { }
  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //SACAMOS EL NOMBRE DE USUARIO Y EL NOMBRE DE LA PANTALLA EN LA QUE ESTAMOS
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuarioConectado.Text = Nombre.SacarNombreUsuarioConectado();
                Label lbNombrePantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantallaActual.Text = "GENERAR SOLICITUD DE CHEQUES";

                CargarListasDesplegables();
                rbNoEndosable.Checked = true;
                txttasa.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
                txtMontoMinimo.Text = "500";
            }
        }

        protected void cbGenerarSolicitudPorLote_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGenerarSolicitudPorLote.Checked == true) {
                lbLetreroRojo.Visible = true;
                txtCodigoIntermediario.Enabled = false;
                txtCodigoIntermediario.Text = "00000";
            }
            else if (cbGenerarSolicitudPorLote.Checked == false) {
                lbLetreroRojo.Visible = false;
                txtCodigoIntermediario.Enabled = true;
                txtCodigoIntermediario.Text = string.Empty;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ExportarInformacionExcel();
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ProcesarInformacionSOlicitudChqeue();
            }
        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            }
        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {
                ConsultarInformacionPantalla();
            
            }
        }

        protected void btnSeleccionarSeleccionarRegistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {
                ConsultarInformacionPantalla();

            }
        }
    }
}
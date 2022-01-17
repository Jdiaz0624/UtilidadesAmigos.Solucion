using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class EstadisticaRenovacion : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarOficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjDataComun.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }

        private void CargarRamos() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataComun.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubramo, ObjDataComun.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamo.SelectedValue.ToString(), null), true);
        }
        #endregion

        #region PROCESO DE CARGA DE INFORMACION
        private void CargarInformacion() {

            decimal IdUsuario = (decimal)Session["IdUsuario"];
            //ELIMINAMOS DATOS
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion(
                IdUsuario, 0, 0, "", 0, 0, "", 0, "", 0, DateTime.Now, DateTime.Now, 0, 0, 0,0,0,0,0,0, DateTime.Now, DateTime.Now, "DELETE");
            Eliminar.ProcesarInformacion();

            //BUSCAMOS LA INFORMACION A PROCESAR
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {

                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true); }
            }
            else {

                int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubramo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramo.SelectedValue) : new Nullable<int>();
                int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
                int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
                decimal? _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoCliente.Text);
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                bool ExcluirMotores = cbExcluirMotores.Checked;

                var BuscarInformacion = ObjDataConsulta.Value.BuscaEstadisticaRenovacionOrigen(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Oficina,
                    _Ramo,
                    _SubRamo,
                    _Intermediario,
                    _Supervisor,
                    _Cliente,
                    _Poliza,
                    ExcluirMotores);
                if (BuscarInformacion.Count() < 1) { ClientScript.RegisterStartupScript(GetType(), "CamposNoEncontrados()", "CamposNoEncontrados();", true); }
                else {

                    foreach (var n in BuscarInformacion) {

                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion(
                            IdUsuario,
                            (decimal)n.Cotizacion,
                            (int)n.Secuencia,
                            n.Poliza,
                            (int)n.CodigoOficina,
                            (int)n.CodigoRamo,
                            n.NombreRamo,
                            (int)n.CodigoSubramo,
                            n.NombreSubramo,
                            (decimal)n.Bruto,
                            (DateTime)n.FechaInicioVigencia,
                            (DateTime)n.FechaFinVigencia,
                            (int)n.CodigoIntermediario,
                            (int)n.CodigoSupervisor,
                            (decimal)n.CodigoCliente,
                            (int)n.CantidadRenovadas,
                            (decimal)n.MontoRenovado,
                            (int)n.CantidadCanceladas,
                            (decimal)n.MontoCancelado,
                            (decimal)n.Cobrado,
                            (DateTime)n.ValidadoDesde,
                            (DateTime)n.ValidadoHasta,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }
                }
            }
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
                lbPantalla.Text = "ESTADISTICA DE RENOVACION";


                CargarOficinas();
                CargarRamos();
                CargarSubRamo();

                rbPDF.Checked = true;
                rbNoAgrupar.Checked = true;
                cbExcluirMotores.Checked = false;               
            }
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = Nombre.SacarNombreIntermediario();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente Nombre = new Logica.Comunes.ESacarNombreCliente(txtCodigoCliente.Text);
            txtNombreCliente.Text = Nombre.SacarCodigoCLiente();
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarInformacion();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            CargarInformacion();
        }

        protected void btnkPrimeraPaginaEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAnteriorEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionEstadisticaRenovacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionEstadisticaRenovacion_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguienteEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimoEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSeleccionarRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubRamo();
        }

        protected void cbExcluirMotores_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExcluirMotores.Checked == true) {

                ddlSeleccionarRamo.Enabled = false;
                ddlSeleccionarSubramo.Enabled = false;
            }
            else if (cbExcluirMotores.Checked == false) {
                ddlSeleccionarRamo.Enabled = true;
                ddlSeleccionarSubramo.Enabled = true;
            }
        }
    }
}
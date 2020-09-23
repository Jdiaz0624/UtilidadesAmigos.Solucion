using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoPorcientoComisionPorDefecto : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObjData = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR Y OCULTAR CONTROLES
        private void OcultarControles() {
            lbTipoPrceso.Visible = false;
            rbModificarSubRamoSeleccionadoMantenimiento.Visible = false;
            rbModificarTodoRamoSeleccionado.Visible = false;
            lbCodigoRamoMantenimiento.Visible = false;
            txtCodigoRamoMantenimiento.Visible = false;
            lbDescripcionRamomantenimiento.Visible = false;
            txtDescripcionRamoMantenimiento.Visible = false;
            lbCodigoSubRamoMantenimiento.Visible = false;
            txtCodigoSubramoMantenimiento.Visible = false;
            lbDescripcionSubramoMantenimiento.Visible = false;
            txtDescripcionSubramoMantenimiento.Visible = false;
            lbPorcientoComisionMantenimiento.Visible = false;
            txtPorcientoComision.Visible = false;
            lbClaveSeguridad.Visible = false;
            txtClaveSeguridad.Visible = false;
            btnProcesar.Visible = false;
            btnVolver.Visible = false;

            gvEmpleados.Visible = true;
            btnConsultar.Visible = true;
            txtDescripcionSubramoConsulta.Visible = true;
            lbDescripcionSunramoConsulta.Visible = true;
            txtCodigoSubramoConsulta.Visible = true;
            lbCodigoSubramoConsulta.Visible = true;
            txtDescripcionRamoConsulta.Visible = true;
            lbDescripcionRamoConsulta.Visible = true;
            txtCodigoRamoConsulta.Visible = true;
            lbCodigoRamoConsulta.Visible = true;
        }
        private void MostrarControles() {
            lbTipoPrceso.Visible = true;
            rbModificarSubRamoSeleccionadoMantenimiento.Visible = true;
            rbModificarTodoRamoSeleccionado.Visible = true;
            lbCodigoRamoMantenimiento.Visible = true;
            txtCodigoRamoMantenimiento.Visible = true;
            lbDescripcionRamomantenimiento.Visible = true;
            txtDescripcionRamoMantenimiento.Visible = true;
            lbCodigoSubRamoMantenimiento.Visible = true;
            txtCodigoSubramoMantenimiento.Visible = true;
            lbDescripcionSubramoMantenimiento.Visible = true;
            txtDescripcionSubramoMantenimiento.Visible = true;
            lbPorcientoComisionMantenimiento.Visible = true;
            txtPorcientoComision.Visible = true;
            lbClaveSeguridad.Visible = true;
            txtClaveSeguridad.Visible = true;
            btnProcesar.Visible = true;
            btnVolver.Visible = true;

            gvEmpleados.Visible = false;
            btnConsultar.Visible = false;
            txtDescripcionSubramoConsulta.Visible = false;
            lbDescripcionSunramoConsulta.Visible = false;
            txtCodigoSubramoConsulta.Visible = false;
            lbCodigoSubramoConsulta.Visible = false;
            txtDescripcionRamoConsulta.Visible = false;
            lbDescripcionRamoConsulta.Visible = false;
            txtCodigoRamoConsulta.Visible = false;
            lbCodigoRamoConsulta.Visible = false;
        }
        private void LimpiarControles() {
            txtCodigoRamoConsulta.Text = string.Empty;
            txtCodigoSubramoConsulta.Text = string.Empty;
            txtDescripcionRamoConsulta.Text = string.Empty;
            txtDescripcionSubramoConsulta.Text = string.Empty;
            txtCodigoRamoMantenimiento.Text = string.Empty;
            txtDescripcionRamoMantenimiento.Text = string.Empty;
            txtCodigoSubramoMantenimiento.Text = string.Empty;
            txtDescripcionSubramoMantenimiento.Text = string.Empty;
            txtPorcientoComision.Text = string.Empty;
            txtClaveSeguridad.Text = string.Empty;
            rbModificarSubRamoSeleccionadoMantenimiento.Checked = true;
            Session["IdRegistroComision"] = null;
            ConsultarRegistros();
        }
        #endregion
        #region CONSULTAR REGISTROS 
        private void ConsultarRegistros() {
            string _Ramo = string.IsNullOrEmpty(txtCodigoRamoConsulta.Text.Trim()) ? null : txtCodigoRamoConsulta.Text.Trim();
            string _Subramo = string.IsNullOrEmpty(txtCodigoSubramoConsulta.Text.Trim()) ? null : txtCodigoSubramoConsulta.Text.Trim();

            var BuscarRegistros = ObjData.Value.BuscaComisionesPorDefecto(
                new Nullable<decimal>(),
                _Ramo,
                _Subramo);
            gvEmpleados.DataSource = BuscarRegistros;
            gvEmpleados.DataBind();
        }
        #endregion
        #region PROCESAR INFORMACION COMISIONES POR DEFECTO
        private void ProcesarinformacionComsiionPorDefecto(decimal IdRegistro, int Ramo, int SubRamo,string Accion) {
            try {
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionPorcientoComisionesPorDefecto Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionPorcientoComisionesPorDefecto(
                    IdRegistro,
                    Ramo,
                    SubRamo,
                    Convert.ToDecimal(txtPorcientoComision.Text),
                    Accion);
                Procesar.ProcesarInformacion();
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorMantenimiento()", "ErrorMantenimiento();", true);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rbModificarSubRamoSeleccionadoMantenimiento.Checked = true;
                ConsultarRegistros();
            }
        }

        protected void txtCodigoRamoConsulta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoRamoConsulta.Text.Trim())) {
                txtDescripcionRamoConsulta.Text = string.Empty;
            }
            else {
                var SacarDescripcionRamo = ObjData.Value.BuscaComisionesPorDefecto(
               new Nullable<decimal>(),
               txtCodigoRamoConsulta.Text,
               null);
                if (SacarDescripcionRamo.Count() < 1) { txtDescripcionRamoConsulta.Text = string.Empty; }
                else {
                    foreach (var n in SacarDescripcionRamo)
                    {
                        txtDescripcionRamoConsulta.Text = n.Ramo;
                    }
                }
            }
        }

        protected void txtCodigoSubramoConsulta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoRamoConsulta.Text.Trim()) && string.IsNullOrEmpty(txtCodigoSubramoConsulta.Text.Trim())) { txtDescripcionSubramoConsulta.Text = string.Empty; }
            else
            {
                var SacarDescripcionSubramo = ObjData.Value.BuscaComisionesPorDefecto(
               new Nullable<decimal>(),
               txtCodigoRamoConsulta.Text,
               txtCodigoSubramoConsulta.Text);
                if (SacarDescripcionSubramo.Count() < 1) { txtDescripcionSubramoConsulta.Text = string.Empty; }
                else {
                    foreach (var n in SacarDescripcionSubramo)
                    {
                        txtDescripcionSubramoConsulta.Text = n.Subramo;
                    }
                }
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarRegistros();
        }

      

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;
            ConsultarRegistros();
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //VALIDAMOS LA CLAVE DE SEGURIDAD
            string _ClaveIngresada = string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()) ? null : txtClaveSeguridad.Text.Trim();

            var ValidarClave = ObjdataGeneral.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveIngresada));
            if (ValidarClave.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida()", "ClaveSeguridadNoValida();", true);
            }
            else {
                if (Session["IdRegistroComision"] != null) {
                    if (rbModificarSubRamoSeleccionadoMantenimiento.Checked)
                    {
                        ProcesarinformacionComsiionPorDefecto(
                            Convert.ToDecimal(Session["IdRegistroComision"]),
                            Convert.ToInt32(txtCodigoRamoMantenimiento.Text),
                            Convert.ToInt32(txtCodigoSubramoMantenimiento.Text),
                            "UPDATE");
                     
                    }
                    else
                    {
                        ProcesarinformacionComsiionPorDefecto(
                            Convert.ToDecimal(Session["IdRegistroComision"]),
                            Convert.ToInt32(txtCodigoRamoMantenimiento.Text),
                            Convert.ToInt32(txtCodigoSubramoMantenimiento.Text),
                            "UPDATEALL");
                    }
                    LimpiarControles();
                    OcultarControles();
                }
             
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OcultarControles();
        }

        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvEmpleados.SelectedRow;
            Session["IdRegistroComision"] = gv.Cells[1].Text;
            var SeleccionarRegistro = ObjData.Value.BuscaComisionesPorDefecto(
                Convert.ToDecimal(gv.Cells[1].Text),
                null, null);
            foreach (var n in SeleccionarRegistro)
            {
                txtCodigoRamoMantenimiento.Text = n.CodRamo.ToString();
                txtDescripcionRamoMantenimiento.Text = n.Ramo;
                txtCodigoSubramoMantenimiento.Text = n.CodSubramo.ToString();
                txtDescripcionSubramoMantenimiento.Text = n.Subramo;
                txtPorcientoComision.Text = n.PorcientoComision.ToString();
                MostrarControles();
            }
        }
    }
}
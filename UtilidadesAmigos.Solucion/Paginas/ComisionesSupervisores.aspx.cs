using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ComisionesSupervisores : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region BUSCAR LOS DATOS DEL INTERMEDIARIO
        private void BuscarDatosSupervisor() {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _NombreVendedor = string.IsNullOrEmpty(txtNombreSupervisor.Text.Trim()) ? null : txtNombreSupervisor.Text.Trim();

            var BuscarRegistros = ObjData.Value.BuscaInformacionSUperisor(
                _CodigoSupervisor,
                _NombreVendedor);
            gvInformacionSupervisor.DataSource = BuscarRegistros;
            gvInformacionSupervisor.DataBind();
        }
        #endregion
        #region MOSTRAR LOS CODIGOS PERMITIDOS
        private void MostrarCodigospermitidos() {
            var MostrarCodigospermitidos = ObjData.Value.BuscarCodigosSupervisoresPermitidos(
                new Nullable<decimal>(),
                null, null, null, null);
            gvCodigosPermitidos.DataSource = MostrarCodigospermitidos;
            gvCodigosPermitidos.DataBind();
        }
        #endregion
        #region MANTENIMIENTO CODIGOS PERMITIDOS
        private void MANCodigoPermitidos(decimal IdRegistro, decimal CodigoSupervisor, string Accion) {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionCodigosSupervisoresPermitidos Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionCodigosSupervisoresPermitidos(
                IdRegistro, CodigoSupervisor, Convert.ToDecimal(Session["IdUsuario"]), Accion);
            Procesar.ProcesarInformacion();
            MostrarCodigospermitidos();
            btnGuardarDato.Enabled = true;
            btnEliminarDato.Enabled = false;
            Restablecer();
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarListasDesplegables() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalConsulta, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaConsulta, ObjData.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue, null), true);
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS COMISIONES DE LOS SUPERVISORES
        private void ConsultarComisionesSupervisores() {
            if (string.IsNullOrEmpty(txtFechaDesdeConsulta.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaConsulta.Text.Trim()))
            {
                //CAMPOS VACIOS
            }
            else
            {
                string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
                int? _Oficina = ddlSeleccionaroficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaConsulta.SelectedValue) : new Nullable<int>();

                var Consultar = ObjData.Value.ComisionesSupervisores(
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHastaConsulta.Text),
                    _CodigoSupervisor,
                    _Oficina);
                gvComisionSupervisor.DataSource = Consultar;
                gvComisionSupervisor.DataBind();
            }
        }
        #endregion

        private void Restablecer() {
            //MOSTRAMOS LOS CONTROLES
            lbCodigoSupervisorMantenimientio.Visible = false;
            txtCodigoSupervisorMantenimiento.Visible = false;
            lbNombreSupervisorMantenimiento.Visible = false;
            txtNombreSupervisorMantenimientio.Visible = false;
            lbOficinaSupervisorMantenimiento.Visible = false;
            txtOficinaSupervisorMantenimienti.Visible = false;
            lbEstatusSupervisorMantenimiento.Visible = false;
            txtEstatusSupervisirMantenimiento.Visible = false;
            btnGuardarDato.Visible = false;
            btnEliminarDato.Visible = false;
            btnRestablecer.Visible = false;
            txtCodigoSupervisor.Text = string.Empty;
            txtNombreSupervisor.Text = string.Empty;

            //LIMPIAMOS LOS CTROLES
            txtCodigoSupervisorMantenimiento.Text = string.Empty;
            txtNombreSupervisorMantenimientio.Text = string.Empty;
            txtOficinaSupervisorMantenimienti.Text = string.Empty;
            txtEstatusSupervisirMantenimiento.Text = string.Empty;
            MostrarCodigospermitidos();
            gvInformacionSupervisor.DataSource = null;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                MostrarCodigospermitidos();
                CargarListasDesplegables();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnConsultarComisiones_Click(object sender, EventArgs e)
        {
            ConsultarComisionesSupervisores();
        }

        protected void btnExortarComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnReporteCOmisiones_Click(object sender, EventArgs e)
        {

        }

        protected void gvComisionSupervisor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvComisionSupervisor.PageIndex = e.NewPageIndex;
            ConsultarComisionesSupervisores();
        }

        protected void btnValidarClaveSeguridad_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarRegistros_Click(object sender, EventArgs e)
        {
            BuscarDatosSupervisor();
        }

        protected void gvInformacionSupervisor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCodigosPermitidos.PageIndex = e.NewPageIndex;
            BuscarDatosSupervisor();
        }

        protected void gvInformacionSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadVacia()", "ClaveSeguridadVacia();", true);
            }
            else {
                //VALIDAMOS LA CLAVE
                string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()) ? null : txtClaveSeguridad.Text.Trim();

                var ValidarClave = ObjData.Value.BuscaClaveSeguridad(
                    new Nullable<decimal>(),
                    UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridad));
                if (ValidarClave.Count() < 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ClaveIngresadanoValida()", "ClaveIngresadanoValida();", true);
                }
                else {
                    GridViewRow gb = gvInformacionSupervisor.SelectedRow;


                    var SeleccionarRegistros = ObjData.Value.BuscaInformacionSUperisor(gb.Cells[0].Text);
                    if (SeleccionarRegistros.Count() < 1) { }
                    else
                    {

                        //MOSTRAMOS LOS CONTROLES
                        lbCodigoSupervisorMantenimientio.Visible = true;
                        txtCodigoSupervisorMantenimiento.Visible = true;
                        lbNombreSupervisorMantenimiento.Visible = true;
                        txtNombreSupervisorMantenimientio.Visible = true;
                        lbOficinaSupervisorMantenimiento.Visible = true;
                        txtOficinaSupervisorMantenimienti.Visible = true;
                        lbEstatusSupervisorMantenimiento.Visible = true;
                        txtEstatusSupervisirMantenimiento.Visible = true;
                        btnGuardarDato.Visible = true;
                        btnEliminarDato.Visible = true;
                        btnRestablecer.Visible = true;

                        //LIMPIAMOS LOS CTROLES
                        txtCodigoSupervisorMantenimiento.Text = String.Empty;
                        txtNombreSupervisorMantenimientio.Text = String.Empty;
                        txtOficinaSupervisorMantenimienti.Text = String.Empty;
                        txtEstatusSupervisirMantenimiento.Text = String.Empty;
                        btnGuardarDato.Enabled = true;
                        btnEliminarDato.Enabled = false;
                        foreach (var n in SeleccionarRegistros)
                        {
                            txtCodigoSupervisorMantenimiento.Text = n.Codigo.ToString();
                            txtNombreSupervisorMantenimientio.Text = n.Nombre;
                            txtOficinaSupervisorMantenimienti.Text = n.Oficina;
                            txtEstatusSupervisirMantenimiento.Text = n.Estatus;
                        }
                    }
                }
            }
          
        }

        protected void gvCodigosPermitidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCodigosPermitidos.PageIndex = e.NewPageIndex;
            MostrarCodigospermitidos();
        }

        protected void gvCodigosPermitidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MOSTRAMOS LOS CONTROLES
            lbCodigoSupervisorMantenimientio.Visible = true;
            txtCodigoSupervisorMantenimiento.Visible = true;
            lbNombreSupervisorMantenimiento.Visible = true;
            txtNombreSupervisorMantenimientio.Visible = true;
            lbOficinaSupervisorMantenimiento.Visible = true;
            txtOficinaSupervisorMantenimienti.Visible = true;
            lbEstatusSupervisorMantenimiento.Visible = true;
            txtEstatusSupervisirMantenimiento.Visible = true;
            btnGuardarDato.Visible = true;
            btnEliminarDato.Visible = true;
            btnRestablecer.Visible = true;

            //LIMPIAMOS LOS CTROLES
            txtCodigoSupervisorMantenimiento.Text = String.Empty;
            txtNombreSupervisorMantenimientio.Text = String.Empty;
            txtOficinaSupervisorMantenimienti.Text = String.Empty;
            txtEstatusSupervisirMantenimiento.Text = String.Empty;
            btnGuardarDato.Enabled = true;
            btnEliminarDato.Enabled = false;

            GridViewRow Gb = gvCodigosPermitidos.SelectedRow;

            var SeleccionarRegistro = ObjData.Value.BuscarCodigosSupervisoresPermitidos(
                Convert.ToDecimal(Gb.Cells[0].Text), null, null, null, null);
            gvCodigosPermitidos.DataSource = SeleccionarRegistro;
            gvCodigosPermitidos.DataBind();
            foreach (var n in SeleccionarRegistro) {
                Session["IdMantenimiento"] = n.IdRegistro;
                txtCodigoSupervisorMantenimiento.Text = n.CodigoSupervisor.ToString();
                txtNombreSupervisorMantenimientio.Text = n.Nombre;
            }
            btnGuardarDato.Enabled = false;
            btnEliminarDato.Enabled = true;

            btnGuardarDato.Visible = true;
            btnEliminarDato.Visible = true;
            btnRestablecer.Visible = true;


        }

        protected void btnGuardarDato_Click(object sender, EventArgs e)
        {
            var ValidarCodigo = ObjData.Value.BuscarCodigosSupervisoresPermitidos(
                new Nullable<decimal>(),
                Convert.ToDecimal(txtCodigoSupervisorMantenimiento.Text), null, null, null);
            if (ValidarCodigo.Count() < 1) {
                MANCodigoPermitidos(0, Convert.ToDecimal(txtCodigoSupervisorMantenimiento.Text), "INSERT");
            }
           
        }

        protected void btnEliminarDato_Click(object sender, EventArgs e)
        {
            MANCodigoPermitidos(Convert.ToDecimal(Session["IdMantenimiento"]), Convert.ToDecimal(txtCodigoSupervisorMantenimiento.Text), "DELETE");
            Session["IdMantenimiento"] = null;

        }


        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            Restablecer();

        }

        protected void ddlSeleccionarSucursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaConsulta, ObjData.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue, null), true);
        }
    }
}
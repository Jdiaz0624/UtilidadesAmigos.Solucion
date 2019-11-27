using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{//decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
    
    public partial class AsignacionTarjetas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LOS DROP 
        private void CargarDropConsulta()
        {
            //CARGAMOS LAS OFICINAS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjData.Value.BuscaListas("OFICINA", null, null), true);
            //CARGAMOS LOS DEPARTAMENTOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
            //CARGAMOS LOS ESTATUS DE TARJETAS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatustarjetaConsulta, ObjData.Value.BuscaListas("ESTATUSTARJETA", null, null), true);
        }
        private void CargarDropMantenimiento()
        {
            //CARGAMOS LAS OFICINAS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjData.Value.BuscaListas("OFICINA", null, null));
            //CARGAMOS LOS DEPARTAMENTOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoMantenimiento, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaMantenimiento.SelectedValue, ddlDepartamentoMantenimiento.SelectedValue));
            //CARGAMOS LOS ESTATUS DE TARJETAS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatus, ObjData.Value.BuscaListas("ESTATUSTARJETA", null, null));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LAS TARJETAS DE ACCESO
        private void MostrarListadoTarjetas()
        {
            decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Empleado = ddlEmpleadoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlEmpleadoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Estatus = ddlSeleccionarEstatustarjetaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlSeleccionarEstatustarjetaConsulta.SelectedValue) : new Nullable<decimal>();
            string _NumeroTarjeta = string.IsNullOrEmpty(txtNumerotarjetaConsulta.Text.Trim()) ? null : txtNumerotarjetaConsulta.Text.Trim();

            if (cbFiltrarPorRangoFechaConsulta.Checked)
            {
                try {
                    var Listado = ObjData.Value.BuscaTarjetaAcceso(
             _Oficina,
             _Departamento,
             _Empleado,
             new Nullable<decimal>(),
             _Estatus,
             _NumeroTarjeta,
             Convert.ToDateTime(txtFechaDesdeConsulta.Text),
             Convert.ToDateTime(txtFechaHastaConsulta.Text));
                    gvTarjetaAcceso.DataSource = Listado;
                    gvTarjetaAcceso.DataBind();
                }
                catch (Exception) { }
            }
            else
            {
                var Listado = ObjData.Value.BuscaTarjetaAcceso(
             _Oficina,
             _Departamento,
             _Empleado,
             new Nullable<decimal>(),
             _Estatus,
             _NumeroTarjeta,
             null,
             null);
                gvTarjetaAcceso.DataSource = Listado;
                gvTarjetaAcceso.DataBind();
            }
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void MostrarControles()
        {
            lbOficinaConsulta.Visible = false;
            ddlOficinaConsulta.Visible = false;
            lbDepartamentoConsulta.Visible = false;
            ddlDepartamentoConsulta.Visible = false;
            lbEmpleadoConsulta.Visible = false;
            ddlEmpleadoConsulta.Visible = false;
            lbEstatustarjetaConsulta.Visible = false;
            ddlSeleccionarEstatustarjetaConsulta.Visible = false;
            lbNumeroTarjetaConsulta.Visible = false;
            txtNumerotarjetaConsulta.Visible = false;
            cbFiltrarPorRangoFechaConsulta.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            btnAtras.Visible = false;
            btnModificar.Visible = false;
            btnDeshabilitar.Visible = false;
            btnExportar.Visible = false;
            gvTarjetaAcceso.Visible = false;


            lbOficinaMantenimiento.Visible = true;
            ddlOficinaMantenimiento.Visible = true;
            lbDepartamentoMantenimiento.Visible = true;
            ddlDepartamentoMantenimiento.Visible = true;
            lbEmpleadoMantenimiento.Visible = true;
            ddlEmpleadoMantenimiento.Visible = true;
            lbSecuenciaInterna.Visible = true;
            txtSecuenciaInterna.Visible = true;
            lbNumeroTarjetraMantenimiento.Visible = true;
            txtNumerotarjetaMantenimiento.Visible = true;
            lbFechaEntregaMantenimiento.Visible = true;
            txtFechaEntregaMantenimiento.Visible = true;
            lbEstatus.Visible = true;
            ddlEstatus.Visible = true;
            btnGuardarMantenimiento.Visible = true;
            btnAtrasMantenimiento.Visible = true;
            lbClaveSeguridad.Visible = true;
            txtClaveSeguridad.Visible = true;

            if (lbAccion.Text != "INSERT")
            {
                var SacarDatos = ObjData.Value.BuscaTarjetaAcceso(
                    null, null, null, Convert.ToDecimal(lbIdMantenimiento.Text), null, null, null, null);
                foreach (var n in SacarDatos)
                {
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjData.Value.BuscaListas("OFICINA", null, null));
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.Value.ToString());
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamentoMantenimiento, n.IdDepartamento.Value.ToString());
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoMantenimiento, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaMantenimiento.SelectedValue, ddlDepartamentoMantenimiento.SelectedValue));
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlEmpleadoMantenimiento, n.IdEmpleado.Value.ToString());
                    txtSecuenciaInterna.Text = n.SecuenciaInterna;
                    txtNumerotarjetaMantenimiento.Text = n.NumeroTarjeta;
                    txtFechaEntregaMantenimiento.Text = n.FechaEntrega0.ToString();
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlEstatus, n.Estatus0.Value.ToString());
                }
            }
        }

        private void OcultarControles()
        {
            lbOficinaConsulta.Visible = true;
            ddlOficinaConsulta.Visible = true;
            lbDepartamentoConsulta.Visible = true;
            ddlDepartamentoConsulta.Visible = true;
            lbEmpleadoConsulta.Visible = true;
            ddlEmpleadoConsulta.Visible = true;
            lbEstatustarjetaConsulta.Visible = true;
            ddlSeleccionarEstatustarjetaConsulta.Visible = true;
            lbNumeroTarjetaConsulta.Visible = true;
            txtNumerotarjetaConsulta.Visible = true;
            cbFiltrarPorRangoFechaConsulta.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            btnAtras.Visible = true;
            btnModificar.Visible = true;
            btnDeshabilitar.Visible = true;
            btnExportar.Visible = true;
            gvTarjetaAcceso.Visible = true;


            lbOficinaMantenimiento.Visible = false;
            ddlOficinaMantenimiento.Visible = false;
            lbDepartamentoMantenimiento.Visible = false;
            ddlDepartamentoMantenimiento.Visible = false;
            lbEmpleadoMantenimiento.Visible = false;
            ddlEmpleadoMantenimiento.Visible = false;
            lbSecuenciaInterna.Visible = false;
            txtSecuenciaInterna.Visible = false;
            lbNumeroTarjetraMantenimiento.Visible = false;
            txtNumerotarjetaMantenimiento.Visible = false;
            lbFechaEntregaMantenimiento.Visible = false;
            txtFechaEntregaMantenimiento.Visible = false;
            lbEstatus.Visible = false;
            ddlEstatus.Visible = false;
            btnGuardarMantenimiento.Visible = false;
            btnAtrasMantenimiento.Visible = false;
            txtNumerotarjetaMantenimiento.Text = string.Empty;
            txtSecuenciaInterna.Text = string.Empty;
            lbClaveSeguridad.Visible = false;
            txtClaveSeguridad.Visible = false;
            txtClaveSeguridad.Text = string.Empty;

            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnAtras.Enabled = false;
            btnModificar.Enabled = false;
            btnDeshabilitar.Enabled = false;
            btnExportar.Enabled = true;
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropConsulta();
                MostrarListadoTarjetas();
            }


        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoTarjetas();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbIdMantenimiento.Text = "0";
            lbAccion.Text = "INSERT";
            CargarDropMantenimiento();
            MostrarControles();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "UPDATE";
            CargarDropMantenimiento();
            MostrarControles();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void gvTarjetaAcceso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvTarjetaAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvTarjetaAcceso.SelectedRow;

            var BuscarRegistro = ObjData.Value.BuscaTarjetaAcceso(
                null, null, null, Convert.ToDecimal(gb.Cells[1].Text), null, null, null, null);
            gvTarjetaAcceso.DataSource = BuscarRegistro;
            gvTarjetaAcceso.DataBind();
            foreach (var n in BuscarRegistro)
            {
                lbIdMantenimiento.Text = n.IdTarjetaAcceso.ToString();
            }
            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnAtras.Enabled = true;
            btnModificar.Enabled = true;
            btnDeshabilitar.Enabled = true;
            btnExportar.Enabled = false;
        }

        protected void gvTarjetaAcceso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try { e.Row.Cells[1].Visible = false; }
            catch (Exception) { }
        }

        protected void cbFiltrarPorRangoFechaConsulta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFiltrarPorRangoFechaConsulta.Checked)
            {
                lbFechaDesdeConsulta.Visible = true;
                txtFechaDesdeConsulta.Visible = true;
                lbFechaHastaConsulta.Visible = true;
                txtFechaHastaConsulta.Visible = true;
            }
            else
            {
                lbFechaDesdeConsulta.Visible = false;
                txtFechaDesdeConsulta.Visible = false;
                lbFechaHastaConsulta.Visible = false;
                txtFechaHastaConsulta.Visible = false;
            }
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
        }

        protected void ddlDepartamentoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoConsulta, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaConsulta.SelectedValue, ddlDepartamentoConsulta.SelectedValue), true);
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS LOS CAMPOS VACIOS
            if (string.IsNullOrEmpty(txtSecuenciaInterna.Text.Trim()) || string.IsNullOrEmpty(txtNumerotarjetaMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtFechaEntregaMantenimiento.Text.Trim()))
            {
                //MENSAJE
            }
            else
            {
                //VERIFICAMOS SI EL CAMPO CLAVE DE SEGURIDAD ESTA VACIO
                if (string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
                {
                    //MENSAJE
                }
                else
                {
                    //VERIFICAMOS SI LA CLAVE DE SEGURIDAD ES VALIDA
                    var ValidarClave = ObjData.Value.BuscaClaveSeguridad(
                        new Nullable<decimal>(),
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridad.Text));
                    if (ValidarClave.Count() < 1)
                    {
                        //MENSAJE
                    }
                    else
                    {
                        //VERIFICAMOS SI EL EMPLEADO SELECCIONADO YA TIENE UNA TARJETA ASIGNADA
                        var VerificarTarjetaUsuario = ObjData.Value.BuscaTarjetaAcceso(
                            null,
                            null,
                            Convert.ToDecimal(ddlEmpleadoMantenimiento.SelectedValue),
                            null, null, null, null);
                        if (VerificarTarjetaUsuario.Count() < 1)
                        {

                            try {
                                //REALIZAMOS EL MANTENIMIENTO
                                UtilidadesAmigos.Logica.Entidades.ETarjetaAcceso Mantenimiento = new Logica.Entidades.ETarjetaAcceso();

                                Mantenimiento.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                                Mantenimiento.IdDepartamento = Convert.ToDecimal(ddlDepartamentoMantenimiento.SelectedValue);
                                Mantenimiento.IdEmpleado = Convert.ToDecimal(ddlEmpleadoMantenimiento.SelectedValue);
                                Mantenimiento.IdTarjetaAcceso = Convert.ToDecimal(lbIdMantenimiento.Text);
                                Mantenimiento.SecuenciaInterna = txtSecuenciaInterna.Text;
                                Mantenimiento.NumeroTarjeta = txtNumerotarjetaMantenimiento.Text;
                                Mantenimiento.FechaEntrega0 = Convert.ToDateTime(txtFechaEntregaMantenimiento.Text);
                                Mantenimiento.Estatus0 = Convert.ToDecimal(ddlEstatus.SelectedValue);
                                Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"]);
                                Mantenimiento.FechaAdiciona0 = DateTime.Now;
                                Mantenimiento.UsuarioModicia = Convert.ToDecimal(Session["IdUsuario"]);
                                Mantenimiento.FechaModifica0 = DateTime.Now;

                                var MAN = ObjData.Value.MantenimientoTarjetaAcceso(Mantenimiento, lbAccion.Text);
                                OcultarControles();
                            }
                            catch (Exception) {
                                //MENSAJE
                            }
                        }
                        else
                        {
                            //MENSAJE
                            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "UsuarioEncontradoTarjetaAcceso();", true);
                        }
                    }
                }
            }
        }

        protected void ddlOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoMantenimiento, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaMantenimiento.SelectedValue, ddlDepartamentoMantenimiento.SelectedValue));
        }

        protected void ddlDepartamentoMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CARGAMOS LOS EMPLEADOS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEmpleadoMantenimiento, ObjData.Value.BuscaListas("EMPLEADO", ddlOficinaMantenimiento.SelectedValue, ddlDepartamentoMantenimiento.SelectedValue));
        }

        protected void btnAtrasMantenimiento_Click(object sender, EventArgs e)
        {
            OcultarControles();
        }
    }
}
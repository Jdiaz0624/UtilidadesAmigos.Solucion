using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class Empleados : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> Objdata = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();

        #region CARGAR LOS DROPS
        private void CargarDropsConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjdataComun.Value.BuscaListas("OFICINA", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
        }

        private void CargarDropsMantenimiento()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataComun.Value.BuscaListas("OFICINA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamenoMantenimiento, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
        }

        #endregion
        #region MOSTRAR EL LISTADO DE LOS EMPLEADOS
        private void MostrarListadoEmpleados()
        {
            decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text) ? null : txtNombreConsulta.Text.Trim();

            var Buscar = Objdata.Value.BuscaEmpleado(
                _Oficina,
                _Departamento,
                null,
                _Nombre);
            gvEmpleados.DataSource = Buscar;
            gvEmpleados.DataBind();
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void MostrarControles()
        {
            lbOficinaConsulta.Visible = false;
            ddlOficinaConsulta.Visible = false;
            lbDepartamentoConsulta.Visible = false;
            ddlDepartamentoConsulta.Visible = false;
            lbNombreConsulta.Visible = false;
            txtNombreConsulta.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            btnatrasConsulta.Visible = false;
            btnModificar.Visible = false;
            btnDeshabilitar.Visible = false;
            btnExportar.Visible = false;
            gvEmpleados.Visible = false;

            lbOficinaMantenimiento.Visible = true;
            ddlOficinaMantenimiento.Visible = true;
            lbDepartamentoMantenimiento.Visible = true;
            ddlDepartamenoMantenimiento.Visible = true;
            lbNombreMantenimiento.Visible = true;
            txtNombreMantenimiento.Visible = true;
            lbClaveSeguridad.Visible = true;
            txtClaveSeguridad.Visible = true;
            cbEstatusMantenimiento.Visible = true;
            btnGuardarMantenimiento.Visible = true;
            btnAtrasMantenimiento.Visible = true;

            CargarDropsMantenimiento();

            if (lbAccion.Text != "INSERT")
            {
                var SacarDatos = Objdata.Value.BuscaEmpleado(
                    null, null, Convert.ToDecimal(lbIdEmpleado.Text));
                foreach (var n in SacarDatos)
                {
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.ToString());
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamenoMantenimiento, n.IdDepartamento.ToString());
                    txtNombreMantenimiento.Text = n.Nombre;
                    cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);

                    if (cbEstatusMantenimiento.Checked == true)
                    {
                        cbEstatusMantenimiento.Visible = false;
                    }
                    else
                    {
                        cbEstatusMantenimiento.Visible = true;
                    }
                }
            }
        }
        private void OcultarControles()
        {
            lbOficinaConsulta.Visible = true;
            ddlOficinaConsulta.Visible = true;
            lbDepartamentoConsulta.Visible = true;
            ddlDepartamentoConsulta.Visible = true;
            lbNombreConsulta.Visible = true;
            txtNombreConsulta.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            btnatrasConsulta.Visible = true;
            btnModificar.Visible = true;
            btnDeshabilitar.Visible = true;
            btnExportar.Visible = true;
            gvEmpleados.Visible = true;

            lbOficinaMantenimiento.Visible = false;
            ddlOficinaMantenimiento.Visible = false;
            lbDepartamentoMantenimiento.Visible = false;
            ddlDepartamenoMantenimiento.Visible = false;
            lbNombreMantenimiento.Visible = false;
            txtNombreMantenimiento.Visible = false;
            lbClaveSeguridad.Visible = false;
            txtClaveSeguridad.Visible = false;
            cbEstatusMantenimiento.Visible = false;
            btnGuardarMantenimiento.Visible = false;
            btnAtrasMantenimiento.Visible = false;

            txtNombreConsulta.Text = string.Empty;
            txtNombreMantenimiento.Text = string.Empty;
            txtClaveSeguridad.Text = string.Empty;
            CargarDropsConsulta();
            MostrarListadoEmpleados();

            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnatrasConsulta.Enabled = false;
            btnModificar.Enabled = false;
            btnDeshabilitar.Enabled = false;
            btnExportar.Enabled = true;
        }
        #endregion
        #region MANTENIMIENTO DE EMPLEADOS
        private void MANEmpleados()
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try {

                    //REALIZAMOS EL MANTENIMIENTO
                    UtilidadesAmigos.Logica.Entidades.Mantenimientos.EEmpleado Mantenimiento = new Logica.Entidades.Mantenimientos.EEmpleado();

                    Mantenimiento.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                    Mantenimiento.IdDepartamento = Convert.ToDecimal(ddlDepartamenoMantenimiento.SelectedValue);
                    Mantenimiento.IdEmpleado = Convert.ToDecimal(lbIdEmpleado.Text);
                    Mantenimiento.Nombre = txtNombreMantenimiento.Text;
                    Mantenimiento.Estatus0 = cbEstatusMantenimiento.Checked;
                    Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimiento.FechaAdiciona = DateTime.Now;
                    Mantenimiento.UsuarioModifica = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimiento.FechaModifica = DateTime.Now;

                    var MAn = Objdata.Value.MantenimientoEmpleado(Mantenimiento, lbAccion.Text);

                }
                catch (Exception) { }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                CargarDropsConsulta();
                MostrarListadoEmpleados();
            }
        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;
            MostrarListadoEmpleados();
        }

        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow gb = gvEmpleados.SelectedRow;

            var Seleccionar = Objdata.Value.BuscaEmpleado(
                null, null, Convert.ToDecimal(gb.Cells[1].Text));
            gvEmpleados.DataSource = Seleccionar;
            gvEmpleados.DataBind();
            foreach (var n in Seleccionar)
            {
                lbIdEmpleado.Text = n.IdEmpleado.ToString();
            }

            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnatrasConsulta.Enabled = true;
            btnModificar.Enabled = true;
            btnDeshabilitar.Enabled = true;
            btnExportar.Enabled = false;
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {

            //VALIDAMOS LA CLAVE DE SEGURIDAD
            var ValidarClave = ObjdataComun.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridad.Text));
            if (ValidarClave.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida();", true);
            }
            else
            {
                MANEmpleados();
            }

        }

        protected void btnAtrasMantenimiento_Click(object sender, EventArgs e)
        {
            OcultarControles();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoEmpleados();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbIdEmpleado.Text = "0";
            lbAccion.Text = "INSERT";
            MostrarControles();
            cbEstatusMantenimiento.Visible = false;
            cbEstatusMantenimiento.Checked = true;
        }

        protected void btnatrasConsulta_Click(object sender, EventArgs e)
        {
            OcultarControles();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "UPDATE";
            MostrarControles();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "DISABLE";
            MostrarControles();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try {
                decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? decimal.Parse(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
                string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();

                var Exportar = (from n in Objdata.Value.BuscaEmpleado(
                    _Oficina,
                    _Departamento,
                    new Nullable<decimal>(),
                    _Nombre)
                                select new
                                {
                                    Oficina=n.Oficina,
                                    Departamento=n.Departamento,
                                    Nombre=n.Nombre,
                                    Estatus=n.Estatus,
                                    CreadoPor=n.CreadoPor,
                                    FechaCreado=n.FechaAdiciona,
                                    ModificadoPor=n.ModificadoPor,
                                    FechaModifica=n.FechaModifica
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Empleados", Exportar);
            }
            catch (Exception) { }
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlOficinaConsulta.SelectedValue, null), true);
        }

        protected void ddlOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamenoMantenimiento, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlOficinaMantenimiento.SelectedValue, null));
        }

        protected void gvEmpleados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try {
            //    e.Row.Cells[1].Visible = false;
            //}
            //catch (Exception) { }
        }
    }
}
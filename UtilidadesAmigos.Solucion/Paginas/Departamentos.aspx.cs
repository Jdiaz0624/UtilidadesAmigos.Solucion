using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas.Mantenimientos
{
    public partial class Departamentos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> Objdata = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LISTAS 
        private void CargarListasCOnsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalCOnsulta, ObjdataGeneral.Value.BuscaListas("SUCURSAL", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddloficinaConsulta, ObjdataGeneral.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalCOnsulta.SelectedValue, null), true);

        }
        private void CargarListasMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalmantenimiento, ObjdataGeneral.Value.BuscaListas("SUCURSAL", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataGeneral.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalmantenimiento.SelectedValue, null));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS DEPARTAMENTOS
        private void MostrarListadoDepartamentos() {
            decimal? _Sucursal = ddlSeleccionarSucursalCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSucursalCOnsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddloficinaConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddloficinaConsulta.SelectedValue) : new Nullable<decimal>();
            string _Departamento = string.IsNullOrEmpty(txtDescripcionDepartamento.Text.Trim()) ? null : txtDescripcionDepartamento.Text.Trim();

            var Buscar = Objdata.Value.BuscaDepartamentos(
                _Sucursal,
                _Oficina,
                new Nullable<decimal>(),
                _Departamento);
            gvDepartamentos.DataSource = Buscar;
            gvDepartamentos.DataBind();
            if (Buscar.Count() < 1)
            {
                lbCantidadRegistrosVariable.Text = "0";
            }
            else {
                foreach (var n in Buscar)
                {
                    int Cantidad = Convert.ToInt32(n.CantidadRegistros);
                    lbCantidadRegistrosVariable.Text = Cantidad.ToString("N0");
                }
            }

        }
        #endregion
        #region MANTENIMIENTO DE DEPARTAMENTOS
        private void MANDepartamentos(string Accion) {
            if (Session["Idusuario"] != null)
            {
                try {
                    UtilidadesAmigos.Logica.Entidades.Mantenimientos.EDepartamentos Mantenimeinto = new Logica.Entidades.Mantenimientos.EDepartamentos();

                    Mantenimeinto.IdSucursal = Convert.ToDecimal(ddlSeleccionarSucursalmantenimiento.SelectedValue);
                    Mantenimeinto.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                    Mantenimeinto.IdDepartamento = Convert.ToDecimal(lbIdDepartamento.Text);
                    Mantenimeinto.Departamento = txtDescripcionDepartamentoMAN.Text;
                    Mantenimeinto.Estatus0 = cbEstatus.Checked;
                    Mantenimeinto.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimeinto.FechaAdiciona = DateTime.Now;
                    Mantenimeinto.UsuarioModifica= Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimeinto.FechaModifica = DateTime.Now;

                    var MAn = Objdata.Value.MantenimientoDepartamentos(Mantenimeinto, Accion);
                }
                catch (Exception) { }
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        #endregion
        #region RESTABLECER PANTALLA
        private void RestablecerPantalla() {
            CargarListasCOnsulta();
            CargarListasMantenimiento();
            txtDescripcionDepartamento.Text = string.Empty;
            MostrarListadoDepartamentos();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListasCOnsulta();
                CargarListasMantenimiento();
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoDepartamentos();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            decimal? _Sucursal = ddlSeleccionarSucursalCOnsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSucursalCOnsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddloficinaConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddloficinaConsulta.SelectedValue) : new Nullable<decimal>();
            string _Departamento = string.IsNullOrEmpty(txtDescripcionDepartamento.Text.Trim()) ? null : txtDescripcionDepartamento.Text.Trim();

            var ExportarRegistros = (from n in Objdata.Value.BuscaDepartamentos(
                _Sucursal,
                _Oficina,
                new Nullable<decimal>(),
                _Departamento)
                                     select new {
                                         Sucursal = n.Sucursal,
                                         Oficina = n.Oficina,
                                         Departamento = n.Departamento,
                                         Estatus = n.Estatus,
                                         CreadoPor = n.CreadoPor,
                                         FechaCreado = n.FechaCreado,
                                         ModificadoPor = n.ModificadoPor,
                                         FechaModificado = n.FechaModificado,
                                     }).ToList();

               ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void gvDepartamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartamentos.PageIndex = e.NewPageIndex;
            MostrarListadoDepartamentos();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void gvDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvDepartamentos.SelectedRow;

            var BuscarRegistros = Objdata.Value.BuscaDepartamentos(
                null,
                null,
                Convert.ToDecimal(gb.Cells[1].Text),
                null);
            gvDepartamentos.DataSource = BuscarRegistros;
            gvDepartamentos.DataBind();
            foreach (var n in BuscarRegistros)
            {
                lbIdDepartamento.Text = n.IdDepartamento.ToString();
                int Cantidad = Convert.ToInt32(n.CantidadRegistros);
                lbCantidadRegistrosVariable.Text = Cantidad.ToString("N0");

                //SACAMOS LOS DATOS PARA EL MANTENIMIENTO
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarSucursalmantenimiento, n.IdSucursal.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.ToString());
                txtDescripcionDepartamentoMAN.Text = n.Departamento;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearControles", "DesbloquearControles();", true);
        }

        protected void ddlSeleccionarSucursalCOnsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddloficinaConsulta, ObjdataGeneral.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalCOnsulta.SelectedValue, null), true);
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
            //VALIDAMOS AL CLAVE DE SEGURIDAD
            if (string.IsNullOrEmpty(txtclaveSeguridad.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida", "ClaveSeguridadNoValida();", true);
            }
            else
            {
                lbIdDepartamento.Text = "0";
                MANDepartamentos("INSERT");
                ClientScript.RegisterStartupScript(GetType(), "RegistroGuardado", "RegistroGuardado();", true);
                RestablecerPantalla();
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnModificarMantenimiento_Click(object sender, EventArgs e)
        {
            //VALIDAMOS AL CLAVE DE SEGURIDAD
            if (string.IsNullOrEmpty(txtclaveSeguridad.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida", "ClaveSeguridadNoValida();", true);
            }
            else
            {
                MANDepartamentos("UPDATE");
                ClientScript.RegisterStartupScript(GetType(), "RegistroModificado", "RegistroModificado();", true);
                RestablecerPantalla();

            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void ddlSeleccionarSucursalmantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataGeneral.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalmantenimiento.SelectedValue, null));
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
            RestablecerPantalla();
        }
    }
}
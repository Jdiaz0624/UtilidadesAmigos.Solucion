using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class Empleados : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> Objdata = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();


        #region CARGAR LAS LISTAS PARA LA CONSULTA
        private void CargarListasConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalConsulta, ObjdataComun.Value.BuscaListas("SUCURSAL", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjdataComun.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalConsulta.SelectedValue, ddlOficinaConsulta.SelectedValue), true);
        }
        private void CargarListasMantenimeinto() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalmantenimiento, ObjdataComun.Value.BuscaListas("SUCURSAL", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataComun.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalmantenimiento.SelectedValue, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamenoMantenimiento, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalmantenimiento.SelectedValue, ddlOficinaMantenimiento.SelectedValue));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS EMPLEADOS
        private void MostrarListado() {
            decimal? _Sucursal = ddlSeleccionarSucursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSucursalConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.TemplateSourceDirectory.Trim()) ? null : txtNombreConsulta.Text.Trim();

            var Buscar = Objdata.Value.BuscaEmpleados(
                _Sucursal,
                _Oficina,
                _Departamento,
                new Nullable<decimal>(),
                _Nombre);
            gvEmpleados.DataSource = Buscar;
            gvEmpleados.DataBind();
            if (Buscar.Count() < 1)
            {
                lbCantidadRegistrosdVariable.Text = "0";
            }
            else
            {
                foreach (var n in Buscar)
                {
                    int cantidad = Convert.ToInt32(n.CantidadRegistros);
                    lbCantidadRegistrosdVariable.Text = cantidad.ToString("N0");
                }
            }
        }
        #endregion
        #region MANTENIMIENTO DE EMPLEADOS
        private void MAnEmpleados(string Accion)
        {
            if (Session["Idusuario"] != null)
            {
                try {
                    UtilidadesAmigos.Logica.Entidades.Mantenimientos.EEmpleado Mantenimeinto = new Logica.Entidades.Mantenimientos.EEmpleado();

                    Mantenimeinto.IdSucursal = Convert.ToDecimal(ddlSeleccionarSucursalmantenimiento.SelectedValue);
                    Mantenimeinto.IdOfiicna = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                    Mantenimeinto.IdDepartamento = Convert.ToDecimal(ddlDepartamenoMantenimiento.SelectedValue);
                    Mantenimeinto.IdEmpleado = Convert.ToDecimal(lbIdEmpleado.Text);
                    Mantenimeinto.Nombre = txtNombreMantenimiento.Text;
                    Mantenimeinto.Estatus0 = cbEstatusMantenimiento.Checked;
                    Mantenimeinto.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimeinto.FechaAdiciona = DateTime.Now;
                    Mantenimeinto.UsuarioModifica = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimeinto.FechaModifica = DateTime.Now;

                    var MAN = Objdata.Value.MantenimientoEmpleado(Mantenimeinto, Accion);
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

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                CargarListasConsulta();
                CargarListasMantenimeinto();
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
            }
        }

        protected void ddlSeleccionarSucursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjdataComun.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalConsulta.SelectedValue, ddlOficinaConsulta.SelectedValue), true);
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void ddlOficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoConsulta, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalConsulta.SelectedValue, ddlOficinaConsulta.SelectedValue), true);
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListado();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
            CargarListasConsulta();
            CargarListasMantenimeinto();
            txtNombreConsulta.Text = string.Empty;
            MostrarListado();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            decimal? _Sucursal = ddlSeleccionarSucursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSucursalConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlOficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.TemplateSourceDirectory.Trim()) ? null : txtNombreConsulta.Text.Trim();

            var Exportar = (from n in Objdata.Value.BuscaEmpleados(
                _Sucursal,
                _Oficina,
                _Departamento,
                new Nullable<decimal>(),
                _Nombre)
                            select new
                            {
                               //IdSucursal = n.IdSucursal,
                                Sucursal = n.Sucursal,
                               //IdOfiicna = n.IdOfiicna,
                                Oficina = n.Oficina,
                                //IdDepartamento = n.IdDepartamento,
                                Departamento = n.Departamento,
                                //IdEmpleado = n.IdEmpleado,
                                Nombre = n.Nombre,
                                //Estatus0 = n.Estatus0,
                                Estatus = n.Estatus,
                                //UsuarioAdiciona = n.UsuarioAdiciona,
                                CreadoPor = n.CreadoPor,
                                //FechaAdiciona = n.FechaAdiciona,
                                FechaCreado = n.FechaCreado,
                                //UsuarioModifica = n.UsuarioModifica,
                                ModificadoPor = n.ModificadoPor,
                                //FechaModifica = n.FechaModifica,
                                FechaModificado = n.FechaModificado,
                                //CantidadRegistros = n.CantidadRegistros
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Empleados", Exportar);
                        ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;
            MostrarListado();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvEmpleados.SelectedRow;

            var Seleccionar = Objdata.Value.BuscaEmpleados(
                null,
                null,
                null,
                Convert.ToDecimal(gv.Cells[1].Text),
                null);
            gvEmpleados.DataSource = Seleccionar;
            gvEmpleados.DataBind();
            foreach (var n in Seleccionar)
            {
                int cantidad = Convert.ToInt32(n.CantidadRegistros);
                lbCantidadRegistrosdVariable.Text = cantidad.ToString("N0");

                lbIdEmpleado.Text = n.IdEmpleado.ToString();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarSucursalmantenimiento, n.IdSucursal.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOfiicna.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamenoMantenimiento, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalmantenimiento.SelectedValue, ddlOficinaMantenimiento.SelectedValue));
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamenoMantenimiento, n.IdDepartamento.ToString());
                txtNombreMantenimiento.Text = n.Nombre;
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearControles", "DesbloquearControles();", true);
        }

        protected void ddlSeleccionarSucursalmantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataComun.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalmantenimiento.SelectedValue, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamenoMantenimiento, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalmantenimiento.SelectedValue, ddlOficinaMantenimiento.SelectedValue));
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void ddlOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamenoMantenimiento, ObjdataComun.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalmantenimiento.SelectedValue, ddlOficinaMantenimiento.SelectedValue));
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {
            //VALIDAMOS LA CLAVE DE SEGURIDAD
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()) ? null : txtClaveSeguridad.Text.Trim();

            var Validar = ObjdataComun.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
               UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridad));
            if (Validar.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida", "ClaveSeguridadNoValida();", true);
            }
            else
            {
                MAnEmpleados("INSERT");
                MostrarListado();
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnModificarMantenimiento_Click(object sender, EventArgs e)
        {
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()) ? null : txtClaveSeguridad.Text.Trim();

            var Validar = ObjdataComun.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
               UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridad));
            if (Validar.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida", "ClaveSeguridadNoValida();", true);
            }
            else
            {
                MAnEmpleados("UPDATE");
                MostrarListado();
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }
    }
}
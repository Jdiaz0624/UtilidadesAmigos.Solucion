using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoUsuarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataLogica = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        //LISTAS PARA LA PARTE DE CONSULTA
        //CARGAMOS LAS SUCURSALES
        private void CargarSucursalesConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalConsulta, ObjDataLogica.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinasConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaConsulta, ObjDataLogica.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalConsulta.SelectedValue, null), true);
        }
        private void CargarDepartamentosConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarDepartamentoConsulta, ObjDataLogica.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalConsulta.SelectedValue, ddlSeleccionaroficinaConsulta.SelectedValue), true);
        }
        private void CargarPerfilesUsuariosConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPerfilConsulta, ObjDataLogica.Value.BuscaListas("PERFILES", null, null), true);
        }

        //CARGAMOS LAS LISTAS DESPLEGABLES EN LA PANTALLA DE MANTENIMIENTO
        private void CargarSucursalesMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalMantenimeinto, ObjDataLogica.Value.BuscaListas("SUCURSAL", null, null));
        }
        private void CargarOficinasMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaMantenimiento, ObjDataLogica.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalMantenimeinto.SelectedValue, null));
        }
        private void CargarDepartamentosMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarDepartamentoMantenimiento, ObjDataLogica.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSucursalMantenimeinto.SelectedValue, ddlSeleccionarOficinaMantenimiento.SelectedValue));
        }
        private void CargarPerfilesUsuariosMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPerfilMantenimiento, ObjDataLogica.Value.BuscaListas("PERFILES", null, null));
        }
        private void CargarTipoPersonaMantenimiento() {
            
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoPersona, ObjDataLogica.Value.BuscaListas("TIPOPERSONA", null, null));
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LOS USUARIOS
        private void CargarListadoUsuarios() {
            decimal? _Sucursal = ddlSeleccionarSucursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSucursalConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlSeleccionaroficinaConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionaroficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlSeleccionarDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Perfil = ddlSeleccionarPerfilConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarPerfilConsulta.SelectedValue) : new Nullable<decimal>();
            string _Usuario = string.IsNullOrEmpty(txtUsuarioConsulta.Text.Trim()) ? null : txtUsuarioConsulta.Text.Trim();

            var Listado = ObjDataLogica.Value.BuscaUsuarios(
                new Nullable<decimal>(),
                _Sucursal,
                _Oficina,
                _Departamento,
                _Perfil,
                _Usuario,
                null, null, null);
            gvUsuario.DataSource = Listado;
            gvUsuario.DataBind();
        }
        #endregion





        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSucursalesConsulta();
                CargarOficinasConsulta();
                CargarDepartamentosConsulta();
                CargarPerfilesUsuariosConsulta();

                CargarSucursalesMantenimiento();
                CargarOficinasMantenimiento();
                CargarDepartamentosMantenimiento();
                CargarPerfilesUsuariosMantenimiento();
                CargarTipoPersonaMantenimiento();
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarListadoUsuarios();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void gvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearControles", "DesbloquearControles()", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);

        }

        protected void ddlSeleccionaroficinaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentosConsulta();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void ddlSeleccionarSucursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinasConsulta();
            CargarDepartamentosConsulta();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void ddlSeleccionarSucursalMantenimeinto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinasMantenimiento();
            CargarDepartamentosMantenimiento();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void ddlSeleccionarOficinaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentosMantenimiento();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }
    }
}
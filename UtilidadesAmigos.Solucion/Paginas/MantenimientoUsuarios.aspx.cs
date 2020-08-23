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

        #region MANTENIMENTO DE USUARIOS
        /// <summary>
        /// Este metodo sirve para agregar, modificar y deshabilitar usuarios en la base de datos
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="Accion"></param>
        private void MAntenimientoUsuarios(decimal IdUsuario, string Accion) {
            try {
                string _ClaveSeguridad = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimiento.Text);
                //VALIDAMOS LA CLAVE DE SEGURIDAD
                var ValidarClaveSeguridad = ObjDataLogica.Value.BuscaClaveSeguridad(
                    new Nullable<decimal>(),
                    _ClaveSeguridad);
                if (ValidarClaveSeguridad.Count() < 1) {
                    ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida", "ClaveSeguridadNoValida()", true);
                }
                else {
                    UtilidadesAmigos.Logica.ProcesoInformacion.ProcesarInformacionUsuarios Procesar = new Logica.ProcesoInformacion.ProcesarInformacionUsuarios(
                  IdUsuario,
                  Convert.ToDecimal(ddlSeleccionarSucursalMantenimeinto.SelectedValue),
                  Convert.ToDecimal(ddlSeleccionarOficinaMantenimiento.SelectedValue),
                  Convert.ToDecimal(ddlSeleccionarDepartamentoMantenimiento.SelectedValue),
                  Convert.ToDecimal(ddlSeleccionarPerfilMantenimiento.SelectedValue),
                  txtNombreUsuarioMantenimiento.Text,
                  UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveMantenimiento.Text),
                  txtNombrePersonaMantenimiento.Text,
                  cbEstatusMantenimiento.Checked,
                  cbLlevaEmailMantenimiento.Checked,
                  txtEmailMantenimiento.Text,
                  0,
                  cbCambiaClave.Checked,
                  "",
                  Convert.ToDecimal(ddlSeleccionarTipoPersona.SelectedValue),
                  Accion);
                    Procesar.ProcesarInformacion();
                }
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorGuardarRegistro", "ErrorGuardarRegistro()", true);
            }


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
            //EXPORTAMOS LA INFORMACION A EXEL
            decimal? _Sucursal = ddlSeleccionarSucursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSucursalConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlSeleccionaroficinaConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionaroficinaConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlSeleccionarDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Perfil = ddlSeleccionarPerfilConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarPerfilConsulta.SelectedValue) : new Nullable<decimal>();
            string _Usuario = string.IsNullOrEmpty(txtUsuarioConsulta.Text.Trim()) ? null : txtUsuarioConsulta.Text.Trim();

            var Exportar = (from n in ObjDataLogica.Value.BuscaUsuarios(
                new Nullable<decimal>(),
                _Sucursal,
                _Oficina,
                _Departamento,
                _Perfil,
                _Usuario, null, null, null)
                            select new {
                                ID=n.IdUsuario,
                                Persona=n.Persona,
                                Usuario=n.Usuario,
                                Estatus =n.Estatus,
                                CambiaClave =n.CambiaClave,
                                LlevaEmail=n.LlevaEmail,
                                Email=n.Email
                            });
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Usurios", Exportar);
                        ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (Session["IdMantenimiento"] != null)
            {
                MAntenimientoUsuarios(Convert.ToDecimal(Session["IdMantenimiento"]), "DISABLE");
                CargarListadoUsuarios();
                ClientScript.RegisterStartupScript(GetType(), "LimpiarControles", "LimpiarControles()", true);
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void gvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //MODIFICAMOS EL CODIGO DE LA VALIDACION
            gvUsuario.PageIndex = e.NewPageIndex;
            CargarListadoUsuarios();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }
        
        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvUsuario.SelectedRow;

            Session["IdMantenimiento"] = gb.Cells[0].Text;

            var BuscarRegistroSeleccionado = ObjDataLogica.Value.BuscaUsuarios(
                Convert.ToDecimal(Session["IdMantenimiento"]));
            gvUsuario.DataSource = BuscarRegistroSeleccionado;
            gvUsuario.DataBind();
            //SACAMOS LOS DATOS DEL USUARIO SELECCIONADO
            foreach (var n in BuscarRegistroSeleccionado) {
                CargarSucursalesMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarSucursalMantenimeinto, n.IdSucursal.ToString());
                CargarOficinasMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarOficinaMantenimiento, n.IdOficina.ToString());
                CargarDepartamentosMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarDepartamentoMantenimiento, n.IdDepartamento.ToString());
                CargarPerfilesUsuariosMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarPerfilMantenimiento, n.IdPerfil.ToString());
                txtNombreUsuarioMantenimiento.Text = n.Usuario;
                txtNombrePersonaMantenimiento.Text = n.Persona;
                txtClaveMantenimiento.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                txtConfirmarClaveMantenimiento.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                txtEmailMantenimiento.Text = n.Email;
                CargarTipoPersonaMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarTipoPersona, n.IdTipoPersona.ToString());
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                cbLlevaEmailMantenimiento.Checked = (n.LlevaEmail0.HasValue ? n.LlevaEmail0.Value : false);
                cbCambiaClave.Checked = (n.CambiaClave0.HasValue ? n.CambiaClave0.Value : false);
            }
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearControles", "DesbloquearControles()", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //GUARDAMOS LOS DATOS
            MAntenimientoUsuarios(0, "INSERT");
            CargarListadoUsuarios();
            ClientScript.RegisterStartupScript(GetType(), "LimpiarControles", "LimpiarControles()", true);
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles()", true);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (Session["IdMantenimiento"] != null)
            {
                MAntenimientoUsuarios(Convert.ToDecimal(Session["IdMantenimiento"]), "UPDATE");
                if (cbCambiaClave.Checked) {
                    MAntenimientoUsuarios(Convert.ToDecimal(Session["IdMantenimiento"]), "STARTCHANGEPASSWORD");
                }
                CargarListadoUsuarios();
                ClientScript.RegisterStartupScript(GetType(), "LimpiarControles", "LimpiarControles()", true);
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            ClientScript.RegisterStartupScript(GetType(), "ErrorGuardarRegistro", "ErrorGuardarRegistro()", true);

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

        protected void btnRestablecerPantalla_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "LimpiarControles", "LimpiarControles()", true);
            CargarListadoUsuarios();
        }
    }
}
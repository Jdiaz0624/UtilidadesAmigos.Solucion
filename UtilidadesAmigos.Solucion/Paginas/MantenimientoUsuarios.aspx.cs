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
        private void CargarListas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarDepartamentoConsulta, ObjDataLogica.Value.BuscaListas("DEPARTAMENTO", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPerfilConsulta, ObjDataLogica.Value.BuscaListas("PERFILES", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarDepartamentoMantenimiento, ObjDataLogica.Value.BuscaListas("DEPARTAMENTO", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPerfilMantenimiento, ObjDataLogica.Value.BuscaListas("PERFILES", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoPersona, ObjDataLogica.Value.BuscaListas("TIPOPERSONA", null, null));

        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS USUAIROS
        private void MostrarListadoUsuarios()
        {
            decimal? _Departamento = ddlSeleccionarDepartamentoConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamentoConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Perfil = ddlSeleccionarPerfilConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarPerfilConsulta.SelectedValue) : new Nullable<decimal>();
            string _Usuario = string.IsNullOrEmpty(txtUsuarioConsulta.Text.Trim()) ? null : txtUsuarioConsulta.Text.Trim();

            var Buscar = ObjDataLogica.Value.BuscaUsuarios(
                new Nullable<decimal>(),
                _Departamento,
                _Perfil,
                _Usuario);
            gvUsuario.DataSource = Buscar;
            gvUsuario.DataBind();

        }
        #endregion
        #region MANTENIMEINTO DE USUARIOS
        private void MANusuarios(string Accion)
        {
            if (Session["IdUsuario"] != null)
            {
                try {
                    UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Mantenimiento = new Logica.Entidades.EMantenimientoUsuarios();

                    Mantenimiento.IdUsuario = Convert.ToDecimal(lbMantenimientoUsuario.Text);
                    Mantenimiento.IdDepartamento = Convert.ToDecimal(ddlSeleccionarDepartamentoMantenimiento.SelectedValue);
                    Mantenimiento.IdPerfil = Convert.ToDecimal(ddlSeleccionarPerfilMantenimiento.SelectedValue);
                    Mantenimiento.Usuario = txtNombreUsuarioMantenimiento.Text;
                    Mantenimiento.Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveMantenimiento.Text);
                    Mantenimiento.Persona = txtNombrePersonaMantenimiento.Text;
                    Mantenimiento.Estatus = cbEstatusMantenimiento.Checked;
                    Mantenimiento.LlevaEmail = cbLlevaEmailMantenimiento.Checked;
                    Mantenimiento.Email = txtEmailMantenimiento.Text;
                    Mantenimiento.Contador = 0;
                    Mantenimiento.CambiaClave = cbCambiaClave.Checked;
                    Mantenimiento.RazonBloqueo = "";
                    Mantenimiento.IdTipoPersona = Convert.ToDecimal(ddlSeleccionarTipoPersona.SelectedValue);

                    var MAN = ObjDataLogica.Value.MantenimientoUsuarios(Mantenimiento, Accion);

                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorMantenimiento", "ErrorMantenimiento();", true);
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        #endregion
        #region RESTABLECER PANTALLA
        private void Restablecer()
        {
            ClientScript.RegisterStartupScript(GetType(), "ActivarBotones", "DesactivarBotones();", true);
            ClientScript.RegisterStartupScript(GetType(), "CleanControls", "CleanControls();", true);
            CargarListas();
            MostrarListadoUsuarios();
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Restablecer();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoUsuarios();
          //  Restablecer();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            decimal? _Departamento = ddlSeleccionarPerfilConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarPerfilConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Perfil = ddlSeleccionarPerfilConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarPerfilConsulta.SelectedValue) : new Nullable<decimal>();
            string _Usuario = string.IsNullOrEmpty(txtUsuarioConsulta.Text.Trim()) ? null : txtUsuarioConsulta.Text.Trim();

            var Exportar = (from n in ObjDataLogica.Value.BuscaUsuarios(
                new Nullable<decimal>(),
                _Departamento,
                _Perfil,
                _Usuario)
                            select new
                            {
                                IdUsuario=n.IdUsuario,
                                Departamento=n.Departamento,
                                Perfil=n.Perfil,
                                Usuario=n.Usuario,
                                Nombre=n.Persona,
                                Estatus=n.Estatus,
                                CambiaClave=n.CambiaClave,
                                LlevaEmail=n.LlevaEmail,
                                Email=n.Email,
                                TipoPersona=n.TipoPersona
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Usuarios", Exportar);
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            MANusuarios("DISABLE");
            Restablecer();
        }

        protected void gvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuario.PageIndex = e.NewPageIndex;
            MostrarListadoUsuarios();
        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvUsuario.SelectedRow;

            var Buscar = ObjDataLogica.Value.BuscaUsuarios(
                Convert.ToDecimal(gb.Cells[0].Text));
            gvUsuario.DataSource = Buscar;
            gvUsuario.DataBind();
            foreach (var n in Buscar)
            {
                ClientScript.RegisterStartupScript(GetType(), "ActivarBotones", "ActivarBotones();", true);
                lbMantenimientoUsuario.Text = n.IdUsuario.ToString();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarDepartamentoMantenimiento, n.IdDepartamento.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarPerfilMantenimiento, n.IdPerfil.ToString());
                txtNombreUsuarioMantenimiento.Text = n.Usuario;
                txtClaveMantenimiento.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                txtConfirmarClaveMantenimiento.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                txtNombrePersonaMantenimiento.Text = n.Persona;
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                cbLlevaEmailMantenimiento.Checked = (n.LlevaEmail0.HasValue ? n.LlevaEmail0.Value : false);
                txtEmailMantenimiento.Text = n.Email;
                cbCambiaClave.Checked = (n.CambiaClave0.HasValue ? n.CambiaClave0.Value : false);
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarTipoPersona, n.IdTipoPersona.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClaveSeguridadMantenimiento.Text.Trim()))
            {

            }
            else
            {
                //VALIDAMOS AL CLAVE DE SEGURIDAD
                var ValidarClave = ObjDataLogica.Value.BuscaClaveSeguridad(
                    new Nullable<decimal>(),
                    UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimiento.Text));
                if (ValidarClave.Count() < 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ValidarClaveSeguridad", "ValidarClaveSeguridad();", true);
                }
                else
                {
               
                    lbMantenimientoUsuario.Text = "0";
                    MANusuarios("INSERT");
                    Restablecer();
                }
            }
           
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClaveSeguridadMantenimiento.Text.Trim()))
            {

            }
            else
            {
                //VALIDAMOS AL CLAVE DE SEGURIDAD
                var ValidarClave = ObjDataLogica.Value.BuscaClaveSeguridad(
                    new Nullable<decimal>(),
                    UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimiento.Text));
                if (ValidarClave.Count() < 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ValidarClaveSeguridad", "ValidarClaveSeguridad();", true);
                }
                else
                {
                    if (cbCambiaClave.Checked == true)
                    {
                        UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Mantenimiento = new Logica.Entidades.EMantenimientoUsuarios();

                        Mantenimiento.IdUsuario = Convert.ToDecimal(lbMantenimientoUsuario.Text);
                        Mantenimiento.Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar("FuturoSeguros123");

                        var MAN = ObjDataLogica.Value.MantenimientoUsuarios(Mantenimiento, "CHANGEPASSWORD");

                    }
                    MANusuarios("UPDATE");
                    Restablecer();
                }
            }
         
        }
    }
}
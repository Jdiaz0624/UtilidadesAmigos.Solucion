using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoUsuarios : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region MOSTRAR EL LISTADO DE USUARIOS
        private void MostrarListadoUsuario()
        {
            string _Usuario = string.IsNullOrEmpty(txtUsuarioFiltro.Text.Trim()) ? null : txtUsuarioFiltro.Text.Trim();

            var BuscarUsuario = ObjData.Value.BuscaUsuarios(
                new Nullable<decimal>(),
                null, null,
                _Usuario, null, null, null);
            gbListadoUsuarios.DataSource = BuscarUsuario;
            gbListadoUsuarios.DataBind();
            
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void MostrarControles()
        {
            lbDepartamentoMantenimiento.Visible = true;
            ddlDepartamentoMantenimiento.Visible = true;
            lbPerfilMantenimiento.Visible = true;
            ddlPerfilMantenimiento.Visible = true;
            lbUsuarioMantenimiento.Visible = true;
            txtUsuarioMantenimiento.Visible = true;
            lbPersonaMantenimiento.Visible = true;
            txtPersonaMantenimiento.Visible = true;
            lbEmailMantenimiento.Visible = true;
            txtEmailMantenimiento.Visible = true;
            lbClaveSeguridad.Visible = true;
            txtClaveSeguridadMantenimeinto.Visible = true;
            cbEstatusMantenimiento.Visible = true;
            cbLlevaEmailMantenimiento.Visible = true;
            cbCambiaClaveMantenimiento.Visible = true;
            btnProcesarMantenimento.Visible = true;
            btnVolverAtras.Visible = true;

            //CONTROLES DE CONSULTA
            lbUsuarioConsulta.Visible = false;
            txtUsuarioFiltro.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
            btnAtras.Visible = false;
            btnDeshabilitar.Visible = false;
            btnEliminar.Visible = false;
            gbListadoUsuarios.Visible = false;

            //CARGAMOS LOS DROP
            CargarDepartamentos();
            CargarPerfiles();

            //SACAMOS LOS DATOS DEL USUARIO EN CASO DE QUE NO SEA UN NUEVO REGISTRO
            if (lbEstatusMantenimiento.Text != "INSERT")
            {
                var SacarDatos = ObjData.Value.BuscaUsuarios(
                    Convert.ToInt32(lbIdUsuarioSeleccionado.Text),
                    null, null, null, null, null, null);
                foreach (var n in SacarDatos)
                {
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamentoMantenimiento, n.IdDepartamento.ToString());
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlPerfilMantenimiento, n.IdPerfil.ToString());
                    txtUsuarioMantenimiento.Text = n.Usuario;
                    txtPersonaMantenimiento.Text = n.Persona;
                    txtEmailMantenimiento.Text = n.Email;
                    cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                    cbLlevaEmailMantenimiento.Checked = (n.LlevaEmail0.HasValue ? n.Estatus0.Value : false);
                    cbCambiaClaveMantenimiento.Checked = (n.CambiaClave0.HasValue ? n.CambiaClave0.Value : false);

                }
                if (cbLlevaEmailMantenimiento.Checked == false)
                {
                    txtEmailMantenimiento.Visible = false;
                }
            }
          

        }
        private void OcultarControles()
        {
            lbDepartamentoMantenimiento.Visible = false;
            ddlDepartamentoMantenimiento.Visible = false;
            lbPerfilMantenimiento.Visible = false;
            ddlPerfilMantenimiento.Visible = false;
            lbUsuarioMantenimiento.Visible = false;
            txtUsuarioMantenimiento.Visible = false;
            lbPersonaMantenimiento.Visible = false;
            txtPersonaMantenimiento.Visible = false;
            lbEmailMantenimiento.Visible = false;
            txtEmailMantenimiento.Visible = false;
            lbClaveSeguridad.Visible = false;
            txtClaveSeguridadMantenimeinto.Visible = false;
            cbEstatusMantenimiento.Visible = false;
            cbLlevaEmailMantenimiento.Visible = false;
            cbCambiaClaveMantenimiento.Visible = false;
            btnProcesarMantenimento.Visible = false;
            btnVolverAtras.Visible = false;

            //CONTROLES DE CONSULTA
            lbUsuarioConsulta.Visible = true;
            txtUsuarioFiltro.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            btnModificar.Visible = true;
            btnAtras.Visible = true;
            btnDeshabilitar.Visible = true;
            btnEliminar.Visible = true;
            gbListadoUsuarios.Visible = true;

            btnNuevo.Enabled = true;
            btnConsultar.Enabled = true;
            btnModificar.Enabled = false;
            btnDeshabilitar.Enabled = false;
            btnEliminar.Enabled = false;
            txtUsuarioFiltro.Text = string.Empty;
            MostrarListadoUsuario();

            txtclave.Visible = false;
            txtConfirmarClave.Visible = false;

            HabilitarControles();
        }
        #endregion
        #region HABILITAR Y DESHABILITAR CONTROLES
        private void HabilitarControles()
        {
            lbDepartamentoMantenimiento.Enabled = true;
            ddlDepartamentoMantenimiento.Enabled = true;
            lbPerfilMantenimiento.Enabled = true;
            ddlPerfilMantenimiento.Enabled = true;
            lbUsuarioMantenimiento.Enabled = true;
            txtUsuarioMantenimiento.Enabled = true;
            lbPersonaMantenimiento.Enabled = true;
            txtPersonaMantenimiento.Enabled = true;
            lbEmailMantenimiento.Enabled = true;
            txtEmailMantenimiento.Enabled = true;
           // lbClaveSeguridad.Enabled = true;
           // txtClaveSeguridadMantenimeinto.Enabled = true;
            cbEstatusMantenimiento.Enabled = true;
            cbLlevaEmailMantenimiento.Enabled = true;
            cbCambiaClaveMantenimiento.Enabled = true;
           // btnProcesarMantenimento.Enabled = true;
          //  btnVolverAtras.Enabled = true;
        }
        private void DeshabilitarControles()
        {
            lbDepartamentoMantenimiento.Enabled = false;
            ddlDepartamentoMantenimiento.Enabled = false;
            lbPerfilMantenimiento.Enabled = false;
            ddlPerfilMantenimiento.Enabled = false;
            lbUsuarioMantenimiento.Enabled = false;
            txtUsuarioMantenimiento.Enabled = false;
            lbPersonaMantenimiento.Enabled = false;
            txtPersonaMantenimiento.Enabled = false;
            lbEmailMantenimiento.Enabled = false;
            txtEmailMantenimiento.Enabled = false;
           // lbClaveSeguridad.Enabled = false;
          //  txtClaveSeguridadMantenimeinto.Enabled = false;
            cbEstatusMantenimiento.Enabled = false;
            cbLlevaEmailMantenimiento.Enabled = false;
            cbCambiaClaveMantenimiento.Enabled = false;
         //   btnProcesarMantenimento.Enabled = false;
          //  btnVolverAtras.Enabled = false;
        }
        #endregion
        #region CARGAR EL DROP DE DEPARTAMENTOS
        private void CargarDepartamentos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoMantenimiento, ObjData.Value.BuscaListas("DEPARTAMENTOS", null, null));
        }
        #endregion
        #region CARGAR LOS PERFILES DE USUARIO
        private void CargarPerfiles()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPerfilMantenimiento, ObjData.Value.BuscaListas("PERFILES", null, null));
        }
        #endregion
        #region MANTENIMIENTO DE USUARIOS
        private void MANUsuarios(string Accion)
        {
            try {
                UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Mantenimiento = new Logica.Entidades.EMantenimientoUsuarios();

                Mantenimiento.IdUsuario = Convert.ToDecimal(lbIdUsuarioSeleccionado.Text);
                Mantenimiento.IdDepartamento = Convert.ToDecimal(ddlDepartamentoMantenimiento.SelectedValue);
                Mantenimiento.IdPerfil = Convert.ToDecimal(ddlPerfilMantenimiento.SelectedValue);
                Mantenimiento.Usuario = txtUsuarioMantenimiento.Text;
                Mantenimiento.Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtclave.Text);
                Mantenimiento.Persona = txtPersonaMantenimiento.Text;
                Mantenimiento.Estatus = cbEstatusMantenimiento.Checked;
                Mantenimiento.LlevaEmail = cbLlevaEmailMantenimiento.Checked;
                Mantenimiento.Email = txtEmailMantenimiento.Text;
                Mantenimiento.Contador = 0;
                Mantenimiento.CambiaClave = cbCambiaClaveMantenimiento.Checked;
                Mantenimiento.RazonBloqueo = txtRazonBloqueo.Text;

                var MAN = ObjData.Value.MantenimientoUsuarios(Mantenimiento, Accion);
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMantenimiento()", true);
            }
        }
        #endregion
        #region CAMBIAR CLAVE
        private void CambiaClave()
        {
            UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Mantenimiento = new Logica.Entidades.EMantenimientoUsuarios();

            Mantenimiento.IdUsuario = Convert.ToDecimal(lbIdUsuarioSeleccionado.Text);
            Mantenimiento.Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar("FuturoSeguros123");

            var MAN = ObjData.Value.MantenimientoUsuarios(Mantenimiento, "STARTCHANGEPASSWORD");
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarListadoUsuario();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoUsuario();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbEstatusMantenimiento.Text = "INSERT";
            lbIdUsuarioSeleccionado.Text = "0";
            MostrarControles();
            cbEstatusMantenimiento.Checked = true;
            cbLlevaEmailMantenimiento.Checked = true;
            cbCambiaClaveMantenimiento.Checked = true;
            txtUsuarioMantenimiento.Enabled = true;
            txtclave.Visible = true;
            txtConfirmarClave.Visible = true;
            btnProcesarMantenimento.Text = "Guardar";
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lbEstatusMantenimiento.Text = "UPDATE";
            MostrarControles();
            btnProcesarMantenimento.Text = "Modificar";
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            OcultarControles();
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            lbEstatusMantenimiento.Text = "DISABLE";
            MostrarControles();
            btnProcesarMantenimento.Text = "Deshabilitar";
            DeshabilitarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lbEstatusMantenimiento.Text = "DELETE";
            MostrarControles();
            btnProcesarMantenimento.Text = "Eliminar";
            DeshabilitarControles();
        }

        protected void gbListadoUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbListadoUsuarios.PageIndex = e.NewPageIndex;
            MostrarListadoUsuario();
        }

        protected void gbListadoUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gbListadoUsuarios.SelectedRow;

            var BuscarUsuario = ObjData.Value.BuscaUsuarios(
                Convert.ToDecimal(gb.Cells[1].Text));
            foreach (var n in BuscarUsuario)
            {
                lbIdUsuarioSeleccionado.Text = gb.Cells[1].Text;
            }
            gbListadoUsuarios.DataSource = BuscarUsuario;
            gbListadoUsuarios.DataBind();
            btnNuevo.Enabled = false;
            btnConsultar.Enabled = false;
            btnModificar.Enabled = true;
            btnDeshabilitar.Enabled = true;
            btnEliminar.Enabled = true;
            btnAtras.Enabled = true;
        }

        protected void btnProcesarMantenimento_Click(object sender, EventArgs e)
        {
            if (lbEstatusMantenimiento.Text == "INSERT")
            {
                //VERIFICAMOS LOS CAMPOS VACIOS
                if (string.IsNullOrEmpty(txtUsuarioMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtPersonaMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtclave.Text.Trim()) || string.IsNullOrEmpty(txtConfirmarClave.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "CamposVacios()", true);
                }
                else
                {
                    //VERIFICAMOS QUE LAS CLAVES INGRESADAS SON IGUALES
                    string clave = txtclave.Text;
                    string ConfirmarClafe = txtConfirmarClave.Text;

                    if (clave != ConfirmarClafe)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveNoConcuerdan()", true);
                        txtclave.Text = string.Empty;
                        txtConfirmarClave.Text = string.Empty;
                        txtclave.Focus();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtClaveSeguridadMantenimeinto.Text.Trim()))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadVacio()", true);
                        }
                        else
                        {
                            //VALIDAMOS LA CLAVE DE SEGURIDAD
                            var ValidarClaveSeguridad = ObjData.Value.BuscaClaveSeguridad(
                                new Nullable<decimal>(),
                                UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimeinto.Text));
                            if (ValidarClaveSeguridad.Count() < 1)
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida()", true);
                                txtClaveSeguridadMantenimeinto.Text = string.Empty;
                                txtClaveSeguridadMantenimeinto.Focus();
                            }
                            else
                            {
                                //VERIFICAMOS SI EL NOMBRE DE USUARIO INGRESADO YA ESTA CREADO
                                var ValidarUsuario = ObjData.Value.BuscaUsuarios(
                                    new Nullable<decimal>(),
                                    null, null, null, txtUsuarioMantenimiento.Text);
                                if (ValidarUsuario.Count() < 1)
                                {
                                    //REALIZAMOS EL MANTENIMIENTO CORRESPONIENTE
                                    MANUsuarios(lbEstatusMantenimiento.Text);
                                    //VERIFICAMOS SI SE VA A CAMBIAR LA CLAVE
                                    if (cbCambiaClaveMantenimiento.Checked)
                                    {
                                        CambiaClave();
                                    }
                                    OcultarControles();
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "UsuarioNoValido()", true);
                                }
                            }
                        }
                    }

                }
            }
            else if (lbEstatusMantenimiento.Text == "UPDATE")
            {
                if (string.IsNullOrEmpty(txtUsuarioMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtPersonaMantenimiento.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "CamposVacios()", true);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtClaveSeguridadMantenimeinto.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida()", true);
                        txtClaveSeguridadMantenimeinto.Text = string.Empty;
                        txtClaveSeguridadMantenimeinto.Focus();
                    }
                    else
                    {
                        //VALIDAMOS LA CLAVE DE SEGURIDAD
                        var ValidarClaveSeguridad = ObjData.Value.BuscaClaveSeguridad(
                            new Nullable<decimal>(),
                            UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimeinto.Text));
                        if (ValidarClaveSeguridad.Count() < 1)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida()", true);
                            txtClaveSeguridadMantenimeinto.Text = string.Empty;
                            txtClaveSeguridadMantenimeinto.Focus();
                        }
                        else
                        {
                            //REALIZAMOS EL MANTENIMIENTO CORRESPONIENTE
                            MANUsuarios(lbEstatusMantenimiento.Text);
                            //VERIFICAMOS SI SE VA A CAMBIAR LA CLAVE
                            if (cbCambiaClaveMantenimiento.Checked)
                            {
                                CambiaClave();
                            }
                            OcultarControles();
                        }
                    }
                }
            }
            else if (lbEstatusMantenimiento.Text == "DISABLE")
            {
                //VALIDAMOS LA CLAVE DE SEGURIDAD
                var ValidarClaveSeguridad = ObjData.Value.BuscaClaveSeguridad(
                    new Nullable<decimal>(),
                    UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimeinto.Text));
                if (ValidarClaveSeguridad.Count() < 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida()", true);
                    txtClaveSeguridadMantenimeinto.Text = string.Empty;
                    txtClaveSeguridadMantenimeinto.Focus();
                }
                else
                {
                    //REALIZAMOS EL MANTENIMIENTO CORRESPONIENTE
                    MANUsuarios(lbEstatusMantenimiento.Text);
                    OcultarControles();
                }
            }
            else if (lbEstatusMantenimiento.Text == "DELETE")
            {
                //VALIDAMOS LA CLAVE DE SEGURIDAD
                var ValidarClaveSeguridad = ObjData.Value.BuscaClaveSeguridad(
                    new Nullable<decimal>(),
                    UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimeinto.Text));
                if (ValidarClaveSeguridad.Count() < 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida()", true);
                    txtClaveSeguridadMantenimeinto.Text = string.Empty;
                    txtClaveSeguridadMantenimeinto.Focus();
                }
                else
                {
                    //REALIZAMOS EL MANTENIMIENTO CORRESPONIENTE
                    MANUsuarios(lbEstatusMantenimiento.Text);
                    OcultarControles();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorProceso()", true);
            }
        }

        protected void cbEstatusMantenimiento_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cbLlevaEmailMantenimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLlevaEmailMantenimiento.Checked == true)
            {
                txtEmailMantenimiento.Visible = true;
                lbEmailMantenimiento.Visible = true;
            }
            else
            {
                txtEmailMantenimiento.Visible = false;
                lbEmailMantenimiento.Visible = false;
                txtEmailMantenimiento.Text = string.Empty;
            }
        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {
            OcultarControles();
        }

        protected void gbListadoUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                e.Row.Cells[1].Visible = false;
            }
            catch (Exception) { }
        }
    }
}
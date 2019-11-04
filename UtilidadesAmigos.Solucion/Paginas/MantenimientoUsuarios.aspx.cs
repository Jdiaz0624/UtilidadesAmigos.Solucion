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

        #region MOSTRAR EL LISTADO DE LOS USUARIOS
        private void MostrarUsuarios()
        {
            string _Usuario = string.IsNullOrEmpty(txtUsuarioFiltro.Text.Trim()) ? null : txtUsuarioFiltro.Text.Trim();

            var Buscar = ObjData.Value.BuscaUsuarios(
                new Nullable<decimal>(),
                null,
                null,
                _Usuario,
                null,
                null,
                null,
                Convert.ToInt32(txtNumeroPaginas.Text),
                Convert.ToInt32(txtNumeroRegistros.Text));
            gbListadoUsuarios.DataSource = Buscar;
            gbListadoUsuarios.DataBind();
            txtNumeroPaginas.Visible = true;
            txtNumeroRegistros.Visible = true;
            
         //   gbListadoUsuarios.Columns[1].Visible = false;

        }
        #endregion
        #region OCULTAR Y MOSTRAR CONTROLES
        private void OcultarControles()
        {
            lbSubEncabezadoMantenimiento.Visible = false;
            lbDepartamentoMantenimiento.Visible = false;
            ddlDepartamentoMantenimiento.Visible = false;
            lbPerfilMantenimiento.Visible = false;
            ddlPerfilMantenimiento.Visible = false;
            lbUsuarioMantenimiento.Visible = false;
            txtUsuarioMantenimiento.Visible = false;
            lbClaveMantenimiento.Visible = false;
            txtClaveMantenimiento.Visible = false;
            lbConfirmarClaveMantenimiento.Visible = false;
            txtConfirmarClaveMantenimiento.Visible = false;
            lbPersonaMantenimiento.Visible = false;
            txtPersonaMantenimiento.Visible = false;
            cbEstatusMantenimiento.Visible = false;
            cbLlevaEmailMantenimiento.Visible = false;
            lbEmailMantenimiento.Visible = false;
            txtEmailMantenimiento.Visible = false;
            cbCambiaClaveMantenimiento.Visible = false;
            txtClaveSeguridadMantenimeinto.Visible = false;
            btnProcesarMantenimento.Visible = false;
            txtNumeroPaginas.Visible = false;
            txtNumeroRegistros.Visible = false;
        }

        private void MostrarControles()
        {
            lbSubEncabezadoMantenimiento.Visible = true;
            lbDepartamentoMantenimiento.Visible = true;
            ddlDepartamentoMantenimiento.Visible = true;
            lbPerfilMantenimiento.Visible = true;
            ddlPerfilMantenimiento.Visible = true;
            lbUsuarioMantenimiento.Visible = true;
            txtUsuarioMantenimiento.Visible = true;
            lbClaveMantenimiento.Visible = true;
            txtClaveMantenimiento.Visible = true;
            lbConfirmarClaveMantenimiento.Visible = true;
            txtConfirmarClaveMantenimiento.Visible = true;
            lbPersonaMantenimiento.Visible = true;
            txtPersonaMantenimiento.Visible = true;
            cbEstatusMantenimiento.Visible = true;
            cbLlevaEmailMantenimiento.Visible = true;
            lbEmailMantenimiento.Visible = true;
            txtEmailMantenimiento.Visible = true;
            cbCambiaClaveMantenimiento.Visible = true;
            txtClaveSeguridadMantenimeinto.Visible = true;
            btnProcesarMantenimento.Visible = true;
            txtNumeroPaginas.Visible = true;
            txtNumeroRegistros.Visible = true;
        }
        #endregion
        #region CARGAR LOS DROP
        //CARGAR LOS DEPARTAMENTOS
        private void CargarDepartamentos()
        {
            var Departamentos = ObjData.Value.CargarDepartamentos(
                new Nullable<decimal>(),
               null);
            ddlDepartamentoMantenimiento.DataSource = Departamentos;
            ddlDepartamentoMantenimiento.DataTextField = "Departamento";
            ddlDepartamentoMantenimiento.DataValueField = "IdDepartamento";
            ddlDepartamentoMantenimiento.DataBind();
        }
        private void CargarPerfiles()
        {
            var Perfil = ObjData.Value.CargarPerfiles(
                new Nullable<decimal>(),
                null);
            ddlPerfilMantenimiento.DataSource = Perfil;
            ddlPerfilMantenimiento.DataTextField = "Perfil";
            ddlPerfilMantenimiento.DataValueField = "IdPerfil";
            ddlPerfilMantenimiento.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE USUARIOS
        private void MANUsuariosMAN(decimal IdUsuario, string ClaveEncriptada, string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Mantenimiento = new Logica.Entidades.EMantenimientoUsuarios();

            Mantenimiento.IdUsuario = IdUsuario;
            Mantenimiento.IdDepartamento = Convert.ToDecimal(ddlDepartamentoMantenimiento.SelectedValue);
            Mantenimiento.IdPerfil = Convert.ToDecimal(ddlPerfilMantenimiento.SelectedValue);
            Mantenimiento.Usuario = txtUsuarioMantenimiento.Text;
            Mantenimiento.Clave = ClaveEncriptada;
            Mantenimiento.Persona = txtPersonaMantenimiento.Text;
            Mantenimiento.Estatus = cbEstatusMantenimiento.Checked;
            Mantenimiento.LlevaEmail = cbLlevaEmailMantenimiento.Checked;
            Mantenimiento.Email = txtEmailMantenimiento.Text;
            Mantenimiento.Contador = 0;
            Mantenimiento.CambiaClave = cbCambiaClaveMantenimiento.Checked;
            Mantenimiento.RazonBloqueo = "N/A";

            var MAN = ObjData.Value.MantenimientoUsuarios(Mantenimiento, Accion);
        }
        #endregion
        #region LIMPIAR CONTROLES
        private void LimpiarControles()
        {
            ddlDepartamentoMantenimiento.Items.Clear();
            ddlPerfilMantenimiento.Items.Clear();
            txtUsuarioMantenimiento.Text = string.Empty;
            txtClaveMantenimiento.Text = string.Empty;
            txtConfirmarClaveMantenimiento.Text = string.Empty;
            txtPersonaMantenimiento.Text = string.Empty;
            cbEstatusMantenimiento.Checked = false;
            cbLlevaEmailMantenimiento.Checked = false;
            txtEmailMantenimiento.Text = string.Empty;
            cbCambiaClaveMantenimiento.Checked = false;
        }
        #endregion
        #region VOLVER ATRAS
        private void VolverAtras()
        {
            LimpiarControles();
            OcultarControles();
            gbListadoUsuarios.Visible = true;
            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnAtras.Enabled = false;
            btnDeshabilitar.Enabled = false;
            btnEliminar.Enabled = false;
            txtNumeroPaginas.Enabled = true;
            txtNumeroRegistros.Enabled = true;
            MostrarUsuarios();
            HabilitarControles();
        }
        #endregion
        #region HABILITAR Y DESHABILITAR CONTROLES
        private void HabilitarControles()
        {
            ddlDepartamentoMantenimiento.Enabled = true;
            ddlPerfilMantenimiento.Enabled = true;
            txtUsuarioMantenimiento.Enabled = true;
            txtClaveMantenimiento.Enabled = true;
            txtConfirmarClaveMantenimiento.Enabled = true;
            txtPersonaMantenimiento.Enabled = true;
            txtEmailMantenimiento.Enabled = true;
            cbEstatusMantenimiento.Enabled = true;
            cbLlevaEmailMantenimiento.Enabled = true;
            cbCambiaClaveMantenimiento.Enabled = true;
        }
        private void DeshabilitarControles()
        {
            ddlDepartamentoMantenimiento.Enabled = false;
            ddlPerfilMantenimiento.Enabled = false;
            txtUsuarioMantenimiento.Enabled = false;
            txtClaveMantenimiento.Enabled = false;
            txtConfirmarClaveMantenimiento.Enabled = false;
            txtPersonaMantenimiento.Enabled = false;
            txtEmailMantenimiento.Enabled = false;
            cbEstatusMantenimiento.Enabled = false;
            cbLlevaEmailMantenimiento.Enabled = false;
            cbCambiaClaveMantenimiento.Enabled = false;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                OcultarControles();
                txtNumeroPaginas.Visible = false;
                txtNumeroRegistros.Visible = false;
                btnConsultar.Enabled = true;
                btnNuevo.Enabled = true;
                btnModificar.Enabled = false;
                btnAtras.Enabled = false;
                btnEliminar.Enabled = false;
                btnDeshabilitar.Enabled = false;
                if (cbEstatusMantenimiento.Checked == true)
                {
                    cbEstatusMantenimiento.ForeColor = System.Drawing.Color.ForestGreen;
                    cbEstatusMantenimiento.Text = "ACTIVO";
                }
                else
                {
                    cbEstatusMantenimiento.ForeColor = System.Drawing.Color.Red;
                    cbEstatusMantenimiento.Text = "INACTIVO";
                }
            }
        }

        protected void gbListadoUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            txtUsuarioFiltro.Text = string.Empty;
           // gbListadoUsuarios.PageIndex = e.NewPageIndex;
            MostrarUsuarios();

        }

        protected void gbListadoUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUsuarioFiltro.Text = gbListadoUsuarios.SelectedRow.Cells[0].Text;
            
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
           
            MostrarUsuarios();
            
        }

        protected void cbLlevaEmailMantenimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLlevaEmailMantenimiento.Checked)
            {
                txtEmailMantenimiento.Text = string.Empty;
                txtEmailMantenimiento.Enabled = true;
            }
            else
            {
                txtEmailMantenimiento.Text = string.Empty;
                txtEmailMantenimiento.Enabled = false;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            
            lbSubEncabezadoMantenimiento.Text = "Guardar Usuarios";
            btnProcesarMantenimento.Text = "GUARDAR";
            gbListadoUsuarios.Visible = false;
            MostrarControles();
            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnAtras.Enabled = true;
            btnEliminar.Enabled = false;
            btnDeshabilitar.Enabled = false;
            CargarDepartamentos();
            CargarPerfiles();
            cbEstatusMantenimiento.Checked = true;
            cbLlevaEmailMantenimiento.Checked = true;
            cbCambiaClaveMantenimiento.Checked = true;
            if (cbEstatusMantenimiento.Checked == true)
            {
                cbEstatusMantenimiento.Visible = false;
            }
            else
            {
                cbEstatusMantenimiento.Visible = true;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            gbListadoUsuarios.Visible = false;
            txtNumeroPaginas.Visible = false;
            txtNumeroRegistros.Visible = false;
            MostrarControles();
            CargarDepartamentos();
            CargarPerfiles();
            //SACAMOS LOS DATOS DEL USUARIO SELECCIONADO

            var SacarDatosUsuarios = ObjData.Value.BuscaUsuarios(
                Convert.ToDecimal(lbIdUsuarioSeleccionado.Text),
                null,
                null,
                null,
                null,
                null,
                null, 1, 1);
            foreach (var n in SacarDatosUsuarios)
            {
                ddlDepartamentoMantenimiento.SelectedValue = n.IdDepartamento.ToString();
                ddlPerfilMantenimiento.SelectedValue = n.IdPerfil.ToString();
                txtUsuarioMantenimiento.Text = n.Usuario;
                txtClaveMantenimiento.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                txtConfirmarClaveMantenimiento.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                cbEstatusMantenimiento.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                cbLlevaEmailMantenimiento.Checked = (n.LlevaEmail0.HasValue ? n.LlevaEmail0.Value : false);
                txtEmailMantenimiento.Text = n.Email;
                txtPersonaMantenimiento.Text = n.Persona;
                cbCambiaClaveMantenimiento.Checked = (n.CambiaClave0.HasValue ? n.CambiaClave0.Value : false);
            }
            lbSubEncabezadoMantenimiento.Text = "Modificar Registro Seleccionado";
            btnProcesarMantenimento.Text = "Modificar";
            if (cbEstatusMantenimiento.Checked == true)
            {
                cbEstatusMantenimiento.Visible = false;
            }
            else
            {
                cbEstatusMantenimiento.Visible = true;
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
           // Accion = "DESHABILITAR";
            lbSubEncabezadoMantenimiento.Text = "Deshabilitar Registro Seleccionado";
            btnProcesarMantenimento.Text = "DESHABILITAR";
            MostrarControles();
            CargarDepartamentos();
            CargarPerfiles();
            var SacarDatosUsuario = ObjData.Value.BuscaUsuarios(
                Convert.ToDecimal(lbIdUsuarioSeleccionado.Text),
                null, null, null, null, null, null, 1, 1);
            foreach (var n in SacarDatosUsuario)
            {
                ddlDepartamentoMantenimiento.SelectedValue = n.IdDepartamento.ToString();
                ddlPerfilMantenimiento.SelectedValue = n.IdPerfil.ToString();
                txtUsuarioMantenimiento.Text = n.Usuario;

            }

            DeshabilitarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //  Accion = "DELETE";
            // Accion = "DESHABILITAR";
            lbSubEncabezadoMantenimiento.Text = "Eliminar Registro Seleccionado";
            btnProcesarMantenimento.Text = "ELIMINAR";
            MostrarControles();
            CargarDepartamentos();
            CargarPerfiles();
            var SacarDatosUsuario = ObjData.Value.BuscaUsuarios(
                Convert.ToDecimal(lbIdUsuarioSeleccionado.Text),
                null, null, null, null, null, null, 1, 1);
            foreach (var n in SacarDatosUsuario)
            {
                ddlDepartamentoMantenimiento.SelectedValue = n.IdDepartamento.ToString();
                ddlPerfilMantenimiento.SelectedValue = n.IdPerfil.ToString();
                txtUsuarioMantenimiento.Text = n.Usuario;

            }

            DeshabilitarControles();
        }

        protected void btnProcesarMantenimento_Click(object sender, EventArgs e)
        {

            string  ClaveEncriptada = "", Clave = "", ConfirmarClave = "", ClaveSeguridad = "";

            if (lbSubEncabezadoMantenimiento.Text == "Guardar Usuarios")
            {
                //ESTE BLOQUE DE CODIGO ES PARA CREAR UN NUEVO REGISTRO

                //VERIFICAMOS SI HAY CAMPOS VACIOS PARA GUARDAR EL REGISTRO
                if (string.IsNullOrEmpty(txtUsuarioMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtClaveMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtConfirmarClaveMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtPersonaMantenimiento.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para ingresar al sistema');", true);
                }
                else
                {
                    //VALIDAMOS SI SL USUARIO INGRESADO YA ESTA CREADO EN LA BASE DE DATOS
                    string _Usuario = string.IsNullOrEmpty(txtUsuarioMantenimiento.Text.Trim()) ? null : txtUsuarioMantenimiento.Text.Trim();

                    var ValidarUsuarioBD = ObjData.Value.BuscaUsuarios(
                        new Nullable<decimal>(),
                        null,
                        null,
                        null,
                        _Usuario,
                        null,
                        null,
                        1, 1);
                    if (ValidarUsuarioBD.Count() < 1)
                    {
                        //VRIFICAMOS SI LAS DOS CLAVES INGRESADAS SON IGUALES
                        Clave = txtClaveMantenimiento.Text;
                        ConfirmarClave = txtConfirmarClaveMantenimiento.Text;

                        if (Clave != ConfirmarClave)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Las claves ingresadas no concuerdan favor de verificar');", true);
                            txtClaveMantenimiento.Text = string.Empty;
                            txtConfirmarClaveMantenimiento.Text = string.Empty;
                            txtClaveSeguridadMantenimeinto.Focus();
                        }
                        else
                        {
                            //ENCRIPTAMOS LA CLAVE
                            ClaveEncriptada = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(Clave);

                            //VERIFICAMOS SI EL CAMPO DE SEGURIDAD ESTA VACIO
                            if (string.IsNullOrEmpty(txtClaveSeguridadMantenimeinto.Text.Trim()))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo clave de seguridad no puede estar en blanco, favor de verificar');", true);
                                txtClaveSeguridadMantenimeinto.Focus();
                            }
                            else
                            {
                                //VERIFICAMOS SI LA CLAVE DE SEGURIDAD INGRESADA ES VALIDA
                                ClaveSeguridad = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimeinto.Text);

                                var ValidarClaveSeguridad = ObjData.Value.BuscaClaveSeguridad(
                                    Convert.ToDecimal(Session["IdUsuario"]),
                                    ClaveSeguridad);
                                if (ValidarClaveSeguridad.Count() < 1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La clave de seguridad ingresada no es valida favor de verificar');", true);
                                    txtClaveSeguridadMantenimeinto.Text = string.Empty;
                                    txtClaveSeguridadMantenimeinto.Focus();
                                }
                                else
                                {
                                    //PROCEDEMOS A GUARDAR EL REGISTRO
                                    MANUsuariosMAN(0, ClaveEncriptada, "INSERT");
                                    txtUsuarioFiltro.Text = txtUsuarioMantenimiento.Text;
                                    VolverAtras();
                                }


                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El nombre de usuario ingrsado ya se encuentra registrado, favor verificar');", true);
                    }

                }

            }
            else if (lbSubEncabezadoMantenimiento.Text == "Modificar Registro Seleccionado")
            {
                //ESTA COLUMNA ES PARA MODIFICAR UN USUARIO SELECCIONADO
                //Verificamos los campos vacios
                if (string.IsNullOrEmpty(txtUsuarioMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtPersonaMantenimiento.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar el campo usuario o el campo persona vacios para modificar este registro');", true);
                }
                else
                {
                    //VERIFICAMOS SI LA CLAVE DE SEGURIDAD ESTA VACIA
                    if (string.IsNullOrEmpty(txtClaveSeguridadMantenimeinto.Text.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar el campo clave de seguridad vacio para modificar este registro');", true);
                    }
                    else
                    {
                        string ClaveSeguridadModificar = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimeinto.Text);
                        //VERIFICAMOS SI LA CLAVE DE SEGURIDAD INGRESADA ES CORRECTA
                        var ValidarClaveSeguridad = ObjData.Value.BuscaClaveSeguridad(
                            Convert.ToDecimal(Session["IdUsuario"]),
                            ClaveSeguridadModificar);
                        if (ValidarClaveSeguridad.Count() < 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La clave de seguridad ingresada no es valida');", true);
                            txtClaveSeguridadMantenimeinto.Text = string.Empty;
                            txtClaveSeguridadMantenimeinto.Focus();
                        }
                        else
                        {
                            string ClaveUsuario = "";
                            //SACAMOS LA CLAVE
                            if (cbCambiaClaveMantenimiento.Checked)
                            {
                                ClaveUsuario = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar("Amigos123");
                            }
                            else
                            {
                                var SacarClaveUsuario = ObjData.Value.BuscaUsuarios(
                                Convert.ToDecimal(lbIdUsuarioSeleccionado.Text),
                                null, null, null, null,
                                null, null, 1, 1);
                                foreach (var n in SacarClaveUsuario)
                                {
                                    ClaveUsuario = n.Clave;
                                }
                            }
                            //MODIFICAR EL REGISTRO
                            UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Modificar = new Logica.Entidades.EMantenimientoUsuarios();

                            Modificar.IdUsuario = Convert.ToDecimal(lbIdUsuarioSeleccionado.Text);
                            Modificar.IdDepartamento = Convert.ToDecimal(ddlDepartamentoMantenimiento.SelectedValue);
                            Modificar.IdPerfil = Convert.ToDecimal(ddlPerfilMantenimiento.SelectedValue);
                            Modificar.Usuario = txtUsuarioMantenimiento.Text;
                            Modificar.Clave = ClaveUsuario;
                            Modificar.Persona = txtPersonaMantenimiento.Text;
                            Modificar.Estatus = cbEstatusMantenimiento.Checked;
                            Modificar.LlevaEmail = cbLlevaEmailMantenimiento.Checked;
                            Modificar.Email = txtEmailMantenimiento.Text;
                            Modificar.Contador = 0;
                            Modificar.CambiaClave = cbCambiaClaveMantenimiento.Checked;
                            Modificar.RazonBloqueo = "N/A";

                            var MAn = ObjData.Value.MantenimientoUsuarios(Modificar, "UPDATE");
                            VolverAtras();

                        }
                    }
                }
            }
            else if (lbSubEncabezadoMantenimiento.Text == "Deshabilitar Registro Seleccionado")
            {
                //ESTE BLOQUE DE CODIGO ES PARA DESHABILITAR USUARIOS SELECCIONADS
                //VERIFICAMOS SI LA CLAVE DE SEGURIDAD ESTA VACIA
                if (string.IsNullOrEmpty(txtClaveSeguridadMantenimeinto.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo clave de seguridad no puede estar vacio favor de verificar')", true);
                    txtClaveSeguridadMantenimeinto.Focus();
                }
                else
                {
                    string ClaveS = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimeinto.Text);
                    //VERIFICAMOS SI LA CLAVE DE SEGURIDAD INGRESADA ES VALIDA
                    var VerificarClave = ObjData.Value.BuscaClaveSeguridad
                        (Convert.ToDecimal(Session["IdUsuario"]),
                        ClaveS);
                    if (VerificarClave.Count() < 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La clave de seguridad ingresada no es valida, favor de verificar')", true);
                        txtClaveMantenimiento.Text = string.Empty;
                        txtClaveMantenimiento.Focus();
                    }
                    else
                    {
                        //PROCEDEMOS A DESHABILITAR EL REGISTRO
                        MANUsuariosMAN(
                            Convert.ToDecimal(lbIdUsuarioSeleccionado.Text),
                            ClaveS,
                            "DESHABILITAR");
                        VolverAtras();
                    }
                        
                }
            }
            else if (lbSubEncabezadoMantenimiento.Text == "Eliminar Registro Seleccionado")
            {
                //ESTE BLOQUE DE CODIGO ES PARA ELIMINAR USUARIOS SELECCIONADOS
                //VERIFICAMOS SI LA CLAVE DE SEGURIDAD ESTA VACIA
                if (string.IsNullOrEmpty(txtClaveSeguridadMantenimeinto.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo clave de seguridad no puede estar vacio para eliminar este registro')", true);
                    txtClaveSeguridadMantenimeinto.Focus();
                }
                else
                {
                    //VERIFICAMOS SI LA CLAVE INGRESADA ES VALIDA
                    string ClaveS = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridadMantenimeinto.Text);

                    var VerificarClave = ObjData.Value.BuscaClaveSeguridad(
                        Convert.ToDecimal(Session["IdUsuario"]),
                        ClaveS);
                    if (VerificarClave.Count() < 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La clave de seguridad ingresada no es valida, favor de verificar')", true);
                        txtClaveSeguridadMantenimeinto.Text = string.Empty;
                        txtClaveSeguridadMantenimeinto.Focus();
                    }
                    else
                    {
                        //PROCEDEMOS A ELIMINAR EL REGISTRO
                        MANUsuariosMAN(
                            Convert.ToDecimal(lbIdUsuarioSeleccionado.Text),
                            ClaveS,
                            "DELETE");
                        VolverAtras();
                    }
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            VolverAtras();
            
        }

        protected void txtNumeroPaginas_TextChanged(object sender, EventArgs e)
        {
            try {
                if (Convert.ToInt32(txtNumeroPaginas.Text) < 1)
                {
                    txtNumeroPaginas.Text = string.Empty;
                    txtNumeroPaginas.Text = "1";
                    MostrarUsuarios();
                }
                else
                {
                    MostrarUsuarios();
                }
            }
            catch (Exception) { }
        }

        protected void txtNumeroRegistros_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtNumeroRegistros.Text) < 1)
                {
                    txtNumeroRegistros.Text = string.Empty;
                    txtNumeroRegistros.Text = "10";
                    MostrarUsuarios();
                }
                else
                {
                    MostrarUsuarios();
                }
            }
            catch (Exception) { }
        }

        protected void gbListadoUsuarios_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow gb = gbListadoUsuarios.SelectedRow;
            lbIdUsuarioSeleccionado.Text = gb.Cells[1].Text;
            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnAtras.Enabled = true;
            btnDeshabilitar.Enabled = true;
            btnEliminar.Enabled = true;
            txtNumeroPaginas.Enabled = false;
            txtNumeroRegistros.Enabled = false;

            var Buscar = ObjData.Value.BuscaUsuarios(
                Convert.ToDecimal(lbIdUsuarioSeleccionado.Text),
                null,
                null,
                null,
                null,
                null,
                null,
                1, 1);
            gbListadoUsuarios.DataSource = Buscar;
            gbListadoUsuarios.DataBind();
        }

        protected void gbListadoUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;

        }

        protected void cbEstatusMantenimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEstatusMantenimiento.Checked)
            {
                cbEstatusMantenimiento.ForeColor = System.Drawing.Color.ForestGreen;
                cbEstatusMantenimiento.Text = "ACTIVO";
            }
            else
            {
                cbEstatusMantenimiento.ForeColor = System.Drawing.Color.Red;
                cbEstatusMantenimiento.Text = "INACTIVO";
            }
        }

      
    }
}
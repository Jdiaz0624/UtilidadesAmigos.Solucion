using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoClaveSeguridad : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objadata = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjdataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        #region MOSTRAR EL LISTADO DE LA CLAVE DE SEGURIDAD
        private void MostrarListadoClaveSeguridad()
        {
            var Mostrar = Objadata.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                null);
            gbListadoClaveSeguridad.DataSource = Mostrar;
            gbListadoClaveSeguridad.DataBind();
        }
        #endregion
        #region MOSTRAR Y OCLTAR CONTROLES
        private void MostrarControles()
        {
            lbusuario.Visible = false;
            txtUsuario.Visible = false;
            btnNuevo.Visible = false;
            btnConsultar.Visible = false;
            btnModificar.Visible = false;
            btnDeshabilitar.Visible = false;
            btnAtras.Visible = false;
            gbListadoClaveSeguridad.Visible = false;
            lbClaveNueva.Visible = true;
            txtClaveNueva.Visible = true;
            lbConfirmarClave.Visible = true;
            txtConfirmarClave.Visible = true;
            lbSeleccionarUsuario.Visible = true;
            ddlSeleccionarusuario.Visible = true;
            lbClaveSeguridad.Visible = true;
            txtClaveSeguridad.Visible = true;
            cbEstatus.Visible = false;
            btnGuardar.Visible = true;
            btnVolver.Visible = true;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarusuario, Objadata.Value.BuscaListas("USUARIOS", null, null));

            //SACAMOS LOS DATOS DE LA CLAVE DE SEGURIDAD
            if (lbAccion.Text != "INSERT")
            {
                var SacarDatosClave = Objadata.Value.BuscaClaveSeguridad(
                    Convert.ToDecimal(lbIdClaveSeguridad.Text));
                foreach (var n in SacarDatosClave)
                {
                    txtClaveNueva.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                    txtConfirmarClave.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                    UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarusuario, n.IdUsuario.ToString());
                    cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                    if (cbEstatus.Checked == true)
                    {
                        cbEstatus.Visible = false;
                    }
                    else
                    {
                        cbEstatus.Visible = true;
                    }
                }
            }
        }
        private void OcultarControles()
        {
            lbusuario.Visible = true;
            txtUsuario.Visible = true;
            btnNuevo.Visible = true;
            btnConsultar.Visible = true;
            btnModificar.Visible = true;
            btnAtras.Visible = true;
            btnDeshabilitar.Visible = true;
            gbListadoClaveSeguridad.Visible = true;
            lbClaveNueva.Visible = false;
            txtClaveNueva.Visible = false;
            lbConfirmarClave.Visible = false;
            txtConfirmarClave.Visible = false;
            lbSeleccionarUsuario.Visible = false;
            ddlSeleccionarusuario.Visible = false;
            lbClaveSeguridad.Visible = false;
            txtClaveSeguridad.Visible = false;
            btnGuardar.Visible = false;
            btnVolver.Visible = false;
            txtUsuario.Text = string.Empty;
            MostrarListadoClaveSeguridad();
        }
        #endregion
        #region Mantenimiento de clave de seguridad3
        private void MANClaveSeguridad(string Accion)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try {
                    UtilidadesAmigos.Logica.Entidades.Seguridad.EMantenimientoClaveSeguridad Mantenimeitn = new Logica.Entidades.Seguridad.EMantenimientoClaveSeguridad();

                    Mantenimeitn.IdClaveSeguridad = Convert.ToDecimal(lbIdClaveSeguridad.Text);
                    Mantenimeitn.IdUsuario = Convert.ToDecimal(ddlSeleccionarusuario.SelectedValue);
                    Mantenimeitn.Clave = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveNueva.Text);
                    Mantenimeitn.Estatus = cbEstatus.Checked;

                    var MAN = ObjdataSeguridad.Value.MAntenimientoClaveSeguridad(Mantenimeitn, Accion);
                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorMantenimiento();", true);

                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarListadoClaveSeguridad();
            }
        }

        protected void gbListadoClaveSeguridad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoClaveSeguridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gn = gbListadoClaveSeguridad.SelectedRow;

            var Buscar = Objadata.Value.BuscaClaveSeguridad(
                Convert.ToDecimal(gn.Cells[1].Text));
            gbListadoClaveSeguridad.DataSource = Buscar;
            gbListadoClaveSeguridad.DataBind();
            foreach (var n in Buscar)
            {
                lbIdClaveSeguridad.Text = n.IdClaveSeguridad.ToString();
            }
        }

        protected void gbListadoClaveSeguridad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                e.Row.Cells[1].Visible = false;
            }
            catch (Exception) { }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbIdClaveSeguridad.Text = "0";
            lbAccion.Text = "INSERT";
            MostrarControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS LOS CAMPOS VACIOS
            if (string.IsNullOrEmpty(txtClaveNueva.Text.Trim()) || string.IsNullOrEmpty(txtConfirmarClave.Text.Trim()) || string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "CamposVacios();", true);
            }
            else
            {
                //VERIFICAMOS QUE LAS CLAVES INGRESADA SON VALIDAS
                string _ClaveNueva = txtClaveNueva.Text;
                string _ConfirmarClave = txtConfirmarClave.Text;

                if (_ClaveNueva != _ConfirmarClave)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClavesNoConcuerdan();", true);
                }
                else
                {
                    //VERIFICAMOS LA CLAVE DE SEGURIDAD
                    var ValidarClaveSeguridad = Objadata.Value.BuscaClaveSeguridad(
                        new Nullable<decimal>(),
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridad.Text));
                    if (ValidarClaveSeguridad.Count() < 1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida();", true);
                        txtClaveSeguridad.Text = string.Empty;
                        txtClaveSeguridad.Focus();
                    }
                    else
                    {
                        if (lbAccion.Text == "INSERT")
                        {
                            //VERIFICAMOS SI EL USUARIO YA TIENE UNA CLAVE ASIGNADA
                            var VerificarUsuariolave = Objadata.Value.BuscaClaveSeguridad(
                                Convert.ToDecimal(ddlSeleccionarusuario.SelectedValue),
                                null);
                            if (VerificarUsuariolave.Count() < 1)
                            {
                                MANClaveSeguridad(lbAccion.Text);
                                OcultarControles();
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "UsuarioENcontrado();", true);
                            }
                        }
                        else if (lbAccion.Text == "UPDATE")
                        {
                            MANClaveSeguridad(lbAccion.Text);
                            OcultarControles();
                        }
                        else if (lbAccion.Text == "DISABLE")
                        {
                            MANClaveSeguridad(lbAccion.Text);
                            OcultarControles();
                        }
                    }
                }
            }
         
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            MostrarControles();
        }
    }
}
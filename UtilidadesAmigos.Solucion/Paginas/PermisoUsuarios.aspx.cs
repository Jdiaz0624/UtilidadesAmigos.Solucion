using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class PermisoUsuarios : System.Web.UI.Page
    {
        UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.Logica.LogicaSistema();

        #region DESACTIVAR Y ACTIVAR CONTROLES
        private void DesactivarControles()
        {
            txtClaveSeguridad.Enabled = true;
            txtUsuarioFiltro.Enabled = false;
            btnBuscarRegistros.Enabled = false;
            btnAtras.Enabled = false;
            btnProcesar.Enabled = true;
            txtNumeroPagina.Enabled = false;
            txtNumeroRegistros.Enabled = false;
            gbListadoUsuarios.Enabled = false;
            gbListadoPermisousuarios.Enabled = false;
        }
        private void ActivarControles()
        {
            txtClaveSeguridad.Enabled = false;
            txtUsuarioFiltro.Enabled = true;
            btnBuscarRegistros.Enabled = true;
            btnAtras.Enabled = true;
            btnProcesar.Enabled = false;
            txtNumeroPagina.Enabled = true;
            txtNumeroRegistros.Enabled = true;
            gbListadoUsuarios.Enabled = true;
            gbListadoPermisousuarios.Enabled = true;
        }
        #endregion
        #region BUSCAR USUARIOS
        private void Buscarusuarios()
        {
            string _Usuario = string.IsNullOrEmpty(txtUsuarioFiltro.Text.Trim()) ? null : txtUsuarioFiltro.Text.Trim();

            var Buscar = ObjData.BuscaUsuarios(
                new Nullable<decimal>(),
                null, null, null, null,
                _Usuario,
                null, null, null);
            gbListadoUsuarios.DataSource = Buscar;
            gbListadoUsuarios.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DesactivarControles();
                lbSubEncabezadoPermisoPerfil.Visible = false;
                gbListadoPermisousuarios.Visible = false;
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS SI EL CAMPO CLAVE DE SEGURIDAD ESTA VACIO
            if (string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo clave de seguridad no puede estar vacio, favor de verificar')", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La clave de seguridad ingresada no es valida, favor de verificar')", true);
                txtClaveSeguridad.Focus();
            }
            else
            {
                //VERIFICAMOS SI LA CLAVE DE SEGURIDAD INGRESADA ES VALIDA
                string ClaveS = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridad.Text);

                var VerificarClave = ObjData.BuscaClaveSeguridad(
                    Convert.ToDecimal(Session["IdUsuario"]),
                    ClaveS);
                if (VerificarClave.Count() < 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La clave de seguridad ingresada no es valida, favor de verificar')", true);
                    txtClaveSeguridad.Text = string.Empty;
                    txtClaveSeguridad.Focus();
                }
                else
                {
                    ActivarControles();
                    Buscarusuarios();
                }
            }
        }

        protected void btnBuscarRegistros_Click(object sender, EventArgs e)
        {
            Buscarusuarios();
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
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[15].Visible = false;
        }
    }
}
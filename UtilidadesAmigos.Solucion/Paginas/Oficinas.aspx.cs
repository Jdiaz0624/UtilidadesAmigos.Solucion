using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Mantenimientos
{
    public partial class Oficinas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> Objdata = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataSistema = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR EL LISTADO DE LAS OFICINAS
        private void MostrarOficinas()
        {
            string _Oficina = string.IsNullOrEmpty(txtDescripcionOficina.Text.Trim()) ? null : txtDescripcionOficina.Text.Trim();

            var Buscar = Objdata.Value.BuscaOficinas(
                new Nullable<decimal>(),
                _Oficina);
            gvOficinas.DataSource = Buscar;
            gvOficinas.DataBind();
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void MostrarControles()
        {
            lbDescripcion.Visible = false;
            txtDescripcionOficina.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            btnRestabelcer.Visible = false;
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnExportar.Visible = false;
            gvOficinas.Visible = false;

            lbOficina.Visible = true;
            txtDescripcionOficinaMAn.Visible = true;
            lbClaveSeguridad.Visible = true;
            txtClaveSeguridad.Visible = true;
            cbEstatus.Visible = true;
            btnGuardar.Visible = true;
            btnVolver.Visible = true;
        }

        private void OcultarControles()
        {
            lbDescripcion.Visible = true;
            txtDescripcionOficina.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            btnRestabelcer.Visible = true;
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            btnExportar.Visible = true;
            gvOficinas.Visible = true;

            lbOficina.Visible = false;
            txtDescripcionOficinaMAn.Visible = false;
            lbClaveSeguridad.Visible = false;
            txtClaveSeguridad.Visible = false;
            cbEstatus.Visible = false;
            btnGuardar.Visible = false;
            btnVolver.Visible = false;

            txtDescripcionOficinaMAn.Text = string.Empty;
            txtDescripcionOficina.Text = string.Empty;
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
            txtClaveSeguridad.Text = string.Empty;
            MostrarOficinas();
        }
        #endregion
        #region MANTENBIMIENTO DE OFICINAS
        private void MANOficinas()
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try {
                    UtilidadesAmigos.Logica.Entidades.Mantenimientos.EOficinas Mantenimiento = new Logica.Entidades.Mantenimientos.EOficinas();

                    Mantenimiento.IdOficina = Convert.ToDecimal(lbIdOficina.Text);
                    Mantenimiento.Oficina = txtDescripcionOficinaMAn.Text;
                    Mantenimiento.Estatus0 = cbEstatus.Checked;
                    Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimiento.FechaAdiciona = DateTime.Now;
                    Mantenimiento.UsuarioModifica = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimiento.FechaModifica = DateTime.Now;

                    var MAn = Objdata.Value.MantenimientoOficinas(Mantenimiento, lbAccion.Text);

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
                MostrarOficinas();
            }
        }

        protected void gvOficinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOficinas.PageIndex = e.NewPageIndex;
            MostrarOficinas();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarOficinas();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarControles();
            lbIdOficina.Text = "0";
            lbAccion.Text = "INSERT";
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
          //  MANOficinas();
        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
         
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            //VERIFICAMOS LOS CAMPOS VACIOS
            if (string.IsNullOrEmpty(txtDescripcionOficinaMAn.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "CamposVacios();", true);
            }
            else
            {
                //VERIFICAMOS QUE EL CAMPO CLAVE DE SEGURIDAD NO ESTE VACIO
                if (string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadVacio();", true);
                }
                else
                {
                    //VALIDAMOS LA CLAVE DE SEGURIDAD
                    var ValidarClave = ObjdataSistema.Value.BuscaClaveSeguridad(
                        new Nullable<decimal>(),
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtClaveSeguridad.Text));
                    if (ValidarClave.Count() < 1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida();", true);
                    }
                    else
                    {
                        //REALIZAMOS EL MANTENIMIENTO
                        MANOficinas();
                        OcultarControles();
                    }
                }
            }
        }

        protected void gvOficinas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void gvOficinas_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void gvOficinas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[1].Visible = false;
            }
            catch (Exception) { }
        }
    }
}
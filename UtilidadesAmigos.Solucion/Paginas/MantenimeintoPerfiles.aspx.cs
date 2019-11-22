using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimeintoPerfiles : System.Web.UI.Page
        
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjdataLogica = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        #region MOSTRAR EL LISTADO DE LOS PERFILES
        private void MostrarListado()
        {
            string _Perfil = string.IsNullOrEmpty(txtDescripcionPerfil.Text.Trim()) ? null : txtDescripcionPerfil.Text.Trim();

            var Buscar = ObjdataLogica.Value.ListadoPerfiles(
                new Nullable<decimal>(),
                _Perfil);
            gbListadoPerfiles.DataSource = Buscar;
            gbListadoPerfiles.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarListado();
            }
        }

        protected void gbListadoPerfiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gbListadoPerfiles.SelectedRow;

            var BuscarRegistro = ObjdataLogica.Value.ListadoPerfiles(
                Convert.ToDecimal(gb.Cells[1].Text));
            gbListadoPerfiles.DataSource = BuscarRegistro;
            gbListadoPerfiles.DataBind();
            foreach (var n in BuscarRegistro)
            {
                txtDescripcionPerfil.Text = n.perfil;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                if (cbEstatus.Checked == true)
                {
                    cbEstatus.Visible = false;
                }
                else
                {
                    cbEstatus.Visible = true;
                }
                btnNuevo.Enabled = false;
                btnConsultar.Enabled = false;
                btnExportar.Enabled = false;
                btnDeshabilitar.Enabled = true;
                btnModificar.Enabled = true;
                btnAtras.Enabled = true;
            }
        }

        protected void gbListadoPerfiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try {
                e.Row.Cells[1].Visible = false;
            }
            catch (Exception) { }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = true;
            btnConsultar.Enabled = true;
            btnExportar.Enabled = true;
            btnDeshabilitar.Enabled = false;
            btnModificar.Enabled = false;
            btnAtras.Enabled = false;
            txtClaveSeguridad.Text = string.Empty;
            txtDescripcionPerfil.Text = string.Empty;
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
            MostrarListado();
        }
    }
}
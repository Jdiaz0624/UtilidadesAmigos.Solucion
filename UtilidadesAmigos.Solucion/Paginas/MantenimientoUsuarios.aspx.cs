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

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void gbListadoUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gbListadoUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnProcesarMantenimento_Click(object sender, EventArgs e)
        {

        }

        protected void cbEstatusMantenimiento_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cbLlevaEmailMantenimiento_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {

        }
    }
}
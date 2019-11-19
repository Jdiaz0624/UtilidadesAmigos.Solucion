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
            gbListadoUsuarios.PageIndex = e.NewPageIndex;
            MostrarListadoUsuario();
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
    }
}
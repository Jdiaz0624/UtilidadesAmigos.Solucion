using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Mantenimientos
{
    public partial class Departamentos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> Objdata = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS OFICINAS
        private void CargarOficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddloficinaConsulta, ObjdataGeneral.Value.BuscaListas("OFICINA", null, null), true);
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS DEPARTAMENTOS
        private void MostrarListadoDepartamentos()
        {
            decimal? _Oficina = ddloficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddloficinaConsulta.SelectedValue) : new Nullable<decimal>();
            string _Departamento = string.IsNullOrEmpty(txtDescripcionDepartamento.Text.Trim()) ? null : txtDescripcionDepartamento.Text.Trim();

            var Buscar = Objdata.Value.BuscaDepartamentos(
                _Oficina,
                new Nullable<decimal>(),
                _Departamento);
            gvDepartamentos.DataSource = Buscar;
            gvDepartamentos.DataBind();
            CentrarColumnasGrid();
           
        }
        #endregion
        private void CentrarColumnasGrid()
        {
            gvDepartamentos.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvDepartamentos.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvDepartamentos.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvDepartamentos.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvDepartamentos.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvDepartamentos.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvDepartamentos.Columns[6].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvDepartamentos.Columns[7].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvDepartamentos.Columns[8].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        private void VolverAtras()
        {
            btnNuevo.Enabled = true;
            btnConsultar.Enabled = true;
            txtDescripcionDepartamento.Enabled = true;
            ddloficinaConsulta.Enabled = true;
            gvDepartamentos.Enabled = true;
            btnModificar.Enabled = false;
            btnAtras.Enabled = false;
            btnEliminar.Enabled = false;
            ddloficinaConsulta.Enabled = true;
            txtDescripcionDepartamento.Enabled = true;
        }
        #region OCULTAR Y MOSTRAR CONTROLES
        private void OcultarControles()
        {
            //CONTROLES SUPERIORES
            lbOficinaConsulta.Visible = false;
            ddloficinaConsulta.Visible = false;
            lbDescripcion.Visible = false;
            txtDescripcionDepartamento.Visible = false;
            btnConsultar.Visible = false;
            btnNuevo.Visible = false;
            btnRestabelcer.Visible = false;
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnExportar.Visible = false;
            gvDepartamentos.Visible = false;


            //CONTROLES INFERIORES
            lbOficinaMantenimiento.Visible = true;
            ddlOficinaMantenimiento.Visible = true;
            lbOficinaDepartamento.Visible = true;
            txtDescripcionDepartamentoMAN.Visible = true;
            cbEstatus.Visible = true;
            btnGuardar.Visible = true;
            btnAtras.Visible = true;

            //CARGAMOS EL DROP DE LAS OFICINAS
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataGeneral.Value.BuscaListas("OFICINA", null, null));


        }
        private void MostrarControles()
        {
            //CONTROLES SUPERIORES
            lbOficinaConsulta.Visible = true;
            ddloficinaConsulta.Visible = true;
            lbDescripcion.Visible = true;
            txtDescripcionDepartamento.Visible = true;
            btnConsultar.Visible = true;
            btnNuevo.Visible = true;
            btnRestabelcer.Visible = true;
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            btnExportar.Visible = true;
            gvDepartamentos.Visible = true;



            //CONTROLES INFERIORES
            lbOficinaMantenimiento.Visible = false;
            ddlOficinaMantenimiento.Visible = false;
            lbOficinaDepartamento.Visible = false;
            txtDescripcionDepartamentoMAN.Visible = false;
            cbEstatus.Visible = false;
            btnGuardar.Visible = false;
            btnAtras.Visible = false;
            txtDescripcionDepartamentoMAN.Text = string.Empty;
            cbEstatus.Checked = false;
        }
        #endregion

        #region MANTENIMIENTO DE DEPARTAMENTOS
        private void MANDepartamentos(decimal IdDepartamento, string Accion)
        {
            try {
                //VERIFICAMOS LOS CAMPOS VACIOS
                decimal? _Oficina = ddlOficinaMantenimiento.SelectedValue != "-1" ? decimal.Parse(ddlOficinaMantenimiento.SelectedValue) : new Nullable<decimal>();

                if (_Oficina == null || string.IsNullOrEmpty(txtDescripcionDepartamentoMAN.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No puedes dejar campos vacios para realizar esta operación')", true);
                }
                else
                {
                    UtilidadesAmigos.Logica.Entidades.Mantenimientos.EDepartamentos Mantenimiento = new Logica.Entidades.Mantenimientos.EDepartamentos();

                    Mantenimiento.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                    Mantenimiento.IdDepartamento = IdDepartamento;
                    Mantenimiento.Departamento = txtDescripcionDepartamentoMAN.Text;
                    Mantenimiento.Estatus0 = cbEstatus.Checked;
                    Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"].ToString());
                    Mantenimiento.FechaAdiciona = DateTime.Now;
                    Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"].ToString());
                    Mantenimiento.FechaModifica = DateTime.Now;

                    var MAN = Objdata.Value.MantenimientoDepartamentos(Mantenimiento, Accion);
                }

            }
            catch (Exception) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert'(Error al procesar la operación')", true);
            }
        }
        #endregion

        #region EXPORTAR DATA A EXEL
        private void ExportarExel()
        {
            try {
                decimal? _IdOficina = ddloficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddloficinaConsulta.SelectedValue) : new Nullable<decimal>();
                string _Departamento = string.IsNullOrEmpty(txtDescripcionDepartamento.Text.Trim()) ? null : txtDescripcionDepartamento.Text.Trim();

                var Exportar = (from n in Objdata.Value.BuscaDepartamentos(
                    _IdOficina,
                    new Nullable<decimal>(),
                    _Departamento)
                                select new
                                {
                                    Oficina = n.Oficina,
                                    Departamento = n.Departamento,
                                    Estatus = n.Estatus,
                                    CreadoPor = n.CreadoPor,
                                    FechaCreado = n.FechaAdiciona,
                                    ModificadoPor = n.ModificadoPor,
                                    FechaModificado = n.FechaModifica
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Departamentos", Exportar);
            }
            catch (Exception) {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al exportar a exel')", true);
            }

        }
#endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarOficinas();
                MostrarListadoDepartamentos();
            }
        }

        protected void gvOficinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartamentos.PageIndex = e.NewPageIndex;
            MostrarListadoDepartamentos();
        }

        protected void gvDepartamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartamentos.PageIndex = e.NewPageIndex;
            MostrarListadoDepartamentos();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoDepartamentos();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "INSERT";
            lbIdMantenimiento.Text = "0";
            OcultarControles();
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            MostrarControles();
            CargarOficinas();
            txtDescripcionDepartamento.Text = string.Empty;
            MostrarListadoDepartamentos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MANDepartamentos(
                Convert.ToDecimal(lbIdMantenimiento.Text),
                lbAccion.Text);
            MostrarControles();
            VolverAtras();
            MostrarListadoDepartamentos();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //BUSCAMOS LOS REGISTROS MEDIANTE EL ID SELECCIONADO
           // GridViewRow gv = gvDepartamentos.SelectedRow;
           // decimal? _oficina = ddloficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddloficinaConsulta.SelectedValue) : new Nullable<decimal>();

            var Buscar = Objdata.Value.BuscaDepartamentos(
               null,
                Convert.ToDecimal(lbIdMantenimiento.Text),
                null);
            //CARGAMOS EL DROP PARA EL MANTENIMIENTO
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataGeneral.Value.BuscaListas("OFICINA", null, null));

            //SACAMOS LOS DATOS
            foreach (var n in Buscar)
            {
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaMantenimiento, n.IdOficina.ToString());
                txtDescripcionDepartamentoMAN.Text = n.Departamento;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
                if (cbEstatus.Checked == true)
                {
                    cbEstatus.Visible = false;
                }
                else
                {
                    cbEstatus.Visible = true;
                }
                lbAccion.Text = "UPDATE";
                lbIdMantenimiento.Text = n.IdDepartamento.ToString();
                OcultarControles();
            }
            ddloficinaConsulta.Enabled = true;
            txtDescripcionDepartamento.Enabled = true;
            gvDepartamentos.Enabled = true;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //EXPORTAMOS LA DATA A EXEL
            ExportarExel();
        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
            VolverAtras();
        }

        protected void gvDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvDepartamentos.SelectedRow;

            var Buscar = Objdata.Value.BuscaDepartamentos(
                null,
                Convert.ToDecimal(gv.Cells[1].Text),
                null);
            gvDepartamentos.DataSource = Buscar;
            gvDepartamentos.DataBind();
            CentrarColumnasGrid();
            foreach (var n in Buscar)
            {
                lbIdMantenimiento.Text = n.IdDepartamento.ToString();
            }
            btnNuevo.Enabled = false;
            btnConsultar.Enabled = false;
            txtDescripcionDepartamento.Enabled = false;
            ddloficinaConsulta.Enabled = false;
            gvDepartamentos.Enabled = false;
            btnModificar.Enabled = true;
            btnAtras.Enabled = true;
            btnEliminar.Enabled = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataGeneral.Value.BuscaListas("OFICINA", null, null));
                //DESHABILITAMOS EL REGISTRO
                UtilidadesAmigos.Logica.Entidades.Mantenimientos.EDepartamentos Mantenimiento = new Logica.Entidades.Mantenimientos.EDepartamentos();

                Mantenimiento.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                Mantenimiento.IdDepartamento = Convert.ToDecimal(lbIdMantenimiento.Text);
                Mantenimiento.Departamento = txtDescripcionDepartamentoMAN.Text;
                Mantenimiento.Estatus0 = cbEstatus.Checked;
                Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"].ToString());
                Mantenimiento.FechaAdiciona = DateTime.Now;
                Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"].ToString());
                Mantenimiento.FechaModifica = DateTime.Now;

                var MAN = Objdata.Value.MantenimientoDepartamentos(Mantenimiento, "DISABLE");
                VolverAtras();
                MostrarListadoDepartamentos();
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ErrorDeshabilitar()", true);
            }

        }
    }
}
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

        #region CARLAR EL LISTADO DE LAS OFICINAS
        private void CargarDropConsulta()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddloficinaConsulta, ObjdataGeneral.Value.BuscaListas("OFICINA", null, null), true);
        }
        private void CargarDropMantenimiento()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMantenimiento, ObjdataGeneral.Value.BuscaListas("OFICINA", null, null));
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS DEPARTAMENTOS
        private void ListadoDepartamentos()
        {
            decimal? _Oficina = ddloficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddloficinaConsulta.SelectedValue) : new Nullable<decimal>();
            string _Departamento = string.IsNullOrEmpty(txtDescripcionDepartamento.Text.Trim()) ? null : txtDescripcionDepartamento.Text.Trim();

            var Buscar = Objdata.Value.BuscaDepartamentos(
                _Oficina,
                null,
                _Departamento);
            gvDepartamentos.DataSource = Buscar;
            gvDepartamentos.DataBind();
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void MostrarControles()
        {
            lbOficinaMantenimiento.Visible = true;
            ddlOficinaMantenimiento.Visible = true;
            lbOficinaDepartamento.Visible = true;
            txtDescripcionDepartamentoMAN.Visible = true;
            cbEstatus.Visible = true;
            btnGuardar.Visible = true;
            btnAtras.Visible = true;
            lbClaveSeguridad.Visible = true;
            txtclaveSeguridad.Visible = true;

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

            CargarDropMantenimiento();

            if (lbAccion.Text != "INSERT")
            {
                var SacarData = Objdata.Value.BuscaDepartamentos(
                    null,
                    Convert.ToDecimal(lbIdDepartamento.Text), null);
                foreach (var n in SacarData)
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
                }
            }
        }
        private void OcultarControles()
        {
            lbOficinaMantenimiento.Visible = false;
            ddlOficinaMantenimiento.Visible = false;
            lbOficinaDepartamento.Visible = false;
            txtDescripcionDepartamentoMAN.Visible = false;
            cbEstatus.Visible = false;
            btnGuardar.Visible = false;
            btnAtras.Visible = false;
            lbClaveSeguridad.Visible = false;
            txtclaveSeguridad.Visible = false;

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

            txtDescripcionDepartamento.Text = string.Empty;
            txtDescripcionDepartamentoMAN.Text = string.Empty;
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
            CargarDropConsulta();
            ListadoDepartamentos();

            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnRestabelcer.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;

        }
        #endregion
        #region MANTENIMIENTO DE DEPARTAMENTO
        private void MANDepartamento()
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try {
                    UtilidadesAmigos.Logica.Entidades.Mantenimientos.EDepartamentos Mantenimeinto = new Logica.Entidades.Mantenimientos.EDepartamentos();

                    Mantenimeinto.IdOficina = Convert.ToDecimal(ddlOficinaMantenimiento.SelectedValue);
                    Mantenimeinto.IdDepartamento = Convert.ToDecimal(lbIdDepartamento.Text);
                    Mantenimeinto.Departamento = txtDescripcionDepartamentoMAN.Text;
                    Mantenimeinto.Estatus0 = cbEstatus.Checked;
                    Mantenimeinto.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimeinto.FechaAdiciona = DateTime.Now;
                    Mantenimeinto.UsuarioModifica = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimeinto.FechaModifica = DateTime.Now;

                    var MAN = Objdata.Value.MantenimientoDepartamentos(Mantenimeinto, lbAccion.Text);

                }
                catch (Exception) { }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropConsulta();
                ListadoDepartamentos();
            }
        }

        protected void gvOficinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvDepartamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartamentos.PageIndex = e.NewPageIndex;
            ListadoDepartamentos();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            ListadoDepartamentos();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbIdDepartamento.Text = "0";
            lbAccion.Text = "INSERT";
            MostrarControles();
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            OcultarControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS LOS CAMPOS VACIOS
            if (string.IsNullOrEmpty(txtDescripcionDepartamentoMAN.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje", "CamposVacios();", true);
            }
            else
            {
                if (string.IsNullOrEmpty(txtclaveSeguridad.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadVacio();", true);
                }
                else
                {
                    //VALIDAMOS LA CLAVE DE SEGURIDAD
                    var ValidarClave = ObjdataGeneral.Value.BuscaClaveSeguridad(
                        new Nullable<decimal>(),
                        UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(txtclaveSeguridad.Text));
                    if (ValidarClave.Count() < 1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Mensaje", "ClaveSeguridadNoValida();", true);
                    }
                    else
                    {
                        MANDepartamento();
                        OcultarControles();
                    }
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "UPDATE";
            MostrarControles();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try {
                decimal? _oficina = ddloficinaConsulta.SelectedValue != "-1" ? decimal.Parse(ddloficinaConsulta.SelectedValue) : new Nullable<decimal>();
                string _Departamento = string.IsNullOrEmpty(txtDescripcionDepartamento.Text.Trim()) ? null : txtDescripcionDepartamento.Text.Trim();

                var Buscar = (from n in Objdata.Value.BuscaDepartamentos(
                    _oficina,
                    null,
                    _Departamento)
                              select new
                              {
                                  Oficina=n.Oficina,
                                  Departamento=n.Departamento,
                                  Estatus=n.Estatus,
                                  CreadoPor=n.CreadoPor,
                                  FechaCreado=n.FechaAdiciona,
                                  ModificadoPor=n.ModificadoPor,
                                  FechaModifica=n.FechaModifica
                              }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Departamentos", Buscar);

            }
            catch (Exception) { }
        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
            OcultarControles();
        }

        protected void gvDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvDepartamentos.SelectedRow;

            var SacarData = Objdata.Value.BuscaDepartamentos(
                null,
                Convert.ToDecimal(gb.Cells[1].Text),
                null);
            gvDepartamentos.DataSource = SacarData;
            gvDepartamentos.DataBind();
            foreach (var n in SacarData)
            {
                lbIdDepartamento.Text = n.IdDepartamento.ToString();
            }

            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnRestabelcer.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnExportar.Enabled = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "DESHABILITAR";
            MostrarControles();
        }

        protected void gvDepartamentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try { e.Row.Cells[1].Visible = false; }
            catch (Exception) { }
        }
    }
}
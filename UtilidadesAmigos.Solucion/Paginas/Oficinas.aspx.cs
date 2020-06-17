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
            decimal? _Sucursal = ddlSeleccionarSucursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSucursalConsulta.SelectedValue) : new Nullable<decimal>();
            string _Oficina = string.IsNullOrEmpty(txtDescripcionOficina.Text.Trim()) ? null : txtDescripcionOficina.Text.Trim();

            var Buscar = Objdata.Value.BuscaOficinas(
                new Nullable<decimal>(),
                _Sucursal,
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

            if (lbAccion.Text != "INSERT")
            {
                var SACARdATOOFICINA = Objdata.Value.BuscaOficinas(
                    Convert.ToDecimal(lbIdOficina.Text), null);
                foreach (var n in SACARdATOOFICINA)
                {
                    txtDescripcionOficinaMAn.Text = n.Oficina;
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
            txtDescripcionOficinaMAn.Enabled = true;
            cbEstatus.Enabled = true;

            btnConsultar.Enabled = true;
            btnNuevo.Enabled = true;
            btnRestabelcer.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
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
                //CARGAMOS LAS LISTAS DESPLEGABLES
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalConsulta, ObjdataSistema.Value.BuscaListas("SUCURSAL", null, null), true);
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalMantenimiento, ObjdataSistema.Value.BuscaListas("SUCURSAL", null, null));
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
            try {
                decimal? _Sucursal = ddlSeleccionarSucursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSucursalConsulta.SelectedValue) : new Nullable<decimal>();
                string _Oficina = string.IsNullOrEmpty(txtDescripcionOficina.Text.Trim()) ? null : txtDescripcionOficina.Text.Trim();

                var Exportar = (from n in Objdata.Value.BuscaOficinas(
                new Nullable<decimal>(),
                _Sucursal,
                _Oficina)
                                select new
                                {
                                    IdOficina = n.IdOficina,
                                    Oficina = n.Oficina,
                                    Estatus = n.Estatus,
                                    CreadoPor = n.Creadopor,
                                    FechaCreado = n.FechaAdiciona,
                                    ModificadoPor = n.ModificadoPor,
                                    FechaModifica = n.FechaModifica
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Oficinas", Exportar);
            }
            catch (Exception) { }

               
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbIdOficina.Text = "0";
            lbAccion.Text = "INSERT";
            MostrarControles();
 
            cbEstatus.Checked = true;
            cbEstatus.Visible = false;
          //  MANOficinas();
        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
            OcultarControles();
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
            GridViewRow gb = gvOficinas.SelectedRow;

            var SacarDatos = Objdata.Value.BuscaOficinas(
                Convert.ToDecimal(gb.Cells[1].Text),
                null);
            gvOficinas.DataSource = SacarDatos;
            gvOficinas.DataBind();
            foreach (var n in SacarDatos)
            {
                lbIdOficina.Text = n.IdOficina.ToString();
            }
            btnConsultar.Enabled = false;
            btnNuevo.Enabled = false;
            btnRestabelcer.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnExportar.Enabled = false;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "UPDATE";
            MostrarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "DELETE";
            MostrarControles();
            txtDescripcionOficinaMAn.Enabled = false;
            cbEstatus.Enabled = false;
            cbEstatus.Visible = true;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            OcultarControles();
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
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

        #region BUSCA OFICINAS
        private void BuscaOficinas()
        {
            string _Oficina = string.IsNullOrEmpty(txtDescripcionOficina.Text.Trim()) ? null : txtDescripcionOficina.Text.Trim();

            var Buscar = Objdata.Value.BuscaOficinas(
                new Nullable<decimal>(),
                _Oficina);
            gvOficinas.DataSource = Buscar;
            gvOficinas.DataBind();
            //gvOficinas.Columns[1].Visible = true;
            //gvOficinas.Columns[1].Visible = false;
        }
        #endregion
        #region MANTENIMIENTO DE OFICINAS
        private void MANOficina(decimal IdOficina,string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EOficinas Mantenimiento = new Logica.Entidades.Mantenimientos.EOficinas();

            Mantenimiento.IdOficina = IdOficina;
            Mantenimiento.Oficina = txtDescripcionOficinaMAn.Text;
            Mantenimiento.Estatus0 = cbEstatus.Checked;
            Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"]);
            Mantenimiento.FechaAdiciona = DateTime.Now;
            Mantenimiento.UsuarioModifica = Convert.ToDecimal(Session["IdUsuario"]);
            Mantenimiento.FechaModifica = DateTime.Now;

            var MAn = Objdata.Value.MantenimientoOficinas(Mantenimiento, Accion);
        }
        #endregion
        #region RESTABLECER PANTALLA
        private void Restablecer()
        {
            cbEstatus.Visible = true;
            gvOficinas.Visible = true;
            lbOficina.Visible = false;
            txtDescripcionOficinaMAn.Visible = false;
            cbEstatus.Checked = false;
            cbEstatus.Visible = false;
            btnGuardar.Visible = false;

            lbDescripcion.Visible = true;
            txtDescripcionOficina.Visible = true;
            btnConsultar.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnExportar.Enabled = true;
            btnNuevo.Enabled = true;
            txtDescripcionOficina.Text = string.Empty;
            txtDescripcionOficinaMAn.Text = string.Empty;
            cbEstatus.Checked = false;

            cbGuardar.Checked = false;
            cbModificar.Checked = false;
            cbDeshabilitar.Checked = false;
            BuscaOficinas();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }
#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        protected void gvOficinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            BuscaOficinas();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //EXPORTAMOS LOS DATOS A EXEL
            string _oficina = string.IsNullOrEmpty(txtDescripcionOficina.Text.Trim()) ? null : txtDescripcionOficina.Text.Trim();

            var Exportar = (from n in Objdata.Value.BuscaOficinas(
                new Nullable<decimal>(),
                _oficina)
                            select new
                            {
                                CodigoOficina = n.IdOficina,
                                Oficina =n.Oficina,
                                Estatus=n.Estatus,
                                CreadoPor=n.Creadopor,
                                FechaCreado=n.FechaAdiciona,
                                ModificadoPor=n.ModificadoPor,
                                FechaModifica =n.FechaModifica
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de Oficinas", Exportar);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            gvOficinas.Visible = false;
            lbOficina.Visible = true;
            txtDescripcionOficinaMAn.Visible = true;
            cbEstatus.Checked = true;
            cbEstatus.Visible = true;
            btnGuardar.Visible = true;
            lbDescripcion.Visible = false;
            txtDescripcionOficina.Visible = false;
            btnConsultar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = false;
            btnNuevo.Enabled = false;
            txtDescripcionOficina.Text = string.Empty;
            cbGuardar.Checked = true;
            cbModificar.Checked = false;
            cbDeshabilitar.Checked = false;
            lbIdOficinaMantenimiento.Text = "0";
            cbEstatus.Visible = false;
            cbEstatus.Checked = true;
        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
            Restablecer();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcionOficinaMAn.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El campo oicina no puede estar vacio favor de verificar');", true);
            }
            else
            {
                if (cbGuardar.Checked)
                {
                    //VERIFICAMOS SI EL CAMPO INGRESADO YA ESTA REGISTRADO EN EL SISTEMA
                    var ValidarRegistro = Objdata.Value.BuscaOficinas(
                        new Nullable<decimal>(),
                        txtDescripcionOficinaMAn.Text);
                    if (ValidarRegistro.Count() < 1)
                    {
                        //PROCEDEMOS A GUARDAR EL REGISTRO
                        MANOficina(
                            Convert.ToDecimal(lbIdOficinaMantenimiento.Text), "INSERT");
                        Restablecer();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertins", "alert('La oficina ingresada ya se encuentra registrada en el sistema, favor de revisar');", true);
                        txtDescripcionOficinaMAn.Text = string.Empty;
                    }
                }
                else if (cbModificar.Checked)
                {
                    MANOficina(Convert.ToDecimal(lbIdOficinaMantenimiento.Text), "UPDATE");
                    Restablecer();
                }
                else if (cbDeshabilitar.Checked)
                {
                    MANOficina(Convert.ToDecimal(lbIdOficinaMantenimiento.Text), "DELETE");
                    Restablecer();
                }
            }
           
        }

        protected void gvOficinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvOficinas.SelectedRow;

            lbIdOficinaMantenimiento.Text = gv.Cells[1].Text;
            
            btnConsultar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

           
            

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            gvOficinas.Visible = false;
            lbOficina.Visible = true;
            txtDescripcionOficinaMAn.Visible = true;
            cbEstatus.Checked = true;
            cbEstatus.Visible = true;
            btnGuardar.Visible = true;
            lbDescripcion.Visible = false;
            txtDescripcionOficina.Visible = false;
            btnConsultar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = false;
            btnNuevo.Enabled = false;
            txtDescripcionOficina.Text = string.Empty;
            cbGuardar.Checked = false;
            cbModificar.Checked = true;
            cbDeshabilitar.Checked = false;

            //SACAMOS LA INFORMACION DEL REGISTRO SELECCIONADO
            var SacarDatos = Objdata.Value.BuscaOficinas(
                Convert.ToDecimal(lbIdOficinaMantenimiento.Text), null);
            foreach (var n in SacarDatos)
            {
                txtDescripcionOficinaMAn.Text = n.Oficina;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            if (cbEstatus.Checked == true)
            {
                cbEstatus.Visible = false;
            }
            else
            {
                cbEstatus.Visible = true;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            MANOficina(
                Convert.ToDecimal(lbIdOficinaMantenimiento.Text), "DELETE");
            BuscaOficinas();
        }
    }
}
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

        #region MANTENBIMIENTO DE OFICINAS
        private void MANOficinas( string Accion)
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
                    Mantenimiento.IdSucursal = Convert.ToDecimal(ddlSeleccionarSucursalMantenimiento.SelectedValue);
                    Mantenimiento.Oficina = txtDescripcionOficinaMAn.Text;
                    Mantenimiento.Estatus0 = cbEstatus.Checked;
                    Mantenimiento.UsuarioAdiciona = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimiento.FechaAdiciona = DateTime.Now;
                    Mantenimiento.UsuarioModifica = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimiento.FechaModifica = DateTime.Now;

                    var MAn = Objdata.Value.MantenimientoOficinas(Mantenimiento, Accion);

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
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
            }
        }

        protected void gvOficinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOficinas.PageIndex = e.NewPageIndex;
            MostrarOficinas();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
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
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
            }
            catch (Exception) { }

               
        }

 

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()) ? null : txtClaveSeguridad.Text.Trim();
            //VALIDAMOS LA CLAVE DE SEGURIDAD
            var ValidarClave = ObjdataSistema.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridad));
            if (ValidarClave.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida", "ClaveSeguridadNoValida();", true);
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
            }
            else
            {
                lbIdOficina.Text = "0";
                MANOficinas("INSERT");
                ClientScript.RegisterStartupScript(GetType(), "RegistroGuardado", "RegistroGuardado();", true);
                MostrarOficinas();
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
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
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarSucursalMantenimiento, Convert.ToDecimal(n.IdSucursal).ToString());
                txtDescripcionOficinaMAn.Text = n.Oficina;
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
            btnConsultar.Enabled = false;
            btnRestabelcer.Enabled = true;
            btnExportar.Enabled = false;
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearControles", "DesbloquearControles();", true);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            

        }

        protected void btnModificar_Click1(object sender, EventArgs e)
        {
            
        }

        protected void btnModificarMantenimiento_Click(object sender, EventArgs e)
        {
            string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridad.Text.Trim()) ? null : txtClaveSeguridad.Text.Trim();
            //VALIDAMOS LA CLAVE DE SEGURIDAD
            var ValidarClave = ObjdataSistema.Value.BuscaClaveSeguridad(
                new Nullable<decimal>(),
                UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridad));
            if (ValidarClave.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadNoValida", "ClaveSeguridadNoValida();", true);
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
            }
            else
            {
                //lbIdOficina.Text = "0";
                MANOficinas("UPDATE");
                ClientScript.RegisterStartupScript(GetType(), "RegistroModificado", "RegistroModificado();", true);
                MostrarOficinas();
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
            }
        }
    }
}
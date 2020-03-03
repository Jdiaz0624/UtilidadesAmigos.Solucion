using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Synthesis;
using System.Threading;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas

{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objtata = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        #region MANTENIMIENTO DE SUGERENCIAS
        private void MAnSugerencias(string Accion, decimal IdSugerencia)
        {
            if (string.IsNullOrEmpty(txtSugerencia.Text.Trim()))
            {

            }
            else
            {
                if (Session["IdUsuario"] != null)
                {
                    UtilidadesAmigos.Logica.Entidades.ESugerencias Mantenimiento = new Logica.Entidades.ESugerencias();

                    Mantenimiento.IdSugerencia = IdSugerencia;
                    Mantenimiento.IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);
                    Mantenimiento.Sugerencia = txtSugerencia.Text;
                    Mantenimiento.Respuesta = txtRespuesta.Text;

                    var MAn = Objtata.Value.MantenimientoSugeencias(Mantenimiento, Accion);
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }
        #endregion
        #region BUSCAR REGISTROS
        private void BuscarRegistros()
        {
            if (Session["IdUsuario"] != null)
            {
               
                var BuscarRegistros = Objtata.Value.BuscaSugerencias(
                    new Nullable<decimal>(),
                    Convert.ToDecimal(Session["IdUsuario"]));
                gbSugerencia.DataSource = BuscarRegistros;
                gbSugerencia.DataBind();
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        #endregion


        private void SacarDatosUsuario(decimal IdUsuario)
        {
            var SacarDatos = Objtata.Value.BuscaUsuarios(IdUsuario,
                null,
                null,
                null,
                null,
                null,
                null);
            foreach (var n in SacarDatos)
            {
                lbUsuarioConectado.Text = n.Persona;
                lbDepartamento.Text = n.Departamento;
                lbIdPerfil.Text = n.IdPerfil.ToString();
            }

            //MOSTRAMOS LAS SUGERENCIAS 
            int IdPerfil = Convert.ToInt32(lbIdPerfil.Text);
            if (IdPerfil != 1)
            {
                //SACAMOS LOS DATOS DE LOS PERFILES SELECCIONADOS
                var SacarSugerencias = Objtata.Value.BuscaSugerencias(
                    new Nullable<decimal>(),
                    Convert.ToDecimal(Session["IdUsuario"]));
                gbSugerencia.DataSource = SacarSugerencias;
                gbSugerencia.DataBind();
                txtRespuesta.Enabled = false;
                lbAccion.Text = "INSERT";
            }
            else
            {

            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdUsuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    SacarDatosUsuario(Convert.ToDecimal(Session["IdUsuario"]));
                    decimal idiusuario = Convert.ToDecimal(Session["IdUsuario"]);
                    if (idiusuario == 1)
                    {
                        // this.Master.FindControl("lbTiket").Visible = false;
                    }
                    Thread tarea = new Thread(new ParameterizedThreadStart(UtilidadesAmigos.Logica.Comunes.VozVeronica.Hablar));
                    tarea.Start("Hola");

                }
            }
          
        }

        protected void gbSugerencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbSugerencia.PageIndex = e.NewPageIndex;
            BuscarRegistros();
        }

        protected void gbSugerencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAccion.Text = "UPDATE";
            GridViewRow gb = gbSugerencia.SelectedRow;
            var SacarDatos = Objtata.Value.BuscaSugerencias(
                Convert.ToDecimal(gb.Cells[0].Text));
            foreach (var n in SacarDatos)
            {
                lbIdMantenimiento.Text = n.IdSugerencia.ToString();
                txtSugerencia.Text = n.Sugerencia;
                txtRespuesta.Text = n.Respuesta;
            }
            gbSugerencia.DataSource = SacarDatos;
            gbSugerencia.DataBind();
        }

        protected void btnAccion_Click(object sender, EventArgs e)
        {
            if (lbAccion.Text == "UPDATE")
            {
                lbAccion.Text = "UPDATE";
                MAnSugerencias(lbAccion.Text, Convert.ToDecimal(lbIdMantenimiento.Text));
                txtRespuesta.Text = string.Empty;
                txtSugerencia.Text = string.Empty;
                BuscarRegistros();
            }
            else
            {
                lbAccion.Text = "INSERT";
                lbIdMantenimiento.Text = "0";
                MAnSugerencias(lbAccion.Text, Convert.ToDecimal(lbIdMantenimiento.Text));
                txtRespuesta.Text = string.Empty;
                txtSugerencia.Text = string.Empty;
                BuscarRegistros();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lbAccion.Text = "INSERT";
            txtRespuesta.Text = string.Empty;
            txtSugerencia.Text = string.Empty;
            BuscarRegistros();
        }
    }
}
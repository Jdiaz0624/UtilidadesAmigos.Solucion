using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class MantenimientoDependientes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR EL LISTADO DE LOS DEPENEIDNTES
        private void MostrarListadoDependiente(string Poliza)
        {
            lbEstatusPoliza.Visible = true;
            lbRamo.Visible = true;
            lbSubramo.Visible = true;
            var MostrarListado = ObjData.Value.BuscaDependientes(Poliza);
            foreach (var n in MostrarListado)
            {
                lbPolizaFiltrada.Text = n.Poliza;
                lbEstatusPoliza.Text = n.Estatus;
                lbRamo.Text = n.Ramo;
                lbSubramo.Text = n.SubRamo;
            }
            gvDependientes.DataSource = MostrarListado;
            gvDependientes.DataBind();
            ClientScript.RegisterStartupScript(GetType(), "ActivarRestablecerAgregar", "ActivarRestablecerAgregar();", true);
        }
        #endregion
        #region MANTENIMIENTO DE DEPENDIENTES
        private void AgregarDepenDependientes() {
            //VERIFICAMOS SI NO SE PERDIO LA VARIABLE DE SESION
            if (Session["IdUsuario"] != null)
            {
                try { }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorMantenimiento", "ErrorMantenimiento();", true);
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        private void ModificarQuitarDependientes(string Accion) {
            //VERIFICAMOS SI NO SE PERDIO LA VARIABLE DE SESION
            if (Session["IdUsuario"] != null)
            {
                try { }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorMantenimiento", "ErrorMantenimiento();", true);
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
                ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
            }
        }

        protected void gvDependientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDependientes.PageIndex = e.NewPageIndex;
            MostrarListadoDependiente(lbPolizaFiltrada.Text);
        }

        protected void gvDependientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvDependientes.SelectedRow;
            var Selecionar = ObjData.Value.BuscaDependientes(
                lbPolizaFiltrada.Text, Convert.ToDecimal(gv.Cells[0].Text));
            gvDependientes.DataSource = Selecionar;
            gvDependientes.DataBind();
            foreach (var n in Selecionar)
            {
                txtNombreQuitarModificar.Text = n.Nombre;
                txtParentezcoQuitarModificar.Text = n.Parentezco;
                txtCedulaQuitarModificar.Text = n.Cedula;
                txtFechaNacimientoQuitarModificar.Text = n.FechaNacimiento0.ToString();
                txtSexoQuitarModificar.Text = n.Sexo;
                txtPrimaQuitarModificar.Text = n.PorcPrima.ToString(); 
            }
            ClientScript.RegisterStartupScript(GetType(), "ActivarQuitarModificar", "ActivarQuitarModificar();", true);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //VALIDAMOS LA CONSULTA
            var Validar = ObjData.Value.BuscaDependientes(txtPolizaConsulta.Text);
            if (Validar.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "PolizaNoEncontrada", "PolizaNoEncontrada();", true);
                ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
                ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
            }
            else
            {
                MostrarListadoDependiente(txtPolizaConsulta.Text);
            }
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
            ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
            ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
        }

        protected void btnRestabelecer_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
            ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
        }

        protected void btnModificarMantenimiento_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
            ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
        }
    }
}
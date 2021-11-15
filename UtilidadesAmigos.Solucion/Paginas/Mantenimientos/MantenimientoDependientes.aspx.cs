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
                try {

                    decimal Cotizacion = 0, Secuencia = 0, ValorAsegurado = 0, PorcCobertura = 0;
                    bool Estatus = false;
                    DateTime FechaInclusion = DateTime.Now, FechaInicioCobertura = DateTime.Now;
                    string NomnreUsuario = "";

                    var SacarNombreUsuario = ObjData.Value.BuscaUsuarios(
                        Convert.ToDecimal(Session["IdUsuario"]));
                    foreach (var n in SacarNombreUsuario)
                    {
                        NomnreUsuario = n.Persona;
                    }

                    var SacarDatosDependentientes = ObjData.Value.BuscaDependientes(
                        lbPolizaFiltrada.Text);
                    foreach (var n in SacarDatosDependentientes)
                    {
                        Cotizacion = Convert.ToDecimal(n.Cotizacion);
                        Secuencia = Convert.ToDecimal(n.Secuencia);
                        ValorAsegurado = Convert.ToDecimal(n.ValorAsegurado);
                        PorcCobertura = Convert.ToDecimal(n.PorcCobertura);
                        Estatus = Convert.ToBoolean(n.Estatus0);
                        FechaInclusion = Convert.ToDateTime(n.FechaInclusion0);
                        FechaInicioCobertura = Convert.ToDateTime(n.FechaInicioCobertura0);
                    }

                    //GUARDAMOS LOS DATOS
                    UtilidadesAmigos.Logica.Entidades.EDependientes Guardar = new Logica.Entidades.EDependientes();

                    
                    Guardar.Compania = 30;
                    Guardar.Cotizacion = Cotizacion;
                    Guardar.Secuencia = Convert.ToInt32(Secuencia);
                    Guardar.IdAsegurado = 0;
                    Guardar.Nombre = txtNombreMantenimiento.Text;
                    Guardar.Parentezco = txtParentezzcoMantenimiento.Text;
                    Guardar.Cedula = txtCedula.Text;
                    Guardar.FechaNacimiento0 = Convert.ToDateTime(txtFechaNacimiento.Text);
                    Guardar.Sexo = txtSexoMantenimiento.Text;
                    Guardar.PorcPrima = Convert.ToDecimal(txtPrima.Text);
                    Guardar.UsuarioAdiciona = NomnreUsuario;
                    Guardar.FechaAdiciona0 = DateTime.Now;
                    Guardar.Estatus0 = Convert.ToByte(Estatus);
                    Guardar.ValorAsegurado = null;
                    Guardar.PorcCobertura = null;
                    Guardar.FechaInclusion0 = null;
                    Guardar.FechaInicioCobertura0 = null;

                    var MAN = ObjData.Value.MantenimientoDependientes(Guardar, "INSERT");
                }
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
                try {

                    decimal Cotizacion = 0, Secuencia = 0, ValorAsegurado = 0, PorcCobertura = 0;
                    bool Estatus = false;
                    DateTime FechaInclusion = DateTime.Now, FechaInicioCobertura = DateTime.Now;
                    string NomnreUsuario = "";

                    var SacarNombreUsuario = ObjData.Value.BuscaUsuarios(
                        Convert.ToDecimal(Session["IdUsuario"]));
                    foreach (var n in SacarNombreUsuario)
                    {
                        NomnreUsuario = n.Persona;
                    }

                    var SacarDatosDependentientes = ObjData.Value.BuscaDependientes(
                        lbPolizaFiltrada.Text);
                    foreach (var n in SacarDatosDependentientes)
                    {
                        Cotizacion = Convert.ToDecimal(n.Cotizacion);
                        Secuencia = Convert.ToDecimal(n.Secuencia);
                        ValorAsegurado = Convert.ToDecimal(n.ValorAsegurado);
                        PorcCobertura = Convert.ToDecimal(n.PorcCobertura);
                        Estatus = Convert.ToBoolean(n.Estatus0);
                        FechaInclusion = Convert.ToDateTime(n.FechaInclusion0);
                        FechaInicioCobertura = Convert.ToDateTime(n.FechaInicioCobertura0);
                    }

                    UtilidadesAmigos.Logica.Entidades.EDependientes ModificarEditar = new Logica.Entidades.EDependientes();


                    ModificarEditar.Compania = 30;
                    ModificarEditar.Cotizacion = Cotizacion;
                    ModificarEditar.Secuencia = Convert.ToInt32(Secuencia);
                    ModificarEditar.IdAsegurado = Convert.ToInt32(lbIdAsegurado.Text);
                    ModificarEditar.Nombre = txtNombreQuitarModificar.Text;
                    ModificarEditar.Parentezco = txtParentezcoQuitarModificar.Text;
                    ModificarEditar.Cedula = txtCedulaQuitarModificar.Text;
                    ModificarEditar.FechaNacimiento0 = Convert.ToDateTime(txtFechaNacimientoQuitarModificar.Text);
                    ModificarEditar.Sexo = txtSexoQuitarModificar.Text;
                    ModificarEditar.PorcPrima = Convert.ToDecimal(txtPrimaQuitarModificar.Text);
                    ModificarEditar.UsuarioAdiciona = NomnreUsuario;
                    ModificarEditar.FechaAdiciona0 = DateTime.Now;
                    ModificarEditar.Estatus0 = Convert.ToByte(Estatus);
                    ModificarEditar.ValorAsegurado = null;
                    ModificarEditar.PorcCobertura = null;
                    ModificarEditar.FechaInclusion0 = null;
                    ModificarEditar.FechaInicioCobertura0 = null;

                    var MAN = ObjData.Value.MantenimientoDependientes(ModificarEditar, Accion);
                }
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
            lbIdAsegurado.Text = gv.Cells[0].Text;
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
            lbIdAsegurado.Text = "0";
            AgregarDepenDependientes();
            ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
            ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
            txtPolizaConsulta.Text = string.Empty;
            MostrarListadoDependiente(lbPolizaFiltrada.Text);
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            ModificarQuitarDependientes("DELETE");
            ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
            ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
            txtPolizaConsulta.Text = string.Empty;
            MostrarListadoDependiente(lbPolizaFiltrada.Text);
        }

        protected void btnRestabelecer_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
            ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
        }

        protected void btnModificarMantenimiento_Click(object sender, EventArgs e)
        {
            ModificarQuitarDependientes("UPDATE");
            ClientScript.RegisterStartupScript(GetType(), "DesactivarRestablecerAgregar", "DesactivarRestablecerAgregar();", true);
            ClientScript.RegisterStartupScript(GetType(), "DesactivarQuitarModificar", "DesactivarQuitarModificar();", true);
            txtPolizaConsulta.Text = string.Empty;
            MostrarListadoDependiente(lbPolizaFiltrada.Text);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ValidarCoberturas : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarCoberturas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCpbertura, ObjData.Value.BuscaListas("COBERTURA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCoberturaPlanCobertura, ObjData.Value.BuscaListas("COBERTURA", null, null));
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null));
        }
        private void CargarPlanCoberturas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPlanCobertura, ObjData.Value.BuscaListas("PLANCOBERTURA", ddlSeleccionarCpbertura.SelectedValue, null));
        }
        #endregion

        #region MOSTRAR LAS COBERTURAS
        private void MostrarCoberturas()
        {
            txtCoberturaMantenimiento.Text = string.Empty;
            string _Cobertura = string.IsNullOrEmpty(txtCoberturaMantenimiento.Text.Trim()) ? null : txtCoberturaMantenimiento.Text.Trim();

            var Buscar = ObjData.Value.BuscaCoberturaMantenimiento(
                new Nullable<decimal> (),
                _Cobertura);
            gbCoberturas.DataSource = Buscar;
            gbCoberturas.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE COBERTURAS
        private void MAnCoberturas(decimal? IdCobertura)
        {
            try {
                if (Session["IdUsuario"] != null)
                {
                    UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento Mantenimiento = new Logica.Entidades.EBuscaCoberturasMantenimiento();

                    Mantenimiento.IdCobertura = IdCobertura;
                    Mantenimiento.Descripcion = txtCoberturaMantenimiento.Text;
                    Mantenimiento.Estatus0 = cbEstatus.Checked;

                    var MAN = ObjData.Value.MantenimientoCobertura(Mantenimiento, "UPDATE");
                    MostrarCoberturas();
                    CargarCoberturas();
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (Exception) { }
        }
        #endregion
        #region MOSTRAR EL LISTADO DE LOS PLANES DE CBERTURAS
        private void ListadoPlanCoberturas()
        {
            var Buscar = ObjData.Value.BuscaPlanCoberturas();
            gbPlanCobertura.DataSource = Buscar;
            gbPlanCobertura.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE PLAN DE COBERTURAS
        private void MANPlanCoberturas()
        {
            try {
                if (Session["IdUsuario"] != null)
                {
                    UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento Mantenimiento = new Logica.Entidades.EPlanCoberturasMantenimiento();

                    Mantenimiento.IdPlanCobertura = Convert.ToDecimal(lbIdMantenimientoPlanCobertura.Text);
                    Mantenimiento.IdCobertura = Convert.ToDecimal(ddlCoberturaPlanCobertura.SelectedValue);
                    Mantenimiento.CodigoCobertura = Convert.ToDecimal(txtCodigoCoberturaPlanCobertura.Text);
                    Mantenimiento.PlanCobertura = txtPlanCobertura.Text;
                    Mantenimiento.Estatus0 = cbEstatusPlanCobertura.Checked;

                    var MAN = ObjData.Value.MantenimientoPlanCoberturas(Mantenimiento, "UPDATE");
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }

            }
            catch (Exception) { }
        }
        #endregion
        #region MOSTRAR LA DATA DE LAS COBERTURAS
        private void MostrarDataCoberturas()
        {
           
            if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 1)
            {
                try
                {
                    var SacarDataTuAsistencia = ObjData.Value.SacarDataTuAsistencia(
                      Convert.ToDateTime(txtFechaDesde.Text),
                      Convert.ToDateTime(txtFechaHasta.Text),
                      txtPolizaFiltro.Text,
                      Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
                    gvListadoCobertura.DataSource = SacarDataTuAsistencia;
                    gvListadoCobertura.DataBind();
                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 2)
            {
                try {
                    //EXPORTAR LA DATA DE LA CASA DE AERO AMBULANCIA
                    var SacarDataCasaConductor = ObjData.Value.SacarDataCasaConductor(
                       Convert.ToDateTime(txtFechaDesde.Text),
                       Convert.ToDateTime(txtFechaHasta.Text),
                       txtPolizaFiltro.Text,
                       Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
                    gvListadoCobertura.DataSource = SacarDataCasaConductor;
                    gvListadoCobertura.DataBind();

                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
                try {

                    

                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 3)
            {
                try { }
                catch (Exception) {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 4)
            {
                try { }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 5)
            {
                try {
                    //SACAMOS LA DATA DE LA CASA DEL CONDUCTOR

                    var SacarDataCasaConductor = ObjData.Value.SacarDataCasaConductor(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        txtPolizaFiltro.Text,
                        17);
                    gvListadoCobertura.DataSource = SacarDataCasaConductor;
                    gvListadoCobertura.DataBind();
                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
               


            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 6)
            {
                try {
                    //SACAMOS LA DATA DE CEDENSA
                    var SacarDataCedensa = ObjData.Value.SacarDataCedensa(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        txtPolizaFiltro.Text,
                        Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue));
                    gvListadoCobertura.DataSource = SacarDataCedensa;
                    gvListadoCobertura.DataBind();

                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorConsulta();", true);
                }
            

            }
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCoberturas();
                MostrarCoberturas();
                ListadoPlanCoberturas();
          
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarDataCoberturas();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 1)
            {
                try { }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 2)
            {
                try {
                    //EXPORTAR DATA AEROAMBULANCIA
                    var Exportar = (from n in ObjData.Value.SacarDataCasaConductor(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    txtPolizaFiltro.Text,
                    Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue))
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Items = n.Items,
                                        Estatus = n.Estatus,
                                        Concepto = n.Concepto,
                                        Cliente = n.Cliente,
                                        TipoIdentificacion = n.TipoIdentificacion,
                                        NumeroIdentificacion = n.NumeroIdentificacion,
                                        Intermediario = n.Intermediario,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        FechaProceso = n.FechaProceso,
                                        MesValidado = n.MesValidado,
                                        TipoVehiculo = n.Tipovehiculo,
                                        Marca = n.Marca,
                                        Modelo = n.Modelo,
                                        Capacidad = n.Capacidad,
                                        Ano = n.Ano,
                                        Color = n.Color,
                                        Chasis = n.Chasis,
                                        Placa = n.Placa,
                                        ValorAsegurado = n.ValorAsegurado,
                                        Cobertura = n.Cobertura,
                                        TipoMovimiento = n.TipoMovimiento,

                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Registros Casa del Conductor", Exportar);
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
                }
                
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 3)
            {
                try { }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
                }

            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 4)
            {
                try { }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
                }
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 5)
            {
                try {
                    //EXPORTAR CASA DEL CONDUCTOR
                    var Exportar = (from n in ObjData.Value.SacarDataCasaConductor(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    txtPolizaFiltro.Text,
                    17)
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Items = n.Items,
                                        Estatus = n.Estatus,
                                        Concepto = n.Concepto,
                                        Cliente = n.Cliente,
                                        TipoIdentificacion = n.TipoIdentificacion,
                                        NumeroIdentificacion = n.NumeroIdentificacion,
                                        Intermediario = n.Intermediario,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        FechaProceso = n.FechaProceso,
                                        MesValidado = n.MesValidado,
                                        TipoVehiculo = n.Tipovehiculo,
                                        Marca = n.Marca,
                                        Modelo = n.Modelo,
                                        Capacidad = n.Capacidad,
                                        Ano = n.Ano,
                                        Color = n.Color,
                                        Chasis = n.Chasis,
                                        Placa = n.Placa,
                                        ValorAsegurado = n.ValorAsegurado,
                                        Cobertura = n.Cobertura,
                                        TipoMovimiento = n.TipoMovimiento,

                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Registros Casa del Conductor", Exportar);
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
                }
                
            }
            else if (Convert.ToDecimal(ddlSeleccionarCpbertura.SelectedValue) == 6)
            {
                try {
                    //EXPORTAR CEDENSA
                    var ExportarCedensa = (from n in ObjData.Value.SacarDataCedensa(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        txtPolizaFiltro.Text,
                        Convert.ToInt32(ddlSeleccionarPlanCobertura.SelectedValue))
                                           select new
                                           {
                                               Poliza = n.Poliza,
                                               Cotizacion = n.Cotizacion,
                                               CodRamo = n.CodRamo,
                                               Ramo = n.Ramo,
                                               FechaAdiciona = n.FechaProceso,
                                               InicioVigencia = n.InicioVigencia,
                                               FinVigencia = n.FinVigencia,
                                               TipoPlan = n.Cobertura,
                                               Estatus = n.Estatus,
                                               Parentezco = n.Parentezco,
                                               Nombre = n.Nombre,
                                               Provincia = n.Provincia,
                                               Direccion = n.Direccion,
                                               Telefono = n.Telefono,
                                               Cedula = n.Cedula,
                                               FechaNacimiento = n.FechadeNacimiento,
                                               Edad = n.Edad,
                                               Prima = n.Prima


                                           }).ToList();

                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Registros Cedensa", ExportarCedensa);
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Error", "ErrorExportar();", true);
                }
            
            }
            
        }

        protected void gvListadoCobertura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoCobertura.PageIndex = e.NewPageIndex;
            MostrarDataCoberturas();
        }

        protected void gvListadoCobertura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rbGenerarDataRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        protected void rbGenerarDataCompleta_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void rbGenerarDataRangoFecha_CheckedChanged1(object sender, EventArgs e)
        {
          
        }

        protected void ddlSeleccionarCpbertura_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanCoberturas();
        }

        protected void gbCoberturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbCoberturas.PageIndex = e.NewPageIndex;
            MostrarCoberturas();
        }

        protected void gbCoberturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gbCoberturas.SelectedRow;

            var Buscar = ObjData.Value.BuscaCoberturaMantenimiento(Convert.ToDecimal(gb.Cells[0].Text));
            foreach (var n in Buscar)
            {
                txtCoberturaMantenimiento.Text = n.Descripcion;
                lbIdCobertura.Text = n.IdCobertura.ToString();
                cbEstatus.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
         
            }

        }

        protected void btnGuardarCobertura_Click(object sender, EventArgs e)
        {
            MAnCoberturas(Convert.ToDecimal(lbIdCobertura.Text));
            ListadoPlanCoberturas();
            CargarCoberturas();
        }

        protected void gbPlanCobertura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbPlanCobertura.PageIndex = e.NewPageIndex;
            ListadoPlanCoberturas();
        }

        protected void gbPlanCobertura_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gbPlanCobertura.SelectedRow;

            var Buscar = ObjData.Value.BuscaPlanCoberturas(Convert.ToDecimal(gb.Cells[0].Text));
            foreach (var n in Buscar)
            {
                ClientScript.RegisterStartupScript(GetType(), "Activar", "ActivarControlesPlanCobertura();", true);
                lbIdMantenimientoPlanCobertura.Text = n.IdPlanCobertura.ToString();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlCoberturaPlanCobertura, n.IdCobertura.ToString());
                txtCodigoCoberturaPlanCobertura.Text = n.CodigoCobertura.ToString();
                txtPlanCobertura.Text = n.PlanCobertura;
                cbEstatusPlanCobertura.Checked = (n.Estatus0.HasValue ? n.Estatus0.Value : false);
            }
        }

        protected void btnGuardarPlanCobertura_Click(object sender, EventArgs e)
        {
            MANPlanCoberturas();
            ListadoPlanCoberturas();
            CargarCoberturas();
        }
    }
}
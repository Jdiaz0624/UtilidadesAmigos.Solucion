using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarCarteraIntermedirio : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();


        #region CARGAR LAS OFICINAS
        private void CargarOficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaConsulta, ObjDataConexion.Value.BuscaListas("OFICINA", null, null), true);
        }
        #endregion
        #region MOSTRAR EL LISTADO DE INTERMEDIARIO
        private void MostrarListadoIntermediaioro()
        {
            try {
                string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? null : txtCodigoSupervisorConsulta.Text.Trim();
                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();
                string _NombreVendedor = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();

                var Consultar = ObjDataConexion.Value.SacarDatosIntermediarios(
                    _CodigoSupervisor,
                   _CodigoIntermediario,
                    _Oficina,
                    _NombreVendedor);
                gvListadoIntermediario.DataSource = Consultar;
                gvListadoIntermediario.DataBind();
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }
        #endregion
        #region MOSTRAR LAS COMISIONES DE LOS INTERMEDIARIOS
        private void MostrarComisionesIntermediario()
        {
            try {
                var MostrarComisionesIntermediario = ObjDataConexion.Value.GenerarComisionIntermediario(
               Convert.ToDateTime(txtFechaDesdeGenerarComision.Text),
               Convert.ToDateTime(txtFechaHastaGenerarComision.Text),
               Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));
                foreach (var n in MostrarComisionesIntermediario)
                {

                }
                gvComisionIntermediario.DataSource = MostrarComisionesIntermediario;
                gvComisionIntermediario.DataBind();
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }

      
        }
        #endregion
        #region MOSTRAR LA CARTERA DE LOS INTERMEDIARIOS
        private void MostrarCarteraIntermediarios(decimal CofigoIntermediario)
        {
            try {
                var Cartera = ObjDataConexion.Value.BuscaSacarCarteraIntermediario(
               null,
               Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));
                gvCarteraIntermeiarios.DataSource = Cartera;
                gvCarteraIntermeiarios.DataBind();
            }
            catch (Exception) {

                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }
        #endregion
        #region SACAR LA PRODUCCION DE LOS INTERMEDIARIOS
        private void SacarProduccionIntermediarios()
        {
            try {
                var SacarProduccion = ObjDataConexion.Value.SacarProduccionIntermediario(
                    Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                    Convert.ToDateTime(txtFechaHastaProduccion.Text),
                    Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));
                foreach (var n in SacarProduccion)
                {
                    decimal Total = Convert.ToDecimal(n.Total.ToString());
                    lbTotalProduccion.Text = Total.ToString("N2");
                }
                gvListadoProduccion.DataSource = SacarProduccion;
                gvListadoProduccion.DataBind();
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }
        #endregion
        #region GENERAR LISTADO DE COMISIONES MASIVO
        private void GenerarProcesoComisionesmAsivo()
        {
            //VERIFICAMOS SI LOS CAMPOS DE FECHA ESTAN VACIOS
            if (string.IsNullOrEmpty(txtFechaDesdeGenerarComision.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaGenerarComision.Text.Trim()))
            {
            }
            else
            { 
         

                //SACAMOS EL LISTADO DE COMISIONES MEDIANTE LOS PARAMETROS INGRESADOS
                int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamoComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoComisiones.SelectedValue) : new Nullable<int>();

                var BuscarCodigosIntermediarios = ObjDataConexion.Value.SacarCodigoIntermediarios(
                    Convert.ToDateTime(txtFechaDesdeGenerarComision.Text),
                    Convert.ToDateTime(txtFechaHastaGenerarComision.Text),
                    _Ramo,
                    _Oficina);
                if (BuscarCodigosIntermediarios.Count() < 1)
                {

                }
                else
                {
                    //RECORREMOS EL LISTADO ENCONTRADO PARA IR GUARDADO LOS DATOS EN LA TABLA Y EXPORTAR A EXEL
                    foreach (var n in BuscarCodigosIntermediarios)
                    {
                        var BuscarComisiones = ObjDataConexion.Value.GenerarComisionIntermediario(
                            Convert.ToDateTime(txtFechaDesdeGenerarComision.Text),
                            Convert.ToDateTime(txtFechaHastaGenerarComision.Text),
                            Convert.ToDecimal(n.Vendedor),
                            _Oficina);
                        if (BuscarComisiones.Count() < 1)
                        {

                        }
                        else
                        {
                            foreach (var n2 in BuscarComisiones)
                            {
                                //GUARDAMOS LOS DATOS
                                UtilidadesAmigos.Logica.Entidades.EGuardarDatosComisionIntermediario Guardar = new Logica.Entidades.EGuardarDatosComisionIntermediario();
                                Guardar.IdUsuario = Convert.ToDecimal(lbCodigoUsuario.Text);
                                Guardar.FechaDesde = Convert.ToDateTime(txtFechaDesdeGenerarComision.Text);
                                Guardar.FechaHasta = Convert.ToDateTime(txtFechaHastaGenerarComision.Text);
                                Guardar.Supervisor = n2.Supervisor;
                                Guardar.CodigoIntermediario = Convert.ToDecimal(n2.Codigo);
                                Guardar.Intermediario = n2.Intermediario;
                                Guardar.Oficina = n2.Oficina;
                                Guardar.NumeroIdentificacion = n2.NumeroIdentificacion;
                                Guardar.CuentaBanco = n2.CuentaBanco;
                                Guardar.TipoCuenta = n2.TipoCuenta;
                                Guardar.Banco = n2.Banco;
                                Guardar.Cliente = n2.Cliente;
                                Guardar.Recibo = n2.Recibo;
                                Guardar.Fecha = n2.Fecha;
                                Guardar.Factura = n2.Factura;
                                Guardar.FechaFactura = n2.FechaFactura;
                                Guardar.Moneda = n2.Moneda;
                                Guardar.Poliza = n2.Poliza;
                                Guardar.Producto = n2.Producto;
                                Guardar.Bruto = Convert.ToDecimal(n2.Bruto);
                                Guardar.Neto = Convert.ToDecimal(n2.Neto);
                                Guardar.PorcientoComision = Convert.ToDecimal(n2.PorcientoComision);
                                Guardar.Comision = Convert.ToDecimal(n2.Comision);
                                Guardar.Retencion = Convert.ToDecimal(n2.Retencion);
                                Guardar.AvanceComision = Convert.ToDecimal(n2.AvanceComision);
                                Guardar.ALiquidar = Convert.ToDecimal(n2.ALiquidar);

                                var MANGuardar = ObjDataConexion.Value.GuardarComisionesIntermediario(Guardar, "INSERT");
                            }
                        }
                    }
                    //EXPORTAMOS LA INFORMACION A EXEL
                    var ExportarComisiones = (from n in ObjDataConexion.Value.ExportarComisionesIntermediario(Convert.ToDecimal(lbCodigoUsuario.Text))
                                              select new
                                              {
                                                  Intermediario = n.Intermediario,
                                                  Oficina = n.Oficina,
                                                  NumeroIdentificacion = n.NumeroIdentificacion,
                                                  CuentaBanco = n.CuentaBanco,
                                                  TipoCuenta = n.TipoCuenta,
                                                  Banco = n.Banco,
                                                  Cantidad = n.Cantidad,
                                                  Bruto = n.Bruto,
                                                  Neto = n.Neto,
                                                  ComisionBruta = n.ComisionBruta,
                                                  Retencion = n.Retencion,
                                                  AvanceComision = n.AvanceComision,
                                                  ALiquidar = n.ALiquidar
                                              }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comisiones desde " + txtFechaDesdeGenerarComision.Text + " Hasta " + txtFechaHastaGenerarComision.Text + " de " + ddlSeleccionaroficinaComisiones.Text, ExportarComisiones);
                }
            }
        }
        #endregion
        #region GENERAR REPORTE PRODUCCION INTERMEDIARIO
        private void GenerarReporteProduccionIntermediario(decimal IdUsuario) {


            UtilidadesAmigos.Logica.Comunes.GuardarRegistrosReporteIntermediario Eliminar = new Logica.Comunes.GuardarRegistrosReporteIntermediario(
                  IdUsuario,
                  "",
                  "",
                  DateTime.Now,
                  "",
                  "",
                  0,
                  "",
                  "",
                  "",
                  "",
                  0,
                  "",
                  0,
                  "",
                  "",
                  0,
                  "",
                  "",
                  "",
                  "",
                  "",
                  "",
                  "",
                  "",
                  "",
                  0,
                  "DELETE");
            Eliminar.ProcesarInformacion();
            //GUARDAMOS LOS DATOS A PROCESAR

            var SacarProduccion = ObjDataConexion.Value.SacarProduccionIntermediario(
                   Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                   Convert.ToDateTime(txtFechaHastaProduccion.Text),
                   Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));
            foreach (var n in SacarProduccion)
            {
                //GUARDAMOS
                UtilidadesAmigos.Logica.Comunes.GuardarRegistrosReporteIntermediario Guardar = new Logica.Comunes.GuardarRegistrosReporteIntermediario(
                    IdUsuario,
                    n.Poliza,
                    n.NoFactura,
                    Convert.ToDateTime(n.Fecha0),
                    n.Mes,
                    n.Fecha,
                    Convert.ToDecimal(n.Valor),
                    n.Cliente,
                    n.Vendedor,
                    n.Cobrador,
                    n.Concepto,
                    Convert.ToDecimal(n.Balance),
                    n.Ncf,
                    Convert.ToDecimal(n.Tasa),
                    n.Moneda,
                    n.Oficina,
                    Convert.ToDecimal(n.Total),
                    n.TipoVehiculo,
                    n.Marca,
                    n.Modelo,
                    n.Capacidad,
                    n.Ano,
                    n.Color,
                    n.Chasis,
                    n.Placa,
                    n.Uso,
                    Convert.ToDecimal(n.ValorVehiculo),
                    "INSERT");
                Guardar.ProcesarInformacion();


              

            }
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "[Utililades].[SP_GENERAR_REPORTE_PRODUCCION_INTERMEDIARIO] @IdUsuario";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal);
                comando.Parameters["@IdUsuario"].Value = IdUsuario;

                Factura.Load(@"C:\Users\Ing.Juan Marcelino\Desktop\ReporteProduccionIntermediario.rpt");
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetDatabaseLogon("sa", "Pa$$W0rd");
                Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Produccion ");
                //  Factura.PrintToPrinter(1, false, 0, 1);
                //  crystalReportViewer1.ReportSource = Factura;



            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al generar la factura de venta, favor de contactar al administrador del sistema, codigo de error--> " + ex.Message, VariablesGlobales.NombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarOficinas();
                ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();",true);

                lbSeleccionarOficinaComisiones.Visible = false;
                ddlSeleccionaroficinaComisiones.Visible = false;
                //CARGAR LAS OFICINAS Y RAMOS PARA GENERAR LAS COMISIONES
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaComisiones, ObjDataConexion.Value.BuscaListas("OFICINAS", null, null), true);
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamoComisiones, ObjDataConexion.Value.BuscaListas("RAMO", null, null), true);
                lbCodigoUsuario.Text = Session["IdUsuario"].ToString();

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
              MostrarListadoIntermediaioro();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
          
        }

        protected void btnRestabelecer_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void gvListadoIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoIntermediario.PageIndex = e.NewPageIndex;
            MostrarListadoIntermediaioro();
            ClientScript.RegisterStartupScript(GetType(), "BloquearControles", "BloquearControles();", true);
        }

        protected void gvListadoIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gb = gvListadoIntermediario.SelectedRow;

            var SacarCodigoIntermediario = ObjDataConexion.Value.SacarDatosIntermediarios(
                null,
                gb.Cells[2].Text);
            foreach (var n in SacarCodigoIntermediario)
            {
                lbNombreIntermediarioComision.Text = n.NombreVendedor;
                lbNombreIntermediarioCartera.Text = n.NombreVendedor;
                lbNombreIntermediarioProduccion.Text = n.NombreVendedor;
            }
            lbGenerarCodifoIntermediario.Text = gb.Cells[2].Text;
            gvListadoIntermediario.DataSource = SacarCodigoIntermediario;
            gvListadoIntermediario.DataBind();
            MostrarCarteraIntermediarios(Convert.ToDecimal(lbGenerarCodifoIntermediario.Text));


            ClientScript.RegisterStartupScript(GetType(), "ActivarControles", "ActivarControles();", true);
        }

        protected void btnGenerarComisionIntermediario_Click(object sender, EventArgs e)
        {
            MostrarComisionesIntermediario();
         
        }

        protected void btnExportarExel_Click(object sender, EventArgs e)
        {
            try {
                var Exportar = (from n in ObjDataConexion.Value.GenerarComisionIntermediario(
                Convert.ToDateTime(txtFechaDesdeGenerarComision.Text),
                Convert.ToDateTime(txtFechaHastaGenerarComision.Text),
                Convert.ToDecimal(lbGenerarCodifoIntermediario.Text))
                                select new
                                {
                                    Supervisor = n.Supervisor,
                                    Intermediario = n.Intermediario,
                                    Oficina = n.Oficina,
                                    NumeroIdentificacion = n.NumeroIdentificacion,
                                    CuentaBanco = n.CuentaBanco,
                                    TipoCuenta = n.TipoCuenta,
                                    Banco = n.Banco,
                                    Cliente = n.Cliente,
                                    Recibo = n.Recibo,
                                    Fecha = n.Fecha,
                                    Factura = n.Factura,
                                    FechaFactura = n.FechaFactura,
                                    Moneda = n.Moneda,
                                    Poliza = n.Poliza,
                                    Producto = n.Producto,
                                    Bruto = n.Bruto,
                                    Neto = n.Neto,
                                    PorcientoComision = n.PorcientoComision,
                                    Comision = n.Comision,
                                    Retencion = n.Retencion,
                                    AvanceComision = n.AvanceComision,
                                    ALiquidar = n.ALiquidar
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comision " + lbNombreIntermediarioComision.Text + "", Exportar);
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }

        protected void gvComisionIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvComisionIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvCarteraIntermeiarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCarteraIntermeiarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnExportarCarteraExel_Click(object sender, EventArgs e)
        {
            try {
                var Cartera = (from n in ObjDataConexion.Value.BuscaSacarCarteraIntermediario(
             null,
             Convert.ToDecimal(lbGenerarCodifoIntermediario.Text))
                               select new
                               {
                                   Supervisor = n.Supervisor,
                                   Intermediario = n.Intermediario,
                                   Poliza = n.Poliza,
                                   Estatus = n.Estatus,
                                   Ramo = n.Ramo,
                                   SubRamo = n.SubRamo,
                                   Cliente = n.Cliente,
                                   Telefonos=n.Telefonos,
                                   SumaAsegurada = n.SumaAsegurada,
                                   Prima = n.prima,
                                   TotalFacturado = n.TotalFacturado,
                                   TotalPagado = n.TotalPagado,
                                   Balance = n.Balance
                               }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera " + lbNombreIntermediarioCartera.Text + "", Cartera);
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }

        protected void gvListadoProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoProduccion.PageIndex = e.NewPageIndex;
            SacarProduccionIntermediarios();
        }

        protected void gvListadoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarProduccion_Click(object sender, EventArgs e)
        {
            SacarProduccionIntermediarios();
        }

        protected void btnExportarExelProduccion_Click(object sender, EventArgs e)
        {
            try {
                var Exportar = (from n in ObjDataConexion.Value.SacarProduccionIntermediario(
                    Convert.ToDateTime(txtFechaDesdeProduccion.Text),
                    Convert.ToDateTime(txtFechaHastaProduccion.Text),
                    Convert.ToDecimal(lbGenerarCodifoIntermediario.Text))
                                select new
                                {
                                    Poliza=n.Poliza,                                   
                                    Fecha=n.Fecha,
                                    Cliente=n.Cliente,
                                    Vendedor=n.Vendedor,
                                    Cobrador=n.Cobrador,
                                    NoFactura = n.NoFactura,
                                    Valor = n.Valor,
                                    Concepto =n.Concepto,
                                    Balance=n.Balance,
                                    Ncf=n.Ncf,
                                    Tasa=n.Tasa,
                                    Moneda=n.Moneda,
                                    Oficina=n.Oficina,
                                    Total=n.Total,
                                    TipoVehiculo = n.TipoVehiculo,
                                    Marca = n.Marca,
                                    Modelo = n.Modelo,
                                    Capacidad = n.Capacidad,
                                    Ano = n.Ano,
                                    Color = n.Color,
                                    Chasis = n.Chasis,
                                    Placa = n.Placa,
                                    Uso = n.Uso,
                                    ValorVehiculo = n.ValorVehiculo
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción " + lbNombreIntermediarioCartera.Text + "", Exportar);
            }
            catch (Exception) { ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true); }
        }

        protected void gvComisionIntermediario_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvListadoProduccion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void cbGenerarComisionGlobal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGenerarComisionGlobal.Checked == true)
            {
                lbSeleccionarOficinaComisiones.Visible = true;
                ddlSeleccionaroficinaComisiones.Visible = true;

                lbSeleccionarRamoComisiones.Visible = true;
                ddlSeleccionarRamoComisiones.Visible = true;

                btnGenerarComisionIntermediario.Enabled = false;
                btnExportarExel.Enabled = false;

                btnGenerarComisionGeneral.Enabled = true;
            }
            else
            {
                lbSeleccionarOficinaComisiones.Visible = false;
                ddlSeleccionaroficinaComisiones.Visible = false;


                lbSeleccionarRamoComisiones.Visible = false;
                ddlSeleccionarRamoComisiones.Visible = false;

                btnGenerarComisionIntermediario.Enabled = true;
                btnExportarExel.Enabled = true;

                btnGenerarComisionGeneral.Enabled = false;
            }
        }

        protected void btnGenerarComisionGeneral_Click(object sender, EventArgs e)
        {
            if (cbGenerarComisionGlobal.Checked == true)
            {
                //ELIMINAMOS LOS DATOS BAJO EL USUAIRO INGRESADO

                UtilidadesAmigos.Logica.Entidades.EGuardarDatosComisionIntermediario Eliminar = new Logica.Entidades.EGuardarDatosComisionIntermediario();
                Eliminar.IdUsuario = Convert.ToDecimal(lbCodigoUsuario.Text);
                var MANDelete = ObjDataConexion.Value.GuardarComisionesIntermediario(Eliminar, "DELETE");
                GenerarProcesoComisionesmAsivo();
            }
        }

        protected void btnGenerarReporteProduccion_Click(object sender, EventArgs e)
        {
            GenerarReporteProduccionIntermediario(Convert.ToDecimal(Session["IdUsuario"]));
        }
    }
}
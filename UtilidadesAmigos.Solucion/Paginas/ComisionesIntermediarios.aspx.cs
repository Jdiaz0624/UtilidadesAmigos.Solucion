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
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ComisionesIntermediarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();

        #region BUSCAR COMISIONES DE INTERMEDIARIOS
        private void GenerarComisionesIntermediarios()
        {
            try
            {
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta()", "ErrorConsulta();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                    }
                }
                else
                {
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
                    int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();

                    var GenerarComisiones = ObjDataConexion.Value.GenerarComisionIntermediario(
                        Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                        Convert.ToDateTime(txtFechaHastaComisiones.Text),
                        _CodigoIntermediario,
                        _Oficina,
                        Convert.ToDecimal(txtTasaDollar.Text));
                    gvComisionIntermediario.DataSource = GenerarComisiones;
                    gvComisionIntermediario.DataBind();

                }
            }
            catch (Exception) { }
        }
        #endregion
        #region EXPORTAR COMISIONES
        private void ExportarComisionesIntermediarios()
        {

            try
            {
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta()", "ErrorConsulta();", true);
                    if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                    }
                    if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                    }
                }
                else
                {
                    //ELIMINAMOS LOS REGISTROS
                    UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                        Convert.ToDecimal(Session["IdUsuario"]), "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
                    Eliminar.ProcesarInformacion();

                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
                    int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
                   

                    var GenerarComisiones = ObjDataConexion.Value.GenerarComisionIntermediario(
                        Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                        Convert.ToDateTime(txtFechaHastaComisiones.Text),
                        _CodigoIntermediario,
                        _Oficina,
                        Convert.ToDecimal(txtTasaDollar.Text));
                    foreach (var n in GenerarComisiones)
                    {
                        UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Guardar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                            Convert.ToDecimal(Session["IdUsuario"]),
                            n.Supervisor,
                            Convert.ToInt32(n.Codigo),
                            n.Intermediario,
                            n.Oficina,
                            n.NumeroIdentificacion,
                            n.CuentaBanco,
                            n.TipoCuenta,
                            n.Banco,
                            n.Cliente,
                            n.Recibo,
                            n.Fecha,
                            n.Factura,
                            n.FechaFactura,
                            n.Moneda,
                            n.Poliza,
                            n.Producto,
                            Convert.ToDecimal(n.Bruto),
                            Convert.ToDecimal(n.Neto),
                            Convert.ToDecimal(n.PorcientoComision),
                            Convert.ToDecimal(n.Comision),
                            Convert.ToDecimal(n.Retencion),
                            Convert.ToDecimal(n.AvanceComision),
                            Convert.ToDecimal(n.ALiquidar),
                            Convert.ToDecimal(n.CantidadRegistros),
                            Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                            Convert.ToDateTime(txtFechaHastaComisiones.Text),
                            "INSERT");
                        Guardar.ProcesarInformacion();

                    }
                    // ImprimirReporteResumido(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteComisionIntermediarioResumido.rpt"), "sa", "Pa$$W0rd", "Listado de Comisiones Resumido");
                    if (rbGenerarReporteResumido.Checked)
                    {
                        var ExportarResumen = (from n in ObjDataConexion.Value.ComisionIntermediarioResumido(Convert.ToDecimal(Session["IdUsuario"]))
                                               select new
                                               {
                                                   //IdUsuario = n.IdUsuario,
                                                   //GeneradoPor = n.GeneradoPor,
                                                   Supervisor = n.Supervisor,
                                                   //CodigoIntermediario = n.CodigoIntermediario,
                                                   Intermediario = n.Intermediario,
                                                   Oficina = n.Oficina,
                                                   NumeroIdentificacion = n.NumeroIdentificacion,
                                                   CuentaBanco = n.CuentaBanco,
                                                   TipoCuenta = n.TipoCuenta,
                                                   Banco = n.Banco,
                                                   Producto = n.Producto,
                                                   MontoBruto = n.MontoBruto,
                                                   MontoNeto = n.MontoNeto,
                                                   Comision = n.Comision,
                                                   Retencion = n.Retencion,
                                                   AvanceComision = n.AvanceComision,
                                                   ALiquidar = n.ALiquidar,
                                                   //ValidadoDesde = n.ValidadoDesde,
                                                   FechaDesde = n.FechaDesde,
                                                   FechaHasta = n.FechaHasta
                                               }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comisión de Intermediario Fesumen " + txtFechaDesdeComisiones.Text + " - " + txtFechaHastaComisiones.Text, ExportarResumen);
                    }

                    else if (rbGenerarReporteDetalle.Checked)
                    {
                        var ExportarDetalle = (from n in ObjDataConexion.Value.ComisionIntermediarioDetalle(Convert.ToDecimal(Convert.ToDecimal(Session["IdUsuario"])))
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
                                                   NumeroRecibo = n.NumeroRecibo,
                                                   FechaRecibo = n.FechaRecibo,
                                                   NumeroFactura = n.NumeroFactura,
                                                   FechaFactura = n.FechaFactura,
                                                   Moneda = n.Moneda,
                                                   Poliza = n.Poliza,
                                                   Producto = n.Producto,
                                                   MontoBruto = n.MontoBruto,
                                                   MontoNeto = n.MontoNeto,
                                                   PorcientoComision = n.PorcientoComision,
                                                   Comsiion = n.Comsiion,
                                                   Retencion = n.Retencion,
                                                   AvanceComision = n.AvanceComision,
                                                   ALiquidar = n.ALiquidar,
                                                   FechaDesde = n.FechaDesde,
                                                   FechaHasta = n.FechaHasta
                                               }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comisión de Intermediario Detalle " + txtFechaDesdeComisiones.Text + " - " + txtFechaHastaComisiones.Text, ExportarDetalle);
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion
        #region PROCESAR INFORMACION
        private void ProcesarInformacionComisiones() {
          

            //BUSCAMOS LOS REGISTROS

            if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta()", "ErrorConsulta();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaComisionesVAcio()", "FechaHastaComisionesVAcio();", true);
                }
            }
            else
            {
                //ELIMINAMOS LOS REGISTROS
                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                    Convert.ToDecimal(Session["IdUsuario"]), "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");

                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
                int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
                Eliminar.ProcesarInformacion();

                var GenerarComisiones = ObjDataConexion.Value.GenerarComisionIntermediario(
                    Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                    Convert.ToDateTime(txtFechaHastaComisiones.Text),
                    _CodigoIntermediario,
                    _Oficina,
                    Convert.ToDecimal(txtTasaDollar.Text)
                    );
                foreach (var n in GenerarComisiones) {
                    UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Guardar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                        Convert.ToDecimal(Session["IdUsuario"]),
                        n.Supervisor,
                        Convert.ToInt32(n.Codigo),
                        n.Intermediario,
                        n.Oficina,
                        n.NumeroIdentificacion,
                        n.CuentaBanco,
                        n.TipoCuenta,
                        n.Banco,
                        n.Cliente,
                        n.Recibo,
                        n.Fecha,
                        n.Factura,
                        n.FechaFactura,
                        n.Moneda,
                        n.Poliza,
                        n.Producto,
                        Convert.ToDecimal(n.Bruto),
                        Convert.ToDecimal(n.Neto),
                        Convert.ToDecimal(n.PorcientoComision),
                        Convert.ToDecimal(n.Comision),
                        Convert.ToDecimal(n.Retencion),
                        Convert.ToDecimal(n.AvanceComision),
                        Convert.ToDecimal(n.ALiquidar),
                        Convert.ToDecimal(n.CantidadRegistros),
                        Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                        Convert.ToDateTime(txtFechaHastaComisiones.Text),
                        "INSERT");
                    Guardar.ProcesarInformacion();
                   
                }
                // ImprimirReporteResumido(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteComisionIntermediarioResumido.rpt"), "sa", "Pa$$W0rd", "Listado de Comisiones Resumido");
                if (rbGenerarReporteResumido.Checked)
                {
                    ImprimirReporteResumido(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteComisionIntermediarioResumido.rpt"), "sa", "Pa$$W0rd", "Listado de Comisiones Resumido");
                }

                else if (rbGenerarReporteDetalle.Checked)
                {
                    ImprimirFactura(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteComisionesIntermediario.rpt"), "sa", "Pa$$W0rd", "Listado de Comisiones");
                }

            }
        }
        #endregion
        #region IMPRIMIR REPORTE
        private void ImprimirFactura(decimal IdUsuario, string RutaReporte, string UsuaruoBD, string ClaveBD, string NombreArchivo)
        {
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_COMISIONES_INTERMEDIARIO] @IdUsuario";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal);
                comando.Parameters["@IdUsuario"].Value = IdUsuario;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetDatabaseLogon(UsuaruoBD, ClaveBD);
                Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);

                //  Factura.PrintToPrinter(1, false, 0, 1);
                //  crystalReportViewer1.ReportSource = Factura;



            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al generar la factura de venta, favor de contactar al administrador del sistema, codigo de error--> " + ex.Message, VariablesGlobales.NombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirReporteResumido(decimal IdUsuario, string RutaReporte, string UsuaruoBD, string ClaveBD, string NombreArchivo)
        {
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_COMISIONES_INTERMEDIARIO_RESUMIDO] @IdUsuario";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal);
                comando.Parameters["@IdUsuario"].Value = IdUsuario;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetDatabaseLogon(UsuaruoBD, ClaveBD);
                Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);

                //  Factura.PrintToPrinter(1, false, 0, 1);
                //  crystalReportViewer1.ReportSource = Factura;



            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al generar la factura de venta, favor de contactar al administrador del sistema, codigo de error--> " + ex.Message, VariablesGlobales.NombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void CargarSucursalesComisiones()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursalComisiones, ObjDataConexion.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinasComisiones()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaComisiones, ObjDataConexion.Value.BuscaListas("OFICINA", ddlSeleccionarSucursalComisiones.SelectedValue, null), true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CargarSucursalesComisiones();
                CargarOficinasComisiones();
                rbGenerarReporteResumido.Checked = true;
                txtTasaDollar.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
            }
        }

        protected void btnConsultarComisiones_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTasaDollar.Text.Trim())) {
                
                    ClientScript.RegisterStartupScript(GetType(), "CampoTasaVacio", "CampoTasaVacio();", true);
            }
            else {
                GenerarComisionesIntermediarios();
            }
            
        }

        protected void btnExortarComisiones_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTasaDollar.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CampoTasaVacio", "CampoTasaVacio();", true);
            }
            else {
                ExportarComisionesIntermediarios();
            }
            
        }

        protected void btnReporteCOmisiones_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTasaDollar.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoTasaVacio", "CampoTasaVacio();", true); }
            else {
                if (rbGenerarReporteInterno.Checked == true) {
                    if (Session["IdUsuario"] != null) {
                        //ELIMINAMOS LOS DATOS DE LA TABLA
                        UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionDatosReporteIntermediarioInterno Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionDatosReporteIntermediarioInterno(
                            Convert.ToDecimal(Session["IdUsuario"]), "", "", "", 0, "", "", "", "", 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
                        Eliminar.ProcesarInformacionReporteComisionInterno();

                        //BUSCAMOS LA INFORMAICON A PROCESAR
                        string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
                        int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();

                        var GenerarInformacionComision = ObjDataConexion.Value.GenerarComisionIntermediario(
                            Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                            Convert.ToDateTime(txtFechaHastaComisiones.Text),
                            _CodigoIntermediario,
                            _Oficina,
                            Convert.ToDecimal(txtTasaDollar.Text));
                        foreach (var n in GenerarInformacionComision)
                        {
                            //GUARDAMOS LOS REGISTROS
                            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionDatosReporteIntermediarioInterno Guardar = new Logica.Comunes.Reportes.ProcesarInformacionDatosReporteIntermediarioInterno(
                                     Convert.ToDecimal(Session["IdUsuario"]),
                                     n.Producto,
                                     n.Oficina,
                                     n.Intermediario,
                                     Convert.ToDecimal(n.PorcientoComision),
                                     n.NumeroIdentificacion,
                                     n.CuentaBanco,
                                     n.TipoCuenta,
                                     n.Banco,
                                     Convert.ToDecimal(n.Bruto),
                                     Convert.ToDecimal(n.Neto),
                                     Convert.ToDecimal(n.Comision),
                                     Convert.ToDecimal(n.Retencion),
                                     Convert.ToDecimal(n.AvanceComision),
                                     Convert.ToDecimal(n.ALiquidar),
                                     Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                                     Convert.ToDateTime(txtFechaHastaComisiones.Text),
                                     "INSERT");
                            Guardar.ProcesarInformacionReporteComisionInterno();

                        }

                        //GENERAMOS EL REPORTE
                    }
                    else {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }

                }
                else{
                    ProcesarInformacionComisiones();
                }
            }
           
        }

        protected void gvComisionIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void ddlSeleccionarSucursalComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinasComisiones();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteAntiguedadSaldo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObDataMantenimiento = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();

        #region GENERAR REPORTE
        //REPORTE RESUMIDO
        private void AntiguedadSaldoResumido(decimal IdUsuario, decimal TasaDollar, int SuperResumido, string RutaReporte, string UsuaruoBD, string ClaveBD, string NombreArchivo)
        {
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_REPORTE_ANTIDAD_SALDO_RESUMIDO] @IdUsuario,@TasaDollar,@SuperResumido";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", System.Data.SqlDbType.Decimal);
                comando.Parameters.Add("@TasaDollar", System.Data.SqlDbType.Decimal);
                comando.Parameters.Add("@SuperResumido", System.Data.SqlDbType.Int);

                comando.Parameters["@IdUsuario"].Value = IdUsuario;
                comando.Parameters["@TasaDollar"].Value = TasaDollar;
                comando.Parameters["@SuperResumido"].Value = SuperResumido;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetParameterValue("@TasaDollar", TasaDollar);
                Factura.SetParameterValue("@SuperResumido", SuperResumido);
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

        //REPORTE DETALLE
        private void AntiguedadSaldoDetalle(decimal IdUsuario, decimal TasaDollar, string RutaReporte, string UsuaruoBD, string ClaveBD, string NombreArchivo)
        {
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_REPORTE_ANTIDAD_SALDO_DETALLE] @IdUsuario,@TasaDollar";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", System.Data.SqlDbType.Decimal);
                comando.Parameters.Add("@TasaDollar", System.Data.SqlDbType.Decimal);

                comando.Parameters["@IdUsuario"].Value = IdUsuario;
                comando.Parameters["@TasaDollar"].Value = TasaDollar;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetParameterValue("@TasaDollar", TasaDollar);
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

        private void ProcesarInformacion() {
          //  try {
                //BUSCAMOS LA INFORMACION MEDIANTE LOS FILTROS INGRESADOS
                string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFacturaConsulta.Text.Trim()) ? null : txtNumeroFacturaConsulta.Text.Trim();
                string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
                int? Tipo = 0;
                if (rbTodosMovimientos.Checked == true)
                {
                    Tipo = null;
                }
                else if (rbFacturas.Checked == true)
                {
                    Tipo = 10;
                }
                else if (rbCreditos.Checked == true)
                {
                    Tipo = 8;
                }
                else if (rbPrimaDepositos.Checked == true)
                {
                    Tipo = 22;
                }
                else {
                    Tipo = 0;
                }

                var BuscarRegistros = ObDataMantenimiento.Value.BuscarDatosAntiguedadSaldo(
                    Convert.ToDateTime(txtFechaCorteConsulta.Text),
                    _NumeroFactura, _Poliza, _Ramo, Tipo);
                foreach (var n in BuscarRegistros) {
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                        (decimal)Session["Idusuario"],
                        Convert.ToDateTime(txtFechaCorteConsulta.Text),
                        n.Documento,
                        Convert.ToDecimal(n.NumeroFacturaFiltro),
                        Convert.ToInt32(n.Tipo),
                        n.DescripcionTipo,
                        n.Asegurado,
                        Convert.ToDecimal(n.ClienteFiltro),
                        n.Fecha,
                        n.Intermediario,
                        Convert.ToInt32(n.VendedorFiltro),
                        n.Poliza,
                        Convert.ToInt32(n.CodMoneda),
                        n.DescripcionMoneda,
                        n.Estatus,
                        Convert.ToInt32(n.CodRamo),
                        n.InicioVigencia,
                        Convert.ToDateTime(n.Inicio),
                        n.FinVigencia,
                        Convert.ToDateTime(n.Fin),
                        Convert.ToInt32(n.CodOficina),
                        n.Oficina,
                        Convert.ToInt32(n.Dias),
                        Convert.ToDecimal(n.Facturado),
                        Convert.ToDecimal(n.Cobrado),
                        Convert.ToDecimal(n.Balance),
                        Convert.ToDecimal(n.Impuesto),
                        Convert.ToDecimal(n.PorcComision),
                        Convert.ToDecimal(n.ValorComision),
                        Convert.ToDecimal(n.ComisionPendiente),
                        Convert.ToDecimal(n.__0_10),
                        Convert.ToDecimal(n.__0_30),
                        Convert.ToDecimal(n.__31_60),
                        Convert.ToDecimal(n.__61_90),
                        Convert.ToDecimal(n.__91_120),
                        Convert.ToDecimal(n.__121_150),
                        Convert.ToDecimal(n.__151_MAS),
                        Convert.ToDecimal(n.Total),
                        Convert.ToDecimal(n.Diferencia),
                        Convert.ToInt32(n.OrdenTipo),
                        "INSERT");
                    Procesar.ProcesarInformacion();

                }
            //}
            //catch (Exception) {
            //    ClientScript.RegisterStartupScript(GetType(), "ErrorProceso()", "ErrorProceso();", true);
            //}
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rbReporteResumido.Checked = true;
               // rbPorRamo.Checked = true;
                rbTodosMovimientos.Checked = true;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamoConsulta, ObjdataGeneral.Value.BuscaListas("RAMO", null, null), true);

                //SACAMOS LA TASA DE LA MONEDA
                txtTasaDollar.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
            }
        }

        protected void btnExportarRegistros_Click(object sender, EventArgs e)
        {
            //VALIDAMOS SI EL CAMPO FECHA DE CORTE ESTA VACIO
            if (string.IsNullOrEmpty(txtFechaCorteConsulta.Text.Trim()) || string.IsNullOrEmpty(txtTasaDollar.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios()", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaCorteConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Campofechacortevacio()", "Campofechacortevacio();", true);
                }
                if (string.IsNullOrEmpty(txtTasaDollar.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoTasaVacio()", "CampoTasaVacio();", true);
                }
            }
            else {
                if (Session["Idusuario"] != null) {
                 
                    //ELIMINAMOS LOS CAMPOS 
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                       (decimal)Session["Idusuario"], DateTime.Now, "", 0, 0, "", "", 0, "", "", 0, "", 0, "", "", 0, "", DateTime.Now, "", DateTime.Now, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "DELETE");
                    Eliminar.ProcesarInformacion();
                    ProcesarInformacion();

                    //EXPORTAMOS LA INFORMACION
                    //RESUMIDA
                    if (rbReporteResumido.Checked == true) {
                        var ExportarReporteResumido = (from n in ObDataMantenimiento.Value.ReporteAntiguedadSaldoResumido(
                            (decimal)Session["IdUsuario"],
                            Convert.ToDecimal(txtTasaDollar.Text),
                            0)
                                                       select new {
                                                           Moneda =n.DescripcionMoneda,
                                                           Ramo=n.Ramo,
                                                           Balance=n.Balance,
                                                           _0_30=n.__0_30,
                                                           _31_60=n.__31_60,
                                                           _61_90=n.__61_90,
                                                           _91_120=n.__91_120,
                                                           _121_150=n.__121_150,
                                                           _151_Mas=n.__151_Mas,
                                                           Total=n.Total,
                                                           TotalPesos=n.TotalPesos,
                                                           Tasa=n.Tasa

                                                       }).ToList();
                        string FechaCorte = txtFechaCorteConsulta.Text;
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Antiguedad Saldo Resumido cortado al " + FechaCorte, ExportarReporteResumido);
                    }
                    //SUPER RESUMIDA
                    else if (rbReporteSuperResumido.Checked == true) {
                        ClientScript.RegisterStartupScript(GetType(), "FuncionNoDisponible()", "FuncionNoDisponible();", true);
                    }
                    //DETALLADA
                    else if (rbReporteDetallado.Checked == true) {
                        var ExportarReporteDetallado = (from n in ObDataMantenimiento.Value.ReporteAntiguedadSaldoDetalle(
                            (decimal)Session["IdUsuario"],
                            Convert.ToDecimal(txtTasaDollar.Text))
                                                        select new {
                                                            Numero_Factura=n.DocumentoFormateado,
                                                            Tipo_Documento=n.DescripcionTipo,
                                                            Fecha_Factura=n.FechaFactura,
                                                            Asegurado=n.Asegurado,
                                                            Intermediario=n.Intermediario,
                                                            Poliza=n.Poliza,
                                                            Moneda=n.DescripcionMoneda,
                                                            Estatus=n.Estatus,
                                                            Ramo=n.Ramo,
                                                            Inicio_Vigencia=n.InicioVigencia,
                                                            Fin_Vigencia=n.FinVigencia,
                                                            Oficina=n.Oficina,
                                                            CantidadDias=n.dias,
                                                            Facturado=n.Facturado,
                                                            Cobrado=n.Cobrado,
                                                            Balance=n.Balance,
                                                            Impuesto=n.Impuesto,
                                                            PorcientoComision=n.PorcientoComision,
                                                            ValorComision=n.ValorComision,
                                                            ComisionPendiente=n.ComisionPendiente,
                                                            _0_30=n.__0_30,
                                                            _31_60=n.__31_60,
                                                            _61_90=n.__61_90,
                                                            _91_120=n.__91_120,
                                                            _121_150=n.__121_150,
                                                            _151_Mas=n.__151_mas,
                                                            Total=n.Total,
                                                            Diferencia=n.Diferencia,
                                                            TotalPesos=n.TotalPesos,
                                                            Tasa=n.Tasa
                                                        }).ToList();
                        DateTime FechaCorte = Convert.ToDateTime(txtFechaCorteConsulta.Text);
                        string FechaCorteString = FechaCorte.ToShortDateString();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Antiguedad de Saldo Detalle cortado al " + FechaCorteString, ExportarReporteDetallado);

                    }
                }
                else {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            //VALIDAMOS SI EL CAMPO FECHA DE CORTE ESTA VACIO
            if (string.IsNullOrEmpty(txtFechaCorteConsulta.Text.Trim()) || string.IsNullOrEmpty(txtTasaDollar.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios()", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaCorteConsulta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "Campofechacortevacio()", "Campofechacortevacio();", true);
                }
                if (string.IsNullOrEmpty(txtTasaDollar.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoTasaVacio()", "CampoTasaVacio();", true);
                }
            }
            else
            {
               
                if (Session["Idusuario"] != null) {
                    //ELIMINAMOS LOS CAMPOS 
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                       (decimal)Session["Idusuario"], DateTime.Now, "", 0, 0, "", "", 0, "", "", 0, "", 0, "", "", 0, "", DateTime.Now, "", DateTime.Now, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "DELETE");
                    Eliminar.ProcesarInformacion();
                    ProcesarInformacion();

                    if (rbReporteResumido.Checked == true)
                    {
                        DateTime FechaCorte = Convert.ToDateTime(txtFechaCorteConsulta.Text);
                        string FechaCorteString = FechaCorte.ToShortDateString();
                        string Tasa = txtTasaDollar.Text;
                        string NombreReporte = "Antiguedad de Saldo Resumido Cortado al " + FechaCorteString + " a Tasa Dollar " + Tasa;
                        AntiguedadSaldoResumido((decimal)Session["IdUsuario"], Convert.ToDecimal(txtTasaDollar.Text), 0, Server.MapPath("AntiguedadSaldoResumido.rpt"), "sa", "Pa$$W0rd", NombreReporte);
                    }
                    else if (rbReporteDetallado.Checked == true) {
                        DateTime FechaCorte = Convert.ToDateTime(txtFechaCorteConsulta.Text);
                        string FechaCorteString = FechaCorte.ToShortDateString();
                        string Tasa = txtTasaDollar.Text;
                        string NombreReporte = "Antiguedad de Saldo Detalle Cortado al " + FechaCorteString + " a Tasa Dollar " + Tasa;
                        AntiguedadSaldoDetalle((decimal)Session["IdUsuario"],Convert.ToDecimal(txtTasaDollar.Text), Server.MapPath("AntiguedadSaldoDetalle.rpt"), "sa", "Pa$$W0rd", NombreReporte);
                    }
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }
    }
}
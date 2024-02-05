using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Gerencia
{
    public partial class AcuerdoPago : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaGerencia.LogicaGerencia> ObjData = new Lazy<Logica.Logica.LogicaGerencia.LogicaGerencia>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Informacion = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                System.Web.UI.WebControls.Label lbusuarioConectado = (System.Web.UI.WebControls.Label)Master.FindControl("lbUsuarioConectado");
                lbusuarioConectado.Text = Informacion.SacarNombreUsuarioConectado();

                System.Web.UI.WebControls.Label lbPantalla = (System.Web.UI.WebControls.Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "REPORTE DE ACUERDO DE PAGO";

                UtilidadesAmigos.Logica.Comunes.Rangofecha Rango = new Logica.Comunes.Rangofecha();
                Rango.FechaMes(ref txtFechaDesde, ref txtFechaHasta);

                rbPDF.Checked = true;
            }
        }

        protected void txtSupervisor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupervisor.Text.Trim())) {
                txtNombreSupervisor.Text = string.Empty;
            }
            else {

                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtSupervisor.Text);
                txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
            }
        }

        protected void txtIntermediario_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIntermediario.Text.Trim()))
            {
                txtNombreIntermediario.Text = string.Empty;
            }
            else
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtIntermediario.Text);
                txtNombreIntermediario.Text = Nombre.SacarNombreIntermediario();
            }
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            //VARIABLES
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIntermediario.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();


            if (rbExcelPlano.Checked == true) {

                var Validar = ObjData.Value.BuscaAcuerdoPago(
                    _FechaDesde,
                    _FechaHasta,
                    _Supervisor,
                    _Intermediario,
                    _Poliza,
                    null);
                if (Validar.Count() < 1) {
                    ClientScript.RegisterStartupScript(GetType(), "RegistrosNoEncontrados()", "RegistrosNoEncontrados();", true);
                }
                else {

                    var Exportar = (from n in ObjData.Value.BuscaAcuerdoPago(
                        _FechaDesde,
                    _FechaHasta,
                    _Supervisor,
                    _Intermediario,
                    _Poliza,
                    null)
                                    select new
                                    {
                                        Poliza = n.Poliza,
                                        Prima = n.ValorPoliza,
                                        Concepto = n.Concepto,
                                        Fecha_Facturacion = n.FechaFacturacion,
                                        TipoAcuerdo = n.TipoAcuerdo,
                                        Frecuencia = n.Frecuencia,
                                        Nombre_Supervisor = n.NombreSupervisor,
                                        Nombre_Intermediario = n.NombreIntermediario,
                                        FrecuenciaPagos = n.FrecuenciaPagos,
                                        Cantidad_Cuotas = n.CantidadCuotas,
                                        Inicial = n.Inicial,
                                        Cuota = n.Cuota,
                                        FechaC1 = n.FechaC1,
                                        DiasC1 = n.DiasC1,
                                        PagoC1 = n.PagoC1,
                                        EstatusC1 = n.EstatusC1,
                                        FechaC2 = n.FechaC2,
                                        DiasC2 = n.DiasC2,
                                        PagoC2 = n.PagoC2,
                                        EstatusC2 = n.EstatusC2,
                                        Fecha3 = n.Fecha3,
                                        DiasC3 = n.DiasC3,
                                        Pago3 = n.Pago3,
                                        EstatusC3 = n.EstatusC3,
                                        FechaC4 = n.FechaC4,
                                        DiasC4 = n.DiasC4,
                                        Pago4 = n.Pago4,
                                        EstatusC4 = n.EstatusC4,
                                        FechaC5 = n.FechaC5,
                                        DiasC5 = n.DiasC5,
                                        PagoC5 = n.PagoC5,
                                        EstatusC5 = n.EstatusC5,
                                        FechaC6 = n.FechaC6,
                                        DiasC6 = n.DiasC6,
                                        PagoC6 = n.PagoC6,
                                        EstatusC6 = n.EstatusC6,
                                        PagadoTotal = n.PagadoTotal,
                                        Pendiente = n.Pendiente
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Acuerdo de Pago", Exportar);
                }
                    
            }
            else {

                string UsuarioBD = "", ClaveBD = "", RutaReporte = "", NombreReporte = "";

                UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD BD = new Logica.Comunes.SacarCredencialesBD(1);
                UsuarioBD = BD.SacarUsuario();
                ClaveBD = BD.SacarClaveBD();
                RutaReporte = Server.MapPath("AcuerdoPago.rpt");
                NombreReporte = "Acuerdo de pago";

                ReportDocument Reporte = new ReportDocument();

                Reporte.Load(RutaReporte);
                Reporte.Refresh();

                Reporte.SetParameterValue("@FechaDesde", _FechaDesde);
                Reporte.SetParameterValue("@FechaHasta", _FechaHasta);
                Reporte.SetParameterValue("@Supervisor", _Supervisor);
                Reporte.SetParameterValue("@Intermediario", _Intermediario);
                Reporte.SetParameterValue("@Poliza", _Poliza);
                Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

                Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

                if (rbPDF.Checked == true) {
                    Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
                }
                else if (rbExcel.Checked == true) {
                    Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
                }
                Reporte.Dispose();
            }
        }

    }
}
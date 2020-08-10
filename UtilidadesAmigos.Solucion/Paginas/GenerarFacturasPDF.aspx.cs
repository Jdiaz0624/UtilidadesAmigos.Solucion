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
//using CrystalDecisions.Windows.Forms;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarFacturasPDF : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR EL LISTADO DE LOS COMPROBANTES
        private void MostrarListadoCOmprobantes() {
            string _poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
            string _Comprobante = string.IsNullOrEmpty(txtComprobanteConsulta.Text.Trim()) ? null : txtComprobanteConsulta.Text.Trim();

            var Listado = ObjData.Value.GenerarDatosFacturasPDF(
                new Nullable<decimal>(),
                _poliza,
                _Comprobante);
            gvListadoRegistros.DataSource = Listado;
            gvListadoRegistros.DataBind();
            if (Listado.Count() < 1)
            {
                lbCantidadRegistrosVariable.Text = "0";
            }
            else {
                foreach (var n in Listado) {
                    int Cantidad = Convert.ToInt32(n.CantidadRegistros);
                    lbCantidadRegistrosVariable.Text = Cantidad.ToString("N0");
                }
            }
        }
        #endregion

        #region IMPRIMIR FACTURA
        private void ImprimirFactura(decimal IdComprobante, string RutaReporte, string UsuaruoBD, string ClaveBD, string NombreArchivo) {
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_DATOS_FACTURAS_PDF] @IdComprobante";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdComprobante", SqlDbType.Decimal);
                comando.Parameters["@IdComprobante"].Value = IdComprobante;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdComprobante", IdComprobante);
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

            }
        }

        protected void btnGenerarRegistros_Click(object sender, EventArgs e)
        {
            
         



        }

        protected void gvListadoRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoRegistros.PageIndex = e.NewPageIndex;
            MostrarListadoCOmprobantes();
        }

        protected void gvListadoRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gv = gvListadoRegistros.SelectedRow;
            decimal IdComprobante = Convert.ToDecimal(gv.Cells[1].Text);
            string Poliza = gv.Cells[2].Text;
            string Comprobante = gv.Cells[3].Text;
            string NombreArchivo = IdComprobante.ToString() + " - " + Poliza + " - " + Comprobante + ".pdf";
            ImprimirFactura(IdComprobante, @"C:\Users\juan.diaz\Desktop\GenerarFacturaPDF.rpt", "sa", "Pa$$W0rd", NombreArchivo);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoCOmprobantes();
        }
    }
}
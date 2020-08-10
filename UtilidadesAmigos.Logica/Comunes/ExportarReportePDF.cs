using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data;
using System.IO;
using System.Web;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class ExportarReportePDF
    {
        private decimal IdComprobante = 0;
        private string RutaReporte = "";
        private string UsuaruoBD = "";
        private string ClaveBD = "";
        private string NombreArchivo = "";

        public HttpResponse Response { get; private set; }

        public ExportarReportePDF(
              decimal IdComprobanteCON
            , string RutaReporteCON
            , string UsuaruoBDCON
            , string ClaveBDCON
            , string NombreArchivoCON
            )
        {
            IdComprobante = IdComprobanteCON;
            RutaReporte = RutaReporteCON;
            UsuaruoBD = UsuaruoBDCON;
            ClaveBD = ClaveBDCON;
            NombreArchivo = NombreArchivoCON;
        }

        

       

        public void ExportarReporte() {
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
    }
}

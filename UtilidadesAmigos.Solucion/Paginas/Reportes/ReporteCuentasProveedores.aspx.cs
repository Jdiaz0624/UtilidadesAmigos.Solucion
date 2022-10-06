using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReporteCuentasProveedores : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                rbReporteResumido.Checked = true;
            }
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            //SACAMOS LOS PARAMETROS PARA GENERAR EL REPORTE
            int? _Ano = string.IsNullOrEmpty(txtAnoConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtAnoConsulta.Text.Trim());
            int? _Cuenta = string.IsNullOrEmpty(txtCuentaConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCuentaConsulta.Text.Trim());
            int? _Auxiliar = string.IsNullOrEmpty(txtAuxiliarConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtAuxiliarConsulta.Text.Trim());
            decimal? _Usuario = (decimal)Session["IdUsuario"];
            string RutaReporte = rbReporteResumido.Checked == true ? Server.MapPath("ReporteCuentas.rpt") : Server.MapPath("ReporteCuentasdetalle.rpt");
            string NombreReporte = rbReporteResumido.Checked == true ? "Reporte de Cuentas Resumido" : "Reporte de Cuentas Detallado";

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@Ano", _Ano);
            Reporte.SetParameterValue("@CUENTA", _Cuenta);
            Reporte.SetParameterValue("@AUXILIAR", _Auxiliar);
            Reporte.SetParameterValue("@GeneradoPor", _Usuario);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
        }
    }
}
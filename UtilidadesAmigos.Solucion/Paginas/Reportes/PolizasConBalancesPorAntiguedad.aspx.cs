using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class PolizasConBalancesPorAntiguedad : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjdataReporte = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        #region ENUMERACIONES DE LA PANTALLA
        enum TipoReporteGenerarEnumeracion { 
        
            AgrupadoPorRamo=1,
            AgrupadoPorSubRamo=2,
            AgrupadoPorOficina=3,
            AgrupadoPorSupervisor=4,
            AgrupadoPorIntermediario=5
        }
        #endregion

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarListasDesplegables() {

            ListaRamos();
            ListaSubRamos();
            ListaOficina();
            ListaDias();
        }
        private void ListaRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlRamo, ObjDataComun.Value.BuscaListas("RAMO", null, null), true);

          
        }
        private void ListaSubRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubRamo, ObjDataComun.Value.BuscaListas("SUBRAMO", ddlRamo.SelectedValue.ToString(), null), true);
        }
        private void ListaOficina() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjDataComun.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }
        private void ListaDias() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDias, ObjDataComun.Value.BuscaListas("DIASANTIGEUDAD", null, null));
        }
        #endregion

        #region PROCESAR LA INFORMACION PARA GENERAR EL REPORTE AGRUPADO
        private void CargarDataReporteAgrupado(decimal IdUsuario) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionConBalanceAgrupada Eliminear = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionConBalanceAgrupada(
                IdUsuario, 0, "", 0, 0, 0, "", "", "", "", "", 0,"", "DELETE");
            Eliminear.ProcesarInformacion();

            DateTime ? _FechaCorte = string.IsNullOrEmpty(txtFechaCorte.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaCorte.Text);
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamo.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIntermediario.Text);
            bool? _ExcluirMotores = cbExcluirMotores.Visible == false ? false : cbExcluirMotores.Checked;
            int? _Cantidadias = ddlDias.SelectedValue != "-1" ? Convert.ToInt32(ddlDias.SelectedValue) : new Nullable<int>();
            

            int CodigoEntidad = 0, TipoReporteGenerar = 0;
            string NombreEntidad = "";

            var SacarInformacion = ObjdataReporte.Value.BuscaPolizasConBalanceAntiguedadDetallado(
                _FechaCorte,
                _Ramo,
                _SubRamo,
                _Poliza,
                _oficina,
                _Supervisor,
                _Intermediario,
                _ExcluirMotores,
                _Cantidadias,
                IdUsuario);
            foreach (var n in SacarInformacion) {

                //VALIDAMOS EL TIPO DE ENUMERACION
                if (rbAgrupadoPorRamo.Checked == true) {

                    CodigoEntidad = (int)n.CodigoRamo;
                    NombreEntidad = n.NombreRamo;
                    TipoReporteGenerar = (int)TipoReporteGenerarEnumeracion.AgrupadoPorRamo;
                }
                else if (rbAgrupadoPorSubramo.Checked == true) {
                    CodigoEntidad = (int)n.CodigoSubramo;
                    NombreEntidad = n.NombreSubRamo;
                    TipoReporteGenerar = (int)TipoReporteGenerarEnumeracion.AgrupadoPorSubRamo;
                }
                else if (rbAgrupadoPorOficina.Checked == true) {
                    CodigoEntidad = (int)n.Oficina;
                    NombreEntidad = n.NombreOficina;
                    TipoReporteGenerar = (int)TipoReporteGenerarEnumeracion.AgrupadoPorOficina;
                }
                else if (rbAgrupadoPorSupervisor.Checked == true) {

                    CodigoEntidad = (int)n.CodigoSupervisor;
                    NombreEntidad = n.Supervisor;
                    TipoReporteGenerar = (int)TipoReporteGenerarEnumeracion.AgrupadoPorSupervisor;
                }
                else if (rbAgrupadoPorIntermediario.Checked == true) {
                    CodigoEntidad = (int)n.Vendedor;
                    NombreEntidad = n.Intermediario;
                    TipoReporteGenerar = (int)TipoReporteGenerarEnumeracion.AgrupadoPorSubRamo;
                }

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionConBalanceAgrupada Guardar = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionConBalanceAgrupada(
                    IdUsuario,
                    CodigoEntidad,
                    NombreEntidad,
                    (decimal)n.Facturado,
                    (decimal)n.Cobrado,
                    (decimal)n.Balance,
                    n.OficinaFiltro,
                    n.Motores,
                    n.CortadoA,
                    n.GeneradoPor,
                    n.TipoReporteGenerado,
                    TipoReporteGenerar,
                    n.Poliza,
                    "INSERT");
                Guardar.ProcesarInformacion();
            }
        }
        #endregion

        #region REPORTES
        private void ReporteAgrupado() {

            string  RutaReporte = "", NombreReporte = "";
            decimal IdUsuario = (decimal)Session["IdUsuario"];

            RutaReporte = Server.MapPath("ReportePolizasConBalanceAgrupado.rpt");
            NombreReporte = "Reporte Agrupado";

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdUsuario", IdUsuario);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
        }

        private void ReporteDetallado() {

            DateTime? _FechaCorte = string.IsNullOrEmpty(txtFechaCorte.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaCorte.Text);
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamo.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIntermediario.Text);
            bool? _ExcluirMotores = cbExcluirMotores.Visible == false ? false : cbExcluirMotores.Checked;
            int? _Cantidadias = ddlDias.SelectedValue != "-1" ? Convert.ToInt32(ddlDias.SelectedValue) : new Nullable<int>();
            decimal? _GeneradlPor = (decimal)Session["IdUsuario"];

            string RutaReporte = "", NombreReporte = "";

            RutaReporte = Server.MapPath("ReportePolizasConBalanceDetalle.rpt");
            NombreReporte = "Polizas Con Balance Detallado";

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@FechaCorte", _FechaCorte);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@SubRamo", _SubRamo);
            Reporte.SetParameterValue("@Poliza", _Poliza);
            Reporte.SetParameterValue("@Oficina", _oficina);
            Reporte.SetParameterValue("@CodSupervisor", _Supervisor);
            Reporte.SetParameterValue("@CodIntermediario", _Intermediario);
            Reporte.SetParameterValue("@ExcluirMotores", _ExcluirMotores);
            Reporte.SetParameterValue("@CantidadDias", _Cantidadias);
            Reporte.SetParameterValue("@GeneradoPor", _GeneradlPor);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "REPORTE DE POLIZAS CON BALANCE PENDIENTE";

                ReportesAgrupados.Visible = false;
                rbReporteDetallado.Checked = true;
                rbPDF.Checked = true;
                rbAgrupadoPorRamo.Checked = true;
  
                DateTime DiaActual = DateTime.Now;
     
                txtFechaCorte.Text = DiaActual.ToString("yyyy-MM-dd");

                CargarListasDesplegables();
            }
        }

        protected void rbReporteDetallado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReporteDetallado.Checked == true) {
                ReportesAgrupados.Visible = false;
            }
            else {
                ReportesAgrupados.Visible = false;
            }
        }

        protected void rbReporteAgrupado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReporteAgrupado.Checked == true) {
                ReportesAgrupados.Visible = true;
                rbAgrupadoPorRamo.Checked = true;
            }
            else {
                ReportesAgrupados.Visible = false;
            }
        }

        protected void ddlRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaSubRamos();

            int RamoSeleccionadp = 0;
            RamoSeleccionadp = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : 0;
            if (RamoSeleccionadp == 106)
            {
                cbExcluirMotores.Visible = true;
            }
            else
            {
                cbExcluirMotores.Visible = false;
            }
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            try {
                string CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? "0" : txtCodigoSupervisor.Text.Trim();
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreSupervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(CodigoSupervisor);
                txtSupervisor.Text = NombreSupervisor.SacarNombreSupervisor();
            }
            catch (Exception) {
                txtCodigoSupervisor.Text=string.Empty;
                txtSupervisor.Text = string.Empty;
            }
        }

        protected void txtIntermediario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string CodigoIntermediario = string.IsNullOrEmpty(txtIntermediario.Text.Trim()) ? "0" : txtIntermediario.Text.Trim();
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreIntermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(CodigoIntermediario);
                txtNombreIntermediario.Text = NombreIntermediario.SacarNombreIntermediario();
            }
            catch (Exception)
            {
                txtIntermediario.Text = string.Empty;
                txtNombreIntermediario.Text = string.Empty;
            }
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

            DateTime? _FechaCorte = string.IsNullOrEmpty(txtFechaCorte.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaCorte.Text);
            int? _Ramo = ddlRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamo.SelectedValue) : new Nullable<int>();
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIntermediario.Text);
            bool? _ExcluirMotores = cbExcluirMotores.Visible == false ? false : cbExcluirMotores.Checked;
            int? _Cantidadias = ddlDias.SelectedValue != "-1" ? Convert.ToInt32(ddlDias.SelectedValue) : new Nullable<int>();
            decimal? _GeneradlPor = (decimal)Session["IdUsuario"];

            if (rbReporteDetallado.Checked == true) {

                if (rbExcelPlano.Checked == true) {

                    var ExportarDetalle = (from n in ObjdataReporte.Value.BuscaPolizasConBalanceAntiguedadDetallado(
                        _FechaCorte,
                        _Ramo,
                        _SubRamo,
                        _Poliza,
                        _oficina,
                        _Supervisor,
                        _Intermediario,
                        _ExcluirMotores,
                        _Cantidadias,
                        _GeneradlPor)
                                           select new
                                           {
                                               Poliza = n.Poliza,
                                               Motores = n.Motores,
                                               NombreOficina = n.NombreOficina,
                                               Supervisor = n.Supervisor,
                                               Asegurado = n.Asegurado,
                                               Intermediario = n.Intermediario,
                                               CodigoRamo = n.CodigoRamo,
                                               Ramo = n.NombreRamo,
                                               CodigoSubramo = n.CodigoSubramo,
                                               SubRamo = n.NombreSubRamo,
                                               InicioVigencia = n.InicioVigencia,
                                               ValorAnual = n.ValorAnual,
                                               ValorPorDia = n.ValorPorDia,
                                               ValorPagado = n.ValorPagado,
                                               CoberturaHasta = n.CoberturaHasta,
                                               DiasDiferencia = n.DiasDiferencia,
                                               Estatus = n.Estatus,
                                               Factura = n.Factura,
                                               Facturado = n.Facturado,
                                               Cobrado = n.Cobrado,
                                               Balance = n.Balance,
                                               CantidadDias = n.CantidadDias,
                                               CortadoA = n.CortadoA
                                           }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Polizas Con Balance Detallado", ExportarDetalle);
                }
                else {
                    ReporteDetallado();
                }
            
            }
            else if (rbReporteAgrupado.Checked == true) {
                if (rbExcelPlano.Checked == true) {
                    decimal IdUsuario = (decimal)Session["IdUsuario"];
                    CargarDataReporteAgrupado(IdUsuario);
                    var ExportarInformacionAgrupada = (from n in ObjdataReporte.Value.MostrarPolizasConBalanceAgrupado(IdUsuario)
                                                       select new
                                                       {
                                                           Codigo = n.CodigoAgrupacion,
                                                           Nombre = n.NombreAgrupacion,
                                                           Motores = n.Motores,
                                                           CortadoA = n.CortadoA,
                                                           GeneradoPor = n.GeneradoPor,
                                                           TipoReporteGenerado = n.TipoReporteGenerado,
                                                           Facturado = n.Facturado,
                                                           Cobrado = n.Cobrado,
                                                           Balance = n.Balance
                                                       }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Polizas Con Balance Agrupado", ExportarInformacionAgrupada);



                }
                else {
                    decimal IdUsuario = (decimal)Session["IdUsuario"];
                    CargarDataReporteAgrupado(IdUsuario);
                    ReporteAgrupado();
                }
            }
        }
    }
}
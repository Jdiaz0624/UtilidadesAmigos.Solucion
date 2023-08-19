using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Transito
{
    public partial class ReporteProduccionPolizasTransito : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaTransito.LogicaTransito> ObjDataTransito = new Lazy<Logica.Logica.LogicaTransito.LogicaTransito>();

        #region VALIDAR CHECK
        private void ValidarCheck() {

            if (rbDetallado.Checked == true) {

                DIvBloqueTipoDetallado.Visible = true;
                DIVBloqueAgrupado.Visible = false;
                rbDetalladoSinVehiculos.Checked = true;
            }
            else if (rbAgrupado.Checked == true) {
                DIvBloqueTipoDetallado.Visible = false;
                DIVBloqueAgrupado.Visible = true;
                rbAgrupadoPorSupervisor.Checked = true;
            }
            else if (rbPorDia.Checked == true) {
                DIvBloqueTipoDetallado.Visible = false;
                DIVBloqueAgrupado.Visible = false;
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "FuncioNovalida()", "FuncioNovalida();", true);
            }
        }

        private void ColorCheck() {
            if (rbDetallado.Checked == true)
            {
                rbDetallado.ForeColor = System.Drawing.Color.Green;
                rbAgrupado.ForeColor = System.Drawing.Color.Black;
                rbPorDia.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupado.Checked == true)
            {
                rbDetallado.ForeColor = System.Drawing.Color.Black;
                rbAgrupado.ForeColor = System.Drawing.Color.Green;
                rbPorDia.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbPorDia.Checked == true)
            {
                rbDetallado.ForeColor = System.Drawing.Color.Black;
                rbAgrupado.ForeColor = System.Drawing.Color.Black;
                rbPorDia.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "FuncioNovalida()", "FuncioNovalida();", true);
            }


          


            



        }
        private void ColoresDetalle() {
            if (rbDetalladoSinVehiculos.Checked == true)
            {
                rbDetalladoSinVehiculos.ForeColor = System.Drawing.Color.Green;
                rbDetalladoConVehiculos.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbDetalladoConVehiculos.Checked == true)
            {
                rbDetalladoSinVehiculos.ForeColor = System.Drawing.Color.Black;
                rbDetalladoConVehiculos.ForeColor = System.Drawing.Color.Green;
            }
        }
        private void ColoresAgrupados() {
            if (rbAgrupadoPorSupervisor.Checked == true)
            {

                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorIntermediario.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorRamo.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorSubRamo.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorOficina.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Green;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbAgrupadoPorUsuario.Checked == true)
            {
                rbAgrupadoPorSupervisor.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorIntermediario.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorSubRamo.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorOficina.ForeColor = System.Drawing.Color.Black;
                rbAgrupadoPorUsuario.ForeColor = System.Drawing.Color.Green;
            }
        }
        private void ColorFormato() {
            if (rbPDF.Checked == true) { 
              rbPDF.ForeColor = System.Drawing.Color.Green;
               rbExcel.ForeColor = System.Drawing.Color.Black;
                RbExcelPlano.ForeColor = System.Drawing.Color.Black;
            }
            else if (rbExcel.Checked == true) {
                rbPDF.ForeColor = System.Drawing.Color.Black;
                rbExcel.ForeColor = System.Drawing.Color.Green;
                RbExcelPlano.ForeColor = System.Drawing.Color.Black;
            }
            else if (RbExcelPlano.Checked == true) {
                rbPDF.ForeColor = System.Drawing.Color.Black;
                rbExcel.ForeColor = System.Drawing.Color.Black;
                RbExcelPlano.ForeColor = System.Drawing.Color.Green;
            }
        }
        #endregion

        #region SACAR RANGO DE FECHA
        private void SacarRangoFecha() {

            UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
            Fecha.FechaMes(ref txtFechaDesde, ref txtFechaHasta);
        }
        #endregion

        #region SACAR LOS DATOS DE LOS SUPERVISORES, INTERMDIARIOS Y CLIENTES
        private void SacarNombreSupervisor() {

            try {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtSUpervisor.Text);
                txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
            }
            catch (Exception) {
                txtNombreSupervisor.Text = "SUPERVISOR NO VALIDO";
            }
        }
        private void SacarNombreIntermediario() {
            try
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtIntermediario.Text);
                txtNombreIntermediario.Text = Nombre.SacarNombreIntermediario();
            }
            catch (Exception)
            {
                txtNombreIntermediario.Text = "INTERMEDIARIO NO VALIDO";
            }
        }
        private void SacarNombreCliente() {
            try
            {
                UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente Nombre = new Logica.Comunes.ESacarNombreCliente(txtCliente.Text);
                txtNombreCliente.Text = Nombre.SacarCodigoCLiente();
            }
            catch (Exception)
            {
                txtNombreCliente.Text = "CLIENTE NO VALIDO";
            }
        }
        #endregion

        #region CARGAR LISTAS DESPLEGABLES
        private void CargarListaDesplegable()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficina, ObjDataGeneral.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void CargarUsuarios()
        {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjDataGeneral.Value.BuscaListas("USUARIOSMARBETE", ddlOficina.SelectedValue.ToString(), null), true);
        }
        #endregion

        #region REPORTE DETALLADO
        private void Reportedetallado() {

            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtItem.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtItem.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSUpervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSUpervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIntermediario.Text);
            decimal? _Cliente = string.IsNullOrEmpty(txtCliente.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCliente.Text);
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;


            if (RbExcelPlano.Checked == true) {

                var Exportar = (from n in ObjDataTransito.Value.ReportePolizasTransito(
                    _Poliza,
                    _Item,
                    _FechaDesde,
                    _FechaHasta,
                    _Supervisor,
                    _Intermediario,
                    _Cliente,
                    _Oficina,
                    null,
                    _Usuario)
                                select new 
                                {
                                    Poliza = n.Poliza,
                                    ValorAnual = n.ValorAnual,
                                    Fecha = n.Fecha,
                                    Hora = n.Hora,
                                    CreadaPor = n.UsuarioAdiciona,
                                    Oficina = n.NombreOficina,
                                    Concepto = n.ConceptoMov,
                                    Cliente = n.Cliente,
                                    Codigo_Intermediario = n.CodigoIntermediario,
                                    Intermediario = n.Intermediario,
                                    Codigo_Supervisor = n.CodigoSupervisor,
                                    Supervisor = n.Supervisor,
                                    Tipo_Vehiculo = n.TipoVehiculo,
                                    Marca = n.Marca,
                                    Modelo = n.Modelo,
                                    Chasis = n.Chasis,
                                    Placa = n.Placa,
                                    Item = n.NumeroItem,
                                    Color = n.Color,
                                    Uso = n.Uso,
                                    Ano = n.Ano,
                                    Asegurado = n.Asegurado,
                                    Fianza_Judicial = n.FianzaJudicial,
                                    Valor_Vehiculo = n.ValorVehiculo,
                                    Inicio_Vigencia = n.InicioVigencia,
                                    Fin_Vigencia = n.FinVigencia,
                                    Grua = n.Grua,
                                    Servicios = n.Servicios,
                                    Ramo = n.Ramo,
                                    SubRamo = n.SubRamo
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Detalle de Reporte Transito", Exportar);
            
            }
            else
            {
                string UsuarioBD = "", ClaveBD = "", RutaReporte = "", NombreReporte = "";

                //SACAMOS LAS CREDENCIALES DE BASE DE DATOS
                UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credneciales = new Logica.Comunes.SacarCredencialesBD(1);
                UsuarioBD = Credneciales.SacarUsuario();
                ClaveBD = Credneciales.SacarClaveBD();

                if (rbDetalladoSinVehiculos.Checked == true)
                {

                    RutaReporte = Server.MapPath("ReportePolizasTransito.rpt");
                    NombreReporte = "Detalle Sin Vehiculo";
                }
                else if (rbDetalladoConVehiculos.Checked == true)
                {
                    RutaReporte = Server.MapPath("ReportePolizasTransitoConVehiculos.rpt");
                    NombreReporte = "Detalle Con Vehiculo";
                }

                ReportDocument Reporte = new ReportDocument();

                Reporte.Load(RutaReporte);
                Reporte.Refresh();

                Reporte.SetParameterValue("@Poliza", _Poliza);
                Reporte.SetParameterValue("@Item", _Item);
                Reporte.SetParameterValue("@FechaProcesoDesde", _FechaDesde.ToString("yyyy-MM-dd"));
                Reporte.SetParameterValue("@FechaProcesoHasta", _FechaHasta.ToString("yyyy-MM-dd"));
                Reporte.SetParameterValue("@Supervisor", _Supervisor);
                Reporte.SetParameterValue("@Intermediario", _Intermediario);
                Reporte.SetParameterValue("@Cliente", _Cliente);
                Reporte.SetParameterValue("@Oficina", _Oficina);
                Reporte.SetParameterValue("@PolizaImpresa", null);
                Reporte.SetParameterValue("@Usuario", _Usuario);
                Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

                Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

                if (rbPDF.Checked == true)
                {
                    Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
                }
                else if (rbExcel.Checked == true)
                {
                    Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
                }
                Reporte.Close();
            }

        }
        #endregion

        #region REPORTE DE POLIZAS AGRUPADO
        private void ReportePolizasAgrupado() {

            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtItem.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtItem.Text);
            DateTime _FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime _FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtSUpervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtSUpervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIntermediario.Text);
            decimal? _Cliente = string.IsNullOrEmpty(txtCliente.Text.Trim()) ? new Nullable<decimal>() : Convert.ToInt32(txtCliente.Text);
            int? _Oficina = ddlOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlOficina.SelectedValue) : new Nullable<int>();
            string _Usuario = ddlSeleccionarUsuario.SelectedValue !="-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
            decimal? _Generadopor = (decimal)Session["IdUsuario"];
            int TipoAgrupacion = 0;

            if (rbAgrupado.Checked == true && rbAgrupadoPorSupervisor.Checked == true) {

                TipoAgrupacion = (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.TipoAgrupacionReportePolizaTransito.Supervisor;
            }
            else if (rbAgrupado.Checked == true && rbAgrupadoPorIntermediario.Checked == true) {
                TipoAgrupacion = (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.TipoAgrupacionReportePolizaTransito.Intermediario;
            }
            else if (rbAgrupado.Checked == true && rbAgrupadoPorRamo.Checked == true) {
                TipoAgrupacion = (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.TipoAgrupacionReportePolizaTransito.Ramo;
            }
            else if (rbAgrupado.Checked == true && rbAgrupadoPorSubRamo.Checked == true) {
                TipoAgrupacion = (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.TipoAgrupacionReportePolizaTransito.Sub_Ramo;
            }
            else if (rbAgrupado.Checked == true && rbAgrupadoPorOficina.Checked == true) {
                TipoAgrupacion = (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.TipoAgrupacionReportePolizaTransito.Oficina;
            }
            else if (rbAgrupado.Checked == true && rbAgrupadoPorUsuario.Checked == true) {
                TipoAgrupacion = (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.TipoAgrupacionReportePolizaTransito.Usuario;
            }


            if (RbExcelPlano.Checked == true) {

                var Exportar = (from n in ObjDataTransito.Value.ReportePolizasTransitoAgrupado(
                    _Poliza,
                   _Item,
                   _FechaDesde,
                   _FechaHasta,
                   _Supervisor,
                   _Intermediario,
                   _Cliente,
                   _Oficina,
                   _Usuario,
                   (int)_Generadopor,
                   TipoAgrupacion)
                                select new
                                {
                                    Entidad = n.Entidad,
                                    Cantidad =n.Cantidad
                                }).ToList();
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Polizas en Transito Agrupada", Exportar);
            }
            else { }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "REPORTE DE POLIZAS EN TRANSITO";

                rbDetallado.Checked = true;
                rbDetalladoSinVehiculos.Checked = true;
                rbDetalladoSinVehiculos.ForeColor = System.Drawing.Color.Green;
                rbPDF.Checked = true;
                rbPDF.ForeColor = System.Drawing.Color.Green;
                ValidarCheck();
                ColorCheck();

                SacarRangoFecha();
                CargarListaDesplegable();
                CargarUsuarios();
            }
        }

        protected void txtSUpervisor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSUpervisor.Text.Trim())) {
                txtNombreSupervisor.Text = string.Empty;
            }
            else {
                SacarNombreSupervisor();
            }
        }

        protected void txtIntermediario_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIntermediario.Text.Trim())) { 
            txtNombreIntermediario.Text=string.Empty;
            }
            else {
                SacarNombreIntermediario();
            }
        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text.Trim())) {
                txtNombreCliente.Text = string.Empty;
            }
            else {
                SacarNombreCliente();
            }
        }

        protected void ddlOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            if (rbDetallado.Checked == true)
            {

                Reportedetallado();
            }
            else if (rbAgrupado.Checked == true) {
                ReportePolizasAgrupado();
            }
        }
        protected void ValidarCheck(object sender, EventArgs e) {
            ValidarCheck();
            ColorCheck();
            ColoresDetalle();
            ColoresAgrupados();
            rbDetalladoSinVehiculos.ForeColor = System.Drawing.Color.Green;
        }
        protected void ColoresDetalle(object sender, EventArgs e) {
            ColoresDetalle();
        }
        protected void ColoresAgrupados(object sender, EventArgs e) {
            ColoresAgrupados();
        }
        protected void ColoresFormato(object sender, EventArgs e) {

            ColorFormato();
        }
    }
}
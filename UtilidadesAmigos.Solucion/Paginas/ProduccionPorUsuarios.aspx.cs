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
using System.Drawing;
using System.Speech.Synthesis;
using System.Threading;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionPorUsuarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();


        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarSucursales() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSUcursalConsulta, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjData.Value.BuscaListas("OFICINA", ddlSeleccionarSUcursalConsulta.SelectedValue, null), true);
        }
        private void CargarDepartamentos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarDepartamento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSUcursalConsulta.SelectedValue, ddlSeleccionarOficina.SelectedValue), true);
        }
        private void CargarUsuarios() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjData.Value.BuscaListas("EMPLEADO", ddlSeleccionarOficina.SelectedValue, ddlSeleccionarDepartamento.SelectedValue), true);
        }
        #endregion
        #region IMPRIMIR FACTURA
        private void ImprimirFactura(decimal IdUsuario, string RutaReporte, string UsuaruoBD, string ClaveBD, string NombreArchivo)
        {
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_PRODUCCION_USUARIO_RESUMIDO] @IdUsuario";
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

        private void BuscarProduccion() {
            try
            {
                decimal? _Sucursal = ddlSeleccionarSUcursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSUcursalConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue) : new Nullable<decimal>();
                decimal? _Departamento = ddlSeleccionarDepartamento.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue) : new Nullable<decimal>();
                decimal? _Empleado = ddlSeleccionarUsuario.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue) : new Nullable<decimal>();
                int TipoMovimiento = 0;
                if (rbBuscarProduccion.Checked) {
                    TipoMovimiento = 1;
                }
                else if (rbBuscarPagos.Checked) {
                    TipoMovimiento = 2;
                }
                var Buscar = ObjData.Value.BuscaProduccionPorUsuarios(
                         Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                         Convert.ToDateTime(txtFechaHasta.Text),
                         _Sucursal,
                         _Oficina,
                         _Departamento,
                         _Empleado,
                         TipoMovimiento);
                gvListadoProduccion.DataSource = Buscar;
                gvListadoProduccion.DataBind();
                if (Buscar.Count() < 1)
                {
                    lbTotalMontoVariable.Text = "0";
                    lbTotalRegistrosVariable.Text = "0";
                }
                else
                {
                    decimal Cantidadregistros = 0, TotalPrima = 0;
                    foreach (var n in Buscar)
                    {
                        Cantidadregistros = Convert.ToDecimal(n.TotalRegistros);
                        TotalPrima = Convert.ToDecimal(n.TotalValor);
                        lbTotalMontoVariable.Text = TotalPrima.ToString("N2");
                        lbTotalRegistrosVariable.Text = Cantidadregistros.ToString("N0");
                    }
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                rbBuscarProduccion.Checked = true;
                CargarSucursales();
                CargarOficinas();
                CargarDepartamentos();
                CargarUsuarios();
            }
        }

        protected void rbBuscarProduccion_CheckedChanged(object sender, EventArgs e)
        {
            lbTotalMovimientosLetrero.Visible = true;
            lbTotalRegistrosVariable.Visible = true;
            lbTotalRegistrosCerrar.Visible = true;
            Label1.Visible = true;
        }

        protected void rbBuscarPagos_CheckedChanged(object sender, EventArgs e)
        {
            lbTotalMovimientosLetrero.Visible = false;
            lbTotalRegistrosVariable.Visible = false;
            lbTotalRegistrosCerrar.Visible = false;
            Label1.Visible = false;
        }


        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            BuscarProduccion();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try {
                decimal? _Sucursal = ddlSeleccionarSUcursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSUcursalConsulta.SelectedValue) : new Nullable<decimal>();
                decimal? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue) : new Nullable<decimal>();
                decimal? _Departamento = ddlSeleccionarDepartamento.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue) : new Nullable<decimal>();
                decimal? _Empleado = ddlSeleccionarUsuario.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue) : new Nullable<decimal>();
                int TipoMovimiento = 0;
                if (rbBuscarProduccion.Checked)
                {
                    TipoMovimiento = 1;
                }
                else if (rbBuscarPagos.Checked)
                {
                    TipoMovimiento = 2;
                }

                var Exportar = (from n in ObjData.Value.BuscaProduccionPorUsuarios(
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Sucursal,
                    _Oficina,
                    _Departamento,
                    _Empleado,
                    TipoMovimiento)
                                select new
                                {
                                    Sucursal = n.Sucursal,
                                    Oficina = n.Oficina,
                                    Departamento = n.Departamento,
                                    Usuario = n.Usuario,
                                    Concepto = n.Concepto,
                                    Cantidad = n.Cantidad,
                                    Total = n.Total

                                }).ToList();
                string Nombre = "";
                if (rbBuscarProduccion.Checked)
                {
                    Nombre = "Listado de Produccion desde " + txtFechaDesdeConsulta.Text + " Hasta " + txtFechaHasta.Text;
                }
                else if (rbBuscarPagos.Checked)
                {
                    Nombre = "Listado de Pagos desde " + txtFechaDesdeConsulta.Text + " Hasta " + txtFechaHasta.Text;
                }
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(Nombre, Exportar);
            }
            catch (Exception) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            //ELIMINAMOS INFORMAICON
            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarProduccionPorUsuarioResumido Eliminar = new Logica.Comunes.Reportes.ProcesarProduccionPorUsuarioResumido(
                Convert.ToDecimal(Session["IdUsuario"]), "", "", "", "", "", 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
            Eliminar.ProcesarInformacion();

            //BUSCAMOS LOS DATOS A PROCESAR
            decimal? _Sucursal = ddlSeleccionarSUcursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSUcursalConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlSeleccionarDepartamento.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue) : new Nullable<decimal>();
            decimal? _Empleado = ddlSeleccionarUsuario.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue) : new Nullable<decimal>();
            int TipoMovimiento = 0;
            if (rbBuscarProduccion.Checked)
            {
                TipoMovimiento = 1;
            }
            else if (rbBuscarPagos.Checked)
            {
                TipoMovimiento = 2;
            }

            var BuscarRegistros = ObjData.Value.BuscaProduccionPorUsuarios(
                Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                Convert.ToDateTime(txtFechaHasta.Text),
                _Sucursal,
                _Oficina,
                _Departamento,
                _Empleado,
                TipoMovimiento);
            foreach (var n in BuscarRegistros) {
                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarProduccionPorUsuarioResumido Guardar = new Logica.Comunes.Reportes.ProcesarProduccionPorUsuarioResumido(
                    Convert.ToDecimal(Session["IdUsuario"]),
                    n.Sucursal,
                    n.Oficina,
                    n.Departamento,
                    n.Usuario,
                    n.Concepto,
                    Convert.ToDecimal(n.Cantidad),
                    Convert.ToDecimal(n.Total),
                    TipoMovimiento,
                    Convert.ToDecimal(n.TotalRegistros),
                    Convert.ToDecimal(n.TotalValor),
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    "INSERT");
                Guardar.ProcesarInformacion();
            }
            string NombreArchivo = "";

            if (rbBuscarProduccion.Checked) {
                NombreArchivo = "Reporte de Produccion";
            }
            else if (rbBuscarPagos.Checked) {
                NombreArchivo = "Reporte de Pagos";
            }
            ImprimirFactura(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ProduccionUsuarioResumido.rpt"), "sa", "Pa$$W0rd", NombreArchivo);
        }

        protected void gvListadoProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoProduccion.PageIndex = e.NewPageIndex;
            BuscarProduccion();
        }

        protected void gvListadoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarSUcursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinas();
            CargarDepartamentos();
            CargarUsuarios();
        }

        protected void ddlSeleccionarOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentos();
            CargarUsuarios();
        }

        protected void ddlSeleccionarDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
    }
}
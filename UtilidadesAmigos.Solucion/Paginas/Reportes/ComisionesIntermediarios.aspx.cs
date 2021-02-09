﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ComisionesIntermediarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataConexion = new Lazy<Logica.Logica.LogicaSistema>();

        #region BUSCAR COMISIONES DE INTERMEDIARIOS
        private void GenerarComisionesIntermediarios()
        {
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();

            var BuscarRegistros = ObjDataConexion.Value.GenerarComisionIntermediario(
                Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                Convert.ToDateTime(txtFechaHastaComisiones.Text),
                _CodigoIntermediario,
                _Oficina,
                Convert.ToDecimal(txtTasaDollar.Text));
            Paginar(ref rpListadoComision, BuscarRegistros, 10, ref lbCantidadPaginaVariable, ref LinkPrimeraPagina, ref LinkAnterior, ref LinkSiguiente, ref LinkUltimo);
            HandlePaging(ref dtPaginacion, ref lbPaginaActualVariavle);
        }
        #endregion
        #region EXPORTAR LA CONSULTA A EXCEL
        private void ExportarConsultaExcel() {
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();

            var ExportarInformacion = (from n in ObjDataConexion.Value.GenerarComisionIntermediario(
                Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                Convert.ToDateTime(txtFechaHastaComisiones.Text),
                _CodigoIntermediario,
                _Oficina,
                Convert.ToDecimal(txtTasaDollar.Text))
                                       select new
                                       {
                                           Supervisor = n.Supervisor,
                                           Codigo = n.Codigo,
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
                                           ALiquidar = n.ALiquidar,
                                           //CantidadRegistros = n.CantidadRegistros
                                       }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Comisiones de intermediarios", ExportarInformacion);
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
                

            }
        }
        #endregion
        #region CONTROL PARA MOSTRAR LA PAGINACION
        readonly PagedDataSource pagedDataSource = new PagedDataSource();
        int _PrimeraPagina, _UltimaPagina;
        private int _TamanioPagina = 10;
        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }

        }
        private void HandlePaging(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina = CurrentPage - 5;
            if (CurrentPage > 5)
                _UltimaPagina = CurrentPage + 5;
            else
                _UltimaPagina = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina = _UltimaPagina - 10;
            }

            if (_PrimeraPagina < 0)
                _PrimeraPagina = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina; i < _UltimaPagina; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina : _NumeroRegistros);
            pagedDataSource.CurrentPageIndex = CurrentPage;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            RptGrid.DataSource = pagedDataSource;
            RptGrid.DataBind();


            divPaginacion.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
        {

            int PaginaActual = 0;
            switch (Accion)
            {

                case 1:
                    //PRIMERA PAGINA
                    lbPaginaActual.Text = "1";

                    break;

                case 2:
                    //SEGUNDA PAGINA
                    PaginaActual = Convert.ToInt32(lbPaginaActual.Text);
                    PaginaActual++;
                    lbPaginaActual.Text = PaginaActual.ToString();
                    break;

                case 3:
                    //PAGINA ANTERIOR
                    PaginaActual = Convert.ToInt32(lbPaginaActual.Text);
                    if (PaginaActual > 1)
                    {
                        PaginaActual--;
                        lbPaginaActual.Text = PaginaActual.ToString();
                    }
                    break;

                case 4:
                    //ULTIMA PAGINA
                    lbPaginaActual.Text = lbCantidadPaginas.Text;
                    break;


            }

        }
        #endregion
        private void GenerarReporteComisiones(decimal UsuarioGenera, string RutaReporte, string Nombrearchivo) {

            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();
            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            if (rbGenerarReporteDetalle.Checked == true) {
                Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesdeComisiones.Text));
                Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHastaComisiones.Text));
                Reporte.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
                Reporte.SetParameterValue("@Oficina", _Oficina);
                Reporte.SetParameterValue("@Tasa", Convert.ToDecimal(txtTasaDollar.Text));
                Reporte.SetParameterValue("@Usuario", UsuarioGenera);
            }
            else {
                Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesdeComisiones.Text));
                Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHastaComisiones.Text));
                Reporte.SetParameterValue("@Usuario", UsuarioGenera);
            }

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, Nombrearchivo);
            }
            else if (rbExcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, Nombrearchivo);
            }
            else if (rbWord.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, Nombrearchivo);
            }

           

        }

        private void ProcesoComisionesIntermediario() {
            decimal _Usuario = Session["IdUsuario"] != null ? (decimal)Session["Idusuario"] : 0;

            //ELIMINAMOS AL INFORMACION REGISTRADA BAJO EL USUARIO
            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                _Usuario, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
            Eliminar.ProcesarInformacion();

            //BUSCAMOS LA INFORMACION QUE SE VA A MANDAR A LA TABLA PARA SELECCIONAR LOS REPORTES

            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            int? _Oficina = ddlSeleccionaroficinaComisiones.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaComisiones.SelectedValue) : new Nullable<int>();

            var BuscarRegistros = ObjDataConexion.Value.GenerarComisionIntermediario(
                Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                Convert.ToDateTime(txtFechaHastaComisiones.Text),
                _CodigoIntermediario,
                _Oficina,
                Convert.ToDecimal(txtTasaDollar.Text));

            foreach (var n in BuscarRegistros) {
                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Guardar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                    _Usuario,
                    n.Supervisor,
                    (int)n.Codigo,
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
                    (decimal)n.Bruto,
                    (decimal)n.Neto,
                    (decimal)n.PorcientoComision,
                    (decimal)n.Comision,
                    (decimal)n.Retencion,
                    (decimal)n.AvanceComision,
                    (decimal)n.ALiquidar,
                    (decimal)n.CantidadRegistros,
                    Convert.ToDateTime(txtFechaDesdeComisiones.Text),
                    Convert.ToDateTime(txtFechaHastaComisiones.Text),
                    "INSERT");
                Guardar.ProcesarInformacion();
            }

            //if (rbGenerarReporteDetalle.Checked == true) {
            //    GenerarReporteComisiones(_Usuario, Server.MapPath("ReporteComisionesIntermediario.rpt"), "Comisiones Detalle");
            //}
            //else if (rbGenerarReporteResumido.Checked == true) {
            //    GenerarReporteComisiones(_Usuario, Server.MapPath("ReporteComisionIntermediarioResumido.rpt"), "Comisiones Resumido");
            //}
            //else if (rbGenerarReporteInterno.Checked == true) {
            //    GenerarReporteComisiones(_Usuario, Server.MapPath("ReporteComisionIntermediarioInterno.rpt"), "Comisiones Interno");
            //}

        }


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
                rbPDF.Checked = true;
            }
        }

        protected void btnConsultarComisiones_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio()", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                }
            }
            else {
                GenerarComisionesIntermediarios();
            }
            
        }

        protected void btnExortarComisiones_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio()", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                }
            }
            else
            {
                ExportarConsultaExcel();
            }

        }

        protected void btnReporteCOmisiones_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesdeComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeComisionesVacio()", "FechaDesdeComisionesVacio()", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaComisiones.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);
                }
            }
            else
            {
                decimal UsuarioGenera = Session["IdUsuario"] != null ? (decimal)Session["IdUsuario"] : 0;
                string RutaReporte = "";
                string NombreReporte = "";

                if (rbGenerarReporteDetalle.Checked == true) {
                   RutaReporte = "ReporteComisionesIntermediarioDetalleDefinitivo.rpt";
                   NombreReporte = "Comisiones Intermediario Detalle";
                }
                else if (rbGenerarReporteResumido.Checked == true) {
                    RutaReporte = "ReporteComisionesResumidoFinal.rpt";
                    NombreReporte = "Comisiones Intermediario Resumido";
                    ProcesoComisionesIntermediario();
                }
                else if (rbGenerarReporteInterno.Checked == true) {
                    RutaReporte = "ReporteComisionIntermediarioInterno.rpt";
                    NombreReporte = "Comisiones Intermediario Interno";
                    ProcesoComisionesIntermediario();
                }
                GenerarReporteComisiones(UsuarioGenera, Server.MapPath(RutaReporte), NombreReporte);
            }
        }


        protected void ddlSeleccionarSucursalComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinasComisiones();
        }

        protected void txtCodigoIntermediarioComisiones_TextChanged(object sender, EventArgs e)
        {
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioComisiones.Text.Trim()) ? null : txtCodigoIntermediarioComisiones.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreVendedor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoIntermediario);
            txtNombreVendedorComsiiones.Text = NombreVendedor.SacarNombreIntermediario();
        }

        protected void LinkPrimeraPagina_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            GenerarComisionesIntermediarios();

        }

        protected void LinkAnterior_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            GenerarComisionesIntermediarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            GenerarComisionesIntermediarios();
        }

        protected void LinkSiguiente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            GenerarComisionesIntermediarios();
        }

        protected void LinkUltimo_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            GenerarComisionesIntermediarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavle, ref lbCantidadPaginaVariable);
        }
    }
}
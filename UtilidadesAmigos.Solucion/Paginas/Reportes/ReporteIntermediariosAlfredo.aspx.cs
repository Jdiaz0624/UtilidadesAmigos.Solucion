﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Reportes
{
    public partial class ReporteIntermediariosAlfredo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

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
        private void HandlePaging(ref DataList NombreDataList, ref Label PaginaActual)
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
            PaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label CantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            CantidadPagina.Text = pagedDataSource.PageCount.ToString();

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


            //divPaginacionCliente.Visible = true;
            //DivPaginacionIntermediario.Visible = true;
            //OcultarDetalle();
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPagina)
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
                    lbPaginaActual.Text = lbCantidadPagina.Text;
                    break;


            }

        }


        #endregion
        #region PROCESAR LA INFORMACION
        private void ProcesarInformacion() {
            //ELIMINAMOS TODOS LOS REGISTROS MEDIANTE EL USUARIO
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionComisionesIntermediariosAlfredo Eliminar = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionComisionesIntermediariosAlfredo(
                "", 0, 0, "", 0, "", "", "", "", "", 0, "", 0, "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", (decimal)Session["IdUsuario"], "DELETE");
            Eliminar.ProcesarInformacion();

            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioReporte.Text.Trim()) ? null : txtCodigoIntermediarioReporte.Text.Trim();
            var BuscarInformacion = ObjDataReportes.Value.SacarDatosComisionesIntermediarioAlfredo(
                Convert.ToDateTime(txtFechaDesdeReporte.Text),
                Convert.ToDateTime(txtFechaHastaReporte.Text),
                _CodigoIntermediario,
                null, null, 0, null, null, null, null, (decimal)Session["IdUsuario"]);
            if (BuscarInformacion.Count() < 1) { }
            else {
                foreach (var n in BuscarInformacion) {
                    //GUARDAMOS LA INFORMACION
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionComisionesIntermediariosAlfredo Guardar = new Logica.Comunes.ProcesarMantenimientos.Reporte.ProcesarInformacionComisionesIntermediariosAlfredo(
                        n.Supervisor,
                        (int)n.CodigoSupervisor,
                        (int)n.Codigo,
                        n.Intermediario,
                        (int)n.CodigoOficina,
                        n.Oficina,
                        n.NumeroIdentificacion,
                        n.CuentaBanco,
                        n.TipoCuenta,
                        n.Banco,
                        (int)n.CodigoBanco,
                        n.Cliente,
                        (decimal)n.NumeroRecibo,
                        n.Recibo,
                        n.Fecha,
                        n.Factura,
                        n.FechaFactura,
                        n.Moneda,
                        n.Poliza,
                        (int)n.Ramo,
                        n.Producto,
                        (decimal)n.Bruto,
                        (decimal)n.Neto,
                        (decimal)n.PorcientoComision,
                        (decimal)n.Comision,
                        (decimal)n.Retencion,
                        (decimal)n.AvanceComision,
                        (decimal)n.ALiquidar,
                        n.ValidadoDesde,
                        n.ValidadoHasta,
                        (decimal)Session["IdUsuario"],
                        "INSERT");
                    Guardar.ProcesarInformacion();


                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "REPORTE DE INTERMEDIARIOS MOVIMIENTOS";

                rbPDF.Checked = true;
            }
        }

        protected void txtCodigoIntermediarioReporte_TextChanged(object sender, EventArgs e)
        {

            try {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioReporte.Text);
                txtNombreIntermediarioReprte.Text = Nombre.SacarNombreIntermediario(); 
            }
            catch (Exception) {
                txtNombreIntermediarioReprte.Text = string.Empty;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio()", "FechaHastaVacio();", true); }
            }
            else {
                ProcesarInformacion();
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechasVacios()", "CamposFechasVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesdeReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHastaReporte.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "FechaHastaVacio()", "FechaHastaVacio();", true); }
            }
            else {
                ProcesarInformacion();
            }
        }

        protected void LinkPrimeraPaginaReporteIntermediariosEspecial_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorReporteIntermediariosEspecial_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionReporteIntermediariosEspecial_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionReporteIntermediariosEspecial_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteReporteIntermediariosEspecial_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoReporteIntermediariosEspecial_Click(object sender, EventArgs e)
        {

        }
    }
}
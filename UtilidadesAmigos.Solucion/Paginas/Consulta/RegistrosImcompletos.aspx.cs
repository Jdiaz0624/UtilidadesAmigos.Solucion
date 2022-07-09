using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class RegistrosImcompletos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataComun = new Lazy<Logica.Logica.LogicaSistema>();

        #region CONTROL DE PAGINACION DE LOS CLIENTES SIN POLIZA
        readonly PagedDataSource pagedDataSource_ClienteSinPolizas = new PagedDataSource();
        int _PrimeraPagina_ClienteSinPolizas, _UltimaPagina_ClienteSinPolizas;
        private int _TamanioPagina_ClienteSinPolizas = 10;
        private int CurrentPage_ClienteSinPolizas
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

        private void HandlePaging_ClienteSinPolizas(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_ClienteSinPolizas = CurrentPage_ClienteSinPolizas - 5;
            if (CurrentPage_ClienteSinPolizas > 5)
                _UltimaPagina_ClienteSinPolizas = CurrentPage_ClienteSinPolizas + 5;
            else
                _UltimaPagina_ClienteSinPolizas = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_ClienteSinPolizas > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_ClienteSinPolizas = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_ClienteSinPolizas = _UltimaPagina_ClienteSinPolizas - 10;
            }

            if (_PrimeraPagina_ClienteSinPolizas < 0)
                _PrimeraPagina_ClienteSinPolizas = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_ClienteSinPolizas;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_ClienteSinPolizas; i < _UltimaPagina_ClienteSinPolizas; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_ClienteSinPolizas(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_ClienteSinPolizas.DataSource = Listado;
            pagedDataSource_ClienteSinPolizas.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_ClienteSinPolizas.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_ClienteSinPolizas.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_ClienteSinPolizas.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_ClienteSinPolizas : _NumeroRegistros);
            pagedDataSource_ClienteSinPolizas.CurrentPageIndex = CurrentPage_ClienteSinPolizas;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_ClienteSinPolizas.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_ClienteSinPolizas.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_ClienteSinPolizas.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_ClienteSinPolizas.IsLastPage;

            RptGrid.DataSource = pagedDataSource_ClienteSinPolizas;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_ClienteSinPolizas
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_ClienteSinPolizas(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CONTROL DE PAGINACION DE LAS POLIZAS SIN MARBETES
        readonly PagedDataSource pagedDataSource_PolizaSinMarbete = new PagedDataSource();
        int _PrimeraPagina_PolizaSinMarbete, _UltimaPagina_PolizaSinMarbete;
        private int _TamanioPagina_PolizaSinMarbete = 10;
        private int CurrentPage_PolizaSinMarbete
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

        private void HandlePaging_PolizaSinMarbete(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_PolizaSinMarbete = CurrentPage_PolizaSinMarbete - 5;
            if (CurrentPage_PolizaSinMarbete > 5)
                _UltimaPagina_PolizaSinMarbete = CurrentPage_PolizaSinMarbete + 5;
            else
                _UltimaPagina_PolizaSinMarbete = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_PolizaSinMarbete > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_PolizaSinMarbete = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_PolizaSinMarbete = _UltimaPagina_PolizaSinMarbete - 10;
            }

            if (_PrimeraPagina_PolizaSinMarbete < 0)
                _PrimeraPagina_PolizaSinMarbete = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_PolizaSinMarbete;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_PolizaSinMarbete; i < _UltimaPagina_PolizaSinMarbete; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_PolizaSinMarbete(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_PolizaSinMarbete.DataSource = Listado;
            pagedDataSource_PolizaSinMarbete.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_PolizaSinMarbete.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_PolizaSinMarbete.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_PolizaSinMarbete.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_PolizaSinMarbete : _NumeroRegistros);
            pagedDataSource_PolizaSinMarbete.CurrentPageIndex = CurrentPage_PolizaSinMarbete;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_PolizaSinMarbete.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_PolizaSinMarbete.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_PolizaSinMarbete.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_PolizaSinMarbete.IsLastPage;

            RptGrid.DataSource = pagedDataSource_PolizaSinMarbete;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_PolizaSinMarbete
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_PolizaSinMarbete(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region MOSTRAR EL LISTADO DE LOS CLIENTES SIN POOLIZA
        private void MostrarListadoClienteSinpolizas() {

            decimal? _CodigoCliente = string.IsNullOrEmpty(txtCodigoClienteSinPoliza.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoClienteSinPoliza.Text);
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionClienteSinPoliza.Text.Trim()) ? null : txtNumeroIdentificacionClienteSinPoliza.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeClienteSinPoliza.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaClienteSinPoliza.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorClienteSinPoliza.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioClienteSinPoliza.Text);
            string _NombreCliente = string.IsNullOrEmpty(txtNombreClienteClienteSinPoliza.Text.Trim()) ? null : txtNombreClienteClienteSinPoliza.Text.Trim();

            var Listado = ObjDataConsulta.Value.BuscaClientesSinPolizas(
                _CodigoCliente,
                _NumeroIdentificacion,
                _FechaDesde,
                _FechaHasta,
                _Supervisor,
                _Intermediario,
                _NombreCliente);
            if (Listado.Count() < 1) {
                rpListadoClienteSinPolizas.DataSource = null;
                rpListadoClienteSinPolizas.DataBind();
            }
            else {
                Paginar_ClienteSinPolizas(ref rpListadoClienteSinPolizas, Listado,10, ref lbCantidadPaginaClientesSinPoliza, ref btnPrimeraPaginaClientesSinPoliza, ref btnPaginaAnteriorClientesSinPoliza, ref btnSiguientePaginaClientesSinPoliza, ref btnUltimaPaginaClientesSinPoliza);
                HandlePaging_ClienteSinPolizas(ref dtPaginacionListadoPrincipalClientesSinPoliza, ref lbPaginaActualClientesSinPoliza);
            }
        }
        #endregion

        #region EXPORTAR CLIENTES SIN POLIZAS
        private void ExportarClientesSinPolizas() {

            decimal? _CodigoCliente = string.IsNullOrEmpty(txtCodigoClienteSinPoliza.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoClienteSinPoliza.Text);
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionClienteSinPoliza.Text.Trim()) ? null : txtNumeroIdentificacionClienteSinPoliza.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeClienteSinPoliza.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaClienteSinPoliza.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorClienteSinPoliza.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioClienteSinPoliza.Text);
            string _NombreCliente = string.IsNullOrEmpty(txtNombreClienteClienteSinPoliza.Text.Trim()) ? null : txtNombreClienteClienteSinPoliza.Text.Trim();

            var Exportar = (from n in ObjDataConsulta.Value.BuscaClientesSinPolizas(
               _CodigoCliente,
               _NumeroIdentificacion,
               _FechaDesde,
               _FechaHasta,
               _Supervisor,
               _Intermediario,
               _NombreCliente)
                            select new
                            {
                                Codigo = n.Codigo,
                                TipoIdentificacion = n.TipoIdentificacion,
                                NumeroIdentificacion = n.RNC,
                                Cliente = n.Cliente,
                                Direccion = n.Direccion,
                                Supervisor = n.Supervisor,
                                Intermediario = n.Intermediario,
                                Cobrador = n.Cobrador,
                                UsuarioAdiciona = n.UsuarioAdiciona,
                                fecha0 = n.fecha0,
                                Fecha_Formateada = n.Fecha,
                                TelefonoResidencia = n.TelefonoResidencia,
                                TelefonoOficina = n.TelefonoOficina,
                                Celular = n.Celular,
                                fax = n.fax,
                                Beeper = n.Beeper,
                                Comprobante = n.Comprobante,
                                Nacionalidad = n.Nacionalidad,
                                ClaseCliente = n.ClaseCliente
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Clientes Sin polizas", Exportar);
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LAS POLIZAS SIN MARBETES
        private void MostrarPolizasSinMarbetes() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaPolziaSinImpresion.Text.Trim()) ? null : txtPolizaPolziaSinImpresion.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtfechaDesdePolizaSinImpresion.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtfechaDesdePolizaSinImpresion.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHAstaPolizaSinMarbete.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHAstaPolizaSinMarbete.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorPolizaSinMarbete.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorPolizaSinMarbete.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioPolizaSinMarbete.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioPolizaSinMarbete.Text);
            int? _SubRamo = ddlSubRamoPolizasSinMarbete.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamoPolizasSinMarbete.SelectedValue)  : new Nullable<int>();

            var Listado = ObjDataConsulta.Value.BuscaPolziasSinMarbete(
                _Poliza,
                _Supervisor,
                _Intermediario,
                null,
                _FechaDesde,
                _FechaHasta,
                106,
                _SubRamo);
            if (Listado.Count() < 1) {
                rpListadoPolizaSinMarbete.DataSource = null;
                rpListadoPolizaSinMarbete.DataBind();
            }
            else {
                Paginar_PolizaSinMarbete(ref rpListadoPolizaSinMarbete, Listado, 10, ref lbCantidadPaginaPolizaSinMarbete, ref btnPrimeraPaginaPolizaSinMarbete, ref btnPaginaAnteriorPolizaSinMarbete, ref btnSiguientePaginaPolizaSinMarbete, ref btnUltimaPaginaPolizaSinMarbete);
                HandlePaging_PolizaSinMarbete(ref dtPaginacionListadoPrincipalPolizaSinMarbete, ref lbPaginaActualPolizaSinMarbete);
            }
        }
        #endregion

        #region EXPORTAR LAS POLIZAS SIN IMPRESIOND E MARBETES
        private void ExportarPolizasSinImpresion() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaPolziaSinImpresion.Text.Trim()) ? null : txtPolizaPolziaSinImpresion.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtfechaDesdePolizaSinImpresion.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtfechaDesdePolizaSinImpresion.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHAstaPolizaSinMarbete.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHAstaPolizaSinMarbete.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorPolizaSinMarbete.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorPolizaSinMarbete.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioPolizaSinMarbete.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioPolizaSinMarbete.Text);
            int? _SubRamo = ddlSubRamoPolizasSinMarbete.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamoPolizasSinMarbete.SelectedValue) : new Nullable<int>();

            var Exportar = (from n in ObjDataConsulta.Value.BuscaPolziasSinMarbete(
                _Poliza,
                _Supervisor,
                _Intermediario,
                null,
                _FechaDesde,
                _FechaHasta,
                106,
                _SubRamo)
                            select new
                            {
                                Poliza = n.Poliza,
                                Prima = n.Prima,
                                Estatus = n.Estatus,
                                InicioVigencia = n.InicioVigencia,
                                FinVigencia = n.FinVigencia,
                                Supervisor = n.Supervisor,
                                Intermediario = n.Intermediario,
                                Oficina = n.Oficina,
                                Usuario = n.UsuarioAdiciona,
                                FechaCreado = n.FechaCreado,
                                FechaCreadoFormateada = n.FechaCreadoFormateada,
                                Ramo = n.Ramo,
                                SubRamo = n.SubRamo
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Polizas Sin Impresión de Marbetes", Exportar);
        }
        #endregion

        #region CARGAR LISTAS DESPLEGABLES
        private void CargarOficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddloficinaPolziaSinImpresion, ObjdataComun.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void CargarSunramos() {
            int Ramo = 106;
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSubRamoPolizasSinMarbete, ObjdataComun.Value.BuscaListas("SUBRAMO", Ramo.ToString(), null), true);
        }

        private void CargaroficinaClienteSinPoliza() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficinaClienteSinPoliza, ObjdataComun.Value.BuscaListas("OFICINAS", null, null), true);
        }


        #endregion

        #region MOSTRAR EL LISTADO DE LOS CIENTES SIN POLIZA DETALLADO Y RESIMIDO
        private void ClientesSinPolizaDetallada() {

            decimal? _CodigoCliente = string.IsNullOrEmpty(txtCodigoClienteSinPoliza.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoClienteSinPoliza.Text);
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionClienteSinPoliza.Text.Trim()) ? null : txtNumeroIdentificacionClienteSinPoliza.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeClienteSinPoliza.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaClienteSinPoliza.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorClienteSinPoliza.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioClienteSinPoliza.Text);
            string _NombreCliente = string.IsNullOrEmpty(txtNombreClienteClienteSinPoliza.Text.Trim()) ? null : txtNombreClienteClienteSinPoliza.Text.Trim();
            int? _oficina = ddlSeleccionaroficinaClienteSinPoliza.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaClienteSinPoliza.SelectedValue) : new Nullable<int>();

            var BuscarListado = ObjDataConsulta.Value.BuscaClientesSinPolizasDetallado(
                _CodigoCliente,
                _NumeroIdentificacion,
                _FechaDesde,
                _FechaHasta,
                _Supervisor,
                _Intermediario,
                _NombreCliente,
                _oficina,
                (decimal)Session["IdUsuario"]);
            if (BuscarListado.Count() < 1) {
                rpListadoClienteSinPolizas.DataSource = null;
                rpListadoClienteSinPolizas.DataBind();
                CurrentPage_ClienteSinPolizas = 0;
            }
            else {
                Paginar_ClienteSinPolizas(ref rpListadoClienteSinPolizas, BuscarListado, 10, ref lbCantidadPaginaClientesSinPoliza, ref btnPrimeraPaginaClientesSinPoliza, ref btnPaginaAnteriorClientesSinPoliza, ref btnSiguientePaginaClientesSinPoliza, ref btnUltimaPaginaClientesSinPoliza);
                HandlePaging_ClienteSinPolizas(ref dtPaginacionListadoPrincipalClientesSinPoliza, ref lbPaginaActualClientesSinPoliza);
            }
        }

        #endregion

        #region GENERAR REPORTE DE CLIENTES SIN POLIZA
        private void GenerarReporteClientesSinPolizas() {
            decimal? _CodigoCliente = string.IsNullOrEmpty(txtCodigoClienteSinPoliza.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoClienteSinPoliza.Text);
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionClienteSinPoliza.Text.Trim()) ? null : txtNumeroIdentificacionClienteSinPoliza.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeClienteSinPoliza.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaClienteSinPoliza.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorClienteSinPoliza.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioClienteSinPoliza.Text);
            string _NombreCliente = string.IsNullOrEmpty(txtNombreClienteClienteSinPoliza.Text.Trim()) ? null : txtNombreClienteClienteSinPoliza.Text.Trim();
            int? _oficina = ddlSeleccionaroficinaClienteSinPoliza.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaClienteSinPoliza.SelectedValue) : new Nullable<int>();

            if (rbExcelPlano.Checked == true)
            {
                if (rbReporteResumido.Checked == true)
                {
                    var ExportarResumido = (from n in ObjDataConsulta.Value.BuscaClientesSinPolizaResumido(
                        _CodigoCliente,
                        _NumeroIdentificacion,
                        _FechaDesde,
                        _FechaHasta,
                        _Supervisor,
                        _Intermediario,
                        _NombreCliente,
                        _oficina,
                        (decimal)Session["IdUsuario"])
                                            select new
                                            {
                                                Mes = n.Mes,
                                                Oficina = n.Oficina,
                                                Cantidad = n.Cantidad
                                            }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Clientes Sin Poliza Resummido", ExportarResumido);

                }
                else if (rbReporteDetallado.Checked == true) {

                    var ExportarDetallado = (from n in ObjDataConsulta.Value.BuscaClientesSinPolizasDetallado(
                        _CodigoCliente,
                        _NumeroIdentificacion,
                        _FechaDesde,
                        _FechaHasta,
                        _Supervisor,
                        _Intermediario,
                        _NombreCliente,
                        _oficina,
                        (decimal)Session["IdUsuario"])
                                             select new
                                             {
                                                 Cliente = n.Cliente,
                                                 TipoIdentificacion = n.TipoIdentificacion,
                                                 RNC = n.RNC,
                                                 Direccion = n.Direccion,
                                                 Supervisor = n.Supervisor,
                                                 Intermediario = n.Intermediario,
                                                 Cobrador = n.Cobrador,
                                                 Usuario = n.UsuarioAdiciona,
                                                 Fecha = n.fecha0,
                                                 FechaFormateada = n.Fecha,
                                                 Hora = n.Hora,
                                                 Mes = n.Mes,
                                                 TelefonoResidencia = n.TelefonoResidencia,
                                                 TelefonoOficina = n.TelefonoOficina,
                                                 Celular = n.Celular,
                                                 fax = n.fax,
                                                 Beeper = n.Beeper,
                                                 Comprobante = n.Comprobante,
                                                 Nacionalidad = n.Nacionalidad,
                                                 ClaseCliente = n.ClaseCliente,
                                                 CantidadPolizas = n.CantidadPolizas,
                                                 CodigoOficina = n.CodigoOficina,
                                                 Oficina = n.Oficina,
                                                 GeneradoPor = n.GeneradoPor
                                             }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Clientes Sin Poliza Detallado", ExportarDetallado);
                }
            }
            else {
                ReporteClienteSinPoliza();
            }


        }

        private void ReporteClienteSinPoliza() {
            decimal? _CodigoCliente = string.IsNullOrEmpty(txtCodigoClienteSinPoliza.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoClienteSinPoliza.Text);
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtNumeroIdentificacionClienteSinPoliza.Text.Trim()) ? null : txtNumeroIdentificacionClienteSinPoliza.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesdeClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesdeClienteSinPoliza.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHastaClienteSinPoliza.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHastaClienteSinPoliza.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorClienteSinPoliza.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioClienteSinPoliza.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioClienteSinPoliza.Text);
            string _NombreCliente = string.IsNullOrEmpty(txtNombreClienteClienteSinPoliza.Text.Trim()) ? null : txtNombreClienteClienteSinPoliza.Text.Trim();
            int? _oficina = ddlSeleccionaroficinaClienteSinPoliza.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficinaClienteSinPoliza.SelectedValue) : new Nullable<int>();
            string RutaReporte = "";
            string NombreReporte = "";
            if (rbReporteDetallado.Checked == true)
            {
                RutaReporte = Server.MapPath("ReporteClientesSinPolizaDetallado.rpt");
                NombreReporte = "Reporte Clientes Sin Poliza Detallado";
            }
            else if (rbReporteResumido.Checked == true) {
                RutaReporte = Server.MapPath("ReporteClientesSinPolizasResumido.rpt");
                NombreReporte = "Reporte Clientes Sin Poliza Resumido";
            }


            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@CodigoCliente", _CodigoCliente);
            Reporte.SetParameterValue("@Numeroidentificacion", _NumeroIdentificacion);
            Reporte.SetParameterValue("@FechaDesde", _FechaDesde);
            Reporte.SetParameterValue("@FechaHasta", _FechaHasta);
            Reporte.SetParameterValue("@Supervisor", _Supervisor);
            Reporte.SetParameterValue("@Intermediario", _Intermediario);
            Reporte.SetParameterValue("@NombreCliente", _NombreCliente);
            Reporte.SetParameterValue("@CodigoOficina", _oficina);
            Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["IdUsuario"]);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbExcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
        }
        #endregion

        #region MOSTRAR LAS POLIZAS SIN MARBETES
        private void MostrarPolizasSinMarbetesDetallado() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaPolziaSinImpresion.Text.Trim()) ? null : txtPolizaPolziaSinImpresion.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtfechaDesdePolizaSinImpresion.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtfechaDesdePolizaSinImpresion.Text);
            DateTime? _fechaHasta = string.IsNullOrEmpty(txtFechaHAstaPolizaSinMarbete.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHAstaPolizaSinMarbete.Text);
            int? _oficina = ddloficinaPolziaSinImpresion.SelectedValue != "-1" ? Convert.ToInt32(ddloficinaPolziaSinImpresion.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorPolizaSinMarbete.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorPolizaSinMarbete.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioPolizaSinMarbete.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioPolizaSinMarbete.Text);
            int? _Ramo = ddlSubRamoPolizasSinMarbete.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamoPolizasSinMarbete.SelectedValue) : new Nullable<int>();

            var Listado = ObjDataConsulta.Value.BuscaPolziasSinMarbeteDetallado(
                _Poliza,
                _Supervisor,
                _Intermediario,
                _oficina,
                _FechaDesde,
                _fechaHasta,
                _Ramo,
                null,
                (decimal)Session["IdUsuario"]);
            if (Listado.Count() < 1) {
                rpListadoPolizaSinMarbete.DataSource = null;
                rpListadoPolizaSinMarbete.DataBind();
                CurrentPage_PolizaSinMarbete = 0;
            }
            else {
                Paginar_PolizaSinMarbete(ref rpListadoPolizaSinMarbete, Listado, 10, ref lbCantidadPaginaPolizaSinMarbete, ref btnPrimeraPaginaPolizaSinMarbete, ref btnPaginaAnteriorPolizaSinMarbete, ref btnSiguientePaginaPolizaSinMarbete, ref btnUltimaPaginaPolizaSinMarbete);
                HandlePaging_PolizaSinMarbete(ref dtPaginacionListadoPrincipalPolizaSinMarbete, ref lbPaginaActualPolizaSinMarbete);
            }
        }

        private void GenerarReportePolizaSinMarbete() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaPolziaSinImpresion.Text.Trim()) ? null : txtPolizaPolziaSinImpresion.Text.Trim();
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtfechaDesdePolizaSinImpresion.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtfechaDesdePolizaSinImpresion.Text);
            DateTime? _fechaHasta = string.IsNullOrEmpty(txtFechaHAstaPolizaSinMarbete.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHAstaPolizaSinMarbete.Text);
            int? _oficina = ddloficinaPolziaSinImpresion.SelectedValue != "-1" ? Convert.ToInt32(ddloficinaPolziaSinImpresion.SelectedValue) : new Nullable<int>();
            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisorPolizaSinMarbete.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorPolizaSinMarbete.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioPolizaSinMarbete.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioPolizaSinMarbete.Text);
            int? _Ramo = ddlSubRamoPolizasSinMarbete.SelectedValue != "-1" ? Convert.ToInt32(ddlSubRamoPolizasSinMarbete.SelectedValue) : new Nullable<int>();
            string RutaReporte = "", NombeReporte = "";

            if (rbExcelPlano.Checked == true) {

                if (rbReporteDetallado.Checked == true) {
                    var Detallado = (from n in ObjDataConsulta.Value.BuscaPolziasSinMarbeteDetallado(
                        _Poliza,
                        _Supervisor,
                        _Intermediario,
                        _oficina,
                        _FechaDesde,
                        _fechaHasta,
                        _Ramo,
                        null,
                        (decimal)Session["IdUsuario"])
                                     select new
                                     {
                                         Poliza = n.Poliza,
                                         Prima = n.Prima,
                                         Estatus = n.Estatus,
                                         InicioVigencia = n.InicioVigencia,
                                         FinVigencia = n.FinVigencia,
                                         Supervisor = n.Supervisor,
                                         Intermediario = n.Intermediario,
                                         Oficina = n.Oficina,
                                         CreadoPor = n.UsuarioAdiciona,
                                         FechaCreadoFormateada = n.FechaCreadoFormateada,
                                         HoraCreadoFormateada = n.HoraCreadoFormateada,
                                         Mes = n.Mes,
                                         Ramo = n.Ramo,
                                         SubRamo = n.SubRamo
                                     }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Polizas Sin Marbete Detallado", Detallado);
                }
                else if (rbReporteResumido.Checked == true) {
                    var Resumido = (from n in ObjDataConsulta.Value.BuscaPolizasSinMarbetesResumido(
                        _Poliza,
                        _Supervisor,
                        _Intermediario,
                        _oficina,
                        _FechaDesde,
                        _fechaHasta,
                        _Ramo,
                        null,
                        (decimal)Session["IdUsuario"])
                                    select new
                                    {
                                        Mes = n.Mes,
                                        Ramo = n.Ramo,
                                        SubRamo = n.SubRamo,
                                        Oficina = n.Oficina,
                                        Cantidad = n.Cantidad
                                    }).ToList();
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte de Polizas Sin Marbete Resumido", Resumido);
                }
            }
            else {

                if (rbReporteDetallado.Checked == true) {
                    NombeReporte = "Reporte de Polizas Sin Marbete Detallado";
                    RutaReporte = Server.MapPath("ReportePolizasSinMarbeteDetallado.rpt");
                }
                else if (rbReporteResumido.Checked == true) {
                    NombeReporte = "Reporte de Polizas Sin Marbete Resumido";
                    RutaReporte = Server.MapPath("ReportePolizaSinImpresionMarbeteResumido.rpt");
                }

                ReportDocument Reporte = new ReportDocument();

                Reporte.Load(RutaReporte);
                Reporte.Refresh();

                Reporte.SetParameterValue("@Poliza", _Poliza);
                Reporte.SetParameterValue("@Supervisor", _Supervisor);
                Reporte.SetParameterValue("@Intermediario", _Intermediario);
                Reporte.SetParameterValue("@Oficina", _oficina);
                Reporte.SetParameterValue("@FechaDesde", _FechaDesde);
                Reporte.SetParameterValue("@FechaHasta", _fechaHasta);
                Reporte.SetParameterValue("@Ramo", _Ramo);
                Reporte.SetParameterValue("@SubRamo", new Nullable<int>());
                Reporte.SetParameterValue("@GeneradoPor", (decimal)Session["Idusuario"]);

                Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

                if (rbPDF.Checked == true) {
                    Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombeReporte);
                }
                else if (rbExcel.Checked == true) {
                    Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombeReporte);
                }
            }
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
                lbPantalla.Text = "REGISTROS IMCOMPLETOS";

                rbCLientesSinPolizas.Checked = true;
                rbReporteResumido.Checked = true;
                rbPDF.Checked = true;
                DIVBloqueClientesSinPoliza.Visible = true;
                DivBloquePaginacionPolizasSinMarbete.Visible = false;
                CargaroficinaClienteSinPoliza();
                
            }
        }

        protected void rbCLientesSinPolizas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCLientesSinPolizas.Checked == true) {
                DIVBloqueClientesSinPoliza.Visible = true;
                DIVBloquePolziaSinMarbete.Visible = false;
                CargaroficinaClienteSinPoliza();
            }
            else {
                DIVBloqueClientesSinPoliza.Visible = false;
                DIVBloquePolziaSinMarbete.Visible = false;
            }
        }

        protected void rbPolizasSInImpresionMarbete_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPolizasSInImpresionMarbete.Checked == true) {
                DIVBloqueClientesSinPoliza.Visible = false;
                DIVBloquePolziaSinMarbete.Visible = true;
                CargarOficinas();
                CargarSunramos();
            }
            else {
                DIVBloqueClientesSinPoliza.Visible = false;
                DIVBloquePolziaSinMarbete.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            if (rbCLientesSinPolizas.Checked == true) {
                CurrentPage_ClienteSinPolizas = 0;
                ClientesSinPolizaDetallada();
            }
            else if (rbPolizasSInImpresionMarbete.Checked == true) {
                CurrentPage_PolizaSinMarbete = 0;
                MostrarPolizasSinMarbetesDetallado();
            }
        }

        protected void btnExportarExel_Click(object sender, ImageClickEventArgs e)
        {
            if (rbCLientesSinPolizas.Checked == true) {
                ExportarClientesSinPolizas();
            }
            else if (rbPolizasSInImpresionMarbete.Checked == true) {
                ExportarPolizasSinImpresion();
            }
        }

        protected void btnPrimeraPaginaClientesSinPoliza_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ClienteSinPolizas = 0;
            MostrarListadoClienteSinpolizas();
        }

        protected void btnPaginaAnteriorClientesSinPoliza_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_ClienteSinPolizas += -1;
            MostrarListadoClienteSinpolizas();
            MoverValoresPaginacion_ClienteSinPolizas((int)OpcionesPaginacionValores_ClienteSinPolizas.PaginaAnterior, ref lbPaginaActualClientesSinPoliza, ref lbCantidadPaginaClientesSinPoliza);
        }

        protected void dtPaginacionListadoPrincipalClientesSinPoliza_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalClientesSinPoliza_CancelCommand(object source, DataListCommandEventArgs e)
        {

            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_ClienteSinPolizas = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoClienteSinpolizas();
        }

        protected void btnSiguientePaginaClientesSinPoliza_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_ClienteSinPolizas += 1;
            MostrarListadoClienteSinpolizas();
        }

        protected void txtCodigoSupervisorClienteSinPoliza_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Supervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisorClienteSinPoliza.Text);
            txtNombreSupervisorClienteSinPoliza.Text = Supervisor.SacarNombreSupervisor();
        }

        protected void btnPrimeraPaginaPolizaSinMarbete_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PolizaSinMarbete = 0;
            MostrarPolizasSinMarbetes();
        }

        protected void btnPaginaAnteriorPolizaSinMarbete_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PolizaSinMarbete += -1;
            MostrarPolizasSinMarbetes();
            MoverValoresPaginacion_PolizaSinMarbete((int)OpcionesPaginacionValores_PolizaSinMarbete.PaginaAnterior, ref lbPaginaActualPolizaSinMarbete, ref lbCantidadPaginaPolizaSinMarbete);
        }

        protected void dtPaginacionListadoPrincipalPolizaSinMarbete_ItemDataBound(object sender, DataListItemEventArgs e)
        {
           
        }

        protected void btnSiguientePaginaPolizaSinMarbete_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_PolizaSinMarbete += 1;
            MostrarPolizasSinMarbetes();

        }

        protected void btnUltimaPaginaPolizaSinMarbete_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_PolizaSinMarbete = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarPolizasSinMarbetes();
            MoverValoresPaginacion_PolizaSinMarbete((int)OpcionesPaginacionValores_PolizaSinMarbete.UltimaPagina, ref lbPaginaActualPolizaSinMarbete, ref lbCantidadPaginaPolizaSinMarbete);
        }

        protected void dtPaginacionListadoPrincipalPolizaSinMarbete_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_PolizaSinMarbete = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarPolizasSinMarbetes();
        }

        protected void txtCodigoSupervisorPolizaSinMarbete_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Supervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisorPolizaSinMarbete.Text);
            txtNombreSupervisorPolizaSinMarbete.Text = Supervisor.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediarioPolizaSinMarbete_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Intermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioPolizaSinMarbete.Text);
            txtNombreIntermediarioPolizaSinMarbete.Text = Intermediario.SacarNombreSupervisor();
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            if (rbCLientesSinPolizas.Checked == true)
            {
                GenerarReporteClientesSinPolizas();
            }
            //POLIZAS SIN MARBETE
            else if (rbPolizasSInImpresionMarbete.Checked == true) {
                GenerarReportePolizaSinMarbete();
            }
        }

        protected void txtCodigoIntermediarioClienteSinPoliza_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Intermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioClienteSinPoliza.Text);
            txtNombreIntermediarioClienteSinPoliza.Text = Intermediario.SacarNombreIntermediario();
        }

        protected void btnUltimaPaginaClientesSinPoliza_Click(object sender, ImageClickEventArgs e)
        {

            CurrentPage_ClienteSinPolizas = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoClienteSinpolizas();
            MoverValoresPaginacion_ClienteSinPolizas((int)OpcionesPaginacionValores_ClienteSinPolizas.UltimaPagina, ref lbPaginaActualClientesSinPoliza, ref lbCantidadPaginaClientesSinPoliza);
        }
    }
}
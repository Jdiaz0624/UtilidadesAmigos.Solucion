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

        #region CONTROL DE PAGINACION DE LOS COMENTARIOS
        readonly PagedDataSource pagedDataSource_Comentarios = new PagedDataSource();
        int _PrimeraPagina_Comentarios, _UltimaPagina_Comentarios;
        private int _TamanioPagina_Comentarios = 10;
        private int CurrentPage_Comentarios
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

        private void HandlePaging_Comentarios(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Comentarios = CurrentPage_Comentarios - 5;
            if (CurrentPage_Comentarios > 5)
                _UltimaPagina_Comentarios = CurrentPage_Comentarios + 5;
            else
                _UltimaPagina_Comentarios = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Comentarios > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Comentarios = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Comentarios = _UltimaPagina_Comentarios - 10;
            }

            if (_PrimeraPagina_Comentarios < 0)
                _PrimeraPagina_Comentarios = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Comentarios;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Comentarios; i < _UltimaPagina_Comentarios; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Comentarios(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Comentarios.DataSource = Listado;
            pagedDataSource_Comentarios.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Comentarios.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Comentarios.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Comentarios.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Comentarios : _NumeroRegistros);
            pagedDataSource_Comentarios.CurrentPageIndex = CurrentPage_Comentarios;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Comentarios.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Comentarios.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Comentarios.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Comentarios.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Comentarios;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Comentarios
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Comentarios(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
            int? _Estatus = ddlEstatusCliente.SelectedValue != "-1" ? Convert.ToInt32(ddlEstatusCliente.SelectedValue) : new Nullable<int>();

            var BuscarListado = ObjDataConsulta.Value.BuscaClientesSinPolizasDetallado(
                _CodigoCliente,
                _NumeroIdentificacion,
                _FechaDesde,
                _FechaHasta,
                _Supervisor,
                _Intermediario,
                _NombreCliente,
                _oficina,
                (decimal)Session["IdUsuario"],
                _Estatus);
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
                                                 GeneradoPor = n.GeneradoPor,
                                                 SiglaEstatus=n.SiglaEstatus,
                                                 Estatus=n.Estatus
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


        #region SACAR LOS DATOS DEL CLIENTE
        private void SacarInformacionCliente(decimal CodigoCliente) {

            var SacarInformacionCliente = ObjDataConsulta.Value.BuscaClientesSinPolizas(CodigoCliente);
            foreach (var n in SacarInformacionCliente) {

                txtCodigoClienteProcesoClienteSinPoliza.Text = n.Codigo.ToString();
                txtNombreClienteProcesoClienteSinPoliza.Text = n.Cliente;
                txtTipoIdentificacionProcesoClientesSinPoliza.Text = n.TipoIdentificacion;
                txtNumeroIdentificacionProcesoClientesSinPoliza.Text = n.RNC;
                txtFechaProcesoClientesSinPoliza.Text = n.Fecha;
                //txtHoraProcesoClientesSinPoliza.Text=
                txtDireccionProcesoClientesSInPolizs.Text = n.Direccion;
                txtTelefonoProcesoClientesSinPoliza.Text = n.TelefonoResidencia;
                txtTelefonoOficinaProcesoCLienteSinPoliza.Text = n.TelefonoOficina;
                txtCelularProcesoClientesSinPoliza.Text = n.Celular;
                txtSupervisorProcesoClientesSinPoliza.Text = n.Supervisor;
                txtIntermediarioProcesoClientesSinPoliza.Text = n.Intermediario;
                txtUsuarioProcesoClientesSinPoliza.Text = n.UsuarioAdiciona;
                txtEstatusProcesoClientesSinPoliza.Text = n.Estatus;
                lbCodigoEstatusClienteSinPoliza.Text = n.CodigoEstatus.ToString();
            }
            DIVBloqueProcesoClienteSinPoliza.Visible = true;
            DivBloqueListadoClienteSinPoliza.Visible = false;
            DivClienteSinPolzaRecuento.Visible = false;
            DIVPolizaSinMArbeteRecuento.Visible = false;
            DivRadios.Visible = false;
            DIVBotones.Visible = false;

            //VALIDSMOS SI TIENE COMENTARIOS ACTIVOS
            var Comentarios = ObjDataConsulta.Value.BuscaComentariosProcesoClienteSinPoliza(Convert.ToDecimal(txtCodigoClienteProcesoClienteSinPoliza.Text));
            if (Comentarios.Count() < 1) {

                cbAgregarComentario.Checked = false;
                DivBloqueComentarioProcesoClienteSinPoliza.Visible = false;
                txtComentario.Text = string.Empty;
            }
            else {

                //MOSTRAMOS LOS COMENTARIOS
                cbAgregarComentario.Checked = true;
                DivBloqueComentarioProcesoClienteSinPoliza.Visible = true;
                CurrentPage_Comentarios = 0;
                Paginar_Comentarios(ref rpListadoComentariosClientesSinPoliza, Comentarios, 10, ref lbCantidadPaginaComentarios, ref btnPrimeraPaginaComentarios, ref btnPaginaAnteriorComentarios, ref btnSiguientePaginaComentarios, ref btnUltimaPaginaComentarios);
                HandlePaging_Comentarios(ref dtPaginacionListadoPrincipalComentarios, ref lbPaginaActualComentarios);
            }
        }
        #endregion

        #region MOSTRAR LOS COMENTARIOS PARA LA PAGINACION
        private void MostrarComentarios() {
            var Comentarios = ObjDataConsulta.Value.BuscaComentariosProcesoClienteSinPoliza(Convert.ToDecimal(txtCodigoClienteProcesoClienteSinPoliza.Text));
            Paginar_Comentarios(ref rpListadoComentariosClientesSinPoliza, Comentarios, 10, ref lbCantidadPaginaComentarios, ref btnPrimeraPaginaComentarios, ref btnPaginaAnteriorComentarios, ref btnSiguientePaginaComentarios, ref btnUltimaPaginaComentarios);
            HandlePaging_Comentarios(ref dtPaginacionListadoPrincipalComentarios, ref lbPaginaActualComentarios);
        }
        #endregion


        #region CARGAR ESTATUS DE CLIENTES SIN POLIZA
        private void CargarEstatusClientesSinPOliza() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatusCliente, ObjdataComun.Value.BuscaListas("ESTATUSCLIENTESINPOLIZA", null, null), true);
        }
        #endregion

        #region PROCESAR COMENTARIOS DE CLIENTES SIN POLIZA
        private void ProcesarComentariosClientesSinPoliza(decimal CodigoCliente) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionComentariosClientesSinPoliza Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionComentariosClientesSinPoliza(
                0,
                CodigoCliente,
                (decimal)Session["IdUsuario"],
                DateTime.Now,
                txtComentario.Text,
                "INSERT");
            Guardar.ProcesarInformacion();
        }
        #endregion

        #region VOLVER ATRAS CLIENTES SIN POLIZA
        private void VolverAtrasClienteSinPoliza() {

            DIVBloqueProcesoClienteSinPoliza.Visible = false;
            DivBloqueListadoClienteSinPoliza.Visible = true;
            DivClienteSinPolzaRecuento.Visible = true;
            DIVPolizaSinMArbeteRecuento.Visible = true;
            DivRadios.Visible = true;
            DIVBotones.Visible = true;
        }
        #endregion


        #region ASIGNACION DE ESTATUS
        private void AsignacionEstatus(int Estatus,string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionAsignacionEstatus Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionAsignacionEstatus(
                   0,
                   Convert.ToDecimal(txtCodigoClienteProcesoClienteSinPoliza.Text),
                   Estatus,
                   DateTime.Now,
                   Accion);
            Procesar.ProcesarInformacion();

            VolverAtrasClienteSinPoliza();

            CurrentPage_ClienteSinPolizas = 0;
            var BuscarListado = ObjDataConsulta.Value.BuscaClientesSinPolizasDetallado(
               Convert.ToDecimal(txtCodigoClienteProcesoClienteSinPoliza.Text),
               null,
               null,
               null,
               null,
               null,
               null,
               null,
               (decimal)Session["IdUsuario"],
               null);
            if (BuscarListado.Count() < 1)
            {
                rpListadoClienteSinPolizas.DataSource = null;
                rpListadoClienteSinPolizas.DataBind();
                CurrentPage_ClienteSinPolizas = 0;
            }
            else
            {
                Paginar_ClienteSinPolizas(ref rpListadoClienteSinPolizas, BuscarListado, 10, ref lbCantidadPaginaClientesSinPoliza, ref btnPrimeraPaginaClientesSinPoliza, ref btnPaginaAnteriorClientesSinPoliza, ref btnSiguientePaginaClientesSinPoliza, ref btnUltimaPaginaClientesSinPoliza);
                HandlePaging_ClienteSinPolizas(ref dtPaginacionListadoPrincipalClientesSinPoliza, ref lbPaginaActualClientesSinPoliza);
            }


            ClientScript.RegisterStartupScript(GetType(), "ProcesoCompletadoConExito()", "ProcesoCompletadoConExito();", true);
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
                DIVBloqueProcesoClienteSinPoliza.Visible = false;
                DivBloqueListadoClienteSinPoliza.Visible = true;
                DivClienteSinPolzaRecuento.Visible = true;
                DIVPolizaSinMArbeteRecuento.Visible = true;
                DivRadios.Visible = true;
                DIVBotones.Visible = true;
                CargarEstatusClientesSinPOliza();
            }
        }

        protected void rbCLientesSinPolizas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCLientesSinPolizas.Checked == true) {
                DIVBloqueClientesSinPoliza.Visible = true;
                DIVBloquePolziaSinMarbete.Visible = false;
                CargaroficinaClienteSinPoliza();
                DIVBloqueProcesoClienteSinPoliza.Visible = false;
                DivBloqueListadoClienteSinPoliza.Visible = true;
                DivClienteSinPolzaRecuento.Visible = true;
                DIVPolizaSinMArbeteRecuento.Visible = true;
                DivRadios.Visible = true;
                DIVBotones.Visible = true;
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

        protected void btnProcesar_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var CodigoCliente = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoClienteProceso")).Value.ToString();
            var CodigoEstatus = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoEstatus")).Value.ToString();
            int Estatus = Convert.ToInt32(CodigoEstatus);

            //VALIDAMOS EL USUARIO Y SACAMOS EL CODIGO DEL PERFIL DEL USUARIO EN SI
            UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Perfil = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
            int PerfilUsuario = Perfil.SacarPerfilUsuarioConectado();

            switch (PerfilUsuario) {

                case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.ADMINISTRADOR:
                    SacarInformacionCliente(Convert.ToDecimal(CodigoCliente));
                    break;


                case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.TECNICO:


                    if (Estatus == (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Tecnico)
                    {
                        SacarInformacionCliente(Convert.ToDecimal(CodigoCliente));
                    }
                    else {
                        ClientScript.RegisterStartupScript(GetType(), "AccesoDenegadoNegocios()", "AccesoDenegadoNegocios();", true);
                    }

                    break;

                case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.Tecnico_Especial:
                    if (Estatus == (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Tecnico)
                    {
                        SacarInformacionCliente(Convert.ToDecimal(CodigoCliente));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "AccesoDenegadoNegocios()", "AccesoDenegadoNegocios();", true);
                    }
                    break;  

                case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.PerfilesUsuarios.NEGOCIOS:
                    if (Estatus == (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Negocios || Estatus == (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Devuelto)
                    {
                        SacarInformacionCliente(Convert.ToDecimal(CodigoCliente));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "AccesoDenegadoTecnico()", "AccesoDenegadoTecnico();", true);
                    }
                    break;

                default:

                    ClientScript.RegisterStartupScript(GetType(), "AccesoDenegado()", "AccesoDenegado();", true);

                    break;
            }
        }



        protected void btnProcesarInformacion_Click(object sender, ImageClickEventArgs e)
        {
            if (cbAgregarComentario.Checked == true) {
                if (string.IsNullOrEmpty(txtComentario.Text.Trim())) { }
                else {
                    ProcesarComentariosClientesSinPoliza(Convert.ToDecimal(txtCodigoClienteProcesoClienteSinPoliza.Text));
                }
            }

            //VALIDAMOS SI HAY REGISTROS GUARDADOS CON ESTE REGISTRO
            var ValidarRegistro = ObjDataConsulta.Value.ListadoAsignacionEstatus(
                new Nullable<decimal>(),
                Convert.ToDecimal(txtCodigoClienteProcesoClienteSinPoliza.Text),
                null);
            if (ValidarRegistro.Count() < 1)
            {
                //CREAMOS ESTE REGISTRO

                AsignacionEstatus(
                    (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Tecnico,
                    "INSERT");
            }
            else {
                //MODIFICAMOS EL REGISTRO
                int CodigoEstatus = Convert.ToInt32(lbCodigoEstatusClienteSinPoliza.Text); 

                switch (CodigoEstatus) {

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Negocios:
                        AsignacionEstatus(
                    (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Tecnico,
                    "UPDATE");
                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Tecnico:
                        AsignacionEstatus(
                    (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Devuelto,
                    "UPDATE");
                        break;

                    case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Devuelto:
                        AsignacionEstatus(
                    (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.CodigoEstatusClientesSinPoliza.Tecnico,
                    "UPDATE");
                        break;
                }
            }
        }

        protected void btnVolverAtrasCLienteSinnPoliza_Click(object sender, ImageClickEventArgs e)
        {
            VolverAtrasClienteSinPoliza();
        }

        protected void cbAgregarComentario_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarComentario.Checked == true)
            {
                DivBloqueComentarioProcesoClienteSinPoliza.Visible = true;
                txtComentario.Text = string.Empty;
            }
            else {

                DivBloqueComentarioProcesoClienteSinPoliza.Visible = false;
            }
        }

        protected void btnPrimeraPaginaComentarios_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comentarios = 0;
            MostrarComentarios();
        }

        protected void btnPaginaAnteriorComentarios_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comentarios += -1;
            MostrarComentarios();
            MoverValoresPaginacion_Comentarios((int)OpcionesPaginacionValores_Comentarios.PaginaAnterior, ref lbPaginaActualComentarios, ref lbCantidadPaginaComentarios);
        }

        protected void dtPaginacionListadoPrincipalComentarios_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalComentarios_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Comentarios = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarComentarios();
        }

        protected void btnSiguientePaginaComentarios_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comentarios += 1;
            MostrarComentarios();
        }

        protected void btnUltimaPaginaComentarios_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Comentarios = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarComentarios();
            MoverValoresPaginacion_Comentarios((int)OpcionesPaginacionValores_Comentarios.UltimaPagina, ref lbPaginaActualComentarios, ref lbCantidadPaginaComentarios);
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
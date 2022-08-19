using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class ProcesoEmisionPoliza : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProcesos = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();

        enum EstatusProcesoEmisiion {

            CreacionRegistro = 1,
            CreacionCliente = 2,
            RecepcionDocumentos = 3,
            EmisionPoliza = 4,
            SegundaRevision = 5,
            ImpresionMarbete = 6,
            Despacho = 7
        }
        #region CONTROL DE PAGINACION HEADER
        readonly PagedDataSource pagedDataSource_Header = new PagedDataSource();
        int _PrimeraPagina_Header, _UltimaPagina_Header;
        private int _TamanioPagina_Header = 10;
        private int CurrentPage_Header
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

        private void HandlePaging_Header(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Header = CurrentPage_Header - 5;
            if (CurrentPage_Header > 5)
                _UltimaPagina_Header = CurrentPage_Header + 5;
            else
                _UltimaPagina_Header = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Header > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Header = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Header = _UltimaPagina_Header - 10;
            }

            if (_PrimeraPagina_Header < 0)
                _PrimeraPagina_Header = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Header;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Header; i < _UltimaPagina_Header; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Header(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Header.DataSource = Listado;
            pagedDataSource_Header.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Header.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Header.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Header.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Header : _NumeroRegistros);
            pagedDataSource_Header.CurrentPageIndex = CurrentPage_Header;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Header.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Header.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Header.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Header.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Header;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Header
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Header(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DETAIL
        readonly PagedDataSource pagedDataSource_Detail = new PagedDataSource();
        int _PrimeraPagina_Detail, _UltimaPagina_Detail;
        private int _TamanioPagina_Detail = 10;
        private int CurrentPage_Detail
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

        private void HandlePaging_Detail(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Detail = CurrentPage_Detail - 5;
            if (CurrentPage_Detail > 5)
                _UltimaPagina_Detail = CurrentPage_Detail + 5;
            else
                _UltimaPagina_Detail = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Detail > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Detail = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Detail = _UltimaPagina_Detail - 10;
            }

            if (_PrimeraPagina_Detail < 0)
                _PrimeraPagina_Detail = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Detail;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Detail; i < _UltimaPagina_Detail; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Detail(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Detail.DataSource = Listado;
            pagedDataSource_Detail.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Detail.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Detail.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Detail.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Detail : _NumeroRegistros);
            pagedDataSource_Detail.CurrentPageIndex = CurrentPage_Detail;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Detail.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Detail.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Detail.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Detail.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Detail;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Detail
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Detail(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarListasDesplegables() {
            CargarEstatus();
            Oficinas();
        }
        private void CargarEstatus() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatusConsulta, ObjDataComun.Value.BuscaListas("ESTATUSPROCESOEMISION", null, null), true);
        }
        private void Oficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaConsulta, ObjDataComun.Value.BuscaListas("OFICINAS", null, null), true);
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LA CABECERA
        private void MostrarCabecera() {
            decimal? _NumeroRegistro = string.IsNullOrEmpty(txtNumeroRegistroConsulyta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroRegistroConsulyta.Text);
            decimal? _CodigoCliente = string.IsNullOrEmpty(txtCodigoClienteConsulta.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoClienteConsulta.Text);
            string _Poliza = string.IsNullOrEmpty(txtPolizaconsulta.Text.Trim()) ? null : txtPolizaconsulta.Text.Trim();
            int? _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioConsulta.Text);
            int? _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisorConsulta.Text);
            int? _Estatus = ddlSeleccionarEstatusConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarEstatusConsulta.SelectedValue) : new Nullable<int>();
            int? _Oficina = ddlOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlOficinaConsulta.SelectedValue) : new Nullable<int>();

            var Listado = ObjDataProcesos.Value.BuscaProcesoEmisionHeader(
                _NumeroRegistro,
                null,
                _CodigoCliente,
                _Poliza,
                _CodigoIntermediario,
                _CodigoSupervisor,
                _Oficina,
                _Estatus);
            if (Listado.Count() < 1)
            {
                rpProcesoEmisionEncabezado.DataSource = null;
                rpProcesoEmisionEncabezado.DataBind();
                CurrentPage_Header = 0;
            }
            else {
                Paginar_Header(ref rpProcesoEmisionEncabezado, Listado, 10, ref lbCantidadPagina, ref btnPrimeraPaginaHeader, ref btnPaginaAnteriorHeader, ref btnSiguientePaginaHeader, ref btnUltimaPaginaHeader);
                HandlePaging_Header(ref dtPaginacionListadoPrincipalHeader, ref lbPaginaActual);
            }
        }
        #endregion

        #region MOSTRAR EL DETALLE
        private void MostrarDetail(string NumeroConector) {

            var Listado = ObjDataProcesos.Value.BuscaProcesoEmisionDetail(NumeroConector);
            if (Listado.Count() < 1) {
                rpProcesoEmisionDetalle.DataSource = null;
                rpProcesoEmisionDetalle.DataBind();
                CurrentPage_Detail = 0;
            }
            else {
                Paginar_Detail(ref rpProcesoEmisionDetalle, Listado, 10, ref lbCantidadPaginaDetalle, ref btnPrimeraPaginaDetalle, ref btnPaginaAnteriorDetalle, ref btnSiguientePaginaDetalle, ref btnUltimaPaginaDetalle);
                HandlePaging_Detail(ref dtPaginacionListadoPrincipalDetalle,ref lbPaginaActualDetalle);
            }
        }
        #endregion

        #region GENERAR NUMERO DE CONECTOR
        private string GenerarNumeroConector() {

            string NumeroConector = "";
            int PrimerDigito = 0, SegundoDigito = 0, TercerDigito = 0, CuartoDigito = 0, QuintoDigito = 0;
            int Ano = 0, Mes = 0, Dia = 0, Minuto = 0, Segundo = 0;

            Random GenerarNumero = new Random();
            PrimerDigito = GenerarNumero.Next(0, 9999);
            SegundoDigito = GenerarNumero.Next(0, 9999);
            TercerDigito = GenerarNumero.Next(0, 9999);
            CuartoDigito = GenerarNumero.Next(0, 9999);
            QuintoDigito = GenerarNumero.Next(0, 9999);

            Ano = DateTime.Now.Year;
            Mes = DateTime.Now.Month;
            Dia = DateTime.Now.Day;
            Minuto = DateTime.Now.Minute;
            Segundo = DateTime.Now.Second;

            NumeroConector = Ano.ToString() + PrimerDigito.ToString() + Mes.ToString() + SegundoDigito.ToString() + Dia.ToString() + TercerDigito.ToString() + Minuto.ToString() + CuartoDigito.ToString() + Segundo.ToString() + QuintoDigito.ToString();
            return NumeroConector;
        }
        #endregion

        #region PROCESAR LA INFORMACION DE LA SOLICITUD

        
        private void ProcesarInformacionHeader(decimal NumeroRegistro, string NumeroConector, decimal CodigoCliente, bool DocumentoEntragado, bool PolizaEmitida, bool SegundaRevicion, bool ImpresionMarbete, bool Despachada, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionEmisionesHeader Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionEmisionesHeader(
                NumeroRegistro,
                NumeroConector,
                true,
                CodigoCliente,
                DocumentoEntragado,
                PolizaEmitida,
                "",
                SegundaRevicion,
                ImpresionMarbete,
                Despachada,
                Accion);
            Procesar.ProcesarInformacion();
        }

        private void ProcesarInformacionDetail(string NumeroConector, int Secuencia, int IdEstatus) {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionProcesoEmisionDetail GuardarDetail = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionProcesoEmisionDetail(
                NumeroConector,
                Secuencia,
                IdEstatus,
                DateTime.Now,
                (decimal)Session["IdUsuario"],
                "INSERT");
            GuardarDetail.ProcesarInformacion();
        
        }
        #endregion

        private void ValidacionCheck() {
            if (cbDocumentosRevisados.Checked == true)
            {
                cbDocumentosRevisados.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = true;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbDocumentosRevisados.Checked == false)
            {
                cbDocumentosRevisados.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }




            if (cbEmisionPoliza.Checked == true)
            {
                cbEmisionPoliza.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = true;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbEmisionPoliza.Checked == false)
            {
                cbEmisionPoliza.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }






            if (cbSegundaRevision.Checked == true)
            {
                cbSegundaRevision.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = true;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbSegundaRevision.Checked == false)
            {
                cbSegundaRevision.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }





            if (cbImpresiónMarbete.Checked == true)
            {
                cbImpresiónMarbete.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = true;
            }
            else if (cbImpresiónMarbete.Checked == false)
            {
                cbImpresiónMarbete.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }


            if (cbPolizaDespachada.Checked == true)
            {
                cbPolizaDespachada.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbPolizaDespachada.Checked == false)
            {
                cbPolizaDespachada.ForeColor = System.Drawing.Color.Red;

            }

        }
        private void ConfiguracionInicial() {
            cbClienteCreadoEditar.ForeColor = System.Drawing.Color.Green;
            cbClienteCreadoEditar.Checked = true;
            cbClienteCreadoEditar.Enabled = false;

            cbDocumentosRevisados.ForeColor = System.Drawing.Color.Red;
            cbEmisionPoliza.ForeColor = System.Drawing.Color.Red;
            cbSegundaRevision.ForeColor = System.Drawing.Color.Red;
            cbImpresiónMarbete.ForeColor = System.Drawing.Color.Red;
            cbPolizaDespachada.ForeColor = System.Drawing.Color.Red;

            cbClienteCreadoEditar.Enabled = false;
            cbDocumentosRevisados.Enabled = true;
            cbEmisionPoliza.Enabled = false;
            cbSegundaRevision.Enabled = false;
            cbImpresiónMarbete.Enabled = false;
            cbPolizaDespachada.Enabled = false;

            DIVBloqueConsulta.Visible = true;
            DIVBloqueNuevoRegistro.Visible = false;
            DIVSeguimientoCaso.Visible = false;

            txtNumeroRegistroConsulyta.Text = string.Empty;
            txtCodigoClienteConsulta.Text = string.Empty;
            txtNombreClienteConsulta.Text = string.Empty;
            txtPolizaconsulta.Text = string.Empty;
            txtCodigoIntermediarioConsulta.Text = string.Empty;
            txtNombreIntermediarioConsulta.Text = string.Empty;
            txtCodigoSupervisorConsulta.Text = string.Empty;
            txtNombreSupervisorConsulta.Text = string.Empty;
            rpProcesoEmisionEncabezado.DataSource = null;
            rpProcesoEmisionEncabezado.DataBind();
            CurrentPage_Header = 0;
            CargarListasDesplegables();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "SEGUIMIENTO DE EMISION DE POLIZA";
                ConfiguracionInicial();



            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            MostrarCabecera();
        }

        protected void btnRestablecerPantalla_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicial();
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DIVBloqueNuevoRegistro.Visible = true;
            DIVSeguimientoCaso.Visible = false;
            txtCodigoClienteNuevoRegistro.Text = string.Empty;
            txtNombreClienteNuevoRegistro.Text = string.Empty;
        }

        protected void btnEditarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;

            var NumeroRegistro = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroRegistroEncabezado")).Value.ToString();
            var NumeroConector = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroConectorEncabezado")).Value.ToString();

            var BuscarInformacion = ObjDataProcesos.Value.BuscaProcesoEmisionHeader(
                Convert.ToDecimal(NumeroRegistro),
                NumeroConector,
                null, null, null, null, null, null);
            foreach (var n in BuscarInformacion) {

                txtNumeroregistroEditar.Text = n.NumeroRegistro.ToString();
                txtClienteEditar.Text = n.CodigoCliente.ToString();
                txtNombreEditar.Text = n.Cliente;
                txtPolizaEditar.Text = n.Poliza;
                cbClienteCreadoEditar.Checked = (n.ClienteCreado0.HasValue ? n.ClienteCreado0.Value : false);
                cbDocumentosRevisados.Checked = (n.DocumentosEntregadoATecnico0.HasValue ? n.DocumentosEntregadoATecnico0.Value : false);
                if (cbDocumentosRevisados.Checked == true)
                {
                    cbDocumentosRevisados.ForeColor = System.Drawing.Color.Green;
                    cbClienteCreadoEditar.Enabled = false;
                    cbDocumentosRevisados.Enabled = false;
                    cbEmisionPoliza.Enabled = true;
                    cbSegundaRevision.Enabled = false;
                    cbImpresiónMarbete.Enabled = false;
                    cbPolizaDespachada.Enabled = false;
                }

                cbEmisionPoliza.Checked = (n.PolizaEmitida0.HasValue ? n.PolizaEmitida0.Value : false);
                if (cbEmisionPoliza.Checked == true)
                {
                    cbEmisionPoliza.ForeColor = System.Drawing.Color.Green;
                    cbClienteCreadoEditar.Enabled = false;
                    cbDocumentosRevisados.Enabled = false;
                    cbEmisionPoliza.Enabled = false;
                    cbSegundaRevision.Enabled = true;
                    cbImpresiónMarbete.Enabled = false;
                    cbPolizaDespachada.Enabled = false;
                }

                cbSegundaRevision.Checked = (n.SegundaRevision0.HasValue ? n.SegundaRevision0.Value : false);
                if (cbSegundaRevision.Checked == true)
                {
                    cbSegundaRevision.ForeColor = System.Drawing.Color.Green;
                    cbClienteCreadoEditar.Enabled = false;
                    cbDocumentosRevisados.Enabled = false;
                    cbEmisionPoliza.Enabled = false;
                    cbSegundaRevision.Enabled = false;
                    cbImpresiónMarbete.Enabled = true;
                    cbPolizaDespachada.Enabled = false;
                }

                cbImpresiónMarbete.Checked = (n.ImpresionMarbete0.HasValue ? n.ImpresionMarbete0.Value : false);
                if (cbImpresiónMarbete.Checked == true)
                {
                    cbImpresiónMarbete.ForeColor = System.Drawing.Color.Green;
                    cbClienteCreadoEditar.Enabled = false;
                    cbDocumentosRevisados.Enabled = false;
                    cbEmisionPoliza.Enabled = false;
                    cbSegundaRevision.Enabled = false;
                    cbImpresiónMarbete.Enabled = false;
                    cbPolizaDespachada.Enabled = true;
                }

                cbPolizaDespachada.Checked = (n.Despachada0.HasValue ? n.Despachada0.Value : false);

                if (cbPolizaDespachada.Checked == true)
                {
                    cbPolizaDespachada.ForeColor = System.Drawing.Color.Green;
                    cbClienteCreadoEditar.Enabled = false;
                    cbDocumentosRevisados.Enabled = false;
                    cbEmisionPoliza.Enabled = false;
                    cbSegundaRevision.Enabled = false;
                    cbImpresiónMarbete.Enabled = false;
                    cbPolizaDespachada.Enabled = false;
                }
            }
            lbNumeroConectorEditar.Text = NumeroConector;
            DIVBloqueConsulta.Visible = false;
            DIVBloqueNuevoRegistro.Visible = false;
            DIVSeguimientoCaso.Visible = true;
            MostrarDetail(lbNumeroConectorEditar.Text);
        }

        protected void btnPrimeraPaginaHeader_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            MostrarCabecera();
        }

        protected void btnPaginaAnteriorHeader_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header += -1;
            MostrarCabecera();
            MoverValoresPaginacion_Header((int)OpcionesPaginacionValores_Header.PaginaAnterior, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void dtPaginacionListadoPrincipalHeader_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalHeader_CancelCommand(object source, DataListCommandEventArgs e)
        {

            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Header = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarCabecera();
        }

        protected void btnSiguientePaginaHeader_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header += 1;
            MostrarCabecera();

        }

        protected void btnUltimaPaginaHeader_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarCabecera();
            MoverValoresPaginacion_Header((int)OpcionesPaginacionValores_Header.UltimaPagina, ref lbPaginaActual, ref lbCantidadPagina);
        }

        protected void btnGaurdarNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            //VALIDAR EL CODIGO DE CLIENTE INGRESADO
            var ValidarCliente = ObjDataComun.Value.SacarNombreCliente(txtCodigoClienteNuevoRegistro.Text);
            if (ValidarCliente.Count() < 1) {
                ClientScript.RegisterStartupScript(GetType(), "CodigoCLienteNoValido()", "CodigoCLienteNoValido();", true);
            }
            else {
                string NumeroConectorGenerado = GenerarNumeroConector();
                //GUARDAMOS EL REGISTRO
                ProcesarInformacionHeader(
                    0,
                    NumeroConectorGenerado,
                    Convert.ToDecimal(txtCodigoClienteNuevoRegistro.Text),
                    false,
                    false,
                    false,
                    false,
                    false,
                    "INSERT");

                ProcesarInformacionDetail(
                    NumeroConectorGenerado,
                    0,
                    (int)EstatusProcesoEmisiion.CreacionRegistro);
                ProcesarInformacionDetail(
                    NumeroConectorGenerado,
                    0,
                    (int)EstatusProcesoEmisiion.CreacionCliente);
                ConfiguracionInicial();
            }
        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicial();
        }

        protected void txtCodigoClienteNuevoRegistro_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoClienteNuevoRegistro.Text.Trim())) { }
            else {
                UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente NombreCliente = new Logica.Comunes.ESacarNombreCliente(txtCodigoClienteNuevoRegistro.Text);
                txtNombreClienteNuevoRegistro.Text = NombreCliente.SacarCodigoCLiente();
            }
        }

        protected void btnEditarRegistro_Click1(object sender, ImageClickEventArgs e)
        {

            //MODICIAR LOS DATOS
            ProcesarInformacionHeader(
                Convert.ToDecimal(txtNumeroregistroEditar.Text),
                lbNumeroConectorEditar.Text,
                0,
                cbDocumentosRevisados.Checked,
                cbEmisionPoliza.Checked,
                cbSegundaRevision.Checked,
                cbImpresiónMarbete.Checked,
                cbPolizaDespachada.Checked,
                "UPDATE");

            //GUARDAMOS LOS LOG
            int EstatusProceso = 0;
            if (cbDocumentosRevisados.Checked == true) {

                EstatusProceso = (int)EstatusProcesoEmisiion.RecepcionDocumentos;
                //validamos si este campo ya esta registrado
                var ValidarDocumentosRevisados = ObjDataProcesos.Value.BuscaProcesoEmisionDetail(
                    lbNumeroConectorEditar.Text,
                    null,
                    EstatusProceso);

                if (ValidarDocumentosRevisados.Count() < 1) {
                    ProcesarInformacionDetail(
                        lbNumeroConectorEditar.Text,
                        0,
                        EstatusProceso);
                }
            }
            if (cbEmisionPoliza.Checked == true) {
                EstatusProceso = (int)EstatusProcesoEmisiion.EmisionPoliza;
                //validamos si este campo ya esta registrado
                var ValidarEmisionPoliza = ObjDataProcesos.Value.BuscaProcesoEmisionDetail(
                    lbNumeroConectorEditar.Text,
                    null,
                    EstatusProceso);

                if (ValidarEmisionPoliza.Count() < 1)
                {
                    ProcesarInformacionDetail(
                        lbNumeroConectorEditar.Text,
                        0,
                        EstatusProceso);
                }
            }
            if (cbSegundaRevision.Checked == true) {
                EstatusProceso = (int)EstatusProcesoEmisiion.SegundaRevision;
                //validamos si este campo ya esta registrado
                var ValidarSegundaRevision = ObjDataProcesos.Value.BuscaProcesoEmisionDetail(
                    lbNumeroConectorEditar.Text,
                    null,
                    EstatusProceso);

                if (ValidarSegundaRevision.Count() < 1)
                {
                    ProcesarInformacionDetail(
                        lbNumeroConectorEditar.Text,
                        0,
                        EstatusProceso);
                }
            }
            if (cbImpresiónMarbete.Checked == true) {
                EstatusProceso = (int)EstatusProcesoEmisiion.ImpresionMarbete;
                //validamos si este campo ya esta registrado
                var ValidarImpresionMarbete = ObjDataProcesos.Value.BuscaProcesoEmisionDetail(
                    lbNumeroConectorEditar.Text,
                    null,
                    EstatusProceso);

                if (ValidarImpresionMarbete.Count() < 1)
                {
                    ProcesarInformacionDetail(
                        lbNumeroConectorEditar.Text,
                        0,
                        EstatusProceso);
                }
            }
            if (cbPolizaDespachada.Checked == true) {
                EstatusProceso = (int)EstatusProcesoEmisiion.Despacho;
                //validamos si este campo ya esta registrado
                var ValidarDespacho = ObjDataProcesos.Value.BuscaProcesoEmisionDetail(
                    lbNumeroConectorEditar.Text,
                    null,
                    EstatusProceso);

                if (ValidarDespacho.Count() < 1)
                {
                    ProcesarInformacionDetail(
                        lbNumeroConectorEditar.Text,
                        0,
                        EstatusProceso);
                }
            }
            ClientScript.RegisterStartupScript(GetType(), "ProcesoCompletado()", "ProcesoCompletado();", true);
            ConfiguracionInicial();
        }

        protected void btnColverAtrasEditarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicial();
        }

        protected void cbDocumentosRevisados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDocumentosRevisados.Checked == true) {
                cbDocumentosRevisados.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = true;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbDocumentosRevisados.Checked == false) {
                cbDocumentosRevisados.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
        }

        protected void cbEmisionPoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEmisionPoliza.Checked == true)
            {
                cbEmisionPoliza.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = true;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbEmisionPoliza.Checked == false)
            {
                cbEmisionPoliza.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
        }

        protected void cbSegundaRevision_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSegundaRevision.Checked == true)
            {
                cbSegundaRevision.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = true;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbSegundaRevision.Checked == false)
            {
                cbSegundaRevision.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
        }

        protected void cbImpresiónMarbete_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImpresiónMarbete.Checked == true)
            {
                cbImpresiónMarbete.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = true;
            }
            else if (cbImpresiónMarbete.Checked == false)
            {
                cbImpresiónMarbete.ForeColor = System.Drawing.Color.Red;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
        }

        protected void cbPolizaDespachada_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPolizaDespachada.Checked == true)
            {
                cbPolizaDespachada.ForeColor = System.Drawing.Color.Green;
                cbClienteCreadoEditar.Enabled = false;
                cbDocumentosRevisados.Enabled = false;
                cbEmisionPoliza.Enabled = false;
                cbSegundaRevision.Enabled = false;
                cbImpresiónMarbete.Enabled = false;
                cbPolizaDespachada.Enabled = false;
            }
            else if (cbPolizaDespachada.Checked == false)
            {
                cbPolizaDespachada.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void btnPrimeraPaginaDetalle_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Detail = 0;
            MostrarDetail(lbNumeroConectorEditar.Text);
        }

        protected void btnPaginaAnteriorDetalle_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Detail += -1;
            MostrarDetail(lbNumeroConectorEditar.Text);
            MoverValoresPaginacion_Detail((int)OpcionesPaginacionValores_Detail.PaginaAnterior, ref lbPaginaActualDetalle, ref lbCantidadPaginaDetalle);
        }

        protected void dtPaginacionListadoPrincipalDetalle_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalDetalle_CancelCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Detail = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarDetail(lbNumeroConectorEditar.Text);
        }

        protected void btnSiguientePaginaDetalle_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Detail += 1;
            MostrarDetail(lbNumeroConectorEditar.Text);
        }

        protected void txtCodigoClienteConsulta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoClienteConsulta.Text.Trim())) { }
            else {
                UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente NombreCliente = new Logica.Comunes.ESacarNombreCliente(txtCodigoClienteConsulta.Text);
                txtNombreClienteConsulta.Text = NombreCliente.SacarCodigoCLiente();
            }
        }

        protected void txtCodigoIntermediarioConsulta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim())) { }
            else
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreIntermediario = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioConsulta.Text);
                txtNombreIntermediarioConsulta.Text = NombreIntermediario.SacarNombreIntermediario();
            }
        }

        protected void txtCodigoSupervisorConsulta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoSupervisorConsulta.Text.Trim())) { }
            else
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor NombreSupervisor = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisorConsulta.Text);
                txtNombreSupervisorConsulta.Text = NombreSupervisor.SacarNombreSupervisor();
            }
        }

        protected void btnUltimaPaginaDetalle_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Detail = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarDetail(lbNumeroConectorEditar.Text);
            MoverValoresPaginacion_Detail((int)OpcionesPaginacionValores_Detail.UltimaPagina, ref lbPaginaActual, ref lbCantidadPagina);
        }
    }
}
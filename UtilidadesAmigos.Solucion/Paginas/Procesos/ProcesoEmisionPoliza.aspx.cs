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

        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicial();
        }

        protected void txtCodigoClienteNuevoRegistro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditarRegistro_Click1(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnColverAtrasEditarRegistro_Click(object sender, ImageClickEventArgs e)
        {

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

        }

        protected void btnPaginaAnteriorDetalle_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalDetalle_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipalDetalle_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePaginaDetalle_Click(object sender, ImageClickEventArgs e)
        {

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

        }
    }
}
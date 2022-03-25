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
    public partial class ReporteProduccion : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDAtaGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjDataReportes = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        enum TipoAgrupacion { 
        
            Concepto=1,
            Usuario=2,
            Oficina=3,
            Ramo=4,
            Intermediario=5,
            Supervisor=6,
            Moneda=7
        }

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


        private void HandlePaging(ref DataList NombreDataList, ref Label lbPaginaActual)
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
            lbPaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton PaginaSiguiente, ref ImageButton UltimaPagina)
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
            PaginaSiguiente.Enabled = !pagedDataSource.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource.IsLastPage;

            RptGrid.DataSource = pagedDataSource;
            RptGrid.DataBind();


            //  divPaginacionBancos.Visible = true;
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label CantidadPagina)
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
                    lbPaginaActual.Text = CantidadPagina.Text;
                    break;


            }

        }
        #endregion

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void ListasOficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjDAtaGeneral.Value.BuscaListas("OFICINAS", null, null), true);
        }
        private void ListasRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDAtaGeneral.Value.BuscaListas("RAMO", null, null), true);
        }
        private void ListaSubRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubRamo, ObjDAtaGeneral.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamo.SelectedValue.ToString(), null), true);
        }
        private void ListaUsuarios() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjDAtaGeneral.Value.BuscaListas("USUARIOSFACTURACION", null, null), true);
        }
        private void ListaMonedas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMoneda, ObjDAtaGeneral.Value.BuscaListas("MONEDA", null, null), true);
        }
        private void ListaCOnceptos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCOncepto, ObjDAtaGeneral.Value.BuscaListas("CONCEPTOS", null, null), true);
        }
        private void ListaDesplegables() {
            ListasOficinas();
            ListasRamos();
            ListaSubRamo();
            ListaUsuarios();
            ListaMonedas();
            ListaCOnceptos();
        }
        #endregion

        #region MOSTRAR LA PRODUCCION
        private void MostrarProduccion() {

            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAcios()", "CamposFechaVAcios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else {

                int? _Intermediario = string.IsNullOrEmpty(txtCodIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodIntermediario.Text);
                int? _Supervisor = string.IsNullOrEmpty(txtCodSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodSupervisor.Text);
                int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                string _Concepto = ddlSeleccionarCOncepto.SelectedValue != "-1" ? ddlSeleccionarCOncepto.SelectedItem.Text : null;
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
                string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
                decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);


                var Listado = ObjDataReportes.Value.BuscarDatosProduccion(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Intermediario,
                    _Supervisor,
                    _Oficina,
                    _Ramo,
                    _SubRamo,
                    _Usuario,
                    _Poliza,
                    _NumeroFactura,
                    _Moneda,
                    null,
                    _Concepto,
                    (decimal)Session["IdUsuario"]);
                Paginar(ref rpListadoProduccion, Listado, 10, ref lbCantidadPaginaVAriableProduccion, ref btnPrimeraPaginaPaginacion, ref btnPaginaAnteriorPaginacion, ref btnPaginaSiguientePaginacion, ref btnUltimaPaginaPaginacion);
                HandlePaging(ref dtPaginacionPolizasProduccion, ref lbPaginaActualVariableProduccion);

            }

        }
        #endregion

        #region GENERAR REPORTE

        enum TiposAgrupaciones {

            CONCEPTO =1,
            USUARIO=2,
            OFICINA=3,
            RAMO=4,
            INTERMEDIARIO=5,
            SUPERVISOR=6,
            MONEDA=7
        }

        private void GenerarReporteAgrupado(int TipoAgrupacion,string Nombre) {

            int? _Intermediario = string.IsNullOrEmpty(txtCodIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodIntermediario.Text);
            int? _Supervisor = string.IsNullOrEmpty(txtCodSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodSupervisor.Text);
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
            string _Concepto = ddlSeleccionarCOncepto.SelectedValue != "-1" ? ddlSeleccionarCOncepto.SelectedItem.Text : null;
            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
            string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
            decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);

            var ReporteAgrupado = ObjDataReportes.Value.BuscaDatosProduccionAgrupada(
                Convert.ToDateTime(txtFechaDesde.Text),
                Convert.ToDateTime(txtFechaHasta.Text),
                _Intermediario,
                _Supervisor,
                _Oficina,
                _Ramo,
                _SubRamo,
                _Usuario,
                _Poliza,
                _NumeroFactura,
                _Moneda,
                null,
                _Concepto,
                (decimal)Session["IdUSuario"],
                TipoAgrupacion);
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Producción Agrupado Por" + " " + Nombre, ReporteAgrupado);
        }
        private void GenerarReporte(string NombreReporte) {

            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVAcios()", "CamposFechaVAcios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else
            {

                int? _Intermediario = string.IsNullOrEmpty(txtCodIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodIntermediario.Text);
                int? _Supervisor = string.IsNullOrEmpty(txtCodSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodSupervisor.Text);
                int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
                int? _SubRamo = ddlSeleccionarSubRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamo.SelectedValue) : new Nullable<int>();
                string _Concepto = ddlSeleccionarCOncepto.SelectedValue != "-1" ? ddlSeleccionarCOncepto.SelectedItem.Text : null;
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                int? _Moneda = ddlSeleccionarMoneda.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarMoneda.SelectedValue) : new Nullable<int>();
                string _Usuario = ddlSeleccionarUsuario.SelectedValue != "-1" ? ddlSeleccionarUsuario.SelectedItem.Text : null;
                decimal? _NumeroFactura = string.IsNullOrEmpty(txtNumeroDocumento.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroDocumento.Text);

                if (rbExcelPlano.Checked == true)
                {

                    if (rbNoAgruparDatos.Checked == true)
                    {

                        if (rbReporteDetallado.Checked == true)
                        {
                            var ExportarDetalle = (from n in ObjDataReportes.Value.BuscarDatosProduccion(
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                _Intermediario,
                                _Supervisor,
                                _Oficina,
                                _Ramo,
                                _SubRamo,
                                _Usuario,
                                _Poliza,
                                _NumeroFactura,
                                _Moneda,
                                null,
                                _Concepto,
                                (decimal)Session["IdUsuario"])
                                                   select new
                                                   {
                                                       Poliza = n.Poliza,
                                                       Ramo = n.Ramo,
                                                       SubRamo = n.SubRamo,
                                                       Codigo_Cliente = n.Cliente,
                                                       NombreCliente = n.NombreCliente,
                                                       Codigo_Intermediario = n.Vendedor,
                                                       NombreVendedor = n.NombreVendedor,
                                                       Codigo_Supervisor = n.CodigoSupervisor,
                                                       Supervisor = n.Supervisor,
                                                       Usuario = n.Usuario,
                                                       NombreOficina = n.NombreOficina,
                                                       FechaSinFormato = n.Fecha,
                                                       FechaFactura = n.FechaFactura,
                                                       HoraFactura = n.HoraFactura,
                                                       Numero_Comprobante = n.Ncf,
                                                       MontoBruto = n.MontoBruto,
                                                       ISC = n.ISC,
                                                       MontoNeto = n.MontoNeto,
                                                       Moneda = n.Moneda,
                                                       Factura_Sin_Formato = n.Factura,
                                                       NumeroFactura = n.NumeroFactura,
                                                       Concepto = n.Concepto,
                                                       GeneradoPor = n.GeneradoPor
                                                   }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreReporte + " " + "Detallado", ExportarDetalle);




                        }
                        else if (rbReporteResumido.Checked == true) {

                            var ProduccionResumida = (from n in ObjDataReportes.Value.BuscarDatosProduccionResumido(
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                _Intermediario,
                                _Supervisor,
                                _Oficina,
                                _Ramo,
                                _SubRamo,
                                _Usuario,
                                _Poliza,
                                _NumeroFactura,
                                _Moneda,
                                null,
                                _Concepto,
                                (decimal)Session["IdUsuario"])
                                                      select new
                                                      {
                                                          CodigoSupervisor = n.CodigoSupervisor,
                                                          Supervisor = n.Supervisor,
                                                          Ramo = n.Ramo,
                                                          Vendedor = n.Vendedor,
                                                          Intermediario = n.Intermediario,
                                                          Moneda = n.Moneda,
                                                          MontoBruto = n.MontoBruto,
                                                          ISC = n.ISC,
                                                          MontoNeto = n.MontoNeto,
                                                          GeneradoPor = n.GeneradoPor
                                                      }).ToList();
                            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreReporte + " " + "Resumido", ProduccionResumida);
                        }
                    }
                    else if (rbAgruparPorConcepto.Checked == true) {

                        GenerarReporteAgrupado((int)TipoAgrupacion.Concepto, "Concepto");
                    }
                    else if (rbAgruparPorUsuario.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Usuario, "Usuario");
                    }
                    else if (rbAgruparPorOficina.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Oficina, "Oficina");
                    }
                    else if (rbAgruparPorRamo.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Ramo, "Ramo");
                    }
                    else if (rbAgruparPorIntermediario.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Intermediario, "Intermediario");
                    }
                    else if (rbAgruparPorSupervisor.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Supervisor, "Supervisor");
                    }
                    else if (rbAgruparPorMoneda.Checked == true) {
                        GenerarReporteAgrupado((int)TipoAgrupacion.Moneda, "Moneda");
                    }

                }
                else { }


            }

           
        }
        #endregion


        #region VALIDAR LOS CONTROLES DE VALIDACION
        private void LimpiarCOntrolesValidacion()
        {
            lbFechaDesdeValidacion.Text = "0";
            lbFechaHastaValidacion.Text = "0";
            lbTasaValidacion.Text = "0";
        }
        private bool ValidacionControles(string FechaDesdeEntrada, string FechaHastaEntrada, string TasaEntrada)
        {
            bool Validacion = false;

            string FechaDesdeValidar = "", FechaHastaValidar = "", TasaValidar = "";


            FechaDesdeValidar = lbFechaDesdeValidacion.Text;
            FechaHastaValidar = lbFechaHastaValidacion.Text;
            TasaValidar = lbTasaValidacion.Text;

            if (FechaDesdeValidar == FechaDesdeEntrada &&
                FechaHastaValidar == FechaHastaEntrada &&
                TasaValidar == TasaEntrada)
            {
                Validacion = true;
            }
            else
            {
                Validacion = false;
            }
            return Validacion;
        }

        private void PasarParametrosValidacion()
        {
            string FechaDesde = "", FechaHasta = "", Tasa = "";

            FechaDesde = txtFechaDesde.Text;
            FechaHasta = txtFechaHasta.Text;


            if (string.IsNullOrEmpty(txtTasa.Text.Trim()))
            {
                Tasa = "0";
            }
            else
            {
                Tasa = txtTasa.Text;
            }
            Tasa = txtTasa.Text;
            lbFechaDesdeValidacion.Text = FechaDesde;
            lbFechaHastaValidacion.Text = FechaHasta;
            lbTasaValidacion.Text = Tasa;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                rbNoAgruparDatos.Checked = true;
                rbReporteDetallado.Checked = true;
                rbPDF.Checked = true;

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR REPORTE DE PRODUCCION";

                ListaDesplegables();

                decimal Tasa = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2);
                txtTasa.Text = Tasa.ToString();
            }
        }

        protected void rbNoAgruparDatos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoAgruparDatos.Checked == true) {
                DIVTipoReporte.Visible = true;
                rbReporteDetallado.Checked = true;
            }
            else if (rbNoAgruparDatos.Checked == false) {
                DIVTipoReporte.Visible = false;
                rbReporteDetallado.Checked = true;
            }
        }

        protected void txtCodIntermediario_TextChanged(object sender, EventArgs e)
        {
            string NombreIntermediario = "";
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodIntermediario.Text);
            NombreIntermediario = Nombre.SacarNombreIntermediario();
            txtNombreIntermediario.Text = NombreIntermediario;
        }

        protected void txtCodSupervisor_TextChanged(object sender, EventArgs e)
        {
            string NombreSupervisor = "";
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodSupervisor.Text);
            NombreSupervisor = Nombre.SacarNombreIntermediario();
            txtNombreSupervisor.Text = NombreSupervisor;
        }

        protected void ddlSeleccionarRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaSubRamo();
        }

        protected void btnBuscarInformacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarProduccion();
        }

        protected void btnReporteProduccion_Click(object sender, ImageClickEventArgs e)
        {
            GenerarReporte("Reporte de Producción");
        }

        protected void dtPaginacionPolizasProduccion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionPolizasProduccion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarProduccion();
        }

        protected void rbAgruparPorConcepto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorConcepto.Checked == true)
            {

                //DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
             //   DIVRecargarData.Visible = true;
              //  cbRecargarData.Checked = false;
            }
            else {
             //   DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
           //     DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorUsuario.Checked == true)
            {

            //    DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
           //     DIVRecargarData.Visible = true;
             //   cbRecargarData.Checked = false;
            }
            else
            {
              //  DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
             //   DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorOficina_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorOficina.Checked == true)
            {

               // DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
              //  DIVRecargarData.Visible = true;
               // cbRecargarData.Checked = false;
            }
            else
            {
               // DIVTipoReporteGenerar.Visible = true;
              //  HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorRamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorRamo.Checked == true)
            {

              //  DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
             //   DIVRecargarData.Visible = true;
              //  cbRecargarData.Checked = false;
            }
            else
            {
             //   DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorIntermediario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorIntermediario.Checked == true)
            {

              //  DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
               //DIVRecargarData.Visible = true;
               // cbRecargarData.Checked = false;
            }
            else
            {
               // DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorSupervisor.Checked == true)
            {

               // DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
               // DIVRecargarData.Visible = true;
              //  cbRecargarData.Checked = false;
            }
            else
            {
               // DIVTipoReporteGenerar.Visible = true;
              //  HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void rbAgruparPorMoneda_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgruparPorMoneda.Checked == true)
            {

                //DIVTipoReporteGenerar.Visible = false;
                //HRSeparadorTipoReporte.Visible = false;
               // DIVRecargarData.Visible = true;
               // cbRecargarData.Checked = false;
            }
            else
            {
               // DIVTipoReporteGenerar.Visible = true;
               // HRSeparadorTipoReporte.Visible = true;
              //  DIVRecargarData.Visible = false;
            }
        }

        protected void btnPrimeraPaginaPaginacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarProduccion();
        }

        protected void btnPaginaAnteriorPaginacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += -1;
            MostrarProduccion();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableProduccion, ref lbCantidadPaginaVAriableProduccion);
        }

        protected void btnPaginaSiguientePaginacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage += 1;
            MostrarProduccion();
        }

        protected void btnUltimaPaginaPaginacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarProduccion();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.UltimaPagina, ref lbPaginaActualVariableProduccion, ref lbCantidadPaginaVAriableProduccion);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.SuperIntendencia
{
    public partial class ConsultaPersonas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuperIntendencia.LogicaSuperIntendencia> ObjDataSuperIntendencia = new Lazy<Logica.Logica.LogicaSuperIntendencia.LogicaSuperIntendencia>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataSistema = new Lazy<Logica.Logica.LogicaSistema>();

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


            divPaginacionCliente.Visible = true;
            DivPaginacionIntermediario.Visible = true;
            OcultarDetalle();
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

        private void OcultarDetalle() {
            DivBloqueDetalleCliente.Visible = false;
            DivDetalleInformacionIntermediarioSeleccionado.Visible = false;
            DivDetalleProveedores.Visible = false;
            DivDetalleAsegurado.Visible = false;
            DivDetalleAseguradoGeneral.Visible = false;
            DivDetalleDependientes.Visible = false;
        }

        private void MostrarListadoClientes(int ReportePreciso)
        {
            string _Numeroidentificacion = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();
            string _Nombre = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();
            string _Placa = string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()) ? null : txtPlacaConsulta.Text.Trim();
            string _Chasis = string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()) ? null : txtChasisConsulta.Text.Trim();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();

            var BuscarListado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaCliente(
                _Numeroidentificacion,
                _Nombre,
                _Chasis,
                _Placa,
                _Ramo,
                null,null,null,
                ReportePreciso);
            if (BuscarListado.Count() < 1)
            {
                lbCantidadRegistrosClienteVariable.Text = "NO";
                lbCantidadRegistrosClienteVariable.ForeColor = System.Drawing.Color.Red;
                rpListadoBusquedaCliente.DataSource = null;
                rpListadoBusquedaCliente.DataBind();
            }
            else
            {
                lbCantidadRegistrosClienteVariable.Text = "SI";
                lbCantidadRegistrosClienteVariable.ForeColor = System.Drawing.Color.Green;

                Paginar(ref rpListadoBusquedaCliente, BuscarListado, 10, ref lbCantidadPaginaVAriableCliente, ref LinkPrimeraPaginaCliente, ref LinkAnteriorCliente, ref LinkSiguienteCliente, ref LinkUltimoCliente);
                HandlePaging(ref dtPaginacionCliente, ref lbPaginaActualVariavleCliente);
                divPaginacionCliente.Visible = true;
            }
        }

        private void MostrarListadoIntermediarios() {
            string _NumeroIdentificacion = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();
            string _Nombre = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();

            var Listado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaIntermediario(
                new Nullable<int>(),
                _NumeroIdentificacion,
                _Nombre);
            if (Listado.Count() < 1)
            {
                lbCantidadIntermediariosSupervisorVariable.Text = "NO";
                lbCantidadIntermediariosSupervisorVariable.ForeColor = System.Drawing.Color.Red;
            }
            else {
                lbCantidadIntermediariosSupervisorVariable.ForeColor = System.Drawing.Color.Green;
                lbCantidadIntermediariosSupervisorVariable.Text = "SI";
                Paginar(ref rpListadoIntermediarios, Listado, 10, ref lbCantidadPaginaVAriableIntermedairaio, ref LinkPrimeroIntermediario, ref LinkAnteriorIntermediario, ref LinkSiguienteCliente, ref LinkUltimoIntermediario);
                HandlePaging(ref dtIntermediario, ref lbPaginaActualVariavleIntermediario);
                DivPaginacionIntermediario.Visible = true;
            }
        }
        private void SeleccionarRegistrosClientes(string Poliza, decimal Cotizacion, decimal Secuencia, int ReportePreciso) {


            var BuscarRegistroSeleccionado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaCliente(
                null,
                null,
                null,
                null,
                null,
                Poliza,
                Cotizacion,
                Secuencia,
                ReportePreciso);
            Paginar(ref rpListadoBusquedaCliente, BuscarRegistroSeleccionado, 1, ref lbCantidadPaginaVAriableCliente, ref LinkPrimeraPaginaCliente, ref LinkAnteriorCliente, ref LinkSiguienteCliente, ref LinkUltimoCliente);
            HandlePaging(ref dtPaginacionCliente, ref lbPaginaActualVariavleCliente);
            DivBloqueDetalleCliente.Visible = true;
            foreach (var n in BuscarRegistroSeleccionado) {
                txtNombreDetalleCliente.Text = n.Nombre;
                txtENCDetalleCliente.Text = n.NumeroIdentificacion;
                txtRamoDetalleCliente.Text = n.Ramo;
                txtNombreVendedorDetalleCliente.Text = n.NombreVendedor;
                txtRNCVendedorDetalleCliente.Text = n.RNCIntermediario;
                txtLicenciaDetalleVendedor.Text = n.LicenciaSeguro;
                txttipoVehiculoDetalleCliente.Text = n.TipoVehiculo;
                txtMarcaDetalleCliente.Text = n.Marca;
                txtModeloDetalleCliente.Text = n.Modelo;
                txtAnoDetalleCliente.Text = n.Ano;
                txtPalcaDetalleCliente.Text = n.Placa;
                txtCiasusDetalleCliente.Text = n.Chasis;
                txtColorDetalleCliente.Text = n.Color;
                decimal MontoAsegurado = (decimal)n.MontoAsegurado;
                txtMontoAseguradoDetalleCliente.Text = MontoAsegurado.ToString("N2");
                decimal Prima = (decimal)n.Prima;
                txtPrimaDetalleCliente.Text = Prima.ToString("N2");
                txtInicioVigenciaDetalleCliente.Text = n.InicioVigencia;
                txtFinVigenciaDetalleCliente.Text = n.FinVigencia;
                txtPolizaDetalleCliente.Text = n.poliza;
                DivBloqueDetalleCliente.Visible = true;
            }
            //MOSTRAR DETALLE
        }

        private void MostrarListadoProveedores() {
            string _NombreProveedor = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();
            string _RNC = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();

            var Listado = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaProveedor(
                new Nullable<int>(),
                _NombreProveedor,
                _RNC);
            if (Listado.Count() < 1)
            {
                lbCantidadProveedorVariable.Text = "NO";
                lbCantidadProveedorVariable.ForeColor = System.Drawing.Color.Red;
            }
            else {
                lbCantidadProveedorVariable.Text = "SI";
                lbCantidadProveedorVariable.ForeColor = System.Drawing.Color.Green;
                Paginar(ref rpListadoProveedores, Listado, 10, ref lbCantidadPaginaVAriableProveedor, ref LinkPrimeroProveedor, ref LinkAnteriorProveedor, ref LinkSiguienteProveedor, ref LinkUltimoProveedor);
                HandlePaging(ref dtProveedor, ref lbPaginaActualVariavleProveedor);
                DivPaginacionProveedores.Visible = true;
            }
        }

        private void MostrarListadoAsegurado() {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim())) { }
            else {
                string _NombreAsegurado = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();

                var Buscar = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAsegurado(_NombreAsegurado, null, null, null);
                if (Buscar.Count() < 1)
                {
                    lbCantidadRegistrosAseguradoBajoPolizaVariable.Text = "NO";
                    lbCantidadRegistrosAseguradoBajoPolizaVariable.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbCantidadRegistrosAseguradoBajoPolizaVariable.Text = "SI";
                    lbCantidadRegistrosAseguradoBajoPolizaVariable.ForeColor = System.Drawing.Color.Green;

                    Paginar(ref rpListadoRegistrosasegurado, Buscar, 10, ref lbCantidadPaginaVAriableAsegurado, ref LinkPrimeroAsegurado, ref LinkAnteriorAsegurado, ref LinkSiguienteAsegurado, ref LinkUltimaAsegurado);
                    HandlePaging(ref dtAsegurado, ref lbPaginaActualVariavleAsegurado);
                    DivPaginacionInformacionAsegurado.Visible = true;
                }
            }
        }

        private void MostrarListadoAseguradoGeneral() {
            string _Nombre = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();
            string _NumeroRNC = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();

            var BuscarRegistro = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAseguradoGeneral(
                _Nombre,
                _NumeroRNC,
                null, null, null);
            if (BuscarRegistro.Count() < 1) {
                lbCantidadRegistrosAseguradoVariable.Text = "NO";
                lbCantidadRegistrosAseguradoVariable.ForeColor = System.Drawing.Color.Red;
            }
            else {
                lbCantidadRegistrosAseguradoVariable.Text = "SI";
                lbCantidadRegistrosAseguradoVariable.ForeColor = System.Drawing.Color.Green;

                Paginar(ref rpIDListadoAseguradoGeneral, BuscarRegistro, 10, ref lbCantidadPaginaVAriableAseguradoGeneral, ref LinkPrimeroAseguradoGeneral, ref LinkAnteriorAseguradoGeneral, ref LinkSiguienteAseguradoGeneral, ref LinkUltimoAseguradoGeneral);
                HandlePaging(ref dtAseguradoGeneral, ref lbPaginaActualVariavleAseguradoGeneral);
                DivPaginacionAseguradoGeneral.Visible = true;
            }
        }

        private void MostrarListadoDependientes() {
            string _Nombre = string.IsNullOrEmpty(txtNombre.Text.Trim()) ? null : txtNombre.Text.Trim();
            string _RNC = string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) ? null : txtRNCCedula.Text.Trim();

            var Buscar = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaDependente(
                _Nombre,
                _RNC,
                null, null, null);
            if (Buscar.Count() < 1) {
                lbCantidadRegistrosDependienteVariable.Text = "NO";
                lbCantidadRegistrosDependienteVariable.ForeColor = System.Drawing.Color.Red;
            }
            else {
                lbCantidadRegistrosDependienteVariable.Text = "SI";
                lbCantidadRegistrosDependienteVariable.ForeColor = System.Drawing.Color.Green;

                Paginar(ref rpListadoDependientes, Buscar, 10, ref lbCantidadPaginaVAriableDependiente, ref LinkPrimeroDependiente, ref LinkAnteriorDependiente, ref LinkSiguienteDependiente, ref LinkUltimoDependiente);
                HandlePaging(ref dtDependiente, ref lbPaginaActualVariavleDependiente);
                DivPaginacionDependiente.Visible = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "CONSULTA DE REGISTRO DE PERSONAS";



                rbExportarPDF.Checked = true;
                rbConsultaNormal.Checked = true;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataSistema.Value.BuscaListas("RAMO", null, null), true);
                DivBloqueDetalleCliente.Visible = false;
                DivPaginacionIntermediario.Visible = false;
                DivDetalleInformacionIntermediarioSeleccionado.Visible = false;
                DivPaginacionIntermediario.Visible = false;
                DivPaginacionProveedores.Visible = false;
                DivPaginacionInformacionAsegurado.Visible = false;
                DivPaginacionAseguradoGeneral.Visible = false;
                DivPaginacionDependiente.Visible = false;
            }
        }

        protected void btnSeleccionarRegistrosBusquedaCliente_Click(object sender, EventArgs e)
        {
            var PolizaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaBusquedaCliente")).Value.ToString();

            var CotizacionSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfCotizacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionBusquedaCliente")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfSecuenciaBusquedaCliente")).Value.ToString();

            SeleccionarRegistrosClientes(hfPolizaSeleccionada.ToString(), Convert.ToDecimal(hfCotizacionSeleccionada), Convert.ToDecimal(hfSecuenciaSeleccionada), 1);
            DivBloqueDetalleCliente.Visible = true;
        }

        protected void LinkPrimeraPaginaCliente_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoClientes(1);
        }

        protected void LinkAnteriorCliente_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoClientes(1);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleCliente, ref lbCantidadPaginaVAriableCliente);
        }

        protected void dtPaginacionCliente_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoClientes(1);
        }

        protected void dtPaginacionCliente_ItemDataBound(object sender, DataListItemEventArgs e)
        {
           
        }

        protected void LinkSiguienteCliente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoClientes(1);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (rbConsultaNormal.Checked) {
                if (string.IsNullOrEmpty(txtRNCCedula.Text.Trim()) && string.IsNullOrEmpty(txtNombre.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CamposBusquedaNormalVacio()", "CamposBusquedaNormalVacio();", true);
                }
                else {
                    MostrarListadoClientes(1);
                    MostrarListadoIntermediarios();
                    MostrarListadoProveedores();
                    MostrarListadoAsegurado();
                    MostrarListadoAseguradoGeneral();
                    MostrarListadoDependientes();
                }
            }
            else if (rbConsultaChasisPlaca.Checked) {
                if (string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()) && string.IsNullOrEmpty(txtChasisConsulta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CamposChasisPlacaVacios()", "CamposChasisPlacaVacios();", true);
                }
                else {
                    MostrarListadoClientes(2);
                    //MostrarListadoIntermediarios();
                    //MostrarListadoProveedores();
                }
            }
        }

        protected void btnSeleccionarIntermediarioRepeater_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfCodigoIntermediario = ((HiddenField)ItemSeleccionado.FindControl("hfCodigointermediario")).Value.ToString();

            var BuscarRegistroSeleccionado = ObjDataSuperIntendencia.Value.BuscaPersonasSuperIntendenciaIntermediario(Convert.ToInt32(hfCodigoIntermediario), null, null);
            Paginar(ref rpListadoIntermediarios, BuscarRegistroSeleccionado, 10, ref lbCantidadPaginaVAriableIntermedairaio, ref LinkPrimeroIntermediario, ref LinkAnteriorIntermediario, ref LinkSiguienteCliente, ref LinkUltimoIntermediario);
            HandlePaging(ref dtIntermediario, ref lbPaginaActualVariavleIntermediario);
            DivPaginacionIntermediario.Visible = true;
            foreach (var n in BuscarRegistroSeleccionado) {
                txtBusquedaIntermediarioCodigoDetalle.Text = n.Codigo.ToString();
                txtBusquedaIntermediarioTipoRNCDetalle.Text = n.TipoIdentificacion;
                txtBusquedaIntermediarioNumeroIdentificacionDetalle.Text = n.Rnc;
                txtBusquedaIntermediarioNombreDetalle.Text = n.Nombre;
                txtBusquedaIntermediarioSupervisorDetalle.Text = n.Supervisor;
                txtBusquedaIntermediarioFechaEntradaDetalle.Text = n.FechaEntrada;
                txtBusquedaIntermediarioTelefonoResidenciaDetalle.Text = n.Telefono;
                txtBusquedaIntermediarioTelefonoOficinaDetalle.Text = n.TelefonoOficina;
                txtBusquedaIntermediarioCelularDetalle.Text = n.Celular;
                txtBusquedaIntermediarioLicenciaSeguroDetalle.Text = n.LicenciaSeguro;
                txtBusquedaIntermediarioOficinaDetalle.Text = n.NombreOficina;
                txtBusquedaIntermediarioFechaNacimientoDetalle.Text = n.FechaNacimiento;
                txtBusquedaIntermediarioCuentaBancoDetalle.Text = n.CtaBanco;
                txtBusquedaIntermediarioBancoDetalle.Text = n.Banco;
                txtBusquedaIntermediarioFormaPagoDetalle.Text = n.TipoPago;
                DivDetalleInformacionIntermediarioSeleccionado.Visible = true;
            }
            DivDetalleInformacionIntermediarioSeleccionado.Visible = true;
        }

        protected void LinkPrimeroIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoIntermediarios();
        }

        protected void LinkAnteriorIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoIntermediarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleIntermediario, ref lbCantidadPaginaVAriableIntermedairaio);
        }

        protected void dtIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoIntermediarios();
        }

        protected void dtIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void LinkSiguienteIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoIntermediarios();
        }

        protected void LinkUltimoIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoIntermediarios();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleIntermediario, ref lbCantidadPaginaVAriableIntermedairaio);
        }

        protected void btnSeleccionarRegistroProveedor_Click(object sender, EventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfCodigoProveedor = ((HiddenField)ItemSeleccionado.FindControl("hfCodigoproveedor")).Value.ToString();

            var BuscarRegistros = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaProveedor(
                Convert.ToInt32(hfCodigoProveedor));
            Paginar(ref rpListadoProveedores, BuscarRegistros, 1, ref lbCantidadPaginaVAriableProveedor, ref LinkPrimeroProveedor, ref LinkPrimeroProveedor, ref LinkSiguienteProveedor, ref LinkUltimoProveedor);
            HandlePaging(ref dtProveedor, ref lbPaginaActualVariavleProveedor);
            foreach (var n in BuscarRegistros) {
                txtDetalleProveedorCodigo.Text = n.Codigo.ToString();
                txtDetalleProveedorTipoProveedor.Text = n.TipoCliente;
                txtDetalleProveedorNombre.Text = n.NombreCliente;
                txtDetalleProveedorTipoRNC.Text = n.TipoIdentificacion;
                txtDetalleProveedorRNC.Text = n.Rnc;
                txtDetalleProveedorFechaCreado.Text = n.FechaCreado;
                txtDetalleProveedorTelefonoCasa.Text = n.TelefonoCasa;
                txtDetalleProveedorTelefonoOficina.Text = n.TelefonoOficina;
                txtDetalleProveedorCelular.Text = n.Celular;
                txtDetalleProveedorCuentaBanco.Text = n.CuentaBanco;
                txtDetalleProveedorBanco.Text = n.NombreBanco;
                txtDetalleProbeedorTipoCuentaBAnco.Text = n.TipoCuentaBanco;
                txtDetalleProveedorClaseProveedor.Text = n.ClaseProveedor;
                txtDetalleProveedorFechaUltimoPago.Text = n.FechaUltPago;
                decimal LimiteCredito = (decimal)n.LimiteCredito;
                txtDetalleProveedorLimiteCredito.Text = LimiteCredito.ToString("N2");
                txtDetalleProveedorDireccion.Text = n.Direccion;
                decimal TotalPagado = (decimal)n.ToTalPagado;
                txtDetalleProveedorTotalPagado.Text = TotalPagado.ToString("N2");
                int CantidadSolicitud = (int)n.CantidadSolicitud;
                int CantidadSolicitudCanceladas = (int)n.CantidadSolicitudCanceladas;
                txtDetalleProveedorCantidadSolicitud.Text = CantidadSolicitud.ToString("N0");
                txtDetalleProveedorCantidadSolicitudCanceadas.Text = CantidadSolicitudCanceladas.ToString("N0");
                txtDetalleProveedorUltimaFechaSOlicitud.Text = n.UltimaFechaSolicitud;
                txtDetalleProveedorNumeroSolicitud.Text = n.NoSolicitud.ToString();
                txtDetalleProveedorDescripcionTipoSolciitid.Text = n.DescripcionTipoSolicitud;
                decimal ValorSolicitud = (decimal)n.Valor;
                txtDetalleProveedorValor.Text = ValorSolicitud.ToString("N2");
                txtDetalleProveedorNumeroCheque.Text = n.NumeroCheque.ToString();
                txtDetalleProveedorFechaCheque.Text = n.FechaCheque;
                txtDetalleproveedorUsuario.Text = n.Usuario;
                txtDetalleProveedorConcepto1.Text = n.Concepto1;
                txtDetalleProveedorConcepto2.Text = n.Concepto2;
            }
            DivDetalleProveedores.Visible = true;
        }

        protected void LinkPrimeroProveedor_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoProveedores();
        }

        protected void LinkAnteriorProveedor_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoProveedores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleProveedor, ref lbCantidadPaginaVAriableProveedor);
        }

        protected void dtProveedor_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoProveedores();
        }

        protected void dtProveedor_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void LinkSiguienteProveedor_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoProveedores();
        }

        protected void LinkUltimoProveedor_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoProveedores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleProveedor, ref lbCantidadPaginaVAriableProveedor);
        }

        protected void btnSeleccionarRegistrosInformacionAsegurado_Click(object sender, EventArgs e)
        {
            var PolizaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var HfPolizaSeleccionada = ((HiddenField)PolizaSeleccionada.FindControl("hfPolizaInformacionAsegurado")).Value.ToString();

            var CotizzacionSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var HfCotizzacionSeleccionada = ((HiddenField)CotizzacionSeleccionada.FindControl("hfCotizacionInformacionAsegurado")).Value.ToString();

            var itemSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var HFitemSeleccionado = ((HiddenField)itemSeleccionado.FindControl("hfSecuenciaInformacionAsegurado")).Value.ToString();

            var SacarInformacion = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAsegurado(
                null,
                HfPolizaSeleccionada,
                Convert.ToDecimal(HfCotizzacionSeleccionada),
                Convert.ToInt32(HFitemSeleccionado));
            Paginar(ref rpListadoRegistrosasegurado, SacarInformacion, 1, ref lbCantidadPaginaVAriableAsegurado, ref LinkPrimeroAsegurado, ref LinkAnteriorAsegurado, ref LinkSiguienteAsegurado, ref LinkUltimaAsegurado);
            HandlePaging(ref dtAsegurado, ref lbPaginaActualVariavleAsegurado);
            foreach (var n in SacarInformacion) {
                txtDetalleaseguradoNombre.Text = n.Nombre;
                txtDetalleaseguradoPoliza.Text = n.Poliza;
                txtDetalleaseguradoEstatus.Text = n.Estatus;
                txtDetalleaseguradoitem.Text = n.Item.ToString();
                txtDetalleaseguradoInicioVigencia.Text = n.InicioVigencia;
                txtDetalleaseguradoFinVigencia.Text = n.FinVigencia;
                txtDetalleaseguradoIntermediario.Text = n.Intermediario;
                txtDetalleaseguradoRNCIntermediario.Text = n.RNCIntermediario;
                txtDetalleaseguradoLicenciaIntermediario.Text = n.Licencia;
                decimal Prima = (decimal)n.Prima;
                txtDetalleaseguradoPrima.Text = Prima.ToString("N2");
                txtDetalleaseguradoMontoasegurado.Text = n.MontoAsegurado.ToString();
                txtDetalleaseguradoTipoVehiculo.Text = n.TipoVehiculo;
                txtDetalleaseguradoMarca.Text = n.Marca;
                txtDetalleaseguradoModelo.Text = n.Modelo;
                txtDetalleaseguradoChasis.Text = n.Chasis;
                txtDetalleaseguradoPlaca.Text = n.Placa;
                txtDetalleaseguradoAno.Text = n.Ano;
                txtDetalleaseguradoColor.Text = n.Color;
            }
            DivDetalleAsegurado.Visible = true;
        }

        protected void LinkPrimeroAsegurado_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoAsegurado();
        }

        protected void LinkAnteriorAsegurado_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoAsegurado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleAsegurado, ref lbCantidadPaginaVAriableAsegurado);
        }

        protected void dtAsegurado_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoAsegurado();
        }

        protected void dtAsegurado_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void LinkSiguienteAsegurado_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoAsegurado();
        }

        protected void LinkUltimaAsegurado_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoAsegurado();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleAsegurado, ref lbCantidadPaginaVAriableAsegurado);
        }

        protected void LinkPrimeroAseguradoGeneral_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoAseguradoGeneral();
        }

        protected void LinkAnteriorAseguradoGeneral_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoAseguradoGeneral();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleAseguradoGeneral, ref lbCantidadPaginaVAriableAseguradoGeneral);
        }

        protected void dtAseguradoGeneral_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoAseguradoGeneral();
        }

        protected void dtAseguradoGeneral_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void LinkSiguienteAseguradoGeneral_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoAseguradoGeneral();
        }

        protected void LinkUltimoAseguradoGeneral_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoAseguradoGeneral();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleAseguradoGeneral, ref lbCantidadPaginaVAriableAseguradoGeneral);
        }

        protected void btnSeleccionarRegistroAseguradoGeneral_Click(object sender, EventArgs e)
        {
            var CotizacionSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfControlCotiacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionAseguradoGeneral")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfControlSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfItemAseguradoGeneral")).Value.ToString();

            var NumeroAseguradoSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var hfControlNumeroAseguradoSeleccionada = ((HiddenField)NumeroAseguradoSeleccionada.FindControl("hfIdAseguradoAseguradoGeneral")).Value.ToString();

            var Seleccionrregistro = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaAseguradoGeneral(
                null, null,
                Convert.ToDecimal(hfControlCotiacionSeleccionada),
                Convert.ToDecimal(hfControlSecuenciaSeleccionada),
                Convert.ToDecimal(hfControlNumeroAseguradoSeleccionada));
            Paginar(ref rpIDListadoAseguradoGeneral, Seleccionrregistro, 1, ref lbCantidadPaginaVAriableAseguradoGeneral, ref LinkPrimeroAseguradoGeneral, ref LinkAnteriorAseguradoGeneral, ref LinkSiguienteAseguradoGeneral, ref LinkUltimoAseguradoGeneral);
            HandlePaging(ref dtAseguradoGeneral, ref lbPaginaActualVariavleAseguradoGeneral);
            foreach (var n in Seleccionrregistro) {
                txtDetalleAseguradoGeneralPoliza.Text = n.Poliza;
                txtDetalleAseguradoGeneralEstatus.Text = n.Estatus;
                txtDetalleAseguradoGeneralCotizacion.Text = n.Cotizacion.ToString();
                txtDetalleAseguradoGeneralSecuencia.Text = n.Secuencia.ToString();
                txtDetalleAseguradoGeneralIdAsegurado.Text = n.IdAsegurado.ToString();
                txtDetalleAseguradoGeneralNombre.Text = n.Nombre;
                txtDetalleAseguradoGeneralParentezco.Text = n.Parentezco;
                txtDetalleAseguradoGeneralRNC.Text = n.RNC;
                txtDetalleAseguradoGeneralFechaNacimiento.Text = n.FechaNacimiento;
                txtDetalleAseguradoGeneralSexo.Text = n.Sexo;
                txtDetalleAseguradoGeneralInicioVigencia.Text = n.InicioVigencia;
                txtDetalleAseguradoGeneralFinVigencia.Text = n.FinVigencia;
            }
            DivDetalleAseguradoGeneral.Visible = true;
        }

        protected void btnSeleccionarregistroDependiente_Click(object sender, EventArgs e)
        {
            var CotizacionSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var HfCotizacionSeleccionada = ((HiddenField)CotizacionSeleccionada.FindControl("hfCotizacionDependiente")).Value.ToString();

            var SecuenciaSeleccionada = (RepeaterItem)((Button)sender).NamingContainer;
            var HfSecuenciaSeleccionada = ((HiddenField)SecuenciaSeleccionada.FindControl("hfSecuenciaDependiente")).Value.ToString();

            var IdaseguradoSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdAseguradoSeleccionado = ((HiddenField)IdaseguradoSeleccionado.FindControl("hfIdAseguradoDependiente")).Value.ToString();

            var RegistroSeleccionado = ObjDataSuperIntendencia.Value.BuscaPersonaSuperIntendenciaDependente(
                null, null,
                Convert.ToDecimal(HfCotizacionSeleccionada),
                Convert.ToDecimal(HfSecuenciaSeleccionada),
                Convert.ToDecimal(hfIdAseguradoSeleccionado));
            Paginar(ref rpListadoDependientes, RegistroSeleccionado, 1, ref lbCantidadPaginaVAriableDependiente, ref LinkPrimeroDependiente, ref LinkAnteriorDependiente, ref LinkSiguienteDependiente, ref LinkUltimoDependiente);
            HandlePaging(ref dtDependiente, ref lbPaginaActualVariavleDependiente);
            foreach (var n in RegistroSeleccionado) {
                txtDetalleDependientePoliza.Text = n.Poliza;
                txtDetalleDependienteEstatus.Text = n.Estatus;
                txtDetalleDependienteCotizacion.Text = n.Cotizacion.ToString();
                txtDetalleDependienteNombre.Text = n.Nombre;
                txtDetalleDependienteRNC.Text = n.RNC;
                txtDetalleDependienteIdAsegurado.Text = n.IdAsegurado.ToString();
                txtDetalleDependienteParentezco.Text = n.Parentezco;
                txtDetalleDependienteFechaNacimiento.Text = n.FechaNacimiento;
                txtDetalleDependienteSexo.Text = n.Sexo;
                txtDetalleDependienteSecuencia.Text = n.Secuencia.ToString();
                txtDetalleDependienteinicio.Text = n.InicioVigencia;
                txtDetalleDependienteFinVigencia.Text = n.FinVigencia;
            }
            DivDetalleDependientes.Visible = true;
        }

        protected void LinkPrimeroDependiente_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoDependientes();
        }

        protected void LinkAnteriorDependiente_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoDependientes();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleDependiente, ref lbCantidadPaginaVAriableDependiente);
        }

        protected void dtDependiente_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoDependientes();
        }

        protected void dtDependiente_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void LinkSiguienteDependiente_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoDependientes();
        }

        protected void LinkUltimoDependiente_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoDependientes();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleDependiente, ref lbCantidadPaginaVAriableDependiente);
        }

        protected void LinkUltimoCliente_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoClientes(1);
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleCliente, ref lbCantidadPaginaVAriableCliente);
        }
    }
}
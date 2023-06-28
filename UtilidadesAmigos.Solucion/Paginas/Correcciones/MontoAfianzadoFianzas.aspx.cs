using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas.Correcciones
{
    public partial class MontoAfianzadoFianzas : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones> Objdata = new Lazy<Logica.Logica.LogicaCorrecciones.LogicaCorrecciones>();

        #region CONTROL DE PAGINACION DEl HEADER
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

        private void PaginarHeader(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
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
        #region CONFIGURACION INICIAL
        private void ConfiguracionInicial() {

            cbNoAgregarRangoFecha.Checked = false;
            txtPolizaConsulta.Text = string.Empty;
            UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
            Fecha.FechaMes(ref txtFechaDesde, ref txtFechaHasta);
            DivBloqueConsulta.Visible = true;
            DIVBloqueModificacion.Visible = false;
            SubBloqueConsulta.Visible = false;
            SubBloqueModificar.Visible = false;
            txtPolizaValidacion.Text=string.Empty;
            CurrentPage_Header = 0;
            MostrarBitacora();
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LA BITACORA 
        private void MostrarBitacora() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
            DateTime? _Fechadesde = cbNoAgregarRangoFecha.Checked == true ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde.Text);
            DateTime? _fechaHasta = cbNoAgregarRangoFecha.Checked == true ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta.Text);

            var Listado = Objdata.Value.BuscaBitacoraMontoAfianzado(
                _Poliza,
                _Fechadesde,
                _fechaHasta);
            if (Listado.Count() < 1) {

                rpListadoModificaciones.DataSource = null;
                rpListadoModificaciones.DataBind();
            }
            else {

                PaginarHeader(ref rpListadoModificaciones, Listado, 10, ref lbCantidadPaginaVariable, ref btnPrimeraPagina, ref btnPaginaAnterior, ref btnSiguientePaginar, ref btnUltimaPagina);
                HandlePaging_Header(ref dtPaginacion, ref lbPaginaActualVariable);
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
                lbNombrePantalla.Text = "MODIFICACION DE MONTO AFIANZADO";

                ConfiguracionInicial();
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            MostrarBitacora();
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DIVBloqueModificacion.Visible = true;
            SubBloqueConsulta.Visible = true;
            SubBloqueModificar.Visible = false;
        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            MostrarBitacora();
        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header += -1;
            MostrarBitacora();
            MoverValoresPaginacion_Header((int)OpcionesPaginacionValores_Header.PaginaAnterior, ref lbPaginaActualVariable, ref lbCantidadPaginaVariable);
        }

        protected void dtPaginacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Header = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarBitacora();
        }

        protected void btnSiguientePaginar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            MostrarBitacora();
        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarBitacora();
            MoverValoresPaginacion_Header((int)OpcionesPaginacionValores_Header.UltimaPagina, ref lbPaginaActualVariable, ref lbCantidadPaginaVariable);
        }

        protected void btnValidar_Click(object sender, ImageClickEventArgs e)
        {
            var SacarInformacionFianzas = Objdata.Value.BuscaInformacionPolizasFianzas(txtPolizaValidacion.Text);
            if (SacarInformacionFianzas.Count() < 1) {

                ClientScript.RegisterStartupScript(GetType(), "PolizaNoExiste()", "PolizaNoExiste();", true);
            }
            else {

                foreach (var n in SacarInformacionFianzas) {

                    txtPolizaDetalle.Text = n.Poliza;
                    txtEstatusDetalle.Text = n.Estatus;
                    txtClienteDetalle.Text = n.NombreCliente;
                    txtDeudorDetalle.Text = n.Deudor;
                    txtIntermediarioDetalle.Text = n.NombreVendedor;
                    txtRamoDetalle.Text = n.NombreRamo;
                    txtSubramoDetalle.Text = n.NombreSubramo;
                    decimal Prima = (decimal)n.Prima;
                    txtPrimaDetalle.Text = Prima.ToString("N2");
                    decimal MontoAfianzado = (decimal)n.SumaAsegurada;
                    txtMontoAfianzadaDetalle.Text = MontoAfianzado.ToString("N2");
                    decimal Facturado = (decimal)n.Facturado, Cobrado = (decimal)n.Cobrado, Balance = (decimal)n.Balance;
                    txtFacturadoDetalle.Text = Facturado.ToString("N2");
                    txtCobradoDetalle.Text = Cobrado.ToString("N2");
                    txtBalanceDetalle.Text = Balance.ToString("N2");
                    txtMontoAfianzadoNuevo.Text = n.SumaAsegurada.ToString();
                }
                SubBloqueConsulta.Visible = false;
                SubBloqueModificar.Visible = true;
            }
        }

        protected void btnVolverValidacion_Click(object sender, ImageClickEventArgs e)
        {
            ConfiguracionInicial();
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            //MODIFICAMOS EL REGISTRO
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ModificarMontoAfianzado Modificar = new Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ModificarMontoAfianzado(
                txtPolizaDetalle.Text,
                Convert.ToDecimal(txtMontoAfianzadoNuevo.Text),
                "UPDATE");
            Modificar.ModificarInformacion();

            //GUARDAMOS LA BITACORA
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionBitacoraMontoAfianzado Bitacora = new Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionBitacoraMontoAfianzado(
                0,
                txtPolizaDetalle.Text,
                Convert.ToDecimal(txtMontoAfianzadaDetalle.Text.Replace(",", "")),
                Convert.ToDecimal(txtMontoAfianzadoNuevo.Text),
                (decimal)Session["IdUsuario"],
                txtConceptoModificacion.Text,
                "INSERT");
            Bitacora.ProcesarInformacion();

            ClientScript.RegisterStartupScript(GetType(), "PrrocesoCompletado()", "PrrocesoCompletado();", true);
            ConfiguracionInicial();
        }
    }
}
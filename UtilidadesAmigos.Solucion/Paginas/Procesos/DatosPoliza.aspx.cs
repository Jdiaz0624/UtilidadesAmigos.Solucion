using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class DatosPoliza : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

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


            //    divPaginacionDetalle.Visible = true;
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


        private void BuscarDatosPolizas()
        {

            string _Poliza = string.IsNullOrEmpty(txtIngresarPolizaConsulta.Text.Trim()) ? null : txtIngresarPolizaConsulta.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtIngresarItemConsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtIngresarItemConsulta.Text);

            var SacarDatoPoliza = Objdata.Value.SacarDatosDatosPoliza(
                _Poliza,
                _Item);
            if (SacarDatoPoliza.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "RegistronoEncontrado()", "RegistronoEncontrado();", true);
            }
            else
            {
                int CantidadRegistros = SacarDatoPoliza.Count;
                lbCantidadRegistrosBloquePrincipalVariable.Text = CantidadRegistros.ToString("N0");
                Paginar(ref rpListadoPrincipal, SacarDatoPoliza, 10, ref lbCantidadPaginaVariableBloquePrincipal, ref LinkPrimeraPaginaBloquePrincipal, ref LinkAnteriorBloquePrincipal, ref LinkSiguienteBloquePrincipal, ref LinkUltimoBloquePrincipal);
                HandlePaging(ref dtPaginacionBloquePrincipal, ref LinkBlbPaginaActualVariableBloquePrincipal);
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbUsuarioConectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "DATOS DE POLIZA";
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {
            BuscarDatosPolizas();
        }

        protected void btnDetallePrincipal_Click(object sender, EventArgs e)
        {
            var PolizaListadoPrncipalSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfPolizaListadoPrncipal = ((HiddenField)PolizaListadoPrncipalSeleccionado.FindControl("hfPolizaListadoPrncipal")).Value.ToString();

            var NumeroItemPrincipalSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfNumeroItemPrincipal = ((HiddenField)NumeroItemPrincipalSeleccionado.FindControl("hfNumeroItemPrincipal")).Value.ToString();

            var BuscarRegistroSeleccionado = Objdata.Value.SacarDatosDatosPoliza(
                hfPolizaListadoPrncipal, Convert.ToInt32(hfNumeroItemPrincipal));
            lbCantidadRegistrosBloquePrincipalVariable.Text = "1";
            Paginar(ref rpListadoPrincipal, BuscarRegistroSeleccionado, 1, ref lbCantidadPaginaVariableBloquePrincipal, ref LinkPrimeraPaginaBloquePrincipal, ref LinkAnteriorBloquePrincipal, ref LinkSiguienteBloquePrincipal, ref LinkUltimoBloquePrincipal);
            HandlePaging(ref dtPaginacionBloquePrincipal, ref LinkBlbPaginaActualVariableBloquePrincipal);

            DIVBloqueDecision.Visible = true;
            BloqueControlesPrincipales.Visible = true;
            rbDetallePoliza.Checked = true;

            //RECORREMOS Y SACAMOS LAS INFORMACION
            foreach (var n in BuscarRegistroSeleccionado) {
                txtDetalleRamoPrincipal.Text = n.Ramo;
                txtDetalleSubramoPrincipal.Text = n.SubRamo;
                txtDetalleInicioVigenciaPrincipal.Text = n.InicioVigencia;
                txtDetalleFinVigenciaPrincipal.Text = n.FinVigencia;
                txtDetalleTipoVehiculoPrincipal.Text = n.Tipo;
                txtDetalleMarcaPrincipal.Text = n.Marca;
                txtDetalleModeloPrincipal.Text = n.Modelo;
                txtDetalleColorPrincipal.Text = n.Color;
                txtDetalleChasisPrincipal.Text = n.Chasis;
                txtDetallePlacaprincipal.Text = n.Placa;
                decimal ValorAsegurado = (decimal)n.Valor;
                txtDetalleValorAseguradoPrinncipal.Text = ValorAsegurado.ToString("N2");
                txtDetalleFianzaPrincipal.Text = n.Fianza;
                txtDetalleAseguradoPrincipal.Text = n.Asegurado;
                txtDetalleClientePrincipal.Text = n.Cliente;
                decimal Neto = (decimal)n.Neto;
                txtDetallePrimaActualPrincipal.Text = Neto.ToString("N2");
            }
        }

        protected void LinkPrimeraPaginaBloquePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BuscarDatosPolizas();
        }

        protected void LinkAnteriorBloquePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            BuscarDatosPolizas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariableBloquePrincipal, ref lbCantidadPaginaVariableBloquePrincipal);
        }

        protected void dtPaginacionBloquePrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionBloquePrincipal_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BuscarDatosPolizas();
        }

        protected void LinkSiguienteBloquePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BuscarDatosPolizas();

        }

        protected void LinkUltimoBloquePrincipal_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BuscarDatosPolizas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref LinkBlbPaginaActualVariableBloquePrincipal, ref lbCantidadPaginaVariableBloquePrincipal);
        }

        protected void cbModificarValor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarValor.Checked == true) {
                DivPrimaNueva.Visible = true;
                txtDetallePrimaNuevaPrincipal.Text = string.Empty;
            }
            else {
                DivPrimaNueva.Visible = false;
            }
        }

        protected void cbModificarVigencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificarVigencia.Checked == true) {
                DivFechaInicioVigencia.Visible = true;
                DivFechaFinVigencia.Visible = true;

                txtDetalleInicioVigencia.Text = string.Empty;
                txtDetalleFechaFinVigencia.Text = string.Empty;
            }
            else {
                DivFechaInicioVigencia.Visible = false;
                DivFechaFinVigencia.Visible = false;
            }
        }

        protected void btnGuardarDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, EventArgs e)
        {

        }

        protected void rbDetallePoliza_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDetallePoliza.Checked == true) {
                BloqueControlesPrincipales.Visible = true;
                DivBloqieCoberturas.Visible = false;

                DivFechaFinVigencia.Visible = false;
                DivFechaInicioVigencia.Visible = false;
                DivPrimaNueva.Visible = false;
                rbDetallePoliza.Checked = false;
                rbCoberturasPolizas.Checked = false;
            }
            else {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = false;
            }
        }

        protected void rbCoberturasPolizas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoberturasPolizas.Checked == true) {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = true;
            }
            else {
                BloqueControlesPrincipales.Visible = false;
                DivBloqieCoberturas.Visible = false;
            }
        }

        protected void btnseleccionarCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionCoberturas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCoberturas_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoCoberturas_Click(object sender, EventArgs e)
        {

        }

        protected void rbBuscarPorPlaca_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbBuscarPorChasis_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscarotrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalleOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionOtrosFiltros_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionOtrosFiltros_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoOtrosFiltros_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtrasOtrosFiltros_Click(object sender, EventArgs e)
        {

        }
    }
}
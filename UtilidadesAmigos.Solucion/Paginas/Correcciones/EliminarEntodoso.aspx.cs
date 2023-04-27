using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Correcciones
{
    public partial class EliminarEntodoso : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones> ObjDataCorrecciones = new Lazy<Logica.Logica.LogicaCorrecciones.LogicaCorrecciones>();
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

        #region BUSCAR REGISTRO
        private void BuscarRegistro() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtItemConsulta.Text) ? new Nullable<int>() : Convert.ToInt32(txtItemConsulta.Text);

            var Listado = ObjDataCorrecciones.Value.BuscaEndosos(_Poliza, _Item);
            if (Listado.Count() < 1) {
                rpListadoEndosos.DataSource = null;
                rpListadoEndosos.DataBind();
                ClientScript.RegisterStartupScript(GetType(), "PolizaNoEncontrada()", "PolizaNoEncontrada();", true);
            }
            else {

                PaginarHeader(ref rpListadoEndosos, Listado, 10, ref lbCantidadPaginaVariable_Header, ref btnPrimeraPagina_Header, ref btnPaginaAnterior_Header, ref btnSiguientePagina_Header, ref btnUltimaPagina_Header);
                HandlePaging_Header(ref dtPaginacion_Header, ref lbPaginaActualVariable_Header);
            }
        }
        #endregion

        private void VolverAtras() {
            DIVBloqueConsulta.Visible = true;
            DivBloqueProceso.Visible = false;
            DivBloqueHistorico.Visible = false;
            CurrentPage_Header = 0;
            txtPolizaConsulta.Text = string.Empty;
            txtItemConsulta.Text = string.Empty;
            rpListadoEndosos.DataSource = null;
            rpListadoEndosos.DataBind();
        }

        #region ELIMINAR ENDOSOS
        private void EliminarEndoso(decimal Cotizacion, int Secuencia, int IdBeneficiario, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEliminarEndosos Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones.ProcesarInformacionEliminarEndosos(
                30,
                Cotizacion,
                Secuencia,
                IdBeneficiario,
                "", 0, "", DateTime.Now, "DELETE");
            Eliminar.ProcesarInformacion();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "ELIMINAR ENDOSOS";

                DIVBloqueConsulta.Visible = true;
                DivBloqueProceso.Visible = false;
                DivBloqueHistorico.Visible = false;
            }
        }

        protected void btnSeleccionar_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;

            var Poliza = ((HiddenField)ItemSeleccionado.FindControl("hfPoliza")).Value.ToString();
            var Item = ((HiddenField)ItemSeleccionado.FindControl("hfItem")).Value.ToString();
            var Beneficiario = ((HiddenField)ItemSeleccionado.FindControl("hfBeneficiario")).Value.ToString();

            var BuscarInformacion = ObjDataCorrecciones.Value.BuscaEndosos(Poliza, Convert.ToInt32(Item));
            foreach (var n in BuscarInformacion) {

                txtPolizaProceso.Text = n.Poliza;
                txtRamoProceso.Text = n.Ramo;
                txtSubRamoProceso.Text = n.Subramo;
                txtItemProceso.Text = n.Item.ToString();
                txtFechaInicioVigenciaProceso.Text = n.FechaInicioVigencia;
                txtFechaFinVigenciaProceso.Text = n.FechaFinVigencia;
                txtBeneficiarioProceso.Text = n.NombreBeneficiario;
                decimal ValorEndoso = n.ValorEndosoCesion;
                txtValorEndosoProceso.Text = ValorEndoso.ToString("N2");
            }
            DIVBloqueConsulta.Visible = false;
            DivBloqueProceso.Visible = true;
            DivBloqueHistorico.Visible = false;
        }

        protected void btnPrimeraPagina_Header_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            BuscarRegistro();
        }

        protected void btnPaginaAnterior_Header_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header += -1;
            BuscarRegistro();
            MoverValoresPaginacion_Header((int)OpcionesPaginacionValores_Header.PaginaAnterior, ref lbPaginaActualVariable_Header, ref lbCantidadPaginaVariable_Header);
        }

        protected void dtPaginacion_Header_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_Header_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Header = Convert.ToInt32(e.CommandArgument.ToString());
            BuscarRegistro();
        }

        protected void btnSiguientePagina_Header_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            BuscarRegistro();
        }

        protected void btnUltimaPagina_Header_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BuscarRegistro();
            MoverValoresPaginacion_Header((int)OpcionesPaginacionValores_Header.UltimaPagina, ref lbPaginaActualVariable_Header, ref lbCantidadPaginaVariable_Header);
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
            VolverAtras();
        }

        protected void btnHistorico_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Header = 0;
            BuscarRegistro();
        }
    }
}
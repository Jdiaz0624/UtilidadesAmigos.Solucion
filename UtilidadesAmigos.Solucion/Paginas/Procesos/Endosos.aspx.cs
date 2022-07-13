using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class Endosos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProcesos = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();

        #region CONTROL DE PAGINACION
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

        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
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


            //divPaginacionComisionSupervisor.Visible = true;
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


        #region BUSCA POLIZAS
        private void MostrarListadoPolizas() {

            string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
            int? _Item = string.IsNullOrEmpty(txtNumeroItenComsulta.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroItenComsulta.Text);
            string Estatus = "", TipoSeguro = "", Poliza = "", InicioVigencia = "", FinVigencia = "", Supervisor = "", Intrmediario = "", Ramo = "", SubRamo = "", Cliente = "", Grua = "";
            int Item = 0, CodigoGrua = 0;

            var Listado = ObjDataProcesos.Value.BuscaPolizaEndosos(_Poliza, _Item);
            if (Listado.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "RegistroNoEncontrado()", "RegistroNoEncontrado();", true);
                ConfiguracionInicial();
            }
            else {

                foreach (var n in Listado) {
                    Estatus = n.Estatus;
                    TipoSeguro = n.TipoSeguro;
                    Poliza = n.Poliza;
                    Item = (int)n.Item;
                    InicioVigencia = n.InicioVigencia;
                    FinVigencia = n.FinVigencia;
                    Supervisor = n.Supervisor;
                    Intrmediario = n.Intermediario;
                    Ramo = n.NombreRamo;
                    SubRamo = n.NombreSubRamo;
                    Cliente = n.NombreCliente;
                    Grua = n.Grua;
                    CodigoGrua = (int)n.CodigoGrua;
                }
                if (Estatus == "CANCELADA") {

                    ClientScript.RegisterStartupScript(GetType(), "PolizaCancelada()", "PolizaCancelada();", true);
                    ConfiguracionInicial();
                }
                else {
                    if (CodigoGrua == 1) {
                        ClientScript.RegisterStartupScript(GetType(), "PolizaNoAplica()", "PolizaNoAplica();", true);
                    }
                    else {

                       

                        DIVBloqueDetallePoliza.Visible = true;
                        DIVBloqueOperacionRealizar.Visible = true;
                        rbHistoricoEndoso.Checked = true;
                        DIVBloqueHistorico.Visible = true;
                        lbPolizaDetalleVariable.Text = Poliza;
                        lbItemNoDetalleVariable.Text = Item.ToString("N0");
                        lbInicioVigenciaDetalleVariable.Text = InicioVigencia;
                        lbFinVIgenciaDetalleVariable.Text = FinVigencia;
                        lbSupervisorDetalleVariable.Text = Supervisor;
                        lbIntermediarioDetalleVariable.Text = Intrmediario;
                        lbEstatusDetalleVariable.Text = Estatus;
                        lbRamoDetalleVariable.Text = Ramo;
                        lbSubRamoDetalleVariable.Text = SubRamo;
                        lbClienteDetalleVariable.Text = Cliente;
                        lbTipoSeguroVariable.Text = TipoSeguro;
                        lbGruaVariable.Text = Grua;
                        lbCodigoGruaVariable.Text = CodigoGrua.ToString();

                        if (lbTipoSeguroVariable.Text == "Seguro Full")
                        {
                            rbEndosoAclaratorio.Visible = true;
                            rbEndosoAclaratorioPAraCodundorUnico.Visible = true;
                            rbENdosoAuxilioVial.Visible = true;
                            rbEndosoLicenciaExtragero.Visible = true;
                            rbEndosoAclaratorio.Checked = true;
                        }
                        else
                        {
                            rbEndosoAclaratorio.Visible = false;
                            rbEndosoAclaratorioPAraCodundorUnico.Visible = false;
                            rbENdosoAuxilioVial.Visible = true;
                            rbEndosoLicenciaExtragero.Visible = false;
                            rbENdosoAuxilioVial.Checked = true;
                        }
                    }
                }

            }
            
        }
        #endregion

        private void ConfiguracionInicial() {
            rbHistoricoEndoso.Checked = true;
            txtPolizaConsulta.Text = string.Empty;
            txtNumeroItenComsulta.Text = string.Empty;
            txtCedulaConductorUnico.Text = string.Empty;
            txtNombreConductorUnico.Text = string.Empty;
            txtNumeroLicenciaExtranjero.Text = string.Empty;
         
            DIVBloqueDetallePoliza.Visible = false;
            DIVBloqueOperacionRealizar.Visible = false;
            DIVBloqueHistorico.Visible = false;
            DIVBloqueNuevoRegistro.Visible = false;
            txtNumeroItenComsulta.Text = "1";
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR ENDOSOS";

                ConfiguracionInicial();
            }
        }

        protected void btnConsultar_Click(object sender, ImageClickEventArgs e)
        {
            rbHistoricoEndoso.Checked = true;
            MostrarListadoPolizas();
        }

        protected void btnRestablecerPantalla_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/Endosos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void rbHistoricoEndoso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHistoricoEndoso.Checked == true) {
                DIVBloqueHistorico.Visible = true;
                DIVBloqueNuevoRegistro.Visible = false;
            }
            else if (rbGenerarNuevoEndoso.Checked == true) {
                DIVBloqueHistorico.Visible = false;


                DIVBloqueNuevoRegistro.Visible = true;

             
                rbEndosoAclaratorio.Checked = true;
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
                txtNumeroLicenciaExtranjero.Text = string.Empty;
                txtNombreConductorUnico.Text = string.Empty;
                txtCedulaConductorUnico.Text = string.Empty;
            }
        }

        protected void rbGenerarNuevoEndoso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenerarNuevoEndoso.Checked == true) {
                DIVBloqueNuevoRegistro.Visible = true;
                DIVBloqueHistorico.Visible = false;

                
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
                txtNumeroLicenciaExtranjero.Text = string.Empty;
                txtNombreConductorUnico.Text = string.Empty;
                txtCedulaConductorUnico.Text = string.Empty;

                if (lbTipoSeguroVariable.Text == "Seguro Full")
                {
                    rbEndosoAclaratorio.Visible = true;
                    rbEndosoAclaratorioPAraCodundorUnico.Visible = true;
                    rbENdosoAuxilioVial.Visible = true;
                    rbEndosoLicenciaExtragero.Visible = true;
                    rbEndosoAclaratorio.Checked = true;
                }
                else
                {
                    rbEndosoAclaratorio.Visible = false;
                    rbEndosoAclaratorioPAraCodundorUnico.Visible = false;
                    rbENdosoAuxilioVial.Visible = true;
                    rbEndosoLicenciaExtragero.Visible = false;
                    rbENdosoAuxilioVial.Checked = true;
                }
            }
            else if (rbHistoricoEndoso.Checked == true) {
                DIVBloqueNuevoRegistro.Visible = false;
                DIVBloqueHistorico.Visible = true;
            }
        }

        protected void btnReImprimirEndoso_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionListadoPrincipal_CancelCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void rbEndosoAclaratorio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEndosoAclaratorio.Checked == true) {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
            else {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void rbEndosoLicenciaExtragero_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEndosoLicenciaExtragero.Checked == true) {
                DIVBloqueLicenciaExtrajero.Visible = true;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
            else {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void rbEndosoAclaratorioPAraCodundorUnico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEndosoAclaratorioPAraCodundorUnico.Checked == true) {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = true;
                DIVBloqueCedula.Visible = true;
            }
            else {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void rbENdosoAuxilioVial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbENdosoAuxilioVial.Checked == true) {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
            else
            {
                DIVBloqueLicenciaExtrajero.Visible = false;
                DIVBloqueNombre.Visible = false;
                DIVBloqueCedula.Visible = false;
            }
        }

        protected void btnNuevoRegistro_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnCompletar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
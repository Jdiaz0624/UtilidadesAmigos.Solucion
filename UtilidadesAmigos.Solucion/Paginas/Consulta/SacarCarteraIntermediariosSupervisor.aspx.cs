using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class SacarCarteraIntermediariosSupervisor : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();

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

        #region MOSTRAR LA CARTERA DE LOS INTERMEDIARIOS
        private void CarteraIntermediario() {

            int? CodigoVendedor = string.IsNullOrEmpty(txtCodigoIntermedairio.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedairio.Text);
            string Estatus = "";
            int CodigoEstatus = Convert.ToInt32(ddlSeleccionarEstatusPoliza.SelectedValue);

            switch (CodigoEstatus) {

                case 1:
                    Estatus=  "ACTIVO";
                    break;

                case 2:
                    Estatus = "CANCELADA";
                    break;

                case 3:
                    Estatus = "EXCLUSION";
                    break;

                case 4:
                    Estatus = "TRANSITO";
                    break;

                default:
                   Estatus= null;
                    break;
            }

            var SacarCarteraIntermediarios = ObjDataConsulta.Value.SacarCarteraIntermeiario(CodigoVendedor, Estatus);
            if (SacarCarteraIntermediarios.Count() < 1) {
                CurrentPage = 0;
                rpCarteraIntermediario.DataSource = null;
                rpCarteraIntermediario.DataBind();
                lbCantidadPolizasActivasVariable.Text = "0";
                lbCantidadPolizasCanceladasVariable.Text = "0";
                lbCantidadPolizasTransitoVariable.Text = "0";
                lbCantidadPolizasExcluidasVariable.Text = "0";
            }
            else {

                Paginar(ref rpCarteraIntermediario, SacarCarteraIntermediarios, 10, ref lbCantidadPaginaVAriableCarteraIntermediario, ref LinkPrimeraPaginaCarteraIntermediario, ref LinkAnteriorCarteraIntermediario, ref LinkSiguienteCarteraIntermediario, ref LinkUltimoCarteraIntermediario);
                HandlePaging(ref dtPaginacionCarteraIntermediario, ref lbPaginaActualVariableCarteraIntermediario);
                int Activas = 0, Canceladas = 0, Transito = 0, Exclidas = 0;

                foreach (var n in SacarCarteraIntermediarios) {
                    Activas = (int)n.PolizasActivas;
                    Canceladas = (int)n.PolizasCanceladas;
                    Transito = (int)n.PolizasTransito;
                    Exclidas = (int)n.PolizasExclusion;
                }

                lbCantidadPolizasActivasVariable.Text = Activas.ToString("N0");
                lbCantidadPolizasCanceladasVariable.Text = Canceladas.ToString("N0");
                lbCantidadPolizasTransitoVariable.Text = Transito.ToString("N0");
                lbCantidadPolizasExcluidasVariable.Text = Exclidas.ToString("N0");
            }
        }
        #endregion

        #region EXPORTAR CARTERA DE INTERMEDIARIOS
        private void ExportarCarteraVendedores() {

            int? CodigoVendedor = string.IsNullOrEmpty(txtCodigoIntermedairio.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermedairio.Text);
            string Estatus = "";
            int CodigoEstatus = Convert.ToInt32(ddlSeleccionarEstatusPoliza.SelectedValue);

            switch (CodigoEstatus)
            {

                case 1:
                    Estatus = "ACTIVO";
                    break;

                case 2:
                    Estatus = "CANCELADA";
                    break;

                case 3:
                    Estatus = "EXCLUSION";
                    break;

                case 4:
                    Estatus = "TRANSITO";
                    break;

                default:
                    Estatus = null;
                    break;
            }

            var Exportar = (from n in ObjDataConsulta.Value.SacarCarteraIntermeiario(CodigoVendedor, Estatus)
                            select new
                            {
                                Poliza = n.Poliza,
                                EstatusPoliza = n.EstatusPoliza,
                                CodigoDeCliente=n.CodigoCliente,
                                Cliente = n.Cliente,
                                CodigoIntermediario = n.Intermediario,
                                Intermediario = n.NombreVendedor,
                                EstatusIntermediario = n.EstatusIntermediario,
                                Facturado = n.Facturado,
                                Cobrado = n.Cobrado,
                                Balance = n.Balance

                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera de Intermediarios", Exportar);
        }
        #endregion

        #region MOSTRAR LA CARTERA DE LOS SUPERVISORES
        private void MostrarCarteraSupervisores() {

            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioSupervisor.Text);

            var SacarCartera = ObjDataConsulta.Value.SacarCarteraEjecutivos(_Supervisor, _Intermediario);
            if (SacarCartera.Count() < 1) {

                lbCantidadIntermediariosVariable.Text = "0";
                rpCarteraSupervisor.DataSource = null;
                rpCarteraSupervisor.DataBind();
                CurrentPage = 0;
            }
            else {

                Paginar(ref rpCarteraSupervisor, SacarCartera, 10, ref lbCantidadPaginaVAriableCarteraSupervisor, ref LinkPrimeraPaginaCarteraSupervisor, ref LinkAnteriorCarteraSupervisor, ref LinkSiguienteCarteraSupervisor, ref LinkUltimoCarteraSupervisor);
                HandlePaging(ref dtPaginacionCarteraSupervisor, ref lbPaginaActualVariableCarteraSupervisor);

                int CantidadIntemediaro = 0;

                foreach (var n in SacarCartera) {

                    CantidadIntemediaro = (int)n.TotalIntermediarios;
                }
                lbCantidadIntermediariosVariable.Text = CantidadIntemediaro.ToString("N0");
            }
        }
        #endregion

        #region EXPORTAR CARTERA SUPERVISORES
        private void ExportarCartaraSupervisores() {

            int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
            int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediarioSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediarioSupervisor.Text);

            var Exportar = (from n in ObjDataConsulta.Value.SacarCarteraEjecutivos(_Supervisor, _Intermediario)
                            select new
                            {
                                Codigo_Supervisor = n.IdIntermediarioSupervisa,
                                Supervisor = n.NombreSupervisor,
                                Codigo_Intermediario = n.IdIntermediario,
                                Intermediario = n.NombreIntermediario,
                                Estatus_Intermediario = n.EstatusVendedor
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Cartera de Supervisores", Exportar);
        }

        #endregion

        private void CargarEstatus() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarEstatusPoliza, ObjDataGeneral.Value.BuscaListas("ESTATUSPOLIZA", null, null), true);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                rbCarteraIntermediarios.Checked = true;
                DivBloqueIntermediarios.Visible = true;
                DivBloqueSupervisores.Visible = false;
                CargarEstatus();

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "CARTERA DE INTERMEDIARIOS / SUPERVISORES";
            } 
        }

        protected void rbCarteraIntermediarios_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCarteraIntermediarios.Checked == true) {
                DivBloqueIntermediarios.Visible = true;
                DivBloqueSupervisores.Visible = false;
                txtCodigoIntermedairio.Text = string.Empty;
                txtNombreIntermediario.Text = string.Empty;
                txtCodigoIntermedairio.Focus();
                CargarEstatus();
            }
            else {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = false;
            }
        }

        protected void rbCarteraSupervisores_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCarteraSupervisores.Checked == true) {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = true;
                txtCodigoSupervisor.Text = string.Empty;
                txtNombreSupervisor.Text = string.Empty;
                txtCodigoIntermediarioSupervisor.Text = string.Empty;
                txtNombreIntermediarioSupervisor.Text = string.Empty;
                txtCodigoSupervisor.Focus();
            }
            else {
                DivBloqueIntermediarios.Visible = false;
                DivBloqueSupervisores.Visible = false;
            }
        }

        protected void btnConsultarIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            CarteraIntermediario();
        }

        protected void txtCodigoIntermedairio_TextChanged(object sender, EventArgs e)
        {
            string NombreVendedor = "", CodigoIntermediario = "";
            CodigoIntermediario = txtCodigoIntermedairio.Text;
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarNombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(CodigoIntermediario);
            NombreVendedor = SacarNombre.SacarNombreIntermediario();
            txtNombreIntermediario.Text = NombreVendedor;
        }

        protected void LinkPrimeraPaginaCarteraIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            CarteraIntermediario();
        }

        protected void LinkAnteriorCarteraIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            CarteraIntermediario();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableCarteraIntermediario, ref lbCantidadPaginaVAriableCarteraIntermediario);
        }

        protected void dtPaginacionCarteraIntermediario_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCarteraIntermediario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            CarteraIntermediario();
        }

        protected void LinkSiguienteCarteraIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            CarteraIntermediario();

        }

        protected void LinkUltimoCarteraIntermediario_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            CarteraIntermediario();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableCarteraIntermediario, ref lbCantidadPaginaVAriableCarteraIntermediario);
        }

        protected void btnBuscarSupervisores_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarCarteraSupervisores();
        }

        protected void LinkPrimeraPaginaCarteraSupervisor_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarCarteraSupervisores();
        }

        protected void LinkAnteriorCarteraSupervisor_Click(object sender, EventArgs e)
        {

            CurrentPage += -1;
            MostrarCarteraSupervisores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableCarteraSupervisor, ref lbCantidadPaginaVAriableCarteraSupervisor);
        }

        protected void dtPaginacionCarteraSupervisor_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCarteraSupervisor_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarCarteraSupervisores();
        }

        protected void LinkSiguienteCarteraSupervisor_Click(object sender, EventArgs e)
        {

            CurrentPage += 1;
            MostrarCarteraSupervisores();
        }

        protected void LinkUltimoCarteraSupervisor_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarCarteraSupervisores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableCarteraSupervisor, ref lbCantidadPaginaVAriableCarteraSupervisor);
        }

        protected void btnExportarSupervisores_Click(object sender, ImageClickEventArgs e)
        {
            ExportarCartaraSupervisores();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediarioSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediarioSupervisor.Text);
            txtNombreIntermediarioSupervisor.Text = Nombre.SacarNombreIntermediario();
        }

        protected void ExportarInformacionIntermediario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            ExportarCarteraVendedores();
        }
    }
}
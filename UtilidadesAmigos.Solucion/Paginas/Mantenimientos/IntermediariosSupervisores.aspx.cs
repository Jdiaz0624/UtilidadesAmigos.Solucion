using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class IntermediariosSupervisores : System.Web.UI.Page
    {
        UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.Logica.LogicaSistema();
        UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos Objdatamantenimientos = new Logica.Logica.LogicaMantenimientos.LogicaMantenimientos();

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
        #region CARGAR LAS OFICINAS PARA LA PANTALLA DE CONSULTA
        private void CargaroficinaConsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaConsulta, ObjData.BuscaListas("OFICINAS", null, null), true);
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LOS INTERMEDIARIOS Y SUPERVISORES
        private void MostrarIntermediariosSupervisores() {
            string _Codigo = string.IsNullOrEmpty(txtCodigoIntermediarioConsulta.Text.Trim()) ? null : txtCodigoIntermediarioConsulta.Text.Trim();
            string _Nombre = string.IsNullOrEmpty(txtNombreIntermediarioConsulta.Text.Trim()) ? null : txtNombreIntermediarioConsulta.Text.Trim();
            int? _Oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();

            var Listado = Objdatamantenimientos.BuscaListadoIntermediario(
                _Codigo,
                _Nombre,
                null,
                null,
                _Oficina);
            Paginar(ref rpListado, Listado, 10, ref lbCantidadPaginaVariableIntermediariosSupervisores, ref LinkPrimeraPaginaIntermediariosSupervisores, ref LinkAnteriorIntermediariosSupervisores, ref LinkSiguienteIntermediariosSupervisores, ref LinkUltimoIntermediariosSupervisores);
            HandlePaging(ref dtPaginacionIntermediariosSupervisores, ref lbPaginaActualVariavleIntermediariosSupervisores);
        }
        #endregion

        #region LISTAS DEL BLOQUE DE MANTENIMIENTO
        private void ListaTipoIdentificacionMAntenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoIdentificacionMantenimiento, ObjData.BuscaListas("TIPOIDENTIFICACION", null, null));
        }
        private void ListaPaisMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlPaisMantenimiento, ObjData.BuscaListas("LISTADOPAIS", null, null));
        }
        private void ListaZonaMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlZonaMantenimiento, ObjData.BuscaListas("LISTADOZONAS", ddlPaisMantenimiento.SelectedValue, null));
        }
        private void ListaProvinciaMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlProvinciaMantenimiento, ObjData.BuscaListas("LISTADOPROVINCIAS", ddlPaisMantenimiento.SelectedValue, ddlZonaMantenimiento.SelectedValue));
        }
        private void ListaMunicipioMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlMunicipioMAntenimiento, ObjData.BuscaListas("LISTADOMUNICIPIO", ddlPaisMantenimiento.SelectedValue, ddlZonaMantenimiento.SelectedValue, ddlProvinciaMantenimiento.SelectedValue));
        }
        private void ListaSectorMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSectorMantenimiento, ObjData.BuscaListas("LISTADOSECTOR", ddlPaisMantenimiento.SelectedValue, ddlZonaMantenimiento.SelectedValue, ddlProvinciaMantenimiento.SelectedValue, ddlMunicipioMAntenimiento.SelectedValue));
        }
        private void ListaUbicacionMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlUbicacionMantenimiento, ObjData.BuscaListas("LISTADOBARRIO", ddlPaisMantenimiento.SelectedValue, ddlZonaMantenimiento.SelectedValue, ddlProvinciaMantenimiento.SelectedValue, ddlMunicipioMAntenimiento.SelectedValue, ddlSectorMantenimiento.SelectedValue));
        }
        private void ListaOficinaMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaMAntenimiento, ObjData.BuscaListas("OFICINAS", null, null));
        }
        private void ListaBancoMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlBancoMantenimiento, ObjData.BuscaListas("LISTADOBANCOS", null, null));
        }
        private void ListaCanalDistribucion() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCanalDistribucionMantenimiento, ObjData.BuscaListas("LISTADOCANALESDISTRIBUCION", null, null));
        }

        #endregion

        #region CONFIGURACIONES INICIALES PANTALLA DE MANTENIMIENTO
        private void CargarConfiguracionesInicialesBloqueMantenimiento() {
            rbRetencionNoMantenimiento.Checked = true;
            rbActivoMantenimiento.Checked = true;
            rbIntermediarioNoDirectoMantenimiento.Checked = true;
            ListaTipoIdentificacionMAntenimiento();
            ListaPaisMantenimiento();
            ListaZonaMantenimiento();
            ListaProvinciaMantenimiento();
            ListaMunicipioMantenimiento();
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
            ListaOficinaMantenimiento();
            ListaBancoMantenimiento();
            ListaCanalDistribucion();
            rbCuentaCorrienteMantenimiento.Checked = true;
            rbChequeMantenimiento.Checked = true;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario SacarNombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = SacarNombre.SacarNombreUsuarioConectado();
                Label lbPantallaActual = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantallaActual.Text = "MANTENIMIENTO INTERMEDIARIOS / SUPERVISORES";
                CargaroficinaConsulta();
                CurrentPage = 0;
                MostrarIntermediariosSupervisores();
                DivBloqueConsulta.Visible = true;
                DivBloqueMantenimiento.Visible = false;
                DivBloqueComisiones.Visible = false;
                DivBloqueInternoComision.Visible = false;
                btnModificar.Enabled = false;
                btnComisiones.Enabled = false;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarIntermediariosSupervisores();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DivBloqueComisiones.Visible = false;
            DivBloqueInternoComision.Visible = false;
            DivBloqueMantenimiento.Visible = true;
            CargarConfiguracionesInicialesBloqueMantenimiento();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnRestabelcer_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarRegistro_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarIntermediariosSupervisores();

        }

        protected void LinkAnteriorIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarIntermediariosSupervisores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleIntermediariosSupervisores, ref lbCantidadPaginaVariableIntermediariosSupervisores);
        }

        protected void dtPaginacionIntermediariosSupervisores_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionIntermediariosSupervisores_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarIntermediariosSupervisores();
        }

        protected void LinkSiguienteIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarIntermediariosSupervisores();
        }

        protected void btnGuardarMantenimiento_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtrasMantenimiento_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultarComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnValidarClaveSeguridad_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarComision_Click(object sender, EventArgs e)
        {

        }

        protected void LinkPrimeraPaginaIntermediariosSupervisoresComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAnteriorIntermediariosSupervisoresComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void dtPaginacionIntermediariosSupervisoresComisiones_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionIntermediariosSupervisoresComisiones_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void LinkSiguienteIntermediariosSupervisoresComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void LinkUltimoIntermediariosSupervisoresComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarComision_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancearProceso_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverAtrasComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void ddlPaisMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaZonaMantenimiento();
            ListaProvinciaMantenimiento();
            ListaMunicipioMantenimiento();
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
        }

        protected void ddlZonaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaProvinciaMantenimiento();
            ListaMunicipioMantenimiento();
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
        }

        protected void ddlProvinciaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaMunicipioMantenimiento();
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
        }

        protected void ddlMunicipioMAntenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaSectorMantenimiento();
            ListaUbicacionMantenimiento();
        }

        protected void ddlSectorMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaUbicacionMantenimiento();
        }

        protected void txtCodigoSupervisorMantenimiento_TextChanged(object sender, EventArgs e)
        {
            try {
                string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisorMantenimiento.Text.Trim()) ? null : txtCodigoSupervisorMantenimiento.Text.Trim();
                UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoSupervisor);
                txtNombreSupervisorMantenimiento.Text = Nombre.SacarNombreSupervisor();
            }
            catch (Exception) {
                txtNombreSupervisorMantenimiento.Text = "";
            }
        }

        protected void LinkUltimoIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarIntermediariosSupervisores();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleIntermediariosSupervisores, ref lbCantidadPaginaVariableIntermediariosSupervisores);
        }
    }
}
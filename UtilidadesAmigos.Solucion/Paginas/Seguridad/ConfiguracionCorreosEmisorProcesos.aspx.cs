using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Seguridad
{
    public partial class ConfiguracionCorreosEmisorProcesos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjDataProceso = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();

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

        #region CARGAR LOS PROCESOS PARA LA CONSULTA
        private void CargarProcesos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlProcesoConsulta, ObjData.Value.BuscaListas("PROCESOS", null, null), true);
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LOS CORREOS
        private void ListadoCorreos() {
            int? _IdProceso = ddlProcesoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlProcesoConsulta.SelectedValue) : new Nullable<int>();

            var Listado = ObjDataProceso.Value.ListadoCorreosEmisores(
                new Nullable<int>(),
                _IdProceso);
            Paginar(ref rpListadoCorreos, Listado, 10, ref lbCantidadPaginaVariableCorreos, ref LinkPrimeraPaginaCorreos, ref LinkAnteriorCorreos, ref LinkSiguienteCorreos, ref LinkUltimoCorreos);
            HandlePaging(ref dtPaginacionCorreos, ref lbPaginaActualVariavleCorreos);
        }
        #endregion

        #region MODIFICAR INFORMACION
        private void MAnCorreos() {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionCorreosEmisoresSistema Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionCorreosEmisoresSistema(
                Convert.ToInt32(lbIdCorreoSeleccionado.Text),
                Convert.ToInt32(lbIdProcesoSeleccionado.Text),
                txtCorreoModificar.Text,
                txtClaveModificar.Text,
                Convert.ToInt32(txtpuertoMantenimiento.Text),
                txtSMTPMantenimiento.Text,
                "UPDATE");
            Procesar.ProcesarInfrmacion();
        }
        #endregion
        private void IniciarPantalla() {
            DivBloqueConsulta.Visible = true;
            DivBloqueModificar.Visible = false;
            btnConsultarRegistros.Enabled = true;
            btnModificar.Enabled = false;
            btnRestablecer.Enabled = true;
            ddlProcesoConsulta.Enabled = true;
            txtClaveModificar.Text = string.Empty;
            txtClaveSeguridad.Text = string.Empty;
            txtCorreoModificar.Text = string.Empty;
            txtpuertoMantenimiento.Text = string.Empty;
            txtSMTPMantenimiento.Text = string.Empty;

            CargarProcesos();
            CurrentPage = 0;
            ListadoCorreos();
            btnModificar.Enabled = false;
            DivBloqueModificar.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                IniciarPantalla();
            }
        }

        protected void btnConsultarRegistros_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            ListadoCorreos();
        }

        protected void btnSeleccionarRegistro_Click(object sender, EventArgs e)
        {
            var IdCorreoSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdCorreoSeleccionado = ((HiddenField)IdCorreoSeleccionado.FindControl("hfIdCorreo")).Value.ToString();

            var IdProcesoSeleccionado = (RepeaterItem)((Button)sender).NamingContainer;
            var hfIdProcesoSeleccionado = ((HiddenField)IdProcesoSeleccionado.FindControl("hfIdProceso")).Value.ToString();

            lbIdCorreoSeleccionado.Text = hfIdCorreoSeleccionado.ToString();
            lbIdProcesoSeleccionado.Text = hfIdProcesoSeleccionado.ToString();

            var BuscarRegistro = ObjDataProceso.Value.ListadoCorreosEmisores(Convert.ToInt32(lbIdCorreoSeleccionado.Text), Convert.ToInt32(lbIdProcesoSeleccionado.Text));
            Paginar(ref rpListadoCorreos, BuscarRegistro, 1, ref lbCantidadPaginaVariableCorreos, ref LinkPrimeraPaginaCorreos, ref LinkAnteriorCorreos, ref LinkSiguienteCorreos, ref LinkUltimoCorreos);
            HandlePaging(ref dtPaginacionCorreos, ref lbPaginaActualVariavleCorreos);
            btnConsultarRegistros.Enabled = false;
            btnModificar.Enabled = true;
            btnRestablecer.Enabled = true;
            ddlProcesoConsulta.Enabled = false;
        }

        protected void LinkPrimeraPaginaCorreos_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            ListadoCorreos();
        }

        protected void LinkAnteriorCorreos_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            ListadoCorreos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleCorreos, ref lbCantidadPaginaVariableCorreos);
        }

        protected void dtPaginacionCorreos_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionCorreos_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            ListadoCorreos();
        }

        protected void LinkSiguienteCorreos_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            ListadoCorreos();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            DivBloqueConsulta.Visible = false;
            DivBloqueModificar.Visible = true;
            var BuscarRegistro = ObjDataProceso.Value.ListadoCorreosEmisores(Convert.ToInt32(lbIdCorreoSeleccionado.Text), Convert.ToInt32(lbIdProcesoSeleccionado.Text));
            foreach (var n in BuscarRegistro) {
                txtCorreoModificar.Text = n.Correo;
                txtClaveModificar.Text = UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.DesEncriptar(n.Clave);
                txtpuertoMantenimiento.Text = n.Puerto.ToString();
                txtSMTPMantenimiento.Text = n.SMTP;
            }
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            IniciarPantalla();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MAnCorreos();
            IniciarPantalla();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            IniciarPantalla();
        }

        protected void LinkUltimoCorreos_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            ListadoCorreos();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariavleCorreos, ref lbCantidadPaginaVariableCorreos);
        }
    }
}
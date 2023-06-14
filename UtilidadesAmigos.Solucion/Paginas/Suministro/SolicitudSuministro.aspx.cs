using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Suministro
{
    public partial class SolicitudSuministro : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro> ObjDataSuministro = new Lazy<Logica.Logica.LogicaSuministro.LogicaSuministro>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        #region CONTROL DE PAGINACION DE LAS SOLICITUDES
        readonly PagedDataSource pagedDataSource_SolicitudHeader = new PagedDataSource();
        int _PrimeraPagina_SolicitudHeader, _UltimaPagina_SolicitudHeader;
        private int _TamanioPagina_SolicitudHeader = 10;
        private int CurrentPage_SolicitudHeader
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

        private void HandlePaging_SolicitudHeader(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_SolicitudHeader = CurrentPage_SolicitudHeader - 5;
            if (CurrentPage_SolicitudHeader > 5)
                _UltimaPagina_SolicitudHeader = CurrentPage_SolicitudHeader + 5;
            else
                _UltimaPagina_SolicitudHeader = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_SolicitudHeader > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_SolicitudHeader = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_SolicitudHeader = _UltimaPagina_SolicitudHeader - 10;
            }

            if (_PrimeraPagina_SolicitudHeader < 0)
                _PrimeraPagina_SolicitudHeader = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_SolicitudHeader;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_SolicitudHeader; i < _UltimaPagina_SolicitudHeader; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_SolicitudHeader(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_SolicitudHeader.DataSource = Listado;
            pagedDataSource_SolicitudHeader.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_SolicitudHeader.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_SolicitudHeader.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_SolicitudHeader.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_SolicitudHeader : _NumeroRegistros);
            pagedDataSource_SolicitudHeader.CurrentPageIndex = CurrentPage_SolicitudHeader;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_SolicitudHeader.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_SolicitudHeader.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_SolicitudHeader.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_SolicitudHeader.IsLastPage;

            RptGrid.DataSource = pagedDataSource_SolicitudHeader;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_SolicitudHeader
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_SolicitudHeader(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region CONTROL DE PAGINACION DEL INVENTARIO
        readonly PagedDataSource pagedDataSource_Inventario = new PagedDataSource();
        int _PrimeraPagina_Inventario, _UltimaPagina_Inventario;
        private int _TamanioPagina_Inventario = 10;
        private int CurrentPage_Inventario
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

        private void HandlePaging_Inventario(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_Inventario = CurrentPage_Inventario - 5;
            if (CurrentPage_Inventario > 5)
                _UltimaPagina_Inventario = CurrentPage_Inventario + 5;
            else
                _UltimaPagina_Inventario = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_Inventario > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_Inventario = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_Inventario = _UltimaPagina_Inventario - 10;
            }

            if (_PrimeraPagina_Inventario < 0)
                _PrimeraPagina_Inventario = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_Inventario;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_Inventario; i < _UltimaPagina_Inventario; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_Inventario(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_Inventario.DataSource = Listado;
            pagedDataSource_Inventario.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_Inventario.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_Inventario.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_Inventario.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_Inventario : _NumeroRegistros);
            pagedDataSource_Inventario.CurrentPageIndex = CurrentPage_Inventario;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_Inventario.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_Inventario.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_Inventario.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_Inventario.IsLastPage;

            RptGrid.DataSource = pagedDataSource_Inventario;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_Inventario
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_Inventario(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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
        #region SACAR LOS DATOS DEL USUARIO
        private void CargarDatosUSuario(decimal IdUsuario) {

            var SacarInformacionUSuario = ObjData.Value.BuscaUsuarios(IdUsuario);
            foreach (var n in SacarInformacionUSuario) {

                lbSucursal_ConsultaSolicitud.Text = n.Sucursal;
                lbOficina_ConsultaSolicitud.Text = n.Oficina;
                lbDepartamento_ConsultaSolicitud.Text = n.Departamento;
                lbSolicitante_ConsultaSolicitud.Text = n.Persona;
            }
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void EstatusSolicitudConsulta() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlEstatus_ConsultaSolicitud, ObjData.Value.BuscaListas("ESTATUSSOLICITUD", null, null), true);
        }
        #endregion
        #region MOSTRAR LAS SOLICITUDES
        private void MostrarSolicitudes(decimal IdUsuario) {

            decimal? _NumeroSolicitud = string.IsNullOrEmpty(txtNumeroSolicitud_ConsultaSolicitud.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroSolicitud_ConsultaSolicitud.Text.Trim());
            DateTime? _FechaDesde = string.IsNullOrEmpty(txtFechaDesde_ConsultaSolicitud.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaDesde_ConsultaSolicitud.Text);
            DateTime? _FechaHasta = string.IsNullOrEmpty(txtFechaHasta_ConsultaSolicitud.Text.Trim()) ? new Nullable<DateTime>() : Convert.ToDateTime(txtFechaHasta_ConsultaSolicitud.Text);
            int? _Estatus = ddlEstatus_ConsultaSolicitud.SelectedValue != "-1" ? Convert.ToInt32(ddlEstatus_ConsultaSolicitud.SelectedValue) : new Nullable<int>();
            int TotalSolicitudes = 0, SolicitudesActivas = 0, SolicitudesProcesadas = 0, SolicitudesCanceladas = 0, SolicitudesRechazadas = 0;
            var MostrarListado = ObjDataSuministro.Value.BuscaSuministroSulicitud(
                _NumeroSolicitud,
                null, null, null, IdUsuario, null,
                null, null, null,
                _FechaDesde,
                _FechaHasta,
                _Estatus,
                null);
            if (MostrarListado.Count() < 1) {

                lbCantidadSolicitudes_ConsultaSolicitud.Text = "0";
                lbSolicitudesActivas_ConsultaSolicitud.Text = "0";
                lbSolicitudesProcesadas_ConsultaSolicitud.Text = "0";
                lbSolicitudesCanceladas_ConsultaSolicitud.Text = "0";
                lbSolicitudesRechazadas_ConsultaSolicitud.Text = "0";
                CurrentPage_SolicitudHeader = 0;
                rpListadoSolicitudes_ConsultaSolicitud.DataSource = null;
                rpListadoSolicitudes_ConsultaSolicitud.DataBind();
            }
            else {

                foreach (var n in MostrarListado) {

                    TotalSolicitudes = (int)n.CantidadSolicitudes;
                    SolicitudesActivas = (int)n.SolicitudesActivas;
                    SolicitudesProcesadas = (int)n.SolicitudesProcesadas;
                    SolicitudesCanceladas = (int)n.CantidadSolicitudes;
                    SolicitudesRechazadas = (int)n.SolicitudesRechazadas;
                }

                lbCantidadSolicitudes_ConsultaSolicitud.Text = TotalSolicitudes.ToString("N0");
                lbSolicitudesActivas_ConsultaSolicitud.Text = SolicitudesActivas.ToString("N0");
                lbSolicitudesProcesadas_ConsultaSolicitud.Text = SolicitudesProcesadas.ToString("N0");
                lbSolicitudesCanceladas_ConsultaSolicitud.Text = SolicitudesCanceladas.ToString("N0");
                lbSolicitudesRechazadas_ConsultaSolicitud.Text = SolicitudesRechazadas.ToString("N0");
                Paginar_SolicitudHeader(ref rpListadoSolicitudes_ConsultaSolicitud, MostrarListado, 10, ref lbCantidadPaginaVariable_ConsultaSolicitud, ref btnPrimeraPagina_ConsultaSolicitud, ref btnPaginaAnterior_ConsultaSolicitud, ref btnSiguientePagina_ConsultaSolicitud, ref btnUltimaPagina_ConsultaSolicitud);
                HandlePaging_SolicitudHeader(ref dtPaginacion_ConsultaSolicitud, ref lbPaginaActualVariable_ConsultaSolicitud);
            }
        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES DE LA PANTALLA DE MANTENIMIENTO
        private void CargarListasDesplegablesMantenimientos() {
            CargarSucursalesMantenimiento();
            CargarOficinasMantenimiento();
            CargarDepartamentosMantenimiento();
            CargarUsuariosMAntenimientos();
            CargarCategoriasMAntenimiento();
            CargarUnidadMedidaMantenimiento();
        }
        private void CargarSucursalesMantenimiento() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSucursalProceso, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinasMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlOficinaProceso, ObjData.Value.BuscaListas("OFICINA", ddlSucursalProceso.SelectedValue.ToString(), null), true);
        }
        private void CargarDepartamentosMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlDepartamentoProceso, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlSucursalProceso.SelectedValue.ToString(), ddlOficinaProceso.SelectedValue.ToString()), true);
        }
        private void CargarUsuariosMAntenimientos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlUsuarioProceso, ObjData.Value.BuscaListas("USUARIOLISTA", ddlSucursalProceso.SelectedValue.ToString(), ddlOficinaProceso.SelectedValue.ToString(), ddlDepartamentoProceso.SelectedValue.ToString()), true);
        }
        private void CargarCategoriasMAntenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCategoriaProceso, ObjData.Value.BuscaListas("SUMINISTROCATEGORIA", null, null), true);
        }
        private void CargarUnidadMedidaMantenimiento() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlUnidadMedida, ObjData.Value.BuscaListas("SUMINISTROTIPOMEDIDA", null, null), true);
        }
        #endregion
        #region MOSTRAT INVENTARIO
        private void MostrarInventario() {

            decimal? _CodigoProducto = string.IsNullOrEmpty(txtCodigoProceso.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoProceso.Text);
            string _Descripcion = string.IsNullOrEmpty(txtDescripcionProceso.Text.Trim()) ? null : txtDescripcionProceso.Text.Trim();
            int? _Categoria = ddlCategoriaProceso.SelectedValue != "-1" ? Convert.ToInt32(ddlCategoriaProceso.SelectedValue) : new Nullable<int>();
            int? _Medida = ddlUnidadMedida.SelectedValue != "-1" ? Convert.ToInt32(ddlUnidadMedida.SelectedValue) : new Nullable<int>();

            var InformacionInventario = ObjDataSuministro.Value.BuscaInventario(
                _CodigoProducto,
                null,
                Convert.ToInt32(ddlSucursalProceso.SelectedValue),
                Convert.ToInt32(ddlOficinaProceso.SelectedValue),
                _Medida,
                _Descripcion,
                null, null, null, null);
            if (InformacionInventario.Count() < 1) {

                
            }
            else {
                rpListadoInventario.DataSource = InformacionInventario;
                rpListadoInventario.DataBind();
                Paginar_Inventario(ref rpListadoInventario, InformacionInventario, 10, ref lbCantidadPaginaVariable_Inventario, ref btnPrimeraPagina_Inventario, ref btnPaginaAnterior_Inventario, ref btnSiguientePagina_Inventario, ref btnUltimaPagina_Inventario);
                HandlePaging_Inventario(ref dtPaginacion_Inventario, ref lbPaginaActual_Inventario);
            }
        }
        #endregion
        #region PROCESAR INFORMACION DE LAS SOLICITUDES ESPEJO
        private void ProcesarInformacionSolicitudesEspejo(decimal Secuencial, decimal IdUsuario, string Accion) {

            decimal CodigoArticulo = 0;
           //UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudSuministroEspejo Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudSuministroEspejo(
           //    Secuencial,
           //    CodigoArticulo,
           //    txtDescripcionRegistroSeleccionado.Text,
           //    Convert.ToInt32(ddluni
        }
        #endregion
        #region PROCESAR LA INFORMACION DE LAS SOLICITUDES ESPEJO
        private void EliminarRegistrosSolicitudesEspejo(decimal IdUsuario) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudesEspejo Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudesEspejo(
                0, 0, 0, 0, IdUsuario, 0, "", 0, 0, 0, DateTime.Now, 0, "");
            Eliminar.ProcesarInformacion();
        }
        private void CargarLosItemsAgregadosSolicitudesEspejo(decimal IdUsuario) {

            var SacarInformacion = ObjDataSuministro.Value.BuscaSuministroSolicitudesEspejo(IdUsuario);
            rpListadoRegistrosAgregados.DataSource = SacarInformacion;
            rpListadoRegistrosAgregados.DataBind();
        }
        #endregion
        #region GENERAR NUMERO DE CONECTOR
        private string GenerarNumeroConector() {

            Random NumeroConector = new Random();
            int Numero1 = NumeroConector.Next(0, 999999999);
            int Numero2 = NumeroConector.Next(0, 999999999);
            int Numero3 = NumeroConector.Next(0, 999999999);
            string Ano = DateTime.Now.Year.ToString();
            string Mes = DateTime.Now.Month.ToString();
            string Dia = DateTime.Now.Day.ToString();
            string Hora = DateTime.Now.Hour.ToString();
            string Minuto = DateTime.Now.Minute.ToString();
            string NumeroConectorGenerado = Ano + Numero1.ToString() + Mes + Numero2.ToString() + Dia + Numero3.ToString() + Hora + Minuto;
            return NumeroConectorGenerado;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "SOLICITUD DE MATERIALES";

                CargarDatosUSuario((decimal)Session["IdUsuario"]);
                UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
                Fecha.FechaMes(ref txtFechaDesde_ConsultaSolicitud, ref txtFechaHasta_ConsultaSolicitud);
                EstatusSolicitudConsulta();
                DIvBloqueDetalleRegistro.Visible = false;
            }
        }

        protected void btnConsultarInformacion_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_SolicitudHeader = 0;
            MostrarSolicitudes((decimal)Session["IdUsuario"]);
        }

        protected void btnNuevaSolicitud_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            DIVBloqueConsulta.Visible = false;
            DIVBloqueMantenimiento.Visible = true;
            //SACAMOS LOS DATOS DEL USUARIO CONECTADO
            decimal IdUsuario = (decimal)Session["IdUsuario"];
            decimal IdSucursal = 0, IdOficina = 0, IdDepartamento = 0;
            var SacarInformacion = ObjData.Value.BuscaUsuarios(
                IdUsuario);
            foreach (var n in SacarInformacion) {
                IdSucursal = (decimal)n.IdSucursal;
                IdOficina = (decimal)n.IdOficina;
                IdDepartamento = (decimal)n.IdDepartamento;

                CargarSucursalesMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSucursalProceso, n.IdSucursal.ToString());
                ddlSucursalProceso.Enabled = false;
                CargarOficinasMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlOficinaProceso, n.IdOficina.ToString());
                ddlOficinaProceso.Enabled = false;
                CargarDepartamentosMantenimiento();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlDepartamentoProceso, n.IdDepartamento.ToString());
                ddlDepartamentoProceso.Enabled = false;
                CargarUsuariosMAntenimientos();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlUsuarioProceso, n.IdUsuario.ToString());
                ddlUsuarioProceso.Enabled = false;
                CargarCategoriasMAntenimiento();
                CargarUnidadMedidaMantenimiento();
            }
            DIVSubBloqueConsultaInventario.Visible = true;
            DIVSubBloqueRegistroSeleccionado.Visible = false;
            DIVSubBloqueCompletarSolicitud.Visible = true;
            EliminarRegistrosSolicitudesEspejo(IdUsuario);
            CargarLosItemsAgregadosSolicitudesEspejo(IdUsuario);
            lbNumeroConector.Text = GenerarNumeroConector();
        }

        protected void btnPrimeraPagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ConsultaSolicitud_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ConsultaSolicitud_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSucursalProceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlOficinaProceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDepartamentoProceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultarInformacionInventario_Click(object sender, ImageClickEventArgs e)
        {
            MostrarInventario(); 
        }

        protected void btnSeleccionarInventario_Click(object sender, ImageClickEventArgs e)
        {
            DIVSubBloqueConsultaInventario.Visible = false;
            DIVSubBloqueRegistroSeleccionado.Visible = true;
            DIVSubBloqueCompletarSolicitud.Visible = false;
        }

        protected void btnPrimeraPagina_ProcesoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPaginaAnterior_ProcesoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtPaginacion_ProcesoSolicitud_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ProcesoSolicitud_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void btnSiguientePagina_ProcesoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUltimaPagina_ProcesoSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAgregarRegistroSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverRegistroSeleccionado_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrimeraPagina_Inventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void btnPaginaAnterior_Inventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario += -1;
            MostrarInventario();
            MoverValoresPaginacion_Inventario((int)OpcionesPaginacionValores_Inventario.PaginaAnterior, ref lbPaginaActual_Inventario, ref lbCantidadPaginaVariable_Inventario);
        }

        protected void dtPaginacion_Inventario_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
        }

        protected void dtPaginacion_Inventario_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_Inventario = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarInventario();
        }

        protected void btnSiguientePagina_Inventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario += 1;
            MostrarInventario();
        }

        protected void btnUltimaPagina_Inventario_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_Inventario = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarInventario();
            MoverValoresPaginacion_Inventario((int)OpcionesPaginacionValores_Inventario.PaginaAnterior, ref lbPaginaActual_Inventario, ref lbCantidadPaginaVariable_Inventario);
        }

        protected void btnGuardarSolicitud_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
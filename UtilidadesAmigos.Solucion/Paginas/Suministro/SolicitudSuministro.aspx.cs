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

                lbCodigoSucursal_Header.Text = n.IdSucursal.ToString();
                lbCodigoDepartamento_Header.Text = n.IdDepartamento.ToString();
                lbCodigoOficina_Header.Text = n.IdOficina.ToString();
                lbCodigoUsuario_Header.Text = n.IdUsuario.ToString();
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
        #region MOSTRAR INVENTARIO
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
        #region PROCESAR LA INFORMACION DE LAS SOLICITUDES ESPEJO
        private void EliminarRegistrosSolicitudesEspejo(decimal IdUsuario) {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudesEspejo Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudesEspejo(
                0, 0, 0, 0, IdUsuario, 0, "", 0, 0, 0, DateTime.Now, 0, "DELETEALL");
            Eliminar.ProcesarInformacion();
        }
        private void CargarLosItemsAgregadosSolicitudesEspejo(decimal IdUsuario) {
            var SacarInformacion = ObjDataSuministro.Value.BuscaSuministroSolicitudesEspejo(IdUsuario);
            rpListadoRegistrosAgregados.DataSource = SacarInformacion;
            rpListadoRegistrosAgregados.DataBind();
        }
        private void ProcesarInformacionSuministroEspejo(int IdSucursal, int IdOficina, int IdDepartamento, decimal IdUsuario, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudesEspejo Procesar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudesEspejo(
                0,
                IdSucursal,
                IdOficina,
                IdDepartamento,
                IdUsuario,
                Convert.ToDecimal(lbCodigoItemSeleccionado.Text),
                txtDescripcionRegistroSeleccionado.Text,
                Convert.ToInt32(lbCategoria_RegistroSeleccionado.Text),
                Convert.ToInt32(lbUnidadMedida_RegistroSeleccionado.Text),
                Convert.ToInt32(txtCantidadProcesarRegistroSeleccionado.Text),
                DateTime.Now,
                (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Activa,
                Accion);
            Procesar.ProcesarInformacion();
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
        #region PROCESAR LA INFORMACION DE LA SOLICITUD
        private void ProcesarSolicitudHeader(decimal NumeroSolicitud,string NumeroConector, decimal IdUsuario,string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroHeader Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroHeader(
                NumeroSolicitud,
                NumeroConector,
                IdUsuario,
                (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Activa,
                "INSERT");
            Guardar.ProcesarInformacion();
        }
        private void ProcesarSolicidutDetalle(decimal IdUsuario, string NumeroConector) {

            //BUSCAMOS TODOS LOS REGISTROS AGREGADOS PARA LA SOLICITUD
            var SacarInformacionEspejo = ObjDataSuministro.Value.BuscaSuministroSolicitudesEspejo(IdUsuario);
            foreach (var n in SacarInformacionEspejo) {

                //GUARDAMOS LA INFORMACION
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionDetail Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionDetail(
                    (decimal)n.Secuencial,
                    NumeroConector,
                    (decimal)n.CodigoArticulo,
                    n.DescripcionArticulo,
                    (int)n.IdUnidadMedida,
                    (int)n.Cantidad,
                    (int)n.IdSucursal,
                    (int)n.IdOficina,
                    (int)n.IdCategoria,
                    1,
                    false,
                    "INSERT");
                Guardar.ProcesarInformacion();
            }
        }
        #endregion
        #region MOSTRAR LAS SOLICITUDES
        private void MostrarSolicitudesHEader(int IdSucursal, int IdOficina, int IdDepartamento, decimal IdUsuario) {

            decimal? _NumeroSolicitud = string.IsNullOrEmpty(txtNumeroSolicitud_ConsultaSolicitud.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroSolicitud_ConsultaSolicitud.Text);
            DateTime? _FechaDesde = cbNoAgregarRangoFecha.Checked == false ? Convert.ToDateTime(txtFechaDesde_ConsultaSolicitud.Text) : new Nullable<DateTime>();
            DateTime? _FechaHasta = cbNoAgregarRangoFecha.Checked == false ? Convert.ToDateTime(txtFechaHasta_ConsultaSolicitud.Text) : new Nullable<DateTime>();
            int? _Estatus = ddlEstatus_ConsultaSolicitud.SelectedValue != "-1" ? Convert.ToInt32(ddlEstatus_ConsultaSolicitud.SelectedValue) : new Nullable<int>();

            int CantidadSolicitudes = 0, SolicitudesActivas = 0, SolicitudesProcesadas = 0, SolicitudesCanceladas = 0, SolicitudesRechazadas = 0, SolicitudesPendientes = 0;

            var Listado = ObjDataSuministro.Value.BuscaListadoSolicitudesHeader(
                IdSucursal,
                IdOficina,
                IdDepartamento,
                IdUsuario,
                _NumeroSolicitud,
                _FechaDesde,
                _FechaHasta,
                _Estatus);
            if (Listado.Count() < 1)
            {
                lbCantidadSolicitudes_ConsultaSolicitud.Text = "0";
                lbSolicitudesActivas_ConsultaSolicitud.Text = "0";
                lbSolicitudesProcesadas_ConsultaSolicitud.Text = "0";
                lbSolicitudesCanceladas_ConsultaSolicitud.Text = "0";
                lbSolicitudesRechazadas_ConsultaSolicitud.Text = "0";
                rpListadoSolicitudes_ConsultaSolicitud.DataSource = null;
                rpListadoSolicitudes_ConsultaSolicitud.DataBind();
            }
            else {

                foreach (var n in Listado) {

                    CantidadSolicitudes = (int)n.CantidadSolicitudes;
                    SolicitudesActivas = (int)n.CantidadSolicitudes_Activas;
                    SolicitudesProcesadas = (int)n.CantidadSolicitudes_Procesadas;
                    SolicitudesCanceladas = (int)n.CantidadSolicitudes_Canceladas;
                    SolicitudesRechazadas = (int)n.CantidadSolicitudes_Rechazadas;
                    SolicitudesPendientes = (int)n.CantidadSolicitudes_Pendientes;
                }
                Paginar_SolicitudHeader(ref rpListadoSolicitudes_ConsultaSolicitud, Listado, 10, ref lbCantidadPaginaVariable_ConsultaSolicitud, ref btnPrimeraPagina_ConsultaSolicitud, ref btnPaginaAnterior_ConsultaSolicitud, ref btnSiguientePagina_ConsultaSolicitud, ref btnUltimaPagina_ConsultaSolicitud);
                HandlePaging_Inventario(ref dtPaginacion_ConsultaSolicitud, ref lbPaginaActualVariable_ConsultaSolicitud);


                lbCantidadSolicitudes_ConsultaSolicitud.Text = CantidadSolicitudes.ToString("N0");
                lbSolicitudesActivas_ConsultaSolicitud.Text = SolicitudesActivas.ToString("N0");
                lbSolicitudesProcesadas_ConsultaSolicitud.Text = SolicitudesProcesadas.ToString("N0");
                lbSolicitudesCanceladas_ConsultaSolicitud.Text = SolicitudesCanceladas.ToString("N0");
                lbSolicitudesRechazadas_ConsultaSolicitud.Text = SolicitudesRechazadas.ToString("N0");
                lbSolicitudesPendientes_ConsultaSolicitud.Text = SolicitudesPendientes.ToString("N0");
            }
           

        }
        #endregion
        private void ConfiguracionInicial() {
            DIVSubBloqueConsultaInventario.Visible = false;
            DIVSubBloqueRegistroSeleccionado.Visible = false;
            DIVSubBloqueCompletarSolicitud.Visible = false;
            DIVBloqueMantenimiento.Visible = false;
            DIVBloqueConsulta.Visible = true;

            txtNumeroSolicitud_ConsultaSolicitud.Text = string.Empty;
           
            UtilidadesAmigos.Logica.Comunes.Rangofecha Fecha = new Logica.Comunes.Rangofecha();
            Fecha.FechaMes(ref txtFechaDesde_ConsultaSolicitud, ref txtFechaHasta_ConsultaSolicitud);
            EstatusSolicitudConsulta();
            DIvBloqueDetalleRegistro.Visible = false;
            cbNoAgregarRangoFecha.Checked = false;
            CargarDatosUSuario((decimal)Session["IdUsuario"]);
        }

        #region MOSTRAR EL DETALLE DE LA SOLICITUD
        private void MostrarDetalleSocilitud(string Conector) {

            var Detalle = ObjDataSuministro.Value.BuscaDetalleSolicitud(Conector);
            if (Detalle.Count() < 1) {
                rpSolicitudDetalle.DataSource = null;
                rpSolicitudDetalle.DataBind();
            }
            else {
                rpSolicitudDetalle.DataSource = Detalle;
                rpSolicitudDetalle.DataBind();
            }
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

                ConfiguracionInicial();
                MostrarSolicitudesHEader(
                    Convert.ToInt32(lbCodigoSucursal_Header.Text),
                    Convert.ToInt32(lbCodigoOficina_Header.Text),
                    Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                    Convert.ToDecimal(lbCodigoUsuario_Header.Text));
            }
        }

        protected void btnConsultarInformacion_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_SolicitudHeader = 0;
            MostrarSolicitudesHEader(
                   Convert.ToInt32(lbCodigoSucursal_Header.Text),
                   Convert.ToInt32(lbCodigoOficina_Header.Text),
                   Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                   Convert.ToDecimal(lbCodigoUsuario_Header.Text));
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
            lbIdSucursalSeleccionada_RegistroSeleccionado.Text = IdSucursal.ToString();
            lbOficina_RegistroSeleccionado.Text = IdOficina.ToString();
            lbDepartamento_RegistroSeleccionado.Text = IdDepartamento.ToString();
        }

        protected void btnPrimeraPagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_SolicitudHeader = 0;
            MostrarSolicitudesHEader(
                      Convert.ToInt32(lbCodigoSucursal_Header.Text),
                      Convert.ToInt32(lbCodigoOficina_Header.Text),
                      Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                      Convert.ToDecimal(lbCodigoUsuario_Header.Text));
        }

        protected void btnPaginaAnterior_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_SolicitudHeader += -1;
            MostrarSolicitudesHEader(
                     Convert.ToInt32(lbCodigoSucursal_Header.Text),
                     Convert.ToInt32(lbCodigoOficina_Header.Text),
                     Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                     Convert.ToDecimal(lbCodigoUsuario_Header.Text));
            MoverValoresPaginacion_SolicitudHeader((int)OpcionesPaginacionValores_SolicitudHeader.PaginaAnterior, ref lbPaginaActualVariable_ConsultaSolicitud, ref lbCantidadPaginaVariable_Inventario);
        }

        protected void dtPaginacion_ConsultaSolicitud_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacion_ConsultaSolicitud_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_SolicitudHeader = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarSolicitudesHEader(
                    Convert.ToInt32(lbCodigoSucursal_Header.Text),
                    Convert.ToInt32(lbCodigoOficina_Header.Text),
                    Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                    Convert.ToDecimal(lbCodigoUsuario_Header.Text));
        }

        protected void btnSiguientePagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_SolicitudHeader += 1;
            MostrarSolicitudesHEader(
                    Convert.ToInt32(lbCodigoSucursal_Header.Text),
                    Convert.ToInt32(lbCodigoOficina_Header.Text),
                    Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                    Convert.ToDecimal(lbCodigoUsuario_Header.Text));
        }

        protected void btnUltimaPagina_ConsultaSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_SolicitudHeader = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarSolicitudesHEader(
                  Convert.ToInt32(lbCodigoSucursal_Header.Text),
                  Convert.ToInt32(lbCodigoOficina_Header.Text),
                  Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                  Convert.ToDecimal(lbCodigoUsuario_Header.Text));
            MoverValoresPaginacion_SolicitudHeader((int)OpcionesPaginacionValores_SolicitudHeader.PaginaAnterior, ref lbPaginaActualVariable_ConsultaSolicitud, ref lbCantidadPaginaVariable_Inventario);
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
            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var CodigoItem = ((HiddenField)RegistroSeleccionado.FindControl("hfCodigoInventario")).Value.ToString();

            DIVSubBloqueConsultaInventario.Visible = false;
            DIVSubBloqueRegistroSeleccionado.Visible = true;
            DIVSubBloqueCompletarSolicitud.Visible = false;

            var SacarDatosInventario = ObjDataSuministro.Value.BuscaInventario(Convert.ToDecimal(CodigoItem));
            foreach (var n in SacarDatosInventario) {

                lbCodigoItemSeleccionado.Text = n.IdRegistro.ToString();
                txtDescripcionRegistroSeleccionado.Text = n.Articulo;
                txtCategoriaRegistroSeleccionado.Text = n.Categoria;
                txtMedidaRegistroSeleccionado.Text = n.UnidadMedida;
               // txtStockRegistroSeleccionado.Text = n.Stock.ToString();
                txtCantidadProcesarRegistroSeleccionado.Text = "1";
                lbCategoria_RegistroSeleccionado.Text = n.IdCategoria.ToString();
                lbUnidadMedida_RegistroSeleccionado.Text = n.IdUnidadMedida.ToString();
            }
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
            decimal idUsuario = (decimal)Session["IdUsuario"];
            //GUARDAMOS LA INFORMACION PARA EL ESPEJO
            ProcesarInformacionSuministroEspejo(
                Convert.ToInt32(lbIdSucursalSeleccionada_RegistroSeleccionado.Text),
                Convert.ToInt32(lbOficina_RegistroSeleccionado.Text),
                Convert.ToInt32(lbDepartamento_RegistroSeleccionado.Text),
                idUsuario,
                "INSERT");
            DIVSubBloqueConsultaInventario.Visible = true;
            DIVSubBloqueRegistroSeleccionado.Visible = false;
            DIVSubBloqueCompletarSolicitud.Visible = true;
            CargarLosItemsAgregadosSolicitudesEspejo(idUsuario);
            txtCodigoProceso.Text = string.Empty;
            txtDescripcionProceso.Text = string.Empty;
            CargarCategoriasMAntenimiento();
            CargarUnidadMedidaMantenimiento();
            rpListadoInventario.DataSource = null;
            rpListadoInventario.DataBind();
        }

        protected void btnVolverRegistroSeleccionado_Click(object sender, ImageClickEventArgs e)
        {
            DIVSubBloqueConsultaInventario.Visible = true;
            DIVSubBloqueRegistroSeleccionado.Visible = false;
            DIVSubBloqueCompletarSolicitud.Visible = true;
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

        protected void txtCodigoProceso_TextChanged(object sender, EventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void txtDescripcionProceso_TextChanged(object sender, EventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void ddlCategoriaProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }

        protected void ddlUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage_Inventario = 0;
            MostrarInventario();
        }   

        protected void btnBorrarRegitro_Click(object sender, ImageClickEventArgs e)
        {
            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var CodigoProducto = ((HiddenField)RegistroSeleccionado.FindControl("hfIdCodigoProductoAGregado")).Value.ToString();
            var Secuencia = ((HiddenField)RegistroSeleccionado.FindControl("hfSecuenciaEspejo")).Value.ToString();

            //ELIMINAMOS EL REGISTRO
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudesEspejo Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSolicitudesEspejo(
                Convert.ToInt32(Secuencia), 0, 0, 0, 0,
                Convert.ToDecimal(CodigoProducto), "", 0, 0, 0, DateTime.Now, 0, "DELETE");
            Eliminar.ProcesarInformacion();
            CargarLosItemsAgregadosSolicitudesEspejo((decimal)Session["IdUsuario"]);
        }

        protected void btnCancelarSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var NumeroSolicitud = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroSolicitud")).Value.ToString();
            var NumeroCOnector = ((HiddenField)ItemSeleccionado.FindControl("hfNumeroConector")).Value.ToString();

            int Estatus = 0;

            var ValidarEstatusSolicitud = ObjDataSuministro.Value.BuscaListadoSolicitudesHeader(
                null,
                null,
                null,
                null,
                Convert.ToDecimal(NumeroSolicitud), null, null, null);
            foreach (var n in ValidarEstatusSolicitud) {

                Estatus = (int)n.EstatusSolicitud;
            }

            switch (Estatus) {

                case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Procesada:
                    ClientScript.RegisterStartupScript(GetType(), "SolicitudProcesada()", "SolicitudProcesada();", true);
                    break;

                case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Cancelada:
                    ClientScript.RegisterStartupScript(GetType(), "SolicitudCancelada()", "SolicitudCancelada();", true);
                    break;

                case (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Rechazada:
                    ClientScript.RegisterStartupScript(GetType(), "SolicitudRechazada()", "SolicitudRechazada();", true);
                    break;

                default:
                    //CAMBIAMOS EL ESTATUS
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroHeader Cancelar = new Logica.Comunes.ProcesarMantenimientos.InformacionSuministro.ProcesarInformacionSuministroHeader(
                        Convert.ToDecimal(NumeroSolicitud),
                        NumeroCOnector,
                        0,
                        (int)UtilidadesAmigos.Logica.Comunes.Enumeraciones.EstatusSolicitudSuministro.Cancelada,
                        "CHANGESTATUS");
                    Cancelar.ProcesarInformacion();
                    CurrentPage_SolicitudHeader = 0;
                    MostrarSolicitudesHEader(
                           Convert.ToInt32(lbCodigoSucursal_Header.Text),
                           Convert.ToInt32(lbCodigoOficina_Header.Text),
                           Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                           Convert.ToDecimal(lbCodigoUsuario_Header.Text));
                    break;
            }

          
        }


        protected void btnDetalleSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            DIvBloqueDetalleRegistro.Visible = true;
            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var NumeroCOnector = ((HiddenField)RegistroSeleccionado.FindControl("hfNumeroConector")).Value.ToString();

            MostrarDetalleSocilitud(NumeroCOnector);
        }

        protected void btnGuardarSolicitud_Click(object sender, ImageClickEventArgs e)
        {
            //VALIDAMOS SI SE ENCUENTRAN REGISTROS AGREGADOS
            var ValidacionRegistrosEspejos = ObjDataSuministro.Value.BuscaSuministroSolicitudesEspejo((decimal)Session["IdUsuario"]);
            if (ValidacionRegistrosEspejos.Count() < 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "NoSeEncontraronRegistros()", "NoSeEncontraronRegistros();", true);
            }
            else
            {
                ProcesarSolicitudHeader(0, lbNumeroConector.Text, (decimal)Session["IdUsuario"], "INSERT");
                ProcesarSolicidutDetalle((decimal)Session["IdUsuario"], lbNumeroConector.Text);

                ClientScript.RegisterStartupScript(GetType(), "ProcesoCompletado()", "ProcesoCompletado();", true);
                ConfiguracionInicial();

                CurrentPage_SolicitudHeader = 0;
                MostrarSolicitudesHEader(
                       Convert.ToInt32(lbCodigoSucursal_Header.Text),
                       Convert.ToInt32(lbCodigoOficina_Header.Text),
                       Convert.ToInt32(lbCodigoDepartamento_Header.Text),
                       Convert.ToDecimal(lbCodigoUsuario_Header.Text));
            }
        }

        protected void btnVolverAtras_Click(object sender, ImageClickEventArgs e)
        {
           
            ConfiguracionInicial();
        }
    }
}
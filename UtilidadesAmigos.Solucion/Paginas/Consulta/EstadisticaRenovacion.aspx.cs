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

namespace UtilidadesAmigos.Solucion.Paginas.Consulta
{
    public partial class EstadisticaRenovacion : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataComun = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta> ObjDataConsulta = new Lazy<Logica.Logica.LogicaConsulta.LogicaConsulta>();

        enum ConceptosAgrupacion { 
        NoAgrupado=1,
        AgruparPorOficina=2,
        AgruparPorRamo=3,
        AgruparPorIntermediario=4,
        AgruparPorSupervisor=5
        }

        enum RamoPorDefecto { 
        VahiculoMotor = 106
        }

        #region CONTROL DE PAGINACION DE ESTADISTICA DE RENOVACION
        readonly PagedDataSource pagedDataSource_EstadisticaRenovacion = new PagedDataSource();
        int _PrimeraPagina_EstadisticaRenovacion, _UltimaPagina_EstadisticaRenovacion;
        private int _TamanioPagina_EstadisticaRenovacion = 10;
        private int CurrentPage_EstadisticaRenovacion
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

        private void HandlePaging_EstadisticaRenovacion(ref DataList NombreDataList, ref Label LbPaginaActual)
        {
            var dt = new DataTable();
            dt.Columns.Add("IndicePagina"); //Start from 0
            dt.Columns.Add("TextoPagina"); //Start from 1

            _PrimeraPagina_EstadisticaRenovacion = CurrentPage_EstadisticaRenovacion - 5;
            if (CurrentPage_EstadisticaRenovacion > 5)
                _UltimaPagina_EstadisticaRenovacion = CurrentPage_EstadisticaRenovacion + 5;
            else
                _UltimaPagina_EstadisticaRenovacion = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_UltimaPagina_EstadisticaRenovacion > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _UltimaPagina_EstadisticaRenovacion = Convert.ToInt32(ViewState["TotalPages"]);
                _PrimeraPagina_EstadisticaRenovacion = _UltimaPagina_EstadisticaRenovacion - 10;
            }

            if (_PrimeraPagina_EstadisticaRenovacion < 0)
                _PrimeraPagina_EstadisticaRenovacion = 0;

            //AGREGAMOS LA PAGINA EN LA QUE ESTAMOS
            int NumeroPagina = (int)CurrentPage_EstadisticaRenovacion;
            LbPaginaActual.Text = (NumeroPagina + 1).ToString();
            // Now creating page number based on above first and last page index
            for (var i = _PrimeraPagina_EstadisticaRenovacion; i < _UltimaPagina_EstadisticaRenovacion; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }


            NombreDataList.DataSource = dt;
            NombreDataList.DataBind();
        }

        private void Paginar_EstadisticaRenovacion(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label lbCantidadPagina, ref ImageButton PrimeraPagina, ref ImageButton PaginaAnterior, ref ImageButton SiguientePagina, ref ImageButton UltimaPagina)
        {
            pagedDataSource_EstadisticaRenovacion.DataSource = Listado;
            pagedDataSource_EstadisticaRenovacion.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource_EstadisticaRenovacion.PageCount;
            // lbNumeroVariable.Text = "1";
            lbCantidadPagina.Text = pagedDataSource_EstadisticaRenovacion.PageCount.ToString();

            //MOSTRAMOS LA CANTIDAD DE PAGINAS A MOSTRAR O NUMERO DE REGISTROS
            pagedDataSource_EstadisticaRenovacion.PageSize = (_NumeroRegistros == 0 ? _TamanioPagina_EstadisticaRenovacion : _NumeroRegistros);
            pagedDataSource_EstadisticaRenovacion.CurrentPageIndex = CurrentPage_EstadisticaRenovacion;

            //HABILITAMOS LOS BOTONES DE LA PAGINACION
            PrimeraPagina.Enabled = !pagedDataSource_EstadisticaRenovacion.IsFirstPage;
            PaginaAnterior.Enabled = !pagedDataSource_EstadisticaRenovacion.IsFirstPage;
            SiguientePagina.Enabled = !pagedDataSource_EstadisticaRenovacion.IsLastPage;
            UltimaPagina.Enabled = !pagedDataSource_EstadisticaRenovacion.IsLastPage;

            RptGrid.DataSource = pagedDataSource_EstadisticaRenovacion;
            RptGrid.DataBind();


            //divPaginacionComisionSupervisor.Visible = true;
        }
        enum OpcionesPaginacionValores_EstadisticaRenovacion
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion_EstadisticaRenovacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPaginas)
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

        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarOficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjDataComun.Value.BuscaListas("OFICINANORMAL", null, null), true);
        }

        private void CargarRamos() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataComun.Value.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubRamo() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubramo, ObjDataComun.Value.BuscaListas("SUBRAMO", ddlSeleccionarRamo.SelectedValue.ToString(), null), true);
        }
        #endregion

        #region PROCESO DE CARGA DE INFORMACION
        private void CargarInformacion() {

            decimal IdUsuario = (decimal)Session["IdUsuario"];
            //ELIMINAMOS DATOS
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion Eliminar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion(
                IdUsuario, 0, "", "", 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now,false,"DELETE");

            Eliminar.ProcesarInformacion();

            //BUSCAMOS LA INFORMACION A PROCESAR
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) {

                ClientScript.RegisterStartupScript(GetType(), "CamposFechaVacios()", "CamposFechaVacios();", true);

                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true); }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) { ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true); }
            }
            else {

                int? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficina.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : (int)RamoPorDefecto.VahiculoMotor;
                int? _SubRamo = ddlSeleccionarSubramo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubramo.SelectedValue) : new Nullable<int>();
                int? _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoIntermediario.Text);
                int? _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtCodigoSupervisor.Text);
                decimal? _Cliente = string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtCodigoCliente.Text);
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                bool ExcluirMotores = cbExcluirMotores.Checked;

                var BuscarInformacion = ObjDataConsulta.Value.BuscaEstadisticaRenovacionOrigen(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Oficina,
                    _Ramo,
                    _SubRamo,
                    _Poliza,
                    _Intermediario,
                    _Supervisor,
                    ExcluirMotores);

                if (BuscarInformacion.Count() < 1) { ClientScript.RegisterStartupScript(GetType(), "CamposNoEncontrados()", "CamposNoEncontrados();", true); }
                else {

                    foreach (var n in BuscarInformacion) {

                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion Guardar = new Logica.Comunes.ProcesarMantenimientos.InformacionConsulta.ProcesarInformacionEstadisticaRenovacion(
                            IdUsuario,
                            (decimal)n.Cotizacion,
                            n.Poliza,
                            n.Estatus,
                            (int)n.CodigoOficina,
                            (int)n.Ramo,
                            (decimal)n.Bruto,
                            (int)n.CodigoIntermediario,
                            (int)n.CodigoSupervisor,
                            (DateTime)n.ValidadoDesde,
                            (DateTime)n.ValidadoHasta,
                            cbExcluirMotores.Checked,
                            "INSERT");
                        Guardar.ProcesarInformacion();
                    }
                }
              //  cbRetenerInformacion.Visible = true;
            }
        }
        #endregion

        #region MOSTRAR LA ESTADISTICA DE RENOVACION
        private void MostrarEstadisticaRenovacion() {
            decimal IdUsuario = (decimal)Session["IdUsuario"];
            if (rbDetalle.Checked == true) {

              
            }
            else {
                int TipoAgrupacion = 0;
             
                if (rbNoAgrupar.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.NoAgrupado; }
                else if (rbOficina.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorOficina; }
                else if (rbRamo.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorRamo; }
                else if (rbIntermediario.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorIntermediario; }
                else if (rbSupervisor.Checked == true) { TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorSupervisor; }

                var BuscarInformacion = ObjDataConsulta.Value.BuscaEstadisticaRenovacionAgrupada(IdUsuario, TipoAgrupacion);
                Paginar_EstadisticaRenovacion(ref rpEstadisticaRenovacion, BuscarInformacion, 10, ref lbCantidadPaginaVAriableEstadisticaRenovacion, ref btnkPrimeraPaginaEstadisticaRenovacion, ref btnAnteriorEstadisticaRenovacion, ref btnSiguienteEstadisticaRenovacion, ref btnUltimoEstadisticaRenovacion);
                HandlePaging_EstadisticaRenovacion(ref dtPaginacionEstadisticaRenovacion, ref lbPaginaActualVariableEstadisticaRenovacion);
            }
           
        }
        #endregion

        #region GENERER REPORTE DE ESTADISTICA DE RENOVACION
        private void GenerarReporte(string RutaReporte, string NombreReporte,int TipoAgrupaicon, decimal IdUsuario) {

            string UsuarioBD = "sa", ClaveBD = "Pa$$W0rd";

            


            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@IdUsuario", IdUsuario);
            Reporte.SetParameterValue("@TipoAgrupacion", TipoAgrupaicon);

            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbEXcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreReporte);
            }
            else if (rbWord.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreReporte);
            }

        }
        #endregion

        #region GENERAR EL DETALLE DE LA ESTADISTICA DE RENOVACION
        private void GenerarDetalleData(decimal IdUsuario) {

            var Detalle = (from n in ObjDataConsulta.Value.DetalleEstadisticaRenovacion(IdUsuario)
                           select new
                           {
                               Poliza = n.Poliza,
                               Estatus = n.Estatus,
                               InicioVigencia = n.InicioVigencia,
                               FinVigencia = n.FinVigencia,
                               Cliente = n.Cliente,
                               TelefonoResidencia = n.TelefonoResidencia,
                               TelefonoOficina = n.TelefonoOficina,
                               Celular = n.Celular,
                               fax = n.fax,
                               Oficina = n.Oficina,
                               NombreRamo = n.NombreRamo,
                               Prima = n.Prima,
                               CodigoIntermediario = n.CodigoIntermediario,
                               Intermediario = n.Intermediario,
                               CodigoSupervisor = n.CodigoSupervisor,
                               Supervisor = n.Supervisor,
                               ValidadoDesde = n.ValidadoDesde,
                               ValidadoHasta = n.ValidadoHasta,
                               ExcluirMotores = n.ExcluirMotores,
                               CantidadRenovadas = n.CantidadRenovadas,
                               Renovada = n.Renovada,
                               MontoRenovado = n.MontoRenovado,
                               CantidadCanceladas = n.CantidadCanceladas,
                               Cancelada = n.Cancelada,
                               MontoCancelado = n.MontoCancelado,
                               Cobrado = n.Cobrado
                           }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Detalle de Estadistica de Renovacion", Detalle);
        }
        #endregion
        #region PERMISO PERFILES
        enum UsuariosPermiso
        {
            JUAN_MARCELINO_MEDINA_DIAZ = 1,
            ALFREDO_PIMENTEL = 10,
            EDUARD_GARCIA = 12,
            ING_MIGUEL_BERROA = 22,
            NOELIA_GONZALEZ = 28
        }
        private void SacarDatosUsuario(decimal IdUsuario)
        {
            Label lbControlUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
            lbControlUsuarioConectado.Text = "";

            Label lbControlOficinaUsuario = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
            lbControlOficinaUsuario.Text = "";

            var SacarDatos = ObjDataComun.Value.BuscaUsuarios(IdUsuario,
                null,
                null,
                null,
                null,
                null,
                null);
            foreach (var n in SacarDatos)
            {
                lbControlUsuarioConectado.Text = n.Persona;
                lbControlOficinaUsuario.Text = n.Departamento + " - " + n.Sucursal + " - " + n.Oficina;
                //lbDepartamento.Text = n.Departamento;
                //lbSucursal.Text = n.Sucursal;
                //lbOficina.Text = n.Oficina;
                lbIdPerfil.Text = n.IdPerfil.ToString();
            }


        }
        private void PermisoPerfil()
        {

            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                SacarDatosUsuario(Convert.ToDecimal(Session["IdUsuario"]));
                decimal IdUsuarioConectado = Convert.ToDecimal(Session["IdUsuario"]);
                decimal Hablar = Convert.ToDecimal(Session["Veronica"]);

                LinkButton LinkReporteIntermediarioAlfredo = (LinkButton)Master.FindControl("LinkReporteAlfredoIntermediarios");
                LinkReporteIntermediarioAlfredo.Visible = false;

                if (IdUsuarioConectado == (decimal)UsuariosPermiso.JUAN_MARCELINO_MEDINA_DIAZ) { LinkReporteIntermediarioAlfredo.Visible = true; }
                else if (IdUsuarioConectado == (decimal)UsuariosPermiso.ALFREDO_PIMENTEL) { LinkReporteIntermediarioAlfredo.Visible = true; }
                else if (IdUsuarioConectado == (decimal)UsuariosPermiso.EDUARD_GARCIA) { LinkReporteIntermediarioAlfredo.Visible = true; }
                else if (IdUsuarioConectado == (decimal)UsuariosPermiso.ING_MIGUEL_BERROA) { LinkReporteIntermediarioAlfredo.Visible = true; }
                else if (IdUsuarioConectado == (decimal)UsuariosPermiso.NOELIA_GONZALEZ) { LinkReporteIntermediarioAlfredo.Visible = true; }




                int IdPerfil = Convert.ToInt32(lbIdPerfil.Text);

                #region CONTROLE DEL SISTEMA
                //SUMINISTRO------------------------------------------------------------------------------------------------
                LinkButton LinkAdministracionSuministro = (LinkButton)Master.FindControl("LinkAdministracionSuministro");
                LinkButton LinkSolicitud = (LinkButton)Master.FindControl("LinkSolicitud");


                //CONSULTA----------------------------------------------------------------------------------------------------
                LinkButton LinkCartera = (LinkButton)Master.FindControl("LinkCartera");
                LinkButton LinkConsultarPersonas = (LinkButton)Master.FindControl("LinkConsultarPersonas");
                LinkButton linkProduccionPorUsuarios = (LinkButton)Master.FindControl("linkProduccionPorUsuarios");
                LinkButton linkProduccionDiaria = (LinkButton)Master.FindControl("linkProduccionDiaria");
                LinkButton linkGenerarCartera = (LinkButton)Master.FindControl("linkGenerarCartera");
                LinkButton linkCarteraIntermediarios = (LinkButton)Master.FindControl("linkCarteraIntermediarios");
                LinkButton linkComisionesCobrador = (LinkButton)Master.FindControl("linkComisionesCobrador");
                LinkButton LinkEstadisticaRenovacion = (LinkButton)Master.FindControl("LinkEstadisticaRenovacion");
                LinkButton linkValidarCoberturas = (LinkButton)Master.FindControl("linkValidarCoberturas");
                LinkButton linkGenerarReporteUAF = (LinkButton)Master.FindControl("linkGenerarReporteUAF");
                LinkButton LinkReporteReclamos = (LinkButton)Master.FindControl("LinkReporteReclamos");
                LinkButton LinkControlVisitas = (LinkButton)Master.FindControl("LinkControlVisitas");
                LinkButton LinkConsultarInformacionAsegurado = (LinkButton)Master.FindControl("LinkConsultarInformacionAsegurado");



                //REPORTES------------------------------------------------------------------------------------------------------------
                LinkButton LinkProduccionIntermediarioSupervisor = (LinkButton)Master.FindControl("LinkProduccionIntermediarioSupervisor");
                LinkButton LinkReporteCobrado = (LinkButton)Master.FindControl("LinkReporteCobrado");
                LinkButton LinkReporteAlfredoIntermediarios = (LinkButton)Master.FindControl("LinkReporteAlfredoIntermediarios");
                LinkButton LiniComisionesIntermediarios = (LinkButton)Master.FindControl("LiniComisionesIntermediarios");
                LinkButton LinkComisionesSupervisores = (LinkButton)Master.FindControl("LinkComisionesSupervisores");
                LinkButton LinkSobreComision = (LinkButton)Master.FindControl("LinkSobreComision");
                LinkButton LinkProduccionDiariaContabilidad = (LinkButton)Master.FindControl("LinkProduccionDiariaContabilidad");
                LinkButton LinkReportePrimaDeposito = (LinkButton)Master.FindControl("LinkReportePrimaDeposito");
                LinkButton LinkReporteReclamaciones = (LinkButton)Master.FindControl("LinkReporteReclamaciones");
                LinkButton LinkReclamacionesPagadas = (LinkButton)Master.FindControl("LinkReclamacionesPagadas");


                //PROCESOS
                LinkButton LinkBakupBD = (LinkButton)Master.FindControl("LinkBakupBD");
                LinkButton LinkGenerarSOlicitudChequeComisiones = (LinkButton)Master.FindControl("LinkGenerarSOlicitudChequeComisiones");
                LinkButton LinkProcesarDataAsegurado = (LinkButton)Master.FindControl("LinkProcesarDataAsegurado");
                LinkButton LinkCorregirValorDeclarativa = (LinkButton)Master.FindControl("LinkCorregirValorDeclarativa");
                LinkButton LinkCorregirLimites = (LinkButton)Master.FindControl("LinkCorregirLimites");
                LinkButton LinkEnvioCorreo = (LinkButton)Master.FindControl("LinkEnvioCorreo");
                LinkButton LinkEliminarBalance = (LinkButton)Master.FindControl("LinkEliminarBalance");
                LinkButton LinkGenerarFacturasPDF = (LinkButton)Master.FindControl("LinkGenerarFacturasPDF");
                LinkButton LinkVolantePago = (LinkButton)Master.FindControl("LinkVolantePago");
                LinkButton linkUtilidadesCobros = (LinkButton)Master.FindControl("linkUtilidadesCobros");
                LinkButton LinkAgregarDPAReclamos = (LinkButton)Master.FindControl("LinkAgregarDPAReclamos");


                //MANTENIMIENTOS
                LinkButton LinkClientes = (LinkButton)Master.FindControl("LinkClientes");
                LinkButton LinkIntermediariosSupervisores = (LinkButton)Master.FindControl("LinkIntermediariosSupervisores");
                LinkButton linkOficinas = (LinkButton)Master.FindControl("linkOficinas");
                LinkButton linkDeprtamentos = (LinkButton)Master.FindControl("linkDeprtamentos");
                LinkButton linkEmpleados = (LinkButton)Master.FindControl("linkEmpleados");
                LinkButton linkInventario = (LinkButton)Master.FindControl("linkInventario");
                LinkButton LinkDependientes = (LinkButton)Master.FindControl("LinkDependientes");
                LinkButton LinkCorreoElectronicos = (LinkButton)Master.FindControl("LinkCorreoElectronicos");
                LinkButton LinkMantenimientoPorcientoComisionPorDefecto = (LinkButton)Master.FindControl("LinkMantenimientoPorcientoComisionPorDefecto");
                LinkButton LinkMantenimientoMonedas = (LinkButton)Master.FindControl("LinkMantenimientoMonedas");


                //COTIZADOR
                LinkButton LinkCotizador = (LinkButton)Master.FindControl("LinkCotizador");


                //SEGURIDAD
                LinkButton linkUsuarios = (LinkButton)Master.FindControl("linkUsuarios");
                LinkButton linkPerfilesUsuarios = (LinkButton)Master.FindControl("linkPerfilesUsuarios");
                LinkButton linkClaveSeguridad = (LinkButton)Master.FindControl("linkClaveSeguridad");
                LinkButton LinkCorreosEmisoresProcesos = (LinkButton)Master.FindControl("LinkCorreosEmisoresProcesos");
                LinkButton linkMovimientoUsuarios = (LinkButton)Master.FindControl("linkMovimientoUsuarios");
                LinkButton linkTarjetasAccesos = (LinkButton)Master.FindControl("linkTarjetasAccesos");
                LinkButton linkOpcionMenu = (LinkButton)Master.FindControl("linkOpcionMenu");
                LinkButton linkOpcion = (LinkButton)Master.FindControl("linkOpcion");
                LinkButton linkBotones = (LinkButton)Master.FindControl("linkBotones");
                LinkButton linkPermisoUsuarios = (LinkButton)Master.FindControl("linkPermisoUsuarios");
                LinkButton LinkCredencialesBD = (LinkButton)Master.FindControl("LinkCredencialesBD");
                #endregion


                switch (IdPerfil)
                {

                    //ADMINISTRADOR
                    case 1:
                        //SUMINISTRO
                        LinkAdministracionSuministro.Visible = true;
                        LinkSolicitud.Visible = true;

                        //CONSULTA
                        LinkCartera.Visible = true;
                        LinkConsultarPersonas.Visible = true;
                        linkProduccionPorUsuarios.Visible = false; //DESCARTADO
                        linkProduccionDiaria.Visible = false; //DESCARTADO
                        linkGenerarCartera.Visible = false; //DESCARTADO
                        linkCarteraIntermediarios.Visible = false; //DESCARTADO
                        linkComisionesCobrador.Visible = true;
                        LinkEstadisticaRenovacion.Visible = true;
                        linkValidarCoberturas.Visible = true;
                        linkGenerarReporteUAF.Visible = true;
                        LinkReporteReclamos.Visible = false; //DESCARTADO
                        LinkControlVisitas.Visible = true;
                        LinkConsultarInformacionAsegurado.Visible = true;

                        //REPORTES
                        LinkProduccionIntermediarioSupervisor.Visible = true;
                        LinkReporteCobrado.Visible = true;
                        LinkReporteAlfredoIntermediarios.Visible = true;
                        LiniComisionesIntermediarios.Visible = true;
                        LinkComisionesSupervisores.Visible = true;
                        LinkSobreComision.Visible = true;
                        LinkProduccionDiariaContabilidad.Visible = true;
                        LinkReportePrimaDeposito.Visible = true;
                        LinkReporteReclamaciones.Visible = true;
                        LinkReclamacionesPagadas.Visible = true;

                        //PROCESOS
                        LinkBakupBD.Visible = true;
                        LinkGenerarSOlicitudChequeComisiones.Visible = true;
                        LinkProcesarDataAsegurado.Visible = true;
                        LinkCorregirValorDeclarativa.Visible = true;
                        LinkCorregirLimites.Visible = false; //DESCARTADO
                        LinkEnvioCorreo.Visible = false; //DESCARTADO
                        LinkEliminarBalance.Visible = false; //DESCARTADO
                        LinkGenerarFacturasPDF.Visible = false; //DESCARTADO
                        LinkVolantePago.Visible = true;
                        linkUtilidadesCobros.Visible = true;
                        LinkAgregarDPAReclamos.Visible = true;

                        //MANTENIMIENTOS
                        LinkClientes.Visible = true;
                        LinkIntermediariosSupervisores.Visible = true;
                        linkOficinas.Visible = true;
                        linkDeprtamentos.Visible = true;
                        linkEmpleados.Visible = true;
                        linkInventario.Visible = true;
                        LinkDependientes.Visible = true;
                        LinkCorreoElectronicos.Visible = false; //DESCARTADO
                        LinkMantenimientoPorcientoComisionPorDefecto.Visible = true;
                        LinkMantenimientoMonedas.Visible = true;

                        //COTIZADOR
                        LinkCotizador.Visible = false;

                        //SEGURIDAD
                        linkUsuarios.Visible = true;
                        linkPerfilesUsuarios.Visible = true;
                        linkClaveSeguridad.Visible = true;
                        LinkCorreosEmisoresProcesos.Visible = true;
                        linkMovimientoUsuarios.Visible = true;
                        linkTarjetasAccesos.Visible = true;
                        linkOpcionMenu.Visible = true;
                        linkOpcion.Visible = true;
                        linkBotones.Visible = true;
                        linkPermisoUsuarios.Visible = true;
                        LinkCredencialesBD.Visible = true;
                        break;
                    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    case 2:
                        //PERFIL DE CONTABILIDAD, AUDITORIA Y RRHH
                        //SUMINISTRO
                        LinkAdministracionSuministro.Visible = true;
                        LinkSolicitud.Visible = true;

                        //CONSULTA
                        LinkCartera.Visible = true;
                        LinkConsultarPersonas.Visible = true;
                        linkProduccionPorUsuarios.Visible = false; //DESCARTADO
                        linkProduccionDiaria.Visible = false; //DESCARTADO
                        linkGenerarCartera.Visible = false; //DESCARTADO
                        linkCarteraIntermediarios.Visible = false; //DESCARTADO
                        linkComisionesCobrador.Visible = true;
                        LinkEstadisticaRenovacion.Visible = true;
                        linkValidarCoberturas.Visible = true;
                        linkGenerarReporteUAF.Visible = true;
                        LinkReporteReclamos.Visible = false; //DESCARTADO
                        LinkControlVisitas.Visible = true;
                        LinkConsultarInformacionAsegurado.Visible = true;

                        //REPORTES
                        LinkProduccionIntermediarioSupervisor.Visible = true;
                        LinkReporteCobrado.Visible = true;
                        LinkReporteAlfredoIntermediarios.Visible = true;
                        LiniComisionesIntermediarios.Visible = true;
                        LinkComisionesSupervisores.Visible = true;
                        LinkSobreComision.Visible = true;
                        LinkProduccionDiariaContabilidad.Visible = true;
                        LinkReportePrimaDeposito.Visible = true;
                        LinkReporteReclamaciones.Visible = true;
                        LinkReclamacionesPagadas.Visible = true;

                        //PROCESOS
                        LinkBakupBD.Visible = false;
                        LinkGenerarSOlicitudChequeComisiones.Visible = true;
                        LinkProcesarDataAsegurado.Visible = false;
                        LinkCorregirValorDeclarativa.Visible = false;
                        LinkCorregirLimites.Visible = false; //DESCARTADO
                        LinkEnvioCorreo.Visible = false; //DESCARTADO
                        LinkEliminarBalance.Visible = false; //DESCARTADO
                        LinkGenerarFacturasPDF.Visible = false; //DESCARTADO
                        LinkVolantePago.Visible = true;
                        linkUtilidadesCobros.Visible = true;
                        LinkAgregarDPAReclamos.Visible = true;

                        //MANTENIMIENTOS
                        LinkClientes.Visible = false;
                        LinkIntermediariosSupervisores.Visible = true;
                        linkOficinas.Visible = false;
                        linkDeprtamentos.Visible = false;
                        linkEmpleados.Visible = false;
                        linkInventario.Visible = false;
                        LinkDependientes.Visible = true;
                        LinkCorreoElectronicos.Visible = false; //DESCARTADO
                        LinkMantenimientoPorcientoComisionPorDefecto.Visible = false;
                        LinkMantenimientoMonedas.Visible = true;

                        //COTIZADOR
                        LinkCotizador.Visible = true;

                        //SEGURIDAD
                        linkUsuarios.Visible = false;
                        linkPerfilesUsuarios.Visible = false;
                        linkClaveSeguridad.Visible = false;
                        LinkCorreosEmisoresProcesos.Visible = false;
                        linkMovimientoUsuarios.Visible = false;
                        linkTarjetasAccesos.Visible = false;
                        linkOpcionMenu.Visible = false;
                        linkOpcion.Visible = false;
                        linkBotones.Visible = false;
                        linkPermisoUsuarios.Visible = false;
                        LinkCredencialesBD.Visible = false;
                        break;

                    case 3:
                        //PERFIL DE PROCESO
                        //SUMINISTRO
                        LinkAdministracionSuministro.Visible = false;
                        LinkSolicitud.Visible = false;

                        //CONSULTA
                        LinkCartera.Visible = true;
                        LinkConsultarPersonas.Visible = true;
                        linkProduccionPorUsuarios.Visible = false; //DESCARTADO
                        linkProduccionDiaria.Visible = false; //DESCARTADO
                        linkGenerarCartera.Visible = false; //DESCARTADO
                        linkCarteraIntermediarios.Visible = false; //DESCARTADO
                        linkComisionesCobrador.Visible = true;
                        LinkEstadisticaRenovacion.Visible = true;
                        linkValidarCoberturas.Visible = true;
                        linkGenerarReporteUAF.Visible = true;
                        LinkReporteReclamos.Visible = false; //DESCARTADO
                        LinkControlVisitas.Visible = true;
                        LinkConsultarInformacionAsegurado.Visible = false;

                        //REPORTES
                        LinkProduccionIntermediarioSupervisor.Visible = true;
                        LinkReporteCobrado.Visible = true;
                        LinkReporteAlfredoIntermediarios.Visible = false;
                        LiniComisionesIntermediarios.Visible = true;
                        LinkComisionesSupervisores.Visible = true;
                        LinkSobreComision.Visible = true;
                        LinkProduccionDiariaContabilidad.Visible = false;
                        LinkReportePrimaDeposito.Visible = false;
                        LinkReporteReclamaciones.Visible = true;
                        LinkReclamacionesPagadas.Visible = true;

                        //PROCESOS
                        LinkBakupBD.Visible = false;
                        LinkGenerarSOlicitudChequeComisiones.Visible = false;
                        LinkProcesarDataAsegurado.Visible = false;
                        LinkCorregirValorDeclarativa.Visible = true;
                        LinkCorregirLimites.Visible = false; //DESCARTADO
                        LinkEnvioCorreo.Visible = false; //DESCARTADO
                        LinkEliminarBalance.Visible = false; //DESCARTADO
                        LinkGenerarFacturasPDF.Visible = false; //DESCARTADO
                        LinkVolantePago.Visible = false;
                        linkUtilidadesCobros.Visible = true;
                        LinkAgregarDPAReclamos.Visible = true;

                        //MANTENIMIENTOS
                        LinkClientes.Visible = false;
                        LinkIntermediariosSupervisores.Visible = true;
                        linkOficinas.Visible = false;
                        linkDeprtamentos.Visible = false;
                        linkEmpleados.Visible = false;
                        linkInventario.Visible = false;
                        LinkDependientes.Visible = true;
                        LinkCorreoElectronicos.Visible = false; //DESCARTADO
                        LinkMantenimientoPorcientoComisionPorDefecto.Visible = false;
                        LinkMantenimientoMonedas.Visible = false;

                        //COTIZADOR
                        LinkCotizador.Visible = true;

                        //SEGURIDAD
                        linkUsuarios.Visible = false;
                        linkPerfilesUsuarios.Visible = false;
                        linkClaveSeguridad.Visible = false;
                        LinkCorreosEmisoresProcesos.Visible = false;
                        linkMovimientoUsuarios.Visible = false;
                        linkTarjetasAccesos.Visible = false;
                        linkOpcionMenu.Visible = false;
                        linkOpcion.Visible = false;
                        linkBotones.Visible = false;
                        linkPermisoUsuarios.Visible = false;
                        LinkCredencialesBD.Visible = false;
                        break;

                    case 4:
                        //PERFIL DE CONSULTA
                        //PERFIL DE PROCESO
                        //SUMINISTRO
                        LinkAdministracionSuministro.Visible = false;
                        LinkSolicitud.Visible = false;

                        //CONSULTA
                        LinkCartera.Visible = true;
                        LinkConsultarPersonas.Visible = true;
                        linkProduccionPorUsuarios.Visible = false; //DESCARTADO
                        linkProduccionDiaria.Visible = false; //DESCARTADO
                        linkGenerarCartera.Visible = false; //DESCARTADO
                        linkCarteraIntermediarios.Visible = false; //DESCARTADO
                        linkComisionesCobrador.Visible = true;
                        LinkEstadisticaRenovacion.Visible = true;
                        linkValidarCoberturas.Visible = false;
                        linkGenerarReporteUAF.Visible = true;
                        LinkReporteReclamos.Visible = false; //DESCARTADO
                        LinkControlVisitas.Visible = true;
                        LinkConsultarInformacionAsegurado.Visible = false;

                        //REPORTES
                        LinkProduccionIntermediarioSupervisor.Visible = true;
                        LinkReporteCobrado.Visible = true;
                        LinkReporteAlfredoIntermediarios.Visible = false;
                        LiniComisionesIntermediarios.Visible = false;
                        LinkComisionesSupervisores.Visible = false;
                        LinkSobreComision.Visible = false;
                        LinkProduccionDiariaContabilidad.Visible = false;
                        LinkReportePrimaDeposito.Visible = false;
                        LinkReporteReclamaciones.Visible = true;
                        LinkReclamacionesPagadas.Visible = true;

                        //PROCESOS
                        LinkBakupBD.Visible = false;
                        LinkGenerarSOlicitudChequeComisiones.Visible = false;
                        LinkProcesarDataAsegurado.Visible = false;
                        LinkCorregirValorDeclarativa.Visible = true;
                        LinkCorregirLimites.Visible = false; //DESCARTADO
                        LinkEnvioCorreo.Visible = false; //DESCARTADO
                        LinkEliminarBalance.Visible = false; //DESCARTADO
                        LinkGenerarFacturasPDF.Visible = false; //DESCARTADO
                        LinkVolantePago.Visible = false;
                        linkUtilidadesCobros.Visible = true;
                        LinkAgregarDPAReclamos.Visible = true;

                        //MANTENIMIENTOS
                        LinkClientes.Visible = false;
                        LinkIntermediariosSupervisores.Visible = true;
                        linkOficinas.Visible = false;
                        linkDeprtamentos.Visible = false;
                        linkEmpleados.Visible = false;
                        linkInventario.Visible = false;
                        LinkDependientes.Visible = true;
                        LinkCorreoElectronicos.Visible = false; //DESCARTADO
                        LinkMantenimientoPorcientoComisionPorDefecto.Visible = false;
                        LinkMantenimientoMonedas.Visible = false;

                        //COTIZADOR
                        LinkCotizador.Visible = true;

                        //SEGURIDAD
                        linkUsuarios.Visible = false;
                        linkPerfilesUsuarios.Visible = false;
                        linkClaveSeguridad.Visible = false;
                        LinkCorreosEmisoresProcesos.Visible = false;
                        linkMovimientoUsuarios.Visible = false;
                        linkTarjetasAccesos.Visible = false;
                        linkOpcionMenu.Visible = false;
                        linkOpcion.Visible = false;
                        linkBotones.Visible = false;
                        linkPermisoUsuarios.Visible = false;
                        LinkCredencialesBD.Visible = false;
                        break;
                }




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
                lbPantalla.Text = "ESTADISTICA DE RENOVACION";


                CargarOficinas();
                CargarRamos();
                CargarSubRamo();

                rbPDF.Checked = true;
                rbNoAgrupar.Checked = true;
                cbExcluirMotores.Checked = false;
                cbRetenerInformacion.Checked = false;
            }
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoIntermediario.Text);
            txtNombreIntermediario.Text = Nombre.SacarNombreIntermediario();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor Nombre = new Logica.Comunes.SacarNombreIntermediarioSupervisor(txtCodigoSupervisor.Text);
            txtNombreSupervisor.Text = Nombre.SacarNombreSupervisor();
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            UtilidadesAmigos.Logica.Comunes.ESacarNombreCliente Nombre = new Logica.Comunes.ESacarNombreCliente(txtCodigoCliente.Text);
            txtNombreCliente.Text = Nombre.SacarCodigoCLiente();
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarInformacion();
            if (rbDetalle.Checked == true) {
                GenerarDetalleData((decimal)Session["IdUsuario"]);
            }
            else {
                CurrentPage_EstadisticaRenovacion = 0;
                MostrarEstadisticaRenovacion();
            }
            
           
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
           
            CargarInformacion();

            if (rbDetalle.Checked == true) {
                GenerarDetalleData((decimal)Session["IdUsuario"]);
            }
            else if (rbDetalle.Checked == false) {
                int TipoAgrupacion = 0;
                string TipoAgrupacionNombre = "";
                decimal IdUsuario = (decimal)Session["IdUsuario"];
                if (rbNoAgrupar.Checked == true)
                {
                    TipoAgrupacion = (int)ConceptosAgrupacion.NoAgrupado;
                    TipoAgrupacionNombre = "No Agrupado";
                }
                else if (rbOficina.Checked == true)
                {
                    TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorOficina;
                    TipoAgrupacionNombre = "Agrupado Por Oficina";
                }
                else if (rbRamo.Checked == true)
                {
                    TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorRamo;
                    TipoAgrupacionNombre = "Agrupado Por Ramo";
                }
                else if (rbIntermediario.Checked == true)
                {
                    TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorIntermediario;
                    TipoAgrupacionNombre = "Agrupado Por Intermediario";
                }
                else if (rbSupervisor.Checked == true)
                {
                    TipoAgrupacion = (int)ConceptosAgrupacion.AgruparPorSupervisor;
                    TipoAgrupacionNombre = "Agrupado Por Supervisor";
                }

                GenerarReporte(Server.MapPath("ReporteEstadisticaRenovacion.rpt"), "Reporte Estadistica de Renovacion " + TipoAgrupacionNombre, TipoAgrupacion, IdUsuario);
            }
            
        }

        protected void btnkPrimeraPaginaEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EstadisticaRenovacion = 0;
            MostrarEstadisticaRenovacion();
        }

        protected void btnAnteriorEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EstadisticaRenovacion += -1;
            MostrarEstadisticaRenovacion();
            MoverValoresPaginacion_EstadisticaRenovacion((int)OpcionesPaginacionValores_EstadisticaRenovacion.PaginaAnterior, ref lbPaginaActualVariableEstadisticaRenovacion, ref lbCantidadPaginaVAriableEstadisticaRenovacion);
        }

        protected void dtPaginacionEstadisticaRenovacion_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionEstadisticaRenovacion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage_EstadisticaRenovacion = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarEstadisticaRenovacion();
        }

        protected void btnSiguienteEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EstadisticaRenovacion += 1;
            MostrarEstadisticaRenovacion();
        }

        protected void btnUltimoEstadisticaRenovacion_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage_EstadisticaRenovacion = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarEstadisticaRenovacion();
            MoverValoresPaginacion_EstadisticaRenovacion((int)OpcionesPaginacionValores_EstadisticaRenovacion.UltimaPagina, ref lbPaginaActualVariableEstadisticaRenovacion, ref lbCantidadPaginaVAriableEstadisticaRenovacion);
        }

        protected void ddlSeleccionarRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubRamo();
        }


        protected void cbExcluirMotores_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExcluirMotores.Checked == true) {

                ddlSeleccionarRamo.Enabled = false;
                ddlSeleccionarSubramo.Enabled = false;
            }
            else if (cbExcluirMotores.Checked == false) {
                ddlSeleccionarRamo.Enabled = true;
                ddlSeleccionarSubramo.Enabled = true;
            }
        }
    }
}
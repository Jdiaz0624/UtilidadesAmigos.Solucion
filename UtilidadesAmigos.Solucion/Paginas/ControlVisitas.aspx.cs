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
using System.Web.Security;
using System.Data.SqlClient;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ControlVisitas : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objtatas = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad> ObjDataSeguridad = new Lazy<Logica.Logica.LogicaSeguridad.LogicaSeguridad>();

        enum TipoDeProceso
        {
            Visitas = 1,
            EntregaDeDocumentos = 2,
            SalidaDeDocumentos = 3
        }

        enum PermisoUsuarios { 
        CarlosMercado=9,
        ErikSonVeras=30,
        AdalgisaAlmonte=18,
        JuanMarcelino=1,
        AlfredoPimentel=10,
        MiguelBerrora=22,
        KimailiRazon=35,
        AngelaDesire=41,
        DarlenPina = 43,
            glenisbierd=48
        }
        
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
        private void HandlePaging(ref DataList NombreDataList, ref Label PaginaActual)
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
            PaginaActual.Text = (NumeroPagina + 1).ToString();
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
        private void Paginar(ref Repeater RptGrid, IEnumerable<object> Listado, int _NumeroRegistros, ref Label CantidadPagina, ref LinkButton PrimeraPagina, ref LinkButton PaginaAnterior, ref LinkButton SiguientePagina, ref LinkButton UltimaPagina)
        {
            pagedDataSource.DataSource = Listado;
            pagedDataSource.AllowPaging = true;

            ViewState["TotalPages"] = pagedDataSource.PageCount;
            // lbNumeroVariable.Text = "1";
            CantidadPagina.Text = pagedDataSource.PageCount.ToString();

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


            //divPaginacionCliente.Visible = true;
            //DivPaginacionIntermediario.Visible = true;
            //OcultarDetalle();
        }
        enum OpcionesPaginacionValores
        {
            PrimeraPagina = 1,
            SiguientePagina = 2,
            PaginaAnterior = 3,
            UltimaPagina = 4
        }
        private void MoverValoresPaginacion(int Accion, ref Label lbPaginaActual, ref Label lbCantidadPagina)
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
                    lbPaginaActual.Text = lbCantidadPagina.Text;
                    break;


            }

        }


        #endregion
        #region MOSTRAR EL LISTADO DEL CONTROL DE LAS VISITAS
        private void MostrarListadoControlCisitas() {
            int? _TipoProceso = ddlSeleccionarTipoProcesoCOnsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoProcesoCOnsulta.SelectedValue) : new Nullable<int>();
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();
            string _Remitente = string.IsNullOrEmpty(txtRemitenteConsulta.Text.Trim()) ? null : txtRemitenteConsulta.Text.Trim();
            string _Destinatario = string.IsNullOrEmpty(txtDestinatario.Text.Trim()) ? null : txtDestinatario.Text.Trim();

            DateTime? _FechaDesde = cbAgregarRangoFecha.Checked == true ? Convert.ToDateTime(txtFechaDesde.Text) : new Nullable<DateTime>();
            DateTime? _FechaHasta = cbAgregarRangoFecha.Checked == true ? Convert.ToDateTime(txtFechaHAsta.Text) : new Nullable<DateTime>();

            var Listado = ObjData.Value.BuscaControlVisitas(
                new Nullable<decimal>(),
                _TipoProceso,
                _Nombre,
                _Remitente,
                _Destinatario,
                null,
                _FechaDesde,
                _FechaHasta,
                null);
            Paginar(ref rpListadoControlVisitas, Listado, 10, ref lbCantidadPaginaVAriableControlVisistas, ref LinkPrimeraPaginaControlVisistas, ref LinkAnteriorControlVisistas, ref LinkSiguienteControlVisistas, ref LinkUltimoControlVisistas);
            HandlePaging(ref dtPaginacionControlVisistas, ref lbPaginaActualVariableControlVisistas);
            GraficarCantidadProcesos();
        }
        #endregion
        #region CARGAR EL LISTADO DE RECEPCON DE DOCUMENTOS
        private void CargarTipoProcesoCOsnsulta() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoProcesoCOnsulta, ObjData.Value.BuscaListas("TIPOPROCESORECEPCION", null, null), true);
        }
        private void CargarTipoProcesoMantenimiento() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoprocesoMantenimiento, ObjData.Value.BuscaListas("TIPOPROCESORECEPCION", null, null));
        }
        #endregion
        #region PROCESAR LA INFORMACION DEL CONTROL DE VISITAS
        private void ProcesarInformacion(decimal NoRegistro, string Accion) {

            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionControlVisitas Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionControlVisitas(
                NoRegistro,
                Convert.ToInt32(ddlTipoprocesoMantenimiento.SelectedValue),
                txtNombreMantenimiento.Text,
                txtRemitenteMantenimiento.Text,
                txtDestinatarioMantenimiento.Text,
                txtNumeroIdentificacionMantenimiento.Text,
                Convert.ToInt32(txtCantidadDocumentosMantenimiento.Text),
                Convert.ToInt32(txtCantidadPersonasMantenimiento.Text),
                (decimal)Session["IdUsuario"],
                (decimal)Session["IdUsuario"],
                txtComentarioMantenimiento.Text,
                Accion);
            Procesar.ProcesarInformacion();
        }
        #endregion
        #region VOLVER ATRAS
        private void VolverAtras() {
            DivBloqueMantenimiento.Visible = false;
            DivBloqueCOnsulta.Visible = true;
            CurrentPage = 0;
            DivGraficoControlVisitas.Visible = true;
            MostrarListadoControlCisitas();


            btnConsultarNuevo.Enabled = true;
            btnReporteNuevo.Enabled = true;
            btnNuevoNuevo.Enabled = true;
            btnModificarNuevo.Enabled = false;
            btnEliminarNuevo.Enabled = false;
            LinkPrimeraPaginaControlVisistas.Enabled = true;
            LinkSiguienteControlVisistas.Enabled = true;
            LinkAnteriorControlVisistas.Enabled = true;
            LinkUltimoControlVisistas.Enabled = true;
            btnRestablecerNuevo.Enabled = false;


            txtCantidadDocumentosVistaPrevia.Text = string.Empty;
            txtCantidadPersonasVistaPrevia.Text = string.Empty;
            txtCreadoPorVistaPrevia.Text = string.Empty;
            txtModificadoPorVistaPrevia.Text = string.Empty;
            txtFechaModificadoVistaPrevia.Text = string.Empty;
            txtComentarioVistaPrevia.Text = string.Empty;

            DivBloqueDetalle.Visible = false;
        }
        #endregion
        #region BLOQUEAR Y DESBLOQUEAR CONTROLES
        private void BloquearControles() {
            ddlTipoprocesoMantenimiento.Enabled = false;
            txtNombreMantenimiento.Enabled = false;
            txtNumeroIdentificacionMantenimiento.Enabled = false;
            txtRemitenteMantenimiento.Enabled = false;
            txtDestinatarioMantenimiento.Enabled = false;
            txtCantidadDocumentosMantenimiento.Enabled = false;
            txtCantidadPersonasMantenimiento.Enabled = false;
            txtComentarioMantenimiento.Enabled = false;
        }
        private void DesbloquearControles() {
            ddlTipoprocesoMantenimiento.Enabled = true;
            txtNombreMantenimiento.Enabled = true;
            txtNumeroIdentificacionMantenimiento.Enabled = true;
            txtRemitenteMantenimiento.Enabled = true;
            txtDestinatarioMantenimiento.Enabled = true;
            txtCantidadDocumentosMantenimiento.Enabled = true;
            txtCantidadPersonasMantenimiento.Enabled = true;
            txtComentarioMantenimiento.Enabled = true;
        }
        #endregion
        #region ACCION DEL DROP
        private void AccionDrop(int AccionDrop) {

            switch (AccionDrop) {
                case (int)TipoDeProceso.Visitas:
                    txtCantidadDocumentosMantenimiento.Enabled = false;
                    txtCantidadDocumentosMantenimiento.Text = "1";
                    txtCantidadPersonasMantenimiento.Enabled = true;
                    txtCantidadPersonasMantenimiento.Text = "1";

                    txtRemitenteMantenimiento.Enabled = true;
                    txtRemitenteMantenimiento.Text = string.Empty;
                    break;

                case (int)TipoDeProceso.EntregaDeDocumentos:
                    txtCantidadDocumentosMantenimiento.Enabled = true;
                    txtCantidadDocumentosMantenimiento.Text = "1";
                    txtCantidadPersonasMantenimiento.Enabled = false;
                    txtCantidadPersonasMantenimiento.Text = "1";

                    txtRemitenteMantenimiento.Enabled = true;
                    txtRemitenteMantenimiento.Text = string.Empty;
                    break;

                case (int)TipoDeProceso.SalidaDeDocumentos:
                    txtCantidadDocumentosMantenimiento.Enabled = true;
                    txtCantidadDocumentosMantenimiento.Text = "1";
                    txtCantidadPersonasMantenimiento.Enabled = false;
                    txtCantidadPersonasMantenimiento.Text = "1";

                    txtRemitenteMantenimiento.Enabled = false;
                    txtRemitenteMantenimiento.Text = "Futuro Seguros";
                    break;
            }
        }
        #endregion
        #region REPORTE DE CONTROL DE VISITAS
        private void GenerarReporte(string RutaReporte, string NombreArchivo,decimal UsuarioGenera) {
            decimal? _NoRegistro = new Nullable<decimal>();
            decimal? _UsuarioDigita = new Nullable<decimal>();
            int? _TipoProceso = ddlSeleccionarTipoProcesoCOnsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoProcesoCOnsulta.SelectedValue) : new Nullable<int>();
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? null : txtNombreConsulta.Text.Trim();
            string _Remitente = string.IsNullOrEmpty(txtRemitenteConsulta.Text.Trim()) ? null : txtRemitenteConsulta.Text.Trim();
            string _Destinatario = string.IsNullOrEmpty(txtDestinatario.Text.Trim()) ? null : txtDestinatario.Text.Trim();

            DateTime? _FechaDesde = cbAgregarRangoFecha.Checked == true ? Convert.ToDateTime(txtFechaDesde.Text) : new Nullable<DateTime>();
            DateTime? _FechaHasta = cbAgregarRangoFecha.Checked == true ? Convert.ToDateTime(txtFechaHAsta.Text) : new Nullable<DateTime>();

            ReportDocument Reporte = new ReportDocument();
            Reporte.Load(RutaReporte);
            Reporte.Refresh();

            Reporte.SetParameterValue("@NoRegistro", _NoRegistro);
            Reporte.SetParameterValue("@IdTipoProcesoRecepcion", _TipoProceso);
            Reporte.SetParameterValue("@Nombre", _Nombre);
            Reporte.SetParameterValue("@Remitente", _Remitente);
            Reporte.SetParameterValue("@Destinatario", _Destinatario);
            Reporte.SetParameterValue("@UsuarioDigita", _UsuarioDigita);
            Reporte.SetParameterValue("@FechaDigitaDesde", _FechaDesde);
            Reporte.SetParameterValue("@FechaDigitaHasta", _FechaHasta);
            Reporte.SetParameterValue("@UsuarioGenera", UsuarioGenera);

            Reporte.SetDatabaseLogon("sa", "Pa$$W0rd");

            if (rbPDF.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbEXcel.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbWord.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
            else if (rbTXT.Checked == true) {
                Reporte.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreArchivo);
            }

        }
        #endregion
        #region GRAFICOS
        private void GraficarCantidadProcesos() {
            int[] CantidadRegistros = new int[3];
            string[] NombreProceso = new string[3];
            int Contador = 0;

            //VALIDAMOS LOS CAMPOS PARA PASARLO COMO PARAMETROS
            decimal _NoProceso = 0;
            int _TipoProcesoRecepcion = ddlSeleccionarTipoProcesoCOnsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarTipoProcesoCOnsulta.SelectedValue) : 0;
            string _Nombre = string.IsNullOrEmpty(txtNombreConsulta.Text.Trim()) ? "N/A" : txtNombreConsulta.Text.Trim();
            string _Remitente = string.IsNullOrEmpty(txtRemitenteConsulta.Text.Trim()) ? "N/A" : txtRemitenteConsulta.Text.Trim();
            string _Destinatario = string.IsNullOrEmpty(txtDestinatario.Text.Trim()) ? "N/A" : txtDestinatario.Text.Trim();
            decimal _UsuarioDigita = 0;
            DateTime _FechaDigita = cbAgregarRangoFecha.Checked == true ? Convert.ToDateTime(txtFechaDesde.Text) : Convert.ToDateTime("1942-01-01");
            DateTime _FechaHAsta = cbAgregarRangoFecha.Checked == true ? Convert.ToDateTime(txtFechaHAsta.Text) : Convert.ToDateTime("1942-01-01");
            decimal _UsuarioGenera = 0;

            //GENERAMOS EL GRAFICO CON LOS DATOS RECOLECTADOS

            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Comando = new SqlCommand("EXEC [Utililades].[SP_GENERA_GRAFICO_CONTROL_VISITA] @NoRegistro,@IdTipoProcesoRecepcion,@Nombre,@Remitente,@Destinatario,@UsuarioDigita,@FechaDigitaDesde,@FechaDigitaHasta,@UsuarioGenera", Conexion);

            Comando.Parameters.AddWithValue("@NoRegistro", SqlDbType.Decimal).Value = _NoProceso;
            Comando.Parameters.AddWithValue("@IdTipoProcesoRecepcion", SqlDbType.Int).Value = _TipoProcesoRecepcion;
            Comando.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = _Nombre;
            Comando.Parameters.AddWithValue("@Remitente", SqlDbType.VarChar).Value = _Remitente;
            Comando.Parameters.AddWithValue("@Destinatario", SqlDbType.VarChar).Value = _Destinatario;
            Comando.Parameters.AddWithValue("@UsuarioDigita", SqlDbType.Decimal).Value = _UsuarioDigita;
            Comando.Parameters.AddWithValue("@FechaDigitaDesde", SqlDbType.DateTime).Value = _FechaDigita;
            Comando.Parameters.AddWithValue("@FechaDigitaHasta", SqlDbType.DateTime).Value = _FechaHAsta;
            Comando.Parameters.AddWithValue("@UsuarioGenera", SqlDbType.Decimal).Value = _UsuarioGenera;

            Conexion.Open();

            SqlDataReader Reader = Comando.ExecuteReader();
            while (Reader.Read()) {
                CantidadRegistros[Contador] = Convert.ToInt32(Reader.GetInt32(1));
                NombreProceso[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();

            GraControlVisitas.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,k}";
            GraControlVisitas.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraControlVisitas.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraControlVisitas.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraControlVisitas.Series["Serie"].Points.DataBindXY(NombreProceso, CantidadRegistros);
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

            var SacarDatos = ObjData.Value.BuscaUsuarios(IdUsuario,
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
            if (!IsPostBack)
            {

                Label lbNombreUsuarioCOnectado = (Label)Master.FindControl("lbUsuarioConectado");
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbNombreUsuarioCOnectado.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbNombrePantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbNombrePantalla.Text = "CONTROL DE VISITAS";

                DivFechaDesde.Visible = false;
                DivFechaHAsta.Visible = false;

                CargarTipoProcesoCOsnsulta();
                CargarTipoProcesoMantenimiento();
                MostrarListadoControlCisitas();
                cbAgregarRangoFecha.Checked = false;
                rbPDF.Checked = true;

                DivBloqueMantenimiento.Visible = false;

                btnNuevoNuevo.Visible = false;
                btnModificarNuevo.Visible = false;
                btnEliminarNuevo.Visible = false;

                decimal IdUsuario = (decimal)Session["IdUsuario"];

                if (IdUsuario == (decimal)PermisoUsuarios.CarlosMercado)
                {
                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = false;
                }
                else if (IdUsuario == (decimal)PermisoUsuarios.ErikSonVeras)
                {
                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = false;
                }
                else if (IdUsuario == (decimal)PermisoUsuarios.AdalgisaAlmonte)
                {
                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = false;
                }
                else if (IdUsuario == (decimal)PermisoUsuarios.JuanMarcelino)
                {
                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = true;
                }
                else if (IdUsuario == (decimal)PermisoUsuarios.AlfredoPimentel)
                {
                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = true;
                }
                else if (IdUsuario == (decimal)PermisoUsuarios.MiguelBerrora)
                {
                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = true;
                }
                else if (IdUsuario == (decimal)PermisoUsuarios.KimailiRazon)
                {

                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = false;
                }
                else if (IdUsuario == (decimal)PermisoUsuarios.AngelaDesire)
                {
                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = false;
                }
                else if (IdUsuario == (decimal)PermisoUsuarios.DarlenPina){
                    btnNuevoNuevo.Visible = true;
                    btnModificarNuevo.Visible = true;
                    btnEliminarNuevo.Visible = false;                                                                                    
            }
            else if (IdUsuario == (decimal)PermisoUsuarios.glenisbierd)
            {

                btnNuevoNuevo.Visible = true;
                btnModificarNuevo.Visible = true;
                btnEliminarNuevo.Visible = false;
            }
            else
            {
                btnNuevoNuevo.Visible = false;
                btnModificarNuevo.Visible = false;
                btnEliminarNuevo.Visible = false;
            }
                PermisoPerfil();

            }
        }

        protected void cbAgregarRangoFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarRangoFecha.Checked == true) {
                DivFechaDesde.Visible = true;
                DivFechaHAsta.Visible = true;
            }
            else {
                DivFechaDesde.Visible = false;
                DivFechaHAsta.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
          
        }

        protected void LinkPrimeraPaginaControlVisistas_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoControlCisitas();
        }

        protected void LinkAnteriorControlVisistas_Click(object sender, EventArgs e)
        {
            CurrentPage += -1;
            MostrarListadoControlCisitas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableControlVisistas, ref lbCantidadPaginaVAriableControlVisistas);
        }

        protected void dtPaginacionControlVisistas_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dtPaginacionControlVisistas_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            MostrarListadoControlCisitas();
        }

        protected void LinkSiguienteControlVisistas_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            MostrarListadoControlCisitas();
        }

        protected void LinkUltimoControlVisistas_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            MostrarListadoControlCisitas();
            MoverValoresPaginacion((int)OpcionesPaginacionValores.PaginaAnterior, ref lbPaginaActualVariableControlVisistas, ref lbCantidadPaginaVAriableControlVisistas);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
           
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
           
            
        }

        protected void ddlTipoprocesoMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccionDrop(Convert.ToInt32(ddlTipoprocesoMantenimiento.SelectedValue));
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnConsultarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            CurrentPage = 0;
            MostrarListadoControlCisitas();
        }

        protected void btnReporteNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                decimal UsuarioGenera = (decimal)Session["IdUsuario"];

                GenerarReporte(Server.MapPath("ControlVisitas.rpt"), "Reporte de Control de Visitas", UsuarioGenera);
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void btnNuevoNuevo_Click(object sender, ImageClickEventArgs e)
        {
            DesbloquearControles();
            lbIdRegistroSeleccionado.Text = "0";
            lbAccionTomarSeleccionado.Text = "INSERT";
            CargarTipoProcesoMantenimiento();
            txtNombreMantenimiento.Text = string.Empty;
            txtNumeroIdentificacionMantenimiento.Text = string.Empty;
            txtRemitenteMantenimiento.Text = string.Empty;
            txtDestinatarioMantenimiento.Text = string.Empty;
            txtCantidadDocumentosMantenimiento.Text = string.Empty;
            txtCantidadPersonasMantenimiento.Text = string.Empty;
            txtComentarioMantenimiento.Text = string.Empty;
            DivBloqueCOnsulta.Visible = false;
            DivBloqueMantenimiento.Visible = true;

            AccionDrop(Convert.ToInt32(ddlTipoprocesoMantenimiento.SelectedValue));
        }

        protected void btnModificarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            DesbloquearControles();
            ddlTipoprocesoMantenimiento.Enabled = false;
            lbAccionTomarSeleccionado.Text = "UPDATE";
            DivBloqueCOnsulta.Visible = false;
            DivBloqueMantenimiento.Visible = true;
        }

        protected void btnEliminarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            BloquearControles();
            lbAccionTomarSeleccionado.Text = "DELETE";
            DivBloqueCOnsulta.Visible = false;
            DivBloqueMantenimiento.Visible = true;
        }

        protected void btnRestablecerNuevo_Click(object sender, ImageClickEventArgs e)
        {
            VolverAtras();
        }

        protected void btnSeleccionarRegistrosNuevo_Click(object sender, ImageClickEventArgs e)
        {
            var ItemSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfNoRegistroseleccionado = ((HiddenField)ItemSeleccionado.FindControl("hfNoRegistro")).Value.ToString();
            lbIdRegistroSeleccionado.Text = hfNoRegistroseleccionado.ToString();

            var BuscarInformacionSeleccionada = ObjData.Value.BuscaControlVisitas(
                Convert.ToDecimal(hfNoRegistroseleccionado),
                null, null, null, null, null, null, null, null);
            Paginar(ref rpListadoControlVisitas, BuscarInformacionSeleccionada, 1, ref lbCantidadPaginaVAriableControlVisistas, ref LinkPrimeraPaginaControlVisistas, ref LinkAnteriorControlVisistas, ref LinkSiguienteControlVisistas, ref LinkUltimoControlVisistas);
            HandlePaging(ref dtPaginacionControlVisistas, ref lbPaginaActualVariableControlVisistas);

            foreach (var n in BuscarInformacionSeleccionada)
            {

                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlTipoprocesoMantenimiento, n.IdTipoProcesoRecepcion.ToString());
                txtNombreMantenimiento.Text = n.Nombre;
                txtNumeroIdentificacionMantenimiento.Text = n.NumeroIdentificacion;
                txtRemitenteMantenimiento.Text = n.Remitente;
                txtDestinatarioMantenimiento.Text = n.Destinatario;
                txtCantidadDocumentosMantenimiento.Text = n.CantidadDocumentos.ToString();
                txtCantidadPersonasMantenimiento.Text = n.CantidadPersonas.ToString();
                txtComentarioMantenimiento.Text = n.Comentario;


                int CantidadDocumentos = (int)n.CantidadDocumentos;
                txtCantidadDocumentosVistaPrevia.Text = CantidadDocumentos.ToString("N0");
                int CantidadPersonas = (int)n.CantidadPersonas;
                txtCantidadPersonasVistaPrevia.Text = CantidadPersonas.ToString("N0");
                txtCreadoPorVistaPrevia.Text = n.DigitadoPor;
                txtModificadoPorVistaPrevia.Text = n.Modificado;
                txtFechaModificadoVistaPrevia.Text = n.FechaModifica;
                txtComentarioVistaPrevia.Text = n.Comentario;
            }
            btnConsultarNuevo.Enabled = false;
            btnReporteNuevo.Enabled = false;
            btnNuevoNuevo.Enabled = false;
            btnModificarNuevo.Enabled = true;
            btnEliminarNuevo.Enabled = true;
            LinkPrimeraPaginaControlVisistas.Enabled = false;
            LinkSiguienteControlVisistas.Enabled = false;
            LinkAnteriorControlVisistas.Enabled = false;
            LinkUltimoControlVisistas.Enabled = false;
            btnRestablecerNuevo.Enabled = true;
            DivBloqueDetalle.Visible = true;
            DivGraficoControlVisitas.Visible = false;
        }

        protected void btnGuardarNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                ProcesarInformacion(Convert.ToDecimal(lbIdRegistroSeleccionado.Text), lbAccionTomarSeleccionado.Text);
                VolverAtras();
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void btnVolverNuevo_Click(object sender, ImageClickEventArgs e)
        {
            VolverAtras();
        }

   

        protected void txtNombreMantenimiento_TextChanged(object sender, EventArgs e)
        {
            int TipoProcesoSeleccionado = Convert.ToInt32(ddlTipoprocesoMantenimiento.SelectedValue);
            if (TipoProcesoSeleccionado == (int)TipoDeProceso.Visitas)
            {

                txtRemitenteMantenimiento.Text = txtNombreMantenimiento.Text;
            }
            else if (TipoProcesoSeleccionado == (int)TipoDeProceso.EntregaDeDocumentos) { }
            else if (TipoProcesoSeleccionado == (int)TipoDeProceso.SalidaDeDocumentos) { }
        }

        protected void btnSeleccionarRegistros_Click(object sender, EventArgs e)
        {
          
        }
    }
}
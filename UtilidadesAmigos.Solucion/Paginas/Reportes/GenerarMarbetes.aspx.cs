using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarMarbetes : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjdataProcesos = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        #region MOSTRAR EL LISTADO DE LOS REGISTROS
        private void MostrarListadoPolizasMarbete()
        {
            if (cbOtrosFiltros.Checked)
            {
                //BUSCAMOS POR CHASIS O POR PLACA (SI AMBOS CAMPOS ESTAN VACIOS NO BUSCA NADA)
                if (string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()) && string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CamposChasisPlacaVacios()", "CamposChasisPlacaVacios();", true);
                }
                else
                {
                    string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                    string _Item = string.IsNullOrEmpty(txtItemConsulta.Text.Trim()) ? null : txtItemConsulta.Text.Trim();
                    string _Chasis = string.IsNullOrEmpty(txtChasisConsulta.Text.Trim()) ? null : txtChasisConsulta.Text.Trim();
                    string _Placa = string.IsNullOrEmpty(txtPlacaConsulta.Text.Trim()) ? null : txtPlacaConsulta.Text.Trim();

                    var BuscarRegistros = ObjdataProcesos.Value.GenerarDatosParaMarbeteVehiculos(
                        _Poliza,
                        _Item,
                        _Chasis,
                        _Placa);
                    if (BuscarRegistros.Count() < 1)
                    {
                        lbCantidadRegistrosVariable.Text = "0";
                    }
                    else
                    {
                        gvListadoPoliza.DataSource = BuscarRegistros;
                        gvListadoPoliza.DataBind();

                        int CantidadRegistros = 0;
                        foreach (var n in BuscarRegistros)
                        {
                            CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                            lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                        }
                    }
                }
            }
            else
            {
                //BUSCMAOS POR POLIZA E ITEM (CAMPO POLIZA OBLIGATORIO)
                if (string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoPolizaVacio()", "CampoPolizaVacio();", true);
                }
                else
                {
                    string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                    string _Item = string.IsNullOrEmpty(txtItemConsulta.Text.Trim()) ? null : txtItemConsulta.Text.Trim();

                    var Buscarregistros = ObjdataProcesos.Value.GenerarDatosParaMarbeteVehiculos(
                        _Poliza,
                        _Item,
                        null,
                        null);
                    if (Buscarregistros.Count() < 1)
                    {
                        lbCantidadRegistrosVariable.Text = "0";
                    }
                    else
                    {
                        gvListadoPoliza.DataSource = Buscarregistros;
                        gvListadoPoliza.DataBind();

                        int CantidadRegistros = 0;
                        foreach (var n in Buscarregistros)
                        {
                            CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                            lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                        }
                    }
                }

            }
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLES
        private void MostrarControles()
        {
            lbTituloDatosPolizas.Visible = true;
            lbPolizaMantenimiento.Visible = true;
            txtPolizaMantenimiento.Visible = true;
            lbCotizacionMantenimiento.Visible = true;
            txtCotizacionMantenimeinto.Visible = true;
            lbCodigoClienteMantenimiento.Visible = true;
            txtCodigoClienteMantenimiento.Visible = true;
            lbItemMantenimiento.Visible = true;
            txtItemMantenimiento.Visible = true;
            lbNombreClienteMantenimiento.Visible = true;
            txtNombreClienteMantenimiento.Visible = true;
            lbNombreAseguradoMantenimiento.Visible = true;
            txtNombreAseguradoMantenimiento.Visible = true;
            lbInicioVigenciaMantenimeinto.Visible = true;
            txtInicioVigenciaMantenimiento.Visible = true;
            lbFinVigenciaMantenimiento.Visible = true;
            txtFinVigenciaMantenimiento.Visible = true;
            lbTipoVehiculoMantenimiento.Visible = true;
            txtTipoVehiculoMantenimiento.Visible = true;
            lbMarcaMantenimiento.Visible = true;
            txtMarcaMantenimeinto.Visible = true;
            lbModeloMantenimiento.Visible = true;
            txtModeloMantenimeinto.Visible = true;
            lbCapacidadMantenimiento.Visible = true;
            txtCapacidadMantenimeinto.Visible = true;
            lbChasisMantenimiento.Visible = true;
            txtChasisMantenimiento.Visible = true;
            lbPlacaMantenimiento.Visible = true;
            txtPlacaMantenimiento.Visible = true;
            lbColorMantenimiento.Visible = true;
            txtColorMantenimiento.Visible = true;
            lbAnoMantenimiento.Visible = true;
            txtAnoMantenimiento.Visible = true;
            lbUsoMantenimiento.Visible = true;
            txtUsoMantenimiento.Visible = true;
            lbValorVehiculo.Visible = true;
            txtValorVehiculo.Visible = true;
            lbFianzaJudicialMantenimiento.Visible = true;
            txtFianzaJudicialMantenimiento.Visible = true;
            lbVendedorMantenimiento.Visible = true;
            txtVendedorMantenimiento.Visible = true;
            lbGruaMantenimiento.Visible = true;
            txtGruaMantenimiento.Visible = true;
            lbAeroAmbulanciaMantenimiento.Visible = true;
            txtAeroAmbulancia.Visible = true;
            lbOtrosServiciosMantenimiento.Visible = true;
            txtOtrosServiciosMantenimiento.Visible = true;
            btnImprimirMarbete.Visible = true;
            btnRestablecer.Visible = true;
        }
        private void OcultarControles()
        {
            lbTituloDatosPolizas.Visible = false;
            lbPolizaMantenimiento.Visible = false;
            txtPolizaMantenimiento.Visible = false;
            lbCotizacionMantenimiento.Visible = false;
            txtCotizacionMantenimeinto.Visible = false;
            lbCodigoClienteMantenimiento.Visible = false;
            txtCodigoClienteMantenimiento.Visible = false;
            lbItemMantenimiento.Visible = false;
            txtItemMantenimiento.Visible = false;
            lbNombreClienteMantenimiento.Visible = false;
            txtNombreClienteMantenimiento.Visible = false;
            lbNombreAseguradoMantenimiento.Visible = false;
            txtNombreAseguradoMantenimiento.Visible = false;
            lbInicioVigenciaMantenimeinto.Visible = false;
            txtInicioVigenciaMantenimiento.Visible = false;
            lbFinVigenciaMantenimiento.Visible = false;
            txtFinVigenciaMantenimiento.Visible = false;
            lbTipoVehiculoMantenimiento.Visible = false;
            txtTipoVehiculoMantenimiento.Visible = false;
            lbMarcaMantenimiento.Visible = false;
            txtMarcaMantenimeinto.Visible = false;
            lbModeloMantenimiento.Visible = false;
            txtModeloMantenimeinto.Visible = false;
            lbCapacidadMantenimiento.Visible = false;
            txtCapacidadMantenimeinto.Visible = false;
            lbChasisMantenimiento.Visible = false;
            txtChasisMantenimiento.Visible = false;
            lbPlacaMantenimiento.Visible = false;
            txtPlacaMantenimiento.Visible = false;
            lbColorMantenimiento.Visible = false;
            txtColorMantenimiento.Visible = false;
            lbAnoMantenimiento.Visible = false;
            txtAnoMantenimiento.Visible = false;
            lbUsoMantenimiento.Visible = false;
            txtUsoMantenimiento.Visible = false;
            lbValorVehiculo.Visible = false;
            txtValorVehiculo.Visible = false;
            lbFianzaJudicialMantenimiento.Visible = false;
            txtFianzaJudicialMantenimiento.Visible = false;
            lbVendedorMantenimiento.Visible = false;
            txtVendedorMantenimiento.Visible = false;
            lbGruaMantenimiento.Visible = false;
            txtGruaMantenimiento.Visible = false;
            lbAeroAmbulanciaMantenimiento.Visible = false;
            txtAeroAmbulancia.Visible = false;
            lbOtrosServiciosMantenimiento.Visible = false;
            txtOtrosServiciosMantenimiento.Visible = false;
            btnImprimirMarbete.Visible = false;
            btnRestablecer.Visible = false;
        }
        private void LimpiarControles()
        {
            txtPolizaMantenimiento.Text = string.Empty;
            txtCotizacionMantenimeinto.Text = string.Empty;
            txtCodigoClienteMantenimiento.Text = string.Empty;
            txtItemMantenimiento.Text = string.Empty;
            txtNombreClienteMantenimiento.Text = string.Empty;
            txtNombreAseguradoMantenimiento.Text = string.Empty;
            txtInicioVigenciaMantenimiento.Text = string.Empty;
            txtFinVigenciaMantenimiento.Text = string.Empty;
            txtTipoVehiculoMantenimiento.Text = string.Empty;
            txtMarcaMantenimeinto.Text = string.Empty;
            txtModeloMantenimeinto.Text = string.Empty;
            txtCapacidadMantenimeinto.Text = string.Empty;
            txtChasisMantenimiento.Text = string.Empty;
            txtPlacaMantenimiento.Text = string.Empty;
            txtColorMantenimiento.Text = string.Empty;
            txtAnoMantenimiento.Text = string.Empty;
            txtUsoMantenimiento.Text = string.Empty;
            txtValorVehiculo.Text = string.Empty;
            txtFianzaJudicialMantenimiento.Text = string.Empty;
            txtVendedorMantenimiento.Text = string.Empty;
            txtGruaMantenimiento.Text = string.Empty;
            txtAeroAmbulancia.Text = string.Empty;
            txtOtrosServiciosMantenimiento.Text = string.Empty;

        }
        #endregion
        #region IMPRIMIR REPORTE
        private void ImprimirMarbete(decimal IdUsuario, string RutaReporte, string UsuaruoBD, string ClaveBD/*, string NombreArchivo*/)
        {
            try
            {
                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_MARBETE] @IdUsuario";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal);
                comando.Parameters["@IdUsuario"].Value = IdUsuario;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetDatabaseLogon(UsuaruoBD, ClaveBD);
                //Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);

                Factura.PrintToPrinter(1, true, 0, 2);
                //  crystalReportViewer1.ReportSource = Factura;
            }
            catch (Exception) { }

        }

        private void ImprimirMarbeteHoja(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBD, string Nombrearchivo) {
            try
            {
                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_MARBETE] @IdUsuario";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal);
                comando.Parameters["@IdUsuario"].Value = IdUsuario;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetDatabaseLogon(UsuarioBD, ClaveBD);
                Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, Nombrearchivo);

                //Factura.PrintToPrinter(1, true, 0, 2);
                //  crystalReportViewer1.ReportSource = Factura;
            }
            catch (Exception) { }
        }
        #endregion
        #region GUARDAR LOS DATOS DEL HISTORIAL
        private void GuardarHistorial(int TipoImpresion) {
            string NombreUsuario = "";
            string Accion = "";
            

            //SACAR EL NOMBRE DEL USUARIO
            var SacarNombreusuario = ObjDataGeneral.Value.BuscaUsuarios(Convert.ToDecimal(lbIdusuario.Text));
            foreach (var n in SacarNombreusuario) {
                NombreUsuario = n.Persona;
            }


            //VALIDAMOS SI EL REGISTRO EXISTE PARA DETERMINAR SI SE INSERTA O SE ACTUALIZA
            var Validar = ObjdataProcesos.Value.BuscaHistoricoImpresionMarbetes(
                new Nullable<decimal>(),
                txtPolizaMantenimiento.Text,
                txtItemMantenimiento.Text,
                txtInicioVigenciaMantenimiento.Text,
                txtFinVigenciaMantenimiento.Text,
                Convert.ToDecimal(txtCotizacionMantenimeinto.Text),null,null,null,null,null,null,null,null,null,
                TipoImpresion);
            if (Validar.Count() < 1) {
                Accion = "INSERT";
            }
            else {
                Accion = "UPDATE";
            }

            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarHistoricoImpresionMarbetes ProcesarHistorico = new Logica.Comunes.Reportes.ProcesarHistoricoImpresionMarbetes(
                0,
                txtPolizaMantenimiento.Text,
                Convert.ToDecimal(txtCotizacionMantenimeinto.Text),
                Convert.ToDecimal(txtCodigoClienteMantenimiento.Text),
                Convert.ToInt32(txtItemMantenimiento.Text),
                txtNombreClienteMantenimiento.Text,
                txtInicioVigenciaMantenimiento.Text,
                txtFinVigenciaMantenimiento.Text,
                txtNombreAseguradoMantenimiento.Text,
                txtTipoVehiculoMantenimiento.Text,
                txtMarcaMantenimeinto.Text,
                txtModeloMantenimeinto.Text,
                txtChasisConsulta.Text,
                txtPlacaConsulta.Text,
                txtColorMantenimiento.Text,
                txtUsoMantenimiento.Text,
                txtAnoMantenimiento.Text,
                txtCapacidadMantenimeinto.Text,
                Convert.ToDecimal(txtValorVehiculo.Text),
                txtFianzaJudicialMantenimiento.Text,
                txtVendedorMantenimiento.Text,
                txtGruaMantenimiento.Text,
                txtAeroAmbulancia.Text,
                txtOtrosServiciosMantenimiento.Text,
                NombreUsuario,
                TipoImpresion,
                0,
                Accion);
            ProcesarHistorico.ProcesarInformacion();
        }
        #endregion
        #region HISTORICO DE IMPRESION
        private void HistoricoImpresion() {
            string _Poliza = string.IsNullOrEmpty(txtPolizaHistorico.Text.Trim()) ? null : txtPolizaHistorico.Text.Trim();
            string _Item = string.IsNullOrEmpty(txtItemHistorico.Text.Trim()) ? null : txtItemHistorico.Text.Trim();

            var Buscar = ObjdataProcesos.Value.BuscaHistoricoImpresionMarbetes(
                new Nullable<decimal>(),
                _Poliza,
                _Item,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                Convert.ToDateTime(txtFechaDesdeHistorico.Text),
                Convert.ToDateTime(txtFechaHastaHistorico.Text));
            gvHistoricoImpresion.DataSource = Buscar;
            gvHistoricoImpresion.DataBind();
            if (Buscar.Count() < 1)
            {
                lbCantidadImpresoPVCVariable.Text = "0";
                lbCantidadImpresoHojaVariable.Text = "0";
                lbCantidadRegistrosVariableHistorico.Text = "0";
            }
            else {
                int CantidadImprecionPVC = 0, CantidadImpresionHoja = 0, CantidadRregistros = 0;

                foreach (var n in Buscar) {
                    CantidadImprecionPVC = Convert.ToInt32(n.CandidadImpresionesPVC);
                    CantidadImpresionHoja = Convert.ToInt32(n.CandidadImpresionesHoja);
                    CantidadRregistros = Convert.ToInt32(n.CandidadRegistros);

                    lbCantidadImpresoPVCVariable.Text = CantidadImprecionPVC.ToString("N0");
                    lbCantidadImpresoHojaVariable.Text = CantidadImpresionHoja.ToString("N0");
                    lbCantidadRegistrosVariableHistorico.Text = CantidadRregistros.ToString("N0");
                }
            }
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

            var SacarDatos = ObjDataGeneral.Value.BuscaUsuarios(IdUsuario,
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
            if (!IsPostBack) {
                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = Nombre.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR MARBETES";

                cbOtrosFiltros.Checked = false;
                rbMarbetePVC.Checked = true;
                lbIdusuario.Text = Session["IdUsuario"].ToString();
                rbImprimirPVC.Checked = true;
                rbProcesarDataDetalleHistorico.Checked = true;
                rbProcesarDataDetalleHistorico.Visible = false;
                rbProcesarDataResumidaHistorico.Visible = false;
                PermisoPerfil();
            }
        }
      

        protected void cbOtrosFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOtrosFiltros.Checked)
            {
                rbBuscarPorChasis.Visible = true;
                rbBuscarPorPlaca.Visible = true;
                rbBuscarPorChasis.Checked = true;
            }
            else {
                rbBuscarPorChasis.Visible = false;
                rbBuscarPorPlaca.Visible = false;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarListadoPolizasMarbete();
            LimpiarControles();
            OcultarControles();
        }

        protected void gvListadoPoliza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoPoliza.PageIndex = e.NewPageIndex;
            MostrarListadoPolizasMarbete();
        }

        protected void gvListadoPoliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow GV = gvListadoPoliza.SelectedRow;

            MostrarControles();
            var BuscarRegistroSeleccionado = ObjdataProcesos.Value.GenerarDatosParaMarbeteVehiculos(
                GV.Cells[0].Text,
                GV.Cells[1].Text,
                null, null);
            foreach (var n in BuscarRegistroSeleccionado) {
                txtPolizaMantenimiento.Text = n.Poliza;
                txtCotizacionMantenimeinto.Text = n.Cotizacion.ToString();
                txtCodigoClienteMantenimiento.Text = n.CodigoCliente.ToString();
                txtItemMantenimiento.Text = n.Secuencia.ToString();
                txtNombreClienteMantenimiento.Text = n.NombreCliente;
                txtNombreAseguradoMantenimiento.Text = n.Asegurado;
                txtInicioVigenciaMantenimiento.Text = n.InicioVigencia;
                txtFinVigenciaMantenimiento.Text = n.FinVigencia;
                txtTipoVehiculoMantenimiento.Text = n.TipoVehiculo;
                txtMarcaMantenimeinto.Text = n.Marca;
                txtModeloMantenimeinto.Text = n.Modelo;
                txtCapacidadMantenimeinto.Text = n.Capacidad;
                txtChasisMantenimiento.Text = n.Chasis;
                txtPlacaMantenimiento.Text = n.Placa;
                txtColorMantenimiento.Text = n.Color;
                txtAnoMantenimiento.Text = n.Ano;
                txtUsoMantenimiento.Text = n.Uso;
                decimal ValorVehiculo = Convert.ToDecimal(n.ValorVehiculo);
                txtValorVehiculo.Text = ValorVehiculo.ToString("N2");
                txtFianzaJudicialMantenimiento.Text = n.FianzaJudicial;
                txtVendedorMantenimiento.Text = n.Vendedor;
                txtGruaMantenimiento.Text = n.Grua;
                txtAeroAmbulancia.Text = n.AeroAmbulancia;
                txtOtrosServiciosMantenimiento.Text = n.OtrosServicios;
            }
            gvListadoPoliza.DataSource = BuscarRegistroSeleccionado;
            gvListadoPoliza.DataBind();
        }

        protected void btnImprimirMarbete_Click(object sender, EventArgs e)
        {
            //VERIFICAMOS SI EL USUAIRO TIENE PERMISO PARA IMPRIMI MARBETES
            bool PermisoImpresionMarbete = false;

            var Validar = ObjDataGeneral.Value.BuscaUsuarios(Convert.ToDecimal(lbIdusuario.Text), null, null, null, null, null, null, null, null);
            foreach (var n in Validar) {
                PermisoImpresionMarbete = Convert.ToBoolean(n.PermisoImpresionMarbete0);
            }
            if (PermisoImpresionMarbete == false) {
                //NO TIENE PERMISO
                ClientScript.RegisterStartupScript(GetType(), "PermisoDenegado()", "PermisoDenegado();", true);
            }
            else {
                //TIENE PERMISO
                //ELIMINAMOS LOS DATOS DEL USUARIO
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionImpresionMarbetes Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionImpresionMarbetes(
                    Convert.ToDecimal(lbIdusuario.Text), "", 0, 0, 0, "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", 0, "DELETE");
                Procesar.ProcesarInformacion();

                //GUARDAR LOS DATOS ITERANDO LOS DATOS DEL MARBETE
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionImpresionMarbetes Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionImpresionMarbetes(
                        Convert.ToDecimal(lbIdusuario.Text),
                        txtPolizaMantenimiento.Text,
                        Convert.ToDecimal(txtCotizacionMantenimeinto.Text),
                        Convert.ToDecimal(txtCodigoClienteMantenimiento.Text),
                        Convert.ToInt32(txtItemMantenimiento.Text),
                        txtNombreClienteMantenimiento.Text,
                        txtInicioVigenciaMantenimiento.Text,
                        txtFinVigenciaMantenimiento.Text,
                        txtNombreAseguradoMantenimiento.Text,
                        txtTipoVehiculoMantenimiento.Text,
                        txtMarcaMantenimeinto.Text,
                        txtModeloMantenimeinto.Text,
                       txtChasisMantenimiento.Text,
                       txtPlacaMantenimiento.Text,
                       txtColorMantenimiento.Text,
                       txtUsoMantenimiento.Text,
                       txtAnoMantenimiento.Text,
                       txtCapacidadMantenimeinto.Text,
                       Convert.ToDecimal(txtValorVehiculo.Text),
                       txtFianzaJudicialMantenimiento.Text,
                       txtVendedorMantenimiento.Text,
                       txtGruaMantenimiento.Text,
                       txtAeroAmbulancia.Text,
                       txtOtrosServiciosMantenimiento.Text,
                       1, "INSERT");
                Guardar.ProcesarInformacion();

                // 

              

                if (rbImprimirPVC.Checked == true && rbImprimirHoja.Checked==false) {
                    //GUARDMOS LOS DATOS DEL HISTORIAL
                    GuardarHistorial(1);
                   ImprimirMarbete(Convert.ToDecimal(lbIdusuario.Text), Server.MapPath("Marbete.rpt"), "sa", "Pa$$W0rd");
                }
                else if (rbImprimirHoja.Checked == true && rbImprimirPVC.Checked==false) {
                    GuardarHistorial(2);
                    string NombreArchivo = "";
                    NombreArchivo = "Marbete " + txtPolizaMantenimiento.Text + " Item " + txtItemMantenimiento.Text;
                    ImprimirMarbeteHoja(Convert.ToDecimal(lbIdusuario.Text), Server.MapPath("Marbete.rpt"), "sa", "Pa$$W0rd", NombreArchivo);
                   // ImprimirMarbete(Convert.ToDecimal(lbIdusuario.Text), Server.MapPath("Marbete.rpt"), "sa", "Pa$$W0rd");
                }
            }
            LimpiarControles();
            OcultarControles();
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OcultarControles();
        }

        protected void rbImprimirPVC_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnConsultarHistorico_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeHistorico.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaHistorico.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtFechaDesdeHistorico.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaHistorico.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaHistorico()", "FechaHastaHistorico();", true);
                }
            }
            else {
                HistoricoImpresion();
            }
        }

        protected void btnExportarExelHistorixo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesdeHistorico.Text.Trim()) || string.IsNullOrEmpty(txtFechaHastaHistorico.Text.Trim())) {
                if (string.IsNullOrEmpty(txtFechaDesdeHistorico.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "FechaDesdeVacio()", "FechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHastaHistorico.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "FechaHastaHistorico()", "FechaHastaHistorico();", true);
                }

            }
            else {
                if (rbProcesarDataResumidaHistorico.Checked) {
                    //ELIMINAMOS
                    UtilidadesAmigos.Logica.Entidades.Procesos.EHistoricoImpresionResumido Eliminar = new Logica.Entidades.Procesos.EHistoricoImpresionResumido();
                    Eliminar.IdUsuario = Convert.ToDecimal(lbIdusuario.Text);
                    var MAN = ObjdataProcesos.Value.MantenimientoHistoricoImpresionMarbeteResumido(Eliminar, "DELETE");

                    //BUSCAMOS LOS REGISTROS QUE SE VAN A EXPORTAR
                    string _Poliza = string.IsNullOrEmpty(txtPolizaHistorico.Text.Trim()) ? null : txtPolizaHistorico.Text.Trim();
                    string _Item = string.IsNullOrEmpty(txtItemHistorico.Text.Trim()) ? null : txtItemHistorico.Text.Trim();

                    var Buscar = ObjdataProcesos.Value.BuscaHistoricoImpresionMarbetes(
                        new Nullable<decimal>(),
                        _Poliza,
                        _Item,
                        null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                        Convert.ToDateTime(txtFechaDesdeHistorico.Text),
                        Convert.ToDateTime(txtFechaHastaHistorico.Text));
                    foreach (var n in Buscar) {
                        UtilidadesAmigos.Logica.Entidades.Procesos.EHistoricoImpresionResumido Guardar = new Logica.Entidades.Procesos.EHistoricoImpresionResumido();

                        Guardar.IdUsuario = Convert.ToDecimal(lbIdusuario.Text);
                        Guardar.IdRegistro = Convert.ToDecimal(n.IdRegistro);
                        Guardar.UsuarioImprime = n.UsuarioImprime;
                        Guardar.TipoImprecion = n.TipoImpresion;
                        Guardar.CantidadImpresion = Convert.ToInt32(n.CantidadImpreso);
                        Guardar.CantidadPVC = Convert.ToInt32(n.CandidadImpresionesPVC);
                        Guardar.CantidadHoja = Convert.ToInt32(n.CandidadImpresionesHoja);
                        Guardar.TotalImpresiones = Convert.ToInt32(n.CandidadImpresiones);
                        Guardar.CantidadMovimientos = Convert.ToInt32(n.CandidadRegistros);

                        var MAN2 = ObjdataProcesos.Value.MantenimientoHistoricoImpresionMarbeteResumido(Guardar, "INSERT");
                    }

                    var ExportarResumen = (from n in ObjdataProcesos.Value.BuscaHistoricoImpresionMarbeteResumido(Convert.ToDecimal(lbIdusuario.Text))
                                           select new {
                                               Usuario =n.UsuarioImprime,
                                               TipoImpresion=n.TipoImprecion,
                                               CantidadImpresion=n.CantidadImpresion,
                                               CantidadPVC=n.CantidadPVC,
                                               CantidadHoja=n.CantidadHoja,
                                               TotalImpresiones=n.TotalImpresiones,
                                               CantidadMovimientos=n.CantidadMovimientos

                                           }).ToList();
                    string Nombre = "";
                    Nombre = "Reporte de Impresiones Resumido " + txtFechaDesdeHistorico.Text + " - " + txtFechaHastaHistorico.Text;
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(Nombre, ExportarResumen);

                }
                else
                {
                    string _Poliza = string.IsNullOrEmpty(txtPolizaHistorico.Text.Trim()) ? null : txtPolizaHistorico.Text.Trim();
                    string _Item = string.IsNullOrEmpty(txtItemHistorico.Text.Trim()) ? null : txtItemHistorico.Text.Trim();

                    var exportar = (from n in ObjdataProcesos.Value.BuscaHistoricoImpresionMarbetes(
                        new Nullable<decimal>(),
                        _Poliza,
                        _Item,
                        null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                        Convert.ToDateTime(txtFechaDesdeHistorico.Text),
                        Convert.ToDateTime(txtFechaHastaHistorico.Text))
                                    select new
                                    {
                                        UsuarioImprime = n.UsuarioImprime,
                                        FechaImpresion = n.FechaCreado,
                                        TipoImpresion = n.TipoImpresion,
                                        CantidadImpreso = n.CantidadImpreso,
                                        Poliza = n.Poliza,
                                        Item = n.Secuencia,
                                        Cliente = n.NombreCliente,
                                        Asegurado = n.Asegurado,
                                        InicioVigencia = n.InicioVigencia,
                                        FinVigencia = n.FinVigencia,
                                        Tipo = n.TipoVehiculo,
                                        Marca = n.MarcaVehiculo,
                                        Modelo = n.ModeloVehiculo,
                                        Chasis = n.Chasis,
                                        Placa = n.Placa,
                                        Color = n.Color,
                                        Uso = n.uso,
                                        Ano = n.Ano,
                                        Capacidad = n.Capacidad,
                                        ValorVehiculo = n.ValorVehiculo,
                                        FianzaJudicial = n.FianzaJudicial,
                                        Intermediario = n.Vendedor,
                                        Grua = n.Grua,
                                        AeroAmbulancia = n.AeroAmbulancia,
                                        OtrosServicios = n.OtrosServicios,
                                        CantidadImprecionPVC = n.CandidadImpresionesPVC,
                                        CantidadImpresionHoja = n.CandidadImpresionesHoja,
                                        CantidadImpresiones = n.CandidadImpresiones,
                                        CantidadRegistros = n.CandidadRegistros
                                    }).ToList();
                    string Nombre = "";
                    Nombre = "Historico de Impresion " + txtFechaDesdeHistorico.Text + " - " + txtFechaHastaHistorico.Text;
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(Nombre, exportar);
                }
            }
        }

        protected void gvHistoricoImpresion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHistoricoImpresion.PageIndex = e.NewPageIndex;
            HistoricoImpresion();
        }
    }
}
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
using System.IO;
using System.Drawing;
using System.Speech.Synthesis;
using System.Threading;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ProduccionPorUsuarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();


        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarSucursales() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSUcursalConsulta, ObjData.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinas() {

            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficina, ObjData.Value.BuscaListas("OFICINA", ddlSeleccionarSUcursalConsulta.SelectedValue, null), true);
        }
        private void CargarDepartamentos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarDepartamento, ObjData.Value.BuscaListas("DEPARTAMENTO", ddlSeleccionarSUcursalConsulta.SelectedValue, ddlSeleccionarOficina.SelectedValue), true);
        }
        private void CargarUsuarios() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUsuario, ObjData.Value.BuscaListas("EMPLEADO", ddlSeleccionarOficina.SelectedValue, ddlSeleccionarDepartamento.SelectedValue), true);
        }
        #endregion
        #region IMPRIMIR REPORTE
        private void ImprimirFactura(decimal IdUsuario, string RutaReporte, string UsuaruoBD, string ClaveBD, string NombreArchivo)
        {
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_GENERAR_REPORTE_PRODUCCION_USUARIO_RESUMIDO] @IdUsuario";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal);
                comando.Parameters["@IdUsuario"].Value = IdUsuario;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuario", IdUsuario);
                Factura.SetDatabaseLogon(UsuaruoBD, ClaveBD);
                Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);

                //  Factura.PrintToPrinter(1, false, 0, 1);
                //  crystalReportViewer1.ReportSource = Factura;



            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al generar la factura de venta, favor de contactar al administrador del sistema, codigo de error--> " + ex.Message, VariablesGlobales.NombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirReportePduccionDetalle(decimal IdUsuario, string RutaReporte, string UsuaruoBD, string ClaveBD, string NombreArchivo)
        {
            try
            {

                ReportDocument Factura = new ReportDocument();

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EXEC [Utililades].[SP_BUSCA_DATA_REPORTE_PRODUCCION_USUARIO_DETALLE] @IdUsuaio";
                comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                comando.Parameters.Add("@IdUsuaio", SqlDbType.Decimal);
                comando.Parameters["@IdUsuaio"].Value = IdUsuario;

                Factura.Load(RutaReporte);
                Factura.Refresh();
                Factura.SetParameterValue("@IdUsuaio", IdUsuario);
                Factura.SetDatabaseLogon(UsuaruoBD, ClaveBD);
                Factura.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);

                //  Factura.PrintToPrinter(1, false, 0, 1);
                //  crystalReportViewer1.ReportSource = Factura;



            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al generar la factura de venta, favor de contactar al administrador del sistema, codigo de error--> " + ex.Message, VariablesGlobales.NombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void BuscarProduccion() {
            decimal? _Sucursal = ddlSeleccionarSUcursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSUcursalConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlSeleccionarDepartamento.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue) : new Nullable<decimal>();
            decimal? _Empleado = ddlSeleccionarUsuario.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue) : new Nullable<decimal>();
            int TipoMovimiento = 0;
            if (rbBuscarProduccion.Checked)
            {
                TipoMovimiento = 1;
            }
            else if (rbBuscarPagos.Checked)
            {
                TipoMovimiento = 2;
            }

            //GENERAR LA DATA EN RESUMEN
            if (rbGenerarDaraResumido.Checked) {
                try
                {
                    var Buscar = ObjData.Value.BuscaProduccionPorUsuarios(
                             Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                             Convert.ToDateTime(txtFechaHasta.Text),
                             _Sucursal,
                             _Oficina,
                             _Departamento,
                             _Empleado,
                             TipoMovimiento);
                    gvListadoProduccion.DataSource = Buscar;
                    gvListadoProduccion.DataBind();
                    if (Buscar.Count() < 1)
                    {
                        lbTotalMontoVariable.Text = "0";
                        lbTotalRegistrosVariable.Text = "0";
                    }
                    else
                    {
                        decimal Cantidadregistros = 0, TotalPrima = 0;
                        foreach (var n in Buscar)
                        {
                            Cantidadregistros = Convert.ToDecimal(n.TotalRegistros);
                            TotalPrima = Convert.ToDecimal(n.TotalValor);
                            lbTotalMontoVariable.Text = TotalPrima.ToString("N2");
                            lbTotalRegistrosVariable.Text = Cantidadregistros.ToString("N0");
                        }
                    }
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                }
            }
            //GENERAR LA DATA EN DETALLE
            else if (rbGenerarDataDetalle.Checked) {
                try {
                    var BuscarDetalle = ObjData.Value.BuscaProduccionUsuarioDetalle(
                        Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        _Sucursal,
                        _Oficina,
                        _Departamento,
                        _Empleado,
                        TipoMovimiento);
                    gvListadoProduccionDetalle.DataSource = BuscarDetalle;
                    gvListadoProduccionDetalle.DataBind();
                    if (BuscarDetalle.Count() < 1)
                    {
                        lbTotalMontoVariable.Text = "0";
                        lbTotalRegistrosVariable.Text = "0";
                    }
                    else {
                        foreach (var n in BuscarDetalle) {
                            decimal TotalMonto = 0, TotalRegistros = 0;

                            TotalMonto = Convert.ToDecimal(n.TotalValor);
                            TotalRegistros = Convert.ToDecimal(n.TotalRegistros);
                            lbTotalMontoVariable.Text = TotalMonto.ToString("N2");
                            lbTotalRegistrosVariable.Text = TotalRegistros.ToString("N0");
                        }
                    }
                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                rbBuscarProduccion.Checked = true;
                CargarSucursales();
                CargarOficinas();
                CargarDepartamentos();
                CargarUsuarios();
                PermisoPerfil();
            }
        }

        protected void rbBuscarProduccion_CheckedChanged(object sender, EventArgs e)
        {
            lbTotalMovimientosLetrero.Visible = true;
            lbTotalRegistrosVariable.Visible = true;
            lbTotalRegistrosCerrar.Visible = true;
            Label1.Visible = true;
        }

        protected void rbBuscarPagos_CheckedChanged(object sender, EventArgs e)
        {
            lbTotalMovimientosLetrero.Visible = false;
            lbTotalRegistrosVariable.Visible = false;
            lbTotalRegistrosCerrar.Visible = false;
            Label1.Visible = false;
        }


        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            BuscarProduccion();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            decimal? _Sucursal = ddlSeleccionarSUcursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSUcursalConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlSeleccionarDepartamento.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue) : new Nullable<decimal>();
            decimal? _Empleado = ddlSeleccionarUsuario.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue) : new Nullable<decimal>();
            int TipoMovimiento = 0;

            if (rbBuscarProduccion.Checked)
            {
                TipoMovimiento = 1;
            }
            else if (rbBuscarPagos.Checked)
            {
                TipoMovimiento = 2;
            }
            //GENERAR LA DATA EN RESUMEN
            if (rbGenerarDaraResumido.Checked) {
                try
                {
                    var Exportar = (from n in ObjData.Value.BuscaProduccionPorUsuarios(
                        Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        _Sucursal,
                        _Oficina,
                        _Departamento,
                        _Empleado,
                        TipoMovimiento)
                                    select new
                                    {
                                        Sucursal = n.Sucursal,
                                        Oficina = n.Oficina,
                                        Departamento = n.Departamento,
                                        Usuario = n.Usuario,
                                        Concepto = n.Concepto,
                                        Cantidad = n.Cantidad,
                                        Total = n.Total

                                    }).ToList();
                    string Nombre = "";
                    if (rbBuscarProduccion.Checked)
                    {
                        Nombre = "Listado de Produccion desde " + txtFechaDesdeConsulta.Text + " Hasta " + txtFechaHasta.Text;
                    }
                    else if (rbBuscarPagos.Checked)
                    {
                        Nombre = "Listado de Pagos desde " + txtFechaDesdeConsulta.Text + " Hasta " + txtFechaHasta.Text;
                    }
                    UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(Nombre, Exportar);
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorConsulta", "ErrorConsulta();", true);
                }
            }
            //GENERAR LA DATA EN DETALLE
            else if (rbGenerarDataDetalle.Checked) {
                var ExportarDetalle = (from n in ObjData.Value.BuscaProduccionUsuarioDetalle(
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Sucursal,
                    _Oficina,
                    _Departamento,
                    _Empleado,
                    TipoMovimiento)
                                       select new {
                                           Sucursal=n.Sucursal,
                                           Oficina=n.Oficina,
                                           Departamento=n.Departamento,
                                           Usuario=n.Usuario,
                                           Concepto=n.Concepto,
                                           Poliza=n.Poliza,
                                           Monto=n.Monto

                                       }).ToList();
                string NombreArchivo = "";
                if (rbBuscarProduccion.Checked) {
                    NombreArchivo = "Detalle de Produccion Desde " + txtFechaDesdeConsulta.Text + " Hasta " + txtFechaHasta.Text;
                }
                if (rbBuscarPagos.Checked){
                    NombreArchivo = "Detalle de pagos Desde " + txtFechaDesdeConsulta.Text + " Hasta " + txtFechaHasta.Text;
                }
                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(NombreArchivo, ExportarDetalle);
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            decimal? _Sucursal = ddlSeleccionarSUcursalConsulta.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarSUcursalConsulta.SelectedValue) : new Nullable<decimal>();
            decimal? _Oficina = ddlSeleccionarOficina.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarOficina.SelectedValue) : new Nullable<decimal>();
            decimal? _Departamento = ddlSeleccionarDepartamento.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarDepartamento.SelectedValue) : new Nullable<decimal>();
            decimal? _Empleado = ddlSeleccionarUsuario.SelectedValue != "-1" ? Convert.ToDecimal(ddlSeleccionarUsuario.SelectedValue) : new Nullable<decimal>();
            int TipoMovimiento = 0;
            if (rbBuscarProduccion.Checked)
            {
                TipoMovimiento = 1;
            }
            else if (rbBuscarPagos.Checked)
            {
                TipoMovimiento = 2;
            }


            //GENERAR LA DATA EN RESUMEN
            if (rbGenerarDaraResumido.Checked) {
                //ELIMINAMOS INFORMAICON
                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarProduccionPorUsuarioResumido Eliminar = new Logica.Comunes.Reportes.ProcesarProduccionPorUsuarioResumido(
                    Convert.ToDecimal(Session["IdUsuario"]), "", "", "", "", "", 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
                Eliminar.ProcesarInformacion();

                //BUSCAMOS LOS DATOS A PROCESAR
                

                var BuscarRegistros = ObjData.Value.BuscaProduccionPorUsuarios(
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Sucursal,
                    _Oficina,
                    _Departamento,
                    _Empleado,
                    TipoMovimiento);
                foreach (var n in BuscarRegistros)
                {
                    UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarProduccionPorUsuarioResumido Guardar = new Logica.Comunes.Reportes.ProcesarProduccionPorUsuarioResumido(
                        Convert.ToDecimal(Session["IdUsuario"]),
                        n.Sucursal,
                        n.Oficina,
                        n.Departamento,
                        n.Usuario,
                        n.Concepto,
                        Convert.ToDecimal(n.Cantidad),
                        Convert.ToDecimal(n.Total),
                        TipoMovimiento,
                        Convert.ToDecimal(n.TotalRegistros),
                        Convert.ToDecimal(n.TotalValor),
                        Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        "INSERT");
                    Guardar.ProcesarInformacion();
                }
                string NombreArchivo = "";

                if (rbBuscarProduccion.Checked)
                {
                    NombreArchivo = "Reporte de Produccion";
                }
                else if (rbBuscarPagos.Checked)
                {
                    NombreArchivo = "Reporte de Pagos";
                }
                ImprimirFactura(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ProduccionUsuarioResumido.rpt"), "sa", "Pa$$W0rd", NombreArchivo);
            }

            //GENERAR LA DATA EN DETALLE
            else if (rbGenerarDataDetalle.Checked) {
                //ELIMINAMOS EL REGISTRO
                UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionProduccuinPorUsuarioDetalle Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionProduccuinPorUsuarioDetalle(
                    Convert.ToDecimal(Session["IdUsuario"]), DateTime.Now, DateTime.Now, "", "", "", "", "", "", 0, 0, 0, "DELETE");
                Eliminar.ProcesarInformacionProduccionUsuarioDetalle();

                //BUSCAMOS LA INFORFORMACION A PROCESAR
                var BuscarDetalle = ObjData.Value.BuscaProduccionUsuarioDetalle(
                    Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _Sucursal,
                    _Oficina,
                    _Departamento,
                    _Empleado,
                    TipoMovimiento);
                foreach (var n in BuscarDetalle) {
                    UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionProduccuinPorUsuarioDetalle Guardar = new Logica.Comunes.Reportes.ProcesarInformacionProduccuinPorUsuarioDetalle(
                        Convert.ToDecimal(Session["IdUsuario"]),
                        Convert.ToDateTime(txtFechaDesdeConsulta.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        n.Sucursal,
                        n.Oficina,
                        n.Departamento,
                        n.Usuario,
                        n.Concepto,
                        n.Poliza,
                        Convert.ToDecimal(n.Monto),
                        Convert.ToDecimal(n.TotalRegistros),
                        Convert.ToDecimal(n.TotalValor),
                        "INSERT");
                    Guardar.ProcesarInformacionProduccionUsuarioDetalle();
                }
                string NombreArchivo = "";

                if (rbBuscarProduccion.Checked)
                {
                    NombreArchivo = "Reporte de Produccion Detalle";
                }
                else if (rbBuscarPagos.Checked)
                {
                    NombreArchivo = "Reporte de Pagos Detalle";
                }
                ImprimirReportePduccionDetalle(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ProduccionPorUsuarioDetalle.rpt"), "sa", "Pa$$W0rd", NombreArchivo);

            }
        }

        protected void gvListadoProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoProduccion.PageIndex = e.NewPageIndex;
            BuscarProduccion();
        }


        protected void ddlSeleccionarSUcursalConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinas();
            CargarDepartamentos();
            CargarUsuarios();
        }

        protected void ddlSeleccionarOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDepartamentos();
            CargarUsuarios();
        }

        protected void ddlSeleccionarDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        protected void rbGenerarDaraResumido_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenerarDaraResumido.Checked) {
                gvListadoProduccion.Visible = true;
                gvListadoProduccionDetalle.Visible = false;
            }
            else if (rbGenerarDataDetalle.Checked) {
                gvListadoProduccion.Visible = false;
                gvListadoProduccionDetalle.Visible = false;
            }
        }

        protected void rbGenerarDataDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGenerarDataDetalle.Checked) {
                gvListadoProduccion.Visible = false;
                gvListadoProduccionDetalle.Visible = true;
            }
            else if (rbGenerarDataDetalle.Checked) {
                gvListadoProduccion.Visible = false;
                gvListadoProduccionDetalle.Visible = false;
            }
        }

        protected void gvListadoProduccionDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoProduccionDetalle.PageIndex = e.NewPageIndex;
            BuscarProduccion();
        }
    }
}
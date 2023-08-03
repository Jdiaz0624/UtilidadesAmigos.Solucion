using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.MasterPage
{
    public partial class PatallaPrincila : System.Web.UI.MasterPage
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();

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

            var SacarDatos = Objdata.Value.BuscaUsuarios(IdUsuario,
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

        #endregion

        enum PefilesUsuarios
        {
            ADMINISTRADOR = 1,
            CONTABILIDAD = 2,
            AUDITORIA = 3,
            NEGOCIOS = 4,
            TECNICO = 5,
            RECLAMACIONES = 6,
            ADMINISTRACION = 7,
            ARCHIVO = 8,
            RECEPCION = 9,
            COBROS = 10,
            CUMPLIMIENTO=11,
            COBROSESPECIAL=12,
            TECNICOESPECIAL=13
        }

        #region APLCIAR PERMISOS A PERFILES
        public void ValidarModulos() {

            //SACAMOS EL PERFIL DEL USUARIO
            int IdPerfil = 0;
            var SacarInformacion = Objdata.Value.BuscaUsuarios((decimal)Session["IdUsuario"]);
            foreach (var n in SacarInformacion) {
                IdPerfil = (int)n.IdPerfil;
            }

            switch (IdPerfil) {

                case (int)PefilesUsuarios.ADMINISTRADOR:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = true;
                    DivModuloCorrecciones.Visible = true;
                    DIVModuloHoja.Visible = true;
                    break;

                case (int)PefilesUsuarios.CONTABILIDAD:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = true;
                    break;

                case (int)PefilesUsuarios.AUDITORIA:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = false;
                    break;

                case (int)PefilesUsuarios.NEGOCIOS:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = true;
                    DIVModuloHoja.Visible = true;
                    break;

                case (int)PefilesUsuarios.TECNICO:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = true;
                    DIVModuloHoja.Visible = true;
                    break;

                case (int)PefilesUsuarios.RECLAMACIONES:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = true;
                    break;

                case (int)PefilesUsuarios.ADMINISTRACION:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = false;
                    DivModuloProcesos.Visible = false;
                    DivModuloMantenimiento.Visible = false;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = false;
                    break;

                case (int)PefilesUsuarios.ARCHIVO:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = false;
                    DivModuloReportes.Visible = false;
                    DivModuloProcesos.Visible = false;
                    DivModuloMantenimiento.Visible = false;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = false;
                    break;

                case (int)PefilesUsuarios.RECEPCION:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = false;
                    DivModuloProcesos.Visible = false;
                    DivModuloMantenimiento.Visible = false;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = false;
                    break;

                case (int)PefilesUsuarios.COBROS:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = false;
                    break;

                case (int)PefilesUsuarios.CUMPLIMIENTO:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = false;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = false;
                    break;

                case (int)PefilesUsuarios.COBROSESPECIAL:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = false;
                    break;

                case (int)PefilesUsuarios.TECNICOESPECIAL:
                    DivModuloSuministro.Visible = true;
                    DivModuloConsulta.Visible = true;
                    DivModuloReportes.Visible = true;
                    DivModuloProcesos.Visible = true;
                    DivModuloMantenimiento.Visible = true;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = true;
                    DIVModuloHoja.Visible = false;
                    break;

                default:
                    DivModuloSuministro.Visible = false;
                    DivModuloConsulta.Visible = false;
                    DivModuloReportes.Visible = false;
                    DivModuloProcesos.Visible = false;
                    DivModuloMantenimiento.Visible = false;
                    DivModuloSeguridad.Visible = false;
                    DivModuloCorrecciones.Visible = false;
                    DIVModuloHoja.Visible = false;
                    break;
            }

        }

        public void ValidarPantallas() {
            //SACAMOS EL PERFIL DEL USUARIO
            int IdPerfil = 0;
            var SacarInformacion = Objdata.Value.BuscaUsuarios((decimal)Session["IdUsuario"]);
            foreach (var n in SacarInformacion)
            {
                IdPerfil = (int)n.IdPerfil;
            }

            switch (IdPerfil)
            {

                case (int)PefilesUsuarios.ADMINISTRADOR:
                    //SUMINISTRO
                    LinkAdministracion.Visible = true;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = true;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = true;
                    LinkGestionCobros.Visible = true;
                    LinkEstadisticaRenovacion.Visible = true;
                    LinkSacarDataCoberturas.Visible = true;
                    LinkGenerarReporteUAF.Visible = true;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = true;
                    LinkRegistrosInconpletos.Visible = true;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = true;
                    LinkComisionesIntermediario.Visible = true;
                    LinkComisionesSupervisores.Visible = true;
                    LinkSobreComision.Visible = true;
                    LinkProduccionDiaria.Visible = true;
                    LinkAntiguedadSaldoCXP.Visible = true;
                    LinkReporteCuentaProveedores.Visible = true;
                    LinkDepositosPrima.Visible = true;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = true;
                    LinkReclamacionesPagadas.Visible = true;
                    LinkImpresionMarbetes.Visible = true;
                    LinkFichatecnica.Visible = true;
                    LinkReportePolizasBalance.Visible = true;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = true;
                    LinkSolicitudesCheques.Visible = true;
                    LinkImpresionCheques.Visible = true;
                    LinkProcesarDataAsegurado.Visible = true;
                    LinkDatoPoliza.Visible = true;
                    LinkEndosos.Visible = true;
                    LinkProcesoEmision.Visible = true;
                    LinkVolantePagos.Visible = true;
                    LinkUtilidadesCobros.Visible = true;
                    LinkAgregarItemsReclamos.Visible = true;
                    LinkReciboIngreso.Visible = true;
                    LinkCartaCancelacion.Visible = true;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = true;
                    LinkPolizaTransito.Visible = true;
                    LinkSumaAseguradaFianzas.Visible = true;
                    LinkCambioIntermediario.Visible = true;
                    LinkCambioCliente.Visible = true;
                    LinkModificarDatosCliente.Visible = true;
                    LinkDatoPoliza.Visible = true;

                    //MANTENIMIENTO
                    LinkClientes.Visible = true;
                    LinkIntermediariosSupervisores.Visible = true;
                    LinkOficinas.Visible = true;
                    LinkDepartamentos.Visible = true;
                    LinkEmpleados.Visible = true;
                    LinkInventario.Visible = true;
                    LinkDependientes.Visible = true;
                    LinkPorcientoComision.Visible = true;
                    LinkMonedas.Visible = true;

                    //SEGURIDAD
                    LinkUsuarios.Visible = true;
                    LinkPerfilesUsuarios.Visible = true;
                    LinkClaveSeguridad.Visible = true;
                    LinkConfiguracionCorreos.Visible = true;
                    LinkMovimientoUsuarios.Visible = true;
                    LinkTarjetaAcceso.Visible = true;
                    LinkModulos.Visible = true;
                    LinkPantallas.Visible = true;
                    LinkOpciones.Visible = true;
                    LinkPermisoUsuarios.Visible = true;
                    LinkCredencialesBD.Visible = true;
                    break;

                case (int)PefilesUsuarios.CONTABILIDAD:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = false;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = false;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = false;
                    LinkGenerarReporteUAF.Visible = true;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = false;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = true;
                    LinkComisionesSupervisores.Visible = true;
                    LinkSobreComision.Visible = true;
                    LinkProduccionDiaria.Visible = true;
                    LinkAntiguedadSaldoCXP.Visible = true;
                    LinkReporteCuentaProveedores.Visible = true;
                    LinkDepositosPrima.Visible = true;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = true;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = true;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = true;
                    LinkImpresionCheques.Visible = true;
                    LinkProcesarDataAsegurado.Visible = false;
                    LinkEndosos.Visible = false;
                    LinkProcesoEmision.Visible = false;
                    LinkVolantePagos.Visible = true;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = true;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = false;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = true;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = false;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = true;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.AUDITORIA:
                    //SUMINISTRO
                    LinkAdministracion.Visible = true;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = true;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = true;
                    LinkGestionCobros.Visible = true;
                    LinkEstadisticaRenovacion.Visible = true;
                    LinkSacarDataCoberturas.Visible = true;
                    LinkGenerarReporteUAF.Visible = true;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = false;
                    

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = true;
                    LinkComisionesSupervisores.Visible = true;
                    LinkSobreComision.Visible = true;
                    LinkProduccionDiaria.Visible = true;
                    LinkAntiguedadSaldoCXP.Visible = true;
                    LinkReporteCuentaProveedores.Visible = true;
                    LinkDepositosPrima.Visible = true;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = true;
                    LinkReclamacionesPagadas.Visible = true;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = true;
                    LinkReportePolizasBalance.Visible = true;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = false;
                    LinkEndosos.Visible = false;
                    LinkProcesoEmision.Visible = false;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = false;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = false;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = true;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.NEGOCIOS:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = true;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = false;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = true;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = false;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = true;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = true;
                    LinkComisionesIntermediario.Visible = true;
                    LinkComisionesSupervisores.Visible = true;
                    LinkSobreComision.Visible = true;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = true;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = true;
                    LinkReportePolizasBalance.Visible = true;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = true;
                    LinkDatoPoliza.Visible = false;
                    LinkEndosos.Visible = false;
                    LinkProcesoEmision.Visible = true;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = true;
                    LinkCambioCliente.Visible = true;
                    LinkModificarDatosCliente.Visible = true;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = true;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = false;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.TECNICO:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = true;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = false;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = true;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = false;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = true;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = true;
                    LinkComisionesIntermediario.Visible = true;
                    LinkComisionesSupervisores.Visible = true;
                    LinkSobreComision.Visible = true;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = true;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = false;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = true;
                    LinkDatoPoliza.Visible = true;
                    LinkEndosos.Visible = true;
                    LinkProcesoEmision.Visible = true;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = true;
                    LinkPolizaTransito.Visible = true;
                    LinkSumaAseguradaFianzas.Visible = true;
                    LinkCambioIntermediario.Visible = true;
                    LinkCambioCliente.Visible = true;
                    LinkModificarDatosCliente.Visible = true;
                    LinkDatoPoliza.Visible = true;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = true;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.RECLAMACIONES:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = false;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = false;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = false;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = true;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = false;
                    LinkComisionesSupervisores.Visible = false;
                    LinkSobreComision.Visible = false;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = false;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = false;
                    LinkReporteREclmaciones.Visible = true;
                    LinkReclamacionesPagadas.Visible = true;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = false;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = false;
                    LinkEndosos.Visible = true;
                    LinkProcesoEmision.Visible = false;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = true;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = false;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = true;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.ADMINISTRACION:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = false;
                    LinkConsultaPersonas.Visible = false;
                    LinkListadoRenovacion.Visible = false;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = false;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = false;

                    //REPORTES
                    LinkReporteProduccion.Visible = false;
                    LinkReporteCobros.Visible = false;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = false;
                    LinkComisionesSupervisores.Visible = false;
                    LinkSobreComision.Visible = false;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = false;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = false;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = false;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = false;
                    LinkDatoPoliza.Visible = false;
                    LinkEndosos.Visible = false;
                    LinkProcesoEmision.Visible = false;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = false;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = false;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.ARCHIVO:
                    //SUMINISTRO
                    LinkAdministracion.Visible = true;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = false;
                    LinkConsultaPersonas.Visible = false;
                    LinkListadoRenovacion.Visible = false;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = false;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = false;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = false;

                    //REPORTES
                    LinkReporteProduccion.Visible = false;
                    LinkReporteCobros.Visible = false;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = false;
                    LinkComisionesSupervisores.Visible = false;
                    LinkSobreComision.Visible = false;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = false;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = false;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = false;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = false;
                    LinkDatoPoliza.Visible = false;
                    LinkEndosos.Visible = false;
                    LinkProcesoEmision.Visible = false;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = false;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = false;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.RECEPCION:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = false;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = false;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = false;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = false;

                    //REPORTES
                    LinkReporteProduccion.Visible = false;
                    LinkReporteCobros.Visible = false;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = false;
                    LinkComisionesSupervisores.Visible = false;
                    LinkSobreComision.Visible = false;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = false;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = false;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = false;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = false;
                    LinkDatoPoliza.Visible = false;
                    LinkEndosos.Visible = false;
                    LinkProcesoEmision.Visible = false;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = false;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = false;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.COBROS:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = true;
                    LinkConsultaPersonas.Visible = false;
                    LinkListadoRenovacion.Visible = true;
                    LinkGestionCobros.Visible = true;
                    LinkEstadisticaRenovacion.Visible = true;
                    LinkSacarDataCoberturas.Visible = false;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = false;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = false;
                    LinkComisionesSupervisores.Visible = false;
                    LinkSobreComision.Visible = false;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = false;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = true;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = false;
                    LinkDatoPoliza.Visible = false;
                    LinkEndosos.Visible = false;
                    LinkProcesoEmision.Visible = false;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = true;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = true;
                    LinkCartaCancelacion.Visible = true;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = true;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = true;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.CUMPLIMIENTO:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = true;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = false;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = false;
                    LinkGenerarReporteUAF.Visible = true;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = false;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = false;
                    LinkComisionesSupervisores.Visible = false;
                    LinkSobreComision.Visible = false;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = false;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = false;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = true;
                    LinkDatoPoliza.Visible = true;
                    LinkEndosos.Visible = true;
                    LinkProcesoEmision.Visible = true;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = false;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = false;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.COBROSESPECIAL:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = true;
                    LinkConsultaPersonas.Visible = false;
                    LinkListadoRenovacion.Visible = true;
                    LinkGestionCobros.Visible = true;
                    LinkEstadisticaRenovacion.Visible = true;
                    LinkSacarDataCoberturas.Visible = false;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = true;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = false;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = false;
                    LinkComisionesIntermediario.Visible = true;
                    LinkComisionesSupervisores.Visible = true;
                    LinkSobreComision.Visible = true;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = false;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = true;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = false;
                    LinkDatoPoliza.Visible = false;
                    LinkEndosos.Visible = false;
                    LinkProcesoEmision.Visible = false;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = true;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = true;
                    LinkCartaCancelacion.Visible = true;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = false;
                    LinkPolizaTransito.Visible = false;
                    LinkSumaAseguradaFianzas.Visible = false;
                    LinkCambioIntermediario.Visible = false;
                    LinkCambioCliente.Visible = false;
                    LinkModificarDatosCliente.Visible = true;
                    LinkDatoPoliza.Visible = false;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = false;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = true;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;

                case (int)PefilesUsuarios.TECNICOESPECIAL:
                    //SUMINISTRO
                    LinkAdministracion.Visible = false;
                    LinkSolicitud.Visible = true;

                    //CONSULTAS
                    LinkCartera.Visible = true;
                    LinkConsultaPersonas.Visible = true;
                    LinkListadoRenovacion.Visible = true;
                    LinkGestionCobros.Visible = false;
                    LinkEstadisticaRenovacion.Visible = false;
                    LinkSacarDataCoberturas.Visible = true;
                    LinkGenerarReporteUAF.Visible = false;
                    LinkControlVisitas.Visible = false;
                    LinkInformacionAsegurado.Visible = false;
                    LinkRegistrosInconpletos.Visible = true;

                    //REPORTES
                    LinkReporteProduccion.Visible = true;
                    LinkReporteCobros.Visible = true;
                    LinkReporteProduccionIntermediarioAlfredo.Visible = true;
                    LinkComisionesIntermediario.Visible = true;
                    LinkComisionesSupervisores.Visible = true;
                    LinkSobreComision.Visible = true;
                    LinkProduccionDiaria.Visible = false;
                    LinkAntiguedadSaldoCXP.Visible = false;
                    LinkReporteCuentaProveedores.Visible = true;
                    LinkDepositosPrima.Visible = false;
                    LinkAntiguedadSaldo.Visible = true;
                    LinkReporteREclmaciones.Visible = false;
                    LinkReclamacionesPagadas.Visible = false;
                    LinkImpresionMarbetes.Visible = false;
                    LinkFichatecnica.Visible = false;
                    LinkReportePolizasBalance.Visible = false;

                    //PROCESOS
                    LinkGenerarBAckupBD.Visible = false;
                    LinkSolicitudesCheques.Visible = false;
                    LinkImpresionCheques.Visible = false;
                    LinkProcesarDataAsegurado.Visible = true;
                    LinkDatoPoliza.Visible = true;
                    LinkEndosos.Visible = true;
                    LinkProcesoEmision.Visible = true;
                    LinkVolantePagos.Visible = false;
                    LinkUtilidadesCobros.Visible = false;
                    LinkAgregarItemsReclamos.Visible = false;
                    LinkReciboIngreso.Visible = false;
                    LinkCartaCancelacion.Visible = false;

                    //CORRECCIONES
                    LinkEliminarEndosos.Visible = true;
                    LinkPolizaTransito.Visible = true;
                    LinkSumaAseguradaFianzas.Visible = true;
                    LinkCambioIntermediario.Visible = true;
                    LinkCambioCliente.Visible = true;
                    LinkModificarDatosCliente.Visible = false;
                    LinkDatoPoliza.Visible = true;

                    //MANTENIMIENTO
                    LinkClientes.Visible = false;
                    LinkIntermediariosSupervisores.Visible = true;
                    LinkOficinas.Visible = false;
                    LinkDepartamentos.Visible = false;
                    LinkEmpleados.Visible = false;
                    LinkInventario.Visible = false;
                    LinkDependientes.Visible = true;
                    LinkPorcientoComision.Visible = false;
                    LinkMonedas.Visible = false;

                    //SEGURIDAD
                    LinkUsuarios.Visible = false;
                    LinkPerfilesUsuarios.Visible = false;
                    LinkClaveSeguridad.Visible = false;
                    LinkConfiguracionCorreos.Visible = false;
                    LinkMovimientoUsuarios.Visible = false;
                    LinkTarjetaAcceso.Visible = false;
                    LinkModulos.Visible = false;
                    LinkPantallas.Visible = false;
                    LinkOpciones.Visible = false;
                    LinkPermisoUsuarios.Visible = false;
                    LinkCredencialesBD.Visible = false;
                    break;
                default:
        
                    break;
            }

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //PermisoPerfil();
                ValidarModulos();
                ValidarPantallas();
            }
           
        }

 


        protected void llbProcesarDataGruas_Click(object sender, EventArgs e)
        {
            
        }
        protected void llbUsuarios_Click(object sender, EventArgs e)
        {
           
        }


        protected void llbPermisoUsuarios_Click(object sender, EventArgs e)
        {
           
        }

        protected void llbProcesarDataGruas_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ProcesarDataGruas.aspx");
        }

        protected void llbProcesarDataPowerBI_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ProcesarDataPowerBi.aspx");
        }

   

        protected void llbAsignacionTarjetas_Click(object sender, EventArgs e)
        {
            
        }



        protected void llbCotizadorAmigos_Click(object sender, EventArgs e)
        {
           
        }

        protected void llbGenerarDataCoberturas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/SacarDataCoberturas.aspx");
        }

 

        protected void linkCerrarCesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Paginas/MenuPrincipal.aspx");
        }

        protected void linkProduccionPorUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ProduccionPorUsuarios.aspx");
        }

        protected void LinkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MenuPrincipal.aspx");
        }

        protected void linkTicket_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/SistemaTicket.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkProduccionDiaria_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            // Response.Redirect("ProduccionDiaria.aspx");
        }

        protected void linkGenerarCartera_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/GenerarCartera.aspx");
        }

        protected void linkValidarCoberturas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Consulta/ValidarCoberturas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkGenerarReporteUAF_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Consulta/ReporteOperacionesSospechosas.aspx");
        }

        protected void linkGenerarReporteCoberturas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkOficinas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Oficinas.aspx");
        }

        protected void linkDeprtamentos_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
           Response.Redirect("~/Paginas/Departamentos.aspx");
        }

        protected void linkEmpleados_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            Response.Redirect("~/Paginas/Empleados.aspx");
        }

        protected void linkInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Inventario.aspx");
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkCotizadorFuturoSeguros_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            //Response.Redirect("CotizadorAmigos.aspx");
        }

        protected void linkFuturoARS_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);

        }

        protected void linkTarjetasAccesos_Click(object sender, EventArgs e)
        {
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            Response.Redirect("~/Paginas/Seguridad/AsignacionTarjetas.aspx");
        }

        protected void linkMovimientoUsuarios_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkPermisoUsuarios_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            //Response.Redirect("PermisoUsuarios.aspx");
        }

        protected void linkClaveSeguridad_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MantenimientoClaveSeguridad.aspx");
        }

        protected void linkPerfilesUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/MantenimeintoPerfiles.aspx");
        }

        protected void linkUsuarios_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/MantenimientoUsuarios.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            
            
        }

        protected void linkCarteraIntermediarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/GenerarCarteraIntermedirio.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkComisionesCobrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas//Consulta/ListadoRenovacion.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkProcesarDataGruas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkEmisionPolizas_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkEnvioCorreo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkCorreoElectronicos_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void LinkDependientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Mantenimientos/MantenimientoDependientes.aspx");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkClientes_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
        }

        protected void linkOpcionMenu_Click(object sender, EventArgs e)
        {
            //MOSTRAR LOS MODULOS DEL SISTEMA
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/Modulos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkOpcion_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/Pantallas.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkBotones_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/Opciones.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkEliminarBalance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/EliminarBalancePoliza.aspx");
        }

        protected void LinkReporteFianzas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Consulta/GenerarReporteFianzas.aspx");
        }

        protected void LinkReporteReclamos_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE RECLAMOS
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/ReporteReclamos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkProcesoCasaConductor_Click(object sender, EventArgs e)
        {

        }

        protected void LinkProduccionDiariaContabilidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Reportes/ProduccionDiariaContabilidad.aspx");
        }

  

        protected void LinkCorregirValorDeclarativa_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/DatosPoliza.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCorregirLimites_Click(object sender, EventArgs e)
        {

        }

        protected void LinkSolicitudEmision_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/SolicitudEmisionPoliza.aspx");
        }

        protected void LinkBakupBD_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/GenerarBackupBaseDatos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarFacturasPDF_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/GenerarFacturasPDF.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkProcesarDataAsegurado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/ProcesarDataAsegurado.aspx");
            }
            else
            {

                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LiniComisionesIntermediarios_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE INTERMEDARIOS
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ComisionesIntermediarios.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkComisionesSupervisores_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE LOS SUPERVISORES
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ComisionesSupervisores.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarMarbetesBehiculo_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL REPORTE DE COMISIONES DE LOS SUPERVISORES
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/GenerarMarbetes.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkClientes_Click1(object sender, EventArgs e)
        {

        }

        protected void LinkIntermediariosSupervisores_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Mantenimientos/IntermediariosSupervisores.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkMantenimientoPorcientoComisionPorDefecto_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/MantenimientoPorcientoComisionPorDefecto.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarSOlicitudChequeComisiones_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Procesos/GenerarSolicitudChequeComisionesIntermediarios.aspx");

            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkAntiguedadSaldo_Click(object sender, EventArgs e)
        {

            if (Session["Idusuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/AntiguedadSaldo.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkProduccionIntermediarioSupervisor_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteProduccion.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsumoWS_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("ConsumoWS.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReporteCobrado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Reportes/GenerarReporteCobros.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsultarPersonas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/SuperIntendencia/ConsultaPersonas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkImpresionCheques_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) { 
            
                    Response.Redirect("~/Paginas/Reportes/ImpresionCheques.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkConsultarInformacionAsegurado_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Consulta/ConsultarDataAsegurado.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkVolantePago_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Procesos/VolantesDePagos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCorreosEmisoresProcesos_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/ConfiguracionCorreosEmisorProcesos.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCredencialesBD_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Seguridad/CredencialesBD.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkSobreComision_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteSobreComision.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkControlVisitas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                //ControlVisitas.aspx
                Response.Redirect("~/Paginas/ControlVisitas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReporteAlfredoIntermediarios_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Reportes/ReporteIntermediariosAlfredo.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGestionCObros_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Consulta/GestionCobros.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void linkUtilidadesCobros_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Procesos/UtilidadesCobros.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkAgregarDPAReclamos_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/AgregarItemsReclamos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkMantenimientoMonedas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Mantenimientos/MantenimientoMonedas.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCartera_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Consulta/SacarCarteraIntermediariosSupervisor.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReclamacionesPagadas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReclamacionesPagadas.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCotizador_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {

                Response.Redirect("~/Paginas/ProcesoPoliza/Cotizador.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkEstadisticaRenovacion_Click(object sender, EventArgs e)
        {
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Opción no esta disponible por el momento por que se esta trabajando en una mejora para la misma.');", true);
            if (Session["IdUsuario"] != null)
            {

                Response.Redirect("~/Paginas/Consulta/EstadisticaRenovacion.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReportePrimaDeposito_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {

                Response.Redirect("~/Paginas/Reportes/ReportePrimaDeposito.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkSolicitud_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null) {
                Response.Redirect("~/Paginas/Suministro/SolicitudSuministro.aspx");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkAdministracionSuministro_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Suministro/AdministracionSuministro.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }

        }

        protected void LinkReporteReclamaciones_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteReclamaciones.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReciboDigital_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/ReciboDigital.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCLientesSinPolizaPolizaSinMarbete_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Consulta/RegistrosImcompletos.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReporteImpresionMarbetes_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteImpresionMarbetes.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGenerarEndoso_Click(object sender, EventArgs e)
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

        protected void LinkProcesoEmision_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/ProcesoEmisionPoliza.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkGestionCobros_Click1(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Consulta/GestionCobros.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkAntiguedadSaldoCXP_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Esta Pantalla no esta disponible por el momento');", true);
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/AntiguedadSaldoCXP.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReporteCuuentasProveedores_Click(object sender, EventArgs e)
        {
            
                if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/ReporteCuentasProveedores.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkImpresionCheques_Click1(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/ImpresionCheques.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkFichatecnica_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/FichaTecnica.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCartaCancelacion_Click(object sender, EventArgs e)
        {
            
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Procesos/CartaCancelacion.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkReportePolizasBalance_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Reportes/PolizasConBalancesPorAntiguedad.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkEliminarEndosos_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Correcciones/EliminarEntodoso.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkPolizaTransito_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                //Response.Redirect("~/Paginas/Correcciones/PolizaTransito.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Que Degraciación con ustedes los humanos, si la opcion esta en roja es por que no esta en funcionamiento.');", true);
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCambioIntermediario_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                //Response.Redirect("~/Paginas/Correcciones/CambioIntermediario.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Que Degraciación con ustedes los humanos, si la opcion esta en roja es por que no esta en funcionamiento.');", true);
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCambioCliente_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                //Response.Redirect("~/Paginas/Correcciones/CambioCliente.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Que Degraciación con ustedes los humanos, si la opcion esta en roja es por que no esta en funcionamiento.');", true);
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkModificarDatosCliente_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                //Response.Redirect("~/Paginas/Correcciones/ModificarDatosCliente.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Que Degraciación con ustedes los humanos, si la opcion esta en roja es por que no esta en funcionamiento.');", true);
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkSumaAseguradaFianzas_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Correcciones/MontoAfianzadoFianzas.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void LinkCertificadoMaritimo_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                Response.Redirect("~/Paginas/Hojas/CerrtificadoMaritimo.aspx");
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}
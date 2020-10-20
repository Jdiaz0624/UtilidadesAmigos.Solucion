﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class IntermediariosSupervisores : System.Web.UI.Page
    {
        UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.Logica.LogicaSistema();
        UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos Objdatamantenimientos = new Logica.Logica.LogicaMantenimientos.LogicaMantenimientos();


        #region MOSTRAR Y OCULTAR CONTROLES
        private void OcultarControles() {
            rbRetensionSiMantenimiento.Visible = false;
            rbRetensionNOMantenimiento.Visible = false;
            LBsEPARADOR1.Visible = false;
            rbEstatusMantenimiento.Visible = false;
            rbEstatusInactivoMantenimiento.Visible = false;
            LBsEPARADOR2.Visible = false;
            rbIntermediarioDirecto.Visible = false;
            rbIntermediarioNoDirecto.Visible = false;
            lbFechaEntradaMantenimiento.Visible = false;
            txtFechaEntradaMantenimiento.Visible = false;
            lbFechaNacimientoMantenimiento.Visible = false;
            txtFechaMAcimientoMantenimiento.Visible = false;
            lbSeleccionarTipoIdentificacionMantenimiento.Visible = false;
            ddlSeleccionarTipoIdentificacionMantenimiento.Visible = false;
            lbNumeroIdentificacionMantenimiento.Visible = false;
            txtNumeroIdentificacionMantenimiento.Visible = false;
            lbApellidoIntermediarioMantenimiento.Visible = false;
            txtApellidoIntermediarioMantenimiento.Visible = false;
            lbNombreIntermediarioMantenimiento.Visible = false;
            txtNombreIntermediarioMantenimiento.Visible = false;
            lbDireccionIntermediarioMantenimiento.Visible = false;
            txtDireccionntermediarioMantenimiento.Visible = false;
            lbContactoIntermediarioMantenimiento.Visible = false;
            txtContactoIntermediarioMantenimiento.Visible = false;
            lbSeleccionarPaisMantenimiento.Visible = false;
            ddlSeleccionarPaisMantenimiento.Visible = false;
            lbSeleccionarZonaMantenimiento.Visible = false;
            ddlSeleccionarZonaMantenimiento.Visible = false;
            lbSeleccionarProvinciaMantenimiento.Visible = false;
            ddlSeleccionarProvinciaMantenimiento.Visible = false;
            lbseleccionarMunicipioMantenimiento.Visible = false;
            ddlSeleccionarMunicipioMantenimiento.Visible = false;
            lbSeleccionarSectorMantenimiento.Visible = false;
            ddlSeleccionarSectorMantenimiento.Visible = false;
            lbSeleccionarUbicacionMantenimiento.Visible = false;
            ddlSeleccionarUbicacionMantenimiento.Visible = false;
            lbCodigoSupervisorMantenimiento.Visible = false;
            txtCodigoSupervisor.Visible = false;
            lbNombreSupervisor.Visible = false;
            txtNombreSupervisor.Visible = false;
            ddlSeleccionarOficinaIntermediarioMantenimiento.Visible = false;
            ddlSeleccionarOficinaIntermeiarioMantenimiento.Visible = false;
            lbSeleccionarBancoIntermediarioMantenimiento.Visible = false;
            ddlSeleccionarBancoIntermediarioMantenimeitto.Visible = false;
            lbCuentaBancoMantenimiento.Visible = false;
            txtNumeroCuentaBancoMantenimiento.Visible = false;
            lbSeleccionarCanalDistribucionMantenimiento.Visible = false;
            ddlSeleccionarCanalDistribucionMantenimiento.Visible = false;
            btnGuardar.Visible = false;
            btnVolver.Visible = false;
            lbTipoCuentaBancoMantenimiento.Visible = false;
            rbCuentaAhorroMantenimiento.Visible = false;
            rbCuentaCorrienteMantenimiento.Visible = false;
            rbTarjetaMantenimiento.Visible = false;
            rbPrestamoMantenimiento.Visible = false;
            lbTipoCobroTitulo.Visible = false;
            rbCobroChequesMantenimiento.Visible = false;
            rbCobroEfectivoMantenimiento.Visible = false;
            rbCobroTransferenciaMantenimiento.Visible = false;
            rbCobroCuentasPorPagarMantenimiento.Visible = false;
            lbTelefono1Mantenimiento.Visible = false;
            txtTelefono1Mantenimiento.Visible = false;
            lbTelefono2Mantenimiento.Visible = false;
            txtTelefono2Mantenimiento.Visible = false;
            lbTelefono3Mantenimiento.Visible = false;
            txtTelefono3Mantenimiento.Visible = false;
            lbCelularMantenimiento.Visible = false;
            txtCelularMantenimiento.Visible = false;
            lbFaxMantenimiento.Visible = false;
            txtFaxMantenimiento.Visible = false;
            lbEmailMantenimiento.Visible = false;
            txtEnailMantenimiento.Visible = false;






            lbCodigoIntermediario.Visible = true;
            txtCodigoIntermediarioCosulta.Visible = true;
            lbNombreIntermediario.Visible = true;
            txtNombreIntermediarioCOnsulta.Visible = true;
            lbSelecionarOficina.Visible = true;
            ddlSeleccionarOficinaConsulta.Visible = true;
            btnCOnsultarRegistros.Visible = true;
            btnNuevo.Visible = true;
            btnModificar.Visible = true;
            gvIntermediarios.Visible = true;
            lbCantidadRegistrosTitulo.Visible = true;
            lbCantidadRegistrosVariable.Visible = true;
            lbCantidadRegistrosCerrar.Visible = true;
            lbSeparadorConsulta.Visible = true;
            lbCodigoSeleccionadoTitulo.Visible = true;
            lbCodigoSeleccionadoVariable.Visible = true;
            lbCodigoSeleccionadoCerrar.Visible = true;

        }
        private void MostrarControles() {
            rbRetensionSiMantenimiento.Visible = true;
            rbRetensionNOMantenimiento.Visible = true;
            LBsEPARADOR1.Visible = true;
            rbEstatusMantenimiento.Visible = true;
            rbEstatusInactivoMantenimiento.Visible = true;
            LBsEPARADOR2.Visible = true;
            rbIntermediarioDirecto.Visible = true;
            rbIntermediarioNoDirecto.Visible = true;
            lbFechaEntradaMantenimiento.Visible = true;
            txtFechaEntradaMantenimiento.Visible = true;
            lbFechaNacimientoMantenimiento.Visible = true;
            txtFechaMAcimientoMantenimiento.Visible = true;
            lbSeleccionarTipoIdentificacionMantenimiento.Visible = true;
            ddlSeleccionarTipoIdentificacionMantenimiento.Visible = true;
            lbNumeroIdentificacionMantenimiento.Visible = true;
            txtNumeroIdentificacionMantenimiento.Visible = true;
            lbApellidoIntermediarioMantenimiento.Visible = true;
            txtApellidoIntermediarioMantenimiento.Visible = true;
            lbNombreIntermediarioMantenimiento.Visible = true;
            txtNombreIntermediarioMantenimiento.Visible = true;
            lbDireccionIntermediarioMantenimiento.Visible = true;
            txtDireccionntermediarioMantenimiento.Visible = true;
            lbContactoIntermediarioMantenimiento.Visible = true;
            txtContactoIntermediarioMantenimiento.Visible = true;
            lbSeleccionarPaisMantenimiento.Visible = true;
            ddlSeleccionarPaisMantenimiento.Visible = true;
            lbSeleccionarZonaMantenimiento.Visible = true;
            ddlSeleccionarZonaMantenimiento.Visible = true;
            lbSeleccionarProvinciaMantenimiento.Visible = true;
            ddlSeleccionarProvinciaMantenimiento.Visible = true;
            lbseleccionarMunicipioMantenimiento.Visible = true;
            ddlSeleccionarMunicipioMantenimiento.Visible = true;
            lbSeleccionarSectorMantenimiento.Visible = true;
            ddlSeleccionarSectorMantenimiento.Visible = true;
            lbSeleccionarUbicacionMantenimiento.Visible = true;
            ddlSeleccionarUbicacionMantenimiento.Visible = true;
            lbCodigoSupervisorMantenimiento.Visible = true;
            txtCodigoSupervisor.Visible = true;
            lbNombreSupervisor.Visible = true;
            txtNombreSupervisor.Visible = true;
            ddlSeleccionarOficinaIntermediarioMantenimiento.Visible = true;
            ddlSeleccionarOficinaIntermeiarioMantenimiento.Visible = true;
            lbSeleccionarBancoIntermediarioMantenimiento.Visible = true;
            ddlSeleccionarBancoIntermediarioMantenimeitto.Visible = true;
            lbCuentaBancoMantenimiento.Visible = true;
            txtNumeroCuentaBancoMantenimiento.Visible = true;
            lbSeleccionarCanalDistribucionMantenimiento.Visible = true;
            ddlSeleccionarCanalDistribucionMantenimiento.Visible = true;
            btnGuardar.Visible = true;
            btnVolver.Visible = true;
            lbTipoCuentaBancoMantenimiento.Visible = true;
            rbCuentaAhorroMantenimiento.Visible = true;
            rbCuentaCorrienteMantenimiento.Visible = true;
            rbTarjetaMantenimiento.Visible = true;
            rbPrestamoMantenimiento.Visible = true;
            lbTipoCobroTitulo.Visible = true;
            rbCobroChequesMantenimiento.Visible = true;
            rbCobroEfectivoMantenimiento.Visible = true;
            rbCobroTransferenciaMantenimiento.Visible = true;
            rbCobroCuentasPorPagarMantenimiento.Visible = true;
            lbTelefono1Mantenimiento.Visible = true;
            txtTelefono1Mantenimiento.Visible = true;
            lbTelefono2Mantenimiento.Visible = true;
            txtTelefono2Mantenimiento.Visible = true;
            lbTelefono3Mantenimiento.Visible = true;
            txtTelefono3Mantenimiento.Visible = true;
            lbCelularMantenimiento.Visible = true;
            txtCelularMantenimiento.Visible = true;
            lbFaxMantenimiento.Visible = true;
            txtFaxMantenimiento.Visible = true;
            lbEmailMantenimiento.Visible = true;
            txtEnailMantenimiento.Visible = true;






            lbCodigoIntermediario.Visible = false;
            txtCodigoIntermediarioCosulta.Visible = false;
            lbNombreIntermediario.Visible = false;
            txtNombreIntermediarioCOnsulta.Visible = false;
            lbSelecionarOficina.Visible = false;
            ddlSeleccionarOficinaConsulta.Visible = false;
            btnCOnsultarRegistros.Visible = false;
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
            gvIntermediarios.Visible = false;
            lbCantidadRegistrosTitulo.Visible = false;
            lbCantidadRegistrosVariable.Visible = false;
            lbCantidadRegistrosCerrar.Visible = false;
            lbSeparadorConsulta.Visible = false;
            lbCodigoSeleccionadoTitulo.Visible = false;
            lbCodigoSeleccionadoVariable.Visible = false;
            lbCodigoSeleccionadoCerrar.Visible = false;

        }
        private void LimpiarControles() {
            OcultarControles();
            CargarListasDesplegables();
            //LIMPIAMOS LOS CONTROLES
            txtFechaEntradaMantenimiento.Text = string.Empty;
            txtFechaMAcimientoMantenimiento.Text = string.Empty;
            txtNumeroIdentificacionMantenimiento.Text = string.Empty;
            txtApellidoIntermediarioMantenimiento.Text = string.Empty;
            txtNombreIntermediarioMantenimiento.Text = string.Empty;
            txtDireccionntermediarioMantenimiento.Text = string.Empty;
            txtContactoIntermediarioMantenimiento.Text = string.Empty;
            txtCodigoSupervisor.Text = string.Empty;
            txtNombreSupervisor.Text = string.Empty;
            txtNumeroCuentaBancoMantenimiento.Text = string.Empty;
            txtTelefono1Mantenimiento.Text = string.Empty;
            txtTelefono2Mantenimiento.Text = string.Empty;
            txtTelefono3Mantenimiento.Text = string.Empty;
            txtCelularMantenimiento.Text = string.Empty;
            txtFaxMantenimiento.Text = string.Empty;
            txtEnailMantenimiento.Text = string.Empty;




            txtCodigoIntermediarioCosulta.Text = string.Empty;
            txtNombreIntermediarioCOnsulta.Text = string.Empty;

            btnCOnsultarRegistros.Enabled = true;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnRestabelcerPantalla.Enabled = false;
            // CargarListadoIntermediarios();

            RestablecerPOPOPComisionesIntermediario();

        }
        #endregion
        #region CARGAR LAS LISTAS DESPLEGABLES
        private void CargarListasDesplegables()
        {
            MostrarPais();
            MostrarZonas();
            MostrarProvincias();
            MostrarMunicipios();
            MostrarSector();
            MostrarBarrio();
            CargarOficinas();
            CargarBancos();
            CargarCanalesDistribucion();
        }

        private void MostrarPais()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarPaisMantenimiento, ObjData.BuscaListas("LISTADOPAIS", null, null));
        }
        private void MostrarZonas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarZonaMantenimiento, ObjData.BuscaListas("LISTADOZONAS", ddlSeleccionarPaisMantenimiento.SelectedValue, null));
        }
        private void MostrarProvincias()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarProvinciaMantenimiento, ObjData.BuscaListas("LISTADOPROVINCIAS", ddlSeleccionarPaisMantenimiento.SelectedValue, ddlSeleccionarZonaMantenimiento.SelectedValue));
        }
        private void MostrarMunicipios()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarMunicipioMantenimiento, ObjData.BuscaListas("LISTADOMUNICIPIO", ddlSeleccionarPaisMantenimiento.SelectedValue, ddlSeleccionarZonaMantenimiento.SelectedValue, ddlSeleccionarProvinciaMantenimiento.SelectedValue));
        }
        private void MostrarSector()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSectorMantenimiento, ObjData.BuscaListas("LISTADOSECTOR", ddlSeleccionarPaisMantenimiento.SelectedValue, ddlSeleccionarZonaMantenimiento.SelectedValue, ddlSeleccionarProvinciaMantenimiento.SelectedValue, ddlSeleccionarMunicipioMantenimiento.SelectedValue));
        }
        private void MostrarBarrio()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarUbicacionMantenimiento, ObjData.BuscaListas("LISTADOBARRIO", ddlSeleccionarPaisMantenimiento.SelectedValue, ddlSeleccionarZonaMantenimiento.SelectedValue, ddlSeleccionarProvinciaMantenimiento.SelectedValue, ddlSeleccionarMunicipioMantenimiento.SelectedValue, ddlSeleccionarSectorMantenimiento.SelectedValue));
        }
        private void CargarOficinas()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaConsulta, ObjData.BuscaListas("OFICINAS", null, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarOficinaIntermeiarioMantenimiento, ObjData.BuscaListas("OFICINAS", null, null));
        }
        private void CargarBancos()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarBancoIntermediarioMantenimeitto, ObjData.BuscaListas("LISTADOBANCOS", null, null));
        }
        private void CargarCanalesDistribucion()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarCanalDistribucionMantenimiento, ObjData.BuscaListas("LISTADOCANALESDISTRIBUCION", null, null));
        }
        #endregion
        #region CARGAR EL LISTADO DE LOS INTERMEIDARIOS
        private void CargarListadoIntermediarios() {
            string _Codigointermediario = string.IsNullOrEmpty(txtCodigoIntermediarioCosulta.Text.Trim()) ? null : txtCodigoIntermediarioCosulta.Text.Trim();
            string _NombreVendedor = string.IsNullOrEmpty(txtNombreIntermediarioCOnsulta.Text.Trim()) ? null : txtNombreIntermediarioCOnsulta.Text.Trim();
            int? _oficina = ddlSeleccionarOficinaConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarOficinaConsulta.SelectedValue) : new Nullable<int>();

            var BuscarIntermediarios = Objdatamantenimientos.BuscaListadoIntermediario(
                _Codigointermediario,
                _NombreVendedor,
                null,
                null,
                _oficina);
            if (BuscarIntermediarios.Count() < 1)
            {
                lbCantidadRegistrosVariable.Text = "0";
            }
            else {
                gvIntermediarios.DataSource = BuscarIntermediarios;
                gvIntermediarios.DataBind();
                int CantidadRegistros = 0;
                foreach (var n in BuscarIntermediarios) {
                    CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                    lbCantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                }
            }
        }
        #endregion
        #region MOSTRAR Y OCOLTAR CONTROLES EN LAS COMISIONES
        private void MostrarControlesCmisiones() {
            lbRamoComsionesMantenimiento.Visible = true;
            txtRamoComisionesMantenimiento.Visible = true;
            lbSubRamoComisionesMantenimiento.Visible = true;
            txtSubRamoComisionesMAntenimiento.Visible = true;
            lbPorcientoComisionesComisionesMantenimiento.Visible = true;
            txtPorcientoCOmisionesComisionesMantenimiento.Visible = true;
            lbClaveSeguridadComisionesMAntenimiento.Visible = true;
            txtClaveSeguridadComisionesMAntenimiento.Visible = true;
            btnGuardarComisionesIntermediarios.Visible = true;
        }
        private void OcultarControlesComisiones() {
            lbRamoComsionesMantenimiento.Visible = false;
            txtRamoComisionesMantenimiento.Visible = false;
            lbSubRamoComisionesMantenimiento.Visible = false;
            txtSubRamoComisionesMAntenimiento.Visible = false;
            lbPorcientoComisionesComisionesMantenimiento.Visible = false;
            txtPorcientoCOmisionesComisionesMantenimiento.Visible = false;
            lbClaveSeguridadComisionesMAntenimiento.Visible = false;
            txtClaveSeguridadComisionesMAntenimiento.Visible = false;
            btnGuardarComisionesIntermediarios.Visible = false;
        }
        #endregion
        #region MOSTRAR LOS RAMOS Y LOS SUB RAMOS
        private void CargarRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamoComisionesConsulta, ObjData.BuscaListas("RAMO", null, null), true);
        }
        private void CargarSubramos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSubRamoComisionesConsulta, ObjData.BuscaListas("SUBRAMO", ddlSeleccionarRamoComisionesConsulta.SelectedValue, null), true);
        }
        #endregion
        #region BUSCAR COMISIONES INTERMEDIARIOS
        private void MostrarComisionesIntermediario(int CodigoVenbdedor) {

            int? _Ramo = ddlSeleccionarRamoComisionesConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoComisionesConsulta.SelectedValue) : new Nullable<int>();
            int? _Subramo = ddlSeleccionarSubRamoComisionesConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarSubRamoComisionesConsulta.SelectedValue) : new Nullable<int>();

            var Listado = Objdatamantenimientos.BuscaComisionesIntermediario(
                CodigoVenbdedor,
                _Ramo,
                _Subramo);
            gvListadoComisionesIntermediario.DataSource = Listado;
            gvListadoComisionesIntermediario.DataBind();
        }
        #endregion
        #region MANTENIMIENTO DE COMISIONES DE INTERMEDIARIO
        private void GenerarComisionesIntermediarios(string Accion) {
            
        }
        #endregion
        #region MANTENIMIENTO DE INTERMEDIARIOS
        private void MANIntermediario(int CodigoIntermediario, int Estatus, string UsuarioProcesa, string CanalDistribucion,string Publicidad, string TipoPago,string Retencion,string TipoCuentaBanco, string Accion) {
            try {
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionMantenimientoIntermediariosSupervisores Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionMantenimientoIntermediariosSupervisores(
                    30,
                    CodigoIntermediario,
                    "",
                    0,
                    Convert.ToInt32(ddlSeleccionarTipoIdentificacionMantenimiento.SelectedValue),
                    txtNumeroIdentificacionMantenimiento.Text,
                    "",
                    0,
                    0,
                    Estatus,
                    Convert.ToDateTime(txtFechaEntradaMantenimiento.Text),
                    UsuarioProcesa,
                    DateTime.Now,
                    UsuarioProcesa,
                    DateTime.Now,
                    0,
                    "",
                    CanalDistribucion,
                    txtContactoIntermediarioMantenimiento.Text,
                    Convert.ToDateTime(txtFechaMAcimientoMantenimiento.Text),
                    Publicidad,
                    TipoPago,
                    Convert.ToInt32(ddlSeleccionarBancoIntermediarioMantenimeitto.SelectedValue),
                    txtNumeroCuentaBancoMantenimiento.Text,
                    0,
                    Retencion,
                    Convert.ToDecimal(17.50),
                    0,
                    Convert.ToInt32(txtCodigoSupervisor.Text),
                    "",
                    txtDireccionntermediarioMantenimiento.Text,
                    Convert.ToInt32(ddlSeleccionarUbicacionMantenimiento.SelectedValue),
                    txtTelefono2Mantenimiento.Text,
                    txtTelefono1Mantenimiento.Text,
                    txtCelularMantenimiento.Text,
                    txtTelefono3Mantenimiento.Text,
                    txtFaxMantenimiento.Text,
                    txtEnailMantenimiento.Text,
                    "", //--> CAMPO LICENCIAS DE SEGURO
                    "", //--> CAMPO CODIGO ANTERIOR
                    txtApellidoIntermediarioMantenimiento.Text,
                    txtNombreIntermediarioMantenimiento.Text,
                    Convert.ToInt32(ddlSeleccionarOficinaIntermeiarioMantenimiento.SelectedValue),
                    TipoCuentaBanco,
                    0,
                    0,
                    0,
                    Guid.NewGuid(),
                    0,
                    0,
                    0,
                    0,
                    Accion);
                Procesar.ProcesarInformacion();


            }
            catch (Exception ex) {
                ClientScript.RegisterStartupScript(GetType(), "ErrorRealizarMantenimiento()", "ErrorRealizarMantenimiento();", true);
                ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
            }
        }
        #endregion
        #region MANTENIMIENTO DE INTERMEDIARIO CADENA DETALLE
        private void MANIntermediarioCadenaDetalle(int Compania, int IdIntermediario, int IdSupervisor, string UsuarioAdiciona, string Accion) {
            try {
                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionIntermediarioCadenaDetalle Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionIntermediarioCadenaDetalle(
                    Compania,
                    IdIntermediario,
                    IdSupervisor,
                    UsuarioAdiciona,
                    DateTime.Now,
                    Accion);
                Procesar.ProcesarInformaicon();
            }
            catch (Exception) { }
        }
        #endregion
        #region RESTABLECER POPOP DE COMISIONES
        private void RestablecerPOPOPComisionesIntermediario() {
            //int  CodigoVacio = 0000;
            //MostrarComisionesIntermediario(CodigoVacio);
            //ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
                rbRetensionNOMantenimiento.Checked = true;
                rbEstatusMantenimiento.Checked = true;
                rbIntermediarioNoDirecto.Checked = true;
                rbCuentaCorrienteMantenimiento.Checked = true;
                rbCobroChequesMantenimiento.Checked = true;

                //MOSTRAR LOS TIPOS DE IDENTIFICACION
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarTipoIdentificacionMantenimiento, ObjData.BuscaListas("TIPOIDENTIFICACION", null, null));
                CargarListasDesplegables();


            }
        }

        protected void btnCOnsultarRegistros_Click(object sender, EventArgs e)
        {
            CargarListadoIntermediarios();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void gvIntermediarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIntermediarios.PageIndex = e.NewPageIndex;
            CargarListadoIntermediarios();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void gvIntermediarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow RegistroSeleccionado = gvIntermediarios.SelectedRow;
            btnCOnsultarRegistros.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnRestabelcerPantalla.Enabled = true;

            lbCodigoSeleccionadoVariable.Text = RegistroSeleccionado.Cells[1].Text;

            var BuscarRegistro = Objdatamantenimientos.BuscaListadoIntermediario(RegistroSeleccionado.Cells[1].Text, null, null, null, null);
            gvIntermediarios.DataSource = BuscarRegistro;
            gvIntermediarios.DataBind();
            lbCantidadRegistrosVariable.Text = "1";
            CargarRamos();
            CargarSubramos();

            foreach (var n in BuscarRegistro) {
                lbNombreIntermediarioComisionesTitulo.Text = "COMISIONES DE " + n.NombreVendedor.ToUpper();
            }
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearComision()", "DesbloquearComision();", true);
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
            {
                txtNombreSupervisor.Text = string.Empty;
                ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
            }
            else {
                var BuscarDataSupervisor = ObjData.BuscaInformacionSUperisor(
                    txtCodigoSupervisor.Text, null);
                if (BuscarDataSupervisor.Count() < 1)
                {
                    txtNombreSupervisor.Text = string.Empty;
                }
                else {
                    foreach (var n in BuscarDataSupervisor) {
                        txtNombreSupervisor.Text = n.Nombre;
                    }
                }
                ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
            }
        }

        protected void ddlSeleccionarZonaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarProvincias();
            MostrarMunicipios();
            MostrarSector();
            MostrarBarrio();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void ddlSeleccionarProvinciaMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMunicipios();
            MostrarSector();
            MostrarBarrio();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void ddlSeleccionarMunicipioMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarSector();
            MostrarBarrio();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void ddlSeleccionarSectorMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarBarrio();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int CodigoIntermediario = 0;
            int EstatusIntermediario = 0, Publicidad = 0;
            string UsuarioProcesa = "", CanalDistribucion = "", TipoPago = "", Retencion = "", TipoCuenta = "";
            int CodigoCanalDistribucion = Convert.ToInt32(ddlSeleccionarCanalDistribucionMantenimiento.SelectedValue);
            if (lbAccionTomar.Text == "INSERT") {
                CodigoIntermediario = 0;
            }
            else {
                CodigoIntermediario = Convert.ToInt32(lbCodigoSeleccionadoVariable.Text);
            }
            //SACAMOS EL ESTATUS
            if (rbEstatusMantenimiento.Checked == true) {
                EstatusIntermediario = 1;
            }
            else if (rbEstatusInactivoMantenimiento.Checked == true) {
                EstatusIntermediario = 2;
            }

            //SACAMOS EL NOMBRE DEL USUARIO QUE ESTA PROCESANDO LA INFORMACION
            var SacarNombreUsuario = ObjData.BuscaUsuarios(
                Convert.ToDecimal(Session["IdUsuario"]), null, null, null, null, null, null, null, null);
            foreach (var nUsuario in SacarNombreUsuario) {
                UsuarioProcesa = nUsuario.Persona;
            }

            //SACAMOS LOS CANALES DE DISTRIBUCION
            switch (CodigoCanalDistribucion)
            {
                case 1:
                    CanalDistribucion = "Agentes";
                    break;

                case 2:
                    CanalDistribucion = "Corredor";
                    break;

                case 3:
                    CanalDistribucion = "Canales Alternos";
                    break;

                case 4:
                    CanalDistribucion = "Banca Seguros";
                    break;

                case 5:
                    CanalDistribucion = "Dealers";
                    break;

                case 6:
                    CanalDistribucion = "Gerente Senior";
                    break;

                default:
                    CanalDistribucion = "Agentes";
                    break;
            }
            //SACAMOS LA PUBLICIDAD O SI EL INTERMEDIARIO ES DIRECTO O NO
            if (rbIntermediarioDirecto.Checked == true) {
                Publicidad = 1;
            }
            else if (rbIntermediarioNoDirecto.Checked == true) {
                Publicidad = 0;
            }

            //SACAMOS EL TIPO DE PAGO
            if (rbCobroChequesMantenimiento.Checked == true) {
                TipoPago = "CK";
            }
            else if (rbCobroEfectivoMantenimiento.Checked == true) {
                TipoPago = "EF";
            }
            else if (rbCobroTransferenciaMantenimiento.Checked == true) {
                TipoPago = "DP";
            }
            else if (rbCobroCuentasPorPagarMantenimiento.Checked == true) {
                TipoPago = "CXP";
            }

            //SACAMOS LA RETENCION DEL INTERMEDIARIO
            if (rbRetensionSiMantenimiento.Checked == true) {
                Retencion = "S";
            }
            else if (rbRetensionNOMantenimiento.Checked == true) {
                Retencion = "N";
            }

            //SACAMOS EL TIPO DE CUENTA DEL INTERMEDIARIO
            if (rbCuentaAhorroMantenimiento.Checked == true) {
                TipoCuenta = "Ahorro";
            }
            else if (rbCuentaCorrienteMantenimiento.Checked == true) {
                TipoCuenta = "Corriente";
            }
            else if (rbTarjetaMantenimiento.Checked == true) {
                TipoCuenta = "Tarjeta";
            }
            else if (rbPrestamoMantenimiento.Checked == true) {
                TipoCuenta = "Prestamo";
            }


            MANIntermediario(CodigoIntermediario, EstatusIntermediario, UsuarioProcesa, CanalDistribucion, Publicidad.ToString(), TipoPago, Retencion, TipoCuenta, lbAccionTomar.Text);
         

            decimal CodigoVendedorAfectado = 0;
            if (lbAccionTomar.Text == "UPDATE") {
                CodigoVendedorAfectado = Convert.ToDecimal(lbCodigoSeleccionadoVariable.Text);
               
            }
            else {
                //SACAMOS EL CODIGO MAXIMO PARA REALIZAR LA CONSULTA

                var SacarCodigoMaximo = Objdatamantenimientos.SacarCodigoMaximo();
                foreach (var n in SacarCodigoMaximo) {
                    CodigoVendedorAfectado = Convert.ToDecimal(n.Codigo);
                }

                //EN ESTA PARTE INGRESAMOS LOS DATOS DE LAS COMISIONES DEL INTERMEDIARIO CREADO
                //BUSCAMOS LAS COMISIONES POR DEFECTO
                var BuscarComisionesPorDefecto = Objdatamantenimientos.BuscaComisionesPorDefecto(
                    new Nullable<decimal>(),
                    null, null);
                foreach (var nNuevoPorDefecto in BuscarComisionesPorDefecto) {
                    //GUARDAMOS LOS DATOS DE LAS COMISIONES DEL INTERMEDIARIO
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionComisionesIntermediarioSeleccionado NuevaComision = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionComisionesIntermediarioSeleccionado(
                        30,
                        (int)CodigoVendedorAfectado,
                        (int)nNuevoPorDefecto.CodRamo,
                        (int)nNuevoPorDefecto.CodSubramo,
                        (decimal)nNuevoPorDefecto.PorcientoComision,
                        0,
                        0,
                        0,
                        new Guid(),
                        UsuarioProcesa,
                        "INSERT");
                    NuevaComision.ProcesarInformacion();
                }

            }
            MANIntermediarioCadenaDetalle(30, Convert.ToInt32(CodigoVendedorAfectado), Convert.ToInt32(txtCodigoSupervisor.Text), UsuarioProcesa, lbAccionTomar.Text);

            var Buscar = Objdatamantenimientos.BuscaListadoIntermediario(CodigoVendedorAfectado.ToString(), null, null, null, null);
            gvIntermediarios.DataSource = Buscar;
            gvIntermediarios.DataBind();
            LimpiarControles();

            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
          //  OcultarControles();
            LimpiarControles();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarControles();
            lbAccionTomar.Text = "INSERT";
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            MostrarControles();
            lbAccionTomar.Text = "UPDATE";
            //BUSCAMOS LOS DATOS DEL INTERMEDIARIO SELECCIONADO
            var SacarDatosRegistroSeleccionado = Objdatamantenimientos.BuscaListadoIntermediario(
                lbCodigoSeleccionadoVariable.Text,
                null,
                null,
                null,
                null);
            string RetencionIntermediario = "";
            int EstatusIntermediario = 0, IntermediarioDirecto = 0;
            foreach (var n in SacarDatosRegistroSeleccionado) {
                RetencionIntermediario = n.Retencion;
                EstatusIntermediario = Convert.ToInt32(n.Estatus0);
                IntermediarioDirecto = Convert.ToInt32(n.Publicidad);

                if (RetencionIntermediario == "S") {
                    rbRetensionNOMantenimiento.Checked = false;
                    rbRetensionSiMantenimiento.Checked = true;
                }
                else {
                    rbRetensionSiMantenimiento.Checked = false;
                    rbRetensionNOMantenimiento.Checked = true;
                }

                //SACAMOS EL ESTATUS
                if (EstatusIntermediario == 1) {
                    rbEstatusInactivoMantenimiento.Checked = false;
                    rbEstatusMantenimiento.Checked = true;
                }
                else {
                    rbEstatusMantenimiento.Checked = false;
                    rbEstatusInactivoMantenimiento.Checked = true;
                }

                //VALIDAMOS SI EL INTERMEDIARIO ES DIRECTO O NO, (EN LA TABLA ESTE CAMPO SE LLAMA PUBLICIDAD)
                if (IntermediarioDirecto == 1) {
                    rbIntermediarioNoDirecto.Checked = false;
                    rbIntermediarioDirecto.Checked = true;
                }
                else {
                    rbIntermediarioDirecto.Checked = false;
                    rbIntermediarioNoDirecto.Checked = true;
                }

                //SACAMOS LAS FECHA DE ENTRADA Y NACIMIENTO
                DateTime FechaEntrada = Convert.ToDateTime(n.Fecha_Entrada);
                DateTime FechaNacimiento = Convert.ToDateTime(n.Fec_Nac);
                txtFechaEntradaMantenimiento.Text = FechaEntrada.ToString("yyyy-MM-dd");
                txtFechaMAcimientoMantenimiento.Text = FechaNacimiento.ToString("yyyy-MM-dd");

                //SACAMOS EL TIPO Y EL NUMERO DE RNC
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarTipoIdentificacionMantenimiento, n.TipoRnc.ToString());
                txtNumeroIdentificacionMantenimiento.Text = n.Rnc;

                //SACAMOS LOS DATOS GENERALES DEL INTERMEDIRIO
                txtApellidoIntermediarioMantenimiento.Text = n.Apellido;
                txtNombreIntermediarioMantenimiento.Text = n.Nombre;
                txtDireccionntermediarioMantenimiento.Text = n.Direccion;
                txtContactoIntermediarioMantenimiento.Text = n.Agencia;
                txtCodigoSupervisor.Text = n.VendedorCrea.ToString();
                //SACAMOS EL NOMBRE DEL SUPERVISOR
                if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim())) {
                    txtNombreIntermediarioMantenimiento.Text = "";
                }
                else {
                    var SacarNombreSupervisor = ObjData.BuscaInformacionSUperisor(
                        txtCodigoSupervisor.Text, null);
                    if (SacarNombreSupervisor.Count() < 1) {
                        txtNombreSupervisor.Text = "";
                    }
                    else {
                        foreach (var nSupervisor in SacarNombreSupervisor) {
                            txtNombreSupervisor.Text = nSupervisor.Nombre;
                        }
                    }
                }

                //SACAMOS LOS DATOS DE LA UBICACION GEIGRAFICA
                int CodigoPais = 0, CodigoZona = 0, CodigoProvincia = 0, CodigoMinicipio = 0, CodigoSector = 0, CodigoUbicacion = 0;
                

                //SACAMOS LOS DATOS DE LA UBICACION DEOGRAFICA (CODIGOS)
                var SacarCodigosUbicacionGeografica = ObjData.BuscaDatosUbicacionGeografica(
                    null,
                    null,
                    null,
                    null,
                    null,
                    Convert.ToInt32(n.Ubicacion));
                foreach (var nGeografia in SacarCodigosUbicacionGeografica) {
                    CodigoPais = Convert.ToInt32(nGeografia.CodPais);
                    CodigoZona = Convert.ToInt32(nGeografia.CodZona);
                    CodigoProvincia = Convert.ToInt32(nGeografia.CodProvincia);
                    CodigoMinicipio = Convert.ToInt32(nGeografia.CodMunicipio);
                    CodigoSector = Convert.ToInt32(nGeografia.CodSector);
                    CodigoUbicacion = Convert.ToInt32(nGeografia.CodUbicacion);
                }
                MostrarPais();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarPaisMantenimiento, CodigoPais.ToString());
                MostrarZonas();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarZonaMantenimiento, CodigoZona.ToString());
                MostrarProvincias();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarProvinciaMantenimiento, CodigoProvincia.ToString());
                MostrarMunicipios();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarMunicipioMantenimiento, CodigoMinicipio.ToString());
                MostrarSector();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarSectorMantenimiento, CodigoSector.ToString());
                MostrarBarrio();
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarUbicacionMantenimiento, CodigoUbicacion.ToString());




                //SACAMOS BANCO Y OFICINA
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarOficinaIntermeiarioMantenimiento, n.Oficina.ToString());
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarBancoIntermediarioMantenimeitto, n.Banco.ToString());
                txtNumeroCuentaBancoMantenimiento.Text = n.CtaBanco;

                string CanalDistribucion = n.tipo_Intermediario;
                int IdCanalDistribucion = 0;
                switch (CanalDistribucion) {
                    case "Agentes":
                        IdCanalDistribucion = 1;
                        break;

                    case "Corredor":
                        IdCanalDistribucion = 2;
                        break;

                    case "Canales Alternos":
                        IdCanalDistribucion = 3;
                        break;

                    case "Banca Seguros":
                        IdCanalDistribucion = 4;
                        break;

                    case "Dealers":
                        IdCanalDistribucion = 5;
                        break;

                    case "Gerente Senior":
                        IdCanalDistribucion = 6;
                        break;

                }
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListSeleccionar(ref ddlSeleccionarCanalDistribucionMantenimiento, IdCanalDistribucion.ToString());

                //SACAMOS EL TIPO DE CUENTA DE BANCO
                string TipoCuentaBanco = n.TipoCuentaBco;
                switch (TipoCuentaBanco) {
                    case "Ahorro":
                        rbCuentaCorrienteMantenimiento.Checked = false;
                        rbTarjetaMantenimiento.Checked = false;
                        rbPrestamoMantenimiento.Checked = false;
                        rbCuentaAhorroMantenimiento.Checked = true;
                        break;

                    case "Corriente":
                        rbTarjetaMantenimiento.Checked = false;
                        rbPrestamoMantenimiento.Checked = false;
                        rbCuentaAhorroMantenimiento.Checked = false;
                        rbCuentaCorrienteMantenimiento.Checked = true;
                        break;

                    case "Tarjeta":
                        rbPrestamoMantenimiento.Checked = false;
                        rbCuentaAhorroMantenimiento.Checked = false;
                        rbCuentaCorrienteMantenimiento.Checked = false;
                        rbTarjetaMantenimiento.Checked = true;
                        break;
                    case "Prestamo":
                        rbCuentaAhorroMantenimiento.Checked = false;
                        rbCuentaCorrienteMantenimiento.Checked = false;
                        rbTarjetaMantenimiento.Checked = false;
                        rbPrestamoMantenimiento.Checked = true;
                        break;
                    default:
                        rbCuentaCorrienteMantenimiento.Checked = false;
                        rbTarjetaMantenimiento.Checked = false;
                        rbPrestamoMantenimiento.Checked = false;
                        rbCuentaAhorroMantenimiento.Checked = true;
                        break;
                }

                //SACAMOS EL TIPO DE OCBRO
                string TipoCobro = n.PagoComPor;
                switch (TipoCobro) {
                    case "CK":                      
                        rbCobroEfectivoMantenimiento.Checked = false;
                        rbCobroTransferenciaMantenimiento.Checked = false;
                        rbCobroCuentasPorPagarMantenimiento.Checked = false;
                        rbCobroChequesMantenimiento.Checked = true;
                        break;

                    case "EF":
                        rbCobroTransferenciaMantenimiento.Checked = false;
                        rbCobroCuentasPorPagarMantenimiento.Checked = false;
                        rbCobroChequesMantenimiento.Checked = false;
                        rbCobroEfectivoMantenimiento.Checked = true;
                        break;

                    case "DP":
                        rbCobroCuentasPorPagarMantenimiento.Checked = false;
                        rbCobroChequesMantenimiento.Checked = false;
                        rbCobroEfectivoMantenimiento.Checked = false;
                        rbCobroTransferenciaMantenimiento.Checked = true;
                        break;

                    case "CXP":    
                        rbCobroChequesMantenimiento.Checked = false;
                        rbCobroEfectivoMantenimiento.Checked = false;
                        rbCobroTransferenciaMantenimiento.Checked = false;
                        rbCobroCuentasPorPagarMantenimiento.Checked = true;
                        break;
                }

                //SACAMOS LOS DATOS DE LA COMUNICACION
                txtTelefono1Mantenimiento.Text = n.Telefono;
                txtTelefono2Mantenimiento.Text = n.TelefonoOficina;
                txtTelefono3Mantenimiento.Text = n.Beeper;
                txtCelularMantenimiento.Text = n.Celular;
                txtFaxMantenimiento.Text = n.Fax;
                txtEnailMantenimiento.Text = n.Email;
            }
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void btnRestabelcerPantalla_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void btnConsultarComisiobesIntermediario_Click(object sender, EventArgs e)
        {
            MostrarComisionesIntermediario(Convert.ToInt32(lbCodigoSeleccionadoVariable.Text));
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void gvListadoComisionesIntermediario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoComisionesIntermediario.PageIndex = e.NewPageIndex;
            MostrarComisionesIntermediario(Convert.ToInt32(lbCodigoSeleccionadoVariable.Text));
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearComision()", "DesbloquearComision();", true);
        }

        protected void gvListadoComisionesIntermediario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gbComisiones = gvListadoComisionesIntermediario.SelectedRow;
            lbCodigoRamoSeleccionadoComisionesMantenimiento.Text = gbComisiones.Cells[1].Text;
            lbCodigoSubramoSeleccionaroComisionesMantenimiento.Text = gbComisiones.Cells[3].Text;

            MostrarControlesCmisiones();
            var SacarInformacion = Objdatamantenimientos.BuscaComisionesIntermediario(
                Convert.ToInt32(lbCodigoSeleccionadoVariable.Text),
                Convert.ToInt32(lbCodigoRamoSeleccionadoComisionesMantenimiento.Text),
                Convert.ToInt32(lbCodigoSubramoSeleccionaroComisionesMantenimiento.Text));
            foreach (var n in SacarInformacion) {
                txtRamoComisionesMantenimiento.Text = n.Ramo;
                txtSubRamoComisionesMAntenimiento.Text = n.Subramo;
                txtPorcientoCOmisionesComisionesMantenimiento.Text = n.PorcientoComision.ToString();
            }
            ClientScript.RegisterStartupScript(GetType(), "DesbloquearComision()", "DesbloquearComision();", true);
        }

        protected void btnGuardarComisionesIntermediarios_Click(object sender, EventArgs e)
        {
            //VALIDAMOS EL CAMPO CLAVE DE SEGURIDAD
            if (string.IsNullOrEmpty(txtPorcientoCOmisionesComisionesMantenimiento.Text.Trim()) || string.IsNullOrEmpty(txtClaveSeguridadComisionesMAntenimiento.Text.Trim())) {
                if (string.IsNullOrEmpty(txtPorcientoCOmisionesComisionesMantenimiento.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "PorcientoComisionVacio()", "PorcientoComisionVacio();", true);
                }
                if (string.IsNullOrEmpty(txtClaveSeguridadComisionesMAntenimiento.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadVacio()", "ClaveSeguridadVacio();", true);
                }
            }
            else {
                string _ClaveSeguridad = string.IsNullOrEmpty(txtClaveSeguridadComisionesMAntenimiento.Text.Trim()) ? null : txtClaveSeguridadComisionesMAntenimiento.Text.Trim();

                var ValidarClaveSeguridad = ObjData.BuscaClaveSeguridad(
                    new Nullable<decimal>(),
                    UtilidadesAmigos.Logica.Comunes.SeguridadEncriptacion.Encriptar(_ClaveSeguridad));
                if (ValidarClaveSeguridad.Count() < 1) {
                    ClientScript.RegisterStartupScript(GetType(), "ClaveSeguridadVacio()", "ClaveSeguridadVacio();", true);
                }
                else {
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionComisionesIntermediarioSeleccionado Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionComisionesIntermediarioSeleccionado(
                0
                , Convert.ToInt32(lbCodigoSeleccionadoVariable.Text)
                , Convert.ToInt32(lbCodigoRamoSeleccionadoComisionesMantenimiento.Text)
                , Convert.ToInt32(lbCodigoSubramoSeleccionaroComisionesMantenimiento.Text)
                , Convert.ToDecimal(txtPorcientoCOmisionesComisionesMantenimiento.Text)
                , 0
                , 0
                , 0
                , Guid.NewGuid()
                , ""
                , "UPDATE");
                    Procesar.ProcesarInformacion();
                    OcultarControlesComisiones();
                    MostrarComisionesIntermediario(Convert.ToInt32(lbCodigoSeleccionadoVariable.Text));
                }
            }



            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }

        protected void ddlSeleccionarRamoComisionesConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubramos();
            ClientScript.RegisterStartupScript(GetType(), "BloquearComision()", "BloquearComision();", true);
        }


    }
}
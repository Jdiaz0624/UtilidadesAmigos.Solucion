using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class CotizadorAmigos : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objdata = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaCotizador.LogicaCotizador> ObjDataCotizador = new Lazy<Logica.Logica.LogicaCotizador.LogicaCotizador>();

        #region CARGAR LOS LAS LISTAS DESPLEGABLES
        private void CargarLosDropPadres()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlTipoCotizador, Objdata.Value.BuscaListas("TIPOCOTIZADOR", null, null), true);
            //UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlImpuesto, Objdata.Value.BuscaListas("IMPUESTO", null, null));
            
        }
        private void CargarDatosTipoCotizador()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlValorVehiculo, Objdata.Value.BuscaListas("VALORVEHICULO", ddlTipoCotizador.SelectedValue, null), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculo, Objdata.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCoalicion, Objdata.Value.BuscaListas("COMPRENSIVOINCENDIOROBO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue, ddlAnoVehiculo.SelectedValue), true);
        }
        private void CargarDatosValorVehiculo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlAnoVehiculo, Objdata.Value.BuscaListas("ANOVEHICULO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue), true);
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCoalicion, Objdata.Value.BuscaListas("COMPRENSIVOINCENDIOROBO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue, ddlAnoVehiculo.SelectedValue), true);
        }
        private void CargarDatosAnoVehiculo()
        {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlCoalicion, Objdata.Value.BuscaListas("COMPRENSIVOINCENDIOROBO", ddlTipoCotizador.SelectedValue, ddlValorVehiculo.SelectedValue, ddlAnoVehiculo.SelectedValue), true);
        }
        #endregion
        #region VERIFICAR EL PERMISO DE LA COBERTURA
        private void VerificarPermiso()
        {
            decimal TipoCotizacion = 0;
            decimal Contador = 0;
            bool CasaConductor = false;
            bool ServicioGrua = false;
            bool VehiculoRenado = false;
            bool FuturoExequial = false;
            bool AeroAmbulancia = false;

            TipoCotizacion = Convert.ToDecimal(ddlTipoCotizador.SelectedValue);

            for (Contador = 0; Contador <= 5; Contador++)
            {
                var ValidarPermiso = ObjDataCotizador.Value.VerificarTipoCbertura(
                    TipoCotizacion,
                    Contador);
                foreach (var n in ValidarPermiso)
                {
                    if (Contador == 1)
                    {
                        CasaConductor = Convert.ToBoolean(n.TieneAcceso0);
                    }
                    else if (Contador == 2)
                    {
                        ServicioGrua = Convert.ToBoolean(n.TieneAcceso0);
                    }
                    else if (Contador == 3)
                    {
                        VehiculoRenado = Convert.ToBoolean(n.TieneAcceso0);
                    }
                    else if (Contador == 4)
                    {
                        FuturoExequial = Convert.ToBoolean(n.TieneAcceso0);
                    }
                    else if (Contador == 5)
                    {
                        AeroAmbulancia = Convert.ToBoolean(n.TieneAcceso0);
                    }
                }

                //VALIDAMOS LA CASA DEL CONDUCTOR
                if (CasaConductor == true)
                {
                    lbCasaConductorCoiador.Visible = true;
                    txtCasaConductor.Visible = true;
                }
                else
                {
                    lbCasaConductorCoiador.Visible = false;
                    txtCasaConductor.Visible = false;
                }
                //VALIDAMOS EL SERVICIO DE LAS GRUAS
                if (ServicioGrua == true)
                {
                    lbGruaCotizador.Visible = true;
                    txtServicioGrua.Visible = true;
                }
                else
                {
                    lbGruaCotizador.Visible = false;
                    txtServicioGrua.Visible = false;
                }
                //VALIDAMOS LOS SERVICIOS DE VEHICULO RENTADO
                if (VehiculoRenado == true)
                {
                    lbRentaCotizador.Visible = true;
                    txtRentaVehiculo.Visible = true;
                }
                else
                {
                    lbRentaCotizador.Visible = false;
                    txtRentaVehiculo.Visible = false;
                }
                //VALIDAMOS LOS SERVICIOS DE FUTURO EXEQUIAL
                if (FuturoExequial == true)
                {
                    lbFurutoExequial.Visible = true;
                    txtFuturoExequial.Visible = true;
                }
                else
                {
                    lbFurutoExequial.Visible = false;
                    txtFuturoExequial.Visible = false;
                }
                //VALIDAMOS LOS SERVICIOS DE AEROAMBULANCIA
                if (AeroAmbulancia == true)
                {
                    lbAeroAmbulancia.Visible = true;
                    txtAeroAmbulacia.Visible = true;
                }
                else
                {
                    lbAeroAmbulancia.Visible = false;
                    txtAeroAmbulacia.Visible = false;
                }
            }
        }
        #endregion
        #region OCULTAR Y MOSTRAR CONTROLES
        private void OcultarControlesPrincipales()
        {
            lbTipoCotizadorCotizador.Visible = false;
            ddlTipoCotizador.Visible = false;
            lbValorVehiculoCotizador.Visible = false;
            ddlValorVehiculo.Visible = false;
            lbanovehiculoCotizador.Visible = false;
            ddlAnoVehiculo.Visible = false;
            lbImpuestoCotizador.Visible = false;
            txtImpuesto.Visible = false;
            lbIncendioRobo.Visible = false;
            ddlCoalicion.Visible = false;
            lbCasaConductorCoiador.Visible = false;
            txtCasaConductor.Visible = false;
            lbGruaCotizador.Visible = false;
            txtServicioGrua.Visible = false;
            lbRentaCotizador.Visible = false;
            txtRentaVehiculo.Visible = false;
            lbTotal.Visible = false;
            txtTotal.Visible = false;
            //lbPrima.Visible = false;
            //txtPrima.Visible = false;
            btnTipoCotizador.Visible = false;
            btnValorVehiculo.Visible = false;
            btnAnoVehiculo.Visible = false;
            btnImpuesto.Visible = false;
            btnCoalicion.Visible = false;
        }
        private void MostrarControlesPrincipales()
        {
            lbTipoCotizadorCotizador.Visible = true;
            ddlTipoCotizador.Visible = true;
            lbValorVehiculoCotizador.Visible = true;
            ddlValorVehiculo.Visible = true;
            lbanovehiculoCotizador.Visible = true;
            ddlAnoVehiculo.Visible = true;
            lbImpuestoCotizador.Visible = true;
            txtImpuesto.Visible = true;
            lbIncendioRobo.Visible = true;
            ddlCoalicion.Visible = true;
            lbCasaConductorCoiador.Visible = true;
            txtCasaConductor.Visible = true;
            lbGruaCotizador.Visible = true;
            txtServicioGrua.Visible = true;
            lbRentaCotizador.Visible = true;
            txtRentaVehiculo.Visible = true;
            lbTotal.Visible = true;
            txtTotal.Visible = true;
            //lbPrima.Visible = true;
            //txtPrima.Visible = true;
            btnTipoCotizador.Visible = true;
            btnValorVehiculo.Visible = true;
            btnAnoVehiculo.Visible = true;
            btnImpuesto.Visible = true;
            btnCoalicion.Visible = true;
        }
        private void MostrarControlesTipoCotizador()
        {
            //lbEncabezadoTipoCotizador.Visible = true;
            lblabelControlConsulta.Visible = true;
            txtControlBusqueda.Visible = true;
        }
        private void OcultarControlesTipoCotizador()
        {
           // lbEncabezadoTipoCotizador.Visible = false;
            lblabelControlConsulta.Visible = false;
            txtControlBusqueda.Visible = false;
        }
        #endregion
        #region SACAR LOS DATOS FIJOS
        private void SacarServicioFijo(decimal IdServicioFijo)
        {
            bool Impuesto = true, CasaConductor = true, ServicioGrua = true, VehiculoRentado = true, FuturoExequial = true, AeroAmbulancia = true;
            var Sacar = ObjDataCotizador.Value.BuscaServiciosFijos(IdServicioFijo);
            foreach (var n in Sacar)
            {
                txtImpuesto.Text = n.Impuesto.ToString();
                txtCasaConductor.Text = n.CasaConductor.ToString();
                txtServicioGrua.Text = n.ServicioGrua.ToString();
                txtRentaVehiculo.Text = n.VehiculoRentado.ToString();
                txtFuturoExequial.Text = n.FuturoExequial.ToString();
                txtAeroAmbulacia.Text = n.AeroAmbulancia.ToString();
                Impuesto = Convert.ToBoolean(n.ImpuestoFijo0);
                CasaConductor = Convert.ToBoolean(n.CasaConductorFijo0);
                ServicioGrua = Convert.ToBoolean(n.ServicioGruaFijo0);
                VehiculoRentado = Convert.ToBoolean(n.VehiculoRentadoFijo0);
                FuturoExequial = Convert.ToBoolean(n.FuturoExequialFijo0);
                AeroAmbulancia = Convert.ToBoolean(n.AeroAmbulanciaFijo0);
            }
            //VALIDAMOS SI EL IMPUESTO ESTA FIJO
            if (Impuesto == true)
            {
                txtImpuesto.Enabled = false;
            }
            else
            {
                txtImpuesto.Enabled = true;
            }

            //VALIDAMOS SI LA CASA DEL CONDUCTOR ESTA FIJA
            if (CasaConductor == true)
            {
                txtCasaConductor.Enabled = false;
            }
            else
            {
                txtCasaConductor.Enabled = true;
            }

            //VALIDAMOS SI EL SERVICIO DE GRUA STA FIJO
            if (ServicioGrua == true)
            {
                txtServicioGrua.Enabled = false;
            }
            else
            {
                txtServicioGrua.Enabled = true;
            }

            //VALIDAMOS SI EL VEHICULO RENTADO ESTA FIJO
            if (VehiculoRentado == true)
            {
                txtRentaVehiculo.Enabled = false;
            }
            else
            {
                txtRentaVehiculo.Enabled = true;
            }
            //VALIDAMOS SI EL FUTURO EXEQUIAL ESTA FIJO
            if (FuturoExequial == true)
            {
                txtFuturoExequial.Enabled = false;
            }
            else
            {
                txtFuturoExequial.Enabled = true;
            }
            //VALIDAMOS SI AERO AMBULANCIA ESTA FIJO
            if (AeroAmbulancia == true)
            {
                txtAeroAmbulacia.Enabled = false;
            }
            else
            {
                txtAeroAmbulacia.Enabled = true;
            }
        }
        #endregion
        #region CALCULAR
        private void Calcular()
        {
            /*
            SERVICIOS        --> CASA DEL CONDUCTOR + SERVICIO DE GRUA + VEHICULO RENTADO
            PRIMA BRUTA      --> (VALOR DE VEHICULO * (COALICION INCENDIO Y ROBO / IMPUESTO)) + SERVICIOS
            IMPUESTO         --> PRIMA BRUTA * IMPUESTO
            TOTAL            --> PRIMA BRUTA + IMPUESTO

            * */

            try
            {

                //CALCULAMOS LOS SERVICIOS
                decimal CasaConductor = 0, ServicioGrua = 0, VehiculoRentado = 0, FuturoExequial = 0, Aeroambulancia = 0, TotalServicios;

                switch (txtCasaConductor.Visible)
                {
                    case true:
                        CasaConductor = Convert.ToDecimal(txtCasaConductor.Text);
                        break;
                    case false:
                        CasaConductor = 0;
                        break;
                }

                switch (txtServicioGrua.Visible)
                {
                    case true:
                        ServicioGrua = Convert.ToDecimal(txtServicioGrua.Text);
                        break;
                    case false:
                        ServicioGrua = 0;
                        break;
                }
                switch (txtRentaVehiculo.Visible)
                {
                    case true:
                        VehiculoRentado = Convert.ToDecimal(txtRentaVehiculo.Text);
                        break;
                    case false:
                        VehiculoRentado = 0;
                        break;
                }
                switch (txtFuturoExequial.Visible)
                {
                    case true:
                        FuturoExequial = Convert.ToDecimal(txtFuturoExequial.Text);
                        break;
                    case false:
                        FuturoExequial = 0;
                        break;
                }
                switch (txtAeroAmbulacia.Visible)
                {
                    case true:
                        Aeroambulancia = Convert.ToDecimal(txtAeroAmbulacia.Text);
                        break;
                    case false:
                        Aeroambulancia = 0;
                        break;
                }
                TotalServicios = CasaConductor + ServicioGrua + VehiculoRentado + FuturoExequial + Aeroambulancia;
                txtServicios.Text = TotalServicios.ToString();

                //CALCULAMOS EL TOTAL
                decimal ValorVehiculo = 0, Coalicion = 0, CoalicionConvertido = 0, Impusto = 0, Total;

                ValorVehiculo = Convert.ToDecimal(ddlValorVehiculo.SelectedItem.Text);
                Coalicion = Convert.ToDecimal(ddlCoalicion.SelectedItem.Text);
                CoalicionConvertido = Coalicion / 100;
                Impusto = Convert.ToDecimal(txtImpuesto.Text);

                Total = (ValorVehiculo * CoalicionConvertido) * (Impusto) + TotalServicios;

                txtTotal.Text = Math.Round(Total, 2).ToString();



            }
            catch (Exception)
            {
                txtTotal.Text = string.Empty;
                txtTotal.Text = "0";
                txtServicios.Text = string.Empty;
                txtServicios.Text = "0";
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
            if (!IsPostBack)
            {
                //CARGAMOS EL TIPO DE COTIZADOR
                CargarLosDropPadres();
                CargarDatosTipoCotizador();
                SacarServicioFijo(1);
            }
        }

        protected void ddlTipoCotizador_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarPermiso();
            CargarDatosTipoCotizador();
            Calcular();
        }

        protected void btnTipoCotizador_Click(object sender, EventArgs e)
        {

        }

        protected void btnValorVehiculo_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.open('Login.aspx','popup','width=800,height=500') </script>");


            string vtn = "window.open('ValorVehiculo.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void cbRefrescar_CheckedChanged(object sender, EventArgs e)
        {
            ddlTipoCotizador.AutoPostBack = true;
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            try {
                string vtn = "window.open('prueba.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
            }
            catch (Exception) { }
        }

        protected void ddlValorVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosValorVehiculo();
            Calcular();
            //var CargarPrueba = Objdata.Value.BuscaListas(
            //    "",
            //    ddlTipoCotizador.SelectedValue,
            //    ddlValorVehiculo.SelectedValue);
            //ddlAnoVehiculo.DataSource = CargarPrueba;
            //ddlAnoVehiculo.DataValueField = "IdAnoVehiculo";
            //ddlAnoVehiculo.DataTextField = "AnoVehiculo";
            //ddlAnoVehiculo.DataBind();
        }

        protected void btnAnoVehiculo_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('AnoVehiculo.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void ddlAnoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosAnoVehiculo();
            Calcular();
        }

        protected void btnImpuesto_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('ServiciosFijos.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void btnCoalicion_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('ComprensivoIncendioRoboPoPup.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnCotizar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCoalicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calcular();
        }
    }
}
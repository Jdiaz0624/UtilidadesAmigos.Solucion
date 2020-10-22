using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarSolicitudChequeComisionesIntermediarios : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObjdataMantenimiento = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();

        #region SACAR EL NOMBRE DEL INTERMEDIARIO
        private void SacarNombreIntermediario() {
            var SacarNombreVendedor = ObjdataMantenimiento.Value.BuscaListadoIntermediario(
                txtCodigoIntermediario.Text,
                null,
                null,
                null,
                null);
            foreach (var n in SacarNombreVendedor) {
                txtNombreIntermediario.Text = n.NombreVendedor;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rbChequeNoEndosable.Checked = true;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarBanco, ObjData.Value.BuscaListas("LISTADOBANCOS", null, null));
            }
        }

        protected void btnProcesarSolicitud_Click(object sender, EventArgs e)
        {
       
            //VALIDAMOS QUE LOS CAMPOS FECHAS NO ESTEN VACIOS
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVacio()", "CampoFechaDesdeVacio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHastaVacio()", "CampoFechaHastaVacio();", true);
                }
            }
            else  {
            
                if (cbGenerarSolicidutLote.Checked == true) {
                    //VALIDAMOS LA VARIABLE DE SESION
                    if (Session["IdUsuario"] != null) {
                        //SACAMOS EL NOMBRE DEL USUARIO QUE VA A REALIZAR ESTE PROCESO
                        string UsuarioProcesaLote = "";

                        var SacarNombreusuario = ObjData.Value.BuscaUsuarios(Convert.ToDecimal(Session["IdUsuario"]));
                        foreach (var nUsuarioLote in SacarNombreusuario)
                        {
                            UsuarioProcesaLote = nUsuarioLote.Persona;
                        }

                        //ELIMINAMOS TODOS LOS REGISTROS DE LA TABLA DE COMISIONES DE INTERMEDIARIO
                        UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario Eliminar = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                        Convert.ToDecimal(Session["IdUsuario"]), "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "DELETE");
                        Eliminar.ProcesarInformacion();

                        //ELIMINAR LOS DATOS DE LA TABLA DE REGISTROS DE SOLICITUD DE CHEQUE EN LOTE
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote EliminarDatosLote = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                            0, (decimal)Session["IdUsuario"], 0, 0, DateTime.Now, DateTime.Now, DateTime.Now, 0, false, "DELETE");
                        EliminarDatosLote.ProcesarInformacion();

                        //CONSULTAMOS LAS COMISIONES A PARTIR DEL RANGO DE FECHA INGRESADO
                        var BuscarComisionesIntermediario = ObjData.Value.GenerarComisionIntermediario(
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text), null, null);
                        foreach (var nComisiones in BuscarComisionesIntermediario) {
                            UtilidadesAmigos.Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario ProcesarComisiones = new Logica.Comunes.Reportes.ProcesarInformacionReporteComisionIntermediario(
                                (decimal)Session["IdUsuario"],
                                 nComisiones.Supervisor,
                                 Convert.ToInt32(nComisiones.Codigo),
                                 nComisiones.Intermediario,
                                 nComisiones.Oficina,
                                 nComisiones.NumeroIdentificacion,
                                 nComisiones.CuentaBanco,
                                 nComisiones.TipoCuenta,
                                 nComisiones.Banco,
                                 nComisiones.Cliente,
                                 nComisiones.Recibo,
                                 nComisiones.Fecha,
                                 nComisiones.Factura,
                                 nComisiones.FechaFactura,
                                 nComisiones.Moneda,
                                 nComisiones.Poliza,
                                 nComisiones.Producto,
                                 Convert.ToDecimal(nComisiones.Bruto),
                                 Convert.ToDecimal(nComisiones.Neto),
                                 Convert.ToDecimal(nComisiones.PorcientoComision),
                                 Convert.ToDecimal(nComisiones.Comision),
                                 Convert.ToDecimal(nComisiones.Retencion),
                                 Convert.ToDecimal(nComisiones.AvanceComision),
                                 Convert.ToDecimal(nComisiones.ALiquidar),
                                 Convert.ToDecimal(nComisiones.CantidadRegistros),
                                 Convert.ToDateTime(txtFechaDesde.Text),
                                 Convert.ToDateTime(txtFechaHasta.Text),
                                 "INSERT");
                            ProcesarComisiones.ProcesarInformacion();
                        }
                        //CONSULTAMOS LA INFORMACION DE MANERA RESUMIDA
                        var ConsultarRegistrosResumido = ObjData.Value.ComisionIntermediarioResumido((decimal)Session["IdUsuario"]);
                        int CodigoIntermediarioSacadoResumen = 0;
                        decimal MontoLiquidarIntermediario = 0;
                        decimal MontoMinimo = Convert.ToDecimal(txtMontoMinimoProceso.Text);
                        foreach (var nComisionResumida in ConsultarRegistrosResumido) {
                            CodigoIntermediarioSacadoResumen = Convert.ToInt32(nComisionResumida.CodigoIntermediario);
                            MontoLiquidarIntermediario = Convert.ToDecimal(nComisionResumida.ALiquidar);

                            if (MontoLiquidarIntermediario < MontoMinimo)
                            {
                                //GUARDAMOS LOS DATOS DEL REGISTRO DESCARTADO
                                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote GuardarRegistroloteDescartado = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                                    0,
                                    (decimal)Session["IdUsuario"],
                                    CodigoIntermediarioSacadoResumen,
                                    0,
                                    DateTime.Now,
                                    Convert.ToDateTime(txtFechaDesde.Text),
                                    Convert.ToDateTime(txtFechaHasta.Text),
                                    MontoLiquidarIntermediario,
                                    false,
                                    "INSERT");
                                GuardarRegistroloteDescartado.ProcesarInformacion();
                            }
                            else {
                                //CONSULTAMOS CADA CODIGO QUE CUMPLE LA CONDICION
                                var BuscarCodigoDataIntermediario = ObjdataMantenimiento.Value.BuscaListadoIntermediario(CodigoIntermediarioSacadoResumen.ToString(), null, null, null, null);
                                string NombreIntermediario = "";
                                string NumeroIdentificacionIntermediario = "";
                                foreach (var HalarInformacionIntermediario in BuscarCodigoDataIntermediario) {
                                    NombreIntermediario = HalarInformacionIntermediario.NombreVendedor;
                                    NumeroIdentificacionIntermediario = HalarInformacionIntermediario.Rnc;

                                    //BUSCAMOS EN LA DATA DE LOS PROVEEDORES PARA SABER SI EL ARCHIVO EXISTE
                                    var BuscarDataproveedores = ObjdataMantenimiento.Value.BuscaProveedores(
                                        new Nullable<int>(),
                                        NumeroIdentificacionIntermediario,
                                        NombreIntermediario);
                                    if (BuscarDataproveedores.Count() < 1) {
                                        //REGISTRO NO ENCONTRADO
                                        //CREAMOS UN NUEVO PROVEEDOR A PARTIR DE LOS DATOS DEL INTERMEDIARIO CONSULTADO
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProveedoresSolicitud NuevoProveedor = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProveedoresSolicitud(
                                            Convert.ToInt32(HalarInformacionIntermediario.Compania),
                                            0,
                                            16,
                                            Convert.ToInt32(HalarInformacionIntermediario.TipoRnc),
                                            HalarInformacionIntermediario.Rnc,
                                            HalarInformacionIntermediario.NombreVendedor,
                                            HalarInformacionIntermediario.Direccion,
                                            Convert.ToInt32(HalarInformacionIntermediario.Ubicacion),
                                            0, 0, 0,
                                            Convert.ToInt32(HalarInformacionIntermediario.Estatus0),
                                            DateTime.Now, 0, 0,
                                            UsuarioProcesaLote,
                                            DateTime.Now,
                                            UsuarioProcesaLote,
                                            DateTime.Now,
                                            0,
                                            Convert.ToDecimal(HalarInformacionIntermediario.PorcientoComision),
                                            1,
                                            HalarInformacionIntermediario.Telefono,
                                            HalarInformacionIntermediario.TelefonoOficina,
                                            HalarInformacionIntermediario.Celular,
                                            HalarInformacionIntermediario.Fax,
                                            HalarInformacionIntermediario.Beeper,
                                            HalarInformacionIntermediario.Email,
                                            0,
                                            Convert.ToInt32(HalarInformacionIntermediario.Banco),
                                            HalarInformacionIntermediario.Cuenta,
                                            HalarInformacionIntermediario.Agencia,
                                            HalarInformacionIntermediario.TipoCuentaBco,
                                            "01 - Agente",
                                            "INSERT");
                                        NuevoProveedor.ProcesarInformacion();

                                        decimal SacarCodigoProveedorProcesoLote = 0;

                                        var SacarCodigoProveedor = ObjdataMantenimiento.Value.BuscaProveedores(
                                         new Nullable<int>(),
                                         NumeroIdentificacionIntermediario, NombreIntermediario);
                                        foreach (var n in SacarCodigoProveedor)
                                        {
                                            SacarCodigoProveedorProcesoLote = Convert.ToInt32(n.Codigo);
                                        }

                                        // SACAMOS LA SUMA DE LOS MONTOS GUARDADOS ANTERIORMENTE
                                         decimal SumaBrutoProcesoLote = 0, SumaNetoProcesoLote = 0, SumaComisionProcesolote = 0, SumaRetencionProcesplote = 0, SumaAvanceProcesolote = 0, SumaALiquidarProcesoLote = 0;

                                        var SacarSumaMontos = ObjdataMantenimiento.Value.BuscaMontos(
                                            Convert.ToDecimal(Session["IdUsuario"]),Convert.ToInt32(HalarInformacionIntermediario.Codigo));
                                        foreach (var nSumaMontosProcesoLote in SacarSumaMontos)
                                        {
                                            SumaBrutoProcesoLote = Convert.ToDecimal(nSumaMontosProcesoLote.Bruto);
                                            SumaNetoProcesoLote = Convert.ToDecimal(nSumaMontosProcesoLote.Neto);
                                            SumaComisionProcesolote = Convert.ToDecimal(nSumaMontosProcesoLote.Comision);
                                            SumaRetencionProcesplote = Convert.ToDecimal(nSumaMontosProcesoLote.Retencion);
                                            SumaAvanceProcesolote = Convert.ToDecimal(nSumaMontosProcesoLote.Avance);
                                            SumaALiquidarProcesoLote = Convert.ToDecimal(nSumaMontosProcesoLote.ALiquidar);
                                        }


                                        //GUARDAMOS LA SOLICITUD DE CHEQUE
                                        string EndosableProcesoLote = "";
                                        if (rbChequeEndosable.Checked == true)
                                        {
                                            EndosableProcesoLote = "Si";
                                        }
                                        else if (rbChequeNoEndosable.Checked == true)
                                        {
                                            EndosableProcesoLote = "No";
                                        }
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCheques ProcesarSolicitusChequesLote = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCheques(
                                            HalarInformacionIntermediario.Compania,
                                            "", 0, 0, 0, "",
                                            DateTime.Now,
                                            0, "", 0, "", 0, "",
                                            Convert.ToInt32(HalarInformacionIntermediario.TipoRnc),
                                            HalarInformacionIntermediario.Rnc,
                                            (int)SacarCodigoProveedorProcesoLote,
                                            "", "",
                                            EndosableProcesoLote,
                                            Convert.ToInt32(ddlSeleccionarBanco.SelectedValue),
                                            HalarInformacionIntermediario.Cuenta,
                                            SumaALiquidarProcesoLote,
                                            "", "", 0, DateTime.Now, 0, DateTime.Now,
                                            UsuarioProcesaLote,
                                            UsuarioProcesaLote,
                                            DateTime.Now, DateTime.Now, 0, DateTime.Now, UsuarioProcesaLote, "", "",
                                            UsuarioProcesaLote,
                                            0, "N", 0,
                                            Convert.ToDateTime(txtFechaDesde.Text),
                                            Convert.ToDateTime(txtFechaHasta.Text),
                                            SumaBrutoProcesoLote,
                                            SumaComisionProcesolote,
                                            SumaRetencionProcesplote,
                                            "INSERT");
                                        ProcesarSolicitusChequesLote.ProcesarInformacion();

                                        //SACAMOS EL NUMERO DE SOLICITUD GENERADO
                                        //SACAMOS EL NUMERO DE SOLICITUD GENERADO
                                        int NumeroSolicitudGeneradoProcesoLote = UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SacarUltimoNumeroSolicitudGenerada.SacarNumeroSolicitud((int)SacarCodigoProveedorProcesoLote);
                                        string NumeroSolicitudConvertidaProcesoLote = NumeroSolicitudGeneradoProcesoLote.ToString();

                                        //GUARDAMOS LOS DATOS DE LAS CUENTAS CONTABLES
                                        //CUENTA 1203
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta1 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                            30, "N", 13, NumeroSolicitudGeneradoProcesoLote, 0, "1203", 1, "", "2", SumaALiquidarProcesoLote, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                                        Cuenta1.ProcesarInformacion();

                                        //CUENTA 2503
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta2 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                            30, "N", 13, NumeroSolicitudGeneradoProcesoLote, 0, "2503", 0, "", "1", SumaComisionProcesolote, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                                        Cuenta2.ProcesarInformacion();

                                        //CUENTA 2706
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta3 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                            30, "N", 13, NumeroSolicitudGeneradoProcesoLote, 0, "2706", 0, "", "2", SumaRetencionProcesplote, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                                        Cuenta3.ProcesarInformacion();


                                        //GUARDAMOS LOS DATOS EN LA TABLA DE RegistrosSolicitudChequeLote
                                        //GUARDAMOS LOS DATOS DEL REGISTRO DESCARTADO
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote GuardarRegistroloteProcesado = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                                            0,
                                            (decimal)Session["IdUsuario"],
                                            CodigoIntermediarioSacadoResumen,
                                            NumeroSolicitudGeneradoProcesoLote,
                                            DateTime.Now,
                                            Convert.ToDateTime(txtFechaDesde.Text),
                                            Convert.ToDateTime(txtFechaHasta.Text),
                                            MontoLiquidarIntermediario,
                                            true,
                                            "INSERT");
                                        GuardarRegistroloteProcesado.ProcesarInformacion();

                                      


                                    }
                                    else {
                                        //REGISTRO ENCONTRADO
                                        int SacarCodigoProveedorProcesoLote = 0;
                                        var SacarCodigoProveedorProceso2 = ObjdataMantenimiento.Value.BuscaProveedores(
                                        new Nullable<int>(),
                                        NumeroIdentificacionIntermediario, NombreIntermediario);
                                        foreach (var n in SacarCodigoProveedorProceso2)
                                        {
                                            SacarCodigoProveedorProcesoLote = Convert.ToInt32(n.Codigo);
                                        }

                                        // SACAMOS LA SUMA DE LOS MONTOS GUARDADOS ANTERIORMENTE
                                        decimal SumaBrutoProcesoLote = 0, SumaNetoProcesoLote = 0, SumaComisionProcesolote = 0, SumaRetencionProcesplote = 0, SumaAvanceProcesolote = 0, SumaALiquidarProcesoLote = 0;

                                        var SacarSumaMontos = ObjdataMantenimiento.Value.BuscaMontos(
                                            Convert.ToDecimal(Session["IdUsuario"]), Convert.ToInt32(HalarInformacionIntermediario.Codigo));
                                        foreach (var nSumaMontosProcesoLote in SacarSumaMontos)
                                        {
                                            SumaBrutoProcesoLote = Convert.ToDecimal(nSumaMontosProcesoLote.Bruto);
                                            SumaNetoProcesoLote = Convert.ToDecimal(nSumaMontosProcesoLote.Neto);
                                            SumaComisionProcesolote = Convert.ToDecimal(nSumaMontosProcesoLote.Comision);
                                            SumaRetencionProcesplote = Convert.ToDecimal(nSumaMontosProcesoLote.Retencion);
                                            SumaAvanceProcesolote = Convert.ToDecimal(nSumaMontosProcesoLote.Avance);
                                            SumaALiquidarProcesoLote = Convert.ToDecimal(nSumaMontosProcesoLote.ALiquidar);
                                        }
                                        //GUARDAMOS LA SOLICITUD DE CHEQUE
                                        string EndosableProcesoLote = "";
                                        if (rbChequeEndosable.Checked == true)
                                        {
                                            EndosableProcesoLote = "Si";
                                        }
                                        else if (rbChequeNoEndosable.Checked == true)
                                        {
                                            EndosableProcesoLote = "No";
                                        }
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCheques ProcesarSolicitusChequesLote = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCheques(
                                            HalarInformacionIntermediario.Compania,
                                            "", 0, 0, 0, "",
                                            DateTime.Now,
                                            0, "", 0, "", 0, "",
                                            Convert.ToInt32(HalarInformacionIntermediario.TipoRnc),
                                            HalarInformacionIntermediario.Rnc,
                                            (int)SacarCodigoProveedorProcesoLote,
                                            "", "",
                                            EndosableProcesoLote,
                                            Convert.ToInt32(ddlSeleccionarBanco.SelectedValue),
                                            HalarInformacionIntermediario.Cuenta,
                                            SumaALiquidarProcesoLote,
                                            "", "", 0, DateTime.Now, 0, DateTime.Now,
                                            UsuarioProcesaLote,
                                            UsuarioProcesaLote,
                                            DateTime.Now, DateTime.Now, 0, DateTime.Now, UsuarioProcesaLote, "", "",
                                            UsuarioProcesaLote,
                                            0, "N", 0,
                                            Convert.ToDateTime(txtFechaDesde.Text),
                                            Convert.ToDateTime(txtFechaHasta.Text),
                                            SumaBrutoProcesoLote,
                                            SumaComisionProcesolote,
                                            SumaRetencionProcesplote,
                                            "INSERT");
                                        ProcesarSolicitusChequesLote.ProcesarInformacion();

                                        //SACAMOS EL NUMERO DE SOLICITUD GENERADO
                                        //SACAMOS EL NUMERO DE SOLICITUD GENERADO
                                        int NumeroSolicitudGeneradoProcesoLote = UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SacarUltimoNumeroSolicitudGenerada.SacarNumeroSolicitud((int)SacarCodigoProveedorProcesoLote);
                                        string NumeroSolicitudConvertidaProcesoLote = NumeroSolicitudGeneradoProcesoLote.ToString();

                                        //GUARDAMOS LOS DATOS DE LAS CUENTAS CONTABLES
                                        //CUENTA 1203
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta1 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                            30, "N", 13, NumeroSolicitudGeneradoProcesoLote, 0, "1203", 1, "", "2", SumaALiquidarProcesoLote, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                                        Cuenta1.ProcesarInformacion();

                                        //CUENTA 2503
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta2 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                            30, "N", 13, NumeroSolicitudGeneradoProcesoLote, 0, "2503", 0, "", "1", SumaComisionProcesolote, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                                        Cuenta2.ProcesarInformacion();

                                        //CUENTA 2706
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta3 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                            30, "N", 13, NumeroSolicitudGeneradoProcesoLote, 0, "2706", 0, "", "2", SumaRetencionProcesplote, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                                        Cuenta3.ProcesarInformacion();


                                        //GUARDAMOS LOS DATOS EN LA TABLA DE RegistrosSolicitudChequeLote
                                        //GUARDAMOS LOS DATOS DEL REGISTRO DESCARTADO
                                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote GuardarRegistroloteProcesado = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionRegistrosSolicitudChequeLote(
                                            0,
                                            (decimal)Session["IdUsuario"],
                                            CodigoIntermediarioSacadoResumen,
                                            NumeroSolicitudGeneradoProcesoLote,
                                            DateTime.Now,
                                            Convert.ToDateTime(txtFechaDesde.Text),
                                            Convert.ToDateTime(txtFechaHasta.Text),
                                            MontoLiquidarIntermediario,
                                            true,
                                            "INSERT");
                                        GuardarRegistroloteProcesado.ProcesarInformacion();


                                    }
                                }

                                int CantidadRegistrosprocesados = 0, CantidadRegistrosDescartados = 0, CantidadRegistros = 0;
                                var BuscarCantidadRegistros = ObjdataMantenimiento.Value.BuscaRegistrosSolicitudChequeLote((decimal)Session["IdUsuario"], null);
                                foreach (var nCantidad in BuscarCantidadRegistros)
                                {
                                    CantidadRegistrosprocesados = Convert.ToInt32(nCantidad.CantidadProcesados);
                                    CantidadRegistrosDescartados = Convert.ToInt32(nCantidad.CantidadDescartados);
                                    CantidadRegistros = Convert.ToInt32(nCantidad.CantidadRegistros);
                                }

                                //EXPORTAMOS LA INFORMACION A EXEL
                                var ExportarDataExel = (from n in ObjdataMantenimiento.Value.BuscaRegistrosSolicitudChequeLote((decimal)Session["IdUsuario"], null)
                                                        select new
                                                        {
                                                            Creado_Por = n.CreadoPor,
                                                            Codigo_Intermediario = n.CodigoIntermediario,
                                                            Intermediario = n.Intermediario,
                                                            Numero_Solicitud = n.NumeroSolicitud,
                                                            Fecha_Proceso = n.FechaProceso,
                                                            Validado_Desde = n.ValidadoDesde,
                                                            Validado_Hasta = n.ValidadoHasta,
                                                            Monto = n.MontoSolicitud,
                                                            Estatus = n.Estatus
                                                        }).ToList();
                                UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Registros Procesados Solicitud de Cheques", ExportarDataExel);
                                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Cantidad de Registros procesados " + CantidadRegistrosprocesados.ToString("N0") + " Cantidad de registros Descartados " + CantidadRegistrosDescartados.ToString("N2") + " Cantidad de Registros " + CantidadRegistros.ToString("N2") + "');", true);
                                 


                            }
                        }

                    }
                    else {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }
                }


                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\


                //GENERAMOS LA SOLICITUD DE CHEQUE DE MANERA INDIVIDUAL
                else if (cbGenerarSolicidutLote.Checked == false) {
                    

                    //VALIDAMOS QUE EL CODIGO DE INTERMEDIARIO INGRESADO ES VALIDO
                    string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                    var Validar = ObjdataMantenimiento.Value.BuscaListadoIntermediario(
                        _CodigoIntermediario);
                    if (Validar.Count() < 1)
                    {
                        string Mensaje = "El codigo " + txtCodigoIntermediario.Text + " no existe, favor de verificar e intentar nuevamente";
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + Mensaje + "');", true);
                    }
                    else
                    {

                        if (Session["IdUsuario"] != null)
                        {
                            //SACAMOS EL NOMBRE DEL USUARURIO QUE VA A HACER EL PROCESO
                            string UsuarioProcesa = "";

                            var SacarNombreusuario = ObjData.Value.BuscaUsuarios(Convert.ToDecimal(Session["IdUsuario"]));
                            foreach (var nUsuario in SacarNombreusuario)
                            {
                                UsuarioProcesa = nUsuario.Persona;
                            }
                            //SACAMOS LOS DATOS DEL INTERMEDIARIOS NECESARIOS PARA CREAR EL PROVEEDOR EN CASO DE QUE NO EXISTE
                            //DECLARAMOS LAS VARIABLES NECESARIAS
                            int Compania = 0;
                            int Codigo = 0;
                            int TipoCliente = 0;
                            int TipoRnc = 0;
                            string RNC = "";
                            string NombreCliente = "";
                            string Direccion = "";
                            int Ubicacion = 0;
                            decimal LimiteCredito = 0;
                            decimal Descuento = 0;
                            int CondicionPago = 0;
                            int Estatus = 0;
                            DateTime FechaUltPago = DateTime.Now;
                            decimal MontoUltPago = 0;
                            decimal Balance = 0;
                            string UsuarioAdiciona = "";
                            DateTime FechaAdiciona = DateTime.Now;
                            string UsuarioModifica = "";
                            DateTime FechaModifica = DateTime.Now;
                            int CodigoRnc = 0;
                            decimal PorcComision = 0;
                            int CodMoneda = 0;
                            string TelefonoCasa = "";
                            string TelefonoOficina = "";
                            string Celular = "";
                            string Fax = "";
                            string Beeper = "";
                            string Email = "";
                            int TipoPago = 0;
                            int Banco = 0;
                            string CuentaBanco = "";
                            string Contacto = "";
                            string TipoCuentaBanco = "";
                            string ClaseProveedor = "";

                            foreach (var n in Validar)
                            {
                                Compania = Convert.ToInt32(n.Compania);
                                Codigo = Convert.ToInt32(n.Codigo);
                                TipoCliente = 16;
                                TipoRnc = Convert.ToInt32(n.TipoRnc);
                                RNC = n.Rnc;
                                NombreCliente = n.NombreVendedor;
                                Direccion = n.Direccion;
                                Ubicacion = Convert.ToInt32(n.Ubicacion);
                                LimiteCredito = 0;
                                Descuento = 0;
                                CondicionPago = 0;
                                Estatus = Convert.ToInt32(n.Estatus0);
                                FechaUltPago = DateTime.Now;
                                MontoUltPago = 0;
                                Balance = 0;
                                UsuarioAdiciona = "";
                                FechaAdiciona = DateTime.Now;
                                UsuarioModifica = "";
                                FechaModifica = DateTime.Now;
                                CodigoRnc = 0;
                                PorcComision = Convert.ToDecimal(n.PorcientoComision);
                                CodMoneda = 1;
                                TelefonoCasa = n.Telefono;
                                TelefonoOficina = n.TelefonoOficina;
                                Celular = n.Celular;
                                Fax = n.Fax;
                                Beeper = n.Beeper;
                                Email = n.Email;
                                TipoPago = 0;
                                Banco = Convert.ToInt32(n.Banco);
                                CuentaBanco = n.CtaBanco;
                                Contacto = n.Agencia;
                                TipoCuentaBanco = n.TipoCuentaBco;
                                ClaseProveedor = "01 - Agente";
                            }

                            //BUSCAMOS EL REGISTRO

                            int CodigoProveedorSacardo = 0;
                            var BuscarProveedor = ObjdataMantenimiento.Value.BuscaProveedores(null, RNC, NombreCliente);
                            if (BuscarProveedor.Count() < 1)
                            {
                                //GUARDAMOS EL REGISTRO Y SACAMOS EL CODIGO DEL REGISTRO CREADO
                                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProveedoresSolicitud Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProveedoresSolicitud(
                                    Compania,
                                    0,
                                    TipoCliente,
                                    TipoRnc,
                                    RNC,
                                    NombreCliente,
                                    Direccion,
                                    Ubicacion,
                                    LimiteCredito,
                                    Descuento,
                                    CondicionPago,
                                    Estatus,
                                    FechaUltPago,
                                    MontoUltPago,
                                    Balance,
                                    UsuarioAdiciona,
                                    FechaAdiciona,
                                    UsuarioModifica,
                                    FechaModifica,
                                    CodigoRnc,
                                    PorcComision,
                                    CodMoneda,
                                    TelefonoCasa,
                                    TelefonoOficina,
                                    Celular,
                                    Fax,
                                    Beeper,
                                    Email,
                                    TipoPago,
                                    Banco,
                                    CuentaBanco,
                                    Contacto,
                                    TipoCuentaBanco,
                                    ClaseProveedor,
                                    "INSERT");
                                Procesar.ProcesarInformacion();

                                var SacarCodigoProveedor = ObjdataMantenimiento.Value.BuscaProveedores(
                                    new Nullable<int>(),
                                    RNC, NombreCliente);
                                foreach (var n in SacarCodigoProveedor)
                                {
                                    CodigoProveedorSacardo = Convert.ToInt32(n.Codigo);
                                }

                            }
                            else
                            {
                                var SacarCodigoProveedor = ObjdataMantenimiento.Value.BuscaProveedores(
                                   new Nullable<int>(),
                                   RNC, NombreCliente);
                                foreach (var n in SacarCodigoProveedor)
                                {
                                    CodigoProveedorSacardo = Convert.ToInt32(n.Codigo);
                                }
                            }





                            //ELIMINAMOS LOS REGISTROS DE LA TABLA DE MONTOS
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarMontosSolicitudCheques Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarMontosSolicitudCheques(
                                Convert.ToDecimal(Session["IdUsuario"]),
                                Codigo, 0, 0, 0, 0, 0, 0, "DELETE");
                            Eliminar.ProcesarInformacion();

                            //PROCESAMOS LA INFORMACION PARA SACAR LOS DATOS DE LOS MONTOS PARA GUARDAR LA SOLICITUD
                            var SacarLosMontosProcesados = ObjData.Value.GenerarComisionIntermediario(
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                Codigo.ToString(), null);



                            foreach (var nMontos in SacarLosMontosProcesados)
                            {
                                decimal BrutoSacado = 0, NetoSacado = 0, Comisionsacada = 0, Retencionsacada = 0, Avancesacado = 0, ALiquidarSacada = 0;

                                BrutoSacado = Convert.ToDecimal(nMontos.Bruto);
                                NetoSacado = Convert.ToDecimal(nMontos.Neto);
                                Comisionsacada = Convert.ToDecimal(nMontos.Comision);
                                Retencionsacada = Convert.ToDecimal(nMontos.Retencion);
                                Avancesacado = Convert.ToDecimal(nMontos.AvanceComision);
                                ALiquidarSacada = Convert.ToDecimal(nMontos.ALiquidar);



                                //GUARDAMOS LOS REGISTROS
                                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarMontosSolicitudCheques Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarMontosSolicitudCheques(
                                    Convert.ToDecimal(Session["IdUsuario"]),
                                    Codigo,
                                    BrutoSacado,
                                    NetoSacado,
                                    Comisionsacada,
                                    Retencionsacada,
                                    Avancesacado,
                                    ALiquidarSacada,
                                    "INSERT");
                                Procesar.ProcesarInformacion();
                            }

                            //SACAMOS LA SUMA DE LOS MONTOS GUARDADOS ANTERIORMENTE
                            decimal SumaBruto = 0, SumaNeto = 0, SumaComision = 0, SumaRetencion = 0, SumaAvance = 0, SumaALiquidar = 0;

                            var SacarSumaMontos = ObjdataMantenimiento.Value.BuscaMontos(
                                Convert.ToDecimal(Session["IdUsuario"]), Codigo);
                            foreach (var nSumaMontos in SacarSumaMontos)
                            {
                                SumaBruto = Convert.ToDecimal(nSumaMontos.Bruto);
                                SumaNeto = Convert.ToDecimal(nSumaMontos.Neto);
                                SumaComision = Convert.ToDecimal(nSumaMontos.Comision);
                                SumaRetencion = Convert.ToDecimal(nSumaMontos.Retencion);
                                SumaAvance = Convert.ToDecimal(nSumaMontos.Avance);
                                SumaALiquidar = Convert.ToDecimal(nSumaMontos.ALiquidar);
                            }

                            //GUARDAMOS LOS DATOS DE LA SOLICITUD DE CHEQUE
                            string Endosable = "";
                            if (rbChequeEndosable.Checked == true)
                            {
                                Endosable = "Si";
                            }
                            else if (rbChequeNoEndosable.Checked == true)
                            {
                                Endosable = "No";
                            }
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCheques ProcesarSolicitud = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCheques(
                                0,
                                ""
                                ,
                                0,
                                0,
                                0,
                                "",
                                DateTime.Now,
                                0,
                                "",
                                0,
                                "",
                                0,
                                "",
                                TipoRnc,
                                RNC,
                                CodigoProveedorSacardo,
                                "",
                                "",
                                Endosable,
                                Convert.ToInt32(ddlSeleccionarBanco.SelectedValue),
                                CuentaBanco,
                                SumaALiquidar,
                                "",
                                "",
                                0,
                                DateTime.Now,
                                0,
                                DateTime.Now,
                                UsuarioProcesa,
                                UsuarioProcesa,
                                DateTime.Now,
                                DateTime.Now,
                                0,
                                DateTime.Now,
                                UsuarioProcesa,
                                "",
                                "",
                                UsuarioProcesa,
                                0,
                                "N",
                                0,
                                Convert.ToDateTime(txtFechaDesde.Text),
                                Convert.ToDateTime(txtFechaHasta.Text),
                                SumaBruto,
                                SumaComision,
                                SumaRetencion,
                                "INSERT");
                            ProcesarSolicitud.ProcesarInformacion();

                            //SACAMOS EL NUMERO DE SOLICITUD GENERADO
                            int NumeroSolicitudGenerado = UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SacarUltimoNumeroSolicitudGenerada.SacarNumeroSolicitud(CodigoProveedorSacardo);
                            string NumeroSolicitudConvertida = NumeroSolicitudGenerado.ToString();



                            //GUARDAMOS LOS DATOS DE LAS CUENTAS CONTABLES
                            //CUENTA 1203
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta1 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                30, "N", 13, NumeroSolicitudGenerado, 0, "1203", 1, "", "2", SumaALiquidar, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                            Cuenta1.ProcesarInformacion();

                            //CUENTA 2503
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta2 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                30, "N", 13, NumeroSolicitudGenerado, 0, "2503", 0, "", "1", SumaComision, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                            Cuenta2.ProcesarInformacion();

                            //CUENTA 2706
                            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas Cuenta3 = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionSolicitudCuentas(
                                30, "N", 13, NumeroSolicitudGenerado, 0, "2706", 0, "", "2", SumaRetencion, 0, 0, Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), "INSERT");
                            Cuenta3.ProcesarInformacion();

                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Numero de Solicitud Generada " + NumeroSolicitudConvertida + "');", true);
                        }
                        else
                        {
                            FormsAuthentication.SignOut();
                            FormsAuthentication.RedirectToLoginPage();
                        }

                    }

                }

              
            }



        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            SacarNombreIntermediario();
        }

        protected void cbGenerarSolicidutLote_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGenerarSolicidutLote.Checked == true) {
                txtCodigoIntermediario.Text = string.Empty;
                txtCodigoIntermediario.Text = "00000";
                txtNombreIntermediario.Text = "Proceso de Solicitud en lote";
                txtCodigoIntermediario.Enabled = false;
                lbLetreroSolicitudCheque.Visible = true;
                lbMontoMinimoProceso.Visible = true;
                txtMontoMinimoProceso.Visible = true;
                txtMontoMinimoProceso.Text = "500";
            }
            else if (cbGenerarSolicidutLote.Checked == false) {
                txtCodigoIntermediario.Text = string.Empty;
                txtNombreIntermediario.Text = string.Empty;
                txtCodigoIntermediario.Enabled = true;
                lbLetreroSolicitudCheque.Visible = false;
                lbMontoMinimoProceso.Visible = false;
                txtMontoMinimoProceso.Visible = false;
                txtMontoMinimoProceso.Text = string.Empty;
            }
        }
    }
}
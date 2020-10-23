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
        #region GENERAR LA SOLICITUD DE CHEQUE
        private void GenerarSolicitudChequeIntermediario(int TipoCheque, string CodigoIntermediario, int CodigoBanco, DateTime FechaDesde, DateTime FechaHasta, decimal MontoMinimo) {
            try
            {
                //VALIDAMOS QUE EL CODIGO DE INTERMEDIARIO INGRESADO ES VALIDO


                var Validar = ObjdataMantenimiento.Value.BuscaListadoIntermediario(
                    CodigoIntermediario);
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
            catch (Exception) {

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
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
            else {
                //VALIDAMOS QUE EL CODIGO DE INTERMEDIARIO INGRESADO ES VALIDO
                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();

                var Validar = ObjdataMantenimiento.Value.BuscaListadoIntermediario(
                    _CodigoIntermediario);
                if (Validar.Count() < 1) {
                    string Mensaje = "El codigo " + txtCodigoIntermediario.Text + " no existe, favor de verificar e intentar nuevamente";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + Mensaje + "');", true);
                }
                else {

                    if (Session["IdUsuario"] != null) {
                        //SACAMOS EL NOMBRE DEL USUARURIO QUE VA A HACER EL PROCESO
                        string UsuarioProcesa = "";

                        var SacarNombreusuario = ObjData.Value.BuscaUsuarios(Convert.ToDecimal(Session["IdUsuario"]));
                        foreach (var nUsuario in SacarNombreusuario) {
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
                        if (BuscarProveedor.Count() < 1) {
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
                            foreach (var n in SacarCodigoProveedor) {
                                CodigoProveedorSacardo = Convert.ToInt32(n.Codigo);
                            }

                        }
                        else {
                            var SacarCodigoProveedor = ObjdataMantenimiento.Value.BuscaProveedores(
                               new Nullable<int>(),
                               RNC, NombreCliente);
                            foreach (var n in SacarCodigoProveedor)
                            {
                                CodigoProveedorSacardo = Convert.ToInt32(n.Codigo);
                            }
                        }
                    }
                    else {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }

                }
            }
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            SacarNombreIntermediario();
        }
    }
}
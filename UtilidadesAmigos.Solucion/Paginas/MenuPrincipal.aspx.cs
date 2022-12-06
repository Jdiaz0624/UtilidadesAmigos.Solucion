using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Synthesis;
using System.Threading;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas

{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> Objtata = new Lazy<Logica.Logica.LogicaSistema>();
        public UtilidadesAmigos.Logica.Comunes.VariablesGlobales VariablesGlobales = new Logica.Comunes.VariablesGlobales();

        enum OpcionesEstadisticaPolizasSinPagos
        {

            Poliza_Sin_Pago_Inicial = 1,
            Polzias_11_30 = 2,
            Polizas_31_60 = 3,
            Polizas_61_90 = 4,
            Polizas_91_120 = 5,
            Polizas_121_mas = 6
        }
        private int MostrarEstadisticaPolizasSinPolizaCantidad(int Codigoproceso, int Ramo) {

            int Cantidad = 0;

            var SacarInformacion = Objtata.Value.BuscaEstadisticaPolizasSinPagosCantidad(Codigoproceso, Ramo);
            if (SacarInformacion.Count() < 1) {

                Cantidad = 0;
            }
            else {
                foreach (var n in SacarInformacion) {

                    Cantidad = (int)n.Cantidad;
                }
            }
            return Cantidad;

        }

        private void ExportarInformacionEstadisticaPolizasSinPagosRegistros(int CodigoProceso, int Ramo, string Nombre  ) {

            var Exportar = (from n in Objtata.Value.BuscaEstadisticaPolizaSinPagosRegistros(CodigoProceso, Ramo)
                            select new
                            {
                                Poliza = n.Poliza,
                                No_Factura = n.Numero,
                                Codigo_Ramo = n.CodigoRamo,
                                Ramo = n.Ramo,
                                Codigo_SubRamo = n.CodigoSubRamo,
                                SubRamo = n.SubRamo,
                                Codigo_Asegurado = n.CodigoAsegurado,
                                Asegurado = n.Asegurado,
                                Codigo_Vendedor = n.CodigoVendedor,
                                Vendedor = n.Vendedor,
                                Codigo_Supervisor = n.CodigoSupervisor,
                                Supervisor = n.Supervisor,
                                Oficina = n.Oficina,
                                Fecha = n.Fecha,
                                Hora = n.Hora,
                                Dias_Transcurridos = n.DiasTranscurridos,
                                Ncf = n.Ncf,
                                Monto_Bruto = n.MontoBruto,
                                ISC = n.ISC,
                                Monto_Neto = n.MontoNeto,
                                Cobrado = n.Cobrado,
                                Moneda = n.Moneda,
                                Siglas = n.Siglas,
                                Concepto = n.Concepto
                            }).ToList();
            UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel(Nombre, Exportar);

        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                Label lbUsuarioConectado = (Label)Master.FindControl("lbUsuarioConectado");
                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario Nombre = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                lbUsuarioConectado.Text = Nombre.SacarNombreUsuarioConectado();
                lbPantalla.Text = "Menu Principal";

                btnSinPagoInicial.Enabled = false;
                btnPrimerPagoSinCobros.Enabled = false;
                btnSegundoPagoSinCobros.Enabled = false;
                btnTercerPagoSinCobros.Enabled = false;
                btnCuartoPagoSinCobros.Enabled = false;
                btnMasDeCientoVeinteDiasSinCobros.Enabled = false;
            }
          
        }

        protected void LinkSinPagoInicial_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Poliza_Sin_Pago_Inicial, 106,"Polizas SIn Pago Inicial");
        }

        protected void btnSinPagoInicial_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Poliza_Sin_Pago_Inicial, 106,"Polizas Sin Pago Inicial");
        }

        protected void btnPrimerPagoSinCobros_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polzias_11_30,106,"Polizas Sin Pagos de 11 a 30 Dias");
        }

        protected void btnSegundoPagoSinCobros_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polizas_31_60,106, "Polizas Sin Pagos de 31 a 60 Dias");
        }

        protected void btnTercerPagoSinCobros_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polizas_61_90,106, "Polizas Sin Pagos de 61 a 90 Dias");
        }

        protected void btnCuartoPagoSinCobros_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polizas_91_120, 106, "Polizas Sin Pagos de 91 a 120 Dias");
        }

        protected void btnMasDeCientoVeinteDiasSinCobros_Click(object sender, EventArgs e)
        {
            ExportarInformacionEstadisticaPolizasSinPagosRegistros((int)OpcionesEstadisticaPolizasSinPagos.Polizas_121_mas, 106, "Polizas Sin Pagos mas de 120 Dias");
        }

        protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            if (cbSinInicial.Checked == false &&
                cbPrimerPago.Checked == false &&
                cbSegundoPago.Checked == false &&
                cbTercerpago.Checked == false &&
                cbCuartoPago.Checked == false &&
                cbQuintoPago.Checked == false)
            {
                ClientScript.RegisterStartupScript(GetType(), "Mensaje()", "Mensaje();", true);
            }
            else {

                if (cbSinInicial.Checked == true)
                {
                    btnSinPagoInicial.Enabled = true;
                    btnSinPagoInicial.Text = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.Poliza_Sin_Pago_Inicial, 106).ToString("N0");
                }
                else
                {
                    btnSinPagoInicial.Text = "0";
                    btnSinPagoInicial.Enabled = false;
                }


                if (cbPrimerPago.Checked == true)
                {
                    btnPrimerPagoSinCobros.Enabled = true;
                    btnPrimerPagoSinCobros.Text = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.Polzias_11_30, 106).ToString("N0");
                }
                else
                {
                    btnPrimerPagoSinCobros.Text = "0";
                    btnPrimerPagoSinCobros.Enabled = false;
                }


                if (cbSegundoPago.Checked == true)
                {
                    btnSegundoPagoSinCobros.Enabled = true;
                    btnSegundoPagoSinCobros.Text = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.Polizas_31_60, 106).ToString("N0");
                }
                else
                {
                    btnSegundoPagoSinCobros.Text = "0";
                    btnSegundoPagoSinCobros.Enabled = false;
                }



                if (cbTercerpago.Checked == true)
                {
                    btnTercerPagoSinCobros.Enabled = true;
                    btnTercerPagoSinCobros.Text = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.Polizas_61_90, 106).ToString("N0");
                }
                else
                {
                    btnTercerPagoSinCobros.Text = "0";
                    btnTercerPagoSinCobros.Enabled = false;
                }



                if (cbCuartoPago.Checked == true)
                {
                    btnCuartoPagoSinCobros.Enabled = true;
                    btnCuartoPagoSinCobros.Text = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.Polizas_91_120, 106).ToString("N0");
                }
                else
                {
                    btnCuartoPagoSinCobros.Text = "0";
                    btnCuartoPagoSinCobros.Enabled = false;
                }



                if (cbQuintoPago.Checked == true)
                {
                    btnMasDeCientoVeinteDiasSinCobros.Enabled = true;
                    btnMasDeCientoVeinteDiasSinCobros.Text = MostrarEstadisticaPolizasSinPolizaCantidad((int)OpcionesEstadisticaPolizasSinPagos.Polizas_121_mas, 106).ToString("N0");
                }
                else
                {
                    btnMasDeCientoVeinteDiasSinCobros.Text = "0";
                    btnMasDeCientoVeinteDiasSinCobros.Enabled = false;
                }


                
                
                
                
                
               
            }

        }

        protected void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodos.Checked == true) {

                cbSinInicial.Checked = true;
                cbPrimerPago.Checked = true;
                cbSegundoPago.Checked = true;
                cbTercerpago.Checked = true;
                cbCuartoPago.Checked = true;
                cbQuintoPago.Checked = true;
            }
            else if (cbTodos.Checked == false) {
                cbSinInicial.Checked = false;
                cbPrimerPago.Checked = false;
                cbSegundoPago.Checked = false;
                cbTercerpago.Checked = false;
                cbCuartoPago.Checked = false;
                cbQuintoPago.Checked = false;
            }
        }

        protected void cbSinInicial_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSinInicial.Checked == true) {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else {
                cbTodos.Checked = false;
            }
        }

        protected void cbPrimerPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrimerPago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void cbSegundoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSegundoPago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void cbTercerpago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTercerpago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void cbCuartoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCuartoPago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void cbQuintoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbQuintoPago.Checked == true)
            {

                if (cbSinInicial.Checked == true &&
                    cbPrimerPago.Checked == true &&
                    cbSegundoPago.Checked == true &&
                    cbTercerpago.Checked == true &&
                    cbCuartoPago.Checked == true &&
                    cbQuintoPago.Checked == true)
                {
                    cbTodos.Checked = true;
                }
            }
            else
            {
                cbTodos.Checked = false;
            }
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
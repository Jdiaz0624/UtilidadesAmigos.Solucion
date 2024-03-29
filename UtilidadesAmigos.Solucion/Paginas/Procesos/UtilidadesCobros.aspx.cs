﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace UtilidadesAmigos.Solucion.Paginas.Procesos
{
    public partial class UtilidadesCobros : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos> ObjData = new Lazy<Logica.Logica.LogicaProcesos.LogicaProcesos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
  
        private void CorregirPolizaSinCobro(string Poliza) {


            //VALIDAMOS SI LA POLIZA INGRESADA ES VALIDA
            string _Poliza = string.IsNullOrEmpty(txtPolizaSinPagos.Text.Trim()) ? null : txtPolizaSinPagos.Text.Trim();

            UtilidadesAmigos.Logica.Comunes.Validaciones.ValidarPoliza Validar = new Logica.Comunes.Validaciones.ValidarPoliza(_Poliza);
            bool ResultadoValidacion = Validar.ValidacionPoliza();
            if (ResultadoValidacion == true) {
                try
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "EXEC [utililades].[SP_CORRERIR_POLIZA_NO_SALEN_PAGOS] @Poliza";
                    comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();

                    comando.Parameters.Add("@Poliza", SqlDbType.VarChar);
                    comando.Parameters["@Poliza"].Value = Poliza;

                    UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();
                    comando.ExecuteNonQuery();
                    UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion().Close();

                    ClientScript.RegisterStartupScript(GetType(), "ProcesoCompletado()", "ProcesoCompletado();", true);
                }
                catch (Exception) {
                    ClientScript.RegisterStartupScript(GetType(), "ErrorAlRealizarProceso()", "ErrorAlRealizarProceso();", true);
                }
            }
            else {
                ClientScript.RegisterStartupScript(GetType(), "PolizaNoExiste()", "PolizaNoExiste();", true);
            }
          

           

        }

        private void BuscarReciboFormaPago() {

            decimal? _NumeroRecibo = string.IsNullOrEmpty(txtNumeroRecibo.Text.Trim()) ? new Nullable<decimal>() : Convert.ToDecimal(txtNumeroRecibo.Text);

            var Buscar = ObjData.Value.BuscaPolizaFormaPago(_NumeroRecibo);
            if (Buscar.Count() < 1) {
                rpListadoFormaPago.DataSource = null;
                rpListadoFormaPago.DataBind();
            }
            else {
                rpListadoFormaPago.DataSource = Buscar;
                rpListadoFormaPago.DataBind();
            }
        }

        private void ModificarInformacion() {

            string TipoPago = "";
            if (rbEfectivo.Checked == true) { TipoPago = "EFECTIVO"; }
            else if (rbTarjeta.Checked == true) { TipoPago = "TARJETA"; }
            else if (rbTransferencia.Checked == true) { TipoPago = "TRANSFERENCIA"; }
            else if (rbCheque.Checked == true) { TipoPago = "CHEQUE"; }
            else if (rbOtros.Checked == true) { TipoPago = "OTROS PAGOS"; }


            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionFormaPago Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos.ProcesarInformacionFormaPago(
                Convert.ToDecimal(hfNumeroReciboSeleccionado.Value),
                TipoPago,
                "UPDATE");
            Procesar.ProcesarInformacion();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                hfNumeroReciboSeleccionado.Value = "0";

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "UTILIDADES DE COBROS";

                DIVBloquePrincial.Visible = true;
                DIVBloqueSegundario.Visible = false;

            }
        }

        protected void btnProcesarPolizasSinPagosFinal_Click(object sender, ImageClickEventArgs e)
        {
            string _Poliza = string.IsNullOrEmpty(txtPolizaSinPagos.Text.Trim()) ? null : txtPolizaSinPagos.Text.Trim();
            CorregirPolizaSinCobro(_Poliza);
        }

        protected void btnSeleccionarRegistro_Click(object sender, ImageClickEventArgs e)
        {
            DivBloqueModificar.Visible = true;
            var RegistroSeleccionado = (RepeaterItem)((ImageButton)sender).NamingContainer;
            var hfRegistroSeleccionado = ((HiddenField)RegistroSeleccionado.FindControl("hfNumeroRecibo")).Value.ToString();
            hfNumeroReciboSeleccionado.Value = hfRegistroSeleccionado;

            string TipoPago = "";
            var SacarTipoPago = ObjData.Value.BuscaPolizaFormaPago(Convert.ToDecimal(hfRegistroSeleccionado));
            foreach (var n in SacarTipoPago)
            {
                TipoPago = n.Tipo;
            }
            switch (TipoPago)
            {

                case "EFECTIVO":
                    rbEfectivo.Checked = true;
                    break;

                case "TARJETA":
                    rbTarjeta.Checked = true;
                    break;

                case "TRANSFERENCIA":
                    rbTransferencia.Checked = true;
                    break;

                case "CHEQUE":
                    rbCheque.Checked = true;
                    break;

                case "OTROS":
                    rbOtros.Checked = true;
                    break;

                case "OTROS PAGOS":
                    rbOtros.Checked = true;
                    break;
            }

            DIVBloquePrincial.Visible = false;
            DIVBloqueSegundario.Visible = true;
        }

        protected void btnBuscarPolizaFormaPagoFinal_Click(object sender, ImageClickEventArgs e)
        {
            BuscarReciboFormaPago();
        }

        protected void btnGuardarFinal_Click(object sender, ImageClickEventArgs e)
        {
            ModificarInformacion();
            txtNumeroRecibo.Text = hfNumeroReciboSeleccionado.Value;
            BuscarReciboFormaPago();


            DIVBloquePrincial.Visible = true;
            DIVBloqueSegundario.Visible = false;
        }

        protected void btnVolverFinal_Click(object sender, ImageClickEventArgs e)
        {
            hfNumeroReciboSeleccionado.Value = "0";
            DivBloqueModificar.Visible = false;
            txtNumeroRecibo.Text = string.Empty;

            DIVBloquePrincial.Visible = true;
            DIVBloqueSegundario.Visible = false;
        }
    }
}
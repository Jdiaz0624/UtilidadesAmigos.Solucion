using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas.Transito
{
    public partial class EndosoTransito : System.Web.UI.Page
    {

        Lazy<UtilidadesAmigos.Logica.Logica.LogicaTransito.LogicaTransito> ObjData = new Lazy<Logica.Logica.LogicaTransito.LogicaTransito>();
        #region REGION GENERAR ENDOSO
        private void GenerarEndoso() {

            string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
            int? _NumeroItem = string.IsNullOrEmpty(txtNumeroItem.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(txtNumeroItem.Text);
            string _Endosado = txtEndosadoA.Text;
            decimal _ValorCedido = Convert.ToDecimal(txtValorcedido.Text);
            decimal _MontoDeducible = Convert.ToDecimal(txtMontoDeducible.Text);
            string RutaReporte = "", NombreReporte = "", UsuarioBD = "", ClaveBD = "";


            RutaReporte = Server.MapPath("EndosoPolizasTransito.rpt");
            NombreReporte = "Endoso a favor de " + _Endosado;

            UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
            UsuarioBD = Credenciales.SacarUsuario();
            ClaveBD = Credenciales.SacarClaveBD();



            ReportDocument Endoso = new ReportDocument();

            Endoso.Load(RutaReporte);
            Endoso.Refresh();

            Endoso.SetParameterValue("@Poliza", _Poliza);
            Endoso.SetParameterValue("@Item", _NumeroItem);
            Endoso.SetParameterValue("@GeneradoPor", 1);
            Endoso.SetParameterValue("@EndosadoA", _Endosado);
            Endoso.SetParameterValue("@ValorCredito", _ValorCedido);
            Endoso.SetParameterValue("@MontoDeducible", _MontoDeducible);

            Endoso.SetDatabaseLogon(UsuarioBD, ClaveBD);

            if (rpPDF.Checked == true) {
                Endoso.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);
            }
            else if (rbDocx.Checked == true) {
                Endoso.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreReporte);
            }

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "GENERAR ENDOSOS DE POLIZAS EN TRANSITO";
                rpPDF.Checked = true;
                txtNumeroItem.Text = "1";
            }
        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {

            var ValidarPoliza = ObjData.Value.MostrarEndosoTransito(
                txtPoliza.Text,
                Convert.ToInt32(txtNumeroItem.Text),
                null, null, null, null);
            if (ValidarPoliza.Count() < 1) {

                ClientScript.RegisterStartupScript(GetType(), "PolizaNoEncontrada()", "PolizaNoEncontrada();", true);
            }
            else
            {
               GenerarEndoso();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace UtilidadesAmigos.Solucion.Paginas.Hojas
{
    public partial class CerrtificadoMaritimo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaHoja.LogicaHoja> Objdata = new Lazy<Logica.Logica.LogicaHoja.LogicaHoja>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack) {

                UtilidadesAmigos.Logica.Comunes.SacarNombreUsuario NombreUsuario = new Logica.Comunes.SacarNombreUsuario((decimal)Session["IdUsuario"]);
                Label lbNombreUsuario = (Label)Master.FindControl("lbUsuarioConectado");
                lbNombreUsuario.Text = NombreUsuario.SacarNombreUsuarioConectado();

                Label lbPantalla = (Label)Master.FindControl("lbOficinaUsuairoPantalla");
                lbPantalla.Text = "HOJA DE CERTIFICADO MARITIMO";
            }

        }

        protected void btnReporte_Click(object sender, ImageClickEventArgs e)
        {
            //VALIDAMOS LA POLIZA SI EXISTE
            var ValidarInformacion = Objdata.Value.BuscaPolizacertificadoMaritimo(txtPoliza.Text);
            if (ValidarInformacion.Count() < 1) {

                ClientScript.RegisterStartupScript(GetType(), "PolizaNoEncontrada()", "PolizaNoEncontrada();", true);
            }
            else {

                //GENERAMO EL REPORTE
                string _poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                string UsuarioBD = "", ClaveBD = "", Rutareporte = "", NombreReporte = "";

                UtilidadesAmigos.Logica.Comunes.SacarCredencialesBD Credenciales = new Logica.Comunes.SacarCredencialesBD(1);
                UsuarioBD = Credenciales.SacarUsuario();
                UsuarioBD = Credenciales.SacarClaveBD();
                Rutareporte = Server.MapPath("HojaCertificadoSegurosMaritimo.rpt");
                NombreReporte = "Certificado de " + _poliza;

                ReportDocument Certificado = new ReportDocument();

                Certificado.Load(Rutareporte);
                Certificado.Refresh();

                Certificado.SetParameterValue("@Poliza", _poliza);

                Certificado.SetDatabaseLogon(UsuarioBD, ClaveBD);

                Certificado.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreReporte);

                Certificado.Close();
                Certificado.Dispose();
            }
        }
    }
}
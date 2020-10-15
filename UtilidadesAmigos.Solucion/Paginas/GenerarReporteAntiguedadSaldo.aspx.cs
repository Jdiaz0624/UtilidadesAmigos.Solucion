using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class GenerarReporteAntiguedadSaldo : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjdataGeneral = new Lazy<Logica.Logica.LogicaSistema>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObDataMantenimiento = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();

        private void ProcesarInformacion() {
          //  try {
                //BUSCAMOS LA INFORMACION MEDIANTE LOS FILTROS INGRESADOS
                string _NumeroFactura = string.IsNullOrEmpty(txtNumeroFacturaConsulta.Text.Trim()) ? null : txtNumeroFacturaConsulta.Text.Trim();
                string _Poliza = string.IsNullOrEmpty(txtPolizaConsulta.Text.Trim()) ? null : txtPolizaConsulta.Text.Trim();
                int? _Ramo = ddlSeleccionarRamoConsulta.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamoConsulta.SelectedValue) : new Nullable<int>();
                int? Tipo = 0;
                if (rbTodosMovimientos.Checked == true)
                {
                    Tipo = null;
                }
                else if (rbFacturas.Checked == true)
                {
                    Tipo = 10;
                }
                else if (rbCreditos.Checked == true)
                {
                    Tipo = 8;
                }
                else if (rbPrimaDepositos.Checked == true)
                {
                    Tipo = 22;
                }
                else {
                    Tipo = 0;
                }

                var BuscarRegistros = ObDataMantenimiento.Value.BuscarDatosAntiguedadSaldo(
                    Convert.ToDateTime(txtFechaCorteConsulta.Text),
                    _NumeroFactura, _Poliza, _Ramo, Tipo);
                foreach (var n in BuscarRegistros) {
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Procesar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                        (decimal)Session["Idusuario"],
                        Convert.ToDateTime(txtFechaCorteConsulta.Text),
                        n.Documento,
                        Convert.ToDecimal(n.NumeroFacturaFiltro),
                        Convert.ToInt32(n.Tipo),
                        n.DescripcionTipo,
                        n.Asegurado,
                        Convert.ToDecimal(n.ClienteFiltro),
                        n.Fecha,
                        n.Intermediario,
                        Convert.ToInt32(n.VendedorFiltro),
                        n.Poliza,
                        Convert.ToInt32(n.CodMoneda),
                        n.DescripcionMoneda,
                        n.Estatus,
                        Convert.ToInt32(n.CodRamo),
                        n.InicioVigencia,
                        Convert.ToDateTime(n.Inicio),
                        n.FinVigencia,
                        Convert.ToDateTime(n.Fin),
                        Convert.ToInt32(n.CodOficina),
                        n.Oficina,
                        Convert.ToInt32(n.Dias),
                        Convert.ToDecimal(n.Facturado),
                        Convert.ToDecimal(n.Cobrado),
                        Convert.ToDecimal(n.Balance),
                        Convert.ToDecimal(n.Impuesto),
                        Convert.ToDecimal(n.PorcComision),
                        Convert.ToDecimal(n.ValorComision),
                        Convert.ToDecimal(n.ComisionPendiente),
                        Convert.ToDecimal(n.__0_10),
                        Convert.ToDecimal(n.__0_30),
                        Convert.ToDecimal(n.__31_60),
                        Convert.ToDecimal(n.__61_90),
                        Convert.ToDecimal(n.__91_120),
                        Convert.ToDecimal(n.__121_150),
                        Convert.ToDecimal(n.__151_MAS),
                        Convert.ToDecimal(n.Total),
                        Convert.ToDecimal(n.Diferencia),
                        Convert.ToInt32(n.OrdenTipo),
                        "INSERT");
                    Procesar.ProcesarInformacion();

                }
            //}
            //catch (Exception) {
            //    ClientScript.RegisterStartupScript(GetType(), "ErrorProceso()", "ErrorProceso();", true);
            //}
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rbReporteResumido.Checked = true;
               // rbPorRamo.Checked = true;
                rbTodosMovimientos.Checked = true;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamoConsulta, ObjdataGeneral.Value.BuscaListas("RAMO", null, null), true);

                //SACAMOS LA TASA DE LA MONEDA
                txtTasaDollar.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
            }
        }

        protected void btnExportarRegistros_Click(object sender, EventArgs e)
        {
            //VALIDAMOS SI EL CAMPO FECHA DE CORTE ESTA VACIO
            if (string.IsNullOrEmpty(txtFechaCorteConsulta.Text.Trim()) || string.IsNullOrEmpty(txtTasaDollar.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios()", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaCorteConsulta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Campofechacortevacio()", "Campofechacortevacio();", true);
                }
                if (string.IsNullOrEmpty(txtTasaDollar.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoTasaVacio()", "CampoTasaVacio();", true);
                }
            }
            else {
                if (Session["Idusuario"] != null) {
                 
                    //ELIMINAMOS LOS CAMPOS 
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                       (decimal)Session["Idusuario"], DateTime.Now, "", 0, 0, "", "", 0, "", "", 0, "", 0, "", "", 0, "", DateTime.Now, "", DateTime.Now, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "DELETE");
                    Eliminar.ProcesarInformacion();
                    ProcesarInformacion();
                }
                else {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            //VALIDAMOS SI EL CAMPO FECHA DE CORTE ESTA VACIO
            if (string.IsNullOrEmpty(txtFechaCorteConsulta.Text.Trim()) || string.IsNullOrEmpty(txtTasaDollar.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios()", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaCorteConsulta.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "Campofechacortevacio()", "Campofechacortevacio();", true);
                }
                if (string.IsNullOrEmpty(txtTasaDollar.Text.Trim())) {
                    ClientScript.RegisterStartupScript(GetType(), "CampoTasaVacio()", "CampoTasaVacio();", true);
                }
            }
            else
            {
               
                if (Session["Idusuario"] != null) {
                    //ELIMINAMOS LOS CAMPOS 
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionReporteAntiguedadSaldo(
                       (decimal)Session["Idusuario"], DateTime.Now, "", 0, 0, "", "", 0, "", "", 0, "", 0, "", "", 0, "", DateTime.Now, "", DateTime.Now, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "DELETE");
                    Eliminar.ProcesarInformacion();
                    ProcesarInformacion();
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
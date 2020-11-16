
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ReporteProduccionIntermediarioSupervisor : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjData = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();

        protected void Page_Load(object sender, EventArgs e)
        {
            rbNoAgrupar.Checked = true;
            rbTodas.Checked = true;
            rbDetalle.Checked = true;
            txtTasa.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            txtNombreSupervisor.Text = "Supervisor";
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            txtNombreIntermediario.Text = "Intermediario";
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim())){
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVAcio", "CampoFechaDesdeVAcio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim())){
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHAstaVAcio", "CampoFechaHAstaVAcio();", true);
                }
            }
            else {
                //REALIZAMOS LA COSULTA
                var MostrarConsultaGeneral = ObjData.Value.BuscaReporteProduccionOrigen(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToDecimal(txtTasa.Text));
                gvListdoProduccion.DataSource = MostrarConsultaGeneral;
                gvListdoProduccion.DataBind();

                int CantiadRegistros = 0;
                decimal Totalfacturado = 0, FacturadoPesos = 0, FacturadoDollar = 0, TotalFacturadoGeneral = 0;
                string Entidad = "";
                decimal ValorDecimal = 0;
                int ValorEntero = 0;

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionGrafico Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionGrafico(
                    (decimal)(Session["IdUsuario"]), "", 0, 0, "DELETE");
                Eliminar.ProcesarInformacion();

                foreach (var n in MostrarConsultaGeneral) {
                    CantiadRegistros = (int)n.CantidadRegistros;
                    Totalfacturado = (decimal)n.TotalFacturado;
                    FacturadoPesos = (decimal)n.TotalFActuradoPesos;
                    FacturadoDollar = (decimal)n.TotalFActuradoDollar;
                    TotalFacturadoGeneral = (decimal)n.TotalFacturadoGeneral;
                    Entidad = n.Intermediario;
                    ValorDecimal = (decimal)n.MontoPesos;

                    if (cbGraficar.Checked == true)
                    {
                        //PROCESAMOS LA INFORMACION
                        UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionGrafico Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionGrafico(
                           (decimal)(Session["IdUsuario"]),
                           Entidad,
                           ValorDecimal,
                           ValorEntero,
                           "INSERT");
                        Guardar.ProcesarInformacion();
                     
                    }


                }
                lbcantidadRegistrosVariable.Text = CantiadRegistros.ToString("N0");
                lbTotalFacturadoVariable.Text = Totalfacturado.ToString("N2");
                lbFacturadoPesosVariable.Text = FacturadoPesos.ToString("N2");
                LbFacturadoDollarVariable.Text = FacturadoDollar.ToString("N2");
                lbFacturadoTotalVariable.Text = TotalFacturadoGeneral.ToString("N2");

                if (cbGraficar.Checked == true) {
                    int[] Monto = new int[0];
                    string[] Nombre = new string[10];
                    int Contador = 0;

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = UtilidadesAmigos.Data.Conexiones.ADO.BDConexion.ObtenerConexion();
                    comando.CommandText = "SELECT TOP(10) Entidad,SUM(ValorDecimal) AS ValorDecimal FROM Utililades.DatosGraficos WHERE" + (decimal)Session["Idusuario"] + "AND Entidad NOT IN ('1 - COMISIONISTA DIRECTO') GROUP BY Entidad ORDER BY ValorDecimal DESC";

                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read()) {
                        Monto[Contador] = Convert.ToInt32(reader.GetSqlString(0));
                        Nombre[Contador] = reader.GetSqlString(1).ToString();
                        Contador++;
                    }
                  // GraIntermediarios.Series["Serie"].Points.DataBindxy(Nombre, Monto);

                }

               
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVAcio", "CampoFechaDesdeVAcio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHAstaVAcio", "CampoFechaHAstaVAcio();", true);
                }
            }
            else { }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "CamposVacios", "CamposVacios();", true);
                if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaDesdeVAcio", "CampoFechaDesdeVAcio();", true);
                }
                if (string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
                {
                    ClientScript.RegisterStartupScript(GetType(), "CampoFechaHAstaVAcio", "CampoFechaHAstaVAcio();", true);
                }
            }
            else { }
        }

        protected void gvListdoProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvListdoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
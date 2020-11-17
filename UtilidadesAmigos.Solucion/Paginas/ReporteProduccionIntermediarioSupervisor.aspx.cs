﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ReporteProduccionIntermediarioSupervisor : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjData = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();


        #region METODOS DE GRAFICOS
        private void GraficoIntermediarios() {
            decimal[] Monto = new decimal[10];
            string[] Nombre = new string[10];
            int Contador = 0;
            SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand comando = new SqlCommand("SELECT TOP(10) SUM(ValorDecimal),Entidad FROM Utililades.DatosGraficos WHERE IdUsuario=" + (decimal)Session["IdUsuario"] + " AND Entidad not in ('COMISIONISTA DIRECTO') GROUP BY Entidad ORDER BY SUM(ValorDecimal) DESC ", conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Monto[Contador] = Convert.ToDecimal(reader.GetDecimal(0));
                Nombre[Contador] = reader.GetString(1);
                Contador++;
            }
            reader.Close();
            conexion.Close();
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}K";
            GraIntermediarios.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraIntermediarios.Series["Serie"].Points.DataBindXY(Nombre, Monto);
            EliminarDatosGraficos();
        }
        private void GraficoSupervisores() {
            decimal[] Monto = new decimal[10];
            string[] Nombre = new string[10];
            int Contador = 0;
            SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand comando = new SqlCommand("SELECT TOP(10) SUM(ValorDecimal),Entidad FROM Utililades.DatosGraficos WHERE IdUsuario=" + (decimal)Session["IdUsuario"] + " AND Entidad not in ('COORDINADOR DIRECTO','COORDINADOR DIRECTO SANTIAGO','VENDEDOR DIRECTO SANTIAGO','COORDINADOR DIRECTO','COORDINADOR DIRECTO ZONA ORIENTAL') GROUP BY Entidad ORDER BY SUM(ValorDecimal) DESC ", conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Monto[Contador] = Convert.ToDecimal(reader.GetDecimal(0));
                Nombre[Contador] = reader.GetString(1);
                Contador++;
            }
            reader.Close();
            conexion.Close();
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}K";
            GraSupervisores.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraSupervisores.Series["Serie"].Points.DataBindXY(Nombre, Monto);
            EliminarDatosGraficos();
        }
        private void GraficoOficinas() {
            decimal[] Monto = new decimal[10];
            string[] Nombre = new string[10];
            int Contador = 0;
            SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand comando = new SqlCommand("SELECT TOP(10) SUM(ValorDecimal),Entidad FROM Utililades.DatosGraficos WHERE IdUsuario=" + (decimal)Session["IdUsuario"] + "  GROUP BY Entidad ORDER BY SUM(ValorDecimal) DESC ", conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Monto[Contador] = Convert.ToDecimal(reader.GetDecimal(0));
                Nombre[Contador] = reader.GetString(1);
                Contador++;
            }
            reader.Close();
            conexion.Close();
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}K";
            GraOficina.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraOficina.Series["Serie"].Points.DataBindXY(Nombre, Monto);
            EliminarDatosGraficos();


        }
        private void GraficosUsuarios() { }
        private void GraficosConceptos() { }
        private void EliminarDatosGraficos() {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionGrafico Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionGrafico(
                    (decimal)(Session["IdUsuario"]), "", 0, 0, "DELETE");
            Eliminar.ProcesarInformacion();
        }
        #endregion


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

                
                EliminarDatosGraficos();

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
                    GraficoIntermediarios();
                    foreach (var nSupervisor in MostrarConsultaGeneral) {
                        Entidad = nSupervisor.Supervisor;
                        ValorDecimal = (decimal)nSupervisor.MontoPesos;

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
                    GraficoSupervisores();
                    foreach (var nOficina in MostrarConsultaGeneral) {
                        Entidad = nOficina.Oficina;
                        ValorDecimal = (decimal)nOficina.MontoPesos;

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
                    GraficoOficinas();
                    GraficosUsuarios();
                    GraficosConceptos();

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
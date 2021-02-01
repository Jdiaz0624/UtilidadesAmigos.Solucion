
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class ReporteProduccionIntermediarioSupervisor : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido> ObjData = new Lazy<Logica.Logica.LogicaReportes.ProduccionPorUsuarioResumido>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObjDataMantenimiento = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();


        #region METODOS DE GRAFICOS
        
        private void GraficoSupervisores() {
            decimal[] MontoFacturado = new decimal[10];
            string[] NombreSupervisor = new string[10];
            int Contador = 0;

            decimal IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);

            string Estatus = "";
            if (rbTodas.Checked == true)
            {
                Estatus = "NADA";
            }
            else if (rbActivas.Checked == true)
            {
                Estatus = "ACTIVO";
            }
            else if (rbCanceladas.Checked == true)
            {
                Estatus = "CANCELADA";
            }

            string _Supervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
            {
                _Supervisor = "0";
            }
            else
            {
                _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            }


            string _Intermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
            {
                _Intermediario = "0";
            }
            else
            {
                _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            }



            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

            if (_Oficina == null)
            {
                _Oficina = 0;
            }

            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }



            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Query = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICOS_PRODUCCION] @IdUsuario,@Estatus,@FechaDesde,@FechaHasta,@CodigoSupervisor,@CodigoIntermediario,@Oficina,@Ramo,@TipoGrafico", Conexion);
            Query.Parameters.AddWithValue("@IdUsuario", SqlDbType.Decimal);
            Query.Parameters.AddWithValue("@Estatus", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Query.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Query.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@Oficina", SqlDbType.Int);
            Query.Parameters.AddWithValue("@Ramo", SqlDbType.Int);
            Query.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);


            Query.Parameters["@IdUsuario"].Value = (decimal)Session["IdUsuario"];
            Query.Parameters["@Estatus"].Value = Estatus;
            Query.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);
            Query.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHasta.Text);
            Query.Parameters["@CodigoSupervisor"].Value = _Supervisor;
            Query.Parameters["@CodigoIntermediario"].Value = _Intermediario;
            Query.Parameters["@Oficina"].Value = _Oficina;
            Query.Parameters["@Ramo"].Value = _Ramo;
            Query.Parameters["@TipoGrafico"].Value = 1;

            Conexion.Open();

            SqlDataReader Reader = Query.ExecuteReader();
            while (Reader.Read())
            {
                MontoFacturado[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreSupervisor[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();
            GraSupervisores.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraSupervisores.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraSupervisores.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraSupervisores.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            GraSupervisores.Series["Serie"].Points.DataBindXY(NombreSupervisor, MontoFacturado);

        }
        private void GraficoIntermediarios()
        {

            decimal[] MontoFacturado = new decimal[10];
            string[] NombreIntermediario = new string[10];
            int Contador = 0;

            decimal IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);

            string Estatus = "";
            if (rbTodas.Checked == true)
            {
                Estatus = "NADA";
            }
            else if (rbActivas.Checked == true)
            {
                Estatus = "ACTIVO";
            }
            else if (rbCanceladas.Checked == true)
            {
                Estatus = "CANCELADA";
            }

            string _Supervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
            {
                _Supervisor = "0";
            }
            else
            {
                _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            }


            string _Intermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
            {
                _Intermediario = "0";
            }
            else
            {
                _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            }



            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

            if (_Oficina == null)
            {
                _Oficina = 0;
            }

            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }



            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Query = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICOS_PRODUCCION] @IdUsuario,@Estatus,@FechaDesde,@FechaHasta,@CodigoSupervisor,@CodigoIntermediario,@Oficina,@Ramo,@TipoGrafico", Conexion);
            Query.Parameters.AddWithValue("@IdUsuario", SqlDbType.Decimal);
            Query.Parameters.AddWithValue("@Estatus", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Query.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Query.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@Oficina", SqlDbType.Int);
            Query.Parameters.AddWithValue("@Ramo", SqlDbType.Int);
            Query.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);


            Query.Parameters["@IdUsuario"].Value = (decimal)Session["IdUsuario"];
            Query.Parameters["@Estatus"].Value = Estatus;
            Query.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);
            Query.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHasta.Text);
            Query.Parameters["@CodigoSupervisor"].Value = _Supervisor;
            Query.Parameters["@CodigoIntermediario"].Value = _Intermediario;
            Query.Parameters["@Oficina"].Value = _Oficina;
            Query.Parameters["@Ramo"].Value = _Ramo;
            Query.Parameters["@TipoGrafico"].Value = 2;

            Conexion.Open();

            SqlDataReader Reader = Query.ExecuteReader();
            while (Reader.Read())
            {
                MontoFacturado[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreIntermediario[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();
            GraIntermediarios.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraIntermediarios.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraIntermediarios.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraIntermediarios.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraIntermediarios.Series["Serie"].Points.DataBindXY(NombreIntermediario, MontoFacturado);

        }
        private void GraficoOficinas() {

            decimal[] MontoFacturado = new decimal[10];
            string[] Nombreoficina = new string[10];
            int Contador = 0;

            decimal IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);

            string Estatus = "";
            if (rbTodas.Checked == true)
            {
                Estatus = "NADA";
            }
            else if (rbActivas.Checked == true)
            {
                Estatus = "ACTIVO";
            }
            else if (rbCanceladas.Checked == true)
            {
                Estatus = "CANCELADA";
            }

            string _Supervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
            {
                _Supervisor = "0";
            }
            else
            {
                _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            }


            string _Intermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
            {
                _Intermediario = "0";
            }
            else
            {
                _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            }



            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

            if (_Oficina == null)
            {
                _Oficina = 0;
            }

            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }



            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Query = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICOS_PRODUCCION] @IdUsuario,@Estatus,@FechaDesde,@FechaHasta,@CodigoSupervisor,@CodigoIntermediario,@Oficina,@Ramo,@TipoGrafico", Conexion);
            Query.Parameters.AddWithValue("@IdUsuario", SqlDbType.Decimal);
            Query.Parameters.AddWithValue("@Estatus", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Query.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Query.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@Oficina", SqlDbType.Int);
            Query.Parameters.AddWithValue("@Ramo", SqlDbType.Int);
            Query.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);


            Query.Parameters["@IdUsuario"].Value = (decimal)Session["IdUsuario"];
            Query.Parameters["@Estatus"].Value = Estatus;
            Query.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);
            Query.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHasta.Text);
            Query.Parameters["@CodigoSupervisor"].Value = _Supervisor;
            Query.Parameters["@CodigoIntermediario"].Value = _Intermediario;
            Query.Parameters["@Oficina"].Value = _Oficina;
            Query.Parameters["@Ramo"].Value = _Ramo;
            Query.Parameters["@TipoGrafico"].Value = 3;

            Conexion.Open();

            SqlDataReader Reader = Query.ExecuteReader();
            while (Reader.Read())
            {
                MontoFacturado[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                Nombreoficina[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();
            GraOficina.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraOficina.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraOficina.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraOficina.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraOficina.Series["Serie"].Points.DataBindXY(Nombreoficina, MontoFacturado);

        }
        private void GraficosRamos() {
            decimal[] MontoFacturado = new decimal[10];
            string[] NombreRamo = new string[10];
            int Contador = 0;

            decimal IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);

            string Estatus = "";
            if (rbTodas.Checked == true)
            {
                Estatus = "NADA";
            }
            else if (rbActivas.Checked == true)
            {
                Estatus = "ACTIVO";
            }
            else if (rbCanceladas.Checked == true)
            {
                Estatus = "CANCELADA";
            }

            string _Supervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
            {
                _Supervisor = "0";
            }
            else
            {
                _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            }


            string _Intermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
            {
                _Intermediario = "0";
            }
            else
            {
                _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            }



            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

            if (_Oficina == null)
            {
                _Oficina = 0;
            }

            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }



            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Query = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICOS_PRODUCCION] @IdUsuario,@Estatus,@FechaDesde,@FechaHasta,@CodigoSupervisor,@CodigoIntermediario,@Oficina,@Ramo,@TipoGrafico", Conexion);
            Query.Parameters.AddWithValue("@IdUsuario", SqlDbType.Decimal);
            Query.Parameters.AddWithValue("@Estatus", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Query.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Query.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@Oficina", SqlDbType.Int);
            Query.Parameters.AddWithValue("@Ramo", SqlDbType.Int);
            Query.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);


            Query.Parameters["@IdUsuario"].Value = (decimal)Session["IdUsuario"];
            Query.Parameters["@Estatus"].Value = Estatus;
            Query.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);
            Query.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHasta.Text);
            Query.Parameters["@CodigoSupervisor"].Value = _Supervisor;
            Query.Parameters["@CodigoIntermediario"].Value = _Intermediario;
            Query.Parameters["@Oficina"].Value = _Oficina;
            Query.Parameters["@Ramo"].Value = _Ramo;
            Query.Parameters["@TipoGrafico"].Value = 4;

            Conexion.Open();

            SqlDataReader Reader = Query.ExecuteReader();
            while (Reader.Read())
            {
                MontoFacturado[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreRamo[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();
            GraRamo.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraRamo.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraRamo.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraRamo.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraRamo.Series["Serie"].Points.DataBindXY(NombreRamo, MontoFacturado);
        }
        private void GraficoUsuarios() {
            decimal[] MontoFacturado = new decimal[10];
            string[] NombreUsuario = new string[10];
            int Contador = 0;

            decimal IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);

            string Estatus = "";
            if (rbTodas.Checked == true)
            {
                Estatus = "NADA";
            }
            else if (rbActivas.Checked == true)
            {
                Estatus = "ACTIVO";
            }
            else if (rbCanceladas.Checked == true)
            {
                Estatus = "CANCELADA";
            }

            string _Supervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
            {
                _Supervisor = "0";
            }
            else
            {
                _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            }


            string _Intermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
            {
                _Intermediario = "0";
            }
            else
            {
                _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            }



            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

            if (_Oficina == null)
            {
                _Oficina = 0;
            }

            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }



            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Query = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICOS_PRODUCCION] @IdUsuario,@Estatus,@FechaDesde,@FechaHasta,@CodigoSupervisor,@CodigoIntermediario,@Oficina,@Ramo,@TipoGrafico", Conexion);
            Query.Parameters.AddWithValue("@IdUsuario", SqlDbType.Decimal);
            Query.Parameters.AddWithValue("@Estatus", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Query.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Query.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@Oficina", SqlDbType.Int);
            Query.Parameters.AddWithValue("@Ramo", SqlDbType.Int);
            Query.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);


            Query.Parameters["@IdUsuario"].Value = (decimal)Session["IdUsuario"];
            Query.Parameters["@Estatus"].Value = Estatus;
            Query.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);
            Query.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHasta.Text);
            Query.Parameters["@CodigoSupervisor"].Value = _Supervisor;
            Query.Parameters["@CodigoIntermediario"].Value = _Intermediario;
            Query.Parameters["@Oficina"].Value = _Oficina;
            Query.Parameters["@Ramo"].Value = _Ramo;
            Query.Parameters["@TipoGrafico"].Value = 5;

            Conexion.Open();

            SqlDataReader Reader = Query.ExecuteReader();
            while (Reader.Read())
            {
                MontoFacturado[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreUsuario[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();
            GraUsuario.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraUsuario.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraUsuario.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraUsuario.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraUsuario.Series["Serie"].Points.DataBindXY(NombreUsuario, MontoFacturado);

        }
        private void GraficoConcepto()
        {
            decimal[] MontoFacturado = new decimal[10];
            string[] NombreCocepto = new string[10];
            int Contador = 0;

            decimal IdUsuario = Convert.ToDecimal(Session["IdUsuario"]);

            string Estatus = "";
            if (rbTodas.Checked == true)
            {
                Estatus = "NADA";
            }
            else if (rbActivas.Checked == true)
            {
                Estatus = "ACTIVO";
            }
            else if (rbCanceladas.Checked == true)
            {
                Estatus = "CANCELADA";
            }

            string _Supervisor = "";
            if (string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()))
            {
                _Supervisor = "0";
            }
            else
            {
                _Supervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            }


            string _Intermediario = "";
            if (string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()))
            {
                _Intermediario = "0";
            }
            else
            {
                _Intermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            }



            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();

            if (_Oficina == null)
            {
                _Oficina = 0;
            }

            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            if (_Ramo == null)
            {
                _Ramo = 0;
            }



            SqlConnection Conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            SqlCommand Query = new SqlCommand("EXEC [Utililades].[SP_GENERAR_GRAFICOS_PRODUCCION] @IdUsuario,@Estatus,@FechaDesde,@FechaHasta,@CodigoSupervisor,@CodigoIntermediario,@Oficina,@Ramo,@TipoGrafico", Conexion);
            Query.Parameters.AddWithValue("@IdUsuario", SqlDbType.Decimal);
            Query.Parameters.AddWithValue("@Estatus", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@FechaDesde", SqlDbType.Date);
            Query.Parameters.AddWithValue("@FechaHasta", SqlDbType.Date);
            Query.Parameters.AddWithValue("@CodigoSupervisor", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@CodigoIntermediario", SqlDbType.VarChar);
            Query.Parameters.AddWithValue("@Oficina", SqlDbType.Int);
            Query.Parameters.AddWithValue("@Ramo", SqlDbType.Int);
            Query.Parameters.AddWithValue("@TipoGrafico", SqlDbType.Int);


            Query.Parameters["@IdUsuario"].Value = (decimal)Session["IdUsuario"];
            Query.Parameters["@Estatus"].Value = Estatus;
            Query.Parameters["@FechaDesde"].Value = Convert.ToDateTime(txtFechaDesde.Text);
            Query.Parameters["@FechaHasta"].Value = Convert.ToDateTime(txtFechaHasta.Text);
            Query.Parameters["@CodigoSupervisor"].Value = _Supervisor;
            Query.Parameters["@CodigoIntermediario"].Value = _Intermediario;
            Query.Parameters["@Oficina"].Value = _Oficina;
            Query.Parameters["@Ramo"].Value = _Ramo;
            Query.Parameters["@TipoGrafico"].Value = 6;

            Conexion.Open();

            SqlDataReader Reader = Query.ExecuteReader();
            while (Reader.Read())
            {
                MontoFacturado[Contador] = Convert.ToDecimal(Reader.GetDecimal(1));
                NombreCocepto[Contador] = Reader.GetString(0);
                Contador++;
            }
            Reader.Close();
            Conexion.Close();
            GraConcepto.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}k";
            GraConcepto.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraConcepto.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraConcepto.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            GraConcepto.Series["Serie"].Points.DataBindXY(NombreCocepto, MontoFacturado);

        }
        #endregion
        #region COMPLETENTO DE CONSULTAS
        private void CargarSucursales() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarSucursal, ObjDataGeneral.Value.BuscaListas("SUCURSAL", null, null), true);
        }
        private void CargarOficinas() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionaroficina, ObjDataGeneral.Value.BuscaListas("OFICINA", ddlSeleccionarSucursal.SelectedValue.ToString(), null), true);
        }
        private void CargarRamos() {
            UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarRamo, ObjDataGeneral.Value.BuscaListas("RAMO", null, null), true);
        }
        #endregion
        #region VALIDAR LOS CONTROLES DE VALIDACION
        private void LimpiarCOntrolesValidacion() {
            lbFechaDesdeValidacion.Text = "0";
            lbFechaHastaValidacion.Text = "0";
            lbTasaValidacion.Text = "0";
        }
        private bool ValidacionControles(string FechaDesdeEntrada, string FechaHastaEntrada,string TasaEntrada)
        {
            bool Validacion = false;

            string FechaDesdeValidar = "", FechaHastaValidar = "", TasaValidar = "";


            FechaDesdeValidar = lbFechaDesdeValidacion.Text;
            FechaHastaValidar = lbFechaHastaValidacion.Text;
            TasaValidar = lbTasaValidacion.Text;

            if (FechaDesdeValidar == FechaDesdeEntrada &&
                FechaHastaValidar == FechaHastaEntrada &&
                TasaValidar == TasaEntrada)
            {
                Validacion = true;
            }
            else {
                Validacion = false;
            }
            return Validacion;

        }

        private void PasarParametrosValidacion() {

            string FechaDesde = "", FechaHasta = "",Tasa = "";

            FechaDesde = txtFechaDesde.Text;
            FechaHasta = txtFechaHasta.Text;
           

            if (string.IsNullOrEmpty(txtTasa.Text.Trim()))
            {
                Tasa = "0";
            }
            else {
                Tasa = txtTasa.Text;
            }
            Tasa = txtTasa.Text;
            lbFechaDesdeValidacion.Text = FechaDesde;
            lbFechaHastaValidacion.Text = FechaHasta;
            lbTasaValidacion.Text = Tasa;
        }
        #endregion
        #region BUSCAR DATOS PRODUCCION NO AGRUPADO
        private void BuscarDatosNoAgrupados() {


            if (Session["IdUsuario"] != null)
            {
                string Estatus = "";
                if (rbTodas.Checked == true) {
                    Estatus = null;
                }
                else if (rbActivas.Checked == true) {
                    Estatus = "ACTIVO";
                }
                else if (rbCanceladas.Checked == true) {
                    Estatus = "CANCELADA";
                }


                string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
                string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
                string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;

                int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
                int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();

                var BuscarInformacion = ObjData.Value.BuscaDatosProduccionNoAgrupadoDetalle(
                    Convert.ToDecimal(Session["IdUsuario"]),
                    Estatus,
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    _CodigoSupervisor,
                    _CodigoIntermediario,
                    _Oficina,
                    _Ramo,
                    null,
                    _Concepto, null);
                gvListdoProduccion.DataSource = BuscarInformacion;
                gvListdoProduccion.DataBind();

                int CantidadRegistros = 0;
                decimal TotalFActurado = 0, TotalFActuradoPesos = 0, TotalFacturadoDollar = 0, FacturadoGeneral = 0;
                foreach (var n in BuscarInformacion) {
                    CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                    TotalFActurado = Convert.ToDecimal(n.TotalFacturado);
                    TotalFActuradoPesos = Convert.ToDecimal(n.TotalFActuradoPesos);
                    TotalFacturadoDollar = Convert.ToDecimal(n.TotalDollar);
                    FacturadoGeneral = Convert.ToDecimal(n.TotalFacturadoGeneral);
                }

                lbcantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                lbTotalFacturadoVariable.Text = TotalFActurado.ToString("N2");
                lbFacturadoPesosVariable.Text = TotalFActuradoPesos.ToString("N2");
                LbFacturadoDollarVariable.Text = TotalFacturadoDollar.ToString("N2");
                lbFacturadoTotalVariable.Text = FacturadoGeneral.ToString("N2");
            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        
        }
        #endregion
        #region MOSTRAR Y OCULTAR CONTROLED E LOS GRAFICOS
        private void MostrarControlesGraficos() {
            lbGraficoSupervisores.Visible = true;
            GraSupervisores.Visible = true;
            lbGraficoIntermediario.Visible = true;
            GraIntermediarios.Visible = true;
            lbGraficoOficina.Visible = true;
            GraOficina.Visible = true;
            lbGraficoRamo.Visible = true;
            GraRamo.Visible = true;
            lbGraficoPorUsuario.Visible = true;
            GraUsuario.Visible = true;
            lbGraficoConcepto.Visible = true;
            GraConcepto.Visible = true;
        }
        private void OcultarControlesGraficos() {
            lbGraficoSupervisores.Visible = false;
            GraSupervisores.Visible = false;
            lbGraficoIntermediario.Visible = false;
            GraIntermediarios.Visible = false;
            lbGraficoOficina.Visible = false;
            GraOficina.Visible = false;
            lbGraficoRamo.Visible = false;
            GraRamo.Visible = false;
            lbGraficoPorUsuario.Visible = false;
            GraUsuario.Visible = false;
            lbGraficoConcepto.Visible = false;
            GraConcepto.Visible = false;
        }
        #endregion
        #region SACAR INFORMACION DEL ORIGEN DE LA PRODUCCION PARA PASARLA A LA TABLA QUE SE VA A MANIPULAR
        private void SacarInformacionOrigen() {
            try {
                EliminarDatosProduccion(Convert.ToDecimal(Session["Idusuario"]));

                var SacarofigenDatos = ObjData.Value.BuscaReporteProduccionOrigen(
                    Convert.ToDateTime(txtFechaDesde.Text),
                    Convert.ToDateTime(txtFechaHasta.Text),
                    Convert.ToDecimal(txtTasa.Text));
                foreach (var n in SacarofigenDatos)
                {
                    UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosProduccion GuardarRegistros = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosProduccion(
                        Convert.ToDecimal(Session["IdUsuario"]),
                        Convert.ToInt32(n.CodRamo),
                        n.Ramo,
                        Convert.ToDecimal(n.NumeroFactura),
                        n.NumeroFacturaFormateado,
                        n.Poliza,
                        n.Asegurado,
                        Convert.ToInt32(n.Items),
                        n.Supervisor,
                        Convert.ToInt32(n.CodIntermediario),
                        Convert.ToInt32(n.CodSupervisor),
                        n.Intermediario,
                        Convert.ToDateTime(n.Fecha),
                        n.FechaFormateada,
                        Convert.ToDateTime(n.FechaInicioVigencia),
                        Convert.ToDateTime(n.FechaFinVigencia),
                        n.InicioVigencia,
                        n.FinVigencia,
                        n.SumaAsegurada.ToString(),
                        n.Estatus,
                        Convert.ToInt32(n.CodOficina),
                        n.Oficina,
                        n.Concepto,
                        n.Ncf,
                        Convert.ToInt32(n.Tipo),
                        n.DescripcionTipo,
                        Convert.ToDecimal(n.Bruto),
                        Convert.ToDecimal(n.Impuesto),
                        Convert.ToDecimal(n.Neto),
                        Convert.ToDecimal(n.Tasa),
                        Convert.ToDecimal(n.Cobrado),
                        Convert.ToInt32(n.CodMoneda),
                        n.Moneda,
                        Convert.ToDecimal(n.TasaUsada),
                        Convert.ToDecimal(n.MontoPesos),
                        n.Mes,
                        n.Usuario,
                        "INSERT");
                    GuardarRegistros.ProcesarInformacion();
                }

                PasarParametrosValidacion();
            }
            catch (Exception) { }
        }
        #endregion

        private void EliminarDatosProduccion(decimal IdUsuario) {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosProduccion Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosProduccion(
                IdUsuario, 0, "", 0, "", "", "", 0, "", 0, 0, "", DateTime.Now, "", DateTime.Now, DateTime.Now, "", "", "", "", 0, "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", 0, 0, "", "", "DELETE");
            Eliminar.ProcesarInformacion();
        }
        #region CONSULTAS
        private void CargarInformacionProduccionOrigen(DateTime FechaDesde, DateTime FechaHasta, decimal Tasa) {
            if (Session["IdUsuario"] != null)
            {
                bool ValidarParametros = ValidacionControles(txtFechaDesde.Text, txtFechaHasta.Text, txtTasa.Text);

                if (ValidarParametros == false)
                {
                    SacarInformacionOrigen();
                }

            }
            else {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        private void ConsultarPorPantalla() {
            if (string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) || string.IsNullOrEmpty(txtFechaHasta.Text.Trim())) { }
            else {
                bool ValidarControles = ValidacionControles(txtFechaDesde.Text, txtFechaHasta.Text, txtTasa.Text);

                if (ValidarControles == false) {
                    CargarInformacionProduccionOrigen(
                        Convert.ToDateTime(txtFechaDesde.Text),
                        Convert.ToDateTime(txtFechaHasta.Text),
                        Convert.ToDecimal(txtTasa.Text));
                    cbGraficar.Enabled = true;
                }
                BuscarDatosNoAgrupados();
                if (cbGraficar.Checked == true) {
                    if (Session["IdUsuario"] != null) {
                        GraficoSupervisores();
                        GraficoIntermediarios();
                        GraficoOficinas();
                        GraficosRamos();
                        GraficoUsuarios();
                        GraficoConcepto();
                    }
                    else {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }

                }
            }


        }
        #endregion


        #region GENERAR REPORTES 
        /// <summary>
        /// Este Metodo es para generar el reporte de la prodiccion sin agrupar.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="RutaReporte"></param>
        /// <param name="UsuarioBD"></param>
        /// <param name="ClaveBD"></param>
        /// <param name="NombreArchivo"></param>
        private void GenerarReporteNoAgrupadoDetalle(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBD, string NombreArchivo)
        {

            string Estatus = "";

            if (rbTodas.Checked == true)
            {
                Estatus = null;
            }
            else if (rbActivas.Checked == true)
            {
                Estatus = "ACTIVO";

            }
            else if (rbCanceladas.Checked == true)
            {
                Estatus = "CANCELADA";
            }

            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _CodMoneda = null;
            string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;
            string _Mes = null;

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();
            Reporte.SetParameterValue("@IdUsuario", IdUsuario);
            Reporte.SetParameterValue("@Estatus", Estatus);
            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            Reporte.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@CodMoneda", _CodMoneda);
            Reporte.SetParameterValue("@Concepto", _Concepto);
            Reporte.SetParameterValue("@Mes", _Mes);
            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);
            //VALIDAMOS LA FORMA EN LA QUE SE EXPORTARA LA INFORMACION
            if (rbExportarPDF.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbExportarExel.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbExportarWord.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
            else if (rbExportartxt.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreArchivo);
            }
            else if (rbExportarXML.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Xml, Response, true, NombreArchivo);
            }
            else if (rbExportarCSV.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreArchivo);
            }


        }
        /// <summary>
        /// Este Metodo es para generar el reporte de produccion sin agrupar detallado.
        /// </summary>
        /// <param name="IdUaurio"></param>
        /// <param name="RutaReporte"></param>
        /// <param name="UsuarioBD"></param>
        /// <param name="ClaveBD"></param>
        /// <param name="NombreArchivo"></param>
        private void GenerarReporteNoAgrupadoResumen(decimal IdUaurio, string RutaReporte, string UsuarioBD, string ClaveBD, string NombreArchivo)
        {
            string Estatus = "";

            if (rbTodas.Checked == true)
            {
                Estatus = null;
            }
            else if (rbActivas.Checked == true)
            {
                Estatus = "ACTIVO";

            }
            else if (rbCanceladas.Checked == true)
            {
                Estatus = "CANCELADA";
            }

            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _CodMoneda = null;
            string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;
            string _Mes = null;

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();
            Reporte.SetParameterValue("@IdUsuario", IdUaurio);
            Reporte.SetParameterValue("@Estatus", Estatus);
            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            Reporte.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@CodMoneda", _CodMoneda);
            Reporte.SetParameterValue("@Concepto", _Concepto);
            Reporte.SetParameterValue("@Mes", _Mes);
            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

            if (rbExportarPDF.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbExportarExel.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbExportarWord.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
            else if (rbExportartxt.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreArchivo);
            }
            else if (rbExportarXML.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Xml, Response, true, NombreArchivo);
            }
            else if (rbExportarCSV.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreArchivo);
            }


        }
        /// <summary>
        /// Este metodo es para generar el reporte de produccion agrupado por concepto.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="RutaReporte"></param>
        /// <param name="UsuarioBD"></param>
        /// <param name="ClaveBD"></param>
        /// <param name="NombreArchivo"></param>
        private void GenerarReporteAgrupadoConcepto(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBD, string NombreArchivo)
        {
            string _Estatus = "";
            if (rbTodas.Checked == true)
            {
                _Estatus = null;
            }
            else if (rbActivas.Checked == true)
            {
                _Estatus = "ACTIVO";

            }
            else if (rbCanceladas.Checked == true)
            {
                _Estatus = "CANCELADA";
            }

            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _CodMoneda = null;
            string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;
            string _Mes = null;
            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();
            Reporte.SetParameterValue("@IdUsuario", IdUsuario);
            Reporte.SetParameterValue("@Estatus", _Estatus);
            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            Reporte.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@CodMoneda", _CodMoneda);
            Reporte.SetParameterValue("@Concepto", _Concepto);
            Reporte.SetParameterValue("@Mes", _Mes);
            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

            if (rbExportarPDF.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbExportarExel.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbExportarWord.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
            else if (rbExportartxt.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreArchivo);
            }
            else if (rbExportarXML.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Xml, Response, true, NombreArchivo);
            }
            else if (rbExportarCSV.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreArchivo);
            }
        }
        /// <summary>
        /// Este Metodo es para generar el reporte de produccion agrupado por usuario.
        /// </summary>
        /// <param name="IdUaurio"></param>
        /// <param name="RutaReporte"></param>
        /// <param name="UsuarioBD"></param>
        /// <param name="ClaveBD"></param>
        /// <param name="NombreArchivo"></param>
        private void GenerarReporteAgrupadoUsuario(decimal IdUaurio, string RutaReporte, string UsuarioBD, string ClaveBD, string NombreArchivo)
        {
            string _Estatus = "";
            if (rbTodas.Checked == true)
            {
                _Estatus = null;
            }
            else if (rbActivas.Checked == true)
            {
                _Estatus = "ACTIVO";

            }
            else if (rbCanceladas.Checked == true)
            {
                _Estatus = "CANCELADA";
            }

            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _CodMoneda = null;
            string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;
            string _Mes = null;

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();
            Reporte.SetParameterValue("@IdUsuario", IdUaurio);
            Reporte.SetParameterValue("@Estatus", _Estatus);
            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            Reporte.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@CodMoneda", _CodMoneda);
            Reporte.SetParameterValue("@Concepto", _Concepto);
            Reporte.SetParameterValue("@Mes", _Mes);

            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBD);

            if (rbExportarPDF.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbExportarExel.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbExportarWord.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
            else if (rbExportartxt.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreArchivo);
            }
            else if (rbExportarXML.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Xml, Response, true, NombreArchivo);
            }
            else if (rbExportarCSV.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreArchivo);
            }
        }
        /// <summary>
        /// Este metodo es para generar el reporte de produccion agrupado por Oficina.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="RutaReporte"></param>
        /// <param name="UsuarioBD"></param>
        /// <param name="ClaveBd"></param>
        /// <param name="NombreArchivo"></param>
        private void GenerarReporteAgrupadoPorOficina(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBd, string NombreArchivo)
        {
            string _Estatus = "";
            if (rbTodas.Checked == true)
            {
                _Estatus = null;
            }
            else if (rbActivas.Checked == true)
            {
                _Estatus = "ACTIVO";

            }
            else if (rbCanceladas.Checked == true)
            {
                _Estatus = "CANCELADA";
            }

            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _CodMoneda = null;
            string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;
            string _Mes = null;

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();
            Reporte.SetParameterValue("@IdUsuario", IdUsuario);
            Reporte.SetParameterValue("@Estatus", _Estatus);
            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            Reporte.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@CodMoneda", _CodMoneda);
            Reporte.SetParameterValue("@Concepto", _Concepto);
            Reporte.SetParameterValue("@Mes", _Mes);
            Reporte.SetDatabaseLogon(UsuarioBD, ClaveBd);

            if (rbExportarPDF.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbExportarExel.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbExportarWord.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
            else if (rbExportartxt.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreArchivo);
            }
            else if (rbExportarXML.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Xml, Response, true, NombreArchivo);
            }
            else if (rbExportarCSV.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreArchivo);
            }
        }
        /// <summary>
        /// Este metodo es para generar el reporte de produccion agrupado por ramo.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="RutaReporte"></param>
        /// <param name="UsuarioBD"></param>
        /// <param name="ClabeBD"></param>
        /// <param name="Nombrearchivo"></param>
        private void GenerarReporteAgrupadoPorRamo(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClabeBD, string Nombrearchivo)
        {
            string _Estatus = "";
            if (rbTodas.Checked == true)
            {
                _Estatus = null;
            }
            else if (rbActivas.Checked == true)
            {
                _Estatus = "ACTIVO";

            }
            else if (rbCanceladas.Checked == true)
            {
                _Estatus = "CANCELADA";
            }

            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _CodMoneda = null;
            string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;
            string _Mes = null;

            ReportDocument Reporte = new ReportDocument();

            Reporte.Load(RutaReporte);
            Reporte.Refresh();
            Reporte.SetParameterValue("@IdUsuario", IdUsuario);
            Reporte.SetParameterValue("@Estatus", _Estatus);
            Reporte.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            Reporte.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            Reporte.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            Reporte.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            Reporte.SetParameterValue("@Oficina", _Oficina);
            Reporte.SetParameterValue("@Ramo", _Ramo);
            Reporte.SetParameterValue("@CodMoneda", _CodMoneda);
            Reporte.SetParameterValue("@Concepto", _Concepto);
            Reporte.SetParameterValue("@Mes", _Mes);
            Reporte.SetDatabaseLogon(UsuarioBD, ClabeBD);
            if (rbExportarPDF.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, Nombrearchivo);
            }
            else if (rbExportarExel.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, true, Nombrearchivo);
            }
            else if (rbExportarWord.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, Nombrearchivo);
            }
            else if (rbExportartxt.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Text, Response, true, Nombrearchivo);
            }
            else if (rbExportarXML.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.Xml, Response, true, Nombrearchivo);
            }
            else if (rbExportarCSV.Checked == true)
            {
                Reporte.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, Nombrearchivo);
            }
        }
        /// <summary>
        /// Este metodo es para generar el reporte de produccion agrupado por intermediario.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="RutaReporte"></param>
        /// <param name="UsuarioBD"></param>
        /// <param name="ClaveBD"></param>
        /// <param name="NombreArchivo"></param>
        private void GenerarReporteAgrupadoPorIntermediario(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBD, string NombreArchivo)
        {
            string _Estatus = "";
            if (rbTodas.Checked == true)
            {
                _Estatus = null;
            }
            else if (rbActivas.Checked == true)
            {
                _Estatus = "ACTIVO";

            }
            else if (rbCanceladas.Checked == true)
            {
                _Estatus = "CANCELADA";
            }

            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _CodMoneda = null;
            string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;
            string _Mes = null;

            ReportDocument ReporteIntermediario = new ReportDocument();

            ReporteIntermediario.Load(RutaReporte);
            ReporteIntermediario.Refresh();
            ReporteIntermediario.SetParameterValue("@IdUsuario", IdUsuario);
            ReporteIntermediario.SetParameterValue("@Estatus", _Estatus);
            ReporteIntermediario.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            ReporteIntermediario.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            ReporteIntermediario.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            ReporteIntermediario.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            ReporteIntermediario.SetParameterValue("@Oficina", _Oficina);
            ReporteIntermediario.SetParameterValue("@Ramo", _Ramo);
            ReporteIntermediario.SetParameterValue("@CodMoneda", _CodMoneda);
            ReporteIntermediario.SetParameterValue("@Concepto", _Concepto);
            ReporteIntermediario.SetParameterValue("@Mes", _Mes);
            ReporteIntermediario.SetDatabaseLogon(UsuarioBD, ClaveBD);
            if (rbExportarPDF.Checked == true)
            {
                ReporteIntermediario.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbExportarExel.Checked == true)
            {
                ReporteIntermediario.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbExportarWord.Checked == true)
            {
                ReporteIntermediario.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
            else if (rbExportartxt.Checked == true)
            {
                ReporteIntermediario.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreArchivo);
            }
            else if (rbExportarXML.Checked == true)
            {
                ReporteIntermediario.ExportToHttpResponse(ExportFormatType.Xml, Response, true, NombreArchivo);
            }
            else if (rbExportarCSV.Checked == true)
            {
                ReporteIntermediario.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreArchivo);
            }
        }
        /// <summary>
        /// Este metodo es para generar el reporte de produccionagrupado por supervisor.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="RutaReporte"></param>
        /// <param name="UsuarioBD"></param>
        /// <param name="ClaveBD"></param>
        /// <param name="NombreArchivo"></param>
        private void GenerarReporteAgrupadoPorSupervisor(decimal IdUsuario, string RutaReporte, string UsuarioBD, string ClaveBD, string NombreArchivo)
        {
            string _Estatus = "";
            if (rbTodas.Checked == true)
            {
                _Estatus = null;
            }
            else if (rbActivas.Checked == true)
            {
                _Estatus = "ACTIVO";

            }
            else if (rbCanceladas.Checked == true)
            {
                _Estatus = "CANCELADA";
            }

            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            int? _Oficina = ddlSeleccionaroficina.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionaroficina.SelectedValue) : new Nullable<int>();
            int? _Ramo = ddlSeleccionarRamo.SelectedValue != "-1" ? Convert.ToInt32(ddlSeleccionarRamo.SelectedValue) : new Nullable<int>();
            int? _CodMoneda = null;
            string _Concepto = ddlSeleccionarConcepto.SelectedValue != "-1" ? ddlSeleccionarConcepto.SelectedItem.Text : null;
            string _Mes = null;

            ReportDocument ReporteSupervisor = new ReportDocument();

            ReporteSupervisor.Load(RutaReporte);
            ReporteSupervisor.Refresh();
            ReporteSupervisor.SetParameterValue("@IdUsuario", IdUsuario);
            ReporteSupervisor.SetParameterValue("@Estatus", _Estatus);
            ReporteSupervisor.SetParameterValue("@FechaDesde", Convert.ToDateTime(txtFechaDesde.Text));
            ReporteSupervisor.SetParameterValue("@FechaHasta", Convert.ToDateTime(txtFechaHasta.Text));
            ReporteSupervisor.SetParameterValue("@CodigoSupervisor", _CodigoSupervisor);
            ReporteSupervisor.SetParameterValue("@CodigoIntermediario", _CodigoIntermediario);
            ReporteSupervisor.SetParameterValue("@Oficina", _Oficina);
            ReporteSupervisor.SetParameterValue("@Ramo", _Ramo);
            ReporteSupervisor.SetParameterValue("@CodMoneda", _CodMoneda);
            ReporteSupervisor.SetParameterValue("@Concepto", _Concepto);
            ReporteSupervisor.SetParameterValue("@Mes", _Mes);
            ReporteSupervisor.SetDatabaseLogon(UsuarioBD, ClaveBD);
            if (rbExportarPDF.Checked == true)
            {
                ReporteSupervisor.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, NombreArchivo);
            }
            else if (rbExportarExel.Checked == true)
            {
                ReporteSupervisor.ExportToHttpResponse(ExportFormatType.Excel, Response, true, NombreArchivo);
            }
            else if (rbExportarWord.Checked == true)
            {
                ReporteSupervisor.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, NombreArchivo);
            }
            else if (rbExportartxt.Checked == true)
            {
                ReporteSupervisor.ExportToHttpResponse(ExportFormatType.Text, Response, true, NombreArchivo);
            }
            else if (rbExportarXML.Checked == true)
            {
                ReporteSupervisor.ExportToHttpResponse(ExportFormatType.Xml, Response, true, NombreArchivo);
            }
            else if (rbExportarCSV.Checked == true)
            {
                ReporteSupervisor.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, NombreArchivo);
            }
        }
        #endregion






        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rbExportarPDF.Checked = true;
                rbNoAgrupar.Checked = true;
                rbTodas.Checked = true;
                rbDetalle.Checked = true;
                txtTasa.Text = UtilidadesAmigos.Logica.Comunes.SacartasaMoneda.SacarTasaMoneda(2).ToString();
                CargarSucursales();
                CargarOficinas();
                CargarRamos();
                lbFechaDesdeValidacion.Text = "0";
                lbFechaHastaValidacion.Text = "0";
                lbTasaValidacion.Text = "0";
                cbGraficar.Checked = false;
                cbGraficar.Enabled = false;
                UtilidadesAmigos.Logica.Comunes.UtilidadDrop.DropDownListLlena(ref ddlSeleccionarConcepto, ObjDataGeneral.Value.BuscaListas("CONCEPTOS", null, null), true);
            }

           
         
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            string _CodigoSupervisor = string.IsNullOrEmpty(txtCodigoSupervisor.Text.Trim()) ? null : txtCodigoSupervisor.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarDato = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoSupervisor);
            txtNombreSupervisor.Text = SacarDato.SacarNombreSupervisor();
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            string _CodigoIntermediario = string.IsNullOrEmpty(txtCodigoIntermediario.Text.Trim()) ? null : txtCodigoIntermediario.Text.Trim();
            UtilidadesAmigos.Logica.Comunes.SacarNombreIntermediarioSupervisor SacarDato = new Logica.Comunes.SacarNombreIntermediarioSupervisor(_CodigoIntermediario);
            txtNombreIntermediario.Text = SacarDato.SacarNombreIntermediario();
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

                ConsultarPorPantalla(); 
                cbGraficar.Checked = false;
                OcultarControlesGraficos();
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
            else {

                bool ValidarParametros = ValidacionControles(txtFechaDesde.Text, txtFechaHasta.Text, txtTasa.Text);

                if (ValidarParametros == false) {
                    SacarInformacionOrigen();
                }


                //EXPORTAR INFORMACION SIN AGRUPAR NADA
                if (rbNoAgrupar.Checked == true)
                {

                    //BUSCAR LA INFORMACION DE MANERA DETALLADA
                    if (rbDetalle.Checked == true)
                    {
                        GenerarReporteNoAgrupadoDetalle(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteProduccionNoAgrupadoDetalle.rpt"), "sa", "Pa$$W0rd", "Reporte Producción Detalle");

                    }
                    //BUSCAR LA INFORMACION DE MANERA RESUMIDA
                    else if (rbResumido.Checked == true)
                    {
                        GenerarReporteNoAgrupadoResumen(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteProduccionNoAgrupadoResumen.rpt"), "sa", "Pa$$W0rd", "Reporte de Producción Resumido");
                    }

                }
                //AGRUPAR LA INFORMACION POR CONCEPTO
                else if (rbAgruparConcepto.Checked == true)
                {
                    GenerarReporteAgrupadoConcepto(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteProduccionAgrupadoConcepto.rpt"), "sa", "Pa$$W0rd", "Reporte de Producción Agrupado Por Concepto");
                }
                //AGRUPAR LA INFORMACION POR USUARIOS
                else if (rbAgruparPorUsuarios.Checked == true)
                {
                    GenerarReporteAgrupadoUsuario(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteAgrupadoPorUsuario.rpt"), "sa", "Pa$$W0rd", "Reporte de Producción Agrupado Por Usuario");
                }
                else if (rbAgruparPorOficina.Checked == true)
                {
                    GenerarReporteAgrupadoPorOficina(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteAgrupadoPoroficina.rpt"), "sa", "Pa$$W0rd", "Reporte de Produccion Agrupado Por Oficina");
                }
                else if (rbAgruparPorRamo.Checked == true) {

                    GenerarReporteAgrupadoPorRamo(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteProduccionAgrupadaRamo.rpt"), "sa", "Pa$$W0rd", "Reporte de Producción Agrupado Por Ramo");
                }
                else if (rbAgruparPorIntermediario.Checked == true){
                    GenerarReporteAgrupadoPorIntermediario(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteProduccionAgrupadoIntermediario.rpt"), "sa", "Pa$$W0rd", "Reporte de Producción Agrupado por Intermediario");
                }
                else if (rbAgruparPorSupervisor.Checked == true) {
                    GenerarReporteAgrupadoPorSupervisor(Convert.ToDecimal(Session["IdUsuario"]), Server.MapPath("ReporteProduccionAgrupadoSupervisor.rpt"), "sa", "Pa$$W0rd", "Reporte de Produccion Agrupado Por Supervisor");

                }
            }
        }

        protected void gvListdoProduccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListdoProduccion.PageIndex = e.NewPageIndex;
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
            else
            {

                ConsultarPorPantalla();
                cbGraficar.Checked = false;
                OcultarControlesGraficos();
            }
        }

        protected void gvListdoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSeleccionarSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinas();
        }

        protected void cbGraficar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGraficar.Checked == true) {
                MostrarControlesGraficos();

                GraficoSupervisores();
                GraficoIntermediarios();
                GraficoOficinas();
                GraficosRamos();
                GraficoUsuarios();
                GraficoConcepto();
            }
            else {
                OcultarControlesGraficos();
            }
        }

     
    }
}
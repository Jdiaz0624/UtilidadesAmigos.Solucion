
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

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
        private string SacarSupervisor(string CodigoSupervisor) {

            string NombreSupervisor = "";
            var Nombre = ObjDataMantenimiento.Value.BuscaListadoIntermediario(
                null,
                null,
                CodigoSupervisor,
                null,
                null);
            if (Nombre.Count() < 1) {
                NombreSupervisor = "";
            }
            else {
                foreach (var n in Nombre) {
                    NombreSupervisor = n.NombreSupervisor;
                }
            }

            return NombreSupervisor;
        }
        private string SacarIntermediario(string CodigoIntermediario) {
            string NombreIntermediario = "";

            var Nombre = ObjDataMantenimiento.Value.BuscaListadoIntermediario(
                CodigoIntermediario,
                null, null, null, null);
            if (Nombre.Count() < 1)
            {
                NombreIntermediario = "";
            }
            else {
                foreach (var n in Nombre) {
                    NombreIntermediario = n.NombreVendedor;
                }
            }
            return NombreIntermediario;
        }
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
                    null, null, null);
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






        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
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
            }

           
         
        }

        protected void txtCodigoSupervisor_TextChanged(object sender, EventArgs e)
        {
            txtNombreSupervisor.Text = SacarSupervisor(txtCodigoSupervisor.Text);
        }

        protected void txtCodigoIntermediario_TextChanged(object sender, EventArgs e)
        {
            txtNombreIntermediario.Text = SacarIntermediario(txtCodigoIntermediario.Text);
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

                      
                       

                        var ExportarRegistrosNoagrupados = (from n in ObjData.Value.BuscaDatosProduccionNoAgrupadoDetalle(
                            Convert.ToDecimal(Session["IdUsuario"]),
                            Estatus,
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            _CodigoSupervisor,
                            _CodigoIntermediario,
                            _Oficina,
                            _Ramo,
                            null,
                            null,
                            null)
                                                            select new
                                                            {
                                                                Ramo =n.Ramo,
                                                                NumeroFactura=n.NumeroFacturaFormateado,
                                                                Poliza=n.Poliza,
                                                                Asegurado=n.Asegurado,
                                                                CodSupervisor=n.CodSupervisor,
                                                                Supervisor=n.Supervisor,
                                                                CodIntermediario=n.CodIntermediario,
                                                                Intermediario=n.Intermediario,
                                                                Fecha=n.FechaFormateada,
                                                                InicioVigencia=n.InicioVigencia,
                                                                FinVigencia=n.FinVigencia,
                                                                SumaAsegurada=n.SumaAsegurada,
                                                                Estatus=n.Estatus,
                                                                Oficina=n.Oficina,
                                                                Concepto=n.Concepto,
                                                                NCF =n.Ncf,
                                                                Tipo=n.DescripcionTipo,
                                                                Bruto=n.Bruto,
                                                                Impuesto=n.Impuesto,
                                                                Neto=n.Neto,
                                                                Tasa=n.TasaUsada,
                                                                Cobrado=n.Cobrado,
                                                                Moneda=n.Moneda,
                                                                MontoPesos=n.MontoPesos,
                                                                Mes=n.Mes,
                                                                Usuario=n.Usuario


                                                            }).ToList();

                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Listado de produccion de " + txtFechaDesde.Text + " Hasta " + txtFechaHasta.Text, ExportarRegistrosNoagrupados);

                    }
                    //BUSCAR LA INFORMACION DE MANERA RESUMIDA
                    else if (rbResumido.Checked == true)
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

                        var ExportarResumenProduccionNoAgrupado = (from n in ObjData.Value.BuscaDatosProduccionNoAgrupadoResumen(
                            Convert.ToDecimal(Session["IdUsuario"]),
                            Estatus,
                            Convert.ToDateTime(txtFechaDesde.Text),
                            Convert.ToDateTime(txtFechaHasta.Text),
                            _CodigoSupervisor,
                            _CodigoIntermediario,
                            _Oficina,
                            _Ramo,
                            null, null, null)
                                                                   select new {
                                                                       Ramo=n.Ramo,
                                                                       Supervisor=n.Supervisor,
                                                                       Intermediario=n.Intermediario,
                                                                       Oficina=n.Oficina,
                                                                       Tipo=n.DescripcionTipo,
                                                                       Bruto=n.Bruto,
                                                                       Impuesto=n.Impuesto,
                                                                       Neto=n.Neto,
                                                                       Cobrado=n.Cobrado,
                                                                       CodMoneda=n.CodMoneda,
                                                                       Moneda=n.Moneda,
                                                                       TasaUsada=n.TasaUsada,
                                                                       MontoPesos=n.MontoPesos
                                                                   }).ToList();
                        UtilidadesAmigos.Logica.Comunes.ExportarDataExel.exporttoexcel("Reporte Producción Resumida " + txtFechaDesde.Text + " Hasta " + txtFechaHasta.Text, ExportarResumenProduccionNoAgrupado);
                    }

                }
                //AGRUPAR LA INFORMACION POR CONCEPTO
                else if (rbAgruparConcepto.Checked == true)
                {

                    //BUSCAR LA INFORMACION DE MANERA DETALLADA
                    if (rbDetalle.Checked == true)
                    {

                      
                    }
                    //BUSCAR LA INFORMACION DE MANERA RESUMIDA
                    else if (rbResumido.Checked == true)
                    {
                   
                    }
                }
                //AGRUPAR LA INFORMACION POR USUARIOS
                else if (rbAgruparPorUsuarios.Checked == true)
                {

                    //BUSCAR LA INFORMACION DE MANERA DETALLADA
                    if (rbDetalle.Checked == true)
                    {
                        //BUSCAR LA INFORMACION DE MANERA DETALLADA
                        if (rbDetalle.Checked == true)
                        {

                        }
                        //BUSCAR LA INFORMACION DE MANERA RESUMIDA
                        else if (rbResumido.Checked == true)
                        {
    
                        }
                    }

                }
            }
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
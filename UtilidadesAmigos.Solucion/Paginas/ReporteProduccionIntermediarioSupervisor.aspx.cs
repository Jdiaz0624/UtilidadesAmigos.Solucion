
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
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos> ObjDataMantenimiento = new Lazy<Logica.Logica.LogicaMantenimientos.LogicaMantenimientos>();
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjDataGeneral = new Lazy<Logica.Logica.LogicaSistema>();


        #region METODOS DE GRAFICOS
        private void GraficoIntermediarios() {
            //decimal[] Monto = new decimal[10];
            //string[] Nombre = new string[10];
            //int Contador = 0;
            //SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);
            //SqlCommand comando = new SqlCommand("SELECT TOP(10) SUM(ValorDecimal),Entidad FROM Utililades.DatosGraficos WHERE IdUsuario=" + (decimal)Session["IdUsuario"] + " AND Entidad not in ('COMISIONISTA DIRECTO') GROUP BY Entidad ORDER BY SUM(ValorDecimal) DESC ", conexion);
            //conexion.Open();
            //SqlDataReader reader = comando.ExecuteReader();
            //while (reader.Read())
            //{
            //    Monto[Contador] = Convert.ToDecimal(reader.GetDecimal(0));
            //    Nombre[Contador] = reader.GetString(1);
            //    Contador++;
            //}
            //reader.Close();
            //conexion.Close();
            ////chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}K";
            //GraIntermediarios.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            //GraIntermediarios.Series["Serie"].Points.DataBindXY(Nombre, Monto);
            //EliminarDatosGraficos();
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

        private void EliminarDatosProduccion(decimal IdUsuario) {
            UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosProduccion Eliminar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosProduccion(
                IdUsuario, 0, "", 0, "", "", "", 0, "", 0, 0, "", DateTime.Now, "", DateTime.Now, DateTime.Now, "", "", "", "", 0, "", "", "", 0, "", 0, 0, 0, 0, 0, 0, "", 0, 0, "", "", "DELETE");
            Eliminar.ProcesarInformacion();
        }
        #region CONSULTAS
        private void ConsultarPorPantalla() {

            EliminarDatosProduccion(Convert.ToDecimal(Session["IdUsuario"]));


            int CantidadRegistros = 0;
            decimal TotalFacturado = 0, TotalFacturadoPesos = 0, TotalFacturadoDollar = 0, TotalFacturadoGeneral = 0;

            var BuscarRegistros = ObjData.Value.BuscaReporteProduccionOrigen(
                Convert.ToDateTime(txtFechaDesde.Text),
                Convert.ToDateTime(txtFechaHasta.Text),
                Convert.ToDecimal(txtTasa.Text));
            gvListdoProduccion.DataSource = BuscarRegistros;
            gvListdoProduccion.DataBind();
            foreach (var n in BuscarRegistros) {
                CantidadRegistros = Convert.ToInt32(n.CantidadRegistros);
                TotalFacturado = Convert.ToDecimal(n.TotalFacturado);
                TotalFacturadoPesos = Convert.ToDecimal(n.TotalFActuradoPesos);
                TotalFacturadoDollar = Convert.ToDecimal(n.TotalFActuradoDollar);
                TotalFacturadoGeneral = Convert.ToDecimal(n.TotalFacturadoGeneral);

                lbcantidadRegistrosVariable.Text = CantidadRegistros.ToString("N0");
                lbTotalFacturadoVariable.Text = TotalFacturado.ToString("N2");
                lbFacturadoPesosVariable.Text = TotalFacturadoPesos.ToString("N2");
                LbFacturadoDollarVariable.Text = TotalFacturadoDollar.ToString("N2");
                lbFacturadoTotalVariable.Text= TotalFacturadoGeneral.ToString("N2");


                //GUARDAMOS LOS DATOS 

                UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosProduccion Guardar = new Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionDatosProduccion(
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
                Guardar.ProcesarInformacion();
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

        protected void ddlSeleccionarSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOficinas();
        }
    }
}
using System;
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

        private void CorregirPolizaSinCobro(string Poliza) {

            try {
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
            catch (Exception) { }

           

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            
            }
        }

        protected void btnProcesarPolizaSinPagos_Click(object sender, EventArgs e)
        {
            string _Poliza = string.IsNullOrEmpty(txtPolizaSinPagos.Text.Trim()) ? null : txtPolizaSinPagos.Text.Trim();
            CorregirPolizaSinCobro(_Poliza);
        }

        protected void btnBuscarPolizaFormaPago_Click(object sender, EventArgs e)
        {
            BuscarReciboFormaPago();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }
    }
}
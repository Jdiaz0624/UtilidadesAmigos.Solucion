using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public partial class EliminarBalancePoliza : System.Web.UI.Page
    {
        Lazy<UtilidadesAmigos.Logica.Logica.LogicaSistema> ObjData = new Lazy<Logica.Logica.LogicaSistema>();

        #region MOSTRAR EL LISTADO
        private void MostrarListado()
        {
            if (rbGenerarTodo.Checked)
            {
                var Listado = ObjData.Value.ListadPolizasEliminarBalance(null);
                gbPolizasGuardadas.DataSource = Listado;
                gbPolizasGuardadas.DataBind();
            }
            else if (rbGenerarPolizaEspesifica.Checked)
            {
                string _Poliza = string.IsNullOrEmpty(txtPoliza.Text.Trim()) ? null : txtPoliza.Text.Trim();
                var Listado = ObjData.Value.ListadPolizasEliminarBalance(_Poliza);
                gbPolizasGuardadas.DataSource = Listado;
                gbPolizasGuardadas.DataBind();
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbGenerarTodo.Checked = true;
            }
        }

        protected void gbPolizasGuardadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gbPolizasGuardadas.PageIndex = e.NewPageIndex;
            MostrarListado();
        }

        protected void gbPolizasGuardadas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }
    }
}
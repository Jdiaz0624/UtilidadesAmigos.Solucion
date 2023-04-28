using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class Rangofecha
    {
        #region FECHA DE MES
        public void FechaMes(ref TextBox FechaDesde, ref TextBox FechaHasta)
        {
            // Page.Master.FindControl("ModuloServicio").Visible = false;
            DateTime date = DateTime.Now;
            //Asi obtenemos el primer dia del mes actual
            DateTime PrimerDia = new DateTime(date.Year, date.Month, 1);
            DateTime DiaActual = DateTime.Now;
            FechaDesde.Text = PrimerDia.ToString("yyyy-MM-dd");
            FechaHasta.Text = DiaActual.ToString("yyyy-MM-dd");
        }
        #endregion
    }
}

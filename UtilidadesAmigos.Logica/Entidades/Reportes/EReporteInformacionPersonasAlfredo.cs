using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EReporteInformacionPersonasAlfredo
    {
		public System.Nullable<int> Codigo { get; set; }

		public string Intermediario { get; set; }

		public System.Nullable<decimal> ProduccionBruto { get; set; }

		public System.Nullable<decimal> ISC { get; set; }

		public System.Nullable<decimal> ProduccionNeto { get; set; }

		public System.Nullable<decimal> CobradoBruto { get; set; }

		public System.Nullable<decimal> CobradoNeto { get; set; }

		public System.Nullable<decimal> Comision { get; set; }

		public System.Nullable<decimal> Retencion { get; set; }

		public System.Nullable<decimal> ALiquidar { get; set; }

		public string ValidadoDesde { get; set; }

		public string ValidadoHasta { get; set; }

		public string GeneradoPor { get; set; }
	}
}

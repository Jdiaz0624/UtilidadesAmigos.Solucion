using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class ESacarDatosProduccionResumido
    {
		public System.Nullable<int> CodigoRamo { get; set; }

		public string Ramo { get; set; }

		public System.Nullable<int> Vendedor { get; set; }

		public string Intermediario { get; set; }

		public int CodigoSupervisor { get; set; }

		public string Supervisor { get; set; }

		public System.Nullable<decimal> MontoBruto { get; set; }

		public System.Nullable<decimal> ISC { get; set; }

		public System.Nullable<decimal> MontoNeto { get; set; }

		public System.Nullable<int> CodMoneda { get; set; }

		public string Moneda { get; set; }

		public string GeneradoPor { get; set; }

		public string FechaDesde { get; set; }

		public string FechaHasta { get; set; }
	}
}

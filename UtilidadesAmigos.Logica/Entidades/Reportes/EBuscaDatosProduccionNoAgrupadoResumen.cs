using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscaDatosProduccionNoAgrupadoResumen
    {
		public System.Nullable<decimal> IdUsuario { get; set; }

		public System.Nullable<int> CodRamo{ get; set; }

		public string Ramo { get; set; }

		public string Supervisor { get; set; }

		public System.Nullable<int> CodIntermediario { get; set; }

		public System.Nullable<int> CodSupervisor { get; set; }

		public string Intermediario { get; set; }

		public System.Nullable<int> CodOficina { get; set; }

		public string Oficina { get; set; }

		public System.Nullable<int> Tipo { get; set; }

		public string DescripcionTipo { get; set; }

		public System.Nullable<decimal> Bruto { get; set; }

		public System.Nullable<decimal> Impuesto { get; set; }

		public System.Nullable<decimal> Neto { get; set; }

		public System.Nullable<decimal> Cobrado { get; set; }

		public System.Nullable<int> CodMoneda { get; set; }

		public string Moneda { get; set; }

		public System.Nullable<decimal> TasaUsada { get; set; }

		public System.Nullable<decimal> MontoPesos { get; set; }
	}
}

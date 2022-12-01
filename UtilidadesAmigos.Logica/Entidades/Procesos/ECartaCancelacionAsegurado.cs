using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class ECartaCancelacionAsegurado
    {
		public string FechaCarta { get; set; }

		public string Oficina { get; set; }

		public System.Nullable<decimal> CodigoAsegurado { get; set; }

		public string Asegurado { get; set; }

		public int? CodigoSupervisor { get; set; }

		public string Supervisor { get; set; }

		public int? CodigoIntermediario { get; set; }

		public string Intermediario { get; set; }

		public string Poliza { get; set; }

		public System.Nullable<decimal> BalanceNumerico { get; set; }

		public string BalanceLetra { get; set; }

		public string Moneda { get; set; }

		public string Siglas { get; set; }

		public string EncargadaCobros { get; set; }

		public string Cargo { get; set; }

		public string Telefono { get; set; }

		public string Celular { get; set; }
	}
}

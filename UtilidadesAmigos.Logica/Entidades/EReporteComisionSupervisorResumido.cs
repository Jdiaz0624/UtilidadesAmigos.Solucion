using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EReporteComisionSupervisorResumido
    {
		public System.Nullable<decimal> IdUsuario { get; set; }

		public string GeneradoPor { get; set; }

		public System.Nullable<System.DateTime> FechaDesde0 { get; set; }

		public string ValidadoDesde { get; set; }

		public System.Nullable<System.DateTime> FechaHasta0 { get; set; }

		public string ValidadoHasta { get; set; }

		public System.Nullable<int> CodigoSupervisor { get; set; }

		public string Supervisor { get; set; }

		public string Oficina { get; set; }

		public System.Nullable<decimal> F_EMISION { get; set; }

		public System.Nullable<decimal> F_RENOVACION { get; set; }

		public System.Nullable<decimal> EMISION { get; set; }

		public System.Nullable<decimal> RENOVACION { get; set; }

		public System.Nullable<decimal> ComisionPagar { get; set; }
	}
}

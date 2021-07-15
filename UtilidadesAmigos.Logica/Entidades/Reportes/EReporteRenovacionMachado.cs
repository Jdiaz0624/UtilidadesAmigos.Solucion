using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EReporteRenovacionMachado
    {
		public System.Nullable<decimal> IdSupervisor { get; set; }

		public string Supervisor { get; set; }

		public string Oficina { get; set; }

		public System.Nullable<int> CantidadRenovar { get; set; }

		public System.Nullable<decimal> MontoRenovar { get; set; }

		public System.Nullable<int> CantidadRenovada { get; set; }

		public System.Nullable<decimal> MontoRenovado { get; set; }

		public System.Nullable<decimal> Cobrado { get; set; }

		public string Porcentaje { get; set; }
	}
}

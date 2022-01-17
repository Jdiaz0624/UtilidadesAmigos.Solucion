using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EEstadisticaRenovacionAgrupada
    {
		public string Entidad {get;set;}

		public System.Nullable<int> CantidadRenovaciones {get;set;}

		public System.Nullable<decimal> MontoRenovaciones {get;set;}

		public System.Nullable<int> CantidadRenovadas {get;set;}

		public System.Nullable<decimal> MontoRenovado {get;set;}

		public System.Nullable<int> CantidadCanceladas {get;set;}

		public System.Nullable<decimal> MontoCancelado {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<int> CantidadSinProcesar {get;set;}

		public System.Nullable<decimal> MontoSinRenovar {get;set;}
		public string ValidadoDesde { get; set; }

		public string ValidadoHasta { get; set; }

		public string GeneradoPor { get; set; }
	}
}

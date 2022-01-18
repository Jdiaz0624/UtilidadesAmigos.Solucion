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

		public int? Codigo {get;set;}

		public string ExcluirMotores {get;set;}

		public string ValidadoDesde {get;set;}

		public string ValidadoHasta {get;set;}

		public string GeneradoPor {get;set;}

		public System.Nullable<int> CantidadARenovar {get;set;}

		public System.Nullable<decimal> MontoARenovar {get;set;}

		public System.Nullable<int> CantidadRenovadas {get;set;}

		public System.Nullable<decimal> MontoRenovado {get;set;}

		public System.Nullable<int> CantidadCanceladas {get;set;}

		public System.Nullable<decimal> MontoCancelado {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<int> CantidadPendiente {get;set;}

		public System.Nullable<decimal> MontoPendienteRenovar {get;set;}
	}
}

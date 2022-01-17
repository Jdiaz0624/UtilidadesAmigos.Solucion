using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EEstadisticaRenovacionOrigen
    {
		public decimal? Cotizacion {get;set;}

		public int? Secuencia {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public int? CodigoRamo {get;set;}

		public string NombreRamo {get;set;}

		public int? CodigoSubramo {get;set;}

		public string NombreSubramo {get;set;}

		public System.Nullable<decimal> Bruto {get;set;}

		public System.Nullable<System.DateTime> FechaInicioVigencia {get;set;}

		public System.Nullable<System.DateTime> FechaFinVigencia {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public System.Nullable<int> CodigoSupervisor {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}
		public System.Nullable<int> CantidadRenovadas { get; set; }

		public System.Nullable<decimal> MontoRenovado { get; set; }

		public System.Nullable<int> CantidadCanceladas { get; set; }

		public System.Nullable<decimal> MontoCancelado { get; set; }

		public System.Nullable<decimal> Cobrado { get; set; }

		public System.Nullable<System.DateTime> ValidadoDesde {get;set;}

		public System.Nullable<System.DateTime> ValidadoHasta {get;set;}
	}
}

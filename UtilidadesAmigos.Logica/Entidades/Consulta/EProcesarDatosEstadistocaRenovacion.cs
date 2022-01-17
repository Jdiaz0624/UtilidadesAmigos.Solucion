using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EProcesarDatosEstadistocaRenovacion
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public System.Nullable<decimal> Cotizacion {get;set;}

		public System.Nullable<int> Secuencia {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public System.Nullable<int> CodigoRamo {get;set;}

		public string NombreRamo {get;set;}

		public System.Nullable<int> CodigoSubRamo {get;set;}

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
		public System.Nullable<bool> ExcluirMotores { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EDetalleEstadisticaRenovacion
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public string GeneradoPor {get;set;}

		public System.Nullable<decimal> Cotizacion {get;set;}

		public System.Nullable<int> Secuencia {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public string Oficina {get;set;}

		public System.Nullable<int> CodigoRamo {get;set;}

		public string NombreRamo {get;set;}

		public System.Nullable<int> CodigoSubRamo { get; set; }

		public string NombreSubramo {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public System.Nullable<System.DateTime> FechaInicioVigencia { get; set; }

		public System.Nullable<System.DateTime> FechaFinVigencia1 {get;set;}

		public string InicioVigencia {get;set;}

		public string FinVigencia {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public string Intermediario {get;set;}

		public System.Nullable<int> CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}

		public string Cliente {get;set;}

		public string TelefonoResidencia {get;set;}

		public string TelefonoOficina {get;set;}

		public string Celular {get;set;}

		public string fax {get;set;}

		public string Renovada {get;set;}

		public System.Nullable<decimal> MontoRenovado {get;set;}

		public string Cancelada {get;set;}

		public System.Nullable<decimal> MontoCancelado {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<System.DateTime> ValidadoDesde {get;set;}

		public System.Nullable<System.DateTime> ValidadoHasta {get;set;}
	}
}

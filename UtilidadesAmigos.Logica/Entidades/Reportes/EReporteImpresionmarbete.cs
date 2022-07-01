using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EReporteImpresionmarbete
    {
		public string Poliza {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public string UltimoMovimiento {get;set;}

		public string FechaMovimiento {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}

		public string Cliente {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public int CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public string Intermediario {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public string Oficina {get;set;}

		public int CodigoRamo {get;set;}

		public string Ramo {get;set;}

		public int CodigoSubRamo {get;set;}

		public string Ramo1 {get;set;}

		public decimal Cotizacion {get;set;}

		public System.DateTime Fecha {get;set;}

		public string FechaImpresion {get;set;}

		public string HoraImpresion {get;set;}

		public string Usuario {get;set;}

		public string ValidadoDesde {get;set;}

		public string ValidadoHasta {get;set;}

		public string GeneradoPor {get;set;}
		public System.Nullable<int> CantidadImpresiones { get; set; }
	}
}

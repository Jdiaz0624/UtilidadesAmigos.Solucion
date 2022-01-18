using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EMostrarDataCargadaEstadisticaRenovacion
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public string GeneradoPor {get;set;}

		public System.Nullable<decimal> Cotizacion {get;set;}

		public string Poliza {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public string Oficina {get;set;}

		public System.Nullable<int> Ramo {get;set;}

		public string NombreRamo {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public string Intermediario {get;set;}

		public System.Nullable<int> CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public System.Nullable<System.DateTime> ValidadoDesde0 {get;set;}

		public System.Nullable<System.DateTime> ValidadoHasta0 {get;set;}

		public string ValidadoDesde {get;set;}

		public string ValidadoHasta {get;set;}

		public System.Nullable<int> CantidadRenovadas {get;set;}

		public System.Nullable<decimal> MontoRenovado {get;set;}

		public int CantidadCanceladas {get;set;}

		public System.Nullable<decimal> MontoCancelado {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}
	}
}

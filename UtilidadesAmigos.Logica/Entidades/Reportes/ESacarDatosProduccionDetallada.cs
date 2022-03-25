using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class ESacarDatosProduccionDetallada
    {
		public string Poliza {get;set;}

		public System.Nullable<int> CodigoRamo {get;set;}

		public string Ramo {get;set;}

		public System.Nullable<int> CodigoSubramo {get;set;}

		public string SubRamo {get;set;}

		public System.Nullable<decimal> Cliente {get;set;}

		public string NombreCliente {get;set;}

		public System.Nullable<int> Vendedor {get;set;}

		public string NombreVendedor {get;set;}

		public int? CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public string Usuario {get;set;}

		public System.Nullable<int> Oficina {get;set;}

		public string NombreOficina {get;set;}

		public System.Nullable<System.DateTime> Fecha {get;set;}

		public string FechaFactura {get;set;}

		public string HoraFactura {get;set;}

		public string Ncf {get;set;}

		public System.Nullable<decimal> MontoBruto {get;set;}

		public System.Nullable<decimal> ISC {get;set;}

		public System.Nullable<decimal> MontoNeto {get;set;}

		public System.Nullable<int> CodMoneda {get;set;}
		public string Moneda { get; set; }

		public decimal? Factura {get;set;}

		public int? Tipo {get;set;}

		public string NumeroFactura {get;set;}

		public string Concepto {get;set;}

		public string GeneradoPor {get;set;}

		public string FechaDesde {get;set;}

		public string FechaHasta {get;set;}
	}
}

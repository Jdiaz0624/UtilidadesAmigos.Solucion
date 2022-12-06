using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EReporteEstadisticaPolizasSinPagos
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<decimal> NumeroFactura {get;set;}

		public System.Nullable<int> Tipo {get;set;}

		public System.Nullable<int> CodigoRamo {get;set;}

		public string Ramo {get;set;}

		public System.Nullable<int> CodigoSubRamo {get;set;}

		public string SubRamo {get;set;}

		public System.Nullable<decimal> CodigoAsegurado {get;set;}

		public string NombreAsegurado {get;set;}

		public System.Nullable<int> CodigoVendedor {get;set;}

		public string NombreVendedor {get;set;}

		public System.Nullable<int> CodigoSupervisor {get;set;}

		public string NombreSupervisor {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public string NombreOficina {get;set;}

		public System.Nullable<System.DateTime> Fecha {get;set;}

		public string FechaFormateada {get;set;}

		public string Hora {get;set;}

		public System.Nullable<int> DiasTranscurridos {get;set;}

		public string Ncf {get;set;}

		public System.Nullable<decimal> MontoBruto {get;set;}

		public System.Nullable<decimal> ISC {get;set;}

		public System.Nullable<decimal> MontoNeto {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<int> CodMoneda {get;set;}

		public string Moneda {get;set;}

		public string Siglas {get;set;}

		public string Concepto {get;set;}

		public System.Nullable<int> CodigoEstatus { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProcesarInformacionComisionesSupervisores
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<decimal> Recibo {get;set;}

		public string ConceptoPago {get;set;}

		public string ReciboFormateado {get;set;}

		public string Anulado {get;set;}

		public System.Nullable<System.DateTime> FechaPago {get;set;}

		public string FechaPagoFormateado {get;set;}

		public string TipoPago {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}

		public string NombreCliente {get;set;}

		public System.Nullable<decimal> CodigoIntermediario {get;set;}

		public string NombreIntermediario {get;set;}

		public System.Nullable<decimal> CodigoSupervisor {get;set;}

		public string NombreSupervisor {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public string NombreOficina {get;set;}

		public string Usuario {get;set;}

		public System.Nullable<int> CodigoRamo {get;set;}

		public string DescripcionRamo {get;set;}

		public System.Nullable<int> CodigoMoneda {get;set;}

		public string DescripcionMoneda {get;set;}

		public System.Nullable<decimal> Bruto {get;set;}

		public System.Nullable<decimal> Impuesto {get;set;}

		public System.Nullable<decimal> Neto {get;set;}

		public System.Nullable<decimal> Tasa {get;set;}

		public System.Nullable<decimal> Pesos {get;set;}

		public string ConceptoFactura {get;set;}

		public System.Nullable<decimal> PorcientoComisionIntermediario {get;set;}

		public string ValidadoDesde {get;set;}

		public string ValidadoHasta {get;set;}
	}
}

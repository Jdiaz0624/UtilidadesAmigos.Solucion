using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProcesarInformacionDataCobrado
    {
		public System.Nullable<decimal> CodigoBeneficiario {get;set;}

		public System.Nullable<decimal> PorcientoComisionBeneficiario {get;set;}

		public System.Nullable<decimal> IdUsuarioProcesa {get;set;}

		public System.Nullable<System.DateTime> FechaValidadoDesde {get;set;}

		public System.Nullable<System.DateTime> FechaValidadoHasta {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<decimal> NumeroRecibo {get;set;}

		public string Concepto {get;set;}

		public string NumeroReciboFormateado {get;set;}

		public string TipoPago {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}

		public string NombreCliente {get;set;}

		public System.Nullable<decimal> CodigoIntermediario {get;set;}

		public string NombreIntermediario {get;set;}

		public System.Nullable<decimal> CodigoSupervisor {get;set;}

		public string NombreSupervisor {get;set;}

		public System.Nullable<decimal> CodigoOficina {get;set;}

		public string NombreOficina {get;set;}

		public System.Nullable<decimal> CodigoRamo {get;set;}

		public string NombreRamo {get;set;}

		public System.Nullable<decimal> CodigoMoneda {get;set;}

		public string NombreMoneda {get;set;}

		public System.Nullable<decimal> Bruto {get;set;}

		public System.Nullable<decimal> Impuesto {get;set;}

		public System.Nullable<decimal> Neto {get;set;}

		public System.Nullable<decimal> Tasa {get;set;}

		public System.Nullable<decimal> MontoPesos {get;set;}
	}
}

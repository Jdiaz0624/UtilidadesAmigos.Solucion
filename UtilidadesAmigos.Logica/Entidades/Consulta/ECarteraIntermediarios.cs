using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class ECarteraIntermediarios
    {
		public string Poliza {get;set;}

		public string EstatusPoliza {get;set;}

		public System.Nullable<decimal> SumaAsegurada {get;set;}

		public System.Nullable<int> Intermediario {get;set;}

		public string NombreVendedor {get;set;}

		public System.Nullable<byte> Estatus {get;set;}

		public string EstatusIntermediario {get;set;}

		public System.Nullable<decimal> Facturado {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<decimal> Balance {get;set;}

		public System.Nullable<int> PolizasActivas {get;set;}

		public System.Nullable<int> PolizasCanceladas {get;set;}
	}
}

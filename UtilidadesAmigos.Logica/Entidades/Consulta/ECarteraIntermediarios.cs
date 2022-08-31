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
		public System.Nullable<decimal> CodigoCliente { get; set; }

		public string Cliente { get; set; }

		public System.Nullable<int> Intermediario {get;set;}

		public string NombreVendedor {get;set;}

		public System.Nullable<byte> Estatus {get;set;}

		public string EstatusIntermediario {get;set;}

		public string Direccion { get; set; }

		public string Ubicacion { get; set; }

		public string Telefono { get; set; }

		public string Telefono1 { get; set; }

		public string TelefonoOficina { get; set; }

		public string Celular { get; set; }

		public string Fax { get; set; }

		public string Beeper { get; set; }

		public System.Nullable<decimal> Facturado {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<decimal> Balance {get;set;}

		public System.Nullable<int> PolizasActivas {get;set;}

		public System.Nullable<int> PolizasCanceladas {get;set;}

		public System.Nullable<int> PolizasTransito {get;set;}

		public System.Nullable<int> PolizasExclusion {get;set;}
	}
}

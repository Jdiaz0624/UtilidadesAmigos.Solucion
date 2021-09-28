using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EValidarPoliza
    {
		public byte Compania {get;set;}

		public decimal Cotizacion {get;set;}

		public System.Nullable<decimal> Cliente {get;set;}

		public System.Nullable<int> Intermediario {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<decimal> MontoNeto {get;set;}

		public string UsuarioAdiciona {get;set;}

		public System.Nullable<System.DateTime> FechaAdiciona {get;set;}

		public string UsuarioModifica {get;set;}

		public System.Nullable<System.DateTime> FechaModifica {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<int> Ramo {get;set;}

		public string Hora {get;set;}

		public System.Nullable<decimal> SumaAsegurada {get;set;}

		public System.Nullable<decimal> Deudor {get;set;}

		public System.Nullable<int> CodMoneda {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public string Observacion {get;set;}

		public System.Nullable<decimal> PorcComision {get;set;}

		public System.Nullable<int> Oficina {get;set;}
	}
}

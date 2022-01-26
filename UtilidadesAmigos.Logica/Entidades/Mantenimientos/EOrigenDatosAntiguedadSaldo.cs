using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EOrigenDatosAntiguedadSaldo
    {
		public string Poliza {get;set;}

		public decimal? Cotizacion {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}

		public int? CodigoIntermediario {get;set;}

		public int? CodigoSupervisor {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public System.Nullable<int> CodigoMoneda {get;set;}

		public System.Nullable<int> CodigoRamo {get;set;}

		public System.Nullable<decimal> Valor {get;set;}

		public decimal? NumeroFactura {get;set;}

		public System.Nullable<decimal> Balance {get;set;}

		public int? Tipo {get;set;}

		public System.Nullable<System.DateTime> Fecha {get;set;}

		public System.Nullable<System.DateTime> FechaCorte {get;set;}

		public System.Nullable<decimal> UsuarioGenera {get;set;}
	}
}

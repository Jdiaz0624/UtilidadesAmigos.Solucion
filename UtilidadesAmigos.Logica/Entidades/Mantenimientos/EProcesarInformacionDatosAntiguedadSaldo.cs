using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EProcesarInformacionDatosAntiguedadSaldo
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<decimal> Cotizacion {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public System.Nullable<int> CodigoSupervisor {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public System.Nullable<int> CodigoMoneda {get;set;}

		public System.Nullable<int> CodigoRamo {get;set;}

		public System.Nullable<decimal> Valor {get;set;}

		public System.Nullable<decimal> NumeroFactura {get;set;}

		public System.Nullable<decimal> Balance {get;set;}

		public System.Nullable<int> Tipo {get;set;}

		public System.Nullable<System.DateTime> Fecha {get;set;}

		public System.Nullable<System.DateTime> FechaCorte {get;set;}
	}
}

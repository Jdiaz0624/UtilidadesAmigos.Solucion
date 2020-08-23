using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscarCoberturasPoliza
    {
		public string Poliza {get;set;}

		public decimal? Cotizacion {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public string InicioVigencia {get;set;}

		public string FinVigencia {get;set;}

		public int? SecuenciaCot {get;set;}

		public int? Secuencia {get;set;}

		public string Descripcion {get;set;}

		public string MontoInformativo {get;set;}

		public System.Nullable<decimal> PorcDeducible {get;set;}

		public System.Nullable<decimal> MinimoDeducible {get;set;}

		public System.Nullable<decimal> PorcCobertura {get;set;}
	}
}

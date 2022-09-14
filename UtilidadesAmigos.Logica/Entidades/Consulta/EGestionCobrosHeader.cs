using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EGestionCobrosHeader
    {
		public string Poliza {get;set;}
		public decimal? Factura { get; set; }
		public System.Nullable<int> Comentarios { get; set; }

		public System.Nullable<decimal> Facturado {get;set;}

		public System.Nullable<decimal> Cobrado {get;set;}

		public System.Nullable<decimal> Balance {get;set;}

		public System.Nullable<int> CantidadDias {get;set;}

		public System.Nullable<decimal> SA010 {get;set;}

		public System.Nullable<decimal> SA1130 {get;set;}

		public System.Nullable<decimal> SA3160 {get;set;}

		public System.Nullable<decimal> SA6190 {get;set;}

		public System.Nullable<decimal> SA91120 {get;set;}

		public System.Nullable<decimal> SA121MAS {get;set;}
	}
}

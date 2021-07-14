using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProcesarInformacionPolizasRenovadas
    {
		public System.Nullable<decimal> IdIntermediario {get;set;}

		public System.Nullable<decimal> IdSupervisor {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<int> Ramo {get;set;}

		public System.Nullable<int> SubRamo {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public System.Nullable<System.DateTime> InicioVigencia {get;set;}

		public System.Nullable<System.DateTime> FinVigencia {get;set;}

		public System.Nullable<System.DateTime> FechaProceso {get;set;}

		public System.Nullable<int> CodigoMes {get;set;}

		public System.Nullable<int> CodigoAno {get;set;}

		public System.Nullable<decimal> CobradoMes {get;set;}

		public System.Nullable<decimal> FacturadoTotal {get;set;}

		public System.Nullable<decimal> CobradoTotal {get;set;}

		public System.Nullable<decimal> BalanceTotal {get;set;}
	}
}

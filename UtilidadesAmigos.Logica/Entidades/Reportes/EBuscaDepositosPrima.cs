using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscaDepositosPrima
    {
		public decimal? NumeroDeposito {get;set;}

		public string Fecha {get;set;}

		public int? CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public int? CodigoIntermediario {get;set;}

		public string Intermediario {get;set;}

		public System.Nullable<decimal> MontoPagado {get;set;}

		public System.Nullable<decimal> MontoDeposito {get;set;}

		public System.Nullable<decimal> MontoPrima {get;set;}

		public string Estatus {get;set;}

		public string GeneradoPor {get;set;}
	}
}

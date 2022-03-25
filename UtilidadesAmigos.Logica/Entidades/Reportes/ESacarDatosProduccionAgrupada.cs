using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class ESacarDatosProduccionAgrupada
    {
		public string Entidad {get;set;}

		public System.Nullable<int> CodMoneda {get;set;}

		public string Moneda {get;set;}

		public System.Nullable<decimal> MontoBruto {get;set;}

		public System.Nullable<decimal> ISC {get;set;}

		public System.Nullable<decimal> MontoNeto {get;set;}
	}
}

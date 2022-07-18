using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EProcesoEmisionDetail
    {
		public string NumeroConector {get;set;}

		public System.Nullable<int> Secuencia {get;set;}

		public System.Nullable<int> IdEstatusProcesoEmison {get;set;}

		public System.Nullable<System.DateTime> Fecha {get;set;}

		public System.Nullable<decimal> IdUsuario {get;set;}
	}
}

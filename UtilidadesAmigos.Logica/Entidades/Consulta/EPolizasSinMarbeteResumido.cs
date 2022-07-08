using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EPolizasSinMarbeteResumido
    {
		public string Mes {get;set;}

		public int? CodigoRamo {get;set;}

		public int? CodigoSubramo {get;set;}

		public string Ramo {get;set;}

		public string SubRamo {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public string Oficina {get;set;}

		public System.Nullable<int> Cantidad {get;set;}

		public string GeneradoPor {get;set;}
	}
}

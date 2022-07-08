using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EPolizasSInMarbeteDetallado
    {
		public string Poliza {get;set;}

		public decimal Cotizacion {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public string Estatus {get;set;}

		public string InicioVigencia {get;set;}

		public string FinVigencia {get;set;}

		public int? CodigoSupervisor {get;set;}

		public int? CodigoIntermediario {get;set;}

		public string Supervisor {get;set;}

		public string Intermediario {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public string Oficina {get;set;}

		public string UsuarioAdiciona {get;set;}

		public System.Nullable<System.DateTime> FechaCreado {get;set;}

		public string FechaCreadoFormateada {get;set;}

		public string HoraCreadoFormateada {get;set;}

		public System.Nullable<int> CodigoAno {get;set;}

		public System.Nullable<int> CodigoMes {get;set;}

		public string Mes {get;set;}

		public int? CodigoRamo {get;set;}

		public string Ramo {get;set;}

		public int? CodigoSubramo {get;set;}

		public string SubRamo {get;set;}

		public string GeneradoPor {get;set;}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EProcesarDatosEstadistocaRenovacion
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public System.Nullable<decimal> Cotizacion {get;set;}

		public string Poliza {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<int> CodigoOficina {get;set;}

		public System.Nullable<int> Ramo {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public System.Nullable<int> CodigoSupervisor {get;set;}

		public System.Nullable<System.DateTime> ValidadoDesde {get;set;}

		public System.Nullable<System.DateTime> ValidadoHasta {get;set;}
		public System.Nullable<bool> ExcluirMotores { get; set; }
	}
}

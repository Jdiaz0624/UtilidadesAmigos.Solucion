using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EAsignacionTarjetas
    {
		public decimal? IdRegistro {get;set;}

		public System.Nullable<decimal> CodigoCliente {get;set;}

		public string Cliente {get;set;}

		public System.Nullable<int> IdEstatus {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<System.DateTime> Fecha0 {get;set;}

		public string Fecha {get;set;}

		public string Hora {get;set;}
	}
}

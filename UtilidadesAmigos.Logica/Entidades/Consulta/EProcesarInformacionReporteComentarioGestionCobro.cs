using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EProcesarInformacionReporteComentarioGestionCobro
    {
		public System.Nullable<decimal> NumeroRegistro {get;set;}

		public string Poliza {get;set;}

		public string Comentario {get;set;}

		public System.Nullable<decimal> IdUsuario {get;set;}

		public string Usuario {get;set;}

		public System.Nullable<System.DateTime> FechaProceso {get;set;}

		public string Fecha {get;set;}

		public string Hora {get;set;}

		public System.Nullable<int> CantidadRegistros {get;set;}

		public System.Nullable<decimal> IdUsuarioGenera {get;set;}
	}
}

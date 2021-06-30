using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.SuperIntendencia
{
    public class EProcesarDataResultadoBusquedaPersonaSuperIntendencia
    {
		public System.Nullable<decimal> IdUsuario {get;set;}

		public string Nombre {get;set;}

		public string NumeroIdentificacion {get;set;}

		public string Poliza {get;set;}

		public string Reclamacion {get;set;}

		public string Estatus {get;set;}

		public string Ramo {get;set;}

		public System.Nullable<decimal> MontoAsegurado {get;set;}

		public System.Nullable<decimal> Prima {get;set;}

		public System.Nullable<System.DateTime> InicioVigencia {get;set;}

		public System.Nullable<System.DateTime> FinVigencia {get;set;}

		public string TipoBusqueda {get;set;}

		public string EncontradoComo {get;set;}

		public string Comentario {get;set;}
	}
}

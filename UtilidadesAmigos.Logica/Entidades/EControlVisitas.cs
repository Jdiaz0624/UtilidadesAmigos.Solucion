using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EControlVisitas
    {
		public System.Nullable<decimal> NoRegistro {get;set;}

		public System.Nullable<int> IdTipoProcesoRecepcion {get;set;}

		public string TipoProceso {get;set;}

		public string Nombre {get;set;}

		public string Remitente {get;set;}

		public string Destinatario {get;set;}

		public string NumeroIdentificacion {get;set;}

		public System.Nullable<int> CantidadDocumentos {get;set;}

		public System.Nullable<int> CantidadPersonas {get;set;}

		public System.Nullable<decimal> UsuarioDigita {get;set;}

		public string DigitadoPor {get;set;}

		public System.Nullable<System.DateTime> FechaDigita0 {get;set;}

		public string FechaDigita {get;set;}

		public string HoraDigita {get;set;}

		public System.Nullable<decimal> UsuarioModifica {get;set;}

		public string Modificado {get;set;}

		public System.Nullable<System.DateTime> FechaModifica0 {get;set;}

		public string HoraModifica {get;set;}

		public string FechaModifica {get;set;}

		public string Comentario {get;set;}

		public string GeneradoPor {get;set;}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EComentariosGestionCobrosAntigueadSaldo
    {
		public decimal? NumeroRegistro {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<int> IdEstatusLlamada {get;set;}

		public string EstatusLlamada {get;set;}

		public System.Nullable<int> IdConceptoLlamada {get;set;}

		public string ConceptoLlamada {get;set;}

		public string Comentario {get;set;}

		public System.Nullable<System.DateTime> FechaNuevaLlamada0 {get;set;}

		public string FechaNuevaLlamada {get;set;}

		public string HoraFechaNuevaLlamada {get;set;}

		public string HoraNuevaLlamada {get;set;}

		public System.Nullable<decimal> CodigoUsuario {get;set;}
		public string Usuario { get; set; }

		public System.Nullable<System.DateTime> FechaProceso0 {get;set;}

		public string FechaProceso {get;set;}

		public string HoraFechaProceso {get;set;}

		public string ValidadoDesde {get;set;}

		public string ValidadoHasta {get;set;}

		public string GeneradoPor {get;set;}

		public System.Nullable<int> CantidadRegistros {get;set;}
	}
}

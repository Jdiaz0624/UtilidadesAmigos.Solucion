using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EPolizasAvisoGestionCobros
    {
		public decimal? NumeroRegistro {get;set;}

		public string Poliza {get;set;}

		public System.Nullable<int> IdEstatusLlamada {get;set;}

		public string EstatusLlamada {get;set;}

		public System.Nullable<int> IdConceptoLlamada {get;set;}

		public string ConceptoLlamada {get;set;}

		public string Comentario {get;set;}

		public System.Nullable<decimal> IdUsuario {get;set;}

		public string Usuario {get;set;}

		public System.Nullable<System.DateTime> FechaGuardado {get;set;}

		public string Fecha {get;set;}

		public string Hora {get;set;}

		public string InicioVigencia {get;set;}

		public string FinVigencia {get;set;}

		public System.Nullable<bool> Estatus0 {get;set;}

		public string Estatus {get;set;}

		public System.Nullable<int> CantidadRegistrosNoProcesados {get;set;}

		public System.Nullable<int> CantidadRegistrosProcesados {get;set;}

		public System.Nullable<int> CantidadRegistrosNoProcesadosParametros {get;set;}

		public System.Nullable<int> CantidadRegistrosProcesadosParametros {get;set;}
	}
}

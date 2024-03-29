﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EGenerarReporteCobroFinal
    {
		public decimal? ID {get;set;}

		public string Poliza {get;set;}

		public string Comentario {get;set;}

		public System.Nullable<decimal> IdUsuario {get;set;}

		public string CreadoPor {get;set;}

		public System.Nullable<System.DateTime> FechaProceso {get;set;}

		public string Fecha {get;set;}

		public string Hora {get;set;}

		public System.Nullable<int> IdEstatusLlamada {get;set;}

		public string EstatusLlamada {get;set;}

		public System.Nullable<int> IdConceptoLlamada {get;set;}

		public string ConceptoLlamada {get;set;}

		public string FechaFinVigencia {get;set;}

		public System.Nullable<decimal> NumeroSeguimiento {get;set;}

		public string ValidadoDesde {get;set;}

		public string ValidadoHAsta {get;set;}

		public System.Nullable<bool> NoLLevaRangoFecha0 {get;set;}

		public string NoLlevaRangoFecha {get;set;}

		public string GeneradoPor {get;set;}
	}
}

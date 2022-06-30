using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EReciboDigital
    {
		public decimal? NumeroRecibo { get; set; }

		public System.Nullable<int> CodigoIntermediario { get; set; }

		public string Intermediario { get; set; }

		public int? CodigoSupervisor { get; set; }

		public string NombreIntermediario { get; set; }

		public System.Nullable<System.DateTime> FechaRecibo0 { get; set; }

		public string Fecha { get; set; }

		public string Hora { get; set; }

		public System.Nullable<decimal> ValorRecibo { get; set; }

		public string ValorReciboLetra { get; set; }

		public System.Nullable<int> IdTipoPago { get; set; }

		public string TipoPago { get; set; }

		public string Detalle { get; set; }

		public System.Nullable<decimal> CreadoPor0 { get; set; }

		public string CreadoPor { get; set; }

		public int? IdOficina { get; set; }

		public string Oficina { get; set; }

		public string GeneradoPor { get; set; }
	}
}

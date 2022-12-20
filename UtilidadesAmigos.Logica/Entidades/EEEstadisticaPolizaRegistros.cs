using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EEEstadisticaPolizaRegistros
    {
		public string Poliza { get; set; }

		public string InicioVigencia { get; set; }

		public string FinVigencia { get; set; }

		public decimal? Numero { get; set; }

		public int? Tipo { get; set; }

		public System.Nullable<int> CodigoRamo { get; set; }

		public string Ramo { get; set; }

		public System.Nullable<int> CodigoSubRamo { get; set; }

		public string SubRamo { get; set; }

		public System.Nullable<decimal> CodigoAsegurado { get; set; }

		public string Asegurado { get; set; }

		public System.Nullable<int> CodigoVendedor { get; set; }

		public string Vendedor { get; set; }

		public int? CodigoSupervisor { get; set; }

		public string Supervisor { get; set; }

		public System.Nullable<int> Codigooficina { get; set; }

		public string Oficina { get; set; }

		public System.Nullable<System.DateTime> Fecha0 { get; set; }

		public string Fecha { get; set; }

		public string Hora { get; set; }

		public System.Nullable<int> DiasTranscurridos { get; set; }

		public string Ncf { get; set; }

		public System.Nullable<decimal> MontoBruto { get; set; }

		public System.Nullable<decimal> ISC { get; set; }

		public System.Nullable<decimal> MontoNeto { get; set; }

		public System.Nullable<decimal> Cobrado { get; set; }

		public System.Nullable<decimal> Balance { get; set; }

		public System.Nullable<int> CodMoneda { get; set; }

		public string Moneda { get; set; }

		public string Siglas { get; set; }

		public string Concepto { get; set; }
	}
}

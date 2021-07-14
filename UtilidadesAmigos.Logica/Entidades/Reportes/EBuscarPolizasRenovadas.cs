using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscarPolizasRenovadas
    {
		public System.Nullable<int> CodigoIntermediario;

		public int CodigoSupervisor { get; set; }

		public string Poliza { get; set; }

		public int Ramo { get; set; }

		public int SubRamo { get; set; }

		public System.Nullable<decimal> Prima { get; set; }

		public System.Nullable<System.DateTime> FechaInicioVigencia { get; set; }

		public System.Nullable<System.DateTime> FechaFinVigencia { get; set; }

		public System.Nullable<System.DateTime> Fecha { get; set; }

		public System.Nullable<int> Mes { get; set; }

		public System.Nullable<int> Ano { get; set; }

		public System.Nullable<decimal> Cobrado { get; set; }

		public System.Nullable<decimal> FacturadoTotal { get; set; }

		public System.Nullable<decimal> CobradoTotal { get; set; }

		public System.Nullable<decimal> BalanceTotal { get; set; }
	}
}

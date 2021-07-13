using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProcesarInformacionPolizasARenovar
    {
		public System.Nullable<decimal> IdIntermediario { get; set; }

		public System.Nullable<decimal> IdSupervisor { get; set; }

		public string Poliza { get; set; }

		public System.Nullable<int> Ramo { get; set; }

		public System.Nullable<int> SubRamo { get; set; }

		public System.Nullable<decimal> Prima { get; set; }

		public System.Nullable<System.DateTime> InicioVigencia { get; set; }

		public System.Nullable<System.DateTime> FinVigencia { get; set; }

		public System.Nullable<int> CodigoMes { get; set; }

		public System.Nullable<int> CodigoAno { get; set; }

		public System.Nullable<decimal> Facturado { get; set; }

		public System.Nullable<decimal> Cobrado { get; set; }

		public System.Nullable<decimal> Balance { get; set; }

		public System.Nullable<System.DateTime> FechaDesdeFiltro { get; set; }

		public System.Nullable<System.DateTime> FechaHastaFiltro { get; set; }
	}
}

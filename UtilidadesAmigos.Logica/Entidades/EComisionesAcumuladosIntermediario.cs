using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EComisionesAcumuladosIntermediario
    {
		public System.Nullable<int> CodigoIntermediario { get; set; }

		public string Intermediario { get; set; }

		public string Oficina { get; set; }

		public System.Nullable<decimal> ValorReciboBruto { get; set; }

		public System.Nullable<decimal> ValorReciboNeto { get; set; }

		public System.Nullable<decimal> ComisionGenerada { get; set; }

		public System.Nullable<decimal> Retencion { get; set; }

		public System.Nullable<decimal> AvanceComision { get; set; }

		public System.Nullable<decimal> Aliquidar { get; set; }

		public string GeneraCheque { get; set; }

		public System.Nullable<int> CantiadRegistros { get; set; }
	}
}

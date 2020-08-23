using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EModificarCoberturasPolizas
    {
		public System.Nullable<int> Compania { get; set; }

		public System.Nullable<decimal> Cotizacion { get; set; }

		public System.Nullable<int> Ramo { get; set; }

		public System.Nullable<int> SubRamo { get; set; }

		public System.Nullable<int> SecuenciaCot { get; set; }

		public System.Nullable<int> Secuencia { get; set; }

		public string Descripcion { get; set; }

		public string MontoInformativo { get; set; }

		public System.Nullable<char> TieneCobertura { get; set; }

		public System.Nullable<decimal> Porciento { get; set; }

		public System.Nullable<decimal> Prima { get; set; }

		public System.Nullable<decimal> PorcDeducible { get; set; }

		public System.Nullable<decimal> MinimoDeducible { get; set; }

		public string Endoso { get; set; }

		public System.Nullable<decimal> PorcCobertura { get; set; }

		public System.Nullable<decimal> ValorServicio { get; set; }
	}
}

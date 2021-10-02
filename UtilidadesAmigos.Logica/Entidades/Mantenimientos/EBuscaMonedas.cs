using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EBuscaMonedas
    {
		public int? Codigo { get; set; }

		public string Descripcion { get; set; }

		public string Sigla { get; set; }

		public System.Nullable<decimal> Tasa { get; set; }

		public System.Nullable<decimal> PrimaCobrar { get; set; }
	}
}

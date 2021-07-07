using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscaBeneficiariosSobreComisiones
    {
		public decimal? IdBeneficiarioSobreComision { get; set; }

		public System.Nullable<decimal> CodigoBeneficiario { get; set; }

		public string NombreVendedor { get; set; }

		public System.Nullable<decimal> PorcientoComision { get; set; }

		public string Comision { get; set; }

		public string Ingreso { get; set; }

		public string Estatus { get; set; }
	}
}

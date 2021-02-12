using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EProcesarChequesInformacionImprimir
    {
		public System.Nullable<decimal> IdUsuarioProcesa { get; set; }

		public System.Nullable<decimal> NumeroCheque { get; set; }

		public System.Nullable<System.DateTime> FechaCheque { get; set; }

		public string ConceptoCheque { get; set; }

		public System.Nullable<decimal> ValorCheque { get; set; }

		public string Beneficiario { get; set; }

		public string MontoChqeueLetras { get; set; }

		public string DiaCheque { get; set; }

		public string MesCheque { get; set; }

		public string AnoCheque { get; set; }
	}
}

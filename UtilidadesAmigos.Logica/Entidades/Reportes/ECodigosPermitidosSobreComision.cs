using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class ECodigosPermitidosSobreComision
    {
		public decimal? IdRegistro { get; set; }

		public System.Nullable<decimal> CodigoBeneficiario { get; set; }

		public string Beneficiario { get; set; }

		public System.Nullable<decimal> CodigoSupervisor { get; set; }

	    public string Supervisor { get; set; }
	}
}

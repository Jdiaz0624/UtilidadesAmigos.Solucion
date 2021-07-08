using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EReporteSobreComision
    {
		public string NombreSupervisor {get;set;}

		public string NombreMoneda {get;set;}

		public System.Nullable<decimal> CodigoBeneficiario {get;set;}

		public string Beneficiario {get;set;}

		public System.Nullable<decimal> PorcientoComisionBeneficiario {get;set;}

		public System.Nullable<decimal> IdUsuarioProcesa {get;set;}

		public string GeneradoPor {get;set;}

		public System.Nullable<int> Cantidad {get;set;}

		public System.Nullable<decimal> Bruto {get;set;}

		public System.Nullable<decimal> Impuesto {get;set;}

		public System.Nullable<decimal> Neto {get;set;}

		public System.Nullable<decimal> MontoPesos {get;set;}

		public System.Nullable<decimal> ComisionPagar {get;set;}

		public System.Nullable<decimal> TotalCobradoNeto {get;set;}

		public System.Nullable<decimal> TotalPagar {get;set;}

		public string FechaValidadoDesde {get;set;}

		public string FechaValidadoHasta {get;set;}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EMostrarDatosComisionesIntermediariosResumido
    {
		public System.Nullable<int> CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public System.Nullable<int> CodigoIntermediario {get;set;}

		public string Intermediario {get;set;}

		public System.Nullable<decimal> Bruto {get;set;}

		public System.Nullable<decimal> Neto {get;set;}

		public System.Nullable<decimal> PorcientoComision {get;set;}

		public System.Nullable<decimal> Comision {get;set;}

		public System.Nullable<decimal> Retencion {get;set;}

		public System.Nullable<decimal> AvanceComision {get;set;}

		public System.Nullable<decimal> Acumulado {get;set;}

		public System.Nullable<decimal> Aliquidar {get;set;}

		public System.Nullable<decimal> Total {get;set;}

		public string ValidadoDesde {get;set;}

		public string ValidadoHasta {get;set;}

		public string GeneradoPor {get;set;}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class ECartaCancelacionIntermediario
    {
		public string FechaCarta {get;set;}

		public string Oficina {get;set;}

		public int? CodigoSupervisor {get;set;}

		public string Supervisor {get;set;}

		public int? CodigoIntermediario {get;set;}

		public string Intermediario {get;set;}

		public string Referencia {get;set;}

		public System.Nullable<int> CantidadPolizasBalancePendiente {get;set;}

		public System.Nullable<decimal> SumatoriaPolizasBalancePendientePesos {get;set;}

		public string SumatoriaPolizasBalancePendientePesosLetra {get;set;}

		public System.Nullable<decimal> SumatoriaPolizasBalancePendienteDolar {get;set;}

		public string SumatoriaPolizasBalancePendienteDolarLetra {get;set;}

		public string EncargadaCobros {get;set;}

		public string Cargo {get;set;}

		public string Telefono {get;set;}

		public string Celular {get;set;}
	}
}

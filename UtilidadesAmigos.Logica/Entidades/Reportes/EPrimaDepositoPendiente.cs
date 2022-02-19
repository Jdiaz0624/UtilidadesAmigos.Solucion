using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EPrimaDepositoPendiente
    {
		public decimal Numero { get; set; }

		public string Fecha { get; set; }

		public System.Nullable<decimal> Monto { get; set; }

		public string Cuenta { get; set; }

		public int CodigoSupervisor { get; set; }

		public string Supervisor { get; set; }

		public int CodigoIntermediario { get; set; }

		public string Intermediario { get; set; }

		public string Estatus { get; set; }
	}
}

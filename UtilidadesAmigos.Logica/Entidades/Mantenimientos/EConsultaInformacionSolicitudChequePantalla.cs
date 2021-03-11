using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EConsultaInformacionSolicitudChequePantalla
    {
		public System.Nullable<decimal> IdUsuario { get; set; }

		public System.Nullable<int> CodigoIntermediario { get; set; }

		public string NombreIntermediario { get; set; }

		public System.Nullable<int> CodigoBanco { get; set; }

		public string Banco { get; set; }

		public System.Nullable<decimal> Monto { get; set; }

		public System.Nullable<decimal> Acumulado { get; set; }

		public System.Nullable<decimal> Total { get; set; }
	}
}

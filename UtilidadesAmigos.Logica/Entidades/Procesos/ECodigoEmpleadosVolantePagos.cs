using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class ECodigoEmpleadosVolantePagos
    {
		public decimal? IdRegistro { get; set; }

		public System.Nullable<decimal> CodigoEmpleado { get; set; }

		public string Nombre { get; set; }

		public string Correo { get; set; }

		public System.Nullable<bool> EnvioCorreo0 { get; set; }

		public string EnvioCorreo { get; set; }
	}
}

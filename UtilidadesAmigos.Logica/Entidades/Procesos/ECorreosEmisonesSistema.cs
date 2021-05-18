using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class ECorreosEmisonesSistema
    {
		public int? IdCorreo { get; set; }

		public int? IdProceso { get; set; }

		public string Proceso { get; set; }

		public string Correo { get; set; }

		public string Clave { get; set; }

		public System.Nullable<int> Puerto { get; set; }

		public string SMTP { get; set; }
	}
}

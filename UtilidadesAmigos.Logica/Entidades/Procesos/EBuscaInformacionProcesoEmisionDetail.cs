using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EBuscaInformacionProcesoEmisionDetail
    {
		public string NumeroConector { get; set; }

		public int? Secuencia { get; set; }

		public System.Nullable<int> IdEstatusProcesoEmison { get; set; }

		public string Estatus { get; set; }

		public System.Nullable<System.DateTime> Fecha0 { get; set; }

		public string Fecha { get; set; }

		public string Hora { get; set; }

		public System.Nullable<decimal> IdUsuario { get; set; }

		public string CreadoPor { get; set; }
	}
}

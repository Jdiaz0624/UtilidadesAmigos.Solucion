using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class ECarteraEjecutivos
    {
		public int? IdIntermediarioSupervisa { get; set; }

		public string NombreSupervisor { get; set; }

		public int? IdIntermediario { get; set; }

		public string NombreIntermediario { get; set; }

		public System.Nullable<byte> Estatus { get; set; }

		public string EstatusVendedor { get; set; }

		public System.Nullable<int> TotalIntermediarios { get; set; }
	}
}

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

		public string Direccion { get; set; }

		public string Ubicacion { get; set; }

		public string Telefono { get; set; }

		public string Telefono1 { get; set; }

		public string TelefonoOficina { get; set; }

		public string Celular { get; set; }

		public string Fax { get; set; }

		public string Beeper { get; set; }

		public System.Nullable<int> TotalIntermediarios { get; set; }

	}
}

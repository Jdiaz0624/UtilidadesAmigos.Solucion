using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.SuperIntendencia
{
    public class EBuscaPersonasSuperIntendenciaIntermediario
    {
		public int? Codigo { get; set; }

		public System.Nullable<byte> Estatus0 { get; set; }

		public string Estatus { get; set; }

		public System.Nullable<int> TipoRnc { get; set; }
		public string TipoIdentificacion { get; set; }

		public string Rnc { get; set; }

		public string Supervisor { get; set; }

		public string Nombre { get; set; }

		public System.Nullable<System.DateTime> Fecha_Entrada { get; set; }

		public string FechaEntrada { get; set; }

		public System.Nullable<System.DateTime> Fec_Nac { get; set; }

		public string FechaNacimiento { get; set; }

		public string Direccion { get; set; }

		public string Telefono { get; set; }

		public string TelefonoOficina { get; set; }

		public string Celular { get; set; }

		public string LicenciaSeguro { get; set; }

		public System.Nullable<int> Oficina { get; set; }

		public string NombreOficina { get; set; }

		public string CtaBanco { get; set; }

		public string Banco { get; set; }

		public string TipoPago { get; set; }
	}
}

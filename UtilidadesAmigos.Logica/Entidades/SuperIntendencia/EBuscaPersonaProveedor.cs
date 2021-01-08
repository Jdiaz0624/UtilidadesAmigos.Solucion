using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.SuperIntendencia
{
    public class EBuscaPersonaProveedor
    {
		public int? Codigo { get; set; }

		public System.Nullable<int> TipoCliente0 { get; set; }

		public string TipoCliente { get; set; }

		public System.Nullable<byte> TipoRnc { get; set; }

		public string TipoIdentificacion { get; set; }

		public string Rnc { get; set; }

		public string NombreCliente { get; set; }

		public string Direccion { get; set; }

		public System.Nullable<System.DateTime> FechaAdiciona { get; set; }

		public string FechaCreado { get; set; }

		public string TelefonoCasa { get; set; }

		public string TelefonoOficina { get; set; }

		public string Celular { get; set; }

		public string CuentaBanco { get; set; }

		public System.Nullable<int> Banco { get; set; }

		public string TipoCuentaBanco { get; set; }

		public string ClaseProveedor { get; set; }

		public System.Nullable<System.DateTime> FechaUltPago0 { get; set; }

		public string FechaUltPago { get; set; }

		public System.Nullable<decimal> LimiteCredito { get; set; }
	}
}

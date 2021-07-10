using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscaDataCobradoDetalle
    {
		public string Poliza { get; set; }

		public decimal? Numero { get; set; }

		public string Concepto { get; set; }

		public string NumeroFormateado { get; set; }

		public string Anulado { get; set; }

		public System.Nullable<System.DateTime> Fecha { get; set; }

		public string FechaFormateada { get; set; }

		public string TipoPago { get; set; }

		public System.Nullable<decimal> CodigoCliente { get; set; }

		public string Cliente { get; set; }

		public System.Nullable<int> CodigoIntermediario { get; set; }

		public string Intermediario { get; set; }

		public System.Nullable<int> CodSupervisor { get; set; }

		public string NombreSupervisor { get; set; }

		public System.Nullable<int> CodigoOficina { get; set; }

		public string Oficina { get; set; }

		public string Usuario { get; set; }

		public System.Nullable<int> CodigoRamo { get; set; }

		public string Ramo { get; set; }

		public System.Nullable<int> CodMoneda { get; set; }

		public string Moneda { get; set; }

		public System.Nullable<decimal> Bruto { get; set; }

		public System.Nullable<decimal> Impuesto { get; set; }

		public System.Nullable<decimal> Neto { get; set; }

		public System.Nullable<decimal> Tasa { get; set; }

		public System.Nullable<decimal> MontoPesos { get; set; }

		public System.Nullable<int> CantidadRegistros { get; set; }

		public System.Nullable<decimal> TotalCobradoPesos { get; set; }

		public System.Nullable<decimal> TotalCobradoDolar { get; set; }
		public string UsuarioGenera { get; set; }

		public string ValidadoDesde { get; set; }

		public string ValidadoHasta { get; set; }
	}
}

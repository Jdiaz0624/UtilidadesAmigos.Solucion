using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EListadoRenovacion
    {
		public string Poliza { get; set; }

		public decimal? Cotizacion { get; set; }

		public string Estatus { get; set; }

		public System.Nullable<decimal> Prima { get; set; }

		public System.Nullable<decimal> SumaAsegurada { get; set; }

		public int? CodRamo { get; set; }

		public int? CodSubramo { get; set; }

		public string Ramo { get; set; }

		public string SubRamo { get; set; }

		public string Asegurado { get; set; }

		public string TelefonoResidencia { get; set; }

		public string Celular { get; set; }

		public string TelefonoOficina { get; set; }

		public System.Nullable<int> Items { get; set; }

		public System.Nullable<System.DateTime> InicioVigencia { get; set; }

		public System.Nullable<System.DateTime> FinVigencia { get; set; }

		public string InicioVigenciaFormateado { get; set; }

		public string FinVigenciaFormateado { get; set; }

		public int? Secuencia { get; set; }

		public string Supervisor { get; set; }

		public string Intermediario { get; set; }

		public int? CodSupervisor { get; set; }

		public int? CodIntermediario { get; set; }

		public string Oficina { get; set; }

		public System.Nullable<decimal> Facturado { get; set; }

		public System.Nullable<decimal> Cobrado { get; set; }

		public System.Nullable<decimal> Balance { get; set; }

		public string FechaDesde { get; set; }

		public string FechaHasta { get; set; }

		public System.Nullable<int> Dias { get; set; }

		public System.Nullable<int> Mes { get; set; }

		public System.Nullable<int> Anos { get; set; }

		public System.Nullable<int> CantidadComentarios { get; set; }
		public string Chasis { get; set; }
		public System.Nullable<int> CantidadReclamaciones { get; set; }

		public string UltimaReclamacion { get; set; }

		public string FechaUltimoComentario { get; set; }

		public string HoraUltimoComentario { get; set; }

		public string UltimoEstatusLlamada { get; set; }

		public string UltimoConceptollamada { get; set; }

		public string UltimoComentario { get; set; }

		public string UsuarioComento { get; set; }
	}
}

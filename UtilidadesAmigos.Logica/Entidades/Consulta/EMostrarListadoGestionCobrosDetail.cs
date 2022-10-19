using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EMostrarListadoGestionCobrosDetail
    {
		public string Poliza { get; set; }

		public decimal Factura { get; set; }

		public System.Nullable<System.DateTime> FechaInicioVigencia { get; set; }

		public string InicioVigencia { get; set; }

		public System.Nullable<System.DateTime> FechaFinVigencia { get; set; }

		public string FinVigencia { get; set; }

		public string FechaProceso { get; set; }

		public System.Nullable<decimal> ValorAnual { get; set; }

		public System.Nullable<decimal> ValorPorDia { get; set; }

		public System.Nullable<decimal> ValorPagado { get; set; }

		public System.Nullable<decimal> CantidadDiasAsegurado { get; set; }
		public string FechaUltimoPago { get; set; }

		public System.Nullable<decimal> MontoUltimoPago { get; set; }

		public string CoberturaHasta { get; set; }

		public System.Nullable<int> CantidadReclamaciones { get; set; }

		public string UltimaReclamacion { get; set; }

		public string FechaUltimoComentario { get; set; }

		public string Hora { get; set; }

		public string UltimoEstatusLlamada { get; set; }

		public string UltimoConceptoLlamada { get; set; }

		public string UltimoComentario { get; set; }

		public string Usuario { get; set; }

		public string Estatus { get; set; }

		public System.Nullable<decimal> SumaAsegurada { get; set; }

		public System.Nullable<decimal> Prima { get; set; }

		public System.Nullable<int> CodigoRamo { get; set; }

		public string Ramo { get; set; }

		public System.Nullable<decimal> Cliente { get; set; }

		public string Asegurado { get; set; }

		public string TelefonoResidencia { get; set; }

		public string Celular { get; set; }

		public string TelefonoOficina { get; set; }

		public int CodigoSupervisor { get; set; }

		public string Supervisor { get; set; }

		public System.Nullable<int> Codigointermediario { get; set; }

		public string Intermediario { get; set; }

		public System.Nullable<int> Oficina { get; set; }

		public string NombreOficina { get; set; }

		public System.Nullable<int> CantidadDias { get; set; }

		public System.Nullable<decimal> SA0_10 { get; set; }

		public System.Nullable<decimal> SA11_30 { get; set; }

		public System.Nullable<decimal> SA31_60 { get; set; }

		public System.Nullable<decimal> SA61_90 { get; set; }

		public System.Nullable<decimal> SA91_120 { get; set; }

		public System.Nullable<decimal> SA121_MAS { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.SuperIntendencia
{
    public class EBuscaPersonaAseurados
    {
		public string Nombre { get; set; }

		public int? Item { get; set; }

		public string Intermediario { get; set; }

		public string Licencia { get; set; }

		public string RNCIntermediario { get; set; }

		public string Poliza { get; set; }

		public string Estatus { get; set; }

		public System.Nullable<decimal> Prima { get; set; }

		public decimal Cotizacion { get; set; }

		public string InicioVigencia { get; set; }

		public string FinVigencia { get; set; }

		public string TipoVehiculo { get; set; }

		public string Marca { get; set; }

		public string Modelo { get; set; }

		public string Chasis { get; set; }

		public string Placa { get; set; }

		public string Ano { get; set; }

		public string Color { get; set; }

		public string MontoAsegurado { get; set; }
	}
}

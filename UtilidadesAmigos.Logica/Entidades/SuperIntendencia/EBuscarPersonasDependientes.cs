using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.SuperIntendencia
{
    public class EBuscarPersonasDependientes
    {
		public string Poliza { get; set; }

		public string Estatus { get; set; }

		public decimal? Cotizacion { get; set; }

		public int? Secuencia { get; set; }

		public int? IdAsegurado { get; set; }

		public string Nombre { get; set; }

		public string Parentezco { get; set; }

		public string RNC { get; set; }

		public string FechaNacimiento { get; set; }

		public string Sexo { get; set; }

		public string InicioVigencia { get; set; }

		public string FinVigencia { get; set; }
	}
}

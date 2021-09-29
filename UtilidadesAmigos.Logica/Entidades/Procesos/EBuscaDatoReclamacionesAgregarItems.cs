using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EBuscaDatoReclamacionesAgregarItems
    {
		public string Poliza { get; set; }

		public decimal? Reclamacion { get; set; }

		public int? Secuencia { get; set; }

		public int? IdTipoReclamacion { get; set; }

		public string TipoReclamacion { get; set; }

		public string IdReclamante { get; set; }

		public string Reclamante { get; set; }
	}
}

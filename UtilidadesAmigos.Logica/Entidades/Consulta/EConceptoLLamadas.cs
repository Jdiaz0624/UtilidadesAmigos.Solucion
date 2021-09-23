using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EConceptoLLamadas
    {
		public System.Nullable<int> IdConceptoLlamada { get; set; }

		public System.Nullable<int> IdEstatusLlamada { get; set; }

		public string EstatusLLamada { get; set; }

		public string ConceptoLLamada { get; set; }

		public System.Nullable<bool> Estatus0 { get; set; }

		public string Estatus { get; set; }

		public System.Nullable<bool> AplicaParaAviso0 { get; set; }

		public string AplicaParaAviso { get; set; }
	}
}

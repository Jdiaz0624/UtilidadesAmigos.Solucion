using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EComentariosProcesoClientesSinPoliza
    {
		public decimal? NumeroRegistro { get; set; }

		public System.Nullable<decimal> CodigoCliente { get; set; }

		public System.Nullable<decimal> IdUsuario { get; set; }

		public string Usuario { get; set; }

		public System.Nullable<System.DateTime> Fecha0 { get; set; }

		public string Fecha { get; set; }

		public string Hora { get; set; }

		public string Comentario { get; set; }
	}
}

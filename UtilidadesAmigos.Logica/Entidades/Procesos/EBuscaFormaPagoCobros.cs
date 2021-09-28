using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EBuscaFormaPagoCobros
    {
		public string Poliza { get; set; }

		public decimal? Numero_Recibo { get; set; }

		public System.Nullable<System.DateTime> Fecha_pago { get; set; }

		public string Fecha { get; set; }

		public string Tipo { get; set; }

		public System.Nullable<decimal> Monto { get; set; }
	}
}

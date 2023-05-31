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

        public System.Nullable<System.DateTime> FechaAdiciona { get; set; }

        public System.Nullable<System.DateTime> FechaModifica { get; set; }

        public System.Nullable<System.DateTime> FechaApertura { get; set; }
        public string Fecha { get; set; }

        public System.Nullable<System.DateTime> FechaSiniestro { get; set; }

        public System.Nullable<System.DateTime> FechaNotificacion { get; set; }

        public System.Nullable<System.DateTime> FechaCierre { get; set; }
    }
}

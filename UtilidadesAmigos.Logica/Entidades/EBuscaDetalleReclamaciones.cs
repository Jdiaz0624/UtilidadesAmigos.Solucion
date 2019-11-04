using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscaDetalleReclamaciones
    {
        public string Usuario { get; set; }

        public decimal Reclamacion { get; set; }
        public string Poliza { get; set; }
        public string Estatus { get; set; }

        public System.Nullable<decimal> Reclamado { get; set; }

        public System.Nullable<decimal> Pagado { get; set; }

        public string Apertura { get; set; }

        public string Siniestro { get; set; }
    }
}

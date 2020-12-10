using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscaReporteAgrupadoPorUsuario
    {
        public string Usuario { get; set; }

        public System.Nullable<decimal> Bruto { get; set; }

        public System.Nullable<decimal> Impuesto { get; set; }

        public System.Nullable<decimal> Neto { get; set; }

        public System.Nullable<decimal> Cobrado { get; set; }

        public string Moneda { get; set; }

        public System.Nullable<decimal> TasaUsada { get; set; }

        public System.Nullable<decimal> MontoPesos { get; set; }

        public string ValidadoDesde { get; set; }

        public string ValidadoHasta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarDetalleCobradoUsuario
    {
        public string Usuario { get; set; }

        public decimal? Numero { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public string Poliza { get; set; }

        public string Fecha { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> TotalPagado { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public string Concepto { get; set; }
        public System.Nullable<decimal> TotalPrima { get; set; }
    }
}

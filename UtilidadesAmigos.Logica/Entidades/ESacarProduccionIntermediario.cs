using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarProduccionIntermediario
    {
        public string Poliza { get; set; }

        public string NoFactura { get; set; }

        public string Fecha { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public string Cliente { get; set; }

        public string Vendedor { get; set; }

        public string Cobrador { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public string Ncf { get; set; }

        public System.Nullable<decimal> Tasa { get; set; }

        public string Moneda { get; set; }

        public string Oficina { get; set; }

        public System.Nullable<decimal> Total { get; set; }
    }
}

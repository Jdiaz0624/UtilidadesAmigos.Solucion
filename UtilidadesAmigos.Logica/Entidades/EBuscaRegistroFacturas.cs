using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscaRegistroFacturas
    {
        public string Poliza { get; set; }

        public decimal? Factura { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public string Vendedor { get; set; }

        public string Cliente { get; set; }

        public string Fecha { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public string Concepto { get; set; }
    }
}

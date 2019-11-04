using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscaDetallesCobros
    {
        public string Usuario { get; set; }

        public decimal NumeroPago { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public string Poliza { get; set; }

        public string Fecha { get; set; }

        public string Concepto { get; set; }
    }
}

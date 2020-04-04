using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EProduccionDiariaConsulta
    {
        public System.Nullable<int> CodRamo { get; set; }

        public string Ramo { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<int> Cantidad { get; set; }

        public string Moneda { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> PesosDominicanos { get; set; }

        public System.Nullable<decimal> TotalFacturado { get; set; }

        public System.Nullable<decimal> TotalPesosDominicanos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EProduccionDiariaDetalle
    {
        public string Ramo { get; set; }

        public string Subramo { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<int> Cantidad { get; set; }

        public System.Nullable<decimal> FacturadoPesos { get; set; }

        public System.Nullable<decimal> FacturadoDollar { get; set; }

        public System.Nullable<decimal> FacturadoTotal { get; set; }

        public System.Nullable<decimal> FacturadoNeto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EProduccionDiariaConsulta
    {
        public string Ramo { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<int> Total { get; set; }

        public System.Nullable<decimal> FacturadoPesos { get; set; }

        public System.Nullable<decimal> FacturadoDollar { get; set; }

        public System.Nullable<decimal> facturadoTotal { get; set; }

        public System.Nullable<decimal> FacturadoNeto { get; set; }

        public string ValidadoDesde { get; set; }

        public string ValidadoHasta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EComisionesSupervisores
    {
        public string Supervisor { get; set; }

        public string Intermediario { get; set; }

        public decimal Numero { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public string Oficina { get; set; }

        public string Fecha { get; set; }

        public string Concepto { get; set; }

        public System.Nullable<decimal> @__Comision { get; set; }

        public System.Nullable<decimal> ComisionPagar { get; set; }

        public string ValidadoDesde { get; set; }

        public string ValidadoHasta { get; set; }
    }
}

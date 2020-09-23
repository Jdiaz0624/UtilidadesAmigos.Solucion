using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EComisionesPorDefecto
    {
        public decimal? IdRegistro { get; set; }

        public System.Nullable<int> CodRamo { get; set; }

        public string Ramo { get; set; }

        public System.Nullable<int> CodSubramo { get; set; }

        public string Subramo { get; set; }

        public System.Nullable<decimal> PorcientoComision { get; set; }
    }
}

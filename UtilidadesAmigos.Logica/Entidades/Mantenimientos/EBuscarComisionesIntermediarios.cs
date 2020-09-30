using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EBuscarComisionesIntermediarios
    {
        public int? Codigo { get; set; }

        public string Intermediario { get; set; }

        public int? IdRamo { get; set; }

        public string Ramo { get; set; }

        public int? IdSubRamo { get; set; }

        public string Subramo { get; set; }

        public System.Nullable<decimal> PorcientoComision { get; set; }
    }
}

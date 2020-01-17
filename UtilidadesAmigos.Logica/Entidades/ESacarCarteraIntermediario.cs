using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class ESacarCarteraIntermediario
    {
        public string Supervisor { get; set; }

        public string Intermediario { get; set; }

        public int? CodigoSupervisor { get; set; }

        public int? CodigoIntermediario { get; set; }

        public string Poliza { get; set; }

        public string Estatus { get; set; }

        public string Ramo { get; set; }

        public string SubRamo { get; set; }

        public string Cliente { get; set; }
        public string Telefonos { get; set; }

        public System.Nullable<decimal> SumaAsegurada { get; set; }

        public System.Nullable<decimal> prima { get; set; }

        public System.Nullable<decimal> TotalFacturado { get; set; }

        public System.Nullable<decimal> TotalPagado { get; set; }

        public System.Nullable<decimal> Balance { get; set; }
    }
}

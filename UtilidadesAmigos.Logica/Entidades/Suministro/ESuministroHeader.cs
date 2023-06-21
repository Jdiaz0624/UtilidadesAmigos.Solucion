using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Suministro
{
    public class ESuministroHeader
    {
        public System.Nullable<decimal> NumeroSolicitud { get; set; }

        public string NumeroConector { get; set; }

        public System.Nullable<decimal> IdUsuario { get; set; }

        public System.Nullable<System.DateTime> FechaSolicitud { get; set; }

        public System.Nullable<int> EstatusSolicitud { get; set; }
    }
}

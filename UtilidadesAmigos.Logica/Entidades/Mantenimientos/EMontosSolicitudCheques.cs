using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EMontosSolicitudCheques
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public System.Nullable<int> CodigoIntermediario { get; set; }

        public System.Nullable<decimal> Bruto { get; set; }

        public System.Nullable<decimal> Neto { get; set; }

        public System.Nullable<decimal> Comision { get; set; }

        public System.Nullable<decimal> Retencion { get; set; }

        public System.Nullable<decimal> Avance { get; set; }

        public System.Nullable<decimal> ALiquidar { get; set; }
        public System.Nullable<decimal> Acumulado { get; set; }

        public System.Nullable<decimal> Total { get; set; }
    }
}
